using System;
using Independentsoft.Office;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Fields;
using Independentsoft.Office.Word.Sections;
using Independentsoft.Office.Word.MailMerge;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            Run run = new Run();
            run.AddText("Ship To:");

            MergeField nameField = new MergeField();
            nameField.Name = "name";
            SimpleField nameSimpleField = new SimpleField(nameField);

            MergeField addressField = new MergeField();
            addressField.Name = "address";
            SimpleField addressSimpleField = new SimpleField(addressField);

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run);

            Paragraph paragraph2 = new Paragraph();
            paragraph2.Add(nameSimpleField);

            Paragraph paragraph3 = new Paragraph();
            paragraph3.Add(addressSimpleField);

            doc.Body.Add(paragraph1);
            doc.Body.Add(paragraph2);
            doc.Body.Add(paragraph3);

            doc.Settings.MailMergeSettings.MainDocumentType = MailMergeDocumentType.Envelope;
            doc.Settings.MailMergeSettings.DataSourceType = "native";
            doc.Settings.MailMergeSettings.LinkToQuery = ExtendedBoolean.True;
            doc.Settings.MailMergeSettings.DataSourceConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=True;Initial Catalog=testdb;Data Source=MYSERVER\\SQLEXPRESS;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=MYSERVER;Use Encryption for Data=False;Tag with column collation when possible=False";
            doc.Settings.MailMergeSettings.Query = "SELECT * FROM \"Customer\"";
            doc.Settings.MailMergeSettings.DataSourceFilePath = "file:///C:\\Documents%20and%20Settings\\Administrator\\My%20Documents\\My%20Data%20Sources\\testdb.odc";
            doc.Settings.MailMergeSettings.ViewMergedData = ExtendedBoolean.True;

            doc.Settings.MailMergeSettings.OfficeDataSourceObjectSettings.UniversalDataLinkConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=True;Initial Catalog=testdb;Data Source=MYSERVER\\SQLEXPRESS;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=MYSERVER;Use Encryption for Data=False;Tag with column collation when possible=False";
            doc.Settings.MailMergeSettings.OfficeDataSourceObjectSettings.TableName = "Customer";
            doc.Settings.MailMergeSettings.OfficeDataSourceObjectSettings.ColumnDelimiter = 9;
            doc.Settings.MailMergeSettings.OfficeDataSourceObjectSettings.FirstRowContainsColumnNames = ExtendedBoolean.True;
            doc.Settings.MailMergeSettings.OfficeDataSourceObjectSettings.Source = "file:///C:\\Documents%20and%20Settings\\Administrator\\My%20Documents\\My%20Data%20Sources\\testdb.odc";
            
            FieldMappingData field1 = new FieldMappingData();
            field1.ColumnIndex = 0;
            field1.ColumnName = "name";
            field1.MappedName = "Customer Name";
            field1.Type = MergeFieldMappingType.DBColumn;
            
            FieldMappingData field2 = new FieldMappingData();
            field2.ColumnIndex = 1;
            field2.ColumnName = "address";
            field2.MappedName = "Customer Address";
            field2.Type = MergeFieldMappingType.DBColumn;

            doc.Settings.MailMergeSettings.OfficeDataSourceObjectSettings.FieldMappings.Add(field1);
            doc.Settings.MailMergeSettings.OfficeDataSourceObjectSettings.FieldMappings.Add(field2);

            PageMargins margins = new PageMargins();
            margins.Bottom = 720; // 1/2 inch
            margins.Left = 720; // 1/2 inch
            margins.Right = 720; // 1/2 inch
            margins.Top = 360; // 1/4 inch
            margins.Footer = 720; // 1/2 inch
            margins.Header = 720; // 1/2 inch

            Section section = new Section();
            section.PageSize = new PageSize(9360, 5220, PageOrientation.Landscape);
            section.PageMargins = margins;

            doc.Body.Section = section;

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
