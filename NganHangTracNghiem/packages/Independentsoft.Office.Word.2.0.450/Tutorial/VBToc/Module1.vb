Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Fields

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

        Dim firstChapterTocEntryRun As New Run("First chapter")

        Dim firstChapterReference As New PageReference()
        firstChapterReference.Value = "TocEntry1"

        Dim firstChapterFieldCode As New FieldCode(firstChapterReference)

        Dim firstChapterFieldCodeRun As New Run()
        firstChapterFieldCodeRun.Add(firstChapterFieldCode)

        Dim secondChapterTocEntryRun As New Run("Second chapter")

        Dim secondChapterReference As New PageReference()
        secondChapterReference.Value = "TocEntry2"

        Dim secondChapterFieldCode As New FieldCode(secondChapterReference)

        Dim secondChapterFieldCodeRun As New Run()
        secondChapterFieldCodeRun.Add(secondChapterFieldCode)

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

        Dim firstTocEntryParagraph As New Paragraph()
        firstTocEntryParagraph.Tabs.Add(tab1)
        firstTocEntryParagraph.Add(firstChapterTocEntryRun)
        firstTocEntryParagraph.Add(tabRun)
        firstTocEntryParagraph.Add(startComplexFieldRun)
        firstTocEntryParagraph.Add(firstChapterFieldCodeRun)
        firstTocEntryParagraph.Add(separatorComplexFieldRun)
        firstTocEntryParagraph.Add(endComplexFieldRun)

        Dim secondTocEntryParagraph As New Paragraph()
        secondTocEntryParagraph.Tabs.Add(tab1)
        secondTocEntryParagraph.Add(secondChapterTocEntryRun)
        secondTocEntryParagraph.Add(tabRun)
        secondTocEntryParagraph.Add(startComplexFieldRun)
        secondTocEntryParagraph.Add(secondChapterFieldCodeRun)
        secondTocEntryParagraph.Add(separatorComplexFieldRun)
        secondTocEntryParagraph.Add(endComplexFieldRun)

        Dim tocEndParagraph As New Paragraph()
        tocEndParagraph.Add(endComplexFieldRun)

        Dim startBookmark1 As New BookmarkStart()
        startBookmark1.Name = "TocEntry1"
        startBookmark1.ID = 1

        Dim endBookmark1 As New BookmarkEnd()
        endBookmark1.ID = 1

        Dim firstChapterRun As New Run("First Chapter")

        Dim firstChapterParagraph As New Paragraph()
        firstChapterParagraph.PageBreakBefore = ExtendedBoolean.[True]
        firstChapterParagraph.Add(startBookmark1)
        firstChapterParagraph.Add(firstChapterRun)
        firstChapterParagraph.Add(endBookmark1)

        Dim startBookmark2 As New BookmarkStart()
        startBookmark2.Name = "TocEntry2"
        startBookmark2.ID = 2

        Dim endBookmark2 As New BookmarkEnd()
        endBookmark2.ID = 2

        Dim secondChapterRun As New Run("Second Chapter")

        Dim secondChapterParagraph As New Paragraph()
        secondChapterParagraph.PageBreakBefore = ExtendedBoolean.[True]
        secondChapterParagraph.Add(startBookmark2)
        secondChapterParagraph.Add(secondChapterRun)
        secondChapterParagraph.Add(endBookmark2)

        doc.Body.Add(tocStartParagraph)
        doc.Body.Add(firstTocEntryParagraph)
        doc.Body.Add(secondTocEntryParagraph)
        doc.Body.Add(tocEndParagraph)
        doc.Body.Add(firstChapterParagraph)
        doc.Body.Add(secondChapterParagraph)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module