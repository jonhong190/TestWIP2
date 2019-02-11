CREATE PROCEDURE [dbo].[DeleteClass]
	@ClassID As bigInt
AS
BEGIN


	/** Delete from ClassProps Table by ClassID **/
	DELETE FROM ClassProps
	WHERE ClassID = @ClassID
	/** Delete from Classes Table by ClassID **/
	DELETE FROM Classes
	WHERE ClassID = @ClassID


	

		UPDATE Classes
		SET ArrayIndex = ArrayIndex -1 
		WHERE ClassID > @ClassID


	
END