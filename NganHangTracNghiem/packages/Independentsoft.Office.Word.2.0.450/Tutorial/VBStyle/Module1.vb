Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Fonts
Imports Independentsoft.Office.Word.Styles

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument()

        Dim style1 As Style = New Style
        style1.ID = "Heading 1"
        style1.Name = "Heading 1"
        style1.Type = StyleType.Paragraph
        style1.Primary = ExtendedBoolean.True
        style1.UserInterfacePriority = 9
        style1.ParagraphProperties.KeepNext = ExtendedBoolean.True
        style1.ParagraphProperties.KeepLines = ExtendedBoolean.True
        style1.ParagraphProperties.OutlineLevel = 0

        Dim spacing1 As Spacing = New Spacing
        spacing1.After = 0
        spacing1.Before = 480

        style1.ParagraphProperties.Spacing = spacing1

        style1.RunProperties.Fonts.AsciiThemeFont = ThemeFont.MajorHighAnsi
        style1.RunProperties.Fonts.EastAsiaThemeFont = ThemeFont.MajorEastAsia
        style1.RunProperties.Fonts.HighAnsiThemeFont = ThemeFont.MajorHighAnsi
        style1.RunProperties.Fonts.ComplexScriptThemeFont = ThemeFont.MajorComplexScript
        style1.RunProperties.Bold = ExtendedBoolean.True
        style1.RunProperties.ComplexScriptBold = ExtendedBoolean.True
        style1.RunProperties.FontSize = 28 '14 points
        style1.RunProperties.ComplexScriptFontSize = 28 '14 points

        Dim style2 As Style = New Style
        style2.ID = "Title"
        style2.Name = "Title"
        style2.Type = StyleType.Paragraph
        style2.Primary = ExtendedBoolean.True
        style2.UserInterfacePriority = 9

        Dim bottomBorder As BottomBorder = New BottomBorder(StandardBorderStyle.SingleLine)
        bottomBorder.Space = 4
        bottomBorder.Width = 8

        style2.ParagraphProperties.BottomBorder = bottomBorder

        style2.ParagraphProperties.IgnoreSpace = ExtendedBoolean.True

        Dim spacing2 As Spacing = New Spacing
        spacing2.After = 300
        spacing2.Line = 240
        spacing2.LineRule = LineSpacingRule.Auto

        style2.ParagraphProperties.Spacing = spacing2

        style2.RunProperties.Fonts.AsciiThemeFont = ThemeFont.MajorHighAnsi
        style2.RunProperties.Fonts.EastAsiaThemeFont = ThemeFont.MajorEastAsia
        style2.RunProperties.Fonts.HighAnsiThemeFont = ThemeFont.MajorHighAnsi
        style2.RunProperties.Fonts.ComplexScriptThemeFont = ThemeFont.MajorComplexScript
        style2.RunProperties.Spacing = 5
        style2.RunProperties.FontKern = 28
        style2.RunProperties.FontSize = 52 '26 points
        style2.RunProperties.ComplexScriptFontSize = 52 '26 points

        Dim documentStyles As StyleDefinitions = New StyleDefinitions
        documentStyles.Styles.Add(style1)
        documentStyles.Styles.Add(style2)

        doc.StyleDefinitions = documentStyles

        Dim run1 As Run = New Run
        run1.AddText("Text with style ""Heading 1""")

        Dim run2 As Run = New Run
        run2.AddText("Text with style ""Title""")

        Dim paragraph1 As Paragraph = New Paragraph
        paragraph1.StyleName = "Heading 1"
        paragraph1.Add(run1)

        Dim paragraph2 As Paragraph = New Paragraph
        paragraph2.StyleName = "Title"
        paragraph2.Add(run2)

        Dim emptyParagraph As Paragraph = New Paragraph

        doc.Body.Add(paragraph1)
        doc.Body.Add(emptyParagraph)
        doc.Body.Add(paragraph2)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module