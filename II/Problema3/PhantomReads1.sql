USE Problema3

BEGIN TRANSACTION
	WAITFOR DELAY '00:00:05'
	INSERT INTO Producatori(nume_p, website) VALUES('Tuc','www.tuc.co.uk');
COMMIT TRANSACTION

SELECT * FROM Producatori