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

            NumberingReference numbering1 = new NumberingReference(1);
            
            NumberingReference numbering2 = new NumberingReference(2);
            numbering2.NumberingLevelID = 2;

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

            Paragraph paragraph4 = new Paragraph();
            paragraph4.Add(run1);
            paragraph4.NumberingReference = numbering2;

            Paragraph paragraph5 = new Paragraph();
            paragraph5.Add(run2);
            paragraph5.NumberingReference = numbering2;

            Paragraph paragraph6 = new Paragraph();
            paragraph6.Add(run3);
            paragraph6.NumberingReference = numbering2;

            doc.Body.Add(paragraph1);
            doc.Body.Add(paragraph2);
            doc.Body.Add(paragraph3);
            doc.Body.Add(paragraph4);
            doc.Body.Add(paragraph5);
            doc.Body.Add(paragraph6);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
