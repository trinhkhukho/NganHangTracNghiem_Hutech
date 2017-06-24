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

            PageSize pageSize = new PageSize(12240, 15840); //8.5 x 11 inch
            pageSize.PageOrientation = PageOrientation.Landscape;

            Section section = new Section();
            section.PageSize = pageSize;
            section.PageMargins = margins;

            doc.Body.Section = section;

            Run run = new Run();
            run.AddText("Page size is 8.5 x 11 inch (Letter).");

            Paragraph paragraph = new Paragraph();
            paragraph.Add(run);

            doc.Body.Add(paragraph);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
