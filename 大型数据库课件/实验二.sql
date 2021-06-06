execute sp_helpindex employee
select * from sysindexes where id=OBJECT_ID('employee')
dbcc traceon(3604)
dbcc extentinfo(company_Gushuangquan,employee)
dbcc page (company_Gushuangquan,1,22,1)
/* ①为员工表创建一个索引名为emp_ssn的唯一性非聚集索引，
索引关键字是SSN，填充因子80 % 。*/
create unique nonclustered index emp_ssn
 on employee (ssn)
 with(pad_index=on,fillfactor=80)
execute sp_rename 'employee.emp_ssn','员工表_员工号','index'
/*③为员工参与项目表创建一个索引名为“员工_项目_index”的非聚集复合索引
，索引关键字为“员工号”，升序，“项目编号”，降序，填充因子50%。*/
select * from employee
create nonclustered index 员工_项目_index
on employee (ssn ,dno desc)
with(pad_index=on,fillfactor=50)
drop index employee.员工表_员工号,employee.员工_项目_index