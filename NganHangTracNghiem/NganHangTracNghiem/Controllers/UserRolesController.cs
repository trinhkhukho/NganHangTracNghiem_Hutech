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
    public class UserRolesController : ApiController
    {
        private ObjectiveTestEntities db = new ObjectiveTestEntities();

        // GET: api/UserRoles
        public IQueryable<UserRole> GetUserRoles()
        {
            return db.UserRoles;
        }

        // GET: api/UserRoles/5
        [ResponseType(typeof(UserRole))]
        public IHttpActionResult GetUserRole(int id)
        {
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return NotFound();
            }

            return Ok(userRole);
        }

        // PUT: api/UserRoles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUserRole(int id, UserRole  userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userRole.UserId)
            {
                return BadRequest();
            }

            
            db.Entry(userRole).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserRoleExists(id))
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

        // POST: api/UserRoles
        [ResponseType(typeof(UserRole))]
        public IHttpActionResult PostUserRole(UsRole userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            UserRole us = new UserRole();
            us.UserId = userRole.UserID;
            if (userRole.RoleID != 0)
            {
                us.RoleId = userRole.RoleID;
            }
            else
            {
                Role r = db.Roles.Where(n => n.FacultiesId == userRole.FacultiesID & n.SubjectId == userRole.SubjectID & n.ChapterId == userRole.ChapterID).SingleOrDefault();
                if (r != null)
                {
                    us.RoleId = r.Id;
                }
            }
            db.UserRoles.Add(us);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (UserRoleExists(userRole.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = userRole.UserID }, userRole);
        }

        // DELETE: api/UserRoles/5
        [ResponseType(typeof(UserRole))]
        public IHttpActionResult DeleteUserRole(int id)
        {
            UserRole userRole = db.UserRoles.Find(id);
            if (userRole == null)
            {
                return NotFound();
            }

            db.UserRoles.Remove(userRole);
            db.SaveChanges();

            return Ok(userRole);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserRoleExists(int id)
        {
            return db.UserRoles.Count(e => e.UserId == id) > 0;
        }
    }
}