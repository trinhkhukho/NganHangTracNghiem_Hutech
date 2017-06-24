using System;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.FootnoteEndnote;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            Footnote footnote1 = new Footnote(1);
            FootnoteReference footnoteReference = new FootnoteReference(1);

            Run footnoteRun1 = new Run();
            footnoteRun1.VerticalAlignment = VerticalAlignment.Superscript;
            footnoteRun1.AddFootnoteReferenceMark();

            Run footnoteRun2 = new Run();
            footnoteRun2.AddText("Footnote text.");
            
            Paragraph footnoteParagraph = new Paragraph();
            footnoteParagraph.Add(footnoteRun1);
            footnoteParagraph.Add(footnoteRun2);

            footnote1.Content.Add(footnoteParagraph);

            Run run1 = new Run();
            run1.AddText("Hello Word");
            
            Run footnoteReferenceRun = new Run();
            footnoteReferenceRun.VerticalAlignment = VerticalAlignment.Superscript;
            footnoteReferenceRun.Add(footnoteReference);

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);
            paragraph1.Add(footnoteReferenceRun);

            doc.Body.Add(paragraph1);
            doc.Footnotes.Add(footnote1);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
