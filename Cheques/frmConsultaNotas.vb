Imports System.Data.SqlClient
Imports System.Object
Imports System.Drawing.Printing

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMCONSULTANOTAS.VB MIEMBRO DE NOMINA.SLN                                   **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmConsultaNotas
    Inherits Form
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim cadena As String
    Dim indice As Int32
    Dim tbConsulta As New DataTable("consulta")
    Dim tbDetalle As New DataTable("detalle")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbContratos As New DataTable("contratos")
    Dim cadenaConsulta As String
    Dim fTemp, filaTemp As DataRow
    Dim tbAnulacion As New DataTable("anulacion")
    Dim tbDiario As New DataTable("diario")
    Dim fechaHoy As Date = System.DateTime.Today.ToShortDateString
    Dim WithEvents f As frmConsultaFechas
    Dim InicioConsulta As String = "select e1.inicial,e1.banco, e1.cheque, e1.fecha, e1.empleado, " & _
                                   "e1.contrato, e1.fechai, e1.fechaf, e1.concepto, e1.estado, e1.fechae, " & _
                                   "ch1.moneda, ch1.tasa, ch1.valor from extra1 e1 inner join notasban ch1 on " & _
                                   " e1.empresa=ch1.empresa and e1.cheque=ch1.nota " & _
                                   " where e1.tipo='NB' and e1.empresa=" & empresa

    Dim InicioConsulta2 As String = "select e2.transac, t.nombre, convert ( varchar, convert(money, cantidad), 1 ) as cantidad, " & _
                                     "convert ( varchar, convert ( money, valor), 1) as valor, " & _
                                     "tipomov, tipovalor, afectaSeguro " & _
                                     "from extra2 e2 inner join tipotran t " & _
                                     "on e2.empresa=t.empresa and  e2.transac=t.transac "
    Dim finConsulta As String
    Dim ConsultaFecha As String
    Dim cadenaFecha As String
    Dim chequeSub, bancoSub As Int32
    'Dim v As New cryEmisionCheque 
    Dim v As New ChequeEver
    Dim tt As New DataTable("impresion")
    Dim p As New PrinterSettings
    Dim psize As PaperSize
    Dim fechaC As Date
    Dim WithEvents fEmp As frmMuestraCodigos
    Dim WithEvents f2C As frmMuestra2Columnas

    Dim base, tipSeguro As Integer
    Dim tibase As String
    Dim porSeg, horasDia As Decimal
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents gpCheque As System.Windows.Forms.GroupBox
    Friend WithEvents TextConxCheque As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextConsInicial As System.Windows.Forms.TextBox
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Dim lpara As New Dictionary(Of String, Object)
    Friend WithEvents dtpFechaf As DateTimePicker
    Friend WithEvents dtpFechai As DateTimePicker
    Friend WithEvents tcPrincipal As TabControl
    Friend WithEvents tpPrincipal As TabPage
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents ToolStripStatusLabel1 As ToolStripStatusLabel
    Friend WithEvents tpConsulta As TabPage
    Friend WithEvents Label1 As Label
    Friend WithEvents txtFiltro As TextBox
    Friend WithEvents dgData As DataGridView
    Friend WithEvents Label2 As Label
    Friend WithEvents axFechaC As axFecha.axDateDB
    Dim claseLetras As ValoresLetras
    '    Dim psize As New PaperSize("Custom Paper Size", 850, 550)



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
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents gpCodigo As System.Windows.Forms.GroupBox
    Friend WithEvents btnlimpiar As System.Windows.Forms.Button
    Friend WithEvents gpInformacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnAtr As System.Windows.Forms.Button
    Friend WithEvents btnSig As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TextFechaOp As System.Windows.Forms.TextBox
    Friend WithEvents TextMonto As System.Windows.Forms.TextBox
    Friend WithEvents TextTasa As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmbNombBanco As System.Windows.Forms.ComboBox
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents TextConlConcepto As System.Windows.Forms.TextBox
    Friend WithEvents btnDetalle As System.Windows.Forms.Button
    Friend WithEvents TextEstado As System.Windows.Forms.TextBox
    Friend WithEvents TextBanco As System.Windows.Forms.TextBox
    Friend WithEvents TextNombBanco As System.Windows.Forms.TextBox
    Friend WithEvents cmbBanco As System.Windows.Forms.ComboBox
    Friend WithEvents gpContrato As System.Windows.Forms.GroupBox
    Friend WithEvents btnContrato As System.Windows.Forms.Button
    Friend WithEvents TextConxContrato As System.Windows.Forms.TextBox
    Friend WithEvents gpChofer As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents textConxEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextMoneda As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents gpDetalle As System.Windows.Forms.GroupBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextSeguro As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextDescontado As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextLiquido As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextDevengado As System.Windows.Forms.TextBox
    Friend WithEvents dgDatos As System.Windows.Forms.DataGridView
    Friend WithEvents ctxPrincipal As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxModificar As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxAnulacion As System.Windows.Forms.ToolStripMenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaNotas))
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.gpInformacion = New System.Windows.Forms.GroupBox()
        Me.ctxPrincipal = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModificar = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxAnulacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.dtpFechaf = New System.Windows.Forms.DateTimePicker()
        Me.dtpFechai = New System.Windows.Forms.DateTimePicker()
        Me.TextConsInicial = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.gpCheque = New System.Windows.Forms.GroupBox()
        Me.TextConxCheque = New System.Windows.Forms.TextBox()
        Me.TextMoneda = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.gpContrato = New System.Windows.Forms.GroupBox()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.TextConxContrato = New System.Windows.Forms.TextBox()
        Me.gpChofer = New System.Windows.Forms.GroupBox()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textConxEmpleado = New System.Windows.Forms.TextBox()
        Me.TextEstado = New System.Windows.Forms.TextBox()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.TextFechaOp = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextMonto = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextTasa = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextConlConcepto = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.gpCodigo = New System.Windows.Forms.GroupBox()
        Me.cmbBanco = New System.Windows.Forms.ComboBox()
        Me.cmbNombBanco = New System.Windows.Forms.ComboBox()
        Me.TextBanco = New System.Windows.Forms.TextBox()
        Me.TextNombBanco = New System.Windows.Forms.TextBox()
        Me.btnAtr = New System.Windows.Forms.Button()
        Me.btnSig = New System.Windows.Forms.Button()
        Me.btnlimpiar = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnDetalle = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.gpDetalle = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextSeguro = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TextDescontado = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextLiquido = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TextDevengado = New System.Windows.Forms.TextBox()
        Me.dgDatos = New System.Windows.Forms.DataGridView()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.tcPrincipal = New System.Windows.Forms.TabControl()
        Me.tpPrincipal = New System.Windows.Forms.TabPage()
        Me.tpConsulta = New System.Windows.Forms.TabPage()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel1 = New System.Windows.Forms.ToolStripStatusLabel()
        Me.dgData = New System.Windows.Forms.DataGridView()
        Me.txtFiltro = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.axFechaC = New axFecha.axDateDB()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.gpInformacion.SuspendLayout()
        Me.ctxPrincipal.SuspendLayout()
        Me.gpCheque.SuspendLayout()
        Me.gpContrato.SuspendLayout()
        Me.gpChofer.SuspendLayout()
        Me.gpCodigo.SuspendLayout()
        Me.gpDetalle.SuspendLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcPrincipal.SuspendLayout()
        Me.tpPrincipal.SuspendLayout()
        Me.tpConsulta.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gpInformacion
        '
        Me.gpInformacion.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpInformacion.ContextMenuStrip = Me.ctxPrincipal
        Me.gpInformacion.Controls.Add(Me.Label2)
        Me.gpInformacion.Controls.Add(Me.axFechaC)
        Me.gpInformacion.Controls.Add(Me.dtpFechaf)
        Me.gpInformacion.Controls.Add(Me.dtpFechai)
        Me.gpInformacion.Controls.Add(Me.TextConsInicial)
        Me.gpInformacion.Controls.Add(Me.Label8)
        Me.gpInformacion.Controls.Add(Me.gpCheque)
        Me.gpInformacion.Controls.Add(Me.TextMoneda)
        Me.gpInformacion.Controls.Add(Me.Label11)
        Me.gpInformacion.Controls.Add(Me.Label3)
        Me.gpInformacion.Controls.Add(Me.Label6)
        Me.gpInformacion.Controls.Add(Me.gpContrato)
        Me.gpInformacion.Controls.Add(Me.gpChofer)
        Me.gpInformacion.Controls.Add(Me.TextEstado)
        Me.gpInformacion.Controls.Add(Me.cmbEstado)
        Me.gpInformacion.Controls.Add(Me.TextFechaOp)
        Me.gpInformacion.Controls.Add(Me.Label9)
        Me.gpInformacion.Controls.Add(Me.TextMonto)
        Me.gpInformacion.Controls.Add(Me.Label7)
        Me.gpInformacion.Controls.Add(Me.TextTasa)
        Me.gpInformacion.Controls.Add(Me.Label17)
        Me.gpInformacion.Controls.Add(Me.TextConlConcepto)
        Me.gpInformacion.Controls.Add(Me.Label15)
        Me.gpInformacion.Controls.Add(Me.Label10)
        Me.gpInformacion.Controls.Add(Me.gpCodigo)
        Me.gpInformacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpInformacion.Location = New System.Drawing.Point(3, 6)
        Me.gpInformacion.Name = "gpInformacion"
        Me.gpInformacion.Size = New System.Drawing.Size(1054, 211)
        Me.gpInformacion.TabIndex = 1
        Me.gpInformacion.TabStop = False
        '
        'ctxPrincipal
        '
        Me.ctxPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModificar, Me.ctxAnulacion})
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
        'ctxAnulacion
        '
        Me.ctxAnulacion.Image = Global.NOMINA.My.Resources.Resources.cancelar
        Me.ctxAnulacion.Name = "ctxAnulacion"
        Me.ctxAnulacion.Size = New System.Drawing.Size(125, 22)
        Me.ctxAnulacion.Text = "Anular"
        '
        'dtpFechaf
        '
        Me.dtpFechaf.CalendarTitleBackColor = System.Drawing.Color.White
        Me.dtpFechaf.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaf.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaf.Location = New System.Drawing.Point(906, 99)
        Me.dtpFechaf.Name = "dtpFechaf"
        Me.dtpFechaf.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechaf.TabIndex = 135
        '
        'dtpFechai
        '
        Me.dtpFechai.CalendarTitleBackColor = System.Drawing.Color.White
        Me.dtpFechai.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechai.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechai.Location = New System.Drawing.Point(731, 99)
        Me.dtpFechai.Name = "dtpFechai"
        Me.dtpFechai.Size = New System.Drawing.Size(98, 20)
        Me.dtpFechai.TabIndex = 134
        '
        'TextConsInicial
        '
        Me.TextConsInicial.BackColor = System.Drawing.Color.White
        Me.TextConsInicial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConsInicial.Location = New System.Drawing.Point(911, 175)
        Me.TextConsInicial.MaxLength = 15
        Me.TextConsInicial.Name = "TextConsInicial"
        Me.TextConsInicial.Size = New System.Drawing.Size(112, 20)
        Me.TextConsInicial.TabIndex = 133
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(843, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 13)
        Me.Label8.TabIndex = 132
        Me.Label8.Text = "Emitido por:"
        '
        'gpCheque
        '
        Me.gpCheque.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpCheque.Controls.Add(Me.TextConxCheque)
        Me.gpCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCheque.Location = New System.Drawing.Point(504, 73)
        Me.gpCheque.Name = "gpCheque"
        Me.gpCheque.Size = New System.Drawing.Size(120, 46)
        Me.gpCheque.TabIndex = 131
        Me.gpCheque.TabStop = False
        Me.gpCheque.Text = "Número de nota"
        '
        'TextConxCheque
        '
        Me.TextConxCheque.BackColor = System.Drawing.Color.White
        Me.TextConxCheque.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConxCheque.ForeColor = System.Drawing.Color.Red
        Me.TextConxCheque.Location = New System.Drawing.Point(6, 19)
        Me.TextConxCheque.MaxLength = 8
        Me.TextConxCheque.Name = "TextConxCheque"
        Me.TextConxCheque.Size = New System.Drawing.Size(80, 20)
        Me.TextConxCheque.TabIndex = 1
        '
        'TextMoneda
        '
        Me.TextMoneda.BackColor = System.Drawing.Color.White
        Me.TextMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMoneda.Location = New System.Drawing.Point(281, 139)
        Me.TextMoneda.Name = "TextMoneda"
        Me.TextMoneda.ReadOnly = True
        Me.TextMoneda.Size = New System.Drawing.Size(64, 20)
        Me.TextMoneda.TabIndex = 129
        Me.TextMoneda.TabStop = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(224, 139)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 13)
        Me.Label11.TabIndex = 130
        Me.Label11.Text = "Moneda:"
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(838, 103)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(62, 13)
        Me.Label3.TabIndex = 127
        Me.Label3.Text = "Fecha final:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(656, 103)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(69, 13)
        Me.Label6.TabIndex = 126
        Me.Label6.Text = "Fecha inicial:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'gpContrato
        '
        Me.gpContrato.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpContrato.Controls.Add(Me.btnContrato)
        Me.gpContrato.Controls.Add(Me.TextConxContrato)
        Me.gpContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpContrato.Location = New System.Drawing.Point(632, 13)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(137, 56)
        Me.gpContrato.TabIndex = 89
        Me.gpContrato.TabStop = False
        Me.gpContrato.Text = "Contrato"
        '
        'btnContrato
        '
        Me.btnContrato.BackColor = System.Drawing.SystemColors.Control
        Me.btnContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnContrato.ImageKey = "buscar2.png"
        Me.btnContrato.ImageList = Me.ImageNuevos
        Me.btnContrato.Location = New System.Drawing.Point(79, 15)
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
        Me.TextConxContrato.Location = New System.Drawing.Point(10, 25)
        Me.TextConxContrato.MaxLength = 4
        Me.TextConxContrato.Name = "TextConxContrato"
        Me.TextConxContrato.Size = New System.Drawing.Size(63, 20)
        Me.TextConxContrato.TabIndex = 1
        Me.TextConxContrato.TabStop = False
        '
        'gpChofer
        '
        Me.gpChofer.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpChofer.Controls.Add(Me.btnEmpleado)
        Me.gpChofer.Controls.Add(Me.textNombreEmple)
        Me.gpChofer.Controls.Add(Me.textConxEmpleado)
        Me.gpChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpChofer.Location = New System.Drawing.Point(6, 14)
        Me.gpChofer.Name = "gpChofer"
        Me.gpChofer.Size = New System.Drawing.Size(622, 56)
        Me.gpChofer.TabIndex = 88
        Me.gpChofer.TabStop = False
        Me.gpChofer.Text = "Empleado"
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(520, 15)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(69, 30)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.Text = "Buscar"
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEmpleado, "Empleado")
        Me.btnEmpleado.UseVisualStyleBackColor = False
        '
        'textNombreEmple
        '
        Me.textNombreEmple.BackColor = System.Drawing.Color.White
        Me.textNombreEmple.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombreEmple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombreEmple.Location = New System.Drawing.Point(66, 24)
        Me.textNombreEmple.MaxLength = 40
        Me.textNombreEmple.Name = "textNombreEmple"
        Me.textNombreEmple.Size = New System.Drawing.Size(448, 20)
        Me.textNombreEmple.TabIndex = 2
        '
        'textConxEmpleado
        '
        Me.textConxEmpleado.BackColor = System.Drawing.Color.White
        Me.textConxEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textConxEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textConxEmpleado.Location = New System.Drawing.Point(6, 24)
        Me.textConxEmpleado.MaxLength = 6
        Me.textConxEmpleado.Name = "textConxEmpleado"
        Me.textConxEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textConxEmpleado.TabIndex = 1
        '
        'TextEstado
        '
        Me.TextEstado.BackColor = System.Drawing.Color.White
        Me.TextEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEstado.Location = New System.Drawing.Point(694, 175)
        Me.TextEstado.Name = "TextEstado"
        Me.TextEstado.ReadOnly = True
        Me.TextEstado.Size = New System.Drawing.Size(136, 20)
        Me.TextEstado.TabIndex = 8
        Me.TextEstado.TabStop = False
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.Items.AddRange(New Object() {"ACTIVO", "ANULADO", "BANCO", "PAGADO", ""})
        Me.cmbEstado.Location = New System.Drawing.Point(694, 175)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(136, 21)
        Me.cmbEstado.TabIndex = 8
        '
        'TextFechaOp
        '
        Me.TextFechaOp.BackColor = System.Drawing.Color.White
        Me.TextFechaOp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaOp.Location = New System.Drawing.Point(121, 139)
        Me.TextFechaOp.Name = "TextFechaOp"
        Me.TextFechaOp.ReadOnly = True
        Me.TextFechaOp.Size = New System.Drawing.Size(96, 20)
        Me.TextFechaOp.TabIndex = 12
        Me.TextFechaOp.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 139)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 13)
        Me.Label9.TabIndex = 87
        Me.Label9.Text = "Fecha de operación:"
        '
        'TextMonto
        '
        Me.TextMonto.BackColor = System.Drawing.Color.White
        Me.TextMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMonto.Location = New System.Drawing.Point(555, 139)
        Me.TextMonto.Name = "TextMonto"
        Me.TextMonto.ReadOnly = True
        Me.TextMonto.Size = New System.Drawing.Size(98, 20)
        Me.TextMonto.TabIndex = 11
        Me.TextMonto.TabStop = False
        Me.TextMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(480, 139)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 85
        Me.Label7.Text = "Monto:"
        '
        'TextTasa
        '
        Me.TextTasa.BackColor = System.Drawing.Color.White
        Me.TextTasa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTasa.Location = New System.Drawing.Point(402, 139)
        Me.TextTasa.Name = "TextTasa"
        Me.TextTasa.ReadOnly = True
        Me.TextTasa.Size = New System.Drawing.Size(64, 20)
        Me.TextTasa.TabIndex = 10
        Me.TextTasa.TabStop = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(641, 175)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(43, 13)
        Me.Label17.TabIndex = 69
        Me.Label17.Text = "Estado:"
        '
        'TextConlConcepto
        '
        Me.TextConlConcepto.BackColor = System.Drawing.Color.White
        Me.TextConlConcepto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextConlConcepto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConlConcepto.Location = New System.Drawing.Point(80, 175)
        Me.TextConlConcepto.Name = "TextConlConcepto"
        Me.TextConlConcepto.Size = New System.Drawing.Size(544, 20)
        Me.TextConlConcepto.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(14, 175)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 13)
        Me.Label15.TabIndex = 66
        Me.Label15.Text = "Concepto:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(356, 139)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(34, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Tasa:"
        '
        'gpCodigo
        '
        Me.gpCodigo.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpCodigo.Controls.Add(Me.cmbBanco)
        Me.gpCodigo.Controls.Add(Me.cmbNombBanco)
        Me.gpCodigo.Controls.Add(Me.TextBanco)
        Me.gpCodigo.Controls.Add(Me.TextNombBanco)
        Me.gpCodigo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCodigo.Location = New System.Drawing.Point(7, 78)
        Me.gpCodigo.Name = "gpCodigo"
        Me.gpCodigo.Size = New System.Drawing.Size(480, 42)
        Me.gpCodigo.TabIndex = 1
        Me.gpCodigo.TabStop = False
        Me.gpCodigo.Text = "Correlativo cuenta"
        '
        'cmbBanco
        '
        Me.cmbBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBanco.Location = New System.Drawing.Point(8, 15)
        Me.cmbBanco.Name = "cmbBanco"
        Me.cmbBanco.Size = New System.Drawing.Size(80, 21)
        Me.cmbBanco.TabIndex = 1
        '
        'cmbNombBanco
        '
        Me.cmbNombBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNombBanco.Location = New System.Drawing.Point(101, 15)
        Me.cmbNombBanco.Name = "cmbNombBanco"
        Me.cmbNombBanco.Size = New System.Drawing.Size(370, 21)
        Me.cmbNombBanco.TabIndex = 2
        '
        'TextBanco
        '
        Me.TextBanco.BackColor = System.Drawing.Color.White
        Me.TextBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBanco.Location = New System.Drawing.Point(8, 16)
        Me.TextBanco.Name = "TextBanco"
        Me.TextBanco.ReadOnly = True
        Me.TextBanco.Size = New System.Drawing.Size(64, 20)
        Me.TextBanco.TabIndex = 94
        Me.TextBanco.TabStop = False
        '
        'TextNombBanco
        '
        Me.TextNombBanco.BackColor = System.Drawing.Color.White
        Me.TextNombBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombBanco.Location = New System.Drawing.Point(184, 16)
        Me.TextNombBanco.Name = "TextNombBanco"
        Me.TextNombBanco.ReadOnly = True
        Me.TextNombBanco.Size = New System.Drawing.Size(280, 20)
        Me.TextNombBanco.TabIndex = 95
        Me.TextNombBanco.TabStop = False
        '
        'btnAtr
        '
        Me.btnAtr.BackColor = System.Drawing.SystemColors.Control
        Me.btnAtr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtr.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnAtr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAtr.ImageKey = "anterior.png"
        Me.btnAtr.ImageList = Me.ImageNuevos
        Me.btnAtr.Location = New System.Drawing.Point(3, 220)
        Me.btnAtr.Name = "btnAtr"
        Me.btnAtr.Size = New System.Drawing.Size(79, 30)
        Me.btnAtr.TabIndex = 10
        Me.btnAtr.Text = "Anterior"
        Me.btnAtr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAtr, "Registro anterior")
        Me.btnAtr.UseVisualStyleBackColor = False
        '
        'btnSig
        '
        Me.btnSig.BackColor = System.Drawing.SystemColors.Control
        Me.btnSig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSig.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnSig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSig.ImageKey = "siguiente.png"
        Me.btnSig.ImageList = Me.ImageNuevos
        Me.btnSig.Location = New System.Drawing.Point(828, 220)
        Me.btnSig.Name = "btnSig"
        Me.btnSig.Size = New System.Drawing.Size(82, 30)
        Me.btnSig.TabIndex = 11
        Me.btnSig.Text = "Siguiente"
        Me.btnSig.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnSig, "Siguiente registro")
        Me.btnSig.UseVisualStyleBackColor = False
        '
        'btnlimpiar
        '
        Me.btnlimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnlimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnlimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnlimpiar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnlimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnlimpiar.ImageKey = "limpiar.png"
        Me.btnlimpiar.ImageList = Me.ImageNuevos
        Me.btnlimpiar.Location = New System.Drawing.Point(88, 220)
        Me.btnlimpiar.Name = "btnlimpiar"
        Me.btnlimpiar.Size = New System.Drawing.Size(81, 30)
        Me.btnlimpiar.TabIndex = 318
        Me.btnlimpiar.Text = "Limpiar"
        Me.btnlimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnlimpiar, "Limpiar forma")
        Me.btnlimpiar.UseVisualStyleBackColor = False
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.ImageKey = "buscar2.png"
        Me.btnBuscar.ImageList = Me.ImageNuevos
        Me.btnBuscar.Location = New System.Drawing.Point(746, 220)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(69, 30)
        Me.btnBuscar.TabIndex = 15
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Buscar registro")
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'btnDetalle
        '
        Me.btnDetalle.BackColor = System.Drawing.SystemColors.Control
        Me.btnDetalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDetalle.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnDetalle.ImageKey = "detalle.png"
        Me.btnDetalle.ImageList = Me.ImageNuevos
        Me.btnDetalle.Location = New System.Drawing.Point(393, 220)
        Me.btnDetalle.Name = "btnDetalle"
        Me.btnDetalle.Size = New System.Drawing.Size(68, 30)
        Me.btnDetalle.TabIndex = 16
        Me.btnDetalle.Text = "Detalle"
        Me.btnDetalle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnDetalle, "ver detalle")
        Me.btnDetalle.UseVisualStyleBackColor = False
        '
        'btnGuardar
        '
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(662, 220)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(78, 30)
        Me.btnGuardar.TabIndex = 321
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Buscar registro")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'gpDetalle
        '
        Me.gpDetalle.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gpDetalle.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpDetalle.Controls.Add(Me.Label12)
        Me.gpDetalle.Controls.Add(Me.TextSeguro)
        Me.gpDetalle.Controls.Add(Me.Label14)
        Me.gpDetalle.Controls.Add(Me.TextDescontado)
        Me.gpDetalle.Controls.Add(Me.Label13)
        Me.gpDetalle.Controls.Add(Me.TextLiquido)
        Me.gpDetalle.Controls.Add(Me.Label16)
        Me.gpDetalle.Controls.Add(Me.TextDevengado)
        Me.gpDetalle.Controls.Add(Me.dgDatos)
        Me.gpDetalle.Location = New System.Drawing.Point(3, 254)
        Me.gpDetalle.Name = "gpDetalle"
        Me.gpDetalle.Size = New System.Drawing.Size(1054, 293)
        Me.gpDetalle.TabIndex = 319
        Me.gpDetalle.TabStop = False
        '
        'Label12
        '
        Me.Label12.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(847, 264)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(60, 18)
        Me.Label12.TabIndex = 134
        Me.Label12.Text = "Seguro:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextSeguro
        '
        Me.TextSeguro.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextSeguro.BackColor = System.Drawing.Color.White
        Me.TextSeguro.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSeguro.ForeColor = System.Drawing.Color.Red
        Me.TextSeguro.Location = New System.Drawing.Point(929, 260)
        Me.TextSeguro.Name = "TextSeguro"
        Me.TextSeguro.ReadOnly = True
        Me.TextSeguro.Size = New System.Drawing.Size(117, 24)
        Me.TextSeguro.TabIndex = 133
        Me.TextSeguro.TabStop = False
        Me.TextSeguro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(602, 264)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 18)
        Me.Label14.TabIndex = 132
        Me.Label14.Text = "Descontado:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextDescontado
        '
        Me.TextDescontado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextDescontado.BackColor = System.Drawing.Color.White
        Me.TextDescontado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDescontado.ForeColor = System.Drawing.Color.Red
        Me.TextDescontado.Location = New System.Drawing.Point(726, 261)
        Me.TextDescontado.Name = "TextDescontado"
        Me.TextDescontado.ReadOnly = True
        Me.TextDescontado.Size = New System.Drawing.Size(117, 24)
        Me.TextDescontado.TabIndex = 131
        Me.TextDescontado.TabStop = False
        Me.TextDescontado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(171, 264)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(59, 18)
        Me.Label13.TabIndex = 130
        Me.Label13.Text = "Liquido:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextLiquido
        '
        Me.TextLiquido.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextLiquido.BackColor = System.Drawing.Color.White
        Me.TextLiquido.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextLiquido.ForeColor = System.Drawing.Color.Red
        Me.TextLiquido.Location = New System.Drawing.Point(246, 260)
        Me.TextLiquido.Name = "TextLiquido"
        Me.TextLiquido.ReadOnly = True
        Me.TextLiquido.Size = New System.Drawing.Size(117, 24)
        Me.TextLiquido.TabIndex = 129
        Me.TextLiquido.TabStop = False
        Me.TextLiquido.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(371, 263)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 18)
        Me.Label16.TabIndex = 128
        Me.Label16.Text = "Devengado:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextDevengado
        '
        Me.TextDevengado.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextDevengado.BackColor = System.Drawing.Color.White
        Me.TextDevengado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDevengado.ForeColor = System.Drawing.Color.Red
        Me.TextDevengado.Location = New System.Drawing.Point(478, 260)
        Me.TextDevengado.Name = "TextDevengado"
        Me.TextDevengado.ReadOnly = True
        Me.TextDevengado.Size = New System.Drawing.Size(117, 24)
        Me.TextDevengado.TabIndex = 127
        Me.TextDevengado.TabStop = False
        Me.TextDevengado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dgDatos
        '
        Me.dgDatos.AllowUserToAddRows = False
        Me.dgDatos.AllowUserToDeleteRows = False
        Me.dgDatos.AllowUserToOrderColumns = True
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.LightGreen
        Me.dgDatos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle2
        Me.dgDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDatos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDatos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgDatos.Location = New System.Drawing.Point(9, 14)
        Me.dgDatos.MultiSelect = False
        Me.dgDatos.Name = "dgDatos"
        Me.dgDatos.ReadOnly = True
        Me.dgDatos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDatos.Size = New System.Drawing.Size(1036, 241)
        Me.dgDatos.TabIndex = 126
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'tcPrincipal
        '
        Me.tcPrincipal.Controls.Add(Me.tpPrincipal)
        Me.tcPrincipal.Controls.Add(Me.tpConsulta)
        Me.tcPrincipal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tcPrincipal.Location = New System.Drawing.Point(0, 0)
        Me.tcPrincipal.Name = "tcPrincipal"
        Me.tcPrincipal.SelectedIndex = 0
        Me.tcPrincipal.Size = New System.Drawing.Size(1130, 605)
        Me.tcPrincipal.TabIndex = 322
        '
        'tpPrincipal
        '
        Me.tpPrincipal.Controls.Add(Me.StatusStrip1)
        Me.tpPrincipal.Controls.Add(Me.gpInformacion)
        Me.tpPrincipal.Controls.Add(Me.btnAtr)
        Me.tpPrincipal.Controls.Add(Me.btnSig)
        Me.tpPrincipal.Controls.Add(Me.gpDetalle)
        Me.tpPrincipal.Controls.Add(Me.btnlimpiar)
        Me.tpPrincipal.Controls.Add(Me.btnBuscar)
        Me.tpPrincipal.Controls.Add(Me.btnGuardar)
        Me.tpPrincipal.Controls.Add(Me.btnDetalle)
        Me.tpPrincipal.Location = New System.Drawing.Point(4, 22)
        Me.tpPrincipal.Name = "tpPrincipal"
        Me.tpPrincipal.Padding = New System.Windows.Forms.Padding(3)
        Me.tpPrincipal.Size = New System.Drawing.Size(1122, 579)
        Me.tpPrincipal.TabIndex = 0
        Me.tpPrincipal.Text = "Principal"
        Me.tpPrincipal.UseVisualStyleBackColor = True
        '
        'tpConsulta
        '
        Me.tpConsulta.Controls.Add(Me.Label1)
        Me.tpConsulta.Controls.Add(Me.txtFiltro)
        Me.tpConsulta.Controls.Add(Me.dgData)
        Me.tpConsulta.Location = New System.Drawing.Point(4, 22)
        Me.tpConsulta.Name = "tpConsulta"
        Me.tpConsulta.Padding = New System.Windows.Forms.Padding(3)
        Me.tpConsulta.Size = New System.Drawing.Size(1122, 579)
        Me.tpConsulta.TabIndex = 1
        Me.tpConsulta.Text = "Consulta"
        Me.tpConsulta.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel1})
        Me.StatusStrip1.Location = New System.Drawing.Point(3, 552)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1116, 24)
        Me.StatusStrip1.TabIndex = 322
        Me.StatusStrip1.Text = "stBar"
        '
        'ToolStripStatusLabel1
        '
        Me.ToolStripStatusLabel1.BorderSides = CType((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) _
            Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1"
        Me.ToolStripStatusLabel1.Size = New System.Drawing.Size(1101, 19)
        Me.ToolStripStatusLabel1.Spring = True
        Me.ToolStripStatusLabel1.Text = "Click derecho sobre el panel de información para activar opción de:  modificación" &
    ", anulación y eliminación"
        Me.ToolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgData
        '
        Me.dgData.AllowUserToAddRows = False
        Me.dgData.AllowUserToDeleteRows = False
        Me.dgData.AllowUserToResizeRows = False
        Me.dgData.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgData.BackgroundColor = System.Drawing.Color.White
        Me.dgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgData.Location = New System.Drawing.Point(53, 33)
        Me.dgData.Name = "dgData"
        Me.dgData.ReadOnly = True
        Me.dgData.RowHeadersVisible = False
        Me.dgData.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgData.Size = New System.Drawing.Size(1061, 538)
        Me.dgData.TabIndex = 0
        '
        'txtFiltro
        '
        Me.txtFiltro.Location = New System.Drawing.Point(53, 7)
        Me.txtFiltro.Name = "txtFiltro"
        Me.txtFiltro.Size = New System.Drawing.Size(240, 20)
        Me.txtFiltro.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Filtro:"
        '
        'axFechaC
        '
        Me.axFechaC.DateMaxvalue1 = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.axFechaC.DateMaxvalue2 = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.axFechaC.DateMinvalue1 = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.axFechaC.DateMinvalue2 = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.axFechaC.Datevalue1 = New Date(2023, 10, 27, 0, 0, 0, 0)
        Me.axFechaC.Datevalue2 = New Date(2023, 10, 27, 0, 0, 0, 0)
        Me.axFechaC.EsModoConsulta = False
        Me.axFechaC.Formato = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.axFechaC.FuenteCalendario = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.axFechaC.Location = New System.Drawing.Point(731, 139)
        Me.axFechaC.Name = "axFechaC"
        Me.axFechaC.nombreCampo = "fecha"
        Me.axFechaC.prefijo = "e1"
        Me.axFechaC.Size = New System.Drawing.Size(314, 27)
        Me.axFechaC.TabIndex = 136
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(674, 146)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 137
        Me.Label2.Text = "Fecha:"
        '
        'frmConsultaNotas
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnlimpiar
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.tcPrincipal)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmConsultaNotas"
        Me.Text = "Mantenimiento de Notas Bancarias Extranómina"
        Me.gpInformacion.ResumeLayout(False)
        Me.gpInformacion.PerformLayout()
        Me.ctxPrincipal.ResumeLayout(False)
        Me.gpCheque.ResumeLayout(False)
        Me.gpCheque.PerformLayout()
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        Me.gpChofer.ResumeLayout(False)
        Me.gpChofer.PerformLayout()
        Me.gpCodigo.ResumeLayout(False)
        Me.gpCodigo.PerformLayout()
        Me.gpDetalle.ResumeLayout(False)
        Me.gpDetalle.PerformLayout()
        CType(Me.dgDatos, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcPrincipal.ResumeLayout(False)
        Me.tpPrincipal.ResumeLayout(False)
        Me.tpPrincipal.PerformLayout()
        Me.tpConsulta.ResumeLayout(False)
        Me.tpConsulta.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        CType(Me.dgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Tabla consulta"
    Private Sub defineVista(ByVal dgv As DataGridView)
        With dgv
            .Columns(0).FillWeight = 10
            .Columns(0).HeaderText = "xx"
            .Columns(0).Visible = False

            .Columns(1).FillWeight = 3
            .Columns(1).HeaderText = "Banco"

            .Columns(2).FillWeight = 3
            .Columns(2).HeaderText = "Cheque"

            .Columns(3).FillWeight = 3
            .Columns(3).HeaderText = "Fecha"

            .Columns(4).FillWeight = 3
            .Columns(4).HeaderText = "Empleado"

            .Columns(5).FillWeight = 3
            .Columns(5).HeaderText = "Contrato"
            .Columns(5).Visible = False

            .Columns(6).FillWeight = 10
            .Columns(6).HeaderText = "fechai"
            .Columns(6).Visible = False

            .Columns(7).FillWeight = 10
            .Columns(7).HeaderText = "fechaf"
            .Columns(7).Visible = False

            .Columns(8).FillWeight = 10
            .Columns(8).HeaderText = "Concepto"

            .Columns(9).FillWeight = 10
            .Columns(9).HeaderText = "Estado"
            .Columns(9).Visible = False

            .Columns(10).FillWeight = 10
            .Columns(10).HeaderText = "fechae"
            .Columns(10).Visible = False

            .Columns(11).FillWeight = 10
            .Columns(11).HeaderText = "moneda"
            .Columns(11).Visible = False

            .Columns(12).FillWeight = 10
            .Columns(12).HeaderText = "tasa"
            .Columns(12).Visible = False

            .Columns(13).FillWeight = 10
            .Columns(13).HeaderText = "valor"
            .Columns(13).Visible = False
        End With
    End Sub
#End Region
    Private Sub frmCtaBancarias_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cadena = "select b2.banco,  b1.nombre + ' CTA ' + b2.cta from bancos b1 inner join bancoscta b2 on b1.empresa=b2.empresa and b1.codigo=b2.codigo " &
                 "where b2.empresa=" & empresa & " and tipo=1 order by b2.banco"
        llena_comboDoble(cadena, cmbBanco, cmbNombBanco)
        btnlimpiar_Click(sender, e)
        cmbBanco.MaxLength = 2
    End Sub


#Region "EMLEADO"


    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        If TextConxContrato.ReadOnly = False Then
            TextConxContrato.Clear()
        End If
        If valbool = True Then
            textConxEmpleado.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("nombre") = textNombreEmple.Text.Trim
        Dim numFilas As Int32
        If textNombreEmple.Text.Trim <> "" Then
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and nombre like '%' + @nombre + '%'  order by nombre"
        Else
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa order by nombre"
        End If
        numFilas = llenaTabla(cadena, tbEmpleado, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado(True)
            textConxEmpleado.Clear()
        ElseIf numFilas = 1 Then
            BorraEmpleado(True)
            filaTemp = tbEmpleado.Rows.Item(0)
            textConxEmpleado.Text() = filaTemp.Item(0)
            textNombreEmple.Text = filaTemp.Item(1)
            TextConxContrato.Focus()
        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textConxEmpleado.Text.Trim
        If valida_tipo_Entero(textConxEmpleado.Text, 2) = True Then
            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=@empresa and empleado=@empleado", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textConxEmpleado.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa and empleado=@empleado"
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
            textConxEmpleado.Focus()
        End If
    End Sub

    Private Sub TextEmpleado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textConxEmpleado.Validated
        If textConxEmpleado.Text.Trim <> "" Then
            ValidaEmpleado()
        Else
            BorraEmpleado(False)
        End If
    End Sub

    Private Sub EnBuscaEmpleado()
        fEmp = New frmMuestraCodigos
        fEmp.TopMost = True
        fEmp.inicializa(tbEmpleado)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosEmpleados
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        TextConxContrato.Focus()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        textConxEmpleado.Text() = filaTemp.Item(0)
        textNombreEmple.Text = filaTemp.Item(1)
    End Sub


#End Region


#Region "PRUEBA"

#End Region

#Region "Contrato"

    Private Sub BtnContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContrato.Click
        Dim Num As Int16
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textConxEmpleado.Text
        If textConxEmpleado.Text.Trim <> "" Then
            cadena = "select contrato, pu.nombre " &
                    " from contratos1 c1 " &
                    " inner join empestados e on e.estado=c1.estado and e.empresa=c1.empresa " &
                    " inner join puestosper pu on pu.empresa=c1.empresa and pu.puesto=c1.puesto " &
                    " where c1.empresa=@empresa and empleado=@empleado"
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
                TextConlConcepto.Focus()
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
        lpara("empleado") = textConxEmpleado.Text
        lpara("contrato") = TextConxContrato.Text
        If TextConxContrato.Text.Trim <> "" And textConxEmpleado.Text.Trim <> "" Then
            Dim tbTem As New DataTable("temp")
            cadena = "select contrato, fechai " &
                    " from contratos1 c1 " &
                    " where c1.empresa=@empresa and empleado=@empleado AND c1.contrato=@contrato"
            If llenaTabla(cadena, tbTem, ListaParametros(lpara)) = 0 Then
                MsgBox("ESTE EMPLEADO NO TIENE CONTRATOS ACTIVOS", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            Else
                filaTemp = tbTem.Rows(0)
                TextConxContrato.Text() = filaTemp.Item(0)
                TextConlConcepto.Focus()
            End If
        Else
            TextConxContrato.Clear()
        End If
    End Sub



#End Region



    Private Sub estilo(ByVal dGVista As DataGridView)
        With dGVista
            .Columns(0).HeaderText = "Transacción"
            .Columns(0).Width = 100
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).Width = 435
            .Columns(2).HeaderText = "Cantidad"
            .Columns(2).Width = 140
            .Columns(2).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(3).HeaderText = "Importe"
            .Columns(3).Width = 140
            .Columns(3).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            .Columns(4).Visible = False
            .Columns(5).Visible = False
            .Columns(6).Visible = False
        End With
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        lpara.Clear()
        Dim finConsulta As String
        Dim fechaTemp As Date
        finConsulta = " and 1=1"
        GeneraConsulta(gpInformacion, finConsulta, "e1")
        lpara("banco") = cmbBanco.Text
        lpara("estado") = cmbEstado.SelectedIndex
        If cmbBanco.Text.Trim <> "" Then
            finConsulta = finConsulta & " and e1.banco=@banco"
        End If
        If cmbEstado.Text.Trim <> "" Then
            finConsulta = finConsulta & " and e1.estado=@estado"
        End If
        finConsulta = axFechaC.devuelveConsulta(finConsulta)
        cadenaConsulta = InicioConsulta & finConsulta & " order by e1.cheque asc"
        Mostrar(cadenaConsulta, sender, e)
    End Sub

    Private Sub Mostrar(ByVal subCadena As String, ByVal sender As System.Object, ByVal e As System.EventArgs)
        ConsultaReadOnly(gpInformacion, True)
        btnDetalle.Enabled = True
        btnBuscar.Enabled = False
        textNombreEmple.ReadOnly = True
        btnEmpleado.Enabled = False
        btnContrato.Enabled = False
        ContextoMenuEnab(True, True, ctxPrincipal)
        indice = 0
        axFechaC.EsModoConsulta = False
        If llenaTabla(subCadena, tbConsulta, ListaParametros(lpara)) > 0 Then
            LlenarTextBox(sender, e, 0, tbConsulta)
            dgData.DataSource = tbConsulta
            defineVista(dgData)
        Else
            MsgBox("NO HAY REGISTROS CON ESTOS CRITERIOS DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            btnlimpiar_Click(sender, e)
        End If
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub



    Private Sub LlenarTextBox(ByVal sender As System.Object, ByVal e As System.EventArgs, ByVal indi As Int16, ByVal tabla As DataTable)
        lpara.Clear()
        Dim FilaCopiar As DataRow
        FilaCopiar = tabla.Rows.Item(indi)
        TextConsInicial.Text = FilaCopiar.Item(0)
        TextBanco.Text = FilaCopiar.Item(1)
        cmbBanco.SelectedIndex = cmbBanco.FindStringExact(FilaCopiar.Item(1).ToString.Trim)
        TextNombBanco.Text = cmbNombBanco.Text
        bancoSub = FilaCopiar.Item(1)
        TextConxCheque.Text = FilaCopiar.Item(2)
        chequeSub = FilaCopiar.Item(2)
        axFechaC.Datevalue1 = FilaCopiar.Item(3)
        fechaC = FilaCopiar.Item(3)
        textConxEmpleado.Text = FilaCopiar.Item(4)
        lpara("empresa") = empresa
        lpara("empleado") = textConxEmpleado.Text
        textNombreEmple.Text = BuscaEscalar("select nombre from v_empleadosNuevo where empresa=@empresa and empleado=@empleado", ListaParametros(lpara))
        TextConxContrato.Text = FilaCopiar.Item(5)
        TextConxContrato_Validated(sender, e)
        dtpFechai.Text = FilaCopiar.Item(6)
        dtpFechaf.Text = FilaCopiar.Item(7)

        'textFechaI.Text = FilaCopiar.Item(6)
        'textFechaF.Text = FilaCopiar.Item(7)
        TextConlConcepto.Text = FilaCopiar.Item(8)
        cmbEstado.SelectedIndex = FilaCopiar.Item(9)
        Select Case FilaCopiar.Item(9)
            Case 0

                ctxModificar.Enabled = True
                ctxAnulacion.Enabled = True
            Case 1
                ctxModificar.Enabled = False
                ctxAnulacion.Enabled = False
        End Select
        TextEstado.Text = cmbEstado.Text
        TextFechaOp.Text = FilaCopiar.Item(10)
        TextMoneda.Text = FilaCopiar.Item(11)
        TextTasa.Text = FilaCopiar.Item(12)
        TextMonto.Text = formato(FilaCopiar.Item(13))
    End Sub

    Private Sub btnDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDetalle.Click
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("cheque") = chequeSub
        cadena = InicioConsulta2 & " where e2.empresa=@empresa and cheque=@cheque order by e2.transac"
        If llenaTabla(cadena, tbDetalle, ListaParametros(lpara)) > 0 Then
            gpDetalle.Visible = True

            dgDatos.DataSource = tbDetalle
            estilo(dgDatos)
            'AltoGridView(22, tbDetalle, 150, 859, dgDatos)
            CalculaValores()
        Else
            dgDatos.DataSource = Nothing
            MsgBox("ESTA NOTA NO POSEE DETALLE DE TRANSACCIONES DE NOMINA", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub


    Private Sub CalculaValores()
        Dim devengado, descontado, Importe, Seguro As Decimal
        Dim i As Integer
        devengado = 0
        descontado = 0
        Importe = 0
        Seguro = 0
        For i = 0 To tbDetalle.Rows.Count - 1
            filaTemp = tbDetalle.Rows(i)
            Importe = CDec(filaTemp.Item(3))
            If filaTemp.Item(5) = "V" Then
                If filaTemp.Item(4) = "I" Then
                    devengado = devengado + Importe
                ElseIf filaTemp.Item(4) = "D" Then
                    descontado = descontado + Importe
                End If
            ElseIf filaTemp.Item(5) = "C" And filaTemp.Item(4) = "I" Then
                devengado = devengado + Importe
                If filaTemp.Item(6) = "S" Then
                    Seguro = Seguro + Decimal.Round((Importe * (porSeg / 100)), 2)
                    descontado = descontado + Decimal.Round((Importe * (porSeg / 100)), 2)
                End If
            End If
        Next i
        TextLiquido.Text = formato(devengado - descontado)
        TextDevengado.Text = formato(devengado)
        TextDescontado.Text = formato(descontado)
        TextSeguro.Text = formato(Seguro)
    End Sub



    Private Sub btnlimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnlimpiar.Click
        'axFechaC
        axFechaC.reiniciaControl()
        axFechaC.EsModoConsulta = True
        axFechaC.Datevalue1 = Today
        axFechaC.Datevalue2 = Today
        dgData.DataSource = Nothing
        gpDetalle.Visible = False
        ConsultaReadOnly(gpInformacion, False)
        borra_Mejorado(gpInformacion, ep1)
        btnSig.Enabled = False
        btnAtr.Enabled = False
        btnGuardar.Visible = False
        textNombreEmple.ReadOnly = False
        btnEmpleado.Enabled = True
        btnContrato.Enabled = True
        dgDatos.DataSource = Nothing
        btnBuscar.Enabled = True
        btnBuscar.Visible = True
        btnDetalle.Enabled = False
        dtpFechai.Value = Today
        dtpFechaf.Value = Today
        ContextoMenuEnab(True, False, ctxPrincipal)
    End Sub



#Region "OPCIONES DE SUBMENU"
    Private Sub ctxAnulación_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxAnulacion.Click
        Dim corre, i, mesfiscal As Int32
        Dim TbTempEli As New DataTable("temporal")
        Dim FechaLim As Date



        Dim fechaVal = InputBox("Ingrese la fecha de la anulación", "Mensaje del Sistema")

        If Not DateTime.TryParse(fechaVal, fechaHoy) Then
            MsgBox("Formato de fecha inválido", "Mensaje del sistema")
            Exit Sub
        End If
        Dim cm As New cmodelo
        Try

            lpara("empresa") = empresa
            lpara("fecha") = fechaHoy
            lpara("cheque") = chequeSub
            lpara("nota") = corre + 1
            If MsgBox("ESTA SEGURO QUE DESEA ANULAR ESTA NOTA " & chequeSub, MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                cadena = "update notasban set estado=1,  fechao=@fecha where empresa=@empresa and nota=@cheque"
                cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                cadena = "update extra1 set estado=1,  fechae=@fecha where empresa=@empresa and cheque=@cheque and tipo='NB'"
                cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                mesfiscal = cm.BuscaEscalar("select mesifiscal from empresas where empresa=@empresa", ListaParametros(lpara))
                If mesfiscal = 1 Then
                    FechaLim = "01/01/" & Date.Today.Year
                Else
                    If Date.Today.Month < mesfiscal Then
                        FechaLim = "01/" & mesfiscal & "/" & Date.Today.Year - 1
                    Else
                        FechaLim = "01/" & mesfiscal & "/" & Date.Today.Year
                    End If
                End If
                If fechaC >= FechaLim Then
                    corre = cm.BuscaEscalar("select nota from empresas where empresa=@empresa", ListaParametros(lpara))
                    cadena = "update empresas set nota=@nota where empresa=@empresa"
                    cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    cadena = "select banco, banche, valor  from bantran where tipo=2 and empresa=@empresa and docto = @cheque"
                    cm.llenaTabla(cadena, tbAnulacion, ListaParametros(lpara))

                    For i = 0 To tbAnulacion.Rows.Count - 1
                        fTemp = tbAnulacion.Rows.Item(i)
                        lpara.Clear()
                        lpara("empresa") = empresa
                        lpara("banco") = fTemp.Item(0)
                        lpara("fecha") = fechaHoy
                        lpara("banche") = fTemp.Item(1)
                        lpara("docto") = corre + 1
                        lpara("valor") = -fTemp.Item(2)
                        lpara("concepto") = "ANULACION NOTA BANCARIA" & chequeSub
                        cadena = "insert into bantran (empresa,banco,fecha,banche,tipo,docto,valor,beneficiario,concepto) 
                                  values (@empresa,@banco,@fecha,@banche,1,@docto,@valor,'',@concepto)"
                        cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    Next i

                    lpara("cheque") = chequeSub
                    cadena = "select banco, origen, cuenta,codigo,haber,debe from diario2 where tipo=2 and empresa=@empresa and docto=@cheque"
                    cm.llenaTabla(cadena, tbDiario, ListaParametros(lpara))

                    For i = 0 To tbDiario.Rows.Count - 1
                        fTemp = tbDiario.Rows.Item(i)
                        lpara.Clear()
                        lpara("empresa") = empresa
                        lpara("banco") = fTemp.Item(0)
                        lpara("docto") = corre + 1
                        lpara("fecha") = fechaHoy
                        lpara("origen") = fTemp.Item(1)
                        lpara("cuenta") = fTemp.Item(2)
                        lpara("codigo") = fTemp.Item(3)
                        lpara("debe") = fTemp.Item(4)
                        lpara("haber") = fTemp.Item(5)
                        cadena = "insert into diario2 (empresa,tipo,banco,docto,fecha,origen,cuenta,codigo,debe,haber) 
                                  values(@empresa,1,@banco,@docto,@fecha,@origen,@cuenta,@codigo,@debe,@haber)"
                        cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    Next i
                    lpara.Clear()
                    lpara("empresa") = empresa
                    lpara("banco") = bancoSub
                    lpara("docto") = corre + 1
                    lpara("fecha") = fechaHoy
                    lpara("concepto") = "VALOR ANULACION NOTA BANCARIA" & chequeSub
                    cadena = "insert into diario1 (empresa,tipo,banco,docto,fecha,beneficiario,monto,concepto) 
                              values(@empresa,1,@banco,@docto,@fecha,'',0,@concepto)"
                    cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                Else
                    MsgBox("LA NOTA BANCARIA PERTENECE AL PERIODO FISCAL ANTERIOR, PARA EL REGISTRO CONTABLE DE LA ANULACION DEBE USARS NOTA DE CREDITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                End If
                lpara.Clear()
                lpara("empresa") = empresa
                lpara("docto") = chequeSub
                cadena = "select  prestamo ,  sum (abonos ) from prestamos2 where tipodocto='NB' and empresa=@empresa and docto=@docto group by prestamo"
                If cm.llenaTabla(cadena, TbTempEli, ListaParametros(lpara)) > 0 Then
                    filaTemp = TbTempEli.Rows(0)
                    lpara("prestamo") = filaTemp.Item(0)
                    cadena = "update prestamos1 set saldo=saldo + " & filaTemp.Item(1) & " where empresa=@empresa and prestamo=@prestamo"
                    cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    cadena = "delete from prestamos2  where empresa=@empresa and prestamo=@prestamo and tipodocto='NB' and docto=@docto"
                    cm.EjecutarNonQuery(cadena, ListaParametros(lpara))
                End If
                If cm.Commit Then
                    InsertBitacora(9, 3, "Anulación de nota bancaria en nóminas " + chequeSub.ToString())
                    MsgBox("OPERACIÓN REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                    btnlimpiar_Click(sender, e)
                End If
            End If
        Catch ex As Exception
            cm.RollBack()
            MsgBox("Error en la anulación " & vbNewLine & ex.Message, "Mensaje del Sistema")
        End Try



    End Sub

    Private Sub ctxModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificar.Click
        TextConlConcepto.ReadOnly = False
        btnGuardar.Visible = True
        btnBuscar.Visible = False
        btnSig.Enabled = False
        btnAtr.Enabled = False
        TextConlConcepto.BackColor = ColorModi
        ContextoMenuEnab(False, True, ctxPrincipal)
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        lpara.Clear()
        Dim fechaI, fechaF As Date
        If validetError(TextConxCheque, ep1) = False Or validetComilla(TextConlConcepto, ep1) = False Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        fechaI = dtpFechai.Text
        fechaF = dtpFechaf.Text
        If fechaI >= fechaF Then
            MsgBox("FECHA DEBE INICIAL DEBE SER MENOR  QUE LA FECHA FINAL", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If

        Dim modelo As New cmodelo
        Try
            lpara("empresa") = empresa
            lpara("fechaI") = fechaI
            lpara("fechaF") = fechaF
            lpara("concepto") = TextConlConcepto.Text
            lpara("cheque") = chequeSub
            If MsgBox("ESTA SEGURO QUE DESEA ACTUALIZAR ESTE REGISTRO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                cadena = "update extra1 set fechaI=@fechaI, fechaf=@fechaF, concepto=@concepto " &
                         "where empresa=@empresa and cheque=@cheque and tipo='NB'"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                cadena = "update diario1 set concepto=@concepto " &
                         "where tipo=2 and empresa=@empresa and docto=@cheque"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                cadena = "update notasban set concepto=@concepto " &
                         "where empresa=@empresa and nota=@cheque"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

            End If
            If modelo.Commit() Then
                MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                InsertBitacora(9, 2, "Modificación de nota " + chequeSub.ToString())
                btnlimpiar_Click(sender, e)
            End If
        Catch ex As Exception
            modelo.RollBack()
            MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
#End Region


    Private Function formato(ByVal numformato As Decimal) As String
        Return Format(numformato, "#,##0.00")
    End Function

#Region "BOTONES SIGUIENTE Y ATRAS"
    Private Sub btnSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSig.Click

        gpDetalle.Visible = False
        indice = indice + 1
        LlenarTextBox(sender, e, indice, tbConsulta)
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub

    Private Sub btnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtr.Click

        gpDetalle.Visible = False
        indice = indice - 1
        LlenarTextBox(sender, e, indice, tbConsulta)
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
    End Sub

#End Region

    Private Sub cmbConsuBanco_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNombBanco.SelectedIndexChanged, cmbBanco.SelectedIndexChanged
        AlinearCombos(sender, cmbBanco, cmbNombBanco)
    End Sub

    Private Sub btnBusCFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        f = New frmConsultaFechas
        f.TopMost = True
        AddHandler f.actValor, AddressOf ActualizacionDatosFecha
        f.inicializador("e1", "fecha")
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosFecha(ByVal sender As Object, ByVal e As clsActValorREvento)
        ConsultaFecha = e.va1

    End Sub

    Private Sub TextConsCheque_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        soloNumero(sender, e)
    End Sub

    Private Sub cmbCentro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbBanco.KeyDown
        If e.KeyCode = 13 Then
            ComboCambio(sender)
            sender.selectall()
            If sender.text.trim <> "" Then
                btnBuscar_Click(sender, e)
            End If
        End If
    End Sub

    Private Sub dgData_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgData.CellDoubleClick
        Dim filaSeleccionada As DataRow = CType(dgData.SelectedRows(0).DataBoundItem, DataRowView).Row
        Dim indiceTabla As Int32 = tbConsulta.Rows.IndexOf(filaSeleccionada)
        indice = indiceTabla
        LlenarTextBox(sender, e, indice, tbConsulta)
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSig, btnAtr)
        tcPrincipal.SelectedTab = tpPrincipal
    End Sub

    Private Sub txtFiltro_TextChanged(sender As Object, e As EventArgs) Handles txtFiltro.TextChanged
        If (dgData.DataSource IsNot Nothing) Then
            If (Not String.IsNullOrEmpty(txtFiltro.Text.Trim())) Then
                Dim tbCons As DataTable = dgData.DataSource
                Dim filtro As String = ""

                If (IsNumeric(txtFiltro.Text)) Then
                    If Not (String.IsNullOrEmpty(filtro)) Then
                        filtro += " or "
                    End If
                    filtro += $"cheque = {txtFiltro.Text} or empleado={txtFiltro.Text}"
                End If
                If (Not String.IsNullOrEmpty(txtFiltro.Text.Trim)) Then
                    If Not (String.IsNullOrEmpty(filtro)) Then
                        filtro += " or "
                    End If
                    filtro += $" concepto like '%{txtFiltro.Text}%'"
                End If

                If (String.IsNullOrEmpty(filtro)) Then
                    tbCons.DefaultView.RowFilter = ""
                Else
                    tbCons.DefaultView.RowFilter = filtro
                End If
            Else
                tbConsulta.DefaultView.RowFilter = ""
            End If
        ElseIf (Not String.IsNullOrEmpty(txtFiltro.Text.Trim())) Then
            txtFiltro.Clear()
        End If
    End Sub

    Private Sub TextConsCheque_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextConlConcepto.Enter, cmbEstado.Enter, cmbBanco.Enter, cmbNombBanco.Enter, textConxEmpleado.Enter, textNombreEmple.Enter, TextConxContrato.Enter, TextMoneda.Enter, TextMonto.Enter, TextTasa.Enter, TextFechaOp.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextConlConcepto.Leave, cmbEstado.Leave, cmbBanco.Leave, cmbNombBanco.Leave, textConxEmpleado.Leave, textNombreEmple.Leave, TextConxContrato.Leave, TextMoneda.Leave, TextMonto.Leave, TextTasa.Leave, TextFechaOp.Leave
        'cambia el color cuando un objeto pierde el foco
        desactiva(sender)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        btnlimpiar.Focus()
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub
End Class


