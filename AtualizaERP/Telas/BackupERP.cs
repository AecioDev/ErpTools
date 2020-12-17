using System;
using System.Windows.Forms;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;
using System.IO;
using Ionic.Zip;

namespace AtualizaERP.Telas
{
    public partial class BackupERP : Form
    {
        private string BancoDados = "";
        private string Servidor = "";
        private string Usuario = "";
        private string Senha = "";
        private string PastaBackup = "";
        private string PastaDestino = "";
        private string TipoFuncao = "";

        private string ArqBackup = "";
        private bool Finalizado = false;
        private bool BakResult;
        private int IniciaBackup = 0;
        private int FimBackup = 101;

        public BackupERP(string _tipo, string _databaseName, string _userName, string _password, string _serverName, string _patchBackup, string _destinationPath)
        {
            InitializeComponent();
            this.TipoFuncao = _tipo;
            this.BancoDados = _databaseName;
            this.Usuario = _userName;
            this.Senha = _password;
            this.Servidor = _serverName;
            this.PastaBackup = _patchBackup;
            this.PastaDestino = _destinationPath; //Destino do Backup ou Arquivo de Backup

            if (_tipo == "B")
            {
                ArqBackup = @"\Backup_" + BancoDados + "_" + DateTime.Now.ToString();
                ArqBackup = ArqBackup.Replace("/", "").Replace(" ", "").Replace(":", "");
            }
            else
            {
                ArqBackup = _patchBackup + @"\" + _destinationPath;
            }
        }
        
