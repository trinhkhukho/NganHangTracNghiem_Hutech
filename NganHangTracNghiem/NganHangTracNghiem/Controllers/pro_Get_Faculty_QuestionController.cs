using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NganHangTracNghiem.Models;

namespace NganHangTracNghiem.Controllers
{
    public class pro_Get_Faculty_QuestionController : ApiController
    {
        ObjectiveTestEntities db = new ObjectiveTestEntities();
        public IHttpActionResult Getpro_Get_Faculty_Question(int id)
        {
            try
            {
                var result = db.pro_Get_Faculty_Question3(id);
                if(result!=null)
                {
                    return Ok(result);
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
