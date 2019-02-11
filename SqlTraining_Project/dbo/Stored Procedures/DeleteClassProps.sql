CREATE PROCEDURE [dbo].[DeleteClassProps]
	@ClassPropID As bigInt
AS
BEGIN
	/** Name variable to store the selection querry below **/
	Declare @Name As varChar(50)
	DECLARE @i as int = 0
	DECLARE @ClassID as varChar(50)
	DECLARE @count as int
	
	
	SELECT @Name = PropName, @ClassId = ClassID FROM ClassProps
	WHERE ClassPropID = @ClassPropID

	/** Only delete if the the PropName is not 'Name' **/
	IF @Name <> 'Name' 
	BEGIN
		DELETE FROM ClassProps
		WHERE ClassPropID = @ClassPropID

		SELECT @count = COUNT(*) FROM ClassProps WHERE ClassID = @ClassID
		
		WHILE @i < @count
			BEGIN
				UPDATE ClassProps
				SET ArrayIndex = @i
				WHERE ClassPropID = @ClassPropID + (1*@i)
			
				SET @i = @i + 1
			END

	END
	ELSE
		PRINT 'Can not remove Name property'
END