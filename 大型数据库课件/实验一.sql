declare @i1 char(100),@i2 char(100)
set @i1='10'
set @i2=cast((cast(@i1 as int)*5) as char(100))
print @i2
go
declare @i1 varchar(20)
set @i1='Welcome to SWPU'
print @i1
SELECT SERVERPROPERTY('MachineName')
select @@SERVERNAME
select HOST_NAME()
print @@version
print abs(-3)
print sqrt(16)
print power(5,3)
/*1���ֱ��ַ�����china������MACHINE��ת���ɴ�д��Сд��ĸ��
2��ȥ���ַ�����  machine  ����ߵĿո����롰china������press������������
3��ȥ���ַ�����  machine  ���ұߵĿո����롰china������press������������
4��ȥ���ַ�����  machine  ���������ߵĿո����롰china������press������������
5���ú��������ַ�����I am a student.���ĳ��ȣ���ʹ�ú��������еġ�student��
�滻Ϊ��teacher����
*/
print upper('china')
print lower('MACHINE')
print ltrim('  machine  ')+'china'+'press'
print rtrim('  machine  ')+'china'+'press'
print replace('  machine  ',' ','')+'china'+'press'
print len('I am a student.')
print replace('I am a student.','student','teacher')
/*1������ϵͳ��ǰ���ڲ���������ʽ���ص�ǰ���ڵ���ݡ��·ݡ��ռ����ȣ�
2�����ظ������ڡ�2006-2-21���뵱ǰ��������������������������
3������ǰ����ת��Ϊ�������ڸ�ʽ���
 (4) ϵͳ������Ԫ���ݺ�����ʹ��
1����ʾ����ʹ�õ��û��������ݿ�����
2�����ص�ǰ������ʶ���������ơ�
*/
declare @now datetime
select @now=GETDATE()
select @now as ����, year(@now) as ��,MONTH(@now) as ��,DAY(@now) as ��
,����=case
when MONTH(@now)>0 and MONTH(@now)<4 then 1
when MONTH(@now)>3 and MONTH(@now)<7 then 2
when MONTH(@now)>6 and MONTH(@now)<10 then 3
when MONTH(@now)>9 and MONTH(@now)<13 then 4
end
go
/*2�����ظ������ڡ�2006-2-21���뵱ǰ��������������������������

3������ǰ����ת��Ϊ�������ڸ�ʽ���
*/

declare @now datetime,@old datetime
select @now=GETDATE() ,@old='2006-2-21'
select DATEDIFF(day,@old,@now) as ����,DATEDIFF(MONTH,@old,@now) 
as ����,DATEDIFF(YEAR,@old,@now) as ����
, CONVERT(varchar(60),@now,101) 
as ����ʱ��
/* (4) ϵͳ������Ԫ���ݺ�����ʹ��
1����ʾ����ʹ�õ��û��������ݿ�����
2�����ص�ǰ������ʶ���������ơ�
*/
SP_HELPUSER 
Select Name From Master..SysDataBases 
Where DbId=(Select Dbid From Master..SysProcesses Where Spid = @@spid)
print '��ǰ��������'
print host_name()
print '��ǰ������ʶ��'
print host_id()
/*(1)	 ��COMPANY���ݿ��У����ǽ�Ա���Ĺ���ˮƽ��Ϊ���࣬������С��30000
Ϊ�͹��ʣ����ʴ��ڵ���30000��С��50000Ϊ�еȹ��ʣ����ʴ��ڵ���50000Ϊ�߹��ʡ�
����ʾ����Ա�������������Ӧ�Ĺ���ˮƽ��*/
select fname ,salary,����ˮƽ=
case
when salary<30000 then '�͹���'
when salary<50000 and SALARY>=30000 then '�й���'
when salary>=50000 then '�߹���'
end 
from employee
--(2)	 ��Transact��SQL���Ա�д�������1��100֮�������ܱ�7�����������ܺ͡�

declare @i int ,@sum int
set @i=1;
while(@i<101)
begin
if (@i%7=0)
begin
set @sum=@i+@sum
end
set @i=@i+1
end
print @sum
select @sum as '1��100֮�������ܱ�7�����������ܺ�'
go
declare @i int,@j int,@k int
set @i=1
set @j=0
set @k=0
while @i<100
begin
if @i % 7 =0
begin
set @j=@j+1
set @k=@k+@j
end
set @i=@i+1
end
select 'num=',@j,' sum=',@k
go
declare @S smallint,@I smallint,@NUMS smallint
    set @S=0 --�ܺ�
    set @I=1  --��1��ʼ  
    while(@I<=100) --ѭ��
    begin
        if(@I%7=0)
        begin
            set @S=@S+@I  --�ܺ� --��@Iĳ��������ʱ�����Ǽ�����������Щ�����ܺ�
        end
        set @I=@I+1 --ѭ����ֵ
    end
    print @S  