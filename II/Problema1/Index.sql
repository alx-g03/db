USE Problema1

GO

CREATE INDEX IX__Cofetarii__Adresa ON Cofetarii(adresa)

GO

SELECT * FROM Cofetarii WHERE adresa = 'adresa Carpati'
SELECT * FROM Cofetarii WITH(INDEX(IX__Cofetarii__Adresa)) WHERE adresa = 'adresa Carpati'