CREATE PROCEDURE [dbo].[CSP_VerifyPwd]
(
	@email VARCHAR(120),
	@pwd VARCHAR(100),
	@id INT,
	@pwdOk INT OUTPUT
)
AS
BEGIN
	DECLARE @PreSalt VARCHAR(100)
	DECLARE @PostSalt VARCHAR(100)
	SELECT @PreSalt = PreSalt, @PostSalt = PostSalt FROM T_Salt WHERE Id = @id

	DECLARE @HashKey VARCHAR(100)
	SET @HashKey = dbo.F_GetSecret()

	DECLARE @PwdHash VARBINARY(64)
	SET @PwdHash = HASHBYTES('SHA2_512', CONCAT(@PreSalt, @HashKey, @pwd, @PostSalt))

	DECLARE @pwdUser VARCHAR(100)
	SELECT @pwdUser = Pwd FROM T_User WHERE Email = @email AND IsActif = 1

	IF(@pwdUser = @PwdHash)
	BEGIN
		SET @pwdOk = 1
	END
	RETURN
END
