Imports System.Data.SqlClient
Imports System.IO
Imports NOMINA.controller

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMELIMINANOMI.VB MIEMBRO DE NOMINA.SLN                                     **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmEliminaNomi
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
    Dim WithEvents fEmp As frmMuestraCodigos

    Dim WithEvents f2C As frmMuestra2Columnas

    Dim lpara As New Dictionary(Of String, Object)
    Dim tbEmple As New DataTable

    Dim empleCtr As New EmpleadoController
    Friend WithEvents btnFiltroTodos As Button
    Friend WithEvents btnFiltroMarcados As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents ofdArchivo As OpenFileDialog
    Dim nomCtr As New NominasController



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
    Friend WithEvents gpInfoPri As System.Windows.Forms.GroupBox
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
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
    Friend WithEvents gpChofer As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents textEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnSingle As Panel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents rbSeleccion As RadioButton
    Friend WithEvents rbEmpleado As RadioButton
    Friend WithEvents pnInfoEmpleado As Panel
    Friend WithEvents textFiltro As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents textNoRegistros As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnDesel As Button
    Friend WithEvents btnSel As Button
    Friend WithEvents dgvEmpleado As DataGridView
    Friend WithEvents Panel2 As Panel
    Friend WithEvents PgBar As ProgressBar
    Friend WithEvents btnConsultar As Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEliminaNomi))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gpInfoPri = New System.Windows.Forms.GroupBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextMoneEmpresa = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gpContrato = New System.Windows.Forms.GroupBox()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.TextConxContrato = New System.Windows.Forms.TextBox()
        Me.gpChofer = New System.Windows.Forms.GroupBox()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textEmpleado = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.rbSeleccion = New System.Windows.Forms.RadioButton()
        Me.rbEmpleado = New System.Windows.Forms.RadioButton()
        Me.pnSingle = New System.Windows.Forms.Panel()
        Me.pnInfoEmpleado = New System.Windows.Forms.Panel()
        Me.btnFiltroTodos = New System.Windows.Forms.Button()
        Me.btnFiltroMarcados = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.textFiltro = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.textNoRegistros = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDesel = New System.Windows.Forms.Button()
        Me.btnSel = New System.Windows.Forms.Button()
        Me.dgvEmpleado = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.PgBar = New System.Windows.Forms.ProgressBar()
        Me.btnConsultar = New System.Windows.Forms.Button()
        Me.ofdArchivo = New System.Windows.Forms.OpenFileDialog()
        Me.gpInfoPri.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpContrato.SuspendLayout()
        Me.gpChofer.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.pnSingle.SuspendLayout()
        Me.pnInfoEmpleado.SuspendLayout()
        CType(Me.dgvEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpInfoPri
        '
        Me.gpInfoPri.BackColor = System.Drawing.Color.AliceBlue
        Me.gpInfoPri.Controls.Add(Me.cmbTipo)
        Me.gpInfoPri.Controls.Add(Me.TextAño)
        Me.gpInfoPri.Controls.Add(Me.cmbMes)
        Me.gpInfoPri.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpInfoPri.Location = New System.Drawing.Point(12, 64)
        Me.gpInfoPri.Name = "gpInfoPri"
        Me.gpInfoPri.Size = New System.Drawing.Size(423, 40)
        Me.gpInfoPri.TabIndex = 3
        Me.gpInfoPri.TabStop = False
        Me.gpInfoPri.Text = "Tipo  de nómina y periodo"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(6, 15)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(208, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'TextAño
        '
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(356, 15)
        Me.TextAño.MaxLength = 4
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(56, 20)
        Me.TextAño.TabIndex = 3
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(220, 15)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(121, 21)
        Me.cmbMes.TabIndex = 2
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "cancelar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(799, 517)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(72, 30)
        Me.btnEjecutar.TabIndex = 4
        Me.btnEjecutar.Text = "Eliminar"
        Me.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEjecutar, "Eliminar")
        Me.btnEjecutar.UseVisualStyleBackColor = False
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
        Me.btnLimpiar.Location = New System.Drawing.Point(801, 8)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(74, 30)
        Me.btnLimpiar.TabIndex = 74
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(518, 10)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(84, 30)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.Text = "Empleado"
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEmpleado, "Empleado")
        Me.btnEmpleado.UseVisualStyleBackColor = False
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
        Me.gpEmpresa.Location = New System.Drawing.Point(232, 3)
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
        Me.Label10.Location = New System.Drawing.Point(344, 20)
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
        Me.gpContrato.BackColor = System.Drawing.Color.AliceBlue
        Me.gpContrato.Controls.Add(Me.btnContrato)
        Me.gpContrato.Controls.Add(Me.TextConxContrato)
        Me.gpContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpContrato.Location = New System.Drawing.Point(644, 12)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(164, 51)
        Me.gpContrato.TabIndex = 2
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
        Me.btnContrato.Location = New System.Drawing.Point(79, 11)
        Me.btnContrato.Name = "btnContrato"
        Me.btnContrato.Size = New System.Drawing.Size(79, 30)
        Me.btnContrato.TabIndex = 16
        Me.btnContrato.Text = "Contrato"
        Me.btnContrato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnContrato.UseVisualStyleBackColor = False
        '
        'TextConxContrato
        '
        Me.TextConxContrato.BackColor = System.Drawing.Color.White
        Me.TextConxContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConxContrato.ForeColor = System.Drawing.Color.Red
        Me.TextConxContrato.Location = New System.Drawing.Point(10, 17)
        Me.TextConxContrato.MaxLength = 4
        Me.TextConxContrato.Name = "TextConxContrato"
        Me.TextConxContrato.Size = New System.Drawing.Size(63, 20)
        Me.TextConxContrato.TabIndex = 1
        Me.TextConxContrato.TabStop = False
        '
        'gpChofer
        '
        Me.gpChofer.BackColor = System.Drawing.Color.AliceBlue
        Me.gpChofer.Controls.Add(Me.btnEmpleado)
        Me.gpChofer.Controls.Add(Me.textNombreEmple)
        Me.gpChofer.Controls.Add(Me.textEmpleado)
        Me.gpChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpChofer.Location = New System.Drawing.Point(15, 12)
        Me.gpChofer.Name = "gpChofer"
        Me.gpChofer.Size = New System.Drawing.Size(623, 51)
        Me.gpChofer.TabIndex = 1
        Me.gpChofer.TabStop = False
        Me.gpChofer.Text = "Empleado"
        '
        'textNombreEmple
        '
        Me.textNombreEmple.BackColor = System.Drawing.Color.White
        Me.textNombreEmple.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombreEmple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombreEmple.Location = New System.Drawing.Point(66, 17)
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
        Me.textEmpleado.Location = New System.Drawing.Point(6, 17)
        Me.textEmpleado.MaxLength = 6
        Me.textEmpleado.Name = "textEmpleado"
        Me.textEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textEmpleado.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(883, 58)
        Me.Panel1.TabIndex = 75
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSeleccion)
        Me.GroupBox1.Controls.Add(Me.rbEmpleado)
        Me.GroupBox1.Location = New System.Drawing.Point(483, 64)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(246, 40)
        Me.GroupBox1.TabIndex = 76
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Tipo Eliminación"
        '
        'rbSeleccion
        '
        Me.rbSeleccion.AutoSize = True
        Me.rbSeleccion.Location = New System.Drawing.Point(128, 16)
        Me.rbSeleccion.Name = "rbSeleccion"
        Me.rbSeleccion.Size = New System.Drawing.Size(72, 17)
        Me.rbSeleccion.TabIndex = 20
        Me.rbSeleccion.TabStop = True
        Me.rbSeleccion.Text = "Selección"
        Me.rbSeleccion.UseVisualStyleBackColor = True
        '
        'rbEmpleado
        '
        Me.rbEmpleado.AutoSize = True
        Me.rbEmpleado.Location = New System.Drawing.Point(18, 17)
        Me.rbEmpleado.Name = "rbEmpleado"
        Me.rbEmpleado.Size = New System.Drawing.Size(90, 17)
        Me.rbEmpleado.TabIndex = 19
        Me.rbEmpleado.TabStop = True
        Me.rbEmpleado.Text = "Por empleado"
        Me.rbEmpleado.UseVisualStyleBackColor = True
        '
        'pnSingle
        '
        Me.pnSingle.Controls.Add(Me.gpChofer)
        Me.pnSingle.Controls.Add(Me.gpContrato)
        Me.pnSingle.Location = New System.Drawing.Point(12, 117)
        Me.pnSingle.Name = "pnSingle"
        Me.pnSingle.Size = New System.Drawing.Size(819, 76)
        Me.pnSingle.TabIndex = 77
        '
        'pnInfoEmpleado
        '
        Me.pnInfoEmpleado.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pnInfoEmpleado.Controls.Add(Me.btnFiltroTodos)
        Me.pnInfoEmpleado.Controls.Add(Me.btnFiltroMarcados)
        Me.pnInfoEmpleado.Controls.Add(Me.Button1)
        Me.pnInfoEmpleado.Controls.Add(Me.textFiltro)
        Me.pnInfoEmpleado.Controls.Add(Me.Label5)
        Me.pnInfoEmpleado.Controls.Add(Me.textNoRegistros)
        Me.pnInfoEmpleado.Controls.Add(Me.Label1)
        Me.pnInfoEmpleado.Controls.Add(Me.btnDesel)
        Me.pnInfoEmpleado.Controls.Add(Me.btnSel)
        Me.pnInfoEmpleado.Controls.Add(Me.dgvEmpleado)
        Me.pnInfoEmpleado.Location = New System.Drawing.Point(12, 110)
        Me.pnInfoEmpleado.Name = "pnInfoEmpleado"
        Me.pnInfoEmpleado.Size = New System.Drawing.Size(865, 401)
        Me.pnInfoEmpleado.TabIndex = 78
        '
        'btnFiltroTodos
        '
        Me.btnFiltroTodos.Location = New System.Drawing.Point(710, 4)
        Me.btnFiltroTodos.Name = "btnFiltroTodos"
        Me.btnFiltroTodos.Size = New System.Drawing.Size(98, 23)
        Me.btnFiltroTodos.TabIndex = 95
        Me.btnFiltroTodos.Text = "Ver todos"
        Me.btnFiltroTodos.UseVisualStyleBackColor = True
        '
        'btnFiltroMarcados
        '
        Me.btnFiltroMarcados.Location = New System.Drawing.Point(598, 4)
        Me.btnFiltroMarcados.Name = "btnFiltroMarcados"
        Me.btnFiltroMarcados.Size = New System.Drawing.Size(106, 23)
        Me.btnFiltroMarcados.TabIndex = 94
        Me.btnFiltroMarcados.Text = "Solo ver marcados"
        Me.btnFiltroMarcados.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button1.Location = New System.Drawing.Point(317, 371)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(95, 23)
        Me.Button1.TabIndex = 93
        Me.Button1.Text = "Carga Archivo"
        Me.Button1.UseVisualStyleBackColor = True
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
        Me.textNoRegistros.Location = New System.Drawing.Point(725, 374)
        Me.textNoRegistros.Name = "textNoRegistros"
        Me.textNoRegistros.ReadOnly = True
        Me.textNoRegistros.Size = New System.Drawing.Size(125, 24)
        Me.textNoRegistros.TabIndex = 85
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(648, 381)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 13)
        Me.Label1.TabIndex = 84
        Me.Label1.Text = "No. Registros:"
        '
        'btnDesel
        '
        Me.btnDesel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnDesel.Location = New System.Drawing.Point(162, 371)
        Me.btnDesel.Name = "btnDesel"
        Me.btnDesel.Size = New System.Drawing.Size(137, 23)
        Me.btnDesel.TabIndex = 83
        Me.btnDesel.Text = "Deseleccionar a todos"
        Me.btnDesel.UseVisualStyleBackColor = True
        '
        'btnSel
        '
        Me.btnSel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSel.Location = New System.Drawing.Point(9, 371)
        Me.btnSel.Name = "btnSel"
        Me.btnSel.Size = New System.Drawing.Size(137, 23)
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
        Me.dgvEmpleado.Location = New System.Drawing.Point(9, 30)
        Me.dgvEmpleado.Name = "dgvEmpleado"
        Me.dgvEmpleado.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvEmpleado.Size = New System.Drawing.Size(842, 335)
        Me.dgvEmpleado.TabIndex = 81
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PgBar)
        Me.Panel2.Location = New System.Drawing.Point(0, 553)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(883, 35)
        Me.Panel2.TabIndex = 79
        '
        'PgBar
        '
        Me.PgBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PgBar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PgBar.Location = New System.Drawing.Point(7, 5)
        Me.PgBar.Name = "PgBar"
        Me.PgBar.Size = New System.Drawing.Size(870, 23)
        Me.PgBar.TabIndex = 70
        '
        'btnConsultar
        '
        Me.btnConsultar.BackColor = System.Drawing.SystemColors.Control
        Me.btnConsultar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnConsultar.ImageKey = "buscar2.png"
        Me.btnConsultar.ImageList = Me.ImageNuevos
        Me.btnConsultar.Location = New System.Drawing.Point(741, 70)
        Me.btnConsultar.Name = "btnConsultar"
        Me.btnConsultar.Size = New System.Drawing.Size(79, 30)
        Me.btnConsultar.TabIndex = 80
        Me.btnConsultar.Text = "Buscar"
        Me.btnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnConsultar.UseVisualStyleBackColor = False
        '
        'ofdArchivo
        '
        Me.ofdArchivo.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*"""
        '
        'frmEliminaNomi
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(883, 587)
        Me.Controls.Add(Me.btnConsultar)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnInfoEmpleado)
        Me.Controls.Add(Me.pnSingle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnEjecutar)
        Me.Controls.Add(Me.gpEmpresa)
        Me.Controls.Add(Me.gpInfoPri)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmEliminaNomi"
        Me.Text = "Eliminación de Registros de Nómina"
        Me.gpInfoPri.ResumeLayout(False)
        Me.gpInfoPri.PerformLayout()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        Me.gpChofer.ResumeLayout(False)
        Me.gpChofer.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.pnSingle.ResumeLayout(False)
        Me.pnInfoEmpleado.ResumeLayout(False)
        Me.pnInfoEmpleado.PerformLayout()
        CType(Me.dgvEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        TextAño.Text = Today.Year
        cadena = "select nombre from meses order by mes"
        llena_combo(cadena, cmbMes)
        cmbMes.Items.Add("")
        TextAño.Text = System.DateTime.Now.Year
        EscribeEmpresa(TextNombEmpresa, TextMoneEmpresa)
        cmbMes.SelectedIndex = Today.Month - 1
        cadena = "select nombre, tiponom from tiponomina1 where empresa=@empresa"
        llena_combo(cadena, cmbTipo, ListaParametros(lpara))
        llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        cmbTipo.Items.Add("")
        cmbTipo.SelectedIndex = 0
        textEmpleado.Focus()


        cmbTipo.SelectedIndex = 0
        PgBar.Minimum = 0
        PgBar.Step = 1
        textNoRegistros.Text = 0
        rbEmpleado.Checked = True
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
            .Columns("tipoper").Visible = False
            .Columns("marca").FillWeight = 10

            'AltoGridView(18, tbFamiliares, 275, 836, dgVista)
        End With
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
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = textNombreEmple.Text.Trim
        cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=@empresa and nombre like '%' + @nombre + '%' " &
                " and e.empleado in ( select empleado from contratos1 c1 " &
                "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) " &
                "order by nombre"
        numFilas = llenaTabla(cadena, tbEmpleado, ListaParametros(lpara))
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
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text.Trim
        If valida_tipo_Entero(textEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=@empresa and empleado=@empleado", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textEmpleado.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=@empresa " &
                 " and empleado=@empleado " &
                  " and e.empleado in ( select empleado from contratos1 c1 " &
                  "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) "
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraEmpleado(False)
                dr.Read()
                textNombreEmple.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
                TextConxContrato.Focus()
            Else
                MsgBox("EMPLEADO NO ACTIVO", MsgBoxStyle.Information, "Mensaje del Sistema")
                dr.Close()
                cn.Close()
                BorraEmpleado(True)
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
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text
        If textEmpleado.Text.Trim <> "" Then
            cadena = "select contrato, pu.nombre from contratos1 c1 inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                     "inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " &
                     "where e.generapago='S' and c1.empresa=@empresa and empleado=@empleado "
            Num = llenaTabla(cadena, tbContratos, ListaParametros(lpara))
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
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text
        lpara("contrato") = TextConxContrato.Text
        If TextConxContrato.Text.Trim <> "" And textEmpleado.Text.Trim <> "" Then
            cadena = "select count(*) from contratos1 c1 inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                     "where e.generapago='S' and c1.empresa=@empresa and empleado=@empleado and c1.contrato=@contrato"
            If BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                cmbTipo.Focus()
            Else
                MsgBox("NO EXISTE ESTE NUMERO DE CONTRATO ACTIVO PARA ESTE EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            End If
        Else
            TextConxContrato.Clear()
        End If
    End Sub


#End Region

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        gpInfoPri.Enabled = True
        textNoRegistros.Text = "0"
        dgvEmpleado.DataSource = Nothing
        borra_Mejorado(gpChofer, ep1)
        borra_Mejorado(gpContrato, ep1)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        Dim año As Int16
        Dim mes As Int16 = 0
        Dim modelo As cmodelo
        Dim tipoNom As String
        Dim preRe As prestamosRepositorio

        If rbEmpleado.Checked Then

            lpara.Clear()
            If Not validetError(cmbTipo, ep1) Or Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) Or
               Not validetError(textEmpleado, ep1) Or Not validetError(TextConxContrato, ep1) Then
                MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End If
            tipoNom = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)

            año = CInt(TextAño.Text)
            lpara("empresa") = empresa
            lpara("mes") = cmbMes.SelectedIndex + 1
            lpara("año") = año
            lpara("tiponom") = tipoNom
            lpara("empleado") = textEmpleado.Text
            lpara("contrato") = TextConxContrato.Text
            cadena = "select count (*) from nominas where empresa=@empresa and mes=@mes and año=@año and tiponom=@tiponom and empleado=@empleado and contrato=@contrato"
            If BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                If MsgBox("EXISTEN REGISTROS PARA ESTE EMPLEADO Y ESTE CONTRATO. ¿ESTA SEGURO QUE DESEA ELIMINAR ESTOS REGISTRO DE LA NOMINA " & cmbTipo.Text.Trim & "? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                    Exit Sub
                End If
            Else
                MsgBox("ESTE EMPLEADO NO TIENE REGISTROS GENERADOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            End If
            modelo = New cmodelo

            Try


                cadena = "delete from nominas where empresa=@empresa and mes=@mes and año=@año and tiponom=@tiponom and empleado=@empleado and contrato=@contrato"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                preRe = New prestamosRepositorio(modelo)
                preRe.eliminacion_prestamo(empresa, tipoNom, cmbMes.SelectedIndex + 1, año, CInt(textEmpleado.Text), CType(TextConxContrato.Text, Int16))

                If modelo.Commit() Then
                    InsertBitacora(9, 4, $"Eliminación registro nómina empresa {empresa} tiponomina {tipoNom} mes { cmbMes.SelectedIndex + 1} año {año} empleado { textEmpleado.Text} contrato { TextConxContrato.Text}")
                    MsgBox("OPERACION REALIZA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                    btnLimpiar_Click(sender, e)
                End If
            Catch ex As Exception
                MsgBox("Error del sistema: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                modelo.RollBack()
            End Try
        ElseIf rbSeleccion.Checked Then

            If dgvEmpleado.DataSource IsNot Nothing Then
                Try
                    Dim exito As Boolean = True

                    lpara.Clear()
                    If Not validetError(cmbTipo, ep1) Or Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) Then
                        MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                        Exit Sub
                    End If

                    tipoNom = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)

                    Dim contador = tbEmple.AsEnumerable().Where(Function(x) x.Field(Of Boolean)("marca") = True).Count()
                    If contador = 0 Then
                        MsgBox("No ha seleccionado empleados para eliminar ", MsgBoxStyle.Exclamation)
                        Exit Sub
                    End If

                    mes = cmbMes.SelectedIndex + 1
                    año = CInt(TextAño.Text)
                    lpara("empresa") = empresa
                    lpara("mes") = cmbMes.SelectedIndex + 1
                    lpara("año") = año
                    lpara("tiponom") = tipoNom
                    lpara("empleado") = textEmpleado.Text
                    lpara("contrato") = TextConxContrato.Text


                    For Each fila As DataRow In tbEmple.Rows
                        If (fila("marca") = True) Then
                            lpara("empleado") = fila("empleado")
                            lpara("contrato") = fila("contrato")
                            modelo = New cmodelo
                            Try
                                cadena = "delete from nominas where empresa=@empresa and mes=@mes and año=@año and tiponom=@tiponom and empleado=@empleado and contrato=@contrato"
                                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                preRe = New prestamosRepositorio(modelo)
                                preRe.eliminacion_prestamo(empresa, tipoNom, mes, año, fila("empleado"), fila("contrato"))
                                If modelo.Commit() Then
                                    InsertBitacora(9, 4, $"Eliminación registro nómina empresa {empresa} tiponomina {tipoNom} mes { cmbMes.SelectedIndex + 1} año {año} empleado { textEmpleado.Text} contrato { TextConxContrato.Text}")
                                    exito = exito And True
                                Else
                                    exito = exito And False
                                End If
                            Catch ex As Exception
                                modelo.RollBack()
                                MsgBox($"Error al eliminar el registro de empleado {fila("empleado")} contrato {fila("contrato")} " & ex.Message)
                            End Try

                        End If
                    Next
                    If exito Then
                        MsgBox("Eliminación de los empleados seleccionados, realizada con éxito", MsgBoxStyle.Information)
                        dgvEmpleado.DataSource = Nothing
                    End If
                Catch ex As Exception
                    MsgBox("Error del sistema " & ex.Message)
                End Try
            End If



        End If



    End Sub

    Private Sub cmbMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub rbSeleccion_CheckedChanged(sender As Object, e As EventArgs) Handles rbEmpleado.CheckedChanged
        If rbEmpleado.Checked Then
            pnInfoEmpleado.Visible = False
            pnSingle.Visible = True
            btnConsultar.Visible = False
        Else
            btnConsultar.Visible = True
            pnInfoEmpleado.Visible = True
            pnSingle.Visible = False
        End If

    End Sub

    Private Sub TextAño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextAño.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub textFiltro_TextChanged(sender As Object, e As EventArgs) Handles textFiltro.TextChanged
        If dgvEmpleado.DataSource IsNot Nothing Then
            Dim tbDat As DataTable = dgvEmpleado.DataSource
            If textFiltro.Text.Trim <> "" Then
                tbDat.DefaultView.RowFilter = $" nombre like '%{ textFiltro.Text}%' "
            Else
                tbDat.DefaultView.RowFilter = ""
            End If
        End If
    End Sub

    Private Sub dgvEmpleado_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleado.CellValueChanged
        If dgvEmpleado.Columns(e.ColumnIndex).Name = "marca" Then
            Try

                Dim contador = tbEmple.AsEnumerable().Where(Function(x) x.Field(Of Boolean)("marca") = True).Count()
                textNoRegistros.Text = contador
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub btnConsultar_Click(sender As Object, e As EventArgs) Handles btnConsultar.Click
        Dim mes, año As Short
        mes = 0
        año = 0
        If Not validetError(cmbTipo, ep1) Or Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) And
            Short.TryParse(TextAño.Text, año) Then

            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        mes = cmbMes.SelectedIndex + 1
        Dim tbEmple2 As DataTable = empleCtr.GetEmpleadosContrato(empresa)
        tbEmple2.Columns.Add("marca", Type.GetType("System.Boolean"))
        For Each fila As DataRow In tbEmple2.Rows
            fila("marca") = False
        Next
        tbEmple2.Columns("marca").AllowDBNull = False
        Dim tiponom As String = tbTipo.Rows(cmbTipo.SelectedIndex)("tiponom")

        Dim tbNomi As DataTable = nomCtr.GetNominas(empresa, tiponom, mes, año)
        If tbNomi.Rows.Count = 0 Then
            MsgBox("No existen registros para está nómina.", MsgBoxStyle.Exclamation)
            dgvEmpleado.DataSource = Nothing
            Exit Sub
        End If

        Dim filas As List(Of DataRow) = (From a In tbEmple2.AsEnumerable
                                         Where tbNomi.AsEnumerable.Where(Function(x) x.Field(Of Integer)("empleado") = a.Field(Of Integer)("empleado") And
                       x.Field(Of Short)("contrato") = a.Field(Of Short)("contrato")).Count > 0
                                         Select a).ToList()
        tbEmple = tbEmple2.Clone()
        For Each ele As DataRow In filas
            tbEmple.ImportRow(ele)
        Next



        dgvEmpleado.DataSource = tbEmple
        Vista1(dgvEmpleado)
    End Sub

    Private Sub btnSel_Click(sender As Object, e As EventArgs) Handles btnSel.Click
        If dgvEmpleado.DataSource IsNot Nothing Then
            Dim tbData As DataTable = dgvEmpleado.DataSource
            marca_campos(tbData, True)
        End If

    End Sub

    Private Sub btnDesel_Click(sender As Object, e As EventArgs) Handles btnDesel.Click
        If dgvEmpleado.DataSource IsNot Nothing Then
            Dim tbData As DataTable = dgvEmpleado.DataSource
            marca_campos(tbData, False)
        End If
    End Sub


    Private Sub marca_campos(tb As DataTable, valor As Boolean)
        For Each dr As DataRow In tb.Rows
            dr("marca") = valor
        Next
        If valor = False Then
            textNoRegistros.Text = "0.00"
        Else
            textNoRegistros.Text = tb.Rows.Count
        End If
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

                    fila = tbEmple.AsEnumerable().Where(Function(x) x.Field(Of Int32)("empleado") = ele.empleado And x.Field(Of Short)("contrato")).FirstOrDefault()
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

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
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
End Class
