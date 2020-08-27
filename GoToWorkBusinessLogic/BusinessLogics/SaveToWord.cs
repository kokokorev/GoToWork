using System;
using System.Collections.Generic;
using System.Text;
<<<<<<< HEAD
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using GoToWorkBusinessLogic.BindingModels;
using GoToWorkBusinessLogic.ViewModels;

namespace GoToWorkBusinessLogic.BusinessLogics
{
    static class SaveToWord
    {
        public static void CreateDoc(ReportBindingModel model)
        {
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(model.FileName, WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = mainPart.Document.AppendChild(new Body());
                Paragraph para = body.AppendChild(new Paragraph());
                Run run = para.AppendChild(new Run());

                if (model.ToyModel != null)
                {
                    run.AppendChild(new Text("Состав игрушки \"" + model.ToyModel.ToyName + "\" " + "Дата создания: " + model.ToyModel.DateCreate.ToShortDateString()));
                }
                else
                {
                    run.AppendChild(new Text("Отчет по заказу" + " " + "Дата заказа: " + model.Date.Value.ToShortDateString()));
                }
            }

            using (var document = WordprocessingDocument.Open(model.FileName, true))
            {

                var doc = document.MainDocumentPart.Document;

                Table table = new Table();

                TableProperties props = new TableProperties(
                new TableBorders(
                new TopBorder
                {
                    Val = new EnumValue<BorderValues>(BorderValues.Single),
                    Size = 12
                },
                new BottomBorder
                {
                    Val = new EnumValue<BorderValues>(BorderValues.Single),
                    Size = 12
                },
                new LeftBorder
                {
                    Val = new EnumValue<BorderValues>(BorderValues.Single),
                    Size = 12
                },
                new RightBorder
                {
                    Val = new EnumValue<BorderValues>(BorderValues.Single),
                    Size = 12
                },
                new InsideHorizontalBorder
                {
                    Val = new EnumValue<BorderValues>(BorderValues.Single),
                    Size = 12
                },
                new InsideVerticalBorder
                {
                    Val = new EnumValue<BorderValues>(BorderValues.Single),
                    Size = 12
                }));

                TableJustification justification = new TableJustification();

                table.AppendChild<TableProperties>(props);

                var row = new TableRow();
                var cell = new TableCell();
                cell.Append(new Paragraph(new Run(new Text("Тип детали"))));
                cell.Append(new TableCellProperties(new TableCellWidth { Width = "2000" }));
                row.Append(cell);

                var cell1 = new TableCell();
                cell1.Append(new Paragraph(new Run(new Text("Цвет детали"))));
                cell1.Append(new TableCellProperties(new TableCellWidth { Width = "2000" }));
                row.Append(cell1);

                var cell2 = new TableCell();
                cell2.Append(new Paragraph(new Run(new Text("Количество"))));
                cell2.Append(new TableCellProperties(new TableCellWidth { Width = "2000" }));
                row.Append(cell2);

                table.Append(row);

                Dictionary<int, (string, string, int)> toyParts = new Dictionary<int, (string, string, int)>();
                toyParts.Add(1, (model.PartType, model.PartColor, model.PartCount));

                if (model.ToyModel != null)
                {
                    table = CreateTable(table, model.ToyModel.ToyParts.Values);
                }
                else
                {
                    table = CreateTable(table, toyParts.Values);
                }

                doc.Body.Append(table);
                doc.Save();
            }
        }

        private static Table CreateTable(Table table, Dictionary<int, (string, string, int)>.ValueCollection dict)
        {
            foreach (var part in dict)
            {
                var tr = new TableRow();
                var tc = new TableCell();
                tc.Append(new Paragraph(new Run(new Text(part.Item1))));
                tc.Append(new TableCellProperties(new TableCellWidth { Width = "2000" }));
                tr.Append(tc);

                var tc1 = new TableCell();
                tc1.Append(new Paragraph(new Run(new Text(part.Item2))));
                tc1.Append(new TableCellProperties(new TableCellWidth { Width = "2000" }));
                tr.Append(tc1);

                var tc2 = new TableCell();
                tc2.Append(new Paragraph(new Run(new Text(part.Item3.ToString()))));
                tc2.Append(new TableCellProperties(new TableCellWidth { Width = "2000" }));
                tr.Append(tc2);

                table.Append(tr);
            }

            return table;
        }
=======

namespace GoToWorkBusinessLogic.BusinessLogics
{
    class SaveToWord
    {
>>>>>>> c5de45aa0e96dc1a2a07dfc76df7593ac57c8152
    }
}
