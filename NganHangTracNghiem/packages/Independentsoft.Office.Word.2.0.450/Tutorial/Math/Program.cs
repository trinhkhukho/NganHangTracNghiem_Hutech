using System;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Math;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            MathRun xRun = new MathRun("x");
            MathRun yRun = new MathRun("y");
            MathRun zRun = new MathRun("z");

            Numerator xNumerator = new Numerator();
            xNumerator.MathElements.Add(xRun);

            Denominator yDenominator = new Denominator();
            yDenominator.MathElements.Add(yRun);

            Denominator zDenominator = new Denominator();
            zDenominator.MathElements.Add(zRun);

            Fraction fraction1 = new Fraction(xNumerator, yDenominator);
            Fraction fraction2 = new Fraction(xNumerator, zDenominator);

            MathRun plusRun = new MathRun("+");
            MathRun resultRun = new MathRun("=100");

            OfficeMath math = new OfficeMath();
            math.MathElements.Add(fraction1);
            math.MathElements.Add(plusRun);
            math.MathElements.Add(fraction2);
            math.MathElements.Add(resultRun);
            
            Paragraph paragraph = new Paragraph();
            paragraph.Add(math);

            doc.Body.Add(paragraph);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
