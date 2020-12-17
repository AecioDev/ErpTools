using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AtualizaERP.Classes
{
    public class ConexaoERP
    {
        public ConexaoERP() { }

        public int ClienteId { get; set; }
        public int ConexaoId { get; set; }

        public string Servidor { get; set; }
        public string BancoDados { get; set; }
        public string Usuario { get; set; }
        public string SenhaCript { get; set; }
        public string KeyString { get; set; }
        public string SenhaBD { get; set; }
        public string ServerMirror { get; set; }
        public string PastaBD { get; set; }
        public string PastaBackup { get; set; }

        public string StringConexao { get; set; }

        //public ConexaoERP(string _databaseName, string _userName, string _password, string _serverName, string _patchBackup, string _destinationPath)
        //{
        //    BancoDados = _databaseName;
        //    Servidor = _serverName;
        //    Usuario = _userName;
        //    SenhaCript = _password;
        //    PastaBackup = _patchBackup;
        //    PastaDestino = _destinationPath;
        //}
    }
}
