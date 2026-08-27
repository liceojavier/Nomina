Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMLIBROSALARIO.VB MIEMBRO DE NOMINA.SLN                                    **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmLibroSalario
    Inherits Form
   

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
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents TextPagina As System.Windows.Forms.TextBox
    Friend WithEvents cmbMesF As System.Windows.Forms.ComboBox
    Friend WithEvents TextAñof As System.Windows.Forms.TextBox
    Friend WithEvents cmbMesI As System.Windows.Forms.ComboBox
    Friend WithEvents lbA As System.Windows.Forms.Label
    Friend WithEvents lbDe As System.Windows.Forms.Label
    Friend WithEvents lbFinal As System.Windows.Forms.Label
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents gpTipo As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents lbInicial As System.Windows.Forms.Label
    Friend WithEvents cmbAñof As System.Windows.Forms.ComboBox
    Friend WithEvents cmbAñoI As System.Windows.Forms.ComboBox
    Friend WithEvents gpEmpleado As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents textEmpleado As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLibroSalario))
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.cmbAñof = New System.Windows.Forms.ComboBox()
        Me.cmbAñoI = New System.Windows.Forms.ComboBox()
        Me.lbInicial = New System.Windows.Forms.Label()
        Me.lbFinal = New System.Windows.Forms.Label()
        Me.lbA = New System.Windows.Forms.Label()
        Me.lbDe = New System.Windows.Forms.Label()
        Me.cmbMesF = New System.Windows.Forms.ComboBox()
        Me.TextAñof = New System.Windows.Forms.TextBox()
        Me.cmbMesI = New System.Windows.Forms.ComboBox()
        Me.TextPagina = New System.Windows.Forms.TextBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.gpTipo = New System.Windows.Forms.GroupBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.gpEmpleado = New System.Windows.Forms.GroupBox()
        Me.textNombreEmpleado = New System.Windows.Forms.TextBox()
        Me.textEmpleado = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gpFecha.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpTipo.SuspendLayout()
        Me.gpEmpleado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpFecha
        '
        Me.gpFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpFecha.Controls.Add(Me.cmbAñof)
        Me.gpFecha.Controls.Add(Me.cmbAñoI)
        Me.gpFecha.Controls.Add(Me.lbInicial)
        Me.gpFecha.Controls.Add(Me.lbFinal)
        Me.gpFecha.Controls.Add(Me.lbA)
        Me.gpFecha.Controls.Add(Me.lbDe)
        Me.gpFecha.Controls.Add(Me.cmbMesF)
        Me.gpFecha.Controls.Add(Me.TextAñof)
        Me.gpFecha.Controls.Add(Me.cmbMesI)
        Me.gpFecha.Controls.Add(Me.TextPagina)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.ForeColor = System.Drawing.Color.White
        Me.gpFecha.Location = New System.Drawing.Point(5, 54)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(676, 39)
        Me.gpFecha.TabIndex = 3
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Periodo"
        '
        'cmbAñof
        '
        Me.cmbAñof.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAñof.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAñof.Location = New System.Drawing.Point(439, 13)
        Me.cmbAñof.Name = "cmbAñof"
        Me.cmbAñof.Size = New System.Drawing.Size(56, 21)
        Me.cmbAñof.TabIndex = 4
        '
        'cmbAñoI
        '
        Me.cmbAñoI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAñoI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAñoI.Location = New System.Drawing.Point(189, 13)
        Me.cmbAñoI.Name = "cmbAñoI"
        Me.cmbAñoI.Size = New System.Drawing.Size(56, 21)
        Me.cmbAñoI.TabIndex = 2
        '
        'lbInicial
        '
        Me.lbInicial.AutoSize = True
        Me.lbInicial.Location = New System.Drawing.Point(443, 16)
        Me.lbInicial.Name = "lbInicial"
        Me.lbInicial.Size = New System.Drawing.Size(53, 13)
        Me.lbInicial.TabIndex = 12
        Me.lbInicial.Text = "PAGINA"
        '
        'lbFinal
        '
        Me.lbFinal.AutoSize = True
        Me.lbFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFinal.Location = New System.Drawing.Point(559, 16)
        Me.lbFinal.Name = "lbFinal"
        Me.lbFinal.Size = New System.Drawing.Size(43, 13)
        Me.lbFinal.TabIndex = 11
        Me.lbFinal.Text = "Pagina:"
        '
        'lbA
        '
        Me.lbA.AutoSize = True
        Me.lbA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbA.Location = New System.Drawing.Point(260, 16)
        Me.lbA.Name = "lbA"
        Me.lbA.Size = New System.Drawing.Size(17, 13)
        Me.lbA.TabIndex = 10
        Me.lbA.Text = "A:"
        '
        'lbDe
        '
        Me.lbDe.AutoSize = True
        Me.lbDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbDe.Location = New System.Drawing.Point(7, 16)
        Me.lbDe.Name = "lbDe"
        Me.lbDe.Size = New System.Drawing.Size(24, 13)
        Me.lbDe.TabIndex = 9
        Me.lbDe.Text = "De:"
        '
        'cmbMesF
        '
        Me.cmbMesF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMesF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMesF.Location = New System.Drawing.Point(283, 13)
        Me.cmbMesF.Name = "cmbMesF"
        Me.cmbMesF.Size = New System.Drawing.Size(149, 21)
        Me.cmbMesF.TabIndex = 3
        '
        'TextAñof
        '
        Me.TextAñof.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAñof.Location = New System.Drawing.Point(497, 13)
        Me.TextAñof.MaxLength = 4
        Me.TextAñof.Name = "TextAñof"
        Me.TextAñof.Size = New System.Drawing.Size(56, 20)
        Me.TextAñof.TabIndex = 4
        '
        'cmbMesI
        '
        Me.cmbMesI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMesI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMesI.Location = New System.Drawing.Point(34, 13)
        Me.cmbMesI.Name = "cmbMesI"
        Me.cmbMesI.Size = New System.Drawing.Size(149, 21)
        Me.cmbMesI.TabIndex = 1
        '
        'TextPagina
        '
        Me.TextPagina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextPagina.Location = New System.Drawing.Point(612, 14)
        Me.TextPagina.MaxLength = 4
        Me.TextPagina.Name = "TextPagina"
        Me.TextPagina.Size = New System.Drawing.Size(56, 20)
        Me.TextPagina.TabIndex = 5
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "reportegenerar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(961, 4)
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
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(1047, 4)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 5
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(400, 10)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(60, 30)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEmpleado, "Empleado")
        Me.btnEmpleado.UseVisualStyleBackColor = False
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'crv
        '
        Me.crv.ActiveViewIndex = -1
        Me.crv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv.Location = New System.Drawing.Point(0, 99)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.ShowCloseButton = False
        Me.crv.ShowGotoPageButton = False
        Me.crv.ShowTextSearchButton = False
        Me.crv.Size = New System.Drawing.Size(1130, 506)
        Me.crv.TabIndex = 57
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'gpTipo
        '
        Me.gpTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpTipo.Controls.Add(Me.cmbTipo)
        Me.gpTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTipo.ForeColor = System.Drawing.Color.White
        Me.gpTipo.Location = New System.Drawing.Point(5, 4)
        Me.gpTipo.Name = "gpTipo"
        Me.gpTipo.Size = New System.Drawing.Size(336, 48)
        Me.gpTipo.TabIndex = 1
        Me.gpTipo.TabStop = False
        Me.gpTipo.Text = "Tipo de transporte"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Items.AddRange(New Object() {"VALORES DEVENGADOS", "ENCABEZADOS DE LIBRO DE SALARIOS", "LIBRO DE SALARIOS 2001-2007", "LIBRO DE SALARIOS 2008-2018", "LIBRO DE SALARIOS 2008-2018 (FOLIO ANTIGUO)", "LIBRO DE SALARIOS FOLIO ELECTRONICO"})
        Me.cmbTipo.Location = New System.Drawing.Point(7, 19)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(323, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'gpEmpleado
        '
        Me.gpEmpleado.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpleado.Controls.Add(Me.btnEmpleado)
        Me.gpEmpleado.Controls.Add(Me.textNombreEmpleado)
        Me.gpEmpleado.Controls.Add(Me.textEmpleado)
        Me.gpEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpleado.ForeColor = System.Drawing.Color.White
        Me.gpEmpleado.Location = New System.Drawing.Point(347, 4)
        Me.gpEmpleado.Name = "gpEmpleado"
        Me.gpEmpleado.Size = New System.Drawing.Size(515, 48)
        Me.gpEmpleado.TabIndex = 2
        Me.gpEmpleado.TabStop = False
        Me.gpEmpleado.Text = "Empleado"
        '
        'textNombreEmpleado
        '
        Me.textNombreEmpleado.BackColor = System.Drawing.Color.White
        Me.textNombreEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombreEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombreEmpleado.Location = New System.Drawing.Point(66, 17)
        Me.textNombreEmpleado.MaxLength = 40
        Me.textNombreEmpleado.Name = "textNombreEmpleado"
        Me.textNombreEmpleado.Size = New System.Drawing.Size(328, 20)
        Me.textNombreEmpleado.TabIndex = 2
        '
        'textEmpleado
        '
        Me.textEmpleado.BackColor = System.Drawing.Color.White
        Me.textEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textEmpleado.Location = New System.Drawing.Point(6, 17)
        Me.textEmpleado.MaxLength = 6
        Me.textEmpleado.Name = "textEmpleado"
        Me.textEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textEmpleado.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 107)
        Me.Panel1.TabIndex = 58
        '
        'frmLibroSalario
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.gpEmpleado)
        Me.Controls.Add(Me.gpTipo)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.gpFecha)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmLibroSalario"
        Me.Text = "Libro de Salarios"
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpTipo.ResumeLayout(False)
        Me.gpEmpleado.ResumeLayout(False)
        Me.gpEmpleado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim cadena As String
    Dim tbEmpresa As New DataTable("empresa")
    Dim tbTipo As New DataTable("tipo")
    Dim tbEmpleado As New DataTable("empleado")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim nit As String = ""
    Dim filaTemp As DataRow
    Dim r As ReportClass
    Dim v As New cryLibroSalario
    Dim v1 As New cryListadoDevengado
    Dim v2 As New cryLibroSalarioVacio
    Dim tt As New DataTable("datos")
    Dim WithEvents FEMP As frmMuestraCodigos
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        cadena = "select nombre from meses order by mes"
        llena_combo(cadena, cmbMesI)
        llena_combo(cadena, cmbMesF)
        cmbMesF.Items.Add("")
        cmbMesI.Items.Add("")

        nit = BuscaEscalar("select nit from empresas where empresa=@empresa", ListaParametros(lpara))
        TextPagina.Text = "1"
        cadena = "select nombre, tiponom, cantidad, por, movimientos, desprestamos from tiponomina1 where empresa=" & empresa
        'gpTipo.SendToBack()
        btnLimpiar_Click(sender, e)
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        Dim añoi, añof, mesi, mesf, i As Int32
        Dim fechaFin As Date
        Dim fechaInc As Date
        Dim consultaEmpleado As String = ""
        lpara.Clear()
        'cmbTipo.SelectedIndex = 0
        Select Case cmbTipo.SelectedIndex
            Case 0
                If Not validetError(cmbMesI, ep1) Or Not validetError(cmbAñoI, ep1) Or Not validetError(cmbMesF, ep1) Or _
                    Not validetError(cmbAñof, ep1) Then
                    MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    Exit Sub
                End If
                'cmbTipo.SelectedIndex = 2
            Case 1
                If Not validetError(TextPagina, ep1) Or Not validetError(TextAñof, ep1) Then
                    MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    Exit Sub
                End If

            Case 2, 3, 4
                If Not validetError(cmbMesI, ep1) Or Not validetError(cmbAñoI, ep1) Or Not validetError(cmbMesF, ep1) Or _
                     Not validetError(cmbAñof, ep1) Then
                    MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    Exit Sub
                End If
                'cmbTipo.SelectedIndex = 1

                'cmbTipo.SelectedIndex = 1
        End Select


        'cmbTipo.SelectedIndex <2
        If cmbTipo.SelectedIndex <> 1 Then
            'añoi = CInt(TextAñoI.Text)
            'añof = CInt(TextAñof.Text)
            añoi = CInt(cmbAñoI.Text)
            añof = CInt(cmbAñof.Text)
            mesi = cmbMesI.SelectedIndex + 1
            mesf = cmbMesF.SelectedIndex + 1
            If añof < añoi Then
                MsgBox("EL AÑO FINAL DEBE SER MAYOR O IGUAL QUE EL AÑO INICIAL", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            ElseIf añoi = añof Then
                If mesf < mesi Then
                    MsgBox("EL MES FINAL DEBE SER MAYOR O IGUAL QUE EL MES INICIAL", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    Exit Sub
                End If
            End If
            fechaInc = "01/" & mesi & "/" & añoi
            fechaFin = Date.DaysInMonth(añof, mesf) & "/" & mesf & "/" & añof
            'cmbTipo.SelectedIndex = 2
        ElseIf cmbTipo.SelectedIndex = 1 Then
            If CInt(TextAñof.Text) > CInt(TextPagina.Text) Then
                MsgBox("PAGINA INICIAL DEBE SER MENOR O IGUAL QUE LA PAGINA FINAL", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            End If

        End If

        'cmbTipo.SelectedIndex = 0
     

        Select Case cmbTipo.SelectedIndex
            Case 0
                r = New cryListadoDevengado()
            Case 1
                r = v2
            Case 2
                r = New cryLibroSalario20017
            Case 3
                r = New cryLibroSalarioNuevo_2017
            Case 4
                r = New cryLibroSalario
            Case 5
                r = New cryLibroSalarioElectronico
        End Select

        lpara("empresa") = empresa
        lpara("mesi") = mesi
        lpara("añoi") = añoi
        lpara("mesf") = mesf
        lpara("añof") = añof
        lpara("fechai") = fechaInc
        lpara("fechaf") = fechaFin
        Select Case cmbTipo.SelectedIndex
            Case 0
                If textEmpleado.Text.Trim <> "" And gpEmpleado.Visible Then
                    consultaEmpleado = "where empleado=" & textEmpleado.Text
                End If

                cadena = "select * from LibroSalariosDetalle(@empresa,@mesi,@añoi,@mesf,@añof,@fechai,@fechaf) " & consultaEmpleado & " " &
                "order by nombre"

                llenaTabla(cadena, tt, ListaParametros(lpara))

            Case 1
                cadena = "select * from v_numero"
                llenaTabla(cadena, tt)
                tt.Rows.Clear()
                For i = CInt(TextAñof.Text) To CInt(TextPagina.Text)
                    filaTemp = tt.NewRow
                    filaTemp.Item(0) = i
                    filaTemp.Item(1) = _nombre_empresa
                    filaTemp.Item(2) = nit
                    tt.Rows.Add(filaTemp)
                Next i

            Case 2, 3, 4, 5

                If cmbTipo.SelectedIndex = 3 Or cmbTipo.SelectedIndex = 4 Or cmbTipo.SelectedIndex = 5 Then
                    If textEmpleado.Text.Trim <> "" And gpEmpleado.Visible Then
                        consultaEmpleado = "empleado=" & textEmpleado.Text & " and "
                    End If

                    cadena = "select * from LibroSalarios(@empresa,@mesi,@añoi,@mesf,@añof,@fechai,@fechaf) where " & consultaEmpleado &
                     "(ordinario <> 0 or extraordinario <> 0 or septimo <> 0 or vaca <> 0 or IGSS <> 0 or OtrasOrd <> 0 or DTO <> 0)" &
                     " order by nombre, contrato, año, mes, tiponom"


                Else
                    If textEmpleado.Text.Trim <> "" And gpEmpleado.Visible Then
                        consultaEmpleado = "emp.empleado=" & textEmpleado.Text & " and "
                    End If
                    cadena = "select empr.nombre Nombempresa,emp.empleado," &
                    " coalesce(ltrim(rtrim(apellido1)),'')+' '+coalesce(ltrim(rtrim(apellido2)),'')+' '+case when coalesce(casada,'') <> '' then ' DE ' + casada else '' end+' '+" &
                    " coalesce(ltrim(rtrim(nombre1)),'')+' '+coalesce(ltrim(rtrim(emp.nombre2)),'')+' '+coalesce(ltrim(rtrim(nombre3)),'') nombre," &
                    " emp.fechanac,emp.registro,numidentica,sexo,nac.nombre nombNacional,emp.numseguro,emp.fechai,emp.fechaf,emp.puesto nombPuesto," &
                    " lib.fechai fechainom,lib.fechaf fechafnom,lib.sueldo valorsueldo,lib.canordinario dias,lib.canextras diasext," &
                    " lib.ordinario,lib.extras extraordinario,0.00 septimo,lib.vaca,lib.igss,lib.otrosdesc Otrasord,lib.otrosing DTO, lib.bonifica Bonificacion,lib.mes,lib.año" &
                    " from libro20017 lib" &
                    " inner join empleanterior emp on lib.empresa = emp.empresa and lib.empleado = emp.empleado" &
                    " inner join nacionalidades nac on nac.nacional = emp.nacional" &
                    " inner join empresas empr on empr.empresa = lib.empresa" &
                    " where lib.empresa =@empresa and " & consultaEmpleado & " (( lib.mes >= @mesi and lib.año>=@añoi)" &
                    " and ( lib.mes <=@mesf and lib.año<=@añof)) " &
                    " order by nombre, emp.empleado,año, mes"

                End If
                llenaTabla(cadena, tt, ListaParametros(lpara))
                'cmbTipo.SelectedIndex = 1
                Dim cont, cont2 As Int32
                Dim filaTemp, filaTemp2 As DataRow
                cont2 = 1
                For cont = 0 To tt.Rows.Count - 2
                    filaTemp = tt.Rows(cont)
                    filaTemp2 = tt.Rows(cont + 1)
                    filaTemp.BeginEdit()
                    filaTemp.Item("mes") = cont2
                    filaTemp.EndEdit()
                    If filaTemp.Item("empleado") <> filaTemp2.Item("empleado") Then
                        cont2 = 0
                    End If
                    cont2 = cont2 + 1
                    If cont = tt.Rows.Count - 2 And cont2 = 1 Then
                        filaTemp2.BeginEdit()
                        filaTemp2.Item("mes") = cont2
                        filaTemp2.EndEdit()
                    End If
                Next cont

        End Select

        If tt.Rows.Count > 0 Then

            r.SetDataSource(tt)
            'cmbTipo.SelectedIndex = 2
            If cmbTipo.SelectedIndex = 1 Then
                r.SetParameterValue("Hoja", CInt(TextAñof.Text))
            End If
            crv.ReportSource = r

        Else
            MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If

    End Sub

    Private Sub cmbMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub TextAño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextAñof.KeyPress, TextPagina.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        borra_Mejorado(gpFecha, ep1)
        'cmbTipo.Text = ""
        cmbTipo.SelectedIndex = 0

        crv.ReportSource = Nothing
        cmbMesI.Focus()
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        '    borra_Mejorado(gpFecha, ep1)
        ' BorraEmpleado(True)
        'cmbTipo.SelectedIndex = 0
        Dim cont As Int64
        cmbAñoI.Items.Clear()
        cmbAñof.Items.Clear()
        gpEmpleado.Visible = False
        If cmbTipo.SelectedIndex = 3 Or cmbTipo.SelectedIndex = 2 Or cmbTipo.SelectedIndex = 4 Or cmbTipo.SelectedIndex = 5 Then
            TextPagina.Visible = True
            lbFinal.Visible = False
            lbFinal.Text = "PAGINA"
            gpFecha.Text = "PERIODO"
            lbDe.Visible = True
            lbA.Visible = True
            lbFinal.Visible = True
            cmbMesI.Visible = True
            cmbMesF.Visible = True
            TextAñof.Visible = False
            cmbAñoI.Visible = True
            cmbAñof.Visible = True
            lbInicial.Text = ""
            lbDe.Visible = True
            lbA.Visible = True
            Select Case cmbTipo.SelectedIndex
                Case 2
                    gpEmpleado.Visible = True
                    For cont = 2001 To 2007
                        cmbAñoI.Items.Add(CStr(cont))
                        cmbAñof.Items.Add(CStr(cont))
                    Next cont
                Case 3
                    gpEmpleado.Visible = True
                    For cont = 2008 To 2019
                        cmbAñoI.Items.Add(CStr(cont))
                        cmbAñof.Items.Add(CStr(cont))
                    Next cont
                Case 4
                    gpEmpleado.Visible = True
                    For cont = 2008 To 2019
                        cmbAñoI.Items.Add(CStr(cont))
                        cmbAñof.Items.Add(CStr(cont))
                    Next cont
                Case 5
                    gpEmpleado.Visible = True
                    For cont = 2019 To Today.Year + 20
                        cmbAñoI.Items.Add(CStr(cont))
                        cmbAñof.Items.Add(CStr(cont))
                    Next cont
            End Select
            'cmbMes.Items.Add("")
            'cmbTipo.SelectedIndex = 1
        ElseIf cmbTipo.SelectedIndex = 0 Then
            gpEmpleado.Visible = True
            TextPagina.Visible = False
            lbFinal.Visible = False
            gpFecha.Text = "PERIODO"
            cmbMesI.Visible = True
            cmbMesF.Visible = True
            TextAñof.Visible = False
            cmbAñoI.Visible = True
            cmbAñof.Visible = True
            lbInicial.Text = ""
            lbDe.Visible = True
            lbA.Visible = True
            For cont = 2008 To Today.Year + 20
                cmbAñoI.Items.Add(CStr(cont))
                cmbAñof.Items.Add(CStr(cont))
            Next cont
            'cmbTipo.SelectedIndex = 2
        ElseIf cmbTipo.SelectedIndex = 1 Then
            TextPagina.Visible = True
            lbFinal.Visible = True
            gpFecha.Text = "PAGINA"
            cmbMesI.Visible = False
            cmbMesF.Visible = False
            TextAñof.Visible = True
            cmbAñoI.Visible = False
            cmbAñof.Visible = False
            lbInicial.Text = "INICIAL"
            lbFinal.Text = "FINAL"
            lbDe.Visible = False
            lbA.Visible = False
        End If
    End Sub



#Region "EMLEADO"


    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmpleado.Clear()
        If valbool = True Then
            textEmpleado.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Int32
        Dim nombreTabla As String = ""
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = textNombreEmpleado.Text.Trim
        If cmbTipo.SelectedIndex <> 2 Then
            nombreTabla = "v_empleadosNuevo"
        Else
            nombreTabla = "v_empleadosAnterior"
        End If
        cadena = "select empleado, nombre from " & nombreTabla & " where empresa=@empresa and nombre like '%' + @nombre + '%'  order by nombre"

        numFilas = llenaTabla(cadena, tbEmpleado, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado(True)
            textEmpleado.Clear()
        ElseIf numFilas = 1 Then
            BorraEmpleado(True)
            filaTemp = tbEmpleado.Rows.Item(0)
            textEmpleado.Text() = filaTemp.Item(0)
            textNombreEmpleado.Text = filaTemp.Item(1)
            cmbMesI.Focus()
        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        Dim nombreTabla As String = ""
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text.Trim
        If cmbTipo.SelectedIndex <> 2 Then
            nombreTabla = "v_empleadosNuevo"
        Else
            nombreTabla = "v_empleadosAnterior"
        End If
        If valida_tipo_Entero(textEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from " & nombreTabla & " where empresa=@empresa and empleado=@empleado", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textEmpleado.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from " & nombreTabla & " where empresa=@empresa and empleado=@empleado"
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraEmpleado(False)
                dr.Read()
                textNombreEmpleado.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
                cmbMesI.Focus()
            Else
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL EMPLEADO POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraEmpleado(True)
            textEmpleado.Focus()
        End If
    End Sub

    Private Sub TextEmpleado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textEmpleado.Validated
        If textEmpleado.Text.Trim <> "" Then
            ValidaEmpleado()
        Else
            BorraEmpleado(False)
        End If
    End Sub

    Private Sub EnBuscaEmpleado()
        fEMp = New frmMuestraCodigos
        fEMp.TopMost = True
        fEMp.inicializa(tbEmpleado)
        AddHandler fEMp.actValor, AddressOf ActualizacionDatosEmpleados
        fEMp.StartPosition = FormStartPosition.CenterScreen
        fEMp.ShowDialog()
        cmbMesI.Focus()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        textEmpleado.Text() = filaTemp.Item(0)
        textNombreEmpleado.Text = filaTemp.Item(1)
    End Sub





#End Region

    

    
End Class
