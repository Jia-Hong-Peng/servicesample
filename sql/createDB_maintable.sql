!


use Homework

go


create table Homework
(hid varchar(50), cid varchar(50), title varchar(200), type varchar(50), description varchar(1000), opendate datetime, finaldate datetime, closedate datetime, primary key (hid, cid) )
-- opendate 開放日，finaldate 可更新上傳的期限，closedate 已上傳作業可觀看的最後期限
-- type : 'no upload', '1-upload', 'm-upload' : 無上傳，上傳一個檔案，上傳多個檔


create table Course
(cid varchar(50), title varchar(200),  primary key (cid))


create table HomeworkSubmit
(hid varchar(50), uid varchar(50), updatetime datetime, accessIP varchar(50), accessComputerName varchar(50), primary key (hid, uid))

create table HomeworkContent
(hid varchar(50), uid varchar(50), content varchar(2000), primary key (hid, uid))

create table HomeworkUpload
(hid varchar(50), uid varchar(50), fileIndex int, filename varchar(200), primary key (hid, uid))
-- filename 不含 路徑

create table HomeworkUploadLocation
(uid varchar(50), cid varchar(50), location varchar(500), isLocal char(1), primary key (uid, cid))
-- 一個學生的一個課程 一個資料夾
-- location 若 不為 local 時(isLocal = 'n') 需包含 主機的 domain name 或 ip ，否則(isLocal == 'y')，表示 相對路徑(即 同伺服器內預設的存放路徑下 的子目錄)

create table CourseAccessGroup
(cid varchar(50), gid varchar(20), primary key(cid, gid))
-- for 作業上傳系統 製定的 存取群組，由於 各課程可能各自有存取群組，所以 存取權限 是依 各課程的存取群組)





