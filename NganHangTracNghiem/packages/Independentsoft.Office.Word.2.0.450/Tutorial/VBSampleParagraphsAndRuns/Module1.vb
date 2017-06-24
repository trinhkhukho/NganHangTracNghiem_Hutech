Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument

        Dim run1 As Run = New Run
        run1.AddText("Hello Word!")
        run1.Italic = ExtendedBoolean.True

        Dim run2 As Run = New Run
        run2.AddText("Hello Word!")
        run2.Bold = ExtendedBoolean.True

        Dim run3 As Run = New Run
        run3.AddText("Hello Word!")
        run3.FontSize = 48

        Dim paragraph1 As Paragraph = New Paragraph
        paragraph1.Add(run1)

        Dim paragraph2 As Paragraph = New Paragraph
        paragraph2.Add(run2)

        Dim paragraph3 As Paragraph = New Paragraph
        paragraph3.Add(run3)

        Dim paragraph4 As Paragraph = New Paragraph
        paragraph4.Add(run1)
        paragraph4.Add(run2)
        paragraph4.Add(run3)

        doc.Body.Add(paragraph1)
        doc.Body.Add(paragraph2)
        doc.Body.Add(paragraph3)
        doc.Body.Add(paragraph4)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module
