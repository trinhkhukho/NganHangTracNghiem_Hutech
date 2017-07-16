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
        public IHttpActionResult Get()
        {
            try
            {
                db.Configuration.ProxyCreationEnabled = false;
                var lsFS = new List<Fuculties_Subject>();
                List<Faculty> lsFuculty = db.Faculties.ToList();
                foreach (var f in lsFuculty)
                {
                    Fuculties_Subject fs = new Fuculties_Subject();
                    var lsS = db.Subjects.Where(n => n.FacultyId == f.Id);
                    List<Subject_Chapter> lsSC = new List<Subject_Chapter>();
                    foreach (var s in lsS)
                    {
                        Subject_Chapter sc = new Subject_Chapter();
                        SubjectDecen subde = new SubjectDecen();
                        subde.ID = Convert.ToInt32(s.Id);
                        subde.Name = s.Name;
                        subde.Deleted = Convert.ToBoolean(s.Deleted);
                        subde.Code = s.Code;
                        subde.FacultyId = Convert.ToInt32(s.FacultyId);
                        subde.check = false;
                        subde.ManagementOrder = Convert.ToInt32(s.ManagementOrder);
                        sc.subject = subde;
                        List<ChaptersDecen> cd = new List<ChaptersDecen>();
                        List<Chapter> ct = db.Chapters.Where(n => n.SubjectId == s.Id).ToList();
                        foreach (var c in ct)
                        {
                            ChaptersDecen cds = new ChaptersDecen();
                            cds.ID = c.Id;
                            cds.check = false;
                            cds.Name = c.Name;
                            cds.Order = Convert.ToInt32(c.Order);
                            cds.Conten = c.Content;
                            cds.ParentId = Convert.ToInt32(c.ParentId);
                            cds.Deleted = Convert.ToBoolean(c.Deleted);
                            cds.SubjectId = Convert.ToInt32(c.SubjectId);
                            cds.ManagementOrder = Convert.ToInt32(c.ManagementOrder);
                            cd.Add(cds);
                        }
                        sc.chapter = cd;
                        lsSC.Add(sc);
                    }
                    FucultiesDecen fude = new FucultiesDecen();
                    fude.ID = f.Id;
                    fude.Name = f.Name;
                    fude.Deleted = Convert.ToBoolean(f.Deleted);
                    fude.Comment = f.Comment;
                    fude.check = false;
                    fs.fucalties = fude;
                    fs.subject_chapter = lsSC;
                    lsFS.Add(fs);
                }
                ListDecentralization lsD = new ListDecentralization();
                lsD.ListFuculties = lsFS;
                if (lsFS.Count > 0 && lsFS != null)
                {
                    return Ok(lsD);
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
