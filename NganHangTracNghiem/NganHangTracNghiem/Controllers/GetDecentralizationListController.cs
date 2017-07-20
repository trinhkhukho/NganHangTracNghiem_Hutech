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
                List<Treeview> tree = new List<Treeview>();
                db.Configuration.ProxyCreationEnabled = false;
                List<Faculty> lsFuculty = db.Faculties.ToList();
                foreach (var f in lsFuculty)
                {
                    Treeview tr = new Treeview();
                    List<Nodes> nodes = new List<Nodes>();
                    Nodes nd = new Nodes();
                    var lsS = db.Subjects.Where(n => n.FacultyId == f.Id);
                    foreach (var s in lsS)
                    {
                        
                        nd.Id = Convert.ToInt32(s.Id);
                        nd.Name = s.Name;
                        nd.Check = false;
                        List<Node> node = new List<Node>();
                        List<Chapter> ct = db.Chapters.Where(n => n.SubjectId == s.Id).ToList();
                        foreach (var c in ct)
                        {
                            Node n = new Node();
                            n.Id = c.Id;
                            n.Check = false;
                            n.Name = c.Name;
                            node.Add(n);
                        }
                        nd.child = node;
                    }
                    nodes.Add(nd);
                    tr.Id = Convert.ToInt32(f.Id);
                    tr.Name = f.Name;
                    tr.Check = false;
                    tr.child = nodes;
                    tree.Add(tr); 
                }
                
                if (tree.Count > 0 && tree != null)
                {
                    return Ok(tree);
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
