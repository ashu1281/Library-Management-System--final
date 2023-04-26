CREATE TABLE IssueReturnBook(
  ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
  MemberID int NOT NULL,
  BookID int NOT NULL,
  Book_Issue_Date date not null,
  Book_Return_Date date null,
  FOREIGN KEY (MemberID) REFERENCES NewMember(ID),
  FOREIGN KEY (BookID) REFERENCES NewBook(bId),
);

DROP TABLE dbo.IssueReturnBook

select * from IssueReturnBook

ALTER TABLE IssueReturnBook
DROP CONSTRAINT MemberID;



--UPDATE IssueReturnBook SET Book_Return_Date='05 March 2023' where id = 7;
--UPDATE IssueReturnBook SET Book_Return_Date='01 March 2023' where id = 14;
--UPDATE IssueReturnBook SET Book_Return_Date='01 March 2023' where id = 10;

