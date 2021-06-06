--创建教学管理数据库
CREATE DATABASE 教学管理
GO

--创建表
USE 教学管理
GO
IF EXISTS(SELECT * FROM sysobjects WHERE name='选课表' AND xtype='U') 
  DROP TABLE 选课表
IF EXISTS(SELECT * FROM sysobjects WHERE name='开课表' AND xtype='U') 
  DROP TABLE 开课表
IF EXISTS(SELECT * FROM sysobjects WHERE name='学生表' AND xtype='U') 
  DROP TABLE 学生表
IF EXISTS(SELECT * FROM sysobjects WHERE name='教师表' AND xtype='U') 
  DROP TABLE 教师表
IF EXISTS(SELECT * FROM sysobjects WHERE name='课程表' AND xtype='U') 
  DROP TABLE 课程表

CREATE TABLE 学生表
(
  学号 CHAR(7) NOT NULL,
  身份证号 CHAR(18) NOT NULL,
  姓名 CHAR(8) NOT NULL,
  性别 CHAR(2) DEFAULT '男',
  移动电话 CHAR(11),
  籍贯 VARCHAR(10),
  专业 VARCHAR(20) NOT NULL,
  所在院系 VARCHAR(20) NOT NULL,
  累计学分 INT,
  CONSTRAINT PK_学生表_学号 PRIMARY KEY(学号),
  CONSTRAINT CK_学生表_学号 CHECK(学号 LIKE 'S[0-9][0-9][0-9][0-9][0-9][0-9]')
)
CREATE TABLE 课程表
(
  课号 CHAR(6) NOT NULL,
  课名 VARCHAR(30) NOT NULL,
  学分 INT CHECK(学分>=1 and 学分<=5),
  教材名称 VARCHAR(30),
  编著者 CHAR(8),
  出版社 VARCHAR(20),
  版号 VARCHAR(20),
  定价 money,
  CONSTRAINT PK_课程表_课号 PRIMARY KEY(课号),
  CONSTRAINT CK_课程表_课号 CHECK(课号 LIKE 'C[0-9][0-9][0-9][0-9][0-9]')
)

CREATE TABLE 教师表
(
  工号 CHAR(6) NOT NULL,
  身份证号 CHAR(18) NOT NULL,
  姓名 CHAR(8) NOT NULL,
  性别 CHAR(2) DEFAULT '男',
  移动电话 CHAR(11),
  籍贯 VARCHAR(10),
  所在院系 VARCHAR(20) NOT NULL,
  职称 CHAR(6),
  负责人 CHAR(6),
  CONSTRAINT PK_教师表_工号 PRIMARY KEY(工号),
  CONSTRAINT CK_教师表_工号 CHECK(工号 LIKE 'T[0-9][0-9][0-9][0-9][0-9]')
)

CREATE TABLE 开课表
(
  开课号 CHAR(6) NOT NULL,
  课号 CHAR(6) NOT NULL,
  工号 CHAR(6) NOT NULL,
  开课地点 CHAR(6),
  开课学年 CHAR(9),
  开课学期 INT ,
  开课周数 INT DEFAULT 17,
  开课时间 VARCHAR(20),
  限选人数 INT,
  已选人数 INT,
  CONSTRAINT PK_开课表_开课号 PRIMARY KEY(开课号),
  CONSTRAINT FK_开课表_工号 FOREIGN KEY(工号) REFERENCES 教师表(工号)
  ON UPDATE CASCADE ON DELETE CASCADE,
  CONSTRAINT FK_开课表_课号 FOREIGN KEY(课号) REFERENCES 课程表(课号)
  ON UPDATE CASCADE ON DELETE CASCADE,
  CONSTRAINT CK_开课表_开课号 CHECK(开课号 LIKE '[0-9][0-9][0-9][0-9][0-9][0-9]'),
  CONSTRAINT CK_开课表_工号 CHECK(工号 LIKE 'T[0-9][0-9][0-9][0-9][0-9]'),
  CONSTRAINT CK_开课表_课号 CHECK(课号 LIKE 'C[0-9][0-9][0-9][0-9][0-9]')
)

