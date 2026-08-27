<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReporteador
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReporteador))
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.TextFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextHorario = New System.Windows.Forms.TextBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'crv
        '
        Me.crv.ActiveViewIndex = -1
        Me.crv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv.Location = New System.Drawing.Point(0, 80)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.Size = New System.Drawing.Size(1130, 525)
        Me.crv.TabIndex = 0
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv.ViewTimeSelectionFormula = ""
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
        'TextFecha
        '
        Me.TextFecha.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TextFecha.BackColor = System.Drawing.Color.White
        Me.TextFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFecha.Location = New System.Drawing.Point(902, 8)
        Me.TextFecha.Mask = "##/##/####"
        Me.TextFecha.Name = "TextFecha"
        Me.TextFecha.Size = New System.Drawing.Size(84, 20)
        Me.TextFecha.TabIndex = 2
        '
        'Label32
        '
        Me.Label32.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.ForeColor = System.Drawing.Color.White
        Me.Label32.Location = New System.Drawing.Point(799, 12)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(97, 13)
        Me.Label32.TabIndex = 34
        Me.Label32.Text = "Fecha de contrato:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'TextObservaciones
        '
        Me.TextObservaciones.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TextObservaciones.BackColor = System.Drawing.Color.White
        Me.TextObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextObservaciones.Location = New System.Drawing.Point(113, 54)
        Me.TextObservaciones.MaxLength = 250
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(671, 20)
        Me.TextObservaciones.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 37
        Me.Label2.Text = "Observaciones:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(12, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 39
        Me.Label3.Text = "Horario:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextHorario
        '
        Me.TextHorario.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.TextHorario.BackColor = System.Drawing.Color.White
        Me.TextHorario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextHorario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextHorario.Location = New System.Drawing.Point(113, 31)
        Me.TextHorario.MaxLength = 100
        Me.TextHorario.Name = "TextHorario"
        Me.TextHorario.Size = New System.Drawing.Size(671, 20)
        Me.TextHorario.TabIndex = 4
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageKey = "reportegenerar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(1067, 4)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(60, 30)
        Me.btnEjecutar.TabIndex = 5
        Me.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnEjecutar, "Generar")
        Me.btnEjecutar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cmbTipo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.TextHorario)
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.TextObservaciones)
        Me.Panel1.Controls.Add(Me.Label32)
        Me.Panel1.Controls.Add(Me.TextFecha)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 80)
        Me.Panel1.TabIndex = 40
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "Tipo de personal:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipo
        '
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"DOCENTE", "ADMINISTRACION", "TECNICO ADMINISTRATIVO", "MANTENIMIENTO"})
        Me.cmbTipo.Location = New System.Drawing.Point(113, 4)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(315, 21)
        Me.cmbTipo.TabIndex = 40
        '
        'frmReporteador
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmReporteador"
        Me.Text = "Impresión de Contrato"
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents TextFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextHorario As System.Windows.Forms.TextBox
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ToolTip1 As ToolTip
End Class
