using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace NganHangTracNghiem.Controllers
{
    public class LoginController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("api/Login")]
        public IHttpActionResult LoginAuthenticate()
        {
            var identity = (ClaimsIdentity)User.Identity;

            return Ok(identity.Name);
        }
    }
}
