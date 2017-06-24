Imports System
Imports Independentsoft.Office
Imports Independentsoft.Office.Vml
Imports Independentsoft.Office.Word
Imports Independentsoft.Office.Word.Fields

Module Module1
    Sub Main(ByVal args As String())

        Dim doc As WordDocument = New WordDocument()

        Dim run1 As New Run()
        run1.AddText("Question text:")

        Dim answerRun1 As New Run("Enter answer here")

        Dim startComplexField1 As New ComplexField()
        startComplexField1.CharacterType = ComplexFieldCharacterType.Start
        startComplexField1.FormFieldProperties.Name = "Question1"
        startComplexField1.FormFieldProperties.Enabled = ExtendedBoolean.[True]
        startComplexField1.FormFieldProperties.TextBoxFormFieldProperties.MaxLength = 30

        Dim startComplexFieldRun1 As New Run()
        startComplexFieldRun1.Add(startComplexField1)

        Dim separatorComplexField1 As New ComplexField()
        separatorComplexField1.CharacterType = ComplexFieldCharacterType.Separator

        Dim separatorComplexFieldRun1 As New Run()
        separatorComplexFieldRun1.Add(separatorComplexField1)

        Dim endComplexField1 As New ComplexField()
        endComplexField1.CharacterType = ComplexFieldCharacterType.[End]

        Dim endComplexFieldRun1 As New Run()
        endComplexFieldRun1.Add(endComplexField1)

        Dim formText1 As New FormText()
        Dim formTextFieldCode1 As New FieldCode(formText1)

        Dim formTextRun1 As New Run()
        formTextRun1.Add(formTextFieldCode1)

        Dim paragraph1 As New Paragraph()
        paragraph1.Add(run1)
        paragraph1.Add(startComplexFieldRun1)
        paragraph1.Add(formTextRun1)
        paragraph1.Add(separatorComplexFieldRun1)
        paragraph1.Add(answerRun1)
        paragraph1.Add(endComplexFieldRun1)

        Dim startComplexField2 As New ComplexField()
        startComplexField2.CharacterType = ComplexFieldCharacterType.Start
        startComplexField2.FormFieldProperties.Name = "CheckBox1"
        startComplexField2.FormFieldProperties.Enabled = ExtendedBoolean.[True]
        startComplexField2.FormFieldProperties.CheckBoxFormFieldProperties.AutoSize = ExtendedBoolean.[True]
        startComplexField2.FormFieldProperties.CheckBoxFormFieldProperties.Checked = ExtendedBoolean.[False]

        Dim startComplexFieldRun2 As New Run()
        startComplexFieldRun2.Add(startComplexField2)

        Dim separatorComplexField2 As New ComplexField()
        separatorComplexField2.CharacterType = ComplexFieldCharacterType.Separator

        Dim separatorComplexFieldRun2 As New Run()
        separatorComplexFieldRun2.Add(separatorComplexField2)

        Dim endComplexField2 As New ComplexField()
        endComplexField2.CharacterType = ComplexFieldCharacterType.[End]

        Dim endComplexFieldRun2 As New Run()
        endComplexFieldRun2.Add(endComplexField2)

        Dim formCheckBox2 As New FormCheckBox()
        Dim formTextFieldCode2 As New FieldCode(formCheckBox2)

        Dim formCheckBoxRun2 As New Run()
        formCheckBoxRun2.Add(formTextFieldCode2)

        Dim paragraph2 As New Paragraph()
        paragraph2.Add(startComplexFieldRun2)
        paragraph2.Add(formCheckBoxRun2)
        paragraph2.Add(separatorComplexFieldRun2)
        paragraph2.Add(endComplexFieldRun2)

        doc.Settings.DocumentProtection = New DocumentProtection()
        doc.Settings.DocumentProtection.ProtectionType = DocumentProtectionType.Forms

        doc.Body.Add(paragraph1)
        doc.Body.Add(New Paragraph()) 'just blank paragraph to make space
        doc.Body.Add(New Paragraph()) 'just blank paragraph to make space
        doc.Body.Add(paragraph2)

        doc.Save("c:\test\output.docx", True)

    End Sub
End Module