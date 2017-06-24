using System;
using System.Collections.Generic;
using Independentsoft.Office;
using Independentsoft.Office.Word;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument("c:\\test\\input.docx");

            IList<IContentElement> elements = doc.GetContentElements();

            foreach (IContentElement element in elements)
            {
                if (element is Hyperlink)
                {
                    Hyperlink link = (Hyperlink)element;

                    Console.WriteLine("Target = " + link.Target);
                }
            }

            Console.Read();
        }
    }
}
