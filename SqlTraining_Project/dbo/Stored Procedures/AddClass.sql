CREATE PROCEDURE [dbo].[AddClass]
	@ClassID As int,
	@ClassName As varChar(50),
	@ArrayIndex As int
AS
BEGIN
	/** Insert into class table with parameters passed  **/
	INSERT INTO Classes
	(ClassID, ClassName, ArrayIndex)
	VALUES(@ClassID, @Classname, @ArrayIndex)
END
