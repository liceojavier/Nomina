Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMIMPRESIONCHEQUE.VB MIEMBRO DE NOMINA.SLN                                 **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmImpresionCheque
    Inherits Form
    Dim cadena As String
    Dim tbForma As New DataTable("forma")
    Dim tbDatos As New DataTable("datos")
    Dim tbTipo As New DataTable("tipo")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim fpago, maximo, minimo, banco, minimoOri, maximoOri As Integer
    Dim moneda, cuentaBanco, cuentaNom, tipoNom As String
    Dim tasaOri As Decimal
    Dim v As New ChequeNery
    Dim tt As New DataTable("impresion")
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Dim ObLetras As New ValoresLetras
    Dim lpara As New Dictionary(Of String, Object)

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
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextMoneEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents stbPanel As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents gpFormaPago As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextChequeF As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBanco As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents TextNombBanco As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents TextAño As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImpresionCheque))
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TextChequeF = New System.Windows.Forms.TextBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextCheque = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextMoneEmpresa = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.stbPanel = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gpFormaPago = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBanco = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.TextNombBanco = New System.Windows.Forms.TextBox()
        Me.PgBar = New System.Windows.Forms.ProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
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
        Me.gpFecha.Controls.Add(Me.Label8)
        Me.gpFecha.Controls.Add(Me.Label7)
        Me.gpFecha.Controls.Add(Me.Label6)
        Me.gpFecha.Controls.Add(Me.TextAño)
        Me.gpFecha.Controls.Add(Me.Label11)
        Me.gpFecha.Controls.Add(Me.cmbTipo)
        Me.gpFecha.Controls.Add(Me.TextChequeF)
        Me.gpFecha.Controls.Add(Me.btnEjecutar)
        Me.gpFecha.Controls.Add(Me.cmbMes)
        Me.gpFecha.Controls.Add(Me.Label3)
        Me.gpFecha.Controls.Add(Me.TextCheque)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.Location = New System.Drawing.Point(9, 102)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(1033, 82)
        Me.gpFecha.TabIndex = 2
        Me.gpFecha.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 20
        Me.Label8.Text = "Tipo de nómina:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(315, 21)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Mes:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(489, 21)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Año:"
        '
        'TextAño
        '
        Me.TextAño.BackColor = System.Drawing.Color.White
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(530, 21)
        Me.TextAño.MaxLength = 4
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(57, 20)
        Me.TextAño.TabIndex = 3
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(766, 21)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(69, 13)
        Me.Label11.TabIndex = 10
        Me.Label11.Text = "Cheque final:"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(97, 21)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(208, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'TextChequeF
        '
        Me.TextChequeF.BackColor = System.Drawing.Color.White
        Me.TextChequeF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextChequeF.Location = New System.Drawing.Point(846, 21)
        Me.TextChequeF.MaxLength = 9
        Me.TextChequeF.Name = "TextChequeF"
        Me.TextChequeF.Size = New System.Drawing.Size(71, 20)
        Me.TextChequeF.TabIndex = 5
        '
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "impresora2.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(923, 15)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(88, 30)
        Me.btnEjecutar.TabIndex = 6
        Me.btnEjecutar.Text = "Impresión"
        Me.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.cmbMes.Location = New System.Drawing.Point(353, 21)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(121, 21)
        Me.cmbMes.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(599, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Cheque inicial:"
        '
        'TextCheque
        '
        Me.TextCheque.BackColor = System.Drawing.Color.White
        Me.TextCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCheque.Location = New System.Drawing.Point(685, 21)
        Me.TextCheque.MaxLength = 9
        Me.TextCheque.Name = "TextCheque"
        Me.TextCheque.Size = New System.Drawing.Size(71, 20)
        Me.TextCheque.TabIndex = 4
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
        Me.gpEmpresa.Location = New System.Drawing.Point(339, 2)
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
        Me.TextMoneEmpresa.Location = New System.Drawing.Point(408, 13)
        Me.TextMoneEmpresa.Name = "TextMoneEmpresa"
        Me.TextMoneEmpresa.ReadOnly = True
        Me.TextMoneEmpresa.Size = New System.Drawing.Size(40, 21)
        Me.TextMoneEmpresa.TabIndex = 18
        Me.TextMoneEmpresa.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(341, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Moneda:"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(6, 15)
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(330, 21)
        Me.TextNombEmpresa.TabIndex = 2
        Me.TextNombEmpresa.TabStop = False
        '
        'stbPanel
        '
        Me.stbPanel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.stbPanel.Location = New System.Drawing.Point(0, 318)
        Me.stbPanel.Name = "stbPanel"
        Me.stbPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.stbPanel.Size = New System.Drawing.Size(1134, 24)
        Me.stbPanel.TabIndex = 71
        Me.stbPanel.Text = "Realiza el ingreso de los puestos."
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(1119, 19)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Realiza la impresión de cheques de Nómina"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'gpFormaPago
        '
        Me.gpFormaPago.BackColor = System.Drawing.Color.AliceBlue
        Me.gpFormaPago.Controls.Add(Me.Label4)
        Me.gpFormaPago.Controls.Add(Me.TextBanco)
        Me.gpFormaPago.Controls.Add(Me.Label2)
        Me.gpFormaPago.Controls.Add(Me.cmbFormaPago)
        Me.gpFormaPago.Controls.Add(Me.TextNombBanco)
        Me.gpFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFormaPago.Location = New System.Drawing.Point(9, 55)
        Me.gpFormaPago.Name = "gpFormaPago"
        Me.gpFormaPago.Size = New System.Drawing.Size(664, 43)
        Me.gpFormaPago.TabIndex = 1
        Me.gpFormaPago.TabStop = False
        Me.gpFormaPago.Text = "Forma de pago"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(232, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Banco:"
        '
        'TextBanco
        '
        Me.TextBanco.BackColor = System.Drawing.Color.White
        Me.TextBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBanco.Location = New System.Drawing.Point(283, 14)
        Me.TextBanco.MaxLength = 4
        Me.TextBanco.Name = "TextBanco"
        Me.TextBanco.ReadOnly = True
        Me.TextBanco.Size = New System.Drawing.Size(57, 20)
        Me.TextBanco.TabIndex = 2
        Me.TextBanco.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(367, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre:"
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.Location = New System.Drawing.Point(6, 16)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(208, 21)
        Me.cmbFormaPago.TabIndex = 1
        '
        'TextNombBanco
        '
        Me.TextNombBanco.BackColor = System.Drawing.Color.White
        Me.TextNombBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombBanco.Location = New System.Drawing.Point(422, 13)
        Me.TextNombBanco.MaxLength = 4
        Me.TextNombBanco.Name = "TextNombBanco"
        Me.TextNombBanco.ReadOnly = True
        Me.TextNombBanco.Size = New System.Drawing.Size(232, 20)
        Me.TextNombBanco.TabIndex = 3
        Me.TextNombBanco.TabStop = False
        '
        'PgBar
        '
        Me.PgBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PgBar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PgBar.Location = New System.Drawing.Point(7, 6)
        Me.PgBar.Name = "PgBar"
        Me.PgBar.Size = New System.Drawing.Size(1121, 23)
        Me.PgBar.TabIndex = 73
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1134, 51)
        Me.Panel1.TabIndex = 74
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PgBar)
        Me.Panel2.Location = New System.Drawing.Point(0, 284)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1134, 38)
        Me.Panel2.TabIndex = 75
        '
        'frmImpresionCheque
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1134, 342)
        Me.Controls.Add(Me.gpFormaPago)
        Me.Controls.Add(Me.stbPanel)
        Me.Controls.Add(Me.gpFecha)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmImpresionCheque"
        Me.Text = "Impresión de Cheques de Nómina"
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
        lpara.Clear()
        cadena = "select nombre from meses order by mes"
        llena_combo(cadena, cmbMes)
        cmbMes.Items.Add("")
        TextAño.Text = System.DateTime.Now.Year
        EscribeEmpresa(TextNombEmpresa, TextMoneEmpresa)
        cmbMes.SelectedIndex = System.DateTime.Now.Month - 1
        lpara("empresa") = empresa
        cadena = "select nombre, tiponom, cuenta from tiponomina1 where empresa=@empresa order by tiponom"
        llena_combo(cadena, cmbTipo, ListaParametros(lpara))
        llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        cmbTipo.Items.Add("")
        cadena = "SELECT fp.nombre, fpago, fp.BANCO, b.nombre + ' CTA ' + bc.cta  AS nombBanco, bc.moneda, m.tasa, bc.cuenta " &
                 "FROM formapagoper fp inner join bancoscta bc on fp.empresa=bc.empresa and fp.banco=bc.banco " &
                 "inner join bancos b on b.empresa=fp.empresa and b.codigo=bc.codigo " &
                 "inner join monedasban m on  m.moneda=bc.moneda " &
                 "where fp.empresa=@empresa " &
                 " and tipoforma ='C' order by fp.banco"
        llena_combo(cadena, cmbFormaPago, ListaParametros(lpara))
        llenaTabla(cadena, tbForma, ListaParametros(lpara))
        cmbFormaPago.Items.Add("")
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        lpara.Clear()
        Dim nombCuentaBanco, nombCuentaNom, concepto As String
        Dim NoCheques, existeAux, mes, año, i, auxi As Integer
        Dim montoCh, tasa, tasaEs As Decimal
        Dim fila As DataRow
        If Not validetError(cmbTipo, ep1) Or Not validetError(TextCheque, ep1) Or Not validetError(TextChequeF, ep1) Or
            Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) Then
            MsgBox("LLENE TODO LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If Not Int32.TryParse(TextCheque.Text, minimo) Or Not Int32.TryParse(TextChequeF.Text, maximo) Then
            MsgBox("Ingrese los números de cheque")
            Exit Sub
        End If

        If minimo = 0 Then
            MsgBox("NO EXISTEN CHEQUES GENEREDOS PARA ESTE PAGO", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        ElseIf maximo < minimo Then
            MsgBox("EL CHEQUE FINAL DEBE SER MAYOR AL CHEQUE INICIAL", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        If MsgBox("ESTA SEGURO QUE DESEA IMPRIMIR EL CHEQUE No. " & minimo & " AL CHEQUE " & maximo, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            NoCheques = maximo - minimo
            If TextMoneEmpresa.Text.Trim = moneda Then
                tasa = 1
                tasaEs = 0
            Else
                tasa = tasaOri
                tasaEs = tasaOri
            End If
            mes = cmbMes.SelectedIndex + 1
            año = CInt(TextAño.Text)

            lpara("empresa") = empresa
            lpara("cuentaBanco") = cuentaBanco
            lpara("cuentaNom") = cuentaNom
            lpara("mes") = mes
            lpara("año") = año
            lpara("fpago") = fpago
            lpara("tipoNom") = tipoNom
            lpara("minimo") = minimo
            lpara("maximo") = maximo
            nombCuentaBanco = BuscaEscalar("select nombre from nomencla where cuenta=@cuentaBanco and empresa=@empresa ", ListaParametros(lpara))
            nombCuentaNom = BuscaEscalar("select nombre from nomencla where cuenta=@cuentaNom and empresa=@empresa ", ListaParametros(lpara))

            cadena = "select * from reporte_chequeNomina"
            llenaTablaBatch(cadena, tt)

            cadena = "select count(*) from auxiliarcta where empresa=@empresa and cuenta=@cuentaNom and origen='000'"
            existeAux = BuscaEscalar(cadena, ListaParametros(lpara))

            cadena = "select mes, año, fpago, docto, fecha, pg.empleado, contrato, monto, nombre, pg.fechae " &
                     "from pagosnom pg  inner join v_empleadoReves emp on pg.empresa=emp.empresa and pg.empleado=emp.empleado " &
                     "where  pg.empresa =@empresa And mes=@mes And año=@año  And fpago =@fpago " &
                      " and tiponom=@tipoNom and docto between @minimo and @maximo order by docto"
            llenaTabla(cadena, tbDatos, ListaParametros(lpara))

            PgBar.Maximum = tbDatos.Rows.Count
            NoCheques = 0
            For i = 0 To tbDatos.Rows.Count - 1
                PgBar.PerformStep()
                filaTemp = tbDatos.Rows(i)
                '   cadena = "select count(*) from cheque1 where empresa=" & empresa & " and banco=" & banco & " and cheque=" & _
                '  filaTemp.Item(3)
                ' repetido = BuscaEscalar(cadena)
                If filaTemp.Item("monto") > 0 Then ' And repetido = 0 Then
                    NoCheques = NoCheques + 1
                    If existeAux > 0 Then
                        auxi = filaTemp.Item(5)
                    Else
                        auxi = 0
                    End If
                    montoCh = Decimal.Round((filaTemp.Item("monto") / tasa), 2)
                    concepto = "PAGO DE NOMINA " & cmbTipo.Text.Trim &
                    " " & cmbMes.Text.Trim & " " & TextAño.Text
                    fila = tt.NewRow
                    fila.Item(0) = "000"
                    fila.Item(1) = filaTemp.Item(8)
                    fila.Item(2) = "NOMINA"
                    fila.Item(3) = filaTemp.Item(3)
                    fila.Item(4) = filaTemp.Item(4)
                    fila.Item(5) = montoCh
                    fila.Item(6) = cuentaNom
                    fila.Item(7) = ObLetras.Inicializacion(CStr(montoCh)).ToUpper
                    fila.Item(8) = montoCh
                    fila.Item(9) = 0
                    fila.Item(10) = concepto
                    fila.Item(11) = nombCuentaNom
                    tt.Rows.Add(fila)
                    fila = tt.NewRow
                    fila.Item(0) = "000"
                    fila.Item(1) = filaTemp.Item(8)
                    fila.Item(2) = "NOMINA"
                    fila.Item(3) = filaTemp.Item(3)
                    fila.Item(4) = filaTemp.Item(4)
                    fila.Item(5) = montoCh
                    fila.Item(6) = cuentaBanco
                    fila.Item(7) = ObLetras.Inicializacion(CStr(montoCh)).ToUpper
                    fila.Item(8) = 0
                    fila.Item(9) = montoCh
                    fila.Item(10) = concepto
                    fila.Item(11) = nombCuentaBanco
                    tt.Rows.Add(fila)
                End If
            Next i
            cn.Close()
            PgBar.Value = 0

            If (tt.Rows.Count > 0) Then
                v.SetDataSource(tt)
                v.Refresh()

                Dim rawKind As Integer
                Dim doctoprint As New PrintDocument
                Dim IJ As Int32
                Dim nombrePrinter As String
                Dim printOptions1 As PrintOptions = v.PrintOptions
                nombrePrinter = doctoprint.PrinterSettings.PrinterName
                For IJ = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
                    If doctoprint.PrinterSettings.PaperSizes(IJ).PaperName.ToUpper = "ChequeIvan".ToUpper Then
                        Dim ps = New System.Drawing.Printing.PrinterSettings
                        Dim psize = New System.Drawing.Printing.PaperSize

                        rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(IJ).GetType().GetField("kind",
                           Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(IJ)))
                        printOptions1.PaperSize = doctoprint.PrinterSettings.PaperSizes(IJ).RawKind
                        'v.PrintOptions.PaperSize = rawKind
                        ' v.PrintOptions.CopyFrom(ps, psize)
                        Exit For
                    End If
                Next
                printOptions1.PrinterName = nombrePrinter
                v.PrintToPrinter(1, False, 1, NoCheques)
                InsertBitacora(9, 5, $"Impresión cheque nomina { cmbTipo.Text} mes { cmbMes.Text} año { TextAño.Text} del cheque {TextCheque.Text} al {TextChequeF.Text} ")
                MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            Else
                MsgBox("PAGO NO SE ENCUENTRA ACTIVO O CHEQUE NO EXISTE", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            End If

        End If
    End Sub

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        If cmbFormaPago.Text.Trim <> "" Then
            filaTemp = tbForma.Rows(cmbFormaPago.SelectedIndex)
            fpago = filaTemp.Item(1)
            TextBanco.Text = filaTemp.Item(2)
            banco = filaTemp.Item(2)
            TextNombBanco.Text = filaTemp.Item(3)
            moneda = filaTemp.Item(4)
            tasaOri = filaTemp.Item(5)
            cuentaBanco = filaTemp.Item(6)
        Else
            cmbTipo.Text = ""
            TextBanco.Clear()
            TextNombBanco.Clear()
        End If
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged, cmbMes.SelectedIndexChanged, TextAño.Validated
        lpara.Clear()
        If cmbFormaPago.Text.Trim <> "" Then
            If cmbTipo.Text.Trim <> "" And cmbMes.Text.Trim <> "" And TextAño.Text.Trim <> "" Then
                TextCheque.Enabled = True
                TextChequeF.Enabled = True
                btnEjecutar.Enabled = True
                filaTemp = tbTipo.Rows(cmbTipo.SelectedIndex)
                tipoNom = filaTemp.Item(1)
                cuentaNom = filaTemp.Item(2)
                lpara("empresa") = empresa
                lpara("tiponom") = filaTemp.Item(1)
                lpara("fpago") = fpago
                lpara("mes") = cmbMes.SelectedIndex + 1
                lpara("año") = CInt(TextAño.Text)
                cadena = "select coalesce( min(docto), 0) from pagosnom where tipoforma='C' and estado=0 and docto <> 0 " &
                         "and empresa=@empresa and tiponom=@tiponom and fpago=@fpago and mes=@mes " &
                         " and año=@año"
                minimo = BuscaEscalar(cadena, ListaParametros(lpara))

                cadena = "select coalesce( max(docto), 0) from pagosnom where tipoforma='C' and estado=0 and docto <> 0 " &
                         "and empresa=@empresa and tiponom=@tiponom and fpago=@fpago and mes=@mes" &
                         " and año=@año"
                maximo = BuscaEscalar(cadena, ListaParametros(lpara))
                cn.Close()
                minimoOri = minimo
                maximoOri = maximo
                TextCheque.Text = minimo
                TextChequeF.Text = maximo
            Else
                TextCheque.Clear()
                TextChequeF.Clear()
                btnEjecutar.Enabled = False
                TextCheque.Enabled = False
                TextChequeF.Enabled = False
            End If
        Else
            TextCheque.Enabled = False
            TextChequeF.Enabled = False
            TextCheque.Clear()
            TextChequeF.Clear()
            btnEjecutar.Enabled = False
        End If
    End Sub


    Private Sub TextCheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextCheque.KeyPress, TextChequeF.KeyPress
        soloNumero(sender, e)
    End Sub


    Private Sub cmbMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub TextAño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        soloNumero(sender, e)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub
End Class
