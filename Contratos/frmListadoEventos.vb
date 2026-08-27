Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMLISTADOEVENTOS.VB MIEMBRO DE NOMINA.SLN                                  **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmListadoEventos
    Inherits Form
    Dim cadena As String


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
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents gpContrato As System.Windows.Forms.GroupBox
    Friend WithEvents btnContrato As System.Windows.Forms.Button
    Friend WithEvents TextConxContrato As System.Windows.Forms.TextBox
    Friend WithEvents gpChofer As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents textEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents gpEventos As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipoEvento As System.Windows.Forms.ComboBox
    Friend WithEvents cmbTipoAccion As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMotivoEvento As System.Windows.Forms.ComboBox
    Friend WithEvents lbtipoEvento As System.Windows.Forms.Label
    Friend WithEvents lbTipoAccion As System.Windows.Forms.Label
    Friend WithEvents lbmotivoEvento As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtpFechaF As DateTimePicker
    Friend WithEvents dtpFechaI As DateTimePicker
    Friend WithEvents lbFechaini As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoEventos))
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
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
        Me.gpEventos = New System.Windows.Forms.GroupBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lbTipoAccion = New System.Windows.Forms.Label()
        Me.lbFechaini = New System.Windows.Forms.Label()
        Me.lbmotivoEvento = New System.Windows.Forms.Label()
        Me.lbtipoEvento = New System.Windows.Forms.Label()
        Me.cmbTipoAccion = New System.Windows.Forms.ComboBox()
        Me.cmbMotivoEvento = New System.Windows.Forms.ComboBox()
        Me.cmbTipoEvento = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpFechaI = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechaF = New System.Windows.Forms.DateTimePicker()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpContrato.SuspendLayout()
        Me.gpChofer.SuspendLayout()
        Me.gpEventos.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "reportegenerar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(970, 5)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(75, 30)
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
        Me.btnLimpiar.Location = New System.Drawing.Point(1051, 5)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(69, 30)
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
        Me.btnEmpleado.Location = New System.Drawing.Point(520, 8)
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
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv.Location = New System.Drawing.Point(0, 101)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.ShowCloseButton = False
        Me.crv.ShowGotoPageButton = False
        Me.crv.ShowTextSearchButton = False
        Me.crv.Size = New System.Drawing.Size(1130, 504)
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
        Me.gpContrato.Location = New System.Drawing.Point(622, 5)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(137, 41)
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
        Me.btnContrato.Location = New System.Drawing.Point(79, 7)
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
        Me.TextConxContrato.Location = New System.Drawing.Point(10, 16)
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
        Me.gpChofer.Location = New System.Drawing.Point(12, 5)
        Me.gpChofer.Name = "gpChofer"
        Me.gpChofer.Size = New System.Drawing.Size(586, 42)
        Me.gpChofer.TabIndex = 1
        Me.gpChofer.TabStop = False
        Me.gpChofer.Text = "Empleado"
        '
        'textNombreEmple
        '
        Me.textNombreEmple.BackColor = System.Drawing.Color.White
        Me.textNombreEmple.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombreEmple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombreEmple.Location = New System.Drawing.Point(66, 16)
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
        Me.textEmpleado.Location = New System.Drawing.Point(6, 16)
        Me.textEmpleado.MaxLength = 6
        Me.textEmpleado.Name = "textEmpleado"
        Me.textEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textEmpleado.TabIndex = 1
        '
        'gpEventos
        '
        Me.gpEventos.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEventos.Controls.Add(Me.dtpFechaF)
        Me.gpEventos.Controls.Add(Me.Label2)
        Me.gpEventos.Controls.Add(Me.dtpFechaI)
        Me.gpEventos.Controls.Add(Me.lbTipoAccion)
        Me.gpEventos.Controls.Add(Me.lbFechaini)
        Me.gpEventos.Controls.Add(Me.lbmotivoEvento)
        Me.gpEventos.Controls.Add(Me.lbtipoEvento)
        Me.gpEventos.Controls.Add(Me.cmbTipoAccion)
        Me.gpEventos.Controls.Add(Me.cmbMotivoEvento)
        Me.gpEventos.Controls.Add(Me.cmbTipoEvento)
        Me.gpEventos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEventos.ForeColor = System.Drawing.Color.White
        Me.gpEventos.Location = New System.Drawing.Point(12, 53)
        Me.gpEventos.Name = "gpEventos"
        Me.gpEventos.Size = New System.Drawing.Size(1069, 42)
        Me.gpEventos.TabIndex = 3
        Me.gpEventos.TabStop = False
        Me.gpEventos.Text = "Eventos"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(933, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(19, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Al:"
        '
        'lbTipoAccion
        '
        Me.lbTipoAccion.AutoSize = True
        Me.lbTipoAccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbTipoAccion.Location = New System.Drawing.Point(505, 18)
        Me.lbTipoAccion.Name = "lbTipoAccion"
        Me.lbTipoAccion.Size = New System.Drawing.Size(66, 13)
        Me.lbTipoAccion.TabIndex = 5
        Me.lbTipoAccion.Text = "Tipo acción:"
        '
        'lbFechaini
        '
        Me.lbFechaini.AutoSize = True
        Me.lbFechaini.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFechaini.Location = New System.Drawing.Point(794, 17)
        Me.lbFechaini.Name = "lbFechaini"
        Me.lbFechaini.Size = New System.Drawing.Size(26, 13)
        Me.lbFechaini.TabIndex = 12
        Me.lbFechaini.Text = "Del:"
        '
        'lbmotivoEvento
        '
        Me.lbmotivoEvento.AutoSize = True
        Me.lbmotivoEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbmotivoEvento.Location = New System.Drawing.Point(242, 19)
        Me.lbmotivoEvento.Name = "lbmotivoEvento"
        Me.lbmotivoEvento.Size = New System.Drawing.Size(42, 13)
        Me.lbmotivoEvento.TabIndex = 4
        Me.lbmotivoEvento.Text = "Motivo:"
        '
        'lbtipoEvento
        '
        Me.lbtipoEvento.AutoSize = True
        Me.lbtipoEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbtipoEvento.Location = New System.Drawing.Point(6, 18)
        Me.lbtipoEvento.Name = "lbtipoEvento"
        Me.lbtipoEvento.Size = New System.Drawing.Size(31, 13)
        Me.lbtipoEvento.TabIndex = 3
        Me.lbtipoEvento.Text = "Tipo:"
        '
        'cmbTipoAccion
        '
        Me.cmbTipoAccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoAccion.FormattingEnabled = True
        Me.cmbTipoAccion.Location = New System.Drawing.Point(581, 15)
        Me.cmbTipoAccion.Name = "cmbTipoAccion"
        Me.cmbTipoAccion.Size = New System.Drawing.Size(207, 21)
        Me.cmbTipoAccion.TabIndex = 2
        '
        'cmbMotivoEvento
        '
        Me.cmbMotivoEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMotivoEvento.FormattingEnabled = True
        Me.cmbMotivoEvento.Location = New System.Drawing.Point(289, 15)
        Me.cmbMotivoEvento.Name = "cmbMotivoEvento"
        Me.cmbMotivoEvento.Size = New System.Drawing.Size(210, 21)
        Me.cmbMotivoEvento.TabIndex = 1
        '
        'cmbTipoEvento
        '
        Me.cmbTipoEvento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoEvento.FormattingEnabled = True
        Me.cmbTipoEvento.Location = New System.Drawing.Point(43, 14)
        Me.cmbTipoEvento.Name = "cmbTipoEvento"
        Me.cmbTipoEvento.Size = New System.Drawing.Size(193, 21)
        Me.cmbTipoEvento.TabIndex = 0
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpEventos)
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Controls.Add(Me.gpContrato)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gpChofer)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 101)
        Me.Panel1.TabIndex = 60
        '
        'dtpFechaI
        '
        Me.dtpFechaI.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaI.Location = New System.Drawing.Point(826, 14)
        Me.dtpFechaI.Name = "dtpFechaI"
        Me.dtpFechaI.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaI.TabIndex = 60
        '
        'dtpFechaF
        '
        Me.dtpFechaF.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaF.Location = New System.Drawing.Point(958, 15)
        Me.dtpFechaF.Name = "dtpFechaF"
        Me.dtpFechaF.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaF.TabIndex = 61
        '
        'frmListadoEventos
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmListadoEventos"
        Me.Text = "Listado Eventos"
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        Me.gpChofer.ResumeLayout(False)
        Me.gpChofer.PerformLayout()
        Me.gpEventos.ResumeLayout(False)
        Me.gpEventos.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Dim tbTipo As New DataTable("tipo")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbContratos As New DataTable("contratos")
    Dim tbCodigo As New DataTable("codigo")
    Dim tbMotivoEvento As New DataTable("motivos")
    Dim tbTipoAccion As New DataTable("tipoacciones")
    Dim tbTipoEvento As New DataTable("tipoevento")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim v As New CryListadoGratificacionesySanciones
    Dim tt As New DataTable("datos")
    Dim WithEvents fEMp As frmMuestraCodigos
    Dim nombreEmpresa As String
    Dim WithEvents f2C As frmMuestra2Columnas



    Private Sub frmSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'cadena = "select nombre from meses order by mes"

        cadena = "select nombre,tipoevento from  tiposeventos"
        llena_combo(cadena, cmbTipoEvento)
        llenaTabla(cadena, tbTipoEvento)
        cadena = "select nombre,motivo from motivoeventos"
        llena_combo(cadena, cmbMotivoEvento)
        llenaTabla(cadena, tbMotivoEvento)
        cadena = "select nombre,tipoaccion from tipoacciones"
        llena_combo(cadena, cmbTipoAccion)
        llenaTabla(cadena, tbTipoAccion)
        nombreEmpresa = BuscaEscalar("select nombre from empresas where empresa=" & empresa)
    End Sub


