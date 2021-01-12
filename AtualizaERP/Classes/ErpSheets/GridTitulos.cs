using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using OfficeOpenXml;

namespace AtualizaERP.Classes
{
    class GridTitulos : ErpSheets
    {
        private int lnIni = 0, ln = 0;
        private string cel1 = "", cel2 = "";
        private string descTerceiro;

        public string tipRel { get; set; }

        public void GeraPlanilha()
        {
            //Define Uso Não Comercial
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            if (!string.IsNullOrEmpty(ArqExcel))
                ArqExcel = PastaUser + @"\Controller\GridTitulos.xlsx";

            FileInfo Exfile = new FileInfo(ArqExcel);                        
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

            CabecalhoGeral();

            //msg('Gerando a Planilha por favor aguarde...', nowait)

            lnIni += 1; //Ajusta a Linha Inicial dos Dados para usar no final.
            ln = lnIni; //Variável que será utilizada na geração dos dados.

            ListaTitulos Titulos = CarregaXML();

            using (ExcelPackage package = new ExcelPackage(Exfile))
            {
                ExcelWorksheet ws = package.Workbook.Worksheets["Grid Titulos"]; //Recupera a planilha para edição.
                OfficeOpenXml.Style.ExcelHorizontalAlignment HCentro = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                OfficeOpenXml.Style.ExcelVerticalAlignment VCentro = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                OfficeOpenXml.Style.ExcelHorizontalAlignment HLeft = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                foreach (Titulo titulo in Titulos.ListaDeTitulos)
                {
                    cel1 = "A" + ln; //Sequencia
                    ws.Cells[cel1].Style.Numberformat.Format = "0";
                    ws.Cells[cel1].Value = titulo.seqtit;

                    cel1 = "B" + ln; //Emissão
                    ws.Cells[cel1].Style.Numberformat.Format = "dd/mm/yyyy";
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;

                    string emitit = titulo.emitit.ToShortDateString();
                    if (emitit != "0000-00-00")
                    {
                        ws.Cells[cel1].Value = emitit;
                    }

                    cel1 = "C" + ln; //Documento 
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    ws.Cells[cel1].Value = titulo.numdoctit;

                    cel1 = "D" + ln; //Parcela
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    ws.Cells[cel1].Value = titulo.txtpartit;

                    cel1 = "E" + ln; //Código - Cliente/Fornecedor
                    ws.Cells[cel1].Style.Numberformat.Format = "0";
                    ws.Cells[cel1].Value = titulo.codclifor;

                    cel1 = "F" + ln; //Nome - Cliente/Fornecedor
                    ws.Cells[cel1].Value = titulo.nomclifor;

                    cel1 = "G" + ln; //Data de Vencimento do Título
                    ws.Cells[cel1].Style.Numberformat.Format = "dd/mm/yyyy";
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;

                    string datventit = titulo.datventit.ToShortDateString();
                    if (datventit != "0000-00-00")
                    {
                        ws.Cells[cel1].Value = datventit;
                    }

                    cel1 = "H" + ln; //Valor
                    ws.Cells[cel1].Style.Numberformat.Format = "_-R$ * #.##0,00_-;_-R$ * '-'??_-;_-@_-";
                    ws.Cells[cel1].Value = titulo.valtit;

                    cel1 = "I" + ln; //Saldo
                    ws.Cells[cel1].Style.Numberformat.Format = "_-R$ * #.##0,00_-;_-R$ * '-'??_-;_-@_-"; //"_-R$ * #.##0,00_-;-R$ * #.##0,00_-;_-R$ * '-'??_-;_-@_-";
                    ws.Cells[cel1].Value = titulo.saltit;

                    cel1 = "J" + ln; //Dias
                    ws.Cells[cel1].Style.Numberformat.Format = "0";
                    ws.Cells[cel1].Value = titulo.diasventit;

                    cel1 = "K" + ln; //Último Pagamento  
                    ws.Cells[cel1].Style.Numberformat.Format = "dd/mm/yyyy";
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;
                    
                    string datultpag = titulo.datultpag;
                    if (datultpag != "0000-00-00")
                        {
                        ws.Cells[cel1].Value = datultpag;
                        }

                    cel1 = "L" + ln; //Nosso Número
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    ws.Cells[cel1].Value = titulo.numbantit;

                    cel1 = "M" + ln; //Código
                    ws.Cells[cel1].Style.Numberformat.Format = "0";
                    ws.Cells[cel1].Value = titulo.codventit;

                    cel1 = "N" + ln; //Vendedor
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    ws.Cells[cel1].Value = titulo.nomventit;

                    cel1 = "O" + ln; //Código
                    ws.Cells[cel1].Style.Numberformat.Format = "0";
                    ws.Cells[cel1].Value = titulo.codloccob;

                    cel1 = "P" + ln; //Local de Cobrança
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    ws.Cells[cel1].Value = titulo.desloccob;

                    cel1 = "Q" + ln; //Espécie
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    ws.Cells[cel1].Value = titulo.espdoctit;

                    cel1 = "R" + ln; //Aceite
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    ws.Cells[cel1].Value = titulo.acestatit;

                    cel1 = "S" + ln; //Data Aceite
                    ws.Cells[cel1].Style.Numberformat.Format = "dd/mm/yyyy";
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;

                    string acedattit = titulo.acedattit;
                    if (acedattit != "0000-00-00")
                    {
                        ws.Cells[cel1].Value = acedattit;
                    }

                    cel1 = "T" + ln; //Usuário Aceite
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    ws.Cells[cel1].Value = titulo.aceusutit;

                    cel1 = "U" + ln; //Título Renegociado
                    ws.Cells[cel1].Style.Numberformat.Format = "0";
                    ws.Cells[cel1].Value = titulo.renorig;

                    cel1 = "V" + ln; //Vencimento Original
                    ws.Cells[cel1].Style.Numberformat.Format = "dd/mm/yyyy";
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;

                    string ventit = titulo.ventit.ToShortDateString();
                    if (ventit != "0000-00-00")
                    {
                        ws.Cells[cel1].Value = ventit;
                    }

                    cel1 = "W" + ln; //Referência Cliente
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    ws.Cells[cel1].Value = titulo.codimpcli;

                    cel1 = "X" + ln; //CPF/CNPJ
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    ws.Cells[cel1].Value = titulo.cnpjclifor;

                    cel1 = "Y" + ln; //Observações
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    ws.Cells[cel1].Value = titulo.obstit;

                    ln++;
                }

                //Gera as Bordas dos Dados impressos
                cel1 = "A" + lnIni;
                cel2 = "Y" + ln;
                ws.Cells[cel1 + ":" + cel2].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws.Cells[cel1 + ":" + cel2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick);

                ln++;

                //Finaliza o Rodapé    
                cel1 = "A" + ln;
                cel2 = "D" + ln;
                ws.Cells[cel1 + ":" + cel2].Merge = true;
                ws.Cells[cel1].Style.Font.Bold = true;
                ws.Cells[cel1].Value = "Relatório " + NomeRelat;
                ws.Cells[cel1].Style.HorizontalAlignment = HLeft;

                cel1 = "Q" + ln;
                cel2 = "R" + ln;
                ws.Cells[cel1 + ":" + cel2].Merge = true;
                ws.Cells[cel1].Style.Font.Bold = true;
                ws.Cells[cel1].Value = "CONTROLLER - ERP";
                ws.Cells[cel1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;

                // Save to file
                package.Save();
            }

        }

        private void CabecalhoGeral()
        {            
            string dataAtual = DateTime.Now.ToShortDateString();
            string horaAtual = DateTime.Now.ToShortTimeString();
            ModelEmpresa dadosRel = new ModelEmpresa();

            dadosRel = DadosEmpRel();

            FileInfo ExCab = new FileInfo(ArqExcel);
            using (ExcelPackage pakCab = new ExcelPackage(ExCab))
            {
                ExcelWorksheet ws = pakCab.Workbook.Worksheets.Add("Grid Titulos");
                OfficeOpenXml.Style.ExcelHorizontalAlignment HCentro = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                OfficeOpenXml.Style.ExcelVerticalAlignment VCentro = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                OfficeOpenXml.Style.ExcelHorizontalAlignment HLeft = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                
                lnIni = 1;
                if (GeraCab)
                {
                    if (dadosRel.logoOk) //Adiciona a Logo
                    {
                        Image LogoEmp = GetImagem(dadosRel.logoEmp);

                        ws.Cells["A1:A5"].Merge = true;
                        OfficeOpenXml.Drawing.ExcelPicture picture = ws.Drawings.AddPicture("0", LogoEmp);
                        picture.From.Column = 0;
                        picture.SetPosition(3, 3);
                        picture.SetSize(205, 105);
                    }
                                        
                    //Controller                
                    ws.Cells["B1:Q2"].Merge = true;
                    ws.Cells["B1"].Value = "CONTROLLER ERP";
                    ws.Cells["B1"].Style.HorizontalAlignment = HCentro;
                    ws.Cells["B1"].Style.VerticalAlignment = VCentro;
                    ws.Cells["B1"].Style.Font.Size = 18;
                    ws.Cells["B1"].Style.Font.Bold = true;
                    ws.Cells["B1"].Style.Font.Name = "Calibri";

                    //Data
                    ws.Cells["R1"].Value = "Data: " + dataAtual;
                    ws.Cells["R1"].Style.Font.Bold = true;
                    ws.Cells["R1"].Style.HorizontalAlignment = HCentro;

                    //Hora
                    ws.Cells["R2"].Value = "Hora: " + horaAtual;
                    ws.Cells["R2"].Style.Font.Bold = true;
                    ws.Cells["R2"].Style.HorizontalAlignment = HCentro;

                    //Nome da Empresa
                    ws.Cells["B3:Q3"].Merge = true;
                    ws.Cells["B3"].Value = dadosRel.nomeEmp.ToUpper();
                    ws.Cells["B3"].Style.HorizontalAlignment = HCentro;
                    ws.Cells["B3"].Style.VerticalAlignment = VCentro;
                    ws.Cells["B3"].Style.Font.Size = 16;
                    ws.Cells["B3"].Style.Font.Bold = true;
                    ws.Cells["B3"].Style.Font.Name = "Calibri";

                    //Nome do Relatório 
                    ws.Cells["B4:Q4"].Merge = true;
                    ws.Cells["B4"].Value = NomeRelat.ToUpper();
                    ws.Cells["B4"].Style.HorizontalAlignment = HCentro;
                    ws.Cells["B4"].Style.VerticalAlignment = VCentro;
                    ws.Cells["B4"].Style.Font.Size = 14;
                    ws.Cells["B4"].Style.Font.Bold = true;
                    ws.Cells["B4"].Style.Font.Name = "Calibri";

                    lnIni = 6;
                }

                    //Nome e Tamanho das Colunas do Cabeçalho                
                    cel1 = "A" + lnIni;
                    ws.Cells[cel1].Value = "Sequência";
                    ws.Column(1).Width = 10.00D;

                    cel1 = "B" + lnIni;
                    ws.Cells[cel1].Value = "Emissão";
                    ws.Column(2).Width = 12.00D;

                    cel1 = "C" + lnIni;
                    ws.Cells[cel1].Value = "Documento";
                    ws.Column(3).Width = 20.00D;

                    cel1 = "D" + lnIni;
                    ws.Cells[cel1].Value = "Parcela";
                    ws.Column(4).Width = 7.00D;

                    cel1 = "E" + lnIni;
                    ws.Cells[cel1].Value = "Código";
                    ws.Column(5).Width = 8.00D;

                    cel1 = "F" + lnIni;
                    descTerceiro = (tipRel == "R") ? "Cliente" : "Fornecedor";
                    ws.Cells[cel1].Value = descTerceiro;
                    ws.Column(6).Width = 40.00D;

                    cel1 = "G" + lnIni;
                    ws.Cells[cel1].Value = "Vencimento";
                    ws.Column(7).Width = 12.00D;

                    cel1 = "H" + lnIni;
                    ws.Cells[cel1].Value = "Valor";
                    ws.Column(8).Width = 18.00D;

                    cel1 = "I" + lnIni;
                    ws.Cells[cel1].Value = "Saldo";
                    ws.Column(9).Width = 18.00D;

                    cel1 = "J" + lnIni;
                    ws.Cells[cel1].Value = "Dias";
                    ws.Column(10).Width = 8.00D;

                    cel1 = "K" + lnIni;
                    ws.Cells[cel1].Value = "Último Pagamento";
                    ws.Cells[cel1].Style.WrapText = true;
                    ws.Column(11).Width = 12.00D;

                    cel1 = "L" + lnIni;
                    ws.Cells[cel1].Value = "Nosso Número";
                    ws.Column(12).Width = 22.00D;

                    cel1 = "M" + lnIni;
                    ws.Cells[cel1].Value = "Código";
                    ws.Column(13).Width = 8.00D;

                    cel1 = "N" + lnIni;
                    ws.Cells[cel1].Value = "Vendedor";
                    ws.Column(14).Width = 30.00D;

                    cel1 = "O" + lnIni;
                    ws.Cells[cel1].Value = "Código";
                    ws.Column(15).Width = 8.00D;

                    cel1 = "P" + lnIni;
                    ws.Cells[cel1].Value = "Local de Cobrança";
                    ws.Column(16).Width = 30.00D;

                    cel1 = "Q" + lnIni;
                    ws.Cells[cel1].Value = "Espécie";
                    ws.Column(17).Width = 18.00D;

                    cel1 = "R" + lnIni;
                    ws.Cells[cel1].Value = "Aceite?";
                    ws.Column(18).Width = 18.00D;

                    cel1 = "S" + lnIni;
                    ws.Cells[cel1].Value = "Data Aceite";
                    ws.Column(19).Width = 12.00D;

                    cel1 = "T" + lnIni;
                    ws.Cells[cel1].Value = "Usuário Aceite";
                    ws.Column(20).Width = 14.00D;

                    cel1 = "U" + lnIni;
                    ws.Cells[cel1].Value = "Título Renegociado";
                    ws.Column(21).Width = 18.00D;

                    cel1 = "V" + lnIni;
                    ws.Cells[cel1].Value = "Vencimento Original";
                    ws.Column(22).Width = 20.00D;

                    cel1 = "W" + lnIni;
                    ws.Cells[cel1].Value = "Referência " +descTerceiro;
                    ws.Column(23).Width = 22.00D;

                    cel1 = "X" + lnIni;
                    ws.Cells[cel1].Value = "CPF/CNPJ";
                    ws.Column(24).Width = 18.00D;

                    cel1 = "Y" + lnIni;
                    ws.Cells[cel1].Value = "Observações";
                    ws.Column(25).Width = 60.00D;

                //Fim dos Campos do Cabeçalho

                //Faz a Formatação do Cabeçalho
                ln = lnIni;
                cel1 = "A" + lnIni;
                cel2 = "Y" + lnIni;
                ws.Row(lnIni).Height = 30.00D;
                ws.Cells[cel1 + ":" + cel2].Style.Font.Bold = true;
                ws.Cells[cel1 + ":" + cel2].Style.VerticalAlignment = VCentro;
                ws.Cells[cel1 + ":" + cel2].Style.HorizontalAlignment = HLeft;
                ws.Cells[cel1 + ":" + cel2].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[cel1 + ":" + cel2].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                ws.Cells[cel1 + ":" + cel2].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws.Cells[cel1 + ":" + cel2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick);

                //Termina Formatação Cabeçalho

                // Save to file
                pakCab.Save();

            }
        }

        private ListaTitulos CarregaXML()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ListaTitulos));
            TextReader reader = new StreamReader(PatchXml);
            object obj = deserializer.Deserialize(reader);
            ListaTitulos XmlData = (ListaTitulos)obj;
            reader.Close();

            return XmlData;
        }

    }
}
