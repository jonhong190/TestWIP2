Imports System.Collections.Specialized

Public Class clsClass

	Property Name As String ' holds name property of this class (JH 2-4-19)
	Property Key As Integer ' holds key property of this class (JH 2-4-19)
	Property ArrayIndex As Integer ' holds array index of this class(JH 2-4-19)
	Property Props As OrderedDictionary ' holds child props in this dictionary(JH 2-4-19)

	''' <summary>
	''' Constructor function for instantiating a new clsClass object (JH 2-11-17)
	''' </summary>
	''' <param name="name">Optional name parameter</param>
	''' <param name="key">Optional key parameter</param>
	''' <param name="arrayIndex">Optional ArrayIndex parameter</param>
	Sub New(Optional name As String = Nothing, Optional key As Integer = 0, Optional arrayIndex As Integer = 0)

		ClassAndPropsKeyIndex += 1
		If name <> Nothing Then
			Me.Name = name
		Else
			Me.Name = IncrementName(selectedClass)
		End If

		If key <> 0 Then
			Me.Key = key
		Else
			Me.Key = ClassAndPropsKeyIndex
		End If

		If arrayIndex <> 0 Then
			Me.ArrayIndex = arrayIndex
		Else
			Me.ArrayIndex = dClasses.Count
		End If

		Props = New OrderedDictionary
		dClasses.Insert(Me.ArrayIndex, Me.Name, Me)
		dClassAndPropsByKey.Add(Me.Key, Me)

	End Sub

	''' <summary>
	''' on call, clears this clsClass and clsClassProp objs from both dictionaries and clears this object props (Jh 2-4-19)
	''' </summary>
	Sub Remove()

		For i As Integer = 0 To Props.Count - 1
			dClassAndPropsByKey.Remove(Props(i).key)
		Next

		Props.Clear()
		dClassAndPropsByKey.Remove(Key)
		dClasses.Remove(Name)

	End Sub

End Class
