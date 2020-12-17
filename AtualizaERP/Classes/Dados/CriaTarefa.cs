using Microsoft.Win32.TaskScheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TaskScheduler;

namespace AtualizaERP.Classes
{
    public class CriaTarefa
    {

        //TaskSchedulerClass oAgendador; 
        //ITaskDefinition oDefinicaoTarefa; //Para tratar a definição da tarefa
        //ITimeTrigger oTrigger; //Para tratar a informação do Trigger
        //IExecAction oAcao; //Para tratar a informação da Ação

        AcessoDados Dados;

        private string Tarefa; 
        private string Usuario; 
        private string DescricaoTarefa;
        private string ProgramaExe;
        private string ProgramaArgs;
        private DateTime DataInicio;
        private int FreqAgenda;

        //private int AgendaId;
        private string IDConex;

        public CriaTarefa(string _nomeTarefa)
        {
            Tarefa = _nomeTarefa;
        }
        public CriaTarefa(string _agdUser, DateTime _agdData, int _agdFreq, string _idCon) 
        {
            Usuario = _agdUser;
            DataInicio = _agdData;
            FreqAgenda = _agdFreq;
            IDConex = _idCon;

            Tarefa = "Rebuild_Idx_BD";
            DescricaoTarefa = "Executar Scripts no Banco de Dados do Controller ERP para reorganizar os Índices e melhorar a Performance do Sistema.";
            ProgramaExe = @"C:\Controller\Complementos\AtualizaERP\AtualizaERP.exe";
            ProgramaArgs = "ScriptSQL RebuildIDX " + IDConex.Trim();
        }

        public bool AgendaRebuild()
        {
            bool result = false;
            Dados = new AcessoDados();

            try
            {
                // Get the service on the local machine
                using (TaskService ts = new TaskService())
                {
                    // Crie uma nova definição de tarefa e atribua propriedades
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Author = "Controller Informática - Controller ERP - " + Usuario;
                    td.RegistrationInfo.Description = DescricaoTarefa;
                    td.RegistrationInfo.Date = DataInicio;
                                        
                    td.Settings.Enabled = true;
                    td.Settings.Hidden = false;
                    td.Settings.RunOnlyIfNetworkAvailable = false;

                    // Crie um gatilho que irá disparar a tarefa nesta hora todos os dias
                    td.Triggers.Add(new DailyTrigger { DaysInterval = (short)FreqAgenda, StartBoundary = DataInicio });

                    // Crie uma ação que iniciará o Bloco de notas sempre que o gatilho for disparado
                    td.Actions.Add(new ExecAction(ProgramaExe, ProgramaArgs, null));

                    // Registra a tarefa na pasta raiz
                    ts.RootFolder.RegisterTaskDefinition(Tarefa, td, TaskCreation.CreateOrUpdate, null, null, TaskLogonType.S4U, "");

                    // Remova a tarefa que acabamos de criar
                    //ts.RootFolder.DeleteTask("Test");

                    result = true;
                }
            }
            catch (Exception ex)
            {
                var erro = ex.Message + "\n" + ex.InnerException;
                Dados.GravaErro(erro);
                return result;
            }

            return result;
        }
        public bool AgendaVerCon()
        {
            bool result = false;
            Dados = new AcessoDados();

            try
            {
                // Get the service on the local machine
                using (TaskService ts = new TaskService())
                {
                    // Crie uma nova definição de tarefa e atribua propriedades
                    TaskDefinition td = ts.NewTask();
                    td.RegistrationInfo.Author = Usuario;
                    td.RegistrationInfo.Description = "Efetua a verificação da conexão com o Banco de Dados a Cada 3 Minutos para Informar o usuário que o Banco de Dados está Online Novamente.";
                    td.RegistrationInfo.Date = DataInicio;

                    td.Principal.RunLevel = TaskRunLevel.Highest;

                    td.Settings.Enabled = true;
                    td.Settings.Hidden = false;
                    td.Settings.RunOnlyIfNetworkAvailable = true;

                    TimeSpan TempoIni = new TimeSpan(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second);

                    // Crie um gatilho que irá disparar a tarefa nesta hora todos os dias
                    td.Triggers.Add(new DailyTrigger { Id = "VerificaBD", DaysInterval = 1, StartBoundary = DataInicio});
                    td.Triggers["VerificaBD"].Repetition.Interval = TimeSpan.FromMinutes(3);
                    td.Triggers["VerificaBD"].Repetition.Duration = TimeSpan.FromHours(24);

                    // Crie uma ação que iniciará o Bloco de notas sempre que o gatilho for disparado
                    ProgramaArgs = "ScriptSQL VerificaBD " + IDConex.Trim();
                    td.Actions.Add(new ExecAction(ProgramaExe, ProgramaArgs, null));

                    // Registra a tarefa na pasta raiz
                    Tarefa = "VerConnBD";
                    ts.RootFolder.RegisterTaskDefinition(Tarefa, td, TaskCreation.CreateOrUpdate, null, null, TaskLogonType.InteractiveToken, "");

                    // Remova a tarefa que acabamos de criar
                    //ts.RootFolder.DeleteTask("Test");

                    result = true;
                }
            }
            catch (Exception ex)
            {
                var erro = ex.Message + "\n" + ex.InnerException;
                Dados.GravaErro(erro);
                return result;
            }

            return result;
        }
        public bool DeleteTask()
        {
            bool feito = false;
            Dados = new AcessoDados();

            try
            {                
                TaskSchedulerClass oAgendador = new TaskSchedulerClass();
                oAgendador.Connect();             
                ITaskFolder containingFolder = oAgendador.GetFolder("\\");
                containingFolder.DeleteTask(Tarefa, 0);

                feito = true;
            }
            catch (Exception ex)
            {
                var erro = ex.Message + "\n" + ex.InnerException;
                Dados.GravaErro(erro);
                feito = false;
            }

            return feito;
        }

