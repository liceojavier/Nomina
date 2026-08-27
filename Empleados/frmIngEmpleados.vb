Imports System.Data.SqlClient
Imports System.IO
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Windows.Controls.Primitives
Imports NOMINA.controller

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMINGEMPLEADOS.VB MIEMBRO DE NOMINA.SLN                                    **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmIngEmpleados
    Inherits Form

    Dim cadena As String
    Dim comando As SqlCommand
    Dim tbDeptos As New DataTable("Departamentos")
    Dim tbMunics As New DataTable("Municipios")
    Dim tbCivil As New DataTable("EstadoCP")

    Dim filaTemp As DataRow
    Dim tbDeptoCed As New DataTable("deptoCed")
    Dim tbMunicCed As New DataTable("municCed")
    Dim tbFamiliares As New DataTable("familiares")
    Dim tbAcademico As New DataTable("academicos")
    Dim tbNacional As New DataTable("nacional")
    Dim tbTipoIde As New DataTable("tipoIde")
    Dim tbSituaEcono As New DataTable("situaEcono")
    Dim titulo As New DataTable("Titulos")
    Dim opcModiAca, opcModiFa, IndiceFam, IndicePuesto, opcModiPuesto, opcModiCurso As Int16
    Dim usaReg As String
    Dim ImagenBytes() As Byte
    Dim imagenCarga As Image
    Dim guardaImagen As Boolean
    Dim WithEvents fEMp As frmMuestra2Columnas
    Dim tbPuesto As New DataTable("puesto")
    Dim tbCurso As New DataTable("curso")
    Dim tbArea As New DataTable("area")
    '  Dim tbPuesto2 As New DataTable("puesto2")
    ' Dim tbCurso2 As New DataTable("curso2")

    Dim dr As SqlDataReader
    Dim _fAca As DataRow
    Dim _fCursos As DataRow


    Dim lpara As New Dictionary(Of String, Object)
    Dim colegio As Char
    Dim indice As Int32 = 0

    Dim ctrEmple As New EmpleadoController()
    Dim ctrMes As New MesController(_conexion)
    Dim inicioConsulta As String = "select empleado, apellido1, apellido2, casada, nombre1, nombre2,nombre3,direccion, calle,numero, apto," &
                                   "zona,colonia, deptodir,munidir,telefono,celular,correo,nacional, etnia, fechanac, tipoiden, registro," &
                                   "numidentica,deptoced,municed,docdocente, civil,sexo, numseguro, nit, economica,fechai,usuario,correoi, id_nivel_educativo,
                                   id_pueblo_pertenencia, id_comunidad_ling, titulo_principal, id_tipo_discapacidad,id_area from emplegen em " &
                                   "where empresa=" & empresa
    Friend WithEvents dpFecha As DateTimePicker
    Friend WithEvents dtpFechaNacimiento As DateTimePicker
    Friend WithEvents cmbArea As ComboBox
    Friend WithEvents Label53 As Label
    Friend WithEvents TabCamposEsp As TabPage
    Dim tbConsulta As New DataTable
    Friend WithEvents flPanel1 As FlowLayoutPanel
    Dim tbCamposEsp As New DataTable
    Private ListaCampos As New List(Of CampoEmpleado)

