Imports System.Data.SqlClient
Imports System.Drawing.Printing

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMCONSULTAPAGO.VB MIEMBRO DE NOMINA.SLN                                    **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmConsultaPago
    Inherits Form
    Dim cadena As String
    Dim tbForma As New DataTable("pago")
    Dim tbDatos As New DataTable("datos")
    Dim tbTipo As New DataTable("tipo")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbContratos As New DataTable("contratos")
    Dim tbConsulta As New DataTable("consulta")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim indice As Integer
    Dim inicioConsulta As String = "select p1.tiponom, p1.mes, p1.año, p1.fpago, p1.tipoforma,  p1.docto, p1.fecha, p1.empleado, p1.contrato, p1.monto, p1.fechae, p1.estado," & _
                               "p1.elaborado from pagosnom p1 where p1.empresa=" & empresa

    Dim WithEvents fEmp As frmMuestraCodigos
    Dim WithEvents f2C As frmMuestra2Columnas
    Dim v As Recibo
    Dim v2012 As Recibo2012
    Dim tt As DataTable
    Dim rawKind As Integer
    Dim tipoNom As String
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Dim tipoforma As String
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
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents TextConxAño As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextMoneEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents gpFormaPago As System.Windows.Forms.GroupBox
    Friend WithEvents cmbFormaPago As System.Windows.Forms.ComboBox
    Friend WithEvents TextNombBanco As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBanco As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents gpPrincipal As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextFecha As System.Windows.Forms.TextBox
    Friend WithEvents gpDocto As System.Windows.Forms.GroupBox
    Friend WithEvents TextConxDocto As System.Windows.Forms.TextBox
    Friend WithEvents gpContrato As System.Windows.Forms.GroupBox
    Friend WithEvents btnContrato As System.Windows.Forms.Button
    Friend WithEvents TextConxContrato As System.Windows.Forms.TextBox
    Friend WithEvents gpChofer As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents textConxEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TextFechae As System.Windows.Forms.TextBox
    Friend WithEvents TextTipo As System.Windows.Forms.TextBox
    Friend WithEvents TextMes As System.Windows.Forms.TextBox
    Friend WithEvents TextEstado As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbEstado As System.Windows.Forms.ComboBox
    Friend WithEvents TextFormaPago As System.Windows.Forms.TextBox
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnSig As System.Windows.Forms.Button
    Friend WithEvents btnAtr As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents ctxPrincipal As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxAnulacion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextTipoForma As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextMonto As System.Windows.Forms.TextBox
    Friend WithEvents TextUsuario As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaPago))
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TextConxAño = New System.Windows.Forms.TextBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.btnSig = New System.Windows.Forms.Button()
        Me.btnAtr = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextMoneEmpresa = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.gpFormaPago = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TextTipoForma = New System.Windows.Forms.TextBox()
        Me.TextFormaPago = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBanco = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbFormaPago = New System.Windows.Forms.ComboBox()
        Me.TextNombBanco = New System.Windows.Forms.TextBox()
        Me.gpPrincipal = New System.Windows.Forms.GroupBox()
        Me.ctxPrincipal = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxAnulacion = New System.Windows.Forms.ToolStripMenuItem()
        Me.TextUsuario = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextMonto = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TextFechae = New System.Windows.Forms.TextBox()
        Me.TextTipo = New System.Windows.Forms.TextBox()
        Me.TextMes = New System.Windows.Forms.TextBox()
        Me.TextEstado = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbEstado = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextFecha = New System.Windows.Forms.TextBox()
        Me.gpDocto = New System.Windows.Forms.GroupBox()
        Me.TextConxDocto = New System.Windows.Forms.TextBox()
        Me.gpContrato = New System.Windows.Forms.GroupBox()
        Me.btnContrato = New System.Windows.Forms.Button()
        Me.TextConxContrato = New System.Windows.Forms.TextBox()
        Me.gpChofer = New System.Windows.Forms.GroupBox()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textConxEmpleado = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.gpEmpresa.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpFormaPago.SuspendLayout()
        Me.gpPrincipal.SuspendLayout()
        Me.ctxPrincipal.SuspendLayout()
        Me.gpDocto.SuspendLayout()
        Me.gpContrato.SuspendLayout()
        Me.gpChofer.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(518, 87)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(29, 13)
        Me.Label9.TabIndex = 10
        Me.Label9.Text = "Año:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 87)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 9
        Me.Label8.Text = "Tipo de nómina:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(342, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Mes:"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(103, 84)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(208, 21)
        Me.cmbTipo.TabIndex = 4
        '
        'TextConxAño
        '
        Me.TextConxAño.BackColor = System.Drawing.Color.White
        Me.TextConxAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConxAño.Location = New System.Drawing.Point(553, 84)
        Me.TextConxAño.MaxLength = 4
        Me.TextConxAño.Name = "TextConxAño"
        Me.TextConxAño.Size = New System.Drawing.Size(56, 20)
        Me.TextConxAño.TabIndex = 6
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(381, 84)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(121, 21)
        Me.cmbMes.TabIndex = 5
        '
        'btnImprimir
        '
        Me.btnImprimir.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnImprimir.BackColor = System.Drawing.SystemColors.Control
        Me.btnImprimir.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImprimir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnImprimir.ImageKey = "impresora2.png"
        Me.btnImprimir.ImageList = Me.ImageNuevos
        Me.btnImprimir.Location = New System.Drawing.Point(557, 3)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(80, 30)
        Me.btnImprimir.TabIndex = 77
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnImprimir, "Imprimir Recibo")
        Me.btnImprimir.UseVisualStyleBackColor = False
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
        'btnSig
        '
        Me.btnSig.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSig.BackColor = System.Drawing.SystemColors.Control
        Me.btnSig.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnSig.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSig.ImageKey = "siguiente.png"
        Me.btnSig.ImageList = Me.ImageNuevos
        Me.btnSig.Location = New System.Drawing.Point(1047, 3)
        Me.btnSig.Name = "btnSig"
        Me.btnSig.Size = New System.Drawing.Size(80, 30)
        Me.btnSig.TabIndex = 76
        Me.btnSig.TabStop = False
        Me.btnSig.Text = "Siguiente"
        Me.btnSig.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnSig, "Siguiente Registro")
        Me.btnSig.UseVisualStyleBackColor = False
        '
        'btnAtr
        '
        Me.btnAtr.BackColor = System.Drawing.SystemColors.Control
        Me.btnAtr.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAtr.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtr.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAtr.ImageKey = "anterior.png"
        Me.btnAtr.ImageList = Me.ImageNuevos
        Me.btnAtr.Location = New System.Drawing.Point(4, 3)
        Me.btnAtr.Name = "btnAtr"
        Me.btnAtr.Size = New System.Drawing.Size(80, 30)
        Me.btnAtr.TabIndex = 75
        Me.btnAtr.TabStop = False
        Me.btnAtr.Text = "Anterior"
        Me.btnAtr.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAtr, "Registro anterior")
        Me.btnAtr.UseVisualStyleBackColor = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.ImageKey = "buscar2.png"
        Me.btnBuscar.ImageList = Me.ImageNuevos
        Me.btnBuscar.Location = New System.Drawing.Point(961, 3)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(80, 30)
        Me.btnBuscar.TabIndex = 74
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Buscar registro")
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(90, 3)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 73
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
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
        Me.btnEmpleado.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnEmpleado, "Empleado")
        Me.btnEmpleado.UseVisualStyleBackColor = False
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextMoneEmpresa)
        Me.gpEmpresa.Controls.Add(Me.Label10)
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(345, 2)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(456, 42)
        Me.gpEmpresa.TabIndex = 56
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextMoneEmpresa
        '
        Me.TextMoneEmpresa.BackColor = System.Drawing.Color.White
        Me.TextMoneEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMoneEmpresa.Location = New System.Drawing.Point(408, 16)
        Me.TextMoneEmpresa.Name = "TextMoneEmpresa"
        Me.TextMoneEmpresa.ReadOnly = True
        Me.TextMoneEmpresa.Size = New System.Drawing.Size(40, 21)
        Me.TextMoneEmpresa.TabIndex = 18
        Me.TextMoneEmpresa.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(344, 20)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 13)
        Me.Label10.TabIndex = 17
        Me.Label10.Text = "Moneda:"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(6, 16)
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(330, 21)
        Me.TextNombEmpresa.TabIndex = 2
        Me.TextNombEmpresa.TabStop = False
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'gpFormaPago
        '
        Me.gpFormaPago.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpFormaPago.Controls.Add(Me.Label12)
        Me.gpFormaPago.Controls.Add(Me.TextTipoForma)
        Me.gpFormaPago.Controls.Add(Me.TextFormaPago)
        Me.gpFormaPago.Controls.Add(Me.Label4)
        Me.gpFormaPago.Controls.Add(Me.TextBanco)
        Me.gpFormaPago.Controls.Add(Me.Label2)
        Me.gpFormaPago.Controls.Add(Me.cmbFormaPago)
        Me.gpFormaPago.Controls.Add(Me.TextNombBanco)
        Me.gpFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFormaPago.Location = New System.Drawing.Point(16, 119)
        Me.gpFormaPago.Name = "gpFormaPago"
        Me.gpFormaPago.Size = New System.Drawing.Size(917, 40)
        Me.gpFormaPago.TabIndex = 9
        Me.gpFormaPago.TabStop = False
        Me.gpFormaPago.Text = "Forma de pago"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(706, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Tipo:"
        '
        'TextTipoForma
        '
        Me.TextTipoForma.BackColor = System.Drawing.Color.White
        Me.TextTipoForma.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipoForma.Location = New System.Drawing.Point(750, 17)
        Me.TextTipoForma.MaxLength = 4
        Me.TextTipoForma.Name = "TextTipoForma"
        Me.TextTipoForma.ReadOnly = True
        Me.TextTipoForma.Size = New System.Drawing.Size(155, 20)
        Me.TextTipoForma.TabIndex = 4
        Me.TextTipoForma.TabStop = False
        '
        'TextFormaPago
        '
        Me.TextFormaPago.BackColor = System.Drawing.Color.White
        Me.TextFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFormaPago.Location = New System.Drawing.Point(6, 17)
        Me.TextFormaPago.MaxLength = 4
        Me.TextFormaPago.Name = "TextFormaPago"
        Me.TextFormaPago.ReadOnly = True
        Me.TextFormaPago.Size = New System.Drawing.Size(208, 20)
        Me.TextFormaPago.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(232, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(41, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Banco:"
        '
        'TextBanco
        '
        Me.TextBanco.BackColor = System.Drawing.Color.White
        Me.TextBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBanco.Location = New System.Drawing.Point(288, 15)
        Me.TextBanco.MaxLength = 4
        Me.TextBanco.Name = "TextBanco"
        Me.TextBanco.ReadOnly = True
        Me.TextBanco.Size = New System.Drawing.Size(57, 20)
        Me.TextBanco.TabIndex = 7
        Me.TextBanco.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(356, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre:"
        '
        'cmbFormaPago
        '
        Me.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFormaPago.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFormaPago.Location = New System.Drawing.Point(6, 17)
        Me.cmbFormaPago.Name = "cmbFormaPago"
        Me.cmbFormaPago.Size = New System.Drawing.Size(208, 21)
        Me.cmbFormaPago.TabIndex = 1
        '
        'TextNombBanco
        '
        Me.TextNombBanco.BackColor = System.Drawing.Color.White
        Me.TextNombBanco.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombBanco.Location = New System.Drawing.Point(415, 17)
        Me.TextNombBanco.MaxLength = 4
        Me.TextNombBanco.Name = "TextNombBanco"
        Me.TextNombBanco.ReadOnly = True
        Me.TextNombBanco.Size = New System.Drawing.Size(283, 20)
        Me.TextNombBanco.TabIndex = 3
        Me.TextNombBanco.TabStop = False
        '
        'gpPrincipal
        '
        Me.gpPrincipal.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpPrincipal.ContextMenuStrip = Me.ctxPrincipal
        Me.gpPrincipal.Controls.Add(Me.TextUsuario)
        Me.gpPrincipal.Controls.Add(Me.Label14)
        Me.gpPrincipal.Controls.Add(Me.Label13)
        Me.gpPrincipal.Controls.Add(Me.TextMonto)
        Me.gpPrincipal.Controls.Add(Me.Label11)
        Me.gpPrincipal.Controls.Add(Me.TextFechae)
        Me.gpPrincipal.Controls.Add(Me.TextTipo)
        Me.gpPrincipal.Controls.Add(Me.TextMes)
        Me.gpPrincipal.Controls.Add(Me.TextEstado)
        Me.gpPrincipal.Controls.Add(Me.Label6)
        Me.gpPrincipal.Controls.Add(Me.cmbEstado)
        Me.gpPrincipal.Controls.Add(Me.Label3)
        Me.gpPrincipal.Controls.Add(Me.TextFecha)
        Me.gpPrincipal.Controls.Add(Me.gpDocto)
        Me.gpPrincipal.Controls.Add(Me.gpContrato)
        Me.gpPrincipal.Controls.Add(Me.gpChofer)
        Me.gpPrincipal.Controls.Add(Me.Label9)
        Me.gpPrincipal.Controls.Add(Me.gpFormaPago)
        Me.gpPrincipal.Controls.Add(Me.Label8)
        Me.gpPrincipal.Controls.Add(Me.Label7)
        Me.gpPrincipal.Controls.Add(Me.cmbMes)
        Me.gpPrincipal.Controls.Add(Me.cmbTipo)
        Me.gpPrincipal.Controls.Add(Me.TextConxAño)
        Me.gpPrincipal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpPrincipal.Location = New System.Drawing.Point(4, 58)
        Me.gpPrincipal.Name = "gpPrincipal"
        Me.gpPrincipal.Size = New System.Drawing.Size(960, 310)
        Me.gpPrincipal.TabIndex = 72
        Me.gpPrincipal.TabStop = False
        Me.gpPrincipal.Text = "Datos del pago"
        '
        'ctxPrincipal
        '
        Me.ctxPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxAnulacion})
        Me.ctxPrincipal.Name = "ctxMenu"
        Me.ctxPrincipal.Size = New System.Drawing.Size(129, 26)
        '
        'ctxAnulacion
        '
        Me.ctxAnulacion.Image = Global.NOMINA.My.Resources.Resources.cancelar
        Me.ctxAnulacion.Name = "ctxAnulacion"
        Me.ctxAnulacion.Size = New System.Drawing.Size(128, 22)
        Me.ctxAnulacion.Text = "Anulación"
        '
        'TextUsuario
        '
        Me.TextUsuario.BackColor = System.Drawing.Color.White
        Me.TextUsuario.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextUsuario.Location = New System.Drawing.Point(593, 183)
        Me.TextUsuario.MaxLength = 4
        Me.TextUsuario.Name = "TextUsuario"
        Me.TextUsuario.ReadOnly = True
        Me.TextUsuario.Size = New System.Drawing.Size(121, 20)
        Me.TextUsuario.TabIndex = 12
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(534, 187)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(46, 13)
        Me.Label14.TabIndex = 136
        Me.Label14.Text = "Usuario:"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(793, 87)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Monto:"
        '
        'TextMonto
        '
        Me.TextMonto.BackColor = System.Drawing.Color.White
        Me.TextMonto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMonto.Location = New System.Drawing.Point(842, 84)
        Me.TextMonto.MaxLength = 4
        Me.TextMonto.Name = "TextMonto"
        Me.TextMonto.ReadOnly = True
        Me.TextMonto.Size = New System.Drawing.Size(79, 20)
        Me.TextMonto.TabIndex = 8
        Me.TextMonto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(301, 185)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 13)
        Me.Label11.TabIndex = 22
        Me.Label11.Text = "Fecha de operación:"
        '
        'TextFechae
        '
        Me.TextFechae.BackColor = System.Drawing.Color.White
        Me.TextFechae.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechae.Location = New System.Drawing.Point(416, 184)
        Me.TextFechae.MaxLength = 4
        Me.TextFechae.Name = "TextFechae"
        Me.TextFechae.ReadOnly = True
        Me.TextFechae.Size = New System.Drawing.Size(86, 20)
        Me.TextFechae.TabIndex = 11
        '
        'TextTipo
        '
        Me.TextTipo.BackColor = System.Drawing.Color.White
        Me.TextTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTipo.Location = New System.Drawing.Point(102, 84)
        Me.TextTipo.MaxLength = 4
        Me.TextTipo.Name = "TextTipo"
        Me.TextTipo.ReadOnly = True
        Me.TextTipo.Size = New System.Drawing.Size(208, 20)
        Me.TextTipo.TabIndex = 4
        '
        'TextMes
        '
        Me.TextMes.BackColor = System.Drawing.Color.White
        Me.TextMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMes.Location = New System.Drawing.Point(381, 84)
        Me.TextMes.MaxLength = 4
        Me.TextMes.Name = "TextMes"
        Me.TextMes.ReadOnly = True
        Me.TextMes.Size = New System.Drawing.Size(121, 20)
        Me.TextMes.TabIndex = 5
        '
        'TextEstado
        '
        Me.TextEstado.BackColor = System.Drawing.Color.White
        Me.TextEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEstado.Location = New System.Drawing.Point(76, 180)
        Me.TextEstado.MaxLength = 4
        Me.TextEstado.Name = "TextEstado"
        Me.TextEstado.ReadOnly = True
        Me.TextEstado.Size = New System.Drawing.Size(208, 20)
        Me.TextEstado.TabIndex = 10
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(13, 183)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "Estado:"
        '
        'cmbEstado
        '
        Me.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstado.Items.AddRange(New Object() {"ACTIVO", "ANULADO", "TRASLADADO A CONTABILIDAD", ""})
        Me.cmbEstado.Location = New System.Drawing.Point(76, 180)
        Me.cmbEstado.Name = "cmbEstado"
        Me.cmbEstado.Size = New System.Drawing.Size(208, 21)
        Me.cmbEstado.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(626, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Fecha:"
        '
        'TextFecha
        '
        Me.TextFecha.BackColor = System.Drawing.Color.White
        Me.TextFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFecha.Location = New System.Drawing.Point(674, 84)
        Me.TextFecha.MaxLength = 4
        Me.TextFecha.Name = "TextFecha"
        Me.TextFecha.ReadOnly = True
        Me.TextFecha.Size = New System.Drawing.Size(86, 20)
        Me.TextFecha.TabIndex = 7
        '
        'gpDocto
        '
        Me.gpDocto.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpDocto.Controls.Add(Me.TextConxDocto)
        Me.gpDocto.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.gpDocto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDocto.Location = New System.Drawing.Point(665, 22)
        Me.gpDocto.Name = "gpDocto"
        Me.gpDocto.Size = New System.Drawing.Size(104, 40)
        Me.gpDocto.TabIndex = 1
        Me.gpDocto.TabStop = False
        Me.gpDocto.Text = "Documento"
        '
        'TextConxDocto
        '
        Me.TextConxDocto.BackColor = System.Drawing.Color.White
        Me.TextConxDocto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConxDocto.ForeColor = System.Drawing.Color.Red
        Me.TextConxDocto.Location = New System.Drawing.Point(8, 16)
        Me.TextConxDocto.Name = "TextConxDocto"
        Me.TextConxDocto.ReadOnly = True
        Me.TextConxDocto.Size = New System.Drawing.Size(87, 20)
        Me.TextConxDocto.TabIndex = 0
        Me.TextConxDocto.TabStop = False
        '
        'gpContrato
        '
        Me.gpContrato.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpContrato.Controls.Add(Me.btnContrato)
        Me.gpContrato.Controls.Add(Me.TextConxContrato)
        Me.gpContrato.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpContrato.Location = New System.Drawing.Point(784, 22)
        Me.gpContrato.Name = "gpContrato"
        Me.gpContrato.Size = New System.Drawing.Size(137, 40)
        Me.gpContrato.TabIndex = 3
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
        Me.btnContrato.Size = New System.Drawing.Size(40, 30)
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
        Me.gpChofer.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpChofer.Controls.Add(Me.btnEmpleado)
        Me.gpChofer.Controls.Add(Me.textNombreEmple)
        Me.gpChofer.Controls.Add(Me.textConxEmpleado)
        Me.gpChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpChofer.Location = New System.Drawing.Point(10, 22)
        Me.gpChofer.Name = "gpChofer"
        Me.gpChofer.Size = New System.Drawing.Size(622, 40)
        Me.gpChofer.TabIndex = 2
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
        'textConxEmpleado
        '
        Me.textConxEmpleado.BackColor = System.Drawing.Color.White
        Me.textConxEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textConxEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textConxEmpleado.Location = New System.Drawing.Point(6, 16)
        Me.textConxEmpleado.MaxLength = 6
        Me.textConxEmpleado.Name = "textConxEmpleado"
        Me.textConxEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textConxEmpleado.TabIndex = 1
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 54)
        Me.Panel1.TabIndex = 78
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnImprimir)
        Me.Panel2.Controls.Add(Me.btnAtr)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.btnSig)
        Me.Panel2.Controls.Add(Me.btnBuscar)
        Me.Panel2.Location = New System.Drawing.Point(0, 558)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1130, 47)
        Me.Panel2.TabIndex = 79
        '
        'frmConsultaPago
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.gpPrincipal)
        Me.Controls.Add(Me.gpEmpresa)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmConsultaPago"
        Me.Text = "Mantenimiento de Pagos"
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpFormaPago.ResumeLayout(False)
        Me.gpFormaPago.PerformLayout()
        Me.gpPrincipal.ResumeLayout(False)
        Me.gpPrincipal.PerformLayout()
        Me.ctxPrincipal.ResumeLayout(False)
        Me.gpDocto.ResumeLayout(False)
        Me.gpDocto.PerformLayout()
        Me.gpContrato.ResumeLayout(False)
        Me.gpContrato.PerformLayout()
        Me.gpChofer.ResumeLayout(False)
        Me.gpChofer.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        Dim i As Integer
        cadena = "select nombre from meses order by mes"
        llena_combo(cadena, cmbMes)
        cmbMes.Items.Add("")
        TextConxAño.Text = System.DateTime.Now.Year
        EscribeEmpresa(TextNombEmpresa, TextMoneEmpresa)
        cmbMes.SelectedIndex = System.DateTime.Now.Month - 1
        cadena = "select nombre, tiponom from tiponomina1 where empresa=@empresa"
        llena_combo(cadena, cmbTipo, ListaParametros(lpara))
        llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        cmbTipo.Items.Add("")
        cadena = "SELECT fp.nombre, fpago, tipoforma, fp.BANCO, b.nombre + ' CTA ' + bc.cta  AS nombBanco, " &
           "bc.cheque FROM formapagoper fp inner join bancoscta bc on fp.empresa=bc.empresa and fp.banco=bc.banco " &
           "inner join bancos b on b.empresa=fp.empresa and b.codigo=bc.codigo where fp.empresa=@empresa " &
           "order by fp.banco"
        llena_combo(cadena, cmbFormaPago, ListaParametros(lpara))
        llenaTabla(cadena, tbForma, ListaParametros(lpara))
        cmbFormaPago.Items.Add("")
        Dim doctoprint As New PrintDocument
        For i = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
            If doctoprint.PrinterSettings.PaperSizes(i).PaperName.ToUpper = "mediaCartaSistema".ToUpper Then
                rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind",
                   Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                Exit For
            End If
        Next

        btnLimpiar_Click(sender, e)
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        btnSig.Enabled = False
        btnAtr.Enabled = False
        btnBuscar.Enabled = True
        btnBuscar.Visible = True
        btnEmpleado.Enabled = True
        btnContrato.Enabled = True
        btnImprimir.Enabled = False
        textNombreEmple.ReadOnly = False
        ContextoMenuEnab(True, False, ctxPrincipal)
        borra_Mejorado(gpPrincipal, ep1)
        SoloLeer(gpPrincipal, False)
        ConsultaReadOnly(gpPrincipal, False)
        textConxEmpleado.Focus()
    End Sub


