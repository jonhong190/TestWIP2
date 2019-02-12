Public Class Container
	''' <summary>
	''' Initializes all the screen objects and variables to default settings (JH 1-29-19)
	''' </summary>
	Sub Initialize()

		txtLog.Text = defaultTxt
		cmbClass.Text = cmbClass.Items(0)
		selectedClass = cmbClass.Text
		txtDelete.Text = ""
		txtCount.Text = ClassAndPropsKeyIndex

	End Sub

	''' <summary>
	''' Creates an error message to be sent to the console and server log (JH 2-4-19)
	''' </summary>
	''' <param name="e">error object</param>
	Public Sub CreateErrorMessage(e As Exception)

		Try

			Console.WriteLine(e.GetType.ToString + " Error: " + e.Message)
			txtLog.Text += vbCrLf + GetCurrentDateAndTime() + " " + e.GetType.ToString + " Error: " + e.Message

		Catch ex As Exception
			Console.WriteLine(ex.GetType.ToString + " Error: " + ex.Message)
		End Try

	End Sub

	''' <summary>
	'''  handles on load, setting up default text, txtCount, and dropdown item (JH 1-28-19) EDIT: now just calls initialize function (JH 1-30-19)
	''' </summary>
	Public Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
		Try
			Initialize()
			Startup()
			dgClasses.DataSource = dtClasses
		Catch ex As Exception
			CreateErrorMessage(ex)
		End Try

	End Sub

	''' <summary>
	''' function changes the value of the currently selected drop down item (JH 1-28-19) EDIT: And recounts the holder count for the new selected array (JH 1-29-19)
	''' </summary>
	Public Sub cmbClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClass.SelectedIndexChanged

		Try
			selectedClass = cmbClass.Text
		Catch ex As Exception
			CreateErrorMessage(ex)

		End Try

	End Sub

	''' <summary>
	''' Handles adding a row to dtClasses after the inital database load (JH 2-7-19)
	''' </summary>
	''' <param name="clsClass">cls Class object to get row values from</param>
	Public Sub AddClassAndPropRows(clsClass As clsClass)

		Try

			Dim row As DataRow = dtClasses.NewRow()

			row("Key") = clsClass.Key
			row("ClassName") = clsClass.Name
			row("ArrayIndex") = clsClass.ArrayIndex
			dtClasses.Rows.Add(row)
			dgClasses.DataSource = dtClasses

		Catch ex As Exception
			CreateErrorMessage(ex)
		End Try

	End Sub


	''' <summary>
	''' Function handles the class add button click, and adds a row to the dgClasses screen table, instantiates a new clsClass and three clsClassProps 
	''' each followed by the InsertClassToDatabase Sub, then SetLogText sub called (JH 2-4-19)
	''' </summary>
	Public Sub btnAddClass_Click(sender As Object, e As EventArgs) Handles btnAddClass.Click

		Try
			Dim clsObj = New clsClass(, ,)
			SelectDBProcedure("Add", clsObj)
			AddClassAndPropRows(clsObj)

			Dim clsClassProp1 = New clsClassProp("Name", 0, clsObj.Key)
			SelectDBProcedure("Add", clsClassProp1)

			Dim clsClassProp2 = New clsClassProp("Enabled", 1, clsObj.Key)
			SelectDBProcedure("Add", clsClassProp2)

			Dim clsClassProp3 = New clsClassProp("Size", 2, clsObj.Key)
			SelectDBProcedure("Add", clsClassProp3)

			SetLogText(clsObj.Name, "Add")

		Catch ex As Exception
			CreateErrorMessage(ex)
		End Try

	End Sub

	''' <summary>
	''' Handles removing a row from dtClasses after user deletes a class (JH 2-7-19)
	''' </summary>
	''' <param name="index">index of class </param>
	Sub RemoveClassRow(index As Integer)

		Try

			dtClasses.Rows.RemoveAt(index)
			ReplaceDtClassRows()
			dtClassProps = Nothing
			dgClasses.DataSource = dtClasses
			dgClassProps.DataSource = dtClassProps

		Catch ex As Exception
			CreateErrorMessage(ex)
		End Try

	End Sub

	''' <summary>
	''' Handles removing a property from a specific class (JH 2-7-19)
	''' </summary>
	''' <param name="name">the property name we will look for to remove</param>
	Sub RemovePropRow(name As String)
		Try

			Dim row As DataRow() = dtClassProps.Select()

			For Each item In row
				If item("PropName") = name Then
					dtClassProps.Rows.Remove(item)
					Exit For
				End If
			Next

			dgClassProps.DataSource = dtClassProps

		Catch ex As Exception
			CreateErrorMessage(ex)
		End Try

	End Sub


	''' <summary>
	''' function checks for invalid txtToDelete entries and if the text entry is a class to delete 
	''' or a class property to delete, then finds the index of the txtToDelte entry with call to IndexbyName Function, 
	''' then if it passes validation, calls clsClass remove method, then calls UpdateIndex Sub, then SetLogText Sub (JH 2-6-19)
	''' </summary>
	Public Sub btnDeleteClass_Click(sender As Object, e As EventArgs) Handles btnDeleteClass.Click

		Try
			'class delete (JhH 2-7-19)
			If txtDelete.Text <> "" AndAlso dClasses.Contains(txtDelete.Text) Then

				Dim index = IndexByName(txtDelete.Text)
				Dim dClassesTarget = dClasses(index)

				dClasses(index).Remove()
				UpdateIndex()
				RemoveClassRow(index)
				SelectDBProcedure("Delete", dClassesTarget)
				SetLogText(dClassesTarget.name, "Minus")

				'class property delete (JH 2-7-19)
			ElseIf txtDelete.Text <> "" AndAlso dClasses.Contains(txtDelete.Text.Substring(0, txtDelete.Text.IndexOf("."))) Then

				Dim className = txtDelete.Text.Substring(0, txtDelete.Text.IndexOf("."))
				Dim propName = txtDelete.Text.Substring(txtDelete.Text.IndexOf(".") + 1)

				If txtDelete.Text.Contains("Name") Then
					SetLogText("No Name", "Minus")
				Else

					SelectDBProcedure("Delete", dClassAndPropsByKey(clsPropToDeleteID))
					RemovePropRow(propName)
					SetLogText(txtDelete.Text, "Minus")

				End If

			Else
				SetLogText("Error", "Minus")
			End If

			dClasses.Clear()
			dClassAndPropsByKey.Clear()
			Startup()

		Catch ex As Exception
			CreateErrorMessage(ex)
		End Try

	End Sub


	''' <summary>
	''' On clear call initialize (JH 1-29-19)
	''' </summary>
	Public Sub brnClearLog_Click(sender As Object, e As EventArgs) Handles btnClearLog.Click

		Try
			Initialize()
		Catch ex As Exception
			CreateErrorMessage(ex)
		End Try

	End Sub

	''' <summary>
	''' on signout , disable all screen components (JH 1-29-19)
	''' </summary>
	Private Sub btnSignOut_Click(sender As Object, e As EventArgs) Handles btnSignOut.Click

		Try
			cmbClass.Enabled = False
			btnAddClass.Enabled = False
			btnDeleteClass.Enabled = False
			txtLog.Enabled = False
			txtCount.Enabled = False
			btnClearLog.Enabled = False
			txtDelete.Enabled = False
		Catch ex As Exception
			CreateErrorMessage(ex)
		End Try

	End Sub

	''' <summary>
	''' on sign in, enable all screen components (JH 1-29-19)
	''' </summary>
	Private Sub btnSignIn_Click(sender As Object, e As EventArgs) Handles btnSignIn.Click

		Try
			cmbClass.Enabled = True
			btnAddClass.Enabled = True
			btnDeleteClass.Enabled = True
			txtLog.Enabled = True
			txtCount.Enabled = True
			btnClearLog.Enabled = True
			txtDelete.Enabled = True
		Catch ex As Exception
			CreateErrorMessage(ex)
		End Try

	End Sub

	''' <summary>
	''' function formats LogTimeStamp, determines the operation,if minus then checks if the appropriate count is at zero, then creates the string sent to display in the txtLog , then calls the setClassCount method(JH 1-29-19)
	''' </summary>
	''' <param name="selection"> The currently selected class </param>
	''' <param name="operation"> Which operation button was pressed </param>
	Public Sub SetLogText(selection As String, operation As String)

		Try

			If operation = "Add" Then
				txtLog.Text += vbCrLf & GetCurrentDateAndTime() & " Class " & selection & " was added to the Server. "
			ElseIf operation = "Minus" Then

				If selection = "Error" Then
					txtLog.Text += vbCrLf & GetCurrentDateAndTime() & "Invalid delete entry. Please enter an exisiting class."
				ElseIf selection = "No Name" Then
					txtLog.Text += vbCrLf & GetCurrentDateAndTime() & "Cannot remove a 'Name' property."
				Else
					txtLog.Text += vbCrLf & GetCurrentDateAndTime() & "Class " & selection & " was removed from the Server."

				End If

			End If

			txtCount.Text = ClassAndPropsKeyIndex

		Catch ex As Exception
			CreateErrorMessage(ex)
		End Try

	End Sub
	''' <summary>
	''' On cell click, take entire row and send the name of class to txtDelete text box (JH 2-7-19)
	''' </summary>
	Private Sub dgClasses_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgClasses.CellClick

		If sender.selectedCells(0).value Then
			CreateDgClassProps(sender.selectedCells(0).value)
			dgClassProps.DataSource = dtClassProps
			txtDelete.Text = sender.selectedCells(1).value
		End If

	End Sub

	''' <summary>
	''' on click, take entire row and add name of class property to the txtDelete text box, then set a classProp Key to the 
	''' clsPropToDeleteID global variable, and send that to the SerializeClsProp Sub (JH 2-11-19)
	''' </summary>
	Private Sub dgClassProps_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgClassProps.CellClick

		If sender.selectedCells(0).value Then

			If Not txtDelete.Text.IndexOf(".") Then

				Dim leftStr = txtDelete.Text.Substring(0, txtDelete.Text.IndexOf("."))
				txtDelete.Text = leftStr & "." & sender.selectedCells(1).value

			Else
				txtDelete.Text += "." & sender.selectedCells(1).value
			End If

			clsPropToDeleteID = sender.selectedCells(0).value
			SerializeClsProp(dClassAndPropsByKey(sender.selectedCells(0).value))


		End If

	End Sub

End Class
