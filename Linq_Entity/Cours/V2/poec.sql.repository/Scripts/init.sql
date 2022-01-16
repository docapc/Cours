CREATE TABLE [User]
(
    UserId SMALLINT PRIMARY KEY IDENTITY(1,1),
    UserName VARCHAR(50),
    Login VARCHAR(50),
    Birthday DATETIME
);

INSERT INTO [User] VALUES ('Alex', 'Lelexxx', '10/30/1990');
INSERT INTO [User] VALUES ('Toto', null, '4/9/2000 05:01:00');
INSERT INTO [User] VALUES ('Titi', 'Tit', '1/11/2000');
INSERT INTO [User] VALUES ('Tutu', null, '4/9/2000 05:00:00');

CREATE TABLE [Address]
(
    AddressId SMALLINT PRIMARY KEY IDENTITY(1,1),
    UserId SMALLINT,
    [Label] VARCHAR(50),
    [Address] VARCHAR(50),
    FOREIGN KEY (UserId) REFERENCES [User](UserId)
);

INSERT INTO [Address] VALUES (1, 'Maison', '17b rue des Landes');
INSERT INTO [Address] VALUES (1, 'Travail', '17 rue de Sarlèves');