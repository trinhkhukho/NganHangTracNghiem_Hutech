Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Sections

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument()

        Dim margins As New PageMargins()
        margins.Bottom = 1440 ' 1 inch
        margins.Left = 1440 ' 1 inch
        margins.Right = 1440 ' 1 inch
        margins.Top = 1440 ' 1 inch
        margins.Footer = 720 ' 1/2 inch
        margins.Header = 720 ' 1/2 inch

        Dim pageSize As New PageSize(12240, 15840) '8.5 x 11 inch
        pageSize.PageOrientation = PageOrientation.Landscape

        Dim section As New Section()
        section.PageSize = pageSize
        section.PageMargins = margins

        doc.Body.Section = section

        Dim run As New Run()
        run.AddText("Page size is 8.5 x 11 inch (Letter).")

        Dim paragraph As New Paragraph()
        paragraph.Add(run)

        doc.Body.Add(paragraph)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module