using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHangTracNghiem.Data
{
    public class Chapters
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Conten { get; set; }
        public int Order { get; set; }
        public int ParentId { get; set; }
        public bool Deleted { get; set; }
        public int SubjectId { get; set; }
        public int ManagementOrder {get;set;}
    }
}
