using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHangTracNghiem.Data
{
    public class Subjects
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }
        public int FacultyId { get; set; }
        public int ManagementOrder { get; set; }
    }
}
