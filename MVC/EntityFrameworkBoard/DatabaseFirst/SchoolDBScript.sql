
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[GetCoursesByStudentId]
	-- Add the parameters for the stored procedure here
	@StudentId int = null
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
select c.courseid, c.coursename,c.Location, c.TeacherId
from student s left outer join studentcourse sc on sc.studentid = s.studentid left outer join course c on c.courseid = sc.courseid
where s.studentid = @StudentId
END


GO
/****** Object:  StoredProcedure [dbo].[sp_DeleteStudent]    Script Date: 05-12-2014 11:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_DeleteStudent]
	-- Add the parameters for the stored procedure here
	@StudentId int
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    DELETE FROM [dbo].[Student]
	where StudentID = @StudentId

END

Go
CREATE PROCEDURE [dbo].[GetCourses]
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
select CourseID,CourseName,Location,TeacherId
from Course 

END


GO
/****** Object:  StoredProcedure [dbo].[sp_InsertStudentInfo]    Script Date: 05-12-2014 11:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_InsertStudentInfo]
	-- Add the parameters for the stored procedure here
	@StandardId int = null,
	@StudentName varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

     INSERT INTO [SchoolDB].[dbo].[Student]
           ([StudentName]
           ,[StandardId])
     VALUES
           (
           @StudentName,
@StandardId
)
SELECT SCOPE_IDENTITY() AS StudentId

END


GO
/****** Object:  StoredProcedure [dbo].[sp_UpdateStudent]    Script Date: 05-12-2014 11:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[sp_UpdateStudent]
	-- Add the parameters for the stored procedure here
	@StudentId int,
	@StandardId int = null,
	@StudentName varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    Update [SchoolDB].[dbo].[Student] 
	set StudentName = @StudentName,
	StandardId = @StandardId
	where StudentID = @StudentId;

END


GO
/****** Object:  Table [dbo].[Course]    Script Date: 05-12-2014 11:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Course](
	[CourseId] [int] IDENTITY(1,1) NOT NULL,
	[CourseName] [varchar](50) NULL,
	[Location] [geography] NULL,
	[TeacherId] [int] NULL,
 CONSTRAINT [PK_Course_1] PRIMARY KEY CLUSTERED 
(
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Standard]    Script Date: 05-12-2014 11:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Standard](
	[StandardId] [int] IDENTITY(1,1) NOT NULL,
	[StandardName] [varchar](50) NULL,
	[Description] [varchar](50) NULL,
 CONSTRAINT [PK_Standard] PRIMARY KEY CLUSTERED 
(
	[StandardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Student]    Script Date: 05-12-2014 11:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Student](
	[StudentID] [int] IDENTITY(1,1) NOT NULL,
	[StudentName] [varchar](50) NULL,
	[StandardId] [int] NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentAddress]    Script Date: 05-12-2014 11:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StudentAddress](
	[StudentID] [int] NOT NULL,
	[Address1] [varchar](50) NOT NULL,
	[Address2] [varchar](50) NULL,
	[City] [varchar](50) NOT NULL,
	[State] [varchar](50) NOT NULL,
 CONSTRAINT [PK_StudentAddress] PRIMARY KEY CLUSTERED 
(
	[StudentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[StudentCourse]    Script Date: 05-12-2014 11:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StudentCourse](
	[StudentId] [int] NOT NULL,
	[CourseId] [int] NOT NULL,
 CONSTRAINT [PK_StudentCourse] PRIMARY KEY CLUSTERED 
(
	[StudentId] ASC,
	[CourseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Teacher]    Script Date: 05-12-2014 11:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Teacher](
	[TeacherId] [int] IDENTITY(1,1) NOT NULL,
	[TeacherName] [varchar](50) NULL,
	[StandardId] [int] NULL,
 CONSTRAINT [PK_Teacher_1] PRIMARY KEY CLUSTERED 
(
	[TeacherId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[View_StudentCourse]    Script Date: 05-12-2014 11:56:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[View_StudentCourse]
AS
SELECT     dbo.Student.StudentID, dbo.Student.StudentName, dbo.Course.CourseId, dbo.Course.CourseName
FROM         dbo.Student INNER JOIN
                      dbo.StudentCourse ON dbo.Student.StudentID = dbo.StudentCourse.StudentId INNER JOIN
                      dbo.Course ON dbo.StudentCourse.CourseId = dbo.Course.CourseId


GO
SET IDENTITY_INSERT [dbo].[Course] ON 

GO
INSERT [dbo].[Course] ([CourseId], [CourseName], [Location], [TeacherId]) VALUES (1, N'Maths', NULL, 1)
GO
INSERT [dbo].[Course] ([CourseId], [CourseName], [Location], [TeacherId]) VALUES (2, N'Science', NULL, 2)
GO
INSERT [dbo].[Course] ([CourseId], [CourseName], [Location], [TeacherId]) VALUES (3, N'History', NULL, 3)
GO
INSERT [dbo].[Course] ([CourseId], [CourseName], [Location], [TeacherId]) VALUES (4, N'English', NULL, 4)
GO
INSERT [dbo].[Course] ([CourseId], [CourseName], [Location], [TeacherId]) VALUES (5, N'Spanish', NULL, 5)
GO
SET IDENTITY_INSERT [dbo].[Course] OFF
GO
SET IDENTITY_INSERT [dbo].[Standard] ON 

GO
INSERT [dbo].[Standard] ([StandardId], [StandardName], [Description]) VALUES (1, N'Standard1', N'Standard 1\Grade1')
GO
INSERT [dbo].[Standard] ([StandardId], [StandardName], [Description]) VALUES (2, N'Standard2', NULL)
GO
INSERT [dbo].[Standard] ([StandardId], [StandardName], [Description]) VALUES (3, N'Standard3', NULL)
GO
INSERT [dbo].[Standard] ([StandardId], [StandardName], [Description]) VALUES (4, N'Standard4', NULL)
GO
INSERT [dbo].[Standard] ([StandardId], [StandardName], [Description]) VALUES (5, N'Standard5', NULL)
GO
SET IDENTITY_INSERT [dbo].[Standard] OFF
GO
SET IDENTITY_INSERT [dbo].[Student] ON 

GO
INSERT [dbo].[Student] ([StudentID], [StudentName], [StandardId]) VALUES (1, N'Student1', NULL)
GO
INSERT [dbo].[Student] ([StudentID], [StudentName], [StandardId]) VALUES (2, N'Student2', NULL)
GO
INSERT [dbo].[Student] ([StudentID], [StudentName], [StandardId]) VALUES (3, N'Student3', NULL)
GO
INSERT [dbo].[Student] ([StudentID], [StudentName], [StandardId]) VALUES (4, N'Student4', NULL)
GO
INSERT [dbo].[Student] ([StudentID], [StudentName], [StandardId]) VALUES (5, N'Student5', NULL)
GO
INSERT [dbo].[Student] ([StudentID], [StudentName], [StandardId]) VALUES (6, N'Student6', NULL)
GO
INSERT [dbo].[Student] ([StudentID], [StudentName], [StandardId]) VALUES (7, N'Student7', NULL)
GO
INSERT [dbo].[Student] ([StudentID], [StudentName], [StandardId]) VALUES (8, N'Student8', NULL)
GO
INSERT [dbo].[Student] ([StudentID], [StudentName], [StandardId]) VALUES (9, N'Student9', NULL)
GO
INSERT [dbo].[Student] ([StudentID], [StudentName], [StandardId]) VALUES (10, N'Student10', NULL)
GO
SET IDENTITY_INSERT [dbo].[Student] OFF
GO
INSERT [dbo].[StudentAddress] ([StudentID], [Address1], [Address2], [City], [State]) VALUES (1, N'Student1Address1', N'Student1Address2', N'Student1City', N'Student1State')
GO
INSERT [dbo].[StudentAddress] ([StudentID], [Address1], [Address2], [City], [State]) VALUES (2, N'Student2Address1', N'Student2Address2', N'Student2City', N'Student2State')
GO
INSERT [dbo].[StudentAddress] ([StudentID], [Address1], [Address2], [City], [State]) VALUES (3, N'Student3Address1', N'Student3Address2', N'Student3City', N'Student3State')
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (1, 3)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (1, 4)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (1, 5)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (2, 3)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (2, 4)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (2, 5)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (3, 4)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (4, 1)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (4, 2)
GO
INSERT [dbo].[StudentCourse] ([StudentId], [CourseId]) VALUES (5, 4)
GO
SET IDENTITY_INSERT [dbo].[Teacher] ON 

GO
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [StandardId]) VALUES (2, N'Teacher2', 2)
GO
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [StandardId]) VALUES (3, N'Teacher3', 3)
GO
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [StandardId]) VALUES (4, N'Teacher4', 4)
GO
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [StandardId]) VALUES (5, N'Teacher5', 5)
GO
INSERT [dbo].[Teacher] ([TeacherId], [TeacherName], [StandardId]) VALUES (7, N'Teacher7', 1)
GO
SET IDENTITY_INSERT [dbo].[Teacher] OFF
GO
ALTER TABLE [dbo].[Teacher] ADD  CONSTRAINT [DF_Teacher_StandardId]  DEFAULT ((0)) FOR [StandardId]
GO
ALTER TABLE [dbo].[Course]  WITH NOCHECK ADD  CONSTRAINT [FK_Course_Teacher] FOREIGN KEY([TeacherId])
REFERENCES [dbo].[Teacher] ([TeacherId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Course] NOCHECK CONSTRAINT [FK_Course_Teacher]
GO
ALTER TABLE [dbo].[Student]  WITH NOCHECK ADD  CONSTRAINT [FK_Student_Standard] FOREIGN KEY([StandardId])
REFERENCES [dbo].[Standard] ([StandardId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Student] NOCHECK CONSTRAINT [FK_Student_Standard]
GO
ALTER TABLE [dbo].[StudentAddress]  WITH CHECK ADD  CONSTRAINT [FK_StudentAddress_Student] FOREIGN KEY([StudentID])
REFERENCES [dbo].[Student] ([StudentID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentAddress] CHECK CONSTRAINT [FK_StudentAddress_Student]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Course] FOREIGN KEY([CourseId])
REFERENCES [dbo].[Course] ([CourseId])
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Course]
GO
ALTER TABLE [dbo].[StudentCourse]  WITH CHECK ADD  CONSTRAINT [FK_StudentCourse_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([StudentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[StudentCourse] CHECK CONSTRAINT [FK_StudentCourse_Student]
GO
ALTER TABLE [dbo].[Teacher]  WITH CHECK ADD  CONSTRAINT [FK_Teacher_Standard] FOREIGN KEY([StandardId])
REFERENCES [dbo].[Standard] ([StandardId])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Teacher] CHECK CONSTRAINT [FK_Teacher_Standard]
GO
