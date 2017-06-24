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

            IList<IContentElement> allElements = doc.GetContentElements();

            foreach (IContentElement element in allElements)
            {
                if (element is Paragraph)
                {
                    Paragraph paragraph = (Paragraph)element;

                    for (int i = 0; i < paragraph.Content.Count; i++)
                    {
                        if (paragraph.Content[i] is Run)
                        {
                            Run run = (Run)paragraph.Content[i];

                            for (int r = 0; r < run.Content.Count; r++)
                            {
                                if (run.Content[r] is ComplexField)
                                {
                                    ComplexField complexField = (ComplexField)run.Content[r];

                                    if (complexField.FormFieldProperties != null && complexField.FormFieldProperties.Name == "CheckBox1" && complexField.FormFieldProperties.CheckBoxFormFieldProperties != null)
                                    {
                                        complexField.FormFieldProperties.CheckBoxFormFieldProperties.Checked = ExtendedBoolean.True;
                                    }
                                }
                            }
                        }
                    }
                }
            }

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
