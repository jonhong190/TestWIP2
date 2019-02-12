Public Class clsUser
	Property Username As String = ""
	Property Password As String = ""
	Property LastLogged As Date
	Property FirstName As String = ""
	Property LastName As String = ""
	Property ActivityTimeout As Integer = 0
	Property LastActiveOn As DateTime

	Sub New(username As String, password As String, firstName As String, lastName As String, timeout As String)
		Me.Username = username
		Me.Password = password
		Me.FirstName = firstName
		Me.LastName = lastName
		ActivityTimeout = timeout
	End Sub

End Class
