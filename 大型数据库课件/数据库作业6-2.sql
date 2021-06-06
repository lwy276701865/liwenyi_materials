/*
��T-SQL�У�����ʹ��CREATE INDEX�������⣬������ʹ��ʲô��ʽ����������
��д��SQL���룬�����������_sunyu(�����ƴ��ȫƴ)��׺��*/
alter table department add constraint pk_department_liwenyi
primary key (dnumber)
alter table department add constraint uni_department_liwenyi
unique (dnumber)
exec sp_helpconstraint department
exec sp_helpindex department 
/*sp_rename 'indextbl_test_liwenyi.number','number_liwenyi','column'
sp_rename 'indextbl_test_liwenyi.name','name_liwenyi','column'
sp_rename 'indextbl_test_liwenyi.myname','myname_liwenyi','column'*/
/*�봴��һ������һ��������ݿ⣬�ñ�����2�С��ڴ˱��в�������5�����ݡ��ڸñ��д���
һ���ۼ������ͷǾۼ�������ͨ����ѯSYSINDEXESϵͳ�������Ϣ��DBCC�����ʾ���
���ݱ�洢ҳ�ͷǾۼ������Ĵ洢ҳ���Ǿۼ�������PAGE����鿴�洢ҳʱ����3�Ų鿴��ʽ��
��������ҵ������ʹ�õ�����������롢��ͼ���������˵������ҵ�ĵ����ȡ�
(��ֱ���ϴ�WORD�ĵ���ʵ�������õ����ݿ⡢����ֶ����ȶ�Ҫ��_xxxxxx��β��
���������ƴ��ȫƴ�������ݿ�����������Ҫ��1���ַ������ݣ�����Ҫ�����������ƴ��ȫ
ƴ)*/
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
values('001','����','liwenyi')
insert into indextbl_test_liwenyi(number_liwenyi,name_liwenyi,myname_liwenyi)
values('002','����','liwenyi')
insert into indextbl_test_liwenyi(number_liwenyi,name_liwenyi,myname_liwenyi)
values('003','�','liwenyi')
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