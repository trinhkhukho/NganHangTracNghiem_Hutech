using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NganHangTracNghiem.Models
{
    public class QuestionSearchResult
    {
        public long Id { get; set; }
        public int ChapterId { get; set; }
        public DateTime CreateDate { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Decimal Discrimination { get; set; }
        public Nullable<bool> Interchange { get; set; }
        public Decimal Mark { get; set; }
        public Decimal ObjectiveDifficulty { get; set; }
        public long ParentId { get; set; }
        public int UserId { get; set; }

    }
}