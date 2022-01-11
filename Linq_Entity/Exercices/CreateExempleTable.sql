/*Script SQL pour la BDD*/
CREATE TABLE [User]
(
    UserId SMALLINT PRIMARY KEY IDENTITY(1,1), -- IDENTITY(1,1) : on calcul un nouvel index qui part de 1 et incrémenté de 1 à chaque nouvelle insertion. 
    UserName VARCHAR(50),						-- Pour modifier ensuite les index il faut désactiver la primary key contraint, désactivé le identity, modifier l'index et réactiver ensuite
    Login VARCHAR(50),
    Birthday DATETIME
)

INSERT INTO [User] VALUES ('Alex', 'Lelexxx', '10/30/1990');--attention datetime doit être au format anglais!
INSERT INTO [User] VALUES ('Toto', null, '4/9/2000 05:01:00');
INSERT INTO [User] VALUES ('Titi', 'Tit', '1/11/2000');
INSERT INTO [User] VALUES ('Tutu', null, '4/9/2000 05:00:00');