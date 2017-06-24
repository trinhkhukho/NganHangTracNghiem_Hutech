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
        ObjectiveTestEntities db = new ObjectiveTestEntities();
        public IQueryable<Question> GetQuestionUser(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            var ListQuestion = db.Questions.Where(n => n.UserId == id);
            return ListQuestion;
        }
    }
}