#Region "EMPLEADO"


    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        TextConxContrato.Clear()
        If valbool = True Then
            textEmpleado.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Int32
        If textNombreEmple.Text.Trim <> "" Then
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=" & empresa & " and nombre like '%" &
            textNombreEmple.Text.Trim & "%'  order by nombre"
        Else
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=" & empresa & "  order by nombre"
        End If
        numFilas = llenaTabla(cadena, tbEmpleado)
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
        If valida_tipo_Entero(textEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=" & empresa &
                 " and empleado=" & textEmpleado.Text.Trim) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textEmpleado.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=" & empresa &
                 " and empleado=" & textEmpleado.Text.Trim
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
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
        If textEmpleado.Text.Trim <> "" Then
            cadena = "select contrato, pu.nombre from contratos1 c1 inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                     "inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " &
                     "where c1.empresa=" & empresa & " and empleado=" & textEmpleado.Text
            Num = llenaTabla(cadena, tbContratos)
            If Num = 1 Then
                TextConxContrato.Text = tbContratos.Rows(0).Item(0)
            ElseIf Num > 1 Then
                f2C = New frmMuestra2Columnas
                f2C.TopMost = True
                f2C.inicializa(tbContratos, "CONTRATO", "PUESTO", 0)
                AddHandler f2C.actValor, AddressOf ActualizacionDatosContrato
                f2C.StartPosition = FormStartPosition.CenterScreen
                f2C.ShowDialog()

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
        If TextConxContrato.Text.Trim <> "" And textEmpleado.Text.Trim <> "" Then
            cadena = "select count(*) from contratos1 c1 inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                        "where c1.empresa=" & empresa & " and empleado=" & textEmpleado.Text & " and c1.contrato=" &
                        TextConxContrato.Text
            If BuscaEscalar(cadena) > 0 Then
                dtpFechaI.Focus()
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
        Dim fechaI, fechaF As Date

        fechaI = dtpFechaI.Value.Date
        fechaF = dtpFechaF.Value.Date


        If fechaI > fechaF Then
            MsgBox("LA FECHA INICIAL DEBE SER MENOR QUE LA FECHA FINAL", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If
        cadena = cadena & " and fecha between '" & fechaI & "' and '" & fechaF & "' "

        cadena = "select * from V_ListadoGratificacionesySanciones where empresa = " & empresa & " "

        If cmbTipoEvento.Text <> "" Then
            cadena = cadena & " and tipoevento=" & tbTipoEvento.Rows(cmbTipoEvento.SelectedIndex).Item("tipoevento")
        End If

        If cmbMotivoEvento.Text <> "" Then
            cadena = cadena & " and motivo=" & tbMotivoEvento.Rows(cmbMotivoEvento.SelectedIndex).Item("motivo")
        End If
        If cmbTipoAccion.Text <> "" Then
            cadena = cadena & " and tipoaccion=" & tbTipoAccion.Rows(cmbTipoAccion.SelectedIndex).Item("tipoaccion")
        End If


        If textEmpleado.Text <> "" Then
            cadena = cadena & " and empleado=" & textEmpleado.Text
        End If

        If TextConxContrato.Text <> "" Then
            cadena = cadena & "and contrato=" & TextConxContrato.Text
        End If


        If llenaTabla(cadena, tt) > 0 Then

            v.SetDataSource(tt)
            v.SetParameterValue("valF1", fechaI)
            v.SetParameterValue("valF2", fechaF)
            crv.ReportSource = v

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

    Private Sub TextAño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        soloNumero(sender, e)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub


    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textEmpleado.Enter, textNombreEmple.Enter,
        cmbTipoAccion.Enter, cmbMotivoEvento.Enter, cmbTipoEvento.Enter, TextConxContrato.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub


    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles textEmpleado.Leave, textNombreEmple.Leave,
        cmbTipoAccion.Leave, cmbMotivoEvento.Leave, cmbTipoEvento.Leave, TextConxContrato.Leave
        desactiva(sender)
    End Sub


    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        dtpFechaI.Value = Today
        dtpFechaF.Value = Today
        BorraEmpleado(True)
        cmbMotivoEvento.SelectedIndex = -1
        cmbTipoAccion.SelectedIndex = -1
        cmbTipoEvento.SelectedIndex = -1
        crv.ReportSource = Nothing

    End Sub

    Private Sub gpEventos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gpEventos.Enter

    End Sub

    Private Sub cmbTipoEvento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipoEvento.SelectedIndexChanged

    End Sub

    
End Class
