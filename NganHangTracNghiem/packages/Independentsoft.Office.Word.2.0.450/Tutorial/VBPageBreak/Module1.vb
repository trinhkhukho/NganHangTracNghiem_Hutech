Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument

        Dim run1 As Run = New Run()
        run1.AddText("Some text on the first page.")

        Dim paragraph1 As Paragraph = New Paragraph()
        paragraph1.Add(run1)

        Dim run2 As Run = New Run()
        run2.AddText("Some text on the second page.")

        Dim paragraph2 As Paragraph = New Paragraph()
        paragraph2.Add(run2)
        paragraph2.PageBreakBefore = ExtendedBoolean.True

        doc.Body.Add(paragraph1) 'on the first page
        doc.Body.Add(paragraph2) 'on the second page

        doc.Save("c:\test\input.docx", True)

    End Sub
End Module