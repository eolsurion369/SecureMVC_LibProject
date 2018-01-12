CREATE TABLE LibraryLogin (
UserID varchar(30) PRIMARY KEY,
UserPW varchar(30) NOT NULL,
PWUpdateDate date NOT NULL,
PWExpirationDate date NOT NULL,
AccountLockout bit)