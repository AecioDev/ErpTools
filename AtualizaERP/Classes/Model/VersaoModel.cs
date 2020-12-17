using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtualizaERP.Classes
{
    public class VersaoModel
    {
        public VersaoModel() { }

        public int IdVersao { get; set; }
        public int CodVersao { get; set; }
        public string DescVersao { get; set; }
        public string DataVersao { get; set; }
        public string ImpactDB { get; set; }
        public string URLVersao { get; set; }
        public string URLRelease { get; set; }

        public VersaoModel(int _idVersao, int _codVersao, string _descVersao, string _dataversao, string _impactdb, string _urlversao, string _urlrelease)
        {
            IdVersao = _idVersao;
            CodVersao = _codVersao;
            DescVersao = _descVersao;
            DataVersao = _dataversao;
            ImpactDB = _impactdb;
            URLVersao = _urlversao;
            URLRelease = _urlrelease;
        }

    }
}
