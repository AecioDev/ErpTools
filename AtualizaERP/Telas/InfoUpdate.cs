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
using Ionic.Zip;

namespace AtualizaERP.Telas
{
    public partial class InfoUpdate : Form
    {
        //Acessa ao Banco e Verifica se tem conexões aberta no Banco.
        AcessoDados dados = new AcessoDados();

        private int Tipo = 0;
        private string IdConex = "";
        private string PathArq = "";
        public string arqBaixado = "";

        public InfoUpdate(int _tipo, string _idconex, string _patharq)
        {
            Tipo = _tipo;
            IdConex = _idconex;
            PathArq = _patharq;
            InitializeComponent();
        }

        private void bt_Atualizar_Click(object sender, EventArgs e) //Atualizar Agora.
        {            
            string urlArq = @"http://www.controllernet.com.br/controllernovo/download/Arquivos/";

            try
            {
                //Primeiro verifica se os arquivos para a atualização já foi baixado.            
                if (!File.Exists(PathArq)) //Se não existe, tenta fazer o download.
                {
                    FileInfo file = new FileInfo(PathArq);

                    urlArq = urlArq + file.Name;
                    DownloadERP downERP = new DownloadERP(urlArq, file.DirectoryName, file.Name, "T");
                    downERP.ShowDialog();
                }

                if (File.Exists(PathArq)) //Se existe, executa a atualização
                {
                    if (Tipo == 0) //Atualização Completa - Download dos Executáveis - Backup do Banco de Dados - Atualização do Banco de Dados
                    {
                        var acessos = dados.ConsAcessos(IdConex);

                        if (acessos.Count() > 0)
                        {
                            //Chama form para mostrar as conexões em aberto
                            this.Hide();
                            ListaConexoes verCon = new ListaConexoes(IdConex);
                            verCon.ShowDialog();
                            this.Show();

                            acessos = dados.ConsAcessos(IdConex);

                            if (acessos.Count() > 0)
                            {
                                MessageBox.Show("Favor Finalizar Todas as Conexões do Controller ERP com o Banco de Dados antes de continuar a Atualização.", "Controller ERP");
                                this.Close();
                            }
                        }

                        if (acessos.Count() == 0) //Se não tiver ninguém mais conectado no banco de dados, realiza o backup.
                        {
                            //1 - Coloca o Banco de Dados Como usuário único.

                            //2 - Roda a Rotina de Backup

                            //3 - Executa o Atualizador (Extrai os arquivos)

                            //4 - Roda a Rotina de Atualização do banco de Dados

                            //5 - Atualiza os Relatórios Crystal

                            //6 - Finaliza a Atualização.
                        }
                    }

                    if (Tipo == 1) //Atualização de Executáveis na Estação - Faz o Download e Instala.
                    {
                        //1 - Executa o Atualizador (Extrai os arquivos)
                        //MessageBox.Show("Extrai o Arquivo", "Controller ERP");
                        //Extrair(PathArq);
                        var pid = System.Diagnostics.Process.Start(PathArq);

                        while (!pid.HasExited) //Enquanto mão fechar o atualizador aguarda...
                            ;

                        pid.Close();
                        //Abre o Controller e fecha o atualizador.
                        System.Diagnostics.Process.Start(@"C:\Controller\UCTRMENU.EXE");

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("O Arquivo de Atualização não foi Encontrado. Você pode tentar novamente ou realizar o agendamento com o Suporte para realizar a Atualização.", "Controller ERP");
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocorreram erros ao executar a Atualização!!!\n"+ex.Message, "Controller ERP");
                File.Delete(PathArq);
            }
        }

        private void bt_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bt_Lembrar_Click(object sender, EventArgs e)
        {
            progressBar.Style = ProgressBarStyle.Continuous;
            for (int i = 0; i <= 100; i++)
            {
                progressBar.Value = i;
            }
        }

        private void Extrair(string ArqComp)
        {
            string arqZip = ArqComp.Replace(".exe", ".zip");
            try
            {
                FileInfo file = new FileInfo(ArqComp);
                file.CopyTo(arqZip);

                if (File.Exists(arqZip))
                {
                    using (ZipFile zip = ZipFile.Read(arqZip))
                    {
                        zip.ExtractAll(arqZip.Replace(".zip", ""), ExtractExistingFileAction.OverwriteSilently);
                        zip.SaveProgress += (o, args) =>
                        {   
                            var percentage = (int)(1.0d / args.TotalBytesToTransfer * args.BytesTransferred * 100.0d);
                            progressBar.Value = percentage;
                        };                        
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas ao realizar o Backup!!!\n" + ex.Message, "Controller ERP");
            }

        }
    }
}
