CREATE PROCEDURE [dbo].[StoreClassPropsInXml]
	@XmlData as text ,
	@TextData as text
AS
BEGIN
	INSERT INTO XmlClassProps
		(XmlData,TextData)
		VALUES(
		CAST(CAST(@XmlData AS NTEXT) AS XML),
		@TextData)

END