using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtualizaERP.Classes
{
    public class DadosTarefa
    {
        public DadosTarefa() {}

        public int AgendaId { get; set; }
        public int AgendaTipo { get; set; }
        public DateTime AgendaData { get; set; }
        public int AgendaFreq { get; set; }
        public string AgendaStatus { get; set; }
        public string DescStatusAgd { get; set; }
        public string UserAgendou { get; set; }

        public DadosTarefa(int _agdId, int _agdTipo, DateTime _agdData, int _agdFreq, string _agdStatus, string _agdDescSts, string _agdUser)
        {
            AgendaId = _agdId;
            AgendaTipo = _agdTipo;
            AgendaData = _agdData;
            AgendaFreq = _agdFreq;
            AgendaStatus = _agdStatus;
            DescStatusAgd = _agdDescSts;
            UserAgendou = _agdUser;
        }
    }

}
