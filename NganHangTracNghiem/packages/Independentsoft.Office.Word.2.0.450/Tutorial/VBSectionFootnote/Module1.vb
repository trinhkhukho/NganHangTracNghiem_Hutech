Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Sections
Imports Independentsoft.Office.Word.FootnoteEndnote

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument()

        Dim footnote1 As New Footnote(1)
        Dim footnoteReference As New FootnoteReference(1)

        Dim footnoteRun1 As New Run()
        footnoteRun1.VerticalAlignment = VerticalAlignment.Superscript
        footnoteRun1.AddFootnoteReferenceMark()

        Dim footnoteRun2 As New Run()
        footnoteRun2.AddText("Footnote text.")

        Dim footnoteParagraph As New Paragraph()
        footnoteParagraph.Add(footnoteRun1)
        footnoteParagraph.Add(footnoteRun2)

        footnote1.Content.Add(footnoteParagraph)

        Dim run1 As New Run()
        run1.AddText("Hello Word")

        Dim footnoteReferenceRun As New Run()
        footnoteReferenceRun.VerticalAlignment = VerticalAlignment.Superscript
        footnoteReferenceRun.Add(footnoteReference)

        Dim paragraph1 As New Paragraph()
        paragraph1.Add(run1)
        paragraph1.Add(footnoteReferenceRun)

        doc.Body.Add(paragraph1)
        doc.Footnotes.Add(footnote1)

        Dim section As New Section()
        section.PageSize = New PageSize(12240, 15840)
        '8.5 x 11 in
        section.FootnoteProperties.NumberingFormat = NumberingFormat.[Decimal]

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module