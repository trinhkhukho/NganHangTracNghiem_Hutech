using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Web;

namespace NganHangTracNghiem.Data
{
    public class ModelQuestionsDelete
    {
        public long IdQuestion { get; set; }
        public long IdAnswerA { get; set; }
        public long IdAnswerB { get; set; }
        public long IdAnswerC { get; set; }
        public long IdAnswerD { get; set; }
        

    }
}