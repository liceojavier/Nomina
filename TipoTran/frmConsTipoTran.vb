Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMCONSTIPOTRAN.VB MIEMBRO DE NOMINA.SLN                                    **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmConsTipoTran
    Inherits Form
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter
    Dim cadena As String
    Dim tbConsulta As New DataTable("consulta")
    Dim tbCuenta As New DataTable("cuenta")
    Dim WithEvents fEmp As frmMuestraCodigos
    Dim WithEvents fCta As frmMuestraSoloCuentas
    Dim modifica As Boolean
    Dim filaTemp As DataRow
    Dim formaCalculo() As String = {"FM", "AN", "IM", "EX", "SS", "CA"}
    Dim inicioConsulta As String = "select transac, nombre, tipomov, formacal, tipovalor, afectaseguro," & _
                                   "afectaisr, marextras, ctacte, factor, cuentanom from tipotran t1 where empresa=" & empresa

    Dim indice As Integer
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
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents MaskedTextBox2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox9 As System.Windows.Forms.ComboBox
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextConlNombre As System.Windows.Forms.TextBox
    Friend WithEvents gpCuenta As System.Windows.Forms.GroupBox
    Friend WithEvents TextConsCuentaNom As System.Windows.Forms.TextBox
    Friend WithEvents TextNombCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnConNome As System.Windows.Forms.Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoMov As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents gpPrincipal As System.Windows.Forms.GroupBox
    Friend WithEvents gpNumero As System.Windows.Forms.GroupBox
    Friend WithEvents TextConxTransac As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoValor As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cmbFormaCal As System.Windows.Forms.ComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbMarcaExtra As System.Windows.Forms.ComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents cmbAfectaIsr As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbAfectaSeguro As System.Windows.Forms.ComboBox
    Friend WithEvents TextFactor As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbCtate As System.Windows.Forms.ComboBox
    Friend WithEvents btnSig As System.Windows.Forms.Button
    Friend WithEvents btnAtr As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents TextAfectaIsr As System.Windows.Forms.TextBox
    Friend WithEvents TextAfectaSeguro As System.Windows.Forms.TextBox
    Friend WithEvents TextTipoValor As System.Windows.Forms.TextBox
    Friend WithEvents TextFormaCal As System.Windows.Forms.TextBox
    Friend WithEvents TextTipoMov As System.Windows.Forms.TextBox
    Friend WithEvents TextCtate As System.Windows.Forms.TextBox
    Friend WithEvents TextMarcaExtra As System.Windows.Forms.TextBox
    Friend WithEvents ctxPrincipal As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxEliminacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel




    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsTipoTran))
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnConNome = New System.Windows.Forms.Button()
        Me.btnSig = New System.Windows.Forms.Button()
        Me.btnAtr = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MaskedTextBox2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox9 = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextConlNombre = New System.Windows.Forms.TextBox()
        Me.gpCuenta = New System.Windows.Forms.GroupBox()
        Me.TextConsCuentaNom = New System.Windows.Forms.TextBox()
        Me.TextNombCuenta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbTipoMov = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.gpPrincipal = New System.Windows.Forms.GroupBox()
        Me.ctxPrincipal = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEliminacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextCtate = New System.Windows.Forms.TextBox()
        Me.TextMarcaExtra = New System.Windows.Forms.TextBox()
        Me.TextAfectaIsr = New System.Windows.Forms.TextBox()
        Me.TextAfectaSeguro = New System.Windows.Forms.TextBox()
        Me.TextTipoValor = New System.Windows.Forms.TextBox()
        Me.TextFormaCal = New System.Windows.Forms.TextBox()
        Me.TextTipoMov = New System.Windows.Forms.TextBox()
        Me.TextFactor = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbCtate = New System.Windows.Forms.ComboBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.cmbMarcaExtra = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbAfectaIsr = New System.Windows.Forms.ComboBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbAfectaSeguro = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbTipoValor = New System.Windows.Forms.ComboBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbFormaCal = New System.Windows.Forms.ComboBox()
        Me.gpNumero = New System.Windows.Forms.GroupBox()
        Me.TextConxTransac = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.gpCuenta.SuspendLayout()
        Me.gpPrincipal.SuspendLayout()
        Me.ctxPrincipal.SuspendLayout()
        Me.gpNumero.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(983, 5)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 30)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Guardar registro")
        Me.btnGuardar.UseVisualStyleBackColor = False
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
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(79, 5)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(60, 30)
        Me.btnLimpiar.TabIndex = 52
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.LavenderBlush
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Image = CType(resources.GetObject("Button3.Image"), System.Drawing.Image)
        Me.Button3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button3.Location = New System.Drawing.Point(464, 14)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(88, 40)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Codigo"
        Me.Button3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Button3, "Buscar Transaccion")
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button6
        '
        Me.Button6.BackColor = System.Drawing.Color.LavenderBlush
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Image = CType(resources.GetObject("Button6.Image"), System.Drawing.Image)
        Me.Button6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button6.Location = New System.Drawing.Point(445, 14)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(88, 40)
        Me.Button6.TabIndex = 3
        Me.Button6.Text = "Codigo"
        Me.Button6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.Button6, "Buscar Transaccion")
        Me.Button6.UseVisualStyleBackColor = False
        '
        'btnConNome
        '
        Me.btnConNome.BackColor = System.Drawing.SystemColors.Control
        Me.btnConNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConNome.ImageKey = "buscar1.png"
        Me.btnConNome.ImageList = Me.ImageNuevos
        Me.btnConNome.Location = New System.Drawing.Point(563, 9)
        Me.btnConNome.Name = "btnConNome"
        Me.btnConNome.Size = New System.Drawing.Size(60, 30)
        Me.btnConNome.TabIndex = 5
        Me.btnConNome.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnConNome, "Ingresar cuenta contable")
        Me.btnConNome.UseVisualStyleBackColor = False
        '
        'btnSig
        '
        Me.btnSig.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSig.BackColor = System.Drawing.SystemColors.Control
        Me.btnSig.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSig.ImageKey = "siguiente.png"
        Me.btnSig.ImageList = Me.ImageNuevos
        Me.btnSig.Location = New System.Drawing.Point(1051, 5)
        Me.btnSig.Name = "btnSig"
        Me.btnSig.Size = New System.Drawing.Size(60, 30)
        Me.btnSig.TabIndex = 76
        Me.btnSig.TabStop = False
        Me.btnSig.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnSig, "Siguiente Registro")
        Me.btnSig.UseVisualStyleBackColor = False
        '
        'btnAtr
        '
        Me.btnAtr.BackColor = System.Drawing.SystemColors.Control
        Me.btnAtr.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAtr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtr.ImageKey = "anterior.png"
        Me.btnAtr.ImageList = Me.ImageNuevos
        Me.btnAtr.Location = New System.Drawing.Point(11, 5)
        Me.btnAtr.Name = "btnAtr"
        Me.btnAtr.Size = New System.Drawing.Size(60, 30)
        Me.btnAtr.TabIndex = 75
        Me.btnAtr.TabStop = False
        Me.btnAtr.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnAtr, "Registro anterior")
        Me.btnAtr.UseVisualStyleBackColor = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnBuscar.ImageKey = "buscar2.png"
        Me.btnBuscar.ImageList = Me.ImageNuevos
        Me.btnBuscar.Location = New System.Drawing.Point(982, 5)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(60, 30)
        Me.btnBuscar.TabIndex = 74
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Buscar registro")
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 581)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1130, 24)
        Me.StatusStrip1.TabIndex = 55
        Me.StatusStrip1.Text = "stBar"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(877, 19)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Click derecho sobre el panel de informacion para activar opción de: modificación," &
    " eliminación."
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(347, 3)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(436, 41)
        Me.gpEmpresa.TabIndex = 0
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(5, 15)
        Me.TextNombEmpresa.MaxLength = 30
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(425, 20)
        Me.TextNombEmpresa.TabIndex = 1
        Me.TextNombEmpresa.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LavenderBlush
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(749, 59)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 35)
        Me.Button1.TabIndex = 74
        Me.Button1.TabStop = False
        Me.Button1.Text = "Agregar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.LavenderBlush
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(749, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 35)
        Me.Button2.TabIndex = 73
        Me.Button2.TabStop = False
        Me.Button2.Text = "Cancelar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'MaskedTextBox2
        '
        Me.MaskedTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBox2.Location = New System.Drawing.Point(529, 48)
        Me.MaskedTextBox2.Mask = "##/##/####"
        Me.MaskedTextBox2.Name = "MaskedTextBox2"
        Me.MaskedTextBox2.Size = New System.Drawing.Size(84, 20)
        Me.MaskedTextBox2.TabIndex = 72
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "TIPO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(526, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 16)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "FECHA DE NACIMIENTO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.Color.White
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(154, 48)
        Me.TextBox7.MaxLength = 75
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(353, 20)
        Me.TextBox7.TabIndex = 59
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(151, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 16)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "NOMBRE"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox9
        '
        Me.ComboBox9.BackColor = System.Drawing.Color.White
        Me.ComboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox9.FormattingEnabled = True
        Me.ComboBox9.Location = New System.Drawing.Point(20, 48)
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox9.TabIndex = 63
        '
        'Label20
        '
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(580, 86)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(81, 16)
        Me.Label20.TabIndex = 112
        Me.Label20.Text = "VALOR"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox1.BackColor = System.Drawing.Color.White
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(583, 105)
        Me.TextBox1.MaxLength = 75
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(105, 20)
        Me.TextBox1.TabIndex = 111
        '
        'TextBox2
        '
        Me.TextBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox2.BackColor = System.Drawing.Color.White
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(14, 105)
        Me.TextBox2.MaxLength = 75
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(549, 20)
        Me.TextBox2.TabIndex = 109
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(11, 86)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(243, 16)
        Me.Label21.TabIndex = 110
        Me.Label21.Text = "CONCEPTO"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox1
        '
        Me.ComboBox1.BackColor = System.Drawing.Color.White
        Me.ComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.Items.AddRange(New Object() {"S", "N", ""})
        Me.ComboBox1.Location = New System.Drawing.Point(741, 44)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(41, 21)
        Me.ComboBox1.TabIndex = 107
        '
        'Label22
        '
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(738, 24)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(66, 16)
        Me.Label22.TabIndex = 108
        Me.Label22.Text = "AFECTA"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox2
        '
        Me.ComboBox2.BackColor = System.Drawing.Color.White
        Me.ComboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox2.Items.AddRange(New Object() {"S", "N", ""})
        Me.ComboBox2.Location = New System.Drawing.Point(583, 44)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(139, 21)
        Me.ComboBox2.TabIndex = 105
        '
        'Label23
        '
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(580, 24)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(66, 16)
        Me.Label23.TabIndex = 106
        Me.Label23.Text = "TIPO"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(8, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(557, 61)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "TRANSACCIONES"
        '
        'TextBox3
        '
        Me.TextBox3.BackColor = System.Drawing.Color.White
        Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox3.Location = New System.Drawing.Point(142, 25)
        Me.TextBox3.MaxLength = 25
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(316, 20)
        Me.TextBox3.TabIndex = 2
        '
        'TextBox4
        '
        Me.TextBox4.BackColor = System.Drawing.Color.White
        Me.TextBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox4.Location = New System.Drawing.Point(6, 25)
        Me.TextBox4.MaxLength = 5
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(65, 20)
        Me.TextBox4.TabIndex = 1
        '
        'Label24
        '
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(77, 22)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(64, 24)
        Me.Label24.TabIndex = 48
        Me.Label24.Text = "NOMBRE"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox5
        '
        Me.TextBox5.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox5.BackColor = System.Drawing.Color.White
        Me.TextBox5.Font = New System.Drawing.Font("Courier New", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox5.ForeColor = System.Drawing.Color.Red
        Me.TextBox5.Location = New System.Drawing.Point(688, 337)
        Me.TextBox5.MaxLength = 3
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(165, 35)
        Me.TextBox5.TabIndex = 117
        Me.TextBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(548, 339)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(134, 28)
        Me.Label8.TabIndex = 116
        Me.Label8.Text = "TOTAL"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DataGridView1
        '
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(240, 150)
        Me.DataGridView1.TabIndex = 0
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.Color.LavenderBlush
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button4.ImageKey = "button_cancel.ico"
        Me.Button4.Location = New System.Drawing.Point(667, 75)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(94, 40)
        Me.Button4.TabIndex = 114
        Me.Button4.Text = "Cancelar"
        Me.Button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button4.UseVisualStyleBackColor = False
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.Color.LavenderBlush
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Image = CType(resources.GetObject("Button5.Image"), System.Drawing.Image)
        Me.Button5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button5.Location = New System.Drawing.Point(667, 29)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(94, 40)
        Me.Button5.TabIndex = 4
        Me.Button5.Text = "Ingresar"
        Me.Button5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button5.UseVisualStyleBackColor = False
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Gainsboro
        Me.GroupBox2.Controls.Add(Me.Button6)
        Me.GroupBox2.Controls.Add(Me.TextBox6)
        Me.GroupBox2.Controls.Add(Me.TextBox8)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(111, 29)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(541, 61)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "TRANSACCIONES"
        '
        'TextBox6
        '
        Me.TextBox6.BackColor = System.Drawing.Color.White
        Me.TextBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox6.Location = New System.Drawing.Point(123, 25)
        Me.TextBox6.MaxLength = 25
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(316, 20)
        Me.TextBox6.TabIndex = 2
        '
        'TextBox8
        '
        Me.TextBox8.BackColor = System.Drawing.Color.White
        Me.TextBox8.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox8.Location = New System.Drawing.Point(6, 25)
        Me.TextBox8.MaxLength = 5
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(48, 20)
        Me.TextBox8.TabIndex = 1
        '
        'Label10
        '
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(58, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 24)
        Me.Label10.TabIndex = 48
        Me.Label10.Text = "NOMBRE"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextConlNombre
        '
        Me.TextConlNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextConlNombre.BackColor = System.Drawing.Color.White
        Me.TextConlNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextConlNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConlNombre.Location = New System.Drawing.Point(64, 12)
        Me.TextConlNombre.MaxLength = 25
        Me.TextConlNombre.Name = "TextConlNombre"
        Me.TextConlNombre.Size = New System.Drawing.Size(218, 20)
        Me.TextConlNombre.TabIndex = 1
        '
        'gpCuenta
        '
        Me.gpCuenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpCuenta.Controls.Add(Me.TextConsCuentaNom)
        Me.gpCuenta.Controls.Add(Me.TextNombCuenta)
        Me.gpCuenta.Controls.Add(Me.Label2)
        Me.gpCuenta.Controls.Add(Me.btnConNome)
        Me.gpCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCuenta.Location = New System.Drawing.Point(14, 135)
        Me.gpCuenta.Name = "gpCuenta"
        Me.gpCuenta.Size = New System.Drawing.Size(633, 49)
        Me.gpCuenta.TabIndex = 10
        Me.gpCuenta.TabStop = False
        Me.gpCuenta.Text = "Cuenta para registro contable"
        '
        'TextConsCuentaNom
        '
        Me.TextConsCuentaNom.BackColor = System.Drawing.Color.White
        Me.TextConsCuentaNom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConsCuentaNom.Location = New System.Drawing.Point(8, 18)
        Me.TextConsCuentaNom.MaxLength = 6
        Me.TextConsCuentaNom.Name = "TextConsCuentaNom"
        Me.TextConsCuentaNom.Size = New System.Drawing.Size(48, 20)
        Me.TextConsCuentaNom.TabIndex = 1
        '
        'TextNombCuenta
        '
        Me.TextNombCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombCuenta.Location = New System.Drawing.Point(118, 18)
        Me.TextNombCuenta.MaxLength = 50
        Me.TextNombCuenta.Name = "TextNombCuenta"
        Me.TextNombCuenta.Size = New System.Drawing.Size(439, 20)
        Me.TextNombCuenta.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(66, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nombre:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(10, 15)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "Nombre:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoMov
        '
        Me.cmbTipoMov.BackColor = System.Drawing.Color.White
        Me.cmbTipoMov.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoMov.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoMov.Items.AddRange(New Object() {"INGRESOS", "DESCUENTOS", ""})
        Me.cmbTipoMov.Location = New System.Drawing.Point(412, 13)
        Me.cmbTipoMov.Name = "cmbTipoMov"
        Me.cmbTipoMov.Size = New System.Drawing.Size(260, 21)
        Me.cmbTipoMov.TabIndex = 2
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(297, 17)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(102, 13)
        Me.Label31.TabIndex = 14
        Me.Label31.Text = "Tipo de movimiento:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpPrincipal
        '
        Me.gpPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpPrincipal.ContextMenuStrip = Me.ctxPrincipal
        Me.gpPrincipal.Controls.Add(Me.TextCtate)
        Me.gpPrincipal.Controls.Add(Me.TextMarcaExtra)
        Me.gpPrincipal.Controls.Add(Me.TextAfectaIsr)
        Me.gpPrincipal.Controls.Add(Me.TextAfectaSeguro)
        Me.gpPrincipal.Controls.Add(Me.TextTipoValor)
        Me.gpPrincipal.Controls.Add(Me.TextFormaCal)
        Me.gpPrincipal.Controls.Add(Me.TextTipoMov)
        Me.gpPrincipal.Controls.Add(Me.TextFactor)
        Me.gpPrincipal.Controls.Add(Me.Label7)
        Me.gpPrincipal.Controls.Add(Me.Label6)
        Me.gpPrincipal.Controls.Add(Me.cmbCtate)
        Me.gpPrincipal.Controls.Add(Me.Label16)
        Me.gpPrincipal.Controls.Add(Me.Label15)
        Me.gpPrincipal.Controls.Add(Me.cmbMarcaExtra)
        Me.gpPrincipal.Controls.Add(Me.Label14)
        Me.gpPrincipal.Controls.Add(Me.cmbAfectaIsr)
        Me.gpPrincipal.Controls.Add(Me.Label13)
        Me.gpPrincipal.Controls.Add(Me.cmbAfectaSeguro)
        Me.gpPrincipal.Controls.Add(Me.Label12)
        Me.gpPrincipal.Controls.Add(Me.cmbTipoValor)
        Me.gpPrincipal.Controls.Add(Me.TextBox10)
        Me.gpPrincipal.Controls.Add(Me.Label11)
        Me.gpPrincipal.Controls.Add(Me.cmbFormaCal)
        Me.gpPrincipal.Controls.Add(Me.Label31)
        Me.gpPrincipal.Controls.Add(Me.cmbTipoMov)
        Me.gpPrincipal.Controls.Add(Me.TextConlNombre)
        Me.gpPrincipal.Controls.Add(Me.Label9)
        Me.gpPrincipal.Controls.Add(Me.gpCuenta)
        Me.gpPrincipal.Location = New System.Drawing.Point(4, 58)
        Me.gpPrincipal.Name = "gpPrincipal"
        Me.gpPrincipal.Size = New System.Drawing.Size(1053, 318)
        Me.gpPrincipal.TabIndex = 1
        Me.gpPrincipal.TabStop = False
        '
        'ctxPrincipal
        '
        Me.ctxPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModificar, Me.ctxEliminacion})
        Me.ctxPrincipal.Name = "ctxMenu"
        Me.ctxPrincipal.Size = New System.Drawing.Size(126, 48)
        '
        'ctxModificar
        '
        Me.ctxModificar.Image = Global.NOMINA.My.Resources.Resources.edit1
        Me.ctxModificar.Name = "ctxModificar"
        Me.ctxModificar.Size = New System.Drawing.Size(125, 22)
        Me.ctxModificar.Text = "Modificar"
        '
        'ctxEliminacion
        '
        Me.ctxEliminacion.Image = Global.NOMINA.My.Resources.Resources.menos
        Me.ctxEliminacion.Name = "ctxEliminacion"
        Me.ctxEliminacion.Size = New System.Drawing.Size(125, 22)
        Me.ctxEliminacion.Text = "Eliminar"
        '
        'TextCtate
        '
        Me.TextCtate.BackColor = System.Drawing.Color.White
        Me.TextCtate.Location = New System.Drawing.Point(133, 89)
        Me.TextCtate.Name = "TextCtate"
        Me.TextCtate.ReadOnly = True
        Me.TextCtate.Size = New System.Drawing.Size(53, 20)
        Me.TextCtate.TabIndex = 138
        '
        'TextMarcaExtra
        '
        Me.TextMarcaExtra.BackColor = System.Drawing.Color.White
        Me.TextMarcaExtra.Location = New System.Drawing.Point(933, 47)
        Me.TextMarcaExtra.Name = "TextMarcaExtra"
        Me.TextMarcaExtra.ReadOnly = True
        Me.TextMarcaExtra.Size = New System.Drawing.Size(53, 20)
        Me.TextMarcaExtra.TabIndex = 137
        '
        'TextAfectaIsr
        '
        Me.TextAfectaIsr.BackColor = System.Drawing.Color.White
        Me.TextAfectaIsr.Location = New System.Drawing.Point(650, 45)
        Me.TextAfectaIsr.Name = "TextAfectaIsr"
        Me.TextAfectaIsr.ReadOnly = True
        Me.TextAfectaIsr.Size = New System.Drawing.Size(53, 20)
        Me.TextAfectaIsr.TabIndex = 136
        '
        'TextAfectaSeguro
        '
        Me.TextAfectaSeguro.BackColor = System.Drawing.Color.White
        Me.TextAfectaSeguro.Location = New System.Drawing.Point(492, 44)
        Me.TextAfectaSeguro.Name = "TextAfectaSeguro"
        Me.TextAfectaSeguro.ReadOnly = True
        Me.TextAfectaSeguro.Size = New System.Drawing.Size(53, 20)
        Me.TextAfectaSeguro.TabIndex = 135
        '
        'TextTipoValor
        '
        Me.TextTipoValor.BackColor = System.Drawing.Color.White
        Me.TextTipoValor.Location = New System.Drawing.Point(91, 45)
        Me.TextTipoValor.Name = "TextTipoValor"
        Me.TextTipoValor.ReadOnly = True
        Me.TextTipoValor.Size = New System.Drawing.Size(260, 20)
        Me.TextTipoValor.TabIndex = 134
        '
        'TextFormaCal
        '
        Me.TextFormaCal.BackColor = System.Drawing.Color.White
        Me.TextFormaCal.Location = New System.Drawing.Point(786, 12)
        Me.TextFormaCal.Name = "TextFormaCal"
        Me.TextFormaCal.ReadOnly = True
        Me.TextFormaCal.Size = New System.Drawing.Size(260, 20)
        Me.TextFormaCal.TabIndex = 133
        '
        'TextTipoMov
        '
        Me.TextTipoMov.BackColor = System.Drawing.Color.White
        Me.TextTipoMov.Location = New System.Drawing.Point(411, 13)
        Me.TextTipoMov.Name = "TextTipoMov"
        Me.TextTipoMov.ReadOnly = True
        Me.TextTipoMov.Size = New System.Drawing.Size(260, 20)
        Me.TextTipoMov.TabIndex = 132
        '
        'TextFactor
        '
        Me.TextFactor.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextFactor.BackColor = System.Drawing.Color.White
        Me.TextFactor.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextFactor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFactor.Location = New System.Drawing.Point(348, 91)
        Me.TextFactor.MaxLength = 25
        Me.TextFactor.Name = "TextFactor"
        Me.TextFactor.Size = New System.Drawing.Size(91, 20)
        Me.TextFactor.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(248, 92)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 13)
        Me.Label7.TabIndex = 131
        Me.Label7.Text = "Factor de cálculo:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(10, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 13)
        Me.Label6.TabIndex = 129
        Me.Label6.Text = "Tiene cuenta corriente:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbCtate
        '
        Me.cmbCtate.BackColor = System.Drawing.Color.White
        Me.cmbCtate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCtate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCtate.Items.AddRange(New Object() {"S", "N", ""})
        Me.cmbCtate.Location = New System.Drawing.Point(134, 90)
        Me.cmbCtate.Name = "cmbCtate"
        Me.cmbCtate.Size = New System.Drawing.Size(53, 21)
        Me.cmbCtate.TabIndex = 8
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(720, 52)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(193, 13)
        Me.Label16.TabIndex = 127
        Me.Label16.Text = "Transacción para calcular horas extras:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(752, 133)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(0, 13)
        Me.Label15.TabIndex = 126
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMarcaExtra
        '
        Me.cmbMarcaExtra.BackColor = System.Drawing.Color.White
        Me.cmbMarcaExtra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMarcaExtra.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMarcaExtra.Items.AddRange(New Object() {"S", "N", ""})
        Me.cmbMarcaExtra.Location = New System.Drawing.Point(934, 47)
        Me.cmbMarcaExtra.Name = "cmbMarcaExtra"
        Me.cmbMarcaExtra.Size = New System.Drawing.Size(53, 21)
        Me.cmbMarcaExtra.TabIndex = 7
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(575, 47)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 13)
        Me.Label14.TabIndex = 124
        Me.Label14.Text = "Afecta ISR:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAfectaIsr
        '
        Me.cmbAfectaIsr.BackColor = System.Drawing.Color.White
        Me.cmbAfectaIsr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAfectaIsr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAfectaIsr.Items.AddRange(New Object() {"S", "N", ""})
        Me.cmbAfectaIsr.Location = New System.Drawing.Point(649, 45)
        Me.cmbAfectaIsr.Name = "cmbAfectaIsr"
        Me.cmbAfectaIsr.Size = New System.Drawing.Size(53, 21)
        Me.cmbAfectaIsr.TabIndex = 6
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(372, 47)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(106, 13)
        Me.Label13.TabIndex = 122
        Me.Label13.Text = "Afecta seguro social:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAfectaSeguro
        '
        Me.cmbAfectaSeguro.BackColor = System.Drawing.Color.White
        Me.cmbAfectaSeguro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAfectaSeguro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAfectaSeguro.Items.AddRange(New Object() {"S", "N", "", ""})
        Me.cmbAfectaSeguro.Location = New System.Drawing.Point(492, 44)
        Me.cmbAfectaSeguro.Name = "cmbAfectaSeguro"
        Me.cmbAfectaSeguro.Size = New System.Drawing.Size(53, 21)
        Me.cmbAfectaSeguro.TabIndex = 5
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(10, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 13)
        Me.Label12.TabIndex = 119
        Me.Label12.Text = "Tipo de valor:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoValor
        '
        Me.cmbTipoValor.BackColor = System.Drawing.Color.White
        Me.cmbTipoValor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoValor.Items.AddRange(New Object() {"CANTIDAD", "VALOR", "", ""})
        Me.cmbTipoValor.Location = New System.Drawing.Point(91, 44)
        Me.cmbTipoValor.Name = "cmbTipoValor"
        Me.cmbTipoValor.Size = New System.Drawing.Size(260, 21)
        Me.cmbTipoValor.TabIndex = 4
        '
        'TextBox10
        '
        Me.TextBox10.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextBox10.BackColor = System.Drawing.Color.White
        Me.TextBox10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox10.Location = New System.Drawing.Point(91, 44)
        Me.TextBox10.MaxLength = 3
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.ReadOnly = True
        Me.TextBox10.Size = New System.Drawing.Size(260, 20)
        Me.TextBox10.TabIndex = 120
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(683, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(91, 13)
        Me.Label11.TabIndex = 116
        Me.Label11.Text = "Forma de cálculo:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbFormaCal
        '
        Me.cmbFormaCal.BackColor = System.Drawing.Color.White
        Me.cmbFormaCal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaCal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaCal.Items.AddRange(New Object() {"FIJO MENSUAL", "ANTICIPOS", "INGRESO MOVIMIENTO", "HORAS EXTRAS", "SEGURO SOCIAL", "CALCULO ANUAL", ""})
        Me.cmbFormaCal.Location = New System.Drawing.Point(786, 12)
        Me.cmbFormaCal.Name = "cmbFormaCal"
        Me.cmbFormaCal.Size = New System.Drawing.Size(260, 21)
        Me.cmbFormaCal.TabIndex = 3
        '
        'gpNumero
        '
        Me.gpNumero.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpNumero.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpNumero.Controls.Add(Me.TextConxTransac)
        Me.gpNumero.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpNumero.ForeColor = System.Drawing.Color.White
        Me.gpNumero.Location = New System.Drawing.Point(1005, 2)
        Me.gpNumero.Name = "gpNumero"
        Me.gpNumero.Size = New System.Drawing.Size(117, 41)
        Me.gpNumero.TabIndex = 73
        Me.gpNumero.TabStop = False
        Me.gpNumero.Text = "Transacción"
        '
        'TextConxTransac
        '
        Me.TextConxTransac.BackColor = System.Drawing.Color.White
        Me.TextConxTransac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextConxTransac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConxTransac.ForeColor = System.Drawing.Color.Red
        Me.TextConxTransac.Location = New System.Drawing.Point(11, 16)
        Me.TextConxTransac.MaxLength = 3
        Me.TextConxTransac.Name = "TextConxTransac"
        Me.TextConxTransac.ReadOnly = True
        Me.TextConxTransac.Size = New System.Drawing.Size(95, 20)
        Me.TextConxTransac.TabIndex = 1
        Me.TextConxTransac.TabStop = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Controls.Add(Me.gpNumero)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 56)
        Me.Panel1.TabIndex = 77
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnSig)
        Me.Panel2.Controls.Add(Me.btnGuardar)
        Me.Panel2.Controls.Add(Me.btnAtr)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.btnBuscar)
        Me.Panel2.Location = New System.Drawing.Point(0, 536)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1130, 43)
        Me.Panel2.TabIndex = 78
        '
        'frmConsTipoTran
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnLimpiar
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.gpPrincipal)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmConsTipoTran"
        Me.Text = "Mantenimiento de Trasacciones de Nómina"
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gpCuenta.ResumeLayout(False)
        Me.gpCuenta.PerformLayout()
        Me.gpPrincipal.ResumeLayout(False)
        Me.gpPrincipal.PerformLayout()
        Me.ctxPrincipal.ResumeLayout(False)
        Me.gpNumero.ResumeLayout(False)
        Me.gpNumero.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region



    Private Sub frmDatosFamilia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        TextNombEmpresa.Text = BuscaEscalar("select nombre from Empresas where empresa=@empresa", ListaParametros(lpara))
        btnLimpiar_Click(sender, e)
    End Sub



