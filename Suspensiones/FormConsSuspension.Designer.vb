<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class formConsSuspension
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(formConsSuspension))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnInfo = New System.Windows.Forms.Panel()
        Me.gpContrato = New System.Windows.Forms.GroupBox()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.TextConxContrato = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.axFechaI = New axFecha.axDateDB()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.busqEmpleado = New NOMINA.BusquedaEmpleadoControl()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.dgvDatosConsulta = New System.Windows.Forms.DataGridView()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxAlta = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxAnular = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxDeshacerAlta = New System.Windows.Forms.ToolStripMenuItem()
        Me.bsData = New System.Windows.Forms.BindingSource(Me.components)
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pnInfo.SuspendLayout()
        Me.gpContrato.SuspendLayout()
        CType(Me.dgvDatosConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        CType(Me.bsData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnInfo
        '
        Me.pnInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.pnInfo.Controls.Add(Me.gpContrato)
        Me.pnInfo.Controls.Add(Me.btnBuscar)
        Me.pnInfo.Controls.Add(Me.btnLimpiar)
        Me.pnInfo.Controls.Add(Me.Label4)
        Me.pnInfo.Controls.Add(Me.axFechaI)
        Me.pnInfo.Controls.Add(Me.txtNumero)
        Me.pnInfo.Controls.Add(Me.Label3)
        Me.pnInfo.Controls.Add(Me.busqEmpleado)
        Me.pnInfo.Controls.Add(Me.Label2)
        Me.pnInfo.Controls.Add(Me.Label14)
        Me.pnInfo.Controls.Add(Me.Label1)
        Me.pnInfo.Controls.Add(Me.cmbTipo)
        Me.pnInfo.Controls.Add(Me.cmbEstado)
        Me.pnInfo.Location = New System.Drawing.Point(12, 5)
        Me.pnInfo.Name = "pnInfo"
        Me.pnInfo.Size = New System.Drawing.Size(1009, 101)
        Me.pnInfo.TabIndex = 5
        '
        'gpContrato
        '
        Me.gpContrato.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.gpContrato.Controls.Add(Me.btnContrato)
        Me.gpContrato.Controls.Add(Me.TextConxContrato)
        Me.gpContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpContrato.ForeColor = System.Drawing.Color.White
        Me.gpContrato.Location = New System.Drawing.Point(596, 3)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(137, 44)
        Me.gpContrato.TabIndex = 120
        Me.gpContrato.TabStop = False
        Me.gpContrato.Text = "Contrato"
        '
        'btnContrato
        '
        Me.btnContrato.BackColor = System.Drawing.SystemColors.Control
        Me.btnContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContrato.ImageIndex = 0
        Me.btnContrato.ImageList = Me.ImageList1
        Me.btnContrato.Location = New System.Drawing.Point(82, 10)
        Me.btnContrato.Name = "btnContrato"
        Me.btnContrato.Size = New System.Drawing.Size(40, 30)
        Me.btnContrato.TabIndex = 16
        Me.btnContrato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnContrato.UseVisualStyleBackColor = False
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "buscar2.png")
        Me.ImageList1.Images.SetKeyName(1, "limpiar.png")
        Me.ImageList1.Images.SetKeyName(2, "guardar.png")
        Me.ImageList1.Images.SetKeyName(3, "cancelar.png")
        Me.ImageList1.Images.SetKeyName(4, "familia.png")
        Me.ImageList1.Images.SetKeyName(5, "usuario.png")
        Me.ImageList1.Images.SetKeyName(6, "actualizar.png")
        Me.ImageList1.Images.SetKeyName(7, "anterior.png")
        Me.ImageList1.Images.SetKeyName(8, "siguiente.png")
        Me.ImageList1.Images.SetKeyName(9, "mas.png")
        Me.ImageList1.Images.SetKeyName(10, "edit1.png")
        Me.ImageList1.Images.SetKeyName(11, "reportegenerar.png")
        Me.ImageList1.Images.SetKeyName(12, "impresora2.png")
        Me.ImageList1.Images.SetKeyName(13, "checkok.png")
        Me.ImageList1.Images.SetKeyName(14, "buscar1.png")
        Me.ImageList1.Images.SetKeyName(15, "reportever.png")
        Me.ImageList1.Images.SetKeyName(16, "mostrar.png")
        Me.ImageList1.Images.SetKeyName(17, "detalle.png")
        Me.ImageList1.Images.SetKeyName(18, "fecha.png")
        Me.ImageList1.Images.SetKeyName(19, "open.png")
        Me.ImageList1.Images.SetKeyName(20, "menos.png")
        '
        'TextConxContrato
        '
        Me.TextConxContrato.BackColor = System.Drawing.Color.White
        Me.TextConxContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConxContrato.ForeColor = System.Drawing.Color.Red
        Me.TextConxContrato.Location = New System.Drawing.Point(10, 16)
        Me.TextConxContrato.MaxLength = 4
        Me.TextConxContrato.Name = "TextConxContrato"
        Me.TextConxContrato.Size = New System.Drawing.Size(63, 20)
        Me.TextConxContrato.TabIndex = 1
        Me.TextConxContrato.TabStop = False
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.ImageIndex = 0
        Me.btnBuscar.ImageList = Me.ImageList1
        Me.btnBuscar.Location = New System.Drawing.Point(574, 59)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(71, 30)
        Me.btnBuscar.TabIndex = 119
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageIndex = 1
        Me.btnLimpiar.ImageList = Me.ImageList1
        Me.btnLimpiar.Location = New System.Drawing.Point(488, 59)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(71, 30)
        Me.btnLimpiar.TabIndex = 117
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(15, 68)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 13)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Fecha Ingreso:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'axFechaI
        '
        Me.axFechaI.DateMaxvalue1 = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.axFechaI.DateMaxvalue2 = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.axFechaI.DateMinvalue1 = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.axFechaI.DateMinvalue2 = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.axFechaI.Datevalue1 = New Date(2025, 7, 24, 0, 0, 0, 0)
        Me.axFechaI.Datevalue2 = New Date(2025, 7, 24, 0, 0, 0, 0)
        Me.axFechaI.EsModoConsulta = True
        Me.axFechaI.Formato = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.axFechaI.FuenteCalendario = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.axFechaI.Location = New System.Drawing.Point(96, 68)
        Me.axFechaI.Name = "axFechaI"
        Me.axFechaI.nombreCampo = "fechai"
        Me.axFechaI.prefijo = "a"
        Me.axFechaI.Size = New System.Drawing.Size(326, 27)
        Me.axFechaI.TabIndex = 82
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.White
        Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.ForeColor = System.Drawing.Color.Red
        Me.txtNumero.Location = New System.Drawing.Point(819, 10)
        Me.txtNumero.MaxLength = 10
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.Size = New System.Drawing.Size(90, 20)
        Me.txtNumero.TabIndex = 81
        Me.txtNumero.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(755, 10)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 80
        Me.Label3.Text = "Número:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'busqEmpleado
        '
        Me.busqEmpleado.activo = False
        Me.busqEmpleado.Contrato = 0
        Me.busqEmpleado.Empleado = 0
        Me.busqEmpleado.id_empresa = CType(0, Short)
        Me.busqEmpleado.Location = New System.Drawing.Point(96, 10)
        Me.busqEmpleado.Name = "busqEmpleado"
        Me.busqEmpleado.Nombre = ""
        Me.busqEmpleado.Size = New System.Drawing.Size(490, 23)
        Me.busqEmpleado.TabIndex = 79
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(15, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "Tipo:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(15, 10)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(47, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Nombre:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(755, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 77
        Me.Label1.Text = "Estado:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(96, 39)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(326, 21)
        Me.cmbTipo.TabIndex = 3
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.FormattingEnabled = True
        Me.cmbEstado.Location = New System.Drawing.Point(819, 39)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(178, 21)
        Me.cmbEstado.TabIndex = 2
        '
        'ImageNuevos
        '
        Me.ImageNuevos.ImageStream = CType(resources.GetObject("ImageNuevos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageNuevos.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageNuevos.Images.SetKeyName(0, "buscar.png")
        Me.ImageNuevos.Images.SetKeyName(1, "docto eliminar.png")
        Me.ImageNuevos.Images.SetKeyName(2, "docto nuevo.png")
        Me.ImageNuevos.Images.SetKeyName(3, "edit1.png")
        Me.ImageNuevos.Images.SetKeyName(4, "guardar.png")
        Me.ImageNuevos.Images.SetKeyName(5, "limpiar.png")
        '
        'dgvDatosConsulta
        '
        Me.dgvDatosConsulta.AllowUserToAddRows = False
        Me.dgvDatosConsulta.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        Me.dgvDatosConsulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDatosConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatosConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDatosConsulta.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvDatosConsulta.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatosConsulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDatosConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDatosConsulta.ContextMenuStrip = Me.ctxMenu
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDatosConsulta.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDatosConsulta.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgvDatosConsulta.Location = New System.Drawing.Point(12, 112)
        Me.dgvDatosConsulta.MultiSelect = False
        Me.dgvDatosConsulta.Name = "dgvDatosConsulta"
        Me.dgvDatosConsulta.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatosConsulta.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDatosConsulta.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatosConsulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDatosConsulta.Size = New System.Drawing.Size(1009, 462)
        Me.dgvDatosConsulta.TabIndex = 6
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxAlta, Me.ctxAnular, Me.ctxDeshacerAlta})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(145, 70)
        '
        'ctxAlta
        '
        Me.ctxAlta.Name = "ctxAlta"
        Me.ctxAlta.Size = New System.Drawing.Size(144, 22)
        Me.ctxAlta.Text = "Dar de alta"
        '
        'ctxAnular
        '
        Me.ctxAnular.Name = "ctxAnular"
        Me.ctxAnular.Size = New System.Drawing.Size(144, 22)
        Me.ctxAnular.Text = "Anular"
        '
        'ctxDeshacerAlta
        '
        Me.ctxDeshacerAlta.Name = "ctxDeshacerAlta"
        Me.ctxDeshacerAlta.Size = New System.Drawing.Size(144, 22)
        Me.ctxDeshacerAlta.Text = "Deshacer alta"
        '
        'bsData
        '
        Me.bsData.DataMember = "ViewSuspensiones"
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'formConsSuspension
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 586)
        Me.Controls.Add(Me.pnInfo)
        Me.Controls.Add(Me.dgvDatosConsulta)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "formConsSuspension"
        Me.Text = "Consulta de Suspensiones"
        Me.pnInfo.ResumeLayout(False)
        Me.pnInfo.PerformLayout()
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        CType(Me.dgvDatosConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        CType(Me.bsData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnInfo As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents cmbEstado As ComboBox
    Friend WithEvents dgvDatosConsulta As DataGridView
    Friend WithEvents Label3 As Label
    Friend WithEvents busqEmpleado As BusquedaEmpleadoControl
    Friend WithEvents Label4 As Label
    Friend WithEvents axFechaI As axFecha.axDateDB
    Friend WithEvents txtNumero As TextBox
    Friend WithEvents bsData As BindingSource
    'Friend WithEvents DsVistas1 As DsVistas
    'Friend WithEvents ViewSuspensionesTableAdapter As DsVistasTableAdapters.ViewSuspensionesTableAdapter
    Friend WithEvents ep1 As ErrorProvider
    Friend WithEvents ctxMenu As ContextMenuStrip
    Friend WithEvents ctxAlta As ToolStripMenuItem
    Friend WithEvents ctxAnular As ToolStripMenuItem
    Friend WithEvents IdsuspensionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdempresaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NumeroDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdempleadoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PrefijoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmpleadoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NombreempleadoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdtiposusDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NombretipoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdtipostDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FechaiDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FechafDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CantidadDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ValorDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ObservaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IdestadoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NombreestadoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FechaeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UsuarioDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ctxDeshacerAlta As ToolStripMenuItem
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents ImageNuevos As ImageList
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents gpContrato As GroupBox
    Friend WithEvents btnContrato As Button
    Friend WithEvents TextConxContrato As TextBox
End Class
