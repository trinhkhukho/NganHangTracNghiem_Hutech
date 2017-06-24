using System;
using Independentsoft.Office;
using Independentsoft.Office.Vml;
using Independentsoft.Office.Word;
using Independentsoft.Office.Word.Fields;

namespace Sample
{
    class Program
    {
        static void Main(string[] args)
        {
            WordDocument doc = new WordDocument();

            Run run1 = new Run();
            run1.AddText("Question text:");

            Run answerRun1 = new Run("Enter answer here");

            ComplexField startComplexField1 = new ComplexField();
            startComplexField1.CharacterType = ComplexFieldCharacterType.Start;
            startComplexField1.FormFieldProperties.Name = "Question1";
            startComplexField1.FormFieldProperties.Enabled = ExtendedBoolean.True;
            startComplexField1.FormFieldProperties.TextBoxFormFieldProperties.MaxLength = 30;

            Run startComplexFieldRun1 = new Run();
            startComplexFieldRun1.Add(startComplexField1);

            ComplexField separatorComplexField1 = new ComplexField();
            separatorComplexField1.CharacterType = ComplexFieldCharacterType.Separator;

            Run separatorComplexFieldRun1 = new Run();
            separatorComplexFieldRun1.Add(separatorComplexField1);

            ComplexField endComplexField1 = new ComplexField();
            endComplexField1.CharacterType = ComplexFieldCharacterType.End;

            Run endComplexFieldRun1 = new Run();
            endComplexFieldRun1.Add(endComplexField1);

            FormText formText1 = new FormText();
            FieldCode formTextFieldCode1 = new FieldCode(formText1);

            Run formTextRun1 = new Run();
            formTextRun1.Add(formTextFieldCode1);

            Paragraph paragraph1 = new Paragraph();
            paragraph1.Add(run1);
            paragraph1.Add(startComplexFieldRun1);
            paragraph1.Add(formTextRun1);
            paragraph1.Add(separatorComplexFieldRun1);
            paragraph1.Add(answerRun1);
            paragraph1.Add(endComplexFieldRun1);

            ComplexField startComplexField2 = new ComplexField();
            startComplexField2.CharacterType = ComplexFieldCharacterType.Start;
            startComplexField2.FormFieldProperties.Name = "CheckBox1";
            startComplexField2.FormFieldProperties.Enabled = ExtendedBoolean.True;
            startComplexField2.FormFieldProperties.CheckBoxFormFieldProperties.AutoSize = ExtendedBoolean.True;
            startComplexField2.FormFieldProperties.CheckBoxFormFieldProperties.Checked = ExtendedBoolean.False;

            Run startComplexFieldRun2 = new Run();
            startComplexFieldRun2.Add(startComplexField2);

            ComplexField separatorComplexField2 = new ComplexField();
            separatorComplexField2.CharacterType = ComplexFieldCharacterType.Separator;

            Run separatorComplexFieldRun2 = new Run();
            separatorComplexFieldRun2.Add(separatorComplexField2);

            ComplexField endComplexField2 = new ComplexField();
            endComplexField2.CharacterType = ComplexFieldCharacterType.End;

            Run endComplexFieldRun2 = new Run();
            endComplexFieldRun2.Add(endComplexField2);

            FormCheckBox formCheckBox2 = new FormCheckBox();
            FieldCode formTextFieldCode2 = new FieldCode(formCheckBox2);

            Run formCheckBoxRun2 = new Run();
            formCheckBoxRun2.Add(formTextFieldCode2);

            Paragraph paragraph2 = new Paragraph();
            paragraph2.Add(startComplexFieldRun2);
            paragraph2.Add(formCheckBoxRun2);
            paragraph2.Add(separatorComplexFieldRun2);
            paragraph2.Add(endComplexFieldRun2);

            doc.Settings.DocumentProtection = new DocumentProtection();
            doc.Settings.DocumentProtection.ProtectionType = DocumentProtectionType.Forms;

            doc.Body.Add(paragraph1);
            doc.Body.Add(new Paragraph()); //just blank paragraph to make space
            doc.Body.Add(new Paragraph()); //just blank paragraph to make space
            doc.Body.Add(paragraph2);

            doc.Save("c:\\test\\output.docx", true);
        }
    }
}
