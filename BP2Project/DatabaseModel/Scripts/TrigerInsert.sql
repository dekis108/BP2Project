CREATE OR ALTER TRIGGER TrigerOnInsert
ON Zaposleni
AFTER INSERT
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO dbo.Logs values('Zaposleni inserted',  GETDATE());
END