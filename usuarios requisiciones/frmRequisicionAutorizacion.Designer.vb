<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRequisicionAutorizacion
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
        Me.components = New System.ComponentModel.Container
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.gpEmpresa = New System.Windows.Forms.GroupBox
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox
        Me.btnLimpiar = New System.Windows.Forms.Button
        Me.gpGeneral = New System.Windows.Forms.GroupBox
        Me.btnEliminar = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.TextEmpleado1 = New System.Windows.Forms.TextBox
        Me.TextNombEmpleado1 = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnSubalterno = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.BtnSave = New System.Windows.Forms.Button
        Me.gpCentro = New System.Windows.Forms.GroupBox
        Me.TextEmpleado = New System.Windows.Forms.TextBox
        Me.TextNombEmpleado = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.btnEmpleado = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.tt1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.tt2 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        Me.gpGeneral.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gpCentro.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Location = New System.Drawing.Point(33, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(575, 60)
        Me.Panel1.TabIndex = 14
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(20, 3)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(360, 43)
        Me.gpEmpresa.TabIndex = 13
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "EMPRESA"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(10, 16)
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(344, 21)
        Me.TextNombEmpresa.TabIndex = 1
        Me.TextNombEmpresa.TabStop = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.Location = New System.Drawing.Point(423, 5)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(64, 52)
        Me.btnLimpiar.TabIndex = 12
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'gpGeneral
        '
        Me.gpGeneral.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpGeneral.BackColor = System.Drawing.Color.AliceBlue
        Me.gpGeneral.Controls.Add(Me.btnEliminar)
        Me.gpGeneral.Controls.Add(Me.GroupBox1)
        Me.gpGeneral.Controls.Add(Me.BtnSave)
        Me.gpGeneral.Controls.Add(Me.gpCentro)
        Me.gpGeneral.Location = New System.Drawing.Point(32, 67)
        Me.gpGeneral.Name = "gpGeneral"
        Me.gpGeneral.Size = New System.Drawing.Size(576, 202)
        Me.gpGeneral.TabIndex = 15
        Me.gpGeneral.TabStop = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEliminar.ImageKey = "cancelar.png"
        Me.btnEliminar.Location = New System.Drawing.Point(506, 19)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(64, 52)
        Me.btnEliminar.TabIndex = 10
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.TextEmpleado1)
        Me.GroupBox1.Controls.Add(Me.TextNombEmpleado1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnSubalterno)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(16, 93)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(480, 64)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "AUTORIZADOR NIVEL1"
        '
        'TextEmpleado1
        '
        Me.TextEmpleado1.BackColor = System.Drawing.Color.White
        Me.TextEmpleado1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEmpleado1.Location = New System.Drawing.Point(8, 32)
        Me.TextEmpleado1.MaxLength = 4
        Me.TextEmpleado1.Name = "TextEmpleado1"
        Me.TextEmpleado1.Size = New System.Drawing.Size(64, 20)
        Me.TextEmpleado1.TabIndex = 5
        '
        'TextNombEmpleado1
        '
        Me.TextNombEmpleado1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpleado1.Location = New System.Drawing.Point(72, 32)
        Me.TextNombEmpleado1.MaxLength = 30
        Me.TextNombEmpleado1.Name = "TextNombEmpleado1"
        Me.TextNombEmpleado1.Size = New System.Drawing.Size(328, 20)
        Me.TextNombEmpleado1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(72, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "NOMBRE"
        '
        'btnSubalterno
        '
        Me.btnSubalterno.BackColor = System.Drawing.SystemColors.Control
        Me.btnSubalterno.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubalterno.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSubalterno.ImageKey = "usuario.png"
        Me.btnSubalterno.Location = New System.Drawing.Point(408, 8)
        Me.btnSubalterno.Name = "btnSubalterno"
        Me.btnSubalterno.Size = New System.Drawing.Size(64, 52)
        Me.btnSubalterno.TabIndex = 7
        Me.btnSubalterno.Text = "Usuario"
        Me.btnSubalterno.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSubalterno.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(55, 13)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "CÓDIGO"
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.SystemColors.Control
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSave.ImageKey = "guardar.png"
        Me.BtnSave.Location = New System.Drawing.Point(506, 105)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(64, 52)
        Me.BtnSave.TabIndex = 11
        Me.BtnSave.Text = "Guardar"
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'gpCentro
        '
        Me.gpCentro.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpCentro.Controls.Add(Me.TextEmpleado)
        Me.gpCentro.Controls.Add(Me.TextNombEmpleado)
        Me.gpCentro.Controls.Add(Me.Label19)
        Me.gpCentro.Controls.Add(Me.btnEmpleado)
        Me.gpCentro.Controls.Add(Me.Label4)
        Me.gpCentro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCentro.Location = New System.Drawing.Point(16, 16)
        Me.gpCentro.Name = "gpCentro"
        Me.gpCentro.Size = New System.Drawing.Size(480, 64)
        Me.gpCentro.TabIndex = 2
        Me.gpCentro.TabStop = False
        Me.gpCentro.Text = "USUARIO"
        '
        'TextEmpleado
        '
        Me.TextEmpleado.BackColor = System.Drawing.Color.White
        Me.TextEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEmpleado.Location = New System.Drawing.Point(8, 32)
        Me.TextEmpleado.MaxLength = 4
        Me.TextEmpleado.Name = "TextEmpleado"
        Me.TextEmpleado.Size = New System.Drawing.Size(64, 20)
        Me.TextEmpleado.TabIndex = 1
        '
        'TextNombEmpleado
        '
        Me.TextNombEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpleado.Location = New System.Drawing.Point(72, 32)
        Me.TextNombEmpleado.MaxLength = 30
        Me.TextNombEmpleado.Name = "TextNombEmpleado"
        Me.TextNombEmpleado.Size = New System.Drawing.Size(328, 20)
        Me.TextNombEmpleado.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(72, 16)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(60, 13)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "NOMBRE"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.Location = New System.Drawing.Point(408, 8)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(64, 52)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.Text = "Usuario"
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEmpleado.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "CÓDIGO"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'frmRequisicionAutorizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(620, 291)
        Me.Controls.Add(Me.gpGeneral)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frmRequisicionAutorizacion"
        Me.Text = "frmRequisicionAutorizacion"
        Me.Panel1.ResumeLayout(False)
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        Me.gpGeneral.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpCentro.ResumeLayout(False)
        Me.gpCentro.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents gpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextEmpleado1 As System.Windows.Forms.TextBox
    Friend WithEvents TextNombEmpleado1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSubalterno As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents gpCentro As System.Windows.Forms.GroupBox
    Friend WithEvents TextEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents TextNombEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents tt1 As System.Windows.Forms.ToolTip
    Friend WithEvents tt2 As System.Windows.Forms.ToolTip
End Class
