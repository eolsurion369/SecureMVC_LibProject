CREATE TABLE JuvenileMember (
ID int IDENTITY,
AdultID int NOT NULL,
FirstName varchar(30) NOT NULL, 
LastName varchar(30) NOT NULL, 
MidInit varchar(1),
Suffix varchar(2),
Birthdate datetime NOT NULL,
InActive bit,
InActiveDate date,
CONSTRAINT PK_JuvenileMember PRIMARY KEY (ID, AdultID),
CONSTRAINT FK_JuvenileMember_AdultMember FOREIGN KEY (AdultID) REFERENCES AdultMember(ID)
)