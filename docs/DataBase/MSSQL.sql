/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2011-7-7 11:08:06                            */
/*==============================================================*/


if exists (select 1
            from  sysindexes
           where  id    = object_id('"File"')
            and   name  = 'OwnFile_FK'
            and   indid > 0
            and   indid < 255)
   drop index "File".OwnFile_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"File"')
            and   type = 'U')
   drop table "File"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('FileServer')
            and   type = 'U')
   drop table FileServer
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Friend')
            and   type = 'U')
   drop table Friend
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ShareInfo')
            and   type = 'U')
   drop table ShareInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Tag')
            and   type = 'U')
   drop table Tag
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('"User"')
            and   name  = 'OwnDir_FK'
            and   indid > 0
            and   indid < 255)
   drop index "User".OwnDir_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"User"')
            and   type = 'U')
   drop table "User"
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Dirtory')
            and   name  = 'OwnSubDir_FK'
            and   indid > 0
            and   indid < 255)
   drop index Dirtory.OwnSubDir_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Dirtory')
            and   name  = 'OwnDir2_FK'
            and   indid > 0
            and   indid < 255)
   drop index Dirtory.OwnDir2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Dirtory')
            and   type = 'U')
   drop table Dirtory
go

/*==============================================================*/
/* Table: "File"                                                */
/*==============================================================*/
create table "File" (
   FId                  int                  not null,
   DirId                int                  null,
   FName                varchar(50)          null,
   FDate                datetime             null,
   FSize                int                  null,
   constraint PK_FILE primary key nonclustered (FId)
)
go

/*==============================================================*/
/* Index: OwnFile_FK                                            */
/*==============================================================*/
create index OwnFile_FK on "File" (
DirId ASC
)
go

/*==============================================================*/
/* Table: FileServer                                            */
/*==============================================================*/
create table FileServer (
   FSHost               varchar(100)         not null,
   FSDirtory            varchar(50)          null,
   FSSize               bigint               null,
   FSValidSize          bigint               null,
   constraint PK_FILESERVER primary key nonclustered (FSHost)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '存储文件服务器配置信息',
   'user', @CurrentUser, 'table', 'FileServer'
go

/*==============================================================*/
/* Table: Friend                                                */
/*==============================================================*/
create table Friend (
   FrOwnerId            int                  not null,
   FrFriendId           int                  not null,
   constraint PK_FRIEND primary key nonclustered (FrFriendId, FrOwnerId)
)
go

/*==============================================================*/
/* Table: ShareInfo                                             */
/*==============================================================*/
create table ShareInfo (
   SId                  int                  not null,
   SSender              int                  null,
   SReceive             int                  null,
   SDate                datetime             null,
   constraint PK_SHAREINFO primary key nonclustered (SId)
)
go

/*==============================================================*/
/* Table: Tag                                                   */
/*==============================================================*/
create table Tag (
   TName                varchar(20)          not null,
   TUserId              int                  not null,
   TFileId              int                  not null,
   constraint PK_TAG primary key nonclustered (TName, TUserId, TFileId)
)
go

declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '文件标签',
   'user', @CurrentUser, 'table', 'Tag'
go

/*==============================================================*/
/* Table: "User"                                                */
/*==============================================================*/
create table "User" (
   UId                  int                  not null,
   DirId                int                  null,
   ULiginName           varchar(20)          not null unique,
   URealName            varchar(20)          null,
   UEmail               varchar(50)          null,
   UPassWord            varchar(128)         null,
   constraint PK_USER primary key nonclustered (UId)
)
go

/*==============================================================*/
/* Index: OwnDir_FK                                             */
/*==============================================================*/
create index OwnDir_FK on "User" (
DirId ASC
)
go

/*==============================================================*/
/* Table: Dirtory                                                    */
/*==============================================================*/
create table Dirtory (
   DirId                int                  not null,
   ParentDirId             int                 null,
   UId                  int                  not null,
   DirName              varchar(50)          null,
   DirDesc              varchar(100)         null,
   constraint PK_Dirtory primary key nonclustered (DirId),
)
go

/*==============================================================*/
/* Index: OwnDir2_FK                                            */
/*==============================================================*/
create index OwnDir2_FK on Dirtory (
UId ASC
)
go

/*==============================================================*/
/* Index: OwnSubDir_FK                                          */
/*==============================================================*/
create index OwnSubDir_FK on Dirtory (
DirId ASC
)
go

