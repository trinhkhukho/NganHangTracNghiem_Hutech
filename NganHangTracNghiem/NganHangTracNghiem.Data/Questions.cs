using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHangTracNghiem.Data
{
    public class Questions
    {
        public long Id { get; set; }
        public string Content { get; set; }
        public Nullable<bool> Interchange { get; set; }
        public Nullable<decimal> SubjectiveDifficulty { get; set; }
        public Nullable<int> SelectedTimes { get; set; }
        public Nullable<int> CorrectTimes { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public int ChapterId { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
        public Nullable<decimal> Mark { get; set; }
        public Nullable<int> Duration { get; set; }
        public Nullable<long> ParentId { get; set; }
        public Nullable<bool> Audio { get; set; }
        public Nullable<decimal> Discrimination { get; set; }
        public Nullable<int> ManagementOrder { get; set; }
        public Nullable<int> SubjectId { get; set; }
        public Nullable<int> ListenedTimes { get; set; }
        public Nullable<decimal> ObjectiveDifficulty { get; set; }

    }
}
