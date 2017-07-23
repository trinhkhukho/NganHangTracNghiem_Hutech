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
        [HttpPost]
        public IHttpActionResult PostChapter(List<int> lsID)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Chapter> lsChapter = new List<Chapter>();
                for(int i=0; i<lsID.Count;i++)
                {
                    
                    int chId = lsID[i];
                    Chapter ch = db.Chapters.Where(n => n.Id == chId).SingleOrDefault();
                    lsChapter.Add(ch);
                }
               
                if (lsChapter.Count >0)
                {
                    return Ok(lsChapter);
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
