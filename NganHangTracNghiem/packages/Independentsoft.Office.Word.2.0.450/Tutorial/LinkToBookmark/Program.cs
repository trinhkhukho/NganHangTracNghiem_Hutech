using System;
using System.Collections.Generic;
using Independentsoft.Office;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Fields;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            BookmarkStart startBookmark1 = new BookmarkStart();
            startBookmark1.Name = "bookmark1";
            startBookmark1.ID = 1;

            BookmarkEnd endBookmark1 = new BookmarkEnd();
            endBookmark1.ID = 1;

            Paragraph bookmarkParagraph = new Paragraph();
            bookmarkParagraph.Add(startBookmark1);
            bookmarkParagraph.Add(endBookmark1);
            bookmarkParagraph.Add(new Run("Just test"));


            Run run = new Run();
            run.AddText("ClickMeLink");
            run.Underline = new Underline(UnderlinePattern.Single);
            run.Color = new Independentsoft.Office.Word.RunContentColor("#008000");

            Hyperlink link = new Hyperlink();
            link.Add(run);
            link.Anchor = "bookmark1";

            Paragraph paragraph = new Paragraph();
            paragraph.Add(link);

            doc.Body.Add(paragraph);
            doc.Body.Add(new Paragraph()); //empty paragraph
            doc.Body.Add(new Paragraph()); //empty paragraph
            doc.Body.Add(new Paragraph()); //empty paragraph
            doc.Body.Add(new Paragraph()); //empty paragraph
            doc.Body.Add(new Paragraph()); //empty paragraph
            doc.Body.Add(bookmarkParagraph);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}