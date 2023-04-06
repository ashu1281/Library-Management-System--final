create table loginTable(
id int NOT NULL IDENTITY(1,1) primary key,
UserName varchar(250) not null,
Pass varchar(250) not null

)

select * from loginTable

insert into loginTable (UserName,Pass) values ('shubham','123');

insert into loginTable (UserName,Pass) values ('shreya','123');

