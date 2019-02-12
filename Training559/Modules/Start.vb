Imports System.Collections.Specialized

Module Start

	Public defaultTxt As String = "--Server Log Loaded--" ' ** default text for the server text box (JH 1-28-19)
	Public ClassAndPropsKeyIndex As UInteger = 0 ' ** holds the current class count (JH 1-29-19)
	Public selectedClass As String '** holds the currently seleted class from the drop down (JH 1-28-19)
	Public dClasses As OrderedDictionary = New OrderedDictionary '** dictionary to hold all the clsclass objs (JH 2-4-19)
	Public dClassAndPropsByKey As Dictionary(Of ULong, Object) = New Dictionary(Of ULong, Object) '** dictionary to hold all clsclass and clsclassProp objs (JH 2-4-19)
	Public dtClasses As DataTable ' holds the data table used in dgClasses screen object (JH 2-7-19)
	Public dtClassProps As DataTable ' holds the data table used for dgClassProps screen object (JH 2-7-19)
	Public clsPropToDeleteID As Integer 'stores the id of the class prop to delete (JH 2-7-19)
	Public DatabaseInfo As OrderedDictionary = New OrderedDictionary ' stores DB table and column names (JH 2-11-19)
	Public paramName As New Object() '* global array to hold parameter names when passing values to the DB stored procedures (JH 2-6-19)
	Public SqlServerObj As clsSQLServer '** holds the clsSQLServer class object (JH 2-6-19)
	Public dUsers As Dictionary(Of String, clsUser) = New Dictionary(Of String, clsUser) '** dictionary to hold users (JH 2-12-19)
	Public LoggedUser As clsUser '** holds the current logged in use (JH 2-12-19)




	''' <summary>
	''' Routine instanstiates new clsSQLServer class object then calls 
	''' LoadClassesFromDatabase sub (JH 2-12-19)
	''' </summary>
	Sub Startup()
		SqlServerObj = New clsSQLServer()
		CreateDgClasses()
		LoadClassesFromDatabase(SqlServerObj)
		GetAllDbTableAndCols(SqlServerObj)
	End Sub

	''' <summary>
	''' Conversion of date to current time and date (JH 1-31-19)
	''' </summary>
	''' <returns>date as a string</returns>
	Function GetCurrentDateAndTime() As String

		Dim formattedDate As String
		Try
			formattedDate = Format(Date.Now, "[MM/dd/yyyy hh:mm:ss tt]")
			Return formattedDate
		Catch ex As Exception
			Console.WriteLine(ex.GetType.ToString + " Error: " + ex.Message)
		End Try

		Return Nothing

	End Function

	''' <summary>
	''' Handles incrementing class name, uses a counter starting from 1 and increments by one as 
	''' you loop through dclasses, and checks if dclasses is missing any class names with the counter (JH 2-4-19)
	''' </summary>
	''' <param name="Name">The selected value from the drop down</param>
	''' <returns>Returns the manipulated name</returns>
	Function IncrementName(Name As String) As String

		Dim count As Integer = 1

		Try
			Name = Name & count

			If dClasses.Contains(Name) Then

				For Each item In dClasses

					count += 1
					Name = selectedClass & count

					If Not dClasses.Contains(Name) Then
						Exit For
					End If

				Next
			End If

			Return Name

		Catch ex As Exception
			Console.WriteLine(ex.GetType.ToString + " Error: " + ex.Message)
			Return Nothing
		End Try

	End Function

	''' <summary>
	''' Handles retrieving the index of the dictionary key (JH 1-31-19)
	''' </summary>
	''' <param name="Name">The name we want to search for</param>
	''' <returns>Returns the index of the name, or an error message if not found</returns>
	Function IndexByName(Name As String) As Integer

		Dim a As OrderedDictionary
		a = New OrderedDictionary

		Try
			If dClasses.Contains(Name) Then

				Dim target = dClasses.Item(Name)
				Return target.arrayIndex

			End If
		Catch ex As Exception
			Console.WriteLine(ex.GetType.ToString + " Error: " + ex.Message)
		End Try

		Return -1

	End Function

	''' <summary>
	''' handles updating index values after a delete.  Goes through the selected dictionary and makes each index value arrayIndex 
	''' incremented from 0 (JH 2-4-19)
	''' </summary>
	Sub UpdateIndex()

		Try
			For i As Integer = 1 To dClasses.Count
				dClasses(i).arrayIndex = i
			Next
		Catch ex As Exception
			Console.WriteLine(ex.GetType.ToString + " Error: " + ex.Message)
		End Try

	End Sub

	''' <summary>
	''' Function takes in textbox entries for username and password then searches for matches from a dictionary
	''' of users.  If there is a match, sends the argument values to the SqlServer to process the appropriate stored procedure(JH 2-12-19)
	''' </summary>
	''' <param name="Username">username textbox entry</param>
	''' <param name="Password">password textbox entry</param>
	''' <returns></returns>
	Function ClientLoginRequest(Username As String, Password As String)
		Try

			If dUsers.ContainsKey(Username) Then
				If dUsers(Username).Password = Password Then
					Dim formatDateStr = GetCurrentDateAndTime().Substring(1, GetCurrentDateAndTime().LastIndexOf(" "))

					LoggedUser = dUsers(Username)
					LoggedUser.LastLogged = Format(Date.Now, "yyyy-MM-dd hh:mm:ss")

					SelectDBProcedure(, LoggedUser)
					Return True
				End If
			End If

			Return False

		Catch ex As Exception
			Console.WriteLine(ex.Message)
			Return False
		End Try


	End Function

	''' <summary>
	''' Function handles creating a row in the screen table (JH 2-11-19)
	''' </summary>
	''' <param name="clsObj"></param>
	Sub CreateDtRows(clsObj As Object)

		Dim row = dtClasses.NewRow()
		row("Key") = clsObj.Value("ClassID")
		row("ClassName") = clsObj.Value("ClassName")
		row("ArrayIndex") = clsObj.Value("ArrayIndex")
		dtClasses.Rows.Add(row)

	End Sub

	''' <summary>
	''' Handles creating inital columns for DtClasses, rows are added as the DB query fills dClasses and dclassAndPropsByKey dictionaries (JH 2-7-19)
	''' </summary>
	Sub CreateDgClasses()

		Dim colHeadersArray As String() = New String() {"Key", "ClassName", "ArrayIndex"}
		dtClasses = New DataTable("Classes")

		For i As Integer = 0 To colHeadersArray.Length - 1

			Dim col As DataColumn = New DataColumn()
			col.ColumnName = colHeadersArray(i)
			col.ReadOnly = True
			col.Unique = True
			dtClasses.Columns.Add(col)

		Next

	End Sub

	''' <summary>
	''' Function handles replacing the screen table rows after a class is deleted(JH 2-11-19)
	''' </summary>
	Sub ReplaceDtClassRows()

		dtClasses.Clear()
		CreateDgClasses()

		For Each item In dClasses

			Dim row = dtClasses.NewRow()
			row("Key") = item.Value.Key
			row("ClassName") = item.Value.Name
			row("ArrayIndex") = item.Value.ArrayIndex
			dtClasses.Rows.Add(row)

		Next

	End Sub
	''' <summary>
	''' Handles creating the dgClassProps table (JH 2-7-19)
	''' </summary>
	''' <param name="key">key of element</param>
	Sub CreateDgClassProps(key As Integer)

		Dim colHeadersArray As String() = New String() {"Key", "PropName", "ArrayIndex"}
		dtClassProps = New DataTable("ClassProps")

		For i As Integer = 0 To colHeadersArray.Length - 1

			Dim col As DataColumn = New DataColumn()
			col.ColumnName = colHeadersArray(i)
			col.ReadOnly = True
			col.Unique = True
			dtClassProps.Columns.Add(col)

		Next

		For Each item In dClassAndPropsByKey(key).props

			Dim row As DataRow
			row = dtClassProps.NewRow()
			row("Key") = item.Value.key
			row("PropName") = item.Value.name
			row("ArrayIndex") = item.Value.arrayIndex
			dtClassProps.Rows.Add(row)

		Next

	End Sub

End Module
