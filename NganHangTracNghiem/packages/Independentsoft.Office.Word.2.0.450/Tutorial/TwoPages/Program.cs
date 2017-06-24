using System;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Sections;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            PageMargins margins = new PageMargins();
            margins.Bottom = 1440; // 1 inch
            margins.Left = 1440; // 1 inch
            margins.Right = 1440; // 1 inch
            margins.Top = 1440; // 1 inch
            margins.Footer = 720; // 1/2 inch
            margins.Header = 720; // 1/2 inch

            Section section = new Section();
            section.PageSize = new PageSize(12240, 15840); //8.5 x 11 in
            section.PageMargins = margins;
            
            Run run1 = new Run();
            run1.AddText("Some text on the first page.");

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);

            Paragraph paragraph2 = new Paragraph();
            paragraph2.Add(run1);

            Paragraph paragraph3 = new Paragraph();
            paragraph3.Add(run1);
            paragraph3.Section = section; //last paragraph on the first page
            
            //first page
            doc.Body.Add(paragraph1);
            doc.Body.Add(paragraph2);
            doc.Body.Add(paragraph3);
            
            Run run2 = new Run();
            run2.AddText("Some text on the second page.");

            Paragraph paragraph4 = new Paragraph();
            paragraph4.Add(run2);
            
            //second page
            doc.Body.Add(paragraph4);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