CREATE TABLE 选课表
(
  学号 CHAR(7) NOT NULL,
  开课号 CHAR(6) NOT NULL,
  成绩 INT CHECK(成绩>=0 and 成绩<=100),
  CONSTRAINT PK_选课表_学号_开课号 PRIMARY KEY(学号,开课号),
  CONSTRAINT FK_选课表_学号 FOREIGN KEY(学号) REFERENCES 学生表(学号)
  ON UPDATE CASCADE ON DELETE CASCADE,
  CONSTRAINT FK_选课表_开课号 FOREIGN KEY(开课号) REFERENCES 开课表(开课号)
  ON UPDATE CASCADE ON DELETE CASCADE,
  CONSTRAINT CK_选课表_学号 CHECK(学号 LIKE 'S[0-9][0-9][0-9][0-9][0-9][0-9]'),
  CONSTRAINT CK_选课表_开课号 CHECK(开课号 LIKE '[0-9][0-9][0-9][0-9][0-9][0-9]')
)

--插入原始数据
DECLARE @tb_exist INT
SET @tb_exist=0
IF EXISTS(SELECT * FROM sysobjects WHERE name='选课表' AND xtype='U') 
   SET @tb_exist=@tb_exist | 1
IF EXISTS(SELECT * FROM sysobjects WHERE name='开课表' AND xtype='U')
   SET @tb_exist=@tb_exist | 2
IF EXISTS(SELECT * FROM sysobjects WHERE name='学生表' AND xtype='U')
   SET @tb_exist=@tb_exist | 4
IF EXISTS(SELECT * FROM sysobjects WHERE name='课程表' AND xtype='U')
   SET @tb_exist=@tb_exist | 8
IF EXISTS(SELECT * FROM sysobjects WHERE name='教师表' AND xtype='U')
   SET @tb_exist=@tb_exist | 16
IF @tb_exist !=31 BEGIN  --有一些表不存在
   PRINT '由于下列关系表不存在，因此插入元组失败！'
   IF (@tb_exist & 1) = 0 PRINT '选课表'
   IF (@tb_exist & 2) = 0 PRINT '开课表'
   IF (@tb_exist & 4) = 0 PRINT '学生表'
   IF (@tb_exist & 8) = 0 PRINT '课程表'
   IF (@tb_exist & 16) = 0 PRINT '教师表'
END
ELSE BEGIN  --五张表都存在
   IF EXISTS(SELECT * FROM 选课表) DELETE 选课表
   IF EXISTS(SELECT * FROM 开课表) DELETE 开课表
   IF EXISTS(SELECT * FROM 学生表) DELETE 学生表
   IF EXISTS(SELECT * FROM 课程表) DELETE 课程表
   IF EXISTS(SELECT * FROM 教师表) DELETE 教师表
--学生表样例数据插入
   INSERT INTO 学生表 VALUES('S060101',  '******19880526***', '王东民', 
'男', '135***11', '杭州', '计算机', '信电学院', 2)
   INSERT INTO 学生表 VALUES('S060102',  '******19891001***', '张小芬', 
'女', '131***11', '宁波', '计算机', '信电学院', 2)
   INSERT INTO 学生表 VALUES('S060103',  '******19871021***', '李鹏飞', 
'男', '139***12', '温州', '计算机', '信电学院', 2)
   INSERT INTO 学生表 VALUES('S060109',  '******19880511***', '陈晓莉', 
'女', NULL, '西安', '计算机', '信电学院', NULL)
   INSERT INTO 学生表 VALUES('S060110',  '******19880226***', '赵青山', 
'男', '130***22', '太原', '计算机', '信电学院', 2)
   INSERT INTO 学生表 VALUES('S060201',  '******19880606***', '胡汉民', 
'男', '135***22', '杭州', '信息管理', '信电学院', NULL)
   INSERT INTO 学生表 VALUES('S060202',  '******19871226***', '王俊青', 
'男', NULL, '金华', '信息管理', '信电学院', NULL)
   INSERT INTO 学生表 VALUES('S060306',  '******19880115***', '吴双红', 
'女', '139***01', '杭州', '电子商务', '信电学院', NULL)
   INSERT INTO 学生表 VALUES('S060308',  '******19890526***', '张丹宁', 
'男', '130***12', '宁波', '电子商务', '信电学院', NULL)

--课程表样例数据插入
   INSERT INTO 课程表 VALUES('C01001', 'C++程序设计',2, 'C++程序设计基础', 
'张基温', '高等教育出版社', '7-04-005655-0', 17)
   INSERT INTO 课程表 VALUES('C01002', '数据结构',3, '数据结构', 
NULL, NULL, NULL, NULL)
   INSERT INTO 课程表 VALUES('C01003', '数据库原理', 3,'数据库系统概论', 
'萨师煊', '高等教育出版社', '7-04-007494-X', NULL)
   INSERT INTO 课程表 VALUES('C02001', '管理信息系统', 2,'管理信息系统教程', 
'姚建荣', '浙江科学技术出版社', '7-5341-2422-0', 38)
   INSERT INTO 课程表 VALUES('C02002', 'ERP原理', 2,'ERP原理设计实施', 
'罗鸿', '电子工业出版社', '7-5053-8078-8', 38)
   INSERT INTO 课程表 VALUES('C02003', '会计信息系统',2, '会计信息系统', 
'王衍', NULL, NULL, NULL)
   INSERT INTO 课程表 VALUES('C03001', '电子商务', 2,'电子商务', NULL, 
NULL, NULL, NULL)

