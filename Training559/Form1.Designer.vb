﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Container
	Inherits System.Windows.Forms.Form

	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> _
	Protected Overrides Sub Dispose(ByVal disposing As Boolean)
		Try
			If disposing AndAlso components IsNot Nothing Then
				components.Dispose()
			End If
		Finally
			MyBase.Dispose(disposing)
		End Try
	End Sub

	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer

	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.  
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
		Me.cmbClass = New System.Windows.Forms.ComboBox()
		Me.Label1 = New System.Windows.Forms.Label()
		Me.btnAddClass = New System.Windows.Forms.Button()
		Me.btnDeleteClass = New System.Windows.Forms.Button()
		Me.Panel1 = New System.Windows.Forms.Panel()
		Me.Label5 = New System.Windows.Forms.Label()
		Me.txtDelete = New System.Windows.Forms.TextBox()
		Me.Label4 = New System.Windows.Forms.Label()
		Me.txtCount = New System.Windows.Forms.TextBox()
		Me.Label2 = New System.Windows.Forms.Label()
		Me.txtLog = New System.Windows.Forms.TextBox()
		Me.Label3 = New System.Windows.Forms.Label()
		Me.btnClearLog = New System.Windows.Forms.Button()
		Me.Panel2 = New System.Windows.Forms.Panel()
		Me.btnSignOut = New System.Windows.Forms.Button()
		Me.btnSignIn = New System.Windows.Forms.Button()
		Me.dgClasses = New System.Windows.Forms.DataGridView()
		Me.dgClassProps = New System.Windows.Forms.DataGridView()
		Me.dgClassesLabel = New System.Windows.Forms.Label()
		Me.dgClassPropsLabel = New System.Windows.Forms.Label()
		Me.Panel1.SuspendLayout()
		Me.Panel2.SuspendLayout()
		CType(Me.dgClasses, System.ComponentModel.ISupportInitialize).BeginInit()
		CType(Me.dgClassProps, System.ComponentModel.ISupportInitialize).BeginInit()
		Me.SuspendLayout()
		'
		'cmbClass
		'
		Me.cmbClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
		Me.cmbClass.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.cmbClass.Font = New System.Drawing.Font("Arial", 10.0!, System.Drawing.FontStyle.Italic)
		Me.cmbClass.ImeMode = System.Windows.Forms.ImeMode.NoControl
		Me.cmbClass.Items.AddRange(New Object() {"Button", "Label", "Text", "Form", "List", "Grid", "Image", "Link", "File"})
		Me.cmbClass.Location = New System.Drawing.Point(24, 89)
		Me.cmbClass.Name = "cmbClass"
		Me.cmbClass.Size = New System.Drawing.Size(160, 24)
		Me.cmbClass.TabIndex = 0
		'
		'Label1
		'
		Me.Label1.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
		Me.Label1.Location = New System.Drawing.Point(21, 70)
		Me.Label1.Name = "Label1"
		Me.Label1.Size = New System.Drawing.Size(91, 16)
		Me.Label1.TabIndex = 1
		Me.Label1.Text = "Select Class"
		'
		'btnAddClass
		'
		Me.btnAddClass.BackColor = System.Drawing.Color.SteelBlue
		Me.btnAddClass.FlatAppearance.BorderSize = 0
		Me.btnAddClass.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.btnAddClass.Font = New System.Drawing.Font("Arial", 10.0!)
		Me.btnAddClass.ForeColor = System.Drawing.SystemColors.ControlLightLight
		Me.btnAddClass.Location = New System.Drawing.Point(24, 119)
		Me.btnAddClass.Name = "btnAddClass"
		Me.btnAddClass.Size = New System.Drawing.Size(160, 47)
		Me.btnAddClass.TabIndex = 2
		Me.btnAddClass.Text = "Add Class"
		Me.btnAddClass.UseVisualStyleBackColor = False
		'
		'btnDeleteClass
		'
		Me.btnDeleteClass.BackColor = System.Drawing.Color.IndianRed
		Me.btnDeleteClass.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.btnDeleteClass.Font = New System.Drawing.Font("Arial", 10.0!)
		Me.btnDeleteClass.ForeColor = System.Drawing.SystemColors.ControlLightLight
		Me.btnDeleteClass.Location = New System.Drawing.Point(24, 224)
		Me.btnDeleteClass.Name = "btnDeleteClass"
		Me.btnDeleteClass.Size = New System.Drawing.Size(160, 53)
		Me.btnDeleteClass.TabIndex = 3
		Me.btnDeleteClass.Text = "Delete Class"
		Me.btnDeleteClass.UseVisualStyleBackColor = False
		'
		'Panel1
		'
		Me.Panel1.BackColor = System.Drawing.Color.LightGray
		Me.Panel1.Controls.Add(Me.Label5)
		Me.Panel1.Controls.Add(Me.txtDelete)
		Me.Panel1.Controls.Add(Me.Label4)
		Me.Panel1.Controls.Add(Me.txtCount)
		Me.Panel1.Controls.Add(Me.Label2)
		Me.Panel1.Controls.Add(Me.Label1)
		Me.Panel1.Controls.Add(Me.cmbClass)
		Me.Panel1.Controls.Add(Me.btnDeleteClass)
		Me.Panel1.Controls.Add(Me.btnAddClass)
		Me.Panel1.Location = New System.Drawing.Point(12, 33)
		Me.Panel1.Name = "Panel1"
		Me.Panel1.Padding = New System.Windows.Forms.Padding(1)
		Me.Panel1.Size = New System.Drawing.Size(204, 444)
		Me.Panel1.TabIndex = 5
		'
		'Label5
		'
		Me.Label5.AutoSize = True
		Me.Label5.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
		Me.Label5.Location = New System.Drawing.Point(21, 180)
		Me.Label5.Name = "Label5"
		Me.Label5.Size = New System.Drawing.Size(92, 14)
		Me.Label5.TabIndex = 10
		Me.Label5.Text = "Class To Delete"
		'
		'txtDelete
		'
		Me.txtDelete.Location = New System.Drawing.Point(24, 197)
		Me.txtDelete.Name = "txtDelete"
		Me.txtDelete.Size = New System.Drawing.Size(160, 20)
		Me.txtDelete.TabIndex = 9
		'
		'Label4
		'
		Me.Label4.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Bold)
		Me.Label4.Location = New System.Drawing.Point(21, 336)
		Me.Label4.Name = "Label4"
		Me.Label4.Size = New System.Drawing.Size(69, 13)
		Me.Label4.TabIndex = 8
		Me.Label4.Text = "Count"
		'
		'txtCount
		'
		Me.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.None
		Me.txtCount.Cursor = System.Windows.Forms.Cursors.Arrow
		Me.txtCount.Location = New System.Drawing.Point(24, 352)
		Me.txtCount.Name = "txtCount"
		Me.txtCount.ReadOnly = True
		Me.txtCount.Size = New System.Drawing.Size(160, 13)
		Me.txtCount.TabIndex = 7
		'
		'Label2
		'
		Me.Label2.Font = New System.Drawing.Font("Arial", 12.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Underline), System.Drawing.FontStyle))
		Me.Label2.Location = New System.Drawing.Point(49, 18)
		Me.Label2.Name = "Label2"
		Me.Label2.Size = New System.Drawing.Size(109, 29)
		Me.Label2.TabIndex = 6
		Me.Label2.Text = "Class Editor"
		Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
		'
		'txtLog
		'
		Me.txtLog.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!)
		Me.txtLog.ForeColor = System.Drawing.Color.Blue
		Me.txtLog.Location = New System.Drawing.Point(222, 33)
		Me.txtLog.MaxLength = 100000
		Me.txtLog.MinimumSize = New System.Drawing.Size(700, 300)
		Me.txtLog.Multiline = True
		Me.txtLog.Name = "txtLog"
		Me.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
		Me.txtLog.Size = New System.Drawing.Size(750, 300)
		Me.txtLog.TabIndex = 6
		Me.txtLog.Text = "--Server Log Loaded--"
		'
		'Label3
		'
		Me.Label3.AutoSize = True
		Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		Me.Label3.ForeColor = System.Drawing.Color.CornflowerBlue
		Me.Label3.Location = New System.Drawing.Point(219, 17)
		Me.Label3.Name = "Label3"
		Me.Label3.Size = New System.Drawing.Size(79, 13)
		Me.Label3.TabIndex = 7
		Me.Label3.Text = "Server Logs:"
		'
		'btnClearLog
		'
		Me.btnClearLog.BackColor = System.Drawing.Color.SteelBlue
		Me.btnClearLog.FlatAppearance.BorderSize = 0
		Me.btnClearLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.btnClearLog.Font = New System.Drawing.Font("Arial", 10.0!)
		Me.btnClearLog.ForeColor = System.Drawing.Color.White
		Me.btnClearLog.Location = New System.Drawing.Point(863, 6)
		Me.btnClearLog.Name = "btnClearLog"
		Me.btnClearLog.Size = New System.Drawing.Size(109, 24)
		Me.btnClearLog.TabIndex = 8
		Me.btnClearLog.Text = "Clear Log"
		Me.btnClearLog.UseVisualStyleBackColor = False
		'
		'Panel2
		'
		Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
		Me.Panel2.Controls.Add(Me.btnSignOut)
		Me.Panel2.Controls.Add(Me.btnSignIn)
		Me.Panel2.Location = New System.Drawing.Point(12, 483)
		Me.Panel2.Name = "Panel2"
		Me.Panel2.Size = New System.Drawing.Size(204, 100)
		Me.Panel2.TabIndex = 9
		'
		'btnSignOut
		'
		Me.btnSignOut.BackColor = System.Drawing.Color.Crimson
		Me.btnSignOut.FlatAppearance.BorderSize = 0
		Me.btnSignOut.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.btnSignOut.Font = New System.Drawing.Font("Arial", 10.0!)
		Me.btnSignOut.ForeColor = System.Drawing.Color.White
		Me.btnSignOut.Location = New System.Drawing.Point(108, 21)
		Me.btnSignOut.Name = "btnSignOut"
		Me.btnSignOut.Size = New System.Drawing.Size(75, 51)
		Me.btnSignOut.TabIndex = 1
		Me.btnSignOut.Text = "Sign Out"
		Me.btnSignOut.UseVisualStyleBackColor = False
		'
		'btnSignIn
		'
		Me.btnSignIn.BackColor = System.Drawing.Color.MediumSeaGreen
		Me.btnSignIn.FlatAppearance.BorderSize = 0
		Me.btnSignIn.FlatStyle = System.Windows.Forms.FlatStyle.Popup
		Me.btnSignIn.Font = New System.Drawing.Font("Arial", 10.0!)
		Me.btnSignIn.ForeColor = System.Drawing.Color.White
		Me.btnSignIn.Location = New System.Drawing.Point(23, 21)
		Me.btnSignIn.Name = "btnSignIn"
		Me.btnSignIn.Size = New System.Drawing.Size(75, 51)
		Me.btnSignIn.TabIndex = 0
		Me.btnSignIn.Text = "Sign In"
		Me.btnSignIn.UseVisualStyleBackColor = False
		'
		'dgClasses
		'
		Me.dgClasses.AllowUserToAddRows = False
		Me.dgClasses.AllowUserToDeleteRows = False
		Me.dgClasses.AllowUserToResizeColumns = False
		Me.dgClasses.AllowUserToResizeRows = False
		Me.dgClasses.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgClasses.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightYellow
		DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgClasses.DefaultCellStyle = DataGridViewCellStyle1
		Me.dgClasses.Location = New System.Drawing.Point(222, 355)
		Me.dgClasses.MultiSelect = False
		Me.dgClasses.Name = "dgClasses"
		Me.dgClasses.ReadOnly = True
		Me.dgClasses.RowHeadersVisible = False
		Me.dgClasses.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
		Me.dgClasses.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgClasses.Size = New System.Drawing.Size(300, 228)
		Me.dgClasses.TabIndex = 10
		'
		'dgClassProps
		'
		Me.dgClassProps.AllowUserToAddRows = False
		Me.dgClassProps.AllowUserToDeleteRows = False
		Me.dgClassProps.AllowUserToResizeColumns = False
		Me.dgClassProps.AllowUserToResizeRows = False
		Me.dgClassProps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
		Me.dgClassProps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
		DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
		DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
		DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
		DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightYellow
		DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.ControlText
		DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
		Me.dgClassProps.DefaultCellStyle = DataGridViewCellStyle2
		Me.dgClassProps.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
		Me.dgClassProps.Location = New System.Drawing.Point(555, 355)
		Me.dgClassProps.Name = "dgClassProps"
		Me.dgClassProps.ReadOnly = True
		Me.dgClassProps.RowHeadersVisible = False
		Me.dgClassProps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
		Me.dgClassProps.Size = New System.Drawing.Size(417, 228)
		Me.dgClassProps.TabIndex = 11
		'
		'dgClassesLabel
		'
		Me.dgClassesLabel.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
		Me.dgClassesLabel.ForeColor = System.Drawing.Color.CornflowerBlue
		Me.dgClassesLabel.Location = New System.Drawing.Point(219, 336)
		Me.dgClassesLabel.Name = "dgClassesLabel"
		Me.dgClassesLabel.Size = New System.Drawing.Size(85, 16)
		Me.dgClassesLabel.TabIndex = 12
		Me.dgClassesLabel.Text = "Classes"
		'
		'dgClassPropsLabel
		'
		Me.dgClassPropsLabel.AutoSize = True
		Me.dgClassPropsLabel.Font = New System.Drawing.Font("Arial", 8.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle))
		Me.dgClassPropsLabel.ForeColor = System.Drawing.Color.CornflowerBlue
		Me.dgClassPropsLabel.Location = New System.Drawing.Point(552, 336)
		Me.dgClassPropsLabel.Name = "dgClassPropsLabel"
		Me.dgClassPropsLabel.Size = New System.Drawing.Size(96, 13)
		Me.dgClassPropsLabel.TabIndex = 13
		Me.dgClassPropsLabel.Text = "Class Properties"
		'
		'Container
		'
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.BackColor = System.Drawing.Color.LightYellow
		Me.ClientSize = New System.Drawing.Size(980, 607)
		Me.Controls.Add(Me.dgClassPropsLabel)
		Me.Controls.Add(Me.dgClassesLabel)
		Me.Controls.Add(Me.dgClassProps)
		Me.Controls.Add(Me.dgClasses)
		Me.Controls.Add(Me.Panel2)
		Me.Controls.Add(Me.btnClearLog)
		Me.Controls.Add(Me.Label3)
		Me.Controls.Add(Me.txtLog)
		Me.Controls.Add(Me.Panel1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
		Me.MinimumSize = New System.Drawing.Size(700, 500)
		Me.Name = "Container"
		Me.Text = "Server Form"
		Me.Panel1.ResumeLayout(False)
		Me.Panel1.PerformLayout()
		Me.Panel2.ResumeLayout(False)
		CType(Me.dgClasses, System.ComponentModel.ISupportInitialize).EndInit()
		CType(Me.dgClassProps, System.ComponentModel.ISupportInitialize).EndInit()
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	Friend WithEvents cmbClass As ComboBox
	Friend WithEvents Label1 As Label
	Friend WithEvents btnAddClass As Button
	Friend WithEvents btnDeleteClass As Button
	Friend WithEvents Panel1 As Panel
	Friend WithEvents Label2 As Label
	Friend WithEvents txtLog As TextBox
	Friend WithEvents Label3 As Label
	Friend WithEvents btnClearLog As Button
	Friend WithEvents Label4 As Label
	Friend WithEvents txtCount As TextBox
	Friend WithEvents Panel2 As Panel
	Friend WithEvents btnSignOut As Button
	Friend WithEvents btnSignIn As Button
	Friend WithEvents Label5 As Label
	Friend WithEvents txtDelete As TextBox
	Friend WithEvents dgClasses As DataGridView
	Friend WithEvents dgClassProps As DataGridView
	Friend WithEvents dgClassesLabel As Label
	Friend WithEvents dgClassPropsLabel As Label
End Class