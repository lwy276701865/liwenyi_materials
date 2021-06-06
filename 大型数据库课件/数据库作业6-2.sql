/*
在T-SQL中，除了使用CREATE INDEX命令以外，还可以使用什么方式创建索引。
请写出SQL代码，索引名后加上_sunyu(即你的拼音全拼)后缀。*/
alter table department add constraint pk_department_liwenyi
primary key (dnumber)
alter table department add constraint uni_department_liwenyi
unique (dnumber)
exec sp_helpconstraint department
exec sp_helpindex department 
/*sp_rename 'indextbl_test_liwenyi.number','number_liwenyi','column'
sp_rename 'indextbl_test_liwenyi.name','name_liwenyi','column'
sp_rename 'indextbl_test_liwenyi.myname','myname_liwenyi','column'*/
/*请创建一个包含一个表的数据库，该表至少2列。在此表中插入至少5行数据。在该表中创建
一个聚集索引和非聚集索引，通过查询SYSINDEXES系统表相关信息和DBCC命令，显示你的
数据表存储页和非聚集索引的存储页（非聚集索引用PAGE命令查看存储页时，用3号查看方式）
。附上作业过程中使用的所有命令代码、截图、相关文字说明、作业心得体会等。
(请直接上传WORD文档。实验中所用的数据库、表和字段名等都要以_xxxxxx结尾，
即你的名字拼音全拼，且数据库中数据至少要有1列字符串数据，内容要包括你的姓名拼音全
拼)*/
create database indexdb_test_liwenyi
use indexdb_test_liwenyi
go
create table indextbl_test_liwenyi
(
	number_liwenyi varchar(5) not null,
	name_liwenyi varchar(5) not null,
	myname_liwenyi char(7) not null
)
insert into indextbl_test_liwenyi(number_liwenyi,name_liwenyi,myname_liwenyi)
values('001','李四','liwenyi')
insert into indextbl_test_liwenyi(number_liwenyi,name_liwenyi,myname_liwenyi)
values('002','张三','liwenyi')
insert into indextbl_test_liwenyi(number_liwenyi,name_liwenyi,myname_liwenyi)
values('003','李华','liwenyi')
insert into indextbl_test_liwenyi(number_liwenyi,name_liwenyi,myname_liwenyi)
values('004','rose','liwenyi')
insert into indextbl_test_liwenyi(number_liwenyi,name_liwenyi,myname_liwenyi)
values('005','jack','liwenyi')
select * from indextbl_test_liwenyi
alter table indextbl_test_liwenyi add constraint pk_indextbl_test_liwenyi
primary key (number_liwenyi)
alter table indextbl_test_liwenyi add constraint uni_indextbl_test_liwenyi
unique (name_liwenyi desc)
exec sp_helpconstraint indextbl_test_liwenyi
exec sp_helpindex indextbl_test_liwenyi 
select * from sysindexes where id=OBJECT_ID('indextbl_test_liwenyi')
dbcc traceon(3604)
dbcc page(indexdb_test_liwenyi,1,80,1)