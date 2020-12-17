using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtualizaERP.Classes
{
    public class AcessosModel
    {
        public AcessosModel() { }

        public string HostName { get; set; }
        public string DbName { get; set; }

        public AcessosModel(string _host, string _banco)
        {
            HostName = _host;
            DbName = _banco;
        }
    }
}
