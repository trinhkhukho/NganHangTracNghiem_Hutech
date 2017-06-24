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

            string text = doc.ToText();

            Console.WriteLine(text);
            Console.Read();
        }
    }
}
