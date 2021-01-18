using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using OfficeOpenXml;

namespace AtualizaERP.Classes
{
    class PlanOrcamentario : ErpSheets
    {
        private int lnIni = 0, ln = 0;
        private string cel1 = "", cel2 = "";
        private string descTerceiro;
        private string cabmes, mesChar;
        private int mesVez = 0, AnoVez = 0, NumMeses = 0;

        public string tipRel { get; set; }

        public void GeraPlanilha()
        {
            //Define Uso Não Comercial
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            if (!string.IsNullOrEmpty(ArqExcel))
                ArqExcel = PastaUser + @"\Controller\Planejamento_Orçamentário.xlsx";

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

            ListaPlanejamento Planejamentos = CarregaXML();

            using (ExcelPackage package = new ExcelPackage(Exfile))
            {
                ExcelWorksheet ws = package.Workbook.Worksheets["Planejamento Orçamentário"]; //Recupera a planilha para edição.
                OfficeOpenXml.Style.ExcelHorizontalAlignment HCentro = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                OfficeOpenXml.Style.ExcelVerticalAlignment VCentro = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                OfficeOpenXml.Style.ExcelHorizontalAlignment HLeft = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                foreach (Plano Plano in Planejamentos.ListaDePlanejamentos)
                {
        









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
                ws.Cells[cel1].Value = "ESTRUTURA";
                ws.Column(1).Width = 14.00D;

                cel1 = "B" + lnIni;
                ws.Cells[cel1].Value = "CÓDIGO";
                ws.Column(2).Width = 10.00D;

                cel1 = "C" + lnIni;
                ws.Cells[cel1].Value = "NOMENCLATURA";
                ws.Column(3).Width = 50.00D;

               cabmes = mesChar + AnoVez.ToString();

                //foreach XMes = 1 in NumMeses
                //    cabmes = trim(str(&MesVez)) + '/' + trim(str(&AnoVez))
                //    call(PAjusTXT, &cabmes, 7, 'D', '0', &CabChar)
                //    VB ws.Cells([!&Linhas!], [!&ColExcel!]).Value = [!&CabChar!]
                //    & LinhaAbaixo = &Linhas + 1
                //    if &IncProj = 'S'
                //       VB ws.Cells([!&LinhaAbaixo!], [!&ColExcel!]).ColumnWidth = 12
                //       VB ws.Cells([!&LinhaAbaixo!], [!&ColExcel!]).Value = [!&Previsto!]
                //       & ColExcel = &ColExcel + 1
                //    endif
                //    if &IncReal = 'S'
                //       VB ws.Cells([!&LinhaAbaixo!], [!&ColExcel!]).ColumnWidth = 12
                //       VB ws.Cells([!&LinhaAbaixo!], [!&ColExcel!]).Value = [!&Realizado!]
                //       & ColExcel = &ColExcel + 1
                //    endif
                //    if &IncDif = 'S'.and. & IncProj = 'S'.and. & IncReal = 'S'
                //       VB ws.Cells([!&LinhaAbaixo!], [!&ColExcel!]).ColumnWidth = 12
                //       VB ws.Cells([!&LinhaAbaixo!], [!&ColExcel!]).Value = [!&Diferenca!]
                //       & ColExcel = &ColExcel + 1
                //    endif
                //    & MesVez = &MesVez + 1
                //    if &MesVez > 12
                //       & MesVez = 1
                //       & AnoVez = &AnoVez + 1
                //    endif
                //endfor

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
                ws.Cells[cel1].Value = "Referência " + descTerceiro;
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

        private ListaPlanejamento CarregaXML()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ListaPlanejamento));
            TextReader reader = new StreamReader(PatchXml);
            object obj = deserializer.Deserialize(reader);
            ListaPlanejamento XmlData = (ListaPlanejamento)obj;
            reader.Close();

            return XmlData;
        }

    }
}