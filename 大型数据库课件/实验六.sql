/*(����Ϊ����ʵ����׼�������������)����һ��Total_Hours����������ÿ
��Ա��������Ŀ�ܵĹ���ʱ�䣬����Ա��SSN���ܹ���ʱ�䣨totalHours�����У�
Ȼ��employee�������Ա��SSN�ͳ�ʼ����ʱ�䣨0�����뵽��Total_Hours�У�
����ô�works_on��ͳ�Ƶ�ÿ��Ա
��������Ŀ�ܵ�ʵ�ʹ���ʱ����±�Total_Hours������ͼ��ʾ��*/
create table Total_Hours
(SSN varchar(50) primary key,totalHours decimal(18,1) default(0))
insert into dbo.Total_Hours select ssn,0 from employee
update Total_Hours set totalHours=
(select SUM(hours) from WORKS_ON where Total_Hours.SSN=WORKS_ON.ESSN)
select * from Total_Hours
select * from WORKS_ON
go
/*2��ʹ��INSERT������ʵ�֣���ÿ��employee�����һ��Ա��ʱ���Զ���
Total_Hours��������Ա����SSN�������ʼtotalHours��Ϊ0����ÿ��
works_on�����һ������ʱ���Զ�����Total_Hours���и�Ա����Ӧ��totalHours
��������Ҫ��Ҫ���ڲ������ǰ�󶼼���select * from Total_Hours�Բ鿴��
�������µ�Total_Hours��ı仯��*/
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
/*3��ʹ��UPDATE������ʵ��ÿ������works_on��HOURS����ʱ��ÿ��ֻ����һ��
���ݣ����Զ�����Total_Hours���totalHours. ������Ҫ��Ҫ����update���
ǰ�󶼼���select * from Total_Hours�Բ鿴���������µ�Total_Hours��
�ı仯��*/
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
/*4. ʹ��UPDATE������ʵ�֣����ҽ����޸�EMPLOYEE���SALARY����ʱ��ÿ��
ֻ����һ�����ݣ�������޸ĺ��SALARYС�ڵ����޸���ǰ��SALARY��������
�޸ģ�����ʾ���޸ĺ��� 1000 0000 0000 0000 
or
0000 0000 0000 0000
32768
С�ڵ����޸�ǰ���ʣ��޸�ʧ�ܣ�����������ʾ���޸ĳɹ�������*/
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
			print '�޸ĳɹ���'
			end
			else
			begin
			print '�޸ĺ���С�ڵ����޸�ǰ���ʣ��޸�ʧ�ܣ�'
			end
	end
end
select salary from Employee where SSN='123456789'
update Employee 
set SALARY=40000
where SSN='123456789'
select salary from Employee where SSN='123456789'
go
/*5��ʹ��DELETE����������ʾ����INSTEAD OF��������ʵ��ÿ��ɾ��employee
��Ա�����п��ܻ�ͬʱɾ�����Ա������Ҫ���α괦��ʱ�������ɾ����Ա��
����ͨԱ������ͬʱ����ɾ��Total_Hours��works_on��Dependent�����뱻
ɾ��Ա����ص��������ݣ�����employee���works_on���б�ɾ�����ݷֱ𱸷�
��employee_backup���works_on_backup���У������ɾ��Ա���ǲ��ž���
������ɾ��������ʾ��Manager can not be deleted!��������ʾ��employee ��
������֮�䲻�����κ����Լ����������Ҫ�󣺷ֱ�ɾ������5һ�����ž����һ��
�ǲ��ž���ͬʱɾ�����в���4Ա�����۲��������ִ�н����*/
select * from Employee
create trigger trigger_deleemp
on employee instead of delete
as
begin
	--�����α꣬����ɾ�����е�����
	declare deleted_cur cursor 
	for select ssn from deleted
	declare @ssn varchar(50)
	open deleted_cur
	fetch next from deleted_cur into @ssn
	while @@FETCH_STATUS=0
		begin
			if @ssn in(select MGRSSN from Department)--����Ǿ���
			begin
			print 'Manager can not be deleted!'
			end
				else
				begin--��ͨԱ��
				delete from Employee where SSN=@ssn
				delete from Total_Hours where SSN=@ssn
				delete from Dependent where ESSN=@ssn
					 if object_id('employee_backup') is not null  --�����
					 begin
					 insert into employee_backup select * from deleted where SSN=@ssn
					 end
					 else  --employee_backup������
					 begin
					 select * into employee_backup from deleted where SSN=@ssn
					 end
					 if object_id('works_on_backup') is not null  --�����
					 begin
					 insert into works_on_backup select * from WORKS_ON where essn=@ssn
					 end
					 else  --works_on_backup������
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
/*��INSERT��������ͼ�в���һ�����ݣ�����Ϊ�������ȫƴ��SSNΪ���ѧ�ţ����ű��
Ϊ6����������Ϊ��COMPUTER�������ʸ���ͼ�Ƿ�ɲ������ݣ�Ϊʲô��
����INSTEAD OF���������¸���ͼ����ִ������ͼ�������󣬲�ѯ����ͼ�ܿ�����������
��صļ�¼��*/
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