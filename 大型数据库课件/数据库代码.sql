/*
������SQL SERVER�У�������¼�ͱ䳤��¼�е�NULLֵ�Ƿ�ռ�ô洢�ռ䣿����ʵ��֤����Ľ��ۣ�������ʵ�������ʹ�õ��������
����ͼ���������˵������ҵ�ĵ����ȡ�

(��ֱ���ϴ�WORD�ĵ���ʵ�������õ����ݿ⡢����ֶ����ȶ�Ҫ��_xxxxxx��β�����������ƴ��ȫƴ�������ݿ�������
����Ҫ��1���ַ������ݣ�����Ϊ�������ƴ��ȫƴ)*/

select * from syscolumns where id = OBJECT_ID('course')
insert into mytable_liwenyi values('liwenyi','aaa',null,null,'ccc')
select * from mytable_liwenyi
dbcc traceon(3604)
dbcc extentinfo(mydatabase_liwenyi,mytable_liwenyi)
dbcc page(mydatabase_liwenyi,1,78,1)






