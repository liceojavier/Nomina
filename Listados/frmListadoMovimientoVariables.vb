Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMLISTADOMOVIMIENTOVARIABLES.VB MIEMBRO DE NOMINA.SLN                      **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmListadoMovimientoVariables
    Inherits Form
    Dim cadena As String

    Dim tbTipoNom As New DataTable("tipo")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbContratos As New DataTable("contratos")

    Dim comando As SqlCommand

    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim v As New cryListadoMovVariables
    Dim tt As New DataTable("datos")
    Dim WithEvents fEMp As frmMuestraCodigos
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageNuevo As ImageList
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
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents cmbMesI As System.Windows.Forms.ComboBox
    Friend WithEvents gpContrato As System.Windows.Forms.GroupBox
    Friend WithEvents btnContrato As System.Windows.Forms.Button
    Friend WithEvents TextConxContrato As System.Windows.Forms.TextBox
    Friend WithEvents gpChofer As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents textEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents gpTipo As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents gpTipoNomina As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipoNomina As System.Windows.Forms.ComboBox


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoMovimientoVariables))
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.cmbMesI = New System.Windows.Forms.ComboBox()
        Me.TextAñoI = New System.Windows.Forms.TextBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevo = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.gpContrato = New System.Windows.Forms.GroupBox()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.TextConxContrato = New System.Windows.Forms.TextBox()
        Me.gpChofer = New System.Windows.Forms.GroupBox()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textEmpleado = New System.Windows.Forms.TextBox()
        Me.gpTipo = New System.Windows.Forms.GroupBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.gpTipoNomina = New System.Windows.Forms.GroupBox()
        Me.cmbTipoNomina = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gpFecha.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpContrato.SuspendLayout()
        Me.gpChofer.SuspendLayout()
        Me.gpTipo.SuspendLayout()
        Me.gpTipoNomina.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpFecha
        '
        Me.gpFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpFecha.Controls.Add(Me.cmbMesI)
        Me.gpFecha.Controls.Add(Me.TextAñoI)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.ForeColor = System.Drawing.Color.White
        Me.gpFecha.Location = New System.Drawing.Point(677, 8)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(224, 48)
        Me.gpFecha.TabIndex = 5
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Periodo"
        '
        'cmbMesI
        '
        Me.cmbMesI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMesI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMesI.Location = New System.Drawing.Point(6, 20)
        Me.cmbMesI.Name = "cmbMesI"
        Me.cmbMesI.Size = New System.Drawing.Size(149, 21)
        Me.cmbMesI.TabIndex = 1
        '
        'TextAñoI
        '
        Me.TextAñoI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAñoI.Location = New System.Drawing.Point(161, 20)
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
        Me.btnEjecutar.ImageList = Me.ImageNuevo
        Me.btnEjecutar.Location = New System.Drawing.Point(995, 3)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(80, 30)
        Me.btnEjecutar.TabIndex = 5
        Me.btnEjecutar.Text = "Generar"
        Me.btnEjecutar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEjecutar, "Generar el proceso")
        Me.btnEjecutar.UseVisualStyleBackColor = False
        '
        'ImageNuevo
        '
        Me.ImageNuevo.ImageStream = CType(resources.GetObject("ImageNuevo.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageNuevo.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageNuevo.Images.SetKeyName(0, "actualizar.png")
        Me.ImageNuevo.Images.SetKeyName(1, "agregar1.png")
        Me.ImageNuevo.Images.SetKeyName(2, "alumno.png")
        Me.ImageNuevo.Images.SetKeyName(3, "anterior.png")
        Me.ImageNuevo.Images.SetKeyName(4, "anterior1.png")
        Me.ImageNuevo.Images.SetKeyName(5, "anulado.png")
        Me.ImageNuevo.Images.SetKeyName(6, "aprobar.png")
        Me.ImageNuevo.Images.SetKeyName(7, "asignar1.png")
        Me.ImageNuevo.Images.SetKeyName(8, "asignar2.png")
        Me.ImageNuevo.Images.SetKeyName(9, "bar.png")
        Me.ImageNuevo.Images.SetKeyName(10, "blanco.png")
        Me.ImageNuevo.Images.SetKeyName(11, "buscar1.png")
        Me.ImageNuevo.Images.SetKeyName(12, "buscar2.png")
        Me.ImageNuevo.Images.SetKeyName(13, "cancelar.png")
        Me.ImageNuevo.Images.SetKeyName(14, "candado.png")
        Me.ImageNuevo.Images.SetKeyName(15, "checkok.png")
        Me.ImageNuevo.Images.SetKeyName(16, "detalle.png")
        Me.ImageNuevo.Images.SetKeyName(17, "download.png")
        Me.ImageNuevo.Images.SetKeyName(18, "edit1.png")
        Me.ImageNuevo.Images.SetKeyName(19, "edit2.png")
        Me.ImageNuevo.Images.SetKeyName(20, "familia.png")
        Me.ImageNuevo.Images.SetKeyName(21, "fecha.png")
        Me.ImageNuevo.Images.SetKeyName(22, "guardar.png")
        Me.ImageNuevo.Images.SetKeyName(23, "impresora2.png")
        Me.ImageNuevo.Images.SetKeyName(24, "imprimir.png")
        Me.ImageNuevo.Images.SetKeyName(25, "limpiar.png")
        Me.ImageNuevo.Images.SetKeyName(26, "mas.png")
        Me.ImageNuevo.Images.SetKeyName(27, "menos.png")
        Me.ImageNuevo.Images.SetKeyName(28, "mostrar.png")
        Me.ImageNuevo.Images.SetKeyName(29, "open.png")
        Me.ImageNuevo.Images.SetKeyName(30, "porcentaje.png")
        Me.ImageNuevo.Images.SetKeyName(31, "reportegenerar.png")
        Me.ImageNuevo.Images.SetKeyName(32, "reportever.png")
        Me.ImageNuevo.Images.SetKeyName(33, "secretary.png")
        Me.ImageNuevo.Images.SetKeyName(34, "siguiente.png")
        Me.ImageNuevo.Images.SetKeyName(35, "siguiente2.png")
        Me.ImageNuevo.Images.SetKeyName(36, "upload.png")
        Me.ImageNuevo.Images.SetKeyName(37, "usuario.png")
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevo
        Me.btnLimpiar.Location = New System.Drawing.Point(995, 39)
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
        Me.btnEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevo
        Me.btnEmpleado.Location = New System.Drawing.Point(520, 10)
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
        Me.crv.Location = New System.Drawing.Point(0, 126)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.ShowCloseButton = False
        Me.crv.ShowGotoPageButton = False
        Me.crv.ShowTextSearchButton = False
        Me.crv.Size = New System.Drawing.Size(1130, 479)
        Me.crv.TabIndex = 57
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'gpContrato
        '
        Me.gpContrato.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpContrato.Controls.Add(Me.btnContrato)
        Me.gpContrato.Controls.Add(Me.TextConxContrato)
        Me.gpContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpContrato.ForeColor = System.Drawing.Color.White
        Me.gpContrato.Location = New System.Drawing.Point(764, 61)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(137, 50)
        Me.gpContrato.TabIndex = 4
        Me.gpContrato.TabStop = False
        Me.gpContrato.Text = "Contrato"
        '
        'btnContrato
        '
        Me.btnContrato.BackColor = System.Drawing.SystemColors.Control
        Me.btnContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContrato.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnContrato.ImageKey = "buscar2.png"
        Me.btnContrato.ImageList = Me.ImageNuevo
        Me.btnContrato.Location = New System.Drawing.Point(79, 12)
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
        Me.gpChofer.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpChofer.Controls.Add(Me.btnEmpleado)
        Me.gpChofer.Controls.Add(Me.textNombreEmple)
        Me.gpChofer.Controls.Add(Me.textEmpleado)
        Me.gpChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpChofer.ForeColor = System.Drawing.Color.White
        Me.gpChofer.Location = New System.Drawing.Point(176, 60)
        Me.gpChofer.Name = "gpChofer"
        Me.gpChofer.Size = New System.Drawing.Size(582, 50)
        Me.gpChofer.TabIndex = 3
        Me.gpChofer.TabStop = False
        Me.gpChofer.Text = "Empleado"
        '
        'textNombreEmple
        '
        Me.textNombreEmple.BackColor = System.Drawing.Color.White
        Me.textNombreEmple.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombreEmple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombreEmple.Location = New System.Drawing.Point(69, 24)
        Me.textNombreEmple.MaxLength = 40
        Me.textNombreEmple.Name = "textNombreEmple"
        Me.textNombreEmple.Size = New System.Drawing.Size(448, 20)
        Me.textNombreEmple.TabIndex = 2
        '
        'textEmpleado
        '
        Me.textEmpleado.BackColor = System.Drawing.Color.White
        Me.textEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textEmpleado.Location = New System.Drawing.Point(10, 24)
        Me.textEmpleado.MaxLength = 6
        Me.textEmpleado.Name = "textEmpleado"
        Me.textEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textEmpleado.TabIndex = 1
        '
        'gpTipo
        '
        Me.gpTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpTipo.Controls.Add(Me.cmbTipo)
        Me.gpTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTipo.ForeColor = System.Drawing.Color.White
        Me.gpTipo.Location = New System.Drawing.Point(176, 8)
        Me.gpTipo.Name = "gpTipo"
        Me.gpTipo.Size = New System.Drawing.Size(238, 48)
        Me.gpTipo.TabIndex = 1
        Me.gpTipo.TabStop = False
        Me.gpTipo.Text = "Tipo de listado"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Items.AddRange(New Object() {"GENERAL", "POR EMPLEADO"})
        Me.cmbTipo.Location = New System.Drawing.Point(8, 20)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(222, 21)
        Me.cmbTipo.TabIndex = 2
        '
        'gpTipoNomina
        '
        Me.gpTipoNomina.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpTipoNomina.Controls.Add(Me.cmbTipoNomina)
        Me.gpTipoNomina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTipoNomina.ForeColor = System.Drawing.Color.White
        Me.gpTipoNomina.Location = New System.Drawing.Point(417, 8)
        Me.gpTipoNomina.Name = "gpTipoNomina"
        Me.gpTipoNomina.Size = New System.Drawing.Size(256, 48)
        Me.gpTipoNomina.TabIndex = 2
        Me.gpTipoNomina.TabStop = False
        Me.gpTipoNomina.Text = "Tipo de nómina"
        '
        'cmbTipoNomina
        '
        Me.cmbTipoNomina.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoNomina.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoNomina.Location = New System.Drawing.Point(6, 20)
        Me.cmbTipoNomina.Name = "cmbTipoNomina"
        Me.cmbTipoNomina.Size = New System.Drawing.Size(239, 21)
        Me.cmbTipoNomina.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpContrato)
        Me.Panel1.Controls.Add(Me.gpFecha)
        Me.Panel1.Controls.Add(Me.gpTipoNomina)
        Me.Panel1.Controls.Add(Me.gpChofer)
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Controls.Add(Me.gpTipo)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 120)
        Me.Panel1.TabIndex = 60
        '
        'frmListadoMovimientoVariables
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmListadoMovimientoVariables"
        Me.Text = "Listado de Movimientos Variables de Nómina"
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        Me.gpChofer.ResumeLayout(False)
        Me.gpChofer.PerformLayout()
        Me.gpTipo.ResumeLayout(False)
        Me.gpTipoNomina.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        cadena = "select nombre from meses order by mes"
        llena_combo(cadena, cmbMesI)
        cmbMesI.Items.Add("")

        cadena = "select nombre, tiponom from tiponomina1 where empresa=@empresa order by nombre"
        llena_combo(cadena, cmbTipoNomina, ListaParametros(lpara))
        llenaTabla(cadena, tbTipoNom, ListaParametros(lpara))
        cmbTipoNomina.Items.Add("")
        cmbTipo.SelectedIndex = 0
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
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = textNombreEmple.Text.Trim
        If textNombreEmple.Text.Trim <> "" Then
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa And nombre Like '%' + @nombre + '%'  order by nombre"
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
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text.Trim
        If valida_tipo_Entero(textEmpleado.Text, 2) = True Then
            If BuscaEscalar("Select count (*) from v_empleadosNuevo where empresa=@empresa And empleado=@empleado", ListaParametros(lpara)) = 0 Then
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
                     "where  c1.empresa=@empresa And empleado=@empleado"
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
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text
        lpara("contrato") = TextConxContrato.Text
        If TextConxContrato.Text.Trim <> "" And textEmpleado.Text.Trim <> "" Then
            cadena = "Select count(*) from contratos1 c1 inner join empestados e On e.estado=c1.estado And e.empresa=c1.empresa " &
                        "where c1.empresa=@empresa And empleado=@empleado And c1.contrato=@contrato "
            If BuscaEscalar(cadena, ListaParametros(lpara)) > 0 Then
                cmbMesI.Focus()
            Else
                MsgBox("ESTE NUMERO DE CONTRATO NO EXISTE PARA ESTE EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            End If
        Else
            TextConxContrato.Clear()
        End If
    End Sub


#End Region



    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        Dim añoi, mesi As Int32
        Dim condiciones As String = ""
        Select Case cmbTipo.SelectedIndex
            Case 0
                If Not validetError(cmbMesI, ep1) Or Not validetError(TextAñoI, ep1) Or Not validetError(cmbTipoNomina, ep1) Then
                    MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    Exit Sub
                End If
            Case 1
                If Not validetError(cmbMesI, ep1) Or Not validetError(TextAñoI, ep1) Or Not validetError(cmbTipoNomina, ep1) Or _
                     Not validetError(textEmpleado, ep1) Or Not validetError(TextConxContrato, ep1) Then
                    MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    Exit Sub
                End If
        End Select

        añoi = CInt(TextAñoI.Text)
        mesi = cmbMesI.SelectedIndex + 1

        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textEmpleado.Text
        lpara("contrato") = TextConxContrato.Text

        lpara("mes") = mesi
        lpara("año") = añoi
        lpara("tiponom") = tbTipoNom.Rows(cmbTipoNomina.SelectedIndex).Item(1)
        Select Case cmbTipo.SelectedIndex
            Case 1
                condiciones = " And empleado=@empleado And contrato=@contrato "
        End Select
        cadena = "Select * from  v_ListadoMoviVariables where empresa=@empresa And mes=@mes And año=@año " &
                " And tiponom=@tiponom " & condiciones & " order by nombre, año, mes"
        If llenaTabla(cadena, tt, ListaParametros(lpara)) > 0 Then

            v.SetDataSource(tt)
            crv.ReportSource = v
            crv.RefreshReport()
            crv.Refresh()
        Else
            MsgBox("NO EXISTEN MOVIMIENTOS INGRESADOS", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If

    End Sub

    Private Sub cmbMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub TextAño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextAñoI.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub


    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.Enter, textEmpleado.Enter, textNombreEmple.Enter, cmbMesI.Enter, TextAñoI.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub


    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.Leave, textEmpleado.Leave, textNombreEmple.Leave, cmbMesI.Leave, TextAñoI.Leave
        desactiva(sender)
    End Sub


    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        BorraEmpleado(True)
        borra_Mejorado(gpFecha, ep1)
        crv.ReportSource = Nothing
        cmbTipo.SelectedIndex = 0
    End Sub


    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        Select Case cmbTipo.SelectedIndex
            Case 0
                gpChofer.Visible = False
                gpContrato.Visible = False
            Case 1
                gpChofer.Visible = True
                gpContrato.Visible = True
        End Select
        cmbTipoNomina.Focus()
    End Sub

End Class
