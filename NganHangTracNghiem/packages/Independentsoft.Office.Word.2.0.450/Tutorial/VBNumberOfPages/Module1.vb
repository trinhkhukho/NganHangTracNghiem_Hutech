Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Fields
Imports Independentsoft.Office.Word.HeaderFooter

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument()

        Dim pageNumber As New Page()
        Dim pageNumberField As New SimpleField(pageNumber)

        Dim totalPages As New NumberOfPages()
        Dim totalPagesField As New SimpleField(totalPages)

        Dim run1 As New Run()
        run1.AddText(" of ")

        Dim footerParagraph As New Paragraph()
        footerParagraph.Add(pageNumberField)
        footerParagraph.Add(run1)
        footerParagraph.Add(totalPagesField)
        footerParagraph.HorizontalTextAlignment = HorizontalAlignmentType.Left

        Dim footer As New Footer()
        footer.Add(footerParagraph)

        doc.Body.Footer = footer

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module