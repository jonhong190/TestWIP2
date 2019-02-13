Imports System.Collections.Specialized
Imports System.Data.SqlClient

Public Class clsSQLServer

	Public ConnectionString As String 'holds the connection string to get to DB Server (JH 2-7-19)
	Public SqlObject As SqlConnection ' holds the sqlConnectino object (JH 2-7-19)
	Public Command As New SqlCommand() ' variable to hold command object (JH 2-7-19)
	Public Reader As SqlDataReader ' variable to hold the reader sql object (JH 2-7-19)
	Public DataDict As OrderedDictionary ' variable to hold query objects to return to dclasses and dclassPropsByKey (JH 2-7-19)

	''' <summary>
	''' Constructor that sets and opens inital db connection (JH 2-7-19)
	''' </summary>
	Sub New()
		ConnectionString = "Server=.\SQLEXPRESS;Database=SQL_Training;" & "Integrated Security=SSPI;"
		SqlObject = New SqlConnection(ConnectionString)
		SqlObject.Open()
		dClassAndPropsByKey.Clear()
		dClasses.Clear()
		LoadUsersFromDatabase()
	End Sub


	''' <summary>
	''' FUnction that takes in a query and returns the data with DataDict property (JH 2-7-19)
	''' </summary>
	''' <param name="query">Query String</param>
	''' <returns>DataDict</returns>
	Public Function GetSqlData(query As String) As OrderedDictionary

		DataDict = New OrderedDictionary
		Dim count As Integer = 0

		Command.CommandText = query
		Command.Connection = SqlObject
		Reader = Command.ExecuteReader()

		While Reader.Read()
			Dim tempDict As OrderedDictionary = New OrderedDictionary()

			For i As Integer = 0 To Reader.FieldCount - 1
				tempDict.Add(Reader.GetName(i), Reader(i))
			Next

			DataDict.Add(count, tempDict)
			count += 1
		End While

		Reader.Close()
		Return DataDict

	End Function

	''' <summary>
	''' Function handles executing a DB stored procedure based on the provided procedure name and parameter values (JH 2-7-19)
	''' </summary>
	''' <param name="ProcName">Procedure Name</param>
	''' <param name="ParamValues">Array of parameters to be sent to said stored procedure</param>
	''' <returns></returns>
	Public Function ExecSqlStoredProc(ProcName As String, Optional ParamValues As Object() = Nothing) As Boolean

		Command.CommandType = CommandType.StoredProcedure
		Command.CommandText = ProcName
		Command.Connection = SqlObject
		Command.Parameters.Clear()

		If Not (ParamValues Is Nothing) Then

			For i As Integer = 0 To ParamValues.Length - 1
				Dim param As New SqlParameter(paramName(i).ToString, ParamValues(i))
				Command.Parameters.Add(param)
			Next

		End If

		Try
			Command.ExecuteNonQuery()
			Reader.Close()
			Return True
		Catch ex As Exception
			Console.WriteLine(ex.Message)
			Reader.Close()
			Return False
		End Try

	End Function

	Function LoadUsersFromDatabase()

		Command.CommandText = "Select * FROM Users"
		Command.Connection = SqlObject
		Reader = Command.ExecuteReader()

		While Reader.Read()

			Dim user As clsUser = New clsUser(Reader.Item("Username"), Reader.Item("Password"), Reader.Item("FirstName"), Reader.Item("LastName"), Reader.Item("ActivityTimeout"))
			dUsers.Add(Reader.Item("Username"), user)

		End While

		Reader.Close()
		Return dUsers

	End Function

End Class
