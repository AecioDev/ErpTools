using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using GeneXus.Encryption;

namespace AtualizaERP.Classes
{
    public class AcessoDados
    {
        private string nomeErro = "";

        private string connStr()
        {
            string strConexao = null;

            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings["ConnString"];

            if (settings != null)
                strConexao = settings.ConnectionString;

            return strConexao;
        }
               
        //WebService
        public List<VersaoModel> ConsVersao(int idVersao, int codVersao)
        {
            List<VersaoModel> Versoes = new List<VersaoModel>();

            try
            {
                string conSql = "SELECT  * FROM VERSOESERP \n" +
                                "WHERE ((IdVersao = @idversao OR @idversao = 0) AND (CodVersao = @codversao OR @codversao = 0))";

                SqlConnection conexao = new SqlConnection(connStr());
                SqlCommand cmd = new SqlCommand(conSql, conexao);

                cmd.Parameters.AddWithValue("@idversao", idVersao);
                cmd.Parameters.AddWithValue("@codversao", codVersao);
                                
                conexao.Open();

                SqlDataReader rd = cmd.ExecuteReader();

                //Se tiver coisa pra lê faça:
                //idVersao	CodVersao	VersaoAtual	DescVersao	DataVersao                
                while (rd.Read())
                {
                                             //  idVersao	     CodVersao	     DescVersao	                DataVersao                      ImpactDB	    URLVersao	    URLRelease
                    Versoes.Add(new VersaoModel(rd.GetInt32(0), rd.GetInt32(1), rd.GetString(2), rd.GetDateTime(3).ToShortDateString(), rd.GetString(4), rd.GetString(5), rd.GetString(6)));
                }

                //Finalizar tarefa
                conexao.Close(); 
                return Versoes;
            }
            catch (Exception erro)
            {
                GravaErro(erro.Message);
                return Versoes;
            }
        }

        //WebService
        public string CadVersao(VersaoModel Versao, int caso)
        {
            
            string consulta = "";
            string result = "";

            try
            {

                if (caso == 1) //1 - Cadastro / 2 - Alteração
                    consulta = "INSERT INTO VERSOESERP VALUES(@idVersao, @CodVersao, @DescVersao, @DataVersao, @ImpactDB, @URLVersao, @URLRelease)";                
                else
                    consulta = "UPDATE VERSOESERP SET idVersao = @idVersao, CodVersao = @CodVersao, DescVersao = @DescVersao, " +
                                "DataVersao = @DataVersao, ImpactDB = @ImpactDB, URLVersao = @URLVersao, URLRelease = @URLRelease, " +
                                "WHERE idVersao = @idVersao";

                SqlConnection conexao = new SqlConnection(connStr()); 
                SqlCommand cmd = new SqlCommand(consulta, conexao);

                //Parâmetros
                cmd.Parameters.AddWithValue("@idVersao", Versao.IdVersao);
                cmd.Parameters.AddWithValue("@CodVersao", Versao.CodVersao);
                cmd.Parameters.AddWithValue("@DescVersao", Versao.DescVersao);
                cmd.Parameters.AddWithValue("@DataVersao", Convert.ToDateTime(Versao.DataVersao));
                cmd.Parameters.AddWithValue("@ImpactDB", Versao.ImpactDB);
                cmd.Parameters.AddWithValue("@URLVersao", Versao.URLVersao);
                cmd.Parameters.AddWithValue("@URLRelease", Versao.URLRelease);
                
                conexao.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                result = "OK";
                conexao.Close();
                GravaErro(result);
                return result;

            }
            catch (Exception ex)
            {
                result = ex.Message;
                GravaErro(result);
                return result;
            }
        }

        public List<AcessosModel> ConsAcessos(string IDConex)
        {
            List<AcessosModel> Acessos = new List<AcessosModel>();
            var conERP = LeConfTXT(IDConex);                        
            
            try
            {
                string conSql = "DECLARE @myConTable TABLE \n" +
                                "(spid smallint, ecid smallint, status nchar(30), loginname nchar(128), hostname nchar(128), blk char(5), dbname nchar(128), cmd nchar(16), request_id int) \n" +
                                "INSERT INTO @myConTable EXEC sp_who \n" +
                                "SELECT hostname, dbname FROM @myConTable WHERE dbname = @nomeDB";

                SqlConnection conexao = new SqlConnection(conERP.StringConexao);
                SqlCommand cmd = new SqlCommand(conSql, conexao);

                cmd.Parameters.AddWithValue("@nomeDB", conERP.BancoDados);

                conexao.Open();

                SqlDataReader rd = cmd.ExecuteReader();
                
                while (rd.Read())
                {
                    //                             HostName         BD Name
                    Acessos.Add(new AcessosModel(rd.GetString(0), rd.GetString(1)));
                }

                //Finalizar tarefa
                conexao.Close();
                return Acessos;
            }
            catch (Exception erro)
            {
                GravaErro(erro.Message);
                return Acessos;
            }
        }

