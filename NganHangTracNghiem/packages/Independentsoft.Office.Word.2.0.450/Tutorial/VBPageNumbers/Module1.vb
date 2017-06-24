Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Fields
Imports Independentsoft.Office.Word.HeaderFooter

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument

        Dim pageNumber As New Page()
        Dim simpleField As New SimpleField(pageNumber)

        Dim footerParagraph As New Paragraph()
        footerParagraph.Add(simpleField)
        footerParagraph.HorizontalTextAlignment = HorizontalAlignmentType.Center

        Dim footer As New Footer()
        footer.Add(footerParagraph)

        Dim run1 As New Run()
        run1.AddText("Hello Word!")

        Dim paragraph1 As New Paragraph()
        paragraph1.Add(run1)

        doc.Body.Add(paragraph1)
        doc.Body.Footer = footer

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module