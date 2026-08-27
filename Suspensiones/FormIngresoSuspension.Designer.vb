<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormIngresoSuspension
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormIngresoSuspension))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gpPuesto = New System.Windows.Forms.GroupBox()
        Me.txtNumero = New System.Windows.Forms.TextBox()
        Me.gpDatos = New System.Windows.Forms.Panel()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.txtFechaF = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbAlta = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbGrado = New System.Windows.Forms.ComboBox()
        Me.gpContrato = New System.Windows.Forms.GroupBox()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.TextConxContrato = New System.Windows.Forms.TextBox()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.pnEstado = New System.Windows.Forms.Panel()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtFechae = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtValor = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCantidad = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.dpFechaI = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.busqEmpleado = New NOMINA.BusquedaEmpleadoControl()
        Me.txtObservaciones = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipoSus = New System.Windows.Forms.ComboBox()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.gpPuesto.SuspendLayout()
        Me.gpDatos.SuspendLayout()
        Me.gpContrato.SuspendLayout()
        Me.pnEstado.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpPuesto
        '
        Me.gpPuesto.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpPuesto.Controls.Add(Me.txtNumero)
        Me.gpPuesto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gpPuesto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpPuesto.ForeColor = System.Drawing.Color.White
        Me.gpPuesto.Location = New System.Drawing.Point(942, 10)
        Me.gpPuesto.Name = "gpPuesto"
        Me.gpPuesto.Size = New System.Drawing.Size(111, 44)
        Me.gpPuesto.TabIndex = 3
        Me.gpPuesto.TabStop = False
        Me.gpPuesto.Text = "Suspensión"
        '
        'txtNumero
        '
        Me.txtNumero.BackColor = System.Drawing.Color.White
        Me.txtNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumero.ForeColor = System.Drawing.Color.Red
        Me.txtNumero.Location = New System.Drawing.Point(10, 19)
        Me.txtNumero.Name = "txtNumero"
        Me.txtNumero.ReadOnly = True
        Me.txtNumero.Size = New System.Drawing.Size(90, 20)
        Me.txtNumero.TabIndex = 0
        Me.txtNumero.TabStop = False
        '
        'gpDatos
        '
        Me.gpDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.gpDatos.Controls.Add(Me.btnLimpiar)
        Me.gpDatos.Controls.Add(Me.txtFechaF)
        Me.gpDatos.Controls.Add(Me.Label6)
        Me.gpDatos.Controls.Add(Me.cmbAlta)
        Me.gpDatos.Controls.Add(Me.Label7)
        Me.gpDatos.Controls.Add(Me.cmbGrado)
        Me.gpDatos.Controls.Add(Me.gpContrato)
        Me.gpDatos.Controls.Add(Me.btnGuardar)
        Me.gpDatos.Controls.Add(Me.pnEstado)
        Me.gpDatos.Controls.Add(Me.txtValor)
        Me.gpDatos.Controls.Add(Me.Label4)
        Me.gpDatos.Controls.Add(Me.txtCantidad)
        Me.gpDatos.Controls.Add(Me.Label9)
        Me.gpDatos.Controls.Add(Me.Label2)
        Me.gpDatos.Controls.Add(Me.dpFechaI)
        Me.gpDatos.Controls.Add(Me.Label1)
        Me.gpDatos.Controls.Add(Me.busqEmpleado)
        Me.gpDatos.Controls.Add(Me.gpPuesto)
        Me.gpDatos.Controls.Add(Me.txtObservaciones)
        Me.gpDatos.Controls.Add(Me.Label8)
        Me.gpDatos.Controls.Add(Me.Label5)
        Me.gpDatos.Controls.Add(Me.Label3)
        Me.gpDatos.Controls.Add(Me.cmbTipoSus)
        Me.gpDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDatos.Location = New System.Drawing.Point(2, 4)
        Me.gpDatos.Name = "gpDatos"
        Me.gpDatos.Size = New System.Drawing.Size(1067, 258)
        Me.gpDatos.TabIndex = 41
        Me.gpDatos.Text = "Ingreso"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageIndex = 1
        Me.btnLimpiar.ImageList = Me.ImageList1
        Me.btnLimpiar.Location = New System.Drawing.Point(981, 210)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 123
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnLimpiar.UseVisualStyleBackColor = False
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
        'txtFechaF
        '
        Me.txtFechaF.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtFechaF.BackColor = System.Drawing.Color.White
        Me.txtFechaF.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechaF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechaF.ForeColor = System.Drawing.Color.Red
        Me.txtFechaF.Location = New System.Drawing.Point(364, 107)
        Me.txtFechaF.MaxLength = 12
        Me.txtFechaF.Name = "txtFechaF"
        Me.txtFechaF.ReadOnly = True
        Me.txtFechaF.Size = New System.Drawing.Size(111, 20)
        Me.txtFechaF.TabIndex = 8
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(766, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(66, 13)
        Me.Label6.TabIndex = 120
        Me.Label6.Text = "Tipo de alta:"
        '
        'cmbAlta
        '
        Me.cmbAlta.BackColor = System.Drawing.Color.White
        Me.cmbAlta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAlta.FormattingEnabled = True
        Me.cmbAlta.Location = New System.Drawing.Point(837, 72)
        Me.cmbAlta.Name = "cmbAlta"
        Me.cmbAlta.Size = New System.Drawing.Size(199, 21)
        Me.cmbAlta.TabIndex = 6
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(361, 72)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(98, 13)
        Me.Label7.TabIndex = 118
        Me.Label7.Text = "Grado  de la lesión:"
        '
        'cmbGrado
        '
        Me.cmbGrado.BackColor = System.Drawing.Color.White
        Me.cmbGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrado.FormattingEnabled = True
        Me.cmbGrado.Location = New System.Drawing.Point(464, 72)
        Me.cmbGrado.Name = "cmbGrado"
        Me.cmbGrado.Size = New System.Drawing.Size(296, 21)
        Me.cmbGrado.TabIndex = 5
        '
        'gpContrato
        '
        Me.gpContrato.BackColor = System.Drawing.Color.FromArgb(CType(CType(74, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(226, Byte), Integer))
        Me.gpContrato.Controls.Add(Me.btnContrato)
        Me.gpContrato.Controls.Add(Me.TextConxContrato)
        Me.gpContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpContrato.ForeColor = System.Drawing.Color.White
        Me.gpContrato.Location = New System.Drawing.Point(694, 13)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(137, 44)
        Me.gpContrato.TabIndex = 2
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
        'TextConxContrato
        '
        Me.TextConxContrato.BackColor = System.Drawing.Color.White
        Me.TextConxContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConxContrato.ForeColor = System.Drawing.Color.Red
        Me.TextConxContrato.Location = New System.Drawing.Point(10, 16)
        Me.TextConxContrato.MaxLength = 4
        Me.TextConxContrato.Name = "TextConxContrato"
        Me.TextConxContrato.ReadOnly = True
        Me.TextConxContrato.Size = New System.Drawing.Size(63, 20)
        Me.TextConxContrato.TabIndex = 1
        Me.TextConxContrato.TabStop = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.ImageIndex = 2
        Me.btnGuardar.ImageList = Me.ImageList1
        Me.btnGuardar.Location = New System.Drawing.Point(894, 211)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 30)
        Me.btnGuardar.TabIndex = 13
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'pnEstado
        '
        Me.pnEstado.Controls.Add(Me.txtEstado)
        Me.pnEstado.Controls.Add(Me.Label10)
        Me.pnEstado.Controls.Add(Me.txtFechae)
        Me.pnEstado.Controls.Add(Me.Label11)
        Me.pnEstado.Controls.Add(Me.Label12)
        Me.pnEstado.Controls.Add(Me.txtUsuario)
        Me.pnEstado.Location = New System.Drawing.Point(10, 204)
        Me.pnEstado.Name = "pnEstado"
        Me.pnEstado.Size = New System.Drawing.Size(780, 42)
        Me.pnEstado.TabIndex = 12
        '
        'txtEstado
        '
        Me.txtEstado.BackColor = System.Drawing.Color.White
        Me.txtEstado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEstado.Location = New System.Drawing.Point(110, 13)
        Me.txtEstado.MaxLength = 75
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.ReadOnly = True
        Me.txtEstado.Size = New System.Drawing.Size(236, 20)
        Me.txtEstado.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(1, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 32
        Me.Label10.Text = "Estado:"
        '
        'txtFechae
        '
        Me.txtFechae.BackColor = System.Drawing.Color.White
        Me.txtFechae.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFechae.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFechae.Location = New System.Drawing.Point(491, 13)
        Me.txtFechae.MaxLength = 4
        Me.txtFechae.Name = "txtFechae"
        Me.txtFechae.ReadOnly = True
        Me.txtFechae.Size = New System.Drawing.Size(86, 20)
        Me.txtFechae.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(380, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 13)
        Me.Label11.TabIndex = 36
        Me.Label11.Text = "Fecha de operación:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(596, 13)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Usuario:"
        '
        'txtUsuario
        '
        Me.txtUsuario.BackColor = System.Drawing.Color.White
        Me.txtUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(653, 13)
        Me.txtUsuario.MaxLength = 4
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.ReadOnly = True
        Me.txtUsuario.Size = New System.Drawing.Size(120, 20)
        Me.txtUsuario.TabIndex = 3
        Me.txtUsuario.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtValor
        '
        Me.txtValor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtValor.BackColor = System.Drawing.Color.White
        Me.txtValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtValor.ForeColor = System.Drawing.Color.Red
        Me.txtValor.Location = New System.Drawing.Point(230, 178)
        Me.txtValor.MaxLength = 12
        Me.txtValor.Name = "txtValor"
        Me.txtValor.ReadOnly = True
        Me.txtValor.Size = New System.Drawing.Size(95, 20)
        Me.txtValor.TabIndex = 11
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(190, 178)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "Valor:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCantidad
        '
        Me.txtCantidad.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.txtCantidad.BackColor = System.Drawing.Color.White
        Me.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCantidad.Location = New System.Drawing.Point(119, 178)
        Me.txtCantidad.MaxLength = 6
        Me.txtCantidad.Name = "txtCantidad"
        Me.txtCantidad.ReadOnly = True
        Me.txtCantidad.Size = New System.Drawing.Size(61, 20)
        Me.txtCantidad.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(11, 178)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 13)
        Me.Label9.TabIndex = 109
        Me.Label9.Text = "Cantidad de días:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(299, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Fecha final:"
        '
        'dpFechaI
        '
        Me.dpFechaI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaI.Location = New System.Drawing.Point(120, 107)
        Me.dpFechaI.Name = "dpFechaI"
        Me.dpFechaI.Size = New System.Drawing.Size(111, 20)
        Me.dpFechaI.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(11, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Empleado:"
        '
        'busqEmpleado
        '
        Me.busqEmpleado.activo = False
        Me.busqEmpleado.Contrato = 0
        Me.busqEmpleado.Empleado = 0
        Me.busqEmpleado.id_empresa = CType(0, Short)
        Me.busqEmpleado.Location = New System.Drawing.Point(92, 34)
        Me.busqEmpleado.Margin = New System.Windows.Forms.Padding(4)
        Me.busqEmpleado.Name = "busqEmpleado"
        Me.busqEmpleado.Nombre = ""
        Me.busqEmpleado.Size = New System.Drawing.Size(595, 23)
        Me.busqEmpleado.TabIndex = 1
        '
        'txtObservaciones
        '
        Me.txtObservaciones.BackColor = System.Drawing.Color.White
        Me.txtObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtObservaciones.Location = New System.Drawing.Point(120, 141)
        Me.txtObservaciones.MaxLength = 75
        Me.txtObservaciones.Name = "txtObservaciones"
        Me.txtObservaciones.Size = New System.Drawing.Size(663, 20)
        Me.txtObservaciones.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(11, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Observaciones:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(10, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(82, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Fecha de inicio:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(10, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Tipo de suspensión:"
        '
        'cmbTipoSus
        '
        Me.cmbTipoSus.BackColor = System.Drawing.Color.White
        Me.cmbTipoSus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoSus.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoSus.FormattingEnabled = True
        Me.cmbTipoSus.Location = New System.Drawing.Point(120, 72)
        Me.cmbTipoSus.Name = "cmbTipoSus"
        Me.cmbTipoSus.Size = New System.Drawing.Size(237, 21)
        Me.cmbTipoSus.TabIndex = 4
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
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'dgvData
        '
        Me.dgvData.AllowUserToAddRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.dgvData.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvData.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(4, 268)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.ReadOnly = True
        Me.dgvData.Size = New System.Drawing.Size(1065, 258)
        Me.dgvData.TabIndex = 44
        '
        'FormIngresoSuspension
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1081, 538)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.gpDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormIngresoSuspension"
        Me.Text = "Ingreso de Suspensiones"
        Me.gpPuesto.ResumeLayout(False)
        Me.gpPuesto.PerformLayout()
        Me.gpDatos.ResumeLayout(False)
        Me.gpDatos.PerformLayout()
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        Me.pnEstado.ResumeLayout(False)
        Me.pnEstado.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpPuesto As GroupBox
    Friend WithEvents txtNumero As TextBox
    Friend WithEvents gpDatos As Panel
    Friend WithEvents txtObservaciones As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cmbTipoSus As ComboBox
    Friend WithEvents ep1 As ErrorProvider
    Friend WithEvents ImageNuevos As ImageList
    Friend WithEvents bnPrincipal As BindingNavigator
    Friend WithEvents tsTitulo As ToolStripLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents dpFechaI As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents busqEmpleado As BusquedaEmpleadoControl
    Friend WithEvents txtUsuario As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents txtFechae As TextBox
    Friend WithEvents txtEstado As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents txtValor As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtCantidad As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents pnEstado As Panel
    Friend WithEvents dgvData As DataGridView
    Friend WithEvents btnGuardar As Button
    Friend WithEvents gpContrato As GroupBox
    Friend WithEvents btnContrato As Button
    Friend WithEvents TextConxContrato As TextBox
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents Label6 As Label
    Friend WithEvents cmbAlta As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents cmbGrado As ComboBox
    Friend WithEvents txtFechaF As TextBox
    Friend WithEvents btnLimpiar As Button
End Class
