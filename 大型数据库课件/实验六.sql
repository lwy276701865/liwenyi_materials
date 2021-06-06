/*(此题为后续实验题准备基础表和数据)创建一张Total_Hours表，用来保存每
个员工所有项目总的工作时间，包含员工SSN和总工作时间（totalHours）两列；
然后将employee表的所有员工SSN和初始工作时间（0）插入到表Total_Hours中；
最后用从works_on表统计的每个员
工所有项目总的实际工作时间更新表Total_Hours，如下图所示：*/
create table Total_Hours
(SSN varchar(50) primary key,totalHours decimal(18,1) default(0))
insert into dbo.Total_Hours select ssn,0 from employee
update Total_Hours set totalHours=
(select SUM(hours) from WORKS_ON where Total_Hours.SSN=WORKS_ON.ESSN)
select * from Total_Hours
select * from WORKS_ON
go
/*2．使用INSERT触发器实现：①每向employee表插入一个员工时，自动向
Total_Hours表插入这个员工的SSN并将其初始totalHours置为0；②每向
works_on表插入一行数据时，自动更新Total_Hours表中该员工对应的totalHours
。（测试要求：要求在插入语句前后都加上select * from Total_Hours以查看触
发器导致的Total_Hours表的变化）*/
create trigger trigger_employee
on employee for insert
as
begin
declare @ssn varchar(50)
select @ssn=ssn from inserted
insert into Total_Hours
values(@ssn,0)
end
select * from Total_Hours
insert into Employee (ssn)
values('0123456')
select * from Total_Hours
create trigger trigger_works_on
on works_on for insert
as
begin
declare @ssn varchar(50),@hours float
select @ssn=essn,@hours=hours
from inserted
insert into Total_Hours
values(@ssn,@hours)
end
select * from Total_Hours
insert into works_on 
values('01234567',1,10)
select * from Total_Hours
go
/*3．使用UPDATE触发器实现每当更新works_on表HOURS数据时（每次只更新一行
数据），自动更新Total_Hours表的totalHours. （测试要求：要求在update语句
前后都加上select * from Total_Hours以查看触发器导致的Total_Hours表
的变化）*/
create trigger trigger_works_on1
on works_on for update
as
begin
declare @ssn varchar(50),@hours float
select @ssn=essn,@hours=hours
from inserted
update Total_Hours
set totalHours=@hours 
where SSN=@ssn
end
select * from Total_Hours
update works_on 
set HOURS=20
where ESSN='01234567'
select * from Total_Hours
go
/*4. 使用UPDATE触发器实现：当且仅当修改EMPLOYEE表的SALARY数据时（每次
只更新一行数据），如果修改后的SALARY小于等于修改以前的SALARY，则不允许
修改，并提示“修改后工资 1000 0000 0000 0000 
or
0000 0000 0000 0000
32768
小于等于修改前工资，修改失败！”，否则提示“修改成功！”。*/
select * from Employee
delete from Employee where SSN=0123456
create trigger trigger_emp
on employee instead of update
as
begin 
declare @ssn varchar(50),@oldsalary int,@newsalary int
	if COLUMNS_UPDATED() | 0=32768
	begin 
	select @oldsalary=salary
	from deleted
	select @ssn=ssn,@newsalary=salary 
	from inserted
			if @newsalary>@oldsalary
			begin
			update Employee
			set SALARY=@newsalary
			where ssn=@ssn
			print '修改成功！'
			end
			else
			begin
			print '修改后工资小于等于修改前工资，修改失败！'
			end
	end
