using System;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.HeaderFooter;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            Run run1 = new Run();
            run1.AddText("Hello Word!");

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);

            Run headerRun = new Run();
            headerRun.AddText("Header text");

            Paragraph headerParagraph = new Paragraph();
            headerParagraph.Add(headerRun);
            headerParagraph.HorizontalTextAlignment = HorizontalAlignmentType.Right;

            Header header = new Header();
            header.Add(headerParagraph);

            Run footerRun = new Run();
            footerRun.AddText("Footer text");

            Paragraph footerParagraph = new Paragraph();
            footerParagraph.Add(footerRun);
            footerParagraph.HorizontalTextAlignment = HorizontalAlignmentType.Center;

            Footer footer = new Footer();
            footer.Add(footerParagraph);

            doc.Body.Add(paragraph1);
            doc.Body.Header = header;
            doc.Body.Footer = footer;

            doc.Save("c:\\test\\output.docx", true);

        }
    }
}
