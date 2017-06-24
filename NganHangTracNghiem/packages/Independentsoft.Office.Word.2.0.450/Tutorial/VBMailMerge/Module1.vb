Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Fields
Imports Independentsoft.Office.Word.Sections
Imports Independentsoft.Office.Word.MailMerge

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As WordDocument = New WordDocument

        Dim run As Run = New Run
        run.AddText("Ship To:")

        Dim nameField As MergeField = New MergeField
        nameField.Name = "name"
        Dim nameSimpleField As SimpleField = New SimpleField(nameField)

        Dim addressField As MergeField = New MergeField
        addressField.Name = "address"
        Dim addressSimpleField As SimpleField = New SimpleField(addressField)

        Dim paragraph1 As Paragraph = New Paragraph
        paragraph1.Add(run)

        Dim paragraph2 As Paragraph = New Paragraph
        paragraph2.Add(nameSimpleField)

        Dim paragraph3 As Paragraph = New Paragraph
        paragraph3.Add(addressSimpleField)

        doc.Body.Add(paragraph1)
        doc.Body.Add(paragraph2)
        doc.Body.Add(paragraph3)

        doc.Settings.MailMergeSettings.MainDocumentType = MailMergeDocumentType.Envelope
        doc.Settings.MailMergeSettings.DataSourceType = "native"
        doc.Settings.MailMergeSettings.LinkToQuery = ExtendedBoolean.True
        doc.Settings.MailMergeSettings.DataSourceConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=True;Initial Catalog=testdb;Data Source=MYSERVER\SQLEXPRESS;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=MYSERVER;Use Encryption for Data=False;Tag with column collation when possible=False"
        doc.Settings.MailMergeSettings.Query = "SELECT * FROM ""Customer"""
        doc.Settings.MailMergeSettings.DataSourceFilePath = "file:///C:\Documents%20and%20Settings\Administrator\My%20Documents\My%20Data%20Sources\testdb.odc"
        doc.Settings.MailMergeSettings.ViewMergedData = ExtendedBoolean.True

        doc.Settings.MailMergeSettings.OfficeDataSourceObjectSettings.UniversalDataLinkConnectionString = "Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=True;Initial Catalog=testdb;Data Source=MYSERVER\SQLEXPRESS;Use Procedure for Prepare=1;Auto Translate=True;Packet Size=4096;Workstation ID=MYSERVER;Use Encryption for Data=False;Tag with column collation when possible=False"
        doc.Settings.MailMergeSettings.OfficeDataSourceObjectSettings.TableName = "Customer"
        doc.Settings.MailMergeSettings.OfficeDataSourceObjectSettings.ColumnDelimiter = 9
        doc.Settings.MailMergeSettings.OfficeDataSourceObjectSettings.FirstRowContainsColumnNames = ExtendedBoolean.True
        doc.Settings.MailMergeSettings.OfficeDataSourceObjectSettings.Source = "file:///C:\Documents%20and%20Settings\Administrator\My%20Documents\My%20Data%20Sources\testdb.odc"

        Dim field1 As FieldMappingData = New FieldMappingData
        field1.ColumnIndex = 0
        field1.ColumnName = "name"
        field1.MappedName = "Customer Name"
        field1.Type = MergeFieldMappingType.DBColumn

        Dim field2 As FieldMappingData = New FieldMappingData
        field2.ColumnIndex = 1
        field2.ColumnName = "address"
        field2.MappedName = "Customer Address"
        field2.Type = MergeFieldMappingType.DBColumn

        doc.Settings.MailMergeSettings.OfficeDataSourceObjectSettings.FieldMappings.Add(field1)
        doc.Settings.MailMergeSettings.OfficeDataSourceObjectSettings.FieldMappings.Add(field2)

        Dim margins As PageMargins = New PageMargins
        margins.Bottom = 720
        margins.Left = 720
        margins.Right = 720
        margins.Top = 360
        margins.Footer = 720
        margins.Header = 720

        Dim section As Section = New Section
        section.PageSize = New PageSize(9360, 5220, PageOrientation.Landscape)
        section.PageMargins = margins

        doc.Body.Section = section

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module