using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using NganHangTracNghiem.Data;

namespace NganHangTracNghiem.DLL
{
    public class QuestionsSevices
    {
        //tạo câu hỏi đơn
        public int CreateQuestion(ModelQuestions questionsModel, string host)
        {
            try
            {
                string url_InsertQuestion = host + "/api/Questions";
                string url_InsertAnswer = host + "/api/Answers";
                HttpClient client_Question = new HttpClient(); //using call api save Question
                HttpClient client_answer = new HttpClient(); //using call api save Answer
                Questions qs = new Questions();
                Answers Answer_A = new Answers();
                Answers Answer_B = new Answers();
                Answers Answer_C = new Answers();
                Answers Answer_D = new Answers();
                //gán dữ liệu cho câu hỏi
                qs.Content = questionsModel.DeBai;
                qs.ChapterId = questionsModel.ChapterId; //gán cứng chapter
                qs.Mark = questionsModel.Diem;
                qs.Discrimination = questionsModel.DoPhanCach;
                qs.ObjectiveDifficulty = questionsModel.DoKho;
                qs.UserId = questionsModel.UserId;
                client_Question = new HttpClient();
                var result_q = client_Question.PostAsJsonAsync(url_InsertQuestion, qs).Result;
                if (result_q.IsSuccessStatusCode)
                {
                    client_Question = new HttpClient();
                    client_Question.BaseAddress = new Uri(host);
                    client_Question.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var reponse = client_Question.GetAsync("api/Questions/0").Result;
                    if (reponse.IsSuccessStatusCode)
                    {
                        qs = reponse.Content.ReadAsAsync<Questions>().Result;
                        //gán dữ liệu cho đáp án
                        Answer_A.QuestionId = qs.Id;
                        Answer_A.Content = questionsModel.CauA;
                        Answer_A.Interchange = questionsModel.HoanViA;
                        Answer_A.Correct = questionsModel.DapAnA;
                        var result_A = client_answer.PostAsJsonAsync(url_InsertAnswer, Answer_A).Result;
                        //gán dữ liệu đáp án câu B
                        Answer_B.QuestionId = qs.Id;
                        Answer_B.Content = questionsModel.CauB;
                        Answer_B.Interchange = questionsModel.HoanViB;
                        Answer_B.Correct = questionsModel.DapAnB;
                        var result_B = client_answer.PostAsJsonAsync(url_InsertAnswer, Answer_B).Result;
                        ///gán dữ liệu đáp án Câu C
                        Answer_C.QuestionId = qs.Id;
                        Answer_C.Content = questionsModel.CauC;
                        Answer_C.Interchange = questionsModel.HoanViC;
                        Answer_C.Correct = questionsModel.DapAnC;
                        var result_C = client_answer.PostAsJsonAsync(url_InsertAnswer, Answer_C).Result;
                        ///gán dữ liệu đáp án Câu D
                        Answer_D.QuestionId = qs.Id;
                        Answer_D.Content = questionsModel.CauD;
                        Answer_D.Interchange = questionsModel.HoanViD;
                        Answer_D.Correct = questionsModel.DapAnD;
                        var result_D = client_answer.PostAsJsonAsync(url_InsertAnswer, Answer_D).Result;
                    }
                    else
                    {
                        return 0;
                    }
                }
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        // tạo đề bài cho câu hỏi nhóm
        public long CreateQuestionGroupParent(ModelQuestionsGroupParent questionsModel, string host)
        {
            try
            {
                string url_InsertQuestion = host + "/api/Questions";
                HttpClient client_Question = new HttpClient(); //using call api save Question
                Questions qs = new Questions();
                //gán dữ liệu cho câu hỏi
                qs.Content = questionsModel.DeBai;
                qs.ChapterId = questionsModel.ChapterId; //gán cứng chapter
                qs.Mark = questionsModel.Diem;
                qs.Discrimination = questionsModel.DoPhanCach;
                qs.ObjectiveDifficulty = questionsModel.DoKho;
                qs.UserId = questionsModel.UserId;
                client_Question = new HttpClient();
                var result_q = client_Question.PostAsJsonAsync(url_InsertQuestion, qs).Result;
                if (result_q.IsSuccessStatusCode)
                {
                    client_Question = new HttpClient();
                    client_Question.BaseAddress = new Uri(host);
                    client_Question.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var reponse = client_Question.GetAsync("api/Questions/0").Result;
                    if (reponse.IsSuccessStatusCode)
                    {
                        qs = reponse.Content.ReadAsAsync<Questions>().Result;
                        return qs.Id;
                        //gán dữ liệu cho đáp án

                    }
                    else
                    {
                        return 0;
                    }
                }
                else
                {
                    return 0;
                }

            }
            catch
            {
                return 0;
            }


        }

        //tạo câu hỏi con
        public int CreateQuestionGroupChil(ModelQuestionsGroupChil questionsModel, string host)
        {
            try
            {
                string url_InsertQuestion = host + "/api/Questions";
                string url_InsertAnswer = host + "/api/Answers";
                HttpClient client_Question = new HttpClient(); //using call api save Question
                HttpClient client_answer = new HttpClient(); //using call api save Answer
                Questions qs = new Questions();
                Answers Answer_A = new Answers();
                Answers Answer_B = new Answers();
                Answers Answer_C = new Answers();
                Answers Answer_D = new Answers();
                //gán dữ liệu cho câu hỏi
                qs.Content = questionsModel.DeBai;
                qs.ChapterId = questionsModel.ChapterId; //gán cứng chapter
                qs.Mark = questionsModel.Diem;
                qs.ParentId = questionsModel.ParentId;
                qs.Discrimination = questionsModel.DoPhanCach;
                qs.ObjectiveDifficulty = questionsModel.DoKho;
                qs.UserId = questionsModel.UserId;
                client_Question = new HttpClient();
                var result_q = client_Question.PostAsJsonAsync(url_InsertQuestion, qs).Result;
                if (result_q.IsSuccessStatusCode)
                {
                    client_Question = new HttpClient();
                    client_Question.BaseAddress = new Uri(host);
                    client_Question.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));
                    var reponse = client_Question.GetAsync("api/Questions/0").Result;
                    if (reponse.IsSuccessStatusCode)
                    {
                        qs = reponse.Content.ReadAsAsync<Questions>().Result;
                        //gán dữ liệu cho đáp án
                        Answer_A.QuestionId = qs.Id;
                        Answer_A.Content = questionsModel.CauA;
                        Answer_A.Interchange = questionsModel.HoanViA;
                        Answer_A.Correct = questionsModel.DapAnA;
                        var result_A = client_answer.PostAsJsonAsync(url_InsertAnswer, Answer_A).Result;
                        //gán dữ liệu đáp án câu B
                        Answer_B.QuestionId = qs.Id;
                        Answer_B.Content = questionsModel.CauB;
                        Answer_B.Interchange = questionsModel.HoanViB;
                        Answer_B.Correct = questionsModel.DapAnB;
                        var result_B = client_answer.PostAsJsonAsync(url_InsertAnswer, Answer_B).Result;
                        ///gán dữ liệu đáp án Câu C
                        Answer_C.QuestionId = qs.Id;
                        Answer_C.Content = questionsModel.CauC;
                        Answer_C.Interchange = questionsModel.HoanViC;
                        Answer_C.Correct = questionsModel.DapAnC;
                        var result_C = client_answer.PostAsJsonAsync(url_InsertAnswer, Answer_C).Result;
                        ///gán dữ liệu đáp án Câu D
                        Answer_D.QuestionId = qs.Id;
                        Answer_D.Content = questionsModel.CauD;
                        Answer_D.Interchange = questionsModel.HoanViD;
                        Answer_D.Correct = questionsModel.DapAnD;
                        var result_D = client_answer.PostAsJsonAsync(url_InsertAnswer, Answer_D).Result;
                    }
                    else
                    {
                        return 0;
                    }
                }
                return 1;
            }
            catch
            {
                return 0;
            }

        }

