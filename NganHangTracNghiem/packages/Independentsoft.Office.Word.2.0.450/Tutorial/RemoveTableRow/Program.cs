using System;
using System.Collections.Generic;
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

            Table table1 = tables[0]; //first table

            int rowCount = 0;

            for (int i = 0; i < table1.Content.Count; i++)
            {
                if (table1.Content[i] is Row)
                {
                    Row currentRow = (Row)table1.Content[i];
                    rowCount++;

                    if (rowCount == 3) //remove third row
                    {
                        table1.Content.Remove(currentRow);
                        break;
                    }
                }
            }

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
