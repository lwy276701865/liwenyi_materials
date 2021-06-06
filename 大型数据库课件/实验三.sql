create proc select_Pname
as select pname from project
select_Pname
select SSN,FNAME,LNAME,SALARY from employee 
go
create proc add_salary
as select SSN,FNAME,LNAME, salary*1.1 as new_salary 
from employee
execute add_salary
go
--编写一个查询工资大于30000的员工信息的存储过程。
create proc more_salary
as select SSN,FNAME,LNAME,SALARY from Employee 
where SALARY>30000
execute more_salary
go
/*编写一个查询工资大于给定值的员工信息的存储过程，如果存储过程执行时
没有给定参数，则默认查询工资大于30000的员工信息。分别显示提供参数和
不提供参数的存储过程执行结果。*/
create proc search_salary(@mysalary int=30000)
as select SSN,FNAME,LNAME,SALARY from Employee
where SALARY>@mysalary
execute search_salary @mysalary=20000
exec search_salary 
select * from Project
where PNAME like 'p%'
go

/*5．编写一个按照指定方式针对PNAME进行模式匹配以查询project表中项目
信息的存储过程，如果不提供模式匹配字符串参数，则默认查询PNAME以P开头
的项目信息。分别显示提供参数和不提供参数的存储过程执行结果。*/
create proc match_pname(@str varchar(30)='p%')
as select * from Project
where PNAME like @str
exec match_pname 
select * from employee 
select SSN,SALARY,DNO,pname,dnum,pnumber,SSN,essn ,pno from Employee,project,WORKS_ON
select * from WORKS_ON
go
/*编写一个用OUTPUT参数返回参加了指定项目（用项目名指定项目）的员工的平均
工资，最高工资和最低工资的存储过程。*/

create proc avg_salary(@mypname varchar(20),@avgsalary int output
,@maxsalary int output,@minsalary int output) 
as 
select salary
from Employee e,WORKS_ON w,Project p
where p.PNAME=@mypname
  AND w.PNO=p.PNUMBER
  AND e.SSN=w.ESSN
 select @avgsalary=AVG(salary),@maxsalary=MAX(salary),
@minsalary=MIN(salary)
from Employee e,WORKS_ON w,Project p
where p.PNAME=@mypname
  AND w.PNO=p.PNUMBER
  AND e.SSN=w.ESSN
  return
go
declare @mypname varchar(20),@avgsalary int ,
@maxsalary int ,@minsalary int 
set @mypname='productx'
exec avg_salary @mypname,@avgsalary output,@maxsalary output,
@minsalary output
go



create PROC count_salary(@pro varchar(50),@avgSalary int OUTPUT,
@maxSalary int OUTPUT,@minSalary int OUTPUT)
as
select @avgSalary=AVG(e.SALARY),@maxSalary=MAX(e.SALARY),
@minSalary=MIN(e.SALARY)
from Employee e,WORKS_ON w,Project p
where p.PNAME=@pro
  AND w.PNO=p.PNUMBER
  AND e.SSN=w.ESSN
return
go
 
declare @pro varchar(50),@avgSalary int,@maxSalary int,@minSalary int
set @pro='ProductX'
exec count_salary @pro,@avgSalary OUTPUT,@maxSalary OUTPUT,
@minSalary OUTPUT
select @avgSalary,@maxSalary,@minSalary
go
/*7．编写一个查找是否存在FNAME包含给定字符串(字符串长度不超过20个字符)的员
工的存储过程。如果存在多个符合条件的员工返回1，存在一个返回0，否则返回-1。
要求用return实现返回状态值。分别显示三种情况的存储过程执行结果(必须在结果
中根据存储过程返回的不同状态值输出相应的中文提示)。*/
create proc findName(@myname varchar(10))
as
if ((select COUNT(*) from Employee where FNAME=@myname)=1)
return 0
else if((select COUNT(*) from Employee where FNAME=@myname)=0)
return -1
else
return 1
go
declare @myname varchar(10),@id int
set @myname='john'
exec @id=findName @myname
if(@id=0)
print '存在一个员工'
else if(@id=1)
print '存在多个员工'
else
print '不存在指定员工'
go
/*8．编写一个用OUTPUT参数返回指定部门（用部门号指定部门）员工的平均工资
的存储过程。如果输入部门号不存在，则输出“该部门不存在”。*/
create proc avgSalary(@id int,@avgsalary varchar(20) output)
as
if @id in(select dno from employee)
begin
select @avgsalary=AVG(salary) 
from Employee
where DNO =@id
end
else
select @avgsalary= '部门不存在'
go
declare @id int ,@avgsalary varchar(20)
set @id=5
exec avgSalary @id,@avgsalary output
select @avgsalary 