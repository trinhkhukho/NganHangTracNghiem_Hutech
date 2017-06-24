using System;
using Independentsoft.Office;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Tables;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            Run run1 = new Run("Quantity");
            run1.Bold = ExtendedBoolean.True;

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);

            Run run2 = new Run("Item #");
            run2.Bold = ExtendedBoolean.True;

            Paragraph paragraph2 = new Paragraph();
            paragraph2.Add(run2);

            Run run3 = new Run("Description");
            run3.Bold = ExtendedBoolean.True;

            Paragraph paragraph3 = new Paragraph();
            paragraph3.Add(run3);

            Run run4 = new Run("Unit Price");
            run4.Bold = ExtendedBoolean.True;

            Paragraph paragraph4 = new Paragraph();
            paragraph4.Add(run4);

            Run run5 = new Run("Line Total");
            run5.Bold = ExtendedBoolean.True;

            Paragraph paragraph5 = new Paragraph();
            paragraph5.Add(run5);

            Cell cell1 = new Cell();
            cell1.Width = new Width(TableWidthUnit.Point, 1260);
            cell1.Shading = new Shading(ShadingPattern.Percent10);
            cell1.Add(paragraph1);

            Cell cell2 = new Cell();
            cell2.Width = new Width(TableWidthUnit.Point, 1440);
            cell2.Shading = new Shading(ShadingPattern.Percent10);
            cell2.Add(paragraph2);

            Cell cell3 = new Cell();
            cell3.Width = new Width(TableWidthUnit.Point, 4140);
            cell3.Shading = new Shading(ShadingPattern.Percent10);
            cell3.Add(paragraph3);

            Cell cell4 = new Cell();
            cell4.Width = new Width(TableWidthUnit.Point, 1620);
            cell4.Shading = new Shading(ShadingPattern.Percent10);
            cell4.Add(paragraph4);

            Cell cell5 = new Cell();
            cell5.Width = new Width(TableWidthUnit.Point, 1620);
            cell5.Shading = new Shading(ShadingPattern.Percent10);
            cell5.Add(paragraph5);

            Row headerRow = new Row();
            headerRow.Header = ExtendedBoolean.True;
            headerRow.Add(cell1);
            headerRow.Add(cell2);
            headerRow.Add(cell3);
            headerRow.Add(cell4);
            headerRow.Add(cell5);

            Row row1 = new Row();
            row1.Add(new Cell());
            row1.Add(new Cell());
            row1.Add(new Cell());
            row1.Add(new Cell());
            row1.Add(new Cell());

            Table table1 = new Table(StandardBorderStyle.SingleLine);

            table1.Add(headerRow);

            for (int i = 0; i < 100; i++)
            {
                table1.Add(row1);
            }

            doc.Body.Add(table1);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
