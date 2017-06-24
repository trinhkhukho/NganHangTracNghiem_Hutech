using System;
using Independentsoft.Office;
using Independentsoft.Office.Word;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument first = new WordDocument("c:\\test\\first.docx");
            WordDocument second = new WordDocument("c:\\test\\second.docx");

            foreach (IBlockElement element in second.Body.Content)
            {
                first.Body.Add(element);
            }

            first.Save("c:\\test\\output.docx");
        }
    }
}
