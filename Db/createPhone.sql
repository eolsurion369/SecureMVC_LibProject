CREATE TABLE Phone (
ID int IDENTITY PRIMARY KEY,
PhoneTypeID varchar(1) NOT NULL,
Phone varchar(20) NOT NULL,
InActive bit,
InActiveDate date,
CONSTRAINT FK_Phone_PhoneType FOREIGN KEY (PhoneTypeID) REFERENCES PhoneType(ID))