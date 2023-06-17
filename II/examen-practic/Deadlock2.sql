USE S8

-- PROBLEM: deadlock
BEGIN TRANSACTION
	UPDATE Tablouri	SET Dimensiune = Dimensiune + ' T2' WHERE Tid = 2
	WAITFOR DELAY '00:00:07'
	UPDATE Muzee SET Denumire = Denumire + ' T2' WHERE Mid = 2
COMMIT TRANSACTION

-- SOLUTION
BEGIN TRANSACTION
	UPDATE Muzee SET Denumire = Denumire + ' T2' WHERE Mid = 2
	WAITFOR DELAY '00:00:07'
	UPDATE Tablouri	SET Dimensiune = Dimensiune + ' T2' WHERE Tid = 2
COMMIT TRANSACTION