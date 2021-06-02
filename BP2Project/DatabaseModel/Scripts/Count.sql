SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER FUNCTION FunctionCounting
(
    -- Add the parameters for the function here
    --<@Param1, sysname, @p1> <Data_Type_For_Param1, , int>
) 
RETURNS DECIMAL
AS
BEGIN
    -- Declare the return variable here
    DECLARE @retval AS DECIMAL;

    -- Add the T-SQL statements to compute the return value here
    SELECT @retval = count(*) FROM Zaposleni WHERE PLAT > 16000;
    RETURN @retval;
    END;
GO

declare @ret int
exec @ret =  FunctionCounting
select @ret
go