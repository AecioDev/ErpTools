using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using OfficeOpenXml;

namespace AtualizaERP.Classes
{
    class GridNotas : ErpSheets
    {
        private int lnIni = 0, ln = 0;
        private string cel1 = "", cel2 = "";

        public void GeraPlanilha()
        {
            //Define Uso Não Comercial
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            if (!string.IsNullOrEmpty(ArqExcel))
                ArqExcel = PastaUser + @"\Controller\GridNotas.xlsx";

            FileInfo Exfile = new FileInfo(ArqExcel);
            if (Exfile.Exists)
            {
                if (ArquivoEmUso(ArqExcel))
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

            ListaNotas Notas = CarregaXML();

            using (ExcelPackage package = new ExcelPackage(Exfile))
            {
                ExcelWorksheet ws = package.Workbook.Worksheets["Grid Notas"]; //Recupera a planilha para edição.
                OfficeOpenXml.Style.ExcelHorizontalAlignment HCentro = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                OfficeOpenXml.Style.ExcelVerticalAlignment VCentro = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                OfficeOpenXml.Style.ExcelHorizontalAlignment HLeft = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                foreach (Nota nota in Notas.ListaDeNotas)
                {
                    cel1 = "A" + ln; //Tipo de Nota
                    ws.Cells[cel1].Value = nota.destipnot;

                    cel1 = "B" + ln;    //Sequência
                    ws.Cells[cel1].Style.Numberformat.Format = "0";
                    ws.Cells[cel1].Value = nota.nroentsai;

                    cel1 = "C" + ln; //Emissão
                    ws.Cells[cel1].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;

                    string datemientsai = nota.datemientsai.ToShortDateString();
                    if (datemientsai != "0000-00-00")
                    {
                        ws.Cells[cel1].Value = datemientsai;
                    }

                    cel1 = "D" + ln; //Série
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;
                    ws.Cells[cel1].Value = nota.serentsai;

                    cel1 = "E" + ln; //Número
                    ws.Cells[cel1].Style.Numberformat.Format = "0";
                    ws.Cells[cel1].Value = nota.nfentsai;

                    cel1 = "F" + ln; //Código - Cliente/Fornecedor
                    ws.Cells[cel1].Style.Numberformat.Format = "0";
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;
                    ws.Cells[cel1].Value = nota.codclifor;


                    cel1 = "G" + ln; //Nome - Cliente/Fornecedor
                    ws.Cells[cel1].Value = nota.nomentsai;

                    cel1 = "H" + ln; //Valor
                    ws.Cells[cel1].Style.Numberformat.Format = "_-R$ * #.##0,00_-;-R$ * #.##0,00_-;_-R$ * '-'??_-;_-@_-";
                    ws.Cells[cel1].Value = nota.totgerfinentsai;

                    cel1 = "I" + ln; //Status
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    switch (nota.staentsai)
                    {
                        case "A":
                            ws.Cells[cel1].Value = "Atualizada";
                            break;
                        case "D":
                            ws.Cells[cel1].Value = "Digitada";
                            break;
                        case "C":
                            ws.Cells[cel1].Value = "Cancelada";
                            break;
                        case "R":
                            ws.Cells[cel1].Value = "Reprocessada";
                            break;
                        case "P":
                            ws.Cells[cel1].Value = "F. de Caixa";
                            break;
                        case "E":
                            ws.Cells[cel1].Value = "F. de Caixa";
                            break;
                    }

                    cel1 = "J" + ln; //NF Vinculada
                    ws.Cells[cel1].Style.Numberformat.Format = "0";
                    ws.Cells[cel1].Value = nota.nfCupFisEntSai;

                    cel1 = "K" + ln; //Num. RPS
                    ws.Cells[cel1].Style.Numberformat.Format = "0";
                    ws.Cells[cel1].Value = nota.nrorpsentsai;

                    cel1 = "L" + ln; //Num. Pedido
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    ws.Cells[cel1].Value = string.IsNullOrEmpty(nota.infcretercentsai) ? "" : nota.infcretercentsai;

                    cel1 = "M" + ln; //Data Pedido
                    ws.Cells[cel1].Style.Numberformat.Format = "dd/MM/yyyy";
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;
                    ws.Cells[cel1].Value = string.IsNullOrEmpty(nota.infcretercentsai) ? "" : nota.datatufinentsai.ToShortDateString();

                    cel1 = "N" + ln; //Placa
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;
                    ws.Cells[cel1].Value = nota.plaveientsai;

                    cel1 = "O" + ln; //UF
                    ws.Cells[cel1].Style.Numberformat.Format = "@";
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;
                    ws.Cells[cel1].Value = nota.ufplaveientsai;

                    cel1 = "P" + ln; //Código
                    ws.Cells[cel1].Style.Numberformat.Format = "0";
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;
                    ws.Cells[cel1].Value = nota.codtra;

                    cel1 = "Q" + ln; //Transportadora
                    ws.Cells[cel1].Value = nota.nomtra;

                    cel1 = "R" + ln; //Observações
                    ws.Cells[cel1].Value = nota.obsentsai;

                    ln++;
                }

                //Gera as Bordas dos Dados impressos
                cel1 = "A" + lnIni;
                cel2 = "R" + ln;
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

                cel1 = "O" + ln;
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
                ExcelWorksheet ws = pakCab.Workbook.Worksheets.Add("Grid Notas");
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
                ws.Cells[cel1].Value = "Desc. Tipo de Nota";
                ws.Column(1).Width = 30.00D;

                cel1 = "B" + lnIni;
                ws.Cells[cel1].Value = "Sequência";
                ws.Column(2).Width = 10.00D;

                cel1 = "C" + lnIni;
                ws.Cells[cel1].Value = "Emissão";
                ws.Column(3).Width = 12.00D;

                cel1 = "D" + lnIni;
                ws.Cells[cel1].Value = "Série";
                ws.Column(4).Width = 6.00D;

                cel1 = "E" + lnIni;
                ws.Cells[cel1].Value = "Número";
                ws.Column(5).Width = 12.00D;

                cel1 = "F" + lnIni;
                ws.Cells[cel1].Value = "Código";
                ws.Column(6).Width = 7.00D;

                cel1 = "G" + lnIni;
                ws.Cells[cel1].Value = "Nome";
                ws.Column(7).Width = 42.00D;

                cel1 = "H" + lnIni;
                ws.Cells[cel1].Value = "Valor";
                ws.Column(8).Width = 20.00D;

                cel1 = "I" + lnIni;
                ws.Cells[cel1].Value = "Status";
                ws.Column(9).Width = 14.00D;

                cel1 = "J" + lnIni;
                ws.Cells[cel1].Value = "NF Vinculada";
                ws.Column(10).Width = 12.00D;

                cel1 = "K" + lnIni;
                ws.Cells[cel1].Value = "Num. RPS";
                ws.Cells[cel1].Style.WrapText = true;
                ws.Column(11).Width = 12.00D;

                cel1 = "L" + lnIni;
                ws.Cells[cel1].Value = "Num. Pedido";
                ws.Column(12).Width = 15.00D;

                cel1 = "M" + lnIni;
                ws.Cells[cel1].Value = "Data Pedido";
                ws.Column(13).Width = 12.00D;

                cel1 = "N" + lnIni;
                ws.Cells[cel1].Value = "Placa";
                ws.Column(14).Width = 9.00D;

                cel1 = "O" + lnIni;
                ws.Cells[cel1].Value = "UF";
                ws.Column(15).Width = 4.00D;

                cel1 = "P" + lnIni;
                ws.Cells[cel1].Value = "Código";
                ws.Column(16).Width = 7.00D;

                cel1 = "Q" + lnIni;
                ws.Cells[cel1].Value = "Transportadora";
                ws.Column(17).Width = 38.00D;

                cel1 = "R" + lnIni;
                ws.Cells[cel1].Value = "Observações";
                ws.Column(18).Width = 60.00D;
                //Fim dos Campos do Cabeçalho

                //Faz a Formatação do Cabeçalho
                ln = lnIni;
                cel1 = "A" + lnIni;
                cel2 = "R" + lnIni;
                ws.Row(lnIni).Height = 30.00D;
                ws.Cells[cel1 + ":" + cel2].Style.Font.Bold = true;
                ws.Cells[cel1 + ":" + cel2].Style.VerticalAlignment = VCentro;
                ws.Cells[cel1 + ":" + cel2].Style.HorizontalAlignment = HLeft;
                ws.Cells[cel1 + ":" + cel2].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[cel1 + ":" + cel2].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                ws.Cells[cel1 + ":" + cel2].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws.Cells[cel1 + ":" + cel2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick);

                //Alinha os Campos diferentes:
                cel1 = "C" + lnIni; //Emissão e Série
                cel2 = "D" + lnIni;
                ws.Cells[cel1 + ":" + cel2].Style.HorizontalAlignment = HCentro;

                cel1 = "F" + lnIni; //Código
                ws.Cells[cel1].Style.HorizontalAlignment = HCentro;

                cel1 = "I" + lnIni; //Status
                ws.Cells[cel1].Style.HorizontalAlignment = HCentro;

                cel1 = "M" + lnIni; //Data Pedido, Placa e UF
                cel2 = "O" + lnIni;
                ws.Cells[cel1 + ":" + cel2].Style.HorizontalAlignment = HCentro;

                cel1 = "P" + lnIni; //Código
                ws.Cells[cel1].Style.HorizontalAlignment = HCentro;

                //Termina Formatação Cabeçalho

                // Save to file
                pakCab.Save();

            }
        }

        private ListaNotas CarregaXML()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ListaNotas));
            TextReader reader = new StreamReader(PatchXml);
            object obj = deserializer.Deserialize(reader);
            ListaNotas XmlData = (ListaNotas)obj;
            reader.Close();

            return XmlData;
        }

    }
}