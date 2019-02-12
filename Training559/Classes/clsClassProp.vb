Public Class clsClassProp

	Property Name As String ' holds name of the property (JH 2-4-19)
	Property ArrayIndex As Integer ' holds array index of the property (JH 2-4-19)
	Property ParentKey As Integer ' holds the parentKey of the property(JH 2-4-19)
	Property Key As Integer ' holds the key of the property (JH 2-4-19)

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
		Me.Name = name
		Me.ArrayIndex = arrayIndex
		Me.ParentKey = parentKey
		If key Then
			Me.Key = key
		Else
			Me.Key = ClassAndPropsKeyIndex
		End If
		dClassAndPropsByKey(Me.ParentKey).props.Insert(Me.ArrayIndex, Me.Name, Me)
		dClassAndPropsByKey.Add(Me.Key, Me)


	End Sub

	''' <summary>
	''' Removes this object from dclassAndPropsByKey (JH 2-4-19)
	''' </summary>
	Sub Remove()
		dClassAndPropsByKey.Remove(Key)
	End Sub

End Class
