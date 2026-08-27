<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmConsPrestamos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsPrestamos))
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextEmpresa = New System.Windows.Forms.TextBox()
        Me.gpDatos = New System.Windows.Forms.Panel()
        Me.ctxPrincipal = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxAnulacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxReactivacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.dpFechaI = New System.Windows.Forms.DateTimePicker()
        Me.pnNoCuotas = New System.Windows.Forms.Panel()
        Me.txtMeses = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnDescMensual = New System.Windows.Forms.Button()
        Me.textDescBono = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.pnPrincipal = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.TextEstado = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextFechae = New System.Windows.Forms.TextBox()
        Me.TextUsuario = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.textDescAguinaldo = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.axFechaIngreso = New axFecha.axDateDB()
        Me.TextDescuento = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.gpSaldo = New System.Windows.Forms.GroupBox()
        Me.TextSaldo = New System.Windows.Forms.TextBox()
        Me.btnSaldo = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.TextNoDocto = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbTipoDoc = New System.Windows.Forms.ComboBox()
        Me.gpPrestamo = New System.Windows.Forms.GroupBox()
        Me.TextConxPrestamo = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.TextValor = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gpContrato = New System.Windows.Forms.GroupBox()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.TextConxContrato = New System.Windows.Forms.TextBox()
        Me.gpChofer = New System.Windows.Forms.GroupBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textConxEmpleado = New System.Windows.Forms.TextBox()
        Me.TextObservaciones = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSig = New System.Windows.Forms.Button()
        Me.btnAtr = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCtaCorr = New System.Windows.Forms.Button()
        Me.btnAgregarDet = New System.Windows.Forms.Button()
        Me.pnEncabezado = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPrincipal = New System.Windows.Forms.TabPage()
        Me.TabDetalle = New System.Windows.Forms.TabPage()
        Me.txtAbonos = New System.Windows.Forms.TextBox()
        Me.txtCargos = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dgvDatos = New System.Windows.Forms.DataGridView()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.lblestado = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtValorDet = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbCargo = New System.Windows.Forms.RadioButton()
        Me.rbAbono = New System.Windows.Forms.RadioButton()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbMesDet = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbTipNom = New System.Windows.Forms.ComboBox()
        Me.TabConsulta = New System.Windows.Forms.TabPage()
        Me.dgvConsulta = New System.Windows.Forms.DataGridView()
        Me.ctxDetalle = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuModificarDet = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxPrincipalCuenta = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModCuota = New System.Windows.Forms.ToolStripMenuItem()
        Me.txtAñoDet = New System.Windows.Forms.TextBox()
        Me.gpEmpresa.SuspendLayout()
        Me.gpDatos.SuspendLayout()
        Me.ctxPrincipal.SuspendLayout()
        Me.pnNoCuotas.SuspendLayout()
        Me.pnPrincipal.SuspendLayout()
        Me.gpSaldo.SuspendLayout()
        Me.gpPrestamo.SuspendLayout()
        Me.gpContrato.SuspendLayout()
        Me.gpChofer.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPrincipal.SuspendLayout()
        Me.TabDetalle.SuspendLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabConsulta.SuspendLayout()
        CType(Me.dgvConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxDetalle.SuspendLayout()
        Me.ctxPrincipalCuenta.SuspendLayout()
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
        Me.gpEmpresa.Location = New System.Drawing.Point(360, 2)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(410, 45)
        Me.gpEmpresa.TabIndex = 0
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextEmpresa
        '
        Me.TextEmpresa.BackColor = System.Drawing.Color.White
        Me.TextEmpresa.Location = New System.Drawing.Point(15, 19)
        Me.TextEmpresa.Name = "TextEmpresa"
        Me.TextEmpresa.ReadOnly = True
        Me.TextEmpresa.Size = New System.Drawing.Size(381, 20)
        Me.TextEmpresa.TabIndex = 0
        Me.TextEmpresa.TabStop = False
        '
        'gpDatos
        '
        Me.gpDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpDatos.ContextMenuStrip = Me.ctxPrincipal
        Me.gpDatos.Controls.Add(Me.dpFechaI)
        Me.gpDatos.Controls.Add(Me.pnNoCuotas)
        Me.gpDatos.Controls.Add(Me.btnDescMensual)
        Me.gpDatos.Controls.Add(Me.textDescBono)
        Me.gpDatos.Controls.Add(Me.Label20)
        Me.gpDatos.Controls.Add(Me.pnPrincipal)
        Me.gpDatos.Controls.Add(Me.textDescAguinaldo)
        Me.gpDatos.Controls.Add(Me.Label19)
        Me.gpDatos.Controls.Add(Me.Label1)
        Me.gpDatos.Controls.Add(Me.axFechaIngreso)
        Me.gpDatos.Controls.Add(Me.TextDescuento)
        Me.gpDatos.Controls.Add(Me.Label11)
        Me.gpDatos.Controls.Add(Me.gpSaldo)
        Me.gpDatos.Controls.Add(Me.TextAño)
        Me.gpDatos.Controls.Add(Me.TextNoDocto)
        Me.gpDatos.Controls.Add(Me.Label9)
        Me.gpDatos.Controls.Add(Me.Label7)
        Me.gpDatos.Controls.Add(Me.cmbTipoDoc)
        Me.gpDatos.Controls.Add(Me.gpPrestamo)
        Me.gpDatos.Controls.Add(Me.Label6)
        Me.gpDatos.Controls.Add(Me.Label5)
        Me.gpDatos.Controls.Add(Me.cmbMes)
        Me.gpDatos.Controls.Add(Me.TextValor)
        Me.gpDatos.Controls.Add(Me.Label2)
        Me.gpDatos.Controls.Add(Me.gpContrato)
        Me.gpDatos.Controls.Add(Me.gpChofer)
        Me.gpDatos.Controls.Add(Me.TextObservaciones)
        Me.gpDatos.Controls.Add(Me.Label8)
        Me.gpDatos.Controls.Add(Me.Label3)
        Me.gpDatos.Controls.Add(Me.cmbTipo)
        Me.gpDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDatos.Location = New System.Drawing.Point(6, 6)
        Me.gpDatos.Name = "gpDatos"
        Me.gpDatos.Size = New System.Drawing.Size(1108, 462)
        Me.gpDatos.TabIndex = 3
        '
        'ctxPrincipal
        '
        Me.ctxPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxAnulacion, Me.ctxModificar, Me.ctxReactivacion})
        Me.ctxPrincipal.Name = "ctxMenu"
        Me.ctxPrincipal.Size = New System.Drawing.Size(145, 70)
        '
        'ctxAnulacion
        '
        Me.ctxAnulacion.Image = Global.NOMINA.My.Resources.Resources.cancelar
        Me.ctxAnulacion.Name = "ctxAnulacion"
        Me.ctxAnulacion.Size = New System.Drawing.Size(144, 22)
        Me.ctxAnulacion.Text = "Anulación"
        '
        'ctxModificar
        '
        Me.ctxModificar.Image = Global.NOMINA.My.Resources.Resources.edit1
        Me.ctxModificar.Name = "ctxModificar"
        Me.ctxModificar.Size = New System.Drawing.Size(144, 22)
        Me.ctxModificar.Text = "Modificación"
        '
        'ctxReactivacion
        '
        Me.ctxReactivacion.Image = Global.NOMINA.My.Resources.Resources.reactivate
        Me.ctxReactivacion.Name = "ctxReactivacion"
        Me.ctxReactivacion.Size = New System.Drawing.Size(144, 22)
        Me.ctxReactivacion.Text = "Reactivación"
        '
        'dpFechaI
        '
        Me.dpFechaI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaI.Location = New System.Drawing.Point(720, 67)
        Me.dpFechaI.Name = "dpFechaI"
        Me.dpFechaI.Size = New System.Drawing.Size(119, 20)
        Me.dpFechaI.TabIndex = 5
        '
        'pnNoCuotas
        '
        Me.pnNoCuotas.Controls.Add(Me.txtMeses)
        Me.pnNoCuotas.Controls.Add(Me.Label4)
        Me.pnNoCuotas.Location = New System.Drawing.Point(624, 169)
        Me.pnNoCuotas.Name = "pnNoCuotas"
        Me.pnNoCuotas.Size = New System.Drawing.Size(191, 39)
        Me.pnNoCuotas.TabIndex = 14
        '
        'txtMeses
        '
        Me.txtMeses.BackColor = System.Drawing.Color.White
        Me.txtMeses.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtMeses.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMeses.Location = New System.Drawing.Point(122, 8)
        Me.txtMeses.MaxLength = 4
        Me.txtMeses.Name = "txtMeses"
        Me.txtMeses.Size = New System.Drawing.Size(58, 20)
        Me.txtMeses.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 8)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 26)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Número de cuotas:"
        '
        'btnDescMensual
        '
        Me.btnDescMensual.BackColor = System.Drawing.SystemColors.Control
        Me.btnDescMensual.Location = New System.Drawing.Point(978, 166)
        Me.btnDescMensual.Name = "btnDescMensual"
        Me.btnDescMensual.Size = New System.Drawing.Size(116, 40)
        Me.btnDescMensual.TabIndex = 16
        Me.btnDescMensual.Text = "Calcular descuento mensual"
        Me.btnDescMensual.UseVisualStyleBackColor = False
        '
        'textDescBono
        '
        Me.textDescBono.BackColor = System.Drawing.Color.White
        Me.textDescBono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textDescBono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textDescBono.Location = New System.Drawing.Point(337, 176)
        Me.textDescBono.MaxLength = 11
        Me.textDescBono.Name = "textDescBono"
        Me.textDescBono.Size = New System.Drawing.Size(75, 20)
        Me.textDescBono.TabIndex = 12
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(209, 176)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(120, 13)
        Me.Label20.TabIndex = 141
        Me.Label20.Text = "Descuento Bono Anual:"
        '
        'pnPrincipal
        '
        Me.pnPrincipal.Controls.Add(Me.Label13)
        Me.pnPrincipal.Controls.Add(Me.cmbEstado)
        Me.pnPrincipal.Controls.Add(Me.TextEstado)
        Me.pnPrincipal.Controls.Add(Me.Label10)
        Me.pnPrincipal.Controls.Add(Me.TextFechae)
        Me.pnPrincipal.Controls.Add(Me.TextUsuario)
        Me.pnPrincipal.Controls.Add(Me.Label12)
        Me.pnPrincipal.Location = New System.Drawing.Point(12, 266)
        Me.pnPrincipal.Name = "pnPrincipal"
        Me.pnPrincipal.Size = New System.Drawing.Size(775, 44)
        Me.pnPrincipal.TabIndex = 18
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(15, 13)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 13)
        Me.Label13.TabIndex = 126
        Me.Label13.Text = "Estado:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEstado
        '
        Me.cmbEstado.BackColor = System.Drawing.Color.White
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.Location = New System.Drawing.Point(116, 13)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(212, 21)
        Me.cmbEstado.TabIndex = 1
        '
        'TextEstado
        '
        Me.TextEstado.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextEstado.BackColor = System.Drawing.Color.White
        Me.TextEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEstado.Location = New System.Drawing.Point(116, 13)
        Me.TextEstado.MaxLength = 15
        Me.TextEstado.Name = "TextEstado"
        Me.TextEstado.ReadOnly = True
        Me.TextEstado.Size = New System.Drawing.Size(212, 20)
        Me.TextEstado.TabIndex = 14
        Me.TextEstado.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(339, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(90, 13)
        Me.Label10.TabIndex = 129
        Me.Label10.Text = "Fecha de estado:"
        '
        'TextFechae
        '
        Me.TextFechae.BackColor = System.Drawing.Color.White
        Me.TextFechae.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextFechae.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechae.Location = New System.Drawing.Point(444, 13)
        Me.TextFechae.MaxLength = 4
        Me.TextFechae.Name = "TextFechae"
        Me.TextFechae.ReadOnly = True
        Me.TextFechae.Size = New System.Drawing.Size(96, 20)
        Me.TextFechae.TabIndex = 2
        '
        'TextUsuario
        '
        Me.TextUsuario.BackColor = System.Drawing.Color.White
        Me.TextUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextUsuario.Location = New System.Drawing.Point(637, 13)
        Me.TextUsuario.MaxLength = 4
        Me.TextUsuario.Name = "TextUsuario"
        Me.TextUsuario.ReadOnly = True
        Me.TextUsuario.Size = New System.Drawing.Size(121, 20)
        Me.TextUsuario.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(570, 13)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(46, 13)
        Me.Label12.TabIndex = 134
        Me.Label12.Text = "Usuario:"
        '
        'textDescAguinaldo
        '
        Me.textDescAguinaldo.BackColor = System.Drawing.Color.White
        Me.textDescAguinaldo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textDescAguinaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textDescAguinaldo.Location = New System.Drawing.Point(543, 176)
        Me.textDescAguinaldo.MaxLength = 11
        Me.textDescAguinaldo.Name = "textDescAguinaldo"
        Me.textDescAguinaldo.Size = New System.Drawing.Size(75, 20)
        Me.textDescAguinaldo.TabIndex = 13
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(424, 176)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(112, 13)
        Me.Label19.TabIndex = 138
        Me.Label19.Text = "Descuento Aguinaldo:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(613, 67)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 13)
        Me.Label1.TabIndex = 136
        Me.Label1.Text = "Fecha ingreso:"
        '
        'axFechaIngreso
        '
        Me.axFechaIngreso.DateMaxvalue1 = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.axFechaIngreso.DateMaxvalue2 = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.axFechaIngreso.DateMinvalue1 = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.axFechaIngreso.DateMinvalue2 = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.axFechaIngreso.Datevalue1 = New Date(2024, 1, 4, 0, 0, 0, 0)
        Me.axFechaIngreso.Datevalue2 = New Date(2024, 1, 4, 0, 0, 0, 0)
        Me.axFechaIngreso.EsModoConsulta = False
        Me.axFechaIngreso.Formato = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.axFechaIngreso.FuenteCalendario = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.axFechaIngreso.Location = New System.Drawing.Point(720, 63)
        Me.axFechaIngreso.Name = "axFechaIngreso"
        Me.axFechaIngreso.nombreCampo = "fecha"
        Me.axFechaIngreso.prefijo = "p1"
        Me.axFechaIngreso.Size = New System.Drawing.Size(300, 27)
        Me.axFechaIngreso.TabIndex = 5
        '
        'TextDescuento
        '
        Me.TextDescuento.BackColor = System.Drawing.Color.White
        Me.TextDescuento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDescuento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDescuento.Location = New System.Drawing.Point(893, 177)
        Me.TextDescuento.MaxLength = 11
        Me.TextDescuento.Name = "TextDescuento"
        Me.TextDescuento.Size = New System.Drawing.Size(75, 20)
        Me.TextDescuento.TabIndex = 15
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(824, 177)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(62, 13)
        Me.Label11.TabIndex = 132
        Me.Label11.Text = "Descuento:"
        '
        'gpSaldo
        '
        Me.gpSaldo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpSaldo.Controls.Add(Me.TextSaldo)
        Me.gpSaldo.Controls.Add(Me.btnSaldo)
        Me.gpSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpSaldo.Location = New System.Drawing.Point(960, 96)
        Me.gpSaldo.Name = "gpSaldo"
        Me.gpSaldo.Size = New System.Drawing.Size(142, 42)
        Me.gpSaldo.TabIndex = 10
        Me.gpSaldo.TabStop = False
        Me.gpSaldo.Text = "Saldo"
        '
        'TextSaldo
        '
        Me.TextSaldo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextSaldo.BackColor = System.Drawing.Color.White
        Me.TextSaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSaldo.Location = New System.Drawing.Point(6, 14)
        Me.TextSaldo.MaxLength = 15
        Me.TextSaldo.Name = "TextSaldo"
        Me.TextSaldo.Size = New System.Drawing.Size(82, 20)
        Me.TextSaldo.TabIndex = 118
        Me.TextSaldo.TabStop = False
        '
        'btnSaldo
        '
        Me.btnSaldo.BackColor = System.Drawing.SystemColors.Control
        Me.btnSaldo.ImageKey = "buscar1.png"
        Me.btnSaldo.ImageList = Me.ImageNuevos
        Me.btnSaldo.Location = New System.Drawing.Point(94, 8)
        Me.btnSaldo.Name = "btnSaldo"
        Me.btnSaldo.Size = New System.Drawing.Size(40, 30)
        Me.btnSaldo.TabIndex = 118
        Me.btnSaldo.UseVisualStyleBackColor = False
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
        'TextAño
        '
        Me.TextAño.BackColor = System.Drawing.Color.White
        Me.TextAño.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(275, 127)
        Me.TextAño.MaxLength = 9
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(62, 20)
        Me.TextAño.TabIndex = 7
        '
        'TextNoDocto
        '
        Me.TextNoDocto.BackColor = System.Drawing.Color.White
        Me.TextNoDocto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNoDocto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNoDocto.Location = New System.Drawing.Point(779, 124)
        Me.TextNoDocto.MaxLength = 9
        Me.TextNoDocto.Name = "TextNoDocto"
        Me.TextNoDocto.Size = New System.Drawing.Size(96, 20)
        Me.TextNoDocto.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(671, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(100, 13)
        Me.Label9.TabIndex = 24
        Me.Label9.Text = "Número documento"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(346, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(90, 13)
        Me.Label7.TabIndex = 22
        Me.Label7.Text = "Tipo  documento:"
        '
        'cmbTipoDoc
        '
        Me.cmbTipoDoc.BackColor = System.Drawing.Color.White
        Me.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDoc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDoc.FormattingEnabled = True
        Me.cmbTipoDoc.Items.AddRange(New Object() {"CHEQUE", "OTRO DOCUMENTO", ""})
        Me.cmbTipoDoc.Location = New System.Drawing.Point(452, 124)
        Me.cmbTipoDoc.Name = "cmbTipoDoc"
        Me.cmbTipoDoc.Size = New System.Drawing.Size(214, 21)
        Me.cmbTipoDoc.TabIndex = 8
        '
        'gpPrestamo
        '
        Me.gpPrestamo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpPrestamo.Controls.Add(Me.TextConxPrestamo)
        Me.gpPrestamo.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gpPrestamo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpPrestamo.Location = New System.Drawing.Point(991, 13)
        Me.gpPrestamo.Name = "gpPrestamo"
        Me.gpPrestamo.Size = New System.Drawing.Size(111, 39)
        Me.gpPrestamo.TabIndex = 3
        Me.gpPrestamo.TabStop = False
        Me.gpPrestamo.Text = "Número"
        '
        'TextConxPrestamo
        '
        Me.TextConxPrestamo.BackColor = System.Drawing.Color.White
        Me.TextConxPrestamo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConxPrestamo.ForeColor = System.Drawing.Color.Red
        Me.TextConxPrestamo.Location = New System.Drawing.Point(11, 15)
        Me.TextConxPrestamo.Name = "TextConxPrestamo"
        Me.TextConxPrestamo.ReadOnly = True
        Me.TextConxPrestamo.Size = New System.Drawing.Size(87, 20)
        Me.TextConxPrestamo.TabIndex = 0
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(236, 125)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Año:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 124)
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
        Me.cmbMes.Location = New System.Drawing.Point(111, 125)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(119, 21)
        Me.cmbMes.TabIndex = 6
        '
        'TextValor
        '
        Me.TextValor.BackColor = System.Drawing.Color.White
        Me.TextValor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextValor.Location = New System.Drawing.Point(110, 176)
        Me.TextValor.MaxLength = 11
        Me.TextValor.Name = "TextValor"
        Me.TextValor.Size = New System.Drawing.Size(96, 20)
        Me.TextValor.TabIndex = 11
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(9, 177)
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
        Me.gpContrato.Location = New System.Drawing.Point(755, 13)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(137, 40)
        Me.gpContrato.TabIndex = 2
        Me.gpContrato.TabStop = False
        Me.gpContrato.Text = "Contrato"
        '
        'btnContrato
        '
        Me.btnContrato.BackColor = System.Drawing.SystemColors.Control
        Me.btnContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContrato.ImageKey = "buscar2.png"
        Me.btnContrato.ImageList = Me.ImageNuevos
        Me.btnContrato.Location = New System.Drawing.Point(79, 7)
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
        Me.TextConxContrato.Location = New System.Drawing.Point(6, 15)
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
        Me.gpChofer.Controls.Add(Me.textConxEmpleado)
        Me.gpChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpChofer.Location = New System.Drawing.Point(6, 13)
        Me.gpChofer.Name = "gpChofer"
        Me.gpChofer.Size = New System.Drawing.Size(622, 45)
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
        Me.btnEmpleado.Location = New System.Drawing.Point(536, 10)
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
        Me.textNombreEmple.Location = New System.Drawing.Point(66, 19)
        Me.textNombreEmple.MaxLength = 40
        Me.textNombreEmple.Name = "textNombreEmple"
        Me.textNombreEmple.Size = New System.Drawing.Size(461, 20)
        Me.textNombreEmple.TabIndex = 2
        '
        'textConxEmpleado
        '
        Me.textConxEmpleado.BackColor = System.Drawing.Color.White
        Me.textConxEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textConxEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textConxEmpleado.Location = New System.Drawing.Point(6, 19)
        Me.textConxEmpleado.MaxLength = 6
        Me.textConxEmpleado.Name = "textConxEmpleado"
        Me.textConxEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textConxEmpleado.TabIndex = 1
        '
        'TextObservaciones
        '
        Me.TextObservaciones.BackColor = System.Drawing.Color.White
        Me.TextObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextObservaciones.Location = New System.Drawing.Point(105, 217)
        Me.TextObservaciones.MaxLength = 75
        Me.TextObservaciones.Name = "TextObservaciones"
        Me.TextObservaciones.Size = New System.Drawing.Size(641, 20)
        Me.TextObservaciones.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(9, 217)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Observaciones:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 67)
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
        Me.cmbTipo.Location = New System.Drawing.Point(111, 64)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(387, 21)
        Me.cmbTipo.TabIndex = 4
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'btnSig
        '
        Me.btnSig.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSig.BackColor = System.Drawing.SystemColors.Control
        Me.btnSig.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSig.ImageKey = "siguiente.png"
        Me.btnSig.ImageList = Me.ImageNuevos
        Me.btnSig.Location = New System.Drawing.Point(1047, 5)
        Me.btnSig.Name = "btnSig"
        Me.btnSig.Size = New System.Drawing.Size(80, 30)
        Me.btnSig.TabIndex = 7
        Me.btnSig.TabStop = False
        Me.btnSig.Text = "Siguiente"
        Me.btnSig.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnSig, "Siguiente Registro")
        Me.btnSig.UseVisualStyleBackColor = False
        '
        'btnAtr
        '
        Me.btnAtr.BackColor = System.Drawing.SystemColors.Control
        Me.btnAtr.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAtr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAtr.ImageKey = "anterior.png"
        Me.btnAtr.ImageList = Me.ImageNuevos
        Me.btnAtr.Location = New System.Drawing.Point(10, 4)
        Me.btnAtr.Name = "btnAtr"
        Me.btnAtr.Size = New System.Drawing.Size(80, 30)
        Me.btnAtr.TabIndex = 1
        Me.btnAtr.TabStop = False
        Me.btnAtr.Text = "Anterior"
        Me.btnAtr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAtr, "Registro anterior")
        Me.btnAtr.UseVisualStyleBackColor = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.ImageKey = "buscar2.png"
        Me.btnBuscar.ImageList = Me.ImageNuevos
        Me.btnBuscar.Location = New System.Drawing.Point(881, 5)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(80, 30)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Buscar registro")
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(96, 4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 2
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
        Me.btnGuardar.Location = New System.Drawing.Point(964, 5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 30)
        Me.btnGuardar.TabIndex = 5
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Guardar Registro")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnCtaCorr
        '
        Me.btnCtaCorr.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnCtaCorr.BackColor = System.Drawing.SystemColors.Control
        Me.btnCtaCorr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCtaCorr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCtaCorr.ImageKey = "detalle.png"
        Me.btnCtaCorr.ImageList = Me.ImageNuevos
        Me.btnCtaCorr.Location = New System.Drawing.Point(516, 4)
        Me.btnCtaCorr.Name = "btnCtaCorr"
        Me.btnCtaCorr.Size = New System.Drawing.Size(80, 30)
        Me.btnCtaCorr.TabIndex = 3
        Me.btnCtaCorr.Text = "Cuenta C"
        Me.btnCtaCorr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCtaCorr, "Buscar registro")
        Me.btnCtaCorr.UseVisualStyleBackColor = False
        '
        'btnAgregarDet
        '
        Me.btnAgregarDet.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregarDet.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarDet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarDet.ImageKey = "mas.png"
        Me.btnAgregarDet.ImageList = Me.ImageNuevos
        Me.btnAgregarDet.Location = New System.Drawing.Point(381, 68)
        Me.btnAgregarDet.Name = "btnAgregarDet"
        Me.btnAgregarDet.Size = New System.Drawing.Size(80, 30)
        Me.btnAgregarDet.TabIndex = 70
        Me.btnAgregarDet.Text = "Agregar"
        Me.btnAgregarDet.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAgregarDet, "Agregar registro")
        Me.btnAgregarDet.UseVisualStyleBackColor = False
        '
        'pnEncabezado
        '
        Me.pnEncabezado.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnEncabezado.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.pnEncabezado.Location = New System.Drawing.Point(0, 0)
        Me.pnEncabezado.Name = "pnEncabezado"
        Me.pnEncabezado.Size = New System.Drawing.Size(1130, 57)
        Me.pnEncabezado.TabIndex = 70
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnSig)
        Me.Panel2.Controls.Add(Me.btnCtaCorr)
        Me.Panel2.Controls.Add(Me.btnBuscar)
        Me.Panel2.Controls.Add(Me.btnGuardar)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.btnAtr)
        Me.Panel2.Location = New System.Drawing.Point(0, 564)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1130, 41)
        Me.Panel2.TabIndex = 2
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPrincipal)
        Me.TabControl1.Controls.Add(Me.TabDetalle)
        Me.TabControl1.Controls.Add(Me.TabConsulta)
        Me.TabControl1.Location = New System.Drawing.Point(0, 63)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1130, 500)
        Me.TabControl1.TabIndex = 1
        '
        'TabPrincipal
        '
        Me.TabPrincipal.Controls.Add(Me.gpDatos)
        Me.TabPrincipal.Location = New System.Drawing.Point(4, 22)
        Me.TabPrincipal.Name = "TabPrincipal"
        Me.TabPrincipal.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPrincipal.Size = New System.Drawing.Size(1122, 474)
        Me.TabPrincipal.TabIndex = 0
        Me.TabPrincipal.Text = "Prestamo"
        Me.TabPrincipal.UseVisualStyleBackColor = True
        '
        'TabDetalle
        '
        Me.TabDetalle.Controls.Add(Me.txtAbonos)
        Me.TabDetalle.Controls.Add(Me.txtCargos)
        Me.TabDetalle.Controls.Add(Me.Label22)
        Me.TabDetalle.Controls.Add(Me.Label21)
        Me.TabDetalle.Controls.Add(Me.dgvDatos)
        Me.TabDetalle.Controls.Add(Me.Panel3)
        Me.TabDetalle.Location = New System.Drawing.Point(4, 22)
        Me.TabDetalle.Name = "TabDetalle"
        Me.TabDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDetalle.Size = New System.Drawing.Size(1122, 474)
        Me.TabDetalle.TabIndex = 1
        Me.TabDetalle.Text = "Detalle Prestamo"
        Me.TabDetalle.UseVisualStyleBackColor = True
        '
        'txtAbonos
        '
        Me.txtAbonos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAbonos.Location = New System.Drawing.Point(997, 451)
        Me.txtAbonos.Name = "txtAbonos"
        Me.txtAbonos.ReadOnly = True
        Me.txtAbonos.Size = New System.Drawing.Size(117, 20)
        Me.txtAbonos.TabIndex = 77
        '
        'txtCargos
        '
        Me.txtCargos.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtCargos.Location = New System.Drawing.Point(810, 451)
        Me.txtCargos.Name = "txtCargos"
        Me.txtCargos.ReadOnly = True
        Me.txtCargos.Size = New System.Drawing.Size(117, 20)
        Me.txtCargos.TabIndex = 76
        '
        'Label22
        '
        Me.Label22.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(948, 453)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(43, 13)
        Me.Label22.TabIndex = 75
        Me.Label22.Text = "Abonos"
        '
        'Label21
        '
        Me.Label21.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(747, 453)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 13)
        Me.Label21.TabIndex = 74
        Me.Label21.Text = "Cargos"
        '
        'dgvDatos
        '
        Me.dgvDatos.AllowUserToAddRows = False
        Me.dgvDatos.AllowUserToDeleteRows = False
        Me.dgvDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDatos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDatos.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvDatos.Location = New System.Drawing.Point(3, 122)
        Me.dgvDatos.Name = "dgvDatos"
        Me.dgvDatos.ReadOnly = True
        Me.dgvDatos.Size = New System.Drawing.Size(1111, 322)
        Me.dgvDatos.TabIndex = 2
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel3.ContextMenuStrip = Me.ctxPrincipalCuenta
        Me.Panel3.Controls.Add(Me.txtAñoDet)
        Me.Panel3.Controls.Add(Me.Label18)
        Me.Panel3.Controls.Add(Me.lblestado)
        Me.Panel3.Controls.Add(Me.Label17)
        Me.Panel3.Controls.Add(Me.txtValorDet)
        Me.Panel3.Controls.Add(Me.btnAgregarDet)
        Me.Panel3.Controls.Add(Me.GroupBox1)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.cmbMesDet)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.cmbTipNom)
        Me.Panel3.Location = New System.Drawing.Point(3, 6)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1113, 110)
        Me.Panel3.TabIndex = 1
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.ForeColor = System.Drawing.Color.White
        Me.Label18.Location = New System.Drawing.Point(691, 23)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(43, 13)
        Me.Label18.TabIndex = 74
        Me.Label18.Text = "Estado:"
        '
        'lblestado
        '
        Me.lblestado.AutoSize = True
        Me.lblestado.ForeColor = System.Drawing.Color.White
        Me.lblestado.Location = New System.Drawing.Point(735, 23)
        Me.lblestado.Name = "lblestado"
        Me.lblestado.Size = New System.Drawing.Size(0, 13)
        Me.lblestado.TabIndex = 73
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(243, 74)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(34, 13)
        Me.Label17.TabIndex = 72
        Me.Label17.Text = "Valor:"
        '
        'txtValorDet
        '
        Me.txtValorDet.Location = New System.Drawing.Point(283, 74)
        Me.txtValorDet.MaxLength = 12
        Me.txtValorDet.Name = "txtValorDet"
        Me.txtValorDet.Size = New System.Drawing.Size(92, 20)
        Me.txtValorDet.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbCargo)
        Me.GroupBox1.Controls.Add(Me.rbAbono)
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(16, 55)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(207, 45)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo"
        '
        'rbCargo
        '
        Me.rbCargo.AutoSize = True
        Me.rbCargo.ForeColor = System.Drawing.Color.White
        Me.rbCargo.Location = New System.Drawing.Point(78, 22)
        Me.rbCargo.Name = "rbCargo"
        Me.rbCargo.Size = New System.Drawing.Size(53, 17)
        Me.rbCargo.TabIndex = 1
        Me.rbCargo.Text = "Cargo"
        Me.rbCargo.UseVisualStyleBackColor = True
        '
        'rbAbono
        '
        Me.rbAbono.AutoSize = True
        Me.rbAbono.Checked = True
        Me.rbAbono.ForeColor = System.Drawing.Color.White
        Me.rbAbono.Location = New System.Drawing.Point(16, 20)
        Me.rbAbono.Name = "rbAbono"
        Me.rbAbono.Size = New System.Drawing.Size(56, 17)
        Me.rbAbono.TabIndex = 0
        Me.rbAbono.TabStop = True
        Me.rbAbono.Text = "Abono"
        Me.rbAbono.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(549, 23)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(29, 13)
        Me.Label16.TabIndex = 5
        Me.Label16.Text = "Año:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.ForeColor = System.Drawing.Color.White
        Me.Label15.Location = New System.Drawing.Point(368, 23)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(30, 13)
        Me.Label15.TabIndex = 3
        Me.Label15.Text = "Mes:"
        '
        'cmbMesDet
        '
        Me.cmbMesDet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMesDet.FormattingEnabled = True
        Me.cmbMesDet.Location = New System.Drawing.Point(409, 23)
        Me.cmbMesDet.Name = "cmbMesDet"
        Me.cmbMesDet.Size = New System.Drawing.Size(121, 21)
        Me.cmbMesDet.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.ForeColor = System.Drawing.Color.White
        Me.Label14.Location = New System.Drawing.Point(16, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(70, 13)
        Me.Label14.TabIndex = 1
        Me.Label14.Text = "Tipo Nomina:"
        '
        'cmbTipNom
        '
        Me.cmbTipNom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipNom.FormattingEnabled = True
        Me.cmbTipNom.Location = New System.Drawing.Point(92, 23)
        Me.cmbTipNom.Name = "cmbTipNom"
        Me.cmbTipNom.Size = New System.Drawing.Size(267, 21)
        Me.cmbTipNom.TabIndex = 0
        '
        'TabConsulta
        '
        Me.TabConsulta.Controls.Add(Me.dgvConsulta)
        Me.TabConsulta.Location = New System.Drawing.Point(4, 22)
        Me.TabConsulta.Name = "TabConsulta"
        Me.TabConsulta.Size = New System.Drawing.Size(1122, 474)
        Me.TabConsulta.TabIndex = 2
        Me.TabConsulta.Text = "Detalle de consulta"
        Me.TabConsulta.UseVisualStyleBackColor = True
        '
        'dgvConsulta
        '
        Me.dgvConsulta.AllowUserToAddRows = False
        Me.dgvConsulta.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.SandyBrown
        Me.dgvConsulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvConsulta.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvConsulta.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConsulta.ContextMenuStrip = Me.ctxDetalle
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvConsulta.DefaultCellStyle = DataGridViewCellStyle8
        Me.dgvConsulta.Location = New System.Drawing.Point(5, 3)
        Me.dgvConsulta.Name = "dgvConsulta"
        Me.dgvConsulta.ReadOnly = True
        Me.dgvConsulta.Size = New System.Drawing.Size(1113, 468)
        Me.dgvConsulta.TabIndex = 74
        '
        'ctxDetalle
        '
        Me.ctxDetalle.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuModificarDet})
        Me.ctxDetalle.Name = "ctxDetalle"
        Me.ctxDetalle.Size = New System.Drawing.Size(126, 26)
        '
        'mnuModificarDet
        '
        Me.mnuModificarDet.Name = "mnuModificarDet"
        Me.mnuModificarDet.Size = New System.Drawing.Size(125, 22)
        Me.mnuModificarDet.Text = "Modificar"
        '
        'ctxPrincipalCuenta
        '
        Me.ctxPrincipalCuenta.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModCuota})
        Me.ctxPrincipalCuenta.Name = "ctxMenu"
        Me.ctxPrincipalCuenta.Size = New System.Drawing.Size(145, 26)
        '
        'ctxModCuota
        '
        Me.ctxModCuota.Image = Global.NOMINA.My.Resources.Resources.edit1
        Me.ctxModCuota.Name = "ctxModCuota"
        Me.ctxModCuota.Size = New System.Drawing.Size(144, 22)
        Me.ctxModCuota.Text = "Modificación"
        '
        'txtAñoDet
        '
        Me.txtAñoDet.Location = New System.Drawing.Point(598, 23)
        Me.txtAñoDet.MaxLength = 4
        Me.txtAñoDet.Name = "txtAñoDet"
        Me.txtAñoDet.Size = New System.Drawing.Size(55, 20)
        Me.txtAñoDet.TabIndex = 3
        '
        'frmConsPrestamos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.gpEmpresa)
        Me.Controls.Add(Me.pnEncabezado)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmConsPrestamos"
        Me.Text = "Mantenimiento de Descuentos Fijos"
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        Me.gpDatos.ResumeLayout(False)
        Me.gpDatos.PerformLayout()
        Me.ctxPrincipal.ResumeLayout(False)
        Me.pnNoCuotas.ResumeLayout(False)
        Me.pnNoCuotas.PerformLayout()
        Me.pnPrincipal.ResumeLayout(False)
        Me.pnPrincipal.PerformLayout()
        Me.gpSaldo.ResumeLayout(False)
        Me.gpSaldo.PerformLayout()
        Me.gpPrestamo.ResumeLayout(False)
        Me.gpPrestamo.PerformLayout()
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        Me.gpChofer.ResumeLayout(False)
        Me.gpChofer.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPrincipal.ResumeLayout(False)
        Me.TabDetalle.ResumeLayout(False)
        Me.TabDetalle.PerformLayout()
        CType(Me.dgvDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabConsulta.ResumeLayout(False)
        CType(Me.dgvConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxDetalle.ResumeLayout(False)
        Me.ctxPrincipalCuenta.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents gpDatos As System.Windows.Forms.Panel
    Friend WithEvents gpPrestamo As System.Windows.Forms.GroupBox
    Friend WithEvents TextConxPrestamo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents TextObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpChofer As System.Windows.Forms.GroupBox
    Friend WithEvents textConxEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents btnContrato As System.Windows.Forms.Button
    Friend WithEvents gpContrato As System.Windows.Forms.GroupBox
    Friend WithEvents TextConxContrato As System.Windows.Forms.TextBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents TextValor As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoDoc As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents txtMeses As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextNoDocto As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextAño As System.Windows.Forms.TextBox
    Friend WithEvents TextFechae As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextEstado As System.Windows.Forms.TextBox
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnSig As System.Windows.Forms.Button
    Friend WithEvents btnAtr As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents gpSaldo As System.Windows.Forms.GroupBox
    Friend WithEvents TextSaldo As System.Windows.Forms.TextBox
    Friend WithEvents btnSaldo As System.Windows.Forms.Button
    Friend WithEvents ctxPrincipal As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxAnulacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextDescuento As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnCtaCorr As System.Windows.Forms.Button
    Friend WithEvents ctxModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxReactivacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents pnEncabezado As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents axFechaIngreso As axFecha.axDateDB
    Friend WithEvents Label1 As Label
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPrincipal As TabPage
    Friend WithEvents TabDetalle As TabPage
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnAgregarDet As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbCargo As RadioButton
    Friend WithEvents rbAbono As RadioButton
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents cmbMesDet As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents cmbTipNom As ComboBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtValorDet As TextBox
    Friend WithEvents lblestado As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents ctxDetalle As ContextMenuStrip
    Friend WithEvents mnuModificarDet As ToolStripMenuItem
    Friend WithEvents pnPrincipal As Panel
    Friend WithEvents textDescAguinaldo As TextBox
    Friend WithEvents Label19 As Label
    Friend WithEvents textDescBono As TextBox
    Friend WithEvents Label20 As Label
    Friend WithEvents btnDescMensual As Button
    Friend WithEvents TabConsulta As TabPage
    Friend WithEvents dgvConsulta As DataGridView
    Friend WithEvents pnNoCuotas As Panel
    Friend WithEvents dpFechaI As DateTimePicker
    Friend WithEvents dgvDatos As DataGridView
    Friend WithEvents txtAbonos As TextBox
    Friend WithEvents txtCargos As TextBox
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents ctxPrincipalCuenta As ContextMenuStrip
    Friend WithEvents ctxModCuota As ToolStripMenuItem
    Friend WithEvents txtAñoDet As TextBox
End Class
