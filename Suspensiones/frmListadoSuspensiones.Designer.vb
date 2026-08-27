<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmListadoSuspensiones
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoSuspensiones))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dpFechaf = New System.Windows.Forms.DateTimePicker()
        Me.dpFechaI = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ImageNuevo = New System.Windows.Forms.ImageList(Me.components)
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.gpTipo = New System.Windows.Forms.GroupBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.sfdArchivo = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        Me.gpTipo.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.dpFechaf)
        Me.Panel1.Controls.Add(Me.dpFechaI)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Controls.Add(Me.gpTipo)
        Me.Panel1.Location = New System.Drawing.Point(2, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1015, 134)
        Me.Panel1.TabIndex = 61
        '
        'dpFechaf
        '
        Me.dpFechaf.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaf.Location = New System.Drawing.Point(696, 86)
        Me.dpFechaf.Name = "dpFechaf"
        Me.dpFechaf.Size = New System.Drawing.Size(106, 20)
        Me.dpFechaf.TabIndex = 5
        '
        'dpFechaI
        '
        Me.dpFechaI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaI.Location = New System.Drawing.Point(577, 86)
        Me.dpFechaI.Name = "dpFechaI"
        Me.dpFechaI.Size = New System.Drawing.Size(106, 20)
        Me.dpFechaI.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(693, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "Fecha Inicial"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(574, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Fecha Inicial"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbEstado)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(340, 65)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 48)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Estado "
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.Items.AddRange(New Object() {"GENERAL", "POR TIPO DE PERSONAL", "POR PUESTOS", "POR FORMA DE PAGO", "ANTICIPO"})
        Me.cmbEstado.Location = New System.Drawing.Point(8, 20)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(199, 21)
        Me.cmbEstado.TabIndex = 2
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevo
        Me.btnLimpiar.Location = New System.Drawing.Point(834, 79)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 7
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
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "reportegenerar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevo
        Me.btnEjecutar.Location = New System.Drawing.Point(834, 43)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(80, 30)
        Me.btnEjecutar.TabIndex = 6
        Me.btnEjecutar.Text = "Generar"
        Me.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnEjecutar.UseVisualStyleBackColor = False
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(10, 8)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(456, 42)
        Me.gpEmpresa.TabIndex = 1
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(12, 16)
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(433, 21)
        Me.TextNombEmpresa.TabIndex = 2
        Me.TextNombEmpresa.TabStop = False
        '
        'gpTipo
        '
        Me.gpTipo.Controls.Add(Me.cmbTipo)
        Me.gpTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTipo.ForeColor = System.Drawing.Color.White
        Me.gpTipo.Location = New System.Drawing.Point(10, 65)
        Me.gpTipo.Name = "gpTipo"
        Me.gpTipo.Size = New System.Drawing.Size(324, 48)
        Me.gpTipo.TabIndex = 2
        Me.gpTipo.TabStop = False
        Me.gpTipo.Text = "Tipo de listado"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Items.AddRange(New Object() {"Listado de general de suspensiones"})
        Me.cmbTipo.Location = New System.Drawing.Point(8, 20)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(310, 21)
        Me.cmbTipo.TabIndex = 2
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'sfdArchivo
        '
        Me.sfdArchivo.DefaultExt = "xlsx"
        Me.sfdArchivo.FileName = "listado-suspensiones"
        Me.sfdArchivo.Filter = "Archivo de Excel|*.xlsx"
        '
        'frmListadoSuspensiones
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1016, 291)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListadoSuspensiones"
        Me.Text = "Listado de suspensiones"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        Me.gpTipo.ResumeLayout(False)
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents gpEmpresa As GroupBox
    Friend WithEvents TextNombEmpresa As TextBox
    Friend WithEvents gpTipo As GroupBox
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents btnEjecutar As Button
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents ImageNuevo As ImageList
    Friend WithEvents ep1 As ErrorProvider
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents dpFechaf As DateTimePicker
    Friend WithEvents dpFechaI As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents sfdArchivo As SaveFileDialog
End Class
