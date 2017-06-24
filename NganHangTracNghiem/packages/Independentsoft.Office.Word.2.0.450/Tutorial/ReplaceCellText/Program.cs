using System;
using System.Collections.Generic;
using Independentsoft.Office;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Tables;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument("c:\\test\\input.docx");

            IList<Table> tables = doc.GetTables();

            Table firstTable = tables[0];

            int rowCount = 0;
            int cellCount = 0;

            for (int i = 0; i < firstTable.Content.Count; i++)
            {
                if (firstTable.Content[i] is Row)
                {
                    Row row = (Row)firstTable.Content[i];
                    rowCount++;
                    cellCount = 0;

                    for (int j = 0; j < row.Content.Count; j++)
                    {
                        if (row.Content[j] is Cell)
                        {
                            Cell cell = (Cell)row.Content[j];
                            cellCount++;

                            if (rowCount == 3 && cellCount == 1)
                            {
                                string cellText = "";
                                Paragraph firstParagraph = null;
                                Run firstRun = null;

                                foreach (IBlockElement cellContent in cell.Content)
                                {
                                    if (cellContent is Paragraph)
                                    {
                                        Paragraph paragraph = (Paragraph)cellContent;

                                        if (firstParagraph == null)
                                        {
                                            firstParagraph = paragraph;
                                        }

                                        foreach (IParagraphContent paragraphContent in paragraph.Content)
                                        {
                                            if (paragraphContent is Run)
                                            {
                                                Run run = (Run)paragraphContent;

                                                if (firstRun == null)
                                                {
                                                    firstRun = run;
                                                }

                                                foreach (IRunContent runContent in run.Content)
                                                {
                                                    if (runContent is Text)
                                                    {
                                                        Text text = (Text)runContent;

                                                        if (text.Value != null && text.Value.Length > 0)
                                                        {
                                                            cellText += text.Value;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }

                                cellText = cellText.Replace("oldText", "newText");

                                firstParagraph.Content.Clear();
                                firstRun.Content.Clear();

                                firstRun.Add(new Text(cellText));
                                firstParagraph.Add(firstRun);

                                cell.Content.Clear();
                                cell.Content.Add(firstParagraph);
                            }
                        }
                    }
                }
            }

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}