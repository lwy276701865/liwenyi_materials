/*ɾ��Employee���Department��֮������в��չ�ϵ����DNUMBER����Ϊ
DEARTMENT�����������EMPLOYEE���SEX�������һ��CHECKԼ����������ֻ��
ΪM��F��*/
select * from Department
select * from employee
sp_helpconstraint employee
sp_helpindex employee
select * from sysindexes where id=OBJECT_ID('department')
alter table employee add constraint ck_employee
check (sex='M' or sex='F')
/*��DEPARTMENT���в���һ�²��ţ�������ΪProduction�����ű��Ϊ3��������
Ϊ���ѧ�ţ���EMPLOYEE���в���һ��Ա��������Ϊ���ƴ�����֡�SSNΪ���ѧ��
���Ա�Ϊ��������Ա�����ӡ��Ϣ�������������*/
/*��1��ʹ���Զ�����ģʽִ������3����䣬�ֱ���ʾִ����Ϻ��EMPLOYEE���
DEPARTMENT�������Լ�����Ϣ�������֣������㿴���Ľ����*/
insert into Department(DNAME,DNUMBER,mgrssn)
values('Production',3,201731062208)
insert into employee(FNAME,SSN,sex)
values('liwenyi',201731062208,'��')
print '�������'
go
/*��2����XACT_ABORT���ش򿪣��������PRODUCTION����ɾ��������У���Ȼ��
ʹ���Զ�����ģʽִ������3����䣬�ֱ���ʾִ����Ϻ��EMPLOYEE���
DEPARTMENT�������Լ�����Ϣ�������֣������㿴���Ľ����*/
set xact_abort on
delete from Department where DNUMBER=3
insert into Department(DNAME,DNUMBER,mgrssn)
values('Production',3,201731062208)
insert into employee(FNAME,SSN,sex)
values('liwenyi',201731062208,'��')
print '�������'
go
/*3.��XACT_ABORT���عرգ��������PRODUCTION����ɾ��������У���Ȼ��ʹ����
ʽ����ִ������3����䣬�ֱ���ʾִ����Ϻ��EMPLOYEE���DEPARTMENT��������
������Ϣ�������֣������㿴���Ľ����*/
set xact_abort off
delete from Department where DNUMBER=3
begin transaction
insert into Department(DNAME,DNUMBER,mgrssn)
values('Production',3,201731062208)
insert into employee(FNAME,SSN,sex)
values('liwenyi',201731062208,'��')
print '�������'
commit transaction
go
/*4.��XACT_ABORT���ش򿪣��������PRODUCTION����ɾ��������У���Ȼ��ʹ��
��ʽ����ִ������3����䣬�ֱ���ʾִ����Ϻ��EMPLOYEE���DEPARTMENT������
�Լ�����Ϣ�������֣������㿴���Ľ����*/
set xact_abort on
delete from Department where DNUMBER=3
begin transaction
insert into Department(DNAME,DNUMBER,mgrssn)
values('Production',3,201731062208)
insert into employee(FNAME,SSN,sex)
values('liwenyi',201731062208,'��')
print '�������'
commit transaction
go
/*5.��XACT_ABORT���عرգ��������PRODUCTION����ɾ��������У���Ȼ��ʹ��
��ʽ����ִ������3����䣬������TRY����CATCH�������������������һ����
���ʧ�ܣ���ع��������񣩡��ֱ���ʾִ����Ϻ��EMPLOYEE���DEPARTMENT��
�����Լ�����Ϣ�������֣������㿴���Ľ����*/
set xact_abort off
delete from Department where DNUMBER=3
BEGIN TRY
BEGIN TRANSACTION
insert into Department(DNAME,DNUMBER,mgrssn)
values('Production',3,201731062208)
insert into employee(FNAME,SSN,sex)
values('liwenyi',201731062208,'��')
print '�������'
rollback TRANSACTION
END TRY
BEGIN CATCH
    ROLLBACK TRANSACTION
END CATCH
select * from Department
select * from employee
go
/*6.�������PRODUCTION����ɾ��������У���Ȼ��ʹ����ʽ����ִ������3����䣬
��ͨ���ж�@@errorֵ�������������������һ�������ʧ�ܣ���ع�������
�񣩡��ֱ���ʾִ����Ϻ��EMPLOYEE���DEPARTMENT�������Լ�����Ϣ��������
�������㿴���Ľ����*/
--set  xact_abort on
delete from Department where DNUMBER=3
begin transaction
declare @myerror int
insert into Department(DNAME,DNUMBER,mgrssn)
values('Production',3,201731062208)
set @myerror=@@ERROR+@myerror
insert into employee(FNAME,SSN,sex)
values('liwenyi',201731062208,'��')
set @myerror=@@ERROR+@myerror
print '�������'
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
/*7.�������PRODUCTION����ɾ��������У���ʹ����ʽ����ģʽִ������3����䡣
�ֱ���ʾִ����Ϻ��EMPLOYEE���DEPARTMENT�������Լ�����Ϣ�������֣�����
�㿴���Ľ����*/
delete from Department where DNUMBER=3
set implicit_transactions on
insert into Department(DNAME,DNUMBER,mgrssn)
values('Production',3,201731062208)
insert into employee(FNAME,SSN,sex)
values('liwenyi',201731062208,'��')
print '�������'
commit transaction
set implicit_transactions off