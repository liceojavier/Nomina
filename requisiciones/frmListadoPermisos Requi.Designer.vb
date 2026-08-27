<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoPermisos_Requi
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoPermisos_Requi))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.gbEmpleado = New System.Windows.Forms.GroupBox()
        Me.CtrlBusqEmp = New BusquedaEmpleadoControl()
        Me.gbJefe = New System.Windows.Forms.GroupBox()
        Me.ctrlBusqJefe = New BusquedaEmpleadoControl()
        Me.gbNivelPermiso = New System.Windows.Forms.GroupBox()
        Me.cmbNiveles = New System.Windows.Forms.ComboBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ImageNuevo = New System.Windows.Forms.ImageList(Me.components)
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel2.SuspendLayout()
        Me.gbEmpleado.SuspendLayout()
        Me.gbJefe.SuspendLayout()
        Me.gbNivelPermiso.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel2.Controls.Add(Me.gbEmpleado)
        Me.Panel2.Controls.Add(Me.gbJefe)
        Me.Panel2.Controls.Add(Me.gbNivelPermiso)
        Me.Panel2.Controls.Add(Me.cmbTipo)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.btnEjecutar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1146, 116)
        Me.Panel2.TabIndex = 62
        '
        'gbEmpleado
        '
        Me.gbEmpleado.Controls.Add(Me.CtrlBusqEmp)
        Me.gbEmpleado.ForeColor = System.Drawing.Color.White
        Me.gbEmpleado.Location = New System.Drawing.Point(31, 49)
        Me.gbEmpleado.Name = "gbEmpleado"
        Me.gbEmpleado.Size = New System.Drawing.Size(397, 54)
        Me.gbEmpleado.TabIndex = 106
        Me.gbEmpleado.TabStop = False
        Me.gbEmpleado.Text = "Empleado:"
        '
        'CtrlBusqEmp
        '
        Me.CtrlBusqEmp.Contrato = 0
        Me.CtrlBusqEmp.Empleado = 0
        Me.CtrlBusqEmp.ForeColor = System.Drawing.Color.Black
        Me.CtrlBusqEmp.id_empresa = CType(0, Short)
        Me.CtrlBusqEmp.Location = New System.Drawing.Point(6, 21)
        Me.CtrlBusqEmp.Name = "CtrlBusqEmp"
        Me.CtrlBusqEmp.Nombre = ""
        Me.CtrlBusqEmp.Size = New System.Drawing.Size(387, 23)
        Me.CtrlBusqEmp.TabIndex = 2
        '
        'gbJefe
        '
        Me.gbJefe.Controls.Add(Me.ctrlBusqJefe)
        Me.gbJefe.ForeColor = System.Drawing.Color.White
        Me.gbJefe.Location = New System.Drawing.Point(439, 49)
        Me.gbJefe.Name = "gbJefe"
        Me.gbJefe.Size = New System.Drawing.Size(397, 54)
        Me.gbJefe.TabIndex = 3
        Me.gbJefe.TabStop = False
        Me.gbJefe.Text = "Autorizador:"
        '
        'ctrlBusqJefe
        '
        Me.ctrlBusqJefe.Contrato = 0
        Me.ctrlBusqJefe.Empleado = 0
        Me.ctrlBusqJefe.ForeColor = System.Drawing.Color.Black
        Me.ctrlBusqJefe.id_empresa = CType(0, Short)
        Me.ctrlBusqJefe.Location = New System.Drawing.Point(4, 19)
        Me.ctrlBusqJefe.Name = "ctrlBusqJefe"
        Me.ctrlBusqJefe.Nombre = ""
        Me.ctrlBusqJefe.Size = New System.Drawing.Size(387, 23)
        Me.ctrlBusqJefe.TabIndex = 3
        '
        'gbNivelPermiso
        '
        Me.gbNivelPermiso.Controls.Add(Me.cmbNiveles)
        Me.gbNivelPermiso.ForeColor = System.Drawing.Color.White
        Me.gbNivelPermiso.Location = New System.Drawing.Point(846, 48)
        Me.gbNivelPermiso.Name = "gbNivelPermiso"
        Me.gbNivelPermiso.Size = New System.Drawing.Size(168, 55)
        Me.gbNivelPermiso.TabIndex = 4
        Me.gbNivelPermiso.TabStop = False
        Me.gbNivelPermiso.Text = "Nivel de Autorizador:"
        '
        'cmbNiveles
        '
        Me.cmbNiveles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNiveles.FormattingEnabled = True
        Me.cmbNiveles.Items.AddRange(New Object() {"Nivel 1", "Nivel 2", "Nivel 3"})
        Me.cmbNiveles.Location = New System.Drawing.Point(16, 21)
        Me.cmbNiveles.Name = "cmbNiveles"
        Me.cmbNiveles.Size = New System.Drawing.Size(129, 21)
        Me.cmbNiveles.TabIndex = 4
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"", "Reporte General de Permisos", "Reporte de Permisos por Nivel"})
        Me.cmbTipo.Location = New System.Drawing.Point(33, 17)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(387, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(31, 2)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 13)
        Me.Label2.TabIndex = 100
        Me.Label2.Text = "Tipo Reporte:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(486, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(294, 20)
        Me.Label5.TabIndex = 93
        Me.Label5.Text = "Reporte de Permisos Requisiciones"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevo
        Me.btnLimpiar.Location = New System.Drawing.Point(1046, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 6
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'ImageNuevo
        '
        Me.ImageNuevo.ImageStream = CType(resources.GetObject("ImageNuevo.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageNuevo.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageNuevo.Images.SetKeyName(0, "actualizar.png")
        Me.ImageNuevo.Images.SetKeyName(1, "agregar1.png")
        Me.ImageNuevo.Images.SetKeyName(2, "alumno.png")
        Me.ImageNuevo.Images.SetKeyName(3, "anterior.png")
        Me.ImageNuevo.Images.SetKeyName(4, "anterior1.png")
        Me.ImageNuevo.Images.SetKeyName(5, "anulado.png")
        Me.ImageNuevo.Images.SetKeyName(6, "aprobar.png")
        Me.ImageNuevo.Images.SetKeyName(7, "asignar1.png")
        Me.ImageNuevo.Images.SetKeyName(8, "asignar2.png")
        Me.ImageNuevo.Images.SetKeyName(9, "bar.png")
        Me.ImageNuevo.Images.SetKeyName(10, "blanco.png")
        Me.ImageNuevo.Images.SetKeyName(11, "buscar1.png")
        Me.ImageNuevo.Images.SetKeyName(12, "buscar2.png")
        Me.ImageNuevo.Images.SetKeyName(13, "cancelar.png")
        Me.ImageNuevo.Images.SetKeyName(14, "candado.png")
        Me.ImageNuevo.Images.SetKeyName(15, "checkok.png")
        Me.ImageNuevo.Images.SetKeyName(16, "detalle.png")
        Me.ImageNuevo.Images.SetKeyName(17, "download.png")
        Me.ImageNuevo.Images.SetKeyName(18, "edit1.png")
        Me.ImageNuevo.Images.SetKeyName(19, "edit2.png")
        Me.ImageNuevo.Images.SetKeyName(20, "familia.png")
        Me.ImageNuevo.Images.SetKeyName(21, "fecha.png")
        Me.ImageNuevo.Images.SetKeyName(22, "guardar.png")
        Me.ImageNuevo.Images.SetKeyName(23, "impresora2.png")
        Me.ImageNuevo.Images.SetKeyName(24, "imprimir.png")
        Me.ImageNuevo.Images.SetKeyName(25, "limpiar.png")
        Me.ImageNuevo.Images.SetKeyName(26, "mas.png")
        Me.ImageNuevo.Images.SetKeyName(27, "menos.png")
        Me.ImageNuevo.Images.SetKeyName(28, "mostrar.png")
        Me.ImageNuevo.Images.SetKeyName(29, "open.png")
        Me.ImageNuevo.Images.SetKeyName(30, "porcentaje.png")
        Me.ImageNuevo.Images.SetKeyName(31, "reportegenerar.png")
        Me.ImageNuevo.Images.SetKeyName(32, "reportever.png")
        Me.ImageNuevo.Images.SetKeyName(33, "secretary.png")
        Me.ImageNuevo.Images.SetKeyName(34, "siguiente.png")
        Me.ImageNuevo.Images.SetKeyName(35, "siguiente2.png")
        Me.ImageNuevo.Images.SetKeyName(36, "upload.png")
        Me.ImageNuevo.Images.SetKeyName(37, "usuario.png")
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "reportegenerar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevo
        Me.btnEjecutar.Location = New System.Drawing.Point(960, 8)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(80, 30)
        Me.btnEjecutar.TabIndex = 5
        Me.btnEjecutar.Text = "Generar"
        Me.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEjecutar.UseVisualStyleBackColor = False
        '
        'crv
        '
        Me.crv.ActiveViewIndex = -1
        Me.crv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv.ForeColor = System.Drawing.Color.White
        Me.crv.Location = New System.Drawing.Point(0, 122)
        Me.crv.Name = "crv"
        Me.crv.Size = New System.Drawing.Size(1143, 490)
        Me.crv.TabIndex = 63
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'frmListadoPermisos_Requi
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1146, 611)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.Panel2)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListadoPermisos_Requi"
        Me.Text = "Listado de Permisos Requisiciones"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.gbEmpleado.ResumeLayout(False)
        Me.gbJefe.ResumeLayout(False)
        Me.gbNivelPermiso.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel2 As Panel
    Friend WithEvents CtrlBusqEmp As BusquedaEmpleadoControl
    Friend WithEvents Label5 As Label
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnEjecutar As Button
    Friend WithEvents ImageNuevo As ImageList
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents gbNivelPermiso As GroupBox
    Friend WithEvents cmbNiveles As ComboBox
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents Label2 As Label
    Friend WithEvents ctrlBusqJefe As BusquedaEmpleadoControl
    Friend WithEvents gbJefe As GroupBox
    Friend WithEvents gbEmpleado As GroupBox
End Class
