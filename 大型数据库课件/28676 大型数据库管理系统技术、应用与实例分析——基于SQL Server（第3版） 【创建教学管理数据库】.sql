--������ѧ�������ݿ�
CREATE DATABASE ��ѧ����
GO

--������
USE ��ѧ����
GO
IF EXISTS(SELECT * FROM sysobjects WHERE name='ѡ�α�' AND xtype='U') 
  DROP TABLE ѡ�α�
IF EXISTS(SELECT * FROM sysobjects WHERE name='���α�' AND xtype='U') 
  DROP TABLE ���α�
IF EXISTS(SELECT * FROM sysobjects WHERE name='ѧ����' AND xtype='U') 
  DROP TABLE ѧ����
IF EXISTS(SELECT * FROM sysobjects WHERE name='��ʦ��' AND xtype='U') 
  DROP TABLE ��ʦ��
IF EXISTS(SELECT * FROM sysobjects WHERE name='�γ̱�' AND xtype='U') 
  DROP TABLE �γ̱�

CREATE TABLE ѧ����
(
  ѧ�� CHAR(7) NOT NULL,
  ���֤�� CHAR(18) NOT NULL,
  ���� CHAR(8) NOT NULL,
  �Ա� CHAR(2) DEFAULT '��',
  �ƶ��绰 CHAR(11),
  ���� VARCHAR(10),
  רҵ VARCHAR(20) NOT NULL,
  ����Ժϵ VARCHAR(20) NOT NULL,
  �ۼ�ѧ�� INT,
  CONSTRAINT PK_ѧ����_ѧ�� PRIMARY KEY(ѧ��),
  CONSTRAINT CK_ѧ����_ѧ�� CHECK(ѧ�� LIKE 'S[0-9][0-9][0-9][0-9][0-9][0-9]')
)
CREATE TABLE �γ̱�
(
  �κ� CHAR(6) NOT NULL,
  ���� VARCHAR(30) NOT NULL,
  ѧ�� INT CHECK(ѧ��>=1 and ѧ��<=5),
  �̲����� VARCHAR(30),
  ������ CHAR(8),
  ������ VARCHAR(20),
  ��� VARCHAR(20),
  ���� money,
  CONSTRAINT PK_�γ̱�_�κ� PRIMARY KEY(�κ�),
  CONSTRAINT CK_�γ̱�_�κ� CHECK(�κ� LIKE 'C[0-9][0-9][0-9][0-9][0-9]')
)

CREATE TABLE ��ʦ��
(
  ���� CHAR(6) NOT NULL,
  ���֤�� CHAR(18) NOT NULL,
  ���� CHAR(8) NOT NULL,
  �Ա� CHAR(2) DEFAULT '��',
  �ƶ��绰 CHAR(11),
  ���� VARCHAR(10),
  ����Ժϵ VARCHAR(20) NOT NULL,
  ְ�� CHAR(6),
  ������ CHAR(6),
  CONSTRAINT PK_��ʦ��_���� PRIMARY KEY(����),
  CONSTRAINT CK_��ʦ��_���� CHECK(���� LIKE 'T[0-9][0-9][0-9][0-9][0-9]')
)

CREATE TABLE ���α�
(
  ���κ� CHAR(6) NOT NULL,
  �κ� CHAR(6) NOT NULL,
  ���� CHAR(6) NOT NULL,
  ���εص� CHAR(6),
  ����ѧ�� CHAR(9),
  ����ѧ�� INT ,
  �������� INT DEFAULT 17,
  ����ʱ�� VARCHAR(20),
  ��ѡ���� INT,
  ��ѡ���� INT,
  CONSTRAINT PK_���α�_���κ� PRIMARY KEY(���κ�),
  CONSTRAINT FK_���α�_���� FOREIGN KEY(����) REFERENCES ��ʦ��(����)
  ON UPDATE CASCADE ON DELETE CASCADE,
  CONSTRAINT FK_���α�_�κ� FOREIGN KEY(�κ�) REFERENCES �γ̱�(�κ�)
  ON UPDATE CASCADE ON DELETE CASCADE,
  CONSTRAINT CK_���α�_���κ� CHECK(���κ� LIKE '[0-9][0-9][0-9][0-9][0-9][0-9]'),
  CONSTRAINT CK_���α�_���� CHECK(���� LIKE 'T[0-9][0-9][0-9][0-9][0-9]'),
  CONSTRAINT CK_���α�_�κ� CHECK(�κ� LIKE 'C[0-9][0-9][0-9][0-9][0-9]')
)

