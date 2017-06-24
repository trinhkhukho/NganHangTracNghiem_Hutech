using System;
using Independentsoft.Office;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Fields;
using Independentsoft.Office.Word.HeaderFooter;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            Page pageNumber = new Page();
            SimpleField simpleField = new SimpleField(pageNumber);

            Paragraph footerParagraph = new Paragraph();
            footerParagraph.Add(simpleField);
            footerParagraph.HorizontalTextAlignment = HorizontalAlignmentType.Center;

            Footer footer = new Footer();
            footer.Add(footerParagraph);

            Run run1 = new Run();
            run1.AddText("Hello Word!");

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);

            doc.Body.Add(paragraph1);
            doc.Body.Footer = footer;

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
