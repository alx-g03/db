USE Problema3

BEGIN TRANSACTION
	UPDATE Tari SET nume_t = nume_t + ' Tranzactie 1' WHERE cod_t = 3
	WAITFOR DELAY '00:00:07'
	UPDATE Clienti	SET nume_c = nume_c + ' Tranzactie 1' WHERE cod_c = 3
COMMIT TRANSACTION