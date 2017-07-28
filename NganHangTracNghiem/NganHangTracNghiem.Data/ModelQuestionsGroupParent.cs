using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;

namespace NganHangTracNghiem.Data
{
    public class ModelQuestionsGroupParent
    {
        public string DeBai { get; set; }
        public decimal? Diem { get; set; }
        public decimal? DoPhanCach { get; set; }
        public decimal? DoKho { get; set; }
        public int ChapterId { get; set; }
        public int UserId { get; set; }


    }
}