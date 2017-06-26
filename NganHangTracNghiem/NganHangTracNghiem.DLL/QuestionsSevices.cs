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
                qs.ChapterId = 9; //gán cứng chapter
                qs.Mark = questionsModel.Diem;
                qs.Discrimination = questionsModel.DoPhanCach;
                qs.ObjectiveDifficulty = questionsModel.DoKho;
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
                qs.ChapterId = 9; //gán cứng chapter
                qs.Mark = questionsModel.Diem;
                qs.Discrimination = questionsModel.DoPhanCach;
                qs.ObjectiveDifficulty = questionsModel.DoKho;
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
                qs.ChapterId = 9; //gán cứng chapter
                qs.Mark = questionsModel.Diem;
                qs.ParentId = questionsModel.ParentId;
                qs.Discrimination = questionsModel.DoPhanCach;
                qs.ObjectiveDifficulty = questionsModel.DoKho;
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
            List<Questions> listQuestions = new List<Questions>();
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


       // lấy đáp án của câu hỏi
        //public List<Answers> GetQuestion(int id, string host)
        //{
        //    List<Questions> listQuestions = new List<Questions>();
        //    string url_getQuestion = host + "/api/QuestionUser/" + ;
        //    HttpClient client_Question = new HttpClient(); //using call api save Question
        //    client_Question.BaseAddress = new Uri(host);
        //    client_Question.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //    var reponse = client_Question.GetAsync(url_getQuestion).Result;
        //    if (reponse.IsSuccessStatusCode)
        //    {
        //        listQuestions = reponse.Content.ReadAsAsync<List<Questions>>().Result;
        //    }

        //    return listQuestions;
        //}


    }
}

