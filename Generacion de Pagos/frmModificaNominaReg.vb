Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMMODIFICANOMINA.VB MIEMBRO DE NOMINA.SLN                                  **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmModificaNominaReg
    Inherits Form
    Dim cadena As String
    Dim tbPrestamo As New DataTable("prestamos")
    Dim tbTipo As New DataTable("tipo")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim fTemp As DataRow
    Dim filaTemp As DataRow
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbContratos As New DataTable("contratos")
    Dim tbDetalle As New DataTable("detalle")
    Dim WithEvents fEmp As frmMuestraCodigos
    Dim tipoNOm As String
    Dim año, mes As Integer
    Dim dpara As New Dictionary(Of String, Object)
    Dim tbCodigo As New DataTable
    Dim WithEvents f2C As frmMuestra2Columnas
    Dim _formacal, _tipovalor, _tipomov As String
    Dim tbDetalleBorrado As New DataTable()

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
    Friend WithEvents gpPeriodo As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents TextAño As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextMoneEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents gpContrato As System.Windows.Forms.GroupBox
    Friend WithEvents btnContrato As System.Windows.Forms.Button
    Friend WithEvents TextConxContrato As System.Windows.Forms.TextBox
    Friend WithEvents gpEmpleador As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents textEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents gpData As System.Windows.Forms.GroupBox
    Friend WithEvents TextTotalSueldo As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents dgSueldos As System.Windows.Forms.DataGridView
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents gpDetalle As GroupBox
    Friend WithEvents btnIngresar As Button
    Friend WithEvents gpTransaccion As GroupBox
    Friend WithEvents btnBuscaCodigo As Button
    Friend WithEvents textNombCodigo As TextBox
    Friend WithEvents textCodigo As TextBox
    Friend WithEvents ctxEliSueldo As System.Windows.Forms.ToolStripMenuItem

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmModificaNominaReg))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gpPeriodo = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnBuscaCodigo = New System.Windows.Forms.Button()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextMoneEmpresa = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gpContrato = New System.Windows.Forms.GroupBox()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.TextConxContrato = New System.Windows.Forms.TextBox()
        Me.gpEmpleador = New System.Windows.Forms.GroupBox()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textEmpleado = New System.Windows.Forms.TextBox()
        Me.gpData = New System.Windows.Forms.GroupBox()
        Me.TextTotalSueldo = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.dgSueldos = New System.Windows.Forms.DataGridView()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxEliSueldo = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gpDetalle = New System.Windows.Forms.GroupBox()
        Me.gpTransaccion = New System.Windows.Forms.GroupBox()
        Me.textNombCodigo = New System.Windows.Forms.TextBox()
        Me.textCodigo = New System.Windows.Forms.TextBox()
        Me.gpPeriodo.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpContrato.SuspendLayout()
        Me.gpEmpleador.SuspendLayout()
        Me.gpData.SuspendLayout()
        CType(Me.dgSueldos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.gpDetalle.SuspendLayout()
        Me.gpTransaccion.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpPeriodo
        '
        Me.gpPeriodo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpPeriodo.Controls.Add(Me.Label4)
        Me.gpPeriodo.Controls.Add(Me.Label2)
        Me.gpPeriodo.Controls.Add(Me.Label3)
        Me.gpPeriodo.Controls.Add(Me.cmbTipo)
        Me.gpPeriodo.Controls.Add(Me.TextAño)
        Me.gpPeriodo.Controls.Add(Me.cmbMes)
        Me.gpPeriodo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpPeriodo.Location = New System.Drawing.Point(16, 66)
        Me.gpPeriodo.Name = "gpPeriodo"
        Me.gpPeriodo.Size = New System.Drawing.Size(622, 42)
        Me.gpPeriodo.TabIndex = 3
        Me.gpPeriodo.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(490, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Año:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(318, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 21
        Me.Label2.Text = "Mes:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "Tipo nómina:"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(83, 12)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(208, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'TextAño
        '
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(524, 13)
        Me.TextAño.MaxLength = 4
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(56, 20)
        Me.TextAño.TabIndex = 3
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(353, 12)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(121, 21)
        Me.cmbMes.TabIndex = 2
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.ImageKey = "buscar1.png"
        Me.btnBuscar.ImageList = Me.ImageNuevos
        Me.btnBuscar.Location = New System.Drawing.Point(785, 126)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(80, 30)
        Me.btnBuscar.TabIndex = 4
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Generar el proceso")
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
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(1047, 12)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 74
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(9, 288)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 30)
        Me.btnGuardar.TabIndex = 129
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Almacenar registro")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnBuscaCodigo
        '
        Me.btnBuscaCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscaCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscaCodigo.ImageKey = "buscar1.png"
        Me.btnBuscaCodigo.ImageList = Me.ImageNuevos
        Me.btnBuscaCodigo.Location = New System.Drawing.Point(382, 12)
        Me.btnBuscaCodigo.Name = "btnBuscaCodigo"
        Me.btnBuscaCodigo.Size = New System.Drawing.Size(60, 30)
        Me.btnBuscaCodigo.TabIndex = 3
        Me.btnBuscaCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscaCodigo, "Buscar Transaccion")
        Me.btnBuscaCodigo.UseVisualStyleBackColor = False
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
        'btnIngresar
        '
        Me.btnIngresar.BackColor = System.Drawing.SystemColors.Control
        Me.btnIngresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngresar.ImageKey = "checkok.png"
        Me.btnIngresar.ImageList = Me.ImageNuevos
        Me.btnIngresar.Location = New System.Drawing.Point(465, 22)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(80, 30)
        Me.btnIngresar.TabIndex = 4
        Me.btnIngresar.Text = "Agregar"
        Me.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnIngresar, "Ingresar")
        Me.btnIngresar.UseVisualStyleBackColor = False
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
        Me.gpEmpresa.Location = New System.Drawing.Point(337, 8)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(456, 44)
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
        Me.Label10.Location = New System.Drawing.Point(344, 19)
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
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'gpContrato
        '
        Me.gpContrato.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpContrato.Controls.Add(Me.btnContrato)
        Me.gpContrato.Controls.Add(Me.TextConxContrato)
        Me.gpContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpContrato.Location = New System.Drawing.Point(644, 112)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(124, 50)
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
        Me.btnContrato.Location = New System.Drawing.Point(79, 14)
        Me.btnContrato.Name = "btnContrato"
        Me.btnContrato.Size = New System.Drawing.Size(40, 32)
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
        'gpEmpleador
        '
        Me.gpEmpleador.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpEmpleador.Controls.Add(Me.btnEmpleado)
        Me.gpEmpleador.Controls.Add(Me.textNombreEmple)
        Me.gpEmpleador.Controls.Add(Me.textEmpleado)
        Me.gpEmpleador.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpleador.Location = New System.Drawing.Point(16, 112)
        Me.gpEmpleador.Name = "gpEmpleador"
        Me.gpEmpleador.Size = New System.Drawing.Size(622, 50)
        Me.gpEmpleador.TabIndex = 1
        Me.gpEmpleador.TabStop = False
        Me.gpEmpleador.Text = "Empleado"
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
        'gpData
        '
        Me.gpData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpData.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpData.Controls.Add(Me.btnGuardar)
        Me.gpData.Controls.Add(Me.TextTotalSueldo)
        Me.gpData.Controls.Add(Me.Label25)
        Me.gpData.Controls.Add(Me.dgSueldos)
        Me.gpData.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpData.Location = New System.Drawing.Point(16, 246)
        Me.gpData.Name = "gpData"
        Me.gpData.Size = New System.Drawing.Size(1099, 332)
        Me.gpData.TabIndex = 75
        Me.gpData.TabStop = False
        Me.gpData.Text = "Transacciones"
        '
        'TextTotalSueldo
        '
        Me.TextTotalSueldo.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextTotalSueldo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextTotalSueldo.BackColor = System.Drawing.Color.White
        Me.TextTotalSueldo.Font = New System.Drawing.Font("Courier New", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTotalSueldo.ForeColor = System.Drawing.Color.Red
        Me.TextTotalSueldo.Location = New System.Drawing.Point(912, 290)
        Me.TextTotalSueldo.MaxLength = 3
        Me.TextTotalSueldo.Name = "TextTotalSueldo"
        Me.TextTotalSueldo.Size = New System.Drawing.Size(177, 35)
        Me.TextTotalSueldo.TabIndex = 127
        Me.TextTotalSueldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(826, 294)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(62, 24)
        Me.Label25.TabIndex = 126
        Me.Label25.Text = "Total:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgSueldos
        '
        Me.dgSueldos.AllowUserToAddRows = False
        Me.dgSueldos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen
        Me.dgSueldos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgSueldos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgSueldos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgSueldos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgSueldos.BackgroundColor = System.Drawing.Color.White
        Me.dgSueldos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgSueldos.ContextMenuStrip = Me.ctxMenu
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgSueldos.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgSueldos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.dgSueldos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgSueldos.Location = New System.Drawing.Point(10, 19)
        Me.dgSueldos.MultiSelect = False
        Me.dgSueldos.Name = "dgSueldos"
        Me.dgSueldos.Size = New System.Drawing.Size(1079, 263)
        Me.dgSueldos.TabIndex = 125
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxEliSueldo})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(185, 48)
        '
        'ctxEliSueldo
        '
        Me.ctxEliSueldo.Image = Global.NOMINA.My.Resources.Resources.menos
        Me.ctxEliSueldo.Name = "ctxEliSueldo"
        Me.ctxEliSueldo.Size = New System.Drawing.Size(184, 22)
        Me.ctxEliSueldo.Text = " Eliminar transacción"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 60)
        Me.Panel1.TabIndex = 76
        '
        'gpDetalle
        '
        Me.gpDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpDetalle.Controls.Add(Me.btnIngresar)
        Me.gpDetalle.Controls.Add(Me.gpTransaccion)
        Me.gpDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDetalle.Location = New System.Drawing.Point(18, 165)
        Me.gpDetalle.Name = "gpDetalle"
        Me.gpDetalle.Size = New System.Drawing.Size(609, 75)
        Me.gpDetalle.TabIndex = 77
        Me.gpDetalle.TabStop = False
        '
        'gpTransaccion
        '
        Me.gpTransaccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpTransaccion.Controls.Add(Me.btnBuscaCodigo)
        Me.gpTransaccion.Controls.Add(Me.textNombCodigo)
        Me.gpTransaccion.Controls.Add(Me.textCodigo)
        Me.gpTransaccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTransaccion.Location = New System.Drawing.Point(7, 12)
        Me.gpTransaccion.Name = "gpTransaccion"
        Me.gpTransaccion.Size = New System.Drawing.Size(452, 48)
        Me.gpTransaccion.TabIndex = 1
        Me.gpTransaccion.TabStop = False
        Me.gpTransaccion.Text = "Transacciones"
        '
        'textNombCodigo
        '
        Me.textNombCodigo.BackColor = System.Drawing.Color.White
        Me.textNombCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombCodigo.Location = New System.Drawing.Point(60, 16)
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
        Me.textCodigo.Location = New System.Drawing.Point(6, 16)
        Me.textCodigo.MaxLength = 5
        Me.textCodigo.Name = "textCodigo"
        Me.textCodigo.Size = New System.Drawing.Size(48, 20)
        Me.textCodigo.TabIndex = 1
        '
        'frmModificaNominaReg
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 590)
        Me.Controls.Add(Me.gpDetalle)
        Me.Controls.Add(Me.gpEmpleador)
        Me.Controls.Add(Me.gpData)
        Me.Controls.Add(Me.gpContrato)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.gpPeriodo)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmModificaNominaReg"
        Me.Text = "Proceso para Modificación de Nómina"
        Me.gpPeriodo.ResumeLayout(False)
        Me.gpPeriodo.PerformLayout()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        Me.gpEmpleador.ResumeLayout(False)
        Me.gpEmpleador.PerformLayout()
        Me.gpData.ResumeLayout(False)
        Me.gpData.PerformLayout()
        CType(Me.dgSueldos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.gpDetalle.ResumeLayout(False)
        Me.gpTransaccion.ResumeLayout(False)
        Me.gpTransaccion.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cadena = "select nombre from meses order by mes"
        llena_combo(cadena, cmbMes)
        cmbMes.Items.Add("")
        EscribeEmpresa(TextNombEmpresa, TextMoneEmpresa)
        cadena = "select nombre, tiponom from tiponomina1 where empresa=" & empresa
        llena_combo(cadena, cmbTipo)
        llenaTabla(cadena, tbTipo)
        cmbTipo.Items.Add("")
        textEmpleado.Focus()
        btnLimpiar_Click(sender, e)
        TextAño.Text = Today.Year
    End Sub


#Region "EMLEADO"


    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        TextConxContrato.Clear()
        If valbool = True Then
            textEmpleado.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Int32
        cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=" & empresa & " and nombre like '%" &
        textNombreEmple.Text.Trim & "%' " &
        " and e.empleado in ( select empleado from contratos1 c1 " &
        "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) " &
        "order by nombre"
        numFilas = llenaTabla(cadena, tbEmpleado)
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado(True)
            textEmpleado.Clear()
        ElseIf numFilas = 1 Then
            BorraEmpleado(True)
            filaTemp = tbEmpleado.Rows.Item(0)
            textEmpleado.Text() = filaTemp.Item(0)
            textNombreEmple.Text = filaTemp.Item(1)
            TextConxContrato.Focus()
        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        If valida_tipo_Entero(textEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=" & empresa &
                 " and empleado=" & textEmpleado.Text.Trim) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textEmpleado.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=" & empresa &
                  " and empleado=" & textEmpleado.Text.Trim & " " &
                   " and e.empleado in ( select empleado from contratos1 c1 " &
                   "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) "
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraEmpleado(False)
                dr.Read()
                textNombreEmple.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
                TextConxContrato.Focus()
            Else
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL EMPLEADO POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraEmpleado(True)
            textEmpleado.Focus()
        End If
    End Sub

    Private Sub TextEmpleado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textEmpleado.Validated
        If textEmpleado.Text.Trim <> "" Then
            ValidaEmpleado()
        Else
            BorraEmpleado(False)
        End If
    End Sub

    Private Sub EnBuscaEmpleado()
        fEmp = New frmMuestraCodigos
        fEmp.TopMost = True
        fEmp.inicializa(tbEmpleado)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosEmpleados
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        TextConxContrato.Focus()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        textEmpleado.Text() = filaTemp.Item(0)
        textNombreEmple.Text = filaTemp.Item(1)
    End Sub
#End Region

#Region "Contrato"

    Private Sub BtnContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContrato.Click
        Dim Num As Int16
        If textEmpleado.Text.Trim <> "" Then
            cadena = "select contrato, pu.nombre from contratos1 c1 inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                     "inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " &
                     "where e.generapago='S' and c1.empresa=" & empresa & " and empleado=" & textEmpleado.Text
            Num = llenaTabla(cadena, tbContratos)
            If Num = 1 Then
                TextConxContrato.Text = tbContratos.Rows(0).Item(0)
            ElseIf Num > 1 Then
                f2C = New frmMuestra2Columnas
                f2C.TopMost = True
                f2C.inicializa(tbContratos, "CONTRATO", "PUESTO", 0)
                AddHandler f2C.actValor, AddressOf ActualizacionDatosContrato
                f2C.StartPosition = FormStartPosition.CenterScreen
                f2C.ShowDialog()
                cmbTipo.Focus()

            ElseIf Num = 0 Then
                MsgBox("ESTE EMPLEADO NO TIENE CONTRATOS ACTIVOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            End If
        Else
            MsgBox("INGRESO PRIMERO EL EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ActualizacionDatosContrato(ByVal sender As Object, ByVal e As clsActValorREvento)
        filaTemp = tbContratos.Rows(e.va2)
        TextConxContrato.Text() = filaTemp.Item(0)
        cmbTipo.Focus()
    End Sub


    Private Sub TextConxContrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextConxContrato.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub TextConxContrato_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextConxContrato.Validated
        If TextConxContrato.Text.Trim <> "" And textEmpleado.Text.Trim <> "" Then
            cadena = "select count(*) from contratos1 c1 inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                        "where e.generapago='S' and c1.empresa=" & empresa & " and empleado=" & textEmpleado.Text
            If BuscaEscalar(cadena) > 0 Then
                cmbTipo.Focus()
            Else
                MsgBox("ESTE EMPLEADO NO TIENE CONTRATOS ACTIVOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            End If
        Else
            TextConxContrato.Clear()
        End If
    End Sub


#End Region

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        borra_Mejorado(gpEmpleador, ep1)
        borra_Mejorado(gpContrato, ep1)
        borra_Mejorado(gpDetalle, ep1)
        borra_Mejorado(gpData, ep1)
        gpEmpleador.Enabled = True
        gpContrato.Enabled = True
        gpPeriodo.Enabled = True
        gpData.Enabled = False
        gpDetalle.Enabled = False
        tbDetalleBorrado.Clear()
        ContextoMenuEnab(True, False, ctxMenu)
        dgSueldos.DataSource = Nothing
        TextTotalSueldo.Clear()
        textEmpleado.Focus()
        _tipomov = ""
        _formacal = ""
        _tipovalor = ""
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        If Not validetError(cmbTipo, ep1) Or Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) Or
           Not validetError(textEmpleado, ep1) Or Not validetError(TextConxContrato, ep1) Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If
        tipoNOm = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
        mes = cmbMes.SelectedIndex + 1
        año = CInt(TextAño.Text)

        cadena = "select nom.transac, t.nombre, cantidad, valor, fechai, fechaf, t.tipomov, t.tipovalor " &
                 "from nominas nom inner join tipotran t on nom.empresa=t.empresa and nom.transac=t.transac " &
                 "where nom.empresa=" & empresa & " and tiponom='" & tipoNOm & "' AND año=" & año & " and mes=" & mes &
                 " and empleado=" & textEmpleado.Text & " and contrato=" & TextConxContrato.Text
        If llenaTabla(cadena, tbDetalle) > 0 Then
            tbDetalleBorrado = tbDetalle.Clone()
            ContextoMenuEnab(True, True, ctxMenu)
            gpEmpleador.Enabled = False
            gpContrato.Enabled = False
            gpPeriodo.Enabled = False
            gpData.Enabled = True
            gpDetalle.Enabled = True
            dgSueldos.DataSource = tbDetalle
            Vista(dgSueldos)
            TextTotalSueldo.Text = formato(totaliza(tbDetalle))
        Else
            MsgBox("NO HAY REGISTRO CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub


    Private Function totaliza(ByVal tabla As DataTable) As Decimal

        Dim f As DataRow
        Dim i As Int32
        Dim numT As Decimal = 0
        For i = 0 To tabla.Rows.Count - 1
            f = tabla.Rows(i)

            If (f.Item("tipomov") = "I") Then
                numT = numT + f.Item("valor")
            ElseIf f.Item("tipomov") = "D" Then
                numT = numT - f.Item("valor")
            End If
        Next i
        Return numT


    End Function


#Region "SUELDOS"

    Private Sub Vista(ByVal dgVista As DataGridView)
        With dgVista
            .Columns(0).HeaderText = "Transacción"
            .Columns(0).FillWeight = 20
            .Columns(0).ReadOnly = True
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).FillWeight = 40
            .Columns(1).ReadOnly = True
            .Columns("cantidad").HeaderText = "Cantidad"
            .Columns("cantidad").FillWeight = 20
            .Columns("cantidad").ReadOnly = False
            .Columns("valor").HeaderText = "Valor"
            .Columns("valor").FillWeight = 20
            .Columns("valor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns("valor").DefaultCellStyle.Format = "N2"
            .Columns("fechai").Visible = False
            .Columns("fechaf").Visible = False
            .Columns("tipomov").Visible = False
            .Columns("tipovalor").Visible = False
            'AltoGridView(18, tbDetalle, 272, 710, dgVista)
        End With
    End Sub



    Private Sub ctxEliSueldo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliSueldo.Click
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgSueldos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgSueldos.SelectedRows(0).DataBoundItem, DataRowView).Row
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                tbDetalleBorrado.ImportRow(filaTemp)
                tbDetalle.Rows.Remove(filaTemp)
                TextTotalSueldo.Text = formato(totaliza(tbDetalle))
                'AltoGridView(18, tbDetalle, 272, 710, dgSueldos)
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim i As Int32
        If MsgBox("ESTA SEGURO QUE DESEA MODIFICAR ESTA NOMINA PARA ESTE EMPLEADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            Dim cm As New cmodelo()

            If tbDetalle.Rows.Count > 0 Then
                If tbDetalle.AsEnumerable().Where(Function(x) x.Field(Of Decimal)("valor") = 0).Count > 0 Then
                    MsgBox("No pueden haber transacciones con valor con 0, verifique", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
                Dim resultado As DataRow() = tbDetalle.AsEnumerable().Where(Function(x) x.Field(Of String)("tipovalor") = "C" AndAlso x.Field(Of Decimal)("cantidad") = 0).ToArray()


                If resultado.Count > 0 Then
                    MsgBox("No se puede ir con cantidad 0 transacciones marcadas que utilizan cantidad, verifique las siguientes transacciones", MsgBoxStyle.Exclamation, "Mensaje del Sistema")

                    For Each ele As DataRow In resultado
                        MsgBox(ele("nombre"))
                    Next

                    Exit Sub

                End If

            End If



            Try
                dpara("empresa") = empresa
                dpara("tiponom") = tipoNOm
                dpara("empleado") = CInt(textEmpleado.Text)
                dpara("contrato") = CInt(TextConxContrato.Text)
                dpara("año") = año
                dpara("mes") = mes



                cadena = "delete from nominas  where empresa=@empresa and tiponom=@tiponom AND año=@año and mes=@mes and empleado=@empleado and contrato=@contrato"
                cm.EjecutarNonQuery(cadena, ListaParametros(dpara))
                For i = 0 To tbDetalle.Rows.Count - 1

                    filaTemp = tbDetalle.Rows(i)
                    dpara("transac") = filaTemp("transac")
                    dpara("cantidad") = filaTemp("cantidad")
                    dpara("valor") = filaTemp("valor")
                    dpara("fechai") = filaTemp("fechai")
                    dpara("fechaf") = filaTemp("fechaf")

                    cadena = "insert into nominas (empresa, tiponom, mes, año, empleado, contrato, fechai, fechaf, transac, cantidad, valor) values 
                             (@empresa, @tiponom, @mes, @año, @empleado, @contrato, @fechai, @fechaf, @transac, @cantidad, @valor) "
                    cm.EjecutarNonQuery(cadena, ListaParametros(dpara))
                    cadena = "update movinomina set valor=@valor, cantidad=@cantidad where  empresa=@empresa and empleado=@empleado and contrato=@contrato and
                            tiponom=@tiponom and año=@año and mes=@mes and transac=@transac "
                    cm.EjecutarNonQuery(cadena, ListaParametros(dpara))


                Next i

                If cm.Commit() Then
                    InsertBitacora(9, 4, $"Modificación registro nómina año { dpara("año") } mes { dpara("mes")} tiponom { dpara("tiponom") } empleado { dpara("empleado") } contrato { dpara("contrato")} ")
                    MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                    btnLimpiar_Click(sender, e)
                End If


            Catch ex As Exception

                MsgBox("ERROR AL GUARDAR LOS DATOS", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        End If
    End Sub


#End Region

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textEmpleado.Enter, textNombreEmple.Enter, TextConxContrato.Enter, cmbTipo.Enter, cmbMes.Enter, TextAño.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textEmpleado.Leave, textNombreEmple.Leave, TextConxContrato.Leave, cmbTipo.Leave, cmbMes.Leave, TextAño.Leave
        desactiva(sender)
    End Sub


    Private Sub cmbMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub TextAño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextAño.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub dgSueldos_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgSueldos.CellValueChanged
        If (dgSueldos.Columns(e.ColumnIndex).Name.Contains("valor")) Then
            TextTotalSueldo.Text = formato(totaliza(tbDetalle))
        End If
    End Sub

    Private Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        Dim codigo As Int16 = 0
        If dgSueldos.DataSource IsNot Nothing AndAlso textCodigo.Text.Trim <> "" And Int16.TryParse(textCodigo.Text, codigo) Then

            Dim cuenta = tbDetalle.AsEnumerable.Where(Function(x) x.Field(Of Int16)("transac") = codigo).Count()
            If cuenta > 0 Then
                MsgBox("Transaccion ya existe, verificque")
                Exit Sub
            End If
            Dim f As DataRow = tbDetalle.NewRow
            f("transac") = codigo
            f("nombre") = textNombCodigo.Text
            f("valor") = 0
            f("cantidad") = 0
            f("fechai") = New DateTime(año, mes, 1)
            f("fechaf") = New DateTime(año, mes, DateTime.DaysInMonth(año, mes))
            f("tipomov") = _tipomov
            tbDetalle.Rows.Add(f)


            ' nom.transac, t.nombre, cantidad, valor, fechai, fechaf 
        Else
            MsgBox("Debe ingresar el código de la transacción y debe seleccionar un empleado", MsgBoxStyle.Information, "Mensaje del Sistema")

        End If
    End Sub

    Private Sub dgSueldos_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles dgSueldos.DataError
        MsgBox("Error en tipo de valor ingresado")
        e.Cancel = True
    End Sub



#Region "TRANSACCION"


    Private Sub BorraCodigo(ByVal valbool As Boolean)
        _tipomov = ""
        _tipovalor = ""
        _formacal = ""
        textNombCodigo.Clear()
        If valbool = True Then
            textCodigo.Clear()
        End If
    End Sub


    Private Sub btnCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaCodigo.Click
        Dim numFilas As Int32
        cadena = "select transac, nombre, case when tipomov='I' then 'INGRESO' else 'DESCUENTO' END as nombTipomov," &
                 " formacal,  tipovalor, tipomov from tipotran where empresa=" & empresa & " and nombre like '%" &
        textNombCodigo.Text.Trim & "%'  order by transac"
        numFilas = llenaTabla(cadena, tbCodigo)
        If numFilas = 0 Then
            MsgBox("NO EXISTEN TRANSACCIONES CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCodigo(True)
            textCodigo.Focus()
        ElseIf numFilas = 1 Then
            BorraCodigo(True)
            filaTemp = tbCodigo.Rows.Item(0)
            textCodigo.Text() = filaTemp.Item(0)
            textNombCodigo.Text = filaTemp.Item(1)
            _formacal = filaTemp.Item("formacal")
            _tipovalor = filaTemp.Item("tipovalor")
            _tipomov = filaTemp.Item("tipomov")
            btnIngresar.Focus()
        Else
            EnBuscaCodigo()
        End If
    End Sub

    Private Sub ValidaCodigo()
        If valida_tipo_Entero(textCodigo.Text, 1) = True Then
            If BuscaEscalar("select count (*) from tipotran where empresa=" & empresa &
                 " and transac=" & textCodigo.Text.Trim) = 0 Then
                MsgBox("TRANSACCION NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraCodigo(True)
                textCodigo.Focus()
                Exit Sub
            End If
            cadena = "select transac, nombre, case when tipomov='I' then 'INGRESO' else 'DESCUENTO' END as nombTipomov," &
                  " formacal, tipovalor, tipomov from tipotran where empresa=" & empresa &
                 " and transac=" & textCodigo.Text.Trim & " "
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraCodigo(False)
                dr.Read()
                textNombCodigo.Text = dr.GetValue(1)

                _formacal = dr.GetValue(3)
                _tipovalor = dr.GetValue(4)
                _tipomov = dr.GetValue(5)
                dr.Close()
                cn.Close()
                btnIngresar.Focus()

            Else
                dr.Close()
                cn.Close()
                MsgBox("TRANSACCION NO VALIDA", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                BorraCodigo(True)
            End If
        Else
            MsgBox("TRANSACCION POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraCodigo(True)
            textCodigo.Focus()
        End If
    End Sub

    Private Sub TextCodigo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textCodigo.Validated
        If textCodigo.Text.Trim <> "" Then
            ValidaCodigo()
        Else
            BorraCodigo(False)
        End If
    End Sub

    Private Sub EnBuscaCodigo()
        Dim f3C As New frmMuestra3Columnas
        f3C.TopMost = True
        f3C.inicializa(tbCodigo, "TRANSACCION", "NOMBRE", "TIPO", 2)
        AddHandler f3C.actValor, AddressOf ActualizacionDatosMonitor
        f3C.StartPosition = FormStartPosition.CenterScreen
        f3C.ShowDialog()
        btnIngresar.Focus()
    End Sub

    Private Sub ActualizacionDatosMonitor(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraCodigo(True)
        filaTemp = tbCodigo.Rows.Item(e.va2)
        textCodigo.Text() = filaTemp.Item("transac")
        textNombCodigo.Text = filaTemp.Item("nombre")

        _formacal = filaTemp.Item(3)
        _tipovalor = filaTemp.Item(4)
        _tipomov = filaTemp.Item(5)
        btnIngresar.Focus()
    End Sub






#End Region



    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub







End Class
