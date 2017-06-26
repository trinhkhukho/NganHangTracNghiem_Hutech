using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;

namespace NganHangTracNghiem.Data
{
    public class ModelQuestionsEdit
    {
        public long IdQuestion { get; set; }
        public long IdAnswerA { get; set; }
        public long IdAnswerB { get; set; }
        public long IdAnswerC { get; set; }
        public long IdAnswerD { get; set; }
        public string DeBai { get; set; }
        public string CauA { get; set; }
        public string CauB { get; set; }
        public string CauC { get; set; }
        public string CauD { get; set; }
        public bool HoanViA { get; set; }
        public bool HoanViB { get; set; }
        public bool HoanViC { get; set; }
        public bool HoanViD { get; set; }
        public decimal? Diem { get; set; }
        public decimal? DoPhanCach { get; set; }
        public decimal? DoKho { get; set; }
        public bool DapAnA { get; set; }
        public bool DapAnB { get; set; }
        public bool DapAnC { get; set; }
        public bool DapAnD { get; set; }

    }
}