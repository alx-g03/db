USE Problema1

SELECT * FROM Tari

BEGIN TRANSACTION
    UPDATE Tari SET nume_tara = 'Germania' WHERE cod_tara = 1
	WAITFOR DELAY '00:00:07'
ROLLBACK TRANSACTION