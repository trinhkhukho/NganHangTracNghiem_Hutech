using System;
using System.Collections.Generic;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Tables;
using Independentsoft.Office.Word.Styles;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument input = new WordDocument("c:\\test\\input.docx");
            WordDocument output = new WordDocument();

            IList<Table> tables = input.GetTables();

            if (tables.Count > 0)
            {
                output.Body.Add(tables[0]);

                if(tables[0].StyleName != null)
                {
                    Style tableStyle = null;

                    foreach(Style s in input.StyleDefinitions.Styles)
                    {
                        if (s.ID == tables[0].StyleName)
                        {
                            tableStyle = s;
                        }
                    }

                    if(tableStyle != null)
                    {
                        if(output.StyleDefinitions  == null)
                        {
                            output.StyleDefinitions = new StyleDefinitions();
                        }

                        output.StyleDefinitions.Styles.Add(tableStyle);
                    }
                }
            }

            output.Save("c:\\test\\output.docx", true);
        }
    }
}
