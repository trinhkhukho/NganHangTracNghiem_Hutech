﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NganHangTracNghiem.Models;

namespace NganHangTracNghiem.Controllers
{
    public class pro_Subject_FacultyId_QuestionController : ApiController
    {
        ObjectiveTestEntities db = new ObjectiveTestEntities();
        public IHttpActionResult Getpro_Subject_FacultyId_Question()
        {
            try
            {
                var result = db.pro_Subject_FacultyId_Question();
                if (result != null)
                {
                    return Ok(result);
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
