Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMINGCONXNOMINA.VB MIEMBRO DE NOMINA.SLN                                   **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmIngConxNomina
    Inherits Form
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim da As SqlDataAdapter

    Dim cadena As String
    Dim tbDatos As New DataTable("datos")
    Dim tbDatos2 As New DataTable("datos2")
    Dim tbCodigo As New DataTable("codigo")
    Dim tbCuenta As New DataTable("cuenta")
    Dim tbConsulta As New DataTable("consulta")


    Dim WithEvents fEmp As frmMuestraCodigos
    Dim WithEvents fCta As frmMuestraSoloCuentas
    Dim filaTemp As DataRow
    Dim indice As Integer
    Dim tipoNom As String

    Dim InicioConsulta As String = "select tiponom, nombre, tipago, cuenta, cantidad, cantidadnom, movimientos,desprestamos, por " & _
                                  " from tiponomina1 n1 where empresa=" & empresa

    Dim cadenaDetalle1 As String = "select  n2.transac, t.nombre from tiponomina2 n2  inner join " & _
                                  "tipotran t on n2.transac=t.transac and n2.empresa=t.empresa where " & _
                                  "n2.empresa=" & empresa
    Friend WithEvents TextDePrestamos As System.Windows.Forms.TextBox
    Friend WithEvents TextMovimientos As System.Windows.Forms.TextBox
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel

    Dim cadenaDetalle2 As String = "select  n3.transacnom, t.nombre from tiponomina3 n3  inner join " &
                                 "tipotran t on n3.transacnom=t.transac and n3.empresa=t.empresa where " &
                                 "n3.empresa=" & empresa
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
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbDePrestamos As System.Windows.Forms.ComboBox
    Friend WithEvents numCantNom As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents numCantidad As System.Windows.Forms.NumericUpDown
    Friend WithEvents gpCuenta As System.Windows.Forms.GroupBox
    Friend WithEvents TextConsCuenta As System.Windows.Forms.TextBox
    Friend WithEvents TextNombCuenta As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnConNome As System.Windows.Forms.Button
    Friend WithEvents TextConlNombre As System.Windows.Forms.TextBox
    Friend WithEvents textPorcentaje As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbTipago As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cmbMovimientos As System.Windows.Forms.ComboBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents tbTransac1 As System.Windows.Forms.TabPage
    Friend WithEvents pnTransac1 As System.Windows.Forms.Panel
    Friend WithEvents gpTransaccion As System.Windows.Forms.GroupBox
    Friend WithEvents btnBuscaCodigo As System.Windows.Forms.Button
    Friend WithEvents textNombCodigo As System.Windows.Forms.TextBox
    Friend WithEvents textCodigo As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnIngCod As System.Windows.Forms.Button
    Friend WithEvents btnCancelCod As System.Windows.Forms.Button
    Friend WithEvents dgCodigos As System.Windows.Forms.DataGridView
    Friend WithEvents tbTransac2 As System.Windows.Forms.TabPage
    Friend WithEvents dgCodigos2 As System.Windows.Forms.DataGridView
    Friend WithEvents pnTransac2 As System.Windows.Forms.Panel
    Friend WithEvents gpTransac2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnCod2 As System.Windows.Forms.Button
    Friend WithEvents TextNombCod2 As System.Windows.Forms.TextBox
    Friend WithEvents TextCodigo2 As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnIngCod2 As System.Windows.Forms.Button
    Friend WithEvents btnCanceCod2 As System.Windows.Forms.Button
    Friend WithEvents ctxMenu2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxPrincipal As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnSig As System.Windows.Forms.Button
    Friend WithEvents btnAtr As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents ctxEli2 As System.Windows.Forms.ToolStripMenuItem

    Friend WithEvents TextTiPago As System.Windows.Forms.TextBox
    Friend WithEvents TextTipo As System.Windows.Forms.TextBox


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngConxNomina))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.ctxMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxEli1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.btnBuscaCodigo = New System.Windows.Forms.Button()
        Me.btnConNome = New System.Windows.Forms.Button()
        Me.btnCod2 = New System.Windows.Forms.Button()
        Me.btnSig = New System.Windows.Forms.Button()
        Me.btnAtr = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnIngCod2 = New System.Windows.Forms.Button()
        Me.btnCanceCod2 = New System.Windows.Forms.Button()
        Me.btnIngCod = New System.Windows.Forms.Button()
        Me.btnCancelCod = New System.Windows.Forms.Button()
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
        Me.tbTransac2 = New System.Windows.Forms.TabPage()
        Me.pnTransac2 = New System.Windows.Forms.Panel()
        Me.gpTransac2 = New System.Windows.Forms.GroupBox()
        Me.TextNombCod2 = New System.Windows.Forms.TextBox()
        Me.TextCodigo2 = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dgCodigos2 = New System.Windows.Forms.DataGridView()
        Me.ctxMenu2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxEli2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbTransac1 = New System.Windows.Forms.TabPage()
        Me.pnTransac1 = New System.Windows.Forms.Panel()
        Me.gpTransaccion = New System.Windows.Forms.GroupBox()
        Me.textNombCodigo = New System.Windows.Forms.TextBox()
        Me.textCodigo = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.dgCodigos = New System.Windows.Forms.DataGridView()
        Me.TbGeneral = New System.Windows.Forms.TabPage()
        Me.TextMovimientos = New System.Windows.Forms.TextBox()
        Me.TextDePrestamos = New System.Windows.Forms.TextBox()
        Me.TextTiPago = New System.Windows.Forms.TextBox()
        Me.TextTipo = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbDePrestamos = New System.Windows.Forms.ComboBox()
        Me.numCantNom = New System.Windows.Forms.NumericUpDown()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numCantidad = New System.Windows.Forms.NumericUpDown()
        Me.gpCuenta = New System.Windows.Forms.GroupBox()
        Me.TextConsCuenta = New System.Windows.Forms.TextBox()
        Me.TextNombCuenta = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextConlNombre = New System.Windows.Forms.TextBox()
        Me.textPorcentaje = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbTipago = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.cmbMovimientos = New System.Windows.Forms.ComboBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.tabDatos = New System.Windows.Forms.TabControl()
        Me.ctxPrincipal = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.ctxMenu1.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.tbTransac2.SuspendLayout()
        Me.pnTransac2.SuspendLayout()
        Me.gpTransac2.SuspendLayout()
        CType(Me.dgCodigos2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu2.SuspendLayout()
        Me.tbTransac1.SuspendLayout()
        Me.pnTransac1.SuspendLayout()
        Me.gpTransaccion.SuspendLayout()
        CType(Me.dgCodigos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbGeneral.SuspendLayout()
        CType(Me.numCantNom, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numCantidad, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpCuenta.SuspendLayout()
        Me.tabDatos.SuspendLayout()
        Me.ctxPrincipal.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'ctxMenu1
        '
        Me.ctxMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxEli1})
        Me.ctxMenu1.Name = "ctxMenu"
        Me.ctxMenu1.Size = New System.Drawing.Size(186, 26)
        '
        'ctxEli1
        '
        Me.ctxEli1.Image = Global.NOMINA.My.Resources.Resources.menos
        Me.ctxEli1.Name = "ctxEli1"
        Me.ctxEli1.Size = New System.Drawing.Size(185, 22)
        Me.ctxEli1.Text = " Eliminar Transaccion"
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(924, 6)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(60, 30)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Almacenar registro")
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
        Me.btnLimpiar.Location = New System.Drawing.Point(79, 6)
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
        'btnBuscaCodigo
        '
        Me.btnBuscaCodigo.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscaCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscaCodigo.ImageKey = "buscar1.png"
        Me.btnBuscaCodigo.ImageList = Me.ImageNuevos
        Me.btnBuscaCodigo.Location = New System.Drawing.Point(460, 16)
        Me.btnBuscaCodigo.Name = "btnBuscaCodigo"
        Me.btnBuscaCodigo.Size = New System.Drawing.Size(60, 30)
        Me.btnBuscaCodigo.TabIndex = 3
        Me.btnBuscaCodigo.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscaCodigo, "Buscar Transaccion")
        Me.btnBuscaCodigo.UseVisualStyleBackColor = False
        '
        'btnConNome
        '
        Me.btnConNome.BackColor = System.Drawing.SystemColors.Control
        Me.btnConNome.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConNome.ImageKey = "buscar1.png"
        Me.btnConNome.ImageList = Me.ImageNuevos
        Me.btnConNome.Location = New System.Drawing.Point(590, 12)
        Me.btnConNome.Name = "btnConNome"
        Me.btnConNome.Size = New System.Drawing.Size(60, 30)
        Me.btnConNome.TabIndex = 5
        Me.btnConNome.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnConNome, "Ingresar cuenta contable")
        Me.btnConNome.UseVisualStyleBackColor = False
        '
        'btnCod2
        '
        Me.btnCod2.BackColor = System.Drawing.SystemColors.Control
        Me.btnCod2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCod2.ImageKey = "buscar1.png"
        Me.btnCod2.ImageList = Me.ImageNuevos
        Me.btnCod2.Location = New System.Drawing.Point(445, 15)
        Me.btnCod2.Name = "btnCod2"
        Me.btnCod2.Size = New System.Drawing.Size(60, 30)
        Me.btnCod2.TabIndex = 3
        Me.btnCod2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCod2, "Buscar Transaccion")
        Me.btnCod2.UseVisualStyleBackColor = False
        '
        'btnSig
        '
        Me.btnSig.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSig.BackColor = System.Drawing.SystemColors.Control
        Me.btnSig.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSig.ImageKey = "siguiente.png"
        Me.btnSig.ImageList = Me.ImageNuevos
        Me.btnSig.Location = New System.Drawing.Point(1057, 6)
        Me.btnSig.Name = "btnSig"
        Me.btnSig.Size = New System.Drawing.Size(60, 30)
        Me.btnSig.TabIndex = 71
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
        Me.btnAtr.Location = New System.Drawing.Point(11, 6)
        Me.btnAtr.Name = "btnAtr"
        Me.btnAtr.Size = New System.Drawing.Size(60, 30)
        Me.btnAtr.TabIndex = 70
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
        Me.btnBuscar.Location = New System.Drawing.Point(990, 6)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(60, 30)
        Me.btnBuscar.TabIndex = 69
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Buscar registro")
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'btnIngCod2
        '
        Me.btnIngCod2.BackColor = System.Drawing.SystemColors.Control
        Me.btnIngCod2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngCod2.ImageKey = "checkok.png"
        Me.btnIngCod2.ImageList = Me.ImageNuevos
        Me.btnIngCod2.Location = New System.Drawing.Point(550, 18)
        Me.btnIngCod2.Name = "btnIngCod2"
        Me.btnIngCod2.Size = New System.Drawing.Size(60, 30)
        Me.btnIngCod2.TabIndex = 1
        Me.btnIngCod2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnIngCod2, "Ingresar")
        Me.btnIngCod2.UseVisualStyleBackColor = False
        '
        'btnCanceCod2
        '
        Me.btnCanceCod2.BackColor = System.Drawing.SystemColors.Control
        Me.btnCanceCod2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCanceCod2.ImageKey = "cancelar.png"
        Me.btnCanceCod2.ImageList = Me.ImageNuevos
        Me.btnCanceCod2.Location = New System.Drawing.Point(616, 18)
        Me.btnCanceCod2.Name = "btnCanceCod2"
        Me.btnCanceCod2.Size = New System.Drawing.Size(60, 30)
        Me.btnCanceCod2.TabIndex = 2
        Me.btnCanceCod2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCanceCod2, "Cancelar")
        Me.btnCanceCod2.UseVisualStyleBackColor = False
        '
        'btnIngCod
        '
        Me.btnIngCod.BackColor = System.Drawing.SystemColors.Control
        Me.btnIngCod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnIngCod.ImageKey = "checkok.png"
        Me.btnIngCod.ImageList = Me.ImageNuevos
        Me.btnIngCod.Location = New System.Drawing.Point(550, 19)
        Me.btnIngCod.Name = "btnIngCod"
        Me.btnIngCod.Size = New System.Drawing.Size(60, 30)
        Me.btnIngCod.TabIndex = 1
        Me.btnIngCod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnIngCod, "Ingresar")
        Me.btnIngCod.UseVisualStyleBackColor = False
        '
        'btnCancelCod
        '
        Me.btnCancelCod.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelCod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelCod.ImageKey = "cancelar.png"
        Me.btnCancelCod.ImageList = Me.ImageNuevos
        Me.btnCancelCod.Location = New System.Drawing.Point(616, 18)
        Me.btnCancelCod.Name = "btnCancelCod"
        Me.btnCancelCod.Size = New System.Drawing.Size(60, 30)
        Me.btnCancelCod.TabIndex = 2
        Me.btnCancelCod.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelCod, "Cancelar")
        Me.btnCancelCod.UseVisualStyleBackColor = False
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
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(1115, 19)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Click derecho sobre el panel de información para habilitar la opción: modificació" &
    "n."
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(337, -2)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(456, 41)
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
        Me.TextNombEmpresa.Size = New System.Drawing.Size(444, 20)
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
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightBlue
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.ContextMenuStrip = Me.ctxMenu1
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridView1.Location = New System.Drawing.Point(111, 121)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle12
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
        'tbTransac2
        '
        Me.tbTransac2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.tbTransac2.Controls.Add(Me.pnTransac2)
        Me.tbTransac2.Controls.Add(Me.dgCodigos2)
        Me.tbTransac2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTransac2.Location = New System.Drawing.Point(4, 22)
        Me.tbTransac2.Name = "tbTransac2"
        Me.tbTransac2.Size = New System.Drawing.Size(1102, 420)
        Me.tbTransac2.TabIndex = 8
        Me.tbTransac2.Text = "Transacciones con que se graba la nómina"
        '
        'pnTransac2
        '
        Me.pnTransac2.Controls.Add(Me.gpTransac2)
        Me.pnTransac2.Controls.Add(Me.btnIngCod2)
        Me.pnTransac2.Controls.Add(Me.btnCanceCod2)
        Me.pnTransac2.Location = New System.Drawing.Point(7, 6)
        Me.pnTransac2.Name = "pnTransac2"
        Me.pnTransac2.Size = New System.Drawing.Size(738, 57)
        Me.pnTransac2.TabIndex = 119
        '
        'gpTransac2
        '
        Me.gpTransac2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpTransac2.Controls.Add(Me.btnCod2)
        Me.gpTransac2.Controls.Add(Me.TextNombCod2)
        Me.gpTransac2.Controls.Add(Me.TextCodigo2)
        Me.gpTransac2.Controls.Add(Me.Label12)
        Me.gpTransac2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTransac2.Location = New System.Drawing.Point(3, 3)
        Me.gpTransac2.Name = "gpTransac2"
        Me.gpTransac2.Size = New System.Drawing.Size(541, 51)
        Me.gpTransac2.TabIndex = 1
        Me.gpTransac2.TabStop = False
        Me.gpTransac2.Text = "Transacción de nómina"
        '
        'TextNombCod2
        '
        Me.TextNombCod2.BackColor = System.Drawing.Color.White
        Me.TextNombCod2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombCod2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombCod2.Location = New System.Drawing.Point(123, 25)
        Me.TextNombCod2.MaxLength = 25
        Me.TextNombCod2.Name = "TextNombCod2"
        Me.TextNombCod2.Size = New System.Drawing.Size(316, 20)
        Me.TextNombCod2.TabIndex = 2
        '
        'TextCodigo2
        '
        Me.TextCodigo2.BackColor = System.Drawing.Color.White
        Me.TextCodigo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCodigo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCodigo2.Location = New System.Drawing.Point(6, 25)
        Me.TextCodigo2.MaxLength = 5
        Me.TextCodigo2.Name = "TextCodigo2"
        Me.TextCodigo2.Size = New System.Drawing.Size(48, 20)
        Me.TextCodigo2.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(66, 28)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(47, 13)
        Me.Label12.TabIndex = 48
        Me.Label12.Text = "Nombre:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgCodigos2
        '
        Me.dgCodigos2.AllowUserToAddRows = False
        Me.dgCodigos2.AllowUserToDeleteRows = False
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.LightGreen
        Me.dgCodigos2.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle5
        Me.dgCodigos2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCodigos2.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCodigos2.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgCodigos2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCodigos2.ContextMenuStrip = Me.ctxMenu2
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCodigos2.DefaultCellStyle = DataGridViewCellStyle7
        Me.dgCodigos2.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgCodigos2.Location = New System.Drawing.Point(7, 66)
        Me.dgCodigos2.MultiSelect = False
        Me.dgCodigos2.Name = "dgCodigos2"
        Me.dgCodigos2.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCodigos2.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgCodigos2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCodigos2.Size = New System.Drawing.Size(1087, 346)
        Me.dgCodigos2.TabIndex = 115
        '
        'ctxMenu2
        '
        Me.ctxMenu2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxEli2})
        Me.ctxMenu2.Name = "ctxMenu"
        Me.ctxMenu2.Size = New System.Drawing.Size(186, 26)
        '
        'ctxEli2
        '
        Me.ctxEli2.Image = Global.NOMINA.My.Resources.Resources.menos
        Me.ctxEli2.Name = "ctxEli2"
        Me.ctxEli2.Size = New System.Drawing.Size(185, 22)
        Me.ctxEli2.Text = " Eliminar Transaccion"
        '
        'tbTransac1
        '
        Me.tbTransac1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.tbTransac1.Controls.Add(Me.pnTransac1)
        Me.tbTransac1.Controls.Add(Me.dgCodigos)
        Me.tbTransac1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbTransac1.Location = New System.Drawing.Point(4, 22)
        Me.tbTransac1.Name = "tbTransac1"
        Me.tbTransac1.Size = New System.Drawing.Size(1102, 420)
        Me.tbTransac1.TabIndex = 6
        Me.tbTransac1.Text = "Transacciones con que se calcula la nómina"
        '
        'pnTransac1
        '
        Me.pnTransac1.Controls.Add(Me.gpTransaccion)
        Me.pnTransac1.Controls.Add(Me.btnIngCod)
        Me.pnTransac1.Controls.Add(Me.btnCancelCod)
        Me.pnTransac1.Location = New System.Drawing.Point(7, 7)
        Me.pnTransac1.Name = "pnTransac1"
        Me.pnTransac1.Size = New System.Drawing.Size(741, 60)
        Me.pnTransac1.TabIndex = 118
        '
        'gpTransaccion
        '
        Me.gpTransaccion.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpTransaccion.Controls.Add(Me.btnBuscaCodigo)
        Me.gpTransaccion.Controls.Add(Me.textNombCodigo)
        Me.gpTransaccion.Controls.Add(Me.textCodigo)
        Me.gpTransaccion.Controls.Add(Me.Label13)
        Me.gpTransaccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTransaccion.Location = New System.Drawing.Point(3, 3)
        Me.gpTransaccion.Name = "gpTransaccion"
        Me.gpTransaccion.Size = New System.Drawing.Size(541, 53)
        Me.gpTransaccion.TabIndex = 1
        Me.gpTransaccion.TabStop = False
        Me.gpTransaccion.Text = "Transacción de nómina"
        '
        'textNombCodigo
        '
        Me.textNombCodigo.BackColor = System.Drawing.Color.White
        Me.textNombCodigo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombCodigo.Location = New System.Drawing.Point(123, 25)
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
        Me.textCodigo.Location = New System.Drawing.Point(6, 25)
        Me.textCodigo.MaxLength = 5
        Me.textCodigo.Name = "textCodigo"
        Me.textCodigo.Size = New System.Drawing.Size(48, 20)
        Me.textCodigo.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(66, 27)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Nombre:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgCodigos
        '
        Me.dgCodigos.AllowUserToAddRows = False
        Me.dgCodigos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen
        Me.dgCodigos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCodigos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCodigos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCodigos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgCodigos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCodigos.ContextMenuStrip = Me.ctxMenu1
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgCodigos.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgCodigos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgCodigos.Location = New System.Drawing.Point(7, 73)
        Me.dgCodigos.MultiSelect = False
        Me.dgCodigos.Name = "dgCodigos"
        Me.dgCodigos.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgCodigos.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgCodigos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCodigos.Size = New System.Drawing.Size(1088, 339)
        Me.dgCodigos.TabIndex = 115
        '
        'TbGeneral
        '
        Me.TbGeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TbGeneral.Controls.Add(Me.TextMovimientos)
        Me.TbGeneral.Controls.Add(Me.TextDePrestamos)
        Me.TbGeneral.Controls.Add(Me.TextTiPago)
        Me.TbGeneral.Controls.Add(Me.TextTipo)
        Me.TbGeneral.Controls.Add(Me.Label7)
        Me.TbGeneral.Controls.Add(Me.cmbDePrestamos)
        Me.TbGeneral.Controls.Add(Me.numCantNom)
        Me.TbGeneral.Controls.Add(Me.Label6)
        Me.TbGeneral.Controls.Add(Me.numCantidad)
        Me.TbGeneral.Controls.Add(Me.gpCuenta)
        Me.TbGeneral.Controls.Add(Me.TextConlNombre)
        Me.TbGeneral.Controls.Add(Me.textPorcentaje)
        Me.TbGeneral.Controls.Add(Me.Label9)
        Me.TbGeneral.Controls.Add(Me.cmbTipago)
        Me.TbGeneral.Controls.Add(Me.Label36)
        Me.TbGeneral.Controls.Add(Me.cmbMovimientos)
        Me.TbGeneral.Controls.Add(Me.Label42)
        Me.TbGeneral.Controls.Add(Me.Label18)
        Me.TbGeneral.Controls.Add(Me.Label32)
        Me.TbGeneral.Controls.Add(Me.cmbTipo)
        Me.TbGeneral.Controls.Add(Me.Label31)
        Me.TbGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbGeneral.Location = New System.Drawing.Point(4, 22)
        Me.TbGeneral.Name = "TbGeneral"
        Me.TbGeneral.Size = New System.Drawing.Size(1102, 420)
        Me.TbGeneral.TabIndex = 3
        Me.TbGeneral.Text = "Datos generales"
        Me.TbGeneral.Visible = False
        '
        'TextMovimientos
        '
        Me.TextMovimientos.BackColor = System.Drawing.Color.White
        Me.TextMovimientos.Location = New System.Drawing.Point(637, 139)
        Me.TextMovimientos.Name = "TextMovimientos"
        Me.TextMovimientos.ReadOnly = True
        Me.TextMovimientos.Size = New System.Drawing.Size(40, 20)
        Me.TextMovimientos.TabIndex = 114
        '
        'TextDePrestamos
        '
        Me.TextDePrestamos.BackColor = System.Drawing.Color.White
        Me.TextDePrestamos.Location = New System.Drawing.Point(196, 177)
        Me.TextDePrestamos.Name = "TextDePrestamos"
        Me.TextDePrestamos.ReadOnly = True
        Me.TextDePrestamos.Size = New System.Drawing.Size(40, 20)
        Me.TextDePrestamos.TabIndex = 113
        '
        'TextTiPago
        '
        Me.TextTiPago.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextTiPago.BackColor = System.Drawing.Color.White
        Me.TextTiPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTiPago.Location = New System.Drawing.Point(852, 15)
        Me.TextTiPago.MaxLength = 3
        Me.TextTiPago.Name = "TextTiPago"
        Me.TextTiPago.ReadOnly = True
        Me.TextTiPago.Size = New System.Drawing.Size(222, 20)
        Me.TextTiPago.TabIndex = 112
        '
        'TextTipo
        '
        Me.TextTipo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextTipo.BackColor = System.Drawing.Color.White
        Me.TextTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipo.Location = New System.Drawing.Point(108, 16)
        Me.TextTipo.MaxLength = 3
        Me.TextTipo.Name = "TextTipo"
        Me.TextTipo.ReadOnly = True
        Me.TextTipo.Size = New System.Drawing.Size(260, 20)
        Me.TextTipo.TabIndex = 111
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 180)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(176, 13)
        Me.Label7.TabIndex = 110
        Me.Label7.Text = "Permite descuentos fijos de nómina:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDePrestamos
        '
        Me.cmbDePrestamos.AutoCompleteCustomSource.AddRange(New String() {"S", "N", ""})
        Me.cmbDePrestamos.BackColor = System.Drawing.Color.White
        Me.cmbDePrestamos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDePrestamos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDePrestamos.Items.AddRange(New Object() {"S", "N", ""})
        Me.cmbDePrestamos.Location = New System.Drawing.Point(195, 177)
        Me.cmbDePrestamos.Name = "cmbDePrestamos"
        Me.cmbDePrestamos.Size = New System.Drawing.Size(43, 21)
        Me.cmbDePrestamos.TabIndex = 8
        '
        'numCantNom
        '
        Me.numCantNom.BackColor = System.Drawing.Color.White
        Me.numCantNom.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numCantNom.Location = New System.Drawing.Point(322, 140)
        Me.numCantNom.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.numCantNom.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCantNom.Name = "numCantNom"
        Me.numCantNom.Size = New System.Drawing.Size(56, 20)
        Me.numCantNom.TabIndex = 6
        Me.numCantNom.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(172, 144)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(138, 13)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Cantidad anual de nóminas:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'numCantidad
        '
        Me.numCantidad.BackColor = System.Drawing.Color.White
        Me.numCantidad.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.numCantidad.Location = New System.Drawing.Point(103, 139)
        Me.numCantidad.Maximum = New Decimal(New Integer() {360, 0, 0, 0})
        Me.numCantidad.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numCantidad.Name = "numCantidad"
        Me.numCantidad.Size = New System.Drawing.Size(56, 20)
        Me.numCantidad.TabIndex = 5
        Me.numCantidad.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'gpCuenta
        '
        Me.gpCuenta.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpCuenta.Controls.Add(Me.TextConsCuenta)
        Me.gpCuenta.Controls.Add(Me.TextNombCuenta)
        Me.gpCuenta.Controls.Add(Me.Label2)
        Me.gpCuenta.Controls.Add(Me.btnConNome)
        Me.gpCuenta.Location = New System.Drawing.Point(5, 48)
        Me.gpCuenta.Name = "gpCuenta"
        Me.gpCuenta.Size = New System.Drawing.Size(659, 50)
        Me.gpCuenta.TabIndex = 4
        Me.gpCuenta.TabStop = False
        Me.gpCuenta.Text = "Cuenta para el registro contable"
        '
        'TextConsCuenta
        '
        Me.TextConsCuenta.BackColor = System.Drawing.Color.White
        Me.TextConsCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConsCuenta.Location = New System.Drawing.Point(8, 19)
        Me.TextConsCuenta.MaxLength = 6
        Me.TextConsCuenta.Name = "TextConsCuenta"
        Me.TextConsCuenta.Size = New System.Drawing.Size(48, 20)
        Me.TextConsCuenta.TabIndex = 1
        '
        'TextNombCuenta
        '
        Me.TextNombCuenta.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombCuenta.Location = New System.Drawing.Point(139, 19)
        Me.TextNombCuenta.MaxLength = 50
        Me.TextNombCuenta.Name = "TextNombCuenta"
        Me.TextNombCuenta.Size = New System.Drawing.Size(439, 20)
        Me.TextNombCuenta.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(85, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Nombre:"
        '
        'TextConlNombre
        '
        Me.TextConlNombre.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextConlNombre.BackColor = System.Drawing.Color.White
        Me.TextConlNombre.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextConlNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConlNombre.Location = New System.Drawing.Point(465, 18)
        Me.TextConlNombre.MaxLength = 20
        Me.TextConlNombre.Name = "TextConlNombre"
        Me.TextConlNombre.Size = New System.Drawing.Size(260, 20)
        Me.TextConlNombre.TabIndex = 2
        '
        'textPorcentaje
        '
        Me.textPorcentaje.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textPorcentaje.BackColor = System.Drawing.Color.White
        Me.textPorcentaje.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textPorcentaje.Location = New System.Drawing.Point(428, 177)
        Me.textPorcentaje.MaxLength = 3
        Me.textPorcentaje.Name = "textPorcentaje"
        Me.textPorcentaje.ReadOnly = True
        Me.textPorcentaje.Size = New System.Drawing.Size(56, 20)
        Me.textPorcentaje.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(404, 21)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(47, 13)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "Nombre:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipago
        '
        Me.cmbTipago.BackColor = System.Drawing.Color.White
        Me.cmbTipago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipago.Items.AddRange(New Object() {"ANTICIPO", "SUELDOS", "PRESTACIONES", ""})
        Me.cmbTipago.Location = New System.Drawing.Point(852, 15)
        Me.cmbTipago.Name = "cmbTipago"
        Me.cmbTipago.Size = New System.Drawing.Size(222, 21)
        Me.cmbTipago.TabIndex = 3
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(766, 18)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(73, 13)
        Me.Label36.TabIndex = 82
        Me.Label36.Text = "Tipo de pago:"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMovimientos
        '
        Me.cmbMovimientos.BackColor = System.Drawing.Color.White
        Me.cmbMovimientos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMovimientos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMovimientos.Items.AddRange(New Object() {"S", "N", ""})
        Me.cmbMovimientos.Location = New System.Drawing.Point(635, 139)
        Me.cmbMovimientos.Name = "cmbMovimientos"
        Me.cmbMovimientos.Size = New System.Drawing.Size(43, 21)
        Me.cmbMovimientos.TabIndex = 7
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(421, 142)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(203, 13)
        Me.Label42.TabIndex = 68
        Me.Label42.Text = "Permite movimientos variables de nómina:"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(265, 180)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(155, 13)
        Me.Label18.TabIndex = 66
        Me.Label18.Text = "Porcentaje que le corresponde:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(2, 143)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(91, 13)
        Me.Label32.TabIndex = 21
        Me.Label32.Text = "Cantidad de días:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipo
        '
        Me.cmbTipo.BackColor = System.Drawing.Color.White
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Items.AddRange(New Object() {"ANTICIPO QUINCENAL", "BONO 14", "COMPLEMENTO BONO 14", "MENSUAL", "BONO VACACIONAL", "VACA/AGUI. ADMON.", "VACA. ACADEMICO", "VACTA/AGUI. ACADEMICO", ""})
        Me.cmbTipo.Location = New System.Drawing.Point(109, 16)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(260, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(2, 18)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(83, 13)
        Me.Label31.TabIndex = 14
        Me.Label31.Text = "Tipo de nómina:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabDatos
        '
        Me.tabDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabDatos.ContextMenuStrip = Me.ctxPrincipal
        Me.tabDatos.Controls.Add(Me.TbGeneral)
        Me.tabDatos.Controls.Add(Me.tbTransac1)
        Me.tabDatos.Controls.Add(Me.tbTransac2)
        Me.tabDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDatos.Location = New System.Drawing.Point(11, 65)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectedIndex = 0
        Me.tabDatos.Size = New System.Drawing.Size(1110, 446)
        Me.tabDatos.TabIndex = 3
        '
        'ctxPrincipal
        '
        Me.ctxPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModificar})
        Me.ctxPrincipal.Name = "ctxMenu"
        Me.ctxPrincipal.Size = New System.Drawing.Size(214, 26)
        '
        'ctxModificar
        '
        Me.ctxModificar.Image = Global.NOMINA.My.Resources.Resources.edit1
        Me.ctxModificar.Name = "ctxModificar"
        Me.ctxModificar.Size = New System.Drawing.Size(213, 22)
        Me.ctxModificar.Text = "Modificar Tipo de Nómina"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Location = New System.Drawing.Point(0, 1)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 105)
        Me.Panel1.TabIndex = 72
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnAtr)
        Me.Panel2.Controls.Add(Me.btnGuardar)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.btnBuscar)
        Me.Panel2.Controls.Add(Me.btnSig)
        Me.Panel2.Location = New System.Drawing.Point(0, 536)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1130, 42)
        Me.Panel2.TabIndex = 73
        '
        'frmIngConxNomina
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnLimpiar
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.tabDatos)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmIngConxNomina"
        Me.Text = "Mantenimiento de Tipos de Nómina"
        Me.ctxMenu1.ResumeLayout(False)
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
        Me.tbTransac2.ResumeLayout(False)
        Me.pnTransac2.ResumeLayout(False)
        Me.gpTransac2.ResumeLayout(False)
        Me.gpTransac2.PerformLayout()
        CType(Me.dgCodigos2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu2.ResumeLayout(False)
        Me.tbTransac1.ResumeLayout(False)
        Me.pnTransac1.ResumeLayout(False)
        Me.gpTransaccion.ResumeLayout(False)
        Me.gpTransaccion.PerformLayout()
        CType(Me.dgCodigos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbGeneral.ResumeLayout(False)
        Me.TbGeneral.PerformLayout()
        CType(Me.numCantNom, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numCantidad, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpCuenta.ResumeLayout(False)
        Me.gpCuenta.PerformLayout()
        Me.tabDatos.ResumeLayout(False)
        Me.ctxPrincipal.ResumeLayout(False)
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
        cadena = "select  n2.transac, t.nombre from tiponomina2 n2  inner join " &
                 "tipotran t on n2.transac=t.transac and n2.empresa=t.empresa where " &
                 "n2.empresa=@empresa and tiponom=''"
        llenaTabla(cadena, tbDatos, ListaParametros(lpara))
        llenaTabla(cadena, tbDatos2, ListaParametros(lpara))
        cn.Close()
        dgCodigos.DataSource = tbDatos
        dgCodigos2.DataSource = tbDatos2
        Vista1(dgCodigos, tbDatos)
        Vista1(dgCodigos2, tbDatos2)
        btnLimpiar_Click(sender, e)
    End Sub


#Region "CUENTA"

    Private Sub BorraCuenta(ByVal valbool As Boolean)
        TextNombCuenta.Clear()
        If valbool = True Then
            TextConsCuenta.Clear()
        End If
    End Sub

    Private Sub btnConNome_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConNome.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = TextNombCuenta.Text.Trim
        If TextNombCuenta.Text.Trim <> "" Then
            cadena = "select cuenta,nombre from nomencla where empresa=@empresa and nombre like '%' + @nombre + '%' and operable='S' and (naturaleza='1' or naturaleza='2')  order by cuenta"
        Else
            cadena = "select cuenta,nombre from nomencla where empresa=@empresa and  operable='S' and (naturaleza='1' or naturaleza='2') order by cuenta"
        End If
        numFilas = llenaTabla(cadena, tbCuenta, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN CUENTAS CONTABLES CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCuenta(True)
            TextConsCuenta.Focus()
        ElseIf numFilas = 1 Then
            BorraCuenta(True)
            filaTemp = tbCuenta.Rows.Item(0)
            TextConsCuenta.Text() = filaTemp.Item(0)
            TextNombCuenta.Text = filaTemp.Item(1)
            numCantidad.Focus()
        Else
            EnBuscaCContable()
        End If

    End Sub

    Private Sub ValidaCuenta()
        lpara.Clear()
        lpara("cuenta") = TextConsCuenta.Text.Trim
        If BuscaEscalar("select count (*) from nomencla where cuenta=@cuenta", ListaParametros(lpara)) = 0 Then
            MsgBox("CUENTA CONTABLE NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCuenta(True)
            Exit Sub
        End If
        cadena = "select cuenta,nombre from nomencla where cuenta=@cuenta and operable='S' and (naturaleza='1' or naturaleza='2')"
        abrir_conexion(cn)
        comando = New SqlCommand(cadena, cn)
        comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
        dr = comando.ExecuteReader
        If dr.HasRows() Then
            BorraCuenta(False)
            dr.Read()
            TextNombCuenta.Text = dr.GetValue(1)
            numCantidad.Focus()
        Else
            MsgBox("CUENTA CONTABLE NO ES VALIDA, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCuenta(True)
            TextConsCuenta.Focus()
        End If
        dr.Close()
        cn.Close()
    End Sub

    Private Sub TextCuenta_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextConsCuenta.Validated
        If TextConsCuenta.Text.Trim <> "" Then
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
        numCantidad.Focus()
    End Sub

    Private Sub ActualizacionDatos(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraCuenta(True)
        filaTemp = tbCuenta.Rows.Item(e.va2)
        TextConsCuenta.Text() = filaTemp.Item(0)
        TextNombCuenta.Text = filaTemp.Item(1)
        numCantidad.Focus()
    End Sub
#End Region

#Region "LIMPIAR Y  FORMATOS"


    Private Sub Vista1(ByVal dgVista As DataGridView, ByVal Tabla As DataTable)
        With dgVista
            .Columns(0).HeaderText = "Transacción"
            .Columns(0).Width = 140
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).Width = 465
            'AltoGridView(18, Tabla, 148, 650, dgVista)
        End With
    End Sub


    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        btnSig.Enabled = False
        btnAtr.Enabled = False
        btnBuscar.Enabled = True
        btnBuscar.Visible = True
        btnGuardar.Visible = False
        btnConNome.Enabled = True
        tbDatos.Rows.Clear()
        tbDatos2.Rows.Clear()
        btnCanceCod_Click(sender, e)
        btnCanceCod2_Click(sender, e)
        borra_Mejorado(TbGeneral, ep1)
        SoloLeer(TbGeneral, True)
        TextNombCuenta.ReadOnly = False
        ConsultaReadOnly(TbGeneral, False)
        pnTransac1.Enabled = False
        pnTransac2.Enabled = False
        ContextoMenuEnab(True, False, ctxPrincipal)
        ContextoMenuEnab(True, False, ctxMenu1)
        ContextoMenuEnab(True, False, ctxMenu2)
        tbDatos.Rows.Clear()
    End Sub

    Private Sub btnCanceCod2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCanceCod2.Click
        BorraCodigo2(True)
        textCodigo.Focus()
    End Sub

    Private Sub btnCanceCod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelCod.Click
        BorraCodigo(True)
        textCodigo.Focus()
    End Sub

#End Region


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
        cadena = "select transac, nombre from tipotran where empresa=@empresa and nombre like '%' + @nombre + '%' and tipomov='I' and ( formacal='FM' or formacal='EX' or formacal='IM')  order by transac"
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
            btnIngCod.Focus()
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
            cadena = "select transac, nombre from tipotran where empresa=@empresa and transac=@transac and tipomov='I' and ( formacal='FM' or formacal='EX' or formacal='IM')"
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
                btnIngCod.Focus()
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
        btnIngCod.Focus()
    End Sub

    Private Sub ActualizacionDatosMonitor(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraCodigo(True)
        filaTemp = tbCodigo.Rows.Item(e.va2)
        textCodigo.Text() = filaTemp.Item(0)
        textNombCodigo.Text = filaTemp.Item(1)
    End Sub

#End Region

#Region "TRANSACCION 2"


    Private Sub BorraCodigo2(ByVal valbool As Boolean)
        TextNombCod2.Clear()
        If valbool = True Then
            TextCodigo2.Clear()
        End If
    End Sub


    Private Sub btnCodigo2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCod2.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = TextNombCod2.Text.Trim
        cadena = "select transac, nombre from tipotran where empresa=@empresa and nombre like '%' + @nombre + '%' and formacal='CA'  order by transac"
        numFilas = llenaTabla(cadena, tbCodigo, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN TRANSACCIONES CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraCodigo2(True)
            TextCodigo2.Focus()
        ElseIf numFilas = 1 Then
            BorraCodigo(True)
            filaTemp = tbCodigo.Rows.Item(0)
            TextCodigo2.Text() = filaTemp.Item(0)
            TextNombCod2.Text = filaTemp.Item(1)
            btnIngCod2.Focus()
        Else
            EnBuscaCodigo2()
        End If
    End Sub

    Private Sub ValidaCodigo2()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("transac") = TextCodigo2.Text.Trim
        If valida_tipo_Entero(TextCodigo2.Text, 1) = True Then
            If BuscaEscalar("select count (*) from tipotran where empresa=@empresa and transac=@transac", ListaParametros(lpara)) = 0 Then
                MsgBox("TRANSACCION NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraCodigo2(True)
                TextCodigo2.Focus()
                Exit Sub
            End If
            cadena = "select transac, nombre from tipotran where empresa=@empresa and transac=@transac and  formacal='CA'"
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraCodigo2(False)
                dr.Read()
                TextNombCod2.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
                btnIngCod2.Focus()
            Else
                dr.Close()
                cn.Close()
                MsgBox("TRANSACCION NO VALIDA", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                BorraCodigo2(True)
            End If
        Else
            MsgBox("TRANSACCION POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraCodigo2(True)
            TextCodigo2.Focus()
        End If
    End Sub

    Private Sub TextCodigo2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextCodigo2.Validated
        If TextCodigo2.Text.Trim <> "" Then
            ValidaCodigo2()
        Else
            BorraCodigo2(False)
        End If
    End Sub

    Private Sub EnBuscaCodigo2()
        fEmp = New frmMuestraCodigos
        fEmp.TopMost = True
        fEmp.inicializa(tbCodigo)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosMonitor2
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        btnIngCod2.Focus()
    End Sub

    Private Sub ActualizacionDatosMonitor2(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraCodigo2(True)
        filaTemp = tbCodigo.Rows.Item(e.va2)
        TextCodigo2.Text() = filaTemp.Item(0)
        TextNombCod2.Text = filaTemp.Item(1)
    End Sub

#End Region

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim i As Int32
        Dim modelo As New cmodelo
        lpara.Clear()
        If validetError(cmbTipo, ep1) And validetError(TextConlNombre, ep1) And validetError(cmbTipago, ep1) And _
            validetError(TextConsCuenta, ep1) And validetError(cmbMovimientos, ep1) And validetError(cmbDePrestamos, ep1) And _
            validetError(textPorcentaje, ep1) Then
            Select Case cmbTipago.SelectedIndex
                Case 0
                    If tbDatos2.Rows.Count = 0 Then
                        MsgBox("DEBE INGRESAR LAS TRANSACCIONES CON QUE SE GRABAN LA NOMINA", MsgBoxStyle.Information, "Mensaje del Sistema")
                        tabDatos.SelectedIndex = 1
                        Exit Sub
                    End If
                Case 2
                    If tbDatos.Rows.Count = 0 Then
                        MsgBox("DEBE INGRESAR LAS TRANSACCIONES CON QUE SE CALCULA LA NOMINA", MsgBoxStyle.Information, "Mensaje del Sistema")
                        tabDatos.SelectedIndex = 1
                        Exit Sub
                    ElseIf tbDatos2.Rows.Count = 0 Then
                        MsgBox("DEBE INGRESAR LAS TRANSACCIONES CON QUE SE GRABAN LA NOMINA", MsgBoxStyle.Information, "Mensaje del Sistema")
                        tabDatos.SelectedIndex = 2
                        Exit Sub
                    End If
            End Select

            If MsgBox("ESTA SEGURO QUE DESEA  ESTA NOMINA", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then

                lpara("nombre") = TextConlNombre.Text
                lpara("tipago") = cmbTipago.Text.Substring(0, 1)
                lpara("cuenta") = TextConsCuenta.Text
                lpara("cantidad") = numCantidad.Value
                lpara("cantidadnom") = numCantNom.Value
                lpara("movimientos") = cmbMovimientos.Text
                lpara("desprestamos") = cmbDePrestamos.Text
                lpara("empresa") = empresa
                lpara("tiponom") = tipoNom
                Try
                    cadena = "UPDATE tiponomina1 SET  nombre=@nombre, tipago=@tipago " &
                             ",cuenta=@cuenta, cantidad=@cantidad, cantidadnom=@cantidadnom " &
                             ",movimientos=@movimientos, desprestamos=@desprestamos where empresa=@empresa and tiponom=@tiponom "
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                    cadena = "delete from tiponomina2 where empresa=@empresa and tiponom=@tiponom "
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                    For i = 0 To tbDatos.Rows.Count - 1
                        filaTemp = tbDatos.Rows(i)
                        lpara("transac") = filaTemp.Item(0)
                        cadena = " insert into tiponomina2 (empresa,tiponom, transac) 
                                   values (@empresa,@tiponom,@transac)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    Next i

                    cadena = "delete from tiponomina3 where empresa=@empresa and tiponom=@tiponom "
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                    For i = 0 To tbDatos2.Rows.Count - 1
                        filaTemp = tbDatos2.Rows(i)
                        lpara("transacnom") = filaTemp.Item(0)
                        cadena = " insert into tiponomina3 (empresa,tiponom, transacnom) 
                                   values (@empresa,@tiponom,@transacnom)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    Next i
                    modelo.Commit()
                    InsertBitacora(9, 2, Me.Text)
                    MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                    btnLimpiar_Click(sender, e)
                Catch ex As Exception
                    MsgBox("Error del Sistema: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                    modelo.RollBack()
                End Try

            End If
        Else
            MsgBox("LLENE LOS CAMPOS MARCADOS", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim finConsulta, cadenaConsulta As String
        finConsulta = ""
        GeneraConsulta(tabDatos, finConsulta, "n1")
        lpara.Clear()
        If cmbTipo.Text.Trim <> "" Then
            Select Case cmbTipo.SelectedIndex
                Case 0
                    tipoNom = "A"
                Case 1
                    tipoNom = "B"
                Case 2
                    tipoNom = "C"
                Case 3
                    tipoNom = "M"
                Case 4
                    tipoNom = "O"
                Case 5
                    tipoNom = "V"
                Case 6
                    tipoNom = "W"
                Case 7
                    tipoNom = "X"
            End Select
            finConsulta = finConsulta & " and n1.tiponom='" & tipoNom & "'"
        End If


        If cmbTipago.Text.Trim <> "" Then
            lpara("tipago") = cmbTipago.Text.Substring(0, 1)
            finConsulta = finConsulta & " and n1.tipago=@tipago "
        End If
        If cmbMovimientos.Text.Trim <> "" Then
            lpara("movimientos") = cmbMovimientos.Text
            finConsulta = finConsulta & " and n1.movimientos=@movimientos "
        End If
        If cmbDePrestamos.Text.Trim <> "" Then
            lpara("deprestamos") = cmbDePrestamos.Text
            finConsulta = finConsulta & " and n1.deprestamos=@deprestamos "
        End If
        cadenaConsulta = InicioConsulta & finConsulta & " order by tiponom asc"
        Mostrar(cadenaConsulta, sender, e)
    End Sub

    Private Sub Mostrar(ByVal subCadena As String, ByVal sender As System.Object, ByVal e As System.EventArgs)
        ConsultaReadOnly(TbGeneral, True)
        SoloLeer(TbGeneral, True)
        btnBuscar.Enabled = False
        ContextoMenuEnab(True, True, ctxPrincipal)
        btnConNome.Enabled = False
        TextNombCuenta.ReadOnly = True
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
        lpara.Clear()
        filaCopiar = tabla.Rows.Item(indi)
        tipoNom = filaCopiar.Item(0)
        Select Case filaCopiar.Item(0)
            Case "A"
                cmbTipo.SelectedIndex = 0
            Case "B"
                cmbTipo.SelectedIndex = 1
            Case "C"
                cmbTipo.SelectedIndex = 2
            Case "M"
                cmbTipo.SelectedIndex = 3
            Case "O"
                cmbTipo.SelectedIndex = 4
            Case "V"
                cmbTipo.SelectedIndex = 5
            Case "W"
                cmbTipo.SelectedIndex = 6
            Case "X"
                cmbTipo.SelectedIndex = 7
        End Select
        TextTipo.Text = cmbTipo.Text
        TextConlNombre.Text = filaCopiar.Item(1)
        Select Case filaCopiar.Item(2)
            Case "A"
                cmbTipago.SelectedIndex = 0
            Case "S"
                cmbTipago.SelectedIndex = 1
            Case "P"
                cmbTipago.SelectedIndex = 2
            Case "B"
                cmbTipago.SelectedIndex = 3
        End Select

        lpara("cuenta") = TextConsCuenta.Text
        lpara("empresa") = empresa
        TextTiPago.Text = cmbTipago.Text
        TextConsCuenta.Text = filaCopiar.Item(3)
        'TextNombCuenta.Text = BuscaEscalar("select nombre from nomencla where cuenta=@cuenta and empresa=@empresa ", ListaParametros(lpara))
        TextNombCuenta.Text = filaCopiar.Item(1)
        numCantidad.Value = filaCopiar.Item(4)
        numCantNom.Value = filaCopiar.Item(5)
        cmbMovimientos.Text = filaCopiar.Item(6)
        TextMovimientos.Text = cmbMovimientos.Text
        cmbDePrestamos.Text = filaCopiar.Item(7)
        TextDePrestamos.Text = cmbDePrestamos.Text
        textPorcentaje.Text = filaCopiar.Item(8)
        lpara("tiponom") = filaCopiar.Item(0)
        cadena = cadenaDetalle1 & " and tiponom=@tiponom"
        llenaTabla(cadena, tbDatos, ListaParametros(lpara))
        Vista1(dgCodigos, tbDatos)
        cadena = cadenaDetalle2 & " and tiponom=@tiponom"
        llenaTabla(cadena, tbDatos2, ListaParametros(lpara))
        Vista1(dgCodigos2, tbDatos2)
    End Sub

    Private Sub ctxModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificar.Click
        btnSig.Enabled = False
        btnAtr.Enabled = False
        btnBuscar.Visible = False
        btnGuardar.Visible = True
        ContextoMenuEnab(False, True, ctxPrincipal)
        ContextoMenuEnab(True, True, ctxMenu1)
        ContextoMenuEnab(True, True, ctxMenu2)
        ConsultaReadOnly(TbGeneral, False)
        SoloLeer(TbGeneral, False)
        cmbTipo.Visible = False
        TextTipo.Visible = True
        TextConlNombre.BackColor = ColorModi
        cmbTipago.BackColor = ColorModi
        TextConsCuenta.BackColor = ColorModi
        numCantidad.BackColor = ColorModi
        numCantNom.BackColor = ColorModi
        cmbMovimientos.BackColor = ColorModi
        cmbDePrestamos.BackColor = ColorModi
        pnTransac1.Enabled = True
        pnTransac2.Enabled = True
        btnConNome.Enabled = True
        TextNombCuenta.ReadOnly = True
    End Sub


#Region "CODIGOS"

    Private Sub btnIngCod1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngCod.Click
        Dim i As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("transac") = textCodigo.Text
        If validetError(textCodigo, ep1) Then
            For i = 0 To tbDatos.Rows.Count - 1
                filaTemp = tbDatos.Rows(i)
                If CInt(textCodigo.Text) = filaTemp.Item(0) Then
                    MsgBox("CODIGO DE TRANSACCION YA INGRESADA", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
            Next i
            filaTemp = tbDatos.NewRow
            filaTemp.Item(0) = textCodigo.Text
            filaTemp.Item(1) = BuscaEscalar("select nombre from tipotran where empresa=@empresa and transac=@transac", ListaParametros(lpara))
            tbDatos.Rows.Add(filaTemp)
            MueveScrollView(dgCodigos, tbDatos.Rows.Count - 1)
            btnCanceCod_Click(sender, e)
        Else
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ctxEli1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEli1.Click
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgCodigos.SelectedRows.Count > 0 Then
            filaTemp = CType(dgCodigos.SelectedRows(0).DataBoundItem, DataRowView).Row
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                tbDatos.Rows.Remove(filaTemp)
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnIngCod2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIngCod2.Click
        Dim i As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("transac") = TextCodigo2.Text
        If validetError(TextCodigo2, ep1) Then
            For i = 0 To tbDatos2.Rows.Count - 1
                filaTemp = tbDatos2.Rows(i)
                If CInt(TextCodigo2.Text) = filaTemp.Item(0) Then
                    MsgBox("CODIGO DE TRANSACCION YA INGRESADA", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
            Next i
            filaTemp = tbDatos2.NewRow
            filaTemp.Item(0) = TextCodigo2.Text
            filaTemp.Item(1) = BuscaEscalar("select nombre from tipotran where empresa=@empresa and transac=@transac", ListaParametros(lpara))
            tbDatos2.Rows.Add(filaTemp)
            'AltoGridView(18, tbDatos2, 148, 650, dgCodigos2)
            MueveScrollView(dgCodigos2, tbDatos2.Rows.Count - 1)
            btnCanceCod2_Click(sender, e)
        Else
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ctxEli2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEli2.Click
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgCodigos2.SelectedRows.Count > 0 Then
            filaTemp = CType(dgCodigos2.SelectedRows(0).DataBoundItem, DataRowView).Row
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                tbDatos2.Rows.Remove(filaTemp)
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub





#End Region


    Private Sub TextPor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles textPorcentaje.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub textPorcentaje_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textPorcentaje.Validated
        If sender.text.trim <> "" Then
            If CInt(sender.text) = 0 Or CInt(sender.text) > 100 Then
                MsgBox("PORCENTAJE DEBE SER ENTRE EL 1 Y 100", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                sender.text = 1
            End If
        End If
    End Sub

    Private Sub cmbTiPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipago.SelectedIndexChanged
        tabDatos.TabPages.Clear()
        tabDatos.TabPages.Add(TbGeneral)
        Select Case cmbTipago.SelectedIndex
            Case 0
                tabDatos.TabPages.Add(tbTransac2)
            Case 2, 3
                tabDatos.TabPages.Add(tbTransac1)
                tabDatos.TabPages.Add(tbTransac2)
        End Select
    End Sub

#Region "ENTRA Y DEJA FOCO"
    Private Sub Foco(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMovimientos.Enter, cmbTipago.Enter, textPorcentaje.Enter, cmbTipo.Enter, textCodigo.Enter, textNombCodigo.Enter, numCantidad.Enter, numCantNom.Enter, TextConsCuenta.Enter, TextConsCuenta.Enter, TextNombCuenta.Enter, textCodigo.Enter, TextCodigo2.Enter, TextNombCod2.Enter, textNombCodigo.Enter, TextConlNombre.Enter
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbMovimientos.Leave, cmbTipago.Leave, textPorcentaje.Leave, cmbTipo.Leave, textCodigo.Leave, textNombCodigo.Leave, numCantidad.Leave, numCantNom.Leave, TextConsCuenta.Leave, TextConsCuenta.Leave, TextNombCuenta.Leave, textCodigo.Leave, TextCodigo2.Leave, TextNombCod2.Leave, textNombCodigo.Leave, TextConlNombre.Leave
        desactiva(sender)
    End Sub
#End Region

    Private Sub frmDatosGen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub


    Private Sub numCantidad_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles numCantidad.Validated, numCantNom.Validated
        Dim numT As NumericUpDown
        numT = sender
        If numT.Value = numT.Minimum Then
            numT.UpButton()
            numT.DownButton()
        End If
    End Sub


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


    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub






End Class
