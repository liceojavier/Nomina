Imports System.Data.SqlClient
Imports System.IO
Imports NOMINA.controller

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMGENEPAGOMENSUAL.VB MIEMBRO DE NOMINA.SLN                                 **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmGenePagoMensual
    Inherits Form
    Dim cadena As String
    Dim tbContra1 As New DataTable("contra1")
    Dim tbTipo As New DataTable("tipo")
    Dim filaTemp As DataRow
    Dim lpara As New Dictionary(Of String, Object)

    Dim tt As New DataTable("datos")
    Dim tbEmple As New DataTable

    Dim empleCtr As New EmpleadoController





#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()

        'Agregar cualquier inicialización después de la llamada a InitializeComponent()

    End Sub

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms requiere el siguiente procedimiento
    'Puede modificarse utilizando el Diseñador de Windows Forms. 
    'No lo modifique con el editor de código.
    Friend WithEvents rbSeleccionar As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents TextAño As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextMoneEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents PgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents pnIntro As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rbSeleccion As RadioButton
    Friend WithEvents rbTodos As RadioButton
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents pnInfoEmpleado As Panel
    Friend WithEvents textFiltro As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents textNoRegistros As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDesel As Button
    Friend WithEvents btnSel As Button
    Friend WithEvents dgvEmpleado As DataGridView
    Friend WithEvents btnApli2 As Button
    Friend WithEvents cklbTipoPersonal As CheckedListBox
    Friend WithEvents btnCargaArchivo As Button
    Friend WithEvents ofdArchivo As OpenFileDialog
    Friend WithEvents btnFiltroTodos As Button
    Friend WithEvents btnFiltroMarcados As Button
    Friend WithEvents btnGenerarArchivo As Button
    Friend WithEvents sfdGeneraArchivo As SaveFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenePagoMensual))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.rbSeleccionar = New System.Windows.Forms.GroupBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.rbSeleccion = New System.Windows.Forms.RadioButton()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextMoneEmpresa = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.PgBar = New System.Windows.Forms.ProgressBar()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.pnIntro = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnInfoEmpleado = New System.Windows.Forms.Panel()
        Me.btnGenerarArchivo = New System.Windows.Forms.Button()
        Me.btnFiltroTodos = New System.Windows.Forms.Button()
        Me.btnFiltroMarcados = New System.Windows.Forms.Button()
        Me.btnCargaArchivo = New System.Windows.Forms.Button()
        Me.btnApli2 = New System.Windows.Forms.Button()
        Me.cklbTipoPersonal = New System.Windows.Forms.CheckedListBox()
        Me.textFiltro = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.textNoRegistros = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDesel = New System.Windows.Forms.Button()
        Me.btnSel = New System.Windows.Forms.Button()
        Me.dgvEmpleado = New System.Windows.Forms.DataGridView()
        Me.ofdArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.sfdGeneraArchivo = New System.Windows.Forms.SaveFileDialog()
        Me.rbSeleccionar.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnIntro.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnInfoEmpleado.SuspendLayout()
        CType(Me.dgvEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'rbSeleccionar
        '
        Me.rbSeleccionar.BackColor = System.Drawing.Color.AliceBlue
        Me.rbSeleccionar.Controls.Add(Me.btnLimpiar)
        Me.rbSeleccionar.Controls.Add(Me.rbSeleccion)
        Me.rbSeleccionar.Controls.Add(Me.rbTodos)
        Me.rbSeleccionar.Controls.Add(Me.Label2)
        Me.rbSeleccionar.Controls.Add(Me.Label7)
        Me.rbSeleccionar.Controls.Add(Me.Label6)
        Me.rbSeleccionar.Controls.Add(Me.cmbTipo)
        Me.rbSeleccionar.Controls.Add(Me.TextAño)
        Me.rbSeleccionar.Controls.Add(Me.btnEjecutar)
        Me.rbSeleccionar.Controls.Add(Me.cmbMes)
        Me.rbSeleccionar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSeleccionar.Location = New System.Drawing.Point(11, 62)
        Me.rbSeleccionar.Name = "rbSeleccionar"
        Me.rbSeleccionar.Size = New System.Drawing.Size(852, 78)
        Me.rbSeleccionar.TabIndex = 1
        Me.rbSeleccionar.TabStop = False
        Me.rbSeleccionar.Text = "Tipo y periodo"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(539, 43)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(102, 30)
        Me.btnLimpiar.TabIndex = 88
        Me.btnLimpiar.Text = "Limpiar"
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar")
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
        '
        'rbSeleccion
        '
        Me.rbSeleccion.AutoSize = True
        Me.rbSeleccion.Location = New System.Drawing.Point(663, 34)
        Me.rbSeleccion.Name = "rbSeleccion"
        Me.rbSeleccion.Size = New System.Drawing.Size(130, 17)
        Me.rbSeleccion.TabIndex = 18
        Me.rbSeleccion.TabStop = True
        Me.rbSeleccion.Text = "Seleccionar empleado"
        Me.rbSeleccion.UseVisualStyleBackColor = True
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(663, 11)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(55, 17)
        Me.rbTodos.TabIndex = 17
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 13)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Nómina:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(278, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Mes:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(441, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Año:"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(62, 20)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(208, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'TextAño
        '
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(477, 19)
        Me.TextAño.MaxLength = 4
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(56, 20)
        Me.TextAño.TabIndex = 3
        '
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "actualizar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(539, 11)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(102, 30)
        Me.btnEjecutar.TabIndex = 4
        Me.btnEjecutar.Text = "Generar"
        Me.ToolTip1.SetToolTip(Me.btnEjecutar, "Generar el proceso")
        Me.btnEjecutar.UseVisualStyleBackColor = False
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(316, 18)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(121, 21)
        Me.cmbMes.TabIndex = 2
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextMoneEmpresa)
        Me.gpEmpresa.Controls.Add(Me.Label10)
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(219, 3)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(456, 43)
        Me.gpEmpresa.TabIndex = 56
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextMoneEmpresa
        '
        Me.TextMoneEmpresa.BackColor = System.Drawing.Color.White
        Me.TextMoneEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMoneEmpresa.Location = New System.Drawing.Point(408, 16)
        Me.TextMoneEmpresa.Name = "TextMoneEmpresa"
        Me.TextMoneEmpresa.ReadOnly = True
        Me.TextMoneEmpresa.Size = New System.Drawing.Size(40, 21)
        Me.TextMoneEmpresa.TabIndex = 18
        Me.TextMoneEmpresa.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(346, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Moneda:"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(6, 16)
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(330, 21)
        Me.TextNombEmpresa.TabIndex = 2
        Me.TextNombEmpresa.TabStop = False
        '
        'PgBar
        '
        Me.PgBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PgBar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PgBar.Location = New System.Drawing.Point(7, 5)
        Me.PgBar.Name = "PgBar"
        Me.PgBar.Size = New System.Drawing.Size(862, 23)
        Me.PgBar.TabIndex = 70
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'pnIntro
        '
        Me.pnIntro.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnIntro.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.pnIntro.Controls.Add(Me.gpEmpresa)
        Me.pnIntro.Location = New System.Drawing.Point(0, 0)
        Me.pnIntro.Name = "pnIntro"
        Me.pnIntro.Size = New System.Drawing.Size(875, 56)
        Me.pnIntro.TabIndex = 72
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PgBar)
        Me.Panel2.Location = New System.Drawing.Point(0, 556)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(875, 35)
        Me.Panel2.TabIndex = 73
        '
        'pnInfoEmpleado
        '
        Me.pnInfoEmpleado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnInfoEmpleado.Controls.Add(Me.btnGenerarArchivo)
        Me.pnInfoEmpleado.Controls.Add(Me.btnFiltroTodos)
        Me.pnInfoEmpleado.Controls.Add(Me.btnFiltroMarcados)
        Me.pnInfoEmpleado.Controls.Add(Me.btnCargaArchivo)
        Me.pnInfoEmpleado.Controls.Add(Me.btnApli2)
        Me.pnInfoEmpleado.Controls.Add(Me.cklbTipoPersonal)
        Me.pnInfoEmpleado.Controls.Add(Me.textFiltro)
        Me.pnInfoEmpleado.Controls.Add(Me.Label5)
        Me.pnInfoEmpleado.Controls.Add(Me.textNoRegistros)
        Me.pnInfoEmpleado.Controls.Add(Me.Label1)
        Me.pnInfoEmpleado.Controls.Add(Me.btnDesel)
        Me.pnInfoEmpleado.Controls.Add(Me.btnSel)
        Me.pnInfoEmpleado.Controls.Add(Me.dgvEmpleado)
        Me.pnInfoEmpleado.Location = New System.Drawing.Point(12, 146)
        Me.pnInfoEmpleado.Name = "pnInfoEmpleado"
        Me.pnInfoEmpleado.Size = New System.Drawing.Size(851, 398)
        Me.pnInfoEmpleado.TabIndex = 74
        '
        'btnGenerarArchivo
        '
        Me.btnGenerarArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGenerarArchivo.Location = New System.Drawing.Point(437, 339)
        Me.btnGenerarArchivo.Name = "btnGenerarArchivo"
        Me.btnGenerarArchivo.Size = New System.Drawing.Size(95, 23)
        Me.btnGenerarArchivo.TabIndex = 93
        Me.btnGenerarArchivo.Text = "Generar Archivo"
        Me.btnGenerarArchivo.UseVisualStyleBackColor = True
        '
        'btnFiltroTodos
        '
        Me.btnFiltroTodos.Location = New System.Drawing.Point(701, 4)
        Me.btnFiltroTodos.Name = "btnFiltroTodos"
        Me.btnFiltroTodos.Size = New System.Drawing.Size(98, 23)
        Me.btnFiltroTodos.TabIndex = 92
        Me.btnFiltroTodos.Text = "Ver todos"
        Me.btnFiltroTodos.UseVisualStyleBackColor = True
        '
        'btnFiltroMarcados
        '
        Me.btnFiltroMarcados.Location = New System.Drawing.Point(589, 4)
        Me.btnFiltroMarcados.Name = "btnFiltroMarcados"
        Me.btnFiltroMarcados.Size = New System.Drawing.Size(106, 23)
        Me.btnFiltroMarcados.TabIndex = 91
        Me.btnFiltroMarcados.Text = "Solo ver marcados"
        Me.btnFiltroMarcados.UseVisualStyleBackColor = True
        '
        'btnCargaArchivo
        '
        Me.btnCargaArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnCargaArchivo.Location = New System.Drawing.Point(437, 368)
        Me.btnCargaArchivo.Name = "btnCargaArchivo"
        Me.btnCargaArchivo.Size = New System.Drawing.Size(95, 23)
        Me.btnCargaArchivo.TabIndex = 90
        Me.btnCargaArchivo.Text = "Carga Archivo"
        Me.btnCargaArchivo.UseVisualStyleBackColor = True
        '
        'btnApli2
        '
        Me.btnApli2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnApli2.Location = New System.Drawing.Point(379, 368)
        Me.btnApli2.Name = "btnApli2"
        Me.btnApli2.Size = New System.Drawing.Size(57, 23)
        Me.btnApli2.TabIndex = 89
        Me.btnApli2.Text = "Aplicar"
        Me.btnApli2.UseVisualStyleBackColor = True
        '
        'cklbTipoPersonal
        '
        Me.cklbTipoPersonal.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cklbTipoPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cklbTipoPersonal.FormattingEnabled = True
        Me.cklbTipoPersonal.Location = New System.Drawing.Point(185, 327)
        Me.cklbTipoPersonal.Name = "cklbTipoPersonal"
        Me.cklbTipoPersonal.Size = New System.Drawing.Size(191, 64)
        Me.cklbTipoPersonal.TabIndex = 88
        '
        'textFiltro
        '
        Me.textFiltro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFiltro.Location = New System.Drawing.Point(45, 4)
        Me.textFiltro.MaxLength = 150
        Me.textFiltro.Name = "textFiltro"
        Me.textFiltro.Size = New System.Drawing.Size(536, 20)
        Me.textFiltro.TabIndex = 87
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(8, 7)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 13)
        Me.Label5.TabIndex = 86
        Me.Label5.Text = "Filtro:"
        '
        'textNoRegistros
        '
        Me.textNoRegistros.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.textNoRegistros.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNoRegistros.ForeColor = System.Drawing.Color.Red
        Me.textNoRegistros.Location = New System.Drawing.Point(613, 366)
        Me.textNoRegistros.Name = "textNoRegistros"
        Me.textNoRegistros.Size = New System.Drawing.Size(125, 24)
        Me.textNoRegistros.TabIndex = 85
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(535, 368)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "No. Registros:"
        '
        'btnDesel
        '
        Me.btnDesel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDesel.Location = New System.Drawing.Point(95, 342)
        Me.btnDesel.Name = "btnDesel"
        Me.btnDesel.Size = New System.Drawing.Size(84, 49)
        Me.btnDesel.TabIndex = 83
        Me.btnDesel.Text = "Deseleccionar a todos"
        Me.btnDesel.UseVisualStyleBackColor = True
        '
        'btnSel
        '
        Me.btnSel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSel.Location = New System.Drawing.Point(9, 342)
        Me.btnSel.Name = "btnSel"
        Me.btnSel.Size = New System.Drawing.Size(80, 49)
        Me.btnSel.TabIndex = 82
        Me.btnSel.Text = "Seleccionar a todos"
        Me.btnSel.UseVisualStyleBackColor = True
        '
        'dgvEmpleado
        '
        Me.dgvEmpleado.AllowUserToAddRows = False
        Me.dgvEmpleado.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvEmpleado.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvEmpleado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEmpleado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvEmpleado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpleado.Location = New System.Drawing.Point(9, 30)
        Me.dgvEmpleado.Name = "dgvEmpleado"
        Me.dgvEmpleado.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmpleado.Size = New System.Drawing.Size(729, 289)
        Me.dgvEmpleado.TabIndex = 81
        '
        'ofdArchivo
        '
        Me.ofdArchivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"""
        '
        'sfdGeneraArchivo
        '
        Me.sfdGeneraArchivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"""
        '
        'frmGenePagoMensual
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(875, 591)
        Me.Controls.Add(Me.pnInfoEmpleado)
        Me.Controls.Add(Me.rbSeleccionar)
        Me.Controls.Add(Me.pnIntro)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmGenePagoMensual"
        Me.Text = "Proceso de Generación de la Nómina de Pago Mensual"
        Me.rbSeleccionar.ResumeLayout(False)
        Me.rbSeleccionar.PerformLayout()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnIntro.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pnInfoEmpleado.ResumeLayout(False)
        Me.pnInfoEmpleado.PerformLayout()
        CType(Me.dgvEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim tbTipoPer As New DataTable
        lpara.Clear()
        lpara("empresa") = empresa
        cadena = "select nombre from meses order by mes"
        llena_combo(cadena, cmbMes)
        cmbMes.Items.Add("")
        TextAño.Text = System.DateTime.Now.Year
        EscribeEmpresa(TextNombEmpresa, TextMoneEmpresa)
        cmbMes.SelectedIndex = System.DateTime.Now.Month - 1
        cadena = "select nombre, tiponom, cantidad, por, movimientos, desprestamos from tiponomina1 where empresa=@empresa and tiponom='M'"
        llena_combo(cadena, cmbTipo, ListaParametros(lpara))
        llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        cmbTipo.Items.Add("")


        cadena = "select a.nombre, a.tibase, a.basevaca, a.cantvaca, a.tipoper from tipopersonal a
                 where a.empresa=@empresa and a.prestaciones='S' and a.pagonomina='S'"
        llenaTabla(cadena, tbTipoPer, ListaParametros(lpara))
        cklbTipoPersonal.DataSource = tbTipoPer
        cklbTipoPersonal.DisplayMember = "nombre"

        tbEmple = empleCtr.GetEmpleadosContrato(empresa)
        tbEmple.Columns.Add("marca", Type.GetType("System.Boolean"))
        For Each fila As DataRow In tbEmple.Rows
            fila("marca") = False
        Next
        tbEmple.Columns("marca").AllowDBNull = False
        dgvEmpleado.DataSource = tbEmple
        Vista1(dgvEmpleado)
        cmbTipo.SelectedIndex = 0
        PgBar.Minimum = 0
        PgBar.Step = 1
        textNoRegistros.Text = 0
        rbTodos.Checked = True
    End Sub


    Private Sub marca_por_tipoper(lista As List(Of Int16))
        For Each fila As DataRow In tbEmple.Rows
            fila("marca") = False
        Next
        Dim tbEmpleTipo As DataTable
        tbEmpleTipo = empleCtr.GetEmpleadosContrato(empresa, lista)
        Dim filas() As DataRow
        Dim contador As Int32 = 0
        For Each fila As DataRow In tbEmpleTipo.Rows
            filas = tbEmple.Select($"empleado={fila("empleado")} and contrato={fila("contrato")}")
            For Each fil2 As DataRow In filas
                fil2("marca") = True
                contador += 1
            Next
        Next
        textNoRegistros.Text = contador
    End Sub



    Private Sub Vista1(ByVal dgVista As DataGridView)
        With dgVista

            .Columns("empleado").HeaderText = "Empleado"
            .Columns("empleado").ReadOnly = True
            .Columns("empleado").FillWeight = 15
            .Columns("nombre").HeaderText = "Nombre"
            .Columns("nombre").FillWeight = 35
            .Columns("nombre").ReadOnly = True
            .Columns("contrato").HeaderText = "Contrato"
            .Columns("contrato").FillWeight = 10
            .Columns("contrato").ReadOnly = True
            .Columns("nombre_puesto").HeaderText = "Puesto"
            .Columns("nombre_puesto").FillWeight = 30
            .Columns("nombre_puesto").ReadOnly = True
            .Columns("marca").HeaderText = "Marca"
            .Columns("marca").FillWeight = 10
            .Columns("tipoper").Visible = False
            'AltoGridView(18, tbFamiliares, 275, 836, dgVista)
        End With
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        lpara.Clear()
        Dim año, mes As Int16
        Dim i, j, dias As Int32
        Dim cantidad, valorNom, por, cantidadI, cantiMov, SueldoEsp As Decimal
        Dim FechaInom, fechaFnom, fechaI As Date
        Dim tipoNom, movimientos, deprestamos As String
        Dim tbMovi As New DataTable("movimientos")
        Dim tbPrestamo As New DataTable("prestamo")
        Dim fTemp2 As DataRow
        If Not validetError(cmbTipo, ep1) Or Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If
        tipoNom = tbTipo.Rows(cmbTipo.SelectedIndex).Item("tiponom") ' Tipo Nomina
        cantidadI = tbTipo.Rows(cmbTipo.SelectedIndex).Item("cantidad") ' Cantidad de Horas que tiene que trabajar por nomina
        por = tbTipo.Rows(cmbTipo.SelectedIndex).Item("por") 'El porcentaje equivalente a su sueldo
        movimientos = tbTipo.Rows(cmbTipo.SelectedIndex).Item("movimientos") 'Si se descuentan moviemientos de movinomina
        deprestamos = tbTipo.Rows(cmbTipo.SelectedIndex).Item("desprestamos") ' Si se descuentan prestamos
        año = CInt(TextAño.Text)
        mes = cmbMes.SelectedIndex + 1
        FechaInom = New Date(año, mes, 1)
        fechaFnom = New Date(año, mes, Date.DaysInMonth(año, mes))
        If MsgBox("ESTA SEGURO QUE DESEA GENERAR ESTA NOMINA", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
            Exit Sub
        End If

        lpara("empresa") = empresa
        lpara("tiponom") = tipoNom
        lpara("mes") = mes
        lpara("año") = año
        lpara("estado") = 0

        cadena = "select count(*) from nomina_registro where estado=0 and empresa=@empresa and tiponom=@tiponom and mes=@mes and año=@año"
        Dim existeNom As Int32 = BuscaEscalar(cadena, ListaParametros(lpara))
        If existeNom > 0 Then
            MsgBox("Nómina ya ha generado pagos, no se puede generar, contacte a su administrador", MsgBoxStyle.Exclamation, "Nominas")
            Exit Sub
        End If

        'Verifica si la nomina esta ya realizada

        cadena = "select count(*) from nominas where empresa=@empresa and mes=@mes and año=@año and tiponom=@tiponom "
        existeNom = BuscaEscalar(cadena, ListaParametros(lpara))

        If existeNom > 0 Then
            If MsgBox("ESTA NOMINA YA HA SIDO GENERADA, DESEA CORRER DE NUEVO EL PROCESO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                Exit Sub
            Else
                lpara("tipodocto") = "N" & tipoNom.Trim
                lpara("docto") = CInt((mes.ToString() & año.ToString()))
                lpara("tiponom") = tipoNom
                lpara("mes") = mes
                lpara("año") = año

                cadena = "select prestamo, abonos from prestamos2 where empresa=@empresa and tipodocto=@tipodocto and docto=@docto and abonos <> 0 and tiponom=@tiponom  and mes=@mes and año=@año"
                llenaTabla(cadena, tbPrestamo, ListaParametros(lpara))
                cadena = "delete prestamos2 where empresa=@empresa and tiponom=@tiponom  and mes=@mes and año=@año"
                EjecutarQuery(cadena, ListaParametros(lpara))
                'Si desea borrarla se anulan los descuentos hechos en los prestamos y se regresa el saldo
                For i = 0 To tbPrestamo.Rows.Count - 1

                    filaTemp = tbPrestamo.Rows(i)

                    lpara("prestamo") = filaTemp.Item("prestamo")
                    lpara("abonos") = filaTemp.Item("abonos")
                    cadena = "update prestamos1 set saldo= (select sum(cargos-abonos) from prestamos2 where prestamo=@prestamo) where empresa=@empresa and prestamo=@prestamo "
                    EjecutarQuery(cadena, ListaParametros(lpara))
                Next i

            End If
            cadena = "delete from nominas where empresa=@empresa and mes=@mes and año=@año and tiponom=@tiponom"
            EjecutarQuery(cadena, ListaParametros(lpara))
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim modelo As New cmodelo
        Dim procesa As Boolean = True
        Try

            'se borra la nomina


            Dim basevaca As Int16 = 0
            If mes = 12 Or mes = 11 Then
                basevaca = 11
            Else
                basevaca = mes
            End If

            lpara("fecha") = fechaFnom
            lpara("basevaca") = basevaca
            cadena = "select c1.contrato, c1.empleado,  c1.fechai, c1.tipoper, c1.tiposeguro, tip.tibase, c1.base , coalesce(tsus.nomina, 'X') as nomina, " &
                     "sue.afecta, sue.transac,  sue.valor as sueldo, tib.horasdia " &
                     "from contratos1 c1 " &
                     "inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                     "inner join tipopersonal tip on tip.empresa=c1.empresa and tip.tipoper=c1.tipoper " &
                     "inner join tiposbase tib on tib.empresa=c1.empresa and tib.id_tbase=tip.id_tbase " &
                     "inner join sueldos sue on c1.empresa =sue.empresa and c1.empleado=sue.empleado and c1.contrato=sue.contrato " &
                     "left join suspensiones su on  su.empresa=c1.empresa and su.empleado=c1.empleado and su.contrato=c1.contrato and su.estado=0 " &
                     "left join tiposuspensiones tsus on tsus.tiposus=su.tiposus " &
                     "where c1.mpago=@tiponom and e.generapago='S' and tip.pagonomina='S' and c1.empresa=@empresa " &
                     " and c1.fechai < @fecha   " &
                     " order by c1.empleado, c1.contrato "
            modelo.llenaTabla(cadena, tbContra1, ListaParametros(lpara))
            PgBar.Maximum = tbContra1.Rows.Count
            Dim cuenta As Short = 0

            For i = 0 To tbContra1.Rows.Count - 1
                PgBar.PerformStep()
                lpara.Clear()
                lpara("empresa") = empresa
                cantidad = 0

                filaTemp = tbContra1.Rows(i)
                If rbTodos.Checked = True Then
                    procesa = True
                Else
                    cuenta = tbEmple.AsEnumerable().Where(Function(x) x.Field(Of Int32)("empleado") = filaTemp("empleado") _
                                                              AndAlso x.Field(Of Int16)("contrato") = filaTemp("contrato") _
                                                              AndAlso x.Field(Of Boolean)("marca") = True).Count
                    If cuenta > 0 Then
                        procesa = True
                    Else
                        procesa = False
                    End If
                End If


                If procesa Then
                    'Importante, aqui revisa las transacciones que están en la tabla de sueldos, las otras transacciones que pudieran estar en movimientos las ve en la otra rutina
                    'La X ser genera si no tiene suspensiones y la S si la el tipo de suspension genera nomina
                    'Esta es una forma de verificar que se le genere nomina a un empleado, de igual manera se necesita que el sueldo sea mayor que 0
                    If (filaTemp.Item("nomina") = "X" Or filaTemp.Item("nomina") = "S") And filaTemp.Item("sueldo") > 0 Then
                        fechaI = FechaInom
                        cantiMov = 0
                        'Si la  tipo de nomina acepta movimientos y la transaccion es afectada por los días,
                        'afecta es que dependiendo el número de días laborados se paga o no se paga
                        lpara("empleado") = filaTemp.Item("empleado")
                        lpara("contrato") = filaTemp.Item("contrato")
                        lpara("transac") = filaTemp.Item("transac")
                        lpara("mes") = mes
                        lpara("año") = año
                        If movimientos = "S" And filaTemp.Item("afecta") = "S" Then
                            cadena = "select coalesce( max( cantidad), 0) from movinomina where empresa=@empresa and empleado=@empleado and contrato=@contrato and transac=@transac and año=@año and mes=@mes "
                            cantiMov = modelo.BuscaEscalar(cadena, ListaParametros(lpara))
                            ' Se obtiene la cantidad maxima de una transacción en los movimientos, por empleado y contrato para un
                            ' mes y año específico
                            'Puede darse el caso que los movimientos sean por valor o por cantidad
                        End If
                        'Si el movimiento es por cantidad
                        If cantiMov > 0 Then
                            'Se revisa si el contrato base del empleado es por horas o por días
                            If filaTemp.Item("tibase") = "D" Then
                                'Si es por días solo se iguala a la cantidad
                                cantidad = cantiMov
                            ElseIf filaTemp.Item("tibase") = "H" Then
                                'Si es por hora agarra la cantidad máxima de Horas por 
                                cantidad = (cantiMov * filaTemp.Item("base")) / cantidadI
                            End If
                            valorNom = (filaTemp.Item("sueldo") / filaTemp.Item("base")) * cantidad * (por / 100)
                            lpara("fecha") = FechaInom
                            cadena = "select p1.prestamo, p1.tipopre,  p1.descuento, p1.saldo, tp.transac from (" &
                                     " select *, cast ( ('01/' + cast (mesini as varchar(2)) + '/' + cast (añoini as varchar(4))) as datetime ) as fechaIni " &
                                     "from prestamos1 ) p1 , tiposprestamo tp " &
                                     "where p1.empresa=tp.empresa and p1.tipopre=tp.tipopre and p1.empresa=@empresa " &
                                     "and p1.estado=0 and contrato=@contrato and empleado=@empleado " &
                                     "and saldo > 0 and @fecha >= fechaIni and tp.transac=@transac"
                            If modelo.llenaTabla(cadena, tbMovi, ListaParametros(lpara)) > 0 Then
                                fTemp2 = tbMovi.Rows(0)
                                lpara("prestamo") = fTemp2.Item("prestamo")
                                cadena = "select sum( cargos-abonos) from prestamos2 where prestamo=@prestamo"
                                Dim valorSaldo = modelo.BuscaEscalar(cadena, ListaParametros(lpara))
                                Dim abono As Decimal = 0
                                If (fTemp2("descuento") > valorSaldo) Then
                                    abono = valorSaldo
                                Else
                                    abono = fTemp2("descuento")
                                End If
                                lpara("tiponom") = tipoNom
                                lpara("abonos") = abono

                                lpara("fecha") = fechaFnom
                                lpara("abonos") = valorNom
                                lpara("docto") = CInt(mes.ToString() & año.ToString())
                                cadena = "insert into prestamos2 (empresa,prestamo,fecha,tipodocto,docto,cargos,abonos,tiponom,mes,año) 
                                      values (@empresa,@prestamo,@fecha,'NM',@docto,0.00,@abonos,@tiponom,@mes,@año)"
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                Dim saldo As Decimal = valorSaldo - abono
                                lpara("saldo") = saldo
                                cadena = "update prestamos1 set saldo=@saldo where empresa=@empresa and prestamo=@prestamo "
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                            End If
                        ElseIf cantiMov = 0 And filaTemp.Item("afecta") = "S" Then
                            fechaI = FechaInom
                            If filaTemp.Item("fechai") > fechaI Then
                                fechaI = filaTemp.Item("fechai")
                                dias = cantidadI - fechaI.Day + 1
                                If filaTemp.Item("tibase") = "D" Then
                                    cantidad = dias
                                ElseIf filaTemp.Item("tibase") = "H" Then
                                    cantidad = (dias * filaTemp.Item("base")) / cantidadI
                                End If
                                valorNom = (filaTemp.Item("sueldo") / filaTemp.Item("base")) * cantidad * (por / 100)
                            Else
                                cantidad = cantidadI
                                valorNom = filaTemp.Item("sueldo") * (por / 100)
                            End If
                        Else
                            cantidad = cantidadI
                            valorNom = filaTemp.Item("sueldo") * (por / 100)
                        End If
                        lpara("fechai") = fechaI
                        lpara("fechaFnom") = fechaFnom
                        lpara("cantidad") = cantidad
                        lpara("valor") = valorNom
                        lpara("tiponom") = tipoNom
                        cadena = "insert into nominas (empresa, tiponom, mes, año, empleado, contrato, fechai, fechaf, transac, cantidad, valor ) 
                              values (@empresa,@tiponom,@mes,@año,@empleado,@contrato,@fechai,@fechaFnom,@transac,@cantidad,@valor)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    End If
                End If



            Next i
            lpara("fecha") = fechaFnom
            lpara("basevaca") = basevaca
            lpara("empresa") = empresa
            lpara("tiponom") = tipoNom
            PgBar.Value = 0

            cadena = "select c1.contrato, c1.empleado,  c1.fechai, c1.tipoper, c1.tiposeguro, tip.tibase, c1.base , coalesce(tsus.nomina, 'X') as nomina, " &
                  " tib.horasdia " &
                  "from contratos1 c1 " &
                  "inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                  "inner join tipopersonal tip on tip.empresa=c1.empresa and tip.tipoper=c1.tipoper " &
                  "inner join tiposbase tib on tib.empresa=c1.empresa and tib.id_tbase=tip.id_tbase " &
                  "left join suspensiones su on  su.empresa=c1.empresa and su.empleado=c1.empleado and su.contrato=c1.contrato and su.estado=0 " &
                  "left join tiposuspensiones tsus on tsus.tiposus=su.tiposus " &
                  "where c1.mpago=@tiponom and e.generapago='S' and tip.pagonomina='S' and c1.empresa=@empresa " &
                  " and c1.fechai < @fecha " &
                  " order by c1.empleado, c1.contrato "
            modelo.llenaTabla(cadena, tbContra1, ListaParametros(lpara))
            PgBar.Maximum = tbContra1.Rows.Count



            For i = 0 To tbContra1.Rows.Count - 1
                PgBar.PerformStep()
                lpara.Clear()
                filaTemp = tbContra1.Rows(i)

                If rbTodos.Checked = True Then
                    procesa = True
                Else
                    cuenta = tbEmple.AsEnumerable().Where(Function(x) x.Field(Of Int32)("empleado") = filaTemp("empleado") _
                                                              AndAlso x.Field(Of Int16)("contrato") = filaTemp("contrato") _
                                                              AndAlso x.Field(Of Boolean)("marca") = True).Count
                    If cuenta > 0 Then
                        procesa = True
                    Else
                        procesa = False
                    End If
                End If

                If procesa Then

                    lpara("empresa") = empresa
                    lpara("empleado") = filaTemp.Item("empleado")
                    lpara("contrato") = filaTemp.Item("contrato")
                    lpara("tiponom") = tipoNom
                    lpara("mes") = mes
                    lpara("año") = año
                    If (filaTemp.Item("nomina") = "X" Or filaTemp.Item("nomina") = "S") Then
                        fechaI = FechaInom
                        fechaI = FechaInom
                        If filaTemp.Item("fechai") > fechaI Then
                            fechaI = filaTemp.Item("fechai")
                        End If
                        If movimientos = "S" Then
                            'Revisa transacciones que no están en la tabla de sueldos
                            cadena = "select movi.transac, t.tipomov, t.formacal, t.factor, movi.cantidad, movi.valor from movinomina movi " &
                                     "inner join tipotran t on t.empresa=movi.empresa and t.transac=movi.transac " &
                                     "where movi.empresa=@empresa and movi.empleado=@empleado and movi.contrato=@contrato and movi.tiponom=@tiponom and año=@año " &
                                     "and mes=@mes and movi.transac not in (select transac from sueldos where empresa=@empresa and empleado=@empleado and contrato=@contrato )"

                            modelo.llenaTabla(cadena, tbMovi, ListaParametros(lpara))

                            For j = 0 To tbMovi.Rows.Count - 1
                                fTemp2 = tbMovi.Rows(j)
                                If fTemp2.Item("tipomov") = "I" And fTemp2.Item("formacal") = "EX" Then
                                    cadena = "select coalesce( sum(valor),0) from sueldos where empresa=@empresa And empleado = @empleado and contrato=@contrato And transac In (Select transac from tipotran where marextras='S')"
                                    SueldoEsp = modelo.BuscaEscalar(cadena, ListaParametros(lpara))
                                    If SueldoEsp > 0 Then
                                        If filaTemp.Item("tibase") = "D" Then
                                            valorNom = (SueldoEsp / (filaTemp.Item("horasDia") * filaTemp.Item("base"))) * fTemp2.Item("factor") * fTemp2.Item("cantidad")
                                        ElseIf filaTemp.Item("tibase") = "H" Then
                                            valorNom = (SueldoEsp / filaTemp.Item("base")) * fTemp2.Item("factor") * fTemp2.Item("cantidad")
                                        End If
                                    End If
                                Else
                                    valorNom = fTemp2.Item("valor")
                                End If
                                lpara("fechai") = fechaI
                                lpara("fechaf") = fechaFnom
                                lpara("transac") = fTemp2.Item("transac")
                                lpara("cantidad") = fTemp2.Item("cantidad")
                                lpara("valorNom") = valorNom
                                lpara("tiponom") = tipoNom
                                If (valorNom > 0) Then

                                    cadena = "insert into nominas (empresa, tiponom, mes, año, empleado, contrato, fechai, fechaf, transac, cantidad, valor ) 
                                      values (@empresa,@tiponom,@mes,@año,@empleado,@contrato,@fechai,@fechaf,@transac,@cantidad,@valorNom)"
                                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                                End If

                            Next j

                        End If
                        If deprestamos = "S" Then
                            lpara("fechainom") = FechaInom
                            cadena = "select p1.prestamo, p1.tipopre,  p1.descuento, tp.transac, sum(p2.cargos-p2.abonos) as saldo, p1.desc_bono14, p1.desc_aguinaldo " &
                                 "from prestamos1  p1 , tiposprestamo tp, prestamos2 p2  " &
                                 "where p1.empresa=tp.empresa and p1.tipopre=tp.tipopre and p1.empresa=@empresa and contrato=@contrato and p1.empresa=p2.empresa and p1.prestamo=p2.prestamo " &
                                 " and empleado=@empleado and @fechainom >= cast( cast(p1.añoini as varchar)  + '-01' + '-' +cast(p1.mesini as varchar) as datetime)  and tp.transac not in " &
                                 " (select transac from movinomina where empresa=@empresa and empleado=@empleado " &
                                 "  and contrato=@contrato and tiponom=@tiponom and año=@año and mes=@mes) and p1.estado=0 group by  p1.prestamo, p1.tipopre,  p1.descuento, tp.transac, p1.desc_bono14, p1.desc_aguinaldo "
                            modelo.llenaTabla(cadena, tbMovi, ListaParametros(lpara))
                            For j = 0 To tbMovi.Rows.Count - 1

                                lpara("empresa") = empresa
                                lpara("tiponom") = tipoNom
                                lpara("mes") = mes
                                lpara("año") = año
                                lpara("empleado") = filaTemp.Item("empleado")
                                lpara("contrato") = filaTemp.Item("contrato")
                                lpara("fechai") = fechaI
                                lpara("fechaf") = fechaFnom
                                lpara("docto") = CInt(mes.ToString() & año.ToString())
                                fTemp2 = tbMovi.Rows(j)


                                lpara("prestamo") = fTemp2.Item("prestamo")
                                cadena = "select sum( cargos-abonos) from prestamos2 where prestamo=@prestamo and empresa=@empresa"
                                Dim valorSaldo = modelo.BuscaEscalar(cadena, ListaParametros(lpara))


                                If valorSaldo < fTemp2.Item("descuento") Then
                                    valorNom = fTemp2.Item("saldo")
                                Else
                                    valorNom = fTemp2.Item("descuento")
                                End If
                                lpara("transac") = fTemp2.Item("transac")
                                lpara("prestamo") = fTemp2.Item("prestamo")
                                lpara("valor") = valorNom
                                If (valorNom > 0) Then

                                    cadena = "insert into prestamos2 (empresa,prestamo,fecha,tipodocto,docto,cargos,abonos,tiponom,mes,año) 
                                      values (@empresa,@prestamo,@fechaf,'NM',@docto,0.00,@valor,@tiponom,@mes,@año)"
                                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                    Dim saldo As Decimal = valorSaldo - valorNom
                                    lpara("saldo") = saldo
                                    cadena = "update prestamos1 set saldo=@saldo where empresa=@empresa and prestamo=@prestamo "
                                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                    cadena = "insert into nominas (empresa, tiponom, mes, año, empleado, contrato, fechai, fechaf, transac, cantidad, valor ) 
                                          values (@empresa,@tiponom,@mes,@año,@empleado,@contrato,@fechai,@fechaf,@transac,0,@valor)"
                                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                                End If

                            Next j
                        End If
                    End If
                End If

            Next i


            lpara("empresa") = empresa

            lpara("tiponom") = tipoNom
            lpara("mes") = mes
            lpara("año") = año

            lpara("fecha") = fechaI
            lpara("fechaf") = fechaFnom
            cadena = "insert into nominas " &
                     "select no.empresa, no.tiponom, no.mes, no.año, no.empleado, no.contrato, no.fechai, no.fechaf, " &
                     "se.transac, 0 as cantidad, ( coalesce( sum(valor), 0) * ( se.por/100)) as valor " &
                     "from nominas no " &
                     "inner join tipotran t on no.empresa=t.empresa and no.transac=t.transac " &
                     "inner join contratos1 c1 on  c1.empresa=no.empresa and c1.contrato=no.contrato and c1.empleado=no.empleado " &
                     "inner join segurosocial se on se.empresa=c1.empresa and se.tiposeguro=c1.tiposeguro " &
                     " where no.empresa=@empresa and mes=@mes and año=@año and tiponom=@tiponom " &
                     " and tipomov='I' and afectaseguro='S' " &
                     " group by no.empresa, no.tiponom, no.mes, no.año, no.empleado, no.contrato, no.fechai, no.fechaf, se.transac, se.por "
            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
            cadena = "insert into nominas " &
                     "select nom.empresa, @tiponom as tiponom, nom.mes, nom.año, nom.empleado, nom.contrato," &
                     "case when c1.fechai > @fecha then c1.fechai else @fecha end as fechai, @fechaf as fechaf, transac, " &
                     "cantidad, valor from nominas nom " &
                     "inner join contratos1 c1 on nom.empresa=c1.empresa and c1.empleado=nom.empleado and c1.contrato=nom.contrato " &
                     "inner join empestados ee on ee.empresa=nom.empresa and ee.estado=c1.estado " &
                     " where ee.generapago='S' and nom.empresa=@empresa and mes=@mes and año=@año and tiponom='A'"
            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
            PgBar.Value = 0


            If modelo.Commit() Then
                InsertBitacora(9, 7, $"Generación de nómina mensual mes {cmbMes.Text} año {TextAño.Text}")
                MsgBox("OPERACION REALIZA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox("Error del sistema: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del sistema")
            modelo.RollBack()
        End Try


        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub



    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub TextAño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextAño.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub btnSel_Click(sender As Object, e As EventArgs) Handles btnSel.Click
        If tbEmple IsNot Nothing Then
            For Each fila As DataRow In tbEmple.Rows
                fila("marca") = True
            Next
        End If
        textNoRegistros.Text = tbEmple.Rows.Count()
    End Sub

    Private Sub btnDesel_Click(sender As Object, e As EventArgs) Handles btnDesel.Click
        If tbEmple IsNot Nothing Then
            For Each fila As DataRow In tbEmple.Rows
                fila("marca") = False
            Next
        End If
        textNoRegistros.Text = "0"
    End Sub

    Private Sub dgvEmpleado_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleado.CellValueChanged
        If e.RowIndex >= 0 AndAlso dgvEmpleado.Rows.Count > 0 AndAlso dgvEmpleado.Columns(e.ColumnIndex).Name.Contains("marca") Then
            Dim valor As Int32 = 0
            If dgvEmpleado.Rows(e.RowIndex).Cells(e.ColumnIndex).Value = True Then
                valor = 1
            Else
                valor = -1
            End If
            Dim total As Int32 = 0
            If Int32.TryParse(textNoRegistros.Text, total) Then
                textNoRegistros.Text = total + valor
            End If
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles textFiltro.TextChanged
        If Not String.IsNullOrEmpty(textFiltro.Text.Trim) Then
            tbEmple.DefaultView.RowFilter = String.Format(" nombre like '%{0}%'", textFiltro.Text.Trim)
        Else
            tbEmple.DefaultView.RowFilter = ""
        End If
    End Sub



    Private Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub

    Private Sub limpiar()
        If tbEmple IsNot Nothing Then
            For Each fila As DataRow In tbEmple.Rows
                fila("marca") = False
            Next
        End If
        textNoRegistros.Text = "0"
        cmbTipo.SelectedIndex = 0
        PgBar.Minimum = 0
        PgBar.Step = 1
        textNoRegistros.Text = 0

    End Sub

    Private Sub rbSeleccion_CheckedChanged(sender As Object, e As EventArgs) Handles rbSeleccion.CheckedChanged, rbTodos.CheckedChanged
        If rbTodos.Checked Then
            pnInfoEmpleado.Visible = False
        Else
            pnInfoEmpleado.Visible = True
        End If

    End Sub

    Private Sub btnApli2_Click(sender As Object, e As EventArgs) Handles btnApli2.Click
        Dim listado = cklbTipoPersonal.CheckedItems
        For Each ele As DataRow In tbEmple.Rows

            For Each ele2 As DataRowView In listado
                If ele("tipoper") = ele2("tipoper") Then
                    ele("marca") = True
                End If

            Next


        Next
        Dim cuenta As Int32 = 0
        For Each ele As DataRow In tbEmple.Rows
            If ele("marca") = True Then
                cuenta += 1
            End If

        Next
        textNoRegistros.Text = cuenta
    End Sub



    Private Sub ofdArchivo_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles ofdArchivo.FileOk
        Dim filePath As String = ofdArchivo.FileName
        Dim lEmpleMarca As New List(Of infoEmple)

        Try
            Dim fileStream As Stream = ofdArchivo.OpenFile()
            Dim linea As String = ""
            Dim empCod As Int32 = 0
            Dim contCod As Short = 0
            Using reader As New StreamReader(fileStream)

                linea = reader.ReadLine()
                While linea IsNot Nothing
                    Dim elementos As String() = linea.Split(",")
                    empCod = 0
                    contCod = 0
                    If elementos.Count = 2 Then
                        If Int32.TryParse(elementos(0), empCod) And Short.TryParse(elementos(1), contCod) Then
                            lEmpleMarca.Add(New infoEmple With {
                            .empleado = empCod,
                            .contrato = contCod
                            })
                        End If
                    End If
                    linea = reader.ReadLine()
                End While
            End Using

            Dim fila As DataRow
            If tbEmple IsNot Nothing And lEmpleMarca.Count > 0 Then

                For Each ele As infoEmple In lEmpleMarca

                    fila = tbEmple.AsEnumerable().Where(Function(x) x.Field(Of Int32)("empleado") = ele.empleado And x.Field(Of Short)("contrato") And x.Field(Of Short)("contrato") = ele.contrato).FirstOrDefault()
                    fila("marca") = True
                Next
            End If
            Dim cuenta As Int32 = 0
            For Each ele As DataRow In tbEmple.Rows
                If ele("marca") = True Then
                    cuenta += 1
                End If
            Next
            textNoRegistros.Text = cuenta
            MsgBox("Archivo cargado con éxito", MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("Error al cargar el archivo de texto" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Structure infoEmple
        Public empleado As Int32
        Public contrato As Short
    End Structure

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnCargaArchivo.Click
        ofdArchivo.Title = "Seleccione el archivo con los empleados"
        ofdArchivo.ShowDialog()
    End Sub

    Private Sub btnFiltroMarcados_Click(sender As Object, e As EventArgs) Handles btnFiltroMarcados.Click
        If tbEmple IsNot Nothing Then
            tbEmple.DefaultView.RowFilter = String.Format(" marca = true")
        End If
    End Sub

    Private Sub btnFiltroTodos_Click(sender As Object, e As EventArgs) Handles btnFiltroTodos.Click
        If tbEmple IsNot Nothing Then
            tbEmple.DefaultView.RowFilter = ""
        End If
    End Sub



    Private Sub btnGenerarArchivo_Click(sender As Object, e As EventArgs) Handles btnGenerarArchivo.Click
        sfdGeneraArchivo.Title = "Genere el archivo con los empleados"
        sfdGeneraArchivo.ShowDialog()
    End Sub

    Private Sub ofdGeneraArchivo_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles sfdGeneraArchivo.FileOk
        Dim filePath As String = sfdGeneraArchivo.FileName
        Dim lEmpleMarca As New List(Of infoEmple)

        Try
            Dim fs As New StreamWriter(sfdGeneraArchivo.FileName)
            Dim linea As String = ""
            Dim empCod As Int32 = 0
            Dim contCod As Short = 0

            For Each ele As DataRow In tbEmple.Rows
                If ele("marca") = True Then
                    fs.WriteLine($"{ele("empleado")},{ele("contrato")}")
                End If
            Next
            fs.Close()
            MsgBox("Archivo generado con éxito", MsgBoxStyle.Exclamation)
        Catch ex As Exception
            MsgBox("Error al generar el archivo de texto" & vbNewLine & ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub


End Class
