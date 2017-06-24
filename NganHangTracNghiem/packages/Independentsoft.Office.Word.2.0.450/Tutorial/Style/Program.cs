using System;
using Independentsoft.Office;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Fonts;
using Independentsoft.Office.Word.Styles;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            Style style1 = new Style();
            style1.ID = "Heading 1";
            style1.Name = "Heading 1";
            style1.Type = StyleType.Paragraph;
            style1.Primary = ExtendedBoolean.True;
            style1.UserInterfacePriority = 9;

            style1.ParagraphProperties.KeepNext = ExtendedBoolean.True;
            style1.ParagraphProperties.KeepLines = ExtendedBoolean.True;
            style1.ParagraphProperties.OutlineLevel = 0;

            Spacing spacing1 = new Spacing();
            spacing1.After = 0;
            spacing1.Before = 480;

            style1.ParagraphProperties.Spacing = spacing1;

            style1.RunProperties.Fonts.AsciiThemeFont = ThemeFont.MajorHighAnsi;
            style1.RunProperties.Fonts.EastAsiaThemeFont = ThemeFont.MajorEastAsia;
            style1.RunProperties.Fonts.HighAnsiThemeFont = ThemeFont.MajorHighAnsi;
            style1.RunProperties.Fonts.ComplexScriptThemeFont = ThemeFont.MajorComplexScript;
            style1.RunProperties.Bold = ExtendedBoolean.True;
            style1.RunProperties.ComplexScriptBold = ExtendedBoolean.True;
            style1.RunProperties.FontSize = 28; //14 points
            style1.RunProperties.ComplexScriptFontSize = 28; //14 points
           
            Style style2 = new Style();
            style2.ID = "Title";
            style2.Name = "Title";
            style2.Type = StyleType.Paragraph;
            style2.Primary = ExtendedBoolean.True;
            style2.UserInterfacePriority = 9;
           
            BottomBorder bottomBorder = new BottomBorder(StandardBorderStyle.SingleLine);
            bottomBorder.Space = 4;
            bottomBorder.Width = 8;

            style2.ParagraphProperties.BottomBorder = bottomBorder;
            style2.ParagraphProperties.IgnoreSpace = ExtendedBoolean.True;

            Spacing spacing2 = new Spacing();
            spacing2.After = 300;
            spacing2.Line = 240;
            spacing2.LineRule = LineSpacingRule.Auto;

            style2.ParagraphProperties.Spacing = spacing2;

            style2.RunProperties.Fonts.AsciiThemeFont = ThemeFont.MajorHighAnsi;
            style2.RunProperties.Fonts.EastAsiaThemeFont = ThemeFont.MajorEastAsia;
            style2.RunProperties.Fonts.HighAnsiThemeFont = ThemeFont.MajorHighAnsi;
            style2.RunProperties.Fonts.ComplexScriptThemeFont = ThemeFont.MajorComplexScript;
            style2.RunProperties.Spacing = 5;
            style2.RunProperties.FontKern = 28;
            style2.RunProperties.FontSize = 52; //26 points
            style2.RunProperties.ComplexScriptFontSize = 52; //26 points

            StyleDefinitions documentStyles = new StyleDefinitions();
            documentStyles.Styles.Add(style1);
            documentStyles.Styles.Add(style2);

            doc.StyleDefinitions = documentStyles;

            Run run1 = new Run();
            run1.AddText("Text with style \"Heading 1\"");

            Run run2 = new Run();
            run2.AddText("Text with style \"Title\"");

            Paragraph paragraph1 = new Paragraph();
            paragraph1.StyleName = "Heading 1";
            paragraph1.Add(run1);

            Paragraph paragraph2 = new Paragraph();
            paragraph2.StyleName = "Title";
            paragraph2.Add(run2);

            Paragraph emptyParagraph = new Paragraph();

            doc.Body.Add(paragraph1);
            doc.Body.Add(emptyParagraph);
            doc.Body.Add(paragraph2);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
