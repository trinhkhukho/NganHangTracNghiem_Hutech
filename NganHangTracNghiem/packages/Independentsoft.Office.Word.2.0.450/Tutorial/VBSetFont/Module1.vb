Imports System
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument

        Dim run1 As Run = New Run
        run1.AddText("Hello Word.")
        run1.AsciiFont = "Times New Roman"
        run1.HighAnsiFont = "Times New Roman"
        run1.FontSize = 28 '14 points

        Dim paragraph1 As Paragraph = New Paragraph
        paragraph1.Add(run1)

        doc.Body.Add(paragraph1)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module
