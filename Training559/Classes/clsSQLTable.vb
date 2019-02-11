Public Class clsSQLTable

	Property Name As String
	Property NumberOfCols As Integer

	Sub New(Name As String, NumberOfCols As Integer)
		Me.Name = Name
		Me.NumberOfCols = NumberOfCols
	End Sub

End Class
