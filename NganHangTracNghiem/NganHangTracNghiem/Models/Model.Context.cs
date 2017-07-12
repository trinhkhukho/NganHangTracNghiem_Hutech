﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class ObjectiveTestEntities : DbContext
    {
        public ObjectiveTestEntities()
            : base("name=ObjectiveTestEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<Chapter> Chapters { get; set; }
        public virtual DbSet<Exam> Exams { get; set; }
        public virtual DbSet<Faculty> Faculties { get; set; }
        public virtual DbSet<Matrix> Matrices { get; set; }
        public virtual DbSet<MatrixDetail> MatrixDetails { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionSheetDetail> QuestionSheetDetails { get; set; }
        public virtual DbSet<QuestionSheet> QuestionSheets { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Shift> Shifts { get; set; }
        public virtual DbSet<ShiftSubject> ShiftSubjects { get; set; }
        public virtual DbSet<ShiftSubjectStudent> ShiftSubjectStudents { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
    
        public virtual ObjectResult<pro_Login_Result> pro_Login(string username, string password)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_Login_Result>("pro_Login", usernameParameter, passwordParameter);
        }
    
        public virtual ObjectResult<pro_GetUser_byUserName_Result> pro_GetUser_byUserName(string username)
        {
            var usernameParameter = username != null ?
                new ObjectParameter("Username", username) :
                new ObjectParameter("Username", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_GetUser_byUserName_Result>("pro_GetUser_byUserName", usernameParameter);
        }
    
        public virtual ObjectResult<pro_Get_Chapters_Question_Result> pro_Get_Chapters_Question(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_Get_Chapters_Question_Result>("pro_Get_Chapters_Question", idParameter);
        }
    
        public virtual ObjectResult<pro_Get_Faculty_Question_Result> pro_Get_Faculty_Question(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_Get_Faculty_Question_Result>("pro_Get_Faculty_Question", idParameter);
        }
    
        public virtual ObjectResult<pro_Get_Subject_Question_Result> pro_Get_Subject_Question(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_Get_Subject_Question_Result>("pro_Get_Subject_Question", idParameter);
        }
    
        public virtual ObjectResult<pro_Subject_FacultyId_Result> pro_Subject_FacultyId()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_Subject_FacultyId_Result>("pro_Subject_FacultyId");
        }
    
        public virtual ObjectResult<pro_Subject_FacultyId_Question_Result> pro_Subject_FacultyId_Question()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_Subject_FacultyId_Question_Result>("pro_Subject_FacultyId_Question");
        }
    
        public virtual ObjectResult<pro_Get_Faculty_Question1_Result> pro_Get_Faculty_Question1(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_Get_Faculty_Question1_Result>("pro_Get_Faculty_Question1", idParameter);
        }
    
        public virtual ObjectResult<pro_Get_Subject_Question1_Result> pro_Get_Subject_Question1(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_Get_Subject_Question1_Result>("pro_Get_Subject_Question1", idParameter);
        }
    
        public virtual ObjectResult<pro_Get_Faculty_Question2_Result> pro_Get_Faculty_Question2(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_Get_Faculty_Question2_Result>("pro_Get_Faculty_Question2", idParameter);
        }
    
        public virtual ObjectResult<pro_Get_Faculty_Question3_Result> pro_Get_Faculty_Question3(Nullable<int> id)
        {
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_Get_Faculty_Question3_Result>("pro_Get_Faculty_Question3", idParameter);
        }
    
        public virtual ObjectResult<pro_search_Question_Result> pro_search_Question(Nullable<int> facultiesId, Nullable<int> subjectId, Nullable<int> chapterId, Nullable<System.DateTime> starDate, Nullable<System.DateTime> endDate)
        {
            var facultiesIdParameter = facultiesId.HasValue ?
                new ObjectParameter("FacultiesId", facultiesId) :
                new ObjectParameter("FacultiesId", typeof(int));
    
            var subjectIdParameter = subjectId.HasValue ?
                new ObjectParameter("SubjectId", subjectId) :
                new ObjectParameter("SubjectId", typeof(int));
    
            var chapterIdParameter = chapterId.HasValue ?
                new ObjectParameter("ChapterId", chapterId) :
                new ObjectParameter("ChapterId", typeof(int));
    
            var starDateParameter = starDate.HasValue ?
                new ObjectParameter("StarDate", starDate) :
                new ObjectParameter("StarDate", typeof(System.DateTime));
    
            var endDateParameter = endDate.HasValue ?
                new ObjectParameter("EndDate", endDate) :
                new ObjectParameter("EndDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pro_search_Question_Result>("pro_search_Question", facultiesIdParameter, subjectIdParameter, chapterIdParameter, starDateParameter, endDateParameter);
        }
    }
}