CREATE TABLE ѡ�α�
(
  ѧ�� CHAR(7) NOT NULL,
  ���κ� CHAR(6) NOT NULL,
  �ɼ� INT CHECK(�ɼ�>=0 and �ɼ�<=100),
  CONSTRAINT PK_ѡ�α�_ѧ��_���κ� PRIMARY KEY(ѧ��,���κ�),
  CONSTRAINT FK_ѡ�α�_ѧ�� FOREIGN KEY(ѧ��) REFERENCES ѧ����(ѧ��)
  ON UPDATE CASCADE ON DELETE CASCADE,
  CONSTRAINT FK_ѡ�α�_���κ� FOREIGN KEY(���κ�) REFERENCES ���α�(���κ�)
  ON UPDATE CASCADE ON DELETE CASCADE,
  CONSTRAINT CK_ѡ�α�_ѧ�� CHECK(ѧ�� LIKE 'S[0-9][0-9][0-9][0-9][0-9][0-9]'),
  CONSTRAINT CK_ѡ�α�_���κ� CHECK(���κ� LIKE '[0-9][0-9][0-9][0-9][0-9][0-9]')
)

--����ԭʼ����
DECLARE @tb_exist INT
SET @tb_exist=0
IF EXISTS(SELECT * FROM sysobjects WHERE name='ѡ�α�' AND xtype='U') 
   SET @tb_exist=@tb_exist | 1
IF EXISTS(SELECT * FROM sysobjects WHERE name='���α�' AND xtype='U')
   SET @tb_exist=@tb_exist | 2
IF EXISTS(SELECT * FROM sysobjects WHERE name='ѧ����' AND xtype='U')
   SET @tb_exist=@tb_exist | 4
IF EXISTS(SELECT * FROM sysobjects WHERE name='�γ̱�' AND xtype='U')
   SET @tb_exist=@tb_exist | 8
IF EXISTS(SELECT * FROM sysobjects WHERE name='��ʦ��' AND xtype='U')
   SET @tb_exist=@tb_exist | 16
IF @tb_exist !=31 BEGIN  --��һЩ������
   PRINT '�������й�ϵ�����ڣ���˲���Ԫ��ʧ�ܣ�'
   IF (@tb_exist & 1) = 0 PRINT 'ѡ�α�'
   IF (@tb_exist & 2) = 0 PRINT '���α�'
   IF (@tb_exist & 4) = 0 PRINT 'ѧ����'
   IF (@tb_exist & 8) = 0 PRINT '�γ̱�'
   IF (@tb_exist & 16) = 0 PRINT '��ʦ��'
END
ELSE BEGIN  --���ű�����
   IF EXISTS(SELECT * FROM ѡ�α�) DELETE ѡ�α�
   IF EXISTS(SELECT * FROM ���α�) DELETE ���α�
   IF EXISTS(SELECT * FROM ѧ����) DELETE ѧ����
   IF EXISTS(SELECT * FROM �γ̱�) DELETE �γ̱�
   IF EXISTS(SELECT * FROM ��ʦ��) DELETE ��ʦ��
--ѧ�����������ݲ���
   INSERT INTO ѧ���� VALUES('S060101',  '******19880526***', '������', 
'��', '135***11', '����', '�����', '�ŵ�ѧԺ', 2)
   INSERT INTO ѧ���� VALUES('S060102',  '******19891001***', '��С��', 
'Ů', '131***11', '����', '�����', '�ŵ�ѧԺ', 2)
   INSERT INTO ѧ���� VALUES('S060103',  '******19871021***', '������', 
'��', '139***12', '����', '�����', '�ŵ�ѧԺ', 2)
   INSERT INTO ѧ���� VALUES('S060109',  '******19880511***', '������', 
'Ů', NULL, '����', '�����', '�ŵ�ѧԺ', NULL)
   INSERT INTO ѧ���� VALUES('S060110',  '******19880226***', '����ɽ', 
'��', '130***22', '̫ԭ', '�����', '�ŵ�ѧԺ', 2)
   INSERT INTO ѧ���� VALUES('S060201',  '******19880606***', '������', 
'��', '135***22', '����', '��Ϣ����', '�ŵ�ѧԺ', NULL)
   INSERT INTO ѧ���� VALUES('S060202',  '******19871226***', '������', 
'��', NULL, '��', '��Ϣ����', '�ŵ�ѧԺ', NULL)
   INSERT INTO ѧ���� VALUES('S060306',  '******19880115***', '��˫��', 
'Ů', '139***01', '����', '��������', '�ŵ�ѧԺ', NULL)
   INSERT INTO ѧ���� VALUES('S060308',  '******19890526***', '�ŵ���', 
'��', '130***12', '����', '��������', '�ŵ�ѧԺ', NULL)

