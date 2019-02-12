CREATE PROCEDURE UpdateUserLogTime
	@LastLogged AS nvarchar(50),
	@Username AS nvarchar(50)
AS
BEGIN
	UPDATE USERS
	SET LastLogged = CAST(@LastLogged AS datetime2)
	WHERE Username = @Username
END