Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Fields

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument("c:\test\input.docx")

        Dim allElements As IList(Of IContentElement) = doc.GetContentElements()

        For Each element As IContentElement In allElements
            If TypeOf element Is Paragraph Then
                Dim paragraph As Paragraph = DirectCast(element, Paragraph)

                For i As Integer = 0 To paragraph.Content.Count - 1
                    If TypeOf paragraph.Content(i) Is Run Then
                        Dim run As Run = DirectCast(paragraph.Content(i), Run)

                        For r As Integer = 0 To run.Content.Count - 1
                            If TypeOf run.Content(r) Is ComplexField Then
                                Dim complexField As ComplexField = DirectCast(run.Content(r), ComplexField)

                                If complexField.FormFieldProperties IsNot Nothing AndAlso complexField.FormFieldProperties.Name = "CheckBox1" AndAlso complexField.FormFieldProperties.CheckBoxFormFieldProperties IsNot Nothing Then
                                    complexField.FormFieldProperties.CheckBoxFormFieldProperties.Checked = ExtendedBoolean.[True]
                                End If
                            End If
                        Next
                    End If
                Next
            End If
        Next

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module