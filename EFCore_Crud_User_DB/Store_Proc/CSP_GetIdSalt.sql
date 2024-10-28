CREATE PROCEDURE [dbo].[CSP_GetIdSalt]
	@email VARCHAR(120),
	@idSalt INT OUTPUT
AS
BEGIN
	SELECT @idSalt = SaltId FROM T_User WHERE Email = @email AND Isactif = 1
	RETURN 
END