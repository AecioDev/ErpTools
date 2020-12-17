using System;
using System.ComponentModel;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace AtualizaERP.Telas
{
    public partial class DownloadERP : Form
    {
        private string UrlDown = "";
        private string LocalDown = "";
        private string ArqExe = "";
        string ArqDown = "";

        public DownloadERP(string url, string local, string arqexe)
        {
            InitializeComponent();
            this.UrlDown = url;
            this.LocalDown = local;
            this.ArqExe = arqexe;
        }

        private void DownloadERP_Load(object sender, EventArgs e)
        {
            ArqDown = LocalDown + "\\" + ArqExe;

            try
            {
                if (!Directory.Exists(LocalDown))
                {
                    Directory.CreateDirectory(LocalDown);
                }

                WebClient webClient = new WebClient();
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completo);
                webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressoFeito);
                webClient.DownloadFileAsync(new Uri(UrlDown), ArqDown);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }
                
        private void ProgressoFeito(object sender, DownloadProgressChangedEventArgs e)
        {
            lb_Progress.Text = e.ProgressPercentage.ToString() + "%";
            progressBar.Value = e.ProgressPercentage;
        }

        private void Completo(object sender, AsyncCompletedEventArgs e)
        {
            lb_Info.Visible = true;
            bt_Abrir.Visible = true;
            bt_Fechar.Visible = true;
        }

        private void bt_Abrir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(ArqDown);
            this.Close();
        }

        private void bt_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
