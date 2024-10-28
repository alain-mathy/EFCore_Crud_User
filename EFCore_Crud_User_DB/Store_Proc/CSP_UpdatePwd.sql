CREATE PROCEDURE [dbo].[CSP_UpdatePwd]
	@email VARCHAR(120),
	@pwd VARCHAR(100)
	
AS
BEGIN
	DECLARE @idSalt INT;
	SELECT @idSalt = SaltId FROM T_User WHERE Email = @email;

	DECLARE @PreSaltDate DATETIME
	SET @PreSaltDate = GETDATE()

	DECLARE @PostSaltDate DATETIME
	SET @PostSaltDate = GETDATE()
		
	DECLARE @InsertedId INT
	INSERT INTO T_Salt(PreSalt, PostSalt)
		VALUES(@PreSaltDate, @PostSaltDate)
	SET @InsertedId = @@IDENTITY
	
	DECLARE @HashKey VARCHAR(100)
	SET @HashKey = dbo.F_GetSecret()

	DECLARE @PreSalt VARCHAR(100)
	DECLARE @PostSalt VARCHAR(100)
	SELECT @PreSalt = PreSalt, @PostSalt = PostSalt FROM T_Salt

	DECLARE @PwdHash VARBINARY(64)
	SET @PwdHash = HASHBYTES('SHA2_512', CONCAT(@PreSalt, @HashKey, @pwd, @PostSalt))

	UPDATE T_User SET Pwd = @PwdHash, SaltId = @InsertedId 
		WHERE Email = @email;

	DELETE FROM T_Salt WHERE Id = @idSalt;

END