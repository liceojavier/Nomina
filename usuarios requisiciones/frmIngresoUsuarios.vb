Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMINGRESOUSUARIOS.VB MIEMBRO DE NOMINA.SLN                                 **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmIngresoUsuarios
    Inherits System.Windows.Forms.Form
    'variables locales
    Dim fecha As Date
    Dim cadena As String
    'tablas locales
    Dim tbAutoriza1 As New DataTable("autoriza1")
    Dim tbAutoriza2 As New DataTable("autoriza2")
    Dim tbpermisos As New DataTable("permisos")
    Dim tbtipousuario As New DataTable("tipousuarios")
    'variables de manejo de filas
    Dim dc As DataColumn
    Dim g As DataRow
    Dim filaTemp As DataRow
    Dim codigoemp1, codigoemp2 As Integer
    'variables de vistas 
    Dim ts As DataGridTableStyle = New DataGridTableStyle
    Dim primeraves As Boolean = True
    'varibles de reportes
    'Dim WithEvents f As FrmReportePedidosBS
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim tbOrigen As New DataTable("origenes")
    Dim tbBodega As New DataTable("bodega")
    'Dim tbProducto As New DataTable("producto")
    Dim WithEvents fOrig As frmMuestraUsuarios
    Dim opcModi, filaAct As Int16
    Friend WithEvents gpGeneral As System.Windows.Forms.GroupBox
    Friend WithEvents btnEliminar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextEmpleado2 As System.Windows.Forms.TextBox
    Friend WithEvents TextNombEmpleado2 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnEmpleado2 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextEmpleado1 As System.Windows.Forms.TextBox
    Friend WithEvents TextNombEmpleado1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnEmpleado1 As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BtnSave As System.Windows.Forms.Button
    Friend WithEvents cmbTipoUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents gpCentro As System.Windows.Forms.GroupBox
    Friend WithEvents TextEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents TextNombEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label4 As System.Windows.Forms.Label
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
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngresoUsuarios))
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gpCentro = New System.Windows.Forms.GroupBox()
        Me.TextEmpleado = New System.Windows.Forms.TextBox()
        Me.TextNombEmpleado = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoUsuario = New System.Windows.Forms.ComboBox()
        Me.BtnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextEmpleado1 = New System.Windows.Forms.TextBox()
        Me.TextNombEmpleado1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnEmpleado1 = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextEmpleado2 = New System.Windows.Forms.TextBox()
        Me.TextNombEmpleado2 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnEmpleado2 = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.gpGeneral = New System.Windows.Forms.GroupBox()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gpEmpresa.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpCentro.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.gpGeneral.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(164, 8)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(360, 43)
        Me.gpEmpresa.TabIndex = 4
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(8, 16)
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(344, 21)
        Me.TextNombEmpresa.TabIndex = 1
        Me.TextNombEmpresa.TabStop = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(625, 12)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(60, 30)
        Me.btnLimpiar.TabIndex = 12
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar")
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
        'gpCentro
        '
        Me.gpCentro.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpCentro.Controls.Add(Me.TextEmpleado)
        Me.gpCentro.Controls.Add(Me.TextNombEmpleado)
        Me.gpCentro.Controls.Add(Me.Label19)
        Me.gpCentro.Controls.Add(Me.btnEmpleado)
        Me.gpCentro.Controls.Add(Me.Label4)
        Me.gpCentro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCentro.Location = New System.Drawing.Point(8, 16)
        Me.gpCentro.Name = "gpCentro"
        Me.gpCentro.Size = New System.Drawing.Size(587, 46)
        Me.gpCentro.TabIndex = 2
        Me.gpCentro.TabStop = False
        Me.gpCentro.Text = "Usuario"
        '
        'TextEmpleado
        '
        Me.TextEmpleado.BackColor = System.Drawing.Color.White
        Me.TextEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEmpleado.Location = New System.Drawing.Point(60, 17)
        Me.TextEmpleado.MaxLength = 4
        Me.TextEmpleado.Name = "TextEmpleado"
        Me.TextEmpleado.Size = New System.Drawing.Size(64, 20)
        Me.TextEmpleado.TabIndex = 1
        '
        'TextNombEmpleado
        '
        Me.TextNombEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpleado.Location = New System.Drawing.Point(187, 17)
        Me.TextNombEmpleado.MaxLength = 30
        Me.TextNombEmpleado.Name = "TextNombEmpleado"
        Me.TextNombEmpleado.Size = New System.Drawing.Size(328, 20)
        Me.TextNombEmpleado.TabIndex = 2
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(134, 21)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(47, 13)
        Me.Label19.TabIndex = 6
        Me.Label19.Text = "Nombre:"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(519, 8)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(60, 30)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnEmpleado, "Usuario")
        Me.btnEmpleado.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 54
        Me.Label4.Text = "Código:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(16, 80)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Tipo de usuario:"
        '
        'cmbTipoUsuario
        '
        Me.cmbTipoUsuario.Items.AddRange(New Object() {"USUARIO", "JEFE INMEDIATO", "ADMINISTRADOR"})
        Me.cmbTipoUsuario.Location = New System.Drawing.Point(112, 77)
        Me.cmbTipoUsuario.Name = "cmbTipoUsuario"
        Me.cmbTipoUsuario.Size = New System.Drawing.Size(152, 21)
        Me.cmbTipoUsuario.TabIndex = 4
        '
        'BtnSave
        '
        Me.BtnSave.BackColor = System.Drawing.SystemColors.Control
        Me.BtnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnSave.ImageKey = "guardar.png"
        Me.BtnSave.ImageList = Me.ImageNuevos
        Me.BtnSave.Location = New System.Drawing.Point(535, 290)
        Me.BtnSave.Name = "BtnSave"
        Me.BtnSave.Size = New System.Drawing.Size(60, 30)
        Me.BtnSave.TabIndex = 11
        Me.BtnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.BtnSave, "Guardar")
        Me.BtnSave.UseVisualStyleBackColor = False
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.TextEmpleado1)
        Me.GroupBox1.Controls.Add(Me.TextNombEmpleado1)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnEmpleado1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(9, 107)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(586, 47)
        Me.GroupBox1.TabIndex = 78
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Autorizador nivel 1"
        '
        'TextEmpleado1
        '
        Me.TextEmpleado1.BackColor = System.Drawing.Color.White
        Me.TextEmpleado1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEmpleado1.Location = New System.Drawing.Point(58, 19)
        Me.TextEmpleado1.MaxLength = 4
        Me.TextEmpleado1.Name = "TextEmpleado1"
        Me.TextEmpleado1.Size = New System.Drawing.Size(64, 20)
        Me.TextEmpleado1.TabIndex = 5
        '
        'TextNombEmpleado1
        '
        Me.TextNombEmpleado1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpleado1.Location = New System.Drawing.Point(184, 19)
        Me.TextNombEmpleado1.MaxLength = 30
        Me.TextNombEmpleado1.Name = "TextNombEmpleado1"
        Me.TextNombEmpleado1.Size = New System.Drawing.Size(328, 20)
        Me.TextNombEmpleado1.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(131, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Nombre:"
        '
        'btnEmpleado1
        '
        Me.btnEmpleado1.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado1.ImageKey = "usuario.png"
        Me.btnEmpleado1.ImageList = Me.ImageNuevos
        Me.btnEmpleado1.Location = New System.Drawing.Point(518, 10)
        Me.btnEmpleado1.Name = "btnEmpleado1"
        Me.btnEmpleado1.Size = New System.Drawing.Size(60, 30)
        Me.btnEmpleado1.TabIndex = 7
        Me.btnEmpleado1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnEmpleado1, "Usuario")
        Me.btnEmpleado1.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(7, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 54
        Me.Label3.Text = "Código:"
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.GroupBox2.Controls.Add(Me.TextEmpleado2)
        Me.GroupBox2.Controls.Add(Me.TextNombEmpleado2)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.btnEmpleado2)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox2.Location = New System.Drawing.Point(12, 163)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(579, 47)
        Me.GroupBox2.TabIndex = 79
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Autorizador nivel 2"
        '
        'TextEmpleado2
        '
        Me.TextEmpleado2.BackColor = System.Drawing.Color.White
        Me.TextEmpleado2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEmpleado2.Location = New System.Drawing.Point(56, 19)
        Me.TextEmpleado2.MaxLength = 4
        Me.TextEmpleado2.Name = "TextEmpleado2"
        Me.TextEmpleado2.Size = New System.Drawing.Size(64, 20)
        Me.TextEmpleado2.TabIndex = 8
        '
        'TextNombEmpleado2
        '
        Me.TextNombEmpleado2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpleado2.Location = New System.Drawing.Point(181, 19)
        Me.TextNombEmpleado2.MaxLength = 30
        Me.TextNombEmpleado2.Name = "TextNombEmpleado2"
        Me.TextNombEmpleado2.Size = New System.Drawing.Size(325, 20)
        Me.TextNombEmpleado2.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(125, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Nombre:"
        '
        'btnEmpleado2
        '
        Me.btnEmpleado2.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado2.ImageKey = "usuario.png"
        Me.btnEmpleado2.ImageList = Me.ImageNuevos
        Me.btnEmpleado2.Location = New System.Drawing.Point(515, 9)
        Me.btnEmpleado2.Name = "btnEmpleado2"
        Me.btnEmpleado2.Size = New System.Drawing.Size(60, 30)
        Me.btnEmpleado2.TabIndex = 9
        Me.btnEmpleado2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnEmpleado2, "Usuario")
        Me.btnEmpleado2.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(5, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 13)
        Me.Label7.TabIndex = 54
        Me.Label7.Text = "Código:"
        '
        'gpGeneral
        '
        Me.gpGeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpGeneral.Controls.Add(Me.btnEliminar)
        Me.gpGeneral.Controls.Add(Me.GroupBox2)
        Me.gpGeneral.Controls.Add(Me.GroupBox1)
        Me.gpGeneral.Controls.Add(Me.BtnSave)
        Me.gpGeneral.Controls.Add(Me.cmbTipoUsuario)
        Me.gpGeneral.Controls.Add(Me.Label1)
        Me.gpGeneral.Controls.Add(Me.gpCentro)
        Me.gpGeneral.Location = New System.Drawing.Point(5, 60)
        Me.gpGeneral.Name = "gpGeneral"
        Me.gpGeneral.Size = New System.Drawing.Size(601, 328)
        Me.gpGeneral.TabIndex = 6
        Me.gpGeneral.TabStop = False
        '
        'btnEliminar
        '
        Me.btnEliminar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEliminar.ImageKey = "cancelar.png"
        Me.btnEliminar.ImageList = Me.ImageNuevos
        Me.btnEliminar.Location = New System.Drawing.Point(460, 289)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(60, 30)
        Me.btnEliminar.TabIndex = 10
        Me.btnEliminar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnEliminar, "Eliminar")
        Me.btnEliminar.UseVisualStyleBackColor = False
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(688, 60)
        Me.Panel1.TabIndex = 13
        '
        'frmIngresoUsuarios
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(688, 392)
        Me.Controls.Add(Me.gpGeneral)
        Me.Controls.Add(Me.gpEmpresa)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmIngresoUsuarios"
        Me.Text = "Ingreso de Permisos a Usuario para Requisiciones"
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpCentro.ResumeLayout(False)
        Me.gpCentro.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.gpGeneral.ResumeLayout(False)
        Me.gpGeneral.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Empleado"

    Private Sub BorraEmpleado(ByVal valorBool As Boolean, ByVal control As System.Object)
        If valorBool = True Then
            control.Clear()
        End If
    End Sub


    Private Function verifica_permisos(ByVal numero) As Boolean
        Dim numFilas As Int32
        Dim ffila As DataRow
        lpara.Clear()
        lpara("empresa") = empresa
        If TextEmpleado.Text <> "" And TextNombEmpleado.Text <> "" Then
            lpara("empleado") = TextEmpleado.Text
            Select Case numero
                Case 1
                    cadena = "select empleado,autorizador_nivel1,autorizador_nivel2,id_tipo_usuario from permisos_requisiciones where empleado=@empleado and empresa=@empresa"
                    numFilas = llenaTabla(cadena, tbpermisos, ListaParametros(lpara))
                    If numFilas <> 0 Then
                        ffila = tbpermisos.Rows(0)
                        lpara("empleado1") = ffila.Item("autorizador_nivel1")
                        lpara("empleado2") = ffila.Item("autorizador_nivel2")
                        cadena = "select empresa,empleado,nombre1+' '+nombre2+' '+apellido1+' '+apellido2 as nombre from emplegen where empleado=@empleado1 and empresa=@empresa"
                        If llenaTabla(cadena, tbOrigen, ListaParametros(lpara)) > 0 Then
                            TextEmpleado1.Text = ffila.Item("autorizador_nivel1")
                            TextNombEmpleado1.Text = tbOrigen.Rows(0).Item("nombre")
                        End If
                        cadena = "select empresa,empleado,nombre1+' '+nombre2+' '+apellido1+' '+apellido2 as nombre from emplegen where empleado=@empleado2 and empresa=@empresa"
                        If llenaTabla(cadena, tbOrigen, ListaParametros(lpara)) > 0 Then
                            TextEmpleado2.Text = ffila.Item("autorizador_nivel2")
                            TextNombEmpleado2.Text = tbOrigen.Rows(0).Item("nombre")
                            cmbTipoUsuario.SelectedIndex = ffila.Item("id_tipo_usuario") - 1
                            Return True

                        End If
                    Else
                        Return False
                    End If
                Case 2
                    lpara("autorizadorNivel1") = TextEmpleado1.Text
                    cadena = "select empleado,autorizador_nivel1,autorizador_nivel2,id_tipo_usuario from permisos_requisiciones " &
                             "where autorizador_nivel1=@autorizadorNivel1 or id_tipo_usuario=2 and empresa=@empresa"
                    numFilas = llenaTabla(cadena, tbpermisos, ListaParametros(lpara))
                    If numFilas <> 0 Then
                        Return True
                    Else : Return False
                    End If
                Case 3
                    lpara("autorizadorNivel2") = TextEmpleado2.Text
                    cadena = "select empleado,autorizador_nivel1,autorizador_nivel2,id_tipo_usuario from permisos_requisiciones " &
                    "where autorizador_nivel2=@autorizadorNivel2 and empresa=@empresa"
                    numFilas = llenaTabla(cadena, tbpermisos, ListaParametros(lpara))
                    If numFilas <> 0 Then
                        Return True
                    Else : Return False
                    End If

            End Select
        Else
            Exit Function
        End If

    End Function


    Private Sub btnEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = TextNombEmpleado.Text.Trim
        cadena = " select empleado,nombre from " &
                 "(select empresa, empleado,nombre1+' '+nombre2+' '+apellido1+' '+apellido2 as nombre from emplegen ) L " &
                 " where empresa=@empresa and nombre like '%' + @nombre + '%' " &
                 " and empleado not in (select distinct(autorizador_nivel2) from permisos_requisiciones) " &
                 " group by empleado,nombre order by nombre"

        numFilas = llenaTabla(cadena, tbOrigen, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN USUARIOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado(True, TextEmpleado)
            TextEmpleado.Focus()
        ElseIf numFilas = 1 Then
            filaTemp = tbOrigen.Rows.Item(0)
            TextEmpleado.Text() = filaTemp.Item("empleado")
            TextNombEmpleado.Text = filaTemp.Item("nombre")
        Else
            EnBuscaEmpleado(1)
        End If

        If verifica_permisos(1) Then
            btnEliminar.Enabled = True
        End If

    End Sub

    Private Sub btnEmpleado1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado1.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = TextNombEmpleado1.Text.Trim
        cadena = " select empleado,nombre from " &
                 "(select empresa, empleado,nombre1+' '+nombre2+' '+apellido1+' '+apellido2 as nombre from emplegen " &
                 " where  empleado  in (select empleado from permisos_requisiciones where id_tipo_usuario in (2,3))) L " &
                 " where empresa=@empresa and nombre like '%' + @nombre + '%' " &
                 " group by empleado,nombre order by nombre"

        numFilas = llenaTabla(cadena, tbOrigen, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN USUARIOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraJefe(True)
            TextEmpleado1.Focus()
        ElseIf numFilas = 1 Then
            filaTemp = tbOrigen.Rows.Item(0)
            TextEmpleado1.Text() = filaTemp.Item("empleado")
            TextNombEmpleado1.Text = filaTemp.Item("nombre")
        Else
            EnBuscaEmpleado(2)
        End If
    End Sub


    Private Sub btnEmpleado2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado2.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = TextNombEmpleado2.Text.Trim
        cadena = " select empleado,nombre from " &
                 "(select empresa, empleado,nombre1+' '+nombre2+' '+apellido1+' '+apellido2 as nombre from emplegen " &
                 " where  empleado in (select empleado from permisos_requisiciones where id_tipo_usuario=3)) L " &
                 " where empresa=@empresa and nombre like '%' + @nombre + '%' " &
                 " group by empleado,nombre order by nombre"

        numFilas = llenaTabla(cadena, tbOrigen, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN USUARIOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraJefeSuperior(True)
            TextEmpleado2.Focus()
        ElseIf numFilas = 1 Then
            filaTemp = tbOrigen.Rows.Item(0)
            TextEmpleado2.Text() = filaTemp.Item("empleado")
            TextNombEmpleado2.Text = filaTemp.Item("nombre")
        Else
            EnBuscaEmpleado(3)
        End If
    End Sub

    Private Sub EnBuscaEmpleado(ByVal numero)
        fOrig = New frmMuestraUsuarios
        fOrig.TopMost = True
        fOrig.inicializa(tbOrigen, numero)
        AddHandler fOrig.actValor, AddressOf ActualizacionDatosOrigen
        fOrig.StartPosition = FormStartPosition.CenterScreen
        fOrig.ShowDialog()
    End Sub



    Private Sub ActualizacionDatosOrigen(ByVal sender As Object, ByVal e As clsActValorREvento)
        'BorraOrigen(True)
        filaTemp = tbOrigen.Rows.Item(e.va2)
        Select Case Trim(e.va1)
            Case "1"
                TextEmpleado.Text() = filaTemp.Item(0)
                TextNombEmpleado.Text = filaTemp.Item(1)
            Case "2"
                TextEmpleado1.Text() = filaTemp.Item(0)
                TextNombEmpleado1.Text = filaTemp.Item(1)
            Case "3"
                TextEmpleado2.Text() = filaTemp.Item(0)
                TextNombEmpleado2.Text = filaTemp.Item(1)

        End Select
        'Textsolicitante.Focus()
    End Sub

    Private Sub ValidaEmpleado(ByVal control As System.Object)
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = control.Text.Trim
        If valida_tipo_Entero(control.Text, 2) = True Then
            If BuscaEscalar("select count (*) from emplegen where empresa=@empresa and empleado=@empleado", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True, control)
                control.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre1+' '+nombre2+' '+apellido1+' '+apellido2  as nombre " &
                     "from emplegen where empresa=@empresa and empleado=@empleado "
            If LCase(Trim(control.name)) = "textempleado" Then

                cadena = cadena & " and empleado not in (select distinct(autorizador_nivel2) from permisos_requisiciones)"
            End If
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraEmpleado(False, control)
                dr.Read()

                Select Case LCase(Trim(control.name))
                    Case "textempleado"
                        TextNombEmpleado.Text = dr.GetValue(1)

                    Case "textempleado1"
                        TextNombEmpleado1.Text = dr.GetValue(1)
                    Case "textempleado2"
                        TextNombEmpleado2.Text = dr.GetValue(1)

                End Select

                dr.Close()
                cn.Close()
                verifica_permisos(1)
                btnEliminar.Enabled = True
                'cmbTipoUsuario.Focus()
            Else
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL EMPLEADO POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraEmpleado(True, control)
            control.Focus()
        End If
    End Sub

    Private Sub TextEmpleado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextEmpleado.Validated
        If TextEmpleado.Text.Trim <> "" Then
            ValidaEmpleado(TextEmpleado)
        Else
            BorraEmpleado(False, TextEmpleado)
        End If
    End Sub
    Private Sub TextEmpleado1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextEmpleado1.Validated
        If TextEmpleado1.Text.Trim <> "" Then
            ValidaEmpleado(TextEmpleado1)
        Else
            BorraEmpleado(False, TextEmpleado1)
        End If
    End Sub
    Private Sub TextEmpleado2_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextEmpleado2.Validated
        If TextEmpleado2.Text.Trim <> "" Then
            ValidaEmpleado(TextEmpleado2)
        Else
            BorraEmpleado(False, TextEmpleado2)
        End If
    End Sub

#End Region


    Private Sub limpia()
        opcModi = 0
        cmbTipoUsuario.SelectedIndex = -1
        BorraEmpleado(True, TextEmpleado)
        BorraEmpleado(True, TextEmpleado1)
        BorraEmpleado(True, TextEmpleado2)
        BorraEmpleado(True, TextNombEmpleado)
        BorraEmpleado(True, TextNombEmpleado1)
        BorraEmpleado(True, TextNombEmpleado2)
        BtnSave.Enabled = False
        TextEmpleado.Focus()
        BtnSave.Enabled = True
        btnEliminar.Enabled = False

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpia()
    End Sub

    Private Sub frmIngresoUsuarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        cadena = "select nombre from empresas where empresa=@empresa"
        TextNombEmpresa.Text = BuscaEscalar(cadena, ListaParametros(lpara))
        Me.KeyPreview = True
        btnLimpiar_Click(sender, e)
        cadena = "select upper(nom_tipo_usuario),id_tipo_usuario from tipo_usuario order by id_tipo_usuario asc"
        llena_combo(cadena, cmbTipoUsuario)
        llenaTabla(cadena, tbtipousuario)
    End Sub

    Private Function verifica_usuario() As Integer
        lpara.Clear()
        lpara("empleado") = TextEmpleado.Text
        '(1) usuario (2) autorizador1 (3) autorizador2
        Dim contador As Integer
        cadena = "select count(empleado) from permisos_requisiciones  where empleado=@empleado"
        contador = BuscaEscalar(cadena, ListaParametros(lpara))
        Return contador

    End Function



    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Dim cadena2 As String
        lpara.Clear()
        If validetError(TextEmpleado2, ep1) = False And validetError(TextNombEmpleado2, ep1) = False Or _
           validetError(TextEmpleado, ep1) = False And validetError(TextNombEmpleado, ep1) = False Or _
           validetError(cmbTipoUsuario, ep1) = False Then
            Exit Sub
        End If

        ' si no ingreso autorizador1 por defecto es 0 
        If TextEmpleado1.Text = "" Then
            TextEmpleado1.Text = "0"
        End If
        lpara("empresa") = empresa
        lpara("empleado") = TextEmpleado.Text
        lpara("autorizador1") = TextEmpleado1.Text
        lpara("autorizador2") = TextEmpleado2.Text
        lpara("usuario") = tbtipousuario.Rows(cmbTipoUsuario.SelectedIndex).Item("id_tipo_usuario")
        If verifica_usuario() = 0 Then 'es nuevo
            cadena = "insert into permisos_requisiciones(empresa,empleado,autorizador_nivel1,autorizador_nivel2,id_tipo_usuario)" &
                     " values(@empresa,@empleado,@autorizador1,@autorizador2,@usuario)"

            EjecutarQuery(cadena, ListaParametros(lpara))
            MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            limpia()
        ElseIf verifica_usuario() > 0 Then

            'si no si es modificacion

            cadena2 = "update permisos_requisiciones set empresa=@empresa, empleado=@empleado," &
                     " autorizador_nivel1=@autorizador1," &
                     " autorizador_nivel2=@autorizador2, id_tipo_usuario=@usuario " &
                     " where empleado = @empleado and empresa=@emprea "

            EjecutarQuery(cadena2, ListaParametros(lpara))
            MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            limpia()

        End If

    End Sub
    Function BuscaEmpleado(ByVal nombre As String, ByVal tbtemp As DataTable) As Integer
        Dim i As Integer
        For i = 0 To tbAutoriza1.Rows.Count

            If tbtemp.Rows.Item(i).ItemArray(0) = nombre Then
                BuscaEmpleado = tbtemp.Rows.Item(i).ItemArray(1)
                Exit Function
            End If
        Next
        BuscaEmpleado = 0

    End Function


    Private Sub BorraJefe(ByVal valorBool As Boolean)
        TextNombEmpleado1.Clear()
        If valorBool = True Then
            TextEmpleado.Clear()
        End If
    End Sub

    Private Sub BorraJefeSuperior(ByVal valorBool As Boolean)
        TextNombEmpleado1.Clear()
        If valorBool = True Then
            TextEmpleado.Clear()
        End If
    End Sub

    Private Function verifica_eliminacion() As Boolean
        Dim contador As Integer
        lpara.Clear()
        lpara("empleado") = TextEmpleado.Text
        cadena = "select count(*) from permisos_requisiciones where empleado=@empleado and " &
                 " ((select count(*) from permisos_requisiciones where autorizador_nivel1=@empleado) < 1 and" &
                 " (select count(*) from permisos_requisiciones where autorizador_nivel2=@empleado) < 1)"
        contador = BuscaEscalar(cadena, ListaParametros(lpara))
        If contador > 0 Then
            verifica_eliminacion = True
        Else
            verifica_eliminacion = False
        End If

    End Function

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        lpara.Clear()
        lpara("empleado") = TextEmpleado.Text
        If verifica_eliminacion() Then
            cadena = "Delete permisos_requisiciones  where empleado=@empleado"
            EjecutarQuery(cadena, ListaParametros(lpara))
            limpia()
            MsgBox("OPERACIÓN REALIZADA CON ÉXITO", MsgBoxStyle.Information, " Mensaje del Sistema")
        Else
            MsgBox("N0 SE PUEDE ELIMINAR ESTE USUARIO ES AUTORIZADOR CON DEPENDENCIAS", MsgBoxStyle.Critical, "Mensaje del Sistema")
            limpia()
        End If
    End Sub


    Private Sub cmbTipoUsuario_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoUsuario.SelectedIndexChanged
        Dim indice As Int16
        Dim dato As Int32
        indice = cmbTipoUsuario.SelectedIndex
        lpara.Clear()
        lpara("empleado") = TextEmpleado.Text
        cadena = "select count(*) from permisos_requisiciones where autorizador_nivel1=@empleado"
        dato = BuscaEscalar(cadena, ListaParametros(lpara))
        If dato <> 0 And (indice = 0 Or indice = 2) Then
            MsgBox(" EL USUARIO TIENE DEPENDENCIAS COMO AUTORIZADOR, PRIMERO DEBE QUITARLO COMO AUTORIZADOR EN LOS USUARIOS DEPENDIENTES", MsgBoxStyle.Information, "Mensaje del Sistema")
            cmbTipoUsuario.SelectedIndex = 1
            Exit Sub
        End If
    End Sub
End Class

