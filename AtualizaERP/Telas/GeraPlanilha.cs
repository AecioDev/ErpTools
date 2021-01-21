using AtualizaERP.Classes;
using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace AtualizaERP.Telas
{
    public partial class GeraPlanilha : Form
    {
        private int Metodo;
        private string Parametros;
        private string PatchXML;
        private string IdConex;
        private string PastaUser;
        private string ArqExcel;
        private bool GeraCab;
        private int tempo = 5;

        public GeraPlanilha(int _metodo, string _parametros, string _patchXML, string _idConex)
        {
            Metodo = _metodo;
            Parametros = _parametros;
            PatchXML = _patchXML;
            IdConex = _idConex;

            InitializeComponent();
        }

        private void GeraPlanilha_Load(object sender, EventArgs e)
        {
            PastaUser = Environment.GetEnvironmentVariable("USERPROFILE");
            cb_GeraCab.SelectedIndex = 0; //Sem cabeçalho
            //notifyIcon1.BalloonTipClicked -= notifyIcon1_BalloonTipClicked;
            timer1.Enabled = false;

            switch (Metodo)
            {
                case 1: //MAN-2164: Consulta de Titulos a Receber
                    lb_Cab.Text = "Planilha da Consulta de Títulos à Receber";
                    ArqExcel = @"\GridTitulosReceber.xlsx";
                    tb_PatchPadrao.Text = PastaUser + @"\Controller" + ArqExcel;
                    break;

                case 2: //MAN-2164: Consulta de Titulos a Pagar
                    lb_Cab.Text = "Planilha da Consulta de Títulos à Pagar";
                    ArqExcel = @"\GridTitulosPagar.xlsx";
                    tb_PatchPadrao.Text = PastaUser + @"\Controller" + ArqExcel;
                    break;

                case 3: //MAN-2368: Consulta de Notas
                    lb_Cab.Text = "Planilha da Grid de Notas";
                    ArqExcel = @"\GridNotas.xlsx";
                    tb_PatchPadrao.Text = PastaUser + @"\Controller" + ArqExcel;

                    break;

                case 10: //Planejamento Orçamentário
                    lb_Cab.Text = "Planejamento Orçamentário";
                    ArqExcel = @"\PlanOrc.xlsx";
                    tb_PatchPadrao.Text = PastaUser + @"\Controller" + ArqExcel;
                    
                    break;
            }
        }

        private void bt_salvar_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog pastaArq = new FolderBrowserDialog();
            pastaArq.SelectedPath = (PastaUser);

            if (pastaArq.ShowDialog() == DialogResult.OK)
            {
                tb_PatchPadrao.Text = pastaArq.SelectedPath + ArqExcel;
            }
        }

        private void cb_GeraCab_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_GeraCab.SelectedIndex == 0)
                GeraCab = false;
            else
                GeraCab = true;
        }

        private void bt_GerarPlanilha_Click(object sender, EventArgs e)
        {
            pg_Progresso.Visible = true;
            lb_progress.Visible = true;

            pg_Progresso.Value = 50;

            switch (Metodo)
            {
                case 1: //MAN-2164: Consulta de Titulos a Receber

                    GridTitulos titulosR = new GridTitulos();
                    titulosR.ArqExcel = tb_PatchPadrao.Text;
                    titulosR.GeraCab = GeraCab;
                    titulosR.IDConex = IdConex;
                    titulosR.PastaUser = PastaUser;
                    titulosR.PatchXml = PatchXML;
                    titulosR.tipRel = "R";
                    titulosR.NomeRelat = "Grid Consulta de Títulos a Receber";

                    titulosR.GeraPlanilha();
                    break;

                case 2: //MAN-2164: Consulta de Titulos a Pagar
                    GridTitulos titulosP = new GridTitulos();
                    titulosP.ArqExcel = tb_PatchPadrao.Text;
                    titulosP.GeraCab = GeraCab;
                    titulosP.IDConex = IdConex;
                    titulosP.PastaUser = PastaUser;
                    titulosP.PatchXml = PatchXML;
                    titulosP.tipRel = "P";
                    titulosP.NomeRelat = "Grid Consulta de Títulos a Pagar";

                    titulosP.GeraPlanilha();
                    break;

                case 3: //MAN-2368: Consulta de Notas

                    GridNotas notas = new GridNotas();
                    notas.ArqExcel = tb_PatchPadrao.Text;
                    notas.GeraCab = GeraCab;
                    notas.IDConex = IdConex;
                    notas.PastaUser = PastaUser;
                    notas.PatchXml = PatchXML;
                    notas.NomeRelat = "Grid Consulta de Notas";

                    notas.GeraPlanilha();
                    break;

                case 10: //Planejamento Orçamentário

                    PlanOrcamentario planejamento = new PlanOrcamentario(Parametros, this);
                    planejamento.ArqExcel = tb_PatchPadrao.Text;
                    planejamento.GeraCab = GeraCab;
                    planejamento.IDConex = IdConex;
                    planejamento.PastaUser = PastaUser;
                    planejamento.PatchXml = PatchXML;
                    planejamento.NomeRelat = "Planejamento Orçamentário";


                    planejamento.GeraPlanilha();
                    break;

            }

            pg_Progresso.Value = 99;

            //Verifica se Pode Abrir a Planilha.
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook;  // = new Excel.Workbook();
                Excel.Worksheet xlWorkSheet = new Excel.Worksheet();

                xlWorkBook = xlApp.Workbooks.Open(tb_PatchPadrao.Text);
                xlApp.Visible = true;

                timer1.Enabled = true; //Habilita o timer
                lb_timer.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível abrir a Planilha Automaticamente!!! Deseja ver o Arquivo na Pasta?", "Controller ERP");
                if (MessageBox.Show("Não foi possível abrir a Planilha Automaticamente!!! Deseja ver o Arquivo na Pasta?", "Controller ERP", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string cmd = "explorer.exe";
                    string arg = "/select, " + tb_PatchPadrao.Text;
                    System.Diagnostics.Process.Start(cmd, arg);
                }

            }

            
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lb_timer.Text = "Fechando em: " + tempo;
            if (tempo == 0)
            {
                this.Close();
            }

            tempo--;
        }

        private void bt_fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}