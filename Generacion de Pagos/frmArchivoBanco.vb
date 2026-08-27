Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMARCHIVOBANCO.VB MIEMBRO DE NOMINA.SLN                                    **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmArchivoBanco
    Inherits Form
    Dim cadena As String
    Dim tbForma As New DataTable("forma")
    Dim tbDatos As New DataTable("datos")
    Dim tbTipo As New DataTable("tipo")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim fpago, maximo, minimo, banco As Integer
    Dim moneda, cuentaBanco, cuentaNom, tipoNom As String
    Dim tasaOri As Decimal
    Dim v As New ChequeNery
    Dim tt As New DataTable("impresion")
    Dim ObLetras As New ValoresLetras
    Dim oWrite As StreamWriter
    Dim nombreNomina As String
    Dim lpara As New Dictionary(Of String, Object)

    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents PgBar As System.Windows.Forms.ProgressBar
    Friend WithEvents GuardaArchi As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TextAño As System.Windows.Forms.TextBox



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
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBanco As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents TextNombBanco As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmArchivoBanco))
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.cmbMes = New System.Windows.Forms.ComboBox()
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
        Me.GuardaArchi = New System.Windows.Forms.SaveFileDialog()
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
        Me.gpFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpFecha.Controls.Add(Me.Label3)
        Me.gpFecha.Controls.Add(Me.Label7)
        Me.gpFecha.Controls.Add(Me.Label6)
        Me.gpFecha.Controls.Add(Me.TextAño)
        Me.gpFecha.Controls.Add(Me.cmbTipo)
        Me.gpFecha.Controls.Add(Me.btnEjecutar)
        Me.gpFecha.Controls.Add(Me.cmbMes)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.Location = New System.Drawing.Point(10, 109)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(684, 63)
        Me.gpFecha.TabIndex = 1
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Tipo y periodo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Nómina:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(312, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Mes:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(484, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(29, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Año:"
        '
        'TextAño
        '
        Me.TextAño.BackColor = System.Drawing.Color.White
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(526, 19)
        Me.TextAño.MaxLength = 4
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(57, 20)
        Me.TextAño.TabIndex = 11
        Me.TextAño.TabStop = False
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(66, 19)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(208, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "actualizar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(598, 19)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(80, 30)
        Me.btnEjecutar.TabIndex = 4
        Me.btnEjecutar.Text = "Generar"
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
        Me.cmbMes.Location = New System.Drawing.Point(349, 19)
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
        Me.gpEmpresa.Location = New System.Drawing.Point(143, -3)
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
        Me.Label10.Location = New System.Drawing.Point(351, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Moneda:"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(15, 16)
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(321, 21)
        Me.TextNombEmpresa.TabIndex = 2
        Me.TextNombEmpresa.TabStop = False
        '
        'stbPanel
        '
        Me.stbPanel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.stbPanel.Location = New System.Drawing.Point(0, 231)
        Me.stbPanel.Name = "stbPanel"
        Me.stbPanel.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional
        Me.stbPanel.Size = New System.Drawing.Size(719, 24)
        Me.stbPanel.TabIndex = 71
        Me.stbPanel.Text = "Realiza el ingreso de los puestos."
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(704, 19)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Realiza la generación del Archivo del Banco"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'gpFormaPago
        '
        Me.gpFormaPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpFormaPago.Controls.Add(Me.Label4)
        Me.gpFormaPago.Controls.Add(Me.TextBanco)
        Me.gpFormaPago.Controls.Add(Me.Label2)
        Me.gpFormaPago.Controls.Add(Me.cmbFormaPago)
        Me.gpFormaPago.Controls.Add(Me.TextNombBanco)
        Me.gpFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFormaPago.Location = New System.Drawing.Point(10, 59)
        Me.gpFormaPago.Name = "gpFormaPago"
        Me.gpFormaPago.Size = New System.Drawing.Size(684, 47)
        Me.gpFormaPago.TabIndex = 72
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
        Me.TextBanco.Location = New System.Drawing.Point(282, 15)
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
        Me.Label2.Location = New System.Drawing.Point(370, 15)
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
        Me.cmbFormaPago.Size = New System.Drawing.Size(208, 21)
        Me.cmbFormaPago.TabIndex = 1
        '
        'TextNombBanco
        '
        Me.TextNombBanco.BackColor = System.Drawing.Color.White
        Me.TextNombBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombBanco.Location = New System.Drawing.Point(427, 15)
        Me.TextNombBanco.MaxLength = 4
        Me.TextNombBanco.Name = "TextNombBanco"
        Me.TextNombBanco.ReadOnly = True
        Me.TextNombBanco.Size = New System.Drawing.Size(251, 20)
        Me.TextNombBanco.TabIndex = 3
        Me.TextNombBanco.TabStop = False
        '
        'PgBar
        '
        Me.PgBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PgBar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PgBar.Location = New System.Drawing.Point(12, 7)
        Me.PgBar.Name = "PgBar"
        Me.PgBar.Size = New System.Drawing.Size(695, 23)
        Me.PgBar.TabIndex = 73
        '
        'GuardaArchi
        '
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(719, 42)
        Me.Panel1.TabIndex = 74
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.PgBar)
        Me.Panel2.Location = New System.Drawing.Point(0, 195)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(719, 40)
        Me.Panel2.TabIndex = 75
        '
        'frmArchivoBanco
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(719, 255)
        Me.Controls.Add(Me.gpFormaPago)
        Me.Controls.Add(Me.stbPanel)
        Me.Controls.Add(Me.gpFecha)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmArchivoBanco"
        Me.Text = "Generación de Archivo del Banco"
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
        cadena = "select nombre, tiponom, cuenta from tiponomina1 where empresa=@empresa order by tiponom"
        llena_combo(cadena, cmbTipo, ListaParametros(lpara))
        llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        cmbTipo.Items.Add("")
        cadena = "SELECT fp.nombre, fpago, fp.BANCO, b.nombre + ' CTA ' + bc.cta  AS nombBanco, bc.moneda, m.tasa, bc.cuenta " &
                 "FROM formapagoper fp inner join bancoscta bc on fp.empresa=bc.empresa and fp.banco=bc.banco " &
                 "inner join bancos b on b.empresa=fp.empresa and b.codigo=bc.codigo " &
                 "inner join monedasban m on m.moneda=bc.moneda " &
                 "where fp.empresa=@empresa " &
                 " and tipoforma ='D' order by fp.banco"
        llena_combo(cadena, cmbFormaPago, ListaParametros(lpara))
        llenaTabla(cadena, tbForma, ListaParametros(lpara))
        cmbFormaPago.Items.Add("")
    End Sub

    Private Sub gpFecha_Enter(sender As Object, e As EventArgs) Handles gpFecha.Enter

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        If Not validetError(cmbTipo, ep1) Or Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) Then
            Exit Sub
        End If
        nombreNomina = "NOMINA " & cmbTipo.Text
        GuardaArchi.Title = "GUARDAR ARCHIVO"
        GuardaArchi.FileName = "NOMINA" & cmbMes.SelectedIndex + 1 & TextAño.Text
        GuardaArchi.Filter = "Todos los Archivos (*.*)|*.*|Archivos de texto" & _
        "(*.txt)|*.txt"
        ' Specify default filter
        GuardaArchi.FilterIndex = 2
        GuardaArchi.ShowDialog()
    End Sub

    Private Sub GuardaArchi_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles GuardaArchi.FileOk
        lpara.Clear()
        Dim nombreArchi As String
        Dim mes, año, i As Integer
        Dim numero As String
        Dim nombre, Cuenta, Valor As String
        mes = cmbMes.SelectedIndex + 1
        año = CInt(TextAño.Text)
        nombreArchi = GuardaArchi.FileName()
        oWrite = File.CreateText(nombreArchi)
        lpara("empresa") = empresa
        lpara("fpago") = fpago
        lpara("tiponom") = tipoNom
        lpara("mes") = mes
        lpara("año") = año
        cadena = "select p.empleado, p.contrato, v.nombre, c1.cuentaban,monto from pagosnom p inner join " &
                 "v_EmpleadosNuevo v on v.empresa=p.empresa and v.empleado=p.empleado " &
                 "inner join contratos1 c1 on c1.empresa=p.empresa and c1.empleado=p.empleado and " &
                 "c1.contrato=p.contrato where p.empresa=@empresa and p.fpago=@fpago and p.tiponom=@tiponom and mes=@mes and año=@año and p.estado=0"
        If llenaTabla(cadena, tbDatos, ListaParametros(lpara)) > 0 Then
            PgBar.Maximum = tbDatos.Rows.Count

            For i = 0 To tbDatos.Rows.Count - 1
                PgBar.PerformStep()
                filaTemp = tbDatos.Rows(i)
                If filaTemp.Item(4) > 0 Then
                    numero = filaTemp.Item(0).ToString() & filaTemp.Item(1).ToString().Substring(0, 1)
                    nombre = filaTemp.Item(2)
                    Cuenta = filaTemp.Item(3)
                    Valor = filaTemp.Item(4).ToString.Trim
                    nombre = nombre.Replace("ñ", "n")
                    nombre = nombre.Replace("Ñ", "N")
                    oWrite.WriteLine(Format(CDec(numero), "00000") & Rellena(40, nombre, True) & Rellena(10, Cuenta, True) &
                    Rellena(13, Valor, False) & nombreNomina)
                End If
            Next i

            PgBar.Value = 0
            InsertBitacora(9, 7, Me.Text)
            MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
        Else
            MsgBox("NO SE ENCUENTRA GENERADO NINGUN PAGO EN ESTE PERIODO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
        oWrite.Close()
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

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        If cmbTipo.Text.Trim <> "" Then
            If cmbFormaPago.Text.Trim <> "" Then
                btnEjecutar.Enabled = True
                filaTemp = tbTipo.Rows(cmbTipo.SelectedIndex)
                tipoNom = filaTemp.Item(1)
                cuentaNom = filaTemp.Item(2)
            Else
                cmbTipo.Text = ""
            End If
        Else
            btnEjecutar.Enabled = False
        End If
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

End Class
