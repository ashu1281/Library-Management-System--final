create table NewMember(
ID int NOT NULL IDENTITY(1,1) primary key,
EnrollID AS 'UID-' + RIGHT('100' + CAST(ID AS VARCHAR(5)), 5) PERSISTED,
mName varchar(250) not null,
mContact varchar(250) not null,
mEmail varchar(250) not null,
mState varchar(250) not null,
mCity varchar(250) not null,
mPinCode bigint not null,
mPhoto IMAGE NULL,
mPassword VARCHAR (250) not NULL,
mPetName VARCHAR (250) not NULL
)



--mName, mContact, mEmail, mState, mCity, mPinCode
select * from NewMember

