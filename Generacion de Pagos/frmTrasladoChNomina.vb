Imports System.Data.SqlClient
Imports System.Drawing.Printing

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMTRASLADOCHNOMINA.VB MIEMBRO DE NOMINA.SLN                                **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmTrasladoChNomina
    Inherits Form
    Dim cadena As String
    Dim tbForma As New DataTable("pago")
    Dim tbDatos As New DataTable("datos")
    Dim tbTipo As New DataTable("tipo")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim v As New ChequeNery
    Dim tt As New DataTable("impresion")
    Dim ObLetras As New ValoresLetras
    Dim cuentaBanco, cuentaNom As String
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBanco As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextTasa As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextMoneda As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrasladoChNomina))
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextMoneEmpresa = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.PgBar = New System.Windows.Forms.ProgressBar()
        Me.stbPanel = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gpFormaPago = New System.Windows.Forms.GroupBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextTasa = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextMoneda = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBanco = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.TextNombBanco = New System.Windows.Forms.TextBox()
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
        Me.gpFecha.Controls.Add(Me.Label9)
        Me.gpFecha.Controls.Add(Me.Label8)
        Me.gpFecha.Controls.Add(Me.Label7)
        Me.gpFecha.Controls.Add(Me.cmbTipo)
        Me.gpFecha.Controls.Add(Me.TextAño)
        Me.gpFecha.Controls.Add(Me.btnEjecutar)
        Me.gpFecha.Controls.Add(Me.cmbMes)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.Location = New System.Drawing.Point(9, 124)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(728, 56)
        Me.gpFecha.TabIndex = 2
        Me.gpFecha.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(505, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Año:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(17, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Tipo de nómina:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(334, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Mes:"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(116, 20)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(208, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'TextAño
        '
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(539, 20)
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
        Me.btnEjecutar.ImageKey = "checkok.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(601, 20)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(80, 30)
        Me.btnEjecutar.TabIndex = 5
        Me.btnEjecutar.Text = "Trasladar"
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
        Me.cmbMes.Location = New System.Drawing.Point(374, 20)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(121, 21)
        Me.cmbMes.TabIndex = 2
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(893, 17)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 72
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar")
        Me.btnLimpiar.UseVisualStyleBackColor = False
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
        Me.gpEmpresa.Location = New System.Drawing.Point(261, 8)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(456, 42)
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
        Me.Label10.Location = New System.Drawing.Point(343, 18)
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
        Me.PgBar.Location = New System.Drawing.Point(7, 4)
        Me.PgBar.Name = "PgBar"
        Me.PgBar.Size = New System.Drawing.Size(966, 23)
        Me.PgBar.TabIndex = 70
        '
        'stbPanel
        '
        Me.stbPanel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.stbPanel.Location = New System.Drawing.Point(0, 232)
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
        Me.ToolStripStatusLabel1.Text = "Realiza el traslado del pago de Cheques a la Contabilidad."
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'gpFormaPago
        '
        Me.gpFormaPago.BackColor = System.Drawing.Color.AliceBlue
        Me.gpFormaPago.Controls.Add(Me.Label6)
        Me.gpFormaPago.Controls.Add(Me.TextTasa)
        Me.gpFormaPago.Controls.Add(Me.Label3)
        Me.gpFormaPago.Controls.Add(Me.TextMoneda)
        Me.gpFormaPago.Controls.Add(Me.Label4)
        Me.gpFormaPago.Controls.Add(Me.TextBanco)
        Me.gpFormaPago.Controls.Add(Me.Label2)
        Me.gpFormaPago.Controls.Add(Me.cmbFormaPago)
        Me.gpFormaPago.Controls.Add(Me.TextNombBanco)
        Me.gpFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFormaPago.Location = New System.Drawing.Point(9, 59)
        Me.gpFormaPago.Name = "gpFormaPago"
        Me.gpFormaPago.Size = New System.Drawing.Size(970, 59)
        Me.gpFormaPago.TabIndex = 1
        Me.gpFormaPago.TabStop = False
        Me.gpFormaPago.Text = "Forma de pago"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(843, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(34, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Tasa:"
        '
        'TextTasa
        '
        Me.TextTasa.BackColor = System.Drawing.Color.White
        Me.TextTasa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTasa.Location = New System.Drawing.Point(885, 19)
        Me.TextTasa.MaxLength = 4
        Me.TextTasa.Name = "TextTasa"
        Me.TextTasa.ReadOnly = True
        Me.TextTasa.Size = New System.Drawing.Size(57, 20)
        Me.TextTasa.TabIndex = 11
        Me.TextTasa.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(720, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 13)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "Moneda:"
        '
        'TextMoneda
        '
        Me.TextMoneda.BackColor = System.Drawing.Color.White
        Me.TextMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMoneda.Location = New System.Drawing.Point(776, 21)
        Me.TextMoneda.MaxLength = 4
        Me.TextMoneda.Name = "TextMoneda"
        Me.TextMoneda.ReadOnly = True
        Me.TextMoneda.Size = New System.Drawing.Size(57, 20)
        Me.TextMoneda.TabIndex = 9
        Me.TextMoneda.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(255, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Banco:"
        '
        'TextBanco
        '
        Me.TextBanco.BackColor = System.Drawing.Color.White
        Me.TextBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBanco.Location = New System.Drawing.Point(310, 24)
        Me.TextBanco.MaxLength = 4
        Me.TextBanco.Name = "TextBanco"
        Me.TextBanco.ReadOnly = True
        Me.TextBanco.Size = New System.Drawing.Size(57, 20)
        Me.TextBanco.TabIndex = 7
        Me.TextBanco.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(373, 26)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre:"
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.Location = New System.Drawing.Point(6, 27)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(208, 21)
        Me.cmbFormaPago.TabIndex = 1
        '
        'TextNombBanco
        '
        Me.TextNombBanco.BackColor = System.Drawing.Color.White
        Me.TextNombBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombBanco.Location = New System.Drawing.Point(431, 22)
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
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(979, 58)
        Me.Panel1.TabIndex = 73
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PgBar)
        Me.Panel2.Location = New System.Drawing.Point(0, 201)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(979, 35)
        Me.Panel2.TabIndex = 74
        '
        'frmTrasladoChNomina
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(979, 256)
        Me.Controls.Add(Me.gpFormaPago)
        Me.Controls.Add(Me.stbPanel)
        Me.Controls.Add(Me.gpFecha)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmTrasladoChNomina"
        Me.Text = "Traslado de Cheques de Nómina"
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
        lpara("empresa") = empresa
        cadena = "select nombre from meses order by mes"
        llena_combo(cadena, cmbMes)
        cmbMes.Items.Add("")
        TextAño.Text = System.DateTime.Now.Year
        EscribeEmpresa(TextNombEmpresa, TextMoneEmpresa)
        cmbMes.SelectedIndex = System.DateTime.Now.Month - 1
        cadena = "select nombre, tiponom, cuenta from tiponomina1 where empresa=@empresa "
        llena_combo(cadena, cmbTipo, ListaParametros(lpara))
        llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        cmbTipo.Items.Add("")
        cadena = "SELECT fp.nombre, fpago, tipoforma, fp.BANCO, b.nombre + ' CTA ' + bc.cta  AS nombBanco, " &
                "bc.moneda, tasa, bc.cuenta FROM formapagoper fp inner join bancoscta bc on fp.empresa=bc.empresa and fp.banco=bc.banco " &
                "inner join monedasban m on bc.moneda=m.moneda " &
                "inner join bancos b on b.empresa=fp.empresa and b.codigo=bc.codigo where fp.empresa=@empresa " &
                " and tipoforma='C' order by fp.banco"
        llena_combo(cadena, cmbFormaPago, ListaParametros(lpara))
        llenaTabla(cadena, tbForma, ListaParametros(lpara))
        cmbFormaPago.Items.Add("")
        PgBar.Minimum = 0
        PgBar.Step = 1



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        Dim año, mes As Int16
        Dim i, fpago, banco, auxi, existeAux, repetido, repeSigue As Int32
        Dim tasa, tasaEs, montoCh As Decimal
        Dim id_diario As Int32 = 0
        Dim tipoNom, concepto, NombCuentaBanco, NombCuentaNom As String
        Dim fila As DataRow
        Dim NoCheques As Int32
        lpara.Clear()
        If Not validetError(cmbTipo, ep1) Or Not validetError(cmbTipo, ep1) Or Not validetError(cmbMes, ep1) Or _
        Not validetError(TextAño, ep1) Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If
        tipoNom = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
        cuentaNom = tbTipo.Rows(cmbTipo.SelectedIndex).Item(2)
        fpago = tbForma.Rows(cmbFormaPago.SelectedIndex).Item(1)

        banco = tbForma.Rows(cmbFormaPago.SelectedIndex).Item(3)
        año = CInt(TextAño.Text)
        mes = cmbMes.SelectedIndex + 1
        Dim modelo As New cmodelo
        lpara("empresa") = empresa
        lpara("tiponom") = tipoNom
        lpara("mes") = mes
        lpara("año") = año

        lpara("cuenta") = cuentaBanco
        lpara("cuentaNom") = cuentaNom
        lpara("fpago") = fpago
        If MsgBox("ESTA SEGURO QUE DESEA TRASLADAR ESTOS CHEQUES A CONTABILIDAD", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            Try

                cadena = "select count(*) from pagosnom where tiponom=@tiponom and mes=@mes and año=@año and tipoforma='C' and estado=0"
                If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
                    MsgBox("NO EXISTEN CHEQUES PARA TRASLADAR A CONTABILIDAD, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
                If MsgBox("UNA VEZ TRASLADADOS NO SE PUEDEN IMPRIMIR LOS CHEQUES POR ESTE MODULO, ESTA SEGURO QUE DESEA CONTINUAR", MsgBoxStyle.YesNo + MsgBoxStyle.Exclamation, "Mensaje del Sistema") = MsgBoxResult.No Then
                    Exit Sub
                End If

                If TextTasa.Text.Trim = "" Then
                    tasa = 1
                    tasaEs = 0
                Else
                    tasa = CDec(TextTasa.Text)
                    tasaEs = CDec(TextTasa.Text.Trim)
                End If
                NombCuentaBanco = modelo.BuscaEscalar("select nombre from nomencla where cuenta=@cuenta and empresa=@empresa ", ListaParametros(lpara))
                NombCuentaNom = modelo.BuscaEscalar("select nombre from nomencla where cuenta=@cuentaNom and empresa=@empresa ", ListaParametros(lpara))
                cadena = "select * from reporte_chequeNomina"
                modelo.llenaTabla(cadena, tt)
                cadena = "select count(*) from auxiliarcta where empresa=@empresa and cuenta=@cuentaNom and origen='000'"
                existeAux = modelo.BuscaEscalar(cadena, ListaParametros(lpara))
                cadena = "select mes, año, fpago, docto, fecha, pg.empleado, contrato, monto, nombre, pg.fechae " &
                         "from pagosnom pg  inner join v_empleadoReves emp on pg.empresa=emp.empresa and pg.empleado=emp.empleado " &
                         "where estado=0 and pg.empresa =@empresa And mes=@mes And año=@año And fpago =@fpago and tiponom=@tiponom order by docto"
                modelo.llenaTabla(cadena, tbDatos, ListaParametros(lpara))

                PgBar.Maximum = tbDatos.Rows.Count
                NoCheques = 0
                Dim idCheque As Int32

                For i = 0 To tbDatos.Rows.Count - 1
                    lpara.Clear()
                    PgBar.PerformStep()
                    filaTemp = tbDatos.Rows(i)
                    lpara("empresa") = empresa
                    lpara("banco") = banco
                    lpara("cheque") = filaTemp.Item(3)
                    cadena = "select count(*) from cheque1 where empresa=@empresa and banco=@banco and cheque=@cheque"
                    repetido = modelo.BuscaEscalar(cadena, ListaParametros(lpara))
                    repeSigue = repeSigue + repetido

                    lpara("inicial") = "NOM-" & user
                    lpara("fecha") = filaTemp.Item(4)
                    lpara("beneficiario") = filaTemp.Item(8)
                    lpara("moneda") = TextMoneda.Text.Trim
                    lpara("tasa") = tasaEs
                    lpara("fecha_oper") = filaTemp.Item(9)

                    If filaTemp.Item("monto") > 0 And repetido = 0 Then
                        NoCheques = NoCheques + 1
                        If existeAux > 0 Then
                            auxi = filaTemp.Item(5)
                        Else
                            auxi = 0
                        End If
                        montoCh = Decimal.Round((filaTemp.Item("monto") / tasa), 2)
                        concepto = "NOMINA " & cmbTipo.Text.Trim & " DE " & cmbMes.Text.Trim & " " & TextAño.Text

                        lpara("concepto") = concepto
                        lpara("monto") = montoCh
                        cadena = "insert into cheque1 (empresa,banco,cheque,inicial,fecha,beneficiario,concepto,moneda,tasa,monto,estado,fecha_oper,mes,anio,negociable) 
                                  values (@empresa,@banco,@cheque,@inicial,@fecha,@beneficiario,@concepto,@moneda,@tasa,@monto,0,@fecha_oper,'','',0) ; " &
                                 "SELECT SCOPE_IDENTITY()"
                        idCheque = modelo.BuscaEscalar(cadena, ListaParametros(lpara))

                        lpara("monto") = filaTemp.Item(7)
                        cadena = "insert into diario1 (empresa,tipo,banco,docto,fecha,beneficiario,monto,concepto,bancta) 
                                  values(@empresa,3,@banco,@cheque,@fecha,@beneficiario,@monto,@concepto,@banco);" &
                                  "SELECT SCOPE_IDENTITY()"
                        id_diario = modelo.BuscaEscalar(cadena, ListaParametros(lpara))

                        lpara("valor") = -montoCh
                        cadena = "insert into bantran (empresa,banco,fecha,banche,tipo,docto,valor,beneficiario,concepto,tasa) 
                                  values (@empresa,@banco,@fecha,@banco,3,@cheque,@valor,@beneficiario,@concepto,@tasa)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                        lpara("idCheque") = idCheque
                        lpara("id_diario") = id_diario
                        lpara("cuenta") = cuentaNom
                        lpara("codigo") = auxi
                        lpara("debe") = montoCh
                        cadena = "insert into cheque2 (id_cheque,numero,empresa,banco,cheque,origen,cuenta,codigo,debe,haber) 
                                  values(@idCheque,1,@empresa,@banco,@cheque,'000',@cuenta,@codigo,@debe,0.00)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                        cadena = "insert into diario2 (id_diario,empresa,tipo,banco,docto,fecha,origen,cuenta,codigo,debe,haber,bancta) 
                                  values(@id_diario,@empresa,3,@banco,@cheque,@fecha,'000',@cuenta,@codigo,@monto,0.00,@banco)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                        lpara("cuentaBanco") = cuentaBanco
                        lpara("haber") = montoCh
                        cadena = "insert into cheque2 (id_cheque,numero,empresa,banco,cheque,origen,cuenta,codigo,debe,haber) 
                                  values(@idCheque,1,@empresa,@banco,@cheque,'000',@cuentaBanco,@banco,0.00,@haber)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                        cadena = "insert into diario2 (id_diario,empresa,tipo,banco,docto,fecha,origen,cuenta,codigo,debe,haber,bancta) 
                                  values(@id_diario,@empresa,3,@banco,@cheque,@fecha,'000',@cuentaBanco,@banco,0.00,@monto,@banco)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                        lpara("tiponom") = tipoNom
                        lpara("cmbmes") = cmbMes.SelectedIndex + 1
                        lpara("añot") = TextAño.Text
                        lpara("empleado") = filaTemp.Item(5)
                        lpara("contrato") = filaTemp.Item(6)
                        lpara("fechae") = Today
                        cadena = "update pagosnom set estado=2, fechae=@fechae where empresa=@empresa " &
                                 " and tiponom=@tiponom and mes=@cmbmes AND AÑO=@añot " &
                                 " and empleado=@empleado and contrato=@contrato and tipoforma='C'"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                        fila = tt.NewRow
                        fila.Item(0) = "000"
                        fila.Item(1) = filaTemp.Item(8)
                        fila.Item(2) = "NOMINA"
                        fila.Item(3) = filaTemp.Item(3)
                        fila.Item(4) = filaTemp.Item(4)
                        fila.Item(5) = montoCh
                        fila.Item(6) = cuentaNom
                        fila.Item(7) = ObLetras.Inicializacion(CStr(montoCh))
                        fila.Item(8) = montoCh
                        fila.Item(9) = 0
                        fila.Item(10) = concepto
                        fila.Item(11) = NombCuentaNom
                        tt.Rows.Add(fila)
                        fila = tt.NewRow
                        fila.Item(0) = "000"
                        fila.Item(1) = filaTemp.Item(8)
                        fila.Item(2) = "NOMINA"
                        fila.Item(3) = filaTemp.Item(3)
                        fila.Item(4) = filaTemp.Item(4)
                        fila.Item(5) = montoCh
                        fila.Item(6) = cuentaBanco
                        fila.Item(7) = ObLetras.Inicializacion(CStr(montoCh))
                        fila.Item(8) = 0
                        fila.Item(9) = montoCh
                        fila.Item(10) = concepto
                        fila.Item(11) = NombCuentaBanco
                        tt.Rows.Add(fila)
                    End If


                Next i
                If modelo.Commit() Then
                    InsertBitacora(9, 7, "TRASLADO DE " & cmbFormaPago.Text & " " & cmbTipo.Text & " " & cmbMes.Text & " " & TextAño.Text)
                    MsgBox("OPERACION REALIZA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If
                If repeSigue > 0 Then
                    MsgBox("SE ENCONTRARON CHEQUES YA INGRESADOS CON LOS NUMEROS ASIGNADOS A LOS CHEQUES DE NOMINA, ESTOS NO SE GENERARON", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                End If
                PgBar.Value = 0
            Catch ex As Exception
                MsgBox("Error del Sistema: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                modelo.RollBack()
            End Try
          
        End If
    End Sub

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        If cmbFormaPago.Text.Trim <> "" Then
            filaTemp = tbForma.Rows(cmbFormaPago.SelectedIndex)
            TextBanco.Text = filaTemp.Item(3)
            TextNombBanco.Text = filaTemp.Item(4)
            TextMoneda.Text = filaTemp.Item(5)
            If filaTemp.Item(5).ToString.Trim = TextMoneEmpresa.Text.Trim Then
                TextTasa.Clear()
            Else
                TextTasa.Text = filaTemp.Item(6)
            End If
            cuentaBanco = filaTemp.Item(7)

        Else
            TextBanco.Clear()
            TextNombBanco.Clear()
            TextMoneda.Clear()
            TextTasa.Clear()
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
