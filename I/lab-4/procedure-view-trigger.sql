USE LabBD

GO

CREATE OR ALTER FUNCTION idIsNull (@id int)
RETURNS int
AS
BEGIN
	DECLARE @ret int
	IF @id = 0
		SET @ret = 0
	ELSE
		SET @ret = 1
	RETURN @ret
END

GO

CREATE OR ALTER FUNCTION ageIsNegative (@varsta int)
RETURNS int
AS
BEGIN
	DECLARE @ret int
	IF @varsta < 0
		SET @ret = 0
	ELSE
		SET @ret = 1
	RETURN @ret
END

GO

CREATE OR ALTER FUNCTION fieldIsEmpty (@field varchar(250))
RETURNS int
AS
BEGIN
	DECLARE @ret int
	IF @field = ''
		SET @ret = 0
	ELSE
		SET @ret = 1
	RETURN @ret
END

GO

CREATE OR ALTER PROCEDURE InsertIntoClient (@cod_c int, @nume varchar(75), @varsta int) AS
BEGIN
	IF dbo.idIsNull(@cod_c) = 0
		BEGIN
			RAISERROR ('id-ul nu poate fi nul!', 10, 1)
			RETURN 
		END
	DECLARE @check_id int
	SET @check_id = (SELECT COUNT(cod_c) FROM Client WHERE cod_c = @cod_c)
	IF @check_id != 0
		BEGIN
			RAISERROR ('id-ul exista deja!', 10, 1)
			RETURN
		END
	IF dbo.fieldIsEmpty(@nume) = 0
		BEGIN
			RAISERROR ('numele nu poate fi gol!', 10, 1)
			RETURN 
		END
	IF dbo.ageIsNegative(@varsta) = 0
		BEGIN
			RAISERROR ('varsta nu poate fi negativa!', 10, 1)
			RETURN 
		END
	INSERT INTO Client VALUES (@cod_c, @nume, @varsta)
END

GO

CREATE OR ALTER PROCEDURE InsertIntoEveniment (@cod_e int, @nume varchar(75), @descriere varchar(250)) AS
BEGIN
	IF dbo.idIsNull(@cod_e) = 0
		BEGIN
			RAISERROR ('id-ul nu poate fi nul!', 10, 1)
			RETURN 
		END
	DECLARE @check_id int
	SET @check_id = (SELECT COUNT(cod_e) FROM Eveniment WHERE cod_e = @cod_e)
	IF @check_id != 0
		BEGIN
			RAISERROR ('id-ul exista deja!', 10, 1)
			RETURN
		END
	IF dbo.fieldIsEmpty(@nume) = 0
		BEGIN
			RAISERROR ('numele nu poate fi gol!', 10, 1)
			RETURN 
		END
	IF dbo.fieldIsEmpty(@descriere) = 0
		BEGIN
			RAISERROR ('descrierea nu poate fi goala!', 10, 1)
			RETURN 
		END
	INSERT INTO Eveniment VALUES (@cod_e, @nume, @descriere)
END

GO

CREATE OR ALTER PROCEDURE InsertIntoShowroom (@cod_sh int, @locatie varchar(75), @cod_e int) AS
BEGIN
	IF dbo.idIsNull(@cod_sh) = 0
		BEGIN
			RAISERROR ('id-ul nu poate fi nul!', 10, 1)
			RETURN 
		END
	DECLARE @check_id int
	SET @check_id = (SELECT COUNT(cod_sh) FROM Showroom WHERE cod_sh = @cod_sh)
	IF @check_id != 0
		BEGIN
			RAISERROR ('id-ul exista deja!', 10, 1)
			RETURN
		END
	IF dbo.fieldIsEmpty(@locatie) = 0
		BEGIN
			RAISERROR ('locatia nu poate fi goala!', 10, 1)
			RETURN 
		END
	SET @check_id = (SELECT COUNT(cod_e) FROM Eveniment WHERE cod_e = @cod_e)
	IF @check_id = 0
		BEGIN
			RAISERROR ('nu exista evenimentul cu id-ul dat!', 10, 1)
			RETURN
		END
	INSERT INTO Showroom VALUES (@cod_sh, @locatie, @cod_e)
END

GO

EXEC InsertIntoClient @cod_c = 1, @nume = 'Alex', @varsta = 22
EXEC InsertIntoClient @cod_c = 5, @nume = '', @varsta = 3
EXEC InsertIntoClient @cod_c = 6, @nume = 'Daniel', @varsta = -33
EXEC InsertIntoClient @cod_c = 4, @nume = 'Alexia', @varsta = 20
EXEC InsertIntoEveniment @cod_e = 0, @nume = 'WWDC', @descriere = 'Prezentare produse Apple'
EXEC InsertIntoEveniment @cod_e = 7, @nume = '', @descriere = 'Prezentare produse Apple'
EXEC InsertIntoEveniment @cod_e = 8, @nume = 'WWDC', @descriere = ''
EXEC InsertIntoEveniment @cod_e = 3, @nume = 'Galaxy UNPACKED', @descriere = 'Prezentare produse Samsung'
EXEC InsertIntoShowroom @cod_sh = 4, @locatie = 'Timisoara', @cod_e = 22
EXEC InsertIntoShowroom @cod_sh = 9, @locatie = '', @cod_e = 3
EXEC InsertIntoShowroom @cod_sh = 4, @locatie = 'Oradea', @cod_e = 3

GO

CREATE OR ALTER VIEW [showroom si eveniment] AS
(SELECT Showroom.locatie, Eveniment.nume, Eveniment.descriere
FROM Showroom
INNER JOIN Eveniment
ON Showroom.cod_e = Eveniment.cod_e);

GO

CREATE OR ALTER TRIGGER dateTimeInsert ON Client AFTER INSERT AS
BEGIN
	PRINT('Insert in tabelul Client')
	PRINT(GETDATE())
END

GO

CREATE OR ALTER TRIGGER dateTimeDelete ON Client AFTER DELETE AS
BEGIN
	PRINT('Delete in tabelul Client')
	PRINT(GETDATE())
END

GO