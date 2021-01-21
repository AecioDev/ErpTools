using System;
using System.Drawing;
using System.IO;
using System.Windows;
using System.Xml.Serialization;
using AtualizaERP.Telas;
using OfficeOpenXml;

namespace AtualizaERP.Classes
{
    class PlanOrcamentario : ErpSheets
    {
        private int CenCus;
        private int AnoOrc;
        private int MesIni;
        private int NumMeses;
        private string VerPrevisto;
        private string VerRealizado;
        private string VerDiferenca;

        private int ln = 0;
        private int lnIni = 0;
        private string cel1;
        private string cel2;
        private int ColExcel;

        GeraPlanilha Form;

        public PlanOrcamentario(string parametros, GeraPlanilha _form)
        {
            var Parm = parametros.Split(';');

            if (!string.IsNullOrEmpty(Parm[0]))
                CenCus = Convert.ToInt32(Parm[0]);

            if (!string.IsNullOrEmpty(Parm[1]))
                AnoOrc = Convert.ToInt32(Parm[1]);

            if (!string.IsNullOrEmpty(Parm[2]))
                MesIni = Convert.ToInt32(Parm[2]);

            if (!string.IsNullOrEmpty(Parm[3]))
                NumMeses = Convert.ToInt32(Parm[3]);

            VerPrevisto = Parm[4];
            VerRealizado = Parm[5];
            VerDiferenca = Parm[6];

            Form = _form;
        }


        public void GeraPlanilha()
        {
            //Define Uso Não Comercial
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            string[] dadosMes = {"","",""};
            string[] dadosTotal = { "", "", "" };
            string[] dadosMedia = { "", "", "" };
            string[] dadosReceita = { "", ""};
            

            if (string.IsNullOrEmpty(ArqExcel))
                ArqExcel = PastaUser + @"\Controller\Planej_Orcamentario.xlsx";

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
                ExcelWorksheet ws = package.Workbook.Worksheets["PlanOrc"]; //Recupera a planilha para edição.
                OfficeOpenXml.Style.ExcelHorizontalAlignment HCentro = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                OfficeOpenXml.Style.ExcelVerticalAlignment VCentro = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                OfficeOpenXml.Style.ExcelHorizontalAlignment HLeft = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
                OfficeOpenXml.Style.ExcelHorizontalAlignment HRight = OfficeOpenXml.Style.ExcelHorizontalAlignment.Right;

                foreach (Plano dadosPlano in Planejamentos.ListaDePlanejamentos)
                {                    
                    Form.lb_progress.Text = dadosPlano.Estrutura.ToUpper() + " - " + dadosPlano.Nomenclatura.ToUpper().Trim();
                    Form.lb_progress.Refresh();

                    if (ln == lnIni) //Primeiro Registro
                    {
                        ws.Cells[ln, 202].Value = dadosPlano.coluna202.Trim();
                    }

                    //Descrição Contas Plano
                    cel1 = "A" + ln; //ESTRUTURA
                    ws.Cells[cel1].Style.HorizontalAlignment = HRight;
                    ws.Cells[cel1].Value = dadosPlano.Estrutura.ToUpper();

                    cel1 = "B" + ln; //CÓDIGO
                    ws.Cells[cel1].Style.Numberformat.Format = "0";
                    ws.Cells[cel1].Value = dadosPlano.Codigo;

                    cel1 = "C" + ln; //DESCRIÇÃO
                    ws.Cells[cel1].Style.HorizontalAlignment = HLeft;
                    ws.Cells[cel1].Value = dadosPlano.Nomenclatura.ToUpper().Trim();

                    #region //Gera os SubTotais Primeiro
                    if (dadosPlano.dessubtot != "")
                    {
                        ws.Cells[ln, 3].Value = dadosPlano.dessubtot.Trim();

                        //Gera os SubTotais
                        #region Gera Os Meses
                        ColExcel = 4;
                        for (int xMes = 1; xMes <= NumMeses; xMes++)
                        {
                            dadosMes = VerDadosMes(xMes, "S", dadosPlano);

                            if (VerPrevisto == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Value = dadosMes[0].Trim();
                                ColExcel++;
                            }

                            if (VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Value = dadosMes[1].Trim();
                                ColExcel++;
                            }

                            if (VerDiferenca == "S" && VerPrevisto == "S" && VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosMes[2].Trim();
                                ColExcel++;
                            }

                        }
                        #endregion

                        #region Gera os Totais dos Meses
                        if (NumMeses > 1)
                        {
                            dadosTotal = dadosPlano.subTotGer.Split('|');

                            if (VerPrevisto == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosTotal[0].Trim();
                                ColExcel++;
                            }

                            if (VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosTotal[1].Trim();
                                ColExcel++;
                            }

                            if (VerDiferenca == "S" && VerPrevisto == "S" && VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosTotal[2].Trim();
                                ColExcel++;
                            }

                            dadosMedia = dadosPlano.subTotMed.Split('|');

                            if (VerPrevisto == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosMedia[0].Trim();
                                ColExcel++;
                            }

                            if (VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosMedia[1].Trim();
                                ColExcel++;
                            }

                            if (VerDiferenca == "S" && VerPrevisto == "S" && VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosMedia[2].Trim();
                                ColExcel++;
                            }
                        }
                        #endregion

                        #region Gera a Receita
                        dadosReceita = dadosPlano.subTotRec.Split('|');

                        if (VerPrevisto == "S")
                        {
                            ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                            ws.Cells[ln, ColExcel].Formula = dadosReceita[0].Trim();
                            ColExcel++;
                        }

                        if (VerRealizado == "S")
                        {
                            ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                            ws.Cells[ln, ColExcel].Formula = dadosReceita[1].Trim();
                            ColExcel++;
                        }
                        #endregion
                    }
                    #endregion

                    if (dadosPlano.Codigo > 0 && dadosPlano.coluna200 == "S")
                    {
                        #region Gera Os Meses
                        ColExcel = 4;
                        for (int xMes = 1; xMes <= NumMeses; xMes++)
                        {
                            dadosMes = VerDadosMes(xMes, "V", dadosPlano);

                            if (VerPrevisto == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Value = (!string.IsNullOrEmpty(dadosMes[0].Trim()) ? Convert.ToInt32(dadosMes[0].Trim()) : 0);
                                ColExcel++;
                            }

                            if (VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Value = (!string.IsNullOrEmpty(dadosMes[1].Trim()) ? Convert.ToInt32(dadosMes[1].Trim()) : 0);
                                ColExcel++;
                            }

                            if (VerDiferenca == "S" && VerPrevisto == "S" && VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosMes[2].Trim();
                                ColExcel++;
                            }
                        }
                        #endregion

                        #region Gera os Totais dos Meses
                        if (NumMeses > 1)
                        {
                            dadosTotal = dadosPlano.totalGeral.Split('|');

                            if (VerPrevisto == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosTotal[0].Trim();
                                ColExcel++;
                            }

                            if (VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosTotal[1].Trim();
                                ColExcel++;
                            }

                            if (VerDiferenca == "S" && VerPrevisto == "S" && VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosTotal[2].Trim();
                                ColExcel++;
                            }

                            dadosMedia = dadosPlano.mediaGeral.Split('|');

                            if (VerPrevisto == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosMedia[0].Trim();
                                ColExcel++;
                            }

                            if (VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosMedia[1].Trim();
                                ColExcel++;
                            }

                            if (VerDiferenca == "S" && VerPrevisto == "S" && VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosMedia[2].Trim();
                                ColExcel++;
                            }
                        }
                        #endregion

                        #region Gera a Receita
                        if (!string.IsNullOrEmpty(dadosPlano.receitaGeral))
                        {
                            dadosReceita = dadosPlano.receitaGeral.Split('|');

                            if (VerPrevisto == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosReceita[0].Trim();
                                ColExcel++;
                            }

                            if (VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Formula = dadosReceita[1].Trim();
                                ColExcel++;
                            }
                        }
                        #endregion
                    }
                    else
                    {
                        //Gera os Totais do Grupo
                        #region Gera Os Meses
                        ColExcel = 4;
                        for (int xMes = 1; xMes <= NumMeses; xMes++)
                        {                            
                            dadosMes = VerDadosMes(xMes, "T", dadosPlano);

                            if (VerPrevisto == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Style.Font.Bold = true;
                                ws.Cells[ln, ColExcel].Formula = dadosMes[0];
                                ColExcel++;
                            }

                            if (VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Style.Font.Bold = true;
                                ws.Cells[ln, ColExcel].Formula = dadosMes[1];
                                ColExcel++;
                            }

                            if (VerDiferenca == "S" && VerPrevisto == "S" && VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Style.Font.Bold = true;
                                ws.Cells[ln, ColExcel].Formula = dadosMes[2];
                                ColExcel++;
                            }

                        }
                        #endregion

                        #region Gera os Totais dos Meses dos Totais
                        if (NumMeses > 1)
                        {
                            //Total dos Totais dos Meses
                            dadosTotal = dadosPlano.totalGeral.Split('|');

                            if (VerPrevisto == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Style.Font.Bold = true;
                                ws.Cells[ln, ColExcel].Formula = dadosTotal[0].Trim();
                                ColExcel++;
                            }

                            if (VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Style.Font.Bold = true;
                                ws.Cells[ln, ColExcel].Formula = dadosTotal[1].Trim();
                                ColExcel++;
                            }

                            if (VerDiferenca == "S" && VerPrevisto == "S" && VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Style.Font.Bold = true;
                                ws.Cells[ln, ColExcel].Formula = dadosTotal[2].Trim();
                                ColExcel++;
                            }

                            //Media dos Totais dos Meses
                            dadosMedia = dadosPlano.mediaGeral.Split('|');

                            if (VerPrevisto == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Style.Font.Bold = true;
                                ws.Cells[ln, ColExcel].Formula = dadosMedia[0].Trim();
                                ColExcel++;
                            }

                            if (VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Style.Font.Bold = true;
                                ws.Cells[ln, ColExcel].Formula = dadosMedia[1].Trim();
                                ColExcel++;
                            }

                            if (VerDiferenca == "S" && VerPrevisto == "S" && VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Style.Font.Bold = true;
                                ws.Cells[ln, ColExcel].Formula = dadosMedia[2].Trim();
                                ColExcel++;
                            }
                        }
                        #endregion

                        #region Gera a Receita dos Totais
                        if (!string.IsNullOrEmpty(dadosPlano.receitaGeral))
                        {
                            dadosReceita = dadosPlano.receitaGeral.Split('|');

                            if (VerPrevisto == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Style.Font.Bold = true;
                                ws.Cells[ln, ColExcel].Formula = dadosReceita[0].Trim();
                                ColExcel++;
                            }

                            if (VerRealizado == "S")
                            {
                                ws.Cells[ln, ColExcel].Style.Numberformat.Format = "_ - R$ * #.##0_-;-R$ * #.##0_-;_-R$ * -_-;_-@_-";
                                ws.Cells[ln, ColExcel].Style.Font.Bold = true;
                                ws.Cells[ln, ColExcel].Formula = dadosReceita[1].Trim();
                                ColExcel++;
                            }
                        }
                        #endregion

                        //Pinta o Fundo da Linha dos Totais
                        cel1 = "A" + ln;
                        cel2 = ColunaTxt(ColExcel) + ln;
                        ws.Cells[cel1 + ":" + cel2].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                        ws.Cells[cel1 + ":" + cel2].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                    }

                    ws.Cells[ln, 200].Value = dadosPlano.coluna200;

                    ln++;

                } //fim ForEach

                //Gera as Bordas dos Dados impressos
                cel1 = "A" + lnIni;
                cel2 = ColunaTxt(ColExcel) + ln;
                ws.Cells[cel1 + ":" + cel2].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws.Cells[cel1 + ":" + cel2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick);

                cel2 = "C" + ln;
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
            int mesVez = MesIni;
            int anoVez = AnoOrc;
            int LinhaAbaixo = 0;
            int ColMes = 0;
            string cabMes = "";
            string dataAtual = DateTime.Now.ToShortDateString();
            string horaAtual = DateTime.Now.ToShortTimeString();
            ModelEmpresa dadosRel = new ModelEmpresa();

            dadosRel = DadosEmpRel();
            
            FileInfo ExCab = new FileInfo(ArqExcel);
            using (ExcelPackage pakCab = new ExcelPackage(ExCab))
            {
                ExcelWorksheet ws = pakCab.Workbook.Worksheets.Add("PlanOrc");
                OfficeOpenXml.Style.ExcelHorizontalAlignment HCentro = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                OfficeOpenXml.Style.ExcelVerticalAlignment VCentro = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                OfficeOpenXml.Style.ExcelHorizontalAlignment HLeft = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

                Form.lb_progress.Text = "Gerando Cabeçalho...";
                Form.lb_progress.Refresh();

                lnIni = 4;                

                //Controller
                ws.Cells["A1:C1"].Merge = true;
                ws.Cells["A1"].Value = "CONTROLLER ERP - Gestão Empresarial";
                ws.Cells["A1"].Style.HorizontalAlignment = HLeft;
                ws.Cells["A1"].Style.VerticalAlignment = VCentro;
                ws.Cells["A1"].Style.Font.Size = 18;
                ws.Cells["A1"].Style.Font.Bold = true;
                ws.Cells["A1"].Style.Font.Name = "Calibri";

                //Controller   
                ws.Cells["A2:C2"].Merge = true;
                ws.Cells["A2"].Value = "PLANEJAMENTO ORÇAMENTÁRIO";
                ws.Cells["A2"].Style.HorizontalAlignment = HLeft;
                ws.Cells["A2"].Style.VerticalAlignment = VCentro;
                ws.Cells["A2"].Style.Font.Size = 18;
                ws.Cells["A2"].Style.Font.Bold = true;
                ws.Cells["A2"].Style.Font.Name = "Calibri";

                //Nome e Tamanho das Colunas do Cabeçalho    
                ws.Cells["A4:A5"].Merge = true;
                ws.Cells["A4"].Style.Font.Bold = true;
                ws.Cells["A4"].Value = "ESTRUTURA";
                ws.Cells["A4"].Style.VerticalAlignment = VCentro;
                ws.Column(1).Width = 14.00D;

                ws.Cells["B4:B5"].Merge = true;
                ws.Cells["B4"].Style.Font.Bold = true;
                ws.Cells["B4"].Value = "CÓDIGO";
                ws.Cells["B4"].Style.VerticalAlignment = VCentro;
                ws.Column(2).Width = 10.00D;

                ws.Cells["C4:C5"].Merge = true;
                ws.Cells["C4"].Style.Font.Bold = true;
                ws.Cells["C4"].Value = "NOMENCLATURA";
                ws.Cells["C4"].Style.VerticalAlignment = VCentro;
                ws.Column(3).Width = 60.00D;

                #region Gera Os Meses
                ColExcel = 4;
                
                for (int xMes = 1; xMes <= NumMeses; xMes++)
                {
                    DateTime dataCab = Convert.ToDateTime("01/" + mesVez + "/" + anoVez);
                    cabMes = dataCab.ToString("MMMM/yyyy");

                    ColMes = ColExcel + 2;
                    cel1 = ColunaTxt(ColExcel) + "4";
                    cel2 = ColunaTxt(ColMes) + "4";
                    ws.Cells[cel1 + ":" + cel2].Merge = true;
                    ws.Cells[cel1].Value = cabMes;
                    ws.Cells[cel1].Style.Font.Bold = true;
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;
                    LinhaAbaixo = lnIni + 1;

                    if (VerPrevisto == "S")
                    {
                        ws.Cells[LinhaAbaixo, ColExcel].Value = "Previsto";
                        ws.Cells[LinhaAbaixo, ColExcel].Style.Font.Bold = true;
                        ws.Cells[LinhaAbaixo, ColExcel].Style.HorizontalAlignment = HCentro;
                        ColExcel++;
                    }

                    if (VerRealizado == "S")
                    {
                        ws.Cells[LinhaAbaixo, ColExcel].Value = "Realizado";
                        ws.Cells[LinhaAbaixo, ColExcel].Style.Font.Bold = true;
                        ws.Cells[LinhaAbaixo, ColExcel].Style.HorizontalAlignment = HCentro;
                        ColExcel++;
                    }

                    if (VerDiferenca == "S" && VerPrevisto == "S" && VerRealizado == "S")
                    {
                        ws.Cells[LinhaAbaixo, ColExcel].Value = "Diferença";
                        ws.Cells[LinhaAbaixo, ColExcel].Style.Font.Bold = true;
                        ws.Cells[LinhaAbaixo, ColExcel].Style.HorizontalAlignment = HCentro;
                        ColExcel++;
                    }

                    mesVez = mesVez + 1;
                    if (mesVez > 12)
                    {
                        mesVez = 1;
                        anoVez = anoVez + 1;
                    }

                }

                if (NumMeses > 1)
                {
                    ColMes = ColExcel + 2;
                    cel1 = ColunaTxt(ColExcel) + "4";
                    cel2 = ColunaTxt(ColMes) + "4";
                    ws.Cells[cel1 + ":" + cel2].Merge = true;
                    ws.Cells[cel1].Value = "TOTAL";
                    ws.Cells[cel1].Style.Font.Bold = true;
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;

                    if (VerPrevisto == "S")
                    {
                        ws.Cells[LinhaAbaixo, ColExcel].Value = "Previsto";
                        ws.Cells[LinhaAbaixo, ColExcel].Style.Font.Bold = true;
                        ws.Cells[LinhaAbaixo, ColExcel].Style.HorizontalAlignment = HCentro;
                        ColExcel++;
                    }

                    if (VerRealizado == "S")
                    {
                        ws.Cells[LinhaAbaixo, ColExcel].Value = "Realizado";
                        ws.Cells[LinhaAbaixo, ColExcel].Style.Font.Bold = true;
                        ws.Cells[LinhaAbaixo, ColExcel].Style.HorizontalAlignment = HCentro;
                        ColExcel++;
                    }

                    if (VerDiferenca == "S" && VerPrevisto == "S" && VerRealizado == "S")
                    {
                        ws.Cells[LinhaAbaixo, ColExcel].Value = "Diferença";
                        ws.Cells[LinhaAbaixo, ColExcel].Style.Font.Bold = true;
                        ws.Cells[LinhaAbaixo, ColExcel].Style.HorizontalAlignment = HCentro;
                        ColExcel++;
                    }

                    ColMes = ColExcel + 2;
                    cel1 = ColunaTxt(ColExcel) + "4";
                    cel2 = ColunaTxt(ColMes) + "4";
                    ws.Cells[cel1 + ":" + cel2].Merge = true;
                    ws.Cells[cel1].Value = "MÉDIA";
                    ws.Cells[cel1].Style.Font.Bold = true;
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;

                    if (VerPrevisto == "S")
                    {
                        ws.Cells[LinhaAbaixo, ColExcel].Value = "Previsto";
                        ws.Cells[LinhaAbaixo, ColExcel].Style.Font.Bold = true;
                        ws.Cells[LinhaAbaixo, ColExcel].Style.HorizontalAlignment = HCentro;
                        ColExcel++;
                    }

                    if (VerRealizado == "S")
                    {
                        ws.Cells[LinhaAbaixo, ColExcel].Value = "Realizado";
                        ws.Cells[LinhaAbaixo, ColExcel].Style.Font.Bold = true;
                        ws.Cells[LinhaAbaixo, ColExcel].Style.HorizontalAlignment = HCentro;
                        ColExcel++;
                    }

                    if (VerDiferenca == "S" && VerPrevisto == "S" && VerRealizado == "S")
                    {
                        ws.Cells[LinhaAbaixo, ColExcel].Value = "Diferença";
                        ws.Cells[LinhaAbaixo, ColExcel].Style.Font.Bold = true;
                        ws.Cells[LinhaAbaixo, ColExcel].Style.HorizontalAlignment = HCentro;
                        ColExcel++;
                    }

                    ColMes = ColExcel + 1;
                    cel1 = ColunaTxt(ColExcel) + "4";
                    cel2 = ColunaTxt(ColMes) + "4";
                    ws.Cells[cel1 + ":" + cel2].Merge = true;
                    ws.Cells[cel1].Value = "% RECEITA";
                    ws.Cells[cel1].Style.Font.Bold = true;
                    ws.Cells[cel1].Style.HorizontalAlignment = HCentro;

                    if (VerPrevisto == "S")
                    {
                        ws.Cells[LinhaAbaixo, ColExcel].Value = "Previsto";
                        ws.Cells[LinhaAbaixo, ColExcel].Style.Font.Bold = true;
                        ws.Cells[LinhaAbaixo, ColExcel].Style.HorizontalAlignment = HCentro;
                        ColExcel++;
                    }

                    if (VerRealizado == "S")
                    {
                        ws.Cells[LinhaAbaixo, ColExcel].Value = "Realizado";
                        ws.Cells[LinhaAbaixo, ColExcel].Style.Font.Bold = true;
                        ws.Cells[LinhaAbaixo, ColExcel].Style.HorizontalAlignment = HCentro;
                        ColExcel++;
                    }

                }
                #endregion
                //Fim dos Campos do Cabeçalho

                //Faz a Formatação do Cabeçalho
                cel1 = "A4";
                cel2 = ColunaTxt(ColExcel) + "5";
                ws.Cells[cel1 + ":" + cel2].Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                ws.Cells[cel1 + ":" + cel2].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                ws.Cells[cel1 + ":" + cel2].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
                ws.Cells[cel1 + ":" + cel2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick);

                cel2 = "C5";
                ws.Cells[cel1 + ":" + cel2].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Thick);
                                
                //Termina Formatação Cabeçalho
                lnIni = 5;

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

        private string[] VerDadosMes(int Mes, string tipo, Plano dadosPlano)
        {
            string[] valMes = null;

            switch (Mes)
            {
                case 1:
                    if (tipo == "V")
                        valMes = dadosPlano.Janeiro.Split('|');
                    else if (tipo == "T")
                        valMes = dadosPlano.totalJan.Split('|');
                    else
                        valMes = dadosPlano.subTotJan.Split('|');
                    break;
                case 2:
                    if (tipo == "V")
                        valMes = dadosPlano.Fevereiro.Split('|');
                    else if (tipo == "T")
                        valMes = dadosPlano.totalFev.Split('|');
                    else
                        valMes = dadosPlano.subTotFev.Split('|');
                    break;
                case 3:
                    if (tipo == "V")
                        valMes = dadosPlano.Marco.Split('|');
                    else if (tipo == "T")
                        valMes = dadosPlano.totalMar.Split('|');
                    else
                        valMes = dadosPlano.subTotMar.Split('|');
                    break;
                case 4:
                    if (tipo == "V")
                        valMes = dadosPlano.Abril.Split('|');
                    else if (tipo == "T")
                        valMes = dadosPlano.totalAbr.Split('|');
                    else
                        valMes = dadosPlano.subTotAbr.Split('|');
                    break;
                case 5:
                    if (tipo == "V")
                        valMes = dadosPlano.Maio.Split('|');
                    else if (tipo == "T")
                        valMes = dadosPlano.totalMai.Split('|');
                    else
                        valMes = dadosPlano.subTotMai.Split('|');
                    break;
                case 6:
                    if (tipo == "V")
                        valMes = dadosPlano.Junho.Split('|');
                    else if (tipo == "T")
                        valMes = dadosPlano.totalJun.Split('|');
                    else
                        valMes = dadosPlano.subTotJun.Split('|');
                    break;
                case 7:
                    if (tipo == "V")
                        valMes = dadosPlano.Julho.Split('|');
                    else if (tipo == "T")
                        valMes = dadosPlano.totalJul.Split('|');
                    else
                        valMes = dadosPlano.subTotJul.Split('|');
                    break;
                case 8:
                    if (tipo == "V")
                        valMes = dadosPlano.Agosto.Split('|');
                    else if (tipo == "T")
                        valMes = dadosPlano.totalAgo.Split('|');
                    else
                        valMes = dadosPlano.subTotAgo.Split('|');
                    break;
                case 9:
                    if (tipo == "V")
                        valMes = dadosPlano.Setembro.Split('|');
                    else if (tipo == "T")
                        valMes = dadosPlano.totalSet.Split('|');
                    else
                        valMes = dadosPlano.subTotSet.Split('|');
                    break;
                case 10:
                    if (tipo == "V")
                        valMes = dadosPlano.Outubro.Split('|');
                    else if (tipo == "T")
                        valMes = dadosPlano.totalOut.Split('|');
                    else
                        valMes = dadosPlano.subTotOut.Split('|');
                    break;
                case 11:
                    if (tipo == "V")
                        valMes = dadosPlano.Novembro.Split('|');
                    else if (tipo == "T")
                        valMes = dadosPlano.totalNov.Split('|');
                    else
                        valMes = dadosPlano.subTotNov.Split('|');
                    break;
                case 12:
                    if (tipo == "V")
                        valMes = dadosPlano.Dezembro.Split('|');
                    else if (tipo == "T")
                        valMes = dadosPlano.totalDez.Split('|');
                    else
                        valMes = dadosPlano.subTotDez.Split('|');
                    break;
            }

            return valMes;
        }

    }
}