CREATE OR ALTER TRIGGER TrigerOnDelete
ON Hardveri
AFTER DELETE
AS
BEGIN
SET NOCOUNT ON;
INSERT INTO dbo.Logs values('Hardver deleted',  GETDATE());
END