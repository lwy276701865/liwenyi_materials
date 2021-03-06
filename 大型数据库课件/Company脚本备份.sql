USE [Company_Gushuangquan]
GO
/****** Object:  Table [dbo].[Employee]    Script Date: 12/23/2017 21:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Employee](
	[FNAME] [char](10) NULL,
	[MINIT] [char](10) NULL,
	[LNAME] [char](10) NULL,
	[SSN] [varchar](50) NOT NULL,
	[BDATE] [datetime] NULL,
	[ADDRESS] [varchar](50) NULL,
	[SEX] [char](10) NULL,
	[SALARY] [int] NULL,
	[SUPERSSN] [varchar](50) NULL,
	[DNO] [int] NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[SSN] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Employee] ([FNAME], [MINIT], [LNAME], [SSN], [BDATE], [ADDRESS], [SEX], [SALARY], [SUPERSSN], [DNO]) VALUES (N'John      ', N'B         ', N'Smith     ', N'123456789', CAST(0x00005CC500000000 AS DateTime), N'731 Fondren, Houston,TX', N'M         ', 30000, N'333445555', 5)
INSERT [dbo].[Employee] ([FNAME], [MINIT], [LNAME], [SSN], [BDATE], [ADDRESS], [SEX], [SALARY], [SUPERSSN], [DNO]) VALUES (N'Franklin  ', N'T         ', N'Wong      ', N'333445555', CAST(0x00004FCD00000000 AS DateTime), N'638 Voss, Houston,TX', N'M         ', 40000, N'888665555', 5)
INSERT [dbo].[Employee] ([FNAME], [MINIT], [LNAME], [SSN], [BDATE], [ADDRESS], [SEX], [SALARY], [SUPERSSN], [DNO]) VALUES (N'Joyce     ', N'A         ', N'English   ', N'453453453', CAST(0x0000678D00000000 AS DateTime), N'5631 Rice, Houston, TX', N'F         ', 25000, N'333445555', 5)
INSERT [dbo].[Employee] ([FNAME], [MINIT], [LNAME], [SSN], [BDATE], [ADDRESS], [SEX], [SALARY], [SUPERSSN], [DNO]) VALUES (N'Ramesh    ', N'K         ', N'Narayan   ', N'666884444', CAST(0x0000597600000000 AS DateTime), N'975 Fire Oak, Humble, TX', N'M         ', 38000, N'333445555', 5)
INSERT [dbo].[Employee] ([FNAME], [MINIT], [LNAME], [SSN], [BDATE], [ADDRESS], [SEX], [SALARY], [SUPERSSN], [DNO]) VALUES (N'James     ', N'E         ', N'Borg      ', N'888665555', CAST(0x0000360300000000 AS DateTime), N'450 Stone, Houston, TX', N'M         ', 55000, NULL, 1)
INSERT [dbo].[Employee] ([FNAME], [MINIT], [LNAME], [SSN], [BDATE], [ADDRESS], [SEX], [SALARY], [SUPERSSN], [DNO]) VALUES (N'Jennifer  ', N'S         ', N'Wallace   ', N'987654321', CAST(0x00003B2900000000 AS DateTime), N'291 Berry, Bellaire, TX', N'F         ', 43000, N'888665555', 4)
INSERT [dbo].[Employee] ([FNAME], [MINIT], [LNAME], [SSN], [BDATE], [ADDRESS], [SEX], [SALARY], [SUPERSSN], [DNO]) VALUES (N'Ahmad     ', N'V         ', N'Jabbar    ', N'987987987', CAST(0x000062C900000000 AS DateTime), N'980 Dallas, Houston, TX', N'M         ', 25000, N'987654321', 4)
INSERT [dbo].[Employee] ([FNAME], [MINIT], [LNAME], [SSN], [BDATE], [ADDRESS], [SEX], [SALARY], [SUPERSSN], [DNO]) VALUES (N'Alicia    ', N'J         ', N'Zelaya    ', N'999887777', CAST(0x000061CC00000000 AS DateTime), N'3321 Castle, Spring, TX', N'F         ', 25000, N'987654321', 4)
/****** Object:  Table [dbo].[Dept_locations]    Script Date: 12/23/2017 21:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dept_locations](
	[DNUMBER] [int] NOT NULL,
	[DLOCATION] [char](10) NOT NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Dept_locations] ([DNUMBER], [DLOCATION]) VALUES (1, N'Houston   ')
INSERT [dbo].[Dept_locations] ([DNUMBER], [DLOCATION]) VALUES (4, N'Stafford  ')
INSERT [dbo].[Dept_locations] ([DNUMBER], [DLOCATION]) VALUES (5, N'Bellaire  ')
INSERT [dbo].[Dept_locations] ([DNUMBER], [DLOCATION]) VALUES (5, N'Houston   ')
INSERT [dbo].[Dept_locations] ([DNUMBER], [DLOCATION]) VALUES (5, N'Sugarland ')
/****** Object:  Table [dbo].[Dependent]    Script Date: 12/23/2017 21:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dependent](
	[ESSN] [varchar](50) NOT NULL,
	[DEPENDENT_NAME] [char](10) NOT NULL,
	[SEX] [char](10) NULL,
	[BDATE] [datetime] NULL,
	[RELATIONSHIP] [char](10) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Dependent] ([ESSN], [DEPENDENT_NAME], [SEX], [BDATE], [RELATIONSHIP]) VALUES (N'123456789', N'Alice     ', N'F         ', CAST(0x00007EF900000000 AS DateTime), N'Daughter  ')
INSERT [dbo].[Dependent] ([ESSN], [DEPENDENT_NAME], [SEX], [BDATE], [RELATIONSHIP]) VALUES (N'123456789', N'Elizabeth ', N'F         ', CAST(0x0000601300000000 AS DateTime), N'Spouse    ')
INSERT [dbo].[Dependent] ([ESSN], [DEPENDENT_NAME], [SEX], [BDATE], [RELATIONSHIP]) VALUES (N'123456789', N'Michael   ', N'M         ', CAST(0x00007D9000000000 AS DateTime), N'Son       ')
INSERT [dbo].[Dependent] ([ESSN], [DEPENDENT_NAME], [SEX], [BDATE], [RELATIONSHIP]) VALUES (N'333445555', N'Alice     ', N'F         ', CAST(0x00007B1100000000 AS DateTime), N'Daughter  ')
INSERT [dbo].[Dependent] ([ESSN], [DEPENDENT_NAME], [SEX], [BDATE], [RELATIONSHIP]) VALUES (N'333445555', N'Joy       ', N'F         ', CAST(0x0000533A00000000 AS DateTime), N'Spouse    ')
INSERT [dbo].[Dependent] ([ESSN], [DEPENDENT_NAME], [SEX], [BDATE], [RELATIONSHIP]) VALUES (N'333445555', N'Theodore  ', N'M         ', CAST(0x0000779400000000 AS DateTime), N'Son       ')
INSERT [dbo].[Dependent] ([ESSN], [DEPENDENT_NAME], [SEX], [BDATE], [RELATIONSHIP]) VALUES (N'987654321', N'Abner     ', N'M         ', CAST(0x00003C2600000000 AS DateTime), N'Spouse    ')
/****** Object:  Table [dbo].[Department]    Script Date: 12/23/2017 21:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Department](
	[DNAME] [char](20) NULL,
	[DNUMBER] [int] NOT NULL,
	[MGRSSN] [varchar](50) NULL,
	[MGRSTARTDATE] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Department] ([DNAME], [DNUMBER], [MGRSSN], [MGRSTARTDATE]) VALUES (N'Headquarters        ', 1, N'888665555', CAST(0x0000743A00000000 AS DateTime))
INSERT [dbo].[Department] ([DNAME], [DNUMBER], [MGRSSN], [MGRSTARTDATE]) VALUES (N'Administration      ', 4, N'987654321', CAST(0x0000878A00000000 AS DateTime))
INSERT [dbo].[Department] ([DNAME], [DNUMBER], [MGRSSN], [MGRSTARTDATE]) VALUES (N'Research            ', 5, N'333445555', CAST(0x00007E1B00000000 AS DateTime))
/****** Object:  Table [dbo].[WORKS_ON]    Script Date: 12/23/2017 21:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[WORKS_ON](
	[ESSN] [varchar](50) NOT NULL,
	[PNO] [int] NOT NULL,
	[HOURS] [numeric](18, 1) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'123456789', 1, CAST(32.5 AS Numeric(18, 1)))
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'123456789', 2, CAST(7.5 AS Numeric(18, 1)))
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'333445555', 2, CAST(10.0 AS Numeric(18, 1)))
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'333445555', 3, CAST(10.0 AS Numeric(18, 1)))
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'333445555', 10, CAST(10.0 AS Numeric(18, 1)))
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'333445555', 20, CAST(10.0 AS Numeric(18, 1)))
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'453453453', 1, CAST(20.0 AS Numeric(18, 1)))
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'453453453', 2, CAST(20.0 AS Numeric(18, 1)))
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'666884444', 3, CAST(40.0 AS Numeric(18, 1)))
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'888665555', 20, NULL)
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'987654321', 20, CAST(15.0 AS Numeric(18, 1)))
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'987654321', 30, CAST(20.0 AS Numeric(18, 1)))
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'987987987', 10, CAST(35.0 AS Numeric(18, 1)))
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'987987987', 30, CAST(5.0 AS Numeric(18, 1)))
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'999887777', 10, CAST(10.0 AS Numeric(18, 1)))
INSERT [dbo].[WORKS_ON] ([ESSN], [PNO], [HOURS]) VALUES (N'999887777', 30, CAST(30.0 AS Numeric(18, 1)))
/****** Object:  Table [dbo].[Project]    Script Date: 12/23/2017 21:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Project](
	[PNAME] [nvarchar](50) NULL,
	[PNUMBER] [int] NOT NULL,
	[PLOCATION] [char](20) NULL,
	[DNUM] [int] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[Project] ([PNAME], [PNUMBER], [PLOCATION], [DNUM]) VALUES (N'ProductX  ', 1, N'Bellaire            ', 5)
INSERT [dbo].[Project] ([PNAME], [PNUMBER], [PLOCATION], [DNUM]) VALUES (N'ProductY  ', 2, N'Sugarland           ', 5)
INSERT [dbo].[Project] ([PNAME], [PNUMBER], [PLOCATION], [DNUM]) VALUES (N'ProductZ  ', 3, N'Houston             ', 5)
INSERT [dbo].[Project] ([PNAME], [PNUMBER], [PLOCATION], [DNUM]) VALUES (N'Computerization', 10, N'Stafford            ', 4)
INSERT [dbo].[Project] ([PNAME], [PNUMBER], [PLOCATION], [DNUM]) VALUES (N'Reorganization', 20, N'Houston             ', 1)
INSERT [dbo].[Project] ([PNAME], [PNUMBER], [PLOCATION], [DNUM]) VALUES (N'Newbenefits', 30, N'Stafford            ', 4)
/****** Object:  UserDefinedFunction [dbo].[F1_查询部门员工信息_X]    Script Date: 12/23/2017 21:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[F1_查询部门员工信息_X](@Dname nvarchar(50))
RETURNS TABLE
AS
	RETURN(
	SELECT LNAME as 姓,FNAME as 名,SEX as 性别,SSN,datediff(year,BDATE,GetDate()) as 年龄 
	FROM Employee e,Department d
	WHERE e.DNO = d.DNUMBER
	 AND d.DNAME = @Dname
	)
GO
/****** Object:  UserDefinedFunction [dbo].[F1_查询部门员工信息]    Script Date: 12/23/2017 21:01:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[F1_查询部门员工信息](@Dname nvarchar(50))
RETURNS @DEinf TABLE
(
	名 char(10),
	工资 float,
	年龄 int
)
AS
BEGIN
	INSERT @DEinf
	SELECT Upper(FNAME),SALARY,datediff(year,BDATE,GetDate()) 
	FROM Employee e,Department d
	WHERE e.DNO = d.DNUMBER
	 AND d.DNAME = @Dname
	RETURN
END
GO
/****** Object:  ForeignKey [FK_Employee_Employee]    Script Date: 12/23/2017 21:01:29 ******/
ALTER TABLE [dbo].[Employee]  WITH NOCHECK ADD  CONSTRAINT [FK_Employee_Employee] FOREIGN KEY([SUPERSSN])
REFERENCES [dbo].[Employee] ([SSN])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Employee]
GO
