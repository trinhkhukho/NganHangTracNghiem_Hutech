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
            run1.AddText("Hello Word!");
            run1.Italic = ExtendedBoolean.True;

            Run run2 = new Run();
            run2.AddText("Hello Word!");
            run2.Bold = ExtendedBoolean.True;

            Run run3 = new Run();
            run3.AddText("Hello Word!");
            run3.FontSize = 48; //24 points

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);

            Paragraph paragraph2 = new Paragraph();
            paragraph2.Add(run2);

            Paragraph paragraph3 = new Paragraph();
            paragraph3.Add(run3);

            Paragraph paragraph4 = new Paragraph();
            paragraph4.Add(run1);
            paragraph4.Add(run2);
            paragraph4.Add(run3);

            doc.Body.Add(paragraph1);
            doc.Body.Add(paragraph2);
            doc.Body.Add(paragraph3);
            doc.Body.Add(paragraph4);

            doc.Save("c:\\test\\output.docx", true);

        }
    }
}
