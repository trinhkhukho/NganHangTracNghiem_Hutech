Imports System
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Tables

Module Module1
    Sub Main(ByVal args() As String)

        Dim doc As New WordDocument("c:\test\input.docx")

        For i As Integer = 0 To doc.Body.Content.Count - 1

            If TypeOf doc.Body.Content(i) Is Paragraph Then
                Dim paragraph As Paragraph = DirectCast(doc.Body.Content(i), Paragraph)

                Dim bookmarkId As Long = -1
                Dim contentToRemove As IList(Of IParagraphContent) = New List(Of IParagraphContent)()

                For Each pContent As IParagraphContent In paragraph.Content
                    If TypeOf pContent Is BookmarkStart Then
                        Dim bookmarkStart As BookmarkStart = DirectCast(pContent, BookmarkStart)

                        If bookmarkStart.Name = "REMOVE" Then
                            bookmarkId = bookmarkStart.ID
                        End If
                    ElseIf TypeOf pContent Is BookmarkEnd Then
                        Dim bookmarkEnd As BookmarkEnd = DirectCast(pContent, BookmarkEnd)

                        If bookmarkEnd.ID = bookmarkId Then
                            bookmarkId = -1
                        End If
                    ElseIf TypeOf pContent Is Run AndAlso bookmarkId > -1 Then
                        Dim run As Run = DirectCast(pContent, Run)

                        contentToRemove.Add(run)
                    End If
                Next

                If contentToRemove.Count > 0 Then
                    For Each element As IParagraphContent In contentToRemove
                        paragraph.Content.Remove(element)
                    Next
                End If

            End If
        Next

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module
