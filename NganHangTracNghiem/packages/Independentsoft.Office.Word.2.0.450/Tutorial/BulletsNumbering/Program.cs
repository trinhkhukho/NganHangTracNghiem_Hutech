using System;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Numbering;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            NumberingLevel level0 = new NumberingLevel();
            level0.Level = 0;
            level0.Start = 1;
            level0.Justification = HorizontalAlignmentType.Left;
            level0.Format = NumberingFormat.Bullet;
            level0.RunProperties.Fonts.AsciiFont = "Wingdings";
            level0.RunProperties.Fonts.HighAnsiFont = "Wingdings";

            byte[] bulletBuffer = new byte[3];
            bulletBuffer[0] = (byte)239;
            bulletBuffer[1] = (byte)130;
            bulletBuffer[2] = (byte)167;

            level0.Text = new NumberingLevelText(System.Text.Encoding.UTF8.GetString(bulletBuffer));

            AbstractNumbering abstractNumbering = new AbstractNumbering();
            abstractNumbering.ID = 1;
            abstractNumbering.Levels.Add(level0);

            NumberingReference numbering1 = new NumberingReference(2);
            numbering1.NumberingLevelID = 0;
            numbering1.NumberingID = 1;

            NumberingDefinitionInstance numberingInstance = new NumberingDefinitionInstance();
            numberingInstance.ID = 1;
            numberingInstance.AbstractNumberingID = 1;

            NumberingDefinitions numberingDefinitions = new NumberingDefinitions();
            numberingDefinitions.Numberings.Add(numberingInstance);
            numberingDefinitions.AbstractNumberings.Add(abstractNumbering);

            doc.NumberingDefinitions = numberingDefinitions;

            Run run1 = new Run();
            run1.AddText("First");

            Run run2 = new Run();
            run2.AddText("Second");

            Run run3 = new Run();
            run3.AddText("Third");

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);
            paragraph1.NumberingReference = numbering1;

            Paragraph paragraph2 = new Paragraph();
            paragraph2.Add(run2);
            paragraph2.NumberingReference = numbering1;

            Paragraph paragraph3 = new Paragraph();
            paragraph3.Add(run3);
            paragraph3.NumberingReference = numbering1;

            doc.Body.Add(paragraph1);
            doc.Body.Add(paragraph2);
            doc.Body.Add(paragraph3);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
