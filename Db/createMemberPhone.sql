CREATE TABLE MemberPhone (
AdultID int NOT NULL,
JuvenileID int,
PhoneID int NOT NULL,
CONSTRAINT PK_MemberPhone PRIMARY KEY (AdultID, JuvenileID, PhoneID),
CONSTRAINT FK_MemberPhone_AdultMember FOREIGN KEY (AdultID) REFERENCES AdultMember(ID),
CONSTRAINT FK_MemberPhone_JuvenileMember FOREIGN KEY (JuvenileID, AdultID) REFERENCES JuvenileMember(ID, AdultID),
CONSTRAINT FK_MemberPhone_Email FOREIGN KEY (PhoneID) REFERENCES Phone(ID))