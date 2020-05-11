using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.HelperModels;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace GoToWorkBusinessLogic.BusinessLogics
{
    class SaveToPdf
    {
        public static void CreateDoc(ReportBindingModel model)
        {
            Document document = new Document();
            DefineStyles(document);

            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph("Отчет по движению деталей c " + model.Date.Value.ToShortDateString() + " по " + model.DateTo.Value.ToShortDateString());
            paragraph.Format.SpaceAfter = "1cm";
            paragraph.Format.Alignment = ParagraphAlignment.Center;
            paragraph.Style = "NormalTitle";

            var table = document.LastSection.AddTable();
            List<string> columns = new List<string> { "2.5cm", "4cm", "4cm", "3cm", "4cm" };

            foreach (var elem in columns)
            {
                table.AddColumn(elem);
            }

            if (model.ToyDict != null)
            {
                CreateRow(new PdfRowParameters
                {
                    Table = table,
                    Texts = new List<string> { "Дата", "Тип детали", "Цвет детали", "Количество", "Название игрушки" },
                    Style = "NormalTitle",
                    ParagraphAlignment = ParagraphAlignment.Center
                });

                decimal countParts = 0;

                foreach (var date in model.dates)
                {
                    bool dateFlag = false;

                    foreach (var toy in model.ToyDict.Where(rec => rec.DateCreate.Date == date.Date))
                    {
                        foreach (var tp in toy.ToyParts)
                        {
                            if (!dateFlag)
                            {
                                CreateRow(new PdfRowParameters
                                {
                                    Table = table,
                                    Texts = new List<string>
                                        {
                                            date.ToShortDateString(),
                                            tp.Value.Item1,
                                            tp.Value.Item2,
                                            tp.Value.Item3.ToString(),
                                            toy.ToyName
                                        },
                                    Style = "Normal",
                                    ParagraphAlignment = ParagraphAlignment.Left
                                });
                                dateFlag = true;
                                countParts++;
                            }
                            else if (dateFlag)
                            {
                                CreateRow(new PdfRowParameters
                                {
                                    Table = table,
                                    Texts = new List<string>
                                        {
                                            "",
                                            tp.Value.Item1,
                                            tp.Value.Item2,
                                            tp.Value.Item3.ToString(),
                                            toy.ToyName
                                        },
                                    Style = "Normal",
                                    ParagraphAlignment = ParagraphAlignment.Left
                                });
                                countParts++;
                            }
                        }
                        CreateRow(new PdfRowParameters
                        {
                            Table = table,
                            Texts = new List<string>
                                {
                                    "", "", "", "", ""
                                },
                            Style = "Normal",
                            ParagraphAlignment = ParagraphAlignment.Left
                        });
                    }
                }
            }
            else
            {
                CreateRow(new PdfRowParameters
                {
                    Table = table,
                    Texts = new List<string> { "Дата", "Тип детали", "Цвет детали", "Количество", "Статус" },
                    Style = "NormalTitle",
                    ParagraphAlignment = ParagraphAlignment.Center
                });

                List<string> partsType = new List<string>() { };

                if (model.PartDict != null)
                {
                    decimal count = 0;
                    foreach (var part in model.PartDict.Where(rec =>
                        (rec.DateRecieve.Date >= model.Date.Value.Date &&
                         rec.DateRecieve.Date <= model.DateTo.Value.Date) && rec.DateTransfer == null))
                    {
                        if (!partsType.Contains(part.PartType))
                        {
                            decimal countRecieve = 0;

                            foreach (var partTransfer in model.PartDict.Where(recT =>
                                recT.PartType == part.PartType && recT.DateTransfer != null &&
                                recT.DateTransfer.Value.Date >= model.Date.Value.Date &&
                                recT.DateTransfer.Value.Date <= model.DateTo.Value.Date))
                            {
                                CreateRow(new PdfRowParameters
                                {
                                    Table = table,
                                    Texts = new List<string>
                                        {
                                            partTransfer.DateTransfer.Value.Date.ToShortDateString(),
                                            partTransfer.PartType,
                                            partTransfer.PartColor,
                                            partTransfer.PartCount.ToString(),
                                            partTransfer.PartStatus.ToString()
                                        },
                                    Style = "Normal",
                                    ParagraphAlignment = ParagraphAlignment.Left
                                });

                                countRecieve += partTransfer.PartCount;
                            }
                            count += part.PartCount + countRecieve;
                            CreateRow(new PdfRowParameters
                            {
                                Table = table,
                                Texts = new List<string>
                                    {
                                        part.DateRecieve.Date.ToShortDateString(),
                                        part.PartType,
                                        part.PartColor,
                                        (part.PartCount + countRecieve).ToString(),
                                        part.PartStatus.ToString()
                                    },
                                Style = "Normal",
                                ParagraphAlignment = ParagraphAlignment.Left
                            });

                            CreateRow(new PdfRowParameters
                            {
                                Table = table,
                                Texts = new List<string>
                                {
                                    "", "", "", "", ""
                                },
                                Style = "Normal",
                                ParagraphAlignment = ParagraphAlignment.Left
                            });

                            partsType.Add(part.PartType);
                        }
                    }
                    CreateRow(new PdfRowParameters
                    {
                        Table = table,
                        Texts = new List<string>
                            {
                                "", "", "", "Всего прибыло:", count.ToString()
                            },
                        Style = "Normal",
                        ParagraphAlignment = ParagraphAlignment.Left
                    });
                }
            }

            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always) { Document = document };
            renderer.RenderDocument();
            renderer.PdfDocument.Save(model.FileName);
        }

        private static void DefineStyles(Document document)
        {
            Style style = document.Styles["Normal"];
            style.Font.Name = "Times New Roman";
            style.Font.Size = 14;
            style = document.Styles.AddStyle("NormalTitle", "Normal");
            style.Font.Bold = true;
        }

        private static void CreateRow(PdfRowParameters rowParameters)
        {
            Row row = rowParameters.Table.AddRow();

            for (int i = 0; i < rowParameters.Texts.Count; ++i)
            {
                FillCell(new PdfCellParameters
                {
                    Cell = row.Cells[i],
                    Text = rowParameters.Texts[i],
                    Style = rowParameters.Style,
                    BorderWidth = 0.5,
                    ParagraphAlignment = rowParameters.ParagraphAlignment
                });
            }
        }

        private static void FillCell(PdfCellParameters cellParameters)
        {
            cellParameters.Cell.AddParagraph(cellParameters.Text);

            if (!string.IsNullOrEmpty(cellParameters.Style))
            {
                cellParameters.Cell.Style = cellParameters.Style;
            }

            cellParameters.Cell.Borders.Left.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Right.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Top.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Borders.Bottom.Width = cellParameters.BorderWidth;
            cellParameters.Cell.Format.Alignment = cellParameters.ParagraphAlignment;
            cellParameters.Cell.VerticalAlignment = VerticalAlignment.Center;
        }
    }
}