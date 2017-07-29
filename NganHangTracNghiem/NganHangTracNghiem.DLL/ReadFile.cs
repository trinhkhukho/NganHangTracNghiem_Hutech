using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NganHangTracNghiem.Data;
using Ovml = DocumentFormat.OpenXml.Vml.Office;
using V = DocumentFormat.OpenXml.Vml;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Xsl;
using System.Xml;
using NganHangTracNghiem.DLL;
using System.IO.Compression;
//error list
// 3000: don't save.
// 3001: content of question is empty.
// 3002: content of answer is empty.
// 3003: question exits two or more answer correct.
// 3004: question don't have answer correct.


namespace NganHangTracNghiem.DDL
{
    public class ReadFile
    {
        string m_img = @"http://localhost:53112/Img/";
        string m_audio= @"http://localhost:53112/Audio/";
        private string m_filePath = null;
        string mark_df = "0.5";
        string SubjectiveDifficulty_df = "0.5";
        string Discrimination_df = "0.5";
        int userId = 10001;
        int ChapterID = 1163;
        public ListQuestion OpenWordprocessingDocumentReadonly(string filepath,string filepath_zip,string host, int _chapterID,int _userid)
        {
            this.ChapterID = _chapterID;
            this.userId = _userid;
            m_img = host + "Img/";
            m_audio = host + "Audio/";
            List<Question_Detail> Question_Success= new List<Question_Detail>();
            List<Question_Detail> Question_Error = new List<Question_Detail>(); ;
            ListQuestion listquestion = new ListQuestion();
            string url_InsertQuestion = host+"/api/Questions";
            string url_InsertAnswer = host+"/api/Answers";
            HttpClient client_Question = new HttpClient();//using call api save Question
            HttpClient client_answer = new HttpClient();//using call api save Answer
            HttpClient client_Img = new HttpClient();//unsing call api save image
            Questions Question = new Questions();
            Answers Answer_A = new Answers();
            Answers Answer_B = new Answers();
            Answers Answer_C = new Answers();
            Answers Answer_D = new Answers();
            Question_Detail qd = new Question_Detail();
            List<Answers> ls_answer = new List<Answers>();
            Questions Group_Question = new Questions();// save group questions.
            int Group = 0;
            int End_Content = 0;
            int id_question = 0;
            string Content = string.Empty;// content of Question
            string answer = string.Empty;//content of answer
            string Name = Guid.NewGuid().ToString();
            string SubjectiveDifficulty = string.Empty;//độ khó
            string Discrimination = string.Empty;//độ phân cách
            string Mark = string.Empty;// mark of Question
            List<ImagePart> imgParts;
            // Open a WordprocessingDocument based on a filepath.
            Dictionary<int, string> pageviseContent = new Dictionary<int, string>();
            int pageCount = 0;
            using (WordprocessingDocument wordDocument =
                WordprocessingDocument.Open(filepath, false))//openXML of Doc in filepath
            {
                MainDocumentPart mainDoc = wordDocument.MainDocumentPart;//get main doc in filepath
                Document document = mainDoc.Document;
                // Assign a reference to the existing document body. 
                wordDocument.MainDocumentPart.Document.InnerXml = wordDocument.MainDocumentPart.Document.InnerXml.Replace("minorEastAsia", "minorBidi");
                Body body = wordDocument.MainDocumentPart.Document.Body;
                if (wordDocument.ExtendedFilePropertiesPart.Properties.Pages.Text != null)
                {
                    pageCount = Convert.ToInt32(wordDocument.ExtendedFilePropertiesPart.Properties.Pages.Text);
                }
                int i = 1;
                StringBuilder pageContentBuilder = new StringBuilder();
                int img = 0;
                imgParts = new List<ImagePart>(wordDocument.MainDocumentPart.ImageParts);//get all img in file
                foreach (var element in body.ChildElements)
                {

                    #region
                    if (element.InnerXml.IndexOf("<w:br w:type=\"page\" />", StringComparison.OrdinalIgnoreCase) < 0)
                    {
                        //if have group question create new group question and assign to group is 1
                        if(element.InnerText.Contains("[<sg>]"))
                        {
                            Group_Question = new Questions();
                            Group = 1;
                            End_Content = 0;
                            continue;
                        }
                        if(element.InnerText.Contains("[</sg>]"))
                        {
                            End_Content = 0;
                            Group = 0;
                        }
                        if(element.InnerText.Contains("[<egc>]"))
                        {
                            id_question++;
                            End_Content = 1;
                            if (End_Content == 0)
                            {
                                continue;
                            }
                            if (Group_Question.Id == 0)//if group question don't save 
                            {
                                Group_Question.UserId = userId;
                                Group_Question.Content = Content;
                                Group_Question.ChapterId = ChapterID;
                                Group_Question.SubjectiveDifficulty = Convert.ToDecimal(SubjectiveDifficulty_df);
                                Group_Question.CreateDate = DateTime.Now;
                                Group_Question.Mark = Convert.ToDecimal(mark_df);
                                Group_Question.Discrimination = Convert.ToDecimal(Discrimination_df);
                                //call api save questions
                                //================================================================
                                client_Question = new HttpClient();
                                var result_q = client_Question.PostAsJsonAsync(url_InsertQuestion, Group_Question).Result;
                                if (result_q.IsSuccessStatusCode)
                                {
                                    client_Question = new HttpClient();
                                    client_Question.BaseAddress = new Uri(host);
                                    client_Question.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                    var reponse = client_Question.GetAsync("api/Questions/0").Result;
                                    if (reponse.IsSuccessStatusCode)
                                    {
                                        Group_Question = reponse.Content.ReadAsAsync<Questions>().Result;
                                    }
                                    qd = new Question_Detail();
                                    qd.Question = Group_Question;
                                    qd.Group = 1;
                                    Question_Success.Add(qd);
                                }
                                else
                                {
                                    Group_Question.Id = id_question;
                                    Group_Question.UserId = userId;
                                    Group_Question.Content = Content;
                                    Group_Question.ChapterId = ChapterID;
                                    Group_Question.SubjectiveDifficulty = Convert.ToDecimal(SubjectiveDifficulty_df);
                                    Group_Question.CreateDate = DateTime.Now;
                                    Group_Question.Mark = Convert.ToDecimal(mark_df);
                                    Group_Question.Discrimination = Convert.ToDecimal(Discrimination_df);
                                    qd = new Question_Detail();
                                    qd.Question = Group_Question;
                                    qd.Erorr = 3000;
                                    qd.Group = 1;
                                    Question_Error.Add(qd);
                                }
                                Content = string.Empty;
                                answer = string.Empty;
                                continue;
                            }
                        }
                        if(element.InnerText.Contains("[<audio>]"))
                        {
                            if(Group==1)
                            {
                                Group_Question.Audio = true;
                            }
                            else
                            {
                                Question.Audio = true;
                            }
                            string Audio_Name= element.InnerText.Replace("[<audio>]", "").Replace("[</audio>]", "").Replace("audio/","");
                            ExtractZip extraxtzip = new ExtractZip();
                            ZipArchiveEntry entry= extraxtzip.GetFileByName(filepath_zip, Audio_Name);
                            if(entry!=null)
                            {
                                Stream data = entry.Open();
                                var conten = new MultipartFormDataContent();
                                var fileContent1 = new ByteArrayContent(ReadFully(data));
                                fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                                {
                                    FileName = Audio_Name
                                };
                                conten.Add(fileContent1);
                                client_answer = new HttpClient();
                                var result_q = client_answer.PostAsync(host+"/api/SaveFile_Audio", conten).Result;
                                if (result_q.StatusCode == System.Net.HttpStatusCode.Created)
                                {

                                }
                                else
                                {

                                }
                            }
                            //"< audio controls = 'controls' > < source src = "+" type = 'audio/mpeg' /></ audio >"
                            Content += " <audio controls = \"controls\"> <source src = \"" + m_audio + Audio_Name + "\" type = \"audio/mpeg\" /></audio>";

                            continue;
                        }
                        //create new questions and answer
                        #region
                        //next to new questions
                        if (element.InnerText.Contains("[<br>]"))
                        {
                            id_question++;
                            #region
                            //if content of question is empty then add this question to error list
                            #region
                            if (Question.Content==" "||Question.Content==null)
                            {
                                if(Group==1)
                                {
                                    Question.ParentId = Group_Question.Id;
                                }
                                Question.Id = id_question;
                                Question.UserId = userId;
                                Question.SubjectiveDifficulty = Convert.ToDecimal(SubjectiveDifficulty_df);
                                Question.Content = Content;
                                Question.ChapterId = ChapterID;
                                Question.CreateDate = DateTime.Now;
                                Question.Mark = Convert.ToDecimal(mark_df);
                                Question.Discrimination = Convert.ToDecimal(Discrimination_df);
                                qd = new Question_Detail();
                                qd.Question = Question;
                                if (Group == 1)
                                {
                                    qd.QuestionOfGroup = 1;
                                }
                                else
                                {
                                    qd.QuestionOfGroup = 0;
                                }
                                qd.Erorr = 3001;
                                qd.Group = 0;
                                ls_answer = new List<Answers>();
                                ls_answer.Add(Answer_A);
                                ls_answer.Add(Answer_B);
                                ls_answer.Add(Answer_C);
                                ls_answer.Add(Answer_D);
                                qd.Answer = ls_answer;
                                Question_Error.Add(qd);
                                Question = new Questions();//create new questions
                                Answer_A = new Answers();//create new answer
                                Answer_B = new Answers();
                                Answer_C = new Answers();
                                Answer_D = new Answers();
                                Content = string.Empty;
                                answer = string.Empty;
                                continue;
                            }
                            #endregion
                            //if content of Answer is empty then add this question to error list
                            #region
                            if (Answer_A.Content==" "||Answer_A.Content==null)
                            {
                                if (Group == 1)
                                {
                                    Question.ParentId = Group_Question.Id;
                                }
                                Question.Id = id_question;
                                Question.UserId = userId;
                                Question.SubjectiveDifficulty = Convert.ToDecimal(SubjectiveDifficulty_df);
                                Question.Content = Content;
                                Question.ChapterId = ChapterID;
                                Question.CreateDate = DateTime.Now;
                                Question.Mark = Convert.ToDecimal(mark_df);
                                Question.Discrimination = Convert.ToDecimal(Discrimination_df);
                                qd = new Question_Detail();
                                qd = new Question_Detail();
                                if (Group == 1)
                                {
                                    qd.QuestionOfGroup = 1;
                                }
                                else
                                {
                                    qd.QuestionOfGroup = 0;
                                }
                                qd.Question = Question;
                                qd.Erorr = 3002;
                                qd.Group = 0;
                                ls_answer = new List<Answers>();
                                ls_answer.Add(Answer_A);
                                ls_answer.Add(Answer_B);
                                ls_answer.Add(Answer_C);
                                ls_answer.Add(Answer_D);
                                qd.Answer = ls_answer;
                                Question_Error.Add(qd);
                                Question = new Questions();//create new questions
                                Answer_A = new Answers();//create new answer
                                Answer_B = new Answers();
                                Answer_C = new Answers();
                                Answer_D = new Answers();
                                Content = string.Empty;
                                answer = string.Empty;
                                continue;
                            }
                            if (Answer_B.Content == " " || Answer_B.Content == null)
                            {
                                if (Group == 1)
                                {
                                    Question.ParentId = Group_Question.Id;
                                }
                                Question.Id = id_question;
                                qd = new Question_Detail();
                                qd.Question = Question;
                                qd.Erorr = 3002;
                                qd.Group = 0;
                                ls_answer = new List<Answers>();
                                ls_answer.Add(Answer_A);
                                ls_answer.Add(Answer_B);
                                ls_answer.Add(Answer_C);
                                ls_answer.Add(Answer_D);
                                qd.Answer = ls_answer;
                                Question_Error.Add(qd);
                                Question = new Questions();//create new questions
                                Answer_A = new Answers();//create new answer
                                Answer_B = new Answers();
                                Answer_C = new Answers();
                                Answer_D = new Answers();
                                Content = string.Empty;
                                answer = string.Empty;
                                continue;
                            }
                            if (Answer_C.Content == " " || Answer_C.Content == null)
                            {
                                if (Group == 1)
                                {
                                    Question.ParentId = Group_Question.Id;
                                }
                                Question.Id = id_question;
                                qd = new Question_Detail();
                                qd.Question = Question;
                                qd.Erorr = 3002;
                                qd.Group = 0;
                                ls_answer = new List<Answers>();
                                ls_answer.Add(Answer_A);
                                ls_answer.Add(Answer_B);
                                ls_answer.Add(Answer_C);
                                ls_answer.Add(Answer_D);
                                qd.Answer = ls_answer;
                                Question_Error.Add(qd);
                                Question = new Questions();//create new questions
                                Answer_A = new Answers();//create new answer
                                Answer_B = new Answers();
                                Answer_C = new Answers();
                                Answer_D = new Answers();
                                Content = string.Empty;
                                answer = string.Empty;
                                continue;
                            }
                            if (Answer_D.Content == " " || Answer_D.Content == null)
                            {
                                if (Group == 1)
                                {
                                    Question.ParentId = Group_Question.Id;
                                }
                                Question.Id = id_question;
                                qd = new Question_Detail();
                                qd.Question = Question;
                                qd.Erorr = 3002;
                                qd.Group = 0;
                                ls_answer = new List<Answers>();
                                ls_answer.Add(Answer_A);
                                ls_answer.Add(Answer_B);
                                ls_answer.Add(Answer_C);
                                ls_answer.Add(Answer_D);
                                qd.Answer = ls_answer;
                                Question_Error.Add(qd);
                                Question = new Questions();//create new questions
                                Answer_A = new Answers();//create new answer
                                Answer_B = new Answers();
                                Answer_C = new Answers();
                                Answer_D = new Answers();
                                Content = string.Empty;
                                answer = string.Empty;
                                continue;
                            }
                            #endregion
                            //count correct answer
                            #region
                            int correct = 0;
                            if(Answer_A.Correct==true)
                            {
                                correct++;
                            }
                            if (Answer_B.Correct == true)
                            {
                                correct++;
                            }
                            if (Answer_C.Correct == true)
                            {
                                correct++;
                            }
                            if (Answer_D.Correct == true)
                            {
                                correct++;
                            }
                            #endregion
                            //if question don't have correct answer then add this question to error list
                            #region
                            if (correct==0)
                            {
                                if (Group == 1)
                                {
                                    Question.ParentId = Group_Question.Id;
                                }
                                Question.Id = id_question;
                                Question.UserId = userId;
                                Question.SubjectiveDifficulty = Convert.ToDecimal(SubjectiveDifficulty_df);
                                Question.Content = Content;
                                Question.ChapterId = ChapterID;
                                Question.CreateDate = DateTime.Now;
                                Question.Mark = Convert.ToDecimal(mark_df);
                                Question.Discrimination = Convert.ToDecimal(Discrimination_df);
                                qd = new Question_Detail();
                                qd = new Question_Detail();
                                if (Group == 1)
                                {
                                    qd.QuestionOfGroup = 1;
                                }
                                else
                                {
                                    qd.QuestionOfGroup = 0;
                                }
                                qd.Question = Question;
                                qd.Erorr = 3004;
                                qd.Group = 0;
                                ls_answer = new List<Answers>();
                                ls_answer.Add(Answer_A);
                                ls_answer.Add(Answer_B);
                                ls_answer.Add(Answer_C);
                                ls_answer.Add(Answer_D);
                                qd.Answer = ls_answer;
                                Question_Error.Add(qd);
                                Question = new Questions();//create new questions
                                Answer_A = new Answers();//create new answer
                                Answer_B = new Answers();
                                Answer_C = new Answers();
                                Answer_D = new Answers();
                                Content = string.Empty;
                                answer = string.Empty;
                                continue;
                            }
                            #endregion
                            //if question have 2 correct answer or more then add this question to error list
                            #region
                            if (correct > 1)
                            {
                                if (Group == 1)
                                {
                                    Question.ParentId = Group_Question.Id;
                                }
                                Question.Id = id_question;
                                Question.UserId = userId;
                                Question.SubjectiveDifficulty = Convert.ToDecimal(SubjectiveDifficulty_df);
                                Question.Content = Content;
                                Question.ChapterId = ChapterID;
                                Question.CreateDate = DateTime.Now;
                                Question.Mark = Convert.ToDecimal(mark_df);
                                Question.Discrimination = Convert.ToDecimal(Discrimination_df);
                                qd = new Question_Detail();
                                qd = new Question_Detail();
                                qd.Question = Question;
                                if (Group == 1)
                                {
                                    qd.QuestionOfGroup = 1;
                                }
                                else
                                {
                                    qd.QuestionOfGroup = 0;
                                }
                                qd.Erorr = 3003;
                                qd.Group = 0;
                                ls_answer = new List<Answers>();
                                ls_answer.Add(Answer_A);
                                ls_answer.Add(Answer_B);
                                ls_answer.Add(Answer_C);
                                ls_answer.Add(Answer_D);
                                qd.Answer = ls_answer;
                                Question_Error.Add(qd);
                                Question = new Questions();//create new questions
                                Answer_A = new Answers();//create new answer
                                Answer_B = new Answers();
                                Answer_C = new Answers();
                                Answer_D = new Answers();
                                Content = string.Empty;
                                answer = string.Empty;
                                continue;
                            }
                            #endregion
                            //if exist group question
                            #region
                            if (Group == 1)
                            {
                                if (Question.Id == 0)
                                {
                                    Question.UserId = userId;
                                    Question.SubjectiveDifficulty = Convert.ToDecimal(SubjectiveDifficulty_df);
                                    Question.Content = Content;
                                    Question.ChapterId = ChapterID;
                                    Question.CreateDate = DateTime.Now;
                                    Question.ParentId = Group_Question.Id;
                                    Question.Mark= Convert.ToDecimal(mark_df);
                                    Question.Discrimination= Convert.ToDecimal(Discrimination_df);
                                    //call api save questions
                                    //================================================================
                                    client_Question = new HttpClient();
                                    var result_q = client_Question.PostAsJsonAsync(url_InsertQuestion, Question).Result;
                                    if (result_q.IsSuccessStatusCode)
                                    {
                                        client_Question = new HttpClient();
                                        client_Question.BaseAddress = new Uri(host);
                                        client_Question.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                        var reponse = client_Question.GetAsync("api/Questions/0").Result;
                                        if (reponse.IsSuccessStatusCode)
                                        {
                                            Question = reponse.Content.ReadAsAsync<Questions>().Result;
                                        }
                                    }
                                    else
                                    {
                                        //Question.Id = id_question;
                                        //Question.ParentId = Group_Question.Id;
                                        //Question_Detail qd = new Question_Detail();
                                        //qd.Question = Question;
                                        //qd.Erorr = 3000;
                                        //qd.Group = 0;
                                        //listquestion.Question_Error.Add(qd);
                                    }
                                    Content = string.Empty;
                                    answer = string.Empty;
                                }
                            }
                            #endregion
                            //else save question
                            #region
                            else
                            {
                                if (Question.Id == 0)
                                {
                                    Question.UserId = userId;
                                    Question.ChapterId = ChapterID;
                                    Question.SubjectiveDifficulty = Convert.ToDecimal(SubjectiveDifficulty_df);
                                    Question.CreateDate = DateTime.Now;
                                    Question.Mark = Convert.ToDecimal(mark_df);
                                    Question.Discrimination = Convert.ToDecimal(Discrimination_df);
                                    //call api save questions
                                    //================================================================
                                    client_Question = new HttpClient();
                                    var result_q = client_Question.PostAsJsonAsync(url_InsertQuestion, Question).Result;
                                    if (result_q.IsSuccessStatusCode)
                                    {
                                        client_Question = new HttpClient();
                                        client_Question.BaseAddress = new Uri(host);
                                        client_Question.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                                        var reponse = client_Question.GetAsync("api/Questions/0").Result;
                                        if (reponse.IsSuccessStatusCode)
                                        {
                                            Question = reponse.Content.ReadAsAsync<Questions>().Result;
                                            
                                        }
                                    }
                                    else
                                    {
                                        //Question.Id = id_question;
                                        //Question_Detail qd = new Question_Detail();
                                        //qd.Question = Question;
                                        //qd.Erorr = 3000;
                                        //qd.Group = 0;
                                        //listquestion.Question_Error.Add(qd);
                                    }
                                    Content = string.Empty;
                                    answer = string.Empty;
                                }
                            }
                            #endregion
                            //save answer
                            #region
                            Answer_A.QuestionId = Question.Id;
                            Answer_B.QuestionId = Question.Id;
                            Answer_C.QuestionId = Question.Id;
                            Answer_D.QuestionId = Question.Id;
                            client_answer = new HttpClient();
                            var result_A = client_answer.PostAsJsonAsync(url_InsertAnswer, Answer_A).Result;
                            if (result_A.IsSuccessStatusCode)
                            {

                            }
                            else
                            {

                            }
                            client_answer = new HttpClient();
                            var result_B = client_answer.PostAsJsonAsync(url_InsertAnswer, Answer_B).Result;
                            if (result_B.IsSuccessStatusCode)
                            {

                            }
                            else
                            {

                            }
                            client_answer = new HttpClient();
                            var result_C = client_answer.PostAsJsonAsync(url_InsertAnswer, Answer_C).Result;
                            if (result_C.IsSuccessStatusCode)
                            {

                            }
                            else
                            {

                            }
                            client_answer = new HttpClient();
                            var result_D = client_answer.PostAsJsonAsync(url_InsertAnswer, Answer_D).Result;
                            if (result_D.IsSuccessStatusCode)
                            {

                            }
                            else
                            {

                            }
                            
                            qd = new Question_Detail();
                            qd.Question = Question;
                            if(Group==1)
                            {
                                qd.QuestionOfGroup = 1;
                            }
                            else
                            {
                                qd.QuestionOfGroup = 0;
                            }
                            qd.Erorr = 0;
                            qd.Group = 0;
                            ls_answer = new List<Answers>();
                            ls_answer.Add(Answer_A);
                            ls_answer.Add(Answer_B);
                            ls_answer.Add(Answer_C);
                            ls_answer.Add(Answer_D);
                            qd.Answer = ls_answer;
                            Question_Success.Add(qd);
                            Question = new Questions();//create new questions
                            Answer_A = new Answers();//create new answer
                            Answer_B = new Answers();
                            Answer_C = new Answers();
                            Answer_D = new Answers();
                            Content = string.Empty;
                            answer = string.Empty;
                            continue;
                            #endregion
                        }
                        #endregion
                        //get subjectiveDifficulty
                        #region
                        if (element.InnerText.Contains("[<df>]"))
                        {
                            
                            SubjectiveDifficulty = element.InnerText.Replace("[<df>]", "").Replace("[</df>]", "");
                            try
                            {
                                Decimal sub = Convert.ToDecimal(SubjectiveDifficulty);
                                this.SubjectiveDifficulty_df = sub.ToString();
                            }
                            catch
                            {
                                
                            }
                            continue;

                        }
                        #endregion
                        //get Discrimination
                        #region
                        if (element.InnerText.Contains("[<dpc>]"))
                        {
                            Discrimination = element.InnerText.Replace("[<dpc>]", "").Replace("[</dpc>]", "");
                            try
                            {
                                Decimal dis = Convert.ToDecimal(Discrimination);
                                this.Discrimination_df = dis.ToString();
                            }
                            catch
                            {
                                
                            }
                            continue;
                        }
                        #endregion
                        //get Mark
                        #region
                        if (element.InnerText.Contains("[<sc>]"))
                        {
                            if (Group == 1)
                            {
                                Mark = element.InnerText.Replace("[<sc>]", "").Replace("[</sc>]", "");
                                try
                                {
                                    Decimal mar = Convert.ToDecimal(Mark);
                                    this.mark_df = mar.ToString();
                                }
                                catch
                                {
                                    
                                }
                                continue;
                            }
                            else
                            {
                                Mark = element.InnerText.Replace("[<sc>]", "").Replace("[</sc>]", "");
                                try
                                {
                                    Decimal mar = Convert.ToDecimal(Mark);
                                    this.mark_df = mar.ToString();
                                }
                                catch
                                {

                                }
                                continue;
                            }
                            
                        }
                        #endregion
                        //read content Question an Answer
                        #region
                        if (element.InnerText.Contains("A.") || element.InnerText.Contains("B.") || element.InnerText.Contains("C.") || element.InnerText.Contains("D."))
                        {
                            #endregion
                            
                            //get Answer A
                            #region 
                            if (element.InnerText.Contains("A."))
                            {
                                Answer_A.QuestionId = Question.Id;
                                Answer_A.Interchange = false;
                                Answer_A.Order = 1;
                                if (element.InnerXml.Contains("<w:i />"))
                                {
                                    Answer_A.Interchange = true;
                                }
                                foreach (var element_A in element.ChildElements)
                                {
                                    Answer_A.Content+= element_A.InnerText.Replace("A.", "");
                                    ///
                                   
                                    ///
                                    //get img in answer
                                    #region
                                    try
                                    {
                                        if (element_A.InnerXml.IndexOf("</w:drawing>", StringComparison.OrdinalIgnoreCase) > 0)
                                        {
                                            ImagePart imgPart = imgParts[img];
                                            Image imgs = Image.FromStream(imgPart.GetStream());
                                            img++;
                                            byte[] Bytes = ImageToByteArray(imgs);
                                            var conten = new MultipartFormDataContent();
                                            var fileContent1 = new ByteArrayContent(Bytes);
                                            string filename = Guid.NewGuid().ToString() + ".png";
                                            fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                                            {
                                                FileName = filename
                                            };
                                            conten.Add(fileContent1);
                                            client_answer = new HttpClient();
                                            var result_D = client_answer.PostAsync(host+"/api/SaveFile_Img", conten).Result;
                                            if (result_D.StatusCode == System.Net.HttpStatusCode.Created)
                                            {

                                            }
                                            else
                                            {

                                            }
                                            answer = @"<img src=" + m_img + filename + " />";
                                        }
                                    }
                                    catch
                                    {

                                    }
                                    Answer_A.Content += answer;
                                    answer = "";
                                    #endregion
                                    //read Equation in XML
                                    #region
                                    try
                                    {
                                        foreach (Ovml.OleObject oleObject in element_A.Descendants<Ovml.OleObject>())
                                        {
                                            //get the oleobject id
                                            if (oleObject.ProgId.ToString().Contains("Equation"))// in your case, ProgId should be Equation.DSMT4
                                            {
                                                foreach (V.Shape shape in element_A.Descendants<V.Shape>())
                                                {
                                                    // get the imagedata from relation id 
                                                    if (shape.Id.Value == oleObject.ShapeId.Value)
                                                    {
                                                        i++;
                                                        V.ImageData datas = shape.Descendants<V.ImageData>().FirstOrDefault();
                                                        var id = datas.RelationshipId;
                                                        var imagePart = mainDoc.GetPartById(id.Value);
                                                        Image imgs = Image.FromStream(imagePart.GetStream(FileMode.Open, FileAccess.Read));
                                                        byte[] Bytes = ImageToByteArray_PNG(imgs);
                                                        var conten = new MultipartFormDataContent();
                                                        var fileContent1 = new ByteArrayContent(Bytes);
                                                        string filename = Guid.NewGuid().ToString() + ".wmf";
                                                        fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                                                        {
                                                            FileName = filename
                                                        };
                                                        conten.Add(fileContent1);
                                                        client_answer = new HttpClient();
                                                        var result_D = client_answer.PostAsync(host+"/api/SaveFile_Img", conten).Result;
                                                        if (result_D.StatusCode == System.Net.HttpStatusCode.Created)
                                                        {

                                                        }
                                                        else
                                                        {

                                                        }
                                                        string hinh = @"<img src=" + m_img + filename + " />";
                                                        answer += hinh;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        string s = ex.Message;
                                    }
                                    #endregion
                                    Answer_A.Content += answer;
                                    answer = "";
                                }
                               
                                if (element.InnerXml.Contains("single") && element.InnerXml.Contains("<w:t>A.</w:t>"))
                                {
                                    Answer_A.Correct = true;
                                }
                                else
                                {
                                    Answer_A.Correct = false;
                                }
                                answer = string.Empty;
                            }
                            #endregion
                            //get Answer B
                            #region
                            else
                            {
                                if (element.InnerText.Contains("B."))
                                {
                                    Answer_B.QuestionId = Question.Id;
                                    Answer_B.Interchange = false;
                                    Answer_B.Order = 2;
                                    if ( element.InnerXml.Contains("<w:i />"))
                                    {
                                        Answer_B.Interchange = true;
                                    }
                                    foreach (var element_B in element.ChildElements)
                                    {
                                        Answer_B.Content += element_B.InnerText.Replace("B.", "");
                                        
                                        //get img in answer
                                        #region
                                        try
                                        {
                                            if (element_B.InnerXml.IndexOf("</w:drawing>", StringComparison.OrdinalIgnoreCase) > 0)
                                            {
                                                ImagePart imgPart = imgParts[img];
                                                Image imgs = Image.FromStream(imgPart.GetStream());
                                                img++;
                                                byte[] Bytes = ImageToByteArray(imgs);
                                                var conten = new MultipartFormDataContent();
                                                var fileContent1 = new ByteArrayContent(Bytes);
                                                string filename = Guid.NewGuid().ToString() + ".png";
                                                fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                                                {
                                                    FileName = filename
                                                };
                                                conten.Add(fileContent1);
                                                client_answer = new HttpClient();
                                                var result_D = client_answer.PostAsync(host+"/api/SaveFile_Img", conten).Result;
                                                if (result_D.StatusCode == System.Net.HttpStatusCode.Created)
                                                {

                                                }
                                                else
                                                {

                                                }
                                                answer = @"<img src=" + m_img + filename + " />";
                                            }
                                        }
                                        catch
                                        {

                                        }
                                        #endregion
                                        //read Equation in XML
                                        #region
                                        try
                                        {
                                            foreach (Ovml.OleObject oleObject in element_B.Descendants<Ovml.OleObject>())
                                            {
                                                //get the oleobject id
                                                if (oleObject.ProgId.ToString().Contains("Equation"))// in your case, ProgId should be Equation.DSMT4
                                                {
                                                    foreach (V.Shape shape in element_B.Descendants<V.Shape>())
                                                    {
                                                        // get the imagedata from relation id 
                                                        if (shape.Id.Value == oleObject.ShapeId.Value)
                                                        {
                                                            i++;
                                                            V.ImageData datas = shape.Descendants<V.ImageData>().FirstOrDefault();
                                                            var id = datas.RelationshipId;
                                                            var imagePart = mainDoc.GetPartById(id.Value);
                                                            Image imgs = Image.FromStream(imagePart.GetStream(FileMode.Open, FileAccess.Read));
                                                            byte[] Bytes = ImageToByteArray_PNG(imgs);
                                                            var conten = new MultipartFormDataContent();
                                                            var fileContent1 = new ByteArrayContent(Bytes);
                                                            string filename = Guid.NewGuid().ToString() + ".wmf";
                                                            fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                                                            {
                                                                FileName = filename
                                                            };
                                                            conten.Add(fileContent1);
                                                            client_answer = new HttpClient();
                                                            var result_D = client_answer.PostAsync(host+"/api/SaveFile_Img", conten).Result;
                                                            if (result_D.StatusCode == System.Net.HttpStatusCode.Created)
                                                            {

                                                            }
                                                            else
                                                            {

                                                            }
                                                            string hinh = @"<img src=" + m_img + filename + " />";
                                                            answer += hinh;
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        catch (Exception ex)
                                        {
                                            string s = ex.Message;
                                        }
                                        #endregion
                                        Answer_B.Content += answer;
                                        answer = "";
                                    }
                                    if (element.InnerXml.Contains("single") && element.InnerXml.Contains("<w:t>B.</w:t>"))
                                    {
                                        Answer_B.Correct = true;
                                    }
                                    else
                                    {
                                        Answer_B.Correct = false;
                                    }
                                    answer = string.Empty;
                                }
                                #endregion
                                //get Answer C
                                #region
                                else
                                {
                                    if (element.InnerText.Contains("C."))
                                    {
                                        Answer_C.QuestionId = Question.Id;
                                        Answer_C.Interchange = false;
                                        Answer_C.Order = 3;
                                        if (element.InnerXml.Contains("<w:i />"))
                                        {
                                            Answer_C.Interchange = true;
                                        }
                                        foreach (var element_C in element.ChildElements)
                                        {
                                            Answer_C.Content += element_C.InnerText.Replace("C.", "");
                                            //get img in answer
                                            #region
                                            try
                                            {
                                                if (element_C.InnerXml.IndexOf("</w:drawing>", StringComparison.OrdinalIgnoreCase) > 0)
                                                {
                                                    ImagePart imgPart = imgParts[img];
                                                    Image imgs = Image.FromStream(imgPart.GetStream());
                                                    img++;
                                                    byte[] Bytes = ImageToByteArray(imgs);
                                                    var conten = new MultipartFormDataContent();
                                                    var fileContent1 = new ByteArrayContent(Bytes);
                                                    string filename = Guid.NewGuid().ToString() + ".png";
                                                    fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                                                    {
                                                        FileName = filename
                                                    };
                                                    conten.Add(fileContent1);
                                                    client_answer = new HttpClient();
                                                    var result_D = client_answer.PostAsync(host+"/api/SaveFile_Img", conten).Result;
                                                    if (result_D.StatusCode == System.Net.HttpStatusCode.Created)
                                                    {

                                                    }
                                                    else
                                                    {

                                                    }
                                                    answer = @"<img src=" + m_img + filename + " />";
                                                }
                                            }
                                            catch
                                            {

                                            }
                                            #endregion
                                            //read Equation in XML
                                            #region
                                            try
                                            {
                                                foreach (Ovml.OleObject oleObject in element_C.Descendants<Ovml.OleObject>())
                                                {
                                                    //get the oleobject id
                                                    if (oleObject.ProgId.ToString().Contains("Equation"))// in your case, ProgId should be Equation.DSMT4
                                                    {
                                                        foreach (V.Shape shape in element_C.Descendants<V.Shape>())
                                                        {
                                                            // get the imagedata from relation id 
                                                            if (shape.Id.Value == oleObject.ShapeId.Value)
                                                            {
                                                                i++;
                                                                V.ImageData datas = shape.Descendants<V.ImageData>().FirstOrDefault();
                                                                var id = datas.RelationshipId;
                                                                var imagePart = mainDoc.GetPartById(id.Value);
                                                                Image imgs = Image.FromStream(imagePart.GetStream(FileMode.Open, FileAccess.Read));
                                                                byte[] Bytes = ImageToByteArray_PNG(imgs);
                                                                var conten = new MultipartFormDataContent();
                                                                var fileContent1 = new ByteArrayContent(Bytes);
                                                                string filename = Guid.NewGuid().ToString() + ".wmf";
                                                                fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                                                                {
                                                                    FileName = filename
                                                                };
                                                                conten.Add(fileContent1);
                                                                client_answer = new HttpClient();
                                                                var result_D = client_answer.PostAsync(host+"/api/SaveFile_Img", conten).Result;
                                                                if (result_D.StatusCode == System.Net.HttpStatusCode.Created)
                                                                {

                                                                }
                                                                else
                                                                {

                                                                }
                                                                string hinh = @"<img src=" + m_img + filename + " />";
                                                                answer += hinh;
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            catch (Exception ex)
                                            {
                                                string s = ex.Message;
                                            }
                                            #endregion
                                            Answer_C.Content += answer;
                                            answer = "";
                                        }
                                       
                                        if (element.InnerXml.Contains("single") && element.InnerXml.Contains("<w:t>C.</w:t>"))
                                        {
                                            Answer_C.Correct = true;
                                        }
                                        else
                                        {
                                            Answer_C.Correct = false;
                                        }
                                        answer = string.Empty;

                                    }
                                    #endregion
                                    //get Answer D
                                    #region
                                    else
                                    {
                                        if (element.InnerText.Contains("D."))
                                        {
                                            Answer_D.QuestionId = Question.Id;
                                            Answer_D.Interchange = false;
                                            Answer_D.Order = 4;
                                            if (element.InnerXml.Contains("<w:i />"))
                                            {
                                                Answer_D.Interchange = true;
                                            }
                                            foreach (var element_D in element.ChildElements)
                                            {

                                                Answer_D.Content += element_D.InnerText.Replace("D.", "");
                                                
                                                //get img in answer
                                                #region
                                                try
                                                {
                                                    if (element_D.InnerXml.IndexOf("</w:drawing>", StringComparison.OrdinalIgnoreCase) > 0)
                                                    {
                                                        ImagePart imgPart = imgParts[img];
                                                        Image imgs = Image.FromStream(imgPart.GetStream());
                                                        img++;
                                                        byte[] Bytes = ImageToByteArray(imgs);
                                                        var conten = new MultipartFormDataContent();
                                                        var fileContent1 = new ByteArrayContent(Bytes);
                                                        string filename = Guid.NewGuid().ToString() + ".png";
                                                        fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                                                        {
                                                            FileName = filename
                                                        };
                                                        conten.Add(fileContent1);
                                                        client_answer = new HttpClient();
                                                        var result_D = client_answer.PostAsync(host+"/api/SaveFile_Img", conten).Result;
                                                        if (result_D.StatusCode == System.Net.HttpStatusCode.Created)
                                                        {

                                                        }
                                                        else
                                                        {

                                                        }
                                                        answer = @"<img src=" + m_img + filename + " />";
                                                    }
                                                }
                                                catch
                                                {

                                                }
                                                #endregion
                                                //read Equation in XML
                                                #region
                                                try
                                                {
                                                    foreach (Ovml.OleObject oleObject in element_D.Descendants<Ovml.OleObject>())
                                                    {
                                                        //get the oleobject id
                                                        if (oleObject.ProgId.ToString().Contains("Equation"))// in your case, ProgId should be Equation.DSMT4
                                                        {
                                                            foreach (V.Shape shape in element_D.Descendants<V.Shape>())
                                                            {
                                                                // get the imagedata from relation id 
                                                                if (shape.Id.Value == oleObject.ShapeId.Value)
                                                                {
                                                                    i++;
                                                                    V.ImageData datas = shape.Descendants<V.ImageData>().FirstOrDefault();
                                                                    var id = datas.RelationshipId;
                                                                    var imagePart = mainDoc.GetPartById(id.Value);
                                                                    Image imgs = Image.FromStream(imagePart.GetStream(FileMode.Open, FileAccess.Read));
                                                                    byte[] Bytes = ImageToByteArray_PNG(imgs);
                                                                    var conten = new MultipartFormDataContent();
                                                                    var fileContent1 = new ByteArrayContent(Bytes);
                                                                    string filename = Guid.NewGuid().ToString() + ".wmf";
                                                                    fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                                                                    {
                                                                        FileName = filename
                                                                    };
                                                                    conten.Add(fileContent1);
                                                                    client_answer = new HttpClient();
                                                                    var result_D = client_answer.PostAsync(host+"/api/SaveFile_Img", conten).Result;
                                                                    if (result_D.StatusCode == System.Net.HttpStatusCode.Created)
                                                                    {

                                                                    }
                                                                    else
                                                                    {

                                                                    }
                                                                    string hinh = @"<img src=" + m_img + filename + " />";
                                                                    answer += hinh;
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                                catch (Exception ex)
                                                {
                                                    string s = ex.Message;
                                                }
                                                #endregion
                                                Answer_D.Content += answer;
                                                answer = "";
                                            }
                                            
                                            if (element.InnerXml.Contains("single") && element.InnerXml.Contains("<w:t>D.</w:t>"))
                                            {
                                                Answer_D.Correct = true;
                                            }
                                            else
                                            {
                                                Answer_D.Correct = false;
                                            }
                                            answer = string.Empty;
                                        }
                                    }
                                    #endregion
                                }
                            }
                        }
                        
                        else
                        {
                            //get content of questions in XML
                            #region
                            foreach (var element_content in element.ChildElements)
                            {
                                Content += element_content.InnerText;
                                //read Equation in XML
                                try
                                {
                                    foreach (Ovml.OleObject oleObject in element_content.Descendants<Ovml.OleObject>())
                                    {
                                        //get the oleobject id
                                        if (oleObject.ProgId.ToString().Contains("Equation"))// in your case, ProgId should be Equation.DSMT4
                                        {
                                            foreach (V.Shape shape in element_content.Descendants<V.Shape>())
                                            {
                                                // get the imagedata from relation id 
                                                if (shape.Id.Value == oleObject.ShapeId.Value)
                                                {
                                                    i++;
                                                    V.ImageData datas = shape.Descendants<V.ImageData>().FirstOrDefault();
                                                    var id = datas.RelationshipId;
                                                    var imagePart = mainDoc.GetPartById(id.Value);
                                                    Image imgs = Image.FromStream(imagePart.GetStream(FileMode.Open, FileAccess.Read));
                                                    byte[] Bytes = ImageToByteArray_PNG(imgs);
                                                    var conten = new MultipartFormDataContent();
                                                    var fileContent1 = new ByteArrayContent(Bytes);
                                                    string filename = Guid.NewGuid().ToString() + ".wmf";
                                                    fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                                                    {
                                                        FileName = filename
                                                    };
                                                    conten.Add(fileContent1);
                                                    client_answer = new HttpClient();
                                                    var result_q = client_answer.PostAsync(host+"/api/SaveFile_Img", conten).Result;
                                                    if (result_q.StatusCode == System.Net.HttpStatusCode.Created)
                                                    {

                                                    }
                                                    else
                                                    {

                                                    }
                                                    string hinh = @"<img src=" + m_img + filename + " />";
                                                    Content += hinh;
                                                }
                                            }
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    string s = ex.Message;
                                }
                                try
                                {
                                    if (element_content.InnerXml.IndexOf("</w:drawing>", StringComparison.OrdinalIgnoreCase) > 0)
                                    {
                                        ImagePart imgPart = imgParts[img];
                                        Image imgs = Image.FromStream(imgPart.GetStream());
                                        img++;
                                        byte[] Bytes = ImageToByteArray(imgs);
                                        var conten = new MultipartFormDataContent();
                                        var fileContent1 = new ByteArrayContent(Bytes);
                                        string filename = Guid.NewGuid().ToString() + ".png";
                                        fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                                        {
                                            FileName = filename
                                        };
                                        conten.Add(fileContent1);
                                        client_answer = new HttpClient();
                                        var result_q = client_answer.PostAsync(host+"/api/SaveFile_Img", conten).Result;
                                        if (result_q.StatusCode == System.Net.HttpStatusCode.Created)
                                        {

                                        }
                                        else
                                        {

                                        }
                                        string hinh = @"<img src=" + m_img + filename + " />";
                                        Content += hinh;
                                        continue;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    string s = ex.Message;
                                }
                                
                            }
                            
                            #endregion
                        }
                        Question.Content = Content;
                        #endregion
                    }
                    else
                    {
                        pageviseContent.Add(i, pageContentBuilder.ToString());
                        i++;
                        pageContentBuilder = new StringBuilder();
                    }
                    if (body.LastChild == element && pageContentBuilder.Length > 0)
                    {
                        pageviseContent.Add(i, pageContentBuilder.ToString());
                    }
                    #endregion
                }
                listquestion.Question_Error = Question_Error;
                listquestion.Question_Success = Question_Success;
            }
            return listquestion;
        }
        //convert img to byte type GiF
        #region
        public byte[] ImageToByteArray(System.Drawing.Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms.ToArray();
            }
        }
        #endregion
        //convert img to byte type PNG
        public byte[] ImageToByteArray_PNG(System.Drawing.Image imageIn)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    return ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            
        }
        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}
