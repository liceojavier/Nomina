<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmIndemnizacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIndemnizacion))
        Me.busqEmpleado = New ControlesERP.controlBusquedaEmpleado()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.btnGenIndem = New System.Windows.Forms.Button()
        Me.btnGenVaca = New System.Windows.Forms.Button()
        Me.btnGenBono = New System.Windows.Forms.Button()
        Me.btnAguinaldo = New System.Windows.Forms.Button()
        Me.btnMarcarI = New System.Windows.Forms.Button()
        Me.btnDescmarcaI = New System.Windows.Forms.Button()
        Me.btnDesmarcaV = New System.Windows.Forms.Button()
        Me.btnMarcaV = New System.Windows.Forms.Button()
        Me.btnDescmarcaB = New System.Windows.Forms.Button()
        Me.btnMarcaB = New System.Windows.Forms.Button()
        Me.btnDescmarcaA = New System.Windows.Forms.Button()
        Me.btnMarcaA = New System.Windows.Forms.Button()
        Me.btnGenReporte = New System.Windows.Forms.Button()
        Me.btnSalarioMensualFalt = New System.Windows.Forms.Button()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.TabControlP = New System.Windows.Forms.TabControl()
        Me.TPIndem = New System.Windows.Forms.TabPage()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.txtSueldoProIndem = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.dgvIndem = New System.Windows.Forms.DataGridView()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.txtValorIndem = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtTotalDiasIndem = New System.Windows.Forms.TextBox()
        Me.pnIndem = New System.Windows.Forms.Panel()
        Me.cbIndemnizacion = New System.Windows.Forms.CheckBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TPVaca = New System.Windows.Forms.TabPage()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtValDiaPromVac = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.txtSueldoProVac = New System.Windows.Forms.TextBox()
        Me.dgvVacaciones = New System.Windows.Forms.DataGridView()
        Me.txtValorVacaciones = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.nudVacaNoTo = New System.Windows.Forms.NumericUpDown()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dpFechaIVaca = New System.Windows.Forms.DateTimePicker()
        Me.txtNoDiasVacaciones = New System.Windows.Forms.TextBox()
        Me.txtTotalDiasVac = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TPBono14 = New System.Windows.Forms.TabPage()
        Me.rbCalculoBono2 = New System.Windows.Forms.RadioButton()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.txtSueldoProBon = New System.Windows.Forms.TextBox()
        Me.rbCalculoBono1 = New System.Windows.Forms.RadioButton()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.txtTotalDiasBono = New System.Windows.Forms.TextBox()
        Me.dgvBono14 = New System.Windows.Forms.DataGridView()
        Me.txtValorBono14 = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.TPAguinaldo = New System.Windows.Forms.TabPage()
        Me.rbCalculoAgui2 = New System.Windows.Forms.RadioButton()
        Me.rbCalculoAgui1 = New System.Windows.Forms.RadioButton()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtSueldoProAgu = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.dgvAguinaldo = New System.Windows.Forms.DataGridView()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtValorAguinaldo = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtTotalDiasAguinaldo = New System.Windows.Forms.TextBox()
        Me.TPSalario = New System.Windows.Forms.TabPage()
        Me.TLPPri = New System.Windows.Forms.TableLayoutPanel()
        Me.dgvDescuentos = New System.Windows.Forms.DataGridView()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.txtTotalDescuentos = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.txtTotalIngresos = New System.Windows.Forms.TextBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.dgvIngresos = New System.Windows.Forms.DataGridView()
        Me.nudDiasSalario = New System.Windows.Forms.NumericUpDown()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.txtSueldoDiarioSal = New System.Windows.Forms.TextBox()
        Me.txtSueldoSal = New System.Windows.Forms.TextBox()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.dpFechaHoy = New System.Windows.Forms.DateTimePicker()
        Me.txtMotivo = New System.Windows.Forms.TextBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtTotal = New System.Windows.Forms.TextBox()
        Me.txtDiasLaborados = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSueldo = New System.Windows.Forms.TextBox()
        Me.txtPuesto = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtAño = New System.Windows.Forms.TextBox()
        Me.txtMes = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.gpContrato = New System.Windows.Forms.GroupBox()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.txtContrato = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dpFechaF = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtFechaI = New System.Windows.Forms.TextBox()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.dgvPrestamos = New System.Windows.Forms.DataGridView()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlP.SuspendLayout()
        Me.TPIndem.SuspendLayout()
        CType(Me.dgvIndem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnIndem.SuspendLayout()
        Me.TPVaca.SuspendLayout()
        CType(Me.dgvVacaciones, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudVacaNoTo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPBono14.SuspendLayout()
        CType(Me.dgvBono14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPAguinaldo.SuspendLayout()
        CType(Me.dgvAguinaldo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPSalario.SuspendLayout()
        Me.TLPPri.SuspendLayout()
        CType(Me.dgvDescuentos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel5.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvIngresos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudDiasSalario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.gpContrato.SuspendLayout()
        CType(Me.dgvPrestamos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'busqEmpleado
        '
        Me.busqEmpleado.activo = False
        Me.busqEmpleado.Contrato = 0
        Me.busqEmpleado.Empleado = 0
        Me.busqEmpleado.id_empresa = CType(0, Short)
        Me.busqEmpleado.Location = New System.Drawing.Point(75, 24)
        Me.busqEmpleado.Name = "busqEmpleado"
        Me.busqEmpleado.Nombre = "0"
        Me.busqEmpleado.Size = New System.Drawing.Size(387, 23)
        Me.busqEmpleado.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Empleado"
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
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(762, 18)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(102, 30)
        Me.btnLimpiar.TabIndex = 90
        Me.btnLimpiar.Text = "Limpiar"
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "actualizar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(762, 138)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(102, 30)
        Me.btnEjecutar.TabIndex = 10
        Me.btnEjecutar.Text = "Generar"
        Me.ToolTip1.SetToolTip(Me.btnEjecutar, "Generar el proceso")
        Me.btnEjecutar.UseVisualStyleBackColor = False
        '
        'btnGenIndem
        '
        Me.btnGenIndem.BackColor = System.Drawing.SystemColors.Control
        Me.btnGenIndem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenIndem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenIndem.ImageKey = "actualizar.png"
        Me.btnGenIndem.ImageList = Me.ImageNuevos
        Me.btnGenIndem.Location = New System.Drawing.Point(491, 161)
        Me.btnGenIndem.Name = "btnGenIndem"
        Me.btnGenIndem.Size = New System.Drawing.Size(102, 51)
        Me.btnGenIndem.TabIndex = 6
        Me.btnGenIndem.Text = "Generar indemnización"
        Me.btnGenIndem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGenIndem, "Generar el proceso")
        Me.btnGenIndem.UseVisualStyleBackColor = False
        '
        'btnGenVaca
        '
        Me.btnGenVaca.BackColor = System.Drawing.SystemColors.Control
        Me.btnGenVaca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenVaca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenVaca.ImageKey = "actualizar.png"
        Me.btnGenVaca.ImageList = Me.ImageNuevos
        Me.btnGenVaca.Location = New System.Drawing.Point(491, 186)
        Me.btnGenVaca.Name = "btnGenVaca"
        Me.btnGenVaca.Size = New System.Drawing.Size(102, 51)
        Me.btnGenVaca.TabIndex = 9
        Me.btnGenVaca.Text = "Generar vacaciones"
        Me.btnGenVaca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGenVaca, "Generar el proceso")
        Me.btnGenVaca.UseVisualStyleBackColor = False
        '
        'btnGenBono
        '
        Me.btnGenBono.BackColor = System.Drawing.SystemColors.Control
        Me.btnGenBono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenBono.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenBono.ImageKey = "actualizar.png"
        Me.btnGenBono.ImageList = Me.ImageNuevos
        Me.btnGenBono.Location = New System.Drawing.Point(495, 224)
        Me.btnGenBono.Name = "btnGenBono"
        Me.btnGenBono.Size = New System.Drawing.Size(96, 49)
        Me.btnGenBono.TabIndex = 5
        Me.btnGenBono.Text = "Generar bono14"
        Me.btnGenBono.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGenBono, "Generar el proceso")
        Me.btnGenBono.UseVisualStyleBackColor = False
        '
        'btnAguinaldo
        '
        Me.btnAguinaldo.BackColor = System.Drawing.SystemColors.Control
        Me.btnAguinaldo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAguinaldo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAguinaldo.ImageKey = "actualizar.png"
        Me.btnAguinaldo.ImageList = Me.ImageNuevos
        Me.btnAguinaldo.Location = New System.Drawing.Point(498, 207)
        Me.btnAguinaldo.Name = "btnAguinaldo"
        Me.btnAguinaldo.Size = New System.Drawing.Size(96, 51)
        Me.btnAguinaldo.TabIndex = 11
        Me.btnAguinaldo.Text = "Generar aguinaldo"
        Me.btnAguinaldo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAguinaldo, "Generar el proceso")
        Me.btnAguinaldo.UseVisualStyleBackColor = False
        '
        'btnMarcarI
        '
        Me.btnMarcarI.BackColor = System.Drawing.SystemColors.Control
        Me.btnMarcarI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMarcarI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMarcarI.ImageKey = "anterior.png"
        Me.btnMarcarI.Location = New System.Drawing.Point(491, 77)
        Me.btnMarcarI.Name = "btnMarcarI"
        Me.btnMarcarI.Size = New System.Drawing.Size(102, 22)
        Me.btnMarcarI.TabIndex = 4
        Me.btnMarcarI.Text = "Marcar todo"
        Me.ToolTip1.SetToolTip(Me.btnMarcarI, "Marcar todo")
        Me.btnMarcarI.UseVisualStyleBackColor = False
        '
        'btnDescmarcaI
        '
        Me.btnDescmarcaI.BackColor = System.Drawing.SystemColors.Control
        Me.btnDescmarcaI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDescmarcaI.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDescmarcaI.ImageKey = "anterior.png"
        Me.btnDescmarcaI.Location = New System.Drawing.Point(490, 109)
        Me.btnDescmarcaI.Name = "btnDescmarcaI"
        Me.btnDescmarcaI.Size = New System.Drawing.Size(102, 22)
        Me.btnDescmarcaI.TabIndex = 5
        Me.btnDescmarcaI.Text = "Desmarcar todo"
        Me.ToolTip1.SetToolTip(Me.btnDescmarcaI, "Marcar todo")
        Me.btnDescmarcaI.UseVisualStyleBackColor = False
        '
        'btnDesmarcaV
        '
        Me.btnDesmarcaV.BackColor = System.Drawing.SystemColors.Control
        Me.btnDesmarcaV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesmarcaV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDesmarcaV.ImageKey = "anterior.png"
        Me.btnDesmarcaV.Location = New System.Drawing.Point(490, 159)
        Me.btnDesmarcaV.Name = "btnDesmarcaV"
        Me.btnDesmarcaV.Size = New System.Drawing.Size(102, 22)
        Me.btnDesmarcaV.TabIndex = 8
        Me.btnDesmarcaV.Text = "Desmarcar todo"
        Me.ToolTip1.SetToolTip(Me.btnDesmarcaV, "Marcar todo")
        Me.btnDesmarcaV.UseVisualStyleBackColor = False
        '
        'btnMarcaV
        '
        Me.btnMarcaV.BackColor = System.Drawing.SystemColors.Control
        Me.btnMarcaV.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMarcaV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMarcaV.ImageKey = "anterior.png"
        Me.btnMarcaV.Location = New System.Drawing.Point(491, 127)
        Me.btnMarcaV.Name = "btnMarcaV"
        Me.btnMarcaV.Size = New System.Drawing.Size(102, 22)
        Me.btnMarcaV.TabIndex = 7
        Me.btnMarcaV.Text = "Marcar todo"
        Me.ToolTip1.SetToolTip(Me.btnMarcaV, "Marcar todo")
        Me.btnMarcaV.UseVisualStyleBackColor = False
        '
        'btnDescmarcaB
        '
        Me.btnDescmarcaB.BackColor = System.Drawing.SystemColors.Control
        Me.btnDescmarcaB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDescmarcaB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDescmarcaB.ImageKey = "anterior.png"
        Me.btnDescmarcaB.Location = New System.Drawing.Point(489, 114)
        Me.btnDescmarcaB.Name = "btnDescmarcaB"
        Me.btnDescmarcaB.Size = New System.Drawing.Size(102, 22)
        Me.btnDescmarcaB.TabIndex = 4
        Me.btnDescmarcaB.Text = "Desmarcar todo"
        Me.ToolTip1.SetToolTip(Me.btnDescmarcaB, "Marcar todo")
        Me.btnDescmarcaB.UseVisualStyleBackColor = False
        '
        'btnMarcaB
        '
        Me.btnMarcaB.BackColor = System.Drawing.SystemColors.Control
        Me.btnMarcaB.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMarcaB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMarcaB.ImageKey = "anterior.png"
        Me.btnMarcaB.Location = New System.Drawing.Point(490, 82)
        Me.btnMarcaB.Name = "btnMarcaB"
        Me.btnMarcaB.Size = New System.Drawing.Size(102, 22)
        Me.btnMarcaB.TabIndex = 3
        Me.btnMarcaB.Text = "Marcar todo"
        Me.ToolTip1.SetToolTip(Me.btnMarcaB, "Marcar todo")
        Me.btnMarcaB.UseVisualStyleBackColor = False
        '
        'btnDescmarcaA
        '
        Me.btnDescmarcaA.BackColor = System.Drawing.SystemColors.Control
        Me.btnDescmarcaA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDescmarcaA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDescmarcaA.ImageKey = "anterior.png"
        Me.btnDescmarcaA.Location = New System.Drawing.Point(498, 114)
        Me.btnDescmarcaA.Name = "btnDescmarcaA"
        Me.btnDescmarcaA.Size = New System.Drawing.Size(102, 22)
        Me.btnDescmarcaA.TabIndex = 10
        Me.btnDescmarcaA.Text = "Desmarcar todo"
        Me.ToolTip1.SetToolTip(Me.btnDescmarcaA, "Marcar todo")
        Me.btnDescmarcaA.UseVisualStyleBackColor = False
        '
        'btnMarcaA
        '
        Me.btnMarcaA.BackColor = System.Drawing.SystemColors.Control
        Me.btnMarcaA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMarcaA.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnMarcaA.ImageKey = "anterior.png"
        Me.btnMarcaA.Location = New System.Drawing.Point(499, 82)
        Me.btnMarcaA.Name = "btnMarcaA"
        Me.btnMarcaA.Size = New System.Drawing.Size(102, 22)
        Me.btnMarcaA.TabIndex = 9
        Me.btnMarcaA.Text = "Marcar todo"
        Me.ToolTip1.SetToolTip(Me.btnMarcaA, "Marcar todo")
        Me.btnMarcaA.UseVisualStyleBackColor = False
        '
        'btnGenReporte
        '
        Me.btnGenReporte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGenReporte.BackColor = System.Drawing.SystemColors.Control
        Me.btnGenReporte.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenReporte.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenReporte.ImageKey = "impresora2.png"
        Me.btnGenReporte.ImageList = Me.ImageNuevos
        Me.btnGenReporte.Location = New System.Drawing.Point(431, 553)
        Me.btnGenReporte.Name = "btnGenReporte"
        Me.btnGenReporte.Size = New System.Drawing.Size(120, 30)
        Me.btnGenReporte.TabIndex = 13
        Me.btnGenReporte.Text = "Imprimir finiquito"
        Me.btnGenReporte.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGenReporte, "Imprimir finiquito")
        Me.btnGenReporte.UseVisualStyleBackColor = False
        '
        'btnSalarioMensualFalt
        '
        Me.btnSalarioMensualFalt.BackColor = System.Drawing.SystemColors.Control
        Me.btnSalarioMensualFalt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSalarioMensualFalt.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSalarioMensualFalt.ImageKey = "actualizar.png"
        Me.btnSalarioMensualFalt.ImageList = Me.ImageNuevos
        Me.btnSalarioMensualFalt.Location = New System.Drawing.Point(224, 70)
        Me.btnSalarioMensualFalt.Name = "btnSalarioMensualFalt"
        Me.btnSalarioMensualFalt.Size = New System.Drawing.Size(115, 51)
        Me.btnSalarioMensualFalt.TabIndex = 191
        Me.btnSalarioMensualFalt.Text = "Generar pago mensual faltante"
        Me.btnSalarioMensualFalt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnSalarioMensualFalt, "Generar el proceso")
        Me.btnSalarioMensualFalt.UseVisualStyleBackColor = False
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'TabControlP
        '
        Me.TabControlP.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TabControlP.Controls.Add(Me.TPIndem)
        Me.TabControlP.Controls.Add(Me.TPVaca)
        Me.TabControlP.Controls.Add(Me.TPBono14)
        Me.TabControlP.Controls.Add(Me.TPAguinaldo)
        Me.TabControlP.Controls.Add(Me.TPSalario)
        Me.TabControlP.HotTrack = True
        Me.ep1.SetIconAlignment(Me.TabControlP, System.Windows.Forms.ErrorIconAlignment.TopLeft)
        Me.TabControlP.ItemSize = New System.Drawing.Size(80, 18)
        Me.TabControlP.Location = New System.Drawing.Point(20, 191)
        Me.TabControlP.Name = "TabControlP"
        Me.TabControlP.SelectedIndex = 0
        Me.TabControlP.Size = New System.Drawing.Size(740, 352)
        Me.TabControlP.TabIndex = 11
        '
        'TPIndem
        '
        Me.TPIndem.Controls.Add(Me.Label25)
        Me.TPIndem.Controls.Add(Me.txtSueldoProIndem)
        Me.TPIndem.Controls.Add(Me.btnDescmarcaI)
        Me.TPIndem.Controls.Add(Me.btnMarcarI)
        Me.TPIndem.Controls.Add(Me.Label22)
        Me.TPIndem.Controls.Add(Me.btnGenIndem)
        Me.TPIndem.Controls.Add(Me.dgvIndem)
        Me.TPIndem.Controls.Add(Me.Label23)
        Me.TPIndem.Controls.Add(Me.txtValorIndem)
        Me.TPIndem.Controls.Add(Me.Label13)
        Me.TPIndem.Controls.Add(Me.txtTotalDiasIndem)
        Me.TPIndem.Controls.Add(Me.pnIndem)
        Me.TPIndem.Location = New System.Drawing.Point(4, 22)
        Me.TPIndem.Name = "TPIndem"
        Me.TPIndem.Padding = New System.Windows.Forms.Padding(3)
        Me.TPIndem.Size = New System.Drawing.Size(732, 326)
        Me.TPIndem.TabIndex = 0
        Me.TPIndem.Text = "Indmenización"
        Me.TPIndem.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(270, 45)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(89, 13)
        Me.Label25.TabIndex = 188
        Me.Label25.Text = "Sueldo promedio:"
        '
        'txtSueldoProIndem
        '
        Me.txtSueldoProIndem.Location = New System.Drawing.Point(370, 43)
        Me.txtSueldoProIndem.Name = "txtSueldoProIndem"
        Me.txtSueldoProIndem.ReadOnly = True
        Me.txtSueldoProIndem.Size = New System.Drawing.Size(109, 20)
        Me.txtSueldoProIndem.TabIndex = 3
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(456, 19)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(28, 13)
        Me.Label22.TabIndex = 184
        Me.Label22.Text = "días"
        '
        'dgvIndem
        '
        Me.dgvIndem.AllowUserToAddRows = False
        Me.dgvIndem.AllowUserToDeleteRows = False
        Me.dgvIndem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvIndem.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvIndem.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvIndem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIndem.Location = New System.Drawing.Point(9, 67)
        Me.dgvIndem.Name = "dgvIndem"
        Me.dgvIndem.Size = New System.Drawing.Size(468, 222)
        Me.dgvIndem.TabIndex = 7
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(270, 19)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(96, 13)
        Me.Label23.TabIndex = 183
        Me.Label23.Text = "Correspondiente a:"
        '
        'txtValorIndem
        '
        Me.txtValorIndem.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtValorIndem.Location = New System.Drawing.Point(113, 295)
        Me.txtValorIndem.Name = "txtValorIndem"
        Me.txtValorIndem.ReadOnly = True
        Me.txtValorIndem.Size = New System.Drawing.Size(120, 20)
        Me.txtValorIndem.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(20, 297)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(78, 13)
        Me.Label13.TabIndex = 165
        Me.Label13.Text = "Indemnización:"
        '
        'txtTotalDiasIndem
        '
        Me.txtTotalDiasIndem.Location = New System.Drawing.Point(370, 17)
        Me.txtTotalDiasIndem.Name = "txtTotalDiasIndem"
        Me.txtTotalDiasIndem.ReadOnly = True
        Me.txtTotalDiasIndem.Size = New System.Drawing.Size(72, 20)
        Me.txtTotalDiasIndem.TabIndex = 2
        '
        'pnIndem
        '
        Me.pnIndem.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(62, Byte), Integer), CType(CType(222, Byte), Integer))
        Me.pnIndem.Controls.Add(Me.cbIndemnizacion)
        Me.pnIndem.Controls.Add(Me.Label6)
        Me.pnIndem.Location = New System.Drawing.Point(6, 21)
        Me.pnIndem.Name = "pnIndem"
        Me.pnIndem.Size = New System.Drawing.Size(239, 40)
        Me.pnIndem.TabIndex = 1
        '
        'cbIndemnizacion
        '
        Me.cbIndemnizacion.AutoSize = True
        Me.cbIndemnizacion.ForeColor = System.Drawing.Color.White
        Me.cbIndemnizacion.Location = New System.Drawing.Point(198, 16)
        Me.cbIndemnizacion.Name = "cbIndemnizacion"
        Me.cbIndemnizacion.Size = New System.Drawing.Size(36, 17)
        Me.cbIndemnizacion.TabIndex = 134
        Me.cbIndemnizacion.Text = "SI"
        Me.cbIndemnizacion.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(8, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(172, 13)
        Me.Label6.TabIndex = 133
        Me.Label6.Text = "Aplica a indemnización o cesantias"
        '
        'TPVaca
        '
        Me.TPVaca.Controls.Add(Me.Label28)
        Me.TPVaca.Controls.Add(Me.txtValDiaPromVac)
        Me.TPVaca.Controls.Add(Me.Label26)
        Me.TPVaca.Controls.Add(Me.txtSueldoProVac)
        Me.TPVaca.Controls.Add(Me.btnDesmarcaV)
        Me.TPVaca.Controls.Add(Me.btnGenVaca)
        Me.TPVaca.Controls.Add(Me.dgvVacaciones)
        Me.TPVaca.Controls.Add(Me.btnMarcaV)
        Me.TPVaca.Controls.Add(Me.txtValorVacaciones)
        Me.TPVaca.Controls.Add(Me.Label12)
        Me.TPVaca.Controls.Add(Me.Label14)
        Me.TPVaca.Controls.Add(Me.nudVacaNoTo)
        Me.TPVaca.Controls.Add(Me.Label11)
        Me.TPVaca.Controls.Add(Me.Label4)
        Me.TPVaca.Controls.Add(Me.dpFechaIVaca)
        Me.TPVaca.Controls.Add(Me.txtNoDiasVacaciones)
        Me.TPVaca.Controls.Add(Me.txtTotalDiasVac)
        Me.TPVaca.Controls.Add(Me.Label7)
        Me.TPVaca.Location = New System.Drawing.Point(4, 22)
        Me.TPVaca.Name = "TPVaca"
        Me.TPVaca.Padding = New System.Windows.Forms.Padding(3)
        Me.TPVaca.Size = New System.Drawing.Size(732, 326)
        Me.TPVaca.TabIndex = 1
        Me.TPVaca.Text = "Vacaciones"
        Me.TPVaca.UseVisualStyleBackColor = True
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(497, 66)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(89, 13)
        Me.Label28.TabIndex = 189
        Me.Label28.Text = "Sueldo promedio:"
        '
        'txtValDiaPromVac
        '
        Me.txtValDiaPromVac.Location = New System.Drawing.Point(597, 96)
        Me.txtValDiaPromVac.Name = "txtValDiaPromVac"
        Me.txtValDiaPromVac.ReadOnly = True
        Me.txtValDiaPromVac.Size = New System.Drawing.Size(109, 20)
        Me.txtValDiaPromVac.TabIndex = 6
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(493, 99)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(99, 13)
        Me.Label26.TabIndex = 190
        Me.Label26.Text = "Valor día promedio:"
        '
        'txtSueldoProVac
        '
        Me.txtSueldoProVac.Location = New System.Drawing.Point(597, 63)
        Me.txtSueldoProVac.Name = "txtSueldoProVac"
        Me.txtSueldoProVac.ReadOnly = True
        Me.txtSueldoProVac.Size = New System.Drawing.Size(109, 20)
        Me.txtSueldoProVac.TabIndex = 5
        '
        'dgvVacaciones
        '
        Me.dgvVacaciones.AllowUserToAddRows = False
        Me.dgvVacaciones.AllowUserToDeleteRows = False
        Me.dgvVacaciones.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvVacaciones.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvVacaciones.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvVacaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvVacaciones.Location = New System.Drawing.Point(8, 63)
        Me.dgvVacaciones.Name = "dgvVacaciones"
        Me.dgvVacaciones.Size = New System.Drawing.Size(468, 207)
        Me.dgvVacaciones.TabIndex = 10
        '
        'txtValorVacaciones
        '
        Me.txtValorVacaciones.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtValorVacaciones.Location = New System.Drawing.Point(102, 294)
        Me.txtValorVacaciones.Name = "txtValorVacaciones"
        Me.txtValorVacaciones.ReadOnly = True
        Me.txtValorVacaciones.Size = New System.Drawing.Size(120, 20)
        Me.txtValorVacaciones.TabIndex = 11
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(594, 25)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(58, 13)
        Me.Label12.TabIndex = 163
        Me.Label12.Text = "Total días:"
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 296)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 13)
        Me.Label14.TabIndex = 167
        Me.Label14.Text = "Vacaciones:"
        '
        'nudVacaNoTo
        '
        Me.nudVacaNoTo.Location = New System.Drawing.Point(501, 23)
        Me.nudVacaNoTo.Name = "nudVacaNoTo"
        Me.nudVacaNoTo.Size = New System.Drawing.Size(82, 20)
        Me.nudVacaNoTo.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(149, 13)
        Me.Label11.TabIndex = 161
        Me.Label11.Text = "Fecha de inicio de vacacines:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(284, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(28, 13)
        Me.Label4.TabIndex = 144
        Me.Label4.Text = "Dias"
        '
        'dpFechaIVaca
        '
        Me.dpFechaIVaca.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaIVaca.Location = New System.Drawing.Point(166, 25)
        Me.dpFechaIVaca.Name = "dpFechaIVaca"
        Me.dpFechaIVaca.Size = New System.Drawing.Size(109, 20)
        Me.dpFechaIVaca.TabIndex = 1
        '
        'txtNoDiasVacaciones
        '
        Me.txtNoDiasVacaciones.Location = New System.Drawing.Point(326, 25)
        Me.txtNoDiasVacaciones.Name = "txtNoDiasVacaciones"
        Me.txtNoDiasVacaciones.ReadOnly = True
        Me.txtNoDiasVacaciones.Size = New System.Drawing.Size(72, 20)
        Me.txtNoDiasVacaciones.TabIndex = 2
        '
        'txtTotalDiasVac
        '
        Me.txtTotalDiasVac.Location = New System.Drawing.Point(658, 23)
        Me.txtTotalDiasVac.Name = "txtTotalDiasVac"
        Me.txtTotalDiasVac.ReadOnly = True
        Me.txtTotalDiasVac.Size = New System.Drawing.Size(72, 20)
        Me.txtTotalDiasVac.TabIndex = 4
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(404, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 13)
        Me.Label7.TabIndex = 153
        Me.Label7.Text = "Dias no tomados:"
        '
        'TPBono14
        '
        Me.TPBono14.Controls.Add(Me.rbCalculoBono2)
        Me.TPBono14.Controls.Add(Me.Label27)
        Me.TPBono14.Controls.Add(Me.txtSueldoProBon)
        Me.TPBono14.Controls.Add(Me.rbCalculoBono1)
        Me.TPBono14.Controls.Add(Me.btnDescmarcaB)
        Me.TPBono14.Controls.Add(Me.btnMarcaB)
        Me.TPBono14.Controls.Add(Me.Label19)
        Me.TPBono14.Controls.Add(Me.Label18)
        Me.TPBono14.Controls.Add(Me.txtTotalDiasBono)
        Me.TPBono14.Controls.Add(Me.btnGenBono)
        Me.TPBono14.Controls.Add(Me.dgvBono14)
        Me.TPBono14.Controls.Add(Me.txtValorBono14)
        Me.TPBono14.Controls.Add(Me.Label15)
        Me.TPBono14.Location = New System.Drawing.Point(4, 22)
        Me.TPBono14.Name = "TPBono14"
        Me.TPBono14.Size = New System.Drawing.Size(732, 326)
        Me.TPBono14.TabIndex = 2
        Me.TPBono14.Text = "Bono 14"
        Me.TPBono14.UseVisualStyleBackColor = True
        '
        'rbCalculoBono2
        '
        Me.rbCalculoBono2.AutoSize = True
        Me.rbCalculoBono2.Location = New System.Drawing.Point(494, 177)
        Me.rbCalculoBono2.Name = "rbCalculoBono2"
        Me.rbCalculoBono2.Size = New System.Drawing.Size(69, 17)
        Me.rbCalculoBono2.TabIndex = 194
        Me.rbCalculoBono2.TabStop = True
        Me.rbCalculoBono2.Text = "Calculo 2"
        Me.rbCalculoBono2.UseVisualStyleBackColor = True
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(486, 45)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(89, 13)
        Me.Label27.TabIndex = 194
        Me.Label27.Text = "Sueldo promedio:"
        '
        'txtSueldoProBon
        '
        Me.txtSueldoProBon.Location = New System.Drawing.Point(586, 43)
        Me.txtSueldoProBon.Name = "txtSueldoProBon"
        Me.txtSueldoProBon.ReadOnly = True
        Me.txtSueldoProBon.Size = New System.Drawing.Size(109, 20)
        Me.txtSueldoProBon.TabIndex = 2
        '
        'rbCalculoBono1
        '
        Me.rbCalculoBono1.AutoSize = True
        Me.rbCalculoBono1.Location = New System.Drawing.Point(495, 154)
        Me.rbCalculoBono1.Name = "rbCalculoBono1"
        Me.rbCalculoBono1.Size = New System.Drawing.Size(69, 17)
        Me.rbCalculoBono1.TabIndex = 193
        Me.rbCalculoBono1.TabStop = True
        Me.rbCalculoBono1.Text = "Calculo 1"
        Me.rbCalculoBono1.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(672, 15)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(28, 13)
        Me.Label19.TabIndex = 178
        Me.Label19.Text = "días"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(486, 15)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(96, 13)
        Me.Label18.TabIndex = 177
        Me.Label18.Text = "Correspondiente a:"
        '
        'txtTotalDiasBono
        '
        Me.txtTotalDiasBono.Location = New System.Drawing.Point(586, 13)
        Me.txtTotalDiasBono.Name = "txtTotalDiasBono"
        Me.txtTotalDiasBono.ReadOnly = True
        Me.txtTotalDiasBono.Size = New System.Drawing.Size(72, 20)
        Me.txtTotalDiasBono.TabIndex = 1
        '
        'dgvBono14
        '
        Me.dgvBono14.AllowUserToAddRows = False
        Me.dgvBono14.AllowUserToDeleteRows = False
        Me.dgvBono14.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvBono14.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvBono14.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvBono14.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBono14.Location = New System.Drawing.Point(9, 13)
        Me.dgvBono14.Name = "dgvBono14"
        Me.dgvBono14.Size = New System.Drawing.Size(468, 260)
        Me.dgvBono14.TabIndex = 6
        '
        'txtValorBono14
        '
        Me.txtValorBono14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtValorBono14.Location = New System.Drawing.Point(102, 297)
        Me.txtValorBono14.Name = "txtValorBono14"
        Me.txtValorBono14.ReadOnly = True
        Me.txtValorBono14.Size = New System.Drawing.Size(120, 20)
        Me.txtValorBono14.TabIndex = 7
        '
        'Label15
        '
        Me.Label15.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 299)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(50, 13)
        Me.Label15.TabIndex = 169
        Me.Label15.Text = "Bono 14:"
        '
        'TPAguinaldo
        '
        Me.TPAguinaldo.Controls.Add(Me.rbCalculoAgui2)
        Me.TPAguinaldo.Controls.Add(Me.rbCalculoAgui1)
        Me.TPAguinaldo.Controls.Add(Me.Label24)
        Me.TPAguinaldo.Controls.Add(Me.btnDescmarcaA)
        Me.TPAguinaldo.Controls.Add(Me.btnMarcaA)
        Me.TPAguinaldo.Controls.Add(Me.txtSueldoProAgu)
        Me.TPAguinaldo.Controls.Add(Me.Label20)
        Me.TPAguinaldo.Controls.Add(Me.btnAguinaldo)
        Me.TPAguinaldo.Controls.Add(Me.dgvAguinaldo)
        Me.TPAguinaldo.Controls.Add(Me.Label21)
        Me.TPAguinaldo.Controls.Add(Me.txtValorAguinaldo)
        Me.TPAguinaldo.Controls.Add(Me.Label16)
        Me.TPAguinaldo.Controls.Add(Me.txtTotalDiasAguinaldo)
        Me.TPAguinaldo.Location = New System.Drawing.Point(4, 22)
        Me.TPAguinaldo.Name = "TPAguinaldo"
        Me.TPAguinaldo.Size = New System.Drawing.Size(732, 326)
        Me.TPAguinaldo.TabIndex = 3
        Me.TPAguinaldo.Text = "Aguinaldo"
        Me.TPAguinaldo.UseVisualStyleBackColor = True
        '
        'rbCalculoAgui2
        '
        Me.rbCalculoAgui2.AutoSize = True
        Me.rbCalculoAgui2.Location = New System.Drawing.Point(498, 171)
        Me.rbCalculoAgui2.Name = "rbCalculoAgui2"
        Me.rbCalculoAgui2.Size = New System.Drawing.Size(69, 17)
        Me.rbCalculoAgui2.TabIndex = 192
        Me.rbCalculoAgui2.TabStop = True
        Me.rbCalculoAgui2.Text = "Calculo 2"
        Me.rbCalculoAgui2.UseVisualStyleBackColor = True
        '
        'rbCalculoAgui1
        '
        Me.rbCalculoAgui1.AutoSize = True
        Me.rbCalculoAgui1.Location = New System.Drawing.Point(499, 148)
        Me.rbCalculoAgui1.Name = "rbCalculoAgui1"
        Me.rbCalculoAgui1.Size = New System.Drawing.Size(69, 17)
        Me.rbCalculoAgui1.TabIndex = 191
        Me.rbCalculoAgui1.TabStop = True
        Me.rbCalculoAgui1.Text = "Calculo 1"
        Me.rbCalculoAgui1.UseVisualStyleBackColor = True
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(493, 43)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(89, 13)
        Me.Label24.TabIndex = 190
        Me.Label24.Text = "Sueldo promedio:"
        '
        'txtSueldoProAgu
        '
        Me.txtSueldoProAgu.Location = New System.Drawing.Point(594, 41)
        Me.txtSueldoProAgu.Name = "txtSueldoProAgu"
        Me.txtSueldoProAgu.ReadOnly = True
        Me.txtSueldoProAgu.Size = New System.Drawing.Size(109, 20)
        Me.txtSueldoProAgu.TabIndex = 2
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(679, 17)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(28, 13)
        Me.Label20.TabIndex = 181
        Me.Label20.Text = "días"
        '
        'dgvAguinaldo
        '
        Me.dgvAguinaldo.AllowUserToAddRows = False
        Me.dgvAguinaldo.AllowUserToDeleteRows = False
        Me.dgvAguinaldo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.dgvAguinaldo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAguinaldo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvAguinaldo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAguinaldo.Location = New System.Drawing.Point(11, 15)
        Me.dgvAguinaldo.Name = "dgvAguinaldo"
        Me.dgvAguinaldo.Size = New System.Drawing.Size(468, 243)
        Me.dgvAguinaldo.TabIndex = 172
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(493, 17)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(96, 13)
        Me.Label21.TabIndex = 180
        Me.Label21.Text = "Correspondiente a:"
        '
        'txtValorAguinaldo
        '
        Me.txtValorAguinaldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtValorAguinaldo.Location = New System.Drawing.Point(102, 297)
        Me.txtValorAguinaldo.Name = "txtValorAguinaldo"
        Me.txtValorAguinaldo.ReadOnly = True
        Me.txtValorAguinaldo.Size = New System.Drawing.Size(120, 20)
        Me.txtValorAguinaldo.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 299)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(57, 13)
        Me.Label16.TabIndex = 171
        Me.Label16.Text = "Aguinaldo:"
        '
        'txtTotalDiasAguinaldo
        '
        Me.txtTotalDiasAguinaldo.Location = New System.Drawing.Point(594, 15)
        Me.txtTotalDiasAguinaldo.Name = "txtTotalDiasAguinaldo"
        Me.txtTotalDiasAguinaldo.ReadOnly = True
        Me.txtTotalDiasAguinaldo.Size = New System.Drawing.Size(72, 20)
        Me.txtTotalDiasAguinaldo.TabIndex = 1
        '
        'TPSalario
        '
        Me.TPSalario.Controls.Add(Me.dgvPrestamos)
        Me.TPSalario.Controls.Add(Me.Label38)
        Me.TPSalario.Controls.Add(Me.btnSalarioMensualFalt)
        Me.TPSalario.Controls.Add(Me.TLPPri)
        Me.TPSalario.Controls.Add(Me.nudDiasSalario)
        Me.TPSalario.Controls.Add(Me.Label33)
        Me.TPSalario.Controls.Add(Me.Label31)
        Me.TPSalario.Controls.Add(Me.txtSueldoDiarioSal)
        Me.TPSalario.Controls.Add(Me.txtSueldoSal)
        Me.TPSalario.Controls.Add(Me.Label32)
        Me.TPSalario.Location = New System.Drawing.Point(4, 22)
        Me.TPSalario.Name = "TPSalario"
        Me.TPSalario.Size = New System.Drawing.Size(732, 326)
        Me.TPSalario.TabIndex = 4
        Me.TPSalario.Text = "Salario"
        Me.TPSalario.UseVisualStyleBackColor = True
        '
        'TLPPri
        '
        Me.TLPPri.ColumnCount = 2
        Me.TLPPri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TLPPri.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TLPPri.Controls.Add(Me.dgvDescuentos, 1, 1)
        Me.TLPPri.Controls.Add(Me.Panel5, 1, 2)
        Me.TLPPri.Controls.Add(Me.Panel4, 0, 2)
        Me.TLPPri.Controls.Add(Me.Panel3, 1, 0)
        Me.TLPPri.Controls.Add(Me.Panel2, 0, 0)
        Me.TLPPri.Controls.Add(Me.dgvIngresos, 0, 1)
        Me.TLPPri.Location = New System.Drawing.Point(3, 125)
        Me.TLPPri.Name = "TLPPri"
        Me.TLPPri.RowCount = 3
        Me.TLPPri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TLPPri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TLPPri.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30.0!))
        Me.TLPPri.Size = New System.Drawing.Size(729, 198)
        Me.TLPPri.TabIndex = 197
        '
        'dgvDescuentos
        '
        Me.dgvDescuentos.AllowUserToAddRows = False
        Me.dgvDescuentos.AllowUserToDeleteRows = False
        Me.dgvDescuentos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvDescuentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDescuentos.Location = New System.Drawing.Point(367, 33)
        Me.dgvDescuentos.Name = "dgvDescuentos"
        Me.dgvDescuentos.Size = New System.Drawing.Size(359, 132)
        Me.dgvDescuentos.TabIndex = 200
        '
        'Panel5
        '
        Me.Panel5.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel5.Controls.Add(Me.txtTotalDescuentos)
        Me.Panel5.Controls.Add(Me.Label37)
        Me.Panel5.Location = New System.Drawing.Point(367, 171)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(359, 24)
        Me.Panel5.TabIndex = 198
        '
        'txtTotalDescuentos
        '
        Me.txtTotalDescuentos.BackColor = System.Drawing.Color.White
        Me.txtTotalDescuentos.ForeColor = System.Drawing.Color.Red
        Me.txtTotalDescuentos.Location = New System.Drawing.Point(245, 2)
        Me.txtTotalDescuentos.Name = "txtTotalDescuentos"
        Me.txtTotalDescuentos.ReadOnly = True
        Me.txtTotalDescuentos.Size = New System.Drawing.Size(110, 20)
        Me.txtTotalDescuentos.TabIndex = 3
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(156, 6)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(31, 13)
        Me.Label37.TabIndex = 1
        Me.Label37.Text = "Total"
        '
        'Panel4
        '
        Me.Panel4.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel4.Controls.Add(Me.txtTotalIngresos)
        Me.Panel4.Controls.Add(Me.Label36)
        Me.Panel4.Location = New System.Drawing.Point(3, 171)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(358, 24)
        Me.Panel4.TabIndex = 1
        '
        'txtTotalIngresos
        '
        Me.txtTotalIngresos.BackColor = System.Drawing.Color.White
        Me.txtTotalIngresos.ForeColor = System.Drawing.Color.Red
        Me.txtTotalIngresos.Location = New System.Drawing.Point(245, 2)
        Me.txtTotalIngresos.Name = "txtTotalIngresos"
        Me.txtTotalIngresos.ReadOnly = True
        Me.txtTotalIngresos.Size = New System.Drawing.Size(110, 20)
        Me.txtTotalIngresos.TabIndex = 2
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Location = New System.Drawing.Point(156, 6)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(31, 13)
        Me.Label36.TabIndex = 1
        Me.Label36.Text = "Total"
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.Label35)
        Me.Panel3.Location = New System.Drawing.Point(367, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(359, 24)
        Me.Panel3.TabIndex = 1
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(8, 6)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(64, 13)
        Me.Label35.TabIndex = 1
        Me.Label35.Text = "Descuentos"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.Label34)
        Me.Panel2.Location = New System.Drawing.Point(3, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(358, 24)
        Me.Panel2.TabIndex = 0
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(8, 6)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(47, 13)
        Me.Label34.TabIndex = 0
        Me.Label34.Text = "Ingresos"
        '
        'dgvIngresos
        '
        Me.dgvIngresos.AllowUserToAddRows = False
        Me.dgvIngresos.AllowUserToDeleteRows = False
        Me.dgvIngresos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvIngresos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvIngresos.Location = New System.Drawing.Point(3, 33)
        Me.dgvIngresos.Name = "dgvIngresos"
        Me.dgvIngresos.Size = New System.Drawing.Size(358, 132)
        Me.dgvIngresos.TabIndex = 199
        '
        'nudDiasSalario
        '
        Me.nudDiasSalario.Location = New System.Drawing.Point(122, 87)
        Me.nudDiasSalario.Name = "nudDiasSalario"
        Me.nudDiasSalario.Size = New System.Drawing.Size(82, 20)
        Me.nudDiasSalario.TabIndex = 195
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(25, 89)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(80, 13)
        Me.Label33.TabIndex = 196
        Me.Label33.Text = "Dias a calcular:"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(22, 18)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(106, 13)
        Me.Label31.TabIndex = 193
        Me.Label31.Text = "Sueldo total recibido:"
        '
        'txtSueldoDiarioSal
        '
        Me.txtSueldoDiarioSal.Location = New System.Drawing.Point(129, 48)
        Me.txtSueldoDiarioSal.Name = "txtSueldoDiarioSal"
        Me.txtSueldoDiarioSal.ReadOnly = True
        Me.txtSueldoDiarioSal.Size = New System.Drawing.Size(109, 20)
        Me.txtSueldoDiarioSal.TabIndex = 192
        '
        'txtSueldoSal
        '
        Me.txtSueldoSal.Location = New System.Drawing.Point(129, 15)
        Me.txtSueldoSal.Name = "txtSueldoSal"
        Me.txtSueldoSal.ReadOnly = True
        Me.txtSueldoSal.Size = New System.Drawing.Size(109, 20)
        Me.txtSueldoSal.TabIndex = 191
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(18, 51)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(99, 13)
        Me.Label32.TabIndex = 194
        Me.Label32.Text = "Valor día promedio:"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.Label30)
        Me.Panel1.Controls.Add(Me.dpFechaHoy)
        Me.Panel1.Controls.Add(Me.txtMotivo)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Controls.Add(Me.btnGenReporte)
        Me.Panel1.Controls.Add(Me.TabControlP)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me.txtTotal)
        Me.Panel1.Controls.Add(Me.txtDiasLaborados)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.txtSueldo)
        Me.Panel1.Controls.Add(Me.txtPuesto)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.txtAño)
        Me.Panel1.Controls.Add(Me.txtMes)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.gpContrato)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dpFechaF)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtFechaI)
        Me.Panel1.Controls.Add(Me.busqEmpleado)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(880, 587)
        Me.Panel1.TabIndex = 91
        '
        'Label30
        '
        Me.Label30.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(187, 553)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(79, 13)
        Me.Label30.TabIndex = 178
        Me.Label30.Text = "Fecha finiquito:"
        '
        'dpFechaHoy
        '
        Me.dpFechaHoy.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaHoy.Location = New System.Drawing.Point(273, 553)
        Me.dpFechaHoy.Name = "dpFechaHoy"
        Me.dpFechaHoy.Size = New System.Drawing.Size(109, 20)
        Me.dpFechaHoy.TabIndex = 177
        '
        'txtMotivo
        '
        Me.txtMotivo.Location = New System.Drawing.Point(126, 148)
        Me.txtMotivo.MaxLength = 150
        Me.txtMotivo.Name = "txtMotivo"
        Me.txtMotivo.Size = New System.Drawing.Size(630, 20)
        Me.txtMotivo.TabIndex = 9
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(17, 147)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(39, 13)
        Me.Label29.TabIndex = 176
        Me.Label29.Text = "Motivo"
        '
        'Label17
        '
        Me.Label17.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(8, 553)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(34, 13)
        Me.Label17.TabIndex = 173
        Me.Label17.Text = "Total:"
        '
        'txtTotal
        '
        Me.txtTotal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtTotal.Location = New System.Drawing.Point(48, 553)
        Me.txtTotal.Name = "txtTotal"
        Me.txtTotal.ReadOnly = True
        Me.txtTotal.Size = New System.Drawing.Size(120, 20)
        Me.txtTotal.TabIndex = 12
        '
        'txtDiasLaborados
        '
        Me.txtDiasLaborados.Location = New System.Drawing.Point(592, 92)
        Me.txtDiasLaborados.Name = "txtDiasLaborados"
        Me.txtDiasLaborados.ReadOnly = True
        Me.txtDiasLaborados.Size = New System.Drawing.Size(66, 20)
        Me.txtDiasLaborados.TabIndex = 6
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(509, 95)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 13)
        Me.Label10.TabIndex = 158
        Me.Label10.Text = "Dias laborados"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(463, 64)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 157
        Me.Label9.Text = "Sueldo"
        '
        'txtSueldo
        '
        Me.txtSueldo.Location = New System.Drawing.Point(528, 65)
        Me.txtSueldo.Name = "txtSueldo"
        Me.txtSueldo.ReadOnly = True
        Me.txtSueldo.Size = New System.Drawing.Size(100, 20)
        Me.txtSueldo.TabIndex = 3
        '
        'txtPuesto
        '
        Me.txtPuesto.Location = New System.Drawing.Point(102, 65)
        Me.txtPuesto.Name = "txtPuesto"
        Me.txtPuesto.ReadOnly = True
        Me.txtPuesto.Size = New System.Drawing.Size(336, 20)
        Me.txtPuesto.TabIndex = 2
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 68)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 13)
        Me.Label8.TabIndex = 154
        Me.Label8.Text = "Puesto"
        '
        'txtAño
        '
        Me.txtAño.Location = New System.Drawing.Point(320, 122)
        Me.txtAño.Name = "txtAño"
        Me.txtAño.ReadOnly = True
        Me.txtAño.Size = New System.Drawing.Size(73, 20)
        Me.txtAño.TabIndex = 8
        '
        'txtMes
        '
        Me.txtMes.Location = New System.Drawing.Point(126, 122)
        Me.txtMes.Name = "txtMes"
        Me.txtMes.ReadOnly = True
        Me.txtMes.Size = New System.Drawing.Size(188, 20)
        Me.txtMes.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 122)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 13)
        Me.Label5.TabIndex = 149
        Me.Label5.Text = "Último mes de pago"
        '
        'gpContrato
        '
        Me.gpContrato.Controls.Add(Me.btnContrato)
        Me.gpContrato.Controls.Add(Me.txtContrato)
        Me.gpContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpContrato.ForeColor = System.Drawing.Color.White
        Me.gpContrato.Location = New System.Drawing.Point(486, 8)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(137, 44)
        Me.gpContrato.TabIndex = 1
        Me.gpContrato.TabStop = False
        Me.gpContrato.Text = "Contrato"
        '
        'btnContrato
        '
        Me.btnContrato.BackColor = System.Drawing.SystemColors.Control
        Me.btnContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContrato.ImageIndex = 0
        Me.btnContrato.ImageList = Me.ImageNuevos
        Me.btnContrato.Location = New System.Drawing.Point(82, 10)
        Me.btnContrato.Name = "btnContrato"
        Me.btnContrato.Size = New System.Drawing.Size(40, 30)
        Me.btnContrato.TabIndex = 16
        Me.btnContrato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnContrato.UseVisualStyleBackColor = False
        '
        'txtContrato
        '
        Me.txtContrato.BackColor = System.Drawing.Color.White
        Me.txtContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtContrato.ForeColor = System.Drawing.Color.Red
        Me.txtContrato.Location = New System.Drawing.Point(10, 16)
        Me.txtContrato.MaxLength = 4
        Me.txtContrato.Name = "txtContrato"
        Me.txtContrato.ReadOnly = True
        Me.txtContrato.Size = New System.Drawing.Size(63, 20)
        Me.txtContrato.TabIndex = 1
        Me.txtContrato.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(245, 95)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 13)
        Me.Label3.TabIndex = 143
        Me.Label3.Text = "Fecha final de labores:"
        '
        'dpFechaF
        '
        Me.dpFechaF.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFechaF.Location = New System.Drawing.Point(365, 92)
        Me.dpFechaF.Name = "dpFechaF"
        Me.dpFechaF.Size = New System.Drawing.Size(109, 20)
        Me.dpFechaF.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 141
        Me.Label2.Text = "Fecha de Inicio:"
        '
        'txtFechaI
        '
        Me.txtFechaI.Location = New System.Drawing.Point(102, 92)
        Me.txtFechaI.Name = "txtFechaI"
        Me.txtFechaI.ReadOnly = True
        Me.txtFechaI.Size = New System.Drawing.Size(100, 20)
        Me.txtFechaI.TabIndex = 4
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Location = New System.Drawing.Point(367, 15)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(98, 13)
        Me.Label38.TabIndex = 198
        Me.Label38.Text = "Saldo de prestamo:"
        '
        'dgvPrestamos
        '
        Me.dgvPrestamos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPrestamos.Location = New System.Drawing.Point(370, 31)
        Me.dgvPrestamos.Name = "dgvPrestamos"
        Me.dgvPrestamos.ReadOnly = True
        Me.dgvPrestamos.Size = New System.Drawing.Size(359, 77)
        Me.dgvPrestamos.TabIndex = 201
        '
        'frmIndemnizacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(919, 611)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmIndemnizacion"
        Me.Text = "Consulta de Indemnización y otras prestaciones"
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlP.ResumeLayout(False)
        Me.TPIndem.ResumeLayout(False)
        Me.TPIndem.PerformLayout()
        CType(Me.dgvIndem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnIndem.ResumeLayout(False)
        Me.pnIndem.PerformLayout()
        Me.TPVaca.ResumeLayout(False)
        Me.TPVaca.PerformLayout()
        CType(Me.dgvVacaciones, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudVacaNoTo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPBono14.ResumeLayout(False)
        Me.TPBono14.PerformLayout()
        CType(Me.dgvBono14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPAguinaldo.ResumeLayout(False)
        Me.TPAguinaldo.PerformLayout()
        CType(Me.dgvAguinaldo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPSalario.ResumeLayout(False)
        Me.TPSalario.PerformLayout()
        Me.TLPPri.ResumeLayout(False)
        CType(Me.dgvDescuentos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dgvIngresos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudDiasSalario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        CType(Me.dgvPrestamos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents busqEmpleado As ControlesERP.controlBusquedaEmpleado
    Friend WithEvents Label1 As Label
    Friend WithEvents ImageNuevos As ImageList
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ep1 As ErrorProvider
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents btnEjecutar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents pnIndem As Panel
    Friend WithEvents cbIndemnizacion As CheckBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNoDiasVacaciones As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents dpFechaF As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents txtFechaI As TextBox
    Friend WithEvents gpContrato As GroupBox
    Friend WithEvents btnContrato As Button
    Friend WithEvents txtContrato As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtMes As TextBox
    Friend WithEvents txtAño As TextBox
    Friend WithEvents txtTotalDiasVac As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtPuesto As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtSueldo As TextBox
    Friend WithEvents txtDiasLaborados As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents dpFechaIVaca As DateTimePicker
    Friend WithEvents nudVacaNoTo As NumericUpDown
    Friend WithEvents Label12 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents txtValorAguinaldo As TextBox
    Friend WithEvents Label15 As Label
    Friend WithEvents txtValorBono14 As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents txtValorVacaciones As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtValorIndem As TextBox
    Friend WithEvents Label17 As Label
    Friend WithEvents txtTotal As TextBox
    Friend WithEvents TabControlP As TabControl
    Friend WithEvents TPIndem As TabPage
    Friend WithEvents TPVaca As TabPage
    Friend WithEvents TPBono14 As TabPage
    Friend WithEvents TPAguinaldo As TabPage
    Friend WithEvents btnGenIndem As Button
    Friend WithEvents dgvIndem As DataGridView
    Friend WithEvents dgvVacaciones As DataGridView
    Friend WithEvents btnGenVaca As Button
    Friend WithEvents dgvBono14 As DataGridView
    Friend WithEvents dgvAguinaldo As DataGridView
    Friend WithEvents btnGenBono As Button
    Friend WithEvents btnAguinaldo As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents txtTotalDiasBono As TextBox
    Friend WithEvents btnDescmarcaI As Button
    Friend WithEvents btnMarcarI As Button
    Friend WithEvents Label22 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents txtTotalDiasIndem As TextBox
    Friend WithEvents btnDesmarcaV As Button
    Friend WithEvents btnMarcaV As Button
    Friend WithEvents btnDescmarcaB As Button
    Friend WithEvents btnMarcaB As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents txtTotalDiasAguinaldo As TextBox
    Friend WithEvents btnDescmarcaA As Button
    Friend WithEvents btnMarcaA As Button
    Friend WithEvents Label25 As Label
    Friend WithEvents txtSueldoProIndem As TextBox
    Friend WithEvents Label26 As Label
    Friend WithEvents txtSueldoProVac As TextBox
    Friend WithEvents Label27 As Label
    Friend WithEvents txtSueldoProBon As TextBox
    Friend WithEvents Label24 As Label
    Friend WithEvents txtSueldoProAgu As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents txtValDiaPromVac As TextBox
    Friend WithEvents btnGenReporte As Button
    Friend WithEvents txtMotivo As TextBox
    Friend WithEvents Label29 As Label
    Friend WithEvents Label30 As Label
    Friend WithEvents dpFechaHoy As DateTimePicker
    Friend WithEvents TPSalario As TabPage
    Friend WithEvents TLPPri As TableLayoutPanel
    Friend WithEvents dgvDescuentos As DataGridView
    Friend WithEvents Panel5 As Panel
    Friend WithEvents txtTotalDescuentos As TextBox
    Friend WithEvents Label37 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtTotalIngresos As TextBox
    Friend WithEvents Label36 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label35 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label34 As Label
    Friend WithEvents dgvIngresos As DataGridView
    Friend WithEvents nudDiasSalario As NumericUpDown
    Friend WithEvents Label33 As Label
    Friend WithEvents Label31 As Label
    Friend WithEvents txtSueldoDiarioSal As TextBox
    Friend WithEvents txtSueldoSal As TextBox
    Friend WithEvents Label32 As Label
    Friend WithEvents rbCalculoBono2 As RadioButton
    Friend WithEvents rbCalculoBono1 As RadioButton
    Friend WithEvents rbCalculoAgui2 As RadioButton
    Friend WithEvents rbCalculoAgui1 As RadioButton
    Friend WithEvents btnSalarioMensualFalt As Button
    Friend WithEvents Label38 As Label
    Friend WithEvents dgvPrestamos As DataGridView
End Class