#Region " Código generado por el Diseñador de Windows Forms "

    Public Sub New()
        MyBase.New()

        'El Diseñador de Windows Forms requiere esta llamada.
        InitializeComponent()
        'Agregar cualquier inicialización después de la llamada a InitializeComponent()
    End Sub

    ' Form reemplaza a Dispose para limpiar la lista de componentes.

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

    Friend WithEvents ctxMenuFam As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxModificarF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxEliminarF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxMenuAcad As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxModificarAca As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxEliminarAca As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents textObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents TextDocDocente As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents TextCalle As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents textConlNombre3 As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents textConlNombre2 As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents textConlNombre1 As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents textConlApellido2 As System.Windows.Forms.TextBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents textConlApellido1 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents textCorreo As System.Windows.Forms.TextBox
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents TextCelular As System.Windows.Forms.TextBox
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents TextColonia As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents textApto As System.Windows.Forms.TextBox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents textNumeroCalle As System.Windows.Forms.TextBox
    Friend WithEvents cmbSexo As System.Windows.Forms.ComboBox
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents cmbNacional As System.Windows.Forms.ComboBox
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents TextNumIde As System.Windows.Forms.TextBox
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents TextRegistro As System.Windows.Forms.TextBox
    Friend WithEvents cmbIdentifica As System.Windows.Forms.ComboBox
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents cmbPueblo As System.Windows.Forms.ComboBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents cmbDeptoce As System.Windows.Forms.ComboBox
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents cmbMunice As System.Windows.Forms.ComboBox
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents cmbEstadoCivil As System.Windows.Forms.ComboBox
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents cmbSituaEcono As System.Windows.Forms.ComboBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents cmbTipo As System.Windows.Forms.ComboBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents TextNombFam As System.Windows.Forms.TextBox
    Friend WithEvents gpDatosFam As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dgDatosFam As System.Windows.Forms.DataGridView
    Friend WithEvents dgDatosAca As System.Windows.Forms.DataGridView
    Friend WithEvents gpDatosAca As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregarAc As System.Windows.Forms.Button
    Friend WithEvents btnCancelarAca As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents MaskedTextBox2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ComboBox9 As System.Windows.Forms.ComboBox
    Friend WithEvents gpEmpleado As System.Windows.Forms.GroupBox
    Friend WithEvents TextEmpleado As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextConlCasada As System.Windows.Forms.TextBox
    Friend WithEvents axFechaNac As axFecha.axDateDB
    Friend WithEvents TextTituloPrin As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label39 As Label
    Friend WithEvents cmbTipoDiscp As ComboBox
    Friend WithEvents cmbComLing As ComboBox
    Friend WithEvents Label19 As Label
    Friend WithEvents picBoCuadro As System.Windows.Forms.PictureBox
    Friend WithEvents btnImagen As System.Windows.Forms.Button
    Friend WithEvents AbrirImagen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents TabCursos As System.Windows.Forms.TabPage
    Friend WithEvents ctxMenuCursos As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuModificarCurso As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEliminarCurso As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents dgDatosCursos As System.Windows.Forms.DataGridView
    Friend WithEvents gpCurso As System.Windows.Forms.GroupBox
    Friend WithEvents lbmes As System.Windows.Forms.Label
    Friend WithEvents cmbMes As System.Windows.Forms.ComboBox
    Friend WithEvents textConanioCurso As System.Windows.Forms.TextBox
    Friend WithEvents TextNombCurso As System.Windows.Forms.TextBox
    Friend WithEvents btnCancelarCurso As System.Windows.Forms.Button
    Friend WithEvents btnAgregarCurso As System.Windows.Forms.Button
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents textconObservaCurso As System.Windows.Forms.TextBox
    Friend WithEvents textUsuarios As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents textCorreoColegio As System.Windows.Forms.TextBox
    Friend WithEvents Label41 As Label
    Friend WithEvents TextNomInstitucion As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents cmbNivelEducativo As ComboBox
    Friend WithEvents Label52 As Label
    Friend WithEvents textTitulo As TextBox

    Friend WithEvents btnAtras As Button
    Friend WithEvents btnSiguiente As Button
    Friend WithEvents btnBuscar As Button
    Friend WithEvents TabPuestos As TabPage
    Friend WithEvents dgvPuestos As DataGridView
    Friend WithEvents pnConsulta As Panel
    Friend WithEvents TextFechaOp As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents TabCPrincipal As TabControl
    Friend WithEvents TabPri As TabPage
    Friend WithEvents TabDetalle As TabPage
    Friend WithEvents ctxPrincipal As ContextMenuStrip
    Friend WithEvents ctxModPri As ToolStripMenuItem
    Friend WithEvents dgvConsulta As DataGridView

    Friend WithEvents TabCDatos As System.Windows.Forms.TabControl
    Friend WithEvents TabDatos As System.Windows.Forms.TabPage
    Friend WithEvents TabFam As System.Windows.Forms.TabPage
    Friend WithEvents TabAcade As System.Windows.Forms.TabPage
    Friend WithEvents cmbNivel As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents textDireccion As System.Windows.Forms.TextBox
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents cmbZona As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMunicipio As System.Windows.Forms.ComboBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cmbDepartamento As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents textNit As System.Windows.Forms.TextBox
    Friend WithEvents textTelefono As System.Windows.Forms.TextBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents textNumSocial As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIngEmpleados))
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle43 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabCDatos = New System.Windows.Forms.TabControl()
        Me.TabDatos = New System.Windows.Forms.TabPage()
        Me.ctxPrincipal = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModPri = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.cmbTipoDiscp = New System.Windows.Forms.ComboBox()
        Me.textUsuarios = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbComLing = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.TextTituloPrin = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.axFechaNac = New axFecha.axDateDB()
        Me.pnConsulta = New System.Windows.Forms.Panel()
        Me.TextFechaOp = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbNivelEducativo = New System.Windows.Forms.ComboBox()
        Me.Label52 = New System.Windows.Forms.Label()
        Me.textCorreoColegio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnImagen = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.picBoCuadro = New System.Windows.Forms.PictureBox()
        Me.TextDocDocente = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextConlCasada = New System.Windows.Forms.TextBox()
        Me.cmbSituaEcono = New System.Windows.Forms.ComboBox()
        Me.Label51 = New System.Windows.Forms.Label()
        Me.cmbDeptoce = New System.Windows.Forms.ComboBox()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.cmbMunice = New System.Windows.Forms.ComboBox()
        Me.Label50 = New System.Windows.Forms.Label()
        Me.cmbEstadoCivil = New System.Windows.Forms.ComboBox()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.Label48 = New System.Windows.Forms.Label()
        Me.TextNumIde = New System.Windows.Forms.TextBox()
        Me.Label47 = New System.Windows.Forms.Label()
        Me.TextRegistro = New System.Windows.Forms.TextBox()
        Me.cmbIdentifica = New System.Windows.Forms.ComboBox()
        Me.Label46 = New System.Windows.Forms.Label()
        Me.cmbPueblo = New System.Windows.Forms.ComboBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cmbSexo = New System.Windows.Forms.ComboBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.Label43 = New System.Windows.Forms.Label()
        Me.cmbNacional = New System.Windows.Forms.ComboBox()
        Me.Label42 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.textCorreo = New System.Windows.Forms.TextBox()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.TextCelular = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.TextColonia = New System.Windows.Forms.TextBox()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.textApto = New System.Windows.Forms.TextBox()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.textNumeroCalle = New System.Windows.Forms.TextBox()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.TextCalle = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.textConlNombre3 = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.textConlNombre2 = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.textConlNombre1 = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.textConlApellido2 = New System.Windows.Forms.TextBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.textConlApellido1 = New System.Windows.Forms.TextBox()
        Me.textNumSocial = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.textNit = New System.Windows.Forms.TextBox()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.textTelefono = New System.Windows.Forms.TextBox()
        Me.cmbDepartamento = New System.Windows.Forms.ComboBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.cmbMunicipio = New System.Windows.Forms.ComboBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.cmbZona = New System.Windows.Forms.ComboBox()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.textDireccion = New System.Windows.Forms.TextBox()
        Me.TabAcade = New System.Windows.Forms.TabPage()
        Me.dgDatosFam = New System.Windows.Forms.DataGridView()
        Me.ctxMenuFam = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModificarF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEliminarF = New System.Windows.Forms.ToolStripMenuItem()
        Me.gpDatosFam = New System.Windows.Forms.GroupBox()
        Me.dtpFechaNacimiento = New System.Windows.Forms.DateTimePicker()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextNombFam = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TabFam = New System.Windows.Forms.TabPage()
        Me.dgDatosAca = New System.Windows.Forms.DataGridView()
        Me.ctxMenuAcad = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModificarAca = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEliminarAca = New System.Windows.Forms.ToolStripMenuItem()
        Me.gpDatosAca = New System.Windows.Forms.GroupBox()
        Me.dpFecha = New System.Windows.Forms.DateTimePicker()
        Me.textTitulo = New System.Windows.Forms.TextBox()
        Me.textObservaciones = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnAgregarAc = New System.Windows.Forms.Button()
        Me.btnCancelarAca = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbNivel = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TabCursos = New System.Windows.Forms.TabPage()
        Me.dgDatosCursos = New System.Windows.Forms.DataGridView()
        Me.ctxMenuCursos = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuModificarCurso = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminarCurso = New System.Windows.Forms.ToolStripMenuItem()
        Me.gpCurso = New System.Windows.Forms.GroupBox()
        Me.Label41 = New System.Windows.Forms.Label()
        Me.TextNomInstitucion = New System.Windows.Forms.TextBox()
        Me.Label40 = New System.Windows.Forms.Label()
        Me.lbmes = New System.Windows.Forms.Label()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.textConanioCurso = New System.Windows.Forms.TextBox()
        Me.TextNombCurso = New System.Windows.Forms.TextBox()
        Me.btnCancelarCurso = New System.Windows.Forms.Button()
        Me.btnAgregarCurso = New System.Windows.Forms.Button()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label38 = New System.Windows.Forms.Label()
        Me.textconObservaCurso = New System.Windows.Forms.TextBox()
        Me.TabPuestos = New System.Windows.Forms.TabPage()
        Me.dgvPuestos = New System.Windows.Forms.DataGridView()
        Me.TabCamposEsp = New System.Windows.Forms.TabPage()
        Me.flPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnAtras = New System.Windows.Forms.Button()
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.MaskedTextBox2 = New System.Windows.Forms.MaskedTextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ComboBox9 = New System.Windows.Forms.ComboBox()
        Me.gpEmpleado = New System.Windows.Forms.GroupBox()
        Me.TextEmpleado = New System.Windows.Forms.TextBox()
        Me.AbrirImagen = New System.Windows.Forms.OpenFileDialog()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TabCPrincipal = New System.Windows.Forms.TabControl()
        Me.TabPri = New System.Windows.Forms.TabPage()
        Me.TabDetalle = New System.Windows.Forms.TabPage()
        Me.dgvConsulta = New System.Windows.Forms.DataGridView()
        Me.TabCDatos.SuspendLayout()
        Me.TabDatos.SuspendLayout()
        Me.ctxPrincipal.SuspendLayout()
        Me.pnConsulta.SuspendLayout()
        CType(Me.picBoCuadro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabAcade.SuspendLayout()
        CType(Me.dgDatosFam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenuFam.SuspendLayout()
        Me.gpDatosFam.SuspendLayout()
        Me.TabFam.SuspendLayout()
        CType(Me.dgDatosAca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenuAcad.SuspendLayout()
        Me.gpDatosAca.SuspendLayout()
        Me.TabCursos.SuspendLayout()
        CType(Me.dgDatosCursos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenuCursos.SuspendLayout()
        Me.gpCurso.SuspendLayout()
        Me.TabPuestos.SuspendLayout()
        CType(Me.dgvPuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabCamposEsp.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpEmpleado.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabCPrincipal.SuspendLayout()
        Me.TabPri.SuspendLayout()
        Me.TabDetalle.SuspendLayout()
        CType(Me.dgvConsulta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabCDatos
        '
        Me.TabCDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabCDatos.Controls.Add(Me.TabDatos)
        Me.TabCDatos.Controls.Add(Me.TabAcade)
        Me.TabCDatos.Controls.Add(Me.TabFam)
        Me.TabCDatos.Controls.Add(Me.TabCursos)
        Me.TabCDatos.Controls.Add(Me.TabPuestos)
        Me.TabCDatos.Controls.Add(Me.TabCamposEsp)
        Me.TabCDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabCDatos.Location = New System.Drawing.Point(6, 8)
        Me.TabCDatos.Name = "TabCDatos"
        Me.TabCDatos.SelectedIndex = 0
        Me.TabCDatos.Size = New System.Drawing.Size(1109, 503)
        Me.TabCDatos.TabIndex = 3
        '
        'TabDatos
        '
        Me.TabDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TabDatos.ContextMenuStrip = Me.ctxPrincipal
        Me.TabDatos.Controls.Add(Me.cmbArea)
        Me.TabDatos.Controls.Add(Me.Label53)
        Me.TabDatos.Controls.Add(Me.Label39)
        Me.TabDatos.Controls.Add(Me.cmbTipoDiscp)
        Me.TabDatos.Controls.Add(Me.textUsuarios)
        Me.TabDatos.Controls.Add(Me.Label10)
        Me.TabDatos.Controls.Add(Me.cmbComLing)
        Me.TabDatos.Controls.Add(Me.Label19)
        Me.TabDatos.Controls.Add(Me.TextTituloPrin)
        Me.TabDatos.Controls.Add(Me.Label12)
        Me.TabDatos.Controls.Add(Me.axFechaNac)
        Me.TabDatos.Controls.Add(Me.pnConsulta)
        Me.TabDatos.Controls.Add(Me.cmbNivelEducativo)
        Me.TabDatos.Controls.Add(Me.Label52)
        Me.TabDatos.Controls.Add(Me.textCorreoColegio)
        Me.TabDatos.Controls.Add(Me.Label1)
        Me.TabDatos.Controls.Add(Me.btnImagen)
        Me.TabDatos.Controls.Add(Me.picBoCuadro)
        Me.TabDatos.Controls.Add(Me.TextDocDocente)
        Me.TabDatos.Controls.Add(Me.Label9)
        Me.TabDatos.Controls.Add(Me.Label6)
        Me.TabDatos.Controls.Add(Me.TextConlCasada)
        Me.TabDatos.Controls.Add(Me.cmbSituaEcono)
        Me.TabDatos.Controls.Add(Me.Label51)
        Me.TabDatos.Controls.Add(Me.cmbDeptoce)
        Me.TabDatos.Controls.Add(Me.Label49)
        Me.TabDatos.Controls.Add(Me.cmbMunice)
        Me.TabDatos.Controls.Add(Me.Label50)
        Me.TabDatos.Controls.Add(Me.cmbEstadoCivil)
        Me.TabDatos.Controls.Add(Me.Label36)
        Me.TabDatos.Controls.Add(Me.Label48)
        Me.TabDatos.Controls.Add(Me.TextNumIde)
        Me.TabDatos.Controls.Add(Me.Label47)
        Me.TabDatos.Controls.Add(Me.TextRegistro)
        Me.TabDatos.Controls.Add(Me.cmbIdentifica)
        Me.TabDatos.Controls.Add(Me.Label46)
        Me.TabDatos.Controls.Add(Me.cmbPueblo)
        Me.TabDatos.Controls.Add(Me.Label45)
        Me.TabDatos.Controls.Add(Me.cmbSexo)
        Me.TabDatos.Controls.Add(Me.Label44)
        Me.TabDatos.Controls.Add(Me.Label43)
        Me.TabDatos.Controls.Add(Me.cmbNacional)
        Me.TabDatos.Controls.Add(Me.Label42)
        Me.TabDatos.Controls.Add(Me.Label18)
        Me.TabDatos.Controls.Add(Me.textCorreo)
        Me.TabDatos.Controls.Add(Me.Label35)
        Me.TabDatos.Controls.Add(Me.TextCelular)
        Me.TabDatos.Controls.Add(Me.Label34)
        Me.TabDatos.Controls.Add(Me.TextColonia)
        Me.TabDatos.Controls.Add(Me.Label33)
        Me.TabDatos.Controls.Add(Me.textApto)
        Me.TabDatos.Controls.Add(Me.Label27)
        Me.TabDatos.Controls.Add(Me.textNumeroCalle)
        Me.TabDatos.Controls.Add(Me.Label24)
        Me.TabDatos.Controls.Add(Me.TextCalle)
        Me.TabDatos.Controls.Add(Me.Label21)
        Me.TabDatos.Controls.Add(Me.textConlNombre3)
        Me.TabDatos.Controls.Add(Me.Label22)
        Me.TabDatos.Controls.Add(Me.textConlNombre2)
        Me.TabDatos.Controls.Add(Me.Label23)
        Me.TabDatos.Controls.Add(Me.textConlNombre1)
        Me.TabDatos.Controls.Add(Me.Label25)
        Me.TabDatos.Controls.Add(Me.textConlApellido2)
        Me.TabDatos.Controls.Add(Me.Label26)
        Me.TabDatos.Controls.Add(Me.textConlApellido1)
        Me.TabDatos.Controls.Add(Me.textNumSocial)
        Me.TabDatos.Controls.Add(Me.Label2)
        Me.TabDatos.Controls.Add(Me.textNit)
        Me.TabDatos.Controls.Add(Me.Label37)
        Me.TabDatos.Controls.Add(Me.Label32)
        Me.TabDatos.Controls.Add(Me.textTelefono)
        Me.TabDatos.Controls.Add(Me.cmbDepartamento)
        Me.TabDatos.Controls.Add(Me.Label31)
        Me.TabDatos.Controls.Add(Me.cmbMunicipio)
        Me.TabDatos.Controls.Add(Me.Label30)
        Me.TabDatos.Controls.Add(Me.cmbZona)
        Me.TabDatos.Controls.Add(Me.Label29)
        Me.TabDatos.Controls.Add(Me.Label28)
        Me.TabDatos.Controls.Add(Me.textDireccion)
        Me.TabDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabDatos.Location = New System.Drawing.Point(4, 22)
        Me.TabDatos.Name = "TabDatos"
        Me.TabDatos.Size = New System.Drawing.Size(1101, 477)
        Me.TabDatos.TabIndex = 3
        Me.TabDatos.Text = "Datos generales"
        Me.TabDatos.Visible = False
        '
        'ctxPrincipal
        '
        Me.ctxPrincipal.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModPri})
        Me.ctxPrincipal.Name = "ctxMenu"
        Me.ctxPrincipal.Size = New System.Drawing.Size(126, 26)
        '
        'ctxModPri
        '
        Me.ctxModPri.Image = Global.NOMINA.My.Resources.Resources.edit1
        Me.ctxModPri.Name = "ctxModPri"
        Me.ctxModPri.Size = New System.Drawing.Size(125, 22)
        Me.ctxModPri.Text = "Modificar"
        '
        'cmbArea
        '
        Me.cmbArea.BackColor = System.Drawing.Color.White
        Me.cmbArea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbArea.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbArea.Items.AddRange(New Object() {"MASCULINO", "FEMENINO"})
        Me.cmbArea.Location = New System.Drawing.Point(137, 393)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(226, 21)
        Me.cmbArea.TabIndex = 36
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(102, 400)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(32, 13)
        Me.Label53.TabIndex = 139
        Me.Label53.Text = "Área:"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(382, 363)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(97, 13)
        Me.Label39.TabIndex = 138
        Me.Label39.Text = "Tipo discapacidad:"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipoDiscp
        '
        Me.cmbTipoDiscp.BackColor = System.Drawing.Color.White
        Me.cmbTipoDiscp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipoDiscp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipoDiscp.Location = New System.Drawing.Point(485, 360)
        Me.cmbTipoDiscp.Name = "cmbTipoDiscp"
        Me.cmbTipoDiscp.Size = New System.Drawing.Size(228, 21)
        Me.cmbTipoDiscp.TabIndex = 34
        '
        'textUsuarios
        '
        Me.textUsuarios.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textUsuarios.BackColor = System.Drawing.Color.White
        Me.textUsuarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textUsuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textUsuarios.Location = New System.Drawing.Point(837, 360)
        Me.textUsuarios.MaxLength = 30
        Me.textUsuarios.Name = "textUsuarios"
        Me.textUsuarios.Size = New System.Drawing.Size(231, 20)
        Me.textUsuarios.TabIndex = 35
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(785, 360)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 124
        Me.Label10.Text = "Usuario:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbComLing
        '
        Me.cmbComLing.BackColor = System.Drawing.Color.White
        Me.cmbComLing.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbComLing.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbComLing.Location = New System.Drawing.Point(136, 363)
        Me.cmbComLing.Name = "cmbComLing"
        Me.cmbComLing.Size = New System.Drawing.Size(228, 21)
        Me.cmbComLing.TabIndex = 33
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.Transparent
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(18, 363)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(116, 13)
        Me.Label19.TabIndex = 136
        Me.Label19.Text = "Comunidad Linguistica:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextTituloPrin
        '
        Me.TextTituloPrin.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextTituloPrin.BackColor = System.Drawing.Color.White
        Me.TextTituloPrin.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextTituloPrin.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextTituloPrin.Location = New System.Drawing.Point(485, 327)
        Me.TextTituloPrin.MaxLength = 150
        Me.TextTituloPrin.Name = "TextTituloPrin"
        Me.TextTituloPrin.Size = New System.Drawing.Size(370, 20)
        Me.TextTituloPrin.TabIndex = 32
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.Transparent
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(382, 326)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 13)
        Me.Label12.TabIndex = 133
        Me.Label12.Text = "Titulo principal:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'axFechaNac
        '
        Me.axFechaNac.DateMaxvalue1 = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.axFechaNac.DateMaxvalue2 = New Date(9998, 12, 31, 0, 0, 0, 0)
        Me.axFechaNac.DateMinvalue1 = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.axFechaNac.DateMinvalue2 = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.axFechaNac.Datevalue1 = New Date(2023, 9, 19, 0, 0, 0, 0)
        Me.axFechaNac.Datevalue2 = New Date(2023, 9, 19, 0, 0, 0, 0)
        Me.axFechaNac.EsModoConsulta = False
        Me.axFechaNac.Formato = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.axFechaNac.FuenteCalendario = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.axFechaNac.Location = New System.Drawing.Point(133, 204)
        Me.axFechaNac.Name = "axFechaNac"
        Me.axFechaNac.nombreCampo = "fechanac"
        Me.axFechaNac.prefijo = "em"
        Me.axFechaNac.Size = New System.Drawing.Size(313, 27)
        Me.axFechaNac.TabIndex = 19
        '
        'pnConsulta
        '
        Me.pnConsulta.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.pnConsulta.Controls.Add(Me.TextFechaOp)
        Me.pnConsulta.Controls.Add(Me.Label11)
        Me.pnConsulta.Location = New System.Drawing.Point(12, 422)
        Me.pnConsulta.Name = "pnConsulta"
        Me.pnConsulta.Size = New System.Drawing.Size(824, 52)
        Me.pnConsulta.TabIndex = 36
        '
        'TextFechaOp
        '
        Me.TextFechaOp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextFechaOp.BackColor = System.Drawing.Color.White
        Me.TextFechaOp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextFechaOp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaOp.Location = New System.Drawing.Point(123, 17)
        Me.TextFechaOp.MaxLength = 15
        Me.TextFechaOp.Name = "TextFechaOp"
        Me.TextFechaOp.ReadOnly = True
        Me.TextFechaOp.Size = New System.Drawing.Size(94, 20)
        Me.TextFechaOp.TabIndex = 131
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.Transparent
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(11, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(105, 13)
        Me.Label11.TabIndex = 130
        Me.Label11.Text = "Fecha de operación:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbNivelEducativo
        '
        Me.cmbNivelEducativo.BackColor = System.Drawing.Color.White
        Me.cmbNivelEducativo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivelEducativo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNivelEducativo.Location = New System.Drawing.Point(137, 326)
        Me.cmbNivelEducativo.Name = "cmbNivelEducativo"
        Me.cmbNivelEducativo.Size = New System.Drawing.Size(228, 21)
        Me.cmbNivelEducativo.TabIndex = 31
        '
        'Label52
        '
        Me.Label52.AutoSize = True
        Me.Label52.BackColor = System.Drawing.Color.Transparent
        Me.Label52.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label52.Location = New System.Drawing.Point(18, 326)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(97, 13)
        Me.Label52.TabIndex = 129
        Me.Label52.Text = "U. nivel Educativo:"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textCorreoColegio
        '
        Me.textCorreoColegio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textCorreoColegio.BackColor = System.Drawing.Color.White
        Me.textCorreoColegio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textCorreoColegio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textCorreoColegio.Location = New System.Drawing.Point(840, 294)
        Me.textCorreoColegio.MaxLength = 50
        Me.textCorreoColegio.Name = "textCorreoColegio"
        Me.textCorreoColegio.Size = New System.Drawing.Size(228, 20)
        Me.textCorreoColegio.TabIndex = 30
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(676, 294)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(157, 13)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Correo electrónico  institucional:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnImagen
        '
        Me.btnImagen.BackColor = System.Drawing.Color.White
        Me.btnImagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImagen.ImageKey = "open.png"
        Me.btnImagen.ImageList = Me.ImageNuevos
        Me.btnImagen.Location = New System.Drawing.Point(909, 97)
        Me.btnImagen.Name = "btnImagen"
        Me.btnImagen.Size = New System.Drawing.Size(60, 30)
        Me.btnImagen.TabIndex = 123
        Me.btnImagen.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnImagen, "Cargar")
        Me.btnImagen.UseVisualStyleBackColor = False
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
        'picBoCuadro
        '
        Me.picBoCuadro.BackColor = System.Drawing.Color.Gainsboro
        Me.picBoCuadro.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picBoCuadro.Location = New System.Drawing.Point(974, 3)
        Me.picBoCuadro.Name = "picBoCuadro"
        Me.picBoCuadro.Size = New System.Drawing.Size(122, 124)
        Me.picBoCuadro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBoCuadro.TabIndex = 122
        Me.picBoCuadro.TabStop = False
        '
        'TextDocDocente
        '
        Me.TextDocDocente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextDocDocente.BackColor = System.Drawing.Color.White
        Me.TextDocDocente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDocDocente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDocDocente.Location = New System.Drawing.Point(137, 294)
        Me.TextDocDocente.MaxLength = 15
        Me.TextDocDocente.Name = "TextDocDocente"
        Me.TextDocDocente.Size = New System.Drawing.Size(136, 20)
        Me.TextDocDocente.TabIndex = 28
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(16, 294)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 13)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "Cedúla docente:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(568, 7)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 13)
        Me.Label6.TabIndex = 90
        Me.Label6.Text = "Apellido de casada:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextConlCasada
        '
        Me.TextConlCasada.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextConlCasada.BackColor = System.Drawing.Color.White
        Me.TextConlCasada.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextConlCasada.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextConlCasada.Location = New System.Drawing.Point(677, 7)
        Me.TextConlCasada.MaxLength = 20
        Me.TextConlCasada.Name = "TextConlCasada"
        Me.TextConlCasada.Size = New System.Drawing.Size(168, 20)
        Me.TextConlCasada.TabIndex = 3
        '
        'cmbSituaEcono
        '
        Me.cmbSituaEcono.BackColor = System.Drawing.Color.White
        Me.cmbSituaEcono.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSituaEcono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSituaEcono.Location = New System.Drawing.Point(440, 293)
        Me.cmbSituaEcono.Name = "cmbSituaEcono"
        Me.cmbSituaEcono.Size = New System.Drawing.Size(228, 21)
        Me.cmbSituaEcono.TabIndex = 29
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(299, 293)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(137, 13)
        Me.Label51.TabIndex = 88
        Me.Label51.Text = "Situación socio económica:"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDeptoce
        '
        Me.cmbDeptoce.BackColor = System.Drawing.Color.White
        Me.cmbDeptoce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDeptoce.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDeptoce.Location = New System.Drawing.Point(543, 265)
        Me.cmbDeptoce.Name = "cmbDeptoce"
        Me.cmbDeptoce.Size = New System.Drawing.Size(170, 21)
        Me.cmbDeptoce.TabIndex = 26
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(458, 265)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(77, 13)
        Me.Label49.TabIndex = 86
        Me.Label49.Text = "Departamento:"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMunice
        '
        Me.cmbMunice.BackColor = System.Drawing.Color.White
        Me.cmbMunice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMunice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMunice.Location = New System.Drawing.Point(840, 265)
        Me.cmbMunice.Name = "cmbMunice"
        Me.cmbMunice.Size = New System.Drawing.Size(228, 21)
        Me.cmbMunice.TabIndex = 27
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(759, 265)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(55, 13)
        Me.Label50.TabIndex = 85
        Me.Label50.Text = "Municipio:"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEstadoCivil
        '
        Me.cmbEstadoCivil.BackColor = System.Drawing.Color.White
        Me.cmbEstadoCivil.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEstadoCivil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEstadoCivil.Location = New System.Drawing.Point(840, 236)
        Me.cmbEstadoCivil.Name = "cmbEstadoCivil"
        Me.cmbEstadoCivil.Size = New System.Drawing.Size(228, 21)
        Me.cmbEstadoCivil.TabIndex = 26
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(759, 236)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(64, 13)
        Me.Label36.TabIndex = 82
        Me.Label36.Text = "Estado civil:"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label48
        '
        Me.Label48.AutoSize = True
        Me.Label48.BackColor = System.Drawing.Color.Transparent
        Me.Label48.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label48.Location = New System.Drawing.Point(458, 236)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(47, 13)
        Me.Label48.TabIndex = 80
        Me.Label48.Text = "Número:"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextNumIde
        '
        Me.TextNumIde.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextNumIde.BackColor = System.Drawing.Color.White
        Me.TextNumIde.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNumIde.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNumIde.Location = New System.Drawing.Point(543, 236)
        Me.TextNumIde.MaxLength = 14
        Me.TextNumIde.Name = "TextNumIde"
        Me.TextNumIde.Size = New System.Drawing.Size(109, 20)
        Me.TextNumIde.TabIndex = 25
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(284, 236)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(49, 13)
        Me.Label47.TabIndex = 78
        Me.Label47.Text = "Registro:"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextRegistro
        '
        Me.TextRegistro.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextRegistro.BackColor = System.Drawing.Color.White
        Me.TextRegistro.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextRegistro.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextRegistro.Location = New System.Drawing.Point(361, 236)
        Me.TextRegistro.MaxLength = 4
        Me.TextRegistro.Name = "TextRegistro"
        Me.TextRegistro.Size = New System.Drawing.Size(64, 20)
        Me.TextRegistro.TabIndex = 24
        '
        'cmbIdentifica
        '
        Me.cmbIdentifica.BackColor = System.Drawing.Color.White
        Me.cmbIdentifica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdentifica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdentifica.Location = New System.Drawing.Point(134, 236)
        Me.cmbIdentifica.Name = "cmbIdentifica"
        Me.cmbIdentifica.Size = New System.Drawing.Size(139, 21)
        Me.cmbIdentifica.TabIndex = 23
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(16, 236)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(111, 13)
        Me.Label46.TabIndex = 76
        Me.Label46.Text = "Tipo de identificación:"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbPueblo
        '
        Me.cmbPueblo.BackColor = System.Drawing.Color.White
        Me.cmbPueblo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPueblo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPueblo.Location = New System.Drawing.Point(840, 205)
        Me.cmbPueblo.Name = "cmbPueblo"
        Me.cmbPueblo.Size = New System.Drawing.Size(228, 21)
        Me.cmbPueblo.TabIndex = 21
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(759, 205)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(34, 13)
        Me.Label45.TabIndex = 74
        Me.Label45.Text = "Etnia:"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbSexo
        '
        Me.cmbSexo.BackColor = System.Drawing.Color.White
        Me.cmbSexo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSexo.Items.AddRange(New Object() {"MASCULINO", "FEMENINO"})
        Me.cmbSexo.Location = New System.Drawing.Point(545, 205)
        Me.cmbSexo.Name = "cmbSexo"
        Me.cmbSexo.Size = New System.Drawing.Size(168, 21)
        Me.cmbSexo.TabIndex = 20
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(460, 205)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(45, 13)
        Me.Label44.TabIndex = 72
        Me.Label44.Text = "Género:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(15, 208)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(94, 13)
        Me.Label43.TabIndex = 69
        Me.Label43.Text = "Fecha nacimiento:"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbNacional
        '
        Me.cmbNacional.BackColor = System.Drawing.Color.White
        Me.cmbNacional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNacional.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNacional.Location = New System.Drawing.Point(840, 176)
        Me.cmbNacional.Name = "cmbNacional"
        Me.cmbNacional.Size = New System.Drawing.Size(228, 21)
        Me.cmbNacional.TabIndex = 18
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(759, 176)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(72, 13)
        Me.Label42.TabIndex = 68
        Me.Label42.Text = "Nacionalidad:"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.BackColor = System.Drawing.Color.Transparent
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(350, 176)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(96, 13)
        Me.Label18.TabIndex = 66
        Me.Label18.Text = "Correo electrónico:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textCorreo
        '
        Me.textCorreo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textCorreo.BackColor = System.Drawing.Color.White
        Me.textCorreo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textCorreo.Location = New System.Drawing.Point(451, 176)
        Me.textCorreo.MaxLength = 40
        Me.textCorreo.Name = "textCorreo"
        Me.textCorreo.Size = New System.Drawing.Size(240, 20)
        Me.textCorreo.TabIndex = 17
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(177, 176)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(42, 13)
        Me.Label35.TabIndex = 64
        Me.Label35.Text = "Celular:"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextCelular
        '
        Me.TextCelular.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextCelular.BackColor = System.Drawing.Color.White
        Me.TextCelular.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCelular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCelular.Location = New System.Drawing.Point(225, 176)
        Me.TextCelular.MaxLength = 8
        Me.TextCelular.Name = "TextCelular"
        Me.TextCelular.Size = New System.Drawing.Size(85, 20)
        Me.TextCelular.TabIndex = 16
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(14, 140)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(45, 13)
        Me.Label34.TabIndex = 62
        Me.Label34.Text = "Colonia:"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextColonia
        '
        Me.TextColonia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextColonia.BackColor = System.Drawing.Color.White
        Me.TextColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextColonia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextColonia.Location = New System.Drawing.Point(97, 140)
        Me.TextColonia.MaxLength = 25
        Me.TextColonia.Name = "TextColonia"
        Me.TextColonia.Size = New System.Drawing.Size(213, 20)
        Me.TextColonia.TabIndex = 12
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.BackColor = System.Drawing.Color.Transparent
        Me.Label33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label33.Location = New System.Drawing.Point(536, 106)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(70, 13)
        Me.Label33.TabIndex = 60
        Me.Label33.Text = "Apartamento:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textApto
        '
        Me.textApto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textApto.BackColor = System.Drawing.Color.White
        Me.textApto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textApto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textApto.Location = New System.Drawing.Point(613, 106)
        Me.textApto.MaxLength = 8
        Me.textApto.Name = "textApto"
        Me.textApto.Size = New System.Drawing.Size(78, 20)
        Me.textApto.TabIndex = 10
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(350, 106)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(47, 13)
        Me.Label27.TabIndex = 58
        Me.Label27.Text = "Número:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textNumeroCalle
        '
        Me.textNumeroCalle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textNumeroCalle.BackColor = System.Drawing.Color.White
        Me.textNumeroCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNumeroCalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNumeroCalle.Location = New System.Drawing.Point(450, 106)
        Me.textNumeroCalle.MaxLength = 8
        Me.textNumeroCalle.Name = "textNumeroCalle"
        Me.textNumeroCalle.Size = New System.Drawing.Size(80, 20)
        Me.textNumeroCalle.TabIndex = 9
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(15, 106)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(33, 13)
        Me.Label24.TabIndex = 56
        Me.Label24.Text = "Calle:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextCalle
        '
        Me.TextCalle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextCalle.BackColor = System.Drawing.Color.White
        Me.TextCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextCalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextCalle.Location = New System.Drawing.Point(97, 106)
        Me.TextCalle.MaxLength = 50
        Me.TextCalle.Name = "TextCalle"
        Me.TextCalle.Size = New System.Drawing.Size(213, 20)
        Me.TextCalle.TabIndex = 8
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(568, 46)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(79, 13)
        Me.Label21.TabIndex = 54
        Me.Label21.Text = "Tercer nombre:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textConlNombre3
        '
        Me.textConlNombre3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textConlNombre3.BackColor = System.Drawing.Color.White
        Me.textConlNombre3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textConlNombre3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textConlNombre3.Location = New System.Drawing.Point(678, 46)
        Me.textConlNombre3.MaxLength = 20
        Me.textConlNombre3.Name = "textConlNombre3"
        Me.textConlNombre3.Size = New System.Drawing.Size(168, 20)
        Me.textConlNombre3.TabIndex = 6
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.BackColor = System.Drawing.Color.Transparent
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(272, 46)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(91, 13)
        Me.Label22.TabIndex = 53
        Me.Label22.Text = "Segundo nombre:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textConlNombre2
        '
        Me.textConlNombre2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textConlNombre2.BackColor = System.Drawing.Color.White
        Me.textConlNombre2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textConlNombre2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textConlNombre2.Location = New System.Drawing.Point(385, 46)
        Me.textConlNombre2.MaxLength = 20
        Me.textConlNombre2.Name = "textConlNombre2"
        Me.textConlNombre2.Size = New System.Drawing.Size(168, 20)
        Me.textConlNombre2.TabIndex = 5
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.BackColor = System.Drawing.Color.Transparent
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(14, 46)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(77, 13)
        Me.Label23.TabIndex = 52
        Me.Label23.Text = "Primer nombre:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textConlNombre1
        '
        Me.textConlNombre1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textConlNombre1.BackColor = System.Drawing.Color.White
        Me.textConlNombre1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textConlNombre1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textConlNombre1.Location = New System.Drawing.Point(97, 46)
        Me.textConlNombre1.MaxLength = 20
        Me.textConlNombre1.Name = "textConlNombre1"
        Me.textConlNombre1.Size = New System.Drawing.Size(168, 20)
        Me.textConlNombre1.TabIndex = 4
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.BackColor = System.Drawing.Color.Transparent
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(272, 7)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(92, 13)
        Me.Label25.TabIndex = 47
        Me.Label25.Text = "Segundo apellido:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textConlApellido2
        '
        Me.textConlApellido2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textConlApellido2.BackColor = System.Drawing.Color.White
        Me.textConlApellido2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textConlApellido2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textConlApellido2.Location = New System.Drawing.Point(385, 7)
        Me.textConlApellido2.MaxLength = 20
        Me.textConlApellido2.Name = "textConlApellido2"
        Me.textConlApellido2.Size = New System.Drawing.Size(168, 20)
        Me.textConlApellido2.TabIndex = 2
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.BackColor = System.Drawing.Color.Transparent
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(14, 7)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(78, 13)
        Me.Label26.TabIndex = 43
        Me.Label26.Text = "Primer apellido:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textConlApellido1
        '
        Me.textConlApellido1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textConlApellido1.BackColor = System.Drawing.Color.White
        Me.textConlApellido1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textConlApellido1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textConlApellido1.Location = New System.Drawing.Point(97, 7)
        Me.textConlApellido1.MaxLength = 20
        Me.textConlApellido1.Name = "textConlApellido1"
        Me.textConlApellido1.Size = New System.Drawing.Size(168, 20)
        Me.textConlApellido1.TabIndex = 1
        '
        'textNumSocial
        '
        Me.textNumSocial.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textNumSocial.BackColor = System.Drawing.Color.White
        Me.textNumSocial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNumSocial.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNumSocial.Location = New System.Drawing.Point(137, 265)
        Me.textNumSocial.MaxLength = 14
        Me.textNumSocial.Name = "textNumSocial"
        Me.textNumSocial.Size = New System.Drawing.Size(136, 20)
        Me.textNumSocial.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 265)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 13)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Número seguro social:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textNit
        '
        Me.textNit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textNit.BackColor = System.Drawing.Color.White
        Me.textNit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNit.Location = New System.Drawing.Point(329, 265)
        Me.textNit.MaxLength = 11
        Me.textNit.Name = "textNit"
        Me.textNit.Size = New System.Drawing.Size(96, 20)
        Me.textNit.TabIndex = 29
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(284, 265)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(34, 13)
        Me.Label37.TabIndex = 26
        Me.Label37.Text = "N.I.T:"
        Me.Label37.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.BackColor = System.Drawing.Color.Transparent
        Me.Label32.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label32.Location = New System.Drawing.Point(15, 176)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(52, 13)
        Me.Label32.TabIndex = 21
        Me.Label32.Text = "Teléfono:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textTelefono
        '
        Me.textTelefono.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textTelefono.BackColor = System.Drawing.Color.White
        Me.textTelefono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textTelefono.Location = New System.Drawing.Point(97, 176)
        Me.textTelefono.MaxLength = 8
        Me.textTelefono.Name = "textTelefono"
        Me.textTelefono.Size = New System.Drawing.Size(72, 20)
        Me.textTelefono.TabIndex = 15
        '
        'cmbDepartamento
        '
        Me.cmbDepartamento.BackColor = System.Drawing.Color.White
        Me.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDepartamento.Location = New System.Drawing.Point(451, 140)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(262, 21)
        Me.cmbDepartamento.TabIndex = 13
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(350, 140)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(77, 13)
        Me.Label31.TabIndex = 14
        Me.Label31.Text = "Departamento:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMunicipio
        '
        Me.cmbMunicipio.BackColor = System.Drawing.Color.White
        Me.cmbMunicipio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMunicipio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMunicipio.Location = New System.Drawing.Point(840, 140)
        Me.cmbMunicipio.Name = "cmbMunicipio"
        Me.cmbMunicipio.Size = New System.Drawing.Size(228, 21)
        Me.cmbMunicipio.TabIndex = 14
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(759, 140)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(55, 13)
        Me.Label30.TabIndex = 12
        Me.Label30.Text = "Municipio:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbZona
        '
        Me.cmbZona.BackColor = System.Drawing.Color.White
        Me.cmbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbZona.Location = New System.Drawing.Point(841, 106)
        Me.cmbZona.Name = "cmbZona"
        Me.cmbZona.Size = New System.Drawing.Size(48, 21)
        Me.cmbZona.TabIndex = 11
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(761, 106)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(35, 13)
        Me.Label29.TabIndex = 10
        Me.Label29.Text = "Zona:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.BackColor = System.Drawing.Color.Transparent
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(13, 78)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(101, 13)
        Me.Label28.TabIndex = 9
        Me.Label28.Text = "Dirección completa:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textDireccion
        '
        Me.textDireccion.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textDireccion.BackColor = System.Drawing.Color.White
        Me.textDireccion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textDireccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textDireccion.Location = New System.Drawing.Point(122, 78)
        Me.textDireccion.MaxLength = 75
        Me.textDireccion.Name = "textDireccion"
        Me.textDireccion.Size = New System.Drawing.Size(431, 20)
        Me.textDireccion.TabIndex = 7
        '
        'TabAcade
        '
        Me.TabAcade.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TabAcade.Controls.Add(Me.dgDatosFam)
        Me.TabAcade.Controls.Add(Me.gpDatosFam)
        Me.TabAcade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabAcade.Location = New System.Drawing.Point(4, 22)
        Me.TabAcade.Name = "TabAcade"
        Me.TabAcade.Size = New System.Drawing.Size(1101, 477)
        Me.TabAcade.TabIndex = 5
        Me.TabAcade.Text = "Datos de familiares"
        Me.TabAcade.Visible = False
        '
        'dgDatosFam
        '
        Me.dgDatosFam.AllowUserToAddRows = False
        Me.dgDatosFam.AllowUserToDeleteRows = False
        DataGridViewCellStyle40.BackColor = System.Drawing.Color.LightGreen
        Me.dgDatosFam.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle40
        Me.dgDatosFam.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDatosFam.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgDatosFam.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgDatosFam.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle41.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle41.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle41.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle41.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle41.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatosFam.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle41
        Me.dgDatosFam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDatosFam.ContextMenuStrip = Me.ctxMenuFam
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle42.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle42.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle42.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle42.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle42.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDatosFam.DefaultCellStyle = DataGridViewCellStyle42
        Me.dgDatosFam.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgDatosFam.Location = New System.Drawing.Point(6, 56)
        Me.dgDatosFam.MultiSelect = False
        Me.dgDatosFam.Name = "dgDatosFam"
        Me.dgDatosFam.ReadOnly = True
        DataGridViewCellStyle43.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle43.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle43.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle43.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle43.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle43.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatosFam.RowHeadersDefaultCellStyle = DataGridViewCellStyle43
        Me.dgDatosFam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDatosFam.Size = New System.Drawing.Size(1088, 408)
        Me.dgDatosFam.TabIndex = 65
        '
        'ctxMenuFam
        '
        Me.ctxMenuFam.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModificarF, Me.ctxEliminarF})
        Me.ctxMenuFam.Name = "ctxMenu"
        Me.ctxMenuFam.Size = New System.Drawing.Size(126, 48)
        '
        'ctxModificarF
        '
        Me.ctxModificarF.Image = Global.NOMINA.My.Resources.Resources.edit1
        Me.ctxModificarF.Name = "ctxModificarF"
        Me.ctxModificarF.Size = New System.Drawing.Size(125, 22)
        Me.ctxModificarF.Text = "Modificar"
        '
        'ctxEliminarF
        '
        Me.ctxEliminarF.Image = Global.NOMINA.My.Resources.Resources.menos
        Me.ctxEliminarF.Name = "ctxEliminarF"
        Me.ctxEliminarF.Size = New System.Drawing.Size(125, 22)
        Me.ctxEliminarF.Text = "Eliminar"
        '
        'gpDatosFam
        '
        Me.gpDatosFam.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpDatosFam.Controls.Add(Me.dtpFechaNacimiento)
        Me.gpDatosFam.Controls.Add(Me.btnAgregar)
        Me.gpDatosFam.Controls.Add(Me.btnCancelar)
        Me.gpDatosFam.Controls.Add(Me.Label15)
        Me.gpDatosFam.Controls.Add(Me.Label17)
        Me.gpDatosFam.Controls.Add(Me.TextNombFam)
        Me.gpDatosFam.Controls.Add(Me.Label16)
        Me.gpDatosFam.Controls.Add(Me.cmbTipo)
        Me.gpDatosFam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDatosFam.Location = New System.Drawing.Point(6, 4)
        Me.gpDatosFam.Name = "gpDatosFam"
        Me.gpDatosFam.Size = New System.Drawing.Size(1095, 46)
        Me.gpDatosFam.TabIndex = 64
        Me.gpDatosFam.TabStop = False
        Me.gpDatosFam.Text = "Datos de familiares "
        '
        'dtpFechaNacimiento
        '
        Me.dtpFechaNacimiento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFechaNacimiento.Location = New System.Drawing.Point(774, 17)
        Me.dtpFechaNacimiento.Name = "dtpFechaNacimiento"
        Me.dtpFechaNacimiento.Size = New System.Drawing.Size(99, 20)
        Me.dtpFechaNacimiento.TabIndex = 72
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregar.ImageKey = "checkok.png"
        Me.btnAgregar.ImageList = Me.ImageNuevos
        Me.btnAgregar.Location = New System.Drawing.Point(905, 12)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(80, 30)
        Me.btnAgregar.TabIndex = 4
        Me.btnAgregar.Text = "Agregar"
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Agregar")
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.ImageKey = "cancelar.png"
        Me.btnCancelar.ImageList = Me.ImageNuevos
        Me.btnCancelar.Location = New System.Drawing.Point(1009, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelar, "Cancelar")
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 13)
        Me.Label15.TabIndex = 62
        Me.Label15.Text = "Parentesco:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(659, 22)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(109, 13)
        Me.Label17.TabIndex = 71
        Me.Label17.Text = "Fecha de nacimiento:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextNombFam
        '
        Me.TextNombFam.BackColor = System.Drawing.Color.White
        Me.TextNombFam.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombFam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombFam.Location = New System.Drawing.Point(265, 18)
        Me.TextNombFam.MaxLength = 50
        Me.TextNombFam.Name = "TextNombFam"
        Me.TextNombFam.Size = New System.Drawing.Size(384, 20)
        Me.TextNombFam.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(211, 21)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(47, 13)
        Me.Label16.TabIndex = 60
        Me.Label16.Text = "Nombre:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbTipo
        '
        Me.cmbTipo.BackColor = System.Drawing.Color.White
        Me.cmbTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipo.FormattingEnabled = True
        Me.cmbTipo.Items.AddRange(New Object() {"PADRE", "MADRE", "CONYUGE", "HIJO"})
        Me.cmbTipo.Location = New System.Drawing.Point(80, 17)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'TabFam
        '
        Me.TabFam.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TabFam.Controls.Add(Me.dgDatosAca)
        Me.TabFam.Controls.Add(Me.gpDatosAca)
        Me.TabFam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TabFam.Location = New System.Drawing.Point(4, 22)
        Me.TabFam.Name = "TabFam"
        Me.TabFam.Size = New System.Drawing.Size(1101, 477)
        Me.TabFam.TabIndex = 4
        Me.TabFam.Text = "Datos academicos"
        '
        'dgDatosAca
        '
        Me.dgDatosAca.AllowUserToAddRows = False
        Me.dgDatosAca.AllowUserToDeleteRows = False
        DataGridViewCellStyle36.BackColor = System.Drawing.Color.LightGreen
        Me.dgDatosAca.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle36
        Me.dgDatosAca.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDatosAca.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgDatosAca.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgDatosAca.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle37.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle37.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle37.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle37.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle37.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatosAca.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle37
        Me.dgDatosAca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDatosAca.ContextMenuStrip = Me.ctxMenuAcad
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle38.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle38.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle38.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle38.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle38.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDatosAca.DefaultCellStyle = DataGridViewCellStyle38
        Me.dgDatosAca.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgDatosAca.Location = New System.Drawing.Point(9, 99)
        Me.dgDatosAca.MultiSelect = False
        Me.dgDatosAca.Name = "dgDatosAca"
        Me.dgDatosAca.ReadOnly = True
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle39.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle39.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle39.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle39.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle39.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatosAca.RowHeadersDefaultCellStyle = DataGridViewCellStyle39
        Me.dgDatosAca.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatosAca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDatosAca.Size = New System.Drawing.Size(1083, 375)
        Me.dgDatosAca.TabIndex = 66
        '
        'ctxMenuAcad
        '
        Me.ctxMenuAcad.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModificarAca, Me.ctxEliminarAca})
        Me.ctxMenuAcad.Name = "ctxMenu"
        Me.ctxMenuAcad.Size = New System.Drawing.Size(126, 48)
        '
        'ctxModificarAca
        '
        Me.ctxModificarAca.Image = Global.NOMINA.My.Resources.Resources.edit1
        Me.ctxModificarAca.Name = "ctxModificarAca"
        Me.ctxModificarAca.Size = New System.Drawing.Size(125, 22)
        Me.ctxModificarAca.Text = "Modificar"
        '
        'ctxEliminarAca
        '
        Me.ctxEliminarAca.Image = Global.NOMINA.My.Resources.Resources.menos
        Me.ctxEliminarAca.Name = "ctxEliminarAca"
        Me.ctxEliminarAca.Size = New System.Drawing.Size(125, 22)
        Me.ctxEliminarAca.Text = "Eliminar"
        '
        'gpDatosAca
        '
        Me.gpDatosAca.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpDatosAca.Controls.Add(Me.dpFecha)
        Me.gpDatosAca.Controls.Add(Me.textTitulo)
        Me.gpDatosAca.Controls.Add(Me.textObservaciones)
        Me.gpDatosAca.Controls.Add(Me.Label8)
        Me.gpDatosAca.Controls.Add(Me.btnAgregarAc)
        Me.gpDatosAca.Controls.Add(Me.btnCancelarAca)
        Me.gpDatosAca.Controls.Add(Me.Label14)
        Me.gpDatosAca.Controls.Add(Me.cmbNivel)
        Me.gpDatosAca.Controls.Add(Me.Label7)
        Me.gpDatosAca.Controls.Add(Me.Label13)
        Me.gpDatosAca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDatosAca.Location = New System.Drawing.Point(9, 11)
        Me.gpDatosAca.Name = "gpDatosAca"
        Me.gpDatosAca.Size = New System.Drawing.Size(1090, 82)
        Me.gpDatosAca.TabIndex = 65
        Me.gpDatosAca.TabStop = False
        Me.gpDatosAca.Text = "DATOS ACADEMICOS"
        '
        'dpFecha
        '
        Me.dpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dpFecha.Location = New System.Drawing.Point(833, 16)
        Me.dpFecha.Name = "dpFecha"
        Me.dpFecha.Size = New System.Drawing.Size(113, 20)
        Me.dpFecha.TabIndex = 3
        '
        'textTitulo
        '
        Me.textTitulo.BackColor = System.Drawing.Color.White
        Me.textTitulo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textTitulo.Location = New System.Drawing.Point(406, 15)
        Me.textTitulo.MaxLength = 150
        Me.textTitulo.Name = "textTitulo"
        Me.textTitulo.Size = New System.Drawing.Size(375, 20)
        Me.textTitulo.TabIndex = 2
        '
        'textObservaciones
        '
        Me.textObservaciones.BackColor = System.Drawing.Color.White
        Me.textObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textObservaciones.Location = New System.Drawing.Point(98, 43)
        Me.textObservaciones.MaxLength = 60
        Me.textObservaciones.Name = "textObservaciones"
        Me.textObservaciones.Size = New System.Drawing.Size(603, 20)
        Me.textObservaciones.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 13)
        Me.Label8.TabIndex = 72
        Me.Label8.Text = "Observaciones:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnAgregarAc
        '
        Me.btnAgregarAc.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregarAc.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarAc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarAc.ImageKey = "checkok.png"
        Me.btnAgregarAc.ImageList = Me.ImageNuevos
        Me.btnAgregarAc.Location = New System.Drawing.Point(918, 46)
        Me.btnAgregarAc.Name = "btnAgregarAc"
        Me.btnAgregarAc.Size = New System.Drawing.Size(80, 30)
        Me.btnAgregarAc.TabIndex = 5
        Me.btnAgregarAc.Text = "Agregar"
        Me.btnAgregarAc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAgregarAc, "Agregar")
        Me.btnAgregarAc.UseVisualStyleBackColor = False
        '
        'btnCancelarAca
        '
        Me.btnCancelarAca.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelarAca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarAca.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelarAca.ImageKey = "cancelar.png"
        Me.btnCancelarAca.ImageList = Me.ImageNuevos
        Me.btnCancelarAca.Location = New System.Drawing.Point(1003, 46)
        Me.btnCancelarAca.Name = "btnCancelarAca"
        Me.btnCancelarAca.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelarAca.TabIndex = 6
        Me.btnCancelarAca.TabStop = False
        Me.btnCancelarAca.Text = "Cancelar"
        Me.btnCancelarAca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelarAca, "Cancelar")
        Me.btnCancelarAca.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(313, 19)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Título académico:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbNivel
        '
        Me.cmbNivel.BackColor = System.Drawing.Color.White
        Me.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNivel.Location = New System.Drawing.Point(98, 16)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(208, 21)
        Me.cmbNivel.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(787, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Fecha:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(86, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Nivel académico"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TabCursos
        '
        Me.TabCursos.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TabCursos.Controls.Add(Me.dgDatosCursos)
        Me.TabCursos.Controls.Add(Me.gpCurso)
        Me.TabCursos.Location = New System.Drawing.Point(4, 22)
        Me.TabCursos.Name = "TabCursos"
        Me.TabCursos.Size = New System.Drawing.Size(1101, 477)
        Me.TabCursos.TabIndex = 7
        Me.TabCursos.Text = "Cursos empleado"
        '
        'dgDatosCursos
        '
        Me.dgDatosCursos.AllowUserToAddRows = False
        Me.dgDatosCursos.AllowUserToDeleteRows = False
        DataGridViewCellStyle32.BackColor = System.Drawing.Color.LightGreen
        Me.dgDatosCursos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle32
        Me.dgDatosCursos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDatosCursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgDatosCursos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgDatosCursos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle33.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatosCursos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle33
        Me.dgDatosCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDatosCursos.ContextMenuStrip = Me.ctxMenuCursos
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle34.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle34.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle34.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle34.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle34.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDatosCursos.DefaultCellStyle = DataGridViewCellStyle34
        Me.dgDatosCursos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgDatosCursos.Location = New System.Drawing.Point(12, 103)
        Me.dgDatosCursos.MultiSelect = False
        Me.dgDatosCursos.Name = "dgDatosCursos"
        Me.dgDatosCursos.ReadOnly = True
        Me.dgDatosCursos.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatosCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDatosCursos.Size = New System.Drawing.Size(1078, 372)
        Me.dgDatosCursos.TabIndex = 78
        '
        'ctxMenuCursos
        '
        Me.ctxMenuCursos.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuModificarCurso, Me.mnuEliminarCurso})
        Me.ctxMenuCursos.Name = "ctxMenu"
        Me.ctxMenuCursos.Size = New System.Drawing.Size(126, 48)
        '
        'mnuModificarCurso
        '
        Me.mnuModificarCurso.Image = Global.NOMINA.My.Resources.Resources.edit1
        Me.mnuModificarCurso.Name = "mnuModificarCurso"
        Me.mnuModificarCurso.Size = New System.Drawing.Size(125, 22)
        Me.mnuModificarCurso.Text = "Modificar"
        '
        'mnuEliminarCurso
        '
        Me.mnuEliminarCurso.Image = Global.NOMINA.My.Resources.Resources.menos
        Me.mnuEliminarCurso.Name = "mnuEliminarCurso"
        Me.mnuEliminarCurso.Size = New System.Drawing.Size(125, 22)
        Me.mnuEliminarCurso.Text = "Eliminar"
        '
        'gpCurso
        '
        Me.gpCurso.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.gpCurso.Controls.Add(Me.Label41)
        Me.gpCurso.Controls.Add(Me.TextNomInstitucion)
        Me.gpCurso.Controls.Add(Me.Label40)
        Me.gpCurso.Controls.Add(Me.lbmes)
        Me.gpCurso.Controls.Add(Me.cmbMes)
        Me.gpCurso.Controls.Add(Me.textConanioCurso)
        Me.gpCurso.Controls.Add(Me.TextNombCurso)
        Me.gpCurso.Controls.Add(Me.btnCancelarCurso)
        Me.gpCurso.Controls.Add(Me.btnAgregarCurso)
        Me.gpCurso.Controls.Add(Me.Label20)
        Me.gpCurso.Controls.Add(Me.Label38)
        Me.gpCurso.Controls.Add(Me.textconObservaCurso)
        Me.gpCurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCurso.Location = New System.Drawing.Point(12, 4)
        Me.gpCurso.Name = "gpCurso"
        Me.gpCurso.Size = New System.Drawing.Size(1078, 93)
        Me.gpCurso.TabIndex = 77
        Me.gpCurso.TabStop = False
        Me.gpCurso.Text = "Curso"
        '
        'Label41
        '
        Me.Label41.AutoSize = True
        Me.Label41.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label41.Location = New System.Drawing.Point(611, 13)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(58, 13)
        Me.Label41.TabIndex = 82
        Me.Label41.Text = "Institucion:"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextNomInstitucion
        '
        Me.TextNomInstitucion.BackColor = System.Drawing.Color.White
        Me.TextNomInstitucion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNomInstitucion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNomInstitucion.Location = New System.Drawing.Point(675, 13)
        Me.TextNomInstitucion.MaxLength = 100
        Me.TextNomInstitucion.Name = "TextNomInstitucion"
        Me.TextNomInstitucion.Size = New System.Drawing.Size(393, 20)
        Me.TextNomInstitucion.TabIndex = 2
        '
        'Label40
        '
        Me.Label40.AutoSize = True
        Me.Label40.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label40.Location = New System.Drawing.Point(10, 13)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(47, 13)
        Me.Label40.TabIndex = 80
        Me.Label40.Text = "Nombre:"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lbmes
        '
        Me.lbmes.AutoSize = True
        Me.lbmes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbmes.Location = New System.Drawing.Point(10, 42)
        Me.lbmes.Name = "lbmes"
        Me.lbmes.Size = New System.Drawing.Size(30, 13)
        Me.lbmes.TabIndex = 79
        Me.lbmes.Text = "Mes:"
        Me.lbmes.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbMes
        '
        Me.cmbMes.BackColor = System.Drawing.Color.White
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.FormattingEnabled = True
        Me.cmbMes.Items.AddRange(New Object() {"PADRE", "MADRE", "CONJUGE", "HIJIO", ""})
        Me.cmbMes.Location = New System.Drawing.Point(43, 42)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(121, 21)
        Me.cmbMes.TabIndex = 3
        '
        'textConanioCurso
        '
        Me.textConanioCurso.BackColor = System.Drawing.Color.White
        Me.textConanioCurso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textConanioCurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textConanioCurso.Location = New System.Drawing.Point(213, 42)
        Me.textConanioCurso.MaxLength = 6
        Me.textConanioCurso.Name = "textConanioCurso"
        Me.textConanioCurso.Size = New System.Drawing.Size(56, 20)
        Me.textConanioCurso.TabIndex = 4
        '
        'TextNombCurso
        '
        Me.TextNombCurso.BackColor = System.Drawing.Color.White
        Me.TextNombCurso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombCurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombCurso.Location = New System.Drawing.Point(63, 13)
        Me.TextNombCurso.MaxLength = 150
        Me.TextNombCurso.Name = "TextNombCurso"
        Me.TextNombCurso.Size = New System.Drawing.Size(542, 20)
        Me.TextNombCurso.TabIndex = 1
        '
        'btnCancelarCurso
        '
        Me.btnCancelarCurso.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelarCurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarCurso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelarCurso.ImageKey = "cancelar.png"
        Me.btnCancelarCurso.ImageList = Me.ImageNuevos
        Me.btnCancelarCurso.Location = New System.Drawing.Point(979, 42)
        Me.btnCancelarCurso.Name = "btnCancelarCurso"
        Me.btnCancelarCurso.Size = New System.Drawing.Size(80, 30)
        Me.btnCancelarCurso.TabIndex = 7
        Me.btnCancelarCurso.Text = "Cancelar"
        Me.btnCancelarCurso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelarCurso, "Cancelar")
        Me.btnCancelarCurso.UseVisualStyleBackColor = False
        '
        'btnAgregarCurso
        '
        Me.btnAgregarCurso.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregarCurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarCurso.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAgregarCurso.ImageKey = "checkok.png"
        Me.btnAgregarCurso.ImageList = Me.ImageNuevos
        Me.btnAgregarCurso.Location = New System.Drawing.Point(893, 42)
        Me.btnAgregarCurso.Name = "btnAgregarCurso"
        Me.btnAgregarCurso.Size = New System.Drawing.Size(80, 30)
        Me.btnAgregarCurso.TabIndex = 6
        Me.btnAgregarCurso.Text = "Agregar"
        Me.btnAgregarCurso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAgregarCurso, "Agregar")
        Me.btnAgregarCurso.UseVisualStyleBackColor = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(291, 42)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(81, 13)
        Me.Label20.TabIndex = 77
        Me.Label20.Text = "Observaciones:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label38
        '
        Me.Label38.AutoSize = True
        Me.Label38.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label38.Location = New System.Drawing.Point(174, 42)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(29, 13)
        Me.Label38.TabIndex = 75
        Me.Label38.Text = "Año:"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textconObservaCurso
        '
        Me.textconObservaCurso.BackColor = System.Drawing.Color.White
        Me.textconObservaCurso.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textconObservaCurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textconObservaCurso.Location = New System.Drawing.Point(378, 42)
        Me.textconObservaCurso.MaxLength = 150
        Me.textconObservaCurso.Multiline = True
        Me.textconObservaCurso.Name = "textconObservaCurso"
        Me.textconObservaCurso.Size = New System.Drawing.Size(483, 42)
        Me.textconObservaCurso.TabIndex = 5
        '
        'TabPuestos
        '
        Me.TabPuestos.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TabPuestos.Controls.Add(Me.dgvPuestos)
        Me.TabPuestos.Location = New System.Drawing.Point(4, 22)
        Me.TabPuestos.Name = "TabPuestos"
        Me.TabPuestos.Size = New System.Drawing.Size(1101, 477)
        Me.TabPuestos.TabIndex = 8
        Me.TabPuestos.Text = "Puestos"
        '
        'dgvPuestos
        '
        Me.dgvPuestos.AllowUserToAddRows = False
        Me.dgvPuestos.AllowUserToDeleteRows = False
        DataGridViewCellStyle28.BackColor = System.Drawing.Color.LightGreen
        Me.dgvPuestos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle28
        Me.dgvPuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvPuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.dgvPuestos.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.dgvPuestos.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPuestos.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle29
        Me.dgvPuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPuestos.DefaultCellStyle = DataGridViewCellStyle30
        Me.dgvPuestos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgvPuestos.Location = New System.Drawing.Point(10, 34)
        Me.dgvPuestos.MultiSelect = False
        Me.dgvPuestos.Name = "dgvPuestos"
        Me.dgvPuestos.ReadOnly = True
        Me.dgvPuestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPuestos.Size = New System.Drawing.Size(1081, 408)
        Me.dgvPuestos.TabIndex = 66
        '
        'TabCamposEsp
        '
        Me.TabCamposEsp.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TabCamposEsp.Controls.Add(Me.flPanel1)
        Me.TabCamposEsp.Location = New System.Drawing.Point(4, 22)
        Me.TabCamposEsp.Name = "TabCamposEsp"
        Me.TabCamposEsp.Padding = New System.Windows.Forms.Padding(3)
        Me.TabCamposEsp.Size = New System.Drawing.Size(1101, 477)
        Me.TabCamposEsp.TabIndex = 9
        Me.TabCamposEsp.Text = "Campos Adicionales"
        '
        'flPanel1
        '
        Me.flPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.flPanel1.AutoScroll = True
        Me.flPanel1.Location = New System.Drawing.Point(23, 6)
        Me.flPanel1.Name = "flPanel1"
        Me.flPanel1.Size = New System.Drawing.Size(394, 418)
        Me.flPanel1.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(961, 9)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(80, 30)
        Me.btnGuardar.TabIndex = 4
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Almacenar registro")
        Me.btnGuardar.UseVisualStyleBackColor = False
        '
        'btnLimpiar
        '
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(89, 9)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 52
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'btnAtras
        '
        Me.btnAtras.BackColor = System.Drawing.SystemColors.Control
        Me.btnAtras.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAtras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAtras.ImageKey = "anterior.png"
        Me.btnAtras.ImageList = Me.ImageNuevos
        Me.btnAtras.Location = New System.Drawing.Point(7, 9)
        Me.btnAtras.Name = "btnAtras"
        Me.btnAtras.Size = New System.Drawing.Size(80, 30)
        Me.btnAtras.TabIndex = 60
        Me.btnAtras.Text = "Anterior"
        Me.btnAtras.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAtras, "Atras")
        Me.btnAtras.UseVisualStyleBackColor = False
        '
        'btnSiguiente
        '
        Me.btnSiguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSiguiente.BackColor = System.Drawing.SystemColors.Control
        Me.btnSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSiguiente.ImageKey = "siguiente.png"
        Me.btnSiguiente.ImageList = Me.ImageNuevos
        Me.btnSiguiente.Location = New System.Drawing.Point(1047, 9)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(80, 30)
        Me.btnSiguiente.TabIndex = 59
        Me.btnSiguiente.Text = "Siguiente"
        Me.btnSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnSiguiente, "Siguiente")
        Me.btnSiguiente.UseVisualStyleBackColor = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.ImageKey = "buscar2.png"
        Me.btnBuscar.ImageList = Me.ImageNuevos
        Me.btnBuscar.Location = New System.Drawing.Point(875, 9)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(80, 30)
        Me.btnBuscar.TabIndex = 61
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Buscar")
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LavenderBlush
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.ImageIndex = 1
        Me.Button1.Location = New System.Drawing.Point(749, 59)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(99, 35)
        Me.Button1.TabIndex = 74
        Me.Button1.TabStop = False
        Me.Button1.Text = "Agregar"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.LavenderBlush
        Me.Button2.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.ImageIndex = 0
        Me.Button2.Location = New System.Drawing.Point(749, 20)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(99, 35)
        Me.Button2.TabIndex = 73
        Me.Button2.TabStop = False
        Me.Button2.Text = "Cancelar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = False
        '
        'MaskedTextBox2
        '
        Me.MaskedTextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MaskedTextBox2.Location = New System.Drawing.Point(529, 48)
        Me.MaskedTextBox2.Mask = "##/##/####"
        Me.MaskedTextBox2.Name = "MaskedTextBox2"
        Me.MaskedTextBox2.Size = New System.Drawing.Size(84, 20)
        Me.MaskedTextBox2.TabIndex = 72
        '
        'Label3
        '
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(17, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 62
        Me.Label3.Text = "TIPO"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(526, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(177, 16)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "FECHA DE NACIMIENTO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox7
        '
        Me.TextBox7.BackColor = System.Drawing.Color.White
        Me.TextBox7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox7.Location = New System.Drawing.Point(154, 48)
        Me.TextBox7.MaxLength = 75
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(353, 20)
        Me.TextBox7.TabIndex = 59
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(151, 29)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(96, 16)
        Me.Label5.TabIndex = 60
        Me.Label5.Text = "NOMBRE"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ComboBox9
        '
        Me.ComboBox9.BackColor = System.Drawing.Color.White
        Me.ComboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBox9.FormattingEnabled = True
        Me.ComboBox9.Location = New System.Drawing.Point(20, 48)
        Me.ComboBox9.Name = "ComboBox9"
        Me.ComboBox9.Size = New System.Drawing.Size(121, 21)
        Me.ComboBox9.TabIndex = 63
        '
        'gpEmpleado
        '
        Me.gpEmpleado.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.gpEmpleado.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpleado.Controls.Add(Me.TextEmpleado)
        Me.gpEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpleado.ForeColor = System.Drawing.Color.White
        Me.gpEmpleado.Location = New System.Drawing.Point(986, -1)
        Me.gpEmpleado.Name = "gpEmpleado"
        Me.gpEmpleado.Size = New System.Drawing.Size(137, 42)
        Me.gpEmpleado.TabIndex = 1
        Me.gpEmpleado.TabStop = False
        Me.gpEmpleado.Text = "Empleado"
        '
        'TextEmpleado
        '
        Me.TextEmpleado.BackColor = System.Drawing.Color.White
        Me.TextEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEmpleado.ForeColor = System.Drawing.Color.Red
        Me.TextEmpleado.Location = New System.Drawing.Point(6, 15)
        Me.TextEmpleado.MaxLength = 9
        Me.TextEmpleado.Name = "TextEmpleado"
        Me.TextEmpleado.ReadOnly = True
        Me.TextEmpleado.Size = New System.Drawing.Size(124, 20)
        Me.TextEmpleado.TabIndex = 1
        Me.TextEmpleado.TabStop = False
        '
        'AbrirImagen
        '
        Me.AbrirImagen.FileName = "Cargar Imagen"
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 43)
        Me.Panel1.TabIndex = 56
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnAtras)
        Me.Panel2.Controls.Add(Me.btnSiguiente)
        Me.Panel2.Controls.Add(Me.btnBuscar)
        Me.Panel2.Controls.Add(Me.btnGuardar)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Location = New System.Drawing.Point(0, 582)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1130, 42)
        Me.Panel2.TabIndex = 57
        '
        'TabCPrincipal
        '
        Me.TabCPrincipal.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabCPrincipal.Controls.Add(Me.TabPri)
        Me.TabCPrincipal.Controls.Add(Me.TabDetalle)
        Me.TabCPrincipal.Location = New System.Drawing.Point(1, 48)
        Me.TabCPrincipal.Name = "TabCPrincipal"
        Me.TabCPrincipal.SelectedIndex = 0
        Me.TabCPrincipal.Size = New System.Drawing.Size(1126, 537)
        Me.TabCPrincipal.TabIndex = 58
        '
        'TabPri
        '
        Me.TabPri.Controls.Add(Me.TabCDatos)
        Me.TabPri.Location = New System.Drawing.Point(4, 22)
        Me.TabPri.Name = "TabPri"
        Me.TabPri.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPri.Size = New System.Drawing.Size(1118, 511)
        Me.TabPri.TabIndex = 0
        Me.TabPri.Text = "Principal"
        Me.TabPri.UseVisualStyleBackColor = True
        '
        'TabDetalle
        '
        Me.TabDetalle.Controls.Add(Me.dgvConsulta)
        Me.TabDetalle.Location = New System.Drawing.Point(4, 22)
        Me.TabDetalle.Name = "TabDetalle"
        Me.TabDetalle.Padding = New System.Windows.Forms.Padding(3)
        Me.TabDetalle.Size = New System.Drawing.Size(1118, 511)
        Me.TabDetalle.TabIndex = 1
        Me.TabDetalle.Text = "Detalle"
        Me.TabDetalle.UseVisualStyleBackColor = True
        '
        'dgvConsulta
        '
        Me.dgvConsulta.AllowUserToAddRows = False
        Me.dgvConsulta.AllowUserToDeleteRows = False
        DataGridViewCellStyle35.BackColor = System.Drawing.Color.LightGreen
        Me.dgvConsulta.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle35
        Me.dgvConsulta.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvConsulta.BackgroundColor = System.Drawing.Color.White
        Me.dgvConsulta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvConsulta.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgvConsulta.Location = New System.Drawing.Point(6, 6)
        Me.dgvConsulta.MultiSelect = False
        Me.dgvConsulta.Name = "dgvConsulta"
        Me.dgvConsulta.ReadOnly = True
        Me.dgvConsulta.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvConsulta.Size = New System.Drawing.Size(1105, 499)
        Me.dgvConsulta.TabIndex = 67
        '
        'frmIngEmpleados
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnLimpiar
        Me.ClientSize = New System.Drawing.Size(1130, 624)
        Me.Controls.Add(Me.TabCPrincipal)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.gpEmpleado)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmIngEmpleados"
        Me.Text = "Ingreso de Datos de Empleados"
        Me.TabCDatos.ResumeLayout(False)
        Me.TabDatos.ResumeLayout(False)
        Me.TabDatos.PerformLayout()
        Me.ctxPrincipal.ResumeLayout(False)
        Me.pnConsulta.ResumeLayout(False)
        Me.pnConsulta.PerformLayout()
        CType(Me.picBoCuadro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabAcade.ResumeLayout(False)
        CType(Me.dgDatosFam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenuFam.ResumeLayout(False)
        Me.gpDatosFam.ResumeLayout(False)
        Me.gpDatosFam.PerformLayout()
        Me.TabFam.ResumeLayout(False)
        CType(Me.dgDatosAca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenuAcad.ResumeLayout(False)
        Me.gpDatosAca.ResumeLayout(False)
        Me.gpDatosAca.PerformLayout()
        Me.TabCursos.ResumeLayout(False)
        CType(Me.dgDatosCursos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenuCursos.ResumeLayout(False)
        Me.gpCurso.ResumeLayout(False)
        Me.gpCurso.PerformLayout()
        Me.TabPuestos.ResumeLayout(False)
        CType(Me.dgvPuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabCamposEsp.ResumeLayout(False)
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpEmpleado.ResumeLayout(False)
        Me.gpEmpleado.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.TabCPrincipal.ResumeLayout(False)
        Me.TabPri.ResumeLayout(False)
        Me.TabDetalle.ResumeLayout(False)
        CType(Me.dgvConsulta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private _Consulta As Boolean
    Public Property Consulta() As Boolean
        Get
            Return _Consulta
        End Get
        Set(ByVal value As Boolean)
            _Consulta = value
            habilita_consulta(value)

        End Set
    End Property


    Private Sub habilita_consulta(valor As Boolean)
        btnBuscar.Enabled = valor
        ctxPrincipal.Visible = valor
        TabPuestos.Visible = valor
        gpDatosAca.Enabled = Not valor
        gpDatosFam.Enabled = Not valor
        gpCurso.Enabled = Not valor
        ContextoMenuEnab(True, Not valor, ctxMenuFam)
        ContextoMenuEnab(True, Not valor, ctxMenuAcad)
        ContextoMenuEnab(True, Not valor, ctxMenuCursos)
        pnConsulta.Visible = valor

        If Not Me.Consulta Then
            If TabCPrincipal.TabPages.Contains(TabDetalle) Then
                TabCPrincipal.TabPages.Remove(TabDetalle)
            End If
            If TabCDatos.TabPages.Contains(TabPuestos) Then
                TabCPrincipal.TabPages.Remove(TabPuestos)
            End If
        Else
            If Not TabCPrincipal.TabPages.Contains(TabDetalle) Then
                TabCPrincipal.TabPages.Add(TabDetalle)
            End If
            If Not TabCDatos.TabPages.Contains(TabPuestos) Then
                TabCPrincipal.TabPages.Add(TabPuestos)
            End If
        End If
    End Sub


    Private Sub Inicializacion()
        lpara.Clear()
        lpara("empresa") = empresa
        cadena = "SELECT * FROM ZONAS order by zona"
        llena_combo(cadena, cmbZona)
        cmbZona.Items.Add("")
        cadena = "SELECT NOMBRE,DEPTO FROM DEPARTAMENTOS order by depto"
        llena_combo(cadena, cmbDepartamento)
        cmbDepartamento.Items.Add("")
        llenaTabla(cadena, tbDeptos)
        cadena = "select nombre,estado from estadosciviles order by estado"
        llena_combo(cadena, cmbEstadoCivil)
        cmbEstadoCivil.Items.Add("")
        llenaTabla(cadena, tbCivil)


        cadena = "select nombre,depto from departamentos  order by depto"
        llena_combo(cadena, cmbDeptoce)
        cmbDeptoce.Items.Add("")
        llenaTablaBatch(cadena, tbDeptoCed)
        cadena = "select nombre,tipositua from situaecono where empresa=@empresa order by nombre"
        llena_combo(cadena, cmbSituaEcono, ListaParametros(lpara))
        cmbSituaEcono.Items.Add("")
        llenaTabla(cadena, tbSituaEcono, ListaParametros(lpara))
        cadena = "select nombre,tipoiden, usareg from tiidentifica order by nombre"
        llena_combo(cadena, cmbIdentifica)
        cmbIdentifica.Items.Add("")
        llenaTablaBatch(cadena, tbTipoIde)
        cadena = "select nombre,nacional from nacionalidades order by nombre"
        llena_combo(cadena, cmbNacional)
        cmbNacional.Items.Add("")
        llenaTablaBatch(cadena, tbNacional)

        Dim registro_vac As Boolean = If(Me.Consulta, True, False)

        ctrMes.FillComboMes(cmbMes, registro_vac)

        ctrEmple.FillComboNivelEducativo(cmbNivelEducativo, registro_vac)
        ctrEmple.FillComboNivelEducativo(cmbNivel, registro_vac)
        ctrEmple.FillComboComunidadLing(cmbComLing, registro_vac)
        ctrEmple.FillComboPuebloPert(cmbPueblo, registro_vac)
        ctrEmple.FillComboTipoDiscapacidad(cmbTipoDiscp, registro_vac)

    End Sub

    Private Sub iniciliza_detalle(empleado As Int32)
        lpara.Clear()
        limpia_academico()
        limpia_curso()
        limpia_fam()
        lpara("empleado") = empleado
        lpara("empresa") = empresa

        cadena = "select  case when tipo='P' then 'PADRE' when tipo='M' then 'MADRE' " &
                 " when tipo='C' then 'CONYUGE' when tipo='H' then 'HIJO' else '' end as nombTipo, tipo," &
                 " nombreFam, case when fechaNac ='01/01/1900' then '' else convert( varchar, fechaNac) end as fechaNac " &
                 " from EMPLEFAM where empresa=@empresa and empleado=@empleado order by id_efam"
        llenaTabla(cadena, tbFamiliares, ListaParametros(lpara))
        dgDatosFam.DataSource = tbFamiliares
        Vista1(dgDatosFam)
        cadena = "select a.nombre as nombnivel,  e.nombre_titulo as nombtitulo, " &
              " e.fecha, e.id_nivel_educativo, e.observa from empleaca e " &
              "inner join emplegen_nivel_educativo a on a.id_nivel_educativo=e.id_nivel_educativo " &
              "where empresa=@empresa and empleado=@empleado order by id_ea"
        llenaTabla(cadena, tbAcademico, ListaParametros(lpara))
        dgDatosAca.DataSource = tbAcademico
        Vista2(dgDatosAca)
        cadena = " select a.institucion, a.nombre,a.mes,a.año,a.observacion " &
                 " from nom_curso_empleado a " &
                 " where  empresa=@empresa and empleado=@empleado" &
                 " order by a.id_cemp"
        llenaTabla(cadena, tbCurso, ListaParametros(lpara))
        dgDatosCursos.DataSource = tbCurso
        Vista4(dgDatosCursos)
    End Sub

    Private Sub frmDatosFamilia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Inicializacion()
        iniciliza_detalle(0)
        CargarCamposGenericos()
        limpia()

        cadena = "select id_area,nombre from area_nomina"
        llenaTabla(cadena, tbArea)
        Dim filaVacia As DataRow = tbArea.NewRow()
        filaVacia("id_area") = 0
        filaVacia("nombre") = ""
        tbArea.Rows.InsertAt(filaVacia, 0)
        cmbArea.DataSource = tbArea
        cmbArea.DisplayMember = "nombre"
        cmbArea.ValueMember = "id_area"

        cadena = "SELECT id_campo, nombre_campo, tipo_campo FROM emplegen_campos
                  WHERE activo = 1 ORDER BY id_campo"
        llenaTabla(cadena, tbCamposEsp)

    End Sub

#Region "Formato de datagrid"
    Private Sub VistaConsulta(ByVal dgVista As DataGridView)
        With dgVista

            .Columns("empleado").HeaderText = "Empleado"
            .Columns("empleado").Width = 125
            .Columns("apellido1").HeaderText = "Apellido1"
            .Columns("apellido1").Width = 175
            .Columns("apellido2").HeaderText = "Apellido2"
            .Columns("apellido2").Width = 175
            .Columns("nombre1").HeaderText = "Nombre1"
            .Columns("nombre1").Width = 175
            .Columns("nombre2").HeaderText = "Nombre2"
            .Columns("nombre2").Width = 175
            .Columns("direccion").HeaderText = "Direccion"
            .Columns("direccion").Width = 175
            .Columns("telefono").HeaderText = "Telefono"
            .Columns("telefono").Width = 175
            .Columns("celular").HeaderText = "Celular"
            .Columns("celular").Width = 175
            .Columns("correo").HeaderText = "Correo"
            .Columns("correo").Width = 175
            .Columns("fechanac").HeaderText = "Fecha Nac"
            .Columns("fechanac").Width = 175


            .Columns("calle").Visible = False
            .Columns("numero").Visible = False
            .Columns("apto").Visible = False
            .Columns("zona").Visible = False
            .Columns("colonia").Visible = False

            .Columns("deptodir").Visible = False
            .Columns("munidir").Visible = False
            .Columns("telefono").Visible = False
            .Columns("celular").Visible = False
            .Columns("nacional").Visible = False
            .Columns("tipoiden").Visible = False
            .Columns("registro").Visible = False
            .Columns("numidentica").Visible = False
            .Columns("deptoced").Visible = False
            .Columns("municed").Visible = False
            .Columns("docdocente").Visible = False
            .Columns("civil").Visible = False
            .Columns("sexo").Visible = False
            .Columns("economica").Visible = False
            .Columns("fechai").Visible = False
            .Columns("usuario").Visible = False
            .Columns("correoi").Visible = False

            .Columns("id_nivel_educativo").Visible = False
            .Columns("id_pueblo_pertenencia").Visible = False
            .Columns("id_comunidad_ling").Visible = False
            .Columns("titulo_principal").Visible = False
            .Columns("id_tipo_discapacidad").Visible = False

            'AltoGridView(18, tbFamiliares, 275, 836, dgVista)
        End With
    End Sub

    Private Sub Vista1(ByVal dgVista As DataGridView)
        With dgVista
            .Columns("tipo").Visible = False

            .Columns("nombtipo").HeaderText = "Tipo"

            .Columns("nombtipo").FillWeight = 30
            .Columns("nombrefam").HeaderText = "Nombre"
            .Columns("nombrefam").FillWeight = 60

            .Columns("fechaNac").HeaderText = "Fecha de nacimiento"
            .Columns("fechaNac").FillWeight = 10

            'AltoGridView(18, tbFamiliares, 275, 836, dgVista)
        End With
    End Sub

    Private Sub Vista2(ByVal dgVista As DataGridView)
        With dgVista

            .Columns("nombnivel").HeaderText = "Nivel"
            .Columns("nombnivel").FillWeight = 30


            .Columns("nombtitulo").HeaderText = "Titulo"
            .Columns("nombtitulo").FillWeight = 30

            .Columns("fecha").HeaderText = "Fecha"
            .Columns("fecha").FillWeight = 10

            .Columns("observa").HeaderText = "Observaciones"
            .Columns("observa").FillWeight = 30
            .Columns("id_nivel_educativo").Visible = False
            'AltoGridView(18, tbFamiliares, 275, 836, dgVista)
        End With
    End Sub
    Private Sub Vista3(ByVal dgVista As DataGridView)
        With dgVista
            .Columns("puesto").HeaderText = "Código"
            .Columns("puesto").Width = 60
            .Columns("puesto").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("nombre").HeaderText = "Nombre"
            .Columns("nombre").Width = 290
            .Columns("nombre").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("fechaing").HeaderText = "Fecha ingreso"
            .Columns("fechaing").Width = 85
            .Columns("fechaing").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("fechaeg").HeaderText = "Fecha egreso"
            .Columns("fechaeg").Width = 85
            .Columns("fechaeg").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("observacion").HeaderText = "Observaciones"
            .Columns("observacion").Width = 270
            .Columns("observacion").SortMode = DataGridViewColumnSortMode.NotSortable
            'AltoGridView(18, tbPuesto, 275, 836, dgVista)
        End With
    End Sub
    Private Sub Vista4(ByVal dgVista As DataGridView)
        With dgVista
            .Columns("institucion").HeaderText = "Institución"
            .Columns("institucion").FillWeight = 30
            .Columns("nombre").HeaderText = "Nombre"
            .Columns("nombre").FillWeight = 30

            .Columns("mes").HeaderText = "Mes"
            .Columns("mes").FillWeight = 5

            .Columns("año").HeaderText = "Año"
            .Columns("año").FillWeight = 5

            .Columns("observacion").HeaderText = "Observaciones"
            .Columns("observacion").FillWeight = 30

            'AltoGridView(18, tbCurso, 275, 836, dgVista)
        End With
    End Sub
#End Region


#Region "Limpia opciones"

#End Region
    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpia()

    End Sub

    Private Sub limpia()
        lpara.Clear()
        lpara("empresa") = empresa
        If Not Me.Consulta Then
            TextEmpleado.Text = BuscaEscalar("select coalesce(max(empleado), 0) from emplegen where empresa=@empresa", ListaParametros(lpara)) + 1
            TextEmpleado.ReadOnly = True
            axFechaNac.EsModoConsulta = False
            btnImagen.Enabled = True
            TextEmpleado.ReadOnly = True
            ctxModPri.Visible = False
        Else
            TextEmpleado.Clear()
            TextEmpleado.ReadOnly = False
            axFechaNac.EsModoConsulta = True
            axFechaNac.reiniciaControl()
            btnBuscar.Enabled = True
            TextEmpleado.ReadOnly = False
            gpCurso.Enabled = False
            gpDatosAca.Enabled = False
            gpDatosFam.Enabled = False
            ContextoMenuEnab(True, False, ctxMenuAcad)
            ContextoMenuEnab(True, False, ctxMenuAcad)
            ContextoMenuEnab(True, False, ctxMenuAcad)
            btnGuardar.Enabled = False
            btnImagen.Enabled = False
            habilita_mod(False)
            ctxModPri.Visible = True
            ctxModPri.Enabled = False
            habilita_mod(False)
        End If
        ConsultaReadOnly(TabDatos, False)
        axFechaNac.Datevalue1 = Today.Date
        axFechaNac.Datevalue2 = Today.Date
        limpia_academico()
        limpia_fam()
        limpia_curso()
        tbConsulta.Rows.Clear()
        borra_Mejorado(TabDatos, ep1)
        tbAcademico.Rows.Clear()
        tbFamiliares.Rows.Clear()
        tbCurso.Rows.Clear()
        picBoCuadro.Image = Nothing
        guardaImagen = False

        btnSiguiente.Enabled = False
        btnAtras.Enabled = False
        cmbArea.SelectedValue = 0

        LimpiarCamposGenericos()
        'Volver a cargar los campos vacíos
        CargarCamposGenericos()
        'Regresar al primer Tab
        'TabCPrincipal.SelectedIndex = 0
        TabCDatos.SelectedIndex = 0
        'Poner el foco
        TextEmpleado.Focus()

    End Sub

    Private Sub btnCancelarAca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarAca.Click
        limpia_academico()
    End Sub

    Private Sub limpia_academico()
        opcModiAca = 0
        borra_Mejorado(gpDatosAca, ep1)
        ContextoMenuEnab(True, True, ctxMenuAcad)
        dpFecha.Value = Today
        cmbNivel.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        limpia_fam()
    End Sub

    Private Sub limpia_fam()
        opcModiFa = 0
        borra_Mejorado(gpDatosFam, ep1)
        ContextoMenuEnab(True, True, ctxMenuFam)
        dtpFechaNacimiento.Value = Today
        cmbTipo.Focus()
    End Sub

    Private Sub btnCancelarCurso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarCurso.Click
        limpia_curso()
    End Sub

    Private Sub limpia_curso()
        opcModiCurso = 0
        borra_Mejorado(gpCurso, ep1)
        ContextoMenuEnab(True, True, ctxMenuCursos)
        TextNombCurso.Focus()
    End Sub


    Private Sub habilita_mod(valor As Boolean)
        Dim colAplicar, colEspecial As Color
        If valor Then
            colAplicar = ColorModi
            colEspecial = ColorModi
        Else
            colAplicar = Color.White
            colEspecial = colorCons
        End If
        Colorea_Mejorado(TabDatos, colAplicar)
        textConlApellido1.BackColor = colEspecial
        textConlApellido2.BackColor = colEspecial
        TextConlCasada.BackColor = colEspecial
        textConlNombre1.BackColor = colEspecial
        textConlNombre2.BackColor = colEspecial
        textConlNombre3.BackColor = colEspecial
        ' ctxModPri.Visible = False
        '        ctxModPri.Enabled = True
        gpDatosAca.Enabled = valor
        gpDatosFam.Enabled = valor
        gpCurso.Enabled = valor
        ContextoMenuEnab(True, valor, ctxMenuFam)
        ContextoMenuEnab(True, valor, ctxMenuAcad)
        ContextoMenuEnab(True, valor, ctxMenuCursos)
        ConsultaReadOnly(TabDatos, Not valor)
        '   btnSiguiente.Enabled = False
        '  btnAtras.Enabled = False
        '   btnBuscar.Visible = False
        btnGuardar.Enabled = valor
        axFechaNac.EsModoConsulta = Not valor
        btnImagen.Enabled = valor
        cmbArea.Enabled = valor
    End Sub


    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim fechaI, tipoFa As String
        Dim i As Int32
        tipoFa = ""
        fechaI = dtpFechaNacimiento.Value.Date

        If validetError(cmbTipo, ep1) = False Or validetError(TextNombFam, ep1) = False Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If
        Select Case cmbTipo.SelectedIndex
            Case 0
                tipoFa = "P"
            Case 1
                tipoFa = "M"
            Case 2
                tipoFa = "C"
            Case 3
                tipoFa = "H"
        End Select
        For i = 0 To tbFamiliares.Rows.Count - 1
            filaTemp = tbFamiliares.Rows(i)
            If opcModiFa = 0 Then
                If filaTemp.Item(1) = tipoFa And tipoFa <> "H" Then
                    MsgBox("FAMILIAR YA SE HA INGRESADO, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
            Else
                If filaTemp.Item(1) = tipoFa And tipoFa <> "H" And IndiceFam <> i Then
                    MsgBox("FAMILIAR YA SE HA INGRESADO, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
            End If
        Next i
        If opcModiFa = 0 Then
            filaTemp = tbFamiliares.NewRow()
            filaTemp.Item(0) = cmbTipo.Text
            filaTemp.Item(1) = tipoFa
            filaTemp.Item(2) = TextNombFam.Text
            filaTemp.Item(3) = fechaI
            tbFamiliares.Rows.Add(filaTemp)
        Else
            filaTemp = tbFamiliares.Rows(IndiceFam)
            filaTemp.BeginEdit()
            filaTemp.Item(0) = cmbTipo.Text
            filaTemp.Item(1) = tipoFa
            filaTemp.Item(2) = TextNombFam.Text
            filaTemp.Item(3) = fechaI
            filaTemp.EndEdit()
        End If
        MueveScrollView(dgDatosFam, tbFamiliares.Rows.Count - 1)
        btnCancelar_Click(sender, e)
    End Sub

    Private Sub btnAgregarAc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarAc.Click

        If validetError(textTitulo, ep1) = False Or validetComilla(textObservaciones, ep1) = False Then
            MsgBox("VERIFIQUE INGRESO DE CAMPOS ", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If
        If opcModiAca = 0 Then
            filaTemp = tbAcademico.NewRow()
        Else
            filaTemp = _fAca
        End If
        filaTemp.Item("nombnivel") = cmbNivel.Text
        filaTemp.Item("id_nivel_educativo") = cmbNivel.SelectedValue
        filaTemp.Item("nombtitulo") = textTitulo.Text.Trim()

        filaTemp.Item("fecha") = dpFecha.Value.Date
        filaTemp.Item("observa") = textObservaciones.Text
        If opcModiAca = 0 Then
            tbAcademico.Rows.Add(filaTemp)
        End If
        MueveScrollView(dgDatosAca, tbAcademico.Rows.Count - 1)
        btnCancelarAca_Click(sender, e)
    End Sub

#Region "SUB MENUS MODIFICACION Y ELIMINACION "
    Private Sub ctxModificaF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificarF.Click
        Dim f As DataRow
        If dgDatosFam.SelectedRows.Count > 0 Then
            opcModiFa = 1
            IndiceFam = dgDatosFam.SelectedRows(0).Index
            ContextoMenuEnab(False, True, ctxMenuFam)
            f = CType(dgDatosFam.SelectedRows(0).DataBoundItem, DataRowView).Row
            Select Case f.Item(1)
                Case "P"
                    cmbTipo.SelectedIndex = 0
                Case "M"
                    cmbTipo.SelectedIndex = 1
                Case "C"
                    cmbTipo.SelectedIndex = 2
                Case "H"
                    cmbTipo.SelectedIndex = 3
            End Select
            TextNombFam.Text = f.Item(2)
            dtpFechaNacimiento.Value = f.Item(3)
            cmbTipo.Focus()
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ctxModificaAca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificarAca.Click

        If dgDatosAca.SelectedRows.Count > 0 Then
            opcModiAca = 1

            ContextoMenuEnab(False, True, ctxMenuAcad)
            _fAca = CType(dgDatosAca.SelectedRows(0).DataBoundItem, DataRowView).Row
            cmbNivel.SelectedValue = _fAca("id_nivel_educativo")
            textTitulo.Text = _fAca.Item("nombtitulo")
            If _fAca("fecha") IsNot DBNull.Value Then
                dpFecha.Value = _fAca.Item("fecha")

            End If

            textObservaciones.Text = _fAca.Item("observa")
            cmbNivel.Focus()
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ctxEliminaFa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminarF.Click
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatosFam.SelectedRows.Count > 0 Then
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                filaTemp = CType(dgDatosFam.SelectedRows(0).DataBoundItem, DataRowView).Row
                tbFamiliares.Rows.Remove(filaTemp)
                'verificar si tiene referencia en inscrip
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ctxEliminaAca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxEliminarAca.Click

        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatosAca.SelectedRows.Count > 0 Then
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                filaTemp = CType(dgDatosAca.SelectedRows(0).DataBoundItem, DataRowView).Row
                tbAcademico.Rows.Remove(filaTemp)
                'verificar si tiene referencia en inscrip
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub




    Private Sub mnuModificarCurso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuModificarCurso.Click

        If dgDatosCursos.SelectedRows.Count = 0 Then
            MsgBox("SELECCIONE LA FILA A MODIFICAR", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        If dgDatosCursos.SelectedRows.Count > 0 Then
            opcModiCurso = 1

            ContextoMenuEnab(False, True, ctxMenuCursos)
            _fCursos = CType(dgDatosCursos.SelectedRows(0).DataBoundItem, DataRowView).Row

            TextNombCurso.Text = _fCursos.Item("nombre")
            TextNomInstitucion.Text = _fCursos("institucion")
            cmbMes.SelectedIndex = _fCursos.Item("mes") - 1
            textConanioCurso.Text = _fCursos.Item("año")
            textconObservaCurso.Text = _fCursos.Item("observacion")
            TextNombCurso.Focus()
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub mnuEliminarCurso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEliminarCurso.Click
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatosCursos.SelectedRows.Count > 0 Then
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                filaTemp = CType(dgDatosCursos.SelectedRows(0).DataBoundItem, DataRowView).Row
                tbCurso.Rows.Remove(filaTemp)
                'verificar si tiene referencia en inscrip
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

#End Region
    Private Sub guardar()
        Dim i As Int32
        Dim fechaNac As Date
        Dim zona As Int16
        Dim civil, depto, munic, deptoced, municed, situaE, tipoDoc, nacional, nombAux As String
        Dim arregloBits As New MemoryStream
        Dim paraEmpresa As SqlParameter
        Dim paraEmpleado As SqlParameter
        Dim paraImagen As SqlParameter

        Dim fechaActual As DateTime = DateTime.Now
        'Dim fechaFormato As String = fechaActual.ToString("yyyy/MM/dd")
        lpara.Clear()
        civil = ""
        depto = ""
        munic = ""
        deptoced = ""
        municed = ""
        situaE = ""
        tipoDoc = ""
        nacional = ""


        fechaNac = axFechaNac.Datevalue1.Date

        If cmbZona.Text.Trim <> "" Then
            zona = CInt(cmbZona.Text)
        Else
            zona = 0
        End If

        AsignaElemento(tbDeptoCed, deptoced, cmbDeptoce, 1, True)
        AsignaElemento(tbMunicCed, municed, cmbMunice, 1, True)
        If validetError(textConlApellido1, ep1) And
            validetError(textConlNombre1, ep1) And
            validetError(textDireccion, ep1) And validetError(TextCalle, ep1) And validetError(textNumeroCalle, ep1) And
            validetComilla(textApto, ep1) And validetComilla(TextColonia, ep1) And validetError(cmbDepartamento, ep1) And
            validetError(cmbMunicipio, ep1) And validetError(cmbNacional, ep1) And validetError(cmbPueblo, ep1) And
             validetError(cmbIdentifica, ep1) And validetComilla(TextRegistro, ep1) And validetError(TextNumIde, ep1) And
             validetError(cmbEstadoCivil, ep1) And validetError(cmbSexo, ep1) And validetError(cmbTipoDiscp, ep1) And
             validetError(cmbNivelEducativo, ep1) And validetError(cmbComLing, ep1) And validetError(cmbEstadoCivil, ep1) And
            validetError(cmbSituaEcono, ep1) And validetError(cmbDeptoce, ep1) And validetError(cmbMunice, ep1) And validetError(cmbArea, ep1) Then

            If usaReg = "S" Then
                If Not validetError(TextRegistro, ep1) Then
                    MsgBox("DEBE INGRESAR NUMERO DE REGISTRO DE LA IDENTIFICACION", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                    Exit Sub
                End If
            End If
            AsignaElemento(tbNacional, nacional, cmbNacional, 1, True)
            AsignaElemento(tbDeptos, depto, cmbDepartamento, 1, True)
            AsignaElemento(tbMunics, munic, cmbMunicipio, 1, True)
            AsignaElemento(tbCivil, civil, cmbEstadoCivil, 1, False)
            AsignaElemento(tbSituaEcono, situaE, cmbSituaEcono, 1, True)
            AsignaElemento(tbTipoIde, tipoDoc, cmbIdentifica, 1, True)
            If Not Me.Consulta Then
                cadena = "select count(*) from emplegen where empresa=" & empresa & " and empleado=" & TextEmpleado.Text
                If BuscaEscalar(cadena) > 0 Then
                    MsgBox("NUMERO DE EMPLEADO YA SE ENCUENTRA REGISTRADO, INTENTELO NUEVAMENTE", MsgBoxStyle.Information, "Mensaje del Sistema")
                    TextEmpleado.Text = BuscaEscalar("select coalesce(max(empleado), 0) from emplegen where empresa=" & empresa) + 1
                    Exit Sub
                End If
            End If


            Dim modelo As New cmodelo
            Try
                lpara("empresa") = empresa
                lpara("empleado") = TextEmpleado.Text
                lpara("apellido1") = textConlApellido1.Text
                lpara("apellido2") = textConlApellido2.Text
                lpara("casada") = TextConlCasada.Text
                lpara("nombre1") = textConlNombre1.Text
                lpara("nombre2") = textConlNombre2.Text
                lpara("nombre3") = textConlNombre3.Text
                lpara("direccion") = textDireccion.Text
                lpara("calle") = TextCalle.Text
                lpara("numero") = textNumeroCalle.Text
                lpara("apto") = textApto.Text
                lpara("zona") = zona
                lpara("colonia") = TextColonia.Text
                lpara("deptodir") = depto
                lpara("munidir") = munic
                lpara("telefono") = textTelefono.Text
                lpara("celular") = TextCelular.Text
                lpara("correo") = textCorreo.Text
                lpara("nacional") = nacional
                lpara("etnia") = ""
                lpara("fechaNac") = fechaNac
                lpara("tipoiden") = tipoDoc
                lpara("registro") = TextRegistro.Text
                lpara("numidentica") = TextNumIde.Text
                lpara("deptoced") = deptoced
                lpara("municed") = municed
                lpara("docdocente") = TextDocDocente.Text
                lpara("civil") = civil
                lpara("sexo") = cmbSexo.Text.Substring(0, 1)
                lpara("numseguro") = textNumSocial.Text
                lpara("nit") = textNit.Text
                lpara("economica") = situaE
                lpara("fechai") = fechaActual
                lpara("usuario") = textUsuarios.Text
                lpara("correoi") = textCorreoColegio.Text
                lpara("id_nivel_educativo") = cmbNivelEducativo.SelectedValue
                lpara("id_pueblo_pertenencia") = cmbPueblo.SelectedValue
                lpara("id_comunidad_ling") = cmbComLing.SelectedValue
                lpara("titulo_principal") = TextTituloPrin.Text.ToUpper()
                lpara("id_tipo_discapacidad") = cmbTipoDiscp.SelectedValue
                lpara("id_area") = cmbArea.SelectedValue
                If MsgBox("ESTA SEGURO QUE DESEA INGRESAR ESTE EMPLEADO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then

                    If Not Consulta Then
                        cadena = "insert into emplegen(empresa,empleado,apellido1,apellido2,casada,nombre1,nombre2,nombre3,direccion,calle,numero,apto,zona,colonia,deptodir,munidir,
                                telefono,celular,correo,nacional,etnia,fechanac,tipoiden,registro,numidentica,deptoced,municed,docdocente,civil,sexo,numseguro,nit,economica,fechai,usuario,correoi,
                                id_nivel_educativo, id_pueblo_pertenencia, id_comunidad_ling, titulo_principal, id_tipo_discapacidad,id_area) 
                                values(@empresa,@empleado,@apellido1,@apellido2,@casada,@nombre1,@nombre2,@nombre3,@direccion,@calle,@numero,@apto,@zona,@colonia,@deptodir,@munidir,
                                    @telefono,@celular,@correo,@nacional,@etnia,@fechaNac,@tipoiden,@registro,@numidentica,@deptoced,@municed,@docdocente,@civil,@sexo,@numseguro,@nit,@economica,@fechai,@usuario,@correoi,
                                  @id_nivel_educativo, @id_pueblo_pertenencia, @id_comunidad_ling, @titulo_principal, @id_tipo_discapacidad,@id_area)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    Else

                        cadena = "update  emplegen set apellido1=@apellido1, apellido2=@apellido2 " &
                                 ",casada=@casada,nombre1=@nombre1, nombre2=@nombre2 " &
                                 ",nombre3=@nombre3, direccion=@direccion, calle=@calle " &
                                 ",numero=@numero, apto=@apto, zona=@zona, colonia=@colonia " &
                                 ",deptodir=@deptodir, munidir=@munidir, telefono=@telefono, celular=@celular " &
                                 ",correo=@correo, nacional=@nacional, etnia=@etnia, fechanac=@fechanac " &
                                 ",tipoiden=@tipoiden, registro=@registro, numidentica=@numidentica " &
                                 ",deptoced=@deptoced, municed=@municed, docdocente=@docdocente, civil=@civil " &
                                 ",sexo=@sexo, numseguro=@numseguro, nit=@nit " &
                                 ",economica=@economica, usuario=@usuario " &
                                 ",correoi=@correoi, id_nivel_educativo = @id_nivel_educativo, 
                                   id_pueblo_pertenencia = @id_pueblo_pertenencia, 
                                  id_comunidad_ling = @id_comunidad_ling, titulo_principal = @titulo_principal, 
                                 id_tipo_discapacidad=@id_tipo_discapacidad,id_area=@id_area  where empresa=@empresa and empleado=@empleado"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    End If



                    cadena = "delete from emplefam where empresa=@empresa and empleado=@empleado"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                    For i = 0 To tbFamiliares.Rows.Count - 1
                        lpara.Clear()
                        filaTemp = tbFamiliares.Rows(i)
                        'fechaf = filaTemp.Item(3).ToString("yyyy/MM/dd")
                        lpara("empresa") = empresa
                        lpara("empleado") = TextEmpleado.Text
                        lpara("tipo") = filaTemp.Item(1)
                        lpara("nombreFam") = filaTemp.Item(2)
                        lpara("fechanac") = filaTemp.Item(3)
                        cadena = " insert into EMPLEFAM (empresa,empleado,tipo,nombrefam,fechanac) 
                                   values (@empresa,@empleado,@tipo,@nombreFam,@fechanac)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    Next i

                    cadena = "delete from empleaca where empresa=@empresa and empleado=@empleado"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))


                    For i = 0 To tbAcademico.Rows.Count - 1
                        lpara.Clear()

                        filaTemp = tbAcademico.Rows(i)
                        lpara("empresa") = empresa
                        lpara("empleado") = CInt(TextEmpleado.Text)
                        lpara("id_nivel_educativo") = filaTemp.Item("id_nivel_educativo")
                        lpara("nombre_titulo") = filaTemp.Item("nombtitulo")
                        lpara("fecha") = filaTemp.Item("fecha")
                        lpara("observa") = filaTemp.Item("observa")
                        cadena = " insert into empleaca (empresa,empleado,id_nivel_educativo,nombre_titulo,fecha,observa) 
                                   values (@empresa,@empleado,@id_nivel_educativo,@nombre_titulo,@fecha,@observa)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    Next i

                    cadena = "delete from nom_curso_empleado where empresa=@empresa And empleado =@empleado "
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                    For i = 0 To tbCurso.Rows.Count - 1
                        lpara.Clear()
                        filaTemp = tbCurso.Rows(i)
                        lpara("empresa") = empresa
                        lpara("empleado") = TextEmpleado.Text
                        lpara("nombre") = filaTemp.Item("nombre")
                        lpara("observacion") = filaTemp.Item("observacion")
                        lpara("institucion") = filaTemp.Item("institucion")
                        lpara("mes") = filaTemp.Item("mes")
                        lpara("año") = filaTemp.Item("año")
                        cadena = " insert into nom_curso_empleado (empresa,empleado,nombre,observacion,institucion,mes,año) 
                                   values (@empresa,@empleado,@nombre,@observacion,@institucion,@mes,@año)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    Next i
                    nombAux = textConlNombre1.Text.Trim & " " & textConlApellido1.Text.Trim & " " & textConlApellido2.Text.Trim
                    If nombAux.Length > 60 Then
                        nombAux = nombAux.Substring(0, 60)
                    End If
                    lpara("nombre") = nombAux
                    If Not Me.Consulta Then
                        cadena = "insert auxiliares(empresa,numero,codigo,nombre) 
                              values(@empresa,4,@empleado,@nombre)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    Else
                        cadena = "update auxiliares set nombre=@nombre where empresa=@empresa and numero=4 and codigo=@empleado"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    End If

                    If modelo.Commit() Then
                        GuardarCamposGenericos(CInt(TextEmpleado.Text))

                        If guardaImagen = True Then

                            cadena = "delete from fotoempleado where empresa=@empresa and empleado=@empleado"
                            EjecutarQuery(cadena, ListaParametros(lpara))
                            Try
                                abrir_conexion(cn)
                                comando = New SqlCommand("guardaArchivo", cn)
                                comando.CommandType = CommandType.StoredProcedure
                                paraEmpresa = New SqlParameter("@empresa", empresa)
                                paraEmpleado = New SqlParameter("@empleado", CInt(TextEmpleado.Text))
                                paraImagen = New SqlParameter("@imagen", SqlDbType.Image)
                                paraImagen.Value = ImagenBytes
                                comando.Parameters.Add(paraEmpresa)
                                comando.Parameters.Add(paraImagen)
                                comando.Parameters.Add(paraEmpleado)
                                comando.ExecuteNonQuery()
                                cn.Close()
                            Catch ex As Exception
                                MsgBox("ERROR AL GUARDAR LA IMAGEN, COMPRUEBE EL TIPO DE IMAGEN Y ACTUALICELO EN EL MANTENIMIENTO", MsgBoxStyle.Critical, "Mensaje del Sistema")
                                cn.Close()
                            End Try
                        End If
                        If Not Consulta Then
                            InsertBitacora(9, 1, $"Creación del empleado {TextEmpleado.Text}")
                            limpia()
                        Else
                            InsertBitacora(9, 1, $"Modificación del empleado {TextEmpleado.Text}")
                            habilita_mod(False)
                        End If

                        MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")

                    End If

                End If

            Catch ex As Exception
                MsgBox("Error del Sistema " & ex.Message, MsgBoxStyle.Critical, " Mensaje del Sistema")
                modelo.RollBack()
            End Try
        Else
            MsgBox("LLENE LOS CAMPOS MARCADOS", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub


    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        guardar()
    End Sub

    Private Sub btnImagen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImagen.Click
        AbrirImagen.Title = "GUARDAR ARCHIVO"
        AbrirImagen.Filter = "Todos los Archivos (*.*)|*.*|ARCHIVO DE IMAGEN" &
        "(*.jpg)|*.jpg"
        ' Specify default filter
        AbrirImagen.FilterIndex = 2
        AbrirImagen.ShowDialog()
    End Sub


    Private Sub AbrirImagen_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles AbrirImagen.FileOk
        Dim nombreArchivo As String
        Dim fsFoto As FileStream

        Dim fiFoto As FileInfo
        Try
            'buscamos la imagen a grabar

            'CARGAR FOTOGRAFIA
            nombreArchivo = AbrirImagen.FileName()
            fiFoto = New FileInfo(nombreArchivo)
            If fiFoto.Exists() Then
                fsFoto = New FileStream(nombreArchivo, FileMode.Open)
                ReDim ImagenBytes(fsFoto.Length)
                fsFoto.Read(ImagenBytes, 0, fsFoto.Length)
                imagenCarga = Image.FromStream(fsFoto)
                picBoCuadro.Image = imagenCarga
                fsFoto.Close()
                guardaImagen = True
            Else
                MsgBox("Error al cargar la imagen", MsgBoxStyle.Critical, "Mensaje del Sistema")
                picBoCuadro.Image = Nothing
                guardaImagen = False
            End If
        Catch ex As Exception
            MsgBox("Error al cargar la imagen", MsgBoxStyle.Critical, "Mensaje del Sistema")
            picBoCuadro.Image = Nothing
            guardaImagen = False
        End Try
    End Sub



#Region "CambioCombos"



    Private Sub cmbDepartamento_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDepartamento.SelectedIndexChanged
        lpara.Clear()

        If cmbDepartamento.Text.Trim <> "" Then
            filaTemp = tbDeptos.Rows(cmbDepartamento.SelectedIndex)
            lpara("depto") = filaTemp.Item(1)
            cadena = "SELECT NOMBRE,MUNIC FROM MUNICIPIOS WHERE DEPTO=@depto"
            llena_combo(cadena, cmbMunicipio, ListaParametros(lpara))
            cmbMunicipio.Items.Add("")
            llenaTabla(cadena, tbMunics, ListaParametros(lpara))
        Else
            cmbMunicipio.Items.Clear()
        End If
    End Sub

    Private Sub cmbDeptoCed_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDeptoce.SelectedIndexChanged
        lpara.Clear()

        If cmbDeptoce.Text.Trim <> "" Then
            filaTemp = tbDeptoCed.Rows(cmbDeptoce.SelectedIndex)
            lpara("depto") = filaTemp.Item(1)
            cadena = "SELECT NOMBRE,MUNIC FROM MUNICIPIOS WHERE DEPTO=@depto"
            llena_combo(cadena, cmbMunice, ListaParametros(lpara))
            cmbMunice.Items.Add("")
            llenaTabla(cadena, tbMunicCed, ListaParametros(lpara))
        Else
            cmbMunice.Items.Clear()
        End If
    End Sub


    Private Sub cmbIdentifica_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbIdentifica.SelectedIndexChanged
        If cmbIdentifica.Text.Trim <> "" Then
            usaReg = tbTipoIde.Rows(cmbIdentifica.SelectedIndex).Item(2)
        End If
    End Sub


#End Region


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim finConsulta, cadenaConsulta As String
        finConsulta = " and 1=1"
        GeneraConsulta(TabDatos, finConsulta, "em")
        If TextEmpleado.Text.Trim <> "" Then
            finConsulta = finConsulta & " and empleado=" & TextEmpleado.Text
        End If
        finConsulta = axFechaNac.devuelveConsulta(finConsulta)
        cadenaConsulta = inicioConsulta & finConsulta & " order by empleado asc"
        Mostrar(cadenaConsulta, sender, e)
    End Sub


    Private Sub Mostrar(ByVal subCadena As String, ByVal sender As System.Object, ByVal e As System.EventArgs)



        If llenaTabla(subCadena, tbConsulta) > 0 Then
            btnBuscar.Enabled = False
            TextEmpleado.ReadOnly = True
            axFechaNac.EsModoConsulta = False
            ContextoMenuEnab(True, True, ctxPrincipal)
            indice = 0
            ctxModPri.Visible = True
            TextEmpleado.ReadOnly = True
            LlenarTextBox(0, tbConsulta)
            dgvConsulta.DataSource = tbConsulta
            VistaConsulta(dgvConsulta)
            mostrar_Botones(tbConsulta.Rows.Count, indice, btnSiguiente, btnAtras)
        Else
            MsgBox("NO HAY REGISTROS CON ESTOS CRITERIOS DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            '  btnLimpiar_Click(sender, e)
        End If

    End Sub



    Private Sub LlenarTextBox(ByVal indi As Int32, ByVal tabla As DataTable)
        Dim comando As SqlCommand
        Dim dr As SqlDataReader
        Dim filaCopiar As DataRow
        Dim tbMaestro As New DataTable()
        cadena = ""
        lpara.Clear()
        filaCopiar = tabla.Rows.Item(indi)
        lpara("empleado") = filaCopiar("empleado")
        cadena = inicioConsulta & " and empleado=@empleado "
        If llenaTabla(cadena, tbMaestro, ListaParametros(lpara)) > 0 Then
            filaCopiar = tbMaestro.Rows(0)
            Dim empleado As Int32 = filaCopiar.Item("empleado")

            TextEmpleado.Text = empleado
            textConlApellido1.Text = filaCopiar.Item("apellido1")
            textConlApellido2.Text = filaCopiar.Item("apellido2")
            TextConlCasada.Text = filaCopiar.Item("casada")
            textConlNombre1.Text = filaCopiar.Item("nombre1")
            textConlNombre2.Text = filaCopiar.Item("nombre2")
            textConlNombre3.Text = filaCopiar.Item("nombre3")
            textDireccion.Text = filaCopiar.Item("direccion")
            TextCalle.Text = filaCopiar.Item("calle")
            textNumeroCalle.Text = filaCopiar.Item("numero")
            textApto.Text = filaCopiar.Item("apto")
            cmbZona.SelectedIndex = cmbZona.FindStringExact(filaCopiar.Item("zona").ToString.Trim)

            TextColonia.Text = filaCopiar.Item("colonia")
            BuscaElementoCombo(tbDeptos, filaCopiar.Item("deptodir"), cmbDepartamento, 1, True)

            BuscaElementoCombo(tbMunics, filaCopiar.Item("munidir"), cmbMunicipio, 1, True)

            textTelefono.Text = filaCopiar.Item("telefono")
            TextCelular.Text = filaCopiar.Item("celular")
            textCorreo.Text = filaCopiar.Item("correo")
            BuscaElementoCombo(tbNacional, filaCopiar.Item("nacional"), cmbNacional, 1, True)



            axFechaNac.Datevalue1 = filaCopiar.Item("fechanac")

            BuscaElementoCombo(tbTipoIde, filaCopiar.Item("tipoiden"), cmbIdentifica, 1, True)

            TextRegistro.Text = filaCopiar.Item("registro")
            TextNumIde.Text = filaCopiar.Item("numidentica")
            BuscaElementoCombo(tbDeptoCed, filaCopiar.Item("deptoced"), cmbDeptoce, 1, True)

            BuscaElementoCombo(tbMunicCed, filaCopiar.Item("deptodir"), cmbMunice, 1, True)

            TextDocDocente.Text = filaCopiar.Item("docdocente")
            BuscaElementoCombo(tbCivil, filaCopiar.Item("civil"), cmbEstadoCivil, 1, False)
            If (filaCopiar("id_nivel_educativo") IsNot DBNull.Value) Then
                cmbNivelEducativo.SelectedValue = filaCopiar("id_nivel_educativo")
            Else
                cmbNivelEducativo.SelectedValue = 1
            End If
            cmbPueblo.SelectedValue = filaCopiar("id_pueblo_pertenencia")
            cmbComLing.SelectedValue = filaCopiar("id_comunidad_ling")
            cmbTipoDiscp.SelectedValue = filaCopiar("id_tipo_discapacidad")
            If (filaCopiar("titulo_principal") IsNot DBNull.Value) Then
                TextTituloPrin.Text = filaCopiar("titulo_principal")
            Else
                TextTituloPrin.Clear()
            End If


            If filaCopiar.Item("sexo") = "F" Then
                cmbSexo.SelectedIndex = 1
            ElseIf filaCopiar.Item("sexo") = "M" Then
                cmbSexo.SelectedIndex = 0
            Else
                cmbSexo.Text = ""
            End If

            If Not IsDBNull(filaCopiar.Item("id_area")) AndAlso filaCopiar.Item("id_area") > 0 Then

                cmbArea.SelectedValue = filaCopiar.Item("id_area")
            Else
                cmbArea.SelectedValue = 0
            End If

            textNumSocial.Text = filaCopiar.Item("numseguro")
            textNit.Text = filaCopiar.Item("nit")
            BuscaElementoCombo(tbSituaEcono, filaCopiar.Item("economica"), cmbSituaEcono, 1, True)
            textUsuarios.Text = filaCopiar("usuario")
            TextFechaOp.Text = filaCopiar.Item("fechai")
            textUsuarios.Text = filaCopiar.Item("usuario")
            textCorreoColegio.Text = filaCopiar.Item("correoi")

            lpara("empresa") = empresa
            lpara("empleado") = empleado

            cadena = " select b.puesto, b.nombre, a.fechaing, a.fechaeg, a.observacion " &
                     " from nom_puesto_empleado a " &
                     " inner join puestosper b on a.empresa=b.empresa and a.id_puesto=b.puesto " &
                     " where a.empresa = @empresa And a.empleado = @empleado" &
                     " order by b.puesto asc"

            llenaTabla(cadena, tbPuesto, ListaParametros(lpara))
            'dgDatosPuestos.DataSource = tbPuesto
            'Vista3(dgDatosPuestos)

            iniciliza_detalle(empleado)
            CargarCamposGenericos(empleado)

            Try
                cadena = "select foto from fotoempleado where empresa=@empresa and empleado=@empleado"
                abrir_conexion(cn)
                comando = New SqlCommand(cadena, cn)
                comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
                dr = comando.ExecuteReader()
                If dr.HasRows Then
                    dr.Read()
                    If dr.GetValue(0) IsNot DBNull.Value Then
                        Dim img As Image = Bytes2Image(CType(dr.GetValue(0), Byte()))
                        If img IsNot Nothing Then
                            picBoCuadro.Image = img
                            'picBoCuadro.Image.Save("C:\tempfotos\imagen.jpg")
                            ' Else
                            '   picBoCuadro.Image = Nothing
                        End If
                    Else
                        guardaImagen = False
                    End If
                Else
                    guardaImagen = False
                    picBoCuadro.Image = Nothing
                End If
                dr.Close()
                cn.Close()
            Catch ex As Exception
                MsgBox("Error al cargar imagen " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                guardaImagen = False
                picBoCuadro.Image = Nothing
                dr.Close()
                cn.Close()
            Finally
                comando.Dispose()
            End Try
        End If




    End Sub

    Private Sub Foco(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDepartamento.Enter, cmbMunicipio.Enter, cmbNivel.Enter, cmbZona.Enter, textNit.Enter, textTelefono.Enter, textConlApellido1.Enter, textConlApellido2.Enter, TextConlCasada.Enter, textConlNombre1.Enter, textConlNombre2.Enter, textConlNombre3.Enter, textConlNombre1.Enter, textDireccion.Enter, TextCalle.Enter, textApto.Enter, textNumeroCalle.Enter, TextColonia.Enter, textTelefono.Enter, TextCelular.Enter, textCorreo.Enter, cmbNacional.Enter, cmbEstadoCivil.Enter, cmbPueblo.Enter, cmbIdentifica.Enter, TextRegistro.Enter, TextNumIde.Enter, cmbDeptoce.Enter, cmbMunice.Enter, textNumSocial.Enter, cmbSituaEcono.Enter, TextDocDocente.Enter, cmbTipo.Enter, TextNombFam.Enter, cmbNivel.Enter, textObservaciones.Enter
        activa(sender)
    End Sub



    Private Sub Deja(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDepartamento.Leave, cmbMunicipio.Leave, cmbNivel.Leave, cmbZona.Leave, textNit.Leave, textTelefono.Leave, textConlApellido1.Leave, textConlApellido2.Leave, TextConlCasada.Leave, textConlNombre1.Leave, textConlNombre2.Leave, textConlNombre3.Leave, textConlNombre1.Leave, textDireccion.Leave, TextCalle.Leave, textApto.Leave, textNumeroCalle.Leave, TextColonia.Leave, textTelefono.Leave, TextCelular.Leave, textCorreo.Leave, cmbNacional.Leave, cmbEstadoCivil.Leave, cmbPueblo.Leave, cmbIdentifica.Leave, TextRegistro.Leave, TextNumIde.Leave, cmbDeptoce.Leave, cmbMunice.Leave, textNumSocial.Leave, cmbSituaEcono.Leave, TextDocDocente.Leave, cmbTipo.Leave, TextNombFam.Leave, cmbNivel.Leave, textObservaciones.Leave
        desactiva(sender)
    End Sub


    Private Sub frmDatosGen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub dgvConsulta_DoubleClick(sender As Object, e As EventArgs) Handles dgvConsulta.DoubleClick
        If (dgvConsulta.SelectedRows.Count > 0) Then
            Dim f As DataRow = CType(dgvConsulta.SelectedRows(0).DataBoundItem, DataRowView).Row
            Dim indi As Int32 = tbConsulta.Rows.IndexOf(f)
            indice = indi
            LlenarTextBox(indice, tbConsulta)
            mostrar_Botones(tbConsulta.Rows.Count, indice, btnSiguiente, btnAtras)
            TabCPrincipal.SelectedTab = TabPri
        End If
    End Sub

    Private Sub ctxModPri_Click(sender As Object, e As EventArgs) Handles ctxModPri.Click
        habilita_mod(True)
    End Sub




    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub






    Private Sub btnAgregarCurso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregarCurso.Click
        If validetError(TextNombCurso, ep1) = False Or validetComilla(TextNombCurso, ep1) = False _
           Or validetError(cmbMes, ep1) = False Or validetError(textConanioCurso, ep1) = False Then
            MsgBox("VERIFIQUE INGRESO DE CAMPOS ", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If opcModiCurso = 0 Then
            filaTemp = tbCurso.NewRow()
        Else
            filaTemp = _fCursos
        End If
        filaTemp.Item("institucion") = TextNomInstitucion.Text
        filaTemp.Item("nombre") = TextNombCurso.Text
        filaTemp.Item("observacion") = textconObservaCurso.Text
        filaTemp.Item("mes") = cmbMes.SelectedIndex + 1 'textConMesCurso.Text
        filaTemp.Item("año") = textConanioCurso.Text


        If opcModiCurso = 0 Then
            tbCurso.Rows.Add(filaTemp)
        End If
        MueveScrollView(dgDatosCursos, tbCurso.Rows.Count - 1)
        btnCancelarCurso_Click(sender, e)
    End Sub



    Private Sub btnSig_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSiguiente.Click
        indice = indice + 1
        LlenarTextBox(indice, tbConsulta)
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSiguiente, btnAtras)
    End Sub

    Private Sub btnAtr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAtras.Click
        indice = indice - 1
        LlenarTextBox(indice, tbConsulta)
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSiguiente, btnAtras)
    End Sub

    Private Sub GuardarCamposGenericos(IdEmpleado As Integer)


        Dim valor As String

        For Each campo As CampoEmpleado In ListaCampos

            valor = ""
            Select Case campo.Tipo
                Case "T", "M"
                    valor = CType(campo.Control, TextBox).Text.Trim
                Case "N"
                    valor = CType(campo.Control, NumericUpDown).Value.ToString
                Case "D"
                    valor = CType(campo.Control, NumericUpDown).Value.ToString.Replace(",", ".")
                Case "F"
                    valor = CType(campo.Control, DateTimePicker).Value.ToString("yyyy-MM-dd")
                Case "K"
                    valor = If(CType(campo.Control, CheckBox).Checked, "1", "0")
                Case "L"
                    If CType(campo.Control, ComboBox).SelectedValue IsNot Nothing Then
                        valor = CType(campo.Control, ComboBox).SelectedValue.ToString
                    End If

            End Select
            lpara.Clear()
            lpara("empleado") = IdEmpleado
            lpara("idcampo") = campo.IdCampo
            lpara("valor") = valor.Replace("'", "''")
            lpara("empresa") = empresa
            cadena = "if exists(select * from emplegen_valores
                    where empleado=@empleado and id_campo=@idcampo)
                begin
                    update emplegen_valores set valor=@valor
                    where empleado=@empleado and id_campo=@idcampo and empresa=@empresa
                    end else begin
                    insert into emplegen_valores(empleado,id_campo,valor,empresa)
                    values (@empleado,@idcampo,@valor,@empresa) end"
            EjecutarQuery(cadena, ListaParametros(lpara))

        Next

    End Sub

    Private Sub CargarCamposGenericos(Optional IdEmpleado As Integer = 0)

        flPanel1.Controls.Clear()
        ListaCampos.Clear()

        Dim dt As New DataTable
        Dim sql As String

        If IdEmpleado = 0 Then

            sql = "SELECT id_campo,nombre_campo,tipo_campo,titulo_campo,longitud  FROM emplegen_campos WHERE activo=1
             ORDER BY id_campo,nombre_campo"

        Else
            lpara("empleado") = IdEmpleado
            sql = "SELECT c.id_campo,c.nombre_campo,c.tipo_campo,titulo_campo,longitud,ISNULL(v.valor,'') valor
                   FROM emplegen_campos c
                   LEFT JOIN emplegen_valores v ON c.id_campo=v.id_campo AND v.empleado=@empleado
                   WHERE c.activo=1 ORDER BY c.id_campo,c.nombre_campo"

        End If

        llenaTabla(sql, dt, ListaParametros(lpara))

        For Each dr As DataRow In dt.Rows

            CrearCampo(dr)
        Next

    End Sub

    Private Sub CrearCampo(dr As DataRow)

        Dim lbl As New Label
        lbl.Text = dr("titulo_campo").ToString
        lbl.Width = 180
        lbl.TextAlign = ContentAlignment.MiddleLeft
        lbl.Margin = New Padding(5, 8, 5, 2)
        flPanel1.Controls.Add(lbl)

        Dim ctrl As Control = Nothing

        Select Case dr("tipo_campo").ToString

            Case "T"
                Dim txt As New TextBox
                txt.Width = 350
                txt.MaxLength = dr("longitud")
                If dr.Table.Columns.Contains("valor") Then
                    txt.Text = dr("valor").ToString
                End If
                ctrl = txt
            Case "N"
                Dim num As New NumericUpDown
                num.Width = 120
                num.Maximum = 999999999
                If dr.Table.Columns.Contains("valor") Then
                    Dim v As Decimal
                    Decimal.TryParse(dr("valor").ToString, v)
                    num.Value = v
                End If
                ctrl = num
            Case "F"
                Dim fecha As New DateTimePicker
                fecha.Width = 150
                If dr.Table.Columns.Contains("valor") Then
                    Dim f As Date
                    If Date.TryParse(dr("valor").ToString, f) Then
                        fecha.Value = f
                    End If
                End If
                ctrl = fecha
            Case "K"
                Dim chk As New CheckBox
                chk.Width = 20
                If dr.Table.Columns.Contains("valor") Then
                    chk.Checked = dr("valor").ToString = "1"
                End If
                ctrl = chk
            Case "M"
                Dim txt As New TextBox
                txt.Multiline = True
                txt.Width = 350
                txt.Height = 80
                txt.MaxLength = dr("longitud")
                txt.ScrollBars = ScrollBars.Vertical
                If dr.Table.Columns.Contains("valor") Then
                    txt.Text = dr("valor").ToString
                End If
                ctrl = txt
        End Select
        ctrl.Tag = dr("id_campo")
        flPanel1.Controls.Add(ctrl)

        ListaCampos.Add(New CampoEmpleado With {
            .IdCampo = CInt(dr("id_campo")),
            .Nombre = dr("nombre_campo").ToString,
            .Tipo = dr("tipo_campo").ToString,
            .Control = ctrl
        })

    End Sub

    Private Sub LimpiarCamposGenericos()

        ListaCampos.Clear()
        flPanel1.Controls.Clear()

    End Sub







End Class
