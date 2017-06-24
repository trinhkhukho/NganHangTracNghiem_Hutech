using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using NganHangTracNghiem.Models;

namespace NganHangTracNghiem.Controllers
{
    public class QuestionsController : ApiController
    {
        private ObjectiveTestEntities db = new ObjectiveTestEntities();

        // GET: api/Questions
        public IQueryable<Question> GetQuestions()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Questions;
        }

        // GET: api/Questions/5
        [ResponseType(typeof(Question))]
        public IHttpActionResult GetQuestion(long id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Question question;
            if (id==0)//lấy câu hỏi có id cao nhất
            {
                question = db.Questions.OrderByDescending(n => n.Id).FirstOrDefault();
                if (question == null)
                {
                    return NotFound();
                }

                return Ok(question);
            }
            if(id==-1)//lấy câu hỏi có id nhỏ nhất
            {
                question = db.Questions.FirstOrDefault();
                if (question == null)
                {
                    return NotFound();
                }
                return Ok(question);
            }
            question = db.Questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }

            return Ok(question);
        }
        // PUT: api/Questions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuestion(long id, Question question)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != question.Id)
            {
                return BadRequest();
            }

            db.Entry(question).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuestionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Questions
        [ResponseType(typeof(Question))]
        public IHttpActionResult PostQuestion(Question question)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Questions.Add(question);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = question.Id }, question);
        }

        // DELETE: api/Questions/5
        [ResponseType(typeof(Question))]
        public IHttpActionResult DeleteQuestion(long id)
        {
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return NotFound();
            }

            db.Questions.Remove(question);
            db.SaveChanges();

            return Ok(question);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuestionExists(long id)
        {
            return db.Questions.Count(e => e.Id == id) > 0;
        }
    }
}