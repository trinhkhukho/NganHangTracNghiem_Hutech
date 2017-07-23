using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NganHangTracNghiem.Models;

namespace NganHangTracNghiem.Controllers
{
    public class Subjects_FacultiesIDController : ApiController
    {
        ObjectiveTestEntities db = new ObjectiveTestEntities();
        [HttpPost]
        public IHttpActionResult PostSubject(List<int> lsID)
        { 
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Subject> lsSub = new List<Subject>();
                for(int i=0; i<lsID.Count; i++)
                {
                    int subId = lsID[i];
                    Subject sub = db.Subjects.Where(n =>n.Id == subId).SingleOrDefault();
                    lsSub.Add(sub);
                }
                if (lsSub.Count>0)
                {
                    return Ok(lsSub);
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
