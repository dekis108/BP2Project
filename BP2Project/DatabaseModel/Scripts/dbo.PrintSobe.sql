CREATE OR ALTER PROCEDURE [dbo].[RoomCursor]
AS 
DECLARE PROJECT_CURSOR CURSOR
FOR SELECT DISTINCT SP
FROM PoslovniProstori
INNER JOIN Zaposleni ON PoslovniProstori.SP = Zaposleni.PoslovniProstor_SP
INNER JOIN Hardveri_Racunar ON  PoslovniProstori.SP = Hardveri_Racunar.PoslovniProstor_SP
DECLARE
@i VARCHAR(30);
BEGIN
	--ispisi prostorije koje imaju racunare i u kojima sedi neko
	OPEN PROJECT_CURSOR;
	FETCH NEXT FROM PROJECT_CURSOR INTO 
		@i;
	WHILE @@FETCH_STATUS = 0
		BEGIN
			PRINT @i;
			FETCH NEXT FROM PROJECT_CURSOR INTO 
				@i; 
		END;
	CLOSE PROJECT_CURSOR;
	DEALLOCATE PROJECT_CURSOR;

END
GO