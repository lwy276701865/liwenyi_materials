/*删除Employee表和Department表之间的所有参照关系，将DNUMBER设置为
DEARTMENT表的主键。在EMPLOYEE表的SEX列上添加一个CHECK约束，限制其只能
为M或F。*/
select * from Department
select * from employee
sp_helpconstraint employee
sp_helpindex employee
select * from sysindexes where id=OBJECT_ID('department')
alter table employee add constraint ck_employee
check (sex='M' or sex='F')
/*在DEPARTMENT表中插入一新部门，部门名为Production、部门编号为3、经理编号
为你的学号；在EMPLOYEE表中插入一新员工，姓名为你的拼音名字、SSN为你的学号
、性别为你的中文性别；最后打印消息“程序结束”。*/
/*（1）使用自动事务模式执行上述3个语句，分别显示执行完毕后的EMPLOYEE表和
DEPARTMENT表数据以及“消息”框文字，解释你看到的结果。*/
insert into Department(DNAME,DNUMBER,mgrssn)
values('Production',3,201731062208)
insert into employee(FNAME,SSN,sex)
values('liwenyi',201731062208,'男')
print '程序结束'
go
/*（2）将XACT_ABORT开关打开，将插入的PRODUCTION部门删除（如果有）。然后
使用自动事务模式执行上述3个语句，分别显示执行完毕后的EMPLOYEE表和
DEPARTMENT表数据以及“消息”框文字，解释你看到的结果。*/
set xact_abort on
delete from Department where DNUMBER=3
insert into Department(DNAME,DNUMBER,mgrssn)
values('Production',3,201731062208)
insert into employee(FNAME,SSN,sex)
values('liwenyi',201731062208,'男')
print '程序结束'
go
/*3.将XACT_ABORT开关关闭，将插入的PRODUCTION部门删除（如果有）。然后使用显
式事务执行上述3个语句，分别显示执行完毕后的EMPLOYEE表和DEPARTMENT表数据以
及“消息”框文字，解释你看到的结果。*/
set xact_abort off
delete from Department where DNUMBER=3
begin transaction
insert into Department(DNAME,DNUMBER,mgrssn)
values('Production',3,201731062208)
insert into employee(FNAME,SSN,sex)
values('liwenyi',201731062208,'男')
print '程序结束'
commit transaction
go
/*4.将XACT_ABORT开关打开，将插入的PRODUCTION部门删除（如果有）。然后使用
显式事务执行上述3个语句，分别显示执行完毕后的EMPLOYEE表和DEPARTMENT表数据
以及“消息”框文字，解释你看到的结果。*/
set xact_abort on
delete from Department where DNUMBER=3
begin transaction
insert into Department(DNAME,DNUMBER,mgrssn)
values('Production',3,201731062208)
insert into employee(FNAME,SSN,sex)
values('liwenyi',201731062208,'男')
print '程序结束'
commit transaction
go
/*5.将XACT_ABORT开关关闭，将插入的PRODUCTION部门删除（如果有）。然后使用
显式事务执行上述3个语句，并利用TRY……CATCH加入错误处理程序（如果有任一插入
语句失败，则回滚整个事务）。分别显示执行完毕后的EMPLOYEE表和DEPARTMENT表
数据以及“消息”框文字，解释你看到的结果。*/
set xact_abort off
delete from Department where DNUMBER=3
BEGIN TRY
BEGIN TRANSACTION
insert into Department(DNAME,DNUMBER,mgrssn)
values('Production',3,201731062208)
insert into employee(FNAME,SSN,sex)
values('liwenyi',201731062208,'男')
print '程序结束'
rollback TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
END CATCH
select * from Department
select * from employee
go
/*6.将插入的PRODUCTION部门删除（如果有）。然后使用显式事务执行上述3个语句，
并通过判断@@error值加入错误处理程序（如果有任一插入语句失败，则回滚整个事
务）。分别显示执行完毕后的EMPLOYEE表和DEPARTMENT表数据以及“消息”框文字
，解释你看到的结果。*/
--set  xact_abort on
delete from Department where DNUMBER=3
begin transaction
declare @myerror int
insert into Department(DNAME,DNUMBER,mgrssn)
values('Production',3,201731062208)
set @myerror=@@ERROR+@myerror
insert into employee(FNAME,SSN,sex)
values('liwenyi',201731062208,'男')
set @myerror=@@ERROR+@myerror
print '程序结束'
set @myerror=@@ERROR+@myerror
if @myerror=0
begin
commit transaction
end
else
begin
rollback transaction
end
select * from Department
select * from employee
go
/*7.将插入的PRODUCTION部门删除（如果有）。使用隐式事务模式执行上述3个语句。
分别显示执行完毕后的EMPLOYEE表和DEPARTMENT表数据以及“消息”框文字，解释
你看到的结果。*/
delete from Department where DNUMBER=3
set implicit_transactions on
insert into Department(DNAME,DNUMBER,mgrssn)
values('Production',3,201731062208)
insert into employee(FNAME,SSN,sex)
values('liwenyi',201731062208,'男')
print '程序结束'
commit transaction
set implicit_transactions off