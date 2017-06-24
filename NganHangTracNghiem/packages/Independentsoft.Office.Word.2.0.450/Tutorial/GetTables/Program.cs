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

            foreach (Table table in tables)
            {
                table.TopBorder = new TopBorder(StandardBorderStyle.DoubleLine);
                table.BottomBorder = new BottomBorder(StandardBorderStyle.DoubleLine);
                table.LeftBorder = new LeftBorder(StandardBorderStyle.DoubleLine);
                table.RightBorder = new RightBorder(StandardBorderStyle.DoubleLine);
                table.HorizontalInsideBorder = new HorizontalInsideBorder(StandardBorderStyle.DoubleLine);
                table.VerticalInsideBorder = new VerticalInsideBorder(StandardBorderStyle.DoubleLine);
            }

            doc.Save("c:\\test\\output.docx");
        }
    }
}
