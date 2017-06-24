Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.CustomMarkup

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument

        Dim sdt As New StructuredDocumentTag()
        sdt.Properties.Tag = "Test Combox Box"
        sdt.Properties.[Alias] = "Test Combox Box"

        sdt.Properties.ComboBox = New ComboBox()

        Dim item1 As New ComboBoxListItem()
        item1.DisplayText = "1"
        item1.Value = "1"

        Dim item2 As New ComboBoxListItem()
        item2.DisplayText = "2"
        item2.Value = "2"

        Dim item3 As New ComboBoxListItem()
        item3.DisplayText = "3"
        item3.Value = "3"

        sdt.Properties.ComboBox.Items.Add(item1)
        sdt.Properties.ComboBox.Items.Add(item2)
        sdt.Properties.ComboBox.Items.Add(item3)

        Dim run As New Run()
        run.AddText("Choose an item.")

        Dim paragraph As New Paragraph()
        paragraph.Add(run)

        sdt.Content.Add(paragraph)

        doc.Body.Add(sdt)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module
