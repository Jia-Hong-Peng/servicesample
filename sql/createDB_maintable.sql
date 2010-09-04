!


use Homework

go


create table Homework
(hid varchar(50), cid varchar(50), title varchar(200), type varchar(50), description varchar(1000), opendate datetime, finaldate datetime, closedate datetime, primary key (hid, cid) )
-- opendate �}���Afinaldate �i��s�W�Ǫ������Aclosedate �w�W�ǧ@�~�i�[�ݪ��̫����
-- type : 'no upload', '1-upload', 'm-upload' : �L�W�ǡA�W�Ǥ@���ɮסA�W�Ǧh����


create table Course
(cid varchar(50), title varchar(200),  primary key (cid))


create table HomeworkSubmit
(hid varchar(50), uid varchar(50), updatetime datetime, accessIP varchar(50), accessComputerName varchar(50), primary key (hid, uid))

create table HomeworkContent
(hid varchar(50), uid varchar(50), content varchar(2000), primary key (hid, uid))

create table HomeworkUpload
(hid varchar(50), uid varchar(50), fileIndex int, filename varchar(200), primary key (hid, uid))
-- filename ���t ���|

create table HomeworkUploadLocation
(uid varchar(50), cid varchar(50), location varchar(500), isLocal char(1), primary key (uid, cid))
-- �@�Ӿǥͪ��@�ӽҵ{ �@�Ӹ�Ƨ�
-- location �Y ���� local ��(isLocal = 'n') �ݥ]�t �D���� domain name �� ip �A�_�h(isLocal == 'y')�A��� �۹���|(�Y �P���A�����w�]���s����|�U ���l�ؿ�)

create table CourseAccessGroup
(cid varchar(50), gid varchar(20), primary key(cid, gid))
-- for �@�~�W�Ǩt�� �s�w�� �s���s�աA�ѩ� �U�ҵ{�i��U�ۦ��s���s�աA�ҥH �s���v�� �O�� �U�ҵ{���s���s��)





