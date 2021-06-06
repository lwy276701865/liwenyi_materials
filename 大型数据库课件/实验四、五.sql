/*(1)	�����������Զ��庯��
��	����һ����׳˵ĺ�����F1_�Զ��庯������
��	 ���øú�������5!*3!-6!
*/
create function F1_�Զ��庯��(@num int)
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
select dbo.F1_�Զ��庯��(5)*dbo.F1_�Զ��庯��(3)-dbo.F1_�Զ��庯��(6)
select * from employee 
select * from department
select * from Project
select * from WORKS_ON

go
/*(2)	��COMPANY���ݿ��У�����һ���Զ��������������������ĳ������
���������Ϊ���������ơ�����Ա������ */
create function F_Ա����(@dname varchar(20))
returns int
as
begin
declare @num int
select @num=COUNT(dname) from Employee,Department
where
DNO=dnumber and dname=@dname
return @num
end
select dbo.F_Ա����('Administration')
go
/*(3)	��COMPANY���ݿ��У�����һ���Զ�����Ƕ��ֵ��������������ĳ������
���������Ϊ���������ơ���������Ա�����������Ա�SSN��������Ϣ��*/
create function F_Ա����Ϣ(@dname varchar(20))
returns table
as
return(
select fname,sex,ssn,bdate 
from Employee,Department
where DNO=DNUMBER and DNAME=@dname)
select * from dbo.F_Ա����Ϣ('Administration')
go
/*(4)	��COMPANY���ݿ��У�����һ���Զ��������ֵ�������������زμӹ�
ĳ����Ŀ���������Ϊ����Ŀ���ơ�����Ա���ġ�FNAME������SALARY����������Ϣ��Ҫ��
����FNAME��ת���ɴ�д��ĸ����*/
create function F_Ա����Ϣ_�����(@pname varchar(15))
returns @�μӹ���ĿԱ����Ϣ�� table(
FNAME varchar(10),
salary int,
bdate date
)
as
begin
insert @�μӹ���ĿԱ����Ϣ��
select fname,salary,bdate
from Employee,WORKS_ON,Project
where PNO=PNUMBER and pname=@pname and ESSN=ssn
return
end
select * from dbo.F_Ա����Ϣ_�����('productx')
go
--�α�ʵ��
/*(1)	���EMPLOYEE����һ��ֻ���α꣬��ѯ����Ա�������������䡢����
�����ڲ������ƣ��������ɸߵ������򣩡�*/
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
print '���ʵ�'+cast(@i as varchar(2))+'�ߵ�����Ա��'
print'������'+@fname
print '���䣺'+cast(@bdate as varchar(20))
print '���ʣ�'+cast(@salary as varchar(20))
print '���ڲ��ţ�'+cast(@dname as varchar(20))
print '-------------'
fetch next from employee_cur1
into @fname,@bdate,@salary,@dname
set @i=@i+1
end
close employee_cur1
deallocate employee_cur1
go
/*(2)	���EMPLOYEE����һ���α꣬���α��о�
��λ��Ϊ3��Ա��������Ϊ���ƴ�������������Ա��Ϊ����Ա�*/
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
/*(3)	���EMPLOYEE����һ���α꣬��Ա�����������������Ա��ɾ��*/
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
/*(4)	��Ա����������һ�С��μӵ���Ŀ������������һ���α�ͳ
��Ա���μӵ���Ŀ����Ȼ������Ա�����С��μӵ���Ŀ���������С�*/
alter table employee
add �μӵ���Ŀ���� int
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
set �μӵ���Ŀ����=@sumprogect
where FNAME=@fname
fetch next from employee_cur4
into @fname,@sumprogect
end
close employee_cur4
deallocate employee_cur4
select fname,�μӵ���Ŀ���� from employee
select * from employee 
select * from department
select * from Project
select * from WORKS_ON
go
/*(5)	����һ��������ֵ�����������Ա���Ϊ�������ƣ�
����ֵΪָ������Ա������Ŀ����������ۼƲ�����Ŀ��Сʱ����*/
drop function F_Ա��������Ŀ
go

create function F_Ա��������Ŀ(@dname varchar(15))
returns @Ա��������Ŀ�� table(
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
--�����α�
declare Ա������_cur cursor
for 
select ssn,fname,lname,sum(hours)
from Employee,WORKS_ON,Project,Department
where PNO=PNUMBER and SSN=ESSN and DNAME=@dname
and DNUM=DNUMBER
group by ssn,fname,lname
--���α�
open Ա������_cur
fetch next from Ա������_cur into @ssn,@fname,@lname,@hours
	while @@FETCH_STATUS=0
	begin
	--���������ݲ����µı�
		insert @Ա��������Ŀ��
select ssn,fname,lname,pname,hours
from Employee,WORKS_ON,Project,Department
where PNO=PNUMBER and SSN=ESSN and DNAME=@dname 
and DNUM=DNUMBER  and SSN=@ssn

		insert into @Ա��������Ŀ��
		values(@ssn,@fname,@lname,'������Ŀ������ʱ��Ϊ��',@hours)
		fetch next from Ա������_cur into @ssn,@fname,@lname,@hours
	end
	close Ա������_cur
	deallocate Ա������_cur
	return
end
go
select * from dbo.F_Ա��������Ŀ('research')
