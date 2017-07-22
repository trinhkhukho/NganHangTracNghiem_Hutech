using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NganHangTracNghiem.Data
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<bool> LogOut { get; set; }
        public Nullable<System.DateTime> LastActivity { get; set; }
        public Nullable<System.DateTime> LastLogIn { get; set; }
        public Nullable<System.DateTime> LastPasswordChanged { get; set; }
        public Nullable<System.DateTime> LastLogOut { get; set; }
        public string Salt { get; set; }
        public string Comment { get; set; }
        public Nullable<bool> BuildInUser { get; set; }
    }
}