        //public bool NovaTarefa()
        //{
        //    bool tudoOk = true;
        //    bool result = false;

        //    try
        //    {
        //        //CarregaVars();
        //        oAgendador = new TaskSchedulerClass();
        //        oAgendador.Connect();

        //        tudoOk = AtribuiDefinicaoTarefa();   //Atribuindo Definição de tarefa           
        //        if (tudoOk)
        //            tudoOk = DefineInformacaoGatilho();  //Definindo a informação do gatilho da tarefa                

        //        if (tudoOk)
        //            tudoOk = DefineInformacaoAcao();     //Definindo a informção da ação da tarefa

        //        if (tudoOk)
        //        {
        //            ITaskFolder root = oAgendador.GetFolder("\\");  //Obtendo a pasta raiz                

        //            //Registrando a tarefa, se a tarefa ja estiver registrada então ela será atualizada
        //            IRegisteredTask regTask = root.RegisterTaskDefinition(
        //                    Tarefa
        //                    , oDefinicaoTarefa
        //                    , (int)_TASK_CREATION.TASK_CREATE_OR_UPDATE
        //                    , null
        //                    , null
        //                    , _TASK_LOGON_TYPE.TASK_LOGON_S4U
        //                    , "");

        //            IRunningTask runtask = regTask.Run(null); //Para executar a tarefa imediatamente chamamos o método Run()

        //            //exibe mensagem
        //            //MessageBox.Show("Tarefa foi criada com sucesso", "Criar Tarefa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            result = true;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var erro = ex.Message + "\n" + ex.InnerException;
        //        Dados.GravaErro(erro);
        //        return result;
        //    }

        //    return result;
        //}

        //private bool AtribuiDefinicaoTarefa()
        //{
        //    bool feito = false;
        //    Dados = new AcessoDados();

        //    try
        //    {
        //        //Registra informação para a tarefa      
        //        oDefinicaoTarefa = oAgendador.NewTask(0);

        //        //nome do autor da tarefa                
        //        oDefinicaoTarefa.RegistrationInfo.Author = Usuario;

        //        //descrição da tarefa
        //        oDefinicaoTarefa.RegistrationInfo.Description = DescricaoTarefa; 

        //        //Registro da data da tarefa
        //        oDefinicaoTarefa.RegistrationInfo.Date = DataInicio.ToString("yyyy-MM-ddTHH:mm:ss"); //formatacao

        //        //oDefinicaoTarefa.Principal.UserId = "SYSTEM";

        //        //oDefinicaoTarefa.Principal.LogonType = _TASK_LOGON_TYPE.TASK_LOGON_S4U;

        //        //Definição da tarefa
        //        //Prioridade da Thread
        //        oDefinicaoTarefa.Settings.Priority = 7;

        //        //Habilita a tarefa
        //        oDefinicaoTarefa.Settings.Enabled = true;

        //        //Para ocultar/exibir a tarefa
        //        oDefinicaoTarefa.Settings.Hidden = false;

        //        //Tempo de execução limite para a tarefa
        //        //oDefinicaoTarefa.Settings.ExecutionTimeLimit = "PT10M"; //10 minutos

