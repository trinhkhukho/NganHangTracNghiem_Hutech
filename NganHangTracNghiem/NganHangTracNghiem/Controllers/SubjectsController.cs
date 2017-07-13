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
    public class SubjectsController : ApiController
    {
        private ObjectiveTestEntities db = new ObjectiveTestEntities();

        // GET: api/Subjects
        public IQueryable<Subject> GetSubjects()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Subjects;
        }

        // GET: api/Subjects/5
        [ResponseType(typeof(Subject))]
        public IHttpActionResult GetSubject(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return NotFound();
            }

            return Ok(subject);
        }

        // PUT: api/Subjects/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSubject(int id, Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != subject.Id)
            {
                return BadRequest();
            }

            db.Entry(subject).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                Role r = db.Roles.Where(n => n.SubjectId == subject.Id & n.ChapterId == null).SingleOrDefault();
                if (r != null)
                {
                    r.FacultiesId = subject.FacultyId;
                    r.FacultiesId = subject.Id;
                    r.Name = subject.Name;
                    db.Entry(r).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubjectExists(id))
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

        // POST: api/Subjects
        [ResponseType(typeof(Subject))]
        public IHttpActionResult PostSubject(Subject subject)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Subjects.Add(subject);
            db.SaveChanges();
            Role r = new Role();
            Role r_old = db.Roles.OrderByDescending(n => n.Id).Take(1).SingleOrDefault();
            if (r_old != null)
            {
                r.Id = r_old.Id + 1;
            }
            else
            {
                r.Id = 1;
            }
            r.FacultiesId = subject.FacultyId;
            r.SubjectId = subject.Id;
            r.Name = subject.Name;
            db.Roles.Add(r);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = subject.Id }, subject);
        }

        // DELETE: api/Subjects/5
        [ResponseType(typeof(Subject))]
        public IHttpActionResult DeleteSubject(int id)
        {
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return NotFound();
            }

            db.Subjects.Remove(subject);
            Role r = db.Roles.Where(n =>n.SubjectId == id & n.ChapterId == null).SingleOrDefault();
            if(r!=null)
            {
                db.Roles.Remove(r);

            }
            db.SaveChanges();

            return Ok(subject);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SubjectExists(int id)
        {
            return db.Subjects.Count(e => e.Id == id) > 0;
        }
    }
}