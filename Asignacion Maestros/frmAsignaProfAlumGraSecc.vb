Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json

Public Class frmAsignaProfAlumGraSecc
    Inherits Form
    Dim tbTransac As New DataTable("transacciones")
    Dim tablaAlumnos As New DataTable("alumnos")
    Dim tablaAlumnos2 As New DataTable("alumnos2")
    Dim tbMaestros As New DataTable("maestros")
    Dim tbAlumnosCiclo As New DataTable()
    Dim tbMaestrosA As DataTable
    Dim dc As DataColumn
    Dim fechaHoy As Date
    Dim cadena, EsCuota As String
    Dim comando As SqlCommand
    Dim da As SqlDataAdapter
    Dim dr As SqlDataReader

    Dim NumeroClase As Int16

    Dim cadeNota As String
    'Dim WithEvents fImprimir As frmImpresionNotas
    'Dim WithEvents fTranc As frmMuestraTransaccion
    Dim filaTemp As DataRow
    Dim tbColegio As New DataTable("colegio")
    Dim tbnivel As New DataTable("nivel")
    Dim tbgrado As New DataTable("grado")
    Dim tbTipotest As New DataTable("tipotest")
    Dim tempMaestro As DataRow
    Dim tempAlumno As DataRow
    Dim lpara As New Dictionary(Of String, Object)
    Dim wsCliente As soapMoodle.wsMoodleSoapClient
    Dim wsAuth As soapMoodle.AuthUser
    Friend WithEvents btnMarcarMa As Button
    Friend WithEvents btnDesmarMa As Button
    Friend WithEvents btnDesmarAlu As Button
    Friend WithEvents btnMarcarAlu As Button
    Dim BoleanAlumno As Boolean




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
    Friend WithEvents ImageNuevo As System.Windows.Forms.ImageList
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgMaestrosA As System.Windows.Forms.DataGridView
    Friend WithEvents dgMaestros As System.Windows.Forms.DataGridView
    Friend WithEvents dgAlumno As System.Windows.Forms.DataGridView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents textCiclo As System.Windows.Forms.TextBox
    Friend WithEvents gbDatos As System.Windows.Forms.Panel
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbSeccion As System.Windows.Forms.ComboBox
    Friend WithEvents cmbJornada As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbGrado As System.Windows.Forms.ComboBox
    Friend WithEvents cmbNivel As System.Windows.Forms.ComboBox
    Friend WithEvents cmbOpcion As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents acFecha As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents TextColegio As System.Windows.Forms.TextBox
    Friend WithEvents TextNivel As System.Windows.Forms.TextBox
    Friend WithEvents TextGrado As System.Windows.Forms.TextBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnlimpia As System.Windows.Forms.Button
    Friend WithEvents gbaquien As System.Windows.Forms.GroupBox
    Friend WithEvents txtN As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents cmbTipoTest As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dgvAlumnosAsign As System.Windows.Forms.DataGridView
    Friend WithEvents ctxMenu As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxEliminar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents gpN As Panel
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents btnguardar As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Label12 As Label
    Friend WithEvents txtCountAlu As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents txtCountAluA As TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignaProfAlumGraSecc))
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.textCiclo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cmbTipoTest = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgMaestrosA = New System.Windows.Forms.DataGridView()
        Me.ctxMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxEliminar = New System.Windows.Forms.ToolStripMenuItem()
        Me.dgMaestros = New System.Windows.Forms.DataGridView()
        Me.gbaquien = New System.Windows.Forms.GroupBox()
        Me.gpN = New System.Windows.Forms.Panel()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.txtN = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbOpcion = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.btnlimpia = New System.Windows.Forms.Button()
        Me.ImageNuevo = New System.Windows.Forms.ImageList(Me.components)
        Me.gbDatos = New System.Windows.Forms.Panel()
        Me.TextGrado = New System.Windows.Forms.TextBox()
        Me.TextNivel = New System.Windows.Forms.TextBox()
        Me.TextColegio = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbSeccion = New System.Windows.Forms.ComboBox()
        Me.cmbJornada = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbGrado = New System.Windows.Forms.ComboBox()
        Me.cmbNivel = New System.Windows.Forms.ComboBox()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.acFecha = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnguardar = New System.Windows.Forms.Button()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.dgAlumno = New System.Windows.Forms.DataGridView()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dgvAlumnosAsign = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.btnDesmarAlu = New System.Windows.Forms.Button()
        Me.btnMarcarAlu = New System.Windows.Forms.Button()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtCountAlu = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCountAluA = New System.Windows.Forms.TextBox()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnDesmarMa = New System.Windows.Forms.Button()
        Me.btnMarcarMa = New System.Windows.Forms.Button()
        CType(Me.dgMaestrosA, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu.SuspendLayout()
        CType(Me.dgMaestros, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbaquien.SuspendLayout()
        Me.gpN.SuspendLayout()
        Me.gbDatos.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgAlumno, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAlumnosAsign, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel5.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(419, 19)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 13)
        Me.Label9.TabIndex = 64
        Me.Label9.Text = "Ciclo:"
        '
        'textCiclo
        '
        Me.textCiclo.BackColor = System.Drawing.Color.White
        Me.textCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textCiclo.Location = New System.Drawing.Point(461, 16)
        Me.textCiclo.MaxLength = 4
        Me.textCiclo.Name = "textCiclo"
        Me.textCiclo.Size = New System.Drawing.Size(48, 20)
        Me.textCiclo.TabIndex = 0
        Me.textCiclo.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(3, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Evaluación:"
        '
        'cmbTipoTest
        '
        Me.cmbTipoTest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoTest.Location = New System.Drawing.Point(79, 15)
        Me.cmbTipoTest.Name = "cmbTipoTest"
        Me.cmbTipoTest.Size = New System.Drawing.Size(335, 21)
        Me.cmbTipoTest.TabIndex = 68
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(5, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 13)
        Me.Label4.TabIndex = 109
        Me.Label4.Text = "Maestros Asignados"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "Maestros Disponibles"
        '
        'dgMaestrosA
        '
        Me.dgMaestrosA.AllowUserToAddRows = False
        Me.dgMaestrosA.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgMaestrosA.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgMaestrosA.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgMaestrosA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgMaestrosA.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgMaestrosA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMaestrosA.ContextMenuStrip = Me.ctxMenu
        Me.dgMaestrosA.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgMaestrosA.Location = New System.Drawing.Point(6, 23)
        Me.dgMaestrosA.MultiSelect = False
        Me.dgMaestrosA.Name = "dgMaestrosA"
        Me.dgMaestrosA.ReadOnly = True
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgMaestrosA.RowsDefaultCellStyle = DataGridViewCellStyle8
        Me.dgMaestrosA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMaestrosA.Size = New System.Drawing.Size(535, 183)
        Me.dgMaestrosA.TabIndex = 107
        '
        'ctxMenu
        '
        Me.ctxMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxEliminar})
        Me.ctxMenu.Name = "ctxMenu"
        Me.ctxMenu.Size = New System.Drawing.Size(118, 26)
        '
        'ctxEliminar
        '
        Me.ctxEliminar.Name = "ctxEliminar"
        Me.ctxEliminar.Size = New System.Drawing.Size(117, 22)
        Me.ctxEliminar.Text = "Eliminar"
        '
        'dgMaestros
        '
        Me.dgMaestros.AllowUserToAddRows = False
        Me.dgMaestros.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgMaestros.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgMaestros.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgMaestros.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgMaestros.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgMaestros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgMaestros.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgMaestros.Location = New System.Drawing.Point(6, 25)
        Me.dgMaestros.MultiSelect = False
        Me.dgMaestros.Name = "dgMaestros"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgMaestros.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgMaestros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgMaestros.Size = New System.Drawing.Size(535, 177)
        Me.dgMaestros.TabIndex = 106
        '
        'gbaquien
        '
        Me.gbaquien.Controls.Add(Me.gpN)
        Me.gbaquien.Controls.Add(Me.cmbOpcion)
        Me.gbaquien.Controls.Add(Me.Label10)
        Me.gbaquien.Location = New System.Drawing.Point(2, 62)
        Me.gbaquien.Name = "gbaquien"
        Me.gbaquien.Size = New System.Drawing.Size(552, 41)
        Me.gbaquien.TabIndex = 65
        Me.gbaquien.TabStop = False
        '
        'gpN
        '
        Me.gpN.Controls.Add(Me.btnOK)
        Me.gpN.Controls.Add(Me.txtN)
        Me.gpN.Controls.Add(Me.Label2)
        Me.gpN.Location = New System.Drawing.Point(245, 13)
        Me.gpN.Name = "gpN"
        Me.gpN.Size = New System.Drawing.Size(133, 25)
        Me.gpN.TabIndex = 116
        '
        'btnOK
        '
        Me.btnOK.BackColor = System.Drawing.SystemColors.Control
        Me.btnOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOK.Location = New System.Drawing.Point(90, 1)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(32, 23)
        Me.btnOK.TabIndex = 62
        Me.btnOK.Text = "Ok"
        Me.btnOK.UseVisualStyleBackColor = False
        '
        'txtN
        '
        Me.txtN.BackColor = System.Drawing.Color.White
        Me.txtN.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtN.Location = New System.Drawing.Point(36, 3)
        Me.txtN.MaxLength = 4
        Me.txtN.Name = "txtN"
        Me.txtN.Size = New System.Drawing.Size(48, 20)
        Me.txtN.TabIndex = 37
        Me.txtN.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(3, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(27, 13)
        Me.Label2.TabIndex = 61
        Me.Label2.Text = "N ="
        '
        'cmbOpcion
        '
        Me.cmbOpcion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbOpcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbOpcion.Items.AddRange(New Object() {"TODOS LOS ALUMNOS", "PARES DE LA SECCION", "IMPARES DE LA SECCION", "ESCOGER ALUMNO", "CLAVE <= N", "CLAVE > N", ""})
        Me.cmbOpcion.Location = New System.Drawing.Point(90, 15)
        Me.cmbOpcion.Name = "cmbOpcion"
        Me.cmbOpcion.Size = New System.Drawing.Size(144, 21)
        Me.cmbOpcion.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(6, 19)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(57, 13)
        Me.Label10.TabIndex = 61
        Me.Label10.Text = "A quienes:"
        '
        'btnlimpia
        '
        Me.btnlimpia.BackColor = System.Drawing.SystemColors.Control
        Me.btnlimpia.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnlimpia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlimpia.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlimpia.ImageIndex = 3
        Me.btnlimpia.ImageList = Me.ImageNuevo
        Me.btnlimpia.Location = New System.Drawing.Point(1046, 5)
        Me.btnlimpia.Name = "btnlimpia"
        Me.btnlimpia.Size = New System.Drawing.Size(80, 30)
        Me.btnlimpia.TabIndex = 63
        Me.btnlimpia.TabStop = False
        Me.btnlimpia.Text = "Limpiar"
        Me.btnlimpia.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnlimpia, "Limpiar forma")
        Me.btnlimpia.UseVisualStyleBackColor = False
        '
        'ImageNuevo
        '
        Me.ImageNuevo.ImageStream = CType(resources.GetObject("ImageNuevo.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageNuevo.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageNuevo.Images.SetKeyName(0, "buscar2.png")
        Me.ImageNuevo.Images.SetKeyName(1, "cancelar.png")
        Me.ImageNuevo.Images.SetKeyName(2, "guardar.png")
        Me.ImageNuevo.Images.SetKeyName(3, "limpiar.png")
        Me.ImageNuevo.Images.SetKeyName(4, "asignar1.png")
        '
        'gbDatos
        '
        Me.gbDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.gbDatos.Controls.Add(Me.TextGrado)
        Me.gbDatos.Controls.Add(Me.TextNivel)
        Me.gbDatos.Controls.Add(Me.TextColegio)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Controls.Add(Me.cmbSeccion)
        Me.gbDatos.Controls.Add(Me.cmbJornada)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.Label26)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.cmbGrado)
        Me.gbDatos.Controls.Add(Me.cmbNivel)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.Location = New System.Drawing.Point(560, 3)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(486, 87)
        Me.gbDatos.TabIndex = 4
        Me.gbDatos.TabStop = False
        '
        'TextGrado
        '
        Me.TextGrado.BackColor = System.Drawing.Color.White
        Me.TextGrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextGrado.Location = New System.Drawing.Point(104, 60)
        Me.TextGrado.MaxLength = 60
        Me.TextGrado.Name = "TextGrado"
        Me.TextGrado.Size = New System.Drawing.Size(232, 20)
        Me.TextGrado.TabIndex = 36
        '
        'TextNivel
        '
        Me.TextNivel.BackColor = System.Drawing.Color.White
        Me.TextNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNivel.Location = New System.Drawing.Point(104, 36)
        Me.TextNivel.MaxLength = 60
        Me.TextNivel.Name = "TextNivel"
        Me.TextNivel.Size = New System.Drawing.Size(312, 20)
        Me.TextNivel.TabIndex = 35
        '
        'TextColegio
        '
        Me.TextColegio.BackColor = System.Drawing.Color.White
        Me.TextColegio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextColegio.Location = New System.Drawing.Point(104, 12)
        Me.TextColegio.MaxLength = 60
        Me.TextColegio.Name = "TextColegio"
        Me.TextColegio.Size = New System.Drawing.Size(312, 20)
        Me.TextColegio.TabIndex = 34
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(352, 63)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(49, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Sección:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmbSeccion
        '
        Me.cmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSeccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSeccion.Location = New System.Drawing.Point(439, 59)
        Me.cmbSeccion.Name = "cmbSeccion"
        Me.cmbSeccion.Size = New System.Drawing.Size(40, 21)
        Me.cmbSeccion.TabIndex = 4
        '
        'cmbJornada
        '
        Me.cmbJornada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJornada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbJornada.Items.AddRange(New Object() {"M", "V"})
        Me.cmbJornada.Location = New System.Drawing.Point(56, 12)
        Me.cmbJornada.Name = "cmbJornada"
        Me.cmbJornada.Size = New System.Drawing.Size(40, 21)
        Me.cmbJornada.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(7, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Colegio:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Black
        Me.Label26.Location = New System.Drawing.Point(7, 40)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(34, 13)
        Me.Label26.TabIndex = 30
        Me.Label26.Text = "Nivel:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.Black
        Me.Label7.Location = New System.Drawing.Point(7, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 13)
        Me.Label7.TabIndex = 29
        Me.Label7.Text = "Grado:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbGrado
        '
        Me.cmbGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrado.Location = New System.Drawing.Point(56, 60)
        Me.cmbGrado.Name = "cmbGrado"
        Me.cmbGrado.Size = New System.Drawing.Size(40, 21)
        Me.cmbGrado.TabIndex = 3
        '
        'cmbNivel
        '
        Me.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNivel.Items.AddRange(New Object() {"K", "P", "S"})
        Me.cmbNivel.Location = New System.Drawing.Point(56, 36)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(40, 21)
        Me.cmbNivel.TabIndex = 2
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "")
        Me.ImageList1.Images.SetKeyName(1, "")
        '
        'acFecha
        '
        Me.acFecha.Location = New System.Drawing.Point(16, 16)
        Me.acFecha.Name = "acFecha"
        Me.acFecha.Size = New System.Drawing.Size(100, 20)
        Me.acFecha.TabIndex = 3
        '
        'btnguardar
        '
        Me.btnguardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnguardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnguardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnguardar.ImageIndex = 2
        Me.btnguardar.ImageList = Me.ImageNuevo
        Me.btnguardar.Location = New System.Drawing.Point(1046, 89)
        Me.btnguardar.Name = "btnguardar"
        Me.btnguardar.Size = New System.Drawing.Size(80, 30)
        Me.btnguardar.TabIndex = 7
        Me.btnguardar.Text = "Guardar"
        Me.btnguardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnguardar, "Guardar Nota(s)")
        Me.btnguardar.UseVisualStyleBackColor = False
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'dgAlumno
        '
        Me.dgAlumno.AllowUserToAddRows = False
        Me.dgAlumno.AllowUserToDeleteRows = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.LightGreen
        Me.dgAlumno.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dgAlumno.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgAlumno.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgAlumno.BackgroundColor = System.Drawing.Color.White
        Me.dgAlumno.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgAlumno.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgAlumno.Location = New System.Drawing.Point(6, 25)
        Me.dgAlumno.MultiSelect = False
        Me.dgAlumno.Name = "dgAlumno"
        Me.dgAlumno.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgAlumno.Size = New System.Drawing.Size(535, 178)
        Me.dgAlumno.TabIndex = 107
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.Black
        Me.Label8.Location = New System.Drawing.Point(8, 7)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 13)
        Me.Label8.TabIndex = 110
        Me.Label8.Text = "Alumnos Disponibles"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(3, 7)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 13)
        Me.Label11.TabIndex = 112
        Me.Label11.Text = "Alumnos Asignados"
        '
        'dgvAlumnosAsign
        '
        Me.dgvAlumnosAsign.AllowUserToAddRows = False
        Me.dgvAlumnosAsign.AllowUserToDeleteRows = False
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.dgvAlumnosAsign.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvAlumnosAsign.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvAlumnosAsign.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvAlumnosAsign.BackgroundColor = System.Drawing.Color.White
        Me.dgvAlumnosAsign.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlumnosAsign.GridColor = System.Drawing.Color.White
        Me.dgvAlumnosAsign.Location = New System.Drawing.Point(6, 24)
        Me.dgvAlumnosAsign.MultiSelect = False
        Me.dgvAlumnosAsign.Name = "dgvAlumnosAsign"
        Me.dgvAlumnosAsign.ReadOnly = True
        Me.dgvAlumnosAsign.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAlumnosAsign.Size = New System.Drawing.Size(535, 183)
        Me.dgvAlumnosAsign.TabIndex = 111
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(61, Byte), Integer), CType(CType(114, Byte), Integer), CType(CType(186, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.cmbTipoTest)
        Me.Panel1.Controls.Add(Me.textCiclo)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(2, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(545, 47)
        Me.Panel1.TabIndex = 113
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Size = New System.Drawing.Size(226, 157)
        Me.SplitContainer2.SplitterDistance = 196
        Me.SplitContainer2.TabIndex = 0
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Panel5, 1, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel6, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel7, 1, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.Panel4, 0, 0)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(2, 129)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1127, 475)
        Me.TableLayoutPanel1.TabIndex = 116
        '
        'Panel5
        '
        Me.Panel5.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.Panel5.Controls.Add(Me.btnDesmarAlu)
        Me.Panel5.Controls.Add(Me.btnMarcarAlu)
        Me.Panel5.Controls.Add(Me.Label12)
        Me.Panel5.Controls.Add(Me.txtCountAlu)
        Me.Panel5.Controls.Add(Me.Label8)
        Me.Panel5.Controls.Add(Me.dgAlumno)
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel5.Location = New System.Drawing.Point(566, 3)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(558, 231)
        Me.Panel5.TabIndex = 1
        '
        'btnDesmarAlu
        '
        Me.btnDesmarAlu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDesmarAlu.BackColor = System.Drawing.SystemColors.Control
        Me.btnDesmarAlu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesmarAlu.Location = New System.Drawing.Point(355, 206)
        Me.btnDesmarAlu.Name = "btnDesmarAlu"
        Me.btnDesmarAlu.Size = New System.Drawing.Size(83, 23)
        Me.btnDesmarAlu.TabIndex = 114
        Me.btnDesmarAlu.Text = "Desmarcar"
        Me.btnDesmarAlu.UseVisualStyleBackColor = False
        '
        'btnMarcarAlu
        '
        Me.btnMarcarAlu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMarcarAlu.BackColor = System.Drawing.SystemColors.Control
        Me.btnMarcarAlu.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMarcarAlu.Location = New System.Drawing.Point(458, 206)
        Me.btnMarcarAlu.Name = "btnMarcarAlu"
        Me.btnMarcarAlu.Size = New System.Drawing.Size(83, 23)
        Me.btnMarcarAlu.TabIndex = 113
        Me.btnMarcarAlu.Text = "Marcar "
        Me.btnMarcarAlu.UseVisualStyleBackColor = False
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 212)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 112
        Me.Label12.Text = "Total"
        '
        'txtCountAlu
        '
        Me.txtCountAlu.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCountAlu.Location = New System.Drawing.Point(75, 209)
        Me.txtCountAlu.Name = "txtCountAlu"
        Me.txtCountAlu.ReadOnly = True
        Me.txtCountAlu.Size = New System.Drawing.Size(100, 20)
        Me.txtCountAlu.TabIndex = 111
        '
        'Panel6
        '
        Me.Panel6.BackColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.Panel6.Controls.Add(Me.dgMaestrosA)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel6.Location = New System.Drawing.Point(3, 240)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(557, 232)
        Me.Panel6.TabIndex = 2
        '
        'Panel7
        '
        Me.Panel7.BackColor = System.Drawing.Color.FromArgb(CType(CType(126, Byte), Integer), CType(CType(172, Byte), Integer), CType(CType(237, Byte), Integer))
        Me.Panel7.Controls.Add(Me.Label13)
        Me.Panel7.Controls.Add(Me.txtCountAluA)
        Me.Panel7.Controls.Add(Me.dgvAlumnosAsign)
        Me.Panel7.Controls.Add(Me.Label11)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(566, 240)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(558, 232)
        Me.Panel7.TabIndex = 3
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(8, 214)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 114
        Me.Label13.Text = "Total"
        '
        'txtCountAluA
        '
        Me.txtCountAluA.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtCountAluA.Location = New System.Drawing.Point(75, 210)
        Me.txtCountAluA.Name = "txtCountAluA"
        Me.txtCountAluA.ReadOnly = True
        Me.txtCountAluA.Size = New System.Drawing.Size(100, 20)
        Me.txtCountAluA.TabIndex = 113
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.FromArgb(CType(CType(221, Byte), Integer), CType(CType(234, Byte), Integer), CType(CType(252, Byte), Integer))
        Me.Panel4.Controls.Add(Me.btnDesmarMa)
        Me.Panel4.Controls.Add(Me.btnMarcarMa)
        Me.Panel4.Controls.Add(Me.dgMaestros)
        Me.Panel4.Controls.Add(Me.Label1)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel4.Location = New System.Drawing.Point(3, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(557, 231)
        Me.Panel4.TabIndex = 0
        '
        'btnDesmarMa
        '
        Me.btnDesmarMa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDesmarMa.BackColor = System.Drawing.SystemColors.Control
        Me.btnDesmarMa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDesmarMa.Location = New System.Drawing.Point(355, 205)
        Me.btnDesmarMa.Name = "btnDesmarMa"
        Me.btnDesmarMa.Size = New System.Drawing.Size(83, 23)
        Me.btnDesmarMa.TabIndex = 110
        Me.btnDesmarMa.Text = "Desmarcar"
        Me.btnDesmarMa.UseVisualStyleBackColor = False
        '
        'btnMarcarMa
        '
        Me.btnMarcarMa.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMarcarMa.BackColor = System.Drawing.SystemColors.Control
        Me.btnMarcarMa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMarcarMa.Location = New System.Drawing.Point(458, 205)
        Me.btnMarcarMa.Name = "btnMarcarMa"
        Me.btnMarcarMa.Size = New System.Drawing.Size(83, 23)
        Me.btnMarcarMa.TabIndex = 109
        Me.btnMarcarMa.Text = "Marcar "
        Me.btnMarcarMa.UseVisualStyleBackColor = False
        '
        'frmAsignaProfAlumGraSecc
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.btnguardar)
        Me.Controls.Add(Me.btnlimpia)
        Me.Controls.Add(Me.gbaquien)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.gbDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmAsignaProfAlumGraSecc"
        Me.Text = "Asignación de Maestros para Evaluación de Alumnos"
        CType(Me.dgMaestrosA, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu.ResumeLayout(False)
        CType(Me.dgMaestros, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbaquien.ResumeLayout(False)
        Me.gbaquien.PerformLayout()
        Me.gpN.ResumeLayout(False)
        Me.gpN.PerformLayout()
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgAlumno, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAlumnosAsign, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel5.ResumeLayout(False)
        Me.Panel5.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmAsignaProfAlumGraSecc_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        textCiclo.Text = System.DateTime.Today.Year
        cadena = "select distinct colegio, nombre from Colegios"
        llena_combo(cadena, cmbJornada)
        llenaTabla(cadena, tbColegio)
        cmbJornada.Items.Add("")
        wsCliente = New soapMoodle.wsMoodleSoapClient()
        wsAuth = New soapMoodle.AuthUser()
        wsAuth.UserName = _wsCliente
        wsAuth.Password = _wsPass
        textCiclo_Validated(sender, e)
        'btnBuscar.Visible = False
        'gbaquien.Visible = False
        btnlimpia_Click(sender, e)
    End Sub

    Private Function formato(ByVal numformato As Decimal) As String
        Return Format(numformato, "#,##0.00")
    End Function


#Region "vistas"
    Private Sub vista_alumnos(ByVal dgv As DataGridView)
        With dgv
            .Columns("clave").FillWeight = 10
            .Columns("clave").ReadOnly = True
            .Columns("clave").HeaderText = "Clave"
            .Columns("nombre").FillWeight = 65
            .Columns("nombre").ReadOnly = True
            .Columns("nombre").HeaderText = "Nombre"
            .Columns("num_alumno").FillWeight = 15
            .Columns("num_alumno").ReadOnly = True
            .Columns("num_alumno").HeaderText = "Cod. Alu."
            .Columns("aplicar").HeaderText = "Aplicación"
            .Columns("aplicar").ReadOnly = False
            .Columns("aplicar").FillWeight = 10

        End With
        'define la forma como la tabla sera presentada dentro del formulario

    End Sub

    Private Sub vista_profesor(ByVal dgv As DataGridView)

        With dgv
            .Columns("codigo").Visible = False
            .Columns("nombre").FillWeight = 45
            .Columns("nombre").ReadOnly = True
            .Columns("nombre").HeaderText = "Nombre maestro"
            .Columns("nombre_materia").FillWeight = 40
            .Columns("nombre_materia").ReadOnly = True
            .Columns("nombre_materia").HeaderText = "Materia"
            .Columns("aplicar").FillWeight = 15
            .Columns("aplicar").HeaderText = "Aplicación"
            .Columns("aplicar").ReadOnly = False
            .Columns("mdlcourse_id").Visible = False
        End With
        'define la forma como la tabla sera presentada dentro del formulario

    End Sub


    Private Sub vista_profesorA(ByVal dgv As DataGridView)

        With dgv
            .Columns("codigo").Visible = False
            .Columns("nombre").FillWeight = 85
            .Columns("nombre").ReadOnly = True
            .Columns("nombre").HeaderText = "Nombre maestro"
        End With
        'define la forma como la tabla sera presentada dentro del formulario

    End Sub

#End Region

#Region "Cambio de Indices en los Combos"
    Private Sub cmbJornada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJornada.SelectedIndexChanged
        TextColegio.Text = ""
        TextNivel.Text = ""
        cmbNivel.Items.Clear()
        TextGrado.Text = ""
        cmbGrado.Items.Clear()
        cmbSeccion.Items.Clear()
        deshabilita()
        If cmbJornada.Text.Trim <> "" Then
            ' Combos_Disponibles(True, 0)
            TextColegio.Text = tbColegio.Rows.Item(cmbJornada.SelectedIndex).Item(1)
            cadena = "SELECT DISTINCT NIVEL, nombre FROM NIVELES WHERE COLEGIO='" & cmbJornada.Text & "'"
            llena_combo(cadena, cmbNivel)
            llenaTabla(cadena, tbnivel)
            cmbNivel.Focus()
        End If
    End Sub

    Private Sub cmbNivel_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbNivel.SelectedIndexChanged
        TextNivel.Text = ""
        TextGrado.Text = ""
        cmbGrado.Items.Clear()
        cmbSeccion.Items.Clear()
        deshabilita()
        Dim habilitaAsign As Boolean = True
        If cmbNivel.Text.Trim <> "" Then
            TextNivel.Text = tbnivel.Rows.Item(cmbNivel.SelectedIndex).Item(1)
            cadena = "SELECT DISTINCT GRADO, nombre FROM GRADOS WHERE COLEGIO='" & cmbJornada.Text & "' AND NIVEL='" & cmbNivel.Text & "'"
            llena_combo(cadena, cmbGrado)
            llenaTabla(cadena, tbgrado)
            cmbGrado.Focus()
            If cmbNivel.Text = "Y" Or cmbNivel.Text = "Z" Then
                habilitaAsign = False
            End If
        End If
        btnMarcarMa.Enabled = habilitaAsign
        btnDesmarMa.Enabled = habilitaAsign
    End Sub

    Private Sub cmbGrado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrado.SelectedIndexChanged
        TextGrado.Text = ""
        cmbSeccion.Items.Clear()
        deshabilita()
        If cmbGrado.Text.Trim <> "" Then
            ' Combos_Disponibles(True, 2)
            TextGrado.Text = tbgrado.Rows.Item(cmbGrado.SelectedIndex).Item(1)
            cadena = "SELECT DISTINCT SECCION FROM CATALOGOCOLEGIO WHERE COLEGIO='" & cmbJornada.Text & "' AND NIVEL='" &
            cmbNivel.Text & "' AND GRADO='" & cmbGrado.Text & "'"
            llena_combo(cadena, cmbSeccion)
            cmbSeccion.Focus()
        End If
    End Sub
    Private Sub cmbSeccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSeccion.SelectedIndexChanged
        deshabilita()
        If cmbSeccion.Text.Trim <> "" Then
            llenar_Tabla_Maestros(cmbTipoTest.SelectedValue, textCiclo.Text, cmbJornada.Text, cmbNivel.Text, cmbGrado.Text, cmbSeccion.Text)
            If tbMaestros.Rows.Count > 0 Then
                'define_Vista2()
                carga_alumnos()

                If (tablaAlumnos.Rows.Count > 0) Then
                    gbaquien.Visible = True

                    'define_Vista1()
                    btnguardar.Visible = True
                Else
                    MsgBox("No hay alumnos inscritos disponibles en este grado para cargar esta transaccion ".ToUpper, MsgBoxStyle.Information, "Mensaje del sistema")
                End If
            Else
                MsgBox("NO EXISTEN MAESTROS ASIGNADOS A ESTA SECCION", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If
        End If

    End Sub

    Public Sub deshabilita()
        dgAlumno.DataSource = Nothing
        dgvAlumnosAsign.DataSource = Nothing
        dgMaestros.DataSource = Nothing
        dgMaestrosA.DataSource = Nothing
        gbaquien.Visible = False
        btnguardar.Visible = False
        txtCountAlu.Text = ""
        txtCountAluA.Text = ""
    End Sub

#End Region


#Region "Carga de Alumnos"
    Private Sub carga_alumnos()
        If (cmbNivel.Text = "S" Or cmbNivel.Text = "P" Or cmbNivel.Text = "E" Or cmbNivel.Text = "K") Then
            tablaAlumnos = seleccionar_alumnos(textCiclo.Text, cmbJornada.Text, cmbNivel.Text, cmbGrado.Text, cmbSeccion.Text)
            gridAlumnos(tablaAlumnos)
        Else
            txtCountAlu.Clear()
            dgAlumno.DataSource = Nothing
        End If
    End Sub


    Private Function seleccionar_alumnos(ciclo As String, colegio As String, nivel As String, grado As String, seccion As String) As DataTable

        lpara.Clear()
        Dim tbData As New DataTable
        If (nivel = "S" Or nivel = "P" Or nivel = "E" Or nivel = "K") Then
            lpara("ciclo") = ciclo
            lpara("colegio") = colegio
            lpara("nivel") = nivel
            lpara("grado") = grado
            lpara("seccion") = seccion
            cadena = "select clave,rtrim(apell1 + ' ' + apell2 + ' ' + nom1 + ' ' + nom2) as nombre, num_alumno, cast( 0 as bit) as aplicar " &
                         " from Datos_Alumnos where colegio=@colegio and nivel=@nivel and grado=@grado" &
                         " and seccion=@seccion and ciclo=@ciclo and activo='A' " &
                         " order by apell1, apell2, nom1, nom2 "
            tablaAlumnos = New DataTable
            llenaTabla(cadena, tbData, ListaParametros(lpara))
            Return tbData
        Else
            Return Nothing
        End If

    End Function


    Private Sub gridAlumnos(tbAlu As DataTable)
        If (tbAlu IsNot Nothing) Then

            tablaAlumnos.Columns("aplicar").AllowDBNull = False
            dgAlumno.DataSource = tablaAlumnos
            vista_alumnos(dgAlumno)
        End If

    End Sub
#End Region





    Private Sub filtros_aplicacion(tipo As Int32)
        Dim condicion As String = ""
        Dim valor As Int16 = 0
        If habilita_n(tipo) Then
            If Not validetError(txtN, ep1) OrElse Not Int16.TryParse(txtN.Text, valor) Then
                MsgBox("Ingrese un valor >0 para N", MsgBoxStyle.Information, "Mensaje del sistema")
                Exit Sub
            End If
        End If
        Dim fila As DataRow
        Dim clave, resultado As Int16


        If dgAlumno.DataSource IsNot Nothing Then
            Dim tbDAlu As DataTable = dgAlumno.DataSource
            Select Case tipo
                Case 0 'todos
                    For Each fila In tbDAlu.Rows
                        fila("aplicar") = True
                    Next
                Case 1 'pares
                    condicion = "APLICAR=case cast(clave%2 as bit) when 0 then cast(1 as bit) when 1 then cast(0 as bit) end"
                    For Each fila In tbDAlu.Rows
                        clave = fila("clave")
                        resultado = clave Mod 2
                        If resultado = 0 Then
                            fila("aplicar") = True
                        Else
                            fila("aplicar") = False
                        End If

                    Next
                Case 2 'impares
                    condicion = "APLICAR=case cast(clave%2 as bit) when 0 then cast(1 as bit) when 1 then cast(0 as bit) end"
                    For Each fila In tbDAlu.Rows
                        clave = fila("clave")
                        resultado = clave Mod 2
                        If resultado = 1 Then
                            fila("aplicar") = True
                        Else
                            fila("aplicar") = False
                        End If

                    Next
                Case 3 'manual
                    For Each fila In tbDAlu.Rows
                        fila("aplicar") = False
                    Next
                Case 4, 5 ' de 1 a 20
                    For Each fila In tbDAlu.Rows
                        clave = fila("clave")
                        If clave <= valor Then
                            fila("aplicar") = If(tipo = 4, True, False)
                        Else
                            fila("aplicar") = If(tipo = 4, False, True)
                        End If
                    Next
            End Select
        End If

    End Sub


    Private Function habilita_n(ByVal valor As Int16) As Boolean
        If valor = 4 Or valor = 5 Then
            'txtN.Enabled = True
            gpN.Enabled = True
            Return True
        Else
            'txtN.Enabled = False
            gpN.Enabled = False
            Return False
        End If

    End Function

    Private Sub cmbOpcion_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbOpcion.SelectedIndexChanged
        filtros_aplicacion(cmbOpcion.SelectedIndex)
    End Sub


#Region "Guardar asignación"


    Private Sub btnguardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnguardar.Click
        Dim i, j, contador, contadorA As Int16
        contador = 0
        contadorA = 0
        Dim asignar As Boolean
        asignar = False

        Dim tipotest As Int32 = 0


        If Not validetError(cmbTipoTest, ep1) Then
            MsgBox(" SELECCIONE UN TIPO DE EVALUACION PRIMERO ", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        Else
            tipotest = CInt(cmbTipoTest.SelectedValue)
        End If
        Dim cm As cmodelo

        contador = 0
        If dgMaestros.DataSource IsNot Nothing AndAlso dgAlumno.DataSource IsNot Nothing Then
            Dim tbData As DataTable = dgMaestros.DataSource
            contador = tbData.AsEnumerable().Where(Function(x) x.Field(Of Boolean)("aplicar") = True).Count()
            Dim tbAlu As DataTable = dgAlumno.DataSource
            contadorA = tbAlu.AsEnumerable().Where(Function(x) x.Field(Of Boolean)("aplicar") = True).Count()


            If contador > 0 And contadorA Then
                lpara.Clear()
                cm = New cmodelo(_conexionAcademia)
                lpara("ciclo") = textCiclo.Text
                lpara("colegio") = cmbJornada.Text
                lpara("nivel") = cmbNivel.Text
                lpara("grado") = cmbGrado.Text
                lpara("seccion") = cmbSeccion.Text
                lpara("tipotest") = tipotest
                Try
                    Dim sigue As Boolean = True
                    For i = 0 To tbData.Rows.Count - 1
                        tempMaestro = tbData.Rows(i)
                        If tempMaestro.Item("APLICAR") Then
                            sigue = True
                            lpara("codigo") = tempMaestro("codigo")
                            cadena = " select count(*)  from evaluadocasignacion " &
                                              " where ciclo=@ciclo and colegio=@colegio and nivel=@nivel and grado=@grado and seccion=@seccion " &
                                              " and codigo=@codigo and tipotest=@tipotest"

                            If (cm.BuscaEscalar(cadena, ListaParametros(lpara)) > 0) Then
                                If MsgBox($"YA EXISTE UNA ASIGNACION PREVIA DE ESTA SECCION PARA EL MAESTRO { tempMaestro("nombre")}. ¿DESEA REASIGNAR?", vbYesNo) = vbYes Then
                                    cadena = "delete evaluadocasignacion where ciclo=@ciclo " &
                                             " and colegio=@colegio and nivel=@nivel and grado=@grado " &
                                             " and seccion=@seccion and codigo=@codigo and tipotest=@tipotest"
                                    cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                                Else
                                    sigue = False
                                End If
                            End If
                            If sigue Then
                                For j = 0 To tbAlu.Rows.Count - 1
                                    tempAlumno = tbAlu.Rows(j)
                                    If tempAlumno.Item("APLICAR") Then
                                        cadena = "insert into evaluadocasignacion (ciclo,tipotest,colegio,nivel,grado,seccion,num_alumno,clave,codigo) " &
                                                 " values (@ciclo,@tipotest,@colegio,@nivel,@grado,@seccion,@num_alumno,@clave,@codigo) "

                                        lpara("clave") = tempAlumno("clave")
                                        lpara("num_alumno") = tempAlumno("num_alumno")
                                        cm.EjecutarNonQuery(cadena, ListaParametros(lpara))

                                    End If
                                Next
                            End If

                        End If
                    Next
                    If cm.Commit() Then
                        MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                        llenar_Tabla_Maestros(cmbTipoTest.SelectedValue, textCiclo.Text, cmbJornada.Text, cmbNivel.Text, cmbGrado.Text, cmbSeccion.Text)
                    Else
                        MsgBox("ERROR EN LA OPERACION", MsgBoxStyle.Critical, "Mensaje del Sistema")

                    End If
                Catch ex As Exception
                    cm.RollBack()
                    MsgBox("ERROR AL INTENTAR GUARDAR LOS DATOS CONSULTE AL ADMINISTRADOR", MsgBoxStyle.Critical, "Mensaje del Sistema")
                End Try

            Else
                MsgBox("Debe al menos seleccionar algún maestro y alumno para asignar.", MsgBoxStyle.Information, "Mensaje del Sistema")
            End If

        End If




    End Sub


#End Region


    Private Function llenar_Tabla_Maestros(tipotest As Int32, ciclo As String, colegio As String, nivel As String, grado As String, seccion As String) As Tuple(Of DataTable, DataTable)

        tbMaestros = New DataTable
        tbMaestrosA = New DataTable

        Dim cm As New cmodelo(_conexionAcademia)
        lpara.Clear()
        lpara("ciclo") = ciclo
        lpara("colegio") = colegio
        lpara("nivel") = nivel
        lpara("grado") = grado
        lpara("seccion") = seccion
        lpara("tipotest") = tipotest

        cadena = "select * from ( "
        cadena = cadena & "select a.codigo, apell1+' '+apell2+' '+nom1+' '+nom2 as nombre, d.nombre as nombre_materia,cast ( 0 as bit ) as APLICAR, isnull(c.mdlcourse_id, 0) as mdlcourse_id " &
                      "from maestrosporseccion a " &
                     " inner join maestros b on a.codigo=b.codigo " &
                     "inner join materiasporgrado c on a.ciclo=c.ciclo and a.colegio=c.colegio and a.nivel=c.nivel and a.grado=c.grado and a.codmateria=c.codigo " &
                     "inner join materias d on c.colegio=d.colegio and c.codigo=d.codigo " &
                     " where a.colegio=@colegio and a.nivel=@nivel and a.grado=@grado" &
                     " and a.seccion=@seccion and b.tipomaestro<>'M' and b.tipo in ('P','A','C') " &
                     " and a.ciclo=@ciclo and not b.codigo in (select distinct(codigo) from evaluadocasignacion c where " &
                     " c.ciclo=@ciclo and c.tipotest=@tipotest and c.colegio=@colegio and c.nivel=@nivel and c.grado=@grado and c.seccion=@seccion) " &
                     " group by a.codigo,nom1,nom2,apell1,apell2,a.colegio,a.nivel,a.grado,a.seccion, c.mdlcourse_id, d.nombre " &
                     " union all " &
                     "select a.codigo, apell1+' '+apell2+' '+nom1+' '+nom2 as nombre, '' as nombre_materia,cast ( 0 as bit ) as APLICAR, 0 as mdlcourse_id " &
                     "from tutoresporgrado a " &
                     " inner join maestros b on a.codigo=b.codigo " &
                     " where a.colegio=@colegio and a.nivel=@nivel and a.grado=@grado" &
                     " and a.seccion=@seccion and b.tipomaestro='N' and b.tipo in ('A') " &
                     " and not b.codigo in (select distinct(codigo) from evaluadocasignacion c where " &
                     " c.ciclo=@ciclo and c.tipotest=@tipotest and c.colegio=@colegio and c.nivel=@nivel and c.grado=@grado and c.seccion=@seccion) " &
                     " group by a.codigo,nom1,nom2,apell1,apell2,a.colegio,a.nivel,a.grado,a.seccion " &
                     " ) as a order by nombre "

        cm.llenaTabla(cadena, tbMaestros, ListaParametros(lpara))
        dgMaestros.DataSource = tbMaestros
        vista_profesor(dgMaestros)

        tbMaestros.Columns("APLICAR").AllowDBNull = False
        cadena = "select distinct(b.codigo),  apell1+' '+apell2+' '+nom1+' '+nom2 as nombre from evaluadocasignacion a " &
                     "inner join maestros b on a.codigo=b.codigo " &
                     "where " &
                     " a.ciclo=@ciclo and a.tipotest=@tipotest and a.colegio=@colegio" &
                     " and a.nivel=@nivel and a.grado=@grado and a.seccion=@seccion " &
                     "order by b.codigo "
        cm.llenaTabla(cadena, tbMaestrosA, ListaParametros(lpara))
        cm.Commit()
        dgMaestrosA.DataSource = tbMaestrosA
        vista_profesorA(dgMaestrosA)
        Return New Tuple(Of DataTable, DataTable)(tbMaestros, tbMaestrosA)


    End Function






    Private Sub btnlimpia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlimpia.Click
        tablaAlumnos.Clear()
        tbMaestros.Clear()
        dgAlumno.DataSource = Nothing
        dgMaestros.DataSource = Nothing
        dgvAlumnosAsign.DataSource = Nothing
        dgMaestrosA.DataSource = Nothing
        cmbJornada.SelectedIndex = -1
        cmbNivel.SelectedIndex = -1
        cmbGrado.SelectedIndex = -1
        cmbSeccion.SelectedIndex = -1

        btnguardar.Visible = False
        BoleanAlumno = False
        tablaAlumnos.Rows.Clear()
        tbMaestros.Rows.Clear()
        gbaquien.Visible = False
        gpN.Enabled = False
        cmbOpcion.SelectedText = ""
        txtN.Text = ""
        txtCountAlu.Text = ""
        txtCountAluA.Text = ""
    End Sub



    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        filtros_aplicacion(cmbOpcion.SelectedIndex)
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminar.Click
        If dgMaestrosA.SelectedRows.Count > 0 Then
            If Not validetError(textCiclo, ep1) Or Not validetError(cmbJornada, ep1) Or Not validetError(cmbNivel, ep1) _
               Or Not validetError(cmbGrado, ep1) Or Not validetError(cmbSeccion, ep1) Then
                MsgBox("DEBE INGRESAR TODOS VALORES PARA ELIMINAR LA ASIGNACION", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            Else
                Dim codigo As Integer = dgMaestrosA.SelectedRows(0).Cells("codigo").Value

                Try
                    Dim cm As New cmodelo(_conexionAcademia)
                    If (MsgBox("DESEA ELIMINAR LA ASIGNACION DEL MAESTRO " & dgMaestrosA.SelectedRows(0).Cells("nombre").Value.ToString() &
                               " PARA ESTE GRADO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes) Then
                        cadena = "select count (*) " &
                                         " from evaluadocasignacion a " &
                                         " where a.evaluado = 1 and a.codigo=" & codigo & " and a.ciclo=" & textCiclo.Text &
                                         " and a.colegio = '" & cmbJornada.Text & "' and nivel='" & cmbNivel.Text &
                                         "' and grado='" & cmbGrado.Text & "' and seccion='" & cmbSeccion.Text & "' "
                        If (cm.BuscaEscalar(cadena) > 0) Then
                            MsgBox("NO SE PUEDE ELIMINAR ASIGNACION PORQUE YA EXISTEN EVALUACIONES", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                        Else
                            cadena = "delete " &
                                " from evaluadocasignacion " &
                                " where evaluado = 0 and codigo=" & codigo & " and ciclo=" & textCiclo.Text & " and colegio='" &
                                cmbJornada.Text & "' and nivel='" & cmbNivel.Text &
                                "' and grado='" & cmbGrado.Text & "' and seccion='" & cmbSeccion.Text & "' "
                            cm.EjecutarNonQuery(cadena)
                            If cm.Commit() Then
                                MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                                llenar_Tabla_Maestros(cmbTipoTest.SelectedValue, textCiclo.Text, cmbJornada.Text, cmbNivel.Text, cmbGrado.Text, cmbSeccion.Text)
                            End If
                        End If
                    End If
                Catch ex As Exception
                    MsgBox("ERROR EN LA ELIMINACION" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                End Try
            End If
        End If
    End Sub



    Private Sub cmbTipoTest_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipoTest.SelectedIndexChanged
        cmbJornada.Text = ""
        If cmbTipoTest.Text.Trim <> "" Then
            gbDatos.Enabled = True
        Else
            gbDatos.Enabled = False
        End If
    End Sub


    Private Sub textCiclo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textCiclo.Validated
        cmbJornada.Text = ""
        dgMaestros.DataSource = Nothing
        dgAlumno.DataSource = Nothing
        dgMaestrosA.DataSource = Nothing
        lpara.Clear()
        If textCiclo.Text.Trim <> "" Then
            lpara("ciclo") = textCiclo.Text
            Dim cm As New cmodelo(_conexionAcademia)
            cadena = "select nombre,tipotest from evaluatipotest where ciclo=@ciclo  and grupo_asignacion=1  and grupo_asignacion=1 order by tipotest"
            cm.llenaTabla(cadena, tbTipotest, ListaParametros(lpara))
            cmbTipoTest.ValueMember = "tipotest"
            cmbTipoTest.DisplayMember = "nombre"
            cmbTipoTest.DataSource = tbTipotest

            cadena = "select clave, apell1 + ' ' + apell2 + ' ' + nom1 + ' ' + nom2 as nombre, num_alumno, cast (0 as bit) as aplicar " +
                     " From datos_alumnos where ciclo=@ciclo and activo='A' order by colegio,nivel,grado,seccion,clave"
            llenaTabla(cadena, tbAlumnosCiclo, ListaParametros(lpara))
            cm.Commit()
            gbDatos.Enabled = True
        Else
            gbDatos.Enabled = False
        End If


    End Sub

    Private Sub dgMaestrosA_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMaestrosA.SelectionChanged
        If dgMaestrosA.SelectedRows.Count > 0 Then
            Try
                Dim codigo As Integer = 0
                Dim tipotest As Int32 = cmbTipoTest.SelectedValue
                Dim tbAlumnos2 As New DataTable
                codigo = dgMaestrosA.SelectedRows(0).Cells("codigo").Value
                Dim cm As New cmodelo(_conexionAcademia)
                lpara("ciclo") = textCiclo.Text
                lpara("colegio") = cmbJornada.Text
                lpara("nivel") = cmbNivel.Text
                lpara("grado") = cmbGrado.Text
                lpara("seccion") = cmbSeccion.Text
                lpara("codigo") = codigo
                lpara("tipotest") = tipotest
                If (cmbNivel.Text = "S" Or cmbNivel.Text = "K" Or cmbNivel.Text = "E" Or cmbNivel.Text = "P") Then
                    cadena = "select a.clave,rtrim(apell1 + ' ' + apell2 + ' ' + nom1 + ' ' + nom2) as nombre, a.num_alumno , evaluado as aplicar " &
                        " from Datos_Alumnos a " &
                        " inner join evaluadocasignacion b on a.ciclo=b.ciclo and a.num_alumno=b.num_alumno " &
                        "where b.tipotest=@tipotest and a.colegio=@colegio and a.nivel=@nivel and a.grado=@grado " &
                        " and a.seccion=@seccion and a.ciclo=@ciclo and a.activo='A' and b.codigo=@codigo " &
                        " order by a.apell1, a.apell2, a.nom1, a.nom2 "
                    cm.llenaTabla(cadena, tbAlumnos2, ListaParametros(lpara))
                    cm.Commit()
                    dgvAlumnosAsign.DataSource = tbAlumnos2
                    vista_alumnos(dgvAlumnosAsign)
                Else
                    cadena = "select a.clave,rtrim(apell1 + ' ' + apell2 + ' ' + nom1 + ' ' + nom2) as nombre, a.num_alumno , evaluado as aplicar " &
                       " from Datos_Alumnos a " &
                       " inner join evaluadocasignacion b on a.ciclo=b.ciclo and a.num_alumno=b.num_alumno " &
                       "where a.ciclo=@ciclo and b.tipotest=@tipotest and a.activo='A' and b.codigo=@codigo " &
                       " order by a.apell1, a.apell2, a.nom1, a.nom2 "
                    cm.llenaTabla(cadena, tbAlumnos2, ListaParametros(lpara))
                    cm.Commit()
                    dgvAlumnosAsign.DataSource = tbAlumnos2
                    vista_alumnos(dgvAlumnosAsign)
                End If
                txtCountAluA.Text = tbAlumnos2.Rows.Count

            Catch ex As Exception
                MsgBox("Error de la aplicacion " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema ")
            End Try
        End If
    End Sub

    Private Sub dgMaestros_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgMaestros.SelectionChanged
        If dgMaestros.SelectedRows.Count > 0 And (cmbNivel.Text.Trim = "Z" Or cmbNivel.Text.Trim = "Y") Then
            Try
                Dim tbMa As DataTable = dgMaestros.DataSource
                For Each fila As DataRow In tbMa.Rows
                    fila("aplicar") = False
                Next

                Dim codigo, mdlcourse_id As Integer
                Dim tbAlumnos2 As New DataTable
                codigo = dgMaestros.SelectedRows(0).Cells("codigo").Value
                mdlcourse_id = dgMaestros.SelectedRows(0).Cells("mdlcourse_id").Value
                Dim Response As String = wsCliente.GetStudentsFromCourse(wsAuth, mdlcourse_id)
                If (Not String.IsNullOrEmpty(Response)) Then
                    Dim lStudents As New List(Of Students)
                    lStudents = JsonConvert.DeserializeObject(Of List(Of Students))(Response)
                    tablaAlumnos = New DataTable()

                    tablaAlumnos = tbAlumnosCiclo.Clone()
                    Dim filas = (From a In tbAlumnosCiclo.AsEnumerable()
                                 Where lStudents.Select(Function(x) x.NumStudent).ToList().Contains(a.Field(Of Int32)("num_alumno"))
                                 Select a).ToList()
                    For Each fil As DataRow In filas
                        tablaAlumnos.ImportRow(fil)
                    Next
                    dgAlumno.DataSource = tablaAlumnos
                    vista_alumnos(dgAlumno)
                    txtCountAlu.Text = tablaAlumnos.Rows.Count
                Else
                    txtCountAlu.Clear()
                    dgAlumno.DataSource = Nothing
                End If



            Catch ex As Exception
                MsgBox("Error de la aplicacion " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema ")
            End Try
        End If
    End Sub


#Region "Eventos varios"
    Private Sub TextCuotas_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub TextValor_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.text.trim <> "" Then
            sender.text = formato(sender.text)
        End If
    End Sub

    Private Sub textValor_Keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        soloNumeroDec(sender, e)
    End Sub

    Private Sub textCantidad_Keypress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        soloNumero(sender, e)
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs)
        'cambia el color cuando un objeto pierde el foco
        desactiva(sender)
    End Sub

    Private Sub btnDesmarMa_Click(sender As Object, e As EventArgs) Handles btnDesmarMa.Click
        realiza_marca_maestro(False, dgMaestros)
    End Sub

    Private Sub btnMarcarMa_Click(sender As Object, e As EventArgs) Handles btnMarcarMa.Click
        realiza_marca_maestro(True, dgMaestros)
    End Sub

    Private Sub btnDesmarAlu_Click(sender As Object, e As EventArgs) Handles btnDesmarAlu.Click
        realiza_marca_maestro(False, dgAlumno)
    End Sub

    Private Sub btnMarcarAlu_Click(sender As Object, e As EventArgs) Handles btnMarcarAlu.Click
        realiza_marca_maestro(True, dgAlumno)
    End Sub


    Private Sub realiza_marca_maestro(valor As Boolean, dgvDetalle As DataGridView)
        If dgvDetalle.DataSource IsNot Nothing Then
            Dim tbData As DataTable = dgvDetalle.DataSource
            For Each fila As DataRow In tbData.Rows
                fila("aplicar") = valor
            Next
        End If
    End Sub


    Private Sub frmAsignaProfAlumGraSecc_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub





#End Region
End Class
