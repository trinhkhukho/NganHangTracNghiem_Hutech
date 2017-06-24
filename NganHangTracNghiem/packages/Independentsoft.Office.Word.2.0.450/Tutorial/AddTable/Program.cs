using System;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Tables;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            Run run1 = new Run();
            run1.AddText("Below is one table with 5 rows and 3 columns.");

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);

            Cell cell1 = new Cell();

            Row row1 = new Row();
            row1.Add(cell1);
            row1.Add(cell1);
            row1.Add(cell1);

            Table table1 = new Table(StandardBorderStyle.SingleLine);
            table1.Width = new Width(TableWidthUnit.Percent, 100);

            table1.Add(row1);
            table1.Add(row1);
            table1.Add(row1);
            table1.Add(row1);
            table1.Add(row1);

            doc.Body.Add(paragraph1);
            doc.Body.Add(table1);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
