CREATE TABLE Email (
ID int IDENTITY PRIMARY KEY,
Addr varchar(90) NOT NULL,
InActive bit,
InActiveDate date)