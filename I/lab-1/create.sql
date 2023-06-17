CREATE DATABASE LabBD;

GO

USE LabBD;

CREATE TABLE Client
(cod_c int PRIMARY KEY,
nume varchar(75),
varsta int);

CREATE TABLE Telefon
(cod_t int PRIMARY KEY,
brand varchar(50),
model varchar(75),
pret int,
cod_c int FOREIGN KEY REFERENCES Client(cod_c)
ON UPDATE CASCADE
ON DELETE SET NULL);

CREATE TABLE Eveniment
(cod_e int PRIMARY KEY,
nume varchar(75),
descriere varchar(250));

CREATE TABLE Showroom
(cod_sh int PRIMARY KEY,
locatie varchar(75),
cod_e int FOREIGN KEY REFERENCES Eveniment(cod_e)
ON UPDATE CASCADE
ON DELETE SET NULL);

CREATE TABLE Sponsor
(cod_sp int PRIMARY KEY,
nume varchar(75),
investitie int);

CREATE TABLE Inventar
(cod_t int FOREIGN KEY REFERENCES Telefon(cod_t),
cod_sh int FOREIGN KEY REFERENCES Showroom(cod_sh)
CONSTRAINT pkInventar PRIMARY KEY(cod_t, cod_sh));

CREATE TABLE Conventie
(cod_sh int FOREIGN KEY REFERENCES Showroom(cod_sh),
cod_sp int FOREIGN KEY REFERENCES Sponsor(cod_sp)
CONSTRAINT pkConventie PRIMARY KEY(cod_sh, cod_sp));