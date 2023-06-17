USE LabBD

UPDATE Client SET varsta = 20 WHERE cod_c = 1

DELETE FROM Eveniment WHERE cod_e < 2 AND nume = 'Lansare de telefon'