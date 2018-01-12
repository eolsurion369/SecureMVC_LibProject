CREATE TABLE CheckOut (
AdultID int NOT NULL,
JuvenileID int,
MediaCopyID int NOT NULL,
DueDate date NOT NULL,
CheckedInDate date NOT NULL,
CONSTRAINT PK_AdultCheckOut PRIMARY KEY (AdultID, MediaCopyID),
CONSTRAINT FK_AdultCheckOut_AdultMember FOREIGN KEY (AdultID) REFERENCES AdultMember(ID),
CONSTRAINT FK_AdultCheckOut_MediaCopy FOREIGN KEY (MediaCopyID) REFERENCES MediaCopy(ID)
)
