CREATE DATABASE Telecom;

GO

USE Telecom;

CREATE TABLE Client0
(cod_c int PRIMARY KEY,
nume varchar(75),
varsta int);

CREATE TABLE Abonament0
(cod_a int PRIMARY KEY,
descriere varchar(250),
pret int,
cod_c int FOREIGN KEY REFERENCES Client0(cod_c)
ON UPDATE CASCADE
ON DELETE SET NULL);

CREATE TABLE Telefon0
(cod_t int PRIMARY KEY,
brand varchar(50),
model varchar(75),
pret int,
cod_c int FOREIGN KEY REFERENCES Client0(cod_c)
ON UPDATE CASCADE
ON DELETE SET NULL);

CREATE TABLE Eveniment0
(cod_e int PRIMARY KEY,
nume varchar(75),
descriere varchar(250));

CREATE TABLE Participant0
(cod_p int PRIMARY KEY,
nume varchar(75),
varsta int,
cod_e int FOREIGN KEY REFERENCES Eveniment0(cod_e)
ON UPDATE CASCADE
ON DELETE SET NULL);

CREATE TABLE Showroom0
(cod_sh int PRIMARY KEY,
locatie varchar(75));

CREATE TABLE Sponsor0
(cod_sp int PRIMARY KEY,
nume varchar(75),
varsta int,
investitie int);

CREATE TABLE Inventar0
(cod_t int FOREIGN KEY REFERENCES Telefon0(cod_t),
cod_sh int FOREIGN KEY REFERENCES Showroom0(cod_sh)
CONSTRAINT pkInventar PRIMARY KEY(cod_t, cod_sh));

CREATE TABLE Contract0
(cod_sh int FOREIGN KEY REFERENCES Showroom0(cod_sh),
cod_sp int FOREIGN KEY REFERENCES Sponsor0(cod_sp)
CONSTRAINT pkContract PRIMARY KEY(cod_sh, cod_sp));

CREATE TABLE Organizare0
(cod_sh int FOREIGN KEY REFERENCES Showroom0(cod_sh),
cod_e int FOREIGN KEY REFERENCES Eveniment0(cod_e)
CONSTRAINT pkOrganizare PRIMARY KEY(cod_sh, cod_e));