using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;
using AtualizaERP.Classes;

namespace AtualizaERP.Telas
{
    public partial class DownloadERP : Form
    {
        private string UrlDown = "";
        private string LocalDown = "";
        private string ArqExe = "";
        private string OpTela = "";      
        private string ArqDown = "";
        private int tempo = 0;
        private bool ArqOK = false; 
        AcessoDados dados = new AcessoDados();
        private string erro = "";
        
        public DownloadERP(string url, string local, string arqexe, string optela)
        {
            this.UrlDown = url;
            this.LocalDown = local;
            this.ArqExe = arqexe;
            this.OpTela = optela;
            InitializeComponent();
        }
        
        private void DownloadERP_Load(object sender, EventArgs e)
        {
            ArqDown = LocalDown + "\\" + ArqExe;

            try
            {
                if (!File.Exists(ArqDown))
                {
                    if (OpTela != "T")
                    {
                        SisTray();
                        notifyIcon1.BalloonTipClicked -= notifyIcon1_BalloonTipClicked;
                    }

                    if (!Directory.Exists(LocalDown))
                    {
                        Directory.CreateDirectory(LocalDown);
                    }

                    WebClient webClient = new WebClient();
                    webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completo);
                    webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressoFeito);
                    webClient.DownloadFileAsync(new Uri(UrlDown), ArqDown);
                }
                else
                {
                    if (OpTela != "T") //Balão
                    {
                        lb_Info.Text = "O Arquivo já Foi Baixado";
                        lb_Info.Visible = true;
                        //bt_Abrir.Visible = true;
                        bt_Fechar.Visible = true;
                        timer1.Enabled = true;
                        ArqOK = true;
                    }
                    else
                    {
                        lb_Info.Text = "O Arquivo já Foi Baixado";
                        lb_Info.Visible = true;
                        //bt_Abrir.Visible = true;
                        bt_Fechar.Visible = true;
                        ArqOK = true;
                    }
                }
            }
            catch (Exception ex)
            {
                erro = ex.Message;
                MessageBox.Show("Erro: " + erro);
            }
        }
                
        private void ProgressoFeito(object sender, DownloadProgressChangedEventArgs e)
        {
            lb_Progress.Text = e.ProgressPercentage.ToString() + "%";
            progressBar.Value = e.ProgressPercentage;
            notifyIcon1.Text = "Baixando Atualização " + e.ProgressPercentage + "%";
            if (OpTela != "T" && (e.ProgressPercentage == 25 || e.ProgressPercentage == 50 || e.ProgressPercentage == 75))
            {
                notifyIcon1.BalloonTipTitle = "Baixando Atualização " + e.ProgressPercentage + "%";
                notifyIcon1.BalloonTipText = "Controller ERP";
                notifyIcon1.ShowBalloonTip(100);
            }
        }

        private void Completo(object sender, AsyncCompletedEventArgs e)
        {
            lb_Info.Visible = true;
            //bt_Abrir.Visible = true;
            bt_Fechar.Visible = true;
            //infoUpdate.arqBaixado = "S";

            if (OpTela != "T") //Ao Terminar habilita o timer pra mostrar a Notificação a cada 60 segundos
                timer1.Enabled = true;

            ArqOK = true;
        }

        private void bt_Abrir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ArqDown);
            this.Close();
        }

        private void bt_Fechar_Click(object sender, EventArgs e)
        {

            if (ArqOK)
            {
                //dados.GravaFim("Abrir Arquivo");
                if (MessageBox.Show("Deseja ver o Arquivo Agora?", "Controller ERP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //OpenFileDialog abreArq = new OpenFileDialog();
                    //abreArq.InitialDirectory = LocalDown;
                    //abreArq.Filter = "Arquivo Padrão (" + ArqExe + ")|" + ArqExe;
                    //abreArq.ShowDialog();

                    string cmd = "explorer.exe";
                    string arg = "/select, " + ArqDown;
                    System.Diagnostics.Process.Start(cmd, arg);
                }
            }
            else
                dados.GravaFim("Erro: \n" + erro);

            this.Close();
        }

        private void SisTray()
        {           
            notifyIcon1.Visible = true;

            //Aqui encondemos o form
            this.Hide();

            // Aqui escondemos o form da taskbar...
            this.ShowInTaskbar = false;

            // O valor que passamos neste método indica o tempo que o balão vai aparecer.
            // 0 (zero) no caso, significa que mostraremos o balão até que o usuário o feche...
            notifyIcon1.ShowBalloonTip(0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tempo == 0)
            {
                notifyIcon1.BalloonTipTitle = "Download Concluído!";
                notifyIcon1.BalloonTipText = "Clique aqui para mais Opções";
                notifyIcon1.ShowBalloonTip(3000);
                tempo = 60;
                notifyIcon1.BalloonTipClicked += notifyIcon1_BalloonTipClicked;
            }

            tempo--;
        }

        private void notifyIcon1_BalloonTipClicked(object sender, EventArgs e)
        {
            this.Close();
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
        }
        
        private void bt_fecha_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
            this.Hide();
        }
    }
}
