using System;
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
            SimpleField pageNumberField = new SimpleField(pageNumber);

            NumberOfPages totalPages = new NumberOfPages();
            SimpleField totalPagesField = new SimpleField(totalPages);

            Run run1 = new Run();
            run1.AddText(" of ");

            Paragraph footerParagraph = new Paragraph();
            footerParagraph.Add(pageNumberField);
            footerParagraph.Add(run1);
            footerParagraph.Add(totalPagesField);
            footerParagraph.HorizontalTextAlignment = HorizontalAlignmentType.Left;

            Footer footer = new Footer();
            footer.Add(footerParagraph);

            doc.Body.Footer = footer;

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
