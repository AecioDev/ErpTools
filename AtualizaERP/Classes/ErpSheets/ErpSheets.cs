using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

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

            var dadosLogo = dados.DadosEmpresa(IDConex, CodCenCus);

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
            imgFoto = Image.FromStream(ms);

            return imgFoto;
        }
    }
}