        #region CLIENTE

        //WebService
        public DadosCliente BuscaCli(string docCli)
        {
            //Verifica se o cliente existe no Banco
            DadosCliente Cliente = new DadosCliente();
            try
            {
                string conSql = "SELECT * FROM DADOSCLIENTE WHERE docCliente = @docCliente";
                docCli = docCli.Replace(".", "").Replace("-", "").Replace("/", "");
                SqlConnection conexao = new SqlConnection(connStr());
                SqlCommand cmd = new SqlCommand(conSql, conexao);
                cmd.Parameters.AddWithValue("@docCliente", docCli);
                conexao.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Cliente.ClienteId = rd.GetInt32(0);             //ClienteID
                    Cliente.DocCliente = rd.GetString(1);           //DocCliente
                    Cliente.NomeCliente = rd.GetString(2);          //NomeCliente
                    Cliente.SerieCliente = rd.GetString(3);         //serieVersao
                    Cliente.VersaoCliente = rd.GetInt32(4);         //VersaoCli
                    Cliente.DataAtualizacao = rd.GetDateTime(5);    //DataAtualizacao
                }

                conexao.Close();
                return Cliente;
            }
            catch (Exception erro)
            {
                GravaErro(erro.Message);
                return Cliente;
            }
        } //Dados do Cliente no Controle de Versões

