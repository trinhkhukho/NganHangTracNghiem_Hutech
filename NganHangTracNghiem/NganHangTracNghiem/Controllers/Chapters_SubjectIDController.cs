using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NganHangTracNghiem.Models;

namespace NganHangTracNghiem.Controllers
{
    public class Chapters_SubjectIDController : ApiController
    {
        ObjectiveTestEntities db = new ObjectiveTestEntities();
        public IHttpActionResult GetChapter(int id)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var result = db.Chapters.Where(n => n.SubjectId == id);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
