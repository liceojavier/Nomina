Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMLISTADOCONTRATOSCENTRO.VB MIEMBRO DE NOMINA.SLN                          **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmListadoContratosCentro
    Inherits Form
    Dim cadena As String
    Dim tbTipoDif As New DataTable("tipo")
    Dim tbOrigen As New DataTable("origen")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim v As New cryListadoCentroNomina
    Dim tt As New DataTable("datos")
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageNuevo As ImageList
    Dim f2C As frmMuestra2Columnas
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
    Friend WithEvents btnEjecutar As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents gpTipo As System.Windows.Forms.GroupBox
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents gpCentro As System.Windows.Forms.GroupBox
    Friend WithEvents TextOrigen As System.Windows.Forms.TextBox
    Friend WithEvents TextNombOrigen As System.Windows.Forms.TextBox
    Friend WithEvents btnOrigen As System.Windows.Forms.Button


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoContratosCentro))
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevo = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.btnOrigen = New System.Windows.Forms.Button()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.gpTipo = New System.Windows.Forms.GroupBox()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.gpCentro = New System.Windows.Forms.GroupBox()
        Me.TextOrigen = New System.Windows.Forms.TextBox()
        Me.TextNombOrigen = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.gpEmpresa.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpTipo.SuspendLayout()
        Me.gpCentro.SuspendLayout()
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
        Me.btnEjecutar.ImageList = Me.ImageNuevo
        Me.btnEjecutar.Location = New System.Drawing.Point(996, 4)
        Me.btnEjecutar.Name = "btnEjecutar"
        Me.btnEjecutar.Size = New System.Drawing.Size(80, 30)
        Me.btnEjecutar.TabIndex = 4
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
        Me.btnLimpiar.Location = New System.Drawing.Point(996, 44)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 5
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'btnOrigen
        '
        Me.btnOrigen.BackColor = System.Drawing.SystemColors.Control
        Me.btnOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOrigen.ForeColor = System.Drawing.SystemColors.ControlText
        Me.btnOrigen.ImageKey = "buscar1.png"
        Me.btnOrigen.ImageList = Me.ImageNuevo
        Me.btnOrigen.Location = New System.Drawing.Point(385, 13)
        Me.btnOrigen.Name = "btnOrigen"
        Me.btnOrigen.Size = New System.Drawing.Size(60, 30)
        Me.btnOrigen.TabIndex = 3
        Me.btnOrigen.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnOrigen, "Buscar el centro de costo")
        Me.btnOrigen.UseVisualStyleBackColor = False
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
        Me.TextNombEmpresa.Size = New System.Drawing.Size(434, 21)
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
        Me.crv.Location = New System.Drawing.Point(0, 98)
        Me.crv.Name = "crv"
        Me.crv.SelectionFormula = ""
        Me.crv.ShowCloseButton = False
        Me.crv.ShowGotoPageButton = False
        Me.crv.ShowTextSearchButton = False
        Me.crv.Size = New System.Drawing.Size(1130, 507)
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
        Me.gpTipo.Location = New System.Drawing.Point(93, 44)
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
        Me.cmbTipo.Items.AddRange(New Object() {"GENERAL", "CENTRO DE COSTO"})
        Me.cmbTipo.Location = New System.Drawing.Point(8, 20)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(222, 21)
        Me.cmbTipo.TabIndex = 2
        '
        'gpCentro
        '
        Me.gpCentro.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpCentro.Controls.Add(Me.TextOrigen)
        Me.gpCentro.Controls.Add(Me.TextNombOrigen)
        Me.gpCentro.Controls.Add(Me.btnOrigen)
        Me.gpCentro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCentro.ForeColor = System.Drawing.Color.White
        Me.gpCentro.Location = New System.Drawing.Point(337, 44)
        Me.gpCentro.Name = "gpCentro"
        Me.gpCentro.Size = New System.Drawing.Size(456, 48)
        Me.gpCentro.TabIndex = 58
        Me.gpCentro.TabStop = False
        Me.gpCentro.Text = "Centro"
        '
        'TextOrigen
        '
        Me.TextOrigen.BackColor = System.Drawing.Color.White
        Me.TextOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextOrigen.Location = New System.Drawing.Point(6, 21)
        Me.TextOrigen.MaxLength = 3
        Me.TextOrigen.Name = "TextOrigen"
        Me.TextOrigen.Size = New System.Drawing.Size(56, 20)
        Me.TextOrigen.TabIndex = 7
        '
        'TextNombOrigen
        '
        Me.TextNombOrigen.BackColor = System.Drawing.Color.White
        Me.TextNombOrigen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombOrigen.Location = New System.Drawing.Point(72, 21)
        Me.TextNombOrigen.MaxLength = 30
        Me.TextNombOrigen.Name = "TextNombOrigen"
        Me.TextNombOrigen.Size = New System.Drawing.Size(307, 20)
        Me.TextNombOrigen.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.gpCentro)
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Controls.Add(Me.gpTipo)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 96)
        Me.Panel1.TabIndex = 59
        '
        'frmListadoContratosCentro
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.crv)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmListadoContratosCentro"
        Me.Text = "Listado de Contratos por Centro de Costo"
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpTipo.ResumeLayout(False)
        Me.gpCentro.ResumeLayout(False)
        Me.gpCentro.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub frmSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        TextNombEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=@empresa", ListaParametros(lpara))
        cmbTipo.SelectedIndex = 0
    End Sub


