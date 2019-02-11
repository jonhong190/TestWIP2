CREATE PROCEDURE [dbo].[AddClassProp]
	@ClassPropID As bigInt,
	@ClassID As bigInt,
	@PropName as varChar(50),
	@ArrayIndex as int
AS
BEGIN
	/** Insert into ClassProps table with paremeters passed **/
	INSERT INTO ClassProps
	(ClassPropID, ClassID, PropName, ArrayIndex)
	VALUES(@ClassPropID, @ClassID, @PropName, @ArrayIndex)
END