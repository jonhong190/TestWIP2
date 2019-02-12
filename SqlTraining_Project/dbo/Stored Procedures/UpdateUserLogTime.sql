CREATE PROCEDURE [dbo].[UpdateUserLogTime]
	@LastLogged AS Datetime,
	@Username AS text
AS
BEGIN
	UPDATE USERS
	SET LastLogged = @LastLogged
	WHERE Username = CAST(@Username as nvarchar(50))
END