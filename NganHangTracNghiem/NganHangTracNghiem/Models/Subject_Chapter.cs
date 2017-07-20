using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NganHangTracNghiem.Models
{
    public class Subject_Chapter
    {
        public SubjectDecen subject { get; set;}
        public List<ChaptersDecen> chapter { get; set; }
    }
}