CREATE TABLE MediaTypeGenre (
MediaTypeID varchar(1) NOT NULL,
GenreID varchar(2) NOT NULL,
CONSTRAINT PK_MediaTypeGenre PRIMARY KEY (MediaTypeID, GenreID),
CONSTRAINT FK_TypeGenre_MediaType FOREIGN KEY (MediaTypeID) REFERENCES MediaType(ID),
CONSTRAINT FK_TypeGenre_Genre FOREIGN KEY (GenreID) REFERENCES Genre(ID)) 