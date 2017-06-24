Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument

        Dim run1 As Run = New Run
        run1.AddText("See background color!")

        Dim paragraph1 As Paragraph = New Paragraph
        paragraph1.Add(run1)

        doc.Body.Add(paragraph1)

        Dim background As Background = New Background
        background.ThemeColor = ThemeColor.Accent5

        doc.Background = background
        doc.Settings.DisplayBackgroundShape = ExtendedBoolean.True

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module