#Region "CUENTA"

    Private Sub BorraCuenta(ByVal valbool As Boolean)
        TextNombCuenta.Clear()
        If valbool = True Then
            TextConsCuentaNom.Clear()
        End If
    End Sub

    Private Sub btnConNome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConNome.Click
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = TextNombCuenta.Text.Trim
        If modifica = True And cmbTipoMov.Text = "" Then
            MsgBox("DEBE ELEGIR PRIMERO EL TIPO DE MOVIMIENTO", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCuenta(True)
            cmbTipoMov.Focus()
            Exit Sub
        End If

        Dim numFilas As Int32
        TextNombCuenta.Text = TextNombCuenta.Text.Replace("'", " ")
        cadena = "select count(*) from nomencla where nombre like '%' + @nombre + '%'"
        If BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
            MsgBox("NO EXISTEN CUENTAS CONTABLES CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCuenta(True)
            Exit Sub
        End If

        cadena = "select cuenta,nombre from nomencla where empresa=@empresa and nombre like '%' + @nombre + '%' and operable='S' "
        '---------------------------------------------------------------------------------------------
        ' Se filtran si es descuento que no vayan cuentas de ingresos y gastos si se eligio modificar
        '---------------------------------------------------------------------------------------------
        If cmbTipoMov.Text = "DESCUENTOS" And modifica = True Then
            cadena = cadena & " and substring(cuenta,1,1) in ('1','2','3')"
        End If
        cadena = cadena & " order by cuenta"

        numFilas = llenaTabla(cadena, tbCuenta, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN CUENTAS CONTABLES CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCuenta(True)
            TextConsCuentaNom.Focus()
        ElseIf numFilas = 1 Then
            BorraCuenta(True)
            filaTemp = tbCuenta.Rows.Item(0)
            TextConsCuentaNom.Text() = filaTemp.Item(0)
            TextNombCuenta.Text = filaTemp.Item(1)
            '   numCantidad.Focus()
        Else
            EnBuscaCContable()
        End If

    End Sub

    Private Sub ValidaCuenta()
        lpara.Clear()
        lpara("cuenta") = TextConsCuentaNom.Text.Trim
        If BuscaEscalar("select count (*) from nomencla where cuenta=@cuenta ", ListaParametros(lpara)) = 0 Then
            MsgBox("CUENTA CONTABLE NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCuenta(True)
            Exit Sub
        End If
        cadena = "select cuenta,nombre from nomencla where cuenta=@cuenta and operable='S'"

        '---------------------------------------------------------------------
        ' Se filtran si es descuento que no vayan cuentas de ingresos y gastos
        '---------------------------------------------------------------------
        If cmbTipoMov.Text = "DESCUENTOS" Then
            cadena = cadena & " and substring(cuenta,1,1) in ('1','2','3')"
        End If

        abrir_conexion(cn)
        comando = New SqlCommand(cadena, cn)
        comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
        dr = comando.ExecuteReader
        If dr.HasRows() Then
            BorraCuenta(False)
            dr.Read()
            TextNombCuenta.Text = dr.GetValue(1)
            btnGuardar.Focus()
        Else
            MsgBox("CUENTA CONTABLE NO ES VALIDA, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCuenta(True)
            TextConsCuentaNom.Focus()
        End If
        dr.Close()
        cn.Close()
    End Sub

    Private Sub TextCuenta_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextConsCuentaNom.Validated
        If TextConsCuentaNom.Text.Trim <> "" Then
            If cmbTipoMov.Text = "" And modifica = True Then
                MsgBox("DEBE ELEGIR PRIMERO EL TIPO DE MOVIMIENTO", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraCuenta(True)
                cmbTipoMov.Focus()
                Exit Sub
            End If
            ValidaCuenta()
        Else
            BorraCuenta(False)
        End If
    End Sub

    Private Sub EnBuscaCContable()
        fCta = New frmMuestraSoloCuentas
        fCta.TopMost = True
        fCta.inicializa(tbCuenta)
        AddHandler fCta.actValor, AddressOf ActualizacionDatos
        fCta.ShowDialog()
        btnGuardar.Focus()
    End Sub

    Private Sub ActualizacionDatos(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraCuenta(True)
        filaTemp = tbCuenta.Rows.Item(e.va2)
        TextConsCuentaNom.Text() = filaTemp.Item(0)
        TextNombCuenta.Text = filaTemp.Item(1)
        btnGuardar.Focus()
    End Sub
#End Region

#Region "LIMPIAR Y  FORMATOS"



    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        borra_Mejorado(gpPrincipal, ep1)
        ConsultaReadOnly(gpPrincipal, False)
        SoloLeer(gpPrincipal, False)
        btnConNome.Enabled = True
        TextNombCuenta.ReadOnly = False
        btnBuscar.Visible = True
        btnBuscar.Enabled = True
        btnSig.Enabled = False
        btnAtr.Enabled = False
        ContextoMenuEnab(True, False, ctxPrincipal)
        btnBuscar.Visible = True
        btnGuardar.Visible = False
        TextConxTransac.ReadOnly = False
        Colorea_Mejorado(gpPrincipal, Color.White)
        TextConxTransac.Clear()
        TextConlNombre.Focus()
        modifica = False
    End Sub



#End Region

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        modifica = False
        Dim finConsulta As String = ""
        Dim cadenaConsulta As String = ""
        GeneraConsulta(gpPrincipal, finConsulta, "t1")
        If TextConxTransac.Text.Trim <> "" Then
            lpara("transac") = TextConxTransac.Text
            finConsulta = finConsulta & " and t1.transac=@transac "
        End If
        If cmbTipoMov.Text.Trim <> "" Then
            lpara("tipomov") = cmbTipoMov.Text.Substring(0, 1)
            finConsulta = finConsulta & " and t1.tipomov=@tipomov "
        End If
        If cmbFormaCal.Text.Trim <> "" Then
            lpara("formacal") = formaCalculo(cmbFormaCal.SelectedIndex)
            finConsulta = finConsulta & " and t1.formacal=@formacal "
        End If
        If cmbTipoValor.Text.Trim <> "" Then
            lpara("tipovalor") = cmbTipoValor.Text.Substring(0, 1)
            finConsulta = finConsulta & " and t1.tipovalor=@tipovalor "
        End If
        If cmbAfectaSeguro.Text.Trim <> "" Then
            lpara("afectaseguro") = cmbAfectaSeguro.Text
            finConsulta = finConsulta & " and t1.afectaseguro=@afectaseguro "
        End If
        If cmbAfectaIsr.Text.Trim <> "" Then
            lpara("afectaisr") = cmbAfectaIsr.Text
            finConsulta = finConsulta & " and t1.afectaisr=@afectaisr "
        End If
        If cmbMarcaExtra.Text.Trim <> "" Then
            lpara("marextras") = cmbMarcaExtra.Text
            finConsulta = finConsulta & " and t1.marextras=@marextras "
        End If
        If cmbCtate.Text.Trim <> "" Then
            lpara("ctacte") = cmbCtate.Text
            finConsulta = finConsulta & " and t1.ctacte=@ctacte "
        End If
        cadenaConsulta = inicioConsulta & finConsulta & " order by transac "
        Mostrar(cadenaConsulta, sender, e)
    End Sub


    Private Sub Mostrar(ByVal subCadena As String, ByVal sender As System.Object, ByVal e As System.EventArgs)
        ConsultaReadOnly(gpPrincipal, True)
        btnConNome.Enabled = False
        TextNombCuenta.ReadOnly = True
        SoloLeer(gpPrincipal, True)
        btnBuscar.Enabled = False
        ContextoMenuEnab(True, True, ctxPrincipal)
        TextConxTransac.ReadOnly = True
        indice = 0
        If llenaTabla(subCadena, tbConsulta, ListaParametros(lpara)) > 0 Then
            LlenarTextBox(0, tbConsulta)
        Else
            MsgBox("NO HAY REGISTROS CON ESTOS CRITERIOS DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            btnLimpiar_Click(sender, e)
        End If
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub

    Private Sub LlenarTextBox(ByVal indi As Int16, ByVal tabla As DataTable)
        Dim filaCopiar As DataRow
        filaCopiar = tabla.Rows.Item(indi)
        TextConxTransac.Text = filaCopiar.Item(0)
        TextConlNombre.Text = filaCopiar.Item(1)
        Select Case filaCopiar.Item(2)
            Case "I"
                cmbTipoMov.SelectedIndex = 0
            Case "D"
                cmbTipoMov.SelectedIndex = 1
        End Select
        TextTipoMov.Text = cmbTipoMov.Text
        Select Case filaCopiar.Item(3)
            Case "FM"
                cmbFormaCal.SelectedIndex = 0
            Case "AN"
                cmbFormaCal.SelectedIndex = 1
            Case "IM"
                cmbFormaCal.SelectedIndex = 2
            Case "EX"
                cmbFormaCal.SelectedIndex = 3
            Case "SS"
                cmbFormaCal.SelectedIndex = 4
            Case "CA"
                cmbFormaCal.SelectedIndex = 5
        End Select
        TextFormaCal.Text = cmbFormaCal.Text
        Select Case filaCopiar.Item(4)
            Case "C"
                cmbTipoValor.SelectedIndex = 0
            Case "V"
                cmbTipoValor.SelectedIndex = 1
        End Select
        TextTipoValor.Text = cmbTipoValor.Text
        cmbAfectaSeguro.Text = filaCopiar.Item(5)
        TextAfectaSeguro.Text = filaCopiar.Item(5)
        cmbAfectaIsr.Text = filaCopiar.Item(6)
        TextAfectaIsr.Text = filaCopiar.Item(6)
        cmbMarcaExtra.Text = filaCopiar.Item(7)
        TextMarcaExtra.Text = filaCopiar.Item(7)
        cmbCtate.Text = filaCopiar.Item(8)
        TextCtate.Text = filaCopiar.Item(8)
        TextFactor.Text = filaCopiar.Item(9)
        TextConsCuentaNom.Text = filaCopiar.Item(10)
        ValidaCuenta()
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim tipoMov, formaCal As String
        Dim factor As Decimal = 0
        lpara.Clear()
        tipoMov = ""
        formaCal = ""
        If Not validetError(TextConlNombre, ep1) Or Not validetError(cmbTipoMov, ep1) Or Not validetError(cmbFormaCal, ep1) Or _
        Not validetError(TextConsCuentaNom, ep1) Or Not validetError(cmbTipoValor, ep1) Then
            MsgBox("DEBE INGRESAR TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        Select Case cmbTipoMov.SelectedIndex
            Case 0
                If Not validetError(cmbAfectaSeguro, ep1) Or Not validetError(cmbAfectaIsr, ep1) Or Not validetError(cmbMarcaExtra, ep1) Then
                    MsgBox("DEBE INGRESAR TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
                tipoMov = "I"
            Case 1
                If Not validetError(cmbCtate, ep1) Then
                    MsgBox("DEBE INGRESAR TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
                tipoMov = "D"
        End Select
        Select Case cmbFormaCal.SelectedIndex
            Case 0
                formaCal = "FM"
            Case 1
                formaCal = "AN"
            Case 2
                formaCal = "IM"
            Case 3
                formaCal = "EX"
                If Not validetError(TextFactor, ep1) Then
                    MsgBox("DEBE INGRESAR TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                Else
                    factor = CDec(TextFactor.Text)
                End If
            Case 4
                formaCal = "SS"
            Case 5
                formaCal = "CA"
        End Select
        If MsgBox("ESTA SEGURO QUE DESEA ACTUALIZAR ESTE REGISTRO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            Try
                lpara("empresa") = empresa
                lpara("nombre") = TextConlNombre.Text
                lpara("tipomov") = tipoMov
                lpara("formacal") = formaCal
                lpara("tipovalor") = cmbTipoValor.Text.Substring(0, 1)
                lpara("afectaseguro") = cmbAfectaSeguro.Text
                lpara("afectaisr") = cmbAfectaIsr.Text
                lpara("marextras") = cmbMarcaExtra.Text
                lpara("ctacte") = cmbCtate.Text
                lpara("factor") = factor
                lpara("cuentanom") = TextConsCuentaNom.Text
                lpara("transac") = TextConxTransac.Text
                cadena = "update tipotran set nombre=@nombre, tipomov=@tipomov, formacal=@formacal," &
                           " tipovalor=@tipovalor, afectaseguro=@afectaseguro " &
                           ", afectaisr=@afectaisr, marextras=@marextras, ctacte=@ctacte " &
                           ", factor=@factor, cuentanom=@cuentanom " &
                           "where empresa=@empresa and transac=@transac"
                EjecutarQuery(cadena, ListaParametros(lpara))
                InsertBitacora(9, 2, Me.Text)

                MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                btnLimpiar_Click(sender, e)


            Catch ex As Exception
                MsgBox("ERROR EN EL INGRESO DE DATOS O INDICE REPETIDO", MsgBoxStyle.Critical, "Mensaje del Sistema")
                'TextConxTransac.Text = modelo.BuscaEscalar("select coalesce(max(transac),0) from tipotran where empresa=" & empresa) + 1

            End Try
        End If

    End Sub

    Private Sub TextPor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextConsCuentaNom.KeyPress, TextConxTransac.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub TextFactor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextFactor.KeyPress
        soloNumeroDec(sender, e)
    End Sub


    Private Sub cmbTipoMov_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoMov.SelectedIndexChanged
        cmbAfectaSeguro.Text = ""
        cmbAfectaIsr.Text = ""
        cmbMarcaExtra.Text = ""
        cmbCtate.Text = ""
        TextFactor.Text = ""
        TextFactor.Enabled = False
        Select Case cmbTipoMov.SelectedIndex
            Case 0
                cmbAfectaSeguro.Enabled = True
                cmbAfectaIsr.Enabled = True
                cmbMarcaExtra.Enabled = True
                cmbCtate.Enabled = False
            Case 1
                cmbAfectaSeguro.Enabled = False
                cmbAfectaIsr.Enabled = False
                cmbMarcaExtra.Enabled = False
                cmbCtate.Enabled = True
            Case 2
                cmbAfectaSeguro.Enabled = False
                cmbAfectaIsr.Enabled = False
                cmbMarcaExtra.Enabled = False
                cmbCtate.Enabled = False
        End Select
    End Sub

    Private Sub cmbFormaCal_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaCal.SelectedIndexChanged
        TextFactor.Text = ""
        If cmbFormaCal.SelectedIndex = 3 Then
            TextFactor.Enabled = True
        Else
            TextFactor.Enabled = False
        End If
    End Sub


#Region "ENTRA Y DEJA FOCO"
    Private Sub Foco(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoMov.Enter, TextConlNombre.Enter, TextConsCuentaNom.Enter, TextNombCuenta.Enter
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoMov.Leave, TextConlNombre.Leave, TextConsCuentaNom.Leave, TextNombCuenta.Leave
        desactiva(sender)
    End Sub
#End Region

#Region "Botones Siguiente"
    Private Sub btnSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSig.Click
        indice = indice + 1
        LlenarTextBox(indice, tbConsulta)
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub

    Private Sub btnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtr.Click
        indice = indice - 1
        LlenarTextBox(indice, tbConsulta)
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub
#End Region

    Private Sub frmDatosGen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub


    Private Sub numCantidad_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextFactor.Validated
        validatedDecimalPreci(sender, 3, 2)
    End Sub



    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub


    Private Sub ctxModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificar.Click
        modifica = True
        ContextoMenuEnab(True, True, ctxPrincipal)
        ConsultaReadOnly(gpPrincipal, False)
        btnConNome.Enabled = True
        TextNombCuenta.ReadOnly = False
        SoloLeer(gpPrincipal, False)
        btnSig.Enabled = False
        btnAtr.Enabled = False
        btnBuscar.Visible = False
        btnGuardar.Visible = True
        Colorea_Mejorado(gpPrincipal, ColorModi)
    End Sub

    Private Sub ctxEliminacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminacion.Click
        Dim modelo As New cmodelo
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("transac") = TextConxTransac.Text
        If MsgBox("ESTA SEGURO QUE DESEA ELIMINAR ESTA TRANSACCION", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            If BuscaEscalar("select dbo.eliminaTransac  (@empresa,@transac)", ListaParametros(lpara)) > 0 Then
                MsgBox("NO SE PUEDE ELIMINAR TRANSACCION, POSEE REFERENCIA", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End If

            Try
                cadena = "delete from tipotran where empresa=@empresa and transac=@transac"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                modelo.Commit()
                InsertBitacora(9, 4, Me.Text)
                MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                btnLimpiar_Click(sender, e)
            Catch ex As Exception
                MsgBox("Error del Sistema: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Error del Sistema")
                modelo.RollBack()
            End Try

        End If
    End Sub

    Private Sub TextAfectaIsr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextAfectaIsr.TextChanged

    End Sub
End Class
