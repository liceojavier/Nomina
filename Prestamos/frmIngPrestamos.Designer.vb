<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIngPrestamos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngPrestamos))
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextEmpresa = New System.Windows.Forms.TextBox()
        Me.gpDatos = New System.Windows.Forms.GroupBox()
        Me.TextNoDocto = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbTipoDoc = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbAño = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.TextMeses = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextValor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gpContrato = New System.Windows.Forms.GroupBox()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.TextConxContrato = New System.Windows.Forms.TextBox()
        Me.gpChofer = New System.Windows.Forms.GroupBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textEmpleado = New System.Windows.Forms.TextBox()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.gpPrestamo = New System.Windows.Forms.GroupBox()
        Me.TextConxNumero = New System.Windows.Forms.TextBox()
        Me.stbPanel = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.textFecha = New System.Windows.Forms.MaskedTextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.gpEmpresa.SuspendLayout()
        Me.gpDatos.SuspendLayout()
        Me.gpContrato.SuspendLayout()
        Me.gpChofer.SuspendLayout()
        Me.gpPrestamo.SuspendLayout()
        Me.stbPanel.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpFecha.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextEmpresa)
        Me.gpEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(225, 2)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(386, 45)
        Me.gpEmpresa.TabIndex = 0
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextEmpresa
        '
        Me.TextEmpresa.BackColor = System.Drawing.Color.White
        Me.TextEmpresa.Location = New System.Drawing.Point(12, 19)
        Me.TextEmpresa.Name = "TextEmpresa"
        Me.TextEmpresa.ReadOnly = True
        Me.TextEmpresa.Size = New System.Drawing.Size(362, 20)
        Me.TextEmpresa.TabIndex = 0
        Me.TextEmpresa.TabStop = False
        '
        'gpDatos
        '
        Me.gpDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpDatos.Controls.Add(Me.TextNoDocto)
        Me.gpDatos.Controls.Add(Me.Label9)
        Me.gpDatos.Controls.Add(Me.Label7)
        Me.gpDatos.Controls.Add(Me.cmbTipoDoc)
        Me.gpDatos.Controls.Add(Me.Label6)
        Me.gpDatos.Controls.Add(Me.cmbAño)
        Me.gpDatos.Controls.Add(Me.Label5)
        Me.gpDatos.Controls.Add(Me.cmbMes)
        Me.gpDatos.Controls.Add(Me.TextMeses)
        Me.gpDatos.Controls.Add(Me.Label4)
        Me.gpDatos.Controls.Add(Me.TextValor)
        Me.gpDatos.Controls.Add(Me.Label2)
        Me.gpDatos.Controls.Add(Me.gpContrato)
        Me.gpDatos.Controls.Add(Me.gpChofer)
        Me.gpDatos.Controls.Add(Me.TextObservaciones)
        Me.gpDatos.Controls.Add(Me.Label8)
        Me.gpDatos.Controls.Add(Me.Label3)
        Me.gpDatos.Controls.Add(Me.cmbTipo)
        Me.gpDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDatos.Location = New System.Drawing.Point(4, 60)
        Me.gpDatos.Name = "gpDatos"
        Me.gpDatos.Size = New System.Drawing.Size(798, 316)
        Me.gpDatos.TabIndex = 3
        Me.gpDatos.TabStop = False
        Me.gpDatos.Text = "Ingreso"
        '
        'TextNoDocto
        '
        Me.TextNoDocto.BackColor = System.Drawing.Color.White
        Me.TextNoDocto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNoDocto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNoDocto.Location = New System.Drawing.Point(491, 199)
        Me.TextNoDocto.MaxLength = 9
        Me.TextNoDocto.Name = "TextNoDocto"
        Me.TextNoDocto.Size = New System.Drawing.Size(96, 20)
        Me.TextNoDocto.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(352, 202)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(118, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Número de documento:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(10, 202)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Tipo de documento:"
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.BackColor = System.Drawing.Color.White
        Me.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDoc.FormattingEnabled = True
        Me.cmbTipoDoc.Items.AddRange(New Object() {"CHEQUE", "OTRO DOCUMENTO", ""})
        Me.cmbTipoDoc.Location = New System.Drawing.Point(117, 199)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.Size = New System.Drawing.Size(214, 21)
        Me.cmbTipoDoc.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(682, 148)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Año:"
        '
        'cmbAño
        '
        Me.cmbAño.BackColor = System.Drawing.Color.White
        Me.cmbAño.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAño.FormattingEnabled = True
        Me.cmbAño.Location = New System.Drawing.Point(719, 144)
        Me.cmbAño.Name = "cmbAño"
        Me.cmbAño.Size = New System.Drawing.Size(64, 21)
        Me.cmbAño.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(473, 149)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Mes inicial:"
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.White
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Location = New System.Drawing.Point(539, 145)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(135, 21)
        Me.cmbMes.TabIndex = 6
        '
        'TextMeses
        '
        Me.TextMeses.BackColor = System.Drawing.Color.White
        Me.TextMeses.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextMeses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMeses.Location = New System.Drawing.Point(344, 145)
        Me.TextMeses.MaxLength = 4
        Me.TextMeses.Name = "TextMeses"
        Me.TextMeses.Size = New System.Drawing.Size(96, 20)
        Me.TextMeses.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(242, 148)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Número de cuotas:"
        '
        'TextValor
        '
        Me.TextValor.BackColor = System.Drawing.Color.White
        Me.TextValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValor.Location = New System.Drawing.Point(117, 145)
        Me.TextValor.MaxLength = 11
        Me.TextValor.Name = "TextValor"
        Me.TextValor.Size = New System.Drawing.Size(96, 20)
        Me.TextValor.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(10, 149)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Valor total:"
        '
        'gpContrato
        '
        Me.gpContrato.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpContrato.Controls.Add(Me.btnContrato)
        Me.gpContrato.Controls.Add(Me.TextConxContrato)
        Me.gpContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpContrato.Location = New System.Drawing.Point(642, 18)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(137, 48)
        Me.gpContrato.TabIndex = 2
        Me.gpContrato.TabStop = False
        Me.gpContrato.Text = "Contrato"
        '
        'btnContrato
        '
        Me.btnContrato.BackColor = System.Drawing.SystemColors.Control
        Me.btnContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContrato.ImageKey = "buscar2.png"
        Me.btnContrato.ImageList = Me.ImageNuevos
        Me.btnContrato.Location = New System.Drawing.Point(79, 13)
        Me.btnContrato.Name = "btnContrato"
        Me.btnContrato.Size = New System.Drawing.Size(40, 30)
        Me.btnContrato.TabIndex = 16
        Me.btnContrato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnContrato.UseVisualStyleBackColor = False
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
        'TextConxContrato
        '
        Me.TextConxContrato.BackColor = System.Drawing.Color.White
        Me.TextConxContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConxContrato.ForeColor = System.Drawing.Color.Red
        Me.TextConxContrato.Location = New System.Drawing.Point(10, 20)
        Me.TextConxContrato.MaxLength = 4
        Me.TextConxContrato.Name = "TextConxContrato"
        Me.TextConxContrato.Size = New System.Drawing.Size(63, 20)
        Me.TextConxContrato.TabIndex = 1
        Me.TextConxContrato.TabStop = False
        '
        'gpChofer
        '
        Me.gpChofer.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpChofer.Controls.Add(Me.btnEmpleado)
        Me.gpChofer.Controls.Add(Me.textNombreEmple)
        Me.gpChofer.Controls.Add(Me.textEmpleado)
        Me.gpChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpChofer.Location = New System.Drawing.Point(7, 17)
        Me.gpChofer.Name = "gpChofer"
        Me.gpChofer.Size = New System.Drawing.Size(622, 50)
        Me.gpChofer.TabIndex = 1
        Me.gpChofer.TabStop = False
        Me.gpChofer.Text = "Empleado"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(520, 10)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(60, 30)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEmpleado, "Empleado")
        Me.btnEmpleado.UseVisualStyleBackColor = False
        '
        'textNombreEmple
        '
        Me.textNombreEmple.BackColor = System.Drawing.Color.White
        Me.textNombreEmple.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombreEmple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombreEmple.Location = New System.Drawing.Point(66, 18)
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
        Me.textEmpleado.Location = New System.Drawing.Point(6, 18)
        Me.textEmpleado.MaxLength = 6
        Me.textEmpleado.Name = "textEmpleado"
        Me.textEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textEmpleado.TabIndex = 1
        '
        'TextObservaciones
        '
        Me.TextObservaciones.BackColor = System.Drawing.Color.White
        Me.TextObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextObservaciones.Location = New System.Drawing.Point(117, 251)
        Me.TextObservaciones.MaxLength = 75
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(663, 20)
        Me.TextObservaciones.TabIndex = 10
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(10, 253)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Observaciones:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(10, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tipo de descuento:"
        '
        'cmbTipo
        '
        Me.cmbTipo.BackColor = System.Drawing.Color.White
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Location = New System.Drawing.Point(117, 82)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(387, 21)
        Me.cmbTipo.TabIndex = 3
        '
        'gpPrestamo
        '
        Me.gpPrestamo.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpPrestamo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpPrestamo.Controls.Add(Me.TextConxNumero)
        Me.gpPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gpPrestamo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpPrestamo.ForeColor = System.Drawing.Color.White
        Me.gpPrestamo.Location = New System.Drawing.Point(632, 3)
        Me.gpPrestamo.Name = "gpPrestamo"
        Me.gpPrestamo.Size = New System.Drawing.Size(97, 45)
        Me.gpPrestamo.TabIndex = 1
        Me.gpPrestamo.TabStop = False
        Me.gpPrestamo.Text = "Número"
        '
        'TextConxNumero
        '
        Me.TextConxNumero.BackColor = System.Drawing.Color.White
        Me.TextConxNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConxNumero.ForeColor = System.Drawing.Color.Red
        Me.TextConxNumero.Location = New System.Drawing.Point(7, 20)
        Me.TextConxNumero.Name = "TextConxNumero"
        Me.TextConxNumero.ReadOnly = True
        Me.TextConxNumero.Size = New System.Drawing.Size(83, 20)
        Me.TextConxNumero.TabIndex = 0
        Me.TextConxNumero.TabStop = False
        '
        'stbPanel
        '
        Me.stbPanel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.stbPanel.Location = New System.Drawing.Point(0, 423)
        Me.stbPanel.Name = "stbPanel"
        Me.stbPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.stbPanel.Size = New System.Drawing.Size(836, 24)
        Me.stbPanel.TabIndex = 38
        Me.stbPanel.Text = "Realiza el ingreso de los puestos."
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(821, 19)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Permite el ingreso de los descuentos que necesitan llevar una cuenta corriente. "
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(19, 6)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(60, 30)
        Me.btnLimpiar.TabIndex = 37
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(753, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 30)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Guardar Registro")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'gpFecha
        '
        Me.gpFecha.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpFecha.Controls.Add(Me.textFecha)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.ForeColor = System.Drawing.Color.White
        Me.gpFecha.Location = New System.Drawing.Point(735, 3)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(95, 45)
        Me.gpFecha.TabIndex = 2
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Fecha"
        '
        'textFecha
        '
        Me.textFecha.BackColor = System.Drawing.Color.White
        Me.textFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFecha.Location = New System.Drawing.Point(6, 20)
        Me.textFecha.Mask = "##/##/####"
        Me.textFecha.Name = "textFecha"
        Me.textFecha.Size = New System.Drawing.Size(84, 20)
        Me.textFecha.TabIndex = 19
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpFecha)
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Controls.Add(Me.gpPrestamo)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(836, 60)
        Me.Panel1.TabIndex = 39
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnGuardar)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Location = New System.Drawing.Point(0, 382)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(836, 41)
        Me.Panel2.TabIndex = 40
        '
        'frmIngPrestamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(836, 447)
        Me.Controls.Add(Me.stbPanel)
        Me.Controls.Add(Me.gpDatos)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmIngPrestamos"
        Me.Text = "Ingreso de Descuentos Fijos"
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        Me.gpDatos.ResumeLayout(False)
        Me.gpDatos.PerformLayout()
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        Me.gpChofer.ResumeLayout(False)
        Me.gpChofer.PerformLayout()
        Me.gpPrestamo.ResumeLayout(False)
        Me.gpPrestamo.PerformLayout()
        Me.stbPanel.ResumeLayout(False)
        Me.stbPanel.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents gpDatos As System.Windows.Forms.GroupBox
    Friend WithEvents gpPrestamo As System.Windows.Forms.GroupBox
    Friend WithEvents TextConxNumero As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents stbPanel As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpChofer As System.Windows.Forms.GroupBox
    Friend WithEvents textEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents btnContrato As System.Windows.Forms.Button
    Friend WithEvents gpContrato As System.Windows.Forms.GroupBox
    Friend WithEvents TextConxContrato As System.Windows.Forms.TextBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents TextValor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents gpFecha As System.Windows.Forms.GroupBox
    Friend WithEvents textFecha As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbAño As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents TextMeses As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextNoDocto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
