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
            string customerID = "12345";
            string customerName = "John Smith";
            string customerAddress = "123 Way, New York, NY 10019";

            WordDocument doc = new WordDocument("c:\\template.docx");

            IList<IContentElement> docElements = doc.GetContentElements();

            foreach (IContentElement docElement in docElements)
            {
                if (docElement is SimpleField)
                {
                    SimpleField simpleField = (SimpleField)docElement;

                    if (simpleField.Field is MergeField)
                    {
                        MergeField mergeField = (MergeField)simpleField.Field;

                        if (mergeField.Name == "CustomerID")
                        {
                            Run run = new Run(customerID);

                            simpleField.Content.Clear();
                            simpleField.Add(run);
                        }
                        else if (mergeField.Name == "CustomerName")
                        {
                            Run run = new Run(customerName);

                            simpleField.Content.Clear();
                            simpleField.Add(run);
                        }
                        else if (mergeField.Name == "CustomerAddress")
                        {
                            Run run = new Run(customerAddress);

                            simpleField.Content.Clear();
                            simpleField.Add(run);
                        }
                    }
                }
            }

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
