CREATE TABLE Address (
ID int IDENTITY PRIMARY KEY,
AddrTypeID varchar(1) NOT Null,
AddrLn1 varchar(90) NOT NULL,
AddrLn2 varchar(90),
City varchar(30) NOT NULL,
State varchar(2) NOT NULL,
Zip varchar(15) NOT NULL,
InActive bit,
InActiveDate date,
CONSTRAINT FK_Address_AddressType FOREIGN KEY (AddrTypeID) REFERENCES AddrType(ID))