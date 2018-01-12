CREATE TABLE AdultMemberAddress (
AdultID int NOT NULL,
AddressID int NOT NULL,
CONSTRAINT PK_AdultMemberAddress PRIMARY KEY (AdultID, AddressID),
CONSTRAINT FK_MemberAddress_AdultMember FOREIGN KEY (AdultID) REFERENCES AdultMember(ID),
CONSTRAINT FK_MemberAddress_Address FOREIGN KEY (AddressID) REFERENCES [Address](ID))