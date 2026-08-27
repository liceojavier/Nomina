Imports System.Data.SqlClient
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports System.Data
Imports System.Drawing

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMINGRESOPROVISIONES.VB MIEMBRO DE NOMINA.SLN                              **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class FrmIngresoProvisiones
    Inherits Form
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim WithEvents fCta As frmMuestraSoloCuentas
    Dim WithEvents fCtaP As frmMuestraSoloCuentas
    'Dim WithEvents fOrig As frmMuestraUnidadesOp
    Dim tbActivo As New DataTable("activo")
    Dim tbProveedor As New DataTable("proveedor")
    Dim tbOrigen As New DataTable("origen")
    Dim tbDatos As New DataTable("datos")

    '--------------------------------------------------
    ' Definicion de Objetos a Utilizar en Codificaciòn
    '--------------------------------------------------
    Dim tbTipo As New DataTable("tipo")
    Dim tbUbicacion As New DataTable("ubicacion")
    Dim WithEvents fTran As frmMuestraCodigos
    Dim TipoTarE As Integer
    Dim cm As CurrencyManager
    Dim dv As DataView
    Dim primeraves As Boolean = True
    Dim ts As New DataGridTableStyle
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextNombPasivo As System.Windows.Forms.TextBox
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Dim fechaF As Date


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
    Friend WithEvents TxtNoEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents TxtNoBien As System.Windows.Forms.TextBox
    Friend WithEvents BtnGuardar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents gpBien As System.Windows.Forms.GroupBox
    Friend WithEvents btnIngresar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnIngreso As System.Windows.Forms.Button
    Friend WithEvents gpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents dgDatos As System.Windows.Forms.DataGridView
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents StatusBar1 As System.Windows.Forms.StatusBar
    Friend WithEvents StatusBarPanel1 As System.Windows.Forms.StatusBarPanel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpTransac As System.Windows.Forms.GroupBox
    Friend WithEvents TextTransac As System.Windows.Forms.TextBox
    Friend WithEvents TextNombTransac As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnTransac As System.Windows.Forms.Button
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents gpGasto As System.Windows.Forms.GroupBox
    Friend WithEvents TextCGasto As System.Windows.Forms.TextBox
    Friend WithEvents TextNombCGasto As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnGasto As System.Windows.Forms.Button
    Friend WithEvents gpPasivo As System.Windows.Forms.GroupBox
    Friend WithEvents TextCPasivo As System.Windows.Forms.TextBox
    Friend WithEvents TextNombCPasivo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnPasivo As System.Windows.Forms.Button
    Friend WithEvents GpPasivoL As System.Windows.Forms.GroupBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents GpDetalle1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmIngresoProvisiones))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GpPasivoL = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextNombPasivo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CmbTipo = New System.Windows.Forms.ComboBox()
        Me.btnIngresar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.TextPorcentaje = New System.Windows.Forms.TextBox()
        Me.gpGasto = New System.Windows.Forms.GroupBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextCGasto = New System.Windows.Forms.TextBox()
        Me.TextNombCGasto = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnGasto = New System.Windows.Forms.Button()
        Me.gpPasivo = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextCPasivo = New System.Windows.Forms.TextBox()
        Me.TextNombCPasivo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnPasivo = New System.Windows.Forms.Button()
        Me.gpTransac = New System.Windows.Forms.GroupBox()
        Me.TextTransac = New System.Windows.Forms.TextBox()
        Me.TextNombTransac = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnTransac = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.TxtNoBien = New System.Windows.Forms.TextBox()
        Me.BtnGuardar = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.gpBien = New System.Windows.Forms.GroupBox()
        Me.GpDetalle1 = New System.Windows.Forms.GroupBox()
        Me.btnIngreso = New System.Windows.Forms.Button()
        Me.gpDetalle = New System.Windows.Forms.GroupBox()
        Me.dgDatos = New System.Windows.Forms.DataGridView()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusBar1 = New System.Windows.Forms.StatusBar()
        Me.StatusBarPanel1 = New System.Windows.Forms.StatusBarPanel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GpPasivoL.SuspendLayout()
        Me.gpGasto.SuspendLayout()
        Me.gpPasivo.SuspendLayout()
        Me.gpTransac.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.gpBien.SuspendLayout()
        Me.GpDetalle1.SuspendLayout()
        Me.gpDetalle.SuspendLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GpPasivoL
        '
        Me.GpPasivoL.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GpPasivoL.Controls.Add(Me.Label7)
        Me.GpPasivoL.Controls.Add(Me.TextNombPasivo)
        Me.GpPasivoL.Controls.Add(Me.Label5)
        Me.GpPasivoL.Controls.Add(Me.Label6)
        Me.GpPasivoL.Controls.Add(Me.CmbTipo)
        Me.GpPasivoL.Controls.Add(Me.btnIngresar)
        Me.GpPasivoL.Controls.Add(Me.TextPorcentaje)
        Me.GpPasivoL.Controls.Add(Me.gpGasto)
        Me.GpPasivoL.Controls.Add(Me.gpPasivo)
        Me.GpPasivoL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpPasivoL.Location = New System.Drawing.Point(5, 51)
        Me.GpPasivoL.Name = "GpPasivoL"
        Me.GpPasivoL.Size = New System.Drawing.Size(746, 218)
        Me.GpPasivoL.TabIndex = 1
        Me.GpPasivoL.TabStop = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(19, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(47, 13)
        Me.Label7.TabIndex = 107
        Me.Label7.Text = "Nombre:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextNombPasivo
        '
        Me.TextNombPasivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombPasivo.Location = New System.Drawing.Point(85, 16)
        Me.TextNombPasivo.MaxLength = 20
        Me.TextNombPasivo.Name = "TextNombPasivo"
        Me.TextNombPasivo.Size = New System.Drawing.Size(404, 20)
        Me.TextNombPasivo.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(15, 190)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 13)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Tipo de provisión:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(416, 190)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(61, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Porcentaje:"
        '
        'CmbTipo
        '
        Me.CmbTipo.BackColor = System.Drawing.Color.White
        Me.CmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CmbTipo.Items.AddRange(New Object() {"SEGURO SOCIAL PATRONAL", "AGUINALDO", "BONO ANUAL", "VACACIONES", "INDEMNIZACION", ""})
        Me.CmbTipo.Location = New System.Drawing.Point(113, 186)
        Me.CmbTipo.Name = "CmbTipo"
        Me.CmbTipo.Size = New System.Drawing.Size(247, 21)
        Me.CmbTipo.TabIndex = 4
        '
        'btnIngresar
        '
        Me.btnIngresar.BackColor = System.Drawing.SystemColors.Control
        Me.btnIngresar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngresar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngresar.ImageKey = "checkok.png"
        Me.btnIngresar.ImageList = Me.ImageNuevos
        Me.btnIngresar.Location = New System.Drawing.Point(619, 182)
        Me.btnIngresar.Name = "btnIngresar"
        Me.btnIngresar.Size = New System.Drawing.Size(71, 30)
        Me.btnIngresar.TabIndex = 6
        Me.btnIngresar.Text = "Aceptar"
        Me.btnIngresar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnIngresar, "Ingresar datos  generales del bien")
        Me.btnIngresar.UseVisualStyleBackColor = False
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
        '
        'TextPorcentaje
        '
        Me.TextPorcentaje.BackColor = System.Drawing.Color.White
        Me.TextPorcentaje.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPorcentaje.Location = New System.Drawing.Point(497, 187)
        Me.TextPorcentaje.MaxLength = 7
        Me.TextPorcentaje.Name = "TextPorcentaje"
        Me.TextPorcentaje.Size = New System.Drawing.Size(83, 20)
        Me.TextPorcentaje.TabIndex = 5
        '
        'gpGasto
        '
        Me.gpGasto.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpGasto.Controls.Add(Me.Label11)
        Me.gpGasto.Controls.Add(Me.TextCGasto)
        Me.gpGasto.Controls.Add(Me.TextNombCGasto)
        Me.gpGasto.Controls.Add(Me.Label3)
        Me.gpGasto.Controls.Add(Me.btnGasto)
        Me.gpGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpGasto.Location = New System.Drawing.Point(7, 42)
        Me.gpGasto.Name = "gpGasto"
        Me.gpGasto.Size = New System.Drawing.Size(703, 64)
        Me.gpGasto.TabIndex = 2
        Me.gpGasto.TabStop = False
        Me.gpGasto.Text = "Cuenta de gasto"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 7
        Me.Label11.Text = "Código:"
        '
        'TextCGasto
        '
        Me.TextCGasto.BackColor = System.Drawing.Color.White
        Me.TextCGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCGasto.Location = New System.Drawing.Point(61, 16)
        Me.TextCGasto.MaxLength = 4
        Me.TextCGasto.Name = "TextCGasto"
        Me.TextCGasto.Size = New System.Drawing.Size(48, 20)
        Me.TextCGasto.TabIndex = 1
        '
        'TextNombCGasto
        '
        Me.TextNombCGasto.BackColor = System.Drawing.Color.White
        Me.TextNombCGasto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombCGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombCGasto.Location = New System.Drawing.Point(174, 15)
        Me.TextNombCGasto.MaxLength = 75
        Me.TextNombCGasto.Name = "TextNombCGasto"
        Me.TextNombCGasto.Size = New System.Drawing.Size(402, 20)
        Me.TextNombCGasto.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(121, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Nombre:"
        '
        'btnGasto
        '
        Me.btnGasto.BackColor = System.Drawing.SystemColors.Control
        Me.btnGasto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGasto.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGasto.ImageKey = "buscar1.png"
        Me.btnGasto.ImageList = Me.ImageNuevos
        Me.btnGasto.Location = New System.Drawing.Point(612, 15)
        Me.btnGasto.Name = "btnGasto"
        Me.btnGasto.Size = New System.Drawing.Size(71, 30)
        Me.btnGasto.TabIndex = 3
        Me.btnGasto.Text = "Buscar"
        Me.btnGasto.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGasto, "Buscar activo")
        Me.btnGasto.UseVisualStyleBackColor = False
        '
        'gpPasivo
        '
        Me.gpPasivo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpPasivo.Controls.Add(Me.Label10)
        Me.gpPasivo.Controls.Add(Me.TextCPasivo)
        Me.gpPasivo.Controls.Add(Me.TextNombCPasivo)
        Me.gpPasivo.Controls.Add(Me.Label2)
        Me.gpPasivo.Controls.Add(Me.btnPasivo)
        Me.gpPasivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpPasivo.Location = New System.Drawing.Point(7, 112)
        Me.gpPasivo.Name = "gpPasivo"
        Me.gpPasivo.Size = New System.Drawing.Size(703, 64)
        Me.gpPasivo.TabIndex = 3
        Me.gpPasivo.TabStop = False
        Me.gpPasivo.Text = "Cuenta de pasivo"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 7
        Me.Label10.Text = "Código:"
        '
        'TextCPasivo
        '
        Me.TextCPasivo.BackColor = System.Drawing.Color.White
        Me.TextCPasivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCPasivo.Location = New System.Drawing.Point(61, 22)
        Me.TextCPasivo.MaxLength = 6
        Me.TextCPasivo.Name = "TextCPasivo"
        Me.TextCPasivo.Size = New System.Drawing.Size(48, 20)
        Me.TextCPasivo.TabIndex = 1
        '
        'TextNombCPasivo
        '
        Me.TextNombCPasivo.BackColor = System.Drawing.Color.White
        Me.TextNombCPasivo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombCPasivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombCPasivo.Location = New System.Drawing.Point(174, 19)
        Me.TextNombCPasivo.MaxLength = 50
        Me.TextNombCPasivo.Name = "TextNombCPasivo"
        Me.TextNombCPasivo.Size = New System.Drawing.Size(399, 20)
        Me.TextNombCPasivo.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(121, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nombre:"
        '
        'btnPasivo
        '
        Me.btnPasivo.BackColor = System.Drawing.SystemColors.Control
        Me.btnPasivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPasivo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPasivo.ImageKey = "buscar1.png"
        Me.btnPasivo.ImageList = Me.ImageNuevos
        Me.btnPasivo.Location = New System.Drawing.Point(612, 16)
        Me.btnPasivo.Name = "btnPasivo"
        Me.btnPasivo.Size = New System.Drawing.Size(71, 30)
        Me.btnPasivo.TabIndex = 3
        Me.btnPasivo.Text = "Buscar"
        Me.btnPasivo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnPasivo, "Buscar ubicación")
        Me.btnPasivo.UseVisualStyleBackColor = False
        '
        'gpTransac
        '
        Me.gpTransac.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.gpTransac.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpTransac.Controls.Add(Me.TextTransac)
        Me.gpTransac.Controls.Add(Me.TextNombTransac)
        Me.gpTransac.Controls.Add(Me.Label9)
        Me.gpTransac.Controls.Add(Me.btnTransac)
        Me.gpTransac.Controls.Add(Me.Label4)
        Me.gpTransac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTransac.Location = New System.Drawing.Point(10, 6)
        Me.gpTransac.Name = "gpTransac"
        Me.gpTransac.Size = New System.Drawing.Size(603, 56)
        Me.gpTransac.TabIndex = 1
        Me.gpTransac.TabStop = False
        Me.gpTransac.Text = "Transacción"
        '
        'TextTransac
        '
        Me.TextTransac.BackColor = System.Drawing.Color.White
        Me.TextTransac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTransac.Location = New System.Drawing.Point(62, 22)
        Me.TextTransac.MaxLength = 4
        Me.TextTransac.Name = "TextTransac"
        Me.TextTransac.Size = New System.Drawing.Size(48, 20)
        Me.TextTransac.TabIndex = 1
        '
        'TextNombTransac
        '
        Me.TextNombTransac.BackColor = System.Drawing.Color.White
        Me.TextNombTransac.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombTransac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombTransac.Location = New System.Drawing.Point(171, 22)
        Me.TextNombTransac.MaxLength = 50
        Me.TextNombTransac.Name = "TextNombTransac"
        Me.TextNombTransac.Size = New System.Drawing.Size(348, 20)
        Me.TextNombTransac.TabIndex = 2
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(117, 25)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "Nombre:"
        '
        'btnTransac
        '
        Me.btnTransac.BackColor = System.Drawing.SystemColors.Control
        Me.btnTransac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransac.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTransac.ImageKey = "buscar1.png"
        Me.btnTransac.ImageList = Me.ImageNuevos
        Me.btnTransac.Location = New System.Drawing.Point(525, 16)
        Me.btnTransac.Name = "btnTransac"
        Me.btnTransac.Size = New System.Drawing.Size(78, 30)
        Me.btnTransac.TabIndex = 5
        Me.btnTransac.Text = "Buscar"
        Me.btnTransac.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnTransac, "Busar activo")
        Me.btnTransac.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 55
        Me.Label4.Text = "Código:"
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(1058, 9)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(66, 30)
        Me.btnLimpiar.TabIndex = 4
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'TxtNoBien
        '
        Me.TxtNoBien.BackColor = System.Drawing.Color.White
        Me.TxtNoBien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoBien.ForeColor = System.Drawing.Color.Red
        Me.TxtNoBien.Location = New System.Drawing.Point(10, 14)
        Me.TxtNoBien.MaxLength = 7
        Me.TxtNoBien.Name = "TxtNoBien"
        Me.TxtNoBien.ReadOnly = True
        Me.TxtNoBien.Size = New System.Drawing.Size(61, 20)
        Me.TxtNoBien.TabIndex = 4
        Me.TxtNoBien.TabStop = False
        '
        'BtnGuardar
        '
        Me.BtnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BtnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.BtnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.BtnGuardar.ImageKey = "guardar.png"
        Me.BtnGuardar.ImageList = Me.ImageNuevos
        Me.BtnGuardar.Location = New System.Drawing.Point(1041, 194)
        Me.BtnGuardar.Name = "BtnGuardar"
        Me.BtnGuardar.Size = New System.Drawing.Size(77, 30)
        Me.BtnGuardar.TabIndex = 5
        Me.BtnGuardar.Text = "Guardar"
        Me.BtnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.BtnGuardar, "Almacenar registro")
        Me.BtnGuardar.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.TextNombEmpresa)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(372, 1)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(391, 44)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Empresa"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.Location = New System.Drawing.Point(8, 14)
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(371, 20)
        Me.TextNombEmpresa.TabIndex = 0
        Me.TextNombEmpresa.TabStop = False
        '
        'gpBien
        '
        Me.gpBien.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpBien.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpBien.Controls.Add(Me.TxtNoBien)
        Me.gpBien.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpBien.ForeColor = System.Drawing.Color.White
        Me.gpBien.Location = New System.Drawing.Point(972, 1)
        Me.gpBien.Name = "gpBien"
        Me.gpBien.Size = New System.Drawing.Size(80, 44)
        Me.gpBien.TabIndex = 35
        Me.gpBien.TabStop = False
        Me.gpBien.Text = "Pasivo"
        '
        'GpDetalle1
        '
        Me.GpDetalle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GpDetalle1.Controls.Add(Me.gpTransac)
        Me.GpDetalle1.Controls.Add(Me.btnIngreso)
        Me.GpDetalle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GpDetalle1.Location = New System.Drawing.Point(5, 272)
        Me.GpDetalle1.Name = "GpDetalle1"
        Me.GpDetalle1.Size = New System.Drawing.Size(746, 69)
        Me.GpDetalle1.TabIndex = 2
        Me.GpDetalle1.TabStop = False
        '
        'btnIngreso
        '
        Me.btnIngreso.BackColor = System.Drawing.SystemColors.Control
        Me.btnIngreso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngreso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngreso.ImageKey = "checkok.png"
        Me.btnIngreso.ImageList = Me.ImageNuevos
        Me.btnIngreso.Location = New System.Drawing.Point(619, 28)
        Me.btnIngreso.Name = "btnIngreso"
        Me.btnIngreso.Size = New System.Drawing.Size(71, 30)
        Me.btnIngreso.TabIndex = 2
        Me.btnIngreso.Text = "Aceptar"
        Me.btnIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnIngreso, "Ingresar centro de costo para aplicación del gasto")
        Me.btnIngreso.UseVisualStyleBackColor = False
        '
        'gpDetalle
        '
        Me.gpDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpDetalle.Controls.Add(Me.dgDatos)
        Me.gpDetalle.Controls.Add(Me.BtnGuardar)
        Me.gpDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDetalle.Location = New System.Drawing.Point(5, 347)
        Me.gpDetalle.Name = "gpDetalle"
        Me.gpDetalle.Size = New System.Drawing.Size(1125, 228)
        Me.gpDetalle.TabIndex = 3
        Me.gpDetalle.TabStop = False
        '
        'dgDatos
        '
        Me.dgDatos.AllowUserToAddRows = False
        Me.dgDatos.AllowUserToDeleteRows = False
        Me.dgDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDatos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgDatos.ContextMenuStrip = Me.ctxMenu
        Me.dgDatos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgDatos.Location = New System.Drawing.Point(6, 13)
        Me.dgDatos.MultiSelect = False
        Me.dgDatos.Name = "dgDatos"
        Me.dgDatos.ReadOnly = True
        Me.dgDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDatos.Size = New System.Drawing.Size(1113, 175)
        Me.dgDatos.TabIndex = 8
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxEliminar})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(149, 26)
        '
        'ctxEliminar
        '
        Me.ctxEliminar.Name = "ctxEliminar"
        Me.ctxEliminar.Size = New System.Drawing.Size(148, 22)
        Me.ctxEliminar.Text = "Eliminar Línea"
        '
        'StatusBar1
        '
        Me.StatusBar1.Location = New System.Drawing.Point(0, 581)
        Me.StatusBar1.Name = "StatusBar1"
        Me.StatusBar1.Panels.AddRange(New System.Windows.Forms.StatusBarPanel() {Me.StatusBarPanel1})
        Me.StatusBar1.ShowPanels = True
        Me.StatusBar1.Size = New System.Drawing.Size(1130, 24)
        Me.StatusBar1.TabIndex = 36
        '
        'StatusBarPanel1
        '
        Me.StatusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring
        Me.StatusBarPanel1.Name = "StatusBarPanel1"
        Me.StatusBarPanel1.Text = "Realiza el ingreso de un pasivo laboral."
        Me.StatusBarPanel1.Width = 1113
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
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gpBien)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 46)
        Me.Panel1.TabIndex = 37
        '
        'FrmIngresoProvisiones
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.StatusBar1)
        Me.Controls.Add(Me.GpDetalle1)
        Me.Controls.Add(Me.GpPasivoL)
        Me.Controls.Add(Me.gpDetalle)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "FrmIngresoProvisiones"
        Me.Text = "Ingreso de Pasivos Laborales"
        Me.GpPasivoL.ResumeLayout(False)
        Me.GpPasivoL.PerformLayout()
        Me.gpGasto.ResumeLayout(False)
        Me.gpGasto.PerformLayout()
        Me.gpPasivo.ResumeLayout(False)
        Me.gpPasivo.PerformLayout()
        Me.gpTransac.ResumeLayout(False)
        Me.gpTransac.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.gpBien.ResumeLayout(False)
        Me.gpBien.PerformLayout()
        Me.GpDetalle1.ResumeLayout(False)
        Me.gpDetalle.ResumeLayout(False)
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        CType(Me.StatusBarPanel1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Dim cadena, temp As String
    Dim deprecia As DataTable = New DataTable("DEPRECIA")
    Dim mycolumn As DataColumn 'Representa el esquema de una columna.
    Dim f, g As DataRow
    Dim LimpiaPrimera As Boolean = True
    Dim buscapor, TextoPor, NombrePor As Object
    Dim valido As Boolean
    Dim Muestra_DataGrid As Boolean = False
    Dim i, j As Integer
    Dim Suma1, AnteriorSuma As Integer
    Dim lpara As New Dictionary(Of String, Object)

    '------------------------------------------
    ' Boton que Inicializa y limpia la Forma
    '------------------------------------------

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        lpara.Clear()
        lpara("empresa") = empresa
        cadena = "select coalesce(max(pasivo),0) from pasivolab1 where empresa = @empresa"
        TxtNoBien.Text = BuscaEscalar(cadena, ListaParametros(lpara)) + 1
        tbDatos.Clear()
        borra_Mejorado(GpPasivoL, ep1)
        borra_Mejorado(GpDetalle1, ep1)
        GpDetalle1.Enabled = False
        GpPasivoL.Enabled = True
        gpDetalle.Enabled = False
        CmbTipo.Text = Nothing
        TextNombPasivo.Focus()
    End Sub


#Region "ESTILO Y CAMBIO DE VALORES"

    '-----------------------------------------
    ' Funcio de estilo par una tabla de datos
    '-----------------------------------------
    Private Sub estilo()
        'dgDatos.TableStyles.Clear()
        ts.MappingName = "datos"
        'dgDatos.TableStyles.Add(ts)
        With dgDatos '.TableStyles("datos")
            '.PreferredColumnWidth = 15
            .Columns(0).Width = 90
            .Columns(0).ReadOnly = True
            .Columns(0).HeaderText = "Transaccion"
            .Columns(1).Width = 300
            .Columns(1).ReadOnly = True
            .Columns(1).HeaderText = "Nombre"
            '.GridColumnStyles(2).Width = 50
            '.GridColumnStyles(2).ReadOnly = True
            '.GridColumnStyles(2).HeaderText = "CODIGO"
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen
            '.GridLineColor = Color.Black
        End With
    End Sub

    '-------------------------------------------
    ' Menu contextual asociado al tb para borrar
    '-------------------------------------------

    Private Sub ctxEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
        If dgDatos.SelectedRows.Count > 0 Then
            If MsgBox("ESTA SEGURO QUE DESEA ELIMINAR LA LINEA " & dgDatos.SelectedRows(0).Index + 1, MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                filaTemp = CType(dgDatos.SelectedRows(0).DataBoundItem, DataRowView).Row
                tbDatos.Rows.Remove(filaTemp)
                dgDatos.Refresh()
                'AltoGrid(17, tbDatos, 160, 492, False, dgDatos)
            End If
        Else
            MsgBox("NO HAY NINGUNA LINEA PARA ELIMINAR", MsgBoxStyle.Information, "Mensaje del Sistemas")
        End If
    End Sub

#End Region



#Region "CUENTA GASTO"

    Private Sub BorraCGasto(ByVal valbool As Boolean)
        TextNombCGasto.Clear()
        If valbool = True Then
            TextCGasto.Clear()
            'CampoL(TextActivo)
        End If
    End Sub

    Private Sub btnActivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGasto.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("nombre") = TextNombCGasto.Text.Trim
        lpara("empresa") = empresa
        cadena = "select cuenta,nombre from nomencla where empresa=@empresa and nombre like '%' + nombre + '%' and operable='S' and naturaleza = 5 order by nombre"
        numFilas = llenaTabla(cadena, tbActivo, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN CUENTAS DE GASTO CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCGasto(True)
            TextCGasto.Focus()
        ElseIf numFilas = 1 Then
            BorraCGasto(True)
            filaTemp = tbActivo.Rows.Item(0)
            TextCGasto.Text() = filaTemp.Item(0)
            TextNombCGasto.Text = filaTemp.Item(1)
            'textCantidad.Focus()
            TextCPasivo.Focus()
        Else
            EnBuscaCGasto()
        End If
    End Sub

    Private Sub ValidaCGasto()
        lpara.Clear()
        lpara("cuenta") = TextCGasto.Text.Trim
        cadena = "select count (*) from nomencla where cuenta=@cuenta"
        If BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
            MsgBox("NUMERO DE CUENTA NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCGasto(True)
            TextCGasto.Focus()
            Exit Sub
        End If
        cadena = "select cuenta,nombre from nomencla where cuenta=@cuenta and operable='S' and naturaleza = 5"
        abrir_conexion(cn)
        comando = New SqlCommand(cadena, cn)
        comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
        dr = comando.ExecuteReader
        If dr.HasRows() Then
            BorraCGasto(False)
            dr.Read()
            TextNombCGasto.Text = dr.GetValue(1)
            dr.Close()
            cn.Close()
            TextCPasivo.Focus()
        Else
            MsgBox("NO ES UNA CUENTA DE GASTO, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            dr.Close()
            cn.Close()
            BorraCGasto(True)
            TextCGasto.Focus()
        End If
    End Sub

    Private Sub TextCGasto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextCGasto.KeyPress, TextCPasivo.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub TextActivo_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCGasto.Validated
        If TextCGasto.Text.Trim <> "" Then
            ValidaCGasto()
        Else
            BorraCGasto(False)
        End If
    End Sub

    Private Sub EnBuscaCGasto()
        fCta = New frmMuestraSoloCuentas
        fCta.TopMost = True
        fCta.inicializa(tbActivo)
        AddHandler fCta.actValor, AddressOf ActualizacionDatosCGasto
        fCta.ShowDialog()
        TextCPasivo.Focus()
    End Sub

    Private Sub ActualizacionDatosCGasto(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraCGasto(True)
        filaTemp = tbActivo.Rows.Item(e.va2)
        TextCGasto.Text() = filaTemp.Item(0)
        TextNombCGasto.Text = filaTemp.Item(1)
    End Sub

#End Region

#Region "CUENTA PASIVO"

    Private Sub borraCPasivo(ByVal valorBool As Boolean)
        TextNombCPasivo.Clear()
        If valorBool = True Then
            TextCPasivo.Clear()
        End If
    End Sub

    Private Sub BtnUbicacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPasivo.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("nombre") = TextNombCPasivo.Text.Trim
        lpara("empresa") = empresa
        cadena = "select cuenta,nombre from nomencla where empresa=@empresa and nombre like '%' + @nombre + '%' and operable='S' and naturaleza in (2,3) order by nombre"
        numFilas = llenaTabla(cadena, tbUbicacion, ListaParametros(lpara))

        If numFilas = 0 Then
            MsgBox("NO EXISTEN CUENTAS DE PASIVO CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            borraCPasivo(True)
            TextCPasivo.Focus()
        ElseIf numFilas = 1 Then
            filaTemp = tbUbicacion.Rows.Item(0)
            TextCPasivo.Text() = filaTemp.Item(0)
            TextNombCPasivo.Text = filaTemp.Item(1)
            TextPorcentaje.Focus()
        Else
            EnBuscaCPasivo()
        End If
    End Sub

    Private Sub EnBuscaCPasivo()
        fCtaP = New frmMuestraSoloCuentas
        fCtaP.TopMost = True
        fCtaP.inicializa(tbUbicacion)
        AddHandler fCtaP.actValor, AddressOf ActualizacionDatosCPasivo
        fCtaP.ShowDialog()
        'fUbi = New frmMuestraUbica
        'fUbi.TopMost = True
        'AddHandler fUbi.actValor, AddressOf ActualizacionDatosUbica
        'fUbi.inicializa(tbUbicacion)
        'fUbi.StartPosition = FormStartPosition.CenterScreen
        'fUbi.ShowDialog()
        CmbTipo.Focus()
    End Sub

    Private Sub ActualizacionDatosCPasivo(ByVal sender As Object, ByVal e As clsActValorREvento)
        filaTemp = tbUbicacion.Rows.Item(e.va2)
        borraCPasivo(True)
        TextCPasivo.Text() = filaTemp.Item(0)
        TextNombCPasivo.Text = filaTemp.Item(1)
    End Sub

    Private Sub ValidaCPasivo()
        lpara.Clear()
        lpara("cuenta") = TextCPasivo.Text.Trim
        cadena = "select count (*) from nomencla where cuenta=@cuenta"
        If BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
            MsgBox("NUMERO DE CUENTA NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            borraCPasivo(True)
            TextCPasivo.Focus()
            Exit Sub
        End If
        cadena = "select cuenta,nombre from nomencla where cuenta=@cuenta and operable='S' and naturaleza in (2,3)"
        abrir_conexion(cn)
        comando = New SqlCommand(cadena, cn)
        comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
        dr = comando.ExecuteReader
        If dr.HasRows() Then
            dr.Read()
            TextNombCPasivo.Text = dr.GetValue(1)
            dr.Close()
            cn.Close()
            CmbTipo.Focus()
        Else
            MsgBox("NO ES UNA CUENTA DE PASIVO, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            borraCPasivo(True)
            TextCPasivo.Focus()
            dr.Close()
            cn.Close()
        End If
    End Sub


    Private Sub TextUbicacion_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextCPasivo.Validated
        If TextCPasivo.Text.Trim <> "" Then
            ValidaCPasivo()
        Else
            borraCPasivo(True)
        End If
    End Sub

#End Region

    Private Sub FrmIngresoProvisiones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        cadena = "select nombre from empresas where empresa=@empresa"
        'ingreso de la empresa
        TextNombEmpresa.Text = BuscaEscalar(cadena, ListaParametros(lpara))
        'limpia una tabla
        tbDatos.Columns.Clear()
        tbDatos.Clear()
        AgregarColumna(tbDatos, "Transaccion", "System.Int32", 0)
        AgregarColumna(tbDatos, "Nombre", "System.String", "")
        dgDatos.DataSource = tbDatos
        estilo()
        'AltoGrid(17, tbDatos, 160, 492, False, dgDatos)
        cm = CType(BindingContext(tbDatos), CurrencyManager)
        dv = CType(cm.List, DataView)
        dv.AllowNew = False
        gpDetalle.Enabled = False
        GpDetalle1.Enabled = False
        btnLimpiar_Click(sender, e)
        Me.KeyPreview = True
    End Sub

#Region "TIPO"
    '---------------------------------
    ' Borra los campos de la forma
    '---------------------------------
    Private Sub BorraTipo(ByVal valbool As Boolean)
        TextNombTransac.Clear()
        If valbool = True Then
            btnIngreso.Enabled = Not valbool
            TextTransac.Clear()
        End If
    End Sub

    '------------------------------------------------
    ' Realizaciòn de la busqueda del tipo de tarjeta
    '------------------------------------------------

    Private Sub btnTipo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransac.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = TextNombTransac.Text.Trim
        cadena = "select transac, nombre from tipotran where empresa=@empresa and nombre like '%' + @nombre + '%'  and tipomov = 'I' order by transac"
        numFilas = llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN TRANSACCIONES CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraTipo(True)
            TextTransac.Focus()
        ElseIf numFilas = 1 Then
            '----------------------------------------------
            ' Si haya uno directamente entonces lo muestra
            '----------------------------------------------
            BorraTipo(True)
            filaTemp = tbTipo.Rows.Item(0)
            TextTransac.Text() = filaTemp.Item(0)
            TextNombTransac.Text = filaTemp.Item(1)
            btnIngreso.Enabled = True
            btnIngreso.Focus()
        Else
            '-------------------------------------
            ' Si hay muchos lo muestra en tabla
            '-------------------------------------
            EnBuscaTipo()
        End If
    End Sub

    '------------------------------------
    ' Verifica si existe el Tipo Elegido
    '------------------------------------
    Private Sub ValidaTipo()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("transac") = TextTransac.Text.Trim
        cadena = "select count (*) from tipotran where empresa=@empresa and transac=@transac"
        If BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
            MsgBox("TRANSACCION NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraTipo(True)
            TextTransac.Focus()
            Exit Sub
        End If
        cadena = "select transac, nombre from tipotran where empresa=@empresa and tipomov = 'I' and transac=@transac"
        abrir_conexion(cn)
        comando = New SqlCommand(cadena, cn)
        comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
        dr = comando.ExecuteReader
        '-----------
        ' si Existe
        '-----------
        If dr.HasRows() Then
            BorraTipo(False)
            dr.Read()
            TextNombTransac.Text = dr.GetValue(0)
            dr.Close()
            cn.Close()
            btnIngreso.Enabled = True
            btnIngreso.Focus()
        Else
            MsgBox("TRANSACCION NO VALIDA", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            dr.Close()
            cn.Close()
            BorraTipo(True)
            TextTransac.Focus()
        End If
    End Sub

    '----------------------------------------
    ' Verifica si existe algo dentro del Text
    '----------------------------------------
    Private Sub TextTipo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextTransac.Validated
        If TextTransac.Text.Trim <> "" Then
            ValidaTipo()
        Else
            BorraTipo(False)
        End If
    End Sub

    '-----------------------------------------------
    ' Llama un Form para ingresar datos de un table
    '-----------------------------------------------

    Private Sub EnBuscaTipo()
        fTran = New frmMuestraCodigos
        fTran.TopMost = True
        fTran.inicializa(tbTipo)
        AddHandler fTran.actValor, AddressOf ActualizacionDatosTipo
        fTran.StartPosition = FormStartPosition.CenterScreen
        fTran.ShowDialog()
        btnIngreso.Enabled = True
        btnIngreso.Focus()
    End Sub

    Private Sub ActualizacionDatosTipo(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraTipo(True)
        filaTemp = tbTipo.Rows.Item(e.va2)
        TextTransac.Text() = filaTemp.Item(0)
        TextNombTransac.Text = filaTemp.Item(1)
    End Sub

    Private Sub TextTipo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextTransac.KeyPress
        soloNumero(sender, e)
    End Sub
#End Region

#Region "Principal"

    '------------------------------------------
    ' Boton para Ingreso de Articulos a Tarjeta
    '------------------------------------------

    Private Sub btnIngreso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngreso.Click
        If Not validetError(TextTransac, ep1) Or Not validetError(TextNombTransac, ep1) Then
            Exit Sub
        End If

        Dim fila, filatemp As DataRow
        For i = 0 To tbDatos.Rows.Count - 1
            filatemp = tbDatos.Rows(i)
            If CInt(TextTransac.Text) = filatemp.Item(0) Then
                MsgBox("TRANSACCION YA EXISTE, VERIFIQUE", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                BorraTipo(True)
                TextTransac.Focus()
                Exit Sub
            End If
        Next i
        fila = tbDatos.NewRow()
        fila.Item(0) = TextTransac.Text.Trim
        fila.Item(1) = TextNombTransac.Text.Trim
        tbDatos.Rows.Add(fila)
        'AltoGrid(17, tbDatos, 160, 492, False, dgDatos)
        dgDatos.Refresh()
        BorraTipo(True)
        TextTransac.Focus()
    End Sub

    '------------------------------------
    ' Boton Guardar que ingresa en la BD
    '------------------------------------

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        lpara.Clear()
        If tbDatos.Rows.Count = 0 Then
            MsgBox("NO HAY TRANSACCIONES ASOCIADAS AL PASIVO LABORAL, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        lpara("empresa") = empresa

        Dim modelo As New cmodelo
        Try
            If MsgBox("DESEA ALMACENAR ESTOS REGISTROS", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                Dim numero, i As Int16
                Dim tipot As String = ""

                cadena = "select coalesce(max(pasivo),0) from pasivolab1 where empresa =@empresa "
                numero = modelo.BuscaEscalar(cadena, ListaParametros(lpara)) + 1
                If CmbTipo.SelectedIndex = 0 Then
                    tipot = "SP"
                ElseIf CmbTipo.SelectedIndex = 1 Then
                    tipot = "A"
                ElseIf CmbTipo.SelectedIndex = 2 Then
                    tipot = "B"
                ElseIf CmbTipo.SelectedIndex = 3 Then
                    tipot = "V"
                ElseIf CmbTipo.SelectedIndex = 4 Then
                    tipot = "I"
                End If
                lpara("numero") = numero
                lpara("nombre") = TextNombPasivo.Text.Trim
                lpara("tipo") = tipot
                lpara("ctagasto") = TextCGasto.Text.Trim
                lpara("ctapasivo") = TextCPasivo.Text.Trim
                lpara("por") = CDec(TextPorcentaje.Text.Trim)
                cadena = "insert into pasivolab1(empresa,pasivo,nombre,tipo,ctagasto,ctapasivo,por)" &
                         " values(@empresa,@numero,@nombre,@tipo,@ctagasto,@ctapasivo,@por)"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                For i = 0 To tbDatos.Rows.Count - 1
                    lpara.Clear()
                    filaTemp = tbDatos.Rows.Item(i)
                    lpara("empresa") = empresa
                    lpara("pasivo") = numero
                    lpara("transac") = filaTemp.Item("TRANSACCION")
                    cadena = "insert pasivolab2(empresa,pasivo,transac)" &
                             " values(@empresa,@pasivo,@transac)"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                Next i

            End If
            If modelo.Commit() Then
                MessageBox.Show("Operación realizada con exito", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
                btnLimpiar_Click(sender, e)
                InsertBitacora(9, 1, Me.Text)
            End If
        Catch ex As Exception
            modelo.RollBack()
            MessageBox.Show("Error:", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    '----------------------------------------
    ' Boton de Ingreso para Tipo de Tarjeta
    '----------------------------------------

    Private Sub btnIngresar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngresar.Click
        If Not validetError(TextCGasto, ep1) Or Not validetError(TextNombPasivo, ep1) Or Not _
        validetError(TextCPasivo, ep1) Or Not validetError(CmbTipo, ep1) Or Not validetError(TextPorcentaje, ep1) Then
            Exit Sub
        End If
        GpDetalle1.Enabled = True
        GpPasivoL.Enabled = False
        gpDetalle.Enabled = True
    End Sub

    Private Sub ObtieneFoco_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCGasto.Enter, TextNombCGasto.Enter, TextTransac.Enter, TextNombTransac.Enter, TextCPasivo.Enter, TextNombCPasivo.Enter, TextPorcentaje.Enter, CmbTipo.Enter
        'controla la obtención del foco de los controles indicados
        'activa2(sender)
    End Sub

    Private Sub DejaFoco_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextCGasto.Leave, TextNombCGasto.Leave, TextTransac.Leave, TextNombTransac.Leave, TextCPasivo.Leave, TextNombCPasivo.Leave, TextPorcentaje.Leave, CmbTipo.Leave
        'controla la perdida del foco de los controles indicados
        'desactiva2(sender)
    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    '--------------------------------------------------
    ' Boton que da al enter la funcionalidad del TAB
    '--------------------------------------------------

    Private Sub FrmIngresoProvisiones_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    '-----------------------------
    ' Evento que finaliza el form 
    '-----------------------------
    Private Sub frmActual_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub
#End Region


    '--------------------------------------------------
    ' Funcion que sirve para Dar formato de solo decimal
    '--------------------------------------------------

    Private Sub textCantidad_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextPorcentaje.KeyPress
        soloNumeroDec(sender, e)
    End Sub

    Private Sub TextPorcentaje_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextPorcentaje.Validated
        If TextPorcentaje.Text <> "" Then
            If CDec(TextPorcentaje.Text) > 0 And CDec(TextPorcentaje.Text) <= 100 Then
                If Not valida_decimal_Presicion(TextPorcentaje, 3, 4) Then
                    TextPorcentaje.Clear()
                    TextPorcentaje.Focus()
                End If
                btnIngresar.Focus()
            Else
                MsgBox("EL PORCENTAJE DEBE SER MAYOR A 0 Y MENOR O IGUAL A 100, VERIFIQUE", MsgBoxStyle.Information, "Mensaje de Sistema")
                TextPorcentaje.Clear()
                TextPorcentaje.Focus()
            End If
        End If
    End Sub

    Private Sub CmbTipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmbTipo.SelectedIndexChanged
        If CmbTipo.Text <> "" Then
            TextPorcentaje.Focus()
        End If
    End Sub

    Private Sub DgDatos_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgDatos.CellEnter
        If dgDatos.SelectedRows.Count > 0 Then
            dgDatos.Rows(dgDatos.SelectedRows(0).Index).Selected = True
        End If
    End Sub

End Class
