USE S8

BEGIN TRANSACTION
	UPDATE Muzee SET Denumire = Denumire + ' T1' WHERE Mid = 2
	WAITFOR DELAY '00:00:07'
	UPDATE Tablouri	SET Dimensiune = Dimensiune + ' T1' WHERE Tid = 2
COMMIT TRANSACTION