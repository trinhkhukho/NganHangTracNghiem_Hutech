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

			for (int i = 0; i < doc.Body.Content.Count; i++) 
			{				
				if (doc.Body.Content[i] is Paragraph) 
				{
                    Paragraph paragraph = (Paragraph)doc.Body.Content[i];

					for (int j=0; j < paragraph.Content.Count; j++) 
					{									
						if (paragraph.Content[j] is BookmarkStart) 
						{
                            BookmarkStart bookmarkStart = (BookmarkStart)paragraph.Content[j];

							if (bookmarkStart.Name == "mybookmark") 
							{								
								Run run1 = new Run();
								run1.AddText("some text");
                                run1.Bold = ExtendedBoolean.True;
								
								paragraph.Content.Insert(j,run1);
								break;
							}
						} 
					}
				}
			}

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
