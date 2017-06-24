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

            IList<IPicture> pictures = doc.GetPictures();

            foreach (IPicture picture in pictures)
            {
                picture.Save("c:\\test\\" + picture.FileName, true);
            }
        }
    }
}
