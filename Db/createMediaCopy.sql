CREATE TABLE MediaCopy (
ID int IDENTITY PRIMARY KEY,
MediaID int NOT NULL,
MediaTypeID varchar(1) NOT NULL,
MediaGenreID varchar(2) NOT NULL,
MediaFormatID varchar(1) NOT NULL,
CopyNumber int NOT NULL,
InActive bit,
InActiveDate date,
CONSTRAINT FK_MediaCopy_Media FOREIGN KEY (MediaID) REFERENCES Media(ID),
CONSTRAINT FK_MediaCopy_Genre FOREIGN KEY (MediaGenreID) REFERENCES Genre(ID),
CONSTRAINT FK_MediaCopy_MediaType FOREIGN KEY (MediaTypeID) REFERENCES MediaType(ID),
CONSTRAINT FK_MediaCopy_MeidaFormat FOREIGN KEY (MediaFormatID) REFERENCES MediaFormat(ID))
