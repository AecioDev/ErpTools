using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtualizaERP.Classes
{
    public class ParamEnt
    {
        public ParamEnt() { }

        public int VersaoCli { get; set; }
        public string DocCliente { get; set; }
        public string IdConex { get; set; }
        public string Opcao { get; set; }
        public string BancoDados { get; set; }
        public string UserBanco { get; set; }
        public string SenhaBD { get; set; }
        public string ServerBD { get; set; }
        public string PastaBD { get; set; }
        public string PastaDest { get; set; }
        public int IdVersao { get; set; }
        public string DescVersao { get; set; }
        public string DataVersao { get; set; }
        public string ImpactBD { get; set; }
        public string UrlVersao { get; set; }
        public string UrlRelease { get; set; }


    }
}
