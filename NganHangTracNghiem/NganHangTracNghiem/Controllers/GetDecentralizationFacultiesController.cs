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
    public class GetDecentralizationFacultiesController : ApiController
    {
        ObjectiveTestEntities db = new ObjectiveTestEntities();
        [HttpPost]
        public IHttpActionResult Decen_faculties(List<int> lsID)
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                List<Faculty> lsf = new List<Faculty>();
                for(int i=0; i<lsID.Count; i++)
                {
                    int id = lsID[i];
                    Faculty f = new Faculty();
                    f = db.Faculties.Find(id);
                    lsf.Add(f);
                }
                if(lsf.Count>0)
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
