//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NganHangTracNghiem.Models
{
    using System;
    
    public partial class pro_GetUser_byUserName_Result
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
