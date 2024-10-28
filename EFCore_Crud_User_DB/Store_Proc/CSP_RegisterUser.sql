CREATE PROCEDURE [dbo].[CSP_RegisterUser]
	@firstname NVARCHAR(50),
	@lastname NVARCHAR(50),
	@email NVARCHAR(120),
	@pwd NVARCHAR(100),
	@street NVARCHAR(100),
	@housenumber NVARCHAR(10),
	@zipcode INT,
	@city NVARCHAR(50)
	

AS
BEGIN
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

	INSERT INTO T_User (FirstName, LastName, Email, Pwd, Street, HouseNumber, ZipCode, City , SaltId) 
		VALUES (@firstname, @lastname, @email, @PwdHash, @street, @housenumber, @zipcode, @city,  @InsertedId)

END