#Region "ORIGEN"
    Private Sub BorraOrigen(ByVal valorBool As Boolean)
        TextNombOrigen.Clear()
        If valorBool = True Then
            TextOrigen.Clear()
        End If
    End Sub

    Private Sub TextCentro_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextOrigen.KeyDown, TextNombOrigen.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnOrigen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOrigen.Click
        Dim numFilas As Int32
        lpara.Clear()
        lpara("nombre") = TextNombOrigen.Text.Trim
        If TextNombOrigen.Text.Trim <> "" Then
            cadena = "select origen, nombre from origenes where nombre like '%' + @nombre + '%' and operable='S' order by origen"
        Else
            cadena = "select origen,nombre from origenes where operable='S' order by origen"
        End If
        numFilas = llenaTabla(cadena, tbOrigen, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN CENTROS DE COSTO CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraOrigen(True)
            TextOrigen.Focus()
        ElseIf numFilas = 1 Then
            filaTemp = tbOrigen.Rows.Item(0)
            TextOrigen.Text() = filaTemp.Item(0)
            TextNombOrigen.Text = filaTemp.Item(1)
            btnEjecutar.Focus()
        Else
            'borra_Mejorado(gpCentro)
            EnBuscaOrigen()
        End If
    End Sub

    Private Sub ValidaOrigen()
        lpara.Clear()
        lpara("origen") = TextOrigen.Text.Trim
        If BuscaEscalar("select count (*) from origenes where origen=@origen", ListaParametros(lpara)) = 0 Then
            MsgBox("CENTRO DE COSTO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraOrigen(True)
            Exit Sub
        End If
        cadena = "select origen,nombre from origenes where origen=@origen and operable='S'"
        abrir_conexion(cn)
        comando = New SqlCommand(cadena, cn)
        comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
        dr = comando.ExecuteReader
        If dr.HasRows() Then
            BorraOrigen(False)
            dr.Read()
            TextNombOrigen.Text = dr.GetValue(1)
            dr.Close()
            cn.Close()
            btnEjecutar.Focus()
        Else
            MsgBox("CENTRO DE COSTO NO ES OPERABLE A ESTE NIVEL, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
            dr.Close()
            cn.Close()
            BorraOrigen(True)
            TextOrigen.Focus()
        End If

    End Sub

    Private Sub TextOrigen_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextOrigen.Validated
        If TextOrigen.Text.Trim <> "" Then
            ValidaOrigen()
        Else
            BorraOrigen(False)
        End If
    End Sub



    Private Sub EnBuscaOrigen()
        f2C = New frmMuestra2Columnas
        f2C.TopMost = True
        f2C.inicializa(tbOrigen, "CENTRO", "NOMBRE", 0)
        AddHandler f2C.actValor, AddressOf ActualizacionDatosOrigen
        f2C.ShowDialog()
        btnEjecutar.Focus()
    End Sub

    Private Sub ActualizacionDatosOrigen(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraOrigen(True)
        filaTemp = tbOrigen.Rows.Item(e.va2)
        TextOrigen.Text() = filaTemp.Item(0)
        TextNombOrigen.Text = filaTemp.Item(1)
        TextNombOrigen.Focus()
    End Sub

#End Region
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        Dim cadenaConsulta As String = ""
        lpara.Clear()
        lpara("empresa") = empresa
        If cmbTipo.SelectedIndex <> 0 Then
            If Not validetError(TextOrigen, ep1) Then
                Exit Sub
            End If
        End If
        Select Case cmbTipo.SelectedIndex
            Case 1
                cadenaConsulta = " and origen='" & TextOrigen.Text & "' "
        End Select
        cadena = "select * from v_ListadoNominaCentro where empresa=@empresa and activo='S' " & cadenaConsulta &
                 " order by nombEmpleado, contrato, origen, transac "
        If llenaTabla(cadena, tt, ListaParametros(lpara)) > 0 Then

            v.SetDataSource(tt)
            crv.ReportSource = v
            crv.Refresh()
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



    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Sub Foco(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.Enter, TextOrigen.Enter
        'cambia el color cuando un objeto obtiene el foco
        activa(sender)
    End Sub


    Private Sub Deja(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbTipo.Leave, TextOrigen.Leave
        desactiva(sender)
    End Sub

    Private Sub cmbTipo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbTipo.SelectedIndexChanged
        BorraOrigen(True)
        Select Case cmbTipo.SelectedIndex
            Case 0
                gpCentro.Enabled = False
                btnEjecutar.Focus()
            Case 1
                gpCentro.Enabled = True
                TextOrigen.Focus()
        End Select
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        cmbTipo.SelectedIndex = 0
        crv.ReportSource = Nothing
    End Sub

    
End Class
