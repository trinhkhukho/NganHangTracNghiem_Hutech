using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHangTracNghiem.Data
{
    public class ListQuestion
    {
        public List<Question_Detail> Question_Success { get; set; }
        public List<Question_Detail> Question_Error { get; set; }
    }
}
