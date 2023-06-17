CREATE DATABASE Companie

GO

USE Companie

CREATE TABLE Localitate
(cod_lo int PRIMARY KEY,
nume varchar(75));

CREATE TABLE Sofer
(cod_so int PRIMARY KEY,
nume varchar(75),
data_permis date,
cod_lo int FOREIGN KEY REFERENCES Localitate(cod_lo)
ON UPDATE CASCADE
ON DELETE SET NULL);

CREATE TABLE Camion
(cod_ca int PRIMARY KEY,
model varchar(75),
tip varchar(75),
capacitate int,
an_fabricatie varchar(75));

CREATE TABLE Client1
(cod_cl int PRIMARY KEY,
nume varchar(75));

CREATE TABLE Cursa
(cod_cu int PRIMARY KEY,
cod_lo int FOREIGN KEY REFERENCES Localitate(cod_lo),
cod_ld int FOREIGN KEY REFERENCES Localitate(cod_lo),
distanta int,
data_cu date,
incarcatura varchar(75),
cod_so int FOREIGN KEY REFERENCES Sofer(cod_so)
ON UPDATE CASCADE
ON DELETE SET NULL,
cod_ca int FOREIGN KEY REFERENCES Camion(cod_ca)
ON UPDATE CASCADE
ON DELETE SET NULL,
cod_cl int FOREIGN KEY REFERENCES Client1(cod_cl)
ON UPDATE CASCADE
ON DELETE SET NULL);

GO

CREATE OR ALTER VIEW [view] AS
(SELECT Sofer.nume, Cursa.distanta
FROM Sofer
INNER JOIN Cursa
ON Sofer.cod_so = Cursa.cod_so
INNER JOIN Camion
ON Cursa.cod_ca = Camion.cod_ca
WHERE Camion.cod_ca = 'cisterna' AND Sofer.data_permis < '20.10.2018')

GO