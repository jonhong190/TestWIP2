Imports System.Collections.Specialized
Imports System.IO
Imports System.Xml.Serialization
Imports System.Text

Module DatabaseFunctions

	''' <summary>
	''' Sub handles updating ClassAndPropsKeyIndex to highest Key after loading data from the db (JH 2-6-19)
	''' </summary>
	Sub UpdateClassAndPropsKeyIndex()
		Dim d = SqlServerObj.GetSqlData("SELECT * FROM ClassProps ORDER BY ClassPropID")
		ClassAndPropsKeyIndex = d(d.Count - 1)("ClassPropID")
	End Sub


	''' <summary>
	''' Routine handles retrieving database Class and ClassProps and populates 
	''' them into the dClasses and dClassPropsByKey dictionaries with the querried data then calls, while this happens rows are also being added to dtClasses (JH 2-6-19)
	''' </summary>
	''' <param name="DBobj">clsSQLServer class object</param>
	Sub LoadClassesFromDatabase(DBobj As clsSQLServer)

		Try
			Dim dbDict As OrderedDictionary
			Dim typeCheck As Boolean = TypeOf DBobj Is clsSQLServer

			If Not IsNothing(DBobj) AndAlso typeCheck AndAlso DBobj.SqlObject.State = 1 Then
				' Populate dclasses and dtClasses with new clsClass instatiated objects (JH 2-7-19)
				dbDict = DBobj.GetSqlData("SELECT * FROM Classes")

				For Each item In dbDict

					Dim clsObj As clsClass = New clsClass(item.Value("ClassName"), item.Value("ClassID"), item.Value("ArrayIndex"))

					CreateDtRows(item)

				Next
				'Use querried data to create new clsClassProp instantiated objects(JH 2-7-19)
				dbDict = DBobj.GetSqlData("SELECT * FROM ClassProps")

				For Each item In dbDict
					Dim clsProp As clsClassProp = New clsClassProp(item.Value("PropName"), item.Value("ArrayIndex"), item.Value("ClassID"), item.Value("ClassPropID"))
				Next

				If dClassAndPropsByKey.Count > 0 Then
					UpdateClassAndPropsKeyIndex()
				End If


			End If
		Catch ex As Exception
			Console.WriteLine(ex.Message)
		End Try

	End Sub

	''' <summary>
	''' Function handles selecting which DB stored procedure to execute along with which paramenters
	''' and parameter names need to be sent to the DB (JH 2-7-19)
	''' </summary>
	''' <param name="procType">Type of operation</param>
	''' <param name="obj">Optional object parameter passed to determine which type of object to 
	''' enter or delete from db</param>
	Sub SelectDBProcedure(Optional procType As String = "", Optional obj As Object = Nothing)
		Try
			'array to hold the hard coded names for DB procedure parameters
			Dim addParams As Object()

			If Not obj Is Nothing Then

				If TypeOf obj Is clsClass Then

					If procType = "Add" Then

						addParams = New Object() {obj.Key, obj.Name, obj.ArrayIndex}
						paramName = New Object() {"@ClassID", "@ClassName", "@ArrayIndex"}

						SqlServerObj.ExecSqlStoredProc("AddClass", addParams)

					ElseIf procType = "Delete" Then

						addParams = New Object() {obj.Key}
						paramName = New Object() {"@ClassID"}
						SqlServerObj.ExecSqlStoredProc("DeleteClass", addParams)


					End If

				ElseIf TypeOf obj Is clsClassProp Then

					If procType = "Add" Then

						addParams = New Object() {obj.Key, obj.ParentKey, obj.Name, obj.ArrayIndex}
						paramName = New Object() {"@ClassPropID", "@ClassID", "@PropName", "@ArrayIndex"}
						SqlServerObj.ExecSqlStoredProc("AddClassProp", addParams)

					ElseIf procType = "Delete" Then

						addParams = New Object() {obj.Key}
						paramName = New Object() {"@ClassPropID"}
						SqlServerObj.ExecSqlStoredProc("DeleteClassProps", addParams)

					End If
				ElseIf TypeOf obj Is clsUser Then

					paramName = New Object() {"@LastLogged", "@Username"}
					addParams = New Object() {obj.Username, obj.LastLogged}
					SqlServerObj.ExecSqlStoredProc("UpdateUserLogTime", addParams)

				End If

			End If
		Catch ex As Exception
			Console.WriteLine(ex.Message)
		End Try

	End Sub

	''' <summary>
	''' Function handles serializing the clsClassProp object to Xml, the object is serialized into a memorystream object, then 
	''' the stream byte array is converted into a string by the StreamByteArraytoString function call. this string is sent to the db 
	''' stored procedure which handles converting the string to xml and storing the data into the db (JH 2-11-19)
	''' </summary>
	''' <param name="Prop">new instantiated clsClassProp</param>
	Sub SerializeClsProp(Prop As clsClassProp)

		Dim xml As XmlSerializer = New XmlSerializer(GetType(clsClassProp))
		Dim addParams As Object() = New Object() {1, 2}
		Try

			Dim Stream = New MemoryStream()
			xml.Serialize(Stream, Prop)
			Dim xString = StreamByteArrayToString(Stream.ToArray)

			addParams = New Object() {xString, xString}
			paramName = New Object() {"@XmlData", "@TextData"}

			SqlServerObj.ExecSqlStoredProc("StoreClassPropsInXml", addParams)
			Stream.Flush()
			Stream.Seek(0, SeekOrigin.Begin)

		Catch ex As Exception
			Console.WriteLine(ex.Message)
		End Try

	End Sub

	''' <summary>
	''' Function handles taking in bytes from memory stream object array and converting them into a string (JH 2-11-19)
	''' </summary>
	''' <param name="streamBytes">array of bytes from memory stream object</param>
	''' <returns></returns>
	Public Function StreamByteArrayToString(streamBytes As Byte()) As String

		Try
			Dim encoding As New UTF8Encoding
			Dim constructedString As String = encoding.GetString(streamBytes)
			Return constructedString
		Catch ex As Exception
			Console.WriteLine(ex.Message)
			Return Nothing
		End Try

	End Function

	''' <summary>
	''' Functino handles querrying db for table and column names and then puts them into the DatabaseInfo ordered dictionary (JH 2-11-19)
	''' </summary>
	''' <param name="DbObj">SQL Server object instantiated from the startup sub</param>
	''' <returns></returns>
	Public Function GetAllDbTableAndCols(DbObj As clsSQLServer)

		Try

			Dim sqlString = "SELECT INFORMATION_SCHEMA.TABLES.TABLE_NAME, COLUMN_NAME FROM INFORMATION_SCHEMA.TABLES
JOIN INFORMATION_SCHEMA.COLUMNS ON INFORMATION_SCHEMA.COLUMNS.TABLE_NAME = INFORMATION_SCHEMA.TABLES.TABLE_NAME"

			DatabaseInfo = SqlServerObj.GetSqlData(sqlString)
			Return DatabaseInfo

		Catch ex As Exception
			Console.WriteLine(ex)
			Return Nothing
		End Try

	End Function

End Module
