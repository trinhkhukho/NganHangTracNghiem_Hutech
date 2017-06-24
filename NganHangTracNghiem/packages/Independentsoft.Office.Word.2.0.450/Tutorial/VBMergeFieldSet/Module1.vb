Imports System
Imports System.Collections.Generic
Imports Independentsoft.Office
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Fields

Module Module1
    Sub Main(ByVal args As String())

        Dim customerID As String = "12345"
        Dim customerName As String = "John Smith"
        Dim customerAddress As String = "123 Way, New York, NY 10019"

        Dim doc As WordDocument = New WordDocument("c:\test\input.docx")

        Dim docElements As IList(Of IContentElement) = doc.GetContentElements()

        For Each docElement As IContentElement In docElements
            If TypeOf docElement Is SimpleField Then
                Dim simpleField As SimpleField = DirectCast(docElement, SimpleField)

                If TypeOf simpleField.Field Is MergeField Then
                    Dim mergeField As MergeField = DirectCast(simpleField.Field, MergeField)

                    If mergeField.Name = "CustomerID" Then
                        Dim run As New Run(customerID)
                        simpleField.Content.Clear()
                        simpleField.Add(run)
                    ElseIf mergeField.Name = "CustomerName" Then
                        Dim run As New Run(customerName)
                        simpleField.Content.Clear()
                        simpleField.Add(run)
                    ElseIf mergeField.Name = "CustomerAddress" Then
                        Dim run As New Run(customerAddress)
                        simpleField.Content.Clear()
                        simpleField.Add(run)
                    End If

                End If
            End If
        Next

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module