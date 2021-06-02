CREATE PROCEDURE [dbo].[IncrementOZ]
AS
	--svakom timu koji ima vodju nad svakim projektom povecati OZ za 10
	UPDATE TimRadiNaProjektu
	SET OZ = OZ + 10
	FROM Timovi 
	INNER JOIN TimRadiNaProjektuTim ON TimRadiNaProjektuTim.Tim_ST = Timovi.ST
	INNER JOIN TimRadiNaProjektu ON TimRadiNaProjektu.Id = TimRadiNaProjektuTim.TimRadiNaProjektu_Id
	WHERE
	VodjaTima_Id != ''
GO;
