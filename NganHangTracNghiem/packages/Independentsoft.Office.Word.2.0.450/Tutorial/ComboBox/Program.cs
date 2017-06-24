using System;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.CustomMarkup;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();
            
            StructuredDocumentTag sdt = new StructuredDocumentTag();
            sdt.Properties.Tag = "Test Combox Box";
            sdt.Properties.Alias = "Test Combox Box";

            sdt.Properties.ComboBox = new ComboBox();

            ComboBoxListItem item1 = new ComboBoxListItem();
            item1.DisplayText = "1";
            item1.Value = "1";

            ComboBoxListItem item2 = new ComboBoxListItem();
            item2.DisplayText = "2";
            item2.Value = "2";

            ComboBoxListItem item3 = new ComboBoxListItem();
            item3.DisplayText = "3";
            item3.Value = "3";

            sdt.Properties.ComboBox.Items.Add(item1);
            sdt.Properties.ComboBox.Items.Add(item2);
            sdt.Properties.ComboBox.Items.Add(item3);

            Run run = new Run();
            run.AddText("Choose an item.");

            Paragraph paragraph = new Paragraph();
            paragraph.Add(run);

            sdt.Content.Add(paragraph);

            doc.Body.Add(sdt);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
