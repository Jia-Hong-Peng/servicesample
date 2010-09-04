

USE master;
GO
IF DB_ID (N'ServiceSample') IS NOT NULL
DROP DATABASE ServiceSample;
GO
-- Get the SQL Server data path
DECLARE @data_path nvarchar(256);
DECLARE @db_name nvarchar(200);
/*
SET @data_path = (SELECT SUBSTRING(physical_name, 1, CHARINDEX(N'master.mdf', LOWER(physical_name)) - 1)
                  FROM master.sys.master_files
                  WHERE database_id = 1 AND file_id = 1);
*/

SET @data_path = 'd:\Data\';
set @db_name = 'ServiceSample';

-- execute the CREATE DATABASE statement 
EXECUTE ('CREATE DATABASE ' + @db_name + ' 
ON 
( NAME = ' + @db_name + '_dat,
    FILENAME = '''+ @data_path + @db_name + '.mdf''
 )
LOG ON
( NAME = ' + @db_name + '_log,
    FILENAME = '''+ @data_path + @db_name + '.ldf''
 )'
);
GO


--create database ServiceSample3;

--go

use ServiceSample;

-- drop table Users

create table Users 
(uid varchar(50) , password varchar(20), primary key(uid) )

create table user_info 
(uid varchar(50) , username varchar(50), primary key(uid) )


insert into Users
values ('tkli', '123')

insert into user_info
values ('tkli', '���W��')

create table Functions
(fid varchar(50), title varchar(100), prefix varchar(50), classname varchar(50), primary key(fid))

insert into Functions values ('Default', '����', '', 'Default')
insert into Functions values ('Function1', '�\��1', '', 'Function1')
insert into Functions values ('Function2', '�\��2', '', 'Function2')
insert into Functions values ('Function3', '�\��3', '', 'Function3')
insert into Functions values ('Edit', '�s��', '', 'Edit')
insert into Functions values ('Insert', '�s�W', '', 'Insert')
insert into Functions values ('Query', '�d��', '', 'Query')
insert into Functions values ('Update', '��s', '', 'Update')


create table AccessGroup
(gid varchar(20), title varchar(50), primary key(gid))

insert into AccessGroup values ('admin', '�޲z��')
insert into AccessGroup values ('teacher', '�Ѯv')



create table AccessGroupMember
(gid varchar(20), pid varchar(50), isOpen varchar(1), primary key(gid, pid))

insert into AccessGroupMember values ('admin', 'tkli', 'y')


create table AccessGroupRight
(gid varchar(20), fid varchar(50), isOpen varchar(1), primary key(gid, fid))

insert into AccessGroupRight values ('admin', 'Default', 'y')
insert into AccessGroupRight values ('admin', 'Function1', 'y')
insert into AccessGroupRight values ('admin', 'Function2', 'y')
insert into AccessGroupRight values ('admin', 'Function3', 'y')
insert into AccessGroupRight values ('admin', 'Edit', 'y')
insert into AccessGroupRight values ('admin', 'Insert', 'y')
insert into AccessGroupRight values ('admin', 'Query', 'y')
insert into AccessGroupRight values ('admin', 'Update', 'y')


create table AuthenticateIP
(ip varchar(20), uid varchar(50), startdate datetime, enddate datetime, isOpen varchar(1), primary key(ip))

insert into AuthenticateIP
values ('127.0.0.1', 'admin', '20070101', '21000101', 'y')


create table sampleTable
(bookid varchar(20), title varchar(100), auther varchar(50), publisher varchar(20), bookyear varchar(4), price int, primary key(bookid))


go

--�ˬd �@�� user �Ҧ� �v������k
create procedure checkRight 
	@uid varchar(50),
	@classname varchar(50)
as
select classname from users a
join AccessGroupMember b on a.uid = b.pid and b.isOpen='y' --�ѩ�|�� �ޤJ position�A���Ȯɥ� uid �N�� pid
join AccessGroupRight c on b.gid = c.gid and c.isOpen='y'
join Functions d on c.fid = d.fid
where a.uid = @uid and d.prefix+d.classname=@classname

go

--�ҡG
checkRight 'tkli', 'Default'

go

checkRight 'tkli', 'Function2'

go




