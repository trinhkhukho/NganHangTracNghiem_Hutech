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
    public class AnswersController : ApiController
    {
        private ObjectiveTestEntities db = new ObjectiveTestEntities();

        // GET: api/Answers
        public IQueryable<Answer> GetAnswers()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Answers;
        }

        // GET: api/Answers/5
        [ResponseType(typeof(Answer))]
        public IHttpActionResult GetAnswer(long id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return NotFound();
            }

            return Ok(answer);
        }

        // PUT: api/Answers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAnswer(long id, Answer answer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != answer.Id)
            {
                return BadRequest();
            }

            db.Entry(answer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnswerExists(id))
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

        // POST: api/Answers
        [ResponseType(typeof(Answer))]
        public IHttpActionResult PostAnswer(Answer answer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Answers.Add(answer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = answer.Id }, answer);
        }

        // DELETE: api/Answers/5
        [ResponseType(typeof(Answer))]
        public IHttpActionResult DeleteAnswer(long id)
        {
            Answer answer = db.Answers.Find(id);
            if (answer == null)
            {
                return NotFound();
            }

            db.Answers.Remove(answer);
            db.SaveChanges();

            return Ok(answer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AnswerExists(long id)
        {
            return db.Answers.Count(e => e.Id == id) > 0;
        }
    }
}