Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Styles

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument()

        Dim style1 As New Style()
        style1.ID = "Heading1" 'same as name
        style1.Name = "Heading1" 'style name
        style1.Type = StyleType.Paragraph
        style1.ParagraphProperties.KeepNext = ExtendedBoolean.[True]
        style1.ParagraphProperties.KeepLines = ExtendedBoolean.[True]
        style1.ParagraphProperties.OutlineLevel = 0

        style1.ParagraphProperties.Spacing = New Spacing()
        style1.ParagraphProperties.Spacing.Before = 240

        style1.RunProperties.FontSize = 32 'Font size 16
        style1.RunProperties.ComplexScriptFontSize = 32
        style1.RunProperties.Color = New RunContentColor("2E74B5")
        style1.RunProperties.Color.ThemeShade = &HBF
        style1.RunProperties.Color.ThemeColor = ThemeColor.Accent1

        doc.StyleDefinitions = New StyleDefinitions()
        doc.StyleDefinitions.Styles.Add(style1)

        Dim run As New Run()
        run.AddText("Heading Style")

        Dim paragraph As New Paragraph()
        paragraph.Add(run)
        paragraph.StyleName = "Heading1"

        doc.Body.Add(paragraph)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module