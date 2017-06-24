using System;
using Independentsoft.Office.Word;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();
                      
            Run commentRun = new Run();
            commentRun.AddText("Comment text.");

            Paragraph commentParagraph = new Paragraph();
            commentParagraph.Add(commentRun);

            Comment comment1 = new Comment(1);
            comment1.Author = "Joe Smith";
            comment1.Date = DateTime.Now;
            comment1.Initials = "JS";
            comment1.Add(commentParagraph);

            CommentRangeStart commentStart = new CommentRangeStart(1);
            CommentRangeEnd commentEnd = new CommentRangeEnd(1);
            CommentReference commentReference = new CommentReference(1);

            Run commentReferenceRun = new Run();
            commentReferenceRun.Add(commentReference);

            Run run1 = new Run();
            run1.AddText("Hello ");

            Run run2 = new Run();
            run2.AddText("Word");

            Run run3 = new Run();
            run3.AddText(".");

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);
            paragraph1.Add(commentStart);
            paragraph1.Add(run2);
            paragraph1.Add(commentEnd);
            paragraph1.Add(commentReferenceRun);
            paragraph1.Add(run3);

            doc.Body.Add(paragraph1);
            doc.Comments.Add(comment1);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
