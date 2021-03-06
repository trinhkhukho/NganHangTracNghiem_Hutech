﻿using System;
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
    public class FacultiesController : ApiController
    {
        private ObjectiveTestEntities db = new ObjectiveTestEntities();

        // GET: api/Faculties
        public IQueryable<Faculty> GetFaculties()
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.Faculties;
        }

        // GET: api/Faculties/5
        [ResponseType(typeof(Faculty))]
        public IHttpActionResult GetFaculty(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            Faculty faculty = db.Faculties.Find(id);
            if (faculty == null)
            {
                return NotFound();
            }

            return Ok(faculty);
        }

        // PUT: api/Faculties/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFaculty(int id, Faculty faculty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != faculty.Id)
            {
                return BadRequest();
            }

            db.Entry(faculty).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
                Role r = db.Roles.Where(n=>n.FacultiesId==id & n.SubjectId==null & n.ChapterId==null).SingleOrDefault();
                if(r!=null)
                {
                    r.FacultiesId = faculty.Id;
                    r.Name = faculty.Name;
                    db.Entry(r).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                }
                

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacultyExists(id))
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

        // POST: api/Faculties
        [ResponseType(typeof(Faculty))]
        public IHttpActionResult PostFaculty(Faculty faculty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Faculties.Add(faculty);
            db.SaveChanges();
            Role r = new Role();
            Role r_old = db.Roles.OrderByDescending(n => n.Id).Take(1).SingleOrDefault();
            if(r_old!=null)
            {
                r.Id = r_old.Id + 1;
            }
            else
            {
                r.Id =1;
            }
            r.FacultiesId = faculty.Id;
            r.Name = faculty.Name;
            r.ChapterId = 0;
            r.SubjectId = 0;
            db.Roles.Add(r);
            db.SaveChanges();
            return CreatedAtRoute("DefaultApi", new { id = faculty.Id }, faculty);
        }

        // DELETE: api/Faculties/5
        [ResponseType(typeof(Faculty))]
        public IHttpActionResult DeleteFaculty(int id)
        {
            try
            {
                Faculty faculty = db.Faculties.Find(id);
                if (faculty == null)
                {
                    return NotFound();
                }
                db.Faculties.Remove(faculty);
                Role r = db.Roles.Where(n => n.FacultiesId == id & n.SubjectId == null & n.ChapterId == null).SingleOrDefault();
                if(r!=null)
                {
                    db.Roles.Remove(r);
                }             
                db.SaveChanges();
                

                return Ok(faculty);
            }
            catch
            {
                return NotFound();
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FacultyExists(int id)
        {
            return db.Faculties.Count(e => e.Id == id) > 0;
        }
    }
}