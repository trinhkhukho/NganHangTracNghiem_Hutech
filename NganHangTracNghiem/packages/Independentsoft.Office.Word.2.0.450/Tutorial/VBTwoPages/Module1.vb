Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Sections

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument()

        Dim margins As PageMargins = New PageMargins
        margins.Bottom = 1440 '1 inch
        margins.Left = 1440 '1 inch
        margins.Right = 1440 '1 inch
        margins.Top = 1440 '1 inch
        margins.Footer = 720 '1/2 inch
        margins.Header = 720 '1/2 inch

        Dim section As Section = New Section
        section.PageSize = New PageSize(12240, 15840) '8.5 x 11 in
        section.PageMargins = margins

        Dim run1 As Run = New Run
        run1.AddText("Some text on the first page.")

        Dim paragraph1 As Paragraph = New Paragraph
        paragraph1.Add(run1)

        Dim paragraph2 As Paragraph = New Paragraph
        paragraph2.Add(run1)

        Dim paragraph3 As Paragraph = New Paragraph
        paragraph3.Add(run1)
        paragraph3.Section = section 'last paragraph on the first page

        'first page
        doc.Body.Add(paragraph1)
        doc.Body.Add(paragraph2)
        doc.Body.Add(paragraph3)

        Dim run2 As Run = New Run
        run2.AddText("Some text on the second page.")

        Dim paragraph4 As Paragraph = New Paragraph
        paragraph4.Add(run2)

        'second page
        doc.Body.Add(paragraph4)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module