USE Biscuiti

GO

-- roll-back pe intreaga procedura stocata
CREATE PROCEDURE InsertIntoBiscuitiClienti0 (@nume_b varchar(100), @nr_calorii INT, @pret REAL, @nume_c VARCHAR(100), @nota INT) AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION;

		IF (LEN(@nume_b) = 0)
			THROW 50001, 'Biscuit name is empty', 11;
		IF (LEN(@nume_b) > 100)
			THROW 50001, 'Biscuit name is too long', 11;
		IF (@nr_calorii < 0)
			THROW 50001, 'Calories are negative', 11;
		IF (@pret < 0)
			THROW 50001, 'Price is negative', 11;
        INSERT INTO Biscuiti0(nume_b, nr_calorii, pret) VALUES(@nume_b, @nr_calorii, @pret);
		DECLARE @cod_b INT = SCOPE_IDENTITY();

		IF (LEN(@nume_c) = 0)
			THROW 50001, 'Client name is empty', 11;
		IF (LEN(@nume_c) > 100)
			THROW 50001, 'Client name is too long.', 11;
        INSERT INTO Clienti0(nume_c) VALUES(@nume_c);
		DECLARE @cod_c INT = SCOPE_IDENTITY();

		IF (@nota < 1 OR @nota > 10)
			THROW 50001, 'Review is not between 1 and 10', 11;
        INSERT INTO Note0(cod_b, cod_c, nota) VALUES(@cod_b, @cod_c, @nota);

        COMMIT;

		INSERT INTO LogTable0(mesaj) VALUES('Tranzactie efectuata cu succes');
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
		BEGIN
            ROLLBACK;
			INSERT INTO LogTable0(mesaj) VALUES(ERROR_MESSAGE());
		END
    END CATCH;
END

GO

-- se pastreaza cat mai mult posibil din ceea ce s-a modificat
CREATE PROCEDURE InsertIntoBiscuitiClienti1 (@nume_b varchar(100), @nr_calorii INT, @pret REAL, @nume_c VARCHAR(100), @nota INT) AS
BEGIN
	BEGIN TRY
        BEGIN TRANSACTION;

		DECLARE @cod_b INT = NULL;
		IF (LEN(@nume_b) = 0)
			THROW 50001, 'Biscuit name is empty', 11;
		IF (LEN(@nume_b) > 100)
			THROW 50001, 'Biscuit name is too long', 11;
		IF (@nr_calorii < 0)
			THROW 50001, 'Calories are negative', 11;
		IF (@pret < 0)
			THROW 50001, 'Price is negative', 11;
        INSERT INTO Biscuiti0(nume_b, nr_calorii, pret) VALUES(@nume_b, @nr_calorii, @pret);
		SET @cod_b = SCOPE_IDENTITY();

        COMMIT;

		INSERT INTO LogTable0(mesaj) VALUES('Biscuiti adaugati cu succes');
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
		BEGIN
            ROLLBACK;
			INSERT INTO LogTable0(mesaj) VALUES(ERROR_MESSAGE());
		END
    END CATCH;

	BEGIN TRY
        BEGIN TRANSACTION;

		DECLARE @cod_c INT = NULL;
		IF (LEN(@nume_c) = 0)
			THROW 50001, 'Client name is empty', 11;
		IF (LEN(@nume_c) > 100)
			THROW 50001, 'Client name is too long.', 11;
        INSERT INTO Clienti0(nume_c) VALUES(@nume_c);
		SET @cod_c = SCOPE_IDENTITY();

        COMMIT;

		INSERT INTO LogTable0(mesaj) VALUES('Clienti adaugati cu succes');
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
		BEGIN
            ROLLBACK;
			INSERT INTO LogTable0(mesaj) VALUES(ERROR_MESSAGE());
		END
    END CATCH;

	BEGIN TRY
        BEGIN TRANSACTION;

		IF (@cod_b IS NULL OR @cod_c IS NULL)
			THROW 50001, 'Relationship cannot be created', 11;
		IF (@nota < 1 OR @nota > 10)
			THROW 50001, 'Review is not between 1 and 10', 11;
        INSERT INTO Note0(cod_b, cod_c, nota) VALUES(@cod_b, @cod_c, @nota);

        COMMIT;

		INSERT INTO LogTable0(mesaj) VALUES('Note adaugate cu succes');
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
		BEGIN
            ROLLBACK;
			INSERT INTO LogTable0(mesaj) VALUES(ERROR_MESSAGE());
		END
    END CATCH;
END