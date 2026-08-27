<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMovimientosNominaMultiple
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMovimientosNominaMultiple))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.pnFin = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.dgDatos = New System.Windows.Forms.DataGridView()
        Me.rbCantidad = New System.Windows.Forms.RadioButton()
        Me.rbValor = New System.Windows.Forms.RadioButton()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.cbMes = New System.Windows.Forms.CheckedListBox()
        Me.btnDesmarcar = New System.Windows.Forms.Button()
        Me.btnMarcar = New System.Windows.Forms.Button()
        Me.gpDatos = New System.Windows.Forms.GroupBox()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.LbTipo = New System.Windows.Forms.Label()
        Me.TextValor = New System.Windows.Forms.TextBox()
        Me.textFiltro = New System.Windows.Forms.TextBox()
        Me.lbFilter = New System.Windows.Forms.Label()
        Me.gpDetalle = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.busqTransaccion = New BusquedaTransacControl()
        Me.btnDwnXLS = New System.Windows.Forms.Button()
        Me.btnLoadXLS = New System.Windows.Forms.Button()
        Me.pnFin.SuspendLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpDatos.SuspendLayout()
        Me.ctxMenu.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.gpDetalle.SuspendLayout()
        Me.SuspendLayout()
        '
        'pnFin
        '
        Me.pnFin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnFin.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.pnFin.Controls.Add(Me.btnLimpiar)
        Me.pnFin.Controls.Add(Me.btnGuardar)
        Me.pnFin.Location = New System.Drawing.Point(0, 569)
        Me.pnFin.Name = "pnFin"
        Me.pnFin.Size = New System.Drawing.Size(1132, 40)
        Me.pnFin.TabIndex = 47
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(16, 4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(78, 30)
        Me.btnLimpiar.TabIndex = 37
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = False
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
        Me.ImageNuevos.Images.SetKeyName(21, "downloadXLSX.jpg")
        Me.ImageNuevos.Images.SetKeyName(22, "uploadXLSX.jpg")
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(1052, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 30)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'dgDatos
        '
        Me.dgDatos.AllowUserToAddRows = False
        Me.dgDatos.AllowUserToDeleteRows = False
        Me.dgDatos.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgDatos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgDatos.BackgroundColor = System.Drawing.Color.White
        Me.dgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDatos.GridColor = System.Drawing.Color.DimGray
        Me.dgDatos.Location = New System.Drawing.Point(18, 182)
        Me.dgDatos.MultiSelect = False
        Me.dgDatos.Name = "dgDatos"
        Me.dgDatos.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatos.Size = New System.Drawing.Size(1098, 310)
        Me.dgDatos.TabIndex = 45
        '
        'rbCantidad
        '
        Me.rbCantidad.AutoSize = True
        Me.rbCantidad.Location = New System.Drawing.Point(600, 31)
        Me.rbCantidad.Name = "rbCantidad"
        Me.rbCantidad.Size = New System.Drawing.Size(67, 17)
        Me.rbCantidad.TabIndex = 123
        Me.rbCantidad.TabStop = True
        Me.rbCantidad.Text = "Cantidad"
        Me.rbCantidad.UseVisualStyleBackColor = True
        '
        'rbValor
        '
        Me.rbValor.AutoSize = True
        Me.rbValor.Location = New System.Drawing.Point(600, 8)
        Me.rbValor.Name = "rbValor"
        Me.rbValor.Size = New System.Drawing.Size(49, 17)
        Me.rbValor.TabIndex = 122
        Me.rbValor.TabStop = True
        Me.rbValor.Text = "Valor"
        Me.rbValor.UseVisualStyleBackColor = True
        '
        'btnIngresar
        '
        Me.btnIngresar.BackColor = System.Drawing.SystemColors.Control
        Me.btnIngresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngresar.ImageIndex = 14
        Me.btnIngresar.ImageList = Me.ImageNuevos
        Me.btnIngresar.Location = New System.Drawing.Point(750, 95)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(78, 30)
        Me.btnIngresar.TabIndex = 4
        Me.btnIngresar.Text = "Buscar"
        Me.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnIngresar.UseVisualStyleBackColor = False
        '
        'cbMes
        '
        Me.cbMes.CheckOnClick = True
        Me.cbMes.FormattingEnabled = True
        Me.cbMes.Location = New System.Drawing.Point(9, 12)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.Size = New System.Drawing.Size(158, 49)
        Me.cbMes.TabIndex = 121
        '
        'btnDesmarcar
        '
        Me.btnDesmarcar.Location = New System.Drawing.Point(186, 39)
        Me.btnDesmarcar.Name = "btnDesmarcar"
        Me.btnDesmarcar.Size = New System.Drawing.Size(40, 23)
        Me.btnDesmarcar.TabIndex = 120
        Me.btnDesmarcar.Text = "D"
        Me.btnDesmarcar.UseVisualStyleBackColor = True
        '
        'btnMarcar
        '
        Me.btnMarcar.Location = New System.Drawing.Point(186, 12)
        Me.btnMarcar.Name = "btnMarcar"
        Me.btnMarcar.Size = New System.Drawing.Size(40, 23)
        Me.btnMarcar.TabIndex = 119
        Me.btnMarcar.Text = "M"
        Me.btnMarcar.UseVisualStyleBackColor = True
        '
        'gpDatos
        '
        Me.gpDatos.Controls.Add(Me.TextAño)
        Me.gpDatos.Controls.Add(Me.Label6)
        Me.gpDatos.Controls.Add(Me.Label3)
        Me.gpDatos.Controls.Add(Me.cmbTipo)
        Me.gpDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDatos.Location = New System.Drawing.Point(18, 12)
        Me.gpDatos.Name = "gpDatos"
        Me.gpDatos.Size = New System.Drawing.Size(622, 46)
        Me.gpDatos.TabIndex = 43
        Me.gpDatos.TabStop = False
        Me.gpDatos.Text = "Movimiento"
        '
        'TextAño
        '
        Me.TextAño.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextAño.BackColor = System.Drawing.Color.White
        Me.TextAño.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(540, 19)
        Me.TextAño.MaxLength = 4
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(61, 20)
        Me.TextAño.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(502, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Año:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tipo de nómina:"
        '
        'cmbTipo
        '
        Me.cmbTipo.BackColor = System.Drawing.Color.White
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(103, 18)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(387, 21)
        Me.cmbTipo.TabIndex = 3
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModificar, Me.ctxEliminar})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(126, 48)
        '
        'ctxModificar
        '
        Me.ctxModificar.Image = Global.NOMINA.My.Resources.Resources.edit1
        Me.ctxModificar.Name = "ctxModificar"
        Me.ctxModificar.Size = New System.Drawing.Size(125, 22)
        Me.ctxModificar.Text = "Modificar"
        '
        'ctxEliminar
        '
        Me.ctxEliminar.Image = Global.NOMINA.My.Resources.Resources.menos
        Me.ctxEliminar.Name = "ctxEliminar"
        Me.ctxEliminar.Size = New System.Drawing.Size(125, 22)
        Me.ctxEliminar.Text = "Eliminar"
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageKey = "mas.png"
        Me.Button1.ImageList = Me.ImageNuevos
        Me.Button1.Location = New System.Drawing.Point(368, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(60, 30)
        Me.Button1.TabIndex = 123
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Button1, "Ingresar")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.LbTipo)
        Me.Panel1.Controls.Add(Me.TextValor)
        Me.Panel1.Controls.Add(Me.cbMes)
        Me.Panel1.Controls.Add(Me.btnMarcar)
        Me.Panel1.Controls.Add(Me.btnDesmarcar)
        Me.Panel1.Location = New System.Drawing.Point(24, 499)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(735, 64)
        Me.Panel1.TabIndex = 48
        Me.Panel1.Visible = False
        '
        'LbTipo
        '
        Me.LbTipo.AutoSize = True
        Me.LbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbTipo.Location = New System.Drawing.Point(238, 24)
        Me.LbTipo.Name = "LbTipo"
        Me.LbTipo.Size = New System.Drawing.Size(34, 13)
        Me.LbTipo.TabIndex = 124
        Me.LbTipo.Text = "Valor:"
        Me.LbTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextValor
        '
        Me.TextValor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextValor.BackColor = System.Drawing.Color.White
        Me.TextValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValor.Location = New System.Drawing.Point(280, 21)
        Me.TextValor.MaxLength = 11
        Me.TextValor.Name = "TextValor"
        Me.TextValor.Size = New System.Drawing.Size(82, 20)
        Me.TextValor.TabIndex = 122
        '
        'textFiltro
        '
        Me.textFiltro.BackColor = System.Drawing.Color.White
        Me.textFiltro.Location = New System.Drawing.Point(59, 142)
        Me.textFiltro.MaxLength = 150
        Me.textFiltro.Name = "textFiltro"
        Me.textFiltro.Size = New System.Drawing.Size(381, 20)
        Me.textFiltro.TabIndex = 49
        Me.textFiltro.TabStop = False
        '
        'lbFilter
        '
        Me.lbFilter.AutoSize = True
        Me.lbFilter.Location = New System.Drawing.Point(24, 142)
        Me.lbFilter.Name = "lbFilter"
        Me.lbFilter.Size = New System.Drawing.Size(29, 13)
        Me.lbFilter.TabIndex = 50
        Me.lbFilter.Text = "Filtro"
        '
        'gpDetalle
        '
        Me.gpDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpDetalle.Controls.Add(Me.Label1)
        Me.gpDetalle.Controls.Add(Me.busqTransaccion)
        Me.gpDetalle.Controls.Add(Me.rbCantidad)
        Me.gpDetalle.Controls.Add(Me.rbValor)
        Me.gpDetalle.Location = New System.Drawing.Point(16, 64)
        Me.gpDetalle.Name = "gpDetalle"
        Me.gpDetalle.Size = New System.Drawing.Size(702, 57)
        Me.gpDetalle.TabIndex = 51
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 13)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Transacción:"
        '
        'busqTransaccion
        '
        Me.busqTransaccion.Forma_Calculo = "0"
        Me.busqTransaccion.id_empresa = CType(0, Short)
        Me.busqTransaccion.Location = New System.Drawing.Point(83, 8)
        Me.busqTransaccion.Name = "busqTransaccion"
        Me.busqTransaccion.Nombre = ""
        Me.busqTransaccion.Size = New System.Drawing.Size(437, 24)
        Me.busqTransaccion.TabIndex = 124
        Me.busqTransaccion.Tipo_Valor = "0"
        Me.busqTransaccion.transac = 0
        '
        'btnDwnXLS
        '
        Me.btnDwnXLS.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnDwnXLS.ForeColor = System.Drawing.Color.White
        Me.btnDwnXLS.ImageIndex = 21
        Me.btnDwnXLS.Location = New System.Drawing.Point(843, 95)
        Me.btnDwnXLS.Name = "btnDwnXLS"
        Me.btnDwnXLS.Size = New System.Drawing.Size(76, 40)
        Me.btnDwnXLS.TabIndex = 52
        Me.btnDwnXLS.Text = "Descarga XLSX ↓"
        Me.btnDwnXLS.UseVisualStyleBackColor = False
        '
        'btnLoadXLS
        '
        Me.btnLoadXLS.BackColor = System.Drawing.Color.FromArgb(CType(CType(16, Byte), Integer), CType(CType(124, Byte), Integer), CType(CType(65, Byte), Integer))
        Me.btnLoadXLS.ForeColor = System.Drawing.Color.White
        Me.btnLoadXLS.Location = New System.Drawing.Point(925, 95)
        Me.btnLoadXLS.Name = "btnLoadXLS"
        Me.btnLoadXLS.Size = New System.Drawing.Size(75, 40)
        Me.btnLoadXLS.TabIndex = 53
        Me.btnLoadXLS.Text = "Carga...  XLSX ↑"
        Me.btnLoadXLS.UseVisualStyleBackColor = False
        '
        'frmMovimientosNominaMultiple
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1134, 609)
        Me.Controls.Add(Me.btnLoadXLS)
        Me.Controls.Add(Me.btnDwnXLS)
        Me.Controls.Add(Me.gpDetalle)
        Me.Controls.Add(Me.lbFilter)
        Me.Controls.Add(Me.textFiltro)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnIngresar)
        Me.Controls.Add(Me.pnFin)
        Me.Controls.Add(Me.dgDatos)
        Me.Controls.Add(Me.gpDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMovimientosNominaMultiple"
        Me.Text = "Mantenimientos de Movimientos de Nómina"
        Me.pnFin.ResumeLayout(False)
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpDatos.ResumeLayout(False)
        Me.gpDatos.PerformLayout()
        Me.ctxMenu.ResumeLayout(False)
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gpDetalle.ResumeLayout(False)
        Me.gpDetalle.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents pnFin As Panel
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents dgDatos As DataGridView
    Friend WithEvents btnDesmarcar As Button
    Friend WithEvents btnMarcar As Button
    Friend WithEvents btnIngresar As Button
    Friend WithEvents gpDatos As GroupBox
    Friend WithEvents TextAño As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbTipo As ComboBox
    Friend WithEvents ImageNuevos As ImageList
    Friend WithEvents ctxMenu As ContextMenuStrip
    Friend WithEvents ctxModificar As ToolStripMenuItem
    Friend WithEvents ctxEliminar As ToolStripMenuItem
    Friend WithEvents ep1 As ErrorProvider
    Friend WithEvents ToolTip1 As ToolTip

    Friend WithEvents cbMes As CheckedListBox
    Friend WithEvents rbCantidad As RadioButton
    Friend WithEvents rbValor As RadioButton
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents LbTipo As Label
    Friend WithEvents TextValor As TextBox
    Friend WithEvents lbFilter As Label
    Friend WithEvents textFiltro As TextBox
    Friend WithEvents gpDetalle As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents busqTransaccion As BusquedaTransacControl
    Friend WithEvents btnDwnXLS As Button
    Friend WithEvents btnLoadXLS As Button
End Class
