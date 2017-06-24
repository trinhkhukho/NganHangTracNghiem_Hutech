using System;
using Independentsoft.Office;
using Independentsoft.Office.Word;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument("c:\\test\\input.docx");

            doc.Replace("[CustomerID]", "12345");
            doc.Replace("[CustomerName]","John Smith");

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
