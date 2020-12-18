using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using OfficeOpenXml;
using Excel = Microsoft.Office.Interop.Excel;

namespace AtualizaERP.Classes
{
    class GridNotas : ErpSheets
    {
        public void GeraPlanilha(int CodCenCus, string PatchXml)
        {            
            //Define Uso Não Comercial
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            string PastaUser = Environment.GetEnvironmentVariable("USERPROFILE");
            string ArqExcel = PastaUser + @"\Controller\GridNotas.xlsx";

            var Exfile = new FileInfo(ArqExcel);

            //Verifica se a planilha está aberta.
            /*VB If IsFileOpen([!&arqExcel!]) Then
            VB     MsgBox "Parece que a Planilha já esta Aberta! É necessário fechá-la antes de gerar uma nova.", vbOKOnly + vbInformation, "Ops! Algo deu Errado."
                   return
            VB Else
                   & ret = deletefile(&arqExcel)
            VB End If*/
            if (Exfile.Exists)
            {
                if(ArquivoEmUso(ArqExcel))
                {
                    MessageBox.Show("Parece que a Planilha já esta Aberta! É necessário fechá-la antes de gerar uma nova.", "Ops! Algo deu Errado.", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
                else
                {
                    Exfile.Delete();
                }
            }

            using (var package = new ExcelPackage(Exfile))
            {
                var sheet = package.Workbook.Worksheets.Add("Grid Notas");

                sheet.Cells["A1"].Value = "Hello World!";

                // Save to file
                package.Save();
            }

        }
    }
}