        //        //Define que não precisa de conexão de rede
        //        oDefinicaoTarefa.Settings.RunOnlyIfNetworkAvailable = false;

        //        feito = true;

        //    }
        //    catch (Exception ex)
        //    {
        //        var erro = ex.Message + "\n" + ex.InnerException;
        //        Dados.GravaErro(erro);
        //        return feito;
        //    }

        //    return feito;
        //}

        //private bool DefineInformacaoGatilho()
        //{
        //    bool feito = false;
        //    Dados = new AcessoDados();

        //    try
        //    {
        //        //informação do gatilho baseada no tempo - TASK_TRIGGER_TIME
        //        oTrigger = (ITimeTrigger)oDefinicaoTarefa.Triggers.Create(_TASK_TRIGGER_TYPE2.TASK_TRIGGER_TIME);

        //        //Data de Execução
        //        oTrigger.Repetition.Interval = "P" + FreqAgenda + "D";

        //        oTrigger.StartBoundary = DataInicio.ToString("yyyy-MM-ddTHH:mm:ss"); //yyyy-MM-ddTHH:mm:ss
        //        oTrigger.Id = "Trigger_" + Tarefa; //ID do Trigger
        //        feito = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        var erro = ex.Message + "\n" + ex.InnerException;
        //        Dados.GravaErro(erro);
        //        return feito;
        //    }

        //    return feito;
        //}

        //private bool DefineInformacaoAcao()
        //{
        //    bool feito = false;
        //    Dados = new AcessoDados();

        //    try
        //    {
        //        //Informação da Ação baseada no exe- TASK_ACTION_EXEC
        //        oAcao = (IExecAction)oDefinicaoTarefa.Actions.Create(_TASK_ACTION_TYPE.TASK_ACTION_EXEC);

        //        //ID da Ação
        //        oAcao.Id = "acao_" + Tarefa;

        //        //Define o caminho do arquivo EXE a executar (Vamos abrir o Paint)                                                                                 
        //        oAcao.Path = ProgramaExe;
        //        oAcao.Arguments = ProgramaArgs;

        //        feito = true;
        //    }
        //    catch (Exception ex)
        //    {
        //        var erro = ex.Message + "\n" + ex.InnerException;
        //        Dados.GravaErro(erro);
        //        return feito;
        //    }

        //    return feito;
        //}

        //private void btnDeletar_Click(object sender, EventArgs e)
        //{
        //    //try
        //    //{
        //    //    //cria instância do agendador
        //    //    TaskSchedulerClass oAgendador = new TaskSchedulerClass();
        //    //    oAgendador.Connect();
        //    //    //define a pasta raiz
        //    //    ITaskFolder containingFolder = oAgendador.GetFolder("\\");
        //    //    //Deleta a tarefa
        //    //    containingFolder.DeleteTask("_Macoratti_Tarefa", 0);  //da o nome da tarefa que foi criada
        //    //    //MessageBox.Show("Tarefa Deletada...");
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    //MessageBox.Show(ex.Message, "Deletar Tarefa", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    //}
        //}

        //private void CarregaVars()
        //{
        //    Dados = new AcessoDados();
        //    DadosTarefa Agenda = new DadosTarefa();

        //    try
        //    {
        //        Agenda = Dados.GetAgenda(AgendaId, IDConex);

        //        if (Agenda != null)
        //        {
        //            switch (Agenda.AgendaTipo)
        //            {
        //                case 1: //Rebuild Indices do BD
        //                    Tarefa = "Rebuild_Idx_BD";
        //                    Usuario = "Controller_ERP_" + Agenda.UserAgendou;
        //                    DescricaoTarefa = "Executar Scripts no Banco de Dados do Controller ERP para reorganizar os Índices e melhorar a Performance do Sistema.";
        //                    ProgramaExe = @"C:\Controller\Complementos\AtualizaERP\AtualizaERP.exe";
        //                    DataInicio = Agenda.AgendaData;
        //                    TipoAgenda = Agenda.AgendaTipo;
        //                    FreqAgenda = Agenda.AgendaFreq;
        //                    ProgramaArgs = "ScriptSQL RebuildIDX " + IDConex.Trim();
        //                    break;
        //            }
        //        }
        //        else
        //        {
        //            Dados.GravaErro("Não foi possível Carregar os dados da Agenda");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        var erro = ex.Message + "\n" + ex.InnerException;
        //        Dados.GravaErro(erro);
        //    }
        //}

    }
}