end
select salary from Employee where SSN='123456789'
update Employee 
set SALARY=40000
where SSN='123456789'
select salary from Employee where SSN='123456789'
go
/*5．使用DELETE触发器（提示：用INSTEAD OF触发器）实现每当删除employee
表员工（有可能会同时删除多个员工，需要用游标处理）时，如果被删除的员工
是普通员工，则同时级联删除Total_Hours表、works_on表、Dependent表中与被
删除员工相关的所有数据，并将employee表和works_on表中被删除数据分别备份
到employee_backup表和works_on_backup表中；如果被删除员工是部门经理，
则不允许删除，并提示“Manager can not be deleted!”。（提示：employee 和
其它表之间不存在任何外键约束）（测试要求：分别删除部门5一个部门经理和一个
非部门经理；同时删除所有部门4员工，观察三种情况执行结果）*/
select * from Employee
create trigger trigger_deleemp
on employee instead of delete
as
begin
	--定义游标，遍历删除表中的数据
	declare deleted_cur cursor 
	for select ssn from deleted
	declare @ssn varchar(50)
	open deleted_cur
	fetch next from deleted_cur into @ssn
	while @@FETCH_STATUS=0
		begin
			if @ssn in(select MGRSSN from Department)--如果是经理
			begin
			print 'Manager can not be deleted!'
			end
				else
				begin--普通员工
				delete from Employee where SSN=@ssn
				delete from Total_Hours where SSN=@ssn
				delete from Dependent where ESSN=@ssn
					 if object_id('employee_backup') is not null  --表存在
					 begin
					 insert into employee_backup select * from deleted where SSN=@ssn
					 end
					 else  --employee_backup表不存在
					 begin
					 select * into employee_backup from deleted where SSN=@ssn
					 end
					 if object_id('works_on_backup') is not null  --表存在
					 begin
					 insert into works_on_backup select * from WORKS_ON where essn=@ssn
					 end
					 else  --works_on_backup表不存在
					 begin
					  select * into works_on_backup from WORKS_ON where ESSN=@ssn
					 end
					 delete from works_on where ESSN=@ssn
				end
			fetch next from deleted_cur into @ssn
		end
		close deleted_cur
		deallocate deleted_cur
end
select * from employee where SSN='123456789'
delete from employee where SSN='123456789'
select * from employee where SSN='123456789'
select * from employee where DNO=4
select * from Total_Hours where ssn in(select ssn from employee where DNO=4)
select * from WORKS_ON where essn in(select ssn from employee where DNO=4)
select * from Dependent where essn in(select ssn from employee where DNO=4)
delete from employee where DNO=4
select * from employee where DNO=4
select * from Total_Hours where ssn in(select ssn from employee where DNO=4)
select * from WORKS_ON where essn in(select ssn from employee where DNO=4)
select * from Dependent where essn in(select ssn from employee where DNO=4)
select * from employee_backup where DNO=4
select * from works_on_backup where essn in(select ssn from employee_backup where DNO=4)
go
delete from employee
delete from Dependent
delete from works_on
delete from Total_Hours
delete from works_on_backup
delete from employee_backup
CREATE VIEW EMP_DEPT
AS
SELECT fname,lname,ssn,dnumber,dname from 
employee e join department d
on e.dno=d.dnumber
select * from department
/*用INSERT语句向该视图中插入一行数据，姓名为你的姓名全拼，SSN为你的学号，部门编号
为6，部门名称为“COMPUTER”。请问该视图是否可插入数据？为什么？
利用INSTEAD OF触发器更新该视图，即执行了视图插入语句后，查询该视图能看到和你姓名
相关的记录。*/
create trigger view_trigger
on Emp_DEPT instead of insert
as
begin
declare @fname varchar(20),@lname varchar(20),@ssn varchar(50),@dnumber int
,@dname varchar(20)
select @fname=fname,@lname=lname,@ssn=ssn,@dnumber=dnumber,@dname=dname
from inserted
insert into employee(FNAME,LNAME,SSN,DNO)
values(@fname,@lname,@ssn,@dnumber)
insert into Department(DNUMBER,DNAME)
values(@dnumber,@dname)
end
select* from EMP_DEPT
insert into EMP_DEPT
values('li','wenyi',201731062208,6,'COMPUTER')
select* from EMP_DEPT