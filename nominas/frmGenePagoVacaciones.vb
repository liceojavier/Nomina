Imports System.Data.SqlClient
Imports System.IO
Imports NOMINA.controller

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMGENEPAGOVACACIONES.VB MIEMBRO DE NOMINA.SLN                              **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmGenePagoVacaciones
    Inherits Form
    Dim cadena As String
    Dim tbContra1 As New DataTable("contra1")
    Dim tbTipo As New DataTable("tipo")
    Dim tbTipoPer As New DataTable("tipopersonal")
    Dim tbMeses As New DataTable("meses")
    Dim tbMovimientos As New DataTable("movimientos")
    Dim basevaca, cantvaca As Integer
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim mes As Integer
    Dim lpara As New Dictionary(Of String, Object)

    Dim tt As New DataTable("datos")

    Dim tbEmple As New DataTable
    Friend WithEvents btnLimpiar As Button
    Friend WithEvents rbSeleccion As RadioButton
    Friend WithEvents rbTodos As RadioButton
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
    Friend WithEvents gpFecha As System.Windows.Forms.GroupBox
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextMoneEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents PgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents cklbTipoPersonal As System.Windows.Forms.CheckedListBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextAño As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents pnInfoEmpleado As Panel
    Friend WithEvents btnGenerarArchivo As Button
    Friend WithEvents btnFiltroTodos As Button
    Friend WithEvents btnFiltroMarcados As Button
    Friend WithEvents btnCargaArchivo As Button
    Friend WithEvents btnApli2 As Button
    Friend WithEvents cklbTipoPersonal2 As CheckedListBox
    Friend WithEvents textFiltro As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents textNoRegistros As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDesel As Button
    Friend WithEvents btnSel As Button
    Friend WithEvents dgvEmpleado As DataGridView
    Friend WithEvents sfdGeneraArchivo As SaveFileDialog
    Friend WithEvents ofdArchivo As OpenFileDialog
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGenePagoVacaciones))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.rbSeleccion = New System.Windows.Forms.RadioButton()
        Me.rbTodos = New System.Windows.Forms.RadioButton()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cklbTipoPersonal = New System.Windows.Forms.CheckedListBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextMoneEmpresa = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.PgBar = New System.Windows.Forms.ProgressBar()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.pnInfoEmpleado = New System.Windows.Forms.Panel()
        Me.btnGenerarArchivo = New System.Windows.Forms.Button()
        Me.btnFiltroTodos = New System.Windows.Forms.Button()
        Me.btnFiltroMarcados = New System.Windows.Forms.Button()
        Me.btnCargaArchivo = New System.Windows.Forms.Button()
        Me.btnApli2 = New System.Windows.Forms.Button()
        Me.cklbTipoPersonal2 = New System.Windows.Forms.CheckedListBox()
        Me.textFiltro = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.textNoRegistros = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDesel = New System.Windows.Forms.Button()
        Me.btnSel = New System.Windows.Forms.Button()
        Me.dgvEmpleado = New System.Windows.Forms.DataGridView()
        Me.sfdGeneraArchivo = New System.Windows.Forms.SaveFileDialog()
        Me.ofdArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.gpFecha.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.pnInfoEmpleado.SuspendLayout()
        CType(Me.dgvEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpFecha
        '
        Me.gpFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.gpFecha.Controls.Add(Me.rbSeleccion)
        Me.gpFecha.Controls.Add(Me.rbTodos)
        Me.gpFecha.Controls.Add(Me.btnLimpiar)
        Me.gpFecha.Controls.Add(Me.cmbMes)
        Me.gpFecha.Controls.Add(Me.Label6)
        Me.gpFecha.Controls.Add(Me.Label4)
        Me.gpFecha.Controls.Add(Me.Label3)
        Me.gpFecha.Controls.Add(Me.cklbTipoPersonal)
        Me.gpFecha.Controls.Add(Me.cmbTipo)
        Me.gpFecha.Controls.Add(Me.TextAño)
        Me.gpFecha.Controls.Add(Me.btnEjecutar)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.Location = New System.Drawing.Point(8, 60)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(908, 108)
        Me.gpFecha.TabIndex = 1
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "TIPO Y PERIODO"
        '
        'rbSeleccion
        '
        Me.rbSeleccion.AutoSize = True
        Me.rbSeleccion.Location = New System.Drawing.Point(431, 41)
        Me.rbSeleccion.Name = "rbSeleccion"
        Me.rbSeleccion.Size = New System.Drawing.Size(130, 17)
        Me.rbSeleccion.TabIndex = 91
        Me.rbSeleccion.TabStop = True
        Me.rbSeleccion.Text = "Seleccionar empleado"
        Me.rbSeleccion.UseVisualStyleBackColor = True
        '
        'rbTodos
        '
        Me.rbTodos.AutoSize = True
        Me.rbTodos.Location = New System.Drawing.Point(431, 18)
        Me.rbTodos.Name = "rbTodos"
        Me.rbTodos.Size = New System.Drawing.Size(55, 17)
        Me.rbTodos.TabIndex = 90
        Me.rbTodos.TabStop = True
        Me.rbTodos.Text = "Todos"
        Me.rbTodos.UseVisualStyleBackColor = True
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(764, 54)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(102, 30)
        Me.btnLimpiar.TabIndex = 89
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
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(224, 37)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(121, 21)
        Me.cmbMes.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(352, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Año:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(223, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Mes:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(564, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Tipo de personal:"
        '
        'cklbTipoPersonal
        '
        Me.cklbTipoPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cklbTipoPersonal.FormattingEnabled = True
        Me.cklbTipoPersonal.Location = New System.Drawing.Point(567, 37)
        Me.cklbTipoPersonal.Name = "cklbTipoPersonal"
        Me.cklbTipoPersonal.Size = New System.Drawing.Size(191, 64)
        Me.cklbTipoPersonal.TabIndex = 6
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(10, 37)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(208, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'TextAño
        '
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(351, 37)
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
        Me.btnEjecutar.Location = New System.Drawing.Point(763, 17)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(80, 30)
        Me.btnEjecutar.TabIndex = 4
        Me.btnEjecutar.Text = "Generar"
        Me.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEjecutar, "Generar el proceso")
        Me.btnEjecutar.UseVisualStyleBackColor = False
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
        Me.gpEmpresa.Location = New System.Drawing.Point(236, 1)
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
        Me.Label10.Location = New System.Drawing.Point(344, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
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
        Me.PgBar.Location = New System.Drawing.Point(7, 6)
        Me.PgBar.Name = "PgBar"
        Me.PgBar.Size = New System.Drawing.Size(914, 23)
        Me.PgBar.TabIndex = 70
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(928, 55)
        Me.Panel1.TabIndex = 72
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PgBar)
        Me.Panel2.Location = New System.Drawing.Point(0, 503)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(928, 39)
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
        Me.pnInfoEmpleado.Controls.Add(Me.cklbTipoPersonal2)
        Me.pnInfoEmpleado.Controls.Add(Me.textFiltro)
        Me.pnInfoEmpleado.Controls.Add(Me.Label5)
        Me.pnInfoEmpleado.Controls.Add(Me.textNoRegistros)
        Me.pnInfoEmpleado.Controls.Add(Me.Label1)
        Me.pnInfoEmpleado.Controls.Add(Me.btnDesel)
        Me.pnInfoEmpleado.Controls.Add(Me.btnSel)
        Me.pnInfoEmpleado.Controls.Add(Me.dgvEmpleado)
        Me.pnInfoEmpleado.Location = New System.Drawing.Point(12, 174)
        Me.pnInfoEmpleado.Name = "pnInfoEmpleado"
        Me.pnInfoEmpleado.Size = New System.Drawing.Size(897, 323)
        Me.pnInfoEmpleado.TabIndex = 75
        '
        'btnGenerarArchivo
        '
        Me.btnGenerarArchivo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGenerarArchivo.Location = New System.Drawing.Point(437, 260)
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
        Me.btnCargaArchivo.Location = New System.Drawing.Point(437, 289)
        Me.btnCargaArchivo.Name = "btnCargaArchivo"
        Me.btnCargaArchivo.Size = New System.Drawing.Size(95, 23)
        Me.btnCargaArchivo.TabIndex = 90
        Me.btnCargaArchivo.Text = "Carga Archivo"
        Me.btnCargaArchivo.UseVisualStyleBackColor = True
        '
        'btnApli2
        '
        Me.btnApli2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnApli2.Location = New System.Drawing.Point(379, 289)
        Me.btnApli2.Name = "btnApli2"
        Me.btnApli2.Size = New System.Drawing.Size(57, 23)
        Me.btnApli2.TabIndex = 89
        Me.btnApli2.Text = "Aplicar"
        Me.btnApli2.UseVisualStyleBackColor = True
        '
        'cklbTipoPersonal2
        '
        Me.cklbTipoPersonal2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cklbTipoPersonal2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cklbTipoPersonal2.FormattingEnabled = True
        Me.cklbTipoPersonal2.Location = New System.Drawing.Point(185, 248)
        Me.cklbTipoPersonal2.Name = "cklbTipoPersonal2"
        Me.cklbTipoPersonal2.Size = New System.Drawing.Size(191, 64)
        Me.cklbTipoPersonal2.TabIndex = 88
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
        Me.textNoRegistros.Location = New System.Drawing.Point(659, 287)
        Me.textNoRegistros.Name = "textNoRegistros"
        Me.textNoRegistros.Size = New System.Drawing.Size(125, 24)
        Me.textNoRegistros.TabIndex = 85
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(581, 289)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "No. Registros:"
        '
        'btnDesel
        '
        Me.btnDesel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDesel.Location = New System.Drawing.Point(95, 263)
        Me.btnDesel.Name = "btnDesel"
        Me.btnDesel.Size = New System.Drawing.Size(84, 49)
        Me.btnDesel.TabIndex = 83
        Me.btnDesel.Text = "Deseleccionar a todos"
        Me.btnDesel.UseVisualStyleBackColor = True
        '
        'btnSel
        '
        Me.btnSel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSel.Location = New System.Drawing.Point(9, 263)
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
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.dgvEmpleado.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvEmpleado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvEmpleado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvEmpleado.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.dgvEmpleado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpleado.Location = New System.Drawing.Point(9, 33)
        Me.dgvEmpleado.Name = "dgvEmpleado"
        Me.dgvEmpleado.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmpleado.Size = New System.Drawing.Size(829, 212)
        Me.dgvEmpleado.TabIndex = 81
        '
        'sfdGeneraArchivo
        '
        Me.sfdGeneraArchivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"""
        '
        'ofdArchivo
        '
        Me.ofdArchivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"""
        '
        'frmGenePagoVacaciones
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(928, 542)
        Me.Controls.Add(Me.pnInfoEmpleado)
        Me.Controls.Add(Me.gpFecha)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmGenePagoVacaciones"
        Me.Text = " "
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.pnInfoEmpleado.ResumeLayout(False)
        Me.pnInfoEmpleado.PerformLayout()
        CType(Me.dgvEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Integer
        lpara.Clear()
        lpara("empresa") = empresa
        cadena = "select nombre from meses order by mes"
        llena_combo(cadena, cmbMes)
        llenaTabla(cadena, tbMeses)
        TextAño.Text = System.DateTime.Now.Year
        EscribeEmpresa(TextNombEmpresa, TextMoneEmpresa)
        cadena = "select nombre, tiponom, cantidad, por, movimientos, desprestamos from tiponomina1 where empresa=@empresa and ( tiponom='V' or tiponom='W' or tiponom='X')"
        llena_combo(cadena, cmbTipo, ListaParametros(lpara))
        llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        cmbTipo.Items.Add("")
        cmbTipo.SelectedIndex = 0
        cadena = "select nombre, tibase, basevaca, cantvaca, tipoper from tipopersonal where empresa=@empresa and prestaciones='S' and pagonomina='S'"
        llenaTabla(cadena, tbTipoPer, ListaParametros(lpara))
        cklbTipoPersonal.Items.Clear()
        For i = 0 To tbTipoPer.Rows.Count - 1
            filaTemp = tbTipoPer.Rows(i)
            cklbTipoPersonal.Items.Add(filaTemp.Item(0))
        Next i


        cadena = "select a.nombre, a.tibase, a.basevaca, a.cantvaca, a.tipoper from tipopersonal a
                 where a.empresa=@empresa and a.prestaciones='S' and a.pagonomina='S'"
        llenaTabla(cadena, tbTipoPer, ListaParametros(lpara))
        cklbTipoPersonal2.DataSource = tbTipoPer
        cklbTipoPersonal2.DisplayMember = "nombre"

        tbEmple = empleCtr.GetEmpleadosContrato(empresa)
        tbEmple.Columns.Add("marca", Type.GetType("System.Boolean"))
        For Each fila As DataRow In tbEmple.Rows
            fila("marca") = False
        Next
        tbEmple.Columns("marca").AllowDBNull = False
        dgvEmpleado.DataSource = tbEmple
        Vista1(dgvEmpleado)

        textNoRegistros.Text = 0
        rbTodos.Checked = True


        cmbTipo.SelectedIndex = 0
        PgBar.Minimum = 0
        PgBar.Step = 1
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

    Private Sub cklbTipoPersonal_ItemCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.ItemCheckEventArgs) Handles cklbTipoPersonal.ItemCheck
        Dim Elemento, baseAct, cantAct As Int32
        Elemento = CuantosMarcados(False)
        If Elemento = 0 Then
            basevaca = tbTipoPer.Rows(e.Index).Item(2)
            cantvaca = tbTipoPer.Rows(e.Index).Item(3)
        ElseIf Elemento = 1 Then
            If e.CurrentValue = CheckState.Checked Then
                basevaca = 0
                cantvaca = 0
            Else
                baseAct = tbTipoPer.Rows(e.Index).Item(2)
                cantAct = tbTipoPer.Rows(e.Index).Item(3)
                If baseAct <> basevaca Or cantAct <> cantvaca Then
                    MsgBox("TIPOS DE PERSONAL SELECCIONADOS NO TIENEN LA MISMA BASE DE CALCULO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    cklbTipoPersonal.SetItemChecked(e.Index, False)
                    e.NewValue = CheckState.Unchecked
                End If
            End If
        ElseIf Elemento > 1 Then
            baseAct = tbTipoPer.Rows(e.Index).Item(2)
            cantAct = tbTipoPer.Rows(e.Index).Item(3)
            If baseAct <> basevaca Or cantAct <> cantvaca Then
                MsgBox("TIPOS DE PERSONAL SELECCIONADOS NO TIENEN LA MISMA BASE DE CALCULO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                cklbTipoPersonal.SetItemChecked(e.Index, False)
                e.NewValue = CheckState.Unchecked
            End If
        End If
    End Sub

    Private Function CuantosMarcados(ByVal valBool As Boolean) As Integer
        Dim i, contador As Integer
        contador = 0
        For i = 0 To cklbTipoPersonal.Items.Count - 1
            If cklbTipoPersonal.GetItemCheckState(i) = CheckState.Checked Then
                contador = contador + 1
                If valBool = True And contador = 1 Then
                    Return i
                End If
            End If
        Next i
        Return contador
    End Function


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        Dim i, mesi, mesf, año As Int32
        Dim por As Decimal
        Dim FechaInom, fechaFnom As Date
        Dim cantidad As Int32 = 0
        Dim tipoNom, movimientos, deprestamos, consTipoPer As String
        Dim transacV, transacS, transacA, transacVB, transacVacBono As String
        Dim tbPrestamo As New DataTable("prestamos")
        Dim tbTipoBono As New DataTable
        Dim tbtipobono2 As New DataTable
        transacVB = ""
        transacVacBono = ""
        lpara.Clear()
        If CuantosMarcados(False) = 0 Then
            MsgBox("DEBE SELECCIONAR UN TIPO DE PERSONAL", MsgBoxStyle.Information, "Mensaje del Sistema")
            ep1.SetError(cklbTipoPersonal, "SELECCIONE UN TIPO DE PERSONAL")
            Exit Sub
        Else
            ep1.SetError(cklbTipoPersonal, "")
        End If

        If Not validetError(cmbTipo, ep1) Or Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        consTipoPer = ""
        For i = 0 To cklbTipoPersonal.Items.Count - 1
            If cklbTipoPersonal.GetItemCheckState(i) = CheckState.Checked Then
                consTipoPer = consTipoPer & tbTipoPer.Rows(i).Item("tipoper") & ","
            End If
        Next i
        consTipoPer = consTipoPer.Substring(0, consTipoPer.Length - 1)

        mes = cmbMes.SelectedIndex + 1
        tipoNom = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
        cantidad = tbTipo.Rows(cmbTipo.SelectedIndex).Item(2)
        por = tbTipo.Rows(cmbTipo.SelectedIndex).Item(3)
        movimientos = tbTipo.Rows(cmbTipo.SelectedIndex).Item(4)
        deprestamos = tbTipo.Rows(cmbTipo.SelectedIndex).Item(5)
        año = CInt(TextAño.Text)
        FechaInom = "01/01/" & año
        fechaFnom = Date.DaysInMonth(año, mes) & "/" & mes & "/" & año
        mesi = 1
        mesf = mes
        If MsgBox("ESTA SEGURO QUE DESEA GENERAR ESTA NOMINA", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
            Exit Sub
        End If

        'cn.Close()
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

        cadena = "select count(*) from nominas where empresa=@empresa and mes=@mes and año=@año and tiponom=@tiponom "
        If BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
            If MsgBox("ESTA NOMINA YA HA SIDO GENERADA, DESEA CORRER DE NUEVO EL PROCESO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                Exit Sub
            Else
                lpara("tipodocto") = "N" & tipoNom.Trim
                lpara("docto") = CInt((mes.ToString() & año.ToString()))
                lpara("tiponom") = tipoNom
                lpara("mes") = mes
                lpara("año") = año

                cadena = "select prestamo, abonos from prestamos2 where empresa=@empresa and abonos <> 0 and tiponom=@tiponom  and mes=@mes and año=@año"
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
        End If

        cadena = "delete from nominas where empresa=@empresa and mes=@mes and año=@año and tiponom=@tiponom "
        EjecutarQuery(cadena, ListaParametros(lpara))



        transacV = BuscaEscalar(" select coalesce( max( transacnom), 0) from tiponomina3 where empresa=@empresa and tiponom=@tiponom and tipocal='V'", ListaParametros(lpara))
        transacA = BuscaEscalar(" select coalesce( max( transacnom), 0) from tiponomina3 where empresa=@empresa And tipoNom =@tiponom and tipocal='A'", ListaParametros(lpara))
        transacS = BuscaEscalar(" select coalesce( max( transacnom), 0) from tiponomina3 where empresa=@empresa And tipoNom =@tiponom and tipocal='S'", ListaParametros(lpara))
        Select Case tipoNom
            Case "O", "W"
                If transacV = 0 Then

                End If
            Case "X"
                If transacV = 0 Or transacA = 0 Then
                    MsgBox("NO HA INGRESADO ALGUNA DE LAS TRANSACCIONES CON LAS CUALES SE GUARDARAN EL SUELDO, VACACIONES O AGUINALDO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    Exit Sub
                End If
            Case "V"
                If transacV = 0 Or transacA = 0 Or transacS = 0 Then
                    MsgBox("NO HA INGRESADO ALGUNA DE LAS TRANSACCIONES CON LAS CUALES SE GUARDARAN EL SUELDO, VACACIONES O AGUINALDO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    Exit Sub
                End If
        End Select

        If tipoNom = "V" Or tipoNom = "X" Then
            transacVB = BuscaEscalar(" select coalesce( max( transacnom), 0) from tiponomina3 where empresa=" & empresa & " and tiponom='O' and tipocal='V'")
            If transacVB = "" Then
                MsgBox("NO HA INGRESADO LA TRANSACCION DEL BONO VACACIONAL", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End If
        End If

        transacVacBono = BuscaEscalar(" select coalesce( max( transacnom), 0) from tiponomina3 where empresa=@empresa and tiponom='Z'", ListaParametros(lpara))
        If transacVacBono = "" Then
            MsgBox("NO HA INGRESADO LA TRANSACCION DEL BONO AUMENTO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim cm As New cmodelo
        Try




            EscribeCampos(año, mesi, mesf, tipoNom, FechaInom, fechaFnom, consTipoPer, movimientos, deprestamos, por, tipoNom, transacV, transacA, transacS, cantidad, FechaInom, fechaFnom, cm)
            If tipoNom = "V" Or tipoNom = "X" Then
                cadena = "select nombre, tiponom, cantidad, por, movimientos, desprestamos from tiponomina1 where empresa=@empresa and  tiponom='O'"
                If llenaTabla(cadena, tbTipoBono, ListaParametros(lpara)) > 0 Then
                    por = tbTipoBono.Rows(0).Item(3)
                    movimientos = tbTipoBono.Rows(0).Item(4)
                    deprestamos = tbTipoBono.Rows(0).Item(5)
                    EscribeCampos(año, mesi, mesf, "O", FechaInom, fechaFnom, consTipoPer, movimientos, deprestamos, por, tipoNom, transacVB, transacA, transacS, cantidad, FechaInom, fechaFnom, cm)

                End If

            End If

            cadena = "select nombre, tiponom, cantidad, por, movimientos, desprestamos from tiponomina1 where empresa=@empresa and  tiponom='Z'"
            If llenaTabla(cadena, tbtipobono2, ListaParametros(lpara)) > 0 Then
                por = tbtipobono2.Rows(0).Item(3)
                movimientos = tbtipobono2.Rows(0).Item(4)
                deprestamos = tbtipobono2.Rows(0).Item(5)
                EscribeCampos(año, mesi, mesf, "Z", FechaInom, fechaFnom, consTipoPer, movimientos, deprestamos, por, tipoNom, transacVacBono, transacA, transacS, cantidad, FechaInom, fechaFnom, cm)

            End If

            CalculoValSeguroSocial(mes, año, tipoNom, cm)
            If cm.Commit() Then
                InsertBitacora(9, 7, $"Generación de nominas personalizada de {cmbTipo.Text} mes {cmbMes.Text} año {TextAño.Text}")
                MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            End If

        Catch ex As Exception
            cm.RollBack()
            MsgBox($"Error al generar la nómina de {cmbTipo.Text.Trim} mes {cmbMes.Text} año {año} " & vbNewLine & ex.Message, MsgBoxStyle.Critical)
            MsgBox(ex.StackTrace, MsgBoxStyle.Critical)
        End Try



        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmbMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub EscribeCampos(ByVal año As Int16, ByVal mesi As Int16, ByVal mesf As Int16, ByVal tiponom As String,
    ByVal fechaInom As Date, ByVal fechaFnom As Date, ByVal constipoPer As String, ByVal movimientos As String,
    ByVal deprestamos As String, ByVal por As Decimal, ByVal tiponomEs As String, ByVal transacV As String,
    ByVal transacA As String, ByVal transacS As String, ByVal cantidad As Int32, fechaInicial As DateTime,
        fechaFinal As DateTime, cm As cmodelo)
        lpara.Clear()
        Dim sueldoEsp As Decimal = 0
        Dim fechaI As Date
        Dim mesftem, i, j, difMeses, DifDias, CantDias, MesesVaca, cantDiasDif As Int32
        Dim valorT, promedio, valorNom, valorNomEs, diferenciaVa, sueldosV As Decimal
        Dim tbMovi As New DataTable("movimientos")
        Dim tbPrestamo As New DataTable("prestamo")
        Dim valorMovi As Decimal = 0
        Dim fTemp2 As DataRow
        Dim procesa As Boolean
        Dim cuenta As Int32

        If mesf = 12 And constipoPer = 1 Then
            mesftem = 10
        Else
            mesftem = 11
        End If

        lpara("empresa") = empresa
        lpara("año") = año
        lpara("tiponom") = tiponom
        lpara("fechai") = fechaInicial
        lpara("fechaf") = fechaFinal
        cadena = "select c1.contrato, c1.empleado,  c1.fechai, c1.tipoper, c1.tiposeguro, tip.tibase, c1.base , " &
                  "( select coalesce( sum( valor),0) from nominas nom where nom.empresa=c1.empresa and " &
                  "nom.empleado=c1.empleado and nom.contrato=c1.contrato " &
                  " and  año=@año and mes between " & mesi & " and " & mesftem &
                  " and transac in ( select transac from tiponomina2 t2 where t2.extranomina='N' and t2.empresa=c1.empresa and t2.tiponom='" & tiponom &
                  "') ) as valorNomina, " &
                  "(select  coalesce( sum(valor),0) from extra1 e1 inner join extra2 e2 on " &
                  "e1.empresa = e2.empresa And e1.cheque = e2.cheque And e1.banco = e2.banco " &
                  "where e1.estado <> 1 and  e1.empresa=c1.empresa and fecha between '" & fechaInicial &
                  "' and '" & fechaFinal & "' and empleado=c1.empleado and contrato=c1.contrato and " &
                  "transac in ( select transac from tiponomina2 t2 where " &
                  "t2.empresa=c1.empresa and t2.tiponom=@tiponom)) as valExtra, " &
                  "(select coalesce( sum(valor),0) from suspensiones su where estado =2 and " &
                  "empresa=c1.empresa and empleado=c1.empleado and contrato=c1.contrato " &
                  "and fechai>=@fechai and fechaf <=@fechaf) as valSuspensiones,  " &
                  " coalesce(tsus.nomina, 'X') as nominaSus,  tib.horasdia  " &
                  "from contratos1 c1 " &
                  "inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                  "inner join tipopersonal tip on tip.empresa=c1.empresa and tip.tipoper=c1.tipoper " &
                  "inner join tiposbase tib on tib.empresa=c1.empresa and tib.id_tbase=tip.id_tbase " &
                  "left join suspensiones su on  su.empresa=c1.empresa and su.empleado=c1.empleado and su.contrato=c1.contrato and su.estado=0 " &
                  "left join tiposuspensiones tsus on tsus.tiposus=su.tiposus " &
                  "where tip.pagonomina='S' and tip.prestaciones='S' and e.generapago='S' and c1.empresa=@empresa and c1.fechai <=@fechaf and c1.tipoper in (" & constipoPer & ") order by c1.empleado"
        cm.llenaTabla(cadena, tbContra1, ListaParametros(lpara))
        PgBar.Maximum = tbContra1.Rows.Count
        For i = 0 To tbContra1.Rows.Count - 1
            valorMovi = 0
            PgBar.PerformStep()
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
                If tiponom <> "O" And tiponom <> "Z" Then
                    valorT = filaTemp.Item("valorNomina") + filaTemp.Item("valExtra") + filaTemp.Item("valSuspensiones")
                Else
                    If tiponom = "Z" Or tiponom = "O" Then
                        valorT = filaTemp.Item("valorNomina") + filaTemp.Item("valExtra")
                    Else
                        valorT = filaTemp.Item("valorNomina")
                    End If
                End If
                If (filaTemp.Item("nominaSus") = "X" Or filaTemp.Item("nominaSus") = "S") And valorT > 0 Then
                    '     If filaTemp.Item("empleado") = 1142 Then
                    'MsgBox("Parar")
                    ' End If

                    fechaI = fechaInom
                    If filaTemp.Item("fechai") > fechaI Then
                        fechaI = filaTemp.Item("fechai")
                    End If
                    If fechaI > fechaInom Then
                        difMeses = basevaca - CDate(filaTemp.Item("fechai")).Month
                        DifDias = 30 - CDate(filaTemp.Item("fechai")).Day + 1
                        CantDias = (difMeses * 30) + DifDias
                        promedio = valorT / CantDias
                        valorNom = (CantDias / basevaca) * promedio
                    Else
                        CantDias = cantidad - cantvaca
                        valorNom = valorT / basevaca
                    End If
                    MesesVaca = 12 - basevaca
                    diferenciaVa = 0
                    If MesesVaca = 2 Then
                        'If tiponom = "O" And tiponomEs = "X" Then
                        If tiponom = "O" Then
                            valorNomEs = valorNom
                        Else
                            valorNomEs = valorNom
                        End If
                    Else
                        If tiponom = "O" Then
                            valorNomEs = valorNom
                            diferenciaVa = 0
                        Else
                            valorNomEs = valorNom
                            If fechaI > fechaInom Then
                                diferenciaVa = (promedio * 30) - valorNom
                            Else
                                diferenciaVa = 0
                            End If
                        End If
                    End If
                    lpara("tiponomEs") = tiponomEs
                    lpara("mes") = mes
                    lpara("empleado") = filaTemp.Item("empleado")
                    lpara("contrato") = filaTemp.Item("contrato")
                    lpara("fechai") = fechaI
                    lpara("fechaf") = fechaFnom
                    lpara("transac") = transacV
                    lpara("cantidad") = CantDias
                    lpara("valor") = valorNomEs
                    cadena = "insert into nominas (empresa, tiponom, mes, año, empleado, contrato, fechai, fechaf, transac, cantidad, valor ) 
                          values (@empresa,@tiponomEs,@mes,@año,@empleado,@contrato,@fechai,@fechaf,@transac,@cantidad,@valor)"
                    cm.EjecutarNonQuery(cadena, ListaParametros(lpara))

                    If diferenciaVa > 0 Then
                        'Se inserta la diferencia de vacaciones
                        cantDiasDif = (diferenciaVa * 30) / (valorNomEs + diferenciaVa)
                        lpara("transacS") = transacS
                        lpara("cantDiasDif") = cantDiasDif
                        lpara("diferencia") = diferenciaVa
                        cadena = "insert into nominas (empresa, tiponom, mes, año, empleado, contrato, fechai, fechaf, transac, cantidad, valor ) 
                              values (@empresa,@tiponomEs,@mes,@año,@empleado,@contrato,@fechai,@fechaf,@transacS,@cantDiasDif,@diferencia)"
                        cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    End If
                    If tiponom = "V" Or tiponom = "X" Then
                        'Se inserta el aguinaldo
                        cadena = "select coalesce ( sum( valor ) ,0 ) from sueldos su where su.empresa=@empresa and su.empleado=@empleado and contrato=@contrato and transac in ( select tip2.transac from tiponomina2 tip2 inner join tipotran t on " &
                                 "tip2.empresa=t.empresa and tip2.transac=t.transac where tip2.tiponom=@tiponom and t.empresa=@empresa and formacal='FM' )"
                        sueldosV = cm.BuscaEscalar(cadena, ListaParametros(lpara))
                        sueldosV = sueldosV * (CantDias / (basevaca * 30))

                        lpara("transacA") = transacA
                        lpara("sueldosV") = sueldosV
                        cadena = "insert into nominas (empresa, tiponom, mes, año, empleado, contrato, fechai, fechaf, transac, cantidad, valor ) 
                              values (@empresa,@tiponomEs,@mes,@año,@empleado,@contrato,@fechai,@fechaf,@transacA,@cantidad,@sueldosV)"
                        cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    End If
                    If movimientos = "S" Then
                        cadena = "select t.tipomov, t.formacal,t.factor, t.transac, mov.cantidad,  mov.valor as valor from movinomina mov inner join tipotran t on " &
                                " mov.empresa = t.empresa And mov.transac = t.transac where mov.empresa=@empresa " &
                                " and empleado=@empleado and contrato=@contrato " &
                                " and mes=@mes and año=@año  "
                        cm.llenaTabla(cadena, tbMovimientos, ListaParametros(lpara))
                        For j = 0 To tbMovimientos.Rows.Count - 1
                            fTemp2 = tbMovimientos.Rows(j)
                            valorMovi = 0
                            If fTemp2.Item("tipomov") = "I" And fTemp2.Item("formacal") = "EX" Then
                                cadena = "select coalesce( sum(valor),0) from sueldos where empresa=@empresa And empleado = @empleado and contrato=@contrato 
                                    And transac In (Select transac from tipotran where marextras='S')"
                                sueldoEsp = modelo.BuscaEscalar(cadena, ListaParametros(lpara))
                                If sueldoEsp > 0 Then
                                    If filaTemp.Item("tibase") = "D" Then
                                        valorMovi = (sueldoEsp / (filaTemp.Item("horasDia") * filaTemp.Item("base"))) * fTemp2.Item("factor") * fTemp2.Item("cantidad")
                                    ElseIf filaTemp.Item("tibase") = "H" Then
                                        valorMovi = (sueldoEsp / filaTemp.Item("base")) * fTemp2.Item("factor") * fTemp2.Item("cantidad")
                                    End If
                                End If
                            Else
                                valorMovi = fTemp2.Item("valor")
                            End If

                            lpara.Clear()
                            lpara("empresa") = empresa
                            lpara("tiponom") = tiponomEs
                            lpara("mes") = mes
                            lpara("año") = año

                            lpara("empleado") = filaTemp.Item("empleado")
                            lpara("contrato") = filaTemp.Item("contrato")
                            lpara("fechai") = fechaI
                            lpara("fechaf") = fechaFnom
                            lpara("transac") = fTemp2.Item("transac")
                            lpara("valor") = valorMovi

                            If valorMovi > 0 Then
                                cadena = "insert into nominas (empresa, tiponom, mes, año, empleado, contrato, fechai, fechaf, transac, cantidad, valor ) 
                                      values (@empresa,@tiponom,@mes,@año,@empleado,@contrato,@fechai,@fechaf,@transac,0,@valor)"
                                cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                            End If
                        Next j
                    End If
                    If deprestamos = "S" Then





                        lpara("empleado") = filaTemp.Item("empleado")
                        lpara("fechainom") = New DateTime(año, mes, 1)
                        cadena = "select p1.prestamo, p1.tipopre,  p1.descuento, tp.transac, sum(p2.cargos-p2.abonos) as saldo, p1.desc_bono14, p1.desc_aguinaldo " &
                                     "from prestamos1  p1 , tiposprestamo tp, prestamos2 p2  " &
                                     "where p1.empresa=tp.empresa and p1.tipopre=tp.tipopre and p1.empresa=@empresa and contrato=@contrato and p1.empresa=p2.empresa and p1.prestamo=p2.prestamo " &
                                     " and empleado=@empleado and @fechainom >= cast( cast(p1.añoini as varchar)  + '-01' + '-' +cast(p1.mesini as varchar) as datetime)  and tp.transac not in " &
                                     " (select transac from movinomina where empresa=@empresa and empleado=@empleado " &
                                     "  and contrato=@contrato and tiponom=@tiponom and año=@año and mes=@mes) and p1.estado=0 group by  p1.prestamo, p1.tipopre,  p1.descuento, tp.transac, p1.desc_bono14, p1.desc_aguinaldo "
                        cm.llenaTabla(cadena, tbMovi, ListaParametros(lpara))
                        For j = 0 To tbMovi.Rows.Count - 1

                            lpara("empresa") = empresa
                            lpara("tiponom") = tiponom
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
                            Dim valorSaldo = cm.BuscaEscalar(cadena, ListaParametros(lpara))

                            If mes = 12 Then
                                If valorSaldo < fTemp2.Item("descuento") + fTemp2("desc_aguinaldo") Then
                                    valorNom = fTemp2.Item("saldo")
                                Else
                                    valorNom = fTemp2.Item("descuento") + fTemp2("desc_aguinaldo")
                                End If
                            Else
                                If valorSaldo < fTemp2.Item("descuento") Then
                                    valorNom = fTemp2.Item("saldo")
                                Else
                                    valorNom = fTemp2.Item("descuento")
                                End If

                            End If


                            lpara("tipodocto") = "N" + tiponomEs.Trim
                            lpara("transac") = fTemp2.Item("transac")
                            lpara("prestamo") = fTemp2.Item("prestamo")
                            lpara("valor") = valorNom
                            If (valorNom > 0) Then

                                cadena = "insert into prestamos2 (empresa,prestamo,fecha,tipodocto,docto,cargos,abonos,tiponom,mes,año) 
                                      values (@empresa,@prestamo,@fechaf,@tipodocto,@docto,0.00,@valor,@tiponom,@mes,@año)"
                                cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                Dim saldo As Decimal = valorSaldo - valorNom
                                lpara("saldo") = saldo
                                cadena = "update prestamos1 set saldo=@saldo where empresa=@empresa and prestamo=@prestamo "
                                cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                cadena = "insert into nominas (empresa, tiponom, mes, año, empleado, contrato, fechai, fechaf, transac, cantidad, valor ) 
                                          values (@empresa,@tiponom,@mes,@año,@empleado,@contrato,@fechai,@fechaf,@transac,0,@valor)"
                                cm.EjecutarNonQuery(cadena, ListaParametros(lpara))

                            End If

                        Next j



                    End If
                End If
            End If



        Next i

        PgBar.Value = 0
    End Sub

    Private Sub CalculoValSeguroSocial(ByVal mes As Int16, ByVal año As Int16, ByVal tiponom As String, cm As cmodelo)
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("mes") = mes
        lpara("año") = año
        lpara("tiponom") = tiponom
        cadena = "insert into nominas " &
                "select no.empresa, no.tiponom, no.mes, no.año, no.empleado, no.contrato, no.fechai, no.fechaf, " &
                "se.transac, 0 as cantidad, ( coalesce( sum(valor), 0) * ( se.por/100)) as valor  from nominas no " &
                "inner join tipotran t on no.empresa=t.empresa and no.transac=t.transac " &
                "inner join contratos1 c1 on  c1.empresa=no.empresa and c1.contrato=no.contrato and c1.empleado=no.empleado " &
                "inner join segurosocial se on se.empresa=c1.empresa and se.tiposeguro=c1.tiposeguro " &
                "where no.empresa=@empresa and mes=@mes and año=@año and tiponom=@tiponom " &
                "and tipomov='I' and afectaseguro='S' " &
                "group by no.empresa, no.tiponom, no.mes, no.año, no.empleado, no.contrato, no.fechai, no.fechaf, se.transac, se.por "
        cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
    End Sub


    Private Sub TextAño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextAño.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
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
        Dim listado = cklbTipoPersonal2.CheckedItems
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

                    fila = tbEmple.AsEnumerable().Where(Function(x) x.Field(Of Int32)("empleado") = ele.empleado And x.Field(Of Short)("contrato") = ele.contrato).FirstOrDefault()
                    fila("marca") = True
                Next

                Dim cuenta As Int32 = 0
                For Each ele As DataRow In tbEmple.Rows
                    If ele("marca") = True Then
                        cuenta += 1
                    End If
                Next
                textNoRegistros.Text = cuenta
                MsgBox("Archivo cargado con éxito", MsgBoxStyle.Exclamation)
            End If

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
