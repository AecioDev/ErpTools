using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AtualizaERP.Classes;

namespace AtualizaERP.Telas
{
    public partial class Home : Form
    {
        private int VersaoCli = 0;
        private string DocCliente = "";
        private string IDConex = "";
        private string UrlAtualizador = "";
        private int Opcao = 0;
        private int time = 2;

        AcessoDados dados;
        WSVersoesERP.VersoesERP dadosws;

        public Home(string _versaoCli, string _docCliente, string _IDConex, string _opcao, string _urlatualiza)
        {
            if (!string.IsNullOrEmpty(_versaoCli))
                this.VersaoCli = Convert.ToInt32(_versaoCli);
                        
            if (!string.IsNullOrEmpty(_opcao))
                this.Opcao = Convert.ToInt32(_opcao);

            this.IDConex = _IDConex;
            this.DocCliente = _docCliente;
            this.UrlAtualizador = _urlatualiza;

            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            #region Validação e Cadastro do Cliente no banco de Controle de Versão
            ConexaoERP ConnERP = new ConexaoERP();
            dadosws = new WSVersoesERP.VersoesERP();                        
            dados = new AcessoDados();
            string retorno = "";

            dados.GravaErro("VersaoCli: " + VersaoCli.ToString() + " DocCliente: " + DocCliente + " IDConex: " + IDConex + " UrlAtualizador: " + UrlAtualizador + " Opcao: " + Opcao.ToString());
           //Primeiro Valida se o cliente já está Cadastrado no Banco de Dados de Atualização se não estiver faz o cadastro.
            var cli = dadosws.GetCliente(DocCliente);  //dados.BuscaCli(DocCliente);
            

            if (cli.ClienteId == 0) //Se não achou o cliente Faz o Cadastro dele.
            {
                //Cadastra os Dados do Cliente.
                //1 - Obtem os dados de Acesso ao Banco de Dados via Arquivo de Conexão do ERP.
                ConnERP = dados.LeConfTXT(IDConex);
                if (ConnERP.ConexaoId > 0)
                {
                    //2 - Acessa o Banco de Dados do ERP e Obtem os dados do Cliente pra Gravar
                    var CliERP = dados.DadosCliERP(IDConex);

                    //3 - Grava os Dados do Cliente no Banco do Controle de Versões
                    retorno = dadosws.CadCliente(CliERP, 0); //dados.CadCliente(CliERP, 0); //Cadastra o Cliente

                    if (retorno == "OK") //Gravou o cliente com sucesso.
                        tb_info.Text = "Cliente Cadastrado com Sucesso!!!";
                    else
                        MessageBox.Show("Ocorreram Erros ao Cadastrar o Cliente: \n" + retorno, "Controller ERP");
                }
                else
                {
                    tb_info.Text = "Arquivo da Conexão código: " + IDConex + ", não foi encontrado!!!";
                }                        
            }
            #endregion  
            
            switch (Opcao)
            {
                case 0: //A versão do Executável é maior que a versão interna do Banco de Dados - Necessára a Atualização Completa (Banco e EXEs)

                    tb_info.Text = "";
                    InfoUpdate infUpd = new InfoUpdate(0, IDConex, UrlAtualizador);
                    infUpd.ShowDialog();
                    break;

                case 1: //A versão do Executável é MENOR que a versão interna do BD? - Necessária apenas baixar os Executáveis e Atualizar a Estação de Trabalho.
                    tb_info.Text = "";
                    InfoUpdate infUpd2 = new InfoUpdate(1, IDConex, UrlAtualizador);
                    infUpd2.ShowDialog();
                    break;
            }

            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            if (time <= 0)
                timer1.Enabled = false;
        }

        private void AtualizaERPSingle() //Apenas Baixa os Arquivos e Executa sem atualização e Banco de Dados.
        {
            string urlVersao = "";
            string patchDownload = @"C:\Controller\Atualizacao";
            string arqexe = "";
            dados = new AcessoDados();

            var versoes = dados.ConsVersao(0, 0);

            foreach (VersaoModel ver in versoes)
            {
                urlVersao = ver.URLVersao;
                arqexe = "ControllerERP_" + ver.CodVersao + ".exe";
            }

            DownloadERP down = new DownloadERP(urlVersao, patchDownload, arqexe, "T");
            down.ShowDialog();
        
        }        
    }
}
