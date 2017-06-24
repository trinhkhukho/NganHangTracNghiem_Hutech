using System;
using System.Collections.Generic;
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
					Paragraph paragraph = (Paragraph) doc.Body.Content[i];

					long bookmarkId = -1;
					IList<IParagraphContent> contentToRemove = new List<IParagraphContent>();

					foreach (IParagraphContent pContent in paragraph.Content) 
					{
						if (pContent is BookmarkStart) 
						{
							BookmarkStart bookmarkStart = (BookmarkStart) pContent;

							if (bookmarkStart.Name == "REMOVE") 
							{
								bookmarkId = bookmarkStart.ID;
							}
						}
						else if (pContent is BookmarkEnd) 
						{
							BookmarkEnd bookmarkEnd = (BookmarkEnd) pContent;

							if (bookmarkEnd.ID == bookmarkId) 
							{
								bookmarkId = -1;
							}
						}
						else if (pContent is Run && bookmarkId > -1) 
						{
							Run run = (Run) pContent;

							contentToRemove.Add(run);
						}
					}

					if (contentToRemove.Count > 0) 
					{
						foreach (IParagraphContent element in contentToRemove) 
						{
							paragraph.Content.Remove(element);
						}
					}
				}
			}

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
