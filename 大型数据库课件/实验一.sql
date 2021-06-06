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
/*1）分别将字符串“china”、“MACHINE”转换成大写、小写字母；
2）去掉字符串“  machine  ”左边的空格，再与“china”及“press“连接起来；
3）去掉字符串“  machine  ”右边的空格，再与“china”及“press“连接起来；
4）去掉字符串“  machine  ”左右两边的空格，再与“china”及“press“连接起来；
5）用函数计算字符串‘I am a student.’的长度，并使用函数将其中的“student”
替换为“teacher”。
*/
print upper('china')
print lower('MACHINE')
print ltrim('  machine  ')+'china'+'press'
print rtrim('  machine  ')+'china'+'press'
print replace('  machine  ',' ','')+'china'+'press'
print len('I am a student.')
print replace('I am a student.','student','teacher')
/*1）返回系统当前日期并以整数形式返回当前日期的年份、月份、日及季度；
2）返回给定日期“2006-2-21”与当前日期相差的天数、月数及年数。
3）将当前日期转换为美国日期格式输出
 (4) 系统函数与元数据函数的使用
1）显示正在使用的用户名、数据库名；
2）返回当前主机标识及主机名称。
*/
declare @now datetime
select @now=GETDATE()
select @now as 日期, year(@now) as 年,MONTH(@now) as 月,DAY(@now) as 日
,季度=case
when MONTH(@now)>0 and MONTH(@now)<4 then 1
when MONTH(@now)>3 and MONTH(@now)<7 then 2
when MONTH(@now)>6 and MONTH(@now)<10 then 3
when MONTH(@now)>9 and MONTH(@now)<13 then 4
end
go
/*2）返回给定日期“2006-2-21”与当前日期相差的天数、月数及年数。

3）将当前日期转换为美国日期格式输出
*/

declare @now datetime,@old datetime
select @now=GETDATE() ,@old='2006-2-21'
select DATEDIFF(day,@old,@now) as 天数,DATEDIFF(MONTH,@old,@now) 
as 月数,DATEDIFF(YEAR,@old,@now) as 年数
, CONVERT(varchar(60),@now,101) 
as 美国时间
/* (4) 系统函数与元数据函数的使用
1）显示正在使用的用户名、数据库名；
2）返回当前主机标识及主机名称。
*/
SP_HELPUSER 
Select Name From Master..SysDataBases 
Where DbId=(Select Dbid From Master..SysProcesses Where Spid = @@spid)
print '当前主机名称'
print host_name()
print '当前主机标识号'
print host_id()
/*(1)	 在COMPANY数据库中，我们将员工的工资水平分为三类，即工资小于30000
为低工资，工资大于等于30000且小于50000为中等工资，工资大于等于50000为高工资。
请显示所有员工的姓名及其对应的工资水平。*/
select fname ,salary,工资水平=
case
when salary<30000 then '低工资'
when salary<50000 and SALARY>=30000 then '中工资'
when salary>=50000 then '高工资'
end 
from employee
--(2)	 用Transact－SQL语言编写程序计算1～100之间所有能被7整除的数的总和。

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
select @sum as '1～100之间所有能被7整除的数的总和'
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
    set @S=0 --总和
    set @I=1  --从1开始  
    while(@I<=100) --循环
    begin
        if(@I%7=0)
        begin
            set @S=@S+@I  --总和 --当@I某个数符合时，就是加它，即得这些数的总和
        end
        set @I=@I+1 --循环加值
    end
    print @S  