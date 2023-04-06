create table IssueReturnBook(
ID int NOT NULL IDENTITY(1,1) primary key,
EnrollID varchar(250) not null,
Member_Name varchar(250) not null,
Member_Contact bigint not null,
Member_Email varchar(250) not null,
Book_Name varchar(250) not null,
Book_Issue_Date varchar(250) not null,
Book_Return_Date varchar(250) not null
)



select * from IssueReturnBook



--UPDATE IssueReturnBook SET Book_Return_Date='05 March 2023' where id = 7;
--UPDATE IssueReturnBook SET Book_Return_Date='01 March 2023' where id = 14;
--UPDATE IssueReturnBook SET Book_Return_Date='01 March 2023' where id = 10;

