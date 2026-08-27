<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIntegraciones
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIntegraciones))
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpTransac = New System.Windows.Forms.GroupBox()
        Me.rbAguinaldo = New System.Windows.Forms.RadioButton()
        Me.rbBono = New System.Windows.Forms.RadioButton()
        Me.rbIndem = New System.Windows.Forms.RadioButton()
        Me.gpFecha.SuspendLayout()
        Me.gpTransac.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpFecha
        '
        Me.gpFecha.Controls.Add(Me.Label3)
        Me.gpFecha.Controls.Add(Me.TextAño)
        Me.gpFecha.Controls.Add(Me.btnEjecutar)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.Location = New System.Drawing.Point(258, 33)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(223, 49)
        Me.gpFecha.TabIndex = 2
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Periodo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Año:"
        '
        'TextAño
        '
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(48, 26)
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(56, 20)
        Me.TextAño.TabIndex = 2
        '
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "checkok.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(119, 16)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(83, 30)
        Me.btnEjecutar.TabIndex = 3
        Me.btnEjecutar.Text = "Aceptar"
        Me.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEjecutar.UseVisualStyleBackColor = False
        '
        'ImageNuevos
        '
        Me.ImageNuevos.ImageStream = CType(resources.GetObject("ImageNuevos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageNuevos.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageNuevos.Images.SetKeyName(0, "buscar2.png")
        Me.ImageNuevos.Images.SetKeyName(1, "limpiar.png")
        Me.ImageNuevos.Images.SetKeyName(2, "guardar.png")
        Me.ImageNuevos.Images.SetKeyName(3, "cancelar.png")
        Me.ImageNuevos.Images.SetKeyName(4, "familia.png")
        Me.ImageNuevos.Images.SetKeyName(5, "usuario.png")
        Me.ImageNuevos.Images.SetKeyName(6, "actualizar.png")
        Me.ImageNuevos.Images.SetKeyName(7, "anterior.png")
        Me.ImageNuevos.Images.SetKeyName(8, "siguiente.png")
        Me.ImageNuevos.Images.SetKeyName(9, "mas.png")
        Me.ImageNuevos.Images.SetKeyName(10, "edit1.png")
        Me.ImageNuevos.Images.SetKeyName(11, "reportegenerar.png")
        Me.ImageNuevos.Images.SetKeyName(12, "impresora2.png")
        Me.ImageNuevos.Images.SetKeyName(13, "checkok.png")
        '
        'gpTransac
        '
        Me.gpTransac.Controls.Add(Me.rbIndem)
        Me.gpTransac.Controls.Add(Me.rbBono)
        Me.gpTransac.Controls.Add(Me.rbAguinaldo)
        Me.gpTransac.Location = New System.Drawing.Point(27, 23)
        Me.gpTransac.Name = "gpTransac"
        Me.gpTransac.Size = New System.Drawing.Size(200, 93)
        Me.gpTransac.TabIndex = 3
        Me.gpTransac.TabStop = False
        Me.gpTransac.Text = "Transacción"
        '
        'rbAguinaldo
        '
        Me.rbAguinaldo.AutoSize = True
        Me.rbAguinaldo.Location = New System.Drawing.Point(6, 19)
        Me.rbAguinaldo.Name = "rbAguinaldo"
        Me.rbAguinaldo.Size = New System.Drawing.Size(72, 17)
        Me.rbAguinaldo.TabIndex = 0
        Me.rbAguinaldo.TabStop = True
        Me.rbAguinaldo.Text = "Aguinaldo"
        Me.rbAguinaldo.UseVisualStyleBackColor = True
        '
        'rbBono
        '
        Me.rbBono.AutoSize = True
        Me.rbBono.Location = New System.Drawing.Point(6, 42)
        Me.rbBono.Name = "rbBono"
        Me.rbBono.Size = New System.Drawing.Size(65, 17)
        Me.rbBono.TabIndex = 1
        Me.rbBono.TabStop = True
        Me.rbBono.Text = "Bono 14"
        Me.rbBono.UseVisualStyleBackColor = True
        '
        'rbIndem
        '
        Me.rbIndem.AutoSize = True
        Me.rbIndem.Location = New System.Drawing.Point(6, 65)
        Me.rbIndem.Name = "rbIndem"
        Me.rbIndem.Size = New System.Drawing.Size(93, 17)
        Me.rbIndem.TabIndex = 2
        Me.rbIndem.TabStop = True
        Me.rbIndem.Text = "Indemnizacion"
        Me.rbIndem.UseVisualStyleBackColor = True
        '
        'frmIntegraciones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(580, 137)
        Me.Controls.Add(Me.gpTransac)
        Me.Controls.Add(Me.gpFecha)
        Me.Name = "frmIntegraciones"
        Me.Text = "Integraciones pasivos laborales"
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        Me.gpTransac.ResumeLayout(False)
        Me.gpTransac.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gpFecha As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TextAño As TextBox
    Friend WithEvents btnEjecutar As Button
    Friend WithEvents ImageNuevos As ImageList
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents gpTransac As GroupBox
    Friend WithEvents rbIndem As RadioButton
    Friend WithEvents rbBono As RadioButton
    Friend WithEvents rbAguinaldo As RadioButton
End Class
