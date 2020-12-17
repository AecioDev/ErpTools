using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtualizaERP.Classes
{
    public class DadosCliente
    {
        public DadosCliente() { }
                
        public int ClienteId { get; set; }
        public string DocCliente { get; set; }
        public string NomeCliente { get; set; }
        public string SerieCliente { get; set; }
        public int VersaoCliente { get; set; }
        public DateTime DataAtualizacao { get; set; }

        public DadosCliente(int _cliId, string _docCli, string _nomCli, string _serCli, int _verCli, DateTime _datVerCli)
        {
            ClienteId = _cliId;
            DocCliente = _docCli;
            NomeCliente = _nomCli;
            SerieCliente = _serCli;
            VersaoCliente = _verCli;
            DataAtualizacao = _datVerCli;
        }
    }
}
