using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHangTracNghiem.Data
{
    public class Question_Detail
    {
        public Questions Question { get; set; }
        public List<Answers> Answer { get; set; }
        public int Erorr { get; set; }
        public int Group { get; set; }
        public int QuestionOfGroup { get; set; }
    }
}
