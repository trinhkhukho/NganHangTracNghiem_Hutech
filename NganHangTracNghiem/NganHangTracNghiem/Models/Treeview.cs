using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NganHangTracNghiem.Models
{
    public class Treeview
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Check { get; set; }
        public List<Nodes> child { get; set; }
    }
}