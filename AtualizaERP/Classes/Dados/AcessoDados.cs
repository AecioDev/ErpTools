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
        public string nomeErro = "";

        //Conexão do Banco Local de Cadastro dos dados dos Clientes.
        private string connStr() 
        {
            string strConexao = null;

            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings["ConnString"];

            if (settings != null)
                strConexao = settings.ConnectionString;

            return strConexao;
        }

        //WebService (Pode Ser Local)
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

        //WebService (Pode Ser Local)
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

        //Lista as Estações que estão conectadas no banco de dados.
        public List<AcessosModel> ConsAcessos(string IDConex) 
        {
            List<AcessosModel> Acessos = new List<AcessosModel>();
            var conERP = LeConfTXT(IDConex);                        
            
            try
            {
                string conSql = "USE MASTER \n" +
                                "DECLARE @myConTable TABLE \n" +
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
                cmd.Dispose();
                conexao.Close();
                return Acessos;
            }
            catch (Exception erro)
            {
                GravaErro(erro.Message);
                return Acessos;
            }
        }

        //Busca os dados do Cliente no Banco do ERP para gravar no controle de versões
        public WSVersoesERP.Cliente DadosCliERP(string IDConex)
        {
            string dadostxt = "";
            WSVersoesERP.Cliente Cliente = new WSVersoesERP.Cliente();
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
        } 
        
        //Retorna os dados da conexão do ERP 
        public ConexaoERP LeConfTXT(string IDConex)
        {

            ConexaoERP dadosConn = new ConexaoERP();
            string PastaUser = "";
            string ArqConexoes = "";
            string Valor = "";

            var tam = IDConex.Length;
            if (tam < 3)
            {
                if (tam == 2)
                    IDConex = "0" + IDConex.Trim();
                else if(tam == 1)
                    IDConex = "00" + IDConex.Trim();
            }

            PastaUser = Environment.GetEnvironmentVariable("USERPROFILE");
            ArqConexoes = PastaUser + @"\Controller\ConexaoAtual-" + IDConex + ".cfg";

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
      
        //Derruba as conexões abertas com o Banco de dados.
        public string fechaConBD(ConexaoERP ConnErp, int caso)
        { 
            string consulta = "";
            string result = "";
            string connStrMaster = "";

            connStrMaster = String.Format(@"Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                ConnErp.Servidor, "master", ConnErp.Usuario, ConnErp.SenhaBD);

            try
            {
                //SqlConnection conexao = new SqlConnection(connStrMaster);

                if (caso == 1) //1 - Fecha Conexoes / 2 - Retorna para MultUser
                {
                    consulta = "ALTER DATABASE " + ConnErp.BancoDados.ToUpper() + " SET SINGLE_USER WITH ROLLBACK IMMEDIATE; \n" +
                               "ALTER DATABASE " + ConnErp.BancoDados.ToUpper() + " MODIFY NAME = REBUILDidx; \n" +
                               "ALTER DATABASE REBUILDidx SET MULTI_USER; \n";
                }
                else
                {
                    consulta = "ALTER DATABASE REBUILDidx SET SINGLE_USER WITH ROLLBACK IMMEDIATE; \n" +
                               "ALTER DATABASE REBUILDidx MODIFY NAME = " + ConnErp.BancoDados.ToUpper() + ";\n" +
                               "ALTER DATABASE " + ConnErp.BancoDados.ToUpper() + " SET MULTI_USER; \n";
                }

                SqlConnection conexao = new SqlConnection(connStrMaster); 
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

        //Verifica Conexão com o Banco De Dados
        public bool VerConnDB(string IDConex)
        {            
            string script = "";
            bool conectado = false;
         
            var conERP = LeConfTXT(IDConex);

            try
            {
                //Primeiro Lista as Tabelas do Banco de Dados.
                script = "SELECT versisemp FROM EMPRESA";

                SqlConnection conexao = new SqlConnection(conERP.StringConexao);
                SqlCommand cmd = new SqlCommand(script, conexao);
                conexao.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    var versao = rd.GetValue(0).ToString();
                }

                conexao.Close();
                conectado = true;
            }
            catch (Exception erro)
            {
                GravaErro(erro.Message);
                conectado = false;
            }

            return conectado;
        }

        //Dados da Empresa
        public ModelEmpresa DadosEmpresa(string IDConex, int cencus)
        {
            string script = "";

            string nomempimprel  = null;
            string nomfancencus  = null;
            byte[] arqlogocencus = null;

            string fanemp = null;
            string nomemp = null;
            string verlogo = null;
            byte[] logoemp = null;

            SqlConnection conexao = null;
            SqlCommand cmd = null;
            SqlDataReader rd = null;
            ModelEmpresa DadosEmp = new ModelEmpresa();

            var conERP = LeConfTXT(IDConex);

            try
            {
                //Primeiro Pega os dados do Centro de Custo
                script = "SELECT nomempimprel, nomfancencus, arqlogocencus FROM CENCUS WHERE codcencus = " + cencus;

                conexao = new SqlConnection(conERP.StringConexao);
                cmd = new SqlCommand(script, conexao);
                conexao.Open();
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    nomempimprel  = rd.GetString(0);
                    nomfancencus  = rd.GetString(1);

                    if(!string.IsNullOrEmpty(rd.GetValue(2).ToString()))
                        arqlogocencus = (byte[])rd.GetValue(2);
                }
                conexao.Close();

                //Segundo Pega os dados da Empresa Padrão
                script = "SELECT fanemp, nomemp, logorelemp, logoemp FROM EMPRESA WHERE codemp = 1";
                
                conexao = new SqlConnection(conERP.StringConexao);
                cmd = new SqlCommand(script, conexao);
                conexao.Open();
                rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    fanemp  = rd.GetString(0);
                    nomemp  = rd.GetString(1);
                    verlogo = rd.GetString(2);
                    logoemp = (byte[])rd.GetValue(3);
                }
                conexao.Close();

                //Verifica o nome do centro de Custo
                if (!string.IsNullOrEmpty(nomempimprel)) 
                {
                    DadosEmp.nomeEmp = nomempimprel;
                }
                else
                {
                    if (!string.IsNullOrEmpty(nomfancencus))
                        DadosEmp.nomeEmp = nomfancencus;
                }

                //Se não achou pega o Nome Padrão da Empresa
                if (string.IsNullOrEmpty(DadosEmp.nomeEmp))
                {
                    if (!string.IsNullOrEmpty(fanemp))
                        DadosEmp.nomeEmp = fanemp;
                    else
                        DadosEmp.nomeEmp = nomemp;
                }

                //Verifica a Logo
                DadosEmp.logoOk = false;

                if (arqlogocencus.Length > 0)
                {
                    DadosEmp.logoEmp = arqlogocencus;
                    DadosEmp.logoOk = true;
                }

                if(!DadosEmp.logoOk) //Não Achou no Centro de Custo
                {
                    if (verlogo != "N") //Ou pega o da Empresa Padrão e se não tiver pega da pasta do Usuário.
                    {
                        DadosEmp.logoOk = true;
                        if (logoemp != null)
                            DadosEmp.logoEmp = logoemp;                        
                    }
                }

                return DadosEmp;
            }
            catch (Exception erro)
            {
                GravaErro(erro.Message);
                return null;
            }
        }

        //Executa rotina de Manutenção do Banco de Dados 
        public void ManDBERP(string IDConex)
        {
            string dadosdebug = "";
            string script = "";
            string NomeTabela = "";
            int QntLinhas = 0;
            int TamanhoTabela = 0;
            decimal FragIdxTab = 0;
            string connStrRebuild = "";

            var conERP = LeConfTXT(IDConex);

            nomeErro = @"C:\Controller\DebugRebuildIdx\ProcessamentoManDB.txt";
            dadosdebug = "Conexão com BD: -> Servidor:" + conERP.Servidor + "\nBanco:" + conERP.BancoDados + "\nUser:" + conERP.Usuario + "\nSenhaCrip:" + conERP.SenhaCript + "\nKey:" + conERP.KeyString + "\nSenhaBD:" + conERP.SenhaBD + "\nString:" + conERP.StringConexao + "\n";
            dadosdebug += "Inicio Processamento Geral: " + DateTime.Now.ToString() + "\n";


            connStrRebuild = String.Format(@"Data Source={0};Initial Catalog={1};Persist Security Info=True;User ID={2};Password={3}",
                conERP.Servidor, "REBUILDidx", conERP.Usuario, conERP.SenhaBD);
            try
            {
                //Primeiro Lista as Tabelas do Banco de Dados.
                script = "SELECT t.NAME AS TableName, p.rows AS QuantidadeDeLinhas, SUM(a.total_pages) * 8 / 1024 AS EspacoTotalEmMB  \n" +
                         "FROM sys.tables t \n" +
                         "  INNER JOIN sys.indexes i ON t.OBJECT_ID = i.object_id \n" +
                         "  INNER JOIN sys.partitions p ON i.object_id = p.OBJECT_ID AND i.index_id = p.index_id \n" +
                         "  INNER JOIN sys.allocation_units a ON p.partition_id = a.container_id \n" +
                         "  LEFT OUTER JOIN sys.schemas s ON t.schema_id = s.schema_id \n" +
                         "WHERE t.NAME NOT LIKE 'dt%' \n" +
                         "  AND t.is_ms_shipped = 0 \n" +
                         "  AND i.OBJECT_ID > 255 \n" +
                         "GROUP BY t.Name, s.Name, p.Rows \n" +
                         "ORDER BY 3 DESC";

                SqlConnection conexao = new SqlConnection(connStrRebuild);
                SqlCommand cmd = new SqlCommand(script, conexao);
                conexao.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {                    
                    NomeTabela = rd.GetString(0);   //Nome da Tabela

                    if (!string.IsNullOrEmpty(rd.GetValue(1).ToString()))
                        QntLinhas = Convert.ToInt32(rd.GetValue(1).ToString());     //Quantidade de Linhas
                    else
                        QntLinhas = 0;

                    if (!string.IsNullOrEmpty(rd.GetValue(2).ToString()))
                        TamanhoTabela = Convert.ToInt32(rd.GetValue(2).ToString());     //Espaço Total em MB
                    else
                        TamanhoTabela = 0;

                    if (TamanhoTabela >= 10)
                    {
                        //Chama Rotina para Verificar Fragmentação dos Indices da Tabela.
                        FragIdxTab = VerFragTabela(connStrRebuild, NomeTabela);

                        if (FragIdxTab >= 20)
                        {
                            //Executa rotina de Rebuild dos Indices.
                            RebuildIdx(connStrRebuild, NomeTabela);
                        }
                    }
                }
                conexao.Close();

                dadosdebug += "Fim do Processamento Geral: " + DateTime.Now.ToString() + "\n";
                GravaErro(dadosdebug);
            }
            catch (Exception erro)
            {
                GravaErro(erro.Message);
            }
        }

        public decimal VerFragTabela(string ConnErp, string TabelaBD)
        {
            string script1 = "";
            string nomeIdx = "";
            decimal FragIdxTab = 0;
                        
            try
            {
                //Primeiro Lista as Tabelas do Banco de Dados.
                script1 = "SELECT dbindexes.[name] as 'Index', indexstats.avg_fragmentation_in_percent \n" +
                         "FROM sys.dm_db_index_physical_stats(DB_ID(), NULL, NULL, NULL, NULL) AS indexstats \n" +
                         "  INNER JOIN sys.tables dbtables on dbtables.[object_id] = indexstats.[object_id] \n" +
                         "  INNER JOIN sys.schemas dbschemas on dbtables.[schema_id] = dbschemas.[schema_id] \n" +
                         "  INNER JOIN sys.indexes AS dbindexes ON dbindexes.[object_id] = indexstats.[object_id] AND indexstats.index_id = dbindexes.index_id \n" +
                         "WHERE indexstats.database_id = DB_ID() \n" +
                         "  AND dbtables.[name] like '" + TabelaBD.Trim() + "' \n" +
                         "ORDER BY indexstats.avg_fragmentation_in_percent desc";

                SqlConnection conexao1 = new SqlConnection(ConnErp);
                SqlCommand cmd1 = new SqlCommand(script1, conexao1);
                conexao1.Open();
                SqlDataReader rdx = cmd1.ExecuteReader();

                while (rdx.Read())
                {
                    nomeIdx = rdx.GetString(0);      //Nome do Indice

                    if (!string.IsNullOrEmpty(rdx.GetValue(1).ToString()))
                        FragIdxTab = Convert.ToDecimal(rdx.GetValue(1).ToString());     //Percentual de Fragmentação  
                    else
                        FragIdxTab = 0;

                    //Chama Rotina para Verificar Fragmentação da Tabela.
                    if (FragIdxTab >= 20)
                        break; //Sai do Laço
                }

                conexao1.Close();

                return FragIdxTab;
            }
            catch (Exception erro)
            {
                GravaErro(erro.Message);
            }

            return FragIdxTab;
        }

        public void RebuildIdx(string ConnErp, string TabelaBD)
        {
            string dadostxt = "";
            string script2 = "";
            int roles = 0;

            nomeErro = @"C:\Controller\DebugRebuildIdx\RebuildTabela_" + TabelaBD.Trim() + ".txt";
            dadostxt = "Rebuild na Tabela " + TabelaBD.Trim() + "\n";
            
            try
            {
                script2 = "ALTER INDEX ALL ON " + TabelaBD.Trim() + " REBUILD";

                SqlConnection conexao2 = new SqlConnection(ConnErp);
                SqlCommand cmd2 = new SqlCommand(script2, conexao2);

                TimeSpan TempoIni = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                dadostxt += "Início do processamento: " + DateTime.Now.ToString() + "\n";

                conexao2.Open();
                cmd2.CommandTimeout = 900;               
                roles = cmd2.ExecuteNonQuery();

                TimeSpan TempoFim = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);
                TimeSpan intervalo = TempoFim - TempoIni;
                dadostxt += "Fim do processamento: " + DateTime.Now.ToString() + "\n";
                dadostxt += "Tempo total do processamento: ";

                if(intervalo.Hours > 0)
                    dadostxt += intervalo.Hours.ToString() + " Horas, ";

                if (intervalo.Minutes > 0)
                    dadostxt += intervalo.Minutes.ToString() + " Minutos, ";

                if (intervalo.Seconds > 0)
                    dadostxt += intervalo.Seconds.ToString() + " Segundos.\n";

                if (roles > 0)
                    dadostxt += roles.ToString() + " linhas afetadas!" + "\n";
                else
                    dadostxt += "Nenhuma linha afetada!";

                conexao2.Close();
                GravaErro(dadostxt);
            }
            catch (Exception erro)
            {
                nomeErro = "";
                GravaErro(erro.Message);
            }
        }

        public DadosTarefa GetAgenda(int AgendaId, string IDConex)
        {
            string dadostxt = "";
            DadosTarefa Agenda = new DadosTarefa();
            var conERP = LeConfTXT(IDConex);

            dadostxt = "Servidor:" + conERP.Servidor + "\nBanco:" + conERP.BancoDados + "\nUser:" + conERP.Usuario + "\nSenhaCrip:" + conERP.SenhaCript + "\nKey:" + conERP.KeyString + "\nSenhaBD:" + conERP.SenhaBD + "\nString:" + conERP.StringConexao;
            nomeErro = @"C:\Temp\DadosLeConf.txt";
            GravaErro(dadostxt);

            try
            {
                string conSql = "SELECT AgendaId, AgendaTipo, AgendaData, AgendaFreq, AgendaStatus, DescStatusAgd, UserAgendou from AGENDA where AgendaId = @AgendaId";
                SqlConnection conexao = new SqlConnection(conERP.StringConexao);
                SqlCommand cmd = new SqlCommand(conSql, conexao);

                cmd.Parameters.AddWithValue("@AgendaId", AgendaId);

                conexao.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    if(!string.IsNullOrEmpty(rd.GetValue(0).ToString()))    //Id
                        Agenda.AgendaId = Convert.ToInt32(rd.GetValue(0));

                    if (!string.IsNullOrEmpty(rd.GetValue(1).ToString()))   //Tipo
                        Agenda.AgendaTipo = Convert.ToInt32(rd.GetValue(1));

                    var data = rd.GetValue(2).ToString();
                    if (!string.IsNullOrEmpty(rd.GetValue(2).ToString()))   //Data
                        Agenda.AgendaData = Convert.ToDateTime(rd.GetValue(4));
                    else
                        Agenda.AgendaData = Convert.ToDateTime("01-01-1753");

                    if (!string.IsNullOrEmpty(rd.GetValue(3).ToString()))   //Tipo
                        Agenda.AgendaFreq = Convert.ToInt32(rd.GetValue(3));

                    Agenda.AgendaStatus = rd.GetString(4);          //Status
                    Agenda.DescStatusAgd = rd.GetString(5);         //Descrição Status
                    Agenda.UserAgendou = rd.GetString(6);           //Usuário

                    break;
                }

                conexao.Close();
                return Agenda;
            }
            catch (Exception erro)
            {
                GravaErro(erro.Message);
                return null;
            }
        }

        public void AtualizaStatusTarefa(int AgendaId, string Status, string DescStatus, string IDConex)
        {            
            string script = "";

            var conERP = LeConfTXT(IDConex);

            nomeErro = "";            

            try
            {
               
                script = "Update AGENDA set AgendaStatus = @Status, DescStatusAgd = @DescStatus where AgendaId = @AgendaId";
               
                SqlConnection conexao = new SqlConnection(conERP.StringConexao);
                SqlCommand cmd = new SqlCommand(script, conexao);

                cmd.Parameters.AddWithValue("@AgendaId", AgendaId);
                cmd.Parameters.AddWithValue("@Status", Status);
                cmd.Parameters.AddWithValue("@DescStatus", DescStatus);
                
                conexao.Open();
                cmd.ExecuteNonQuery();

                conexao.Close();
            }
            catch (Exception erro)
            {
                nomeErro = "";
                GravaErro(erro.Message);
            }
        }

        public void GravaLogTarefa(int AgendaId, DateTime DataUltima, DateTime DataProxima, string DescStatus, string IDConex)
        {
            string script = "";

            var conERP = LeConfTXT(IDConex);

            nomeErro = "";

            try
            {

                script = "Update AGENDA set AgendaStatus = @Status, DescStatusAgd = @DescStatus where AgendaId = @AgendaId";

                SqlConnection conexao = new SqlConnection(conERP.StringConexao);
                SqlCommand cmd = new SqlCommand(script, conexao);

                //cmd.Parameters.AddWithValue("@AgendaId", AgendaId);
                //cmd.Parameters.AddWithValue("@Status", Status);
                //cmd.Parameters.AddWithValue("@DescStatus", DescStatus);

                conexao.Open();
                cmd.ExecuteNonQuery();

                conexao.Close();
            }
            catch (Exception erro)
            {
                nomeErro = "";
                GravaErro(erro.Message);
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

        public void GravaFim(string mensagem)
        {            
            string arqfim = "FimAtualizaERP.txt";
                        
            try
            {
                FileStream fs = new FileStream(arqfim, FileMode.Create, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(mensagem);

                sw.Close(); //grava e fecha
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
