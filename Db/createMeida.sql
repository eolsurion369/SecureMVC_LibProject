CREATE TABLE Media (
ID int IDENTITY PRIMARY KEY,
Title varchar(60) NOT NULL,
SeriesId int,
Author varchar(60) NOT NULL,
PublisherID int,
CopyRightDate Date NOT NULL,
Characteristics varchar(50) NOT NULL,
Summary varchar(255),
InActive bit,
InActiveDate date,
CONSTRAINT FK_Media_Publisher FOREIGN KEY (PublisherID) REFERENCES Publisher(ID),
CONSTRAINT FK_Media_SeriesId FOREIGN KEY (SeriesID) REFERENCES Series(ID)
)
