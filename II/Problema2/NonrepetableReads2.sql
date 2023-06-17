USE Problema2

BEGIN TRANSACTION
	UPDATE Clasamente SET nume_clasament = nume_clasament + ' update' WHERE cod_clasament = 3
COMMIT TRANSACTION

SELECT * FROM Clasamente