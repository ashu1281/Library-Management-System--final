create table NewBook(
bId int NOT NULL IDENTITY(1,1) primary key,
bName varchar(250) not null,
bAuthor varchar(250) not null,
bPubl varchar(250) not null,
bPurDate varchar(250) not null,
bPrice varchar(250) not null,
bQuan bigint not null
)


--insert into NewBook (bName, bAuthor, bPubl, bPubDate, bPrice, bQuan) values ('OOPs', 'Jk Singh Kumar', '', '');
select * from NewBook
