USE S8

GO

CREATE INDEX IX__Tablouri__Dimensiune ON Tablouri(Dimensiune)

GO

SELECT * FROM Tablouri WHERE Dimensiune = '30*20'
SELECT * FROM Tablouri WITH(INDEX(IX__Tablouri__Dimensiune)) WHERE Dimensiune = '30*20'