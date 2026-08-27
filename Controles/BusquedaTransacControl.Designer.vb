<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BusquedaTransacControl
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.SearchBtn = New System.Windows.Forms.Button()
        Me.NameTxt = New System.Windows.Forms.TextBox()
        Me.CodTxt = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'SearchBtn
        '
        Me.SearchBtn.Location = New System.Drawing.Point(340, 3)
        Me.SearchBtn.Name = "SearchBtn"
        Me.SearchBtn.Size = New System.Drawing.Size(27, 19)
        Me.SearchBtn.TabIndex = 3
        Me.SearchBtn.Text = "▼"
        Me.SearchBtn.UseVisualStyleBackColor = True
        '
        'NameTxt
        '
        Me.NameTxt.Location = New System.Drawing.Point(52, 2)
        Me.NameTxt.MaxLength = 50
        Me.NameTxt.Name = "NameTxt"
        Me.NameTxt.Size = New System.Drawing.Size(286, 20)
        Me.NameTxt.TabIndex = 2
        '
        'CodTxt
        '
        Me.CodTxt.Location = New System.Drawing.Point(2, 2)
        Me.CodTxt.MaxLength = 10
        Me.CodTxt.Name = "CodTxt"
        Me.CodTxt.Size = New System.Drawing.Size(48, 20)
        Me.CodTxt.TabIndex = 1
        '
        'BusquedaTransacControl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SearchBtn)
        Me.Controls.Add(Me.NameTxt)
        Me.Controls.Add(Me.CodTxt)
        Me.Name = "BusquedaTransacControl"
        Me.Size = New System.Drawing.Size(369, 23)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SearchBtn As Button
    Friend WithEvents NameTxt As TextBox
    Friend WithEvents CodTxt As TextBox
End Class
