using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NganHangTracNghiem.Models;

namespace NganHangTracNghiem.Controllers
{
    public class GetDecentralizationListController : ApiController
    {
        ObjectiveTestEntities db = new ObjectiveTestEntities();
        //public IHttpActionResult Get()
        //{
        //    try
        //    {
        //        db.Configuration.ProxyCreationEnabled = false;
        //        var lsFS = new List<Fuculties_Subject>();
        //        List<Faculty> lsFuculty = db.Faculties.ToList();
        //        foreach (var f in lsFuculty)
        //        {
        //            Fuculties_Subject fs = new Fuculties_Subject();
        //            var lsS = db.Subjects.Where(n => n.FacultyId == f.Id);
        //            List<Subject_Chapter> lsSC = new List<Subject_Chapter>();
        //            foreach (var s in lsS)
        //            {
        //                Subject_Chapter sc = new Subject_Chapter();
        //                sc.subject.ID = s.Id;
        //                sc.subject.Name = s.Name;
        //                sc.subject.Deleted =Convert.ToBoolean(s.Deleted);
        //                sc.subject.Code= s.Code;
        //                sc.subject.FacultyId = Convert.ToInt32(s.FacultyId);
        //                sc.subject.check = false;
                        
        //                List<ChaptersDecen> cd = new List<ChaptersDecen>();
        //                List<Chapter> ct= db.Chapters.Where(n => n.SubjectId == s.Id).ToList();
        //                foreach(var c in ct)
        //                {
        //                    ChaptersDecen cds = new ChaptersDecen();
        //                    cds.chapter = c;
        //                    cds.check = false;
        //                    cd.Add(cds);
        //                }
        //                sc.chapter = cd;
        //                sc.check = false;
        //                lsSC.Add(sc);
        //            }
        //            fs.fucalties = f;
        //            fs.subject_chapter = lsSC;
        //            fs.check = false;
        //            lsFS.Add(fs);
        //        }
        //        ListDecentralization lsD = new ListDecentralization();
        //        lsD.ListFuculties = lsFS;
        //        if (lsFS.Count>0&& lsFS!=null)
        //        {
        //            return Ok(lsD);
        //        }
        //        else
        //        {
        //            return InternalServerError();
        //        }
        //    }
        //    catch
        //    {
        //        return InternalServerError();
        //    }
        //}
    //}
}
