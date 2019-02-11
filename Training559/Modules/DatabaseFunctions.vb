Imports System.Collections.Specialized
Imports System.IO
Imports System.Xml.Serialization
Imports System.Text

Module DatabaseFunctions
	''' <summary>
	''' Routine instanstiates new clsSQLServer class object then calls 
	''' LoadClassesFromDatabase sub
	''' </summary>
	Sub Startup()

		Try
			SqlServerObj = New clsSQLServer()
			CreateDgClasses()
			LoadClassesFromDatabase(SqlServerObj)
			GetAllDbTableAndCols(SqlServerObj)
		Catch ex As Exception
			Console.WriteLine(ex.Message)
		End Try

	End Sub

	''' <summary>
	''' Sub handles updating ClassAndPropsKeyIndex to highest Key after loading data from the db (JH 2-6-19)
	''' </summary>
	Sub UpdateClassAndPropsKeyIndex()

		Try
			ClassAndPropsKeyIndex = dClassAndPropsByKey.Keys.ElementAt(dClassAndPropsByKey.Count - 1)
		Catch ex As Exception
			Console.WriteLine(ex.Message)
		End Try

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

					Dim row = dtClasses.NewRow()
					row("Key") = item.Value("ClassID")
					row("ClassName") = item.Value("ClassName")
					row("ArrayIndex") = item.Value("ArrayIndex")
					dtClasses.Rows.Add(row)

				Next
				'Use querried data to create new clsClassProp instantiated objects(JH 2-7-19)
				DBobj.SqlObject.Open()
				dbDict = DBobj.GetSqlData("SELECT * FROM ClassProps")

				For Each item In dbDict
					Dim clsProp As clsClassProp = New clsClassProp(item.Value("PropName"), item.Value("ArrayIndex"), item.Value("ClassID"), item.Value("ClassPropID"))
				Next

				UpdateClassAndPropsKeyIndex()

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
	''' <param name="clsObj">Optional parameter, clsClass Object</param>
	''' <param name="clsObjProp">OPtional parameter, clsProp Object</param>
	Sub SelectDBProcedure(procType As String, Optional clsObj As clsClass = Nothing, Optional clsObjProp As clsClassProp = Nothing)
		Try
			'array to hold the hard coded names for DB procedure parameters
			Dim addParams As Object()

			If Not clsObj Is Nothing Then

				If procType = "Add" Then

					addParams = New Object() {clsObj.Key, clsObj.Name, clsObj.ArrayIndex}
					paramName = New Object() {"@ClassID", "@ClassName", "@ArrayIndex"}
					SqlServerObj.SqlObject.Close()
					SqlServerObj.ExecSqlStoredProc("AddClass", addParams)

				ElseIf procType = "Delete" Then

					addParams = New Object() {clsObj.Key}
					paramName = New Object() {"@ClassID"}
					SqlServerObj.SqlObject.Close()
					SqlServerObj.ExecSqlStoredProc("DeleteClass", addParams)


				End If

			ElseIf Not clsObjProp Is Nothing Then

				If procType = "Add" Then

					addParams = New Object() {clsObjProp.Key, clsObjProp.ParentKey, clsObjProp.Name, clsObjProp.ArrayIndex}
					paramName = New Object() {"@ClassPropID", "@ClassID", "@PropName", "@ArrayIndex"}
					SqlServerObj.SqlObject.Close()
					SqlServerObj.ExecSqlStoredProc("AddClassProp", addParams)

				ElseIf procType = "Delete" Then

					addParams = New Object() {clsObjProp.Key}
					paramName = New Object() {"@ClassPropID"}
					SqlServerObj.SqlObject.Close()
					SqlServerObj.ExecSqlStoredProc("DeleteClassProps", addParams)

				End If

			End If
		Catch ex As Exception

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

			DbObj.SqlObject.Open()
			DatabaseInfo = SqlServerObj.GetSqlData(sqlString)
			Return DatabaseInfo

		Catch ex As Exception
			Console.WriteLine(ex)
			Return Nothing
		End Try

	End Function

End Module
