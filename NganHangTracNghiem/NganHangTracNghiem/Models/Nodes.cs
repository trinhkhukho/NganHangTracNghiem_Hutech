using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NganHangTracNghiem.Models
{
    public class Nodes
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Check { get; set; } 
        public List<Node> child { get; set; }
    }
}