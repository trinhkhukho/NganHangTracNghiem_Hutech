using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHangTracNghiem.Data
{
    public class Answers
    {
        public long Id { get; set; }
        public Nullable<long> QuestionId { get; set; }
        public string Content { get; set; }
        public Nullable<int> Order { get; set; }
        public Nullable<bool> Correct { get; set; }
        public Nullable<bool> Interchange { get; set; }

    }
}