        // lấy danh sách câu hỏi
        public HttpResponseMessage GetQuestion(int userId, string host)
        {
            string url_getQuestion = host + "/api/QuestionUser/" + userId;
            HttpClient client_Question = new HttpClient(); //using call api save Question
            client_Question.BaseAddress = new Uri(host);
            client_Question.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var reponse = client_Question.GetAsync(url_getQuestion).Result;
            //if (reponse.IsSuccessStatusCode)
            //{
            //    listQuestions = reponse.Content.ReadAsAsync<List<Questions>>().Result;
            //}
            return reponse;
        }


        // Chỉnh sửa câu hỏi
        public int EditQuestion(ModelQuestionsEdit questionsModel, string host)
        {
            try
            {
                string url_Question = host + "/api/Questions/";
                string url_Answer = host + "/api/Answers/";
                HttpClient client = new HttpClient(); //using call api save Question

                Questions qs = new Questions();
                Answers Answer_A = new Answers();
                Answers Answer_B = new Answers();
                Answers Answer_C = new Answers();
                Answers Answer_D = new Answers();

                //lấy dữ liệu cũ lên
                var Result = client.GetAsync(url_Question + questionsModel.IdQuestion).Result;
                qs = Result.Content.ReadAsAsync<Questions>().Result;
                //A
                var ResultA = client.GetAsync(url_Answer + questionsModel.IdAnswerA).Result;
                Answer_A = ResultA.Content.ReadAsAsync<Answers>().Result;
                //B
                var ResultB = client.GetAsync(url_Answer + questionsModel.IdAnswerB).Result;
                Answer_B = ResultB.Content.ReadAsAsync<Answers>().Result;
                //C
                var ResultC = client.GetAsync(url_Answer + questionsModel.IdAnswerC).Result;
                Answer_C = ResultC.Content.ReadAsAsync<Answers>().Result;
                //D
                var ResultD = client.GetAsync(url_Answer + questionsModel.IdAnswerD).Result;
                Answer_D = ResultD.Content.ReadAsAsync<Answers>().Result;

                qs.Id = questionsModel.IdQuestion;
                qs.Content = questionsModel.DeBai;
               /* qs.ChapterId = questionsModel.ChapterId;*/ //gán cứng chapter
                qs.Mark = questionsModel.Diem;
                qs.Discrimination = questionsModel.DoPhanCach;
                qs.ObjectiveDifficulty = questionsModel.DoKho;
                client = new HttpClient();
                var result_q = client.PutAsJsonAsync(url_Question + questionsModel.IdQuestion, qs).Result;

                if (result_q.IsSuccessStatusCode)
                {
                    client = new HttpClient();
                    //A
                    Answer_A.Id = questionsModel.IdAnswerA;
                    Answer_A.Correct = questionsModel.DapAnA;
                    Answer_A.Content = questionsModel.CauA;
                    Answer_A.Interchange = questionsModel.HoanViA;
                    var result_a = client.PutAsJsonAsync(url_Answer + questionsModel.IdAnswerA, Answer_A).Result;
                    //B
                    Answer_B.Id = questionsModel.IdAnswerB;
                    Answer_B.Correct = questionsModel.DapAnB;
                    Answer_B.Content = questionsModel.CauB;
                    Answer_B.Interchange = questionsModel.HoanViB;
                    var result_b = client.PutAsJsonAsync(url_Answer + questionsModel.IdAnswerB, Answer_B).Result;
                    //A
                    Answer_C.Id = questionsModel.IdAnswerC;
                    Answer_C.Correct = questionsModel.DapAnC;
                    Answer_C.Content = questionsModel.CauC;
                    Answer_C.Interchange = questionsModel.HoanViC;
                    var result_c = client.PutAsJsonAsync(url_Answer + questionsModel.IdAnswerC, Answer_C).Result;
                    //A
                    Answer_D.Id = questionsModel.IdAnswerD;
                    Answer_D.Correct = questionsModel.DapAnD;
                    Answer_D.Content = questionsModel.CauD;
                    Answer_D.Interchange = questionsModel.HoanViD;
                    var result_d = client.PutAsJsonAsync(url_Answer + questionsModel.IdAnswerD, Answer_D).Result;
                    return 1;
                }
                else
                {
                    return 0;
                }

            }
            catch
            {
                return 0;
            }

        }
        //xóa câu hỏi
        public int deleteQuestion(ModelQuestionsDelete questionsModel, string host)
        {
            try
            {
                string url_InsertQuestion = host + "/api/Questions/";
                string url_InsertAnswer = host + "/api/Answers/";
                HttpClient client = new HttpClient(); //using call api save Question

                client = new HttpClient();
                var result_a = client.DeleteAsync(url_InsertAnswer + questionsModel.IdAnswerA).Result;
                var result_b = client.DeleteAsync(url_InsertAnswer + questionsModel.IdAnswerB).Result;
                var result_c = client.DeleteAsync(url_InsertAnswer + questionsModel.IdAnswerC).Result;
                var result_d = client.DeleteAsync(url_InsertAnswer + questionsModel.IdAnswerD).Result;
                if (result_a.IsSuccessStatusCode && result_b.IsSuccessStatusCode && result_c.IsSuccessStatusCode && result_d.IsSuccessStatusCode)
                {
                    var result_q = client.DeleteAsync(url_InsertQuestion + questionsModel.IdQuestion).Result;
                }
                return 1;
            }
            catch
            {
                return 0;
            }

        }
    }
}

