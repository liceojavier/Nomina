Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Drawing.Printing
Imports System.IO
Imports System.Net.Mail
Imports System.Net

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMIMPRESIONRECIBO.VB MIEMBRO DE NOMINA.SLN                                 **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmImpresionRecibo
    Inherits Form
    Dim cadena As String
    Dim tbContra1 As New DataTable("contra1")
    Dim tbTipo As New DataTable("tipo")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim vVertical As New cryListadoNominaG
    Dim tt As New DataTable("datos")
    Dim v As New Recibo
    Dim v2012 As Recibo2012
    Dim _nombre_empresa As String = ""
    Dim _moneda_empresa As String = ""
    Dim rawKind As Int32

    Dim tbTipoPersonal As New DataTable
    Dim tbEmpleado As New DataTable
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
    Friend WithEvents gpInfo As System.Windows.Forms.Panel
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents TextAño As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Private WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents bwTrabajo As System.ComponentModel.BackgroundWorker

    Friend WithEvents pbLoading As System.Windows.Forms.PictureBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbTipoPersonal As System.Windows.Forms.ComboBox
    Friend WithEvents gpChofer As System.Windows.Forms.GroupBox
    Friend WithEvents btnEmpleado As System.Windows.Forms.Button
    Friend WithEvents textNombreEmple As System.Windows.Forms.TextBox
    Friend WithEvents textEmpleado As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmImpresionRecibo))
        Me.gpInfo = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnEmpleado = New System.Windows.Forms.Button()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pbLoading = New System.Windows.Forms.PictureBox()
        Me.gpChofer = New System.Windows.Forms.GroupBox()
        Me.textNombreEmple = New System.Windows.Forms.TextBox()
        Me.textEmpleado = New System.Windows.Forms.TextBox()
        Me.bwTrabajo = New System.ComponentModel.BackgroundWorker()
        Me.gpInfo.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.pbLoading, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpChofer.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpInfo
        '
        Me.gpInfo.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpInfo.Controls.Add(Me.Label1)
        Me.gpInfo.Controls.Add(Me.cmbTipoPersonal)
        Me.gpInfo.Controls.Add(Me.Label4)
        Me.gpInfo.Controls.Add(Me.Label3)
        Me.gpInfo.Controls.Add(Me.Label2)
        Me.gpInfo.Controls.Add(Me.cmbTipo)
        Me.gpInfo.Controls.Add(Me.TextAño)
        Me.gpInfo.Controls.Add(Me.cmbMes)
        Me.gpInfo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpInfo.ForeColor = System.Drawing.Color.White
        Me.gpInfo.Location = New System.Drawing.Point(12, 9)
        Me.gpInfo.Name = "gpInfo"
        Me.gpInfo.Size = New System.Drawing.Size(859, 44)
        Me.gpInfo.TabIndex = 1
        Me.gpInfo.TabStop = False
        Me.gpInfo.Text = "Tipo y periodo"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(558, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 13)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "Tipo de personal:"
        '
        'cmbTipoPersonal
        '
        Me.cmbTipoPersonal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoPersonal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoPersonal.Location = New System.Drawing.Point(652, 13)
        Me.cmbTipoPersonal.Name = "cmbTipoPersonal"
        Me.cmbTipoPersonal.Size = New System.Drawing.Size(196, 21)
        Me.cmbTipoPersonal.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(464, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Año:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(300, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Mes:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Tipo nómina:"
        '
        'cmbTipo
        '
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.Location = New System.Drawing.Point(85, 14)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(209, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'TextAño
        '
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(497, 14)
        Me.TextAño.MaxLength = 4
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(56, 20)
        Me.TextAño.TabIndex = 3
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(337, 13)
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
        Me.btnEjecutar.Location = New System.Drawing.Point(1014, 7)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(74, 30)
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
        Me.ImageNuevos.Images.SetKeyName(21, "enviar.png")
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackColor = System.Drawing.SystemColors.Control
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.ImageKey = "(ninguno)"
        Me.Button1.ImageList = Me.ImageNuevos
        Me.Button1.Location = New System.Drawing.Point(1014, 43)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(104, 30)
        Me.Button1.TabIndex = 57
        Me.Button1.Text = "Enviar correo"
        Me.ToolTip1.SetToolTip(Me.Button1, "Enviar vía correo")
        Me.Button1.UseVisualStyleBackColor = False
        '
        'btnEmpleado
        '
        Me.btnEmpleado.BackColor = System.Drawing.SystemColors.Control
        Me.btnEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEmpleado.ForeColor = System.Drawing.Color.Black
        Me.btnEmpleado.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEmpleado.ImageKey = "usuario.png"
        Me.btnEmpleado.ImageList = Me.ImageNuevos
        Me.btnEmpleado.Location = New System.Drawing.Point(536, 9)
        Me.btnEmpleado.Name = "btnEmpleado"
        Me.btnEmpleado.Size = New System.Drawing.Size(82, 30)
        Me.btnEmpleado.TabIndex = 3
        Me.btnEmpleado.Text = "Empleado"
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
        Me.crv.Location = New System.Drawing.Point(0, 120)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.ShowCloseButton = False
        Me.crv.ShowGotoPageButton = False
        Me.crv.ShowTextSearchButton = False
        Me.crv.Size = New System.Drawing.Size(1130, 486)
        Me.crv.TabIndex = 57
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv.ViewTimeSelectionFormula = ""
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.pbLoading)
        Me.Panel1.Controls.Add(Me.gpChofer)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.gpInfo)
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 117)
        Me.Panel1.TabIndex = 58
        '
        'pbLoading
        '
        Me.pbLoading.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.pbLoading.Image = CType(resources.GetObject("pbLoading.Image"), System.Drawing.Image)
        Me.pbLoading.Location = New System.Drawing.Point(877, 4)
        Me.pbLoading.Name = "pbLoading"
        Me.pbLoading.Size = New System.Drawing.Size(118, 110)
        Me.pbLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLoading.TabIndex = 59
        Me.pbLoading.TabStop = False
        '
        'gpChofer
        '
        Me.gpChofer.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpChofer.Controls.Add(Me.btnEmpleado)
        Me.gpChofer.Controls.Add(Me.textNombreEmple)
        Me.gpChofer.Controls.Add(Me.textEmpleado)
        Me.gpChofer.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpChofer.ForeColor = System.Drawing.Color.White
        Me.gpChofer.Location = New System.Drawing.Point(12, 57)
        Me.gpChofer.Name = "gpChofer"
        Me.gpChofer.Size = New System.Drawing.Size(622, 44)
        Me.gpChofer.TabIndex = 58
        Me.gpChofer.TabStop = False
        Me.gpChofer.Text = "Empleado"
        '
        'textNombreEmple
        '
        Me.textNombreEmple.BackColor = System.Drawing.Color.White
        Me.textNombreEmple.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNombreEmple.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNombreEmple.Location = New System.Drawing.Point(68, 19)
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
        Me.textEmpleado.Location = New System.Drawing.Point(6, 19)
        Me.textEmpleado.MaxLength = 6
        Me.textEmpleado.Name = "textEmpleado"
        Me.textEmpleado.Size = New System.Drawing.Size(56, 20)
        Me.textEmpleado.TabIndex = 1
        '
        'bwTrabajo
        '
        '
        'frmImpresionRecibo
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmImpresionRecibo"
        Me.Text = "Impresión General de Recibos de Nómina"
        Me.gpInfo.ResumeLayout(False)
        Me.gpInfo.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.pbLoading, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpChofer.ResumeLayout(False)
        Me.gpChofer.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Class bitacora
        Public id As Int32
        Public nombre As String
        Public correo As String
        Public observacion As String
        Public enviado As String
        Public nombre_empresa As String
    End Class

    Private Class info
        Public tiponom As String
        Public mes As Int32
        Public año As Int32
        Public nombre_mes As String
        Public nombre_nomina As String
        Public tipoper As Int32
        Public empleado As Integer
    End Class

    Private Class respuesta
        Public lista As List(Of bitacora)
        Public mensaje As String
        Public ejecutado As Boolean
    End Class



