Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Word

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument("c:\test\input.docx")

        Dim paragraphs As IList(Of Paragraph) = doc.GetParagraphs()

        For Each paragraph As Paragraph In paragraphs

            Dim paragraphText As [String] = ""

            For j As Integer = 0 To paragraph.Content.Count - 1

                If TypeOf paragraph.Content(j) Is Run Then

                    Dim run As Run = DirectCast(paragraph.Content(j), Run)

                    Dim runText As [String] = ""

                    For Each runElement As IRunContent In run.Content

                        If TypeOf runElement Is Text Then

                            Dim currentText As Text = DirectCast(runElement, Text)

                            runText += currentText.Value
                            paragraphText += currentText.Value

                        End If
                    Next

                    If runText.IndexOf("my text") > -1 Then
                        'found text inside current run object
                    End If
                End If
            Next

            If paragraphText.IndexOf("my text") > -1 Then
                'found text inside current paragraph object
            End If
        Next

    End Sub
End Module