Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Fields
Imports Independentsoft.Office.Word.Styles

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As New WordDocument()

        Dim startComplexField As New ComplexField(ComplexFieldCharacterType.Start)
        Dim separatorComplexField As New ComplexField(ComplexFieldCharacterType.Separator)
        Dim endComplexField As New ComplexField(ComplexFieldCharacterType.[End])

        Dim startComplexFieldRun As New Run()
        startComplexFieldRun.Add(startComplexField)

        Dim separatorComplexFieldRun As New Run()
        separatorComplexFieldRun.Add(separatorComplexField)

        Dim endComplexFieldRun As New Run()
        endComplexFieldRun.Add(endComplexField)

        Dim toc As New TableOfContents()
        Dim tocFieldCode As New FieldCode(toc)

        Dim tocFieldCodeRun As New Run()
        tocFieldCodeRun.Add(tocFieldCode)

        Dim chapterTocEntryRun As New Run("1. First Chapter")

        Dim chapterReference As New PageReference()
        chapterReference.Value = "Chapter1"

        Dim chapterFieldCode As New FieldCode(chapterReference)

        Dim chapterFieldCodeRun As New Run()
        chapterFieldCodeRun.Add(chapterFieldCode)

        Dim subchapterTocEntryRun As New Run("1.1 First subchapter")

        Dim subchapterReference As New PageReference()
        subchapterReference.Value = "Subchapter1"

        Dim subchapterFieldCode As New FieldCode(subchapterReference)

        Dim subchapterFieldCodeRun As New Run()
        subchapterFieldCodeRun.Add(subchapterFieldCode)

        Dim tabRun As New Run()
        tabRun.AddTab()

        Dim tab1 As New Tab()
        tab1.Position = 9350
        tab1.Leader = TabLeaderCharacter.Dot
        tab1.Type = TabType.Right

        Dim tocStartParagraph As New Paragraph()
        tocStartParagraph.Add(startComplexFieldRun)
        tocStartParagraph.Add(tocFieldCodeRun)
        tocStartParagraph.Add(separatorComplexFieldRun)

        Dim chapterTocEntryParagraph As New Paragraph()
        chapterTocEntryParagraph.Tabs.Add(tab1)
        chapterTocEntryParagraph.Add(chapterTocEntryRun)
        chapterTocEntryParagraph.Add(tabRun)
        chapterTocEntryParagraph.Add(startComplexFieldRun)
        chapterTocEntryParagraph.Add(chapterFieldCodeRun)
        chapterTocEntryParagraph.Add(separatorComplexFieldRun)
        chapterTocEntryParagraph.Add(endComplexFieldRun)

        Dim subchapterTocEntryParagraph As New Paragraph()
        subchapterTocEntryParagraph.Tabs.Add(tab1)
        subchapterTocEntryParagraph.Add(subchapterTocEntryRun)
        subchapterTocEntryParagraph.Add(tabRun)
        subchapterTocEntryParagraph.Add(startComplexFieldRun)
        subchapterTocEntryParagraph.Add(subchapterFieldCodeRun)
        subchapterTocEntryParagraph.Add(separatorComplexFieldRun)
        subchapterTocEntryParagraph.Add(endComplexFieldRun)

        Dim tocEndParagraph As New Paragraph()
        tocEndParagraph.Add(endComplexFieldRun)

        Dim startBookmark1 As New BookmarkStart()
        startBookmark1.Name = "Chapter1"
        startBookmark1.ID = 1

        Dim endBookmark1 As New BookmarkEnd()
        endBookmark1.ID = 1

        Dim chapterRun As New Run("1. First Chapter")

        Dim chapterParagraph As New Paragraph()
        chapterParagraph.PageBreakBefore = ExtendedBoolean.[True]
        chapterParagraph.Add(startBookmark1)
        chapterParagraph.Add(chapterRun)
        chapterParagraph.Add(endBookmark1)

        Dim startBookmark2 As New BookmarkStart()
        startBookmark2.Name = "Subchapter1"
        startBookmark2.ID = 2

        Dim endBookmark2 As New BookmarkEnd()
        endBookmark2.ID = 2

        Dim subchapterRun As New Run("1.1 First Subchapter")

        Dim subchapterParagraph As New Paragraph()
        subchapterParagraph.PageBreakBefore = ExtendedBoolean.[True]
        subchapterParagraph.Add(startBookmark2)
        subchapterParagraph.Add(subchapterRun)
        subchapterParagraph.Add(endBookmark2)

        Dim chapterTocEntryStyle As New Style()
        chapterTocEntryStyle.ID = "TOC1"
        chapterTocEntryStyle.Name = "TocChapterStyle"
        chapterTocEntryStyle.Type = StyleType.Paragraph
        chapterTocEntryStyle.ParentStyleID = "Normal"
        chapterTocEntryStyle.ParagraphProperties.Indentation = New Indentation()
        chapterTocEntryStyle.ParagraphProperties.Indentation.Left = 240
        chapterTocEntryStyle.RunProperties.FontSize = 28
        chapterTocEntryStyle.RunProperties.Bold = ExtendedBoolean.[True]

        Dim subchapterTocEntryStyle As New Style()
        subchapterTocEntryStyle.ID = "TOC2"
        subchapterTocEntryStyle.Name = "TocSubchapterStyle"
        subchapterTocEntryStyle.Type = StyleType.Paragraph
        subchapterTocEntryStyle.ParentStyleID = "Normal"
        subchapterTocEntryStyle.ParagraphProperties.Indentation = New Indentation()
        subchapterTocEntryStyle.ParagraphProperties.Indentation.Left = 480
        subchapterTocEntryStyle.RunProperties.Italic = ExtendedBoolean.[True]

        doc.StyleDefinitions = New StyleDefinitions()
        doc.StyleDefinitions.Styles.Add(chapterTocEntryStyle)
        doc.StyleDefinitions.Styles.Add(subchapterTocEntryStyle)

        chapterTocEntryParagraph.StyleName = "TOC1"
        subchapterTocEntryParagraph.StyleName = "TOC2"

        doc.Body.Add(tocStartParagraph)
        doc.Body.Add(chapterTocEntryParagraph)
        doc.Body.Add(subchapterTocEntryParagraph)
        doc.Body.Add(tocEndParagraph)
        doc.Body.Add(chapterParagraph)
        doc.Body.Add(subchapterParagraph)


        doc.Save("c:\test\output.docx", True)

    End Sub
End Module