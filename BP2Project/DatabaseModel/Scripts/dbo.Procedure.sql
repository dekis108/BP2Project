CREATE OR ALTER PROCEDURE [dbo].[Procedure]
	@param1 int = 0,
	@param2 int
AS
	SELECT AVG(PLAT) FROM Zaposleni
GO;
