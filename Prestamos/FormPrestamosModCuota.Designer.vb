<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPrestamosModCuota
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.textCuotaN = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.textCuotaA = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'textCuotaN
        '
        Me.textCuotaN.BackColor = System.Drawing.Color.White
        Me.textCuotaN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textCuotaN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textCuotaN.Location = New System.Drawing.Point(131, 91)
        Me.textCuotaN.MaxLength = 11
        Me.textCuotaN.Name = "textCuotaN"
        Me.textCuotaN.ReadOnly = True
        Me.textCuotaN.Size = New System.Drawing.Size(75, 20)
        Me.textCuotaN.TabIndex = 144
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(12, 91)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(113, 13)
        Me.Label20.TabIndex = 145
        Me.Label20.Text = "Nuevo valor de cuota:"
        '
        'textCuotaA
        '
        Me.textCuotaA.BackColor = System.Drawing.Color.White
        Me.textCuotaA.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textCuotaA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textCuotaA.Location = New System.Drawing.Point(131, 48)
        Me.textCuotaA.MaxLength = 11
        Me.textCuotaA.Name = "textCuotaA"
        Me.textCuotaA.ReadOnly = True
        Me.textCuotaA.Size = New System.Drawing.Size(75, 20)
        Me.textCuotaA.TabIndex = 142
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(12, 48)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(111, 13)
        Me.Label19.TabIndex = 143
        Me.Label19.Text = "Valor de cuota actual:"
        '
        'FormPrestamosModCuota
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 211)
        Me.Controls.Add(Me.textCuotaN)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.textCuotaA)
        Me.Controls.Add(Me.Label19)
        Me.Name = "FormPrestamosModCuota"
        Me.Text = "Modificacion de cuota"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents textCuotaN As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents textCuotaA As TextBox
    Friend WithEvents Label19 As Label
End Class
