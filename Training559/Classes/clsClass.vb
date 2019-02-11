Imports System.Collections.Specialized

Public Class clsClass

	Property Name As String ' holds name property of this class (JH 2-4-19)
	Property Key As Integer ' holds key property of this class (JH 2-4-19)
	Property ArrayIndex As Integer ' holds array index of this class(JH 2-4-19)
	Property Props As OrderedDictionary ' holds child props in this dictionary(JH 2-4-19)

	''' <summary>
	''' Constructor used when loading data form DB (JH 2-7-19)
	''' </summary>
	Sub New(name As String, key As Integer, arrayIndex As Integer)
		Me.Name = name
		Me.ArrayIndex = arrayIndex
		Me.Key = key
		Props = New OrderedDictionary
		dClasses.Insert(arrayIndex, name, Me)
		dClassAndPropsByKey.Add(key, Me)

	End Sub


	''' <summary>
	''' Constructor for clsClass object, sets properties, and increments ClassAndPropKeysIndex, then inserts this into dclasses and 
	''' dClassAndPropsByKey(JH 2-4-19)
	''' </summary>
	Sub New()
		ClassAndPropsKeyIndex += 1
		Name = IncrementName(selectedClass)
		Key = ClassAndPropsKeyIndex
		ArrayIndex = dClasses.Count
		Props = New OrderedDictionary
		dClasses.Insert(ArrayIndex, Name, Me)
		dClassAndPropsByKey.Add(Key, Me)

	End Sub

	''' <summary>
	''' on call, clears this clsClass and clsClassProp objs from both dictionaries and clears this object props (Jh 2-4-19)
	''' </summary>
	Sub Remove()

		For i As Integer = 0 To Props.Count - 1
			Props(i).Remove()
		Next

		Props.Clear()
		dClassAndPropsByKey.Remove(Key)
		dClasses.Remove(Name)

	End Sub

End Class
