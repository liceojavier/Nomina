Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMGENERAPAGOCHEQUES.VB MIEMBRO DE NOMINA.SLN                               **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmGeneraPagoCheques
    Inherits Form
    Dim cadena As String
    Dim tbForma As New DataTable("pago")
    Dim tbDatos As New DataTable("datos")
    Dim tbTipo As New DataTable("tipo")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim lpara As New Dictionary(Of String, Object)
    Friend WithEvents dtpFecha As DateTimePicker
    Dim tt As New DataTable("datos")



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
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents TextAño As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextMoneEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents PgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents stbPanel As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents gpFormaPago As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents TextNombBanco As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBanco As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextChequeF As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel2 As System.Windows.Forms.Panel

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGeneraPagoCheques))
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextMoneEmpresa = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.PgBar = New System.Windows.Forms.ProgressBar()
        Me.stbPanel = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gpFormaPago = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextChequeF = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBanco = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextCheque = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.TextNombBanco = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.gpFecha.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        Me.stbPanel.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpFormaPago.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpFecha
        '
        Me.gpFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.gpFecha.Controls.Add(Me.dtpFecha)
        Me.gpFecha.Controls.Add(Me.Label9)
        Me.gpFecha.Controls.Add(Me.Label8)
        Me.gpFecha.Controls.Add(Me.Label7)
        Me.gpFecha.Controls.Add(Me.Label6)
        Me.gpFecha.Controls.Add(Me.cmbTipo)
        Me.gpFecha.Controls.Add(Me.TextAño)
        Me.gpFecha.Controls.Add(Me.btnEjecutar)
        Me.gpFecha.Controls.Add(Me.cmbMes)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.Location = New System.Drawing.Point(11, 121)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(968, 71)
        Me.gpFecha.TabIndex = 2
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Tipo y periodo"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(528, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Año:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(47, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(86, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Tipo  de nómina:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(362, 35)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Mes:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(636, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Fecha de pago:"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(148, 32)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(208, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'TextAño
        '
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(564, 30)
        Me.TextAño.MaxLength = 4
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(56, 20)
        Me.TextAño.TabIndex = 3
        '
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageKey = "actualizar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(896, 19)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(60, 30)
        Me.btnEjecutar.TabIndex = 5
        Me.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnEjecutar, "Generar el proceso")
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
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(397, 31)
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
        Me.gpEmpresa.Location = New System.Drawing.Point(261, 6)
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
        Me.Label10.Location = New System.Drawing.Point(339, 19)
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
        Me.PgBar.Location = New System.Drawing.Point(7, 5)
        Me.PgBar.Name = "PgBar"
        Me.PgBar.Size = New System.Drawing.Size(965, 23)
        Me.PgBar.TabIndex = 70
        '
        'stbPanel
        '
        Me.stbPanel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.stbPanel.Location = New System.Drawing.Point(0, 230)
        Me.stbPanel.Name = "stbPanel"
        Me.stbPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.stbPanel.Size = New System.Drawing.Size(979, 24)
        Me.stbPanel.TabIndex = 71
        Me.stbPanel.Text = "Realiza el ingreso de los puestos."
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(964, 19)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Realiza la generación de cheques de pago de la nómina del personal en calidad de " &
    "dependencia"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'gpFormaPago
        '
        Me.gpFormaPago.BackColor = System.Drawing.Color.AliceBlue
        Me.gpFormaPago.Controls.Add(Me.Label11)
        Me.gpFormaPago.Controls.Add(Me.TextChequeF)
        Me.gpFormaPago.Controls.Add(Me.Label4)
        Me.gpFormaPago.Controls.Add(Me.TextBanco)
        Me.gpFormaPago.Controls.Add(Me.Label3)
        Me.gpFormaPago.Controls.Add(Me.TextCheque)
        Me.gpFormaPago.Controls.Add(Me.Label2)
        Me.gpFormaPago.Controls.Add(Me.cmbFormaPago)
        Me.gpFormaPago.Controls.Add(Me.TextNombBanco)
        Me.gpFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFormaPago.Location = New System.Drawing.Point(11, 56)
        Me.gpFormaPago.Name = "gpFormaPago"
        Me.gpFormaPago.Size = New System.Drawing.Size(968, 51)
        Me.gpFormaPago.TabIndex = 1
        Me.gpFormaPago.TabStop = False
        Me.gpFormaPago.Text = "Forma de pago"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(811, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Cheque final:"
        '
        'TextChequeF
        '
        Me.TextChequeF.BackColor = System.Drawing.Color.White
        Me.TextChequeF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextChequeF.Location = New System.Drawing.Point(885, 16)
        Me.TextChequeF.MaxLength = 4
        Me.TextChequeF.Name = "TextChequeF"
        Me.TextChequeF.ReadOnly = True
        Me.TextChequeF.Size = New System.Drawing.Size(71, 20)
        Me.TextChequeF.TabIndex = 9
        Me.TextChequeF.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(194, 16)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Banco:"
        '
        'TextBanco
        '
        Me.TextBanco.BackColor = System.Drawing.Color.White
        Me.TextBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBanco.Location = New System.Drawing.Point(240, 13)
        Me.TextBanco.MaxLength = 4
        Me.TextBanco.Name = "TextBanco"
        Me.TextBanco.ReadOnly = True
        Me.TextBanco.Size = New System.Drawing.Size(57, 20)
        Me.TextBanco.TabIndex = 7
        Me.TextBanco.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(644, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Cheque inicial:"
        '
        'TextCheque
        '
        Me.TextCheque.BackColor = System.Drawing.Color.White
        Me.TextCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCheque.Location = New System.Drawing.Point(725, 16)
        Me.TextCheque.MaxLength = 4
        Me.TextCheque.Name = "TextCheque"
        Me.TextCheque.ReadOnly = True
        Me.TextCheque.Size = New System.Drawing.Size(71, 20)
        Me.TextCheque.TabIndex = 5
        Me.TextCheque.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(303, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre:"
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.Location = New System.Drawing.Point(6, 15)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(172, 21)
        Me.cmbFormaPago.TabIndex = 1
        '
        'TextNombBanco
        '
        Me.TextNombBanco.BackColor = System.Drawing.Color.White
        Me.TextNombBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombBanco.Location = New System.Drawing.Point(356, 14)
        Me.TextNombBanco.MaxLength = 4
        Me.TextNombBanco.Name = "TextNombBanco"
        Me.TextNombBanco.ReadOnly = True
        Me.TextNombBanco.Size = New System.Drawing.Size(283, 20)
        Me.TextNombBanco.TabIndex = 3
        Me.TextNombBanco.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(979, 55)
        Me.Panel1.TabIndex = 72
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PgBar)
        Me.Panel2.Location = New System.Drawing.Point(0, 198)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(979, 36)
        Me.Panel2.TabIndex = 73
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(725, 29)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(106, 20)
        Me.dtpFecha.TabIndex = 11
        '
        'frmGeneraPagoCheques
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(979, 254)
        Me.Controls.Add(Me.gpFormaPago)
        Me.Controls.Add(Me.stbPanel)
        Me.Controls.Add(Me.gpFecha)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmGeneraPagoCheques"
        Me.Text = "Generación  de Pagos con Cheque"
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        Me.stbPanel.ResumeLayout(False)
        Me.stbPanel.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpFormaPago.ResumeLayout(False)
        Me.gpFormaPago.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub frmSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cadena = "select nombre from meses order by mes"
        llena_combo(cadena, cmbMes)
        cmbMes.Items.Add("")
        TextAño.Text = System.DateTime.Now.Year
        EscribeEmpresa(TextNombEmpresa, TextMoneEmpresa)
        cmbMes.SelectedIndex = System.DateTime.Now.Month - 1
        cadena = "select nombre, tiponom from tiponomina1 where empresa=" & empresa & " order by tiponom"
        llena_combo(cadena, cmbTipo)
        llenaTabla(cadena, tbTipo)
        cmbTipo.Items.Add("")
        cadena = "SELECT fp.nombre, fpago, tipoforma, fp.BANCO, b.nombre + ' CTA ' + bc.cta  AS nombBanco, " & _
           "bc.cheque FROM formapagoper fp inner join bancoscta bc on fp.empresa=bc.empresa and fp.banco=bc.banco " & _
           "inner join bancos b on b.empresa=fp.empresa and b.codigo=bc.codigo where fp.empresa=" & empresa & _
           " and fp.tipoforma='C' order by fp.banco"
        llena_combo(cadena, cmbFormaPago)
        llenaTabla(cadena, tbForma)
        cmbFormaPago.Items.Add("")
        PgBar.Minimum = 0
        PgBar.Step = 1



    End Sub






    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        Dim año, mes As Int16
        Dim i, fpago, banco, doctoOri, doctoEs, k, DocCheque As Int32
        Dim fechaI As Date
        Dim tipoNom, tipoforma As String
        Dim tbMovi As New DataTable("movimientos")
        lpara.Clear()

        If Not validetError(cmbFormaPago, ep1) Or Not validetError(cmbTipo, ep1) Or Not validetError(cmbMes, ep1) Or
        Not validetError(TextAño, ep1) Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If
        tipoNom = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
        fpago = tbForma.Rows(cmbFormaPago.SelectedIndex).Item(1)
        tipoforma = tbForma.Rows(cmbFormaPago.SelectedIndex).Item(2)
        banco = tbForma.Rows(cmbFormaPago.SelectedIndex).Item(3)
        año = CInt(TextAño.Text)
        mes = cmbMes.SelectedIndex + 1
        fechaI = dtpFecha.Value.Date
        Dim cmod As New cmodelo
        MsgBox("ESTE PROCESO GENERARA CHEQUES PARA TODOS LOS EMPLEADOS DE UNA NOMINA NO IMPORTANDO SU FORMA DE PAGO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        If MsgBox("ESTA SEGURO QUE DESEA GENERAR EL PAGO DE  ESTA NOMINA", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            Try
                lpara("tiponom") = tipoNom
                lpara("mes") = mes
                lpara("anio") = año
                cadena = "select count(*) from nominas where tiponom=@tiponom and mes=@mes and año=@anio"
                If cmod.BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
                    MsgBox("NO EXISTE NOMINA GENERADA, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
                lpara("fpago") = fpago
                cadena = "select count(*) from pagosnom where tiponom=@tiponom and mes=@mes and año=@anio and fpago=@fpago"
                If cmod.BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                    cadena = "select count(*) from pagosnom where tiponom=@tiponom and mes=@mes and año=@anio And fpago =@fpago And estado <> 0"
                    If cmod.BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
                        If MsgBox("YA EXISTEN REGISTROS GENERADOS, DESEA VOLVER A GENERAR EL PROCESO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.No Then
                            Exit Sub
                        Else
                            cadena = "delete from pagosnom where tiponom=@tiponom and mes=@mes and año=@anio And fpago =@fpago And estado = 0"
                            cmod.EjecutarNonQuery(cadena, ListaParametros(lpara))
                        End If
                    Else
                        MsgBox("PROCESO YA GENERADO  Y YA HAY REGISTROS ANULADOS O TRASLADADOS A CONTABILIDAD", MsgBoxStyle.Information, "Mensaje del Sistema")
                        Exit Sub
                    End If
                End If
                lpara.Clear()
                lpara("empresa") = empresa
                lpara("banco") = banco
                If tipoforma = "D" Then
                    cadena = "Select coalesce( max(docto),0) from pagosnom where tipoforma='D' and empresa=@empresa"
                    doctoOri = BuscaEscalar(cadena, ListaParametros(lpara))
                Else
                    cadena = "select coalesce( max(cheque),0) from bancoscta where empresa=@empresa and banco=@banco"
                    doctoOri = cmod.BuscaEscalar(cadena, ListaParametros(lpara))
                End If
                DocCheque = 0
                lpara("mes") = mes
                lpara("anio") = año
                lpara("tiponom") = tipoNom
                cadena = "select e.nombre, nom.empleado, nom.contrato," &
                         " coalesce(  sum (( case when t.tipomov='I' then valor  when t.tipomov='D' THEN -valor else 0 end)), 0) as val, " &
                         " coalesce (pg.tipoforma,'X') as marca " &
                         "from contratos1 c1 " &
                         "inner join v_EmpleadosNuevo e on c1.empresa=e.empresa and e.empleado=c1.empleado " &
                         "inner join nominas nom on nom.empresa=c1.empresa and nom.empleado=c1.empleado and nom.contrato=c1.contrato " &
                         "inner join tipotran t  on t.empresa=c1.empresa and t.transac=nom.transac " &
                         "left join pagosnom pg on c1.empresa=pg.empresa and nom.tiponom=pg.tiponom and  nom.mes=pg.mes and nom.año=pg.año  " &
                         " and pg.estado <> 0 " &
                         "where nom.empresa =@empresa And nom.mes=@mes And nom.año=@anio " &
                         " and nom.tiponom=@tiponom  group by nom.empleado, nom.contrato, pg.tipoforma, e.nombre " &
                         " order by e.nombre "
                cmod.llenaTabla(cadena, tbDatos, ListaParametros(lpara))
                k = 0
                PgBar.Maximum = tbDatos.Rows.Count
                For i = 0 To tbDatos.Rows.Count - 1
                    lpara.Clear()
                    PgBar.PerformStep()
                    filaTemp = tbDatos.Rows(i)
                    If filaTemp.Item("marca") = "X" Then
                        If tipoNom = "A" Then
                            filaTemp.Item("val") = Math.Abs(filaTemp.Item("val"))
                        End If
                        If filaTemp.Item("val") > 0 Then
                            k = k + 1
                            doctoEs = doctoOri + k
                            DocCheque = doctoEs
                        Else
                            doctoEs = 0
                        End If
                        lpara("empresa") = empresa
                        lpara("tipo") = tipoNom
                        lpara("mes") = mes
                        lpara("anio") = año
                        lpara("fpago") = fpago
                        lpara("tipoForma") = tipoforma
                        lpara("docto") = doctoEs
                        lpara("fecha") = fechaI
                        lpara("empleado") = filaTemp.Item("empleado")
                        lpara("contrato") = filaTemp.Item("CONTRATO")
                        lpara("val") = filaTemp.Item("val")
                        lpara("fechae") = Today
                        lpara("user") = user
                        cadena = "insert into pagosnom (empresa, tiponom,mes,año,fpago,tipoforma,docto,fecha,empleado,contrato,monto,estado,fechae,elaborado) 
                                  values(@empresa,@tipo,@mes,@anio,@fpago,@tipoForma,@docto,@fecha,@empleado,@contrato,@val,0,@fechae,@user)"
                        cmod.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    End If
                Next i
                If tipoforma = "C" And DocCheque <> 0 Then
                    cadena = "update bancoscta set cheque=" & DocCheque & " where empresa=" & empresa & " and banco=" & banco
                    cmod.EjecutarNonQuery(cadena)
                    TextChequeF.Text = doctoEs
                End If
                lpara("empresa") = empresa
                lpara("tiponom") = tipoNom
                lpara("mes") = mes
                lpara("año") = año
                lpara("fecha") = DateTime.Today
                lpara("hora") = DateTime.Now.ToString("HH:mm")
                lpara("usuario") = _usuario
                lpara("estado") = 0
                cadena = "select count(*) from nomina_registro where estado=0 and empresa=@empresa and tiponom=@tiponom and mes=@mes and año=@año"
                If cmod.BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
                    cadena = "insert into nomina_registro (empresa, tiponom, mes, año, fecha, hora, usuario, estado) values 
                          (@empresa, @tiponom, @mes, @año, @fecha, @hora, @usuario, @estado)"
                    cmod.EjecutarNonQuery(cadena, ListaParametros(lpara))
                End If



                PgBar.Value = 0
                'cn.Close()
                If cmod.Commit() Then
                    InsertBitacora(9, 7, $"Generación de pagos nómina tiponom { tipoNom} mes {mes} año {año}")
                    MsgBox("OPERACION REALIZA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If
            Catch ex As Exception
                MsgBox("Mensaje del Sistema :" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del sistem ")
                cmod.RollBack()
            End Try

            borra_Mejorado(gpFecha, ep1)
            borra_Mejorado(gpFormaPago, ep1)
        End If
    End Sub

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        TextChequeF.Clear()
        If cmbFormaPago.Text.Trim <> "" Then
            filaTemp = tbForma.Rows(cmbFormaPago.SelectedIndex)
            TextBanco.Text = filaTemp.Item(3)
            TextNombBanco.Text = filaTemp.Item(4)
            If filaTemp.Item(2) = "C" Then
                TextCheque.Text = filaTemp.Item(5) + 1
            Else
                TextCheque.Clear()
            End If

        Else
            TextBanco.Clear()
            TextNombBanco.Clear()
            TextCheque.Clear()
        End If
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

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub





   
End Class
