Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMLISTADOSEGUROSOCIAL.VB MIEMBRO DE NOMINA.SLN                             **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmListadoSeguroSocial
    Inherits Form
    Dim cadena As String

    Dim tbEmpresa As New DataTable("empresa")
    Dim tbTipo As New DataTable("tipo")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim v As New cryListadoSS
    Friend WithEvents gpTipo As System.Windows.Forms.GroupBox
    Friend WithEvents rdArchivo As System.Windows.Forms.RadioButton
    Friend WithEvents rdListado As System.Windows.Forms.RadioButton
    Friend WithEvents GuardaArchi As System.Windows.Forms.SaveFileDialog
    Dim tt As New DataTable("datos")
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageNuevo As ImageList
    Dim oWrite As StreamWriter
    Friend WithEvents dtpFecha As DateTimePicker
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
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents TextAño As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoSeguroSocial))
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevo = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.gpTipo = New System.Windows.Forms.GroupBox()
        Me.rdArchivo = New System.Windows.Forms.RadioButton()
        Me.rdListado = New System.Windows.Forms.RadioButton()
        Me.GuardaArchi = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gpFecha.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpTipo.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpFecha
        '
        Me.gpFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpFecha.Controls.Add(Me.dtpFecha)
        Me.gpFecha.Controls.Add(Me.Label6)
        Me.gpFecha.Controls.Add(Me.Label4)
        Me.gpFecha.Controls.Add(Me.Label3)
        Me.gpFecha.Controls.Add(Me.Label2)
        Me.gpFecha.Controls.Add(Me.cmbTipo)
        Me.gpFecha.Controls.Add(Me.TextAño)
        Me.gpFecha.Controls.Add(Me.cmbMes)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.ForeColor = System.Drawing.Color.White
        Me.gpFecha.Location = New System.Drawing.Point(227, 4)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(727, 47)
        Me.gpFecha.TabIndex = 1
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Tipo y periodo"
        '
        'dtpFecha
        '
        Me.dtpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(602, 20)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(105, 20)
        Me.dtpFecha.TabIndex = 61
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(9, 23)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 13)
        Me.Label6.TabIndex = 63
        Me.Label6.Text = "Tipo de nómina:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(556, 23)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 13)
        Me.Label4.TabIndex = 64
        Me.Label4.Text = "Fecha:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(460, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 63
        Me.Label3.Text = "Año:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(296, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 62
        Me.Label2.Text = "Mes:"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(107, 19)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(183, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'TextAño
        '
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(494, 21)
        Me.TextAño.MaxLength = 4
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(56, 20)
        Me.TextAño.TabIndex = 3
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(333, 20)
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
        Me.btnEjecutar.ImageList = Me.ImageNuevo
        Me.btnEjecutar.Location = New System.Drawing.Point(997, 3)
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
        Me.btnLimpiar.Location = New System.Drawing.Point(998, 39)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 59
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
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
        Me.crv.Location = New System.Drawing.Point(0, 79)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.ShowCloseButton = False
        Me.crv.ShowGotoPageButton = False
        Me.crv.ShowTextSearchButton = False
        Me.crv.Size = New System.Drawing.Size(1130, 526)
        Me.crv.TabIndex = 57
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'gpTipo
        '
        Me.gpTipo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpTipo.Controls.Add(Me.rdArchivo)
        Me.gpTipo.Controls.Add(Me.rdListado)
        Me.gpTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpTipo.ForeColor = System.Drawing.Color.White
        Me.gpTipo.Location = New System.Drawing.Point(69, 7)
        Me.gpTipo.Name = "gpTipo"
        Me.gpTipo.Size = New System.Drawing.Size(152, 41)
        Me.gpTipo.TabIndex = 60
        Me.gpTipo.TabStop = False
        Me.gpTipo.Text = "Tipo "
        '
        'rdArchivo
        '
        Me.rdArchivo.AutoSize = True
        Me.rdArchivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdArchivo.Location = New System.Drawing.Point(87, 18)
        Me.rdArchivo.Name = "rdArchivo"
        Me.rdArchivo.Size = New System.Drawing.Size(61, 17)
        Me.rdArchivo.TabIndex = 61
        Me.rdArchivo.TabStop = True
        Me.rdArchivo.Text = "Archivo"
        Me.rdArchivo.UseVisualStyleBackColor = True
        '
        'rdListado
        '
        Me.rdListado.AutoSize = True
        Me.rdListado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdListado.Location = New System.Drawing.Point(11, 18)
        Me.rdListado.Name = "rdListado"
        Me.rdListado.Size = New System.Drawing.Size(59, 17)
        Me.rdListado.TabIndex = 0
        Me.rdListado.TabStop = True
        Me.rdListado.Text = "Listado"
        Me.rdListado.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpTipo)
        Me.Panel1.Controls.Add(Me.gpFecha)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 73)
        Me.Panel1.TabIndex = 61
        '
        'frmListadoSeguroSocial
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmListadoSeguroSocial"
        Me.Text = "PLANILLA DE SEGURO SOCIAL                                        "
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpTipo.ResumeLayout(False)
        Me.gpTipo.PerformLayout()
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
        rdListado.Checked = True
        TextAño.Text = System.DateTime.Now.Year

        cmbMes.SelectedIndex = System.DateTime.Now.Month - 1
        cadena = "select nombre, t1.tiponom, count(*) as cuenta from tiponomina1 t1 " &
                 "left join tiponomina4 t4 on t1.empresa=t4.empresa and t1.tiponom=t4.tiponom " &
                 "where t1.empresa = @empresa and t1.tiponom in ('M','V','W','X') group by " &
                 "nombre, t1.tiponom "
        llena_combo(cadena, cmbTipo, ListaParametros(lpara))
        llenaTabla(cadena, tbTipo, ListaParametros(lpara))
        cmbTipo.Items.Add("")
        cmbTipo.SelectedIndex = 0
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        Dim año, mes As Int16
        Dim tipoNom As String
        Dim fechaFin As Date
        Dim fechaImp As Date
        Dim cadenaCond As String
        Dim Cuenta As Int16 = 0
        lpara.Clear()
        lpara("empresa") = empresa
        If rdListado.Checked Then
            If Not validetError(cmbTipo, ep1) Or Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) Then
                MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End If
            tipoNom = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
            Cuenta = tbTipo.Rows(cmbTipo.SelectedIndex).Item(2)
            año = CInt(TextAño.Text)
            mes = cmbMes.SelectedIndex + 1
            fechaImp = dtpFecha.Value.Date
            fechaFin = Date.DaysInMonth(año, mes) & "/" & mes & "/" & año
            cadena = "select nombre2, g.direccion, g.IGSS  from empresas e inner join generales g on e.empresa = g.empresa where e.empresa=@empresa"
            llenaTabla(cadena, tbEmpresa, ListaParametros(lpara))
            filaTemp = tbEmpresa.Rows(0)

            lpara("tiponom") = tipoNom
            lpara("mes") = mes
            lpara("año") = año
            lpara("fechaf") = fechaFin
            If Cuenta = 1 Then
                cadenaCond = "select * from LISTADOSEGUROSOCIAL (@tiponom,@mes,@año,@empresa,@fechaf) " &
                             "union all " &
                             "select * from  LISTADOSEGUROSOCIAL2 (@tiponom,@mes,@año,@empresa,@fechaf "
            Else
                cadenaCond = "select * from LISTADOSEGUROSOCIALCONTP (@tiponom,@mes,@año,@empresa,@fechaf) " &
                             "union all " &
                             "select * from  LISTADOSEGUROSOCIAL2CONTP (@tiponom,@mes,@año,@empresa,@fechaf "
            End If

            cadena = "select P.empleado, num, nombre, sum(valor) as valor, sum(valor*( por / 100 )) as valorSS, max(observa) as observa from ( " &
                     cadenaCond &
                     ")) P inner join v_EmpleadosNuevo e on p.empresa=e.empresa and " &
                     "p.empleado=e.empleado group by p.empleado, p.num, e.nombre  order by P.num"
            If llenaTabla(cadena, tt, ListaParametros(lpara)) > 0 Then

                v.SetDataSource(tt)
                v.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperLetter
                v.SetParameterValue("establecimiento", filaTemp.Item(0))
                v.SetParameterValue("patrono", filaTemp.Item(0))
                v.SetParameterValue("establecimiento", filaTemp.Item(0))
                v.SetParameterValue("direccionPatrono", filaTemp.Item(1))
                v.SetParameterValue("direccionEstablecimiento", filaTemp.Item(1))
                v.SetParameterValue("patronal", filaTemp.Item(2))
                v.SetParameterValue("iggs", BuscaEscalar("select por from pasivolab1 where empresa=" & empresa & " and pasivo=1"))
                v.SetParameterValue("intecap", BuscaEscalar("select por from pasivolab1 where empresa=" & empresa & " and pasivo=2"))
                v.SetParameterValue("irtra", BuscaEscalar("select por from pasivolab1 where empresa=" & empresa & " and pasivo=3"))
                v.SetParameterValue("fechaFin", fechaFin)
                v.SetParameterValue("fechaEs", fechaImp)
                crv.ReportSource = v
                crv.Refresh() '
            Else
                MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
            End If
        Else
            If Not validetError(cmbTipo, ep1) Or Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) Then
                MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End If
            GuardaArchi.Title = "GUARDAR ARCHIVO"
            GuardaArchi.FileName = "IGSS-ARCHIVO-" & cmbMes.Text.Trim & TextAño.Text.Trim
            GuardaArchi.Filter = "Todos los Archivos (*.*)|*.*|Archivos de separado por comas" & _
            "(*.csv)|*.csv"
            ' Specify default filter
            GuardaArchi.FilterIndex = 2
            If GuardaArchi.ShowDialog() = Windows.Forms.DialogResult.OK Then
                GuardaArchi_FileOk()
            End If
        End If

       
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


    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        borra_Mejorado(gpFecha, ep1)
        crv.ReportSource = Nothing
    End Sub

    Private Sub GuardaArchi_FileOk()
        Dim año, mes As Int16
        Dim tipoNom As String
        Dim fechaFin As Date
        Dim cadenaCond As String
        Dim Cuenta As Int16 = 0
        Dim nombreArchi As String
        Dim tbDatos As New DataTable("datos")
        Dim i As Int32
        lpara.Clear()
        tipoNom = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
        Cuenta = tbTipo.Rows(cmbTipo.SelectedIndex).Item(2)
        año = CInt(TextAño.Text)
        mes = cmbMes.SelectedIndex + 1
        fechaFin = Date.DaysInMonth(año, mes) & "/" & mes & "/" & año

        lpara("empresa") = empresa
        lpara("tiponom") = tipoNom
        lpara("mes") = mes
        lpara("año") = año
        lpara("fechaf") = fechaFin
        If Cuenta = 1 Then
            cadenaCond = "select * from LISTADOSEGUROSOCIAL (@tiponom,@mes,@año,@empresa,@fechaf) " &
                         "union all " &
                         "select * from  LISTADOSEGUROSOCIAL2 (@tiponom,@mes,@año,@empresa,@fechaf) "
        Else
            cadenaCond = "select * from LISTADOSEGUROSOCIALCONTP (@tiponom,@mes,@año,@empresa,@fechaf) " &
                         "union all " &
                         "select * from  LISTADOSEGUROSOCIAL2CONTP (@tiponom,@mes,@año,@empresa,@fechaf) "
        End If
        cadena = "select P.empleado, p.num, e.nombre, sum(valor) as valor, sum(valor*( por / 100 )) as valorSS, max(observa) as observa from ( " &
                 cadenaCond &
                 ") P inner join v_EmpleadosNuevo e on p.empresa=e.empresa and " &
                 "p.empleado=e.empleado group by p.empleado, p.num, e.nombre  order by P.num"
        nombreArchi = GuardaArchi.FileName()
        oWrite = File.CreateText(nombreArchi)
        If llenaTabla(cadena, tbDatos, ListaParametros(lpara)) > 0 Then
            For i = 0 To tbDatos.Rows.Count - 1
                filaTemp = tbDatos.Rows(i)
                oWrite.WriteLine(filaTemp.Item("num") & "," & filaTemp.Item("valor") & "," & "1")
            Next i
            MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
        Else
            MsgBox("NO SE ENCUENTRAN REGISTROS PARA GENERAR ESTA NOMINA", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
        oWrite.Close()
    End Sub
End Class
