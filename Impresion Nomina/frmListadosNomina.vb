Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMLISTADOSNOMINA.VB MIEMBRO DE NOMINA.SLN                                  **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmListadosNomina
    Inherits Form
    Dim cadena As String
    Dim tbContra1 As New DataTable("contra1")
    Dim tbTipo As New DataTable("tipo")
    Dim tbTipoPersonal As New DataTable("tipo")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim vVertical As New cryListadoNominaG
    Dim vHorizontal As New cryListadoNominaVertical
    Dim tt As New DataTable("datos")
    Dim tbTipoSeguro As New DataTable("seguro")
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPersonal As System.Windows.Forms.ComboBox
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoSS As System.Windows.Forms.ComboBox
    Dim lpara As New Dictionary(Of String, Object)
    ' Dim v As ReportClass



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
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents TextAño As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadosNomina))
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbTipoSS = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbTipoPersonal = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gpFecha.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpFecha
        '
        Me.gpFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpFecha.Controls.Add(Me.Label1)
        Me.gpFecha.Controls.Add(Me.cmbTipoSS)
        Me.gpFecha.Controls.Add(Me.Label5)
        Me.gpFecha.Controls.Add(Me.cmbTipoPersonal)
        Me.gpFecha.Controls.Add(Me.Label4)
        Me.gpFecha.Controls.Add(Me.Label3)
        Me.gpFecha.Controls.Add(Me.Label2)
        Me.gpFecha.Controls.Add(Me.cmbTipo)
        Me.gpFecha.Controls.Add(Me.TextAño)
        Me.gpFecha.Controls.Add(Me.cmbMes)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.ForeColor = System.Drawing.Color.White
        Me.gpFecha.Location = New System.Drawing.Point(3, 41)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(1124, 42)
        Me.gpFecha.TabIndex = 1
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Tipo y periodo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(816, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 13)
        Me.Label1.TabIndex = 60
        Me.Label1.Text = "Tipo seguro social:"
        '
        'cmbTipoSS
        '
        Me.cmbTipoSS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoSS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoSS.Location = New System.Drawing.Point(919, 12)
        Me.cmbTipoSS.Name = "cmbTipoSS"
        Me.cmbTipoSS.Size = New System.Drawing.Size(203, 21)
        Me.cmbTipoSS.TabIndex = 27
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(513, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 26
        Me.Label5.Text = "Tipo de personal:"
        '
        'cmbTipoPersonal
        '
        Me.cmbTipoPersonal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoPersonal.Location = New System.Drawing.Point(610, 12)
        Me.cmbTipoPersonal.Name = "cmbTipoPersonal"
        Me.cmbTipoPersonal.Size = New System.Drawing.Size(199, 21)
        Me.cmbTipoPersonal.TabIndex = 25
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(415, 15)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 13)
        Me.Label4.TabIndex = 24
        Me.Label4.Text = "Año: "
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(249, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Mes:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Tipo nómina:"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(85, 12)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(159, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'TextAño
        '
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(452, 13)
        Me.TextAño.MaxLength = 4
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(56, 20)
        Me.TextAño.TabIndex = 3
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(286, 12)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(121, 21)
        Me.cmbMes.TabIndex = 2
        '
        'btnEjecutar
        '
        Me.btnEjecutar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "reportegenerar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevos
        Me.btnEjecutar.Location = New System.Drawing.Point(957, 3)
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
        Me.btnLimpiar.Location = New System.Drawing.Point(1044, 3)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 59
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'gpEmpresa
        '
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(12, 0)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(456, 42)
        Me.gpEmpresa.TabIndex = 56
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(14, 16)
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(428, 21)
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
        Me.crv.Location = New System.Drawing.Point(0, 89)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.ShowCloseButton = False
        Me.crv.ShowGotoPageButton = False
        Me.crv.ShowTextSearchButton = False
        Me.crv.Size = New System.Drawing.Size(1130, 498)
        Me.crv.TabIndex = 57
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gpFecha)
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 89)
        Me.Panel1.TabIndex = 60
        '
        'frmListadosNomina
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 587)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmListadosNomina"
        Me.Text = "Impresión de Nómina"
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        cadena = "select nombre from meses order by mes"
        llena_combo(cadena, cmbMes)
        cmbMes.Items.Add("")
        TextAño.Text = System.DateTime.Now.Year
        TextNombEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=@empresa", ListaParametros(lpara))
        cmbMes.SelectedIndex = System.DateTime.Now.Month - 1
        cadena = "select nombre, tiponom, cantidad, por, movimientos, desprestamos, tipago from tiponomina1 where empresa=@empresa"
        llena_combo(cadena, cmbTipo, ListaParametros(lpara))
        llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        cmbTipo.Items.Add("")
        cmbTipo.SelectedIndex = 0
        cadena = "select 'TODOS' as nombre, 0 as tipoper union all select nombre, tipoper from tipopersonal where empresa=@empresa order by tipoper"
        llenaTabla(cadena, tbTipoPersonal, ListaParametros(lpara))
        llena_combo(cadena, cmbTipoPersonal, ListaParametros(lpara))
        cmbTipoPersonal.Items.Add("")

        cadena = "select nombre, tiposeguro from segurosocial where empresa=@empresa order by tiposeguro"
        llenaTabla(cadena, tbTipoSeguro, ListaParametros(lpara))
        llena_combo(cadena, cmbTipoSS, ListaParametros(lpara))
        cmbTipoSS.Items.Add("")
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        Dim tipoNPago As String = ""
        Dim tbFaltante As DataTable
        Dim año, mes, tipoPersonal As Int16
        Dim condicion2 As String = ""
        Dim condicion3 As String = ""
        Dim tipoNom, tipago, tipoNombPersonal As String
        lpara.Clear()
        lpara("empresa") = empresa
        Me.Cursor = Cursors.WaitCursor
        If Not validetError(cmbTipo, ep1) Or Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) Or _
               not validetError(cmbTipoPersonal, ep1) Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If
        tipoNom = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
        año = CInt(TextAño.Text)
        mes = cmbMes.SelectedIndex + 1
        tipago = tbTipo.Rows(cmbTipo.SelectedIndex).Item("tipago")
        tipoPersonal = tbTipoPersonal.Rows(cmbTipoPersonal.SelectedIndex).Item("tipoper")
        tipoNombPersonal = tbTipoPersonal.Rows(cmbTipoPersonal.SelectedIndex).Item("nombre")

        'Cambio 4 Nov del 2011
        'La siguiente búsqueda funciona para verificar que todas las transacciones en la nómina generada
        'se encuentren en las tablas de estructura de los listados
        lpara("tiponom") = tipoNom
        lpara("año") = año
        lpara("mes") = mes

        cadena = "select distinct (tip.transac), tip.nombre from nominas nom " &
                 "inner join tipotran tip on nom.empresa=tip.empresa and nom.transac=tip.transac " &
                 "where nom.empresa=@empresa and tiponom=@tiponom and año=@año and mes=@mes and tip.transac not in ( " &
                 "select transac from estructuranom2 where empresa=@empresa and tiponom=@tiponom) "
        tbFaltante = New DataTable("faltante")
        If llenaTabla(cadena, tbFaltante, ListaParametros(lpara)) Then
            cadena = "NO PUEDE GENERARSE EL REPORTE PORQUE DEBE ASOCIAR LAS SIGUIENTES TRANSACCIONES: " & vbNewLine
            For Each ftemp As DataRow In tbFaltante.Rows
                cadena = cadena & ftemp.Item("transac") & " " & ftemp.Item("nombre") & vbNewLine
            Next
            MsgBox(cadena, MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Me.Cursor = Cursors.Default
            Exit Sub

        End If


        If tipago = "A" Then
            condicion2 = "and tip.basevaca >=" & mes
            If tipoPersonal > 0 Then
                condicion2 = condicion2 & " and c1.tipoper=" & tipoPersonal
            End If
        Else
            condicion2 = ""
            If tipoPersonal > 0 Then
                condicion2 = "and c1.tipoper=" & tipoPersonal
            Else

                'Se realiza la siguiente separación porque si no muestra los empleados académicos con valor 0 para las 
                'nóminas que no les corresponde
                Select Case tipoNom
                    Case "W", "X"
                        ' Empleados tipopersonal académicos
                        condicion2 = "and c1.tipoper=1"
                    Case "V"
                        ' Empleados Administrativo
                        condicion2 = "and c1.tipoper in (5,2)"
                End Select
            End If
        End If
        If cmbTipoSS.Text.Trim <> "" Then
            condicion3 = " and ss.tiposeguro=" & tbTipoSeguro.Rows(cmbTipoSS.SelectedIndex).Item("tiposeguro")
        End If
        lpara("nombreEmpresa") = TextNombEmpresa.Text.Trim
        lpara("tipo") = cmbTipo.Text.Trim
        cadena = "select LL.*, c1.*, tip.* from ListadosNomina(@mes,@año,@empresa,@nombreEmpresa,@tiponom,@tipo) LL " &
           "inner join contratos1 c1 on c1.empresa=LL.empresa and c1.empleado=LL.empleado and c1.contrato=LL.contrato " &
           "inner join tipopersonal tip on c1.empresa=tip.empresa and c1.tipoper=tip.tipoper " &
           "inner join segurosocial ss on c1.empresa=ss.empresa and c1.tiposeguro=ss.tiposeguro, " &
           "(select empleado, contrato from ListadosNomina(@mes,@año,@empresa,@nombreEmpresa,@tiponom,@tipo) group by " &
           "empleado, contrato having sum(valor) > 0) CC " &
           "where CC.empleado=LL.empleado and CC.contrato=c1.contrato and " &
           "LL.empleado in ( select empleado from nominas where empresa=@empresa " &
           " and tiponom=@tiponom and mes=@mes and año=@año) " & condicion2 & condicion3 & " " &
           "order by LL.tipoper, LL.nombEmpleado, LL.contrato, LL.dias"
        If llenaTabla(cadena, tt, ListaParametros(lpara)) > 0 Then
            cadena = "select count( distinct(columna)) from ListadosNomina(@mes,@año,@empresa,@nombreEmpresa,@tiponom,@tipo)  "
            If BuscaEscalar(cadena, ListaParametros(lpara)) > 5 Then
                Dim v As New cryListadoNominaVertical

                v.SetDataSource(tt)
                v.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Landscape
                v.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperFolio
                v.SetParameterValue("tipoPersonal", "TIPO DE PERSONAL: " & tipoNombPersonal)
                crv.ReportSource = v
            Else
                Dim v As New cryListadoNominaG
                v.SetDataSource(tt)
                v.PrintOptions.PaperOrientation = CrystalDecisions.Shared.PaperOrientation.Portrait
                v.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperFolio
                v.SetParameterValue("tipoPersonal", "TIPO DE PERSONAL: " & tipoNombPersonal)
                crv.ReportSource = v
            End If
            '  v.SetDatabaseLogon(usuarioDB, passwordDB, servidorDB, baseDatosDB)


        Else
            MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub cmbMes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub TextAño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextAño.KeyPress
        soloNumero(sender, e)
    End Sub

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub crv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles crv.Load

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        borra_Mejorado(gpFecha, ep1)
        crv.ReportSource = Nothing
    End Sub
End Class
