using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NganHangTracNghiem.Models;

namespace NganHangTracNghiem.Controllers
{
    public class QuestionUserController : ApiController
    {
        // GET: /api/QuestionUser/10001
        ObjectiveTestEntities db = new ObjectiveTestEntities();

        //public IHttpActionResult GetQuestionUser(int id)
        //{
        //    db.Configuration.ProxyCreationEnabled = false;
        //    var ListQuestion = db.Questions.Where(n => n.UserId == id);
        //    List<Question_Chapter> questionChapters = new List<Question_Chapter>();
        //    foreach (var a in ListQuestion)
        //    {
        //        Question_Chapter qc=new Question_Chapter();
        //        qc.question = a;
        //        qc.chapter = db.Chapters.SingleOrDefault(n => n.Id == a.ChapterId);
        //        questionChapters.Add(qc);
        //    }
        //    //return ListQuestion;
        //    return Ok(questionChapters);
        //}
        ////public IHttpActionResult GetQuestionUser(int id)
        ////{
        ////    db.Configuration.ProxyCreationEnabled = false;
        ////    var ListQuestion = db.Questions.Where(n => n.UserId == id);
        ////    List<Question_Chapter> question_chapter = new List<Question_Chapter>();
        ////    foreach (var a in ListQuestion)
        ////    {
        ////        Question_Chapter qc = new Question_Chapter();
        ////        qc.question = a;
        ////        qc.chapter = db.Chapters.SingleOrDefault(n => n.Id == a.ChapterId);
        ////        question_chapter.Add(qc);
        ////    }
        ////    return Ok(question_chapter);
        ////}
        public IHttpActionResult GetQuestionUser(int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var question_chapter = from a in db.Questions
                    from b in db.Chapters
                    where a.ChapterId == b.Id && a.UserId == id
                    select new
                    {
                        Id = a.Id,
                        Content = a.Content,
                        Interchange = a.Interchange,
                        SubjectiveDifficulty = a.SubjectiveDifficulty,
                        CorrectTimes = a.CorrectTimes,
                        Deleted = a.Deleted,
                        ChapterId = a.ChapterId,
                        CreateDate = a.CreateDate,
                        UpdateDate = a.UpdateDate,
                        Mark = a.Mark,
                        Duration = a.Duration,
                        ParentId = a.ParentId,
                        Audio = a.Audio,
                        Discrimination = a.Discrimination,
                        ManagementOrder = a.ManagementOrder,
                        SubjectId = a.SubjectId,
                        ListenedTimes = a.ListenedTimes,
                        ObjectiveDifficulty = a.ObjectiveDifficulty,
                        UserId = a.UserId,
                        Name = b.Name
                    };
                return Ok(question_chapter);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}