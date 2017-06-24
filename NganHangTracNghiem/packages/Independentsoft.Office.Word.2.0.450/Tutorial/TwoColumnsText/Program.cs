using System;
using Independentsoft.Office;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Fields;
using Independentsoft.Office.Word.Sections;
using Independentsoft.Office.Word.HeaderFooter;

namespace Sample
{
    /// <summary>
    /// Set two columns on the section1 with space 720. Set own header/footer for the section and assign page numbers.
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            //section
            Section section1 = new Section();
            section1.PageNumberingSettings.FirstPageNumber = 1;

            section1.Columns = new ColumnDefinitions();
            section1.Columns.Space = 720;
            section1.Columns.EqualWidthColumnsCount = 2;

            //page numbers in footer
            Page pageNumber1 = new Page();
            SimpleField simpleField1 = new SimpleField(pageNumber1);

            Paragraph footerParagraph1 = new Paragraph();
            footerParagraph1.Add(simpleField1);
            footerParagraph1.HorizontalTextAlignment = HorizontalAlignmentType.Center;

            Footer footer1 = new Footer();
            footer1.Add(footerParagraph1);

            section1.Footer = footer1;
            //end page numbers

            Run run1 = new Run();
            run1.AddText("Some text ...");

            Run run2 = new Run();
            run2.AddText("Additional text ...");

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);

            Paragraph paragraph2 = new Paragraph();
            paragraph2.Add(run2);
            paragraph2.PageBreakBefore = ExtendedBoolean.True;

            Paragraph paragraph3 = new Paragraph();
            paragraph3.Add(run1);
            paragraph3.Section = section1; //last paragraph in this section

            doc.Body.Add(paragraph1);
            doc.Body.Add(paragraph2);
            doc.Body.Add(paragraph3);

            Paragraph paragraph4 = new Paragraph();
            paragraph4.Add(run2);

            doc.Body.Add(paragraph4);

            //new section, new footer
            Section section2 = new Section();
            section2.PageNumberingSettings.FirstPageNumber = 2;

            //page numbers in footer
            Page pageNumber2 = new Page();
            SimpleField simpleField2 = new SimpleField(pageNumber2);

            Paragraph footerParagraph2 = new Paragraph();
            footerParagraph2.Add(simpleField2);
            footerParagraph2.HorizontalTextAlignment = HorizontalAlignmentType.Center;

            Footer footer2 = new Footer();
            footer2.Add(footerParagraph2);

            section2.Footer = footer2;

            Run run21 = new Run();
            run21.AddText("New section text ...");

            Run run22 = new Run();
            run22.AddText("Additional text in new section ...");

            Paragraph paragraph21 = new Paragraph();
            paragraph21.Add(run21);

            Paragraph paragraph22 = new Paragraph();
            paragraph22.Add(run22);
            paragraph22.PageBreakBefore = ExtendedBoolean.True;

            Paragraph paragraph23 = new Paragraph();
            paragraph23.Add(run21);
            paragraph23.Section = section2; //last paragraph in new section

            doc.Body.Add(paragraph21);
            doc.Body.Add(paragraph22);
            doc.Body.Add(paragraph23);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
