using System;
using Independentsoft.Office.Word;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            Run run1 = new Run();
            run1.AddText("[Your Name]");
            run1.AddCarriageReturn();
            run1.AddText("[Street Address]");
            run1.AddCarriageReturn();
            run1.AddText("[City, ST ZIP Code]");
            run1.AddCarriageReturn();
            run1.AddText("September 25, 2006");
            run1.FontSize = 24; //12 points

            Run run2 = new Run();
            run2.AddText("[Recipient Name]");
            run2.AddCarriageReturn();
            run2.AddText("[Title]");
            run2.AddCarriageReturn();
            run2.AddText("[Company Name]");
            run2.AddCarriageReturn();
            run2.AddText("[Street Address]");
            run2.AddCarriageReturn();
            run2.AddText("[City, ST ZIP Code]");
            run2.FontSize = 24; //12 points

            Run run3 = new Run();
            run3.AddText("Dear [Recipient Name]");
            run3.FontSize = 24; //12 points

            Run run4 = new Run();
            run4.AddText("Due to an oversight on our part, this month’s payment, in the amount of $[__] and due on [date], was mailed just today. Our account number is [account number]. Please forgive our inattention. If you have any questions, please contact me at [phone number].");
            run4.FontSize = 24; //12 points

            Run run5 = new Run();
            run5.AddText("Sincerely,");
            run5.FontSize = 24; //12 points

            Run run6 = new Run();
            run6.AddText("[Your Name]");
            run6.AddCarriageReturn();
            run6.AddText("[Title]");
            run6.FontSize = 24; //12 points

            Paragraph emptyParagraph = new Paragraph();

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);

            Paragraph paragraph2 = new Paragraph();
            paragraph2.Add(run2);

            Paragraph paragraph3 = new Paragraph();
            paragraph3.Add(run3);

            Paragraph paragraph4 = new Paragraph();
            paragraph4.Add(run4);

            Paragraph paragraph5 = new Paragraph();
            paragraph5.Add(run5);

            Paragraph paragraph6 = new Paragraph();
            paragraph6.Add(run6);

            doc.Body.Add(paragraph1);
            doc.Body.Add(emptyParagraph);
            doc.Body.Add(paragraph2);
            doc.Body.Add(emptyParagraph);
            doc.Body.Add(paragraph3);
            doc.Body.Add(paragraph4);
            doc.Body.Add(paragraph5);
            doc.Body.Add(emptyParagraph);
            doc.Body.Add(paragraph6);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
