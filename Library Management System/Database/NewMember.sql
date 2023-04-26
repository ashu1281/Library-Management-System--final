create table NewMember(
mID INT NOT NULL IDENTITY(1001,1) primary key,
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
Drop Table NewMember

INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Tanuksha Chaudhary', '9876543210', 'tanu@gmail.com', 'Maharashtra', 'Dhule', 400001, '123', 'Max');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Priya Patel', '9988776655', 'priyapatel@yahoo.com', 'Gujarat', 'Ahmedabad', 380001, '123', 'Buddy');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Rajesh Singh', '9444400000', 'rajeshsingh@hotmail.com', 'Uttar Pradesh', 'Lucknow', 226001, '123', 'Charlie');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Kavita Gupta', '9111122222', 'kavitagupta@gmail.com', 'Haryana', 'Gurgaon', 122001, '123', 'Lucy');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Vikas Verma', '9995550000', 'vikasverma@gmail.com', 'Karnataka', 'Bengaluru', 560001, '123', 'Rocky');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Anjali Desai', '9888877777', 'anjalidesai@yahoo.com', 'Gujarat', 'Surat', 395001, '123', 'Lola');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Sanjay Gupta', '9777744444', 'sanjaygupta@gmail.com', 'Madhya Pradesh', 'Bhopal', 462001, '123', 'Rosie');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Neha Singh', '9666611111', 'nehasingh@gmail.com', 'Maharashtra', 'Pune', 411001, '123', 'Simba');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Ajay Kumar', '9555522222', 'ajaykumar@yahoo.com', 'Kerala', 'Kochi', 682001, '123', 'Maximus');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Swati Patel', '9444400000', 'swatipatel@hotmail.com', 'Gujarat', 'Vadodara', 390001, '123', 'Moti');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Alok Sharma', '9333300000', 'aloksharma@gmail.com', 'Uttar Pradesh', 'Kanpur', 208001, '123', 'Daisy');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Sneha Dubey', '9222211111', 'snehadubey@yahoo.com', 'Madhya Pradesh', 'Indore', 452001, '123', 'Bella');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Gaurav Singh', '9111155555', 'gauravsingh@hotmail.com', 'Rajasthan', 'Jaipur', 302001, '123', 'Milo');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Shweta Gupta', '9000090000', 'shwetagupta@gmail.com', 'West Bengal', 'Kolkata', 700001, '123', 'Buddy');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Rahul Sharma', '9888888888', 'rahulsharma@yahoo.com', 'Delhi', 'New Delhi', 110001, '123', 'Charlie');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Nidhi Patel', '9777777777', 'nidhipatel@gmail.com', 'Gujarat', 'Rajkot', 360001, '123', 'Lucy');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Anil Singh', '9666666666', 'anilsingh@hotmail.com', 'Uttar Pradesh', 'Allahabad', 211001, '123', 'Rocky');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Manisha Gupta', '9555555555', 'manishagupta@yahoo.com', 'Maharashtra', 'Nagpur', 440001, '123', 'Lola');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Rakesh Kumar', '9444433333', 'rakeshkumar@gmail.com', 'Karnataka', 'Mysuru', 570001, '123', 'Rosie');
INSERT INTO NewMember (mName, mContact, mEmail, mState, mCity, mPinCode, mPassword, mPetName) VALUES ('Kavita Singh', '9333366666', 'kavtasingh@hotmail.com', 'Haryana', 'Faridabad', 121001, '123', 'Tommy');