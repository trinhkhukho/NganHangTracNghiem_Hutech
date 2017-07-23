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
    public class GetDecentralizationChapterController : ApiController
    {
        ObjectiveTestEntities db = new ObjectiveTestEntities();
        [HttpPost]
        public IHttpActionResult Decen_chapter(List<int> lsID)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Chapter> lsf = new List<Chapter>();
                for (int i = 0; i < lsID.Count; i++)
                {
                    Chapter c = db.Chapters.Find(lsID[i]);
                    lsf.Add(c);
                }
                if (lsf.Count > 0)
                {
                    return Ok(lsf);
                }
                else
                {
                    return Ok(0);
                }
            }
            catch
            {
                return Ok(0);
            }
        }
    }
}