        //WebService
        public int GetCodCli(string docCli)
        {
            int seqCli = 0;
            try
            {
                string conSql = "SELECT ClienteId FROM DADOSCLIENTE WHERE RTRIM(LTRIM(docCliente)) = '" + docCli.Trim() + "'";
                SqlConnection conexao = new SqlConnection(connStr());
                SqlCommand cmd = new SqlCommand(conSql, conexao);
                conexao.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    seqCli = rd.GetInt32(0);
                }

                conexao.Close();
                return seqCli;
            }
            catch (Exception erro)
            {
                GravaErro(erro.Message);
                return seqCli;
            }
        } //Retorna o código do Cliente pelo Documento

        public DadosCliente DadosCliERP(string IDConex)
        {
            string dadostxt = "";
            DadosCliente Cliente = new DadosCliente();
            var conERP = LeConfTXT(IDConex);

            dadostxt = "Servidor:" + conERP.Servidor + "\nBanco:" + conERP.BancoDados + "\nUser:" + conERP.Usuario + "\nSenhaCrip:" + conERP.SenhaCript + "\nKey:" + conERP.KeyString + "\nSenhaBD:" + conERP.SenhaBD + "\nString:" + conERP.StringConexao;
            nomeErro = @"C:\Temp\DadosLeConf.txt";
            GravaErro(dadostxt);

            try
            {
                string conSql = "SELECT cgcemp, nomemp, nroserfin, versisemp, dataAtualizaEmp from EMPRESA";
                SqlConnection conexao = new SqlConnection(conERP.StringConexao);
                SqlCommand cmd = new SqlCommand(conSql, conexao);
                conexao.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Cliente.DocCliente = rd.GetString(0).Replace(".", "").Replace("-", "").Replace("/", "");           //DocCliente
                    Cliente.NomeCliente = rd.GetString(1);          //NomeCliente
                    Cliente.SerieCliente = rd.GetString(2);         //serieVersao
                    Cliente.VersaoCliente = rd.GetInt32(3);         //VersaoCli

                    var data = rd.GetValue(4).ToString();
                    if (!string.IsNullOrEmpty(rd.GetValue(4).ToString())) //DataAtualizacao
                        Cliente.DataAtualizacao = Convert.ToDateTime(rd.GetValue(4));
                    else
                        Cliente.DataAtualizacao = Convert.ToDateTime("01-01-1753");
                }

                conexao.Close();
                return Cliente;
            }
            catch (Exception erro)
            {
                GravaErro(erro.Message);
                return Cliente;
            }
        } //Busca os dados do Cliente no Banco do ERP para gravar no controle de versões

        //WebService
        public string CadCliente(DadosCliente Cliente, int caso)
        {
            string consulta = "";
            string result = "";
            string conex = "";

            try
            {

                if (caso == 0) //0 - Cadastro / 1 - Alteração
                    consulta = "INSERT INTO DADOSCLIENTE VALUES(@docCliente, @nomeCliente, @serieCliente, @versaoCliente, @dataAtualiza)";
                else
                    consulta = "UPDATE DADOSCLIENTE SET docCliente = @docCliente, nomeCliente = @nomeCliente, serieCliente = @serieCliente, " +
                                "versaoCliente = @versaoCliente, dataAtualiza = @dataAtualiza WHERE ClienteId = @ClienteId";

                conex = connStr();
                nomeErro = @"C:\Temp\StringConexao.txt";
                GravaErro(conex);

                SqlConnection conexao = new SqlConnection(conex);
                SqlCommand cmd = new SqlCommand(consulta, conexao);

                //Parâmetros
                if (caso > 0)
                    cmd.Parameters.AddWithValue("@ClienteId", Cliente.ClienteId);

                cmd.Parameters.AddWithValue("@docCliente", Cliente.DocCliente);
                cmd.Parameters.AddWithValue("@nomeCliente", Cliente.NomeCliente);
                cmd.Parameters.AddWithValue("@serieCliente", Cliente.SerieCliente);
                cmd.Parameters.AddWithValue("@versaoCliente", Cliente.VersaoCliente);
                cmd.Parameters.AddWithValue("@dataAtualiza", Cliente.DataAtualizacao);

                conexao.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                result = "OK";
                conexao.Close();

                return result;

            }
            catch (Exception ex)
            {
                result = ex.Message;
                GravaErro(result);
                return result;
            }
        } //Cadastra o Cliente no Controle de versões
         #endregion

        #region CONEXÃO

        //WebService
        public ConexaoERP ConsConex(int CodCli, int IdConex)
        {
            //Verifica se o cliente existe no Banco
            ConexaoERP ERPConn = new ConexaoERP();
            try
            {
                string conSql = "SELECT * FROM CONEXAOBD WHERE ClienteId = @CodCli AND ConexaoId = @ConnId";
                SqlConnection conexao = new SqlConnection(connStr());
                SqlCommand cmd = new SqlCommand(conSql, conexao);
                cmd.Parameters.AddWithValue("@CodCli", CodCli);
                cmd.Parameters.AddWithValue("@ConnId", IdConex);
                conexao.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    ERPConn.ClienteId = rd.GetInt32(0);
                    ERPConn.ConexaoId = rd.GetInt32(1);
                    ERPConn.Servidor = rd.GetString(2);
                    ERPConn.BancoDados = rd.GetString(3);
                    ERPConn.Usuario = rd.GetString(4);
                    ERPConn.SenhaCript = rd.GetString(5);
                    ERPConn.KeyString = rd.GetString(6);
                    ERPConn.SenhaBD = rd.GetString(7);
                    ERPConn.ServerMirror = rd.GetString(8);
                    ERPConn.PastaBD = rd.GetString(9);
                    ERPConn.PastaBackup = rd.GetString(10);
                    ERPConn.StringConexao = rd.GetString(11);                    
                }

                conexao.Close();
                return ERPConn;
            }
            catch (Exception erro)
            {
                GravaErro(erro.Message);
                return ERPConn;
            }

        } //Dados do Cliente no Controle de Versões

        //WebService
        public string CadConCliente(ConexaoERP ConnERP, int caso)
        {
            string consulta = "";
            string result = "";

            try
            {
                if (caso == 0) //0 - Cadastro / 1 - Alteração
                    consulta = "INSERT INTO CONEXAOBD VALUES(@ClienteId, @ConexaoId, @ServidorBD, @BancoDados, @UsuarioBD, " +
                               "@SenhaCrypt, @KeySenhaBD, @SenhaBD, @ServerMirror, @PastaBD, @PastaBackup, @strConn)";
                else
                    consulta = "UPDATE CONEXAOBD SET ServidorBD = @ServidorBD, BancoDados = @BancoDados, UsuarioBD = @UsuarioBD, " +
                                "SenhaCrypt = @SenhaCrypt, KeySenhaBD = @KeySenhaBD, SenhaBD = @SenhaBD, ServerMirror = @ServerMirror, " +
                                "PastaBD = @PastaBD, PastaBackup = @PastaBackup, stringConexao = @strConn " +
                                "WHERE ClienteId = @ClienteId AND  ConexaoId = @ConexaoId";

                SqlConnection conexao = new SqlConnection(connStr());
                SqlCommand cmd = new SqlCommand(consulta, conexao);

                //Parâmetros                
                cmd.Parameters.AddWithValue("@ClienteId", ConnERP.ClienteId);
                cmd.Parameters.AddWithValue("@ConexaoId", ConnERP.ConexaoId);
                cmd.Parameters.AddWithValue("@ServidorBD", ConnERP.Servidor);
                cmd.Parameters.AddWithValue("@BancoDados", ConnERP.BancoDados);
                cmd.Parameters.AddWithValue("@UsuarioBD", ConnERP.Usuario);
                cmd.Parameters.AddWithValue("@SenhaCrypt", ConnERP.SenhaCript);
                cmd.Parameters.AddWithValue("@KeySenhaBD", ConnERP.KeyString);
                cmd.Parameters.AddWithValue("@SenhaBD", ConnERP.SenhaBD);
                cmd.Parameters.AddWithValue("@ServerMirror", ConnERP.ServerMirror);
                cmd.Parameters.AddWithValue("@PastaBD", ConnERP.PastaBD);
                cmd.Parameters.AddWithValue("@PastaBackup", ConnERP.PastaBackup);
                cmd.Parameters.AddWithValue("@strConn", ConnERP.StringConexao);

                conexao.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                result = "OK";
                conexao.Close();
                return result;

            }
            catch (Exception ex)
            {
                result = ex.Message;
                GravaErro(result);
                return result;
            }
        } //Cadastra a Conexão do Banco ERP do Cliente no Controle de versões


        public ConexaoERP LeConfTXT(string IDConex)
        {
            ConexaoERP dadosConn = new ConexaoERP();
            string PastaUser = Environment.GetEnvironmentVariable("USERPROFILE");
            string ArqConexoes = PastaUser + @"\Controller\ConexaoAtual-" + IDConex + ".cfg";
            string Valor = "";

            try
            {
                if (File.Exists(ArqConexoes))
                {
                    dadosConn.ConexaoId = Convert.ToInt32(IDConex);

                    Regex regex = new Regex(@"(?<chave>[A-Z|_]*)\:(?<valor>.*)");

                    var linhas = File.ReadAllLines(ArqConexoes);

                    foreach (var linha in linhas)
                    {
                        GroupCollection groups = regex.Match(linha).Groups;

                        //   Console.WriteLine( "Group: {0}, Value: {1}",   groupName, groups[groupName].Value);
                        Valor = groups["valor"].Value.ToString();

                        switch (groups["chave"].Value.ToString())
                        {
                            case "SERVIDOR":
                                dadosConn.Servidor = Valor;
                                break;
                            case "BANCO":
                                dadosConn.BancoDados = Valor;
                                break;
                            case "USUARIO":
                                dadosConn.Usuario = Valor;
                                break;
                            case "SENHA":
                                dadosConn.SenhaCript = Valor;
                                break;
                            case "KEY":
                                dadosConn.KeyString = Valor;
                                break;
                            case "MIRROR":
                                dadosConn.ServerMirror = Valor;
                                break;
                            case "PASTA_DB":
                                dadosConn.PastaBD = Valor;
                                break;
                            case "PASTA_BKP":
                                dadosConn.PastaBackup = Valor;
                                break;
                        }
                    }
                }

                //Tenta Descriptar a Senha - Vou deixar pra depois esse trampo pq pode demorar mto
                dadosConn.SenhaBD = Crypto.Decrypt64(dadosConn.SenhaCript, dadosConn.KeyString);

                dadosConn.StringConexao = String.Format(@"Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                dadosConn.Servidor, dadosConn.BancoDados, dadosConn.Usuario, dadosConn.SenhaBD);

                return dadosConn;
            }
            catch (Exception ex)
            {
                return dadosConn;
                throw ex;
            }
        }
        
        #endregion

        public string fechaConBD(string Banco, int caso)
        { 
            string consulta = "";
            string result = "";

            try
            {
                if (caso == 1) //1 - Fecha Conexoes / 2 - Retorna para MultUser
                    consulta = "USE [master] \nGO\n" +                               
                                "ALTER DATABASE " + Banco.ToUpper() + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE\nGO\n" +
                                "ALTER DATABASE " + Banco.ToUpper() + " SET SINGLE_USER \nGO\n";

                else
                    consulta = "USE [master] \nGO\n" +                               
                                "ALTER DATABASE " + Banco.ToUpper() + " SET MULTI_USER \nGO\n";

                SqlConnection conexao = new SqlConnection(connStr()); 
                SqlCommand cmd = new SqlCommand(consulta, conexao);
                conexao.Open();
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                result = "OK";

                conexao.Close();
                return result;

            }
            catch (Exception ex)
            {
                result = ex.Message;
                GravaErro(result);
                return result;
            }
        }

        public void GravaErro(string erro)
        {
            string time = DateTime.Now.ToLongTimeString().Replace(":", "").Replace("/", "");
            string arqdebug = @"C:\Temp\DebugAcessoDados" + time + ".txt";

            if (!string.IsNullOrEmpty(nomeErro))
                arqdebug = nomeErro;

            try
            {
                FileStream fs = new FileStream(arqdebug, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(erro);

                sw.Close(); //grava e fecha
            }
            catch (Exception ex)
            {
                throw ex;
            }

            nomeErro = "";
        }

        public static string EncodeBase64(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string DecodeBase64(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

    }
}
