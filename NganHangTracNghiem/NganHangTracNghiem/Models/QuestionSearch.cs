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
        public DateTime StarDate { get; set; }
        public DateTime EndDate { get; set; }
        public int userId { get; set; }
    }
}