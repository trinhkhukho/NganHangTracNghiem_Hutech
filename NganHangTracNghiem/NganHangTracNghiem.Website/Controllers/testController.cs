using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NganHangTracNghiem.Website.Controllers
{
    public class testController : ApiController
    {
        [HttpGet]
        [Route("api/test")]
        public IHttpActionResult test()
        {
            return Ok("Hello");
        }
    }
}
