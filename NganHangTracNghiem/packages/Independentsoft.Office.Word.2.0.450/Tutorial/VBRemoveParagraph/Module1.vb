Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Tables

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New WordDocument("c:\test\input.docx")

        For i As Integer = 0 To doc.Body.Content.Count - 1
            If TypeOf doc.Body.Content(i) Is Paragraph Then
                Dim paragraph As Paragraph = DirectCast(doc.Body.Content(i), Paragraph)

                Dim paragraphText As [String] = ""

                For Each pContent As IParagraphContent In paragraph.Content
                    If TypeOf pContent Is Run Then
                        Dim run As Run = DirectCast(pContent, Run)

                        For Each rContent As IRunContent In run.Content
                            If TypeOf rContent Is Text Then
                                Dim text As Text = DirectCast(rContent, Text)
                                paragraphText += text.Value
                            End If
                        Next
                    End If
                Next

                If paragraphText.ToLower().IndexOf("remove me") > -1 Then
                    paragraph.Content.Clear()
                End If
            End If
        Next

        doc.Save("c:\test\output.docx", True)
    End Sub
End Module
