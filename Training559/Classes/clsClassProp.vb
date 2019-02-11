Public Class clsClassProp

	Property Name As String ' holds name of the property (JH 2-4-19)
	Property ArrayIndex As Integer ' holds array index of the property (JH 2-4-19)
	Property ParentKey As Integer ' holds the parentKey of the property(JH 2-4-19)
	Property Key As Integer ' holds the key of the property (JH 2-4-19)

	Sub New()

	End Sub
	''' <summary>
	''' Constructor used when loading information from the DB (JH 2-7-19)
	''' </summary>
	Sub New(name As String, arrayIndex As Integer, parentKey As ULong, key As ULong)

		ClassAndPropsKeyIndex += 1
		Me.Name = name
		Me.ArrayIndex = arrayIndex
		Me.ParentKey = parentKey
		Me.Key = key
		dClassAndPropsByKey(parentKey).props.Insert(arrayIndex, name, Me)
		dClassAndPropsByKey.Add(key, Me)

	End Sub
	''' <summary>
	''' Constructor for the clsClassProp class , sets properties, and adds this to parent props and dclassAndPropsByKey (JH 2-4-19)
	''' </summary>
	Sub New(name As String, arrayIndex As Integer, parentKey As ULong)

		ClassAndPropsKeyIndex += 1
		Me.Name = name
		Key = ClassAndPropsKeyIndex
		Me.ArrayIndex = arrayIndex
		Me.ParentKey = parentKey
		dClassAndPropsByKey(parentKey).props.Insert(arrayIndex, name, Me)
		dClassAndPropsByKey.Add(Key, Me)

	End Sub

	''' <summary>
	''' Removes this object from dclassAndPropsByKey (JH 2-4-19)
	''' </summary>
	Sub Remove()
		dClassAndPropsByKey.Remove(Key)
	End Sub

End Class