--�γ̱��������ݲ���
   INSERT INTO �γ̱� VALUES('C01001', 'C++�������',2, 'C++������ƻ���', 
'�Ż���', '�ߵȽ���������', '7-04-005655-0', 17)
   INSERT INTO �γ̱� VALUES('C01002', '���ݽṹ',3, '���ݽṹ', 
NULL, NULL, NULL, NULL)
   INSERT INTO �γ̱� VALUES('C01003', '���ݿ�ԭ��', 3,'���ݿ�ϵͳ����', 
'��ʦ��', '�ߵȽ���������', '7-04-007494-X', NULL)
   INSERT INTO �γ̱� VALUES('C02001', '������Ϣϵͳ', 2,'������Ϣϵͳ�̳�', 
'Ҧ����', '�㽭��ѧ����������', '7-5341-2422-0', 38)
   INSERT INTO �γ̱� VALUES('C02002', 'ERPԭ��', 2,'ERPԭ�����ʵʩ', 
'�޺�', '���ӹ�ҵ������', '7-5053-8078-8', 38)
   INSERT INTO �γ̱� VALUES('C02003', '�����Ϣϵͳ',2, '�����Ϣϵͳ', 
'����', NULL, NULL, NULL)
   INSERT INTO �γ̱� VALUES('C03001', '��������', 2,'��������', NULL, 
NULL, NULL, NULL)

--��ʦ���������ݲ���
   INSERT INTO ��ʦ�� VALUES('T01001', '******19600526***', '������', 
'��', '139***88', '����', '����ѧԺ', '����', 'T01001')
   INSERT INTO ��ʦ�� VALUES('T01002', '******19721203***', '����', 
'Ů', '131***77', '����', '����ѧԺ', '��ʦ', 'T01001')
   INSERT INTO ��ʦ�� VALUES('T02001', '******19580517***', '����ΰ', 
'��', '135***66', '����', '�ŵ�ѧԺ', '����', 'T02001')
   INSERT INTO ��ʦ�� VALUES('T02002', '******19640520***', '������', 
'��', '137***55', '̫ԭ', '�ŵ�ѧԺ', '������', 'T02001')
   INSERT INTO ��ʦ�� VALUES('T02003', '******19740810***', '������', 
'��', '136***44', '����', '�ŵ�ѧԺ', '��ʦ', 'T02001')

--���α��������ݲ���
   INSERT INTO ���α� VALUES('010101', 'C01001', 'T02003', '1-202', 
 '2006-2007', '1', 18, '��һ(1,2)',30,4 )
   INSERT INTO ���α� VALUES('010201', 'C01002', 'T02001', '2-403', 
 '2006-2007', '2', 18, '����(3,4)',30,1 )
   INSERT INTO ���α� VALUES('010202', 'C01002', 'T02001', '2-203', 
 '2006-2007', '2', 18, '����(3,4)',45,0 )
   INSERT INTO ���α� VALUES('010301', 'C01003', 'T02002', '3-101', 
 '2007-2008', '1', 16, '�ܶ�(1,2,3)',20,2 )
   INSERT INTO ���α� VALUES('020101', 'C02001', 'T01001', '3-201', 
 '2007-2008', '2', 18, '����(3,4)',90,2 )
   INSERT INTO ���α� VALUES('020102', 'C02001', 'T01001', '3-201', 
 '2007-2008', '2', 18, '����(3,4)',50,1 )
   INSERT INTO ���α� VALUES('020201', 'C02002', 'T02001', '4-303', 
 '2008-2009', '1', 17, '����(1,2,3)',30,1 )
   INSERT INTO ���α� VALUES('020301', 'C02003', 'T01002', '4-102', 
 '2008-2009', '1', 9, '����(3)',70,1)
   INSERT INTO ���α� VALUES('020302', 'C02003', 'T01002', '4-204', 
 '2008-2009', '1', 18, '����(3,4)',30,0 )
   INSERT INTO ���α� VALUES('030101', 'C03001', 'T01001', '3-303', 
'2008-2009', '2', 18, '����(3,4)',45,1 )

--ѡ�α��������ݲ���
   INSERT INTO ѡ�α� VALUES('S060101', '010101', 90)
   INSERT INTO ѡ�α� VALUES('S060101', '010201', NULL)
   INSERT INTO ѡ�α� VALUES('S060101', '010301', NULL)
   INSERT INTO ѡ�α� VALUES('S060101', '020101', NULL)
   INSERT INTO ѡ�α� VALUES('S060101', '020201', NULL)
   INSERT INTO ѡ�α� VALUES('S060101', '020301', NULL)
   INSERT INTO ѡ�α� VALUES('S060101', '030101', NULL)
   INSERT INTO ѡ�α� VALUES('S060102', '010101', 93)
   INSERT INTO ѡ�α� VALUES('S060102', '010301', NULL)
   INSERT INTO ѡ�α� VALUES('S060102', '020102', NULL)
   INSERT INTO ѡ�α� VALUES('S060103', '010101', 85)
   INSERT INTO ѡ�α� VALUES('S060110', '010101', 88)
   INSERT INTO ѡ�α� VALUES('S060110', '010301', NULL)
   INSERT INTO ѡ�α� VALUES('S060201', '020101', NULL)
   INSERT INTO ѡ�α� VALUES('S060202', '010101', 75)
   INSERT INTO ѡ�α� VALUES('S060202', '020201', NULL)
END

