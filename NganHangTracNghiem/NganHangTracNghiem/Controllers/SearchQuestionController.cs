using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NganHangTracNghiem.Models;
using System.Web.Http.Description;
using System.Data;

namespace NganHangTracNghiem.Controllers
{
    public class SearchQuestionController : ApiController
    {
        ObjectiveTestEntities db = new ObjectiveTestEntities();
        [HttpPost]
        [ResponseType(typeof(QuestionSearchResult))]
        public IHttpActionResult GetQuestions(QuestionSearch q)
        {
            db.Configuration.ProxyCreationEnabled = false;
            q.StarDate = Convert.ToDateTime(q.StarDate.ToString("dd/MM/yyyy"));
            q.EndDate = Convert.ToDateTime(q.EndDate.ToString("dd/MM/yyyy"));
            var result = db.pro_search_Question(q.facultiesId,q.subjectId,q.chapterId, q.StarDate, q.EndDate).ToList();
            if(result != null&& result.Count()>0)
            {
                List<QuestionSearchResult> lsResult = new List<QuestionSearchResult>();
                for (int i=0; i<result.Count(); i++)
                {
                    QuestionSearchResult qs = new QuestionSearchResult();
                    qs.Id = result[i].Id;
                    qs.ChapterId = result[i].ChapterId;
                    if(result[i].CreateDate!=null)
                    {
                        qs.CreateDate = Convert.ToDateTime(result[i].CreateDate.ToString());
                    }
                    qs.Deleted = result[i].Deleted;
                    if(result[i].Discrimination!=null)
                    {
                        qs.Discrimination = Convert.ToDecimal(result[i].Discrimination.ToString());
                    }
                    qs.Interchange = result[i].Interchange;
                    if(result[i].Mark.ToString()!=null)
                    {
                        qs.Mark = Convert.ToDecimal(result[i].Mark.ToString());
                    }
                    if(result[i].ObjectiveDifficulty!=null)
                    {
                        qs.ObjectiveDifficulty = Convert.ToDecimal(result[i].ObjectiveDifficulty.ToString());
                    }
                    if(result[i].ParentId!=null)
                    {
                        qs.ParentId = Convert.ToInt64(result[i].ParentId);
                    }
                    if(result[i].UserId!=null)
                    {
                        qs.UserId = Convert.ToInt32(result[i].UserId);
                    }
                    
                    lsResult.Add(qs);
                }
                return Ok(result);
            }
            else
            {
                return InternalServerError();
            }
        }
    }
}
