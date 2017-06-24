using System;
using Independentsoft.Office;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Styles;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            Style style1 = new Style();
            style1.ID = "Heading1"; //same as name
            style1.Name = "Heading1"; //style name
            style1.Type = StyleType.Paragraph;
            style1.ParagraphProperties.KeepNext = ExtendedBoolean.True;
            style1.ParagraphProperties.KeepLines = ExtendedBoolean.True;
            style1.ParagraphProperties.OutlineLevel = 0;

            style1.ParagraphProperties.Spacing = new Spacing();
            style1.ParagraphProperties.Spacing.Before = 240;

            style1.RunProperties.FontSize = 32; //Font size 16
            style1.RunProperties.ComplexScriptFontSize = 32;
            style1.RunProperties.Color = new RunContentColor("2E74B5");
            style1.RunProperties.Color.ThemeShade = 0xBF;
            style1.RunProperties.Color.ThemeColor = ThemeColor.Accent1;

            doc.StyleDefinitions = new StyleDefinitions();
            doc.StyleDefinitions.Styles.Add(style1);

            Run run = new Run();
            run.AddText("Heading Style");

            Paragraph paragraph = new Paragraph();
            paragraph.Add(run);
            paragraph.StyleName = "Heading1";

            doc.Body.Add(paragraph);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
