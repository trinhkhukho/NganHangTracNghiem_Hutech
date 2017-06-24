using System;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Tables;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument("c:\\test\\input.docx");

            for (int i = 0; i < doc.Body.Content.Count; i++)
            {
                if (doc.Body.Content[i] is Paragraph)
                {
                    Paragraph paragraph = (Paragraph)doc.Body.Content[i];

                    String paragraphText = "";

                    foreach (IParagraphContent pContent in paragraph.Content)
                    {
                        if (pContent is Run)
                        {
                            Run run = (Run)pContent;

                            foreach (IRunContent rContent in run.Content)
                            {
                                if (rContent is Text)
                                {
                                    Text text = (Text)rContent;
                                    paragraphText += text.Value;
                                }
                            }
                        }
                    }

                    if (paragraphText.IndexOf("#TABLE#") > -1)
                    {
                        paragraph.Content.Clear();

                        Table table = CreateTable();

                        doc.Body.Content.Insert(i-1, table);
                    }
                }
            }

            doc.Save("c:\\test\\output.docx", true);
        }

        private static Table CreateTable()
        {
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

            return table1;
        }
    }
}
