CREATE TABLE MemberEmail (
AdultID int NOT NULL,
JuvenileID int,
EmailID int NOT NULL,
CONSTRAINT PK_MemberEmail PRIMARY KEY (AdultID, JuvenileID, EmailID),
CONSTRAINT FK_MemberEmail_AdultMember FOREIGN KEY (AdultID) REFERENCES AdultMember(ID),
CONSTRAINT FK_MemberEmail_JuvenileMember FOREIGN KEY (JuvenileID, AdultID) REFERENCES JuvenileMember(ID, AdultID),
CONSTRAINT FK_MemberEmail_Email FOREIGN KEY (EmailID) REFERENCES Email(ID))