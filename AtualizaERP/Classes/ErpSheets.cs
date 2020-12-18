using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AtualizaERP.Classes
{
    class ErpSheets
    {
        public bool ArquivoEmUso(string caminhoArquivo)
        {
            try
            {
               FileStream fs = File.OpenWrite(caminhoArquivo);
                fs.Close();
                return false;
            }
            catch (Exception)
            {
                return true;
            }

        }

    }
}
