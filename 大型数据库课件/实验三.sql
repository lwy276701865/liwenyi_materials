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
--��дһ����ѯ���ʴ���30000��Ա����Ϣ�Ĵ洢���̡�
create proc more_salary
as select SSN,FNAME,LNAME,SALARY from Employee 
where SALARY>30000
execute more_salary
go
/*��дһ����ѯ���ʴ��ڸ���ֵ��Ա����Ϣ�Ĵ洢���̣�����洢����ִ��ʱ
û�и�����������Ĭ�ϲ�ѯ���ʴ���30000��Ա����Ϣ���ֱ���ʾ�ṩ������
���ṩ�����Ĵ洢����ִ�н����*/
create proc search_salary(@mysalary int=30000)
as select SSN,FNAME,LNAME,SALARY from Employee
where SALARY>@mysalary
execute search_salary @mysalary=20000
exec search_salary 
select * from Project
where PNAME like 'p%'
go

/*5����дһ������ָ����ʽ���PNAME����ģʽƥ���Բ�ѯproject������Ŀ
��Ϣ�Ĵ洢���̣�������ṩģʽƥ���ַ�����������Ĭ�ϲ�ѯPNAME��P��ͷ
����Ŀ��Ϣ���ֱ���ʾ�ṩ�����Ͳ��ṩ�����Ĵ洢����ִ�н����*/
create proc match_pname(@str varchar(30)='p%')
as select * from Project
where PNAME like @str
exec match_pname 
select * from employee 
select SSN,SALARY,DNO,pname,dnum,pnumber,SSN,essn ,pno from Employee,project,WORKS_ON
select * from WORKS_ON
go
/*��дһ����OUTPUT�������زμ���ָ����Ŀ������Ŀ��ָ����Ŀ����Ա����ƽ��
���ʣ���߹��ʺ���͹��ʵĴ洢���̡�*/

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
/*7����дһ�������Ƿ����FNAME���������ַ���(�ַ������Ȳ�����20���ַ�)��Ա
���Ĵ洢���̡�������ڶ������������Ա������1������һ������0�����򷵻�-1��
Ҫ����returnʵ�ַ���״ֵ̬���ֱ���ʾ��������Ĵ洢����ִ�н��(�����ڽ��
�и��ݴ洢���̷��صĲ�ͬ״ֵ̬�����Ӧ��������ʾ)��*/
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
print '����һ��Ա��'
else if(@id=1)
print '���ڶ��Ա��'
else
print '������ָ��Ա��'
go
/*8����дһ����OUTPUT��������ָ�����ţ��ò��ź�ָ�����ţ�Ա����ƽ������
�Ĵ洢���̡�������벿�źŲ����ڣ���������ò��Ų����ڡ���*/
create proc avgSalary(@id int,@avgsalary varchar(20) output)
as
if @id in(select dno from employee)
begin
select @avgsalary=AVG(salary) 
from Employee
where DNO =@id
end
else
select @avgsalary= '���Ų�����'
go
declare @id int ,@avgsalary varchar(20)
set @id=5
exec avgSalary @id,@avgsalary output
select @avgsalary 