using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NganHangTracNghiem.Models;

namespace NganHangTracNghiem.Controllers
{
    public class AnswersQuestionController : ApiController
    {
        ObjectiveTestEntities db = new ObjectiveTestEntities();
        public IHttpActionResult GetAnswersQuestion(int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var answers = db.Answers.Where(n => n.QuestionId == id);
                return Ok(answers);
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
