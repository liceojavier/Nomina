<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultaJefes
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaJefes))
        Me.gpChofer = New System.Windows.Forms.GroupBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textEmpleado = New System.Windows.Forms.TextBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpRepores = New System.Windows.Forms.GroupBox()
        Me.rbAuto = New System.Windows.Forms.RadioButton()
        Me.rbSubordinado = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gpCiclo = New System.Windows.Forms.GroupBox()
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.gpChofer.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpRepores.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gpCiclo.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpChofer
        '
        Me.gpChofer.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpChofer.Controls.Add(Me.btnEmpleado)
        Me.gpChofer.Controls.Add(Me.textNombreEmple)
        Me.gpChofer.Controls.Add(Me.textEmpleado)
        Me.gpChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpChofer.ForeColor = System.Drawing.Color.White
        Me.gpChofer.Location = New System.Drawing.Point(399, 0)
        Me.gpChofer.Name = "gpChofer"
        Me.gpChofer.Size = New System.Drawing.Size(565, 40)
        Me.gpChofer.TabIndex = 3
        Me.gpChofer.TabStop = False
        Me.gpChofer.Text = "Evaluador"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(493, 7)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(60, 30)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEmpleado, "Evaluador")
        Me.btnEmpleado.UseVisualStyleBackColor = False
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
        Me.ImageNuevos.Images.SetKeyName(14, "buscar1.png")
        Me.ImageNuevos.Images.SetKeyName(15, "reportever.png")
        Me.ImageNuevos.Images.SetKeyName(16, "mostrar.png")
        Me.ImageNuevos.Images.SetKeyName(17, "detalle.png")
        Me.ImageNuevos.Images.SetKeyName(18, "fecha.png")
        Me.ImageNuevos.Images.SetKeyName(19, "open.png")
        Me.ImageNuevos.Images.SetKeyName(20, "menos.png")
        '
        'textNombreEmple
        '
        Me.textNombreEmple.BackColor = System.Drawing.Color.White
        Me.textNombreEmple.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombreEmple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombreEmple.Location = New System.Drawing.Point(76, 14)
        Me.textNombreEmple.MaxLength = 40
        Me.textNombreEmple.Name = "textNombreEmple"
        Me.textNombreEmple.Size = New System.Drawing.Size(394, 20)
        Me.textNombreEmple.TabIndex = 2
        '
        'textEmpleado
        '
        Me.textEmpleado.BackColor = System.Drawing.Color.White
        Me.textEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textEmpleado.Location = New System.Drawing.Point(16, 14)
        Me.textEmpleado.MaxLength = 6
        Me.textEmpleado.Name = "textEmpleado"
        Me.textEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textEmpleado.TabIndex = 1
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(1049, 4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 5
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnGenerar
        '
        Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.ImageKey = "reportegenerar.png"
        Me.btnGenerar.ImageList = Me.ImageNuevos
        Me.btnGenerar.Location = New System.Drawing.Point(970, 4)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(80, 30)
        Me.btnGenerar.TabIndex = 4
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGenerar, "Generar")
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'crv
        '
        Me.crv.ActiveViewIndex = -1
        Me.crv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv.Location = New System.Drawing.Point(0, 68)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.ShowCloseButton = False
        Me.crv.ShowGotoPageButton = False
        Me.crv.ShowGroupTreeButton = False
        Me.crv.ShowRefreshButton = False
        Me.crv.ShowTextSearchButton = False
        Me.crv.Size = New System.Drawing.Size(1130, 537)
        Me.crv.TabIndex = 67
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'gpRepores
        '
        Me.gpRepores.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpRepores.Controls.Add(Me.rbAuto)
        Me.gpRepores.Controls.Add(Me.rbSubordinado)
        Me.gpRepores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpRepores.ForeColor = System.Drawing.Color.White
        Me.gpRepores.Location = New System.Drawing.Point(121, 0)
        Me.gpRepores.Name = "gpRepores"
        Me.gpRepores.Size = New System.Drawing.Size(263, 40)
        Me.gpRepores.TabIndex = 2
        Me.gpRepores.TabStop = False
        Me.gpRepores.Text = "Tipo Evaluación"
        '
        'rbAuto
        '
        Me.rbAuto.AutoSize = True
        Me.rbAuto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbAuto.Location = New System.Drawing.Point(125, 16)
        Me.rbAuto.Name = "rbAuto"
        Me.rbAuto.Size = New System.Drawing.Size(103, 17)
        Me.rbAuto.TabIndex = 2
        Me.rbAuto.Text = "Auto Evaluación"
        Me.rbAuto.UseVisualStyleBackColor = True
        '
        'rbSubordinado
        '
        Me.rbSubordinado.AutoSize = True
        Me.rbSubordinado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSubordinado.Location = New System.Drawing.Point(6, 16)
        Me.rbSubordinado.Name = "rbSubordinado"
        Me.rbSubordinado.Size = New System.Drawing.Size(113, 17)
        Me.rbSubordinado.TabIndex = 1
        Me.rbSubordinado.Text = "Hetero Evaluación"
        Me.rbSubordinado.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpCiclo)
        Me.Panel1.Controls.Add(Me.gpRepores)
        Me.Panel1.Controls.Add(Me.gpChofer)
        Me.Panel1.Controls.Add(Me.btnGenerar)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 62)
        Me.Panel1.TabIndex = 70
        '
        'gpCiclo
        '
        Me.gpCiclo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpCiclo.Controls.Add(Me.txtCiclo)
        Me.gpCiclo.ForeColor = System.Drawing.Color.White
        Me.gpCiclo.Location = New System.Drawing.Point(11, 0)
        Me.gpCiclo.Name = "gpCiclo"
        Me.gpCiclo.Size = New System.Drawing.Size(84, 41)
        Me.gpCiclo.TabIndex = 1
        Me.gpCiclo.TabStop = False
        Me.gpCiclo.Text = "Ciclo"
        '
        'txtCiclo
        '
        Me.txtCiclo.BackColor = System.Drawing.Color.White
        Me.txtCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCiclo.ForeColor = System.Drawing.Color.Red
        Me.txtCiclo.Location = New System.Drawing.Point(10, 14)
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(54, 22)
        Me.txtCiclo.TabIndex = 0
        Me.txtCiclo.TabStop = False
        '
        'frmConsultaJefes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaJefes"
        Me.Text = "Consulta Jefes"
        Me.gpChofer.ResumeLayout(False)
        Me.gpChofer.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpRepores.ResumeLayout(False)
        Me.gpRepores.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.gpCiclo.ResumeLayout(False)
        Me.gpCiclo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpChofer As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents textEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpRepores As System.Windows.Forms.GroupBox
    Friend WithEvents rbAuto As System.Windows.Forms.RadioButton
    Friend WithEvents rbSubordinado As System.Windows.Forms.RadioButton
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gpCiclo As GroupBox
    Friend WithEvents txtCiclo As TextBox
End Class