#Region "EMLEADO"


    Private Sub BorraEmpleado(ByVal valbool As Boolean)
            textNombreEmple.Clear()
            If valbool = True Then
                textEmpleado.Clear()
            End If
        End Sub


        Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
            Dim numFilas As Int32
            lpara.Clear()
            lpara("empresa") = empresa
            lpara("nombre") = textNombreEmple.Text.Trim
            cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=@empresa and nombre like '%' + @nombre + '%' " &
                  " and e.empleado in ( select empleado from contratos1 c1 " &
                  "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) " &
                  "order by nombre"
            numFilas = llenaTabla(cadena, tbEmpleado, ListaParametros(lpara))
            If numFilas = 0 Then
                MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textEmpleado.Focus()
            ElseIf numFilas = 1 Then
                BorraEmpleado(True)
                filaTemp = tbEmpleado.Rows.Item(0)
                textEmpleado.Text() = filaTemp.Item(0)
                textNombreEmple.Text = filaTemp.Item(1)

            Else
                EnBuscaEmpleado()
            End If
        End Sub

        Private Sub ValidaEmpleado()
            lpara.Clear()
            lpara("empresa") = empresa
            lpara("empleado") = textEmpleado.Text.Trim
            If valida_tipo_Entero(textEmpleado.Text, 2) = True Then
                If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=@empresa and empleado=@empleado", ListaParametros(lpara)) = 0 Then
                    MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                    BorraEmpleado(True)
                    textEmpleado.Focus()
                    Exit Sub
                End If
                cadena = "select empleado, nombre from v_empleadosNuevo e where empresa=@empresa " &
                    " and empleado=@empleado " &
                    " and e.empleado in ( select empleado from contratos1 c1 " &
                    "inner join empestados es  on c1.empresa=es.empresa and c1.estado=es.estado where es.activo='S' and c1.empresa=e.empresa ) "
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
            Dim fEmp As New frmMuestraCodigos
            fEmp.TopMost = True
            fEmp.inicializa(tbEmpleado)
            AddHandler fEmp.actValor, AddressOf ActualizacionDatosEmpleados
            fEmp.StartPosition = FormStartPosition.CenterScreen
            fEmp.ShowDialog()
        End Sub

        Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
            BorraEmpleado(True)
            filaTemp = tbEmpleado.Rows.Item(e.va2)
            textEmpleado.Text() = filaTemp.Item(0)
            textNombreEmple.Text = filaTemp.Item(1)
        End Sub

#End Region


        Private Sub frmSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim i As Int16
            lpara.Clear()
            lpara("empresa") = empresa
            cadena = "select nombre from meses order by mes"
            llena_combo(cadena, cmbMes)
            cmbMes.Items.Add("")
            TextAño.Text = System.DateTime.Now.Year
            EscribeEmpresa(_nombre_empresa, _moneda_empresa)
            cmbMes.SelectedIndex = System.DateTime.Now.Month - 1
            cadena = "select nombre, tiponom, cantidad, por, movimientos, desprestamos from tiponomina1 where empresa=@empresa"
            llena_combo(cadena, cmbTipo, ListaParametros(lpara))
            llenaTabla(cadena, tbTipo, ListaParametros(lpara))
            cmbTipo.Items.Add("")
            cmbTipo.SelectedIndex = 0
            Dim doctoprint As New PrintDocument
            For i = 0 To doctoprint.PrinterSettings.PaperSizes.Count - 1
                If doctoprint.PrinterSettings.PaperSizes(i).PaperName.Trim.ToUpper = "mediaCartaSistema".ToUpper Then
                    rawKind = CInt(doctoprint.PrinterSettings.PaperSizes(i).GetType().GetField("kind",
                   Reflection.BindingFlags.Instance Or Reflection.BindingFlags.NonPublic).GetValue(doctoprint.PrinterSettings.PaperSizes(i)))
                    Exit For
                End If
            Next
            cadena = "select nombre, tipoper from tipopersonal where empresa=@empresa order by tipoper"
            llenaTabla(cadena, tbTipoPersonal, ListaParametros(lpara))
            llena_combo(cadena, cmbTipoPersonal, ListaParametros(lpara))
            cmbTipoPersonal.Items.Add("")
            pbLoading.Visible = False
        End Sub


        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
            Dim año, mes As Int16
            Dim tipoNom As String = ""
            Dim condicion As String = ""
            Dim condiEmple As String = ""
            lpara.Clear()
            lpara("empresa") = empresa

            lpara("empleado") = textEmpleado.Text
            If Not validetError(cmbTipo, ep1) Or Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) Then
                MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End If
            If cmbTipoPersonal.Text.Trim <> "" Then
                lpara("tipoper") = tbTipoPersonal.Rows(cmbTipoPersonal.SelectedIndex).Item("tipoper")
                condicion = " and tipoper=@tipoper "
            End If
            If textEmpleado.Text.Trim <> "" And IsNumeric(textEmpleado.Text) Then
                condiEmple = " and empleado=@empleado "
            End If


            tipoNom = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
            año = CInt(TextAño.Text)
            mes = cmbMes.SelectedIndex + 1
            lpara("tiponom") = tipoNom
            lpara("mes") = mes
            lpara("año") = año
            cadena = "select * from v_ReciboNomina2012 where empresa=@empresa " &
                 " and tiponom=@tiponom and mes=@mes AND AÑO=@año " &
                 " and tipomov<>'L' " & condicion & condiEmple & " order by nombEmpleado, empleado, contrato, transac"
            v2012 = New Recibo2012
            If llenaTabla(cadena, tt, ListaParametros(lpara)) > 0 Then
                ''    DataGridView1.DataSource = tt

                v2012.SetDataSource(tt)
                v2012.PrintOptions.PaperSize = rawKind
                crv.ReportSource = v2012
                crv.Refresh()
                InsertBitacora(9, 5, Me.Text)
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

        Private Sub TextAño_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextAño.KeyPress
            soloNumero(sender, e)
        End Sub

        Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
            Me.Dispose(True)
            Me.Close()
            Me.Finalize()
        End Sub

        Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
            Dim año, mes As Int16
            Dim tipoNom As String
            If MsgBox("ESTA SEGURO QUE DESEA ENVIAR LOS RECIBOS POR CORREO ELECTRONICO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                If Not validetError(cmbTipo, ep1) Or Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) Then
                    MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    Exit Sub
                End If
                gpInfo.Enabled = False
                Button1.Enabled = False
                btnEjecutar.Enabled = False
                Me.Cursor = Cursors.WaitCursor
                tipoNom = tbTipo.Rows(cmbTipo.SelectedIndex).Item(1)
                año = CInt(TextAño.Text)
                mes = cmbMes.SelectedIndex + 1
                Dim infoNom As New info
                infoNom.mes = mes
                infoNom.año = año
                infoNom.tiponom = tipoNom
                infoNom.nombre_mes = cmbMes.Text.Trim
                infoNom.nombre_nomina = cmbTipo.Text.Trim
                If cmbTipoPersonal.Text.Trim = "" Then
                    infoNom.tipoper = 0
                Else
                    infoNom.tipoper = tbTipoPersonal.Rows(cmbTipoPersonal.SelectedIndex).Item("tipoper")
                End If
                If (textEmpleado.Text.Trim <> "" AndAlso IsNumeric(textEmpleado.Text)) Then
                    infoNom.empleado = CInt(textEmpleado.Text)
                Else
                    infoNom.empleado = 0
                End If

                bwTrabajo.RunWorkerAsync(infoNom)
                pbLoading.Visible = True
            End If
        End Sub


        Private Function envio(ByVal Id As Int32, ByVal DeSMTP As String, ByVal DeNombre As String, ByVal asunto As String, ByVal NDestinatario As String,
                           ByVal CDestinatario As String, ByVal archivo As String, ByVal cuerpo As String, ByVal mailDestAdi As MailAddress) As bitacora
            '  Dim imagen As My.Resources '

            Dim vistaPlano As AlternateView
            Dim registro As New bitacora
            'Dim tbArgumentos(1) As DataTable
            Dim mailDireccion As New MailAddress(DeSMTP, DeNombre, System.Text.Encoding.UTF8)
            Dim mailMensaje As MailMessage
            Dim smtpCliente As SmtpClient
            Dim archivosM As Attachment
            Dim smtpAutenticacion As New NetworkCredential(_userSMTP, _passSMTP)

        Dim correoBody(1) As String
            registro.id = Id
            registro.nombre = NDestinatario
            registro.correo = CDestinatario
            If Not String.IsNullOrEmpty(CDestinatario) Then
                Try
                    Dim mailDest As New MailAddress(CDestinatario, NDestinatario)
                    '   Dim mailDestNom As New MailAddress("nomina@liceojavier.edu.gt", "Nomina")
                    mailMensaje = New MailMessage()
                    mailMensaje.From = mailDireccion

                    mailMensaje.To.Add(mailDest)
                    mailMensaje.To.Add(mailDestAdi)

                    If File.Exists(archivo) Then
                        archivosM = New Attachment(archivo)
                        mailMensaje.Attachments.Add(archivosM)
                    End If
                    mailMensaje.Subject = asunto
                    '---------------------
                    vistaPlano = AlternateView.CreateAlternateViewFromString(cuerpo, System.Text.Encoding.UTF8, "text/plain")
                    mailMensaje.AlternateViews.Add(vistaPlano)
                    '----------------------------------------
                    smtpCliente = New SmtpClient(_ServerSMTP)
                    If _esAutenticado Then
                        smtpCliente.Credentials() = smtpAutenticacion
                    End If
                    smtpCliente.Port = _puertoSMTP
                    smtpCliente.EnableSsl = _sslSMTP
                    smtpCliente.Send(mailMensaje)
                    registro.observacion = "Correo enviado"
                    registro.enviado = "SI"
                    mailMensaje.Dispose()

                Catch ex As Exception
                    registro.observacion = "No se ha enviado el correo. Error " & vbNewLine & ex.Message
                    registro.enviado = "NO"
                End Try
            Else
                registro.observacion = "No se ha enviado porque el correo no existe o no está asociado"
                registro.enviado = "NO"

            End If


            Return registro

        End Function

        Private Sub bwTrabajo_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bwTrabajo.DoWork
            Dim mensaje As String = ""
            Dim lregistro As New List(Of bitacora)
            Dim vbool As Boolean = True
            lpara.Clear()
            Try
                Dim path_temp As String = ""
                Dim infoNom As info = CType(e.Argument, info)
                path_temp = Environment.GetEnvironmentVariable("temp")
                If Directory.Exists(path_temp) Then
                    Dim mailDestNom As New MailAddress("nomina@liceojavier.edu.gt", "Nomina")
                    If Not Directory.Exists(path_temp & "\nomina") Then
                        Directory.CreateDirectory(path_temp & "\nomina")
                    End If
                    path_temp = path_temp & "\nomina\"
                    Dim año, mes As Int16
                    Dim tipoNom As String
                    Dim tbPersonal As New DataTable
                    Dim tbEle As DataTable
                    Dim vRec As Recibo2012
                    Dim nombArchivo As String = ""
                    Dim condicion As String = ""
                    Dim condiEmple As String = ""
                    If infoNom.tipoper <> 0 Then
                        condicion = " and tipoper=@tipoper "
                        lpara("tipoper") = infoNom.tipoper
                    End If

                    If textEmpleado.Text.Trim <> "" And IsNumeric(textEmpleado.Text) Then
                        condiEmple = " and empleado=@empleado "
                        lpara("empleado") = CInt(textEmpleado.Text)
                    End If

                    Dim leyenda As String = "Todos los colaboradores tiene 5 días hábiles para " &
                                         "hacer cualquier consulta o reclamo en relación a su boleta " &
                                         "de pago de forma expresa enviando un correo a: nomina@liceojavier.edu.gt, " &
                                         "después de este tiempo se asume que el colaborador ha recibido su pago conforme y " &
                                         "que no existe ningún error en la boleta"
                    vRec = New Recibo2012
                    tipoNom = infoNom.tiponom
                    año = infoNom.año
                    mes = infoNom.mes
                    lpara("empresa") = empresa
                    lpara("tiponom") = tipoNom.Trim
                    lpara("mes") = mes
                    lpara("año") = año
                    cadena = "select * from v_ReciboNomina2012 where empresa=@empresa " &
                         " and tiponom=@tiponom and mes=@mes AND AÑO=@año " &
                         " and tipomov<>'L' " & condicion & condiEmple & " order by nombEmpleado, empleado, contrato, transac"
                    Dim nomb_empleado As String = ""
                    If llenaTabla(cadena, tbPersonal, ListaParametros(lpara)) > 0 Then
                        Dim llog As New List(Of bitacora)
                        Dim registro As bitacora

                        Dim lemple As List(Of Int32)
                        Dim cuerpo As String
                        lemple = (From ele In tbPersonal.AsEnumerable()
                                  Select ele.Field(Of Int32)("empleado")).Distinct().ToList()
                        'Distinct por empleado
                        For Each empleado As Int32 In lemple

                            nombArchivo = path_temp & empleado & ".pdf"
                            'Borra el archivo por si existe
                            If File.Exists(nombArchivo) Then
                                File.Delete(nombArchivo)
                            End If

                            lpara("empleado") = empleado
                            tbEle = New DataTable()
                            cadena = "select * from v_ReciboNomina2012 where empresa=@empresa " &
                                 " and tiponom=@tiponom and mes=@mes AND AÑO=@año " &
                                 " and tipomov<>'L' and empleado=@empleado order by nombEmpleado, empleado, contrato, transac"
                            If llenaTabla(cadena, tbEle, ListaParametros(lpara)) Then
                                vRec.SetDataSource(tbEle)
                                vRec.PrintOptions.PaperSize = rawKind
                                vRec.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, nombArchivo)

                            End If

                            'Obtiene información específica
                            Dim query As bitacora = (From ele In tbPersonal.AsEnumerable()
                                                     Where ele.Field(Of Int32)("empleado") = empleado
                                                     Select New bitacora With {.id = ele.Field(Of Int32)("empleado"),
                                                   .nombre = ele.Field(Of String)("nombEmpleado"),
                                                    .correo = ele.Field(Of String)("correoi"),
                                                    .observacion = "",
                                                    .nombre_empresa = ele.Field(Of String)("nombEmpresa")}
                                                 ).FirstOrDefault
                        If Not (query Is Nothing) Then

                            cuerpo = "Buen día " & query.nombre & ":" & vbNewLine &
                                         "Por este medio se adjunta su boleta de pago correspondiente a la nomina " &
                                         infoNom.nombre_nomina & " MES " & infoNom.mes & " AÑO " & año & "." & vbNewLine &
                                         "Atte. " & vbNewLine & vbNewLine & Definiciones._nombre_empresa & vbNewLine & vbNewLine & vbNewLine & leyenda
                            'Envío de mensaje
                            registro = envio(empleado, _correo, "Sistema de Personal", "Recibo de Pago ",
                                             query.nombre, query.correo, nombArchivo, cuerpo, mailDestNom)
                            llog.Add(registro)
                            lpara.Clear()
                            cadena = "insert into log_envio_recibo (empresa,empleado,estado,observaciones,mes,año,tiponom,fecha,hora) values " &
                            "(@empresa,@empleado,@estado,@observaciones,@mes,@año,@tiponom,@fecha,@hora)"
                            lpara.Item("empresa") = empresa
                            lpara.Item("empleado") = empleado
                            lpara.Item("estado") = ""
                            lpara.Item("observaciones") = registro.observacion
                            lpara.Item("mes") = mes
                            lpara.Item("año") = año
                            lpara.Item("tiponom") = tipoNom
                            lpara("fecha") = Today
                            lpara("hora") = Now.ToString("HH:mm")
                            EjecutarQuery(cadena, ListaParametros(lpara))
                            lregistro.Add(registro)
                        End If
                    Next
                        mensaje = "Operación Realizada con éxito"
                    Else
                        mensaje = "NO HAY DATOS PARA PODER GENERAR ESTE LISTADO"
                    End If
                Else
                    mensaje = "NO EXISTE LA VARIABLE DE ENTORNO TEMP"
                End If

            Catch ex As Exception
                vbool = False
                mensaje = "Error del Sistema " & vbNewLine & ex.Message
            End Try
        Dim res As New respuesta
        res.ejecutado = vbool
            res.lista = lregistro
            res.mensaje = mensaje
            e.Result = res
        End Sub


        Private Function impresion_reporte(ByVal lregistro As List(Of bitacora), ByVal nomb_tiponom As String, ByVal año As Int32, ByVal nomb_mes As String) As Boolean
            For Each registro As bitacora In lregistro
                registro.nombre_empresa = _nombre_empresa
            Next
            If lregistro.Count > 0 Then
                Dim v As New cryListadoCEviados
                Dim dicPara As New Dictionary(Of String, Object)
                dicPara.Add("nomina", nomb_tiponom)
                dicPara.Add("mes", nomb_mes)
                dicPara.Add("año", año)
                Dim rep As New frmReporte
                rep.ds = lregistro
                rep.v = v
                rep.parametros = dicPara
                rep.ShowDialog()
            Else
                MsgBox("No hay registros para generar el reporte de enviados", MsgBoxStyle.Critical, "Mensaje del Sistema")
            End If

        End Function

        Private Sub bwTrabajo_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bwTrabajo.ProgressChanged



        End Sub

        Private Sub bwTrabajo_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwTrabajo.RunWorkerCompleted
        Dim res As respuesta = e.Result
        pbLoading.Visible = False
            MsgBox(res.mensaje)
            If res.ejecutado Then
                impresion_reporte(res.lista, cmbTipo.Text.Trim(), CInt(TextAño.Text), cmbMes.Text.Trim())
            End If
            Button1.Enabled = True
            btnEjecutar.Enabled = True
            gpInfo.Enabled = True
            Me.Cursor = Cursors.Default
        End Sub

        Private Sub gpFecha_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles gpInfo.Enter

        End Sub
    End Class
