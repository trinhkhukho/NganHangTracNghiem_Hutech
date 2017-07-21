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
        public IHttpActionResult PostUserRole(List<UsRole> userRole)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                int id_old = userRole[0].UserID;
                var us_old = db.UserRoles.Where(n => n.UserId == id_old).ToList();
                for(int j=0; j<us_old.Count(); j++)
                {
                    UserRole us_remove = us_old[j];
                    db.UserRoles.Remove(us_remove);
                }
                db.SaveChanges();

            }
            catch
            {

            }
            for (int i=0; i<userRole.Count; i++)
            {
                
                UserRole us = new UserRole();
                us.UserId = userRole[i].UserID;
                if (userRole[i].RoleID != 0)
                {
                    us.RoleId = userRole[i].RoleID;
                }
                else
                {
                    int id = userRole[i].ChapterID;
                    Role r = db.Roles.Where(n => n.ChapterId == id).SingleOrDefault();
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
                catch (Exception ex)
                {
                    
                }
            }
            

            return CreatedAtRoute("DefaultApi", new { id = 1}, userRole);
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