﻿Imports System.Collections.Specialized

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