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

            foreach (IBlockElement blockElement in doc.Body.Content)
            {
                if (blockElement is Paragraph)
                {
                    Paragraph paragraph = (Paragraph)blockElement;

                    long bookmarkID = -1;
                    string bookmarkName = null;
                    string bookmarkText = null;

                    for (int i = 0; i < paragraph.Content.Count; i++)
                    {
                        if (paragraph.Content[i] is BookmarkStart)
                        {
                            BookmarkStart bookmarkStart = (BookmarkStart)paragraph.Content[i];

                            bookmarkID = bookmarkStart.ID;
                            bookmarkName = bookmarkStart.Name;
                            bookmarkText = "";
                        }

                        if (paragraph.Content[i] is BookmarkEnd)
                        {
                            BookmarkEnd bookmarkEnd = (BookmarkEnd)paragraph.Content[i];

                            if (bookmarkEnd.ID == bookmarkID)
                            {
                                Console.WriteLine("Bookmark ID = " + bookmarkID);
                                Console.WriteLine("Bookmark Name = " + bookmarkName);
                                Console.WriteLine("Bookmark Text = " + bookmarkText);
                            }
                        }

                        if (paragraph.Content[i] is Run)
                        {
                            Run run = (Run)paragraph.Content[i];

                            for (int j = 0; j < run.Content.Count; j++)
                            {
                                if (run.Content[j] is Text)
                                {
                                    Text text = (Text)run.Content[j];
                                    bookmarkText += text.Value;
                                }
                            }
                        }

                    }
                }
            }

            Console.Read();
        }
    }
}
