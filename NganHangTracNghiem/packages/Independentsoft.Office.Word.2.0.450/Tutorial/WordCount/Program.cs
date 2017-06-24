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

            string[] separator = new string[] { " ", "\r\n", "\t" };

            string[] words = text.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            Console.WriteLine("Word count = " + words.Length);
            Console.Read();

        }
    }
}