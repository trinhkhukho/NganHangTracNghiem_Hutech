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

            IList<Paragraph> paragraphs = doc.GetParagraphs();

            foreach(Paragraph paragraph in paragraphs)
            {
                String paragraphText = "";

                for (int j = 0; j < paragraph.Content.Count; j++)
                {
                    if (paragraph.Content[j] is Run)
                    {
                        Run run = (Run)paragraph.Content[j];
                        String runText = "";

                        foreach (IRunContent runElement in run.Content)
                        {
                            if (runElement is Text)
                            {
                                Text currentText = (Text)runElement;

                                runText += currentText.Value;
                                paragraphText += currentText.Value;
                            }
                        }

                        if (runText.IndexOf("my text") > -1)
                        {
                            //found text inside current run object
                        }
                    }
                }
  
                if (paragraphText.IndexOf("my text") > -1)
                {
                    //found text inside current paragraph object
                }
            }
        }
    }
}
