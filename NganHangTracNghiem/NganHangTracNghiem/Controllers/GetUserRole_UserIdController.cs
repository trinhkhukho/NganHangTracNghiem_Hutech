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
    public class GetUserRole_UserIdController : ApiController
    {
        ObjectiveTestEntities db = new ObjectiveTestEntities();
        public IHttpActionResult GetUserRole(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            try
            {
                var ls = from us in db.UserRoles
                                    from r in db.Roles
                                    where us.UserId==id & us.RoleId==r.Id 
                                    select r;
                if(ls!=null && ls.Count()>0)
                {
                    return Ok(ls);
                }
                else
                {
                    return InternalServerError();
                }
            }
            catch
            {
                return InternalServerError();
            }
        }
    }
}