--教师表样例数据插入
   INSERT INTO 教师表 VALUES('T01001', '******19600526***', '黄中天', 
'男', '139***88', '杭州', '管理学院', '教授', 'T01001')
   INSERT INTO 教师表 VALUES('T01002', '******19721203***', '张丽', 
'女', '131***77', '沈阳', '管理学院', '讲师', 'T01001')
   INSERT INTO 教师表 VALUES('T02001', '******19580517***', '曲宏伟', 
'男', '135***66', '西安', '信电学院', '教授', 'T02001')
   INSERT INTO 教师表 VALUES('T02002', '******19640520***', '陈明收', 
'男', '137***55', '太原', '信电学院', '副教授', 'T02001')
   INSERT INTO 教师表 VALUES('T02003', '******19740810***', '王重阳', 
'男', '136***44', '绍兴', '信电学院', '讲师', 'T02001')

--开课表样例数据插入
   INSERT INTO 开课表 VALUES('010101', 'C01001', 'T02003', '1-202', 
 '2006-2007', '1', 18, '周一(1,2)',30,4 )
   INSERT INTO 开课表 VALUES('010201', 'C01002', 'T02001', '2-403', 
 '2006-2007', '2', 18, '周三(3,4)',30,1 )
   INSERT INTO 开课表 VALUES('010202', 'C01002', 'T02001', '2-203', 
 '2006-2007', '2', 18, '周五(3,4)',45,0 )
   INSERT INTO 开课表 VALUES('010301', 'C01003', 'T02002', '3-101', 
 '2007-2008', '1', 16, '周二(1,2,3)',20,2 )
   INSERT INTO 开课表 VALUES('020101', 'C02001', 'T01001', '3-201', 
 '2007-2008', '2', 18, '周三(3,4)',90,2 )
   INSERT INTO 开课表 VALUES('020102', 'C02001', 'T01001', '3-201', 
 '2007-2008', '2', 18, '周五(3,4)',50,1 )
   INSERT INTO 开课表 VALUES('020201', 'C02002', 'T02001', '4-303', 
 '2008-2009', '1', 17, '周四(1,2,3)',30,1 )
   INSERT INTO 开课表 VALUES('020301', 'C02003', 'T01002', '4-102', 
 '2008-2009', '1', 9, '周三(3)',70,1)
   INSERT INTO 开课表 VALUES('020302', 'C02003', 'T01002', '4-204', 
 '2008-2009', '1', 18, '周五(3,4)',30,0 )
   INSERT INTO 开课表 VALUES('030101', 'C03001', 'T01001', '3-303', 
'2008-2009', '2', 18, '周三(3,4)',45,1 )

--选课表样例数据插入
   INSERT INTO 选课表 VALUES('S060101', '010101', 90)
   INSERT INTO 选课表 VALUES('S060101', '010201', NULL)
   INSERT INTO 选课表 VALUES('S060101', '010301', NULL)
   INSERT INTO 选课表 VALUES('S060101', '020101', NULL)
   INSERT INTO 选课表 VALUES('S060101', '020201', NULL)
   INSERT INTO 选课表 VALUES('S060101', '020301', NULL)
   INSERT INTO 选课表 VALUES('S060101', '030101', NULL)
   INSERT INTO 选课表 VALUES('S060102', '010101', 93)
   INSERT INTO 选课表 VALUES('S060102', '010301', NULL)
   INSERT INTO 选课表 VALUES('S060102', '020102', NULL)
   INSERT INTO 选课表 VALUES('S060103', '010101', 85)
   INSERT INTO 选课表 VALUES('S060110', '010101', 88)
   INSERT INTO 选课表 VALUES('S060110', '010301', NULL)
   INSERT INTO 选课表 VALUES('S060201', '020101', NULL)
   INSERT INTO 选课表 VALUES('S060202', '010101', 75)
   INSERT INTO 选课表 VALUES('S060202', '020201', NULL)
END