        private void BackupERP_Load(object sender, EventArgs e)
        {
            if (TipoFuncao == "B") //Backup
                lb_Cab.Text = "Backup Banco de Dados";
            else
                lb_Cab.Text = "Restaura Banco de Dados";

        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IniciaBackup == 5 && !Finalizado)
            {
                if (TipoFuncao == "B")
                {
                    BakResult = BackupDatabase(); //Faz Backup

                    if (BakResult) //Backup finalizado com sucesso Compacta o Arquivo!!!
                        CompactaBackup();

                    FimBackup = 5;
                }
                else
                {
                    FileInfo arq = new FileInfo(ArqBackup); //Caminho completo do arquivo
                    if (arq.Exists)
                    {
                        if (arq.Extension == ".BAK")
                        {
                            BakResult = RestoreDatabase();  //Restaura Backup
                            FimBackup = 5;
                        }
                        else
                        {
                            timer1.Tick -= timer1_Tick;
                            MessageBox.Show("O Arquivo de Backup deve ter a extensão \".BAK\"!!!\n\n", "Controller ERP", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FimBackup = -1;
                        }
                    }
                    else
                    {
                        timer1.Tick -= timer1_Tick;
                        MessageBox.Show("O Arquivo de Backup: " + PastaDestino + " informado não foi encontrado na Pasta: " + PastaBackup, "Controller ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        FimBackup = -1;
                    }
                }                
            }
            else
            {
                switch(FimBackup)
                {
                    case 101:
                        //N faz nada apenas espera 1 segundo
                        FimBackup--;
                        break;
                    case 100:
                        lb_carregando.Text = "Realizando Conexão...";
                        FimBackup--;
                        break;
                    case 99:
                        lb_carregando.Text = "Carregando Informações do Banco de Dados...";
                        FimBackup--;
                        break;
                    case 98:
                        if(TipoFuncao == "B") //Backup
                            lb_carregando.Text = "Preparando Backup...";
                        else
                            lb_carregando.Text = "Preparando Restore BD...";
                        FimBackup--;
                        break;
                    case 97:
                        lb_carregando.Text = "";
                        if (TipoFuncao == "B") //Backup
                            lb_Encerrar.Text = "Realizando Backup...";
                        else
                            lb_Encerrar.Text = "Restaurando BD...";
                        break;
                }
            }

            if (Finalizado && FimBackup <= 5)
            {                                                    
                lb_Encerrar.Text = "Encerrando em: " + FimBackup.ToString() + "'s";
                FimBackup--;
            }
            else
            {
                if(BakResult == false && FimBackup == 5)
                    Application.Exit();
            }

            if (FimBackup < 0)
                Application.Exit();

            IniciaBackup++;
        }
                
        public bool BackupDatabase()
        {
            string ArquivoDest = "";
            string ArqTemp = "";
            //string Arquivo = "";
            
            timer1.Tick -= timer1_Tick;
            try
            {
                Backup sqlBackup = new Backup();
                sqlBackup.Action = BackupActionType.Database;
                sqlBackup.Database = BancoDados;

                ArqTemp = PastaBackup + @"\" + ArqBackup + ".BAK";

                BackupDeviceItem deviceItem = new BackupDeviceItem(ArqTemp, DeviceType.File);
                ServerConnection connection = new ServerConnection(Servidor, Usuario, Senha);
                Server sqlServer = new Server(connection);
                Database db = sqlServer.Databases[BancoDados];

                //ArqTemp = PastaBackup + @"\" + Arquivo;
                
                sqlBackup.Initialize = true;
                sqlBackup.Checksum = true;
                sqlBackup.ContinueAfterError = false;
                sqlBackup.Devices.Add(deviceItem);
                sqlBackup.Incremental = false;
                //sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);
                sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;
                sqlBackup.FormatMedia = false;
                sqlBackup.Complete += new ServerMessageEventHandler(sqlRestore_Complete);
                
                // AQUI VC SETA O VALOR PARA 1;
                sqlBackup.PercentCompleteNotification = 1;

                sqlBackup.PercentComplete += new PercentCompleteEventHandler(sqlRestore_PercentComplete);
                sqlBackup.SqlBackup(sqlServer);
                                
                ArquivoDest = PastaDestino + ArqBackup + ".BAK";

                FileInfo arq = new FileInfo(ArqTemp);
                arq.CopyTo(ArquivoDest, true);
                arq.Delete();
                lb_carregando.Text = "";

                timer1.Tick += timer1_Tick;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreram problemas ao realizar o Backup!!!\n\n" + ex.InnerException.Message + "\n" + ex.Message, "Controller ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }            
        }
        
        public bool RestoreDatabase()
        {
            timer1.Tick -= timer1_Tick;
            try
            {
                Restore sqlRestore = new Restore();
                sqlRestore.Action = RestoreActionType.Database;
                sqlRestore.Database = BancoDados;                
                BackupDeviceItem deviceItem = new BackupDeviceItem(ArqBackup, DeviceType.File);

                ServerConnection connection = new ServerConnection(Servidor, Usuario, Senha);
                Server sqlServer = new Server(connection);
                Database db = sqlServer.Databases[BancoDados];

                sqlRestore.Devices.Add(deviceItem);
                sqlRestore.ReplaceDatabase = true;

                sqlRestore.Complete += new ServerMessageEventHandler(sqlRestore_Complete);

                // AQUI VC SETA O VALOR PARA 1;
                sqlRestore.PercentCompleteNotification = 1;

                sqlRestore.PercentComplete += new PercentCompleteEventHandler(sqlRestore_PercentComplete);
                sqlRestore.SqlRestore(sqlServer);
                
                timer1.Tick += timer1_Tick;
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreram problemas ao Restaurar o Backup!!!\n\n" + ex.InnerException.Message + "\n" + ex.Message, "Controller ERP", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void sqlRestore_PercentComplete(object sender, PercentCompleteEventArgs e)
        {
            // E A CADA PORCENTO QUE O COMANDO SqlBackup DEVOLVER, VOCÊ CARREGA SUA VARIAVEL!
            // AQUI MANDEI UMA MENSAGEM PARA VOCÊ ENTENDER!!!
            //MessageBox.Show(e.Percent.ToString());

            //PercLabel = e.Percent - 10;
            lb_Progress.Refresh();
            lb_Progress.Text = e.Percent.ToString() + "%";
            progressBar.Value = e.Percent;

        }

        void sqlRestore_Complete(object sender, ServerMessageEventArgs e)
        {
            if (TipoFuncao == "B")
            {
                lb_carregando.Text = "Transferindo o Arquivo para a Pasta Solicitada...";
                lb_Info.Text = "Backup Finalizado!!!";
            }
            else
            {
                lb_Info.Text = "Restauração Finalizada!!!";
                lb_carregando.Text = "Restauração realizada com Sucesso!!!";
            }

            lb_Info.Visible = true;
            lb_Info.Refresh();
            lb_carregando.Refresh();
            bt_Fechar.Visible = true;
            Finalizado = true;
        }
        
        private void CompactaBackup()
        {
            string ArquivoBak = PastaDestino + ArqBackup + ".BAK";
            string ArquivoZip = PastaDestino + ArqBackup + ".ZIP";

            timer1.Tick -= timer1_Tick;

            lb_Encerrar.Text = "Compactando Aguarde...";
            lb_Encerrar.Refresh();
            FimBackup = 5;

            try
            {
                using (ZipFile zip = new ZipFile())
                {

                    // se o item é um arquivo
                    if (File.Exists(ArquivoBak))
                    {
                        zip.AddFile(ArquivoBak, ""); // Adiciona o arquivo na pasta raiz dentro do arquivo zip

                        // Salva o arquivo zip para o destino
                        zip.Save(ArquivoZip);
                    }
                }

                if (File.Exists(ArquivoZip))
                {
                    File.Delete(ArquivoBak);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problemas ao realizar o Backup!!!\n" + ex.Message, "Controller ERP");
            }

            timer1.Tick += timer1_Tick;
        }
                
        private void bt_Fechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
