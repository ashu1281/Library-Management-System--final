create table NewBook(
bId int NOT NULL IDENTITY(1,1) primary key,
bName varchar(250) not null,
bAuthor varchar(250) not null,
bPubl varchar(250) not null,
bPurDate varchar(250) not null,
bPrice varchar(250) not null,
bQuan bigint not null
)


select * from NewBook

INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('The Pragmatic Programmer', 'Andrew Hunt, David Thomas', 'Addison-Wesley Professional', '01/01/2023', '999', 5);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Clean Code', 'Robert C. Martin', 'Prentice Hall', '02/01/2023', '899', 7);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Code Complete', 'Steve McConnell', 'Microsoft Press', '03/01/2023', '1099', 10);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Design Patterns', 'Erich Gamma, Richard Helm, Ralph Johnson, John Vlissides', 'Addison-Wesley Professional', '04/01/2023', '1299', 6);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Head First Java', 'Kathy Sierra, Bert Bates', 'O''Reilly Media', '05/01/2023', '899', 20);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Head First Design Patterns', 'Eric Freeman, Elisabeth Robson, Bert Bates, Kathy Sierra', 'O''Reilly Media', '06/01/2023', '1199', 15);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('JavaScript: The Good Parts', 'Douglas Crockford', 'O''Reilly Media', '07/01/2023', '799', 8);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Learning Python', 'Mark Lutz', 'O''Reilly Media', '08/01/2023', '999', 17);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Refactoring', 'Martin Fowler', 'Addison-Wesley Professional', '09/01/2023', '899', 25);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('The C Programming Language', 'Brian Kernighan, Dennis Ritchie', 'Prentice Hall', '10/01/2023', '699', 10);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('The Linux Programming Interface', 'Michael Kerrisk', 'No Starch Press', '11/01/2023', '1499', 10);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Effective Java', 'Joshua Bloch', 'Addison-Wesley Professional', '12/01/2023', '1199', 60);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Programming Pearls', 'Jon Bentley', 'Addison-Wesley Professional', '13/01/2023', '999', 70);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('The Mythical Man-Month', 'Frederick P. Brooks Jr.', 'Addison-Wesley Professional', '14/01/2023', '799', 80);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Head First Servlets and JSP', 'Bryan Basham, Kathy Sierra, Bert Bates', 'O''Reilly Media', '15/01/2023', '1199', 50);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Cracking the Coding Interview', 'Gayle Laakmann McDowell', 'CareerCup', '16/01/2023', '899', 90);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Programming in C', 'Stephen G. Kochan', 'Addison-Wesley Professional', '17/01/2023', '699', 12);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Algorithms', 'Robert Sedgewick, Kevin Wayne', 'Addison-Wesley Professional', '18/01/2023', '1299', 40);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('The Art of Computer Programming', 'Donald E. Knuth', 'Addison-Wesley Professional', '19/01/2023', '1999', 30);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Effective Python', 'Brett Slatkin', 'Addison-Wesley Professional', '20/01/2023', '1099', 65);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Head First Python', 'Paul Barry', 'O''Reilly Media', '21/01/2023', '999', 75);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Programming Rust', 'Jim Blandy, Jason Orendorff', 'O''Reilly Media', '22/01/2023', '1299', 50);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Data Structures and Algorithms in Python', 'Michael T. Goodrich, Roberto Tamassia, Michael H. Goldwasser', 'Wiley', '23/01/2023', '1099', 70);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Code Complete', 'Steve McConnell', 'Microsoft Press', '24/01/2023', '1499', 40);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Introduction to Algorithms', 'Thomas H. Cormen, Charles E. Leiserson, Ronald L. Rivest, Clifford Stein', 'MIT Press', '25/01/2023', '1899', 30);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('C++ Primer', 'Stanley B. Lippman, Josée Lajoie, Barbara E. Moo', 'Addison-Wesley Professional', '26/01/2023', '1299', 50);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Programming in Java', 'Julia Case Bradley, Anita C. Millspaugh', 'McGraw-Hill Education', '27/01/2023', '999', 75);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Clean Code', 'Robert C. Martin', 'Prentice Hall', '28/01/2023', '1199', 60);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('JavaScript: The Good Parts', 'Douglas Crockford', 'Yahoo! Press', '29/01/2023', '899', 90);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Learning Python', 'Mark Lutz', 'O''Reilly Media', '30/01/2023', '1099', 65);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('The C Programming Language', 'Brian W. Kernighan, Dennis M. Ritchie', 'Prentice Hall', '31/01/2023', '799', 80);
INSERT INTO NewBook (bName, bAuthor, bPubl, bPurDate, bPrice, bQuan) VALUES ('Python Crash Course', 'Eric Matthes', 'No Starch Press', '01/02/2022', '999', 70);