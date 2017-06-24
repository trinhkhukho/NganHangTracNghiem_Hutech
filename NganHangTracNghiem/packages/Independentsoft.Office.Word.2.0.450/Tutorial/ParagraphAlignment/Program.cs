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
            run1.AddText("Center alignment.");

            Run run2 = new Run();
            run2.AddText("Left alignment.");

            Run run3 = new Run();
            run3.AddText("Right alignment.");

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);
            paragraph1.HorizontalTextAlignment = HorizontalAlignmentType.Center;

            Paragraph paragraph2 = new Paragraph();
            paragraph2.Add(run2);
            paragraph2.HorizontalTextAlignment = HorizontalAlignmentType.Left;

            Paragraph paragraph3 = new Paragraph();
            paragraph3.Add(run3);
            paragraph3.HorizontalTextAlignment = HorizontalAlignmentType.Right;

            doc.Body.Add(paragraph1);
            doc.Body.Add(new Paragraph()); //empty paragraph
            doc.Body.Add(paragraph2);
            doc.Body.Add(new Paragraph()); //empty paragraph
            doc.Body.Add(paragraph3);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
