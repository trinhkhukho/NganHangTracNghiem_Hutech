using System;
using System.Collections.Generic;
using Independentsoft.Office;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Fields;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument("c:\\test\\input.docx");

            IList<IContentElement> docElements = doc.GetContentElements();

            foreach (IContentElement docElement in docElements)
            {
                if (docElement is SimpleField)
                {
                    SimpleField simpleField = (SimpleField)docElement;

                    if (simpleField.Field is MergeField)
                    {
                        MergeField mergeField = (MergeField)simpleField.Field;
                        
                        string fieldValue = "";

                        IList<IContentElement> simpleFieldElements = simpleField.GetContentElements();

                        foreach(IContentElement element in simpleFieldElements)
                        {
                            if(element is Text)
                            {
                                Text text = (Text)element;
                                fieldValue += text.Value;
                            }
                        }

                        Console.WriteLine("MergeField name = " + mergeField.Name);
                        Console.WriteLine("MergeField value = " + fieldValue);
                    }
                }
            }

            Console.Read();
        }
    }
}
