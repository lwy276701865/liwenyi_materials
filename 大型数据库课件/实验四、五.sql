/*(1)	创建标量型自定义函数
①	建立一个求阶乘的函数“F1_自定义函数”。
②	 调用该函数计算5!*3!-6!
*/
create function F1_自定义函数(@num int)
returns int
as
begin
declare @newnum int,@i int
select @i=1,@newnum=1
while(@i<@num+1 and @i>=1)
begin
set @newnum=@newnum*@i
set @i=@i+1
end
return @newnum
end
go
select dbo.F1_自定义函数(5)*dbo.F1_自定义函数(3)-dbo.F1_自定义函数(6)
select * from employee 
select * from department
select * from Project
select * from WORKS_ON

go
/*(2)	在COMPANY数据库中，创建一个自定义标量函数，用来返回某个部门
（传入参数为“部门名称”）的员工数。 */
create function F_员工数(@dname varchar(20))
returns int
as
begin
declare @num int
select @num=COUNT(dname) from Employee,Department
where
DNO=dnumber and dname=@dname
return @num
end
select dbo.F_员工数('Administration')
go
/*(3)	在COMPANY数据库中，创建一个自定义内嵌表值函数，用来返回某个部门
（传入参数为“部门名称”）的所有员工的姓名、性别、SSN和年龄信息。*/
create function F_员工信息(@dname varchar(20))
returns table
as
return(
select fname,sex,ssn,bdate 
from Employee,Department
where DNO=DNUMBER and DNAME=@dname)
select * from dbo.F_员工信息('Administration')
go
/*(4)	在COMPANY数据库中，创建一个自定义多语句表值函数，用来返回参加过
某个项目（传入参数为“项目名称”）的员工的“FNAME”、“SALARY”和年龄信息（要求
将“FNAME”转换成大写字母）。*/
create function F_员工信息_多语句(@pname varchar(15))
returns @参加过项目员工信息表 table(
FNAME varchar(10),
salary int,
bdate date
)
as
begin
insert @参加过项目员工信息表
select fname,salary,bdate
from Employee,WORKS_ON,Project
where PNO=PNUMBER and pname=@pname and ESSN=ssn
return
end
select * from dbo.F_员工信息_多语句('productx')
go
--游标实验
/*(1)	针对EMPLOYEE表定义一个只读游标，查询男性员工的姓名、年龄、工资
和所在部门名称（按工资由高到低排序）。*/
declare employee_cur1 cursor
for select fname,bdate,salary,dname
from Employee,Department
where DNO=DNUMBER and SEX='m'
order by SALARY desc
for read only
open employee_cur1
declare @fname varchar(15),@bdate date,@salary int,@dname varchar(15),@i int
set @i=1
fetch next from employee_cur1
into @fname,@bdate,@salary,@dname
while @@FETCH_STATUS=0
begin
print '工资第'+cast(@i as varchar(2))+'高的男性员工'
print'姓名：'+@fname
print '年龄：'+cast(@bdate as varchar(20))
print '工资：'+cast(@salary as varchar(20))
print '所在部门：'+cast(@dname as varchar(20))
print '-------------'
fetch next from employee_cur1
into @fname,@bdate,@salary,@dname
set @i=@i+1
end
close employee_cur1
deallocate employee_cur1
go
/*(2)	针对EMPLOYEE表定义一个游标，将游标中绝
对位置为3的员工姓名改为你的拼音姓名，并将性别改为你的性别*/
declare employee_cur2 cursor
for select fname,sex from Employee
for update of fname,sex
declare @fname varchar(15),@sex char(1)
open employee_cur2
fetch next from employee_cur2 
into @fname,@sex
while @@FETCH_STATUS=0
begin
select @fname,@sex
if @fname='Joyce'
begin
update Employee
set FNAME='liwenyi',SEX='m' 
where CURRENT of employee_cur2
end
fetch next from employee_cur2 
into @fname,@sex
end
close employee_cur2
deallocate employee_cur2
go
/*(3)	针对EMPLOYEE表定义一个游标，将员工表中你的姓名那行员工删除*/
declare employee_cur3 cursor
for select fname from Employee
for update
declare @fname varchar(15)
open employee_cur3
fetch next from employee_cur3
into @fname
while @@FETCH_STATUS=0
begin
select @fname
if @fname='liwenyi'
begin
delete Employee
where CURRENT of employee_cur3
end
fetch next from employee_cur3
into @fname
end
close employee_cur3
deallocate employee_cur3
select * from Employee
go
/*(4)	在员工表中增加一列“参加的项目总数”。创建一个游标统
计员工参加的项目数，然后填入员工表中“参加的项目总数“列中。*/
alter table employee
add 参加的项目总数 int
declare employee_cur4 cursor
for select fname ,COUNT(*) from Employee,WORKS_ON
where SSN=ESSN
group by fname
for update
declare @fname varchar(15),@sumprogect int
open employee_cur4
fetch next from employee_cur4
into @fname,@sumprogect
while @@FETCH_STATUS=0
begin
update Employee
set 参加的项目总数=@sumprogect
where FNAME=@fname
fetch next from employee_cur4
into @fname,@sumprogect
end
close employee_cur4
deallocate employee_cur4
select fname,参加的项目总数 from employee
select * from employee 
select * from department
select * from Project
select * from WORKS_ON
go
/*(5)	创建一个多语句表值函数，函数自变量为部门名称，
返回值为指定部门员工的项目参与情况和累计参与项目总小时数，*/
drop function F_员工参与项目
go

create function F_员工参与项目(@dname varchar(15))
returns @员工参与项目表 table(
ssn int,
fname varchar(20),
lname varchar(20),
pname varchar(50),
HOURS float
)
as
begin
declare @ssn int,@fname varchar(20),@lname varchar(20),@hours float
,@pname varchar(20)
--定义游标
declare 员工参与_cur cursor
for 
select ssn,fname,lname,sum(hours)
from Employee,WORKS_ON,Project,Department
where PNO=PNUMBER and SSN=ESSN and DNAME=@dname
and DNUM=DNUMBER
group by ssn,fname,lname
--打开游标
open 员工参与_cur
fetch next from 员工参与_cur into @ssn,@fname,@lname,@hours
	while @@FETCH_STATUS=0
	begin
	--将所得数据插入新的表
		insert @员工参与项目表
select ssn,fname,lname,pname,hours
from Employee,WORKS_ON,Project,Department
where PNO=PNUMBER and SSN=ESSN and DNAME=@dname 
and DNUM=DNUMBER  and SSN=@ssn

		insert into @员工参与项目表
		values(@ssn,@fname,@lname,'所有项目工作总时间为：',@hours)
		fetch next from 员工参与_cur into @ssn,@fname,@lname,@hours
	end
	close 员工参与_cur
	deallocate 员工参与_cur
	return
end
go
select * from dbo.F_员工参与项目('research')
