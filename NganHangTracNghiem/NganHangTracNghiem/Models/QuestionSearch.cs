using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NganHangTracNghiem.Models
{
    public class QuestionSearch
    {
        public int chapterId { get; set; }
        public int subjectId { get; set; }
        public int facultiesId { get; set; }
        public DateTime starDate { get; set; }
        public DateTime endDate { get; set; } 
    }
}