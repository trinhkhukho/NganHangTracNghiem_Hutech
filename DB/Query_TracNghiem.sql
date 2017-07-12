alter table Questions
add  UserId int default null foreign key references Users(Id)
--thống kê số lượng môn, chương phần theo khoa.
if exists(select name from sysobjects where name ='pro_Subject_FacultyId')
	drop procedure pro_Subject_FacultyId
go
create procedure pro_Subject_FacultyId
as
begin
	select f.Id,f.Name,f.Comment,f.Deleted,count(s.FacultyId) as NumberOfSubject,count(c.SubjectId) as NumberOfSubjectChapter
	from Faculties f left join Subjects s on f.Id=s.FacultyId left join Chapters c on s.Id=c.SubjectId
	group by f.Id,f.Name,f.Comment,f.Deleted
end
go
--Thống kê số lượng câu hỏi theo môn chương phần.
if exists(select name from sysobjects where name ='pro_Subject_FacultyId_Question')
	drop procedure pro_Subject_FacultyId_Question
go
create procedure pro_Subject_FacultyId_Question
as
begin
	select f.Id,f.Name,f.Comment,f.Deleted,count(s.FacultyId) as NumberOfSubject,count(c.SubjectId) as NumberOfSubjectChapter,count(q.Id) as NumberOfQuestion
	from Faculties f left join Subjects s on f.Id=s.FacultyId left join Chapters c on s.Id=c.SubjectId left join Questions q on c.Id=q.ChapterId
	group by f.Id,f.Name,f.Comment,f.Deleted
end
go
--thống kê số lương câu hỏi theo từng khoa.
if exists(select name from sysobjects where name ='pro_Get_Faculty_Question')
	drop procedure pro_Get_Faculty_Question
go
create procedure pro_Get_Faculty_Question
(
	@Id int
)
as
begin
	select a.Id,a.Name,a.Code,a.Deleted,count(a.NumberOfSubjectChapter) as NumberOfSubjectChapter,count(q.ChapterId) as NumberOfQuestion from
	(
		select s.Id,s.Name,s.Code,s.Deleted,c.Id as Ids,count(c.Id) as NumberOfSubjectChapter
		from Chapters c  right join Subjects s  on s.Id=c.SubjectId 
		where s.FacultyId=@Id
		group by s.Id,s.Name,s.Code,s.Deleted,c.SubjectId,c.Id
	) as a left join  Questions q on a.Ids=q.ChapterId
	group by a.Id,a.Name,a.Code,a.Deleted,a.NumberOfSubjectChapter
end
go
--thống kê số lượng câu hỏi theo từng môn.
if exists(select name from sysobjects where name ='pro_Get_Subject_Question')
	drop procedure pro_Get_Subject_Question
go
create procedure pro_Get_Subject_Question
(
	@Id int
)
as
begin
	select c.Id,c.Content,c.Name,c.ManagementOrder,count(q.Id) as NumberOfQuestion
	from Chapters c  left join Questions q on c.Id=q.ChapterId
	where c.SubjectId=@Id
	group by c.Id,c.Content,c.Name,c.ManagementOrder
end
go
--thống kê số lượng câu hỏi theo từng phần.
if exists(select name from sysobjects where name ='pro_Get_Chapters_Question')
	drop procedure pro_Get_Chapters_Question
go
create procedure pro_Get_Chapters_Question
(
	@Id int
)
as
begin
	select c.Id,c.Content,c.Deleted,c.ManagementOrder,c.Name,c.ParentId,c.SubjectId,count(s.ChapterId)as NumberOfQuestion
	from Chapters c left join Questions s on c.Id=s.ChapterId
	where c.Id=@Id
	group by c.Id,c.Content,c.Deleted,c.ManagementOrder,c.Name,c.ParentId,c.SubjectId
end
go
--sua lai table UserRoles.
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Roles' and b.name ='Deleted')
	alter table Roles add Deleted Bit  default 0
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Roles' and b.name ='FacultiesId')
	alter table Roles add FacultiesId int  foreign key references Faculties(Id)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Roles' and b.name ='SubjectsId')
	alter table Roles add SubjectsId int  foreign key references Subjects(Id)
go
if not exists(select b.name from sys.objects a inner join sys.columns b on a.object_id=b.object_id where a.name ='Roles' and b.name ='ChaptersId')
	alter table Roles add ChaptersId int  foreign key references Chapters(Id)
go

if exists(select name from sysobjects where name ='pro_search_Question')
	drop procedure pro_search_Question
go
create proc pro_search_Question(
	@FacultiesId int,
	@SubjectId int,
	@ChapterId int,
	@StarDate Date,
	@EndDate Date
)
as
begin
	if(@FacultiesId!=0 and @SubjectId!=0 and @ChapterId!=0)
	begin
		select q.Id,q.ChapterId,q.CreateDate,q.Deleted,q.Discrimination,q.Interchange,q.Mark,q.ObjectiveDifficulty,q.ParentId,q.UserId 
		from Questions q,Chapters c, Subjects s, Faculties f
		where f.Id=s.FacultyId and s.Id=c.SubjectId and c.Id=q.ChapterId 
		and q.ChapterId=@ChapterId and c.SubjectId=@SubjectId and s.FacultyId=@FacultiesId 
		and convert(date,q.CreateDate,103) between convert(date,@StarDate,103) and convert(date,@EndDate,103)
	end
	else
	begin
		if(@FacultiesId!=0 and @SubjectId!=0 and @ChapterId=0)
		begin
			select q.Id,q.ChapterId,q.CreateDate,q.Deleted,q.Discrimination,q.Interchange,q.Mark,q.ObjectiveDifficulty,q.ParentId,q.UserId 
			from Questions q,Chapters c, Subjects s, Faculties f
			where f.Id=s.FacultyId and s.Id=c.SubjectId and c.Id=q.ChapterId 
			and s.FacultyId=@FacultiesId and c.SubjectId=@SubjectId
			and convert(date,q.CreateDate,103) between convert(date,@StarDate,103) and convert(date,@EndDate,103)
		end
		else
		begin
			if(@FacultiesId!=0 and @SubjectId=0 and @ChapterId=0)
			begin
				select q.Id,q.ChapterId,q.CreateDate,q.Deleted,q.Discrimination,q.Interchange,q.Mark,q.ObjectiveDifficulty,q.ParentId,q.UserId 
				from Questions q,Chapters c, Subjects s, Faculties f
				where f.Id=s.FacultyId and s.Id=c.SubjectId and c.Id=q.ChapterId 
				and s.FacultyId=@FacultiesId
				and convert(date,q.CreateDate,103) between convert(date,@StarDate,103) and convert(date,@EndDate,103)
			end
			else
			begin
				select q.Id,q.ChapterId,q.CreateDate,q.Deleted,q.Discrimination,q.Interchange,q.Mark,q.ObjectiveDifficulty,q.ParentId,q.UserId 
				from Questions q,Chapters c, Subjects s, Faculties f
				where f.Id=s.FacultyId and s.Id=c.SubjectId and c.Id=q.ChapterId 
				and convert(date,q.CreateDate,103) between convert(date,@StarDate,103) and convert(date,@EndDate,103)
			end
		end
	end
end

exec pro_search_Question 158,0,0,'07/06/2017','07/06/2017'