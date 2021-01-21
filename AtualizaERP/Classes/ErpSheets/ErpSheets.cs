using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AtualizaERP.Classes
{
    class ErpSheets
    {
        public int CodCenCus { get; set; }
        public string IDConex { get; set; }
        public string PatchXml { get; set; }
        public bool GeraCab { get; set; }
        public string ArqExcel { get; set; }
        public string PastaUser { get; set; }
        public string NomeRelat { get; set; }

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

        public ModelEmpresa DadosEmpRel()
        {
            AcessoDados dados = new AcessoDados();

            ModelEmpresa dadosLogo = dados.DadosEmpresa(IDConex, CodCenCus);

            if (CodCenCus == 0)
            {
                if (dadosLogo.logoOk && dadosLogo.logoEmp == null) //Não Pegou a logo na Empresa mas pega no usuário
                {
                    try
                    {
                        var arqlogo = PastaUser + @"\Controller\logoempresa.bmp";
                        FileInfo arqImg = new FileInfo(arqlogo);

                        if (arqImg.Exists)
                        {
                            Image imgLogo = Image.FromFile(arqlogo);
                            using (MemoryStream mStream = new MemoryStream())
                            {
                                imgLogo.Save(mStream, imgLogo.RawFormat);
                                dadosLogo.logoEmp = mStream.ToArray();
                            }
                        }
                        else
                        {
                            dadosLogo.logoOk = false;
                        }
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }

            return dadosLogo;
        }

        public Image GetImagem(byte[] foto)
        {
            Image imgFoto = null;

            MemoryStream ms = new MemoryStream(foto);
            Image image = Image.FromStream(ms);
            imgFoto = image;

            return imgFoto;
        }

        public string ColunaTxt(int col)
        {
            string[] ColunaExcel = new string[100];

            ColunaExcel[1] = "A";
            ColunaExcel[2] = "B";
            ColunaExcel[3] = "C";
            ColunaExcel[4] = "D";
            ColunaExcel[5] = "E";
            ColunaExcel[6] = "F";
            ColunaExcel[7] = "G";
            ColunaExcel[8] = "H";
            ColunaExcel[9] = "I";
            ColunaExcel[10] = "J";
            ColunaExcel[11] = "K";
            ColunaExcel[12] = "L";
            ColunaExcel[13] = "M";
            ColunaExcel[14] = "N";
            ColunaExcel[15] = "O";
            ColunaExcel[16] = "P";
            ColunaExcel[17] = "Q";
            ColunaExcel[18] = "R";
            ColunaExcel[19] = "S";
            ColunaExcel[20] = "T";
            ColunaExcel[21] = "U";
            ColunaExcel[22] = "V";
            ColunaExcel[23] = "W";
            ColunaExcel[24] = "X";
            ColunaExcel[25] = "Y";
            ColunaExcel[26] = "Z";
            ColunaExcel[27] = "AA";
            ColunaExcel[28] = "AB";
            ColunaExcel[29] = "AC";
            ColunaExcel[30] = "AD";
            ColunaExcel[31] = "AE";
            ColunaExcel[32] = "AF";
            ColunaExcel[33] = "AG";
            ColunaExcel[34] = "AH";
            ColunaExcel[35] = "AI";
            ColunaExcel[36] = "AJ";
            ColunaExcel[37] = "AK";
            ColunaExcel[38] = "AL";
            ColunaExcel[39] = "AM";
            ColunaExcel[40] = "AN";
            ColunaExcel[41] = "AO";
            ColunaExcel[42] = "AP";
            ColunaExcel[43] = "AQ";
            ColunaExcel[44] = "AR";
            ColunaExcel[45] = "AS";
            ColunaExcel[46] = "AT";
            ColunaExcel[47] = "AU";
            ColunaExcel[48] = "AV";
            ColunaExcel[49] = "AW";
            ColunaExcel[50] = "AX";
            ColunaExcel[51] = "AY";
            ColunaExcel[52] = "AZ";
            ColunaExcel[53] = "BA";
            ColunaExcel[54] = "BB";
            ColunaExcel[55] = "BC";
            ColunaExcel[56] = "BD";
            ColunaExcel[57] = "BE";
            ColunaExcel[58] = "BF";
            ColunaExcel[59] = "BG";
            ColunaExcel[60] = "BH";
            ColunaExcel[61] = "BI";
            ColunaExcel[62] = "BJ";
            ColunaExcel[63] = "BK";
            ColunaExcel[64] = "BL";
            ColunaExcel[65] = "BM";
            ColunaExcel[66] = "BN";
            ColunaExcel[67] = "BO";
            ColunaExcel[68] = "BP";
            ColunaExcel[69] = "BQ";
            ColunaExcel[70] = "BR";
            ColunaExcel[71] = "BW";
            ColunaExcel[72] = "BT";
            ColunaExcel[73] = "BU";
            ColunaExcel[74] = "BV";
            ColunaExcel[75] = "BW";
            ColunaExcel[76] = "BX";
            ColunaExcel[77] = "BY";
            ColunaExcel[78] = "BZ";

            return ColunaExcel[col];
        }
    }
}