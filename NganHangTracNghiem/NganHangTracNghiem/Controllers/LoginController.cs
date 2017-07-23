using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;
using NganHangTracNghiem.Models;

namespace NganHangTracNghiem.Controllers
{
    public class LoginController : ApiController
    {
        ObjectiveTestEntities db = new ObjectiveTestEntities();
        [HttpPost]
        public IHttpActionResult login(UserLogin user)
        {
            try
            {
                var us = db.Users.Where(n => n.Username == user.UserName && n.Password == user.PassWord).SingleOrDefault();
                if(us.Username!=null && us.Username!="")
                {
                    return Ok(us.Id);
                }
                return Ok(0);
            }
            catch
            {
                return Ok(-1);
            }
        }
    }
}
