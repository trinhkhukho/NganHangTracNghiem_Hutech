Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument()

        Dim run1 As Run = New Run()
        run1.AddText("Center alignment.")

        Dim run2 As Run = New Run()
        run2.AddText("Left alignment.")

        Dim run3 As Run = New Run()
        run3.AddText("Right alignment.")

        Dim paragraph1 As Paragraph = New Paragraph()
        paragraph1.Add(run1)
        paragraph1.HorizontalTextAlignment = HorizontalAlignmentType.Center

        Dim paragraph2 As Paragraph = New Paragraph()
        paragraph2.Add(run2)
        paragraph2.HorizontalTextAlignment = HorizontalAlignmentType.Left

        Dim paragraph3 As Paragraph = New Paragraph()
        paragraph3.Add(run3)
        paragraph3.HorizontalTextAlignment = HorizontalAlignmentType.Right

        doc.Body.Add(paragraph1)
        doc.Body.Add(New Paragraph()) ''empty paragraph
        doc.Body.Add(paragraph2)
        doc.Body.Add(New Paragraph()) ''empty paragraph
        doc.Body.Add(paragraph3)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module