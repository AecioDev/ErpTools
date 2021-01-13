﻿using AtualizaERP.Classes;
using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace AtualizaERP.Telas
{
    public partial class GeraPlanilha : Form
    {
        private int CodCenCus;
        private int Metodo;
        private string Parametros;
        private string PatchXML;
        private string IdConex;
        private string PastaUser;
        private string ArqExcel;
        private bool GeraCab;

        //Planejamento ORçamentário
        private string AgrpCus;
        private int NumMeses;


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

            var DadosParam = Parametros.Split('|');
            if (!string.IsNullOrEmpty(DadosParam[0].ToString()))
                CodCenCus = Convert.ToInt32(DadosParam[0].ToString());

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

                case 20: //MAN-2368: Consulta de Notas
                    lb_Cab.Text = "Planejamento Orçamentário";
                    ArqExcel = @"\PlanOrc.xlsx";
                    tb_PatchPadrao.Text = PastaUser + @"\Controller" + ArqExcel;

                    AgrpCus = DadosParam[1].ToString();
                    if (!string.IsNullOrEmpty(DadosParam[2].ToString()))
                        NumMeses = Convert.ToInt32(DadosParam[2].ToString());



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
            switch (Metodo)
            {
                case 1: //MAN-2164: Consulta de Titulos a Receber

                    GridTitulos titulosR = new GridTitulos();
                    titulosR.ArqExcel = tb_PatchPadrao.Text;
                    titulosR.CodCenCus = CodCenCus;
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
                    titulosP.CodCenCus = CodCenCus;
                    titulosP.GeraCab = GeraCab;
                    titulosP.IDConex = IdConex;
                    titulosP.PastaUser = PastaUser;
                    titulosP.PatchXml = PatchXML;
                    titulosP.tipRel = "A";
                    titulosP.NomeRelat = "Grid Consulta de Títulos a Pagar";

                    titulosP.GeraPlanilha();
                    break;

                case 3: //MAN-2368: Consulta de Notas

                    GridNotas notas = new GridNotas();
                    notas.ArqExcel = tb_PatchPadrao.Text;
                    notas.CodCenCus = CodCenCus;
                    notas.GeraCab = GeraCab;
                    notas.IDConex = IdConex;
                    notas.PastaUser = PastaUser;
                    notas.PatchXml = PatchXML;
                    notas.NomeRelat = "Grid Consulta de Notas";

                    notas.GeraPlanilha();

                    break;
            }
            
            //Verifica se Pode Abrir a Planilha.
            try
            {
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkBook;  // = new Excel.Workbook();
                Excel.Worksheet xlWorkSheet = new Excel.Worksheet();

                xlWorkBook = xlApp.Workbooks.Open(tb_PatchPadrao.Text);
                xlApp.Visible = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Não foi possível abrir a planilha Automáticamente!!! Deseja ver o Arquivo na Pasta?", "Controller ERP");
            }
        }
    }
}
