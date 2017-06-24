using System;
using Independentsoft.Office.Word;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            Run run = new Run();
            run.AddText("Hello Word!");
            run.Color = new RunContentColor("#FF0000");

            Paragraph paragraph = new Paragraph();
            paragraph.Add(run);

            doc.Body.Add(paragraph);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
