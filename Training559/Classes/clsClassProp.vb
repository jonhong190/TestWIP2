Public Class clsClassProp

	Property name As String ' holds name of the property (JH 2-4-19)
	Property arrayIndex As Integer ' holds array index of the property (JH 2-4-19)
	Property parentKey As Integer ' holds the parentKey of the property(JH 2-4-19)
	Property key As Integer ' holds the key of the property (JH 2-4-19)

	Sub New()

	End Sub
	''' <summary>
	''' Constructor for creating new instantiations of clsClassProp objects(JH 2-11-19)
	''' </summary>
	''' <param name="name">Name parameter</param>
	''' <param name="arrayIndex">ArrayIndex parameter</param>
	''' <param name="parentKey">Parent Key Parameter</param>
	''' <param name="key">Optional key parameter</param>
	Sub New(name As String, arrayIndex As Integer, parentKey As ULong, Optional key As ULong = Nothing)

		ClassAndPropsKeyIndex += 1
		Me.name = name
		Me.arrayIndex = arrayIndex
		Me.parentKey = parentKey
		If key Then
			Me.key = key
		Else
			Me.key = ClassAndPropsKeyIndex
		End If
		dClassAndPropsByKey(Me.parentKey).props.Insert(Me.arrayIndex, Me.name, Me)
		dClassAndPropsByKey.Add(Me.key, Me)


	End Sub

	''' <summary>
	''' Removes this object from dclassAndPropsByKey (JH 2-4-19)
	''' </summary>
	Sub Remove()
		dClasses(dClassAndPropsByKey(parentKey).name).props.RemoveAt(arrayIndex)
		'dClassAndPropsByKey(parentKey).props.RemoveAt(arrayIndex)

		If dClassAndPropsByKey.Count > 0 Then
			ReIndexDtClassPropsColumns(parentKey)
		End If
		dClassAndPropsByKey.Remove(key)

	End Sub

End Class
