CREATE TABLE MediaContent(
ContentID int IDENTITY PRIMARY KEY,
MediaID int NOT NULL,
ContentItemOrder int NOT NULL,
ContentItem varchar(100) NOT NULL,
CONSTRAINT FK_MediaContent_Media FOREIGN KEY (MediaID) REFERENCES Media(ID))