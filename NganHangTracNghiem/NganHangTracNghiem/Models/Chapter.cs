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
    using System.Collections.Generic;
    
    public partial class Chapter
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chapter()
        {
            this.Questions = new HashSet<Question>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public Nullable<int> Order { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<bool> Deleted { get; set; }
        public Nullable<int> SubjectId { get; set; }
        public Nullable<int> ManagementOrder { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Question> Questions { get; set; }
        public virtual Subject Subject { get; set; }
    }
}
