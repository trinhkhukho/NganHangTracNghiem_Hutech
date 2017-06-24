using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NganHangTracNghiem.Models;
using System.Web.Http.Description;

namespace NganHangTracNghiem.Controllers
{
    public class RegisterController : ApiController
    {
        ObjectiveTestEntities db = new ObjectiveTestEntities();
        [HttpPost]
        [Route("api/Register/UserName")]
        public IHttpActionResult UserNames (User u)
        {
            try
            {
                int error = 0;
                var user = db.Users.Where(n => n.Username == u.Username);
                if (user.Count() != 0)
                {
                    error = 1;
                }
                else
                {
                    error = 0;
                }
                return Ok(error);
            }
            catch
            {
                return InternalServerError();
            }
           
        }
    }
}
