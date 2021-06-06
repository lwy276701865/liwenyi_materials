/*
请问在SQL SERVER中，定长记录和变长记录中的NULL值是否占用存储空间？请用实验证明你的结论，并附上实验过程中使用的命令代码
、截图、相关文字说明、作业心得体会等。

(请直接上传WORD文档。实验中所用的数据库、表和字段名等都要以_xxxxxx结尾，即你的名字拼音全拼，且数据库中数据
至少要有1列字符串数据，内容为你的姓名拼音全拼)*/

select * from syscolumns where id = OBJECT_ID('course')
insert into mytable_liwenyi values('liwenyi','aaa',null,null,'ccc')
select * from mytable_liwenyi
dbcc traceon(3604)
dbcc extentinfo(mydatabase_liwenyi,mytable_liwenyi)
dbcc page(mydatabase_liwenyi,1,78,1)






