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

namespace NganHangTracNghiem.API.Controllers
{
    public class ChaptersController : ApiController
    {
        private ObjectiveTestEntities db = new ObjectiveTestEntities();

        // GET: api/Chapters
        public IQueryable<Chapter> GetChapters()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Chapters;
        }

        // GET: api/Chapters/5
        [ResponseType(typeof(Chapter))]
        public IHttpActionResult GetChapter(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Chapter chapter = db.Chapters.Find(id);
            if (chapter == null)
            {
                return NotFound();
            }

            return Ok(chapter);
        }

        // PUT: api/Chapters/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChapter(int id, Chapter chapter)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chapter.Id)
            {
                return BadRequest();
            }

            db.Entry(chapter).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
                Role r = db.Roles.Where(n => n.ChapterId == id).SingleOrDefault();
                if (r != null)
                {
                    var subject = db.Subjects.Where(n => n.Id == chapter.SubjectId).SingleOrDefault();
                    r.ChapterId = chapter.Id;
                    r.SubjectId = chapter.SubjectId;
                    r.FacultiesId = subject.FacultyId;
                    r.Name = chapter.Name;
                    db.Entry(r).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChapterExists(id))
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

        // POST: api/Chapters
        [ResponseType(typeof(Chapter))]
        public IHttpActionResult PostChapter(Chapter chapter)
        {
            db.Configuration.ProxyCreationEnabled = false;
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Chapters.Add(chapter);
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
            var subject = db.Subjects.Where(n => n.Id == chapter.SubjectId).SingleOrDefault();
            r.ChapterId = chapter.Id;
            r.SubjectId = chapter.SubjectId;
            r.FacultiesId = subject.FacultyId;
            r.Name = chapter.Name;
            db.Roles.Add(r);
            db.SaveChanges();
            return Ok();
        }

        // DELETE: api/Chapters/5
        [ResponseType(typeof(Chapter))]
        public IHttpActionResult DeleteChapter(int id)
        {
            Chapter chapter = db.Chapters.Find(id);
            if (chapter == null)
            {
                return NotFound();
            }

            db.Chapters.Remove(chapter);
            Role r = db.Roles.Where( n=>n.ChapterId == id).SingleOrDefault();
            if (r != null)
            {
                db.Roles.Remove(r);

            }
            db.SaveChanges();

            return Ok(chapter);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChapterExists(int id)
        {
            return db.Chapters.Count(e => e.Id == id) > 0;
        }
    }
}