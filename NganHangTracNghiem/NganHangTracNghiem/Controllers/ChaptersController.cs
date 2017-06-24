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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Chapters.Add(chapter);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chapter.Id }, chapter);
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