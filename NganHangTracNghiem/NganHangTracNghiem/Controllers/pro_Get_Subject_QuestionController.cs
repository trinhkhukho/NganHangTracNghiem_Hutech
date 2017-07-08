﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NganHangTracNghiem.Models;

namespace NganHangTracNghiem.Controllers
{
    public class pro_Get_Subject_QuestionController : ApiController
    {
        ObjectiveTestEntities db = new ObjectiveTestEntities();
        public IHttpActionResult Getpro_Get_Subject_Question(int id)
        {
            try
            {
                var result = db.pro_Get_Subject_Question1(id);
                if(result!=null)
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