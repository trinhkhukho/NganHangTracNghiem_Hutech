using System;
using Independentsoft.Office;
using Independentsoft.Office.Word;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            Run run1 = new Run();
            run1.AddText("Some text on the first page.");

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);

            Run run2 = new Run();
            run2.AddText("Some text on the second page.");

            Paragraph paragraph2 = new Paragraph();
            paragraph2.Add(run2);
            paragraph2.PageBreakBefore = ExtendedBoolean.True;

            doc.Body.Add(paragraph1); //on the first page
            doc.Body.Add(paragraph2); //on the second page

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
