using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NganHangTracNghiem.Models
{
    public class SubjectDecen
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public int FacultyId { get; set; }
        public int ManagementOrder { get; set; }
        public bool check { get; set; }
    }
}