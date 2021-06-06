execute sp_helpindex employee
select * from sysindexes where id=OBJECT_ID('employee')
dbcc traceon(3604)
dbcc extentinfo(company_Gushuangquan,employee)
dbcc page (company_Gushuangquan,1,22,1)
/* ��ΪԱ������һ��������Ϊemp_ssn��Ψһ�ԷǾۼ�������
�����ؼ�����SSN���������80 % ��*/
create unique nonclustered index emp_ssn
 on employee (ssn)
 with(pad_index=on,fillfactor=80)
execute sp_rename 'employee.emp_ssn','Ա����_Ա����','index'
/*��ΪԱ��������Ŀ����һ��������Ϊ��Ա��_��Ŀ_index���ķǾۼ���������
�������ؼ���Ϊ��Ա���š������򣬡���Ŀ��š��������������50%��*/
select * from employee
create nonclustered index Ա��_��Ŀ_index
on employee (ssn ,dno desc)
with(pad_index=on,fillfactor=50)
drop index employee.Ա����_Ա����,employee.Ա��_��Ŀ_index