Imports System
Imports System.Collections.Generic
Imports Independentsoft.Office
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Fields

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument("c:\test\input.docx")

        Dim docElements As IList(Of IContentElement) = doc.GetContentElements()

        For Each docElement As IContentElement In docElements
            If TypeOf docElement Is SimpleField Then
                Dim simpleField As SimpleField = DirectCast(docElement, SimpleField)

                If TypeOf simpleField.Field Is MergeField Then
                    Dim mergeField As MergeField = DirectCast(simpleField.Field, MergeField)

                    Dim fieldValue As String = ""

                    Dim simpleFieldElements As IList(Of IContentElement) = simpleField.GetContentElements()

                    For Each element As IContentElement In simpleFieldElements
                        If TypeOf element Is Text Then
                            Dim text As Text = DirectCast(element, Text)
                            fieldValue += text.Value
                        End If
                    Next

                    Console.WriteLine("MergeField name = " + mergeField.Name)
                    Console.WriteLine("MergeField value = " + fieldValue)
                End If
            End If
        Next

        Console.Read()

    End Sub
End Module