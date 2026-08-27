<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMantMovNominas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantMovNominas))
        Me.gpDatos = New System.Windows.Forms.GroupBox()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.gpContrato = New System.Windows.Forms.GroupBox()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.TextConxContrato = New System.Windows.Forms.TextBox()
        Me.gpEmpleado = New System.Windows.Forms.GroupBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textEmpleado = New System.Windows.Forms.TextBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnBuscaCodigo = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.gpDetalle = New System.Windows.Forms.GroupBox()
        Me.btnDesmarcar = New System.Windows.Forms.Button()
        Me.btnMarcar = New System.Windows.Forms.Button()
        Me.cbMes = New System.Windows.Forms.CheckedListBox()
        Me.LbTipo = New System.Windows.Forms.Label()
        Me.TextValor = New System.Windows.Forms.TextBox()
        Me.gpTransaccion = New System.Windows.Forms.GroupBox()
        Me.textNombCodigo = New System.Windows.Forms.TextBox()
        Me.textCodigo = New System.Windows.Forms.TextBox()
        Me.dgDatos = New System.Windows.Forms.DataGridView()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.pnFin = New System.Windows.Forms.Panel()
        Me.gpDatos.SuspendLayout()
        Me.gpContrato.SuspendLayout()
        Me.gpEmpleado.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpDetalle.SuspendLayout()
        Me.gpTransaccion.SuspendLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        Me.pnFin.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpDatos
        '
        Me.gpDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpDatos.Controls.Add(Me.TextAño)
        Me.gpDatos.Controls.Add(Me.Label6)
        Me.gpDatos.Controls.Add(Me.Label3)
        Me.gpDatos.Controls.Add(Me.cmbTipo)
        Me.gpDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDatos.Location = New System.Drawing.Point(16, 54)
        Me.gpDatos.Name = "gpDatos"
        Me.gpDatos.Size = New System.Drawing.Size(622, 46)
        Me.gpDatos.TabIndex = 1
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
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.ImageKey = "checkok.png"
        Me.btnBuscar.ImageList = Me.ImageNuevos
        Me.btnBuscar.Location = New System.Drawing.Point(847, 122)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(80, 30)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Asignar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Buscar")
        Me.btnBuscar.UseVisualStyleBackColor = False
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
        'gpContrato
        '
        Me.gpContrato.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpContrato.Controls.Add(Me.btnContrato)
        Me.gpContrato.Controls.Add(Me.TextConxContrato)
        Me.gpContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpContrato.Location = New System.Drawing.Point(658, 108)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(124, 56)
        Me.gpContrato.TabIndex = 3
        Me.gpContrato.TabStop = False
        Me.gpContrato.Text = "Contrato"
        '
        'btnContrato
        '
        Me.btnContrato.BackColor = System.Drawing.SystemColors.Control
        Me.btnContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContrato.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnContrato.ImageKey = "buscar2.png"
        Me.btnContrato.ImageList = Me.ImageNuevos
        Me.btnContrato.Location = New System.Drawing.Point(79, 14)
        Me.btnContrato.Name = "btnContrato"
        Me.btnContrato.Size = New System.Drawing.Size(33, 30)
        Me.btnContrato.TabIndex = 16
        Me.btnContrato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnContrato.UseVisualStyleBackColor = False
        '
        'TextConxContrato
        '
        Me.TextConxContrato.BackColor = System.Drawing.Color.White
        Me.TextConxContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConxContrato.ForeColor = System.Drawing.Color.Red
        Me.TextConxContrato.Location = New System.Drawing.Point(10, 24)
        Me.TextConxContrato.MaxLength = 4
        Me.TextConxContrato.Name = "TextConxContrato"
        Me.TextConxContrato.Size = New System.Drawing.Size(63, 20)
        Me.TextConxContrato.TabIndex = 1
        Me.TextConxContrato.TabStop = False
        '
        'gpEmpleado
        '
        Me.gpEmpleado.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpEmpleado.Controls.Add(Me.btnEmpleado)
        Me.gpEmpleado.Controls.Add(Me.textNombreEmple)
        Me.gpEmpleado.Controls.Add(Me.textEmpleado)
        Me.gpEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpleado.Location = New System.Drawing.Point(16, 108)
        Me.gpEmpleado.Name = "gpEmpleado"
        Me.gpEmpleado.Size = New System.Drawing.Size(622, 56)
        Me.gpEmpleado.TabIndex = 2
        Me.gpEmpleado.TabStop = False
        Me.gpEmpleado.Text = "Empleado"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(531, 16)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(80, 30)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.Text = "Empleado"
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEmpleado, "Empleado")
        Me.btnEmpleado.UseVisualStyleBackColor = False
        '
        'textNombreEmple
        '
        Me.textNombreEmple.BackColor = System.Drawing.Color.White
        Me.textNombreEmple.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombreEmple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombreEmple.Location = New System.Drawing.Point(66, 24)
        Me.textNombreEmple.MaxLength = 40
        Me.textNombreEmple.Name = "textNombreEmple"
        Me.textNombreEmple.Size = New System.Drawing.Size(448, 20)
        Me.textNombreEmple.TabIndex = 2
        '
        'textEmpleado
        '
        Me.textEmpleado.BackColor = System.Drawing.Color.White
        Me.textEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textEmpleado.Location = New System.Drawing.Point(6, 24)
        Me.textEmpleado.MaxLength = 6
        Me.textEmpleado.Name = "textEmpleado"
        Me.textEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textEmpleado.TabIndex = 1
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
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
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 37
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(1034, 4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 30)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Guardar Registro")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnBuscaCodigo
        '
        Me.btnBuscaCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscaCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscaCodigo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscaCodigo.ImageKey = "buscar1.png"
        Me.btnBuscaCodigo.ImageList = Me.ImageNuevos
        Me.btnBuscaCodigo.Location = New System.Drawing.Point(382, 12)
        Me.btnBuscaCodigo.Name = "btnBuscaCodigo"
        Me.btnBuscaCodigo.Size = New System.Drawing.Size(80, 30)
        Me.btnBuscaCodigo.TabIndex = 3
        Me.btnBuscaCodigo.Text = "Buscar"
        Me.btnBuscaCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscaCodigo, "Buscar Transaccion")
        Me.btnBuscaCodigo.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageKey = "cancelar.png"
        Me.btnCancelar.ImageList = Me.ImageNuevos
        Me.btnCancelar.Location = New System.Drawing.Point(936, 37)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelar, "Cancelar")
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'btnIngresar
        '
        Me.btnIngresar.BackColor = System.Drawing.SystemColors.Control
        Me.btnIngresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngresar.ImageKey = "mas.png"
        Me.btnIngresar.ImageList = Me.ImageNuevos
        Me.btnIngresar.Location = New System.Drawing.Point(936, 9)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(80, 30)
        Me.btnIngresar.TabIndex = 4
        Me.btnIngresar.Text = "Agregar"
        Me.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnIngresar, "Ingresar")
        Me.btnIngresar.UseVisualStyleBackColor = False
        '
        'gpDetalle
        '
        Me.gpDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpDetalle.Controls.Add(Me.btnDesmarcar)
        Me.gpDetalle.Controls.Add(Me.btnMarcar)
        Me.gpDetalle.Controls.Add(Me.cbMes)
        Me.gpDetalle.Controls.Add(Me.btnCancelar)
        Me.gpDetalle.Controls.Add(Me.btnIngresar)
        Me.gpDetalle.Controls.Add(Me.LbTipo)
        Me.gpDetalle.Controls.Add(Me.TextValor)
        Me.gpDetalle.Controls.Add(Me.gpTransaccion)
        Me.gpDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDetalle.Location = New System.Drawing.Point(16, 170)
        Me.gpDetalle.Name = "gpDetalle"
        Me.gpDetalle.Size = New System.Drawing.Size(1098, 71)
        Me.gpDetalle.TabIndex = 5
        Me.gpDetalle.TabStop = False
        '
        'btnDesmarcar
        '
        Me.btnDesmarcar.Location = New System.Drawing.Point(760, 38)
        Me.btnDesmarcar.Name = "btnDesmarcar"
        Me.btnDesmarcar.Size = New System.Drawing.Size(40, 23)
        Me.btnDesmarcar.TabIndex = 120
        Me.btnDesmarcar.Text = "D"
        Me.btnDesmarcar.UseVisualStyleBackColor = True
        '
        'btnMarcar
        '
        Me.btnMarcar.Location = New System.Drawing.Point(760, 11)
        Me.btnMarcar.Name = "btnMarcar"
        Me.btnMarcar.Size = New System.Drawing.Size(40, 23)
        Me.btnMarcar.TabIndex = 119
        Me.btnMarcar.Text = "M"
        Me.btnMarcar.UseVisualStyleBackColor = True
        '
        'cbMes
        '
        Me.cbMes.CheckOnClick = True
        Me.cbMes.FormattingEnabled = True
        Me.cbMes.Location = New System.Drawing.Point(503, 12)
        Me.cbMes.Name = "cbMes"
        Me.cbMes.Size = New System.Drawing.Size(251, 49)
        Me.cbMes.TabIndex = 43
        '
        'LbTipo
        '
        Me.LbTipo.AutoSize = True
        Me.LbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LbTipo.Location = New System.Drawing.Point(806, 16)
        Me.LbTipo.Name = "LbTipo"
        Me.LbTipo.Size = New System.Drawing.Size(34, 13)
        Me.LbTipo.TabIndex = 118
        Me.LbTipo.Text = "Valor:"
        Me.LbTipo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextValor
        '
        Me.TextValor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextValor.BackColor = System.Drawing.Color.White
        Me.TextValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValor.Location = New System.Drawing.Point(806, 35)
        Me.TextValor.MaxLength = 11
        Me.TextValor.Name = "TextValor"
        Me.TextValor.Size = New System.Drawing.Size(82, 20)
        Me.TextValor.TabIndex = 3
        '
        'gpTransaccion
        '
        Me.gpTransaccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpTransaccion.Controls.Add(Me.btnBuscaCodigo)
        Me.gpTransaccion.Controls.Add(Me.textNombCodigo)
        Me.gpTransaccion.Controls.Add(Me.textCodigo)
        Me.gpTransaccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTransaccion.Location = New System.Drawing.Point(7, 13)
        Me.gpTransaccion.Name = "gpTransaccion"
        Me.gpTransaccion.Size = New System.Drawing.Size(484, 52)
        Me.gpTransaccion.TabIndex = 1
        Me.gpTransaccion.TabStop = False
        Me.gpTransaccion.Text = "Transacciones"
        '
        'textNombCodigo
        '
        Me.textNombCodigo.BackColor = System.Drawing.Color.White
        Me.textNombCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombCodigo.Location = New System.Drawing.Point(60, 19)
        Me.textNombCodigo.MaxLength = 25
        Me.textNombCodigo.Name = "textNombCodigo"
        Me.textNombCodigo.Size = New System.Drawing.Size(316, 20)
        Me.textNombCodigo.TabIndex = 2
        '
        'textCodigo
        '
        Me.textCodigo.BackColor = System.Drawing.Color.White
        Me.textCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textCodigo.Location = New System.Drawing.Point(6, 19)
        Me.textCodigo.MaxLength = 5
        Me.textCodigo.Name = "textCodigo"
        Me.textCodigo.Size = New System.Drawing.Size(48, 20)
        Me.textCodigo.TabIndex = 1
        '
        'dgDatos
        '
        Me.dgDatos.AllowUserToAddRows = False
        Me.dgDatos.AllowUserToDeleteRows = False
        Me.dgDatos.AllowUserToOrderColumns = True
        Me.dgDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.dgDatos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgDatos.BackgroundColor = System.Drawing.Color.White
        Me.dgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDatos.ContextMenuStrip = Me.ctxMenu
        Me.dgDatos.GridColor = System.Drawing.Color.DimGray
        Me.dgDatos.Location = New System.Drawing.Point(16, 248)
        Me.dgDatos.MultiSelect = False
        Me.dgDatos.Name = "dgDatos"
        Me.dgDatos.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatos.Size = New System.Drawing.Size(1098, 287)
        Me.dgDatos.TabIndex = 40
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
        'pnFin
        '
        Me.pnFin.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnFin.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.pnFin.Controls.Add(Me.btnLimpiar)
        Me.pnFin.Controls.Add(Me.btnGuardar)
        Me.pnFin.Location = New System.Drawing.Point(0, 555)
        Me.pnFin.Name = "pnFin"
        Me.pnFin.Size = New System.Drawing.Size(1130, 40)
        Me.pnFin.TabIndex = 42
        '
        'frmMantMovNominas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 594)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.pnFin)
        Me.Controls.Add(Me.gpEmpleado)
        Me.Controls.Add(Me.gpContrato)
        Me.Controls.Add(Me.dgDatos)
        Me.Controls.Add(Me.gpDetalle)
        Me.Controls.Add(Me.gpDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmMantMovNominas"
        Me.Text = "Mantenimiento de Movimientos Variables de Nómina"
        Me.gpDatos.ResumeLayout(False)
        Me.gpDatos.PerformLayout()
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        Me.gpEmpleado.ResumeLayout(False)
        Me.gpEmpleado.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpDetalle.ResumeLayout(False)
        Me.gpDetalle.PerformLayout()
        Me.gpTransaccion.ResumeLayout(False)
        Me.gpTransaccion.PerformLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        Me.pnFin.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpEmpleado As System.Windows.Forms.GroupBox
    Friend WithEvents textEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents btnContrato As System.Windows.Forms.Button
    Friend WithEvents gpContrato As System.Windows.Forms.GroupBox
    Friend WithEvents TextConxContrato As System.Windows.Forms.TextBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents gpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
    Friend WithEvents LbTipo As System.Windows.Forms.Label
    Friend WithEvents TextValor As System.Windows.Forms.TextBox
    Friend WithEvents gpTransaccion As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscaCodigo As System.Windows.Forms.Button
    Friend WithEvents textNombCodigo As System.Windows.Forms.TextBox
    Friend WithEvents textCodigo As System.Windows.Forms.TextBox
    Friend WithEvents dgDatos As System.Windows.Forms.DataGridView
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextAño As System.Windows.Forms.TextBox
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents pnFin As System.Windows.Forms.Panel
    Friend WithEvents cbMes As CheckedListBox
    Friend WithEvents btnDesmarcar As Button
    Friend WithEvents btnMarcar As Button
End Class
