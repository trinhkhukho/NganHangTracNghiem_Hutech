using System;
using Independentsoft.Office;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Fields;
using Independentsoft.Office.Word.Styles;

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

            Run chapterTocEntryRun = new Run("1. First Chapter");

            PageReference chapterReference = new PageReference();
            chapterReference.Value = "Chapter1";

            FieldCode chapterFieldCode = new FieldCode(chapterReference);

            Run chapterFieldCodeRun = new Run();
            chapterFieldCodeRun.Add(chapterFieldCode);

            Run subchapterTocEntryRun = new Run("1.1 First subchapter");

            PageReference subchapterReference = new PageReference();
            subchapterReference.Value = "Subchapter1";

            FieldCode subchapterFieldCode = new FieldCode(subchapterReference);

            Run subchapterFieldCodeRun = new Run();
            subchapterFieldCodeRun.Add(subchapterFieldCode);

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

            Paragraph chapterTocEntryParagraph = new Paragraph();
            chapterTocEntryParagraph.Tabs.Add(tab1);
            chapterTocEntryParagraph.Add(chapterTocEntryRun);
            chapterTocEntryParagraph.Add(tabRun);
            chapterTocEntryParagraph.Add(startComplexFieldRun);
            chapterTocEntryParagraph.Add(chapterFieldCodeRun);
            chapterTocEntryParagraph.Add(separatorComplexFieldRun);
            chapterTocEntryParagraph.Add(endComplexFieldRun);

            Paragraph subchapterTocEntryParagraph = new Paragraph();
            subchapterTocEntryParagraph.Tabs.Add(tab1);
            subchapterTocEntryParagraph.Add(subchapterTocEntryRun);
            subchapterTocEntryParagraph.Add(tabRun);
            subchapterTocEntryParagraph.Add(startComplexFieldRun);
            subchapterTocEntryParagraph.Add(subchapterFieldCodeRun);
            subchapterTocEntryParagraph.Add(separatorComplexFieldRun);
            subchapterTocEntryParagraph.Add(endComplexFieldRun);

            Paragraph tocEndParagraph = new Paragraph();
            tocEndParagraph.Add(endComplexFieldRun);

            BookmarkStart startBookmark1 = new BookmarkStart();
            startBookmark1.Name = "Chapter1";
            startBookmark1.ID = 1;

            BookmarkEnd endBookmark1 = new BookmarkEnd();
            endBookmark1.ID = 1;

            Run chapterRun = new Run("1. First Chapter");

            Paragraph chapterParagraph = new Paragraph();
            chapterParagraph.PageBreakBefore = ExtendedBoolean.True;
            chapterParagraph.Add(startBookmark1);
            chapterParagraph.Add(chapterRun);
            chapterParagraph.Add(endBookmark1);

            BookmarkStart startBookmark2 = new BookmarkStart();
            startBookmark2.Name = "Subchapter1";
            startBookmark2.ID = 2;

            BookmarkEnd endBookmark2 = new BookmarkEnd();
            endBookmark2.ID = 2;

            Run subchapterRun = new Run("1.1 First Subchapter");

            Paragraph subchapterParagraph = new Paragraph();
            subchapterParagraph.PageBreakBefore = ExtendedBoolean.True;
            subchapterParagraph.Add(startBookmark2);
            subchapterParagraph.Add(subchapterRun);
            subchapterParagraph.Add(endBookmark2);

            Style chapterTocEntryStyle = new Style();
            chapterTocEntryStyle.ID = "TOC1";
            chapterTocEntryStyle.Name = "TocChapterStyle";
            chapterTocEntryStyle.Type = StyleType.Paragraph;
            chapterTocEntryStyle.ParentStyleID = "Normal";
            chapterTocEntryStyle.ParagraphProperties.Indentation = new Indentation();
            chapterTocEntryStyle.ParagraphProperties.Indentation.Left = 240;
            chapterTocEntryStyle.RunProperties.FontSize = 28;
            chapterTocEntryStyle.RunProperties.Bold = ExtendedBoolean.True;

            Style subchapterTocEntryStyle = new Style();
            subchapterTocEntryStyle.ID = "TOC2";
            subchapterTocEntryStyle.Name = "TocSubchapterStyle";
            subchapterTocEntryStyle.Type = StyleType.Paragraph;
            subchapterTocEntryStyle.ParentStyleID = "Normal";
            subchapterTocEntryStyle.ParagraphProperties.Indentation = new Indentation();
            subchapterTocEntryStyle.ParagraphProperties.Indentation.Left = 480;
            subchapterTocEntryStyle.RunProperties.Italic = ExtendedBoolean.True;

            doc.StyleDefinitions = new StyleDefinitions();
            doc.StyleDefinitions.Styles.Add(chapterTocEntryStyle);
            doc.StyleDefinitions.Styles.Add(subchapterTocEntryStyle);

            chapterTocEntryParagraph.StyleName = "TOC1";
            subchapterTocEntryParagraph.StyleName = "TOC2";

            doc.Body.Add(tocStartParagraph);
            doc.Body.Add(chapterTocEntryParagraph);
            doc.Body.Add(subchapterTocEntryParagraph);
            doc.Body.Add(tocEndParagraph);
            doc.Body.Add(chapterParagraph);
            doc.Body.Add(subchapterParagraph);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