#Region "EMLEADO"
    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        TextConxContrato.Clear()
        If valbool = True Then
            textConxEmpleado.Clear()
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
            If BuscaEscalar("Select count (*) from v_empleadosNuevo where empresa=@empresa And empleado=@empleado", ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textConxEmpleado.Focus()
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
            textConxEmpleado.Focus()
        End If
    End Sub

    Private Sub TextEmpleado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textConxEmpleado.Validated
        If textConxEmpleado.Text.Trim <> "" And textConxEmpleado.ReadOnly = False Then
            ValidaEmpleado()
        ElseIf textConxEmpleado.ReadOnly = False Then
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

#Region "Contrato"

    Private Sub BtnContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnContrato.Click
        Dim Num As Int16
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("empleado") = textConxEmpleado.Text
        If textConxEmpleado.Text.Trim <> "" Then
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
                cmbTipo.Focus()

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
            cadena = "Select count(*) from contratos1 c1 inner join empestados e On e.estado=c1.estado And e.empresa=c1.empresa " &
                     "where c1.empresa=@empresa And empleado=@empleado  And c1.contrato=@contrato"
            If BuscaEscalar(cadena, ListaParametros(lpara)) = 0 Then
                MsgBox("NO EXISTE ESTE NUMERO DE CONTRATO PARA ESTE EMPLEADO", MsgBoxStyle.Information, "Mensaje del Sistema")
                TextConxContrato.Clear()
            End If
        Else
            TextConxContrato.Clear()
        End If
    End Sub

#End Region
    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        lpara.Clear()
        Dim finConsulta, cadenaConsulta As String
        finConsulta = ""
        GeneraConsulta(gpPrincipal, finConsulta, "P1")

        lpara("mes") = cmbMes.SelectedIndex + 1
        lpara("estado") = cmbEstado.SelectedIndex


        If cmbTipo.Text.Trim <> "" Then
            lpara("tiponom") = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
            finConsulta = finConsulta & " And p1.tiponom=@tiponom "
        End If
        If cmbMes.Text.Trim <> "" Then
            finConsulta = finConsulta & " and p1.mes=@mes "
        End If
        If cmbEstado.Text.Trim <> "" Then
            finConsulta = finConsulta & " and p1.estado=@estado "
        End If
        cadenaConsulta = inicioConsulta & finConsulta & " order by p1.tiponom, p1.mes, p1.año, fpago, tipoforma, docto, empleado, contrato "
        Mostrar(cadenaConsulta, sender, e)
    End Sub

    Private Sub Mostrar(ByVal subCadena As String, ByVal sender As System.Object, ByVal e As System.EventArgs)
        ConsultaReadOnly(gpPrincipal, True)
        textNombreEmple.ReadOnly = True
        btnEmpleado.Enabled = False
        btnContrato.Enabled = False
        SoloLeer(gpPrincipal, True)
        btnBuscar.Enabled = False
        ContextoMenuEnab(True, True, ctxPrincipal)
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
        filaCopiar = tabla.Rows.Item(indi)
        BuscaElementoCombo(tbTipo, filaCopiar.Item(0), cmbTipo, 1, False)
        TextTipo.Text = cmbTipo.Text
        tipoNom = filaCopiar.Item(0)
        cmbMes.SelectedIndex = filaCopiar.Item(1) - 1
        TextMes.Text = cmbMes.Text
        TextConxAño.Text = filaCopiar.Item(2)
        BuscaElementoCombo(tbForma, filaCopiar.Item(3), cmbFormaPago, 1, True)
        TextFormaPago.Text = cmbFormaPago.Text
        Select Case filaCopiar.Item(4)
            Case "C"
                TextTipoForma.Text = "CHEQUE"
            Case "D"
                TextTipoForma.Text = "DEPOSITO"
        End Select
        tipoforma = filaCopiar.Item(4)
        TextConxDocto.Text = filaCopiar.Item(5)
        TextFecha.Text = filaCopiar.Item(6)
        textConxEmpleado.Text = filaCopiar.Item(7)
        ValidaEmpleado()
        TextConxContrato.Text = filaCopiar.Item(8)
        TextMonto.Text = formato(filaCopiar.Item(9))
        TextFechae.Text = filaCopiar.Item(10)
        Select Case filaCopiar.Item(11)
            Case 0
                ctxAnulacion.Enabled = True
                btnImprimir.Enabled = True
            Case 1
                ctxAnulacion.Enabled = False
                btnImprimir.Enabled = False
        End Select
        cmbEstado.SelectedIndex = filaCopiar.Item(11)
        TextEstado.Text = cmbEstado.Text
        TextUsuario.Text = filaCopiar.Item(12)
    End Sub

    Private Sub cmbFormaPago_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbFormaPago.SelectedIndexChanged
        If cmbFormaPago.Text.Trim <> "" Then
            filaTemp = tbForma.Rows(cmbFormaPago.SelectedIndex)
            TextBanco.Text = filaTemp.Item(3)
            TextNombBanco.Text = filaTemp.Item(4)
        Else
            TextBanco.Clear()
            TextNombBanco.Clear()
        End If
    End Sub

    Private Sub ctxAnulacion_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxAnulacion.Click
        Dim fechaActual As String = DateTime.Today.ToString("yyyy/MM/dd")
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("fechae") = fechaActual
        lpara("tiponom") = tipoNom
        lpara("mes") = cmbMes.SelectedIndex + 1
        lpara("año") = TextConxAño.Text
        lpara("empleado") = textConxEmpleado.Text
        lpara("contrato") = TextConxContrato.Text
        lpara("tipoForma") = tipoforma
        lpara("docto") = TextConxDocto.Text
        If MsgBox("ESTA SEGURO DE ANULAR ESTE PAGO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
            Dim modelo As New cmodelo
            Try

                cadena = "update pagosnom set estado=1, fechae=@fechae where empresa=@empresa " &
                         " and tiponom=@tiponom and mes=@mes AND AÑO=@año " &
                         " and empleado=@empleado and contrato=@contrato and tipoforma=@tipoForma and docto=@docto"
                modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                InsertBitacora(9, 3, Me.Text)
                MsgBox("OPERACION REALIZA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                btnLimpiar_Click(sender, e)
                modelo.Commit()
                Exit Sub
            Catch ex As Exception
                MsgBox("Error del sitema: " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                modelo.RollBack()
            End Try
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


    Private Sub cmbMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub btnImprimirAnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("tiponom") = tipoNom
        lpara("mes") = cmbMes.SelectedIndex + 1
        lpara("año") = TextConxAño.Text
        lpara("empleado") = textConxEmpleado.Text
        lpara("contrato") = TextConxContrato.Text
        cadena = "select * from v_ReciboNomina where empresa=@empresa " &
                 " and tiponom=@tiponom and mes=@mes AND AÑO=@año " &
                 " and empleado=@empleado and contrato=@contrato order by transac"
        v = New Recibo
        tt = New DataTable("datos")
        llenaTabla(cadena, tt, ListaParametros(lpara))
        If (tt.Rows.Count > 0) Then
            v.SetDataSource(tt)
            ' v.Refresh()

            v.PrintOptions.PaperSize = rawKind
            v.PrintToPrinter(1, False, 1, 1)

        End If
    End Sub


    Private Sub btnImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImprimir.Click
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("tiponom") = tipoNom
        lpara("mes") = cmbMes.SelectedIndex + 1
        lpara("año") = TextConxAño.Text
        lpara("empleado") = textConxEmpleado.Text
        lpara("contrato") = TextConxContrato.Text
        cadena = "select * from v_ReciboNomina2012 where empresa=@empresa " &
                 " and tiponom=@tiponom and mes=@mes AND AÑO=@año " &
                 " and empleado=@empleado and contrato=@contrato order by transac"
        v2012 = New Recibo2012
        tt = New DataTable("datos")
        llenaTabla(cadena, tt, ListaParametros(lpara))
        If (tt.Rows.Count > 0) Then
            v2012.SetDataSource(tt)
            ' v.Refresh()

            v2012.PrintOptions.PaperSize = rawKind
            v2012.PrintToPrinter(1, False, 1, 1)

        End If
        InsertBitacora(9, 5, Me.Text)
    End Sub

    Private Sub TextAño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextConxAño.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

End Class
