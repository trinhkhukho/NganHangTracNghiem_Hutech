Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.HeaderFooter

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument

        Dim run1 As Run = New Run
        run1.AddText("Hello Word!")

        Dim paragraph1 As Paragraph = New Paragraph
        paragraph1.Add(run1)

        Dim headerRun As Run = New Run
        headerRun.AddText("Header text")

        Dim headerParagraph As Paragraph = New Paragraph
        headerParagraph.Add(headerRun)
        headerParagraph.HorizontalTextAlignment = HorizontalAlignmentType.Right

        Dim header As Header = New Header
        header.Add(headerParagraph)

        Dim footerRun As Run = New Run
        footerRun.AddText("Footer text")

        Dim footerParagraph As Paragraph = New Paragraph
        footerParagraph.Add(footerRun)
        footerParagraph.HorizontalTextAlignment = HorizontalAlignmentType.Center

        Dim footer As Footer = New Footer
        footer.Add(footerParagraph)

        doc.Body.Add(paragraph1)
        doc.Body.Header = header
        doc.Body.Footer = footer

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module