using System;
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

            ComplexField startComplexField = new ComplexField(ComplexFieldCharacterType.Start);
            ComplexField separatorComplexField = new ComplexField(ComplexFieldCharacterType.Separator);
            ComplexField endComplexField = new ComplexField(ComplexFieldCharacterType.End);

            Run startComplexFieldRun = new Run();
            startComplexFieldRun.Add(startComplexField);

            Run separatorComplexFieldRun = new Run();
            separatorComplexFieldRun.Add(separatorComplexField);

            Run endComplexFieldRun = new Run();
            endComplexFieldRun.Add(endComplexField);

            TableOfContents toc = new TableOfContents();
            FieldCode tocFieldCode = new FieldCode(toc);

            Run tocFieldCodeRun = new Run();
            tocFieldCodeRun.Add(tocFieldCode);

            Run firstChapterTocEntryRun = new Run("First chapter");

            PageReference firstChapterReference = new PageReference();
            firstChapterReference.Value = "TocEntry1";

            FieldCode firstChapterFieldCode = new FieldCode(firstChapterReference);

            Run firstChapterFieldCodeRun = new Run();
            firstChapterFieldCodeRun.Add(firstChapterFieldCode);

            Run secondChapterTocEntryRun = new Run("Second chapter");

            PageReference secondChapterReference = new PageReference();
            secondChapterReference.Value = "TocEntry2";

            FieldCode secondChapterFieldCode = new FieldCode(secondChapterReference);

            Run secondChapterFieldCodeRun = new Run();
            secondChapterFieldCodeRun.Add(secondChapterFieldCode);

            Run tabRun = new Run();
            tabRun.AddTab();

            Tab tab1 = new Tab();
            tab1.Position = 9350;
            tab1.Leader = TabLeaderCharacter.Dot;
            tab1.Type = TabType.Right;

            Paragraph tocStartParagraph = new Paragraph();
            tocStartParagraph.Add(startComplexFieldRun);
            tocStartParagraph.Add(tocFieldCodeRun);
            tocStartParagraph.Add(separatorComplexFieldRun);

            Paragraph firstTocEntryParagraph = new Paragraph();
            firstTocEntryParagraph.Tabs.Add(tab1);
            firstTocEntryParagraph.Add(firstChapterTocEntryRun);
            firstTocEntryParagraph.Add(tabRun);
            firstTocEntryParagraph.Add(startComplexFieldRun);
            firstTocEntryParagraph.Add(firstChapterFieldCodeRun);
            firstTocEntryParagraph.Add(separatorComplexFieldRun);
            firstTocEntryParagraph.Add(endComplexFieldRun);

            Paragraph secondTocEntryParagraph = new Paragraph();
            secondTocEntryParagraph.Tabs.Add(tab1);
            secondTocEntryParagraph.Add(secondChapterTocEntryRun);
            secondTocEntryParagraph.Add(tabRun);
            secondTocEntryParagraph.Add(startComplexFieldRun);
            secondTocEntryParagraph.Add(secondChapterFieldCodeRun);
            secondTocEntryParagraph.Add(separatorComplexFieldRun);
            secondTocEntryParagraph.Add(endComplexFieldRun);

            Paragraph tocEndParagraph = new Paragraph();
            tocEndParagraph.Add(endComplexFieldRun);

            BookmarkStart startBookmark1 = new BookmarkStart();
            startBookmark1.Name = "TocEntry1";
            startBookmark1.ID = 1;

            BookmarkEnd endBookmark1 = new BookmarkEnd();
            endBookmark1.ID = 1;

            Run firstChapterRun = new Run("First Chapter");

            Paragraph firstChapterParagraph = new Paragraph();
            firstChapterParagraph.PageBreakBefore = ExtendedBoolean.True;
            firstChapterParagraph.Add(startBookmark1);
            firstChapterParagraph.Add(firstChapterRun);
            firstChapterParagraph.Add(endBookmark1);

            BookmarkStart startBookmark2 = new BookmarkStart();
            startBookmark2.Name = "TocEntry2";
            startBookmark2.ID = 2;

            BookmarkEnd endBookmark2 = new BookmarkEnd();
            endBookmark2.ID = 2;

            Run secondChapterRun = new Run("Second Chapter");

            Paragraph secondChapterParagraph = new Paragraph();
            secondChapterParagraph.PageBreakBefore = ExtendedBoolean.True;
            secondChapterParagraph.Add(startBookmark2);
            secondChapterParagraph.Add(secondChapterRun);
            secondChapterParagraph.Add(endBookmark2);
            
            doc.Body.Add(tocStartParagraph);
            doc.Body.Add(firstTocEntryParagraph);
            doc.Body.Add(secondTocEntryParagraph);
            doc.Body.Add(tocEndParagraph);
            doc.Body.Add(firstChapterParagraph);
            doc.Body.Add(secondChapterParagraph);
          
            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
