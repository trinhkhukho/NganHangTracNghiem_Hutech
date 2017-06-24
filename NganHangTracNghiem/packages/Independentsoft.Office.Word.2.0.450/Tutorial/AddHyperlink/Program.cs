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
            run.AddText("Independentsoft");
            run.Underline = new Underline(UnderlinePattern.Single);

            run.Color = new RunContentColor("#0000FF");

            Hyperlink link = new Hyperlink();
            link.Add(run);
            link.Target = "http://www.independentsoft.com";
                        
            Paragraph paragraph = new Paragraph();
            paragraph.Add(link);

            doc.Body.Add(paragraph);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
