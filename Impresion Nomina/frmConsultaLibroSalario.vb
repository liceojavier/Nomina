Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMCONSULTALIBROSALARIO.VB MIEMBRO DE NOMINA.SLN                            **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmConsultaLibroSalario
    Inherits Form
    Dim cadena As String

    Dim tbEmpresa As New DataTable("empresa")
    Dim tbTipo As New DataTable("tipo")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbContratos As New DataTable("contratos")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim v As New cryConsultaLibroSalario
    Dim tt As New DataTable("datos")
    Dim WithEvents fEMp As frmMuestraCodigos
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Dim WithEvents f2C As frmMuestra2Columnas
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
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents TextAñoI As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmbMesF As System.Windows.Forms.ComboBox
    Friend WithEvents TextAñof As System.Windows.Forms.TextBox
    Friend WithEvents cmbMesI As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DEL As System.Windows.Forms.Label
    Friend WithEvents gpContrato As System.Windows.Forms.GroupBox
    Friend WithEvents btnContrato As System.Windows.Forms.Button
    Friend WithEvents TextConxContrato As System.Windows.Forms.TextBox
    Friend WithEvents gpChofer As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents textEmpleado As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaLibroSalario))
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DEL = New System.Windows.Forms.Label()
        Me.TextAñof = New System.Windows.Forms.TextBox()
        Me.cmbMesF = New System.Windows.Forms.ComboBox()
        Me.cmbMesI = New System.Windows.Forms.ComboBox()
        Me.TextAñoI = New System.Windows.Forms.TextBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.gpContrato = New System.Windows.Forms.GroupBox()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.TextConxContrato = New System.Windows.Forms.TextBox()
        Me.gpChofer = New System.Windows.Forms.GroupBox()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textEmpleado = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gpFecha.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpContrato.SuspendLayout()
        Me.gpChofer.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpFecha
        '
        Me.gpFecha.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpFecha.Controls.Add(Me.Label2)
        Me.gpFecha.Controls.Add(Me.DEL)
        Me.gpFecha.Controls.Add(Me.TextAñof)
        Me.gpFecha.Controls.Add(Me.cmbMesF)
        Me.gpFecha.Controls.Add(Me.cmbMesI)
        Me.gpFecha.Controls.Add(Me.TextAñoI)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.ForeColor = System.Drawing.Color.White
        Me.gpFecha.Location = New System.Drawing.Point(620, 46)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(500, 51)
        Me.gpFecha.TabIndex = 3
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Periodo"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(255, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Al:"
        '
        'DEL
        '
        Me.DEL.AutoSize = True
        Me.DEL.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DEL.Location = New System.Drawing.Point(6, 21)
        Me.DEL.Name = "DEL"
        Me.DEL.Size = New System.Drawing.Size(24, 13)
        Me.DEL.TabIndex = 9
        Me.DEL.Text = "De:"
        '
        'TextAñof
        '
        Me.TextAñof.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAñof.Location = New System.Drawing.Point(438, 18)
        Me.TextAñof.MaxLength = 4
        Me.TextAñof.Name = "TextAñof"
        Me.TextAñof.Size = New System.Drawing.Size(56, 20)
        Me.TextAñof.TabIndex = 4
        '
        'cmbMesF
        '
        Me.cmbMesF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMesF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMesF.Location = New System.Drawing.Point(283, 18)
        Me.cmbMesF.Name = "cmbMesF"
        Me.cmbMesF.Size = New System.Drawing.Size(149, 21)
        Me.cmbMesF.TabIndex = 3
        '
        'cmbMesI
        '
        Me.cmbMesI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMesI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMesI.Location = New System.Drawing.Point(36, 18)
        Me.cmbMesI.Name = "cmbMesI"
        Me.cmbMesI.Size = New System.Drawing.Size(149, 21)
        Me.cmbMesI.TabIndex = 1
        '
        'TextAñoI
        '
        Me.TextAñoI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAñoI.Location = New System.Drawing.Point(191, 18)
        Me.TextAñoI.MaxLength = 4
        Me.TextAñoI.Name = "TextAñoI"
        Me.TextAñoI.Size = New System.Drawing.Size(56, 20)
        Me.TextAñoI.TabIndex = 2
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
        Me.btnEjecutar.TabIndex = 5
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
        Me.btnLimpiar.TabIndex = 59
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
        Me.btnEmpleado.Location = New System.Drawing.Point(415, 14)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(60, 30)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEmpleado, "Empleado")
        Me.btnEmpleado.UseVisualStyleBackColor = False
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(337, 0)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(456, 43)
        Me.gpEmpresa.TabIndex = 56
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(11, 16)
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(435, 21)
        Me.TextNombEmpresa.TabIndex = 2
        Me.TextNombEmpresa.TabStop = False
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
        Me.crv.Location = New System.Drawing.Point(0, 103)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.ShowCloseButton = False
        Me.crv.ShowGotoPageButton = False
        Me.crv.ShowTextSearchButton = False
        Me.crv.Size = New System.Drawing.Size(1130, 502)
        Me.crv.TabIndex = 57
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'gpContrato
        '
        Me.gpContrato.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpContrato.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpContrato.Controls.Add(Me.btnContrato)
        Me.gpContrato.Controls.Add(Me.TextConxContrato)
        Me.gpContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpContrato.ForeColor = System.Drawing.Color.White
        Me.gpContrato.Location = New System.Drawing.Point(493, 46)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(121, 50)
        Me.gpContrato.TabIndex = 2
        Me.gpContrato.TabStop = False
        Me.gpContrato.Text = "Contrato"
        '
        'btnContrato
        '
        Me.btnContrato.BackColor = System.Drawing.SystemColors.Control
        Me.btnContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContrato.ImageKey = "buscar2.png"
        Me.btnContrato.ImageList = Me.ImageNuevos
        Me.btnContrato.Location = New System.Drawing.Point(77, 14)
        Me.btnContrato.Name = "btnContrato"
        Me.btnContrato.Size = New System.Drawing.Size(40, 32)
        Me.btnContrato.TabIndex = 16
        Me.btnContrato.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnContrato.UseVisualStyleBackColor = False
        '
        'TextConxContrato
        '
        Me.TextConxContrato.BackColor = System.Drawing.Color.White
        Me.TextConxContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConxContrato.ForeColor = System.Drawing.Color.Red
        Me.TextConxContrato.Location = New System.Drawing.Point(10, 24)
        Me.TextConxContrato.MaxLength = 4
        Me.TextConxContrato.Name = "TextConxContrato"
        Me.TextConxContrato.Size = New System.Drawing.Size(63, 20)
        Me.TextConxContrato.TabIndex = 1
        Me.TextConxContrato.TabStop = False
        '
        'gpChofer
        '
        Me.gpChofer.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpChofer.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpChofer.Controls.Add(Me.btnEmpleado)
        Me.gpChofer.Controls.Add(Me.textNombreEmple)
        Me.gpChofer.Controls.Add(Me.textEmpleado)
        Me.gpChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpChofer.ForeColor = System.Drawing.Color.White
        Me.gpChofer.Location = New System.Drawing.Point(5, 47)
        Me.gpChofer.Name = "gpChofer"
        Me.gpChofer.Size = New System.Drawing.Size(483, 50)
        Me.gpChofer.TabIndex = 1
        Me.gpChofer.TabStop = False
        Me.gpChofer.Text = "Empleado"
        '
        'textNombreEmple
        '
        Me.textNombreEmple.BackColor = System.Drawing.Color.White
        Me.textNombreEmple.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombreEmple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombreEmple.Location = New System.Drawing.Point(66, 24)
        Me.textNombreEmple.MaxLength = 40
        Me.textNombreEmple.Name = "textNombreEmple"
        Me.textNombreEmple.Size = New System.Drawing.Size(346, 20)
        Me.textNombreEmple.TabIndex = 2
        '
        'textEmpleado
        '
        Me.textEmpleado.BackColor = System.Drawing.Color.White
        Me.textEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textEmpleado.Location = New System.Drawing.Point(6, 24)
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
        Me.Panel1.Controls.Add(Me.gpContrato)
        Me.Panel1.Controls.Add(Me.gpFecha)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gpChofer)
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 103)
        Me.Panel1.TabIndex = 60
        '
        'frmConsultaLibroSalario
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmConsultaLibroSalario"
        Me.Text = "Consulta de Historial de Pagos"
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        Me.gpChofer.ResumeLayout(False)
        Me.gpChofer.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        cadena = "select nombre from meses order by mes"
        llena_combo(cadena, cmbMesI)
        llena_combo(cadena, cmbMesF)
        cmbMesF.Items.Add("")
        cmbMesI.Items.Add("")
        TextNombEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=@empresa", ListaParametros(lpara))
        cadena = "select nombre, tiponom, cantidad, por, movimientos, desprestamos from tiponomina1 where empresa=" &
        empresa
        TextAñoI.Text = Today.Year
        TextAñoI.Text = Today.Year
    End Sub


#Region "EMLEADO"


    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        TextConxContrato.Clear()
        If valbool = True Then
            textEmpleado.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Int32
        lpara("empresa") = empresa
        lpara("nombre") = textNombreEmple.Text.Trim
        If textNombreEmple.Text.Trim <> "" Then
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and nombre like '%' + @nombre + '%'  order by nombre"
        Else
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa  order by nombre"
        End If
        numFilas = llenaTabla(cadena, tbEmpleado, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado(True)
            textEmpleado.Clear()
        ElseIf numFilas = 1 Then
            BorraEmpleado(True)
            filaTemp = tbEmpleado.Rows.Item(0)
            textEmpleado.Text() = filaTemp.Item(0)
            textNombreEmple.Text = filaTemp.Item(1)
            TextConxContrato.Focus()
        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        lpara.Clear()
        lpara("empleado") = textEmpleado.Text.Trim
        lpara("empresa") = empresa
        If valida_tipo_Entero(textEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=@empresa And empleado=@empleado", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textEmpleado.Focus()
                Exit Sub
            End If
            cadena = "Select empleado, nombre from v_empleadosNuevo where empresa=@empresa And empleado=@empleado"
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraEmpleado(False)
                dr.Read()
                textNombreEmple.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
                TextConxContrato.Focus()
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
        TextConxContrato.Focus()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        textEmpleado.Text() = filaTemp.Item(0)
        textNombreEmple.Text = filaTemp.Item(1)
    End Sub

#End Region

#Region "Contrato"

    Private Sub BtnContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContrato.Click
        Dim Num As Int16
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text
        If textEmpleado.Text.Trim <> "" Then
            cadena = "Select contrato, pu.nombre from contratos1 c1 inner join empestados e On e.estado=c1.estado And e.empresa=c1.empresa " &
                     "inner join puestosper pu On pu.empresa=c1.empresa And pu.puesto=c1.puesto " &
                     "where c1.empresa=@empresa And empleado=@empleado"
            Num = llenaTabla(cadena, tbContratos, ListaParametros(lpara))
            If Num = 1 Then
                TextConxContrato.Text = tbContratos.Rows(0).Item(0)
            ElseIf Num > 1 Then
                f2C = New frmMuestra2Columnas
                f2C.TopMost = True
                f2C.inicializa(tbContratos, "CONTRATO", "PUESTO", 0)
                AddHandler f2C.actValor, AddressOf ActualizacionDatosContrato
                f2C.StartPosition = FormStartPosition.CenterScreen
                f2C.ShowDialog()
                cmbMesI.Focus()

            ElseIf Num = 0 Then
                MsgBox("ESTE EMPLEADO NO TIENE CONTRATOS ACTIVOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            End If
        Else
            MsgBox("INGRESO PRIMERO EL EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ActualizacionDatosContrato(ByVal sender As Object, ByVal e As clsActValorREvento)
        filaTemp = tbContratos.Rows(e.va2)
        TextConxContrato.Text() = filaTemp.Item(0)
    End Sub


    Private Sub TextConxContrato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextConxContrato.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub TextConxContrato_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextConxContrato.Validated
        lpara.Clear()
        Dim empleado As Int32
        Dim contrato As Short = 0
        If Int32.TryParse(textEmpleado.Text, empleado) And Short.TryParse(TextConxContrato.Text, contrato) Then
            lpara("empresa") = empresa
            lpara("empleado") = empleado
            lpara("contrato") = contrato
            If TextConxContrato.Text.Trim <> "" And textEmpleado.Text.Trim <> "" Then
                cadena = "Select count(*)  from contratos1 c1 inner join empestados e On e.estado=c1.estado And e.empresa=c1.empresa " &
                         "where c1.empresa=@empresa And empleado=@empleado And c1.contrato=@contrato"
                If BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                    cmbMesI.Focus()
                Else
                    MsgBox("ESTE NUMERO DE CONTRATO NO EXISTE PARA ESTE EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                    TextConxContrato.Clear()
                End If
            Else
                TextConxContrato.Clear()
            End If
        End If


    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        Dim añoi, añof, mesi, mesf As Int32
        Dim fechaFin As Date
        Dim fechaInc As Date
        lpara.Clear()
        If Not validetError(cmbMesI, ep1) Or Not validetError(TextAñoI, ep1) Or Not validetError(cmbMesF, ep1) Or _
           Not validetError(TextAñof, ep1) Or Not validetError(textEmpleado, ep1) Or Not validetError(TextConxContrato, ep1) Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If
        añoi = CInt(TextAñoI.Text)
        añof = CInt(TextAñof.Text)
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
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text
        lpara("contrato") = TextConxContrato.Text
        lpara("fechai") = fechaInc
        lpara("fechaf") = fechaFin
        lpara("mesi") = mesi
        lpara("mesf") = mesf
        lpara("añoi") = añoi
        lpara("añof") = añof
        cadena = "Select * from ConsultaLibroSalariosExt (@empresa,@empleado,@contrato,@fechai,@fechaf)" &
                "union all " &
                "select * from ConsultaLibroSalariosNom (@empresa,@mesi,@mesf,@añoi,@añof,@empleado,@contrato) order by  fechapago,año, mes, transac"
        llenaTabla(cadena, tbEmpresa, ListaParametros(lpara))
        If llenaTabla(cadena, tt, ListaParametros(lpara)) > 0 Then

            v.SetDataSource(tt)
            crv.ReportSource = v
            ' crv.RefreshReport()
            v.SetParameterValue("mesi", mesi)
            v.SetParameterValue("mesf", mesf)
            v.SetParameterValue("añoi", añoi)
            v.SetParameterValue("añof", añof)

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

    Private Sub TextAño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextAñoI.KeyPress, TextAñof.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub


    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        BorraEmpleado(True)
        borra_Mejorado(gpFecha, ep1)
        crv.ReportSource = Nothing
    End Sub
End Class
