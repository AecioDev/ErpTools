using AtualizaERP.Telas;
using System;
using System.Linq;
using System.Windows.Forms;
using AtualizaERP.Classes;

namespace AtualizaERP
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            string[] argumentos = args;
            string entrada = "";

            //string[] argumentos = {"Download", "http://www.controllernet.com.br/controllernovo/download/Arquivos/Controller042501002_10052018.exe", @"C:\Temp\Controller042501002_10052018.exe" };

            //string[] argumentos = {"Backup", "B", "AECIO_TESTE", "SA", "CONTROLLER.4000", "SRVDEV00", @"\\SRVDEV00\Backup\TESTE_ERP", @"C:\temp\TesteBD" };

            //string[] argumentos = { "Backup", "R", "AECIO_TESTE", "SA", "CONTROLLER.4000", "SRVDEV00", @"\\SRVDEV00\Backup\TESTE_ERP", @"C:\temp\TesteBD" };

            //string[] argumentos = { "Versao", "128", "520190100", "5.2019.01.00", "08/03/2019", "", "", "", "0" };

            //string[] argumentos = { "Home", "42705001", "17.236.676/0001-81", "002", "0" };

            //string[] argumentos = { "Atualiza", "C"};

            int qntParms = argumentos.Count();
            for(int i = 0; i < qntParms; i++)
            {
                entrada += "Arg" + i + ": " + argumentos[i] + "\n";
            }

            AcessoDados db = new AcessoDados();
            db.GravaErro(entrada);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            switch(argumentos[0])
            {
                case "Atualiza": //Argumentos - 1:VersaoCli; 2:VersaoAtual; 3:IDConexao; 4:Opção
                    //Application.Run(new InfoUpdate(argumentos[1]));
                    break;
                case "Home": //Argumentos - 1:VersaoCli;   2:CNPJ Cliente;  3:IDConexao;    4:Opção
                    Application.Run(new Home(argumentos[1], argumentos[2], argumentos[3], argumentos[4]));
                    break;
                case "Download":
                    Application.Run(new DownloadERP(argumentos[1], argumentos[2], argumentos[3]));
                    break;

                case "Backup": //Argumentos - 1 - Banco; 2 - Usuário; 3 - Senha; 4 - Servidor; 5 - Pasta Backup; 6 - Pasta Destino
                    Application.Run(new BackupERP(argumentos[1], argumentos[2], argumentos[3], argumentos[4], argumentos[5], argumentos[6], argumentos[7]));
                    break;

                case "Versao": //idVersao, codVersao, staVersao, descVersao, dataVersao, Opcao
                    Application.Run(new VersaoERP(argumentos[1], argumentos[2], argumentos[3], argumentos[4], argumentos[5], argumentos[6], argumentos[7], argumentos[8]));
                    break;
            }
        }
    }
}
