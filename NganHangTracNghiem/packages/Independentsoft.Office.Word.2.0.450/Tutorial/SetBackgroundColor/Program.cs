using System;
using Independentsoft.Office;
using Independentsoft.Office.Word;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            Run run1 = new Run();
            run1.AddText("See background color!");

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);

            doc.Body.Add(paragraph1);

            Background background = new Background();
            background.ThemeColor = ThemeColor.Accent5;

            doc.Background = background;
            doc.Settings.DisplayBackgroundShape = ExtendedBoolean.True;

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
