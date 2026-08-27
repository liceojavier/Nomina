Imports System.Data.SqlClient
Imports System.Linq
Imports System.Collections.Generic

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMESTRUCTURANOMINA.VB MIEMBRO DE NOMINA.SLN                                **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmEstructuraNomina
    Inherits Form
    Dim comando As SqlCommand
    Dim dr As SqlDataReader

    Dim cadena As String
    Dim tbColumna As New DataTable("columna")
    Dim tbTipo As New DataTable("tipo")
    Dim tbCodigo As New DataTable("codigo")
    Dim tbData As New DataTable("data")
    Dim WithEvents fEmp As frmMuestraCodigos
    Dim filaTemp As DataRow

    Dim tipoNom As String
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
    Friend WithEvents ctxMenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxEli1 As System.Windows.Forms.ToolStripMenuItem
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
    Friend WithEvents tabDatos As System.Windows.Forms.TabControl
    Friend WithEvents TbGeneral As System.Windows.Forms.TabPage
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents tbTransac1 As System.Windows.Forms.TabPage
    Friend WithEvents dgCodigos As System.Windows.Forms.DataGridView
    Friend WithEvents btnGuardaEstr As System.Windows.Forms.Button
    Friend WithEvents pnColumnas As System.Windows.Forms.Panel
    Friend WithEvents gpColumna As System.Windows.Forms.GroupBox
    Friend WithEvents textNombCodigo As System.Windows.Forms.TextBox
    Friend WithEvents btnIngCol As System.Windows.Forms.Button
    Friend WithEvents btnCancelCol As System.Windows.Forms.Button
    Friend WithEvents TextNoColumna As System.Windows.Forms.TextBox
    Friend WithEvents dgColumna As System.Windows.Forms.DataGridView
    Friend WithEvents gpTransaccion As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscaCodigo As System.Windows.Forms.Button
    Friend WithEvents TextNombColumna As System.Windows.Forms.TextBox
    Friend WithEvents textCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnGuardaP As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbAbsoluto As System.Windows.Forms.ComboBox
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents TextTipoM As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmEstructuraNomina))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ctxMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxEli1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnGuardaEstr = New System.Windows.Forms.Button()
        Me.btnBuscaCodigo = New System.Windows.Forms.Button()
        Me.btnGuardaP = New System.Windows.Forms.Button()
        Me.btnIngCol = New System.Windows.Forms.Button()
        Me.btnCancelCol = New System.Windows.Forms.Button()
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
        Me.tbTransac1 = New System.Windows.Forms.TabPage()
        Me.dgCodigos = New System.Windows.Forms.DataGridView()
        Me.TbGeneral = New System.Windows.Forms.TabPage()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gpTransaccion = New System.Windows.Forms.GroupBox()
        Me.textNombCodigo = New System.Windows.Forms.TextBox()
        Me.textCodigo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.pnColumnas = New System.Windows.Forms.Panel()
        Me.gpColumna = New System.Windows.Forms.GroupBox()
        Me.TextTipoM = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbAbsoluto = New System.Windows.Forms.ComboBox()
        Me.TextNoColumna = New System.Windows.Forms.TextBox()
        Me.TextNombColumna = New System.Windows.Forms.TextBox()
        Me.dgColumna = New System.Windows.Forms.DataGridView()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.tabDatos = New System.Windows.Forms.TabControl()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ctxMenu1.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpEmpresa.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.tbTransac1.SuspendLayout()
        CType(Me.dgCodigos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbGeneral.SuspendLayout()
        Me.gpTransaccion.SuspendLayout()
        Me.pnColumnas.SuspendLayout()
        Me.gpColumna.SuspendLayout()
        CType(Me.dgColumna, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabDatos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ctxMenu1
        '
        Me.ctxMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxEli1})
        Me.ctxMenu1.Name = "ctxMenu"
        Me.ctxMenu1.Size = New System.Drawing.Size(173, 26)
        '
        'ctxEli1
        '
        Me.ctxEli1.Image = Global.NOMINA.My.Resources.Resources.menos
        Me.ctxEli1.Name = "ctxEli1"
        Me.ctxEli1.Size = New System.Drawing.Size(172, 22)
        Me.ctxEli1.Text = " Eliminar Columna"
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
        Me.btnLimpiar.Location = New System.Drawing.Point(1017, 0)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 52
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
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
        'btnGuardaEstr
        '
        Me.btnGuardaEstr.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardaEstr.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardaEstr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardaEstr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardaEstr.ImageKey = "guardar.png"
        Me.btnGuardaEstr.ImageList = Me.ImageNuevos
        Me.btnGuardaEstr.Location = New System.Drawing.Point(939, 454)
        Me.btnGuardaEstr.Name = "btnGuardaEstr"
        Me.btnGuardaEstr.Size = New System.Drawing.Size(152, 30)
        Me.btnGuardaEstr.TabIndex = 116
        Me.btnGuardaEstr.Text = "Guardar aplicación de columnas"
        Me.btnGuardaEstr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardaEstr, "Guardar registro")
        Me.btnGuardaEstr.UseVisualStyleBackColor = False
        '
        'btnBuscaCodigo
        '
        Me.btnBuscaCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscaCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscaCodigo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscaCodigo.ImageKey = "buscar1.png"
        Me.btnBuscaCodigo.ImageList = Me.ImageNuevos
        Me.btnBuscaCodigo.Location = New System.Drawing.Point(442, 8)
        Me.btnBuscaCodigo.Name = "btnBuscaCodigo"
        Me.btnBuscaCodigo.Size = New System.Drawing.Size(80, 30)
        Me.btnBuscaCodigo.TabIndex = 3
        Me.btnBuscaCodigo.Text = "Buscar"
        Me.btnBuscaCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscaCodigo, "Buscar Transaccion")
        Me.btnBuscaCodigo.UseVisualStyleBackColor = False
        '
        'btnGuardaP
        '
        Me.btnGuardaP.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardaP.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardaP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardaP.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardaP.ImageKey = "guardar.png"
        Me.btnGuardaP.ImageList = Me.ImageNuevos
        Me.btnGuardaP.Location = New System.Drawing.Point(1001, 442)
        Me.btnGuardaP.Name = "btnGuardaP"
        Me.btnGuardaP.Size = New System.Drawing.Size(80, 30)
        Me.btnGuardaP.TabIndex = 4
        Me.btnGuardaP.Text = "Guardar"
        Me.btnGuardaP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardaP, "Guardar registro")
        Me.btnGuardaP.UseVisualStyleBackColor = False
        '
        'btnIngCol
        '
        Me.btnIngCol.BackColor = System.Drawing.SystemColors.Control
        Me.btnIngCol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngCol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnIngCol.ImageKey = "checkok.png"
        Me.btnIngCol.ImageList = Me.ImageNuevos
        Me.btnIngCol.Location = New System.Drawing.Point(806, 14)
        Me.btnIngCol.Name = "btnIngCol"
        Me.btnIngCol.Size = New System.Drawing.Size(80, 30)
        Me.btnIngCol.TabIndex = 5
        Me.btnIngCol.Text = "Agregar"
        Me.btnIngCol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnIngCol, "Ingresar")
        Me.btnIngCol.UseVisualStyleBackColor = False
        '
        'btnCancelCol
        '
        Me.btnCancelCol.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelCol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelCol.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelCol.ImageKey = "cancelar.png"
        Me.btnCancelCol.ImageList = Me.ImageNuevos
        Me.btnCancelCol.Location = New System.Drawing.Point(903, 14)
        Me.btnCancelCol.Name = "btnCancelCol"
        Me.btnCancelCol.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelCol.TabIndex = 6
        Me.btnCancelCol.Text = "Cancelar"
        Me.btnCancelCol.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelCol, "Cancelar")
        Me.btnCancelCol.UseVisualStyleBackColor = False
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(370, 3)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(437, 41)
        Me.gpEmpresa.TabIndex = 0
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(6, 15)
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
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.LightBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ContextMenuStrip = Me.ctxMenu1
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle8
        Me.DataGridView1.Location = New System.Drawing.Point(111, 121)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(650, 194)
        Me.DataGridView1.TabIndex = 115
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
        Me.Button5.Image = Global.NOMINA.My.Resources.Resources.ok2
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
        'tbTransac1
        '
        Me.tbTransac1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.tbTransac1.Controls.Add(Me.btnGuardaEstr)
        Me.tbTransac1.Controls.Add(Me.dgCodigos)
        Me.tbTransac1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTransac1.Location = New System.Drawing.Point(4, 22)
        Me.tbTransac1.Name = "tbTransac1"
        Me.tbTransac1.Size = New System.Drawing.Size(1099, 491)
        Me.tbTransac1.TabIndex = 6
        Me.tbTransac1.Text = "Transacciones con que se calcula la nómina"
        '
        'dgCodigos
        '
        Me.dgCodigos.AllowUserToAddRows = False
        Me.dgCodigos.AllowUserToDeleteRows = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGreen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgCodigos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgCodigos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCodigos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCodigos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgCodigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCodigos.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgCodigos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgCodigos.Location = New System.Drawing.Point(8, 8)
        Me.dgCodigos.MultiSelect = False
        Me.dgCodigos.Name = "dgCodigos"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCodigos.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgCodigos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCodigos.Size = New System.Drawing.Size(1083, 440)
        Me.dgCodigos.TabIndex = 115
        '
        'TbGeneral
        '
        Me.TbGeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TbGeneral.Controls.Add(Me.btnGuardaP)
        Me.TbGeneral.Controls.Add(Me.Label2)
        Me.TbGeneral.Controls.Add(Me.gpTransaccion)
        Me.TbGeneral.Controls.Add(Me.pnColumnas)
        Me.TbGeneral.Controls.Add(Me.dgColumna)
        Me.TbGeneral.Controls.Add(Me.cmbTipo)
        Me.TbGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbGeneral.Location = New System.Drawing.Point(4, 22)
        Me.TbGeneral.Name = "TbGeneral"
        Me.TbGeneral.Size = New System.Drawing.Size(1099, 479)
        Me.TbGeneral.TabIndex = 3
        Me.TbGeneral.Text = "Datos generales"
        Me.TbGeneral.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(20, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Tipo de nómina:"
        '
        'gpTransaccion
        '
        Me.gpTransaccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpTransaccion.Controls.Add(Me.textNombCodigo)
        Me.gpTransaccion.Controls.Add(Me.btnBuscaCodigo)
        Me.gpTransaccion.Controls.Add(Me.textCodigo)
        Me.gpTransaccion.Controls.Add(Me.Label13)
        Me.gpTransaccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTransaccion.Location = New System.Drawing.Point(17, 35)
        Me.gpTransaccion.Name = "gpTransaccion"
        Me.gpTransaccion.Size = New System.Drawing.Size(570, 42)
        Me.gpTransaccion.TabIndex = 2
        Me.gpTransaccion.TabStop = False
        Me.gpTransaccion.Text = "Transacción que muestra cantidad de días"
        '
        'textNombCodigo
        '
        Me.textNombCodigo.BackColor = System.Drawing.Color.White
        Me.textNombCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombCodigo.Location = New System.Drawing.Point(120, 17)
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
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(62, 20)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Nombre:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pnColumnas
        '
        Me.pnColumnas.Controls.Add(Me.gpColumna)
        Me.pnColumnas.Controls.Add(Me.btnIngCol)
        Me.pnColumnas.Controls.Add(Me.btnCancelCol)
        Me.pnColumnas.Location = New System.Drawing.Point(9, 94)
        Me.pnColumnas.Name = "pnColumnas"
        Me.pnColumnas.Size = New System.Drawing.Size(1008, 56)
        Me.pnColumnas.TabIndex = 2
        '
        'gpColumna
        '
        Me.gpColumna.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpColumna.Controls.Add(Me.TextTipoM)
        Me.gpColumna.Controls.Add(Me.Label1)
        Me.gpColumna.Controls.Add(Me.Label6)
        Me.gpColumna.Controls.Add(Me.cmbAbsoluto)
        Me.gpColumna.Controls.Add(Me.TextNoColumna)
        Me.gpColumna.Controls.Add(Me.TextNombColumna)
        Me.gpColumna.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpColumna.Location = New System.Drawing.Point(8, 8)
        Me.gpColumna.Name = "gpColumna"
        Me.gpColumna.Size = New System.Drawing.Size(792, 41)
        Me.gpColumna.TabIndex = 1
        Me.gpColumna.TabStop = False
        Me.gpColumna.Text = "Columnas"
        '
        'TextTipoM
        '
        Me.TextTipoM.BackColor = System.Drawing.Color.White
        Me.TextTipoM.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextTipoM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipoM.Location = New System.Drawing.Point(522, 12)
        Me.TextTipoM.MaxLength = 5
        Me.TextTipoM.Name = "TextTipoM"
        Me.TextTipoM.Size = New System.Drawing.Size(48, 20)
        Me.TextTipoM.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(414, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 13)
        Me.Label1.TabIndex = 50
        Me.Label1.Text = "Tipo de movimiento:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(614, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 13)
        Me.Label6.TabIndex = 49
        Me.Label6.Text = "Valor absoluto:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAbsoluto
        '
        Me.cmbAbsoluto.BackColor = System.Drawing.Color.White
        Me.cmbAbsoluto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAbsoluto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAbsoluto.Items.AddRange(New Object() {"S", "N", ""})
        Me.cmbAbsoluto.Location = New System.Drawing.Point(697, 11)
        Me.cmbAbsoluto.Name = "cmbAbsoluto"
        Me.cmbAbsoluto.Size = New System.Drawing.Size(62, 21)
        Me.cmbAbsoluto.TabIndex = 4
        '
        'TextNoColumna
        '
        Me.TextNoColumna.BackColor = System.Drawing.Color.White
        Me.TextNoColumna.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNoColumna.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNoColumna.Location = New System.Drawing.Point(11, 16)
        Me.TextNoColumna.MaxLength = 25
        Me.TextNoColumna.Name = "TextNoColumna"
        Me.TextNoColumna.Size = New System.Drawing.Size(49, 20)
        Me.TextNoColumna.TabIndex = 1
        '
        'TextNombColumna
        '
        Me.TextNombColumna.BackColor = System.Drawing.Color.White
        Me.TextNombColumna.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombColumna.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombColumna.Location = New System.Drawing.Point(73, 16)
        Me.TextNombColumna.MaxLength = 25
        Me.TextNombColumna.Name = "TextNombColumna"
        Me.TextNombColumna.Size = New System.Drawing.Size(316, 20)
        Me.TextNombColumna.TabIndex = 2
        '
        'dgColumna
        '
        Me.dgColumna.AllowUserToAddRows = False
        Me.dgColumna.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgColumna.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgColumna.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgColumna.BackgroundColor = System.Drawing.Color.White
        Me.dgColumna.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgColumna.ContextMenuStrip = Me.ctxMenu1
        Me.dgColumna.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgColumna.Location = New System.Drawing.Point(17, 156)
        Me.dgColumna.MultiSelect = False
        Me.dgColumna.Name = "dgColumna"
        Me.dgColumna.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgColumna.Size = New System.Drawing.Size(1066, 280)
        Me.dgColumna.TabIndex = 119
        '
        'cmbTipo
        '
        Me.cmbTipo.BackColor = System.Drawing.Color.White
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Items.AddRange(New Object() {"ANTICIPO QUINCENAL", "QUINCENAL", "MENSUAL", "BONO 14", "VACACIONES/ AGUINALDO", ""})
        Me.cmbTipo.Location = New System.Drawing.Point(109, 9)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(260, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'tabDatos
        '
        Me.tabDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabDatos.Controls.Add(Me.TbGeneral)
        Me.tabDatos.Controls.Add(Me.tbTransac1)
        Me.tabDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDatos.Location = New System.Drawing.Point(12, 61)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectedIndex = 0
        Me.tabDatos.Size = New System.Drawing.Size(1107, 505)
        Me.tabDatos.TabIndex = 3
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 50)
        Me.Panel1.TabIndex = 56
        '
        'frmEstructuraNomina
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnLimpiar
        Me.ClientSize = New System.Drawing.Size(1130, 578)
        Me.Controls.Add(Me.gpEmpresa)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tabDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmEstructuraNomina"
        Me.Text = "Mantenimiento Formato Impresión de Nómina"
        Me.ctxMenu1.ResumeLayout(False)
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.tbTransac1.ResumeLayout(False)
        CType(Me.dgCodigos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbGeneral.ResumeLayout(False)
        Me.TbGeneral.PerformLayout()
        Me.gpTransaccion.ResumeLayout(False)
        Me.gpTransaccion.PerformLayout()
        Me.pnColumnas.ResumeLayout(False)
        Me.gpColumna.ResumeLayout(False)
        Me.gpColumna.PerformLayout()
        CType(Me.dgColumna, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabDatos.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub frmDatosFamilia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        TextNombEmpresa.Text = BuscaEscalar("select nombre from Empresas where empresa=@empresa", ListaParametros(lpara))
        cadena = "SELECT nombre, tiponom FROM TIPONOMINA1 where empresa=@empresa ORDER BY NOMBRE"
        llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        llena_combo(cadena, cmbTipo, ListaParametros(lpara))
        cmbTipo.Items.Add("")
        cmbTipo.SelectedIndex = cmbTipo.Items.Count - 1
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        lpara.Clear()
        Dim tbTemp As New DataTable
        lpara("empresa") = empresa
        If cmbTipo.Text.Trim = "" Then
            btnGuardaP.Enabled = False
            cmbTipo.Enabled = True
            dgColumna.DataSource = Nothing
            dgCodigos.DataSource = Nothing
            BorraCodigo(True)
            gpTransaccion.Enabled = False
            pnColumnas.Enabled = False
            borra_Mejorado(gpColumna, ep1)
            tabDatos.SelectedIndex = 0

            ContextoMenuEnab(False, False, ctxMenu1)
        Else
            btnGuardaP.Enabled = True
            gpTransaccion.Enabled = True
            tipoNom = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
            lpara("tiponom") = tipoNom
            cadena = "select e.transac, t.nombre from estructuranom e inner join tipotran t on e.empresa=e.empresa and e.transac=t.transac " &
                     "where e.empresa=@empresa And tipoNom =@tiponom"
            pnColumnas.Enabled = True
            ContextoMenuEnab(True, True, ctxMenu1)
            llenaTabla(cadena, tbTemp, ListaParametros(lpara))
            If tbTemp.Rows.Count > 0 Then

                textCodigo.Text = tbTemp.Rows(0).Item("transac")
                textNombCodigo.Text = tbTemp.Rows(0).Item("nombre")

                inicializa_col()

            Else

                pnColumnas.Enabled = False
                ContextoMenuEnab(False, True, ctxMenu1)
            End If
        End If
    End Sub

    Private Sub btnGuardaP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardaP.Click
        lpara.Clear()
        Dim si As Int16
        lpara("empresa") = empresa
        lpara("tiponom") = tipoNom
        lpara("transac") = textCodigo.Text
        If validetError(cmbTipo, ep1) And validetError(textCodigo, ep1) Then
            Dim modelo As New cmodelo()

            cadena = "select count(*) from estructuranom where empresa=@empresa and tiponom=@tiponom"
            If modelo.BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                si = 1
                cadena = "update estructuranom set transac=@transac where empresa=@empresa and tiponom=@tiponom"
            Else
                si = 2
                cadena = "insert into estructuranom (empresa, tiponom, transac) values (@empresa,@tiponom,@transac)"
            End If
            modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
            For Each dc As DataRow In tbColumna.Rows
                lpara.Clear()
                lpara("orden") = dc.Item("orden")
                lpara("empresa") = empresa
                lpara("tiponom") = dc.Item("tiponom")
                lpara("columna") = dc.Item("columna")
                lpara("nombre") = dc.Item("nombre")
                cadena = "update estructuranom1 set orden=@orden, nombre=@nombre where empresa=@empresa and tiponom=@tiponom and columna=@columna"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
            Next
            If modelo.Commit() Then

                InsertBitacora(9, 1, "Actualización de transacción de estructuranom " & cmbTipo.Text & " y cambio de orden ")

                si = 0
                MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextNoColumna.Focus()
            End If




        End If
    End Sub

#Region "TRANSACCION"


    Private Sub BorraCodigo(ByVal valbool As Boolean)
        textNombCodigo.Clear()
        If valbool = True Then
            textCodigo.Clear()
        End If
    End Sub


    Private Sub btnCodigo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscaCodigo.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = textNombCodigo.Text.Trim
        cadena = "select transac, nombre, tipomov from tipotran where empresa=@empresa and nombre like '%' + @nombre + '%' order by transac"
        numFilas = llenaTabla(cadena, tbCodigo, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN TRANSACCIONES CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCodigo(True)
            textCodigo.Focus()
        ElseIf numFilas = 1 Then
            BorraCodigo(True)
            filaTemp = tbCodigo.Rows.Item(0)
            textCodigo.Text() = filaTemp.Item(0)
            textNombCodigo.Text = filaTemp.Item(1)
            btnGuardaP.Focus()
        Else
            EnBuscaCodigo()
        End If
    End Sub

    Private Sub ValidaCodigo()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("transac") = textCodigo.Text.Trim
        If valida_tipo_Entero(textCodigo.Text, 1) = True Then
            If BuscaEscalar("select count (*) from tipotran where empresa=@empresa and transac=@transac", ListaParametros(lpara)) = 0 Then
                MsgBox("TRANSACCION NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraCodigo(True)
                textCodigo.Focus()
                Exit Sub
            End If
            cadena = "select transac, nombre from tipotran where empresa=@empresa and transac=@transac"
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraCodigo(False)
                dr.Read()
                textNombCodigo.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
                btnIngCol.Focus()
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
        fEmp = New frmMuestraCodigos
        fEmp.TopMost = True
        fEmp.inicializa(tbCodigo)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosMonitor
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        btnGuardaP.Focus()
    End Sub

    Private Sub ActualizacionDatosMonitor(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraCodigo(True)
        filaTemp = tbCodigo.Rows.Item(e.va2)
        textCodigo.Text() = filaTemp.Item(0)
        textNombCodigo.Text = filaTemp.Item(1)
    End Sub




#End Region

#Region "LIMPIAR Y  FORMATOS"


    Private Sub Vista1(ByVal dgVista As DataGridView, ByVal Tabla As DataTable)
        With dgVista
            .Columns(0).HeaderText = "Columna"
            .Columns(0).Width = 100
            .Columns(0).ReadOnly = False
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).Width = 415
            .Columns(1).ReadOnly = False
            .Columns("orden").HeaderText = "Orden"
            .Columns("orden").Width = 100
            .Columns("tiponom").Visible = False
            'AltoGridView(18, Tabla, 178, 563, dgVista)
        End With
    End Sub

    Private Sub Vista2(ByVal dgVista As DataGridView, ByVal Tabla As DataTable)
        Dim i As Integer
        If dgVista IsNot Nothing Then
            With dgVista
                .Columns(0).Visible = False
                .Columns(1).HeaderText = "Transacción"
                .Columns(1).Width = 200
                .Columns(2).HeaderText = "Tipo de movimiento"
                .Columns(2).Width = 100
                For i = 0 To tbColumna.Rows.Count - 1
                    filaTemp = tbColumna.Rows(i)
                    .Columns(i + 3).HeaderText = filaTemp.Item(1)
                    .Columns(i + 3).Width = 100
                Next i
            End With
        End If

    End Sub



    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        cmbTipo.Text = ""
    End Sub

#End Region


#Region "COLUMNA"
    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardaEstr.Click
        Dim i, j As Int32
        Dim ftemp As DataRow
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("tiponom") = tipoNom
        If MsgBox("ESTA SEGURO QUE DESEA GUARDAR ESTA ESTRUCTURA", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            cadena = "delete from estructuranom2 where empresa=@empresa and tiponom=@tiponom"
            EjecutarQuery(cadena, ListaParametros(lpara))
            For j = 0 To tbData.Rows.Count - 1
                ftemp = tbData.Rows(j)
                For i = 0 To tbColumna.Rows.Count - 1
                    lpara.Clear()
                    lpara("empresa") = empresa
                    lpara("tiponom") = tipoNom
                    filaTemp = tbColumna.Rows(i)
                    lpara("columna") = filaTemp.Item(0)
                    lpara("transac") = ftemp.Item(0)
                    If ftemp.Item(i + 3) = True Then
                        cadena = "insert into estructuranom2 (empresa,tiponom, columna,transac) " &
                                 "values (@empresa,@tiponom,@columna,@transac)"
                        EjecutarQuery(cadena, ListaParametros(lpara))
                    End If
                Next i
            Next j


            MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            btnLimpiar_Click(sender, e)
        End If
    End Sub

    Private Sub TextPor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextNoColumna.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub btnIngCol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngCol.Click
        Dim i As Integer
        lpara.Clear()
        If validetError(TextNoColumna, ep1) And validetError(TextNombColumna, ep1) And validetError(cmbAbsoluto, ep1) Then
            If tbColumna.Rows.Count > 14 Then
                MsgBox("EL NUMERO DE COLUMNA NO PUEDE SER MAYOR QUE 11", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End If
            For i = 0 To tbColumna.Rows.Count - 1
                filaTemp = tbColumna.Rows(i)
                If CInt(TextNoColumna.Text) = filaTemp.Item(0) Then
                    MsgBox("NUMERO DE COLUMNA YA EXISTE, VERIFIQUE", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    Exit Sub
                End If
            Next i
            lpara.Clear()
            lpara("empresa") = empresa
            lpara("tiponom") = tipoNom
            lpara("columna") = TextNoColumna.Text
            lpara("nombre") = TextNombColumna.Text
            lpara("absoluto") = cmbAbsoluto.Text
            lpara("tipomovi") = TextTipoM.Text
            cadena = "insert estructuranom1 (empresa, tiponom, columna, nombre,absoluto,tipomovi, orden) 
                      values(@empresa,@tiponom,@columna,@nombre,@absoluto,@tipomovi,0)"
            If EjecutarQuery(cadena, ListaParametros(lpara)) Then
                btnCancelCol_Click(sender, e)
            End If


        End If
    End Sub


    Private Sub btnCancelCol_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelCol.Click
        inicializa_col()
    End Sub

    Private Sub inicializa_col()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("tiponom") = tipoNom
        cadena = "select columna, nombre, orden, tiponom from estructuranom1 where empresa=@empresa and tiponom=@tiponom order by orden"
        llenaTabla(cadena, tbColumna, ListaParametros(lpara))
        dgColumna.DataSource = tbColumna
        Vista1(dgColumna, tbColumna)
        If tbColumna.Rows.Count > 0 Then
            TextNoColumna.Text = ((From a In tbColumna.AsEnumerable()
                                   Select a.Field(Of Int16)("columna")).Max() + 1).ToString()
        Else
            TextNoColumna.Text = 1
        End If


    End Sub

    Private Sub ctxEli1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEli1.Click
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("tiponom") = tipoNom

        If dgColumna.SelectedRows.Count > 0 Then
            If MsgBox("ESTA SEGURO QUE DESEA ELIMINAR ESTA COLUMNA (SE ELIMINARAN LAS TRANSACCIONES ASOCIADAS A ESTE) ", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                filaTemp = CType(dgColumna.SelectedRows(0).DataBoundItem, DataRowView).Row
                lpara("columna") = filaTemp.Item(0)
                cadena = "delete from estructuranom1 where empresa=@empresa and tiponom=@tiponom and columna=@columna"
                EjecutarQuery(cadena, ListaParametros(lpara))
                cadena = "delete from estructuranom2 where empresa=@empresa and tiponom=@tiponom and columna=@columna"
                EjecutarQuery(cadena, ListaParametros(lpara))
                MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                btnCancelCol_Click(sender, e)
            End If
        Else
            MsgBox("NO HAY COLUMNAS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

#End Region



#Region "ENTRA Y DEJA FOCO"
    Private Sub Foco(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.Enter
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.Leave
        desactiva(sender)
    End Sub
#End Region

    Private Sub frmDatosGen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
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


    Private Sub tabDatos_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tabDatos.SelectedIndexChanged
        lpara.Clear()
        lpara("empresa") = empresa


        If tabDatos.SelectedIndex = 1 Then
            Dim i As Integer
            lpara("tiponom") = tipoNom
            cadena = "select transac, nombre, tipomov "
            For i = 0 To tbColumna.Rows.Count - 1
                filaTemp = tbColumna.Rows(i)
                lpara($"columna{i}") = filaTemp.Item(0)

                cadena = cadena & ", (select cast( (case when count(*) > 0 then 1 else 0 end) as bit ) from estructuranom2 e2 " &
                         $"where e2.empresa=t.empresa and tiponom=@tiponom and e2.transac=t.transac and e2.columna=@columna{i} ) as val"
            Next i
            cadena = cadena & " from tipotran t where t.empresa=@empresa order by transac "
            llenaTabla(cadena, tbData, ListaParametros(lpara))
            dgCodigos.DataSource = tbData
            Vista2(dgCodigos, tbData)
        End If
    End Sub


End Class
