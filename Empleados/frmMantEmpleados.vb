Imports System.Data.SqlClient
Imports System.IO
'Imports CrystalDecisions.CrystalReports.Engine

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMMANTEMPLEADOS.VB MIEMBRO DE NOMINA.SLN                                   **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmMantEmpleados
    Inherits Form
   
    Dim cadena As String
    Dim tbDeptos As New DataTable("Departamentos")
    Dim tbMunics As New DataTable("Municipios")
    Dim tbCivil As New DataTable("EstadoCP")
    Dim tbTiP1 As New DataTable("TituloP1")
    Dim tbTiP2 As New DataTable("TituloP2")
    Dim filaTemp As DataRow
    Dim tbDeptoCed As New DataTable("deptoCed")
    Dim tbMunicCed As New DataTable("municCed")
    Dim tbFamiliares As New DataTable("familiares")
    Dim tbAcademico As New DataTable("academicos")
    Dim tbNacional As New DataTable("nacional")
    Dim tbTipoIde As New DataTable("tipoIde")
    Dim tbSituaEcono As New DataTable("situaEcono")
    Dim titulo As New DataTable("Titulos")
    Dim tbConsulta As New DataTable("consulta")
    Dim indice As Int32
    Dim opcModiAca, opcModiFa, IndiceAca, IndiceFam, IndicePuesto, opcModiPuesto, IndiceCurso, opcModiCurso As Int16
    Dim usaReg As String
    Dim imagenBytes() As Byte
    Dim guardaImagen As Boolean
    Dim WithEvents fEMp As frmMuestra2Columnas
    Dim tbPuesto As New DataTable("puesto")
    Dim tbCurso As New DataTable("curso")
    Dim tbPuesto2 As New DataTable("puesto2")
    Dim tbCurso2 As New DataTable("curso2")
    Dim tbmes As New DataTable("mes")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim tbArea As New DataTable("area")


    Dim colegio As Char

    Dim inicioConsulta As String = "select empleado, apellido1, apellido2, casada, nombre1, nombre2,nombre3,direccion, calle,numero, apto," &
                                   "zona,colonia, deptodir,munidir,telefono,celular,correo,nacional, etnia, fechanac, tipoiden, registro," &
                                   "numidentica,deptoced,municed,docdocente, civil,sexo, numseguro, nit, economica,fechai,usuario,correoi,id_area from emplegen em " &
                                   "where empresa=" & empresa
    Dim consultaFecha As String


    Dim WithEvents f As frmConsultaFechas
    Friend WithEvents gpCurso As GroupBox
    Friend WithEvents Label41 As Label
    Friend WithEvents TextNomInstitucion As TextBox
    Friend WithEvents Label40 As Label
    Friend WithEvents lbmes As Label
    Friend WithEvents cmbMes As ComboBox
    Friend WithEvents textConanioCurso As TextBox
    Friend WithEvents TextNombCurso As TextBox
    Friend WithEvents btnCancelarCurso As Button
    Friend WithEvents btnAgregarCurso As Button
    Friend WithEvents Label20 As Label
    Friend WithEvents Label38 As Label
    Friend WithEvents textconObservaCurso As TextBox
    Friend WithEvents dgDatosCursos As DataGridView
    Friend WithEvents cmbArea As ComboBox
    Friend WithEvents Label53 As Label
    Friend WithEvents TabCamposEsp As TabPage
    Friend WithEvents flPanel1 As FlowLayoutPanel
    Dim lpara As New Dictionary(Of String, Object)
    Dim tbCamposEsp As New DataTable
    Private ListaCampos As New List(Of CampoEmpleado)


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

    Friend WithEvents ctxMenu1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxModificarF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxEliminarF As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxMenu2 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxModificarAca As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxEliminarAca As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents textObservaciones As System.Windows.Forms.TextBox
    Friend WithEvents TextDocDocente As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
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
    Friend WithEvents textFechaNac As System.Windows.Forms.MaskedTextBox
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
    Friend WithEvents cmbEtnia As System.Windows.Forms.ComboBox
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
    Friend WithEvents textFechaNFam As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents dgDatosFam As System.Windows.Forms.DataGridView
    Friend WithEvents dgDatosAca As System.Windows.Forms.DataGridView
    Friend WithEvents gpDatosAca As System.Windows.Forms.GroupBox
    Friend WithEvents btnAgregarAc As System.Windows.Forms.Button
    Friend WithEvents btnCancelarAca As System.Windows.Forms.Button
    Friend WithEvents textFechaAca As System.Windows.Forms.MaskedTextBox
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
    Friend WithEvents TextFechaOp As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnFecha As System.Windows.Forms.Button
    Friend WithEvents ctxPrincipal As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ctxModPri As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TextSituaEcono As System.Windows.Forms.TextBox
    Friend WithEvents TextMunice As System.Windows.Forms.TextBox
    Friend WithEvents TextEstadoCivil As System.Windows.Forms.TextBox
    Friend WithEvents TextNacional As System.Windows.Forms.TextBox
    Friend WithEvents TextMunicipio As System.Windows.Forms.TextBox
    Friend WithEvents TextDepartamento As System.Windows.Forms.TextBox
    Friend WithEvents TextZona As System.Windows.Forms.TextBox
    Friend WithEvents TextEtnia As System.Windows.Forms.TextBox
    Friend WithEvents TextSexo As System.Windows.Forms.TextBox
    Friend WithEvents TextIdentifica As System.Windows.Forms.TextBox
    Friend WithEvents TextDeptoce As System.Windows.Forms.TextBox
    Friend WithEvents TextAvisoFecha As System.Windows.Forms.TextBox
    Friend WithEvents tabDatos As System.Windows.Forms.TabControl
    Friend WithEvents TbGeneral As System.Windows.Forms.TabPage
    Friend WithEvents TbFam As System.Windows.Forms.TabPage
    Friend WithEvents TbAcade As System.Windows.Forms.TabPage
    Friend WithEvents cmbNivel As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbTitulo As System.Windows.Forms.ComboBox
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
    Friend WithEvents btnSiguiente As System.Windows.Forms.Button
    Friend WithEvents btnAtras As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnImagen As System.Windows.Forms.Button
    Friend WithEvents picBoCuadro As System.Windows.Forms.PictureBox
    Friend WithEvents AbrirImagen As System.Windows.Forms.OpenFileDialog
    Friend WithEvents tabPuesto As System.Windows.Forms.TabPage
    Friend WithEvents tbCursos As System.Windows.Forms.TabPage
    Friend WithEvents dgDatosPuestos As System.Windows.Forms.DataGridView
    Friend WithEvents ctxmenu3 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuModificarPuesto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuElimniarPuesto As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ctxmenu4 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents mnuModificarCurso As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents mnuEliminarCurso As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents textUsuarios As System.Windows.Forms.TextBox
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents textCorreoColegio As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMantEmpleados))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabDatos = New System.Windows.Forms.TabControl()
        Me.TbGeneral = New System.Windows.Forms.TabPage()
        Me.ctxPrincipal = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModPri = New System.Windows.Forms.ToolStripMenuItem()
        Me.cmbArea = New System.Windows.Forms.ComboBox()
        Me.Label53 = New System.Windows.Forms.Label()
        Me.textCorreoColegio = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.textUsuarios = New System.Windows.Forms.TextBox()
        Me.Label39 = New System.Windows.Forms.Label()
        Me.btnImagen = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.picBoCuadro = New System.Windows.Forms.PictureBox()
        Me.TextAvisoFecha = New System.Windows.Forms.TextBox()
        Me.TextZona = New System.Windows.Forms.TextBox()
        Me.TextEtnia = New System.Windows.Forms.TextBox()
        Me.TextSexo = New System.Windows.Forms.TextBox()
        Me.TextIdentifica = New System.Windows.Forms.TextBox()
        Me.TextDeptoce = New System.Windows.Forms.TextBox()
        Me.TextSituaEcono = New System.Windows.Forms.TextBox()
        Me.TextMunice = New System.Windows.Forms.TextBox()
        Me.TextEstadoCivil = New System.Windows.Forms.TextBox()
        Me.TextNacional = New System.Windows.Forms.TextBox()
        Me.TextMunicipio = New System.Windows.Forms.TextBox()
        Me.TextDepartamento = New System.Windows.Forms.TextBox()
        Me.btnFecha = New System.Windows.Forms.Button()
        Me.TextFechaOp = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
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
        Me.cmbEtnia = New System.Windows.Forms.ComboBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.cmbSexo = New System.Windows.Forms.ComboBox()
        Me.Label44 = New System.Windows.Forms.Label()
        Me.textFechaNac = New System.Windows.Forms.MaskedTextBox()
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
        Me.TbAcade = New System.Windows.Forms.TabPage()
        Me.dgDatosFam = New System.Windows.Forms.DataGridView()
        Me.ctxMenu1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModificarF = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEliminarF = New System.Windows.Forms.ToolStripMenuItem()
        Me.gpDatosFam = New System.Windows.Forms.GroupBox()
        Me.btnAgregar = New System.Windows.Forms.Button()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.textFechaNFam = New System.Windows.Forms.MaskedTextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.TextNombFam = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cmbTipo = New System.Windows.Forms.ComboBox()
        Me.TbFam = New System.Windows.Forms.TabPage()
        Me.dgDatosAca = New System.Windows.Forms.DataGridView()
        Me.ctxMenu2 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ctxModificarAca = New System.Windows.Forms.ToolStripMenuItem()
        Me.ctxEliminarAca = New System.Windows.Forms.ToolStripMenuItem()
        Me.gpDatosAca = New System.Windows.Forms.GroupBox()
        Me.textObservaciones = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.btnAgregarAc = New System.Windows.Forms.Button()
        Me.cmbTitulo = New System.Windows.Forms.ComboBox()
        Me.btnCancelarAca = New System.Windows.Forms.Button()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.textFechaAca = New System.Windows.Forms.MaskedTextBox()
        Me.cmbNivel = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tabPuesto = New System.Windows.Forms.TabPage()
        Me.dgDatosPuestos = New System.Windows.Forms.DataGridView()
        Me.ctxmenu3 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuModificarPuesto = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuElimniarPuesto = New System.Windows.Forms.ToolStripMenuItem()
        Me.tbCursos = New System.Windows.Forms.TabPage()
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
        Me.dgDatosCursos = New System.Windows.Forms.DataGridView()
        Me.ctxmenu4 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.mnuModificarCurso = New System.Windows.Forms.ToolStripMenuItem()
        Me.mnuEliminarCurso = New System.Windows.Forms.ToolStripMenuItem()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSiguiente = New System.Windows.Forms.Button()
        Me.btnAtras = New System.Windows.Forms.Button()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
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
        Me.TabCamposEsp = New System.Windows.Forms.TabPage()
        Me.flPanel1 = New System.Windows.Forms.FlowLayoutPanel()
        Me.tabDatos.SuspendLayout()
        Me.TbGeneral.SuspendLayout()
        Me.ctxPrincipal.SuspendLayout()
        CType(Me.picBoCuadro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TbAcade.SuspendLayout()
        CType(Me.dgDatosFam, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu1.SuspendLayout()
        Me.gpDatosFam.SuspendLayout()
        Me.TbFam.SuspendLayout()
        CType(Me.dgDatosAca, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxMenu2.SuspendLayout()
        Me.gpDatosAca.SuspendLayout()
        Me.tabPuesto.SuspendLayout()
        CType(Me.dgDatosPuestos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmenu3.SuspendLayout()
        Me.tbCursos.SuspendLayout()
        Me.gpCurso.SuspendLayout()
        CType(Me.dgDatosCursos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ctxmenu4.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gpEmpresa.SuspendLayout()
        Me.gpEmpleado.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.TabCamposEsp.SuspendLayout()
        Me.SuspendLayout()
        '
        'tabDatos
        '
        Me.tabDatos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tabDatos.Controls.Add(Me.TbGeneral)
        Me.tabDatos.Controls.Add(Me.TbAcade)
        Me.tabDatos.Controls.Add(Me.TbFam)
        Me.tabDatos.Controls.Add(Me.tabPuesto)
        Me.tabDatos.Controls.Add(Me.tbCursos)
        Me.tabDatos.Controls.Add(Me.TabCamposEsp)
        Me.tabDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tabDatos.Location = New System.Drawing.Point(8, 64)
        Me.tabDatos.Name = "tabDatos"
        Me.tabDatos.SelectedIndex = 0
        Me.tabDatos.Size = New System.Drawing.Size(1114, 476)
        Me.tabDatos.TabIndex = 3
        '
        'TbGeneral
        '
        Me.TbGeneral.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TbGeneral.ContextMenuStrip = Me.ctxPrincipal
        Me.TbGeneral.Controls.Add(Me.cmbArea)
        Me.TbGeneral.Controls.Add(Me.Label53)
        Me.TbGeneral.Controls.Add(Me.textCorreoColegio)
        Me.TbGeneral.Controls.Add(Me.Label1)
        Me.TbGeneral.Controls.Add(Me.textUsuarios)
        Me.TbGeneral.Controls.Add(Me.Label39)
        Me.TbGeneral.Controls.Add(Me.btnImagen)
        Me.TbGeneral.Controls.Add(Me.picBoCuadro)
        Me.TbGeneral.Controls.Add(Me.TextAvisoFecha)
        Me.TbGeneral.Controls.Add(Me.TextZona)
        Me.TbGeneral.Controls.Add(Me.TextEtnia)
        Me.TbGeneral.Controls.Add(Me.TextSexo)
        Me.TbGeneral.Controls.Add(Me.TextIdentifica)
        Me.TbGeneral.Controls.Add(Me.TextDeptoce)
        Me.TbGeneral.Controls.Add(Me.TextSituaEcono)
        Me.TbGeneral.Controls.Add(Me.TextMunice)
        Me.TbGeneral.Controls.Add(Me.TextEstadoCivil)
        Me.TbGeneral.Controls.Add(Me.TextNacional)
        Me.TbGeneral.Controls.Add(Me.TextMunicipio)
        Me.TbGeneral.Controls.Add(Me.TextDepartamento)
        Me.TbGeneral.Controls.Add(Me.btnFecha)
        Me.TbGeneral.Controls.Add(Me.TextFechaOp)
        Me.TbGeneral.Controls.Add(Me.Label10)
        Me.TbGeneral.Controls.Add(Me.TextDocDocente)
        Me.TbGeneral.Controls.Add(Me.Label9)
        Me.TbGeneral.Controls.Add(Me.Label6)
        Me.TbGeneral.Controls.Add(Me.TextConlCasada)
        Me.TbGeneral.Controls.Add(Me.cmbSituaEcono)
        Me.TbGeneral.Controls.Add(Me.Label51)
        Me.TbGeneral.Controls.Add(Me.cmbDeptoce)
        Me.TbGeneral.Controls.Add(Me.Label49)
        Me.TbGeneral.Controls.Add(Me.cmbMunice)
        Me.TbGeneral.Controls.Add(Me.Label50)
        Me.TbGeneral.Controls.Add(Me.cmbEstadoCivil)
        Me.TbGeneral.Controls.Add(Me.Label36)
        Me.TbGeneral.Controls.Add(Me.Label48)
        Me.TbGeneral.Controls.Add(Me.TextNumIde)
        Me.TbGeneral.Controls.Add(Me.Label47)
        Me.TbGeneral.Controls.Add(Me.TextRegistro)
        Me.TbGeneral.Controls.Add(Me.cmbIdentifica)
        Me.TbGeneral.Controls.Add(Me.Label46)
        Me.TbGeneral.Controls.Add(Me.cmbEtnia)
        Me.TbGeneral.Controls.Add(Me.Label45)
        Me.TbGeneral.Controls.Add(Me.cmbSexo)
        Me.TbGeneral.Controls.Add(Me.Label44)
        Me.TbGeneral.Controls.Add(Me.textFechaNac)
        Me.TbGeneral.Controls.Add(Me.Label43)
        Me.TbGeneral.Controls.Add(Me.cmbNacional)
        Me.TbGeneral.Controls.Add(Me.Label42)
        Me.TbGeneral.Controls.Add(Me.Label18)
        Me.TbGeneral.Controls.Add(Me.textCorreo)
        Me.TbGeneral.Controls.Add(Me.Label35)
        Me.TbGeneral.Controls.Add(Me.TextCelular)
        Me.TbGeneral.Controls.Add(Me.Label34)
        Me.TbGeneral.Controls.Add(Me.TextColonia)
        Me.TbGeneral.Controls.Add(Me.Label33)
        Me.TbGeneral.Controls.Add(Me.textApto)
        Me.TbGeneral.Controls.Add(Me.Label27)
        Me.TbGeneral.Controls.Add(Me.textNumeroCalle)
        Me.TbGeneral.Controls.Add(Me.Label24)
        Me.TbGeneral.Controls.Add(Me.TextCalle)
        Me.TbGeneral.Controls.Add(Me.Label21)
        Me.TbGeneral.Controls.Add(Me.textConlNombre3)
        Me.TbGeneral.Controls.Add(Me.Label22)
        Me.TbGeneral.Controls.Add(Me.textConlNombre2)
        Me.TbGeneral.Controls.Add(Me.Label23)
        Me.TbGeneral.Controls.Add(Me.textConlNombre1)
        Me.TbGeneral.Controls.Add(Me.Label25)
        Me.TbGeneral.Controls.Add(Me.textConlApellido2)
        Me.TbGeneral.Controls.Add(Me.Label26)
        Me.TbGeneral.Controls.Add(Me.textConlApellido1)
        Me.TbGeneral.Controls.Add(Me.textNumSocial)
        Me.TbGeneral.Controls.Add(Me.Label2)
        Me.TbGeneral.Controls.Add(Me.textNit)
        Me.TbGeneral.Controls.Add(Me.Label37)
        Me.TbGeneral.Controls.Add(Me.Label32)
        Me.TbGeneral.Controls.Add(Me.textTelefono)
        Me.TbGeneral.Controls.Add(Me.cmbDepartamento)
        Me.TbGeneral.Controls.Add(Me.Label31)
        Me.TbGeneral.Controls.Add(Me.cmbMunicipio)
        Me.TbGeneral.Controls.Add(Me.Label30)
        Me.TbGeneral.Controls.Add(Me.cmbZona)
        Me.TbGeneral.Controls.Add(Me.Label29)
        Me.TbGeneral.Controls.Add(Me.Label28)
        Me.TbGeneral.Controls.Add(Me.textDireccion)
        Me.TbGeneral.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbGeneral.Location = New System.Drawing.Point(4, 22)
        Me.TbGeneral.Name = "TbGeneral"
        Me.TbGeneral.Size = New System.Drawing.Size(1106, 450)
        Me.TbGeneral.TabIndex = 3
        Me.TbGeneral.Text = "Datos generales"
        Me.TbGeneral.Visible = False
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
        Me.cmbArea.Location = New System.Drawing.Point(72, 360)
        Me.cmbArea.Name = "cmbArea"
        Me.cmbArea.Size = New System.Drawing.Size(287, 21)
        Me.cmbArea.TabIndex = 37
        '
        'Label53
        '
        Me.Label53.AutoSize = True
        Me.Label53.BackColor = System.Drawing.Color.Transparent
        Me.Label53.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label53.Location = New System.Drawing.Point(17, 368)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(32, 13)
        Me.Label53.TabIndex = 141
        Me.Label53.Text = "Área:"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textCorreoColegio
        '
        Me.textCorreoColegio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textCorreoColegio.BackColor = System.Drawing.Color.White
        Me.textCorreoColegio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textCorreoColegio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textCorreoColegio.Location = New System.Drawing.Point(805, 377)
        Me.textCorreoColegio.MaxLength = 50
        Me.textCorreoColegio.Name = "textCorreoColegio"
        Me.textCorreoColegio.Size = New System.Drawing.Size(261, 20)
        Me.textCorreoColegio.TabIndex = 38
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(644, 381)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 13)
        Me.Label1.TabIndex = 128
        Me.Label1.Text = "Correo electrónico institucional:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textUsuarios
        '
        Me.textUsuarios.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textUsuarios.BackColor = System.Drawing.Color.White
        Me.textUsuarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textUsuarios.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textUsuarios.Location = New System.Drawing.Point(72, 327)
        Me.textUsuarios.MaxLength = 30
        Me.textUsuarios.Name = "textUsuarios"
        Me.textUsuarios.Size = New System.Drawing.Size(271, 20)
        Me.textUsuarios.TabIndex = 35
        '
        'Label39
        '
        Me.Label39.AutoSize = True
        Me.Label39.BackColor = System.Drawing.Color.Transparent
        Me.Label39.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label39.Location = New System.Drawing.Point(17, 334)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(46, 13)
        Me.Label39.TabIndex = 127
        Me.Label39.Text = "Usuario:"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnImagen
        '
        Me.btnImagen.BackColor = System.Drawing.SystemColors.Control
        Me.btnImagen.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImagen.ImageKey = "open.png"
        Me.btnImagen.ImageList = Me.ImageNuevos
        Me.btnImagen.Location = New System.Drawing.Point(891, 136)
        Me.btnImagen.Name = "btnImagen"
        Me.btnImagen.Size = New System.Drawing.Size(60, 30)
        Me.btnImagen.TabIndex = 125
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
        Me.picBoCuadro.Location = New System.Drawing.Point(974, 5)
        Me.picBoCuadro.Name = "picBoCuadro"
        Me.picBoCuadro.Size = New System.Drawing.Size(126, 160)
        Me.picBoCuadro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picBoCuadro.TabIndex = 124
        Me.picBoCuadro.TabStop = False
        '
        'TextAvisoFecha
        '
        Me.TextAvisoFecha.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextAvisoFecha.BackColor = System.Drawing.Color.White
        Me.TextAvisoFecha.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextAvisoFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAvisoFecha.Location = New System.Drawing.Point(138, 182)
        Me.TextAvisoFecha.MaxLength = 11
        Me.TextAvisoFecha.Name = "TextAvisoFecha"
        Me.TextAvisoFecha.Size = New System.Drawing.Size(84, 20)
        Me.TextAvisoFecha.TabIndex = 105
        '
        'TextZona
        '
        Me.TextZona.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextZona.BackColor = System.Drawing.Color.White
        Me.TextZona.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextZona.Location = New System.Drawing.Point(805, 150)
        Me.TextZona.MaxLength = 20
        Me.TextZona.Name = "TextZona"
        Me.TextZona.ReadOnly = True
        Me.TextZona.Size = New System.Drawing.Size(48, 20)
        Me.TextZona.TabIndex = 104
        '
        'TextEtnia
        '
        Me.TextEtnia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextEtnia.BackColor = System.Drawing.Color.White
        Me.TextEtnia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextEtnia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEtnia.Location = New System.Drawing.Point(584, 182)
        Me.TextEtnia.MaxLength = 20
        Me.TextEtnia.Name = "TextEtnia"
        Me.TextEtnia.ReadOnly = True
        Me.TextEtnia.Size = New System.Drawing.Size(100, 20)
        Me.TextEtnia.TabIndex = 103
        '
        'TextSexo
        '
        Me.TextSexo.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextSexo.BackColor = System.Drawing.Color.White
        Me.TextSexo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextSexo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSexo.Location = New System.Drawing.Point(377, 182)
        Me.TextSexo.MaxLength = 20
        Me.TextSexo.Name = "TextSexo"
        Me.TextSexo.ReadOnly = True
        Me.TextSexo.Size = New System.Drawing.Size(150, 20)
        Me.TextSexo.TabIndex = 102
        '
        'TextIdentifica
        '
        Me.TextIdentifica.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextIdentifica.BackColor = System.Drawing.Color.White
        Me.TextIdentifica.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextIdentifica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextIdentifica.Location = New System.Drawing.Point(138, 219)
        Me.TextIdentifica.MaxLength = 20
        Me.TextIdentifica.Name = "TextIdentifica"
        Me.TextIdentifica.ReadOnly = True
        Me.TextIdentifica.Size = New System.Drawing.Size(160, 20)
        Me.TextIdentifica.TabIndex = 101
        '
        'TextDeptoce
        '
        Me.TextDeptoce.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextDeptoce.BackColor = System.Drawing.Color.White
        Me.TextDeptoce.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDeptoce.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDeptoce.Location = New System.Drawing.Point(556, 256)
        Me.TextDeptoce.MaxLength = 20
        Me.TextDeptoce.Name = "TextDeptoce"
        Me.TextDeptoce.ReadOnly = True
        Me.TextDeptoce.Size = New System.Drawing.Size(128, 20)
        Me.TextDeptoce.TabIndex = 30
        '
        'TextSituaEcono
        '
        Me.TextSituaEcono.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextSituaEcono.BackColor = System.Drawing.Color.White
        Me.TextSituaEcono.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextSituaEcono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextSituaEcono.Location = New System.Drawing.Point(805, 336)
        Me.TextSituaEcono.MaxLength = 20
        Me.TextSituaEcono.Name = "TextSituaEcono"
        Me.TextSituaEcono.ReadOnly = True
        Me.TextSituaEcono.Size = New System.Drawing.Size(260, 20)
        Me.TextSituaEcono.TabIndex = 36
        '
        'TextMunice
        '
        Me.TextMunice.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextMunice.BackColor = System.Drawing.Color.White
        Me.TextMunice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextMunice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMunice.Location = New System.Drawing.Point(806, 293)
        Me.TextMunice.MaxLength = 20
        Me.TextMunice.Name = "TextMunice"
        Me.TextMunice.ReadOnly = True
        Me.TextMunice.Size = New System.Drawing.Size(260, 20)
        Me.TextMunice.TabIndex = 34
        '
        'TextEstadoCivil
        '
        Me.TextEstadoCivil.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextEstadoCivil.BackColor = System.Drawing.Color.White
        Me.TextEstadoCivil.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextEstadoCivil.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextEstadoCivil.Location = New System.Drawing.Point(806, 256)
        Me.TextEstadoCivil.MaxLength = 20
        Me.TextEstadoCivil.Name = "TextEstadoCivil"
        Me.TextEstadoCivil.ReadOnly = True
        Me.TextEstadoCivil.Size = New System.Drawing.Size(260, 20)
        Me.TextEstadoCivil.TabIndex = 31
        '
        'TextNacional
        '
        Me.TextNacional.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextNacional.BackColor = System.Drawing.Color.White
        Me.TextNacional.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNacional.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNacional.Location = New System.Drawing.Point(807, 219)
        Me.TextNacional.MaxLength = 20
        Me.TextNacional.Name = "TextNacional"
        Me.TextNacional.ReadOnly = True
        Me.TextNacional.Size = New System.Drawing.Size(257, 20)
        Me.TextNacional.TabIndex = 96
        '
        'TextMunicipio
        '
        Me.TextMunicipio.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextMunicipio.BackColor = System.Drawing.Color.White
        Me.TextMunicipio.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextMunicipio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextMunicipio.Location = New System.Drawing.Point(806, 182)
        Me.TextMunicipio.MaxLength = 20
        Me.TextMunicipio.Name = "TextMunicipio"
        Me.TextMunicipio.ReadOnly = True
        Me.TextMunicipio.Size = New System.Drawing.Size(260, 20)
        Me.TextMunicipio.TabIndex = 95
        '
        'TextDepartamento
        '
        Me.TextDepartamento.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextDepartamento.BackColor = System.Drawing.Color.White
        Me.TextDepartamento.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDepartamento.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDepartamento.Location = New System.Drawing.Point(377, 120)
        Me.TextDepartamento.MaxLength = 20
        Me.TextDepartamento.Name = "TextDepartamento"
        Me.TextDepartamento.ReadOnly = True
        Me.TextDepartamento.Size = New System.Drawing.Size(187, 20)
        Me.TextDepartamento.TabIndex = 13
        '
        'btnFecha
        '
        Me.btnFecha.BackColor = System.Drawing.SystemColors.Control
        Me.btnFecha.ImageKey = "fecha.png"
        Me.btnFecha.ImageList = Me.ImageNuevos
        Me.btnFecha.Location = New System.Drawing.Point(234, 176)
        Me.btnFecha.Name = "btnFecha"
        Me.btnFecha.Size = New System.Drawing.Size(40, 30)
        Me.btnFecha.TabIndex = 59
        Me.btnFecha.UseVisualStyleBackColor = False
        '
        'TextFechaOp
        '
        Me.TextFechaOp.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextFechaOp.BackColor = System.Drawing.Color.White
        Me.TextFechaOp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextFechaOp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextFechaOp.Location = New System.Drawing.Point(399, 293)
        Me.TextFechaOp.MaxLength = 15
        Me.TextFechaOp.Name = "TextFechaOp"
        Me.TextFechaOp.ReadOnly = True
        Me.TextFechaOp.Size = New System.Drawing.Size(94, 20)
        Me.TextFechaOp.TabIndex = 33
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.Transparent
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(287, 296)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(105, 13)
        Me.Label10.TabIndex = 93
        Me.Label10.Text = "Fecha de operación:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextDocDocente
        '
        Me.TextDocDocente.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextDocDocente.BackColor = System.Drawing.Color.White
        Me.TextDocDocente.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextDocDocente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextDocDocente.Location = New System.Drawing.Point(138, 293)
        Me.TextDocDocente.MaxLength = 15
        Me.TextDocDocente.Name = "TextDocDocente"
        Me.TextDocDocente.Size = New System.Drawing.Size(136, 20)
        Me.TextDocDocente.TabIndex = 32
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.Transparent
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(17, 296)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(85, 13)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "Cédula docente:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.Transparent
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(576, 5)
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
        Me.TextConlCasada.Location = New System.Drawing.Point(682, 3)
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
        Me.cmbSituaEcono.Location = New System.Drawing.Point(805, 336)
        Me.cmbSituaEcono.Name = "cmbSituaEcono"
        Me.cmbSituaEcono.Size = New System.Drawing.Size(260, 21)
        Me.cmbSituaEcono.TabIndex = 30
        '
        'Label51
        '
        Me.Label51.AutoSize = True
        Me.Label51.BackColor = System.Drawing.Color.Transparent
        Me.Label51.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label51.Location = New System.Drawing.Point(650, 339)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(137, 13)
        Me.Label51.TabIndex = 88
        Me.Label51.Text = "Situación socio económico:"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbDeptoce
        '
        Me.cmbDeptoce.BackColor = System.Drawing.Color.White
        Me.cmbDeptoce.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbDeptoce.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbDeptoce.Location = New System.Drawing.Point(558, 256)
        Me.cmbDeptoce.Name = "cmbDeptoce"
        Me.cmbDeptoce.Size = New System.Drawing.Size(90, 21)
        Me.cmbDeptoce.TabIndex = 26
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.BackColor = System.Drawing.Color.Transparent
        Me.Label49.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label49.Location = New System.Drawing.Point(470, 257)
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
        Me.cmbMunice.Location = New System.Drawing.Point(806, 292)
        Me.cmbMunice.Name = "cmbMunice"
        Me.cmbMunice.Size = New System.Drawing.Size(260, 21)
        Me.cmbMunice.TabIndex = 27
        '
        'Label50
        '
        Me.Label50.AutoSize = True
        Me.Label50.BackColor = System.Drawing.Color.Transparent
        Me.Label50.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label50.Location = New System.Drawing.Point(729, 296)
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
        Me.cmbEstadoCivil.Location = New System.Drawing.Point(806, 255)
        Me.cmbEstadoCivil.Name = "cmbEstadoCivil"
        Me.cmbEstadoCivil.Size = New System.Drawing.Size(260, 21)
        Me.cmbEstadoCivil.TabIndex = 22
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.BackColor = System.Drawing.Color.Transparent
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.Location = New System.Drawing.Point(729, 257)
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
        Me.Label48.Location = New System.Drawing.Point(495, 222)
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
        Me.TextNumIde.Location = New System.Drawing.Point(556, 219)
        Me.TextNumIde.MaxLength = 14
        Me.TextNumIde.Name = "TextNumIde"
        Me.TextNumIde.Size = New System.Drawing.Size(128, 20)
        Me.TextNumIde.TabIndex = 25
        '
        'Label47
        '
        Me.Label47.AutoSize = True
        Me.Label47.BackColor = System.Drawing.Color.Transparent
        Me.Label47.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label47.Location = New System.Drawing.Point(306, 222)
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
        Me.TextRegistro.Location = New System.Drawing.Point(377, 219)
        Me.TextRegistro.MaxLength = 4
        Me.TextRegistro.Name = "TextRegistro"
        Me.TextRegistro.Size = New System.Drawing.Size(87, 20)
        Me.TextRegistro.TabIndex = 24
        '
        'cmbIdentifica
        '
        Me.cmbIdentifica.BackColor = System.Drawing.Color.White
        Me.cmbIdentifica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbIdentifica.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbIdentifica.Location = New System.Drawing.Point(138, 219)
        Me.cmbIdentifica.Name = "cmbIdentifica"
        Me.cmbIdentifica.Size = New System.Drawing.Size(160, 21)
        Me.cmbIdentifica.TabIndex = 23
        '
        'Label46
        '
        Me.Label46.AutoSize = True
        Me.Label46.BackColor = System.Drawing.Color.Transparent
        Me.Label46.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label46.Location = New System.Drawing.Point(17, 222)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(111, 13)
        Me.Label46.TabIndex = 76
        Me.Label46.Text = "Tipo de identificación:"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbEtnia
        '
        Me.cmbEtnia.BackColor = System.Drawing.Color.White
        Me.cmbEtnia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEtnia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEtnia.Items.AddRange(New Object() {"S", "N", ""})
        Me.cmbEtnia.Location = New System.Drawing.Point(585, 182)
        Me.cmbEtnia.Name = "cmbEtnia"
        Me.cmbEtnia.Size = New System.Drawing.Size(53, 21)
        Me.cmbEtnia.TabIndex = 21
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.BackColor = System.Drawing.Color.Transparent
        Me.Label45.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label45.Location = New System.Drawing.Point(542, 184)
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
        Me.cmbSexo.Items.AddRange(New Object() {"MASCULINO", "FEMENINIO", ""})
        Me.cmbSexo.Location = New System.Drawing.Point(377, 182)
        Me.cmbSexo.Name = "cmbSexo"
        Me.cmbSexo.Size = New System.Drawing.Size(150, 21)
        Me.cmbSexo.TabIndex = 20
        '
        'Label44
        '
        Me.Label44.AutoSize = True
        Me.Label44.BackColor = System.Drawing.Color.Transparent
        Me.Label44.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label44.Location = New System.Drawing.Point(287, 184)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(45, 13)
        Me.Label44.TabIndex = 72
        Me.Label44.Text = "Género:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textFechaNac
        '
        Me.textFechaNac.BackColor = System.Drawing.Color.White
        Me.textFechaNac.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFechaNac.Location = New System.Drawing.Point(139, 182)
        Me.textFechaNac.Mask = "##/##/####"
        Me.textFechaNac.Name = "textFechaNac"
        Me.textFechaNac.Size = New System.Drawing.Size(84, 20)
        Me.textFechaNac.TabIndex = 19
        '
        'Label43
        '
        Me.Label43.AutoSize = True
        Me.Label43.BackColor = System.Drawing.Color.Transparent
        Me.Label43.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label43.Location = New System.Drawing.Point(17, 184)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(109, 13)
        Me.Label43.TabIndex = 69
        Me.Label43.Text = "Fecha de nacimiento:"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbNacional
        '
        Me.cmbNacional.BackColor = System.Drawing.Color.White
        Me.cmbNacional.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNacional.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNacional.Location = New System.Drawing.Point(806, 218)
        Me.cmbNacional.Name = "cmbNacional"
        Me.cmbNacional.Size = New System.Drawing.Size(260, 21)
        Me.cmbNacional.TabIndex = 18
        '
        'Label42
        '
        Me.Label42.AutoSize = True
        Me.Label42.BackColor = System.Drawing.Color.Transparent
        Me.Label42.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label42.Location = New System.Drawing.Point(729, 222)
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
        Me.Label18.Location = New System.Drawing.Point(287, 153)
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
        Me.textCorreo.Location = New System.Drawing.Point(390, 150)
        Me.textCorreo.MaxLength = 40
        Me.textCorreo.Name = "textCorreo"
        Me.textCorreo.Size = New System.Drawing.Size(294, 20)
        Me.textCorreo.TabIndex = 17
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.BackColor = System.Drawing.Color.Transparent
        Me.Label35.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label35.Location = New System.Drawing.Point(158, 153)
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
        Me.TextCelular.Location = New System.Drawing.Point(207, 150)
        Me.TextCelular.MaxLength = 8
        Me.TextCelular.Name = "TextCelular"
        Me.TextCelular.Size = New System.Drawing.Size(74, 20)
        Me.TextCelular.TabIndex = 16
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.BackColor = System.Drawing.Color.Transparent
        Me.Label34.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label34.Location = New System.Drawing.Point(17, 122)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(45, 13)
        Me.Label34.TabIndex = 62
        Me.Label34.Text = "Colonia:"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextColonia
        '
        Me.TextColonia.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.TextColonia.BackColor = System.Drawing.SystemColors.Window
        Me.TextColonia.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextColonia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextColonia.Location = New System.Drawing.Point(68, 120)
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
        Me.Label33.Location = New System.Drawing.Point(606, 96)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(70, 13)
        Me.Label33.TabIndex = 60
        Me.Label33.Text = "Apartamento:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textApto
        '
        Me.textApto.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textApto.BackColor = System.Drawing.SystemColors.Window
        Me.textApto.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textApto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textApto.Location = New System.Drawing.Point(686, 93)
        Me.textApto.MaxLength = 8
        Me.textApto.Name = "textApto"
        Me.textApto.Size = New System.Drawing.Size(70, 20)
        Me.textApto.TabIndex = 10
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.BackColor = System.Drawing.Color.Transparent
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(413, 95)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(47, 13)
        Me.Label27.TabIndex = 58
        Me.Label27.Text = "Número:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textNumeroCalle
        '
        Me.textNumeroCalle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.textNumeroCalle.BackColor = System.Drawing.SystemColors.Window
        Me.textNumeroCalle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textNumeroCalle.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textNumeroCalle.Location = New System.Drawing.Point(465, 92)
        Me.textNumeroCalle.MaxLength = 8
        Me.textNumeroCalle.Name = "textNumeroCalle"
        Me.textNumeroCalle.Size = New System.Drawing.Size(99, 20)
        Me.textNumeroCalle.TabIndex = 9
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.BackColor = System.Drawing.Color.Transparent
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(15, 92)
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
        Me.TextCalle.Location = New System.Drawing.Point(54, 89)
        Me.TextCalle.MaxLength = 50
        Me.TextCalle.Name = "TextCalle"
        Me.TextCalle.Size = New System.Drawing.Size(353, 20)
        Me.TextCalle.TabIndex = 8
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.BackColor = System.Drawing.Color.Transparent
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(576, 31)
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
        Me.textConlNombre3.Location = New System.Drawing.Point(683, 30)
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
        Me.Label22.Location = New System.Drawing.Point(298, 31)
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
        Me.textConlNombre2.Location = New System.Drawing.Point(396, 31)
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
        Me.Label23.Location = New System.Drawing.Point(15, 30)
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
        Me.textConlNombre1.Location = New System.Drawing.Point(100, 28)
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
        Me.Label25.Location = New System.Drawing.Point(298, 6)
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
        Me.textConlApellido2.Location = New System.Drawing.Point(396, 3)
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
        Me.Label26.Location = New System.Drawing.Point(15, 5)
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
        Me.textConlApellido1.Location = New System.Drawing.Point(100, 3)
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
        Me.textNumSocial.Location = New System.Drawing.Point(138, 256)
        Me.textNumSocial.MaxLength = 14
        Me.textNumSocial.Name = "textNumSocial"
        Me.textNumSocial.Size = New System.Drawing.Size(160, 20)
        Me.textNumSocial.TabIndex = 28
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(17, 257)
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
        Me.textNit.Location = New System.Drawing.Point(349, 256)
        Me.textNit.MaxLength = 10
        Me.textNit.Name = "textNit"
        Me.textNit.Size = New System.Drawing.Size(115, 20)
        Me.textNit.TabIndex = 29
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.BackColor = System.Drawing.Color.Transparent
        Me.Label37.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label37.Location = New System.Drawing.Point(306, 257)
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
        Me.Label32.Location = New System.Drawing.Point(15, 153)
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
        Me.textTelefono.Location = New System.Drawing.Point(72, 150)
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
        Me.cmbDepartamento.Location = New System.Drawing.Point(377, 119)
        Me.cmbDepartamento.Name = "cmbDepartamento"
        Me.cmbDepartamento.Size = New System.Drawing.Size(187, 21)
        Me.cmbDepartamento.TabIndex = 13
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.BackColor = System.Drawing.Color.Transparent
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(288, 126)
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
        Me.cmbMunicipio.Location = New System.Drawing.Point(807, 179)
        Me.cmbMunicipio.Name = "cmbMunicipio"
        Me.cmbMunicipio.Size = New System.Drawing.Size(259, 21)
        Me.cmbMunicipio.TabIndex = 14
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.BackColor = System.Drawing.Color.Transparent
        Me.Label30.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(729, 184)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(55, 13)
        Me.Label30.TabIndex = 12
        Me.Label30.Text = "Municipio:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbZona
        '
        Me.cmbZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbZona.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbZona.Location = New System.Drawing.Point(805, 149)
        Me.cmbZona.Name = "cmbZona"
        Me.cmbZona.Size = New System.Drawing.Size(48, 21)
        Me.cmbZona.TabIndex = 11
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.BackColor = System.Drawing.Color.Transparent
        Me.Label29.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(727, 153)
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
        Me.Label28.Location = New System.Drawing.Point(15, 63)
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
        Me.textDireccion.Location = New System.Drawing.Point(123, 60)
        Me.textDireccion.MaxLength = 75
        Me.textDireccion.Name = "textDireccion"
        Me.textDireccion.Size = New System.Drawing.Size(441, 20)
        Me.textDireccion.TabIndex = 7
        '
        'TbAcade
        '
        Me.TbAcade.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TbAcade.Controls.Add(Me.dgDatosFam)
        Me.TbAcade.Controls.Add(Me.gpDatosFam)
        Me.TbAcade.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbAcade.Location = New System.Drawing.Point(4, 22)
        Me.TbAcade.Name = "TbAcade"
        Me.TbAcade.Size = New System.Drawing.Size(1106, 450)
        Me.TbAcade.TabIndex = 5
        Me.TbAcade.Text = "Datos de familiares"
        Me.TbAcade.Visible = False
        '
        'dgDatosFam
        '
        Me.dgDatosFam.AllowUserToAddRows = False
        Me.dgDatosFam.AllowUserToDeleteRows = False
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.LightGreen
        Me.dgDatosFam.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgDatosFam.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDatosFam.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatosFam.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgDatosFam.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDatosFam.ContextMenuStrip = Me.ctxMenu1
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDatosFam.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgDatosFam.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgDatosFam.Location = New System.Drawing.Point(9, 57)
        Me.dgDatosFam.MultiSelect = False
        Me.dgDatosFam.Name = "dgDatosFam"
        Me.dgDatosFam.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatosFam.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgDatosFam.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDatosFam.Size = New System.Drawing.Size(1088, 384)
        Me.dgDatosFam.TabIndex = 65
        '
        'ctxMenu1
        '
        Me.ctxMenu1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModificarF, Me.ctxEliminarF})
        Me.ctxMenu1.Name = "ctxMenu"
        Me.ctxMenu1.Size = New System.Drawing.Size(126, 48)
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
        Me.gpDatosFam.Controls.Add(Me.btnAgregar)
        Me.gpDatosFam.Controls.Add(Me.btnCancelar)
        Me.gpDatosFam.Controls.Add(Me.textFechaNFam)
        Me.gpDatosFam.Controls.Add(Me.Label15)
        Me.gpDatosFam.Controls.Add(Me.Label17)
        Me.gpDatosFam.Controls.Add(Me.TextNombFam)
        Me.gpDatosFam.Controls.Add(Me.Label16)
        Me.gpDatosFam.Controls.Add(Me.cmbTipo)
        Me.gpDatosFam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDatosFam.Location = New System.Drawing.Point(9, 8)
        Me.gpDatosFam.Name = "gpDatosFam"
        Me.gpDatosFam.Size = New System.Drawing.Size(1088, 47)
        Me.gpDatosFam.TabIndex = 64
        Me.gpDatosFam.TabStop = False
        Me.gpDatosFam.Text = "Datos de familiares"
        '
        'btnAgregar
        '
        Me.btnAgregar.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregar.ImageKey = "checkok.png"
        Me.btnAgregar.ImageList = Me.ImageNuevos
        Me.btnAgregar.Location = New System.Drawing.Point(955, 13)
        Me.btnAgregar.Name = "btnAgregar"
        Me.btnAgregar.Size = New System.Drawing.Size(60, 30)
        Me.btnAgregar.TabIndex = 4
        Me.btnAgregar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAgregar, "Agregar")
        Me.btnAgregar.UseVisualStyleBackColor = False
        '
        'btnCancelar
        '
        Me.btnCancelar.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelar.ImageKey = "cancelar.png"
        Me.btnCancelar.ImageList = Me.ImageNuevos
        Me.btnCancelar.Location = New System.Drawing.Point(1022, 13)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(60, 30)
        Me.btnCancelar.TabIndex = 5
        Me.btnCancelar.TabStop = False
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelar, "Cancelar")
        Me.btnCancelar.UseVisualStyleBackColor = False
        '
        'textFechaNFam
        '
        Me.textFechaNFam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFechaNFam.Location = New System.Drawing.Point(824, 18)
        Me.textFechaNFam.Mask = "##/##/####"
        Me.textFechaNFam.Name = "textFechaNFam"
        Me.textFechaNFam.Size = New System.Drawing.Size(84, 20)
        Me.textFechaNFam.TabIndex = 3
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(6, 20)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(61, 13)
        Me.Label15.TabIndex = 62
        Me.Label15.Text = "Parentesco"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(707, 22)
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
        Me.TextNombFam.Location = New System.Drawing.Point(286, 18)
        Me.TextNombFam.MaxLength = 50
        Me.TextNombFam.Name = "TextNombFam"
        Me.TextNombFam.Size = New System.Drawing.Size(413, 20)
        Me.TextNombFam.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(232, 22)
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
        Me.cmbTipo.Items.AddRange(New Object() {"PADRE", "MADRE", "CONJUGE", "HIJIO", ""})
        Me.cmbTipo.Location = New System.Drawing.Point(73, 17)
        Me.cmbTipo.Name = "cmbTipo"
        Me.cmbTipo.Size = New System.Drawing.Size(121, 21)
        Me.cmbTipo.TabIndex = 1
        '
        'TbFam
        '
        Me.TbFam.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TbFam.Controls.Add(Me.dgDatosAca)
        Me.TbFam.Controls.Add(Me.gpDatosAca)
        Me.TbFam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TbFam.Location = New System.Drawing.Point(4, 22)
        Me.TbFam.Name = "TbFam"
        Me.TbFam.Size = New System.Drawing.Size(1106, 450)
        Me.TbFam.TabIndex = 4
        Me.TbFam.Text = "Datos academicos"
        '
        'dgDatosAca
        '
        Me.dgDatosAca.AllowUserToAddRows = False
        Me.dgDatosAca.AllowUserToDeleteRows = False
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.LightGreen
        Me.dgDatosAca.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle7
        Me.dgDatosAca.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDatosAca.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatosAca.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dgDatosAca.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDatosAca.ContextMenuStrip = Me.ctxMenu2
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgDatosAca.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgDatosAca.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgDatosAca.Location = New System.Drawing.Point(12, 85)
        Me.dgDatosAca.MultiSelect = False
        Me.dgDatosAca.Name = "dgDatosAca"
        Me.dgDatosAca.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgDatosAca.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgDatosAca.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDatosAca.Size = New System.Drawing.Size(1082, 353)
        Me.dgDatosAca.TabIndex = 66
        '
        'ctxMenu2
        '
        Me.ctxMenu2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ctxModificarAca, Me.ctxEliminarAca})
        Me.ctxMenu2.Name = "ctxMenu"
        Me.ctxMenu2.Size = New System.Drawing.Size(126, 48)
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
        Me.gpDatosAca.Controls.Add(Me.textObservaciones)
        Me.gpDatosAca.Controls.Add(Me.Label8)
        Me.gpDatosAca.Controls.Add(Me.btnAgregarAc)
        Me.gpDatosAca.Controls.Add(Me.cmbTitulo)
        Me.gpDatosAca.Controls.Add(Me.btnCancelarAca)
        Me.gpDatosAca.Controls.Add(Me.Label14)
        Me.gpDatosAca.Controls.Add(Me.textFechaAca)
        Me.gpDatosAca.Controls.Add(Me.cmbNivel)
        Me.gpDatosAca.Controls.Add(Me.Label7)
        Me.gpDatosAca.Controls.Add(Me.Label13)
        Me.gpDatosAca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDatosAca.Location = New System.Drawing.Point(12, 11)
        Me.gpDatosAca.Name = "gpDatosAca"
        Me.gpDatosAca.Size = New System.Drawing.Size(1082, 73)
        Me.gpDatosAca.TabIndex = 65
        Me.gpDatosAca.TabStop = False
        Me.gpDatosAca.Text = "Datos académicos"
        '
        'textObservaciones
        '
        Me.textObservaciones.BackColor = System.Drawing.Color.White
        Me.textObservaciones.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.textObservaciones.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textObservaciones.Location = New System.Drawing.Point(104, 43)
        Me.textObservaciones.MaxLength = 60
        Me.textObservaciones.Name = "textObservaciones"
        Me.textObservaciones.Size = New System.Drawing.Size(569, 20)
        Me.textObservaciones.TabIndex = 73
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(6, 45)
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
        Me.btnAgregarAc.ImageKey = "checkok.png"
        Me.btnAgregarAc.ImageList = Me.ImageNuevos
        Me.btnAgregarAc.Location = New System.Drawing.Point(784, 38)
        Me.btnAgregarAc.Name = "btnAgregarAc"
        Me.btnAgregarAc.Size = New System.Drawing.Size(60, 30)
        Me.btnAgregarAc.TabIndex = 4
        Me.btnAgregarAc.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAgregarAc, "Agregar")
        Me.btnAgregarAc.UseVisualStyleBackColor = False
        '
        'cmbTitulo
        '
        Me.cmbTitulo.BackColor = System.Drawing.Color.White
        Me.cmbTitulo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTitulo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTitulo.Location = New System.Drawing.Point(435, 16)
        Me.cmbTitulo.Name = "cmbTitulo"
        Me.cmbTitulo.Size = New System.Drawing.Size(367, 21)
        Me.cmbTitulo.TabIndex = 2
        '
        'btnCancelarAca
        '
        Me.btnCancelarAca.BackColor = System.Drawing.SystemColors.Control
        Me.btnCancelarAca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCancelarAca.ImageKey = "cancelar.png"
        Me.btnCancelarAca.ImageList = Me.ImageNuevos
        Me.btnCancelarAca.Location = New System.Drawing.Point(852, 38)
        Me.btnCancelarAca.Name = "btnCancelarAca"
        Me.btnCancelarAca.Size = New System.Drawing.Size(60, 30)
        Me.btnCancelarAca.TabIndex = 5
        Me.btnCancelarAca.TabStop = False
        Me.btnCancelarAca.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelarAca, "Cancelar")
        Me.btnCancelarAca.UseVisualStyleBackColor = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(336, 20)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(93, 13)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Título académico:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'textFechaAca
        '
        Me.textFechaAca.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textFechaAca.Location = New System.Drawing.Point(871, 14)
        Me.textFechaAca.Mask = "##/##/####"
        Me.textFechaAca.Name = "textFechaAca"
        Me.textFechaAca.Size = New System.Drawing.Size(84, 20)
        Me.textFechaAca.TabIndex = 3
        '
        'cmbNivel
        '
        Me.cmbNivel.BackColor = System.Drawing.Color.White
        Me.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNivel.Location = New System.Drawing.Point(104, 16)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(208, 21)
        Me.cmbNivel.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(822, 16)
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
        Me.Label13.Location = New System.Drawing.Point(6, 19)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Nivel académico:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tabPuesto
        '
        Me.tabPuesto.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.tabPuesto.Controls.Add(Me.dgDatosPuestos)
        Me.tabPuesto.Location = New System.Drawing.Point(4, 22)
        Me.tabPuesto.Name = "tabPuesto"
        Me.tabPuesto.Size = New System.Drawing.Size(1106, 450)
        Me.tabPuesto.TabIndex = 6
        Me.tabPuesto.Text = "Puesto empleado"
        '
        'dgDatosPuestos
        '
        Me.dgDatosPuestos.AllowUserToAddRows = False
        Me.dgDatosPuestos.AllowUserToDeleteRows = False
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.LightGreen
        Me.dgDatosPuestos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle11
        Me.dgDatosPuestos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDatosPuestos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgDatosPuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDatosPuestos.ContextMenuStrip = Me.ctxmenu3
        Me.dgDatosPuestos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgDatosPuestos.Location = New System.Drawing.Point(12, 36)
        Me.dgDatosPuestos.MultiSelect = False
        Me.dgDatosPuestos.Name = "dgDatosPuestos"
        Me.dgDatosPuestos.ReadOnly = True
        Me.dgDatosPuestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDatosPuestos.Size = New System.Drawing.Size(1082, 402)
        Me.dgDatosPuestos.TabIndex = 9
        '
        'ctxmenu3
        '
        Me.ctxmenu3.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuModificarPuesto, Me.mnuElimniarPuesto})
        Me.ctxmenu3.Name = "ctxMenu"
        Me.ctxmenu3.Size = New System.Drawing.Size(126, 48)
        '
        'mnuModificarPuesto
        '
        Me.mnuModificarPuesto.Image = Global.NOMINA.My.Resources.Resources.edit1
        Me.mnuModificarPuesto.Name = "mnuModificarPuesto"
        Me.mnuModificarPuesto.Size = New System.Drawing.Size(125, 22)
        Me.mnuModificarPuesto.Text = "Modificar"
        '
        'mnuElimniarPuesto
        '
        Me.mnuElimniarPuesto.Image = Global.NOMINA.My.Resources.Resources.menos
        Me.mnuElimniarPuesto.Name = "mnuElimniarPuesto"
        Me.mnuElimniarPuesto.Size = New System.Drawing.Size(125, 22)
        Me.mnuElimniarPuesto.Text = "Eliminar"
        '
        'tbCursos
        '
        Me.tbCursos.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.tbCursos.Controls.Add(Me.gpCurso)
        Me.tbCursos.Controls.Add(Me.dgDatosCursos)
        Me.tbCursos.Location = New System.Drawing.Point(4, 22)
        Me.tbCursos.Name = "tbCursos"
        Me.tbCursos.Size = New System.Drawing.Size(1106, 450)
        Me.tbCursos.TabIndex = 7
        Me.tbCursos.Text = "Cursos empleado"
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
        Me.gpCurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpCurso.Location = New System.Drawing.Point(10, 12)
        Me.gpCurso.Name = "gpCurso"
        Me.gpCurso.Size = New System.Drawing.Size(1093, 89)
        Me.gpCurso.TabIndex = 78
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
        Me.TextNomInstitucion.Size = New System.Drawing.Size(410, 20)
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
        Me.btnCancelarCurso.ImageKey = "cancelar.png"
        Me.btnCancelarCurso.ImageList = Me.ImageNuevos
        Me.btnCancelarCurso.Location = New System.Drawing.Point(1028, 54)
        Me.btnCancelarCurso.Name = "btnCancelarCurso"
        Me.btnCancelarCurso.Size = New System.Drawing.Size(60, 30)
        Me.btnCancelarCurso.TabIndex = 7
        Me.btnCancelarCurso.TabStop = False
        Me.btnCancelarCurso.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnCancelarCurso, "Cancelar")
        Me.btnCancelarCurso.UseVisualStyleBackColor = False
        '
        'btnAgregarCurso
        '
        Me.btnAgregarCurso.BackColor = System.Drawing.SystemColors.Control
        Me.btnAgregarCurso.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarCurso.ImageKey = "checkok.png"
        Me.btnAgregarCurso.ImageList = Me.ImageNuevos
        Me.btnAgregarCurso.Location = New System.Drawing.Point(963, 54)
        Me.btnAgregarCurso.Name = "btnAgregarCurso"
        Me.btnAgregarCurso.Size = New System.Drawing.Size(60, 30)
        Me.btnAgregarCurso.TabIndex = 6
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
        Me.textconObservaCurso.Size = New System.Drawing.Size(543, 42)
        Me.textconObservaCurso.TabIndex = 5
        '
        'dgDatosCursos
        '
        Me.dgDatosCursos.AllowUserToAddRows = False
        Me.dgDatosCursos.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen
        Me.dgDatosCursos.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgDatosCursos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgDatosCursos.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgDatosCursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgDatosCursos.ContextMenuStrip = Me.ctxmenu4
        Me.dgDatosCursos.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgDatosCursos.Location = New System.Drawing.Point(11, 127)
        Me.dgDatosCursos.MultiSelect = False
        Me.dgDatosCursos.Name = "dgDatosCursos"
        Me.dgDatosCursos.ReadOnly = True
        Me.dgDatosCursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgDatosCursos.Size = New System.Drawing.Size(1084, 313)
        Me.dgDatosCursos.TabIndex = 76
        '
        'ctxmenu4
        '
        Me.ctxmenu4.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.mnuModificarCurso, Me.mnuEliminarCurso})
        Me.ctxmenu4.Name = "ctxMenu"
        Me.ctxmenu4.Size = New System.Drawing.Size(126, 48)
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
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(875, 7)
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
        Me.btnLimpiar.Location = New System.Drawing.Point(89, 7)
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
        'btnSiguiente
        '
        Me.btnSiguiente.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSiguiente.BackColor = System.Drawing.SystemColors.Control
        Me.btnSiguiente.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSiguiente.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSiguiente.ImageKey = "siguiente.png"
        Me.btnSiguiente.ImageList = Me.ImageNuevos
        Me.btnSiguiente.Location = New System.Drawing.Point(1039, 7)
        Me.btnSiguiente.Name = "btnSiguiente"
        Me.btnSiguiente.Size = New System.Drawing.Size(80, 30)
        Me.btnSiguiente.TabIndex = 56
        Me.btnSiguiente.Text = "Siguiente"
        Me.btnSiguiente.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnSiguiente, "Siguiente")
        Me.btnSiguiente.UseVisualStyleBackColor = False
        '
        'btnAtras
        '
        Me.btnAtras.BackColor = System.Drawing.SystemColors.Control
        Me.btnAtras.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnAtras.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAtras.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAtras.ImageKey = "anterior.png"
        Me.btnAtras.ImageList = Me.ImageNuevos
        Me.btnAtras.Location = New System.Drawing.Point(7, 7)
        Me.btnAtras.Name = "btnAtras"
        Me.btnAtras.Size = New System.Drawing.Size(80, 30)
        Me.btnAtras.TabIndex = 57
        Me.btnAtras.Text = "Anterior"
        Me.btnAtras.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnAtras, "Atras")
        Me.btnAtras.UseVisualStyleBackColor = False
        '
        'btnBuscar
        '
        Me.btnBuscar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.ImageKey = "buscar2.png"
        Me.btnBuscar.ImageList = Me.ImageNuevos
        Me.btnBuscar.Location = New System.Drawing.Point(957, 7)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(80, 30)
        Me.btnBuscar.TabIndex = 58
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Buscar")
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(348, 7)
        Me.gpEmpresa.Name = "gpEmpresa"
        Me.gpEmpresa.Size = New System.Drawing.Size(437, 41)
        Me.gpEmpresa.TabIndex = 0
        Me.gpEmpresa.TabStop = False
        Me.gpEmpresa.Text = "Empresa"
        '
        'TextNombEmpresa
        '
        Me.TextNombEmpresa.BackColor = System.Drawing.Color.White
        Me.TextNombEmpresa.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextNombEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNombEmpresa.Location = New System.Drawing.Point(6, 15)
        Me.TextNombEmpresa.MaxLength = 30
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(425, 20)
        Me.TextNombEmpresa.TabIndex = 1
        Me.TextNombEmpresa.TabStop = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.LavenderBlush
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.gpEmpleado.Location = New System.Drawing.Point(986, 7)
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
        Me.TextEmpleado.Location = New System.Drawing.Point(7, 16)
        Me.TextEmpleado.MaxLength = 8
        Me.TextEmpleado.Name = "TextEmpleado"
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
        Me.Panel1.Controls.Add(Me.gpEmpleado)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 55)
        Me.Panel1.TabIndex = 59
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.btnAtras)
        Me.Panel2.Controls.Add(Me.btnLimpiar)
        Me.Panel2.Controls.Add(Me.btnGuardar)
        Me.Panel2.Controls.Add(Me.btnSiguiente)
        Me.Panel2.Controls.Add(Me.btnBuscar)
        Me.Panel2.Location = New System.Drawing.Point(0, 564)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1130, 41)
        Me.Panel2.TabIndex = 60
        '
        'TabCamposEsp
        '
        Me.TabCamposEsp.BackColor = System.Drawing.Color.FromArgb(CType(CType(194, Byte), Integer), CType(CType(214, Byte), Integer), CType(CType(246, Byte), Integer))
        Me.TabCamposEsp.Controls.Add(Me.flPanel1)
        Me.TabCamposEsp.Location = New System.Drawing.Point(4, 22)
        Me.TabCamposEsp.Name = "TabCamposEsp"
        Me.TabCamposEsp.Size = New System.Drawing.Size(1106, 450)
        Me.TabCamposEsp.TabIndex = 8
        Me.TabCamposEsp.Text = "Campos Adicionales"
        '
        'flPanel1
        '
        Me.flPanel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.flPanel1.AutoScroll = True
        Me.flPanel1.Location = New System.Drawing.Point(16, 16)
        Me.flPanel1.Name = "flPanel1"
        Me.flPanel1.Size = New System.Drawing.Size(394, 418)
        Me.flPanel1.TabIndex = 1
        '
        'frmMantEmpleados
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.CancelButton = Me.btnLimpiar
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.gpEmpresa)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.tabDatos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmMantEmpleados"
        Me.Text = "Mantenimiento de Datos de Empleados"
        Me.tabDatos.ResumeLayout(False)
        Me.TbGeneral.ResumeLayout(False)
        Me.TbGeneral.PerformLayout()
        Me.ctxPrincipal.ResumeLayout(False)
        CType(Me.picBoCuadro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TbAcade.ResumeLayout(False)
        CType(Me.dgDatosFam, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu1.ResumeLayout(False)
        Me.gpDatosFam.ResumeLayout(False)
        Me.gpDatosFam.PerformLayout()
        Me.TbFam.ResumeLayout(False)
        CType(Me.dgDatosAca, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxMenu2.ResumeLayout(False)
        Me.gpDatosAca.ResumeLayout(False)
        Me.gpDatosAca.PerformLayout()
        Me.tabPuesto.ResumeLayout(False)
        CType(Me.dgDatosPuestos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmenu3.ResumeLayout(False)
        Me.tbCursos.ResumeLayout(False)
        Me.gpCurso.ResumeLayout(False)
        Me.gpCurso.PerformLayout()
        CType(Me.dgDatosCursos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ctxmenu4.ResumeLayout(False)
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        Me.gpEmpleado.ResumeLayout(False)
        Me.gpEmpleado.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.TabCamposEsp.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmDatosFamilia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        TextNombEmpresa.Text = BuscaEscalar("select nombre from Empresas where empresa=@empresa", ListaParametros(lpara))
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
        cadena = "select nombre,nivel from nivelesaca order by nivel"
        llena_combo(cadena, cmbNivel)
        cmbNivel.Items.Add("")
        llenaTabla(cadena, tbTiP1)
        cadena = "select nombre,depto from departamentos order by depto"
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
        llenaTablaBatch(cadena, tbNacional)
        cmbNacional.Items.Add("")
        cadena = "select nombre,titulo from titulos where operable='S'"
        llena_combo(cadena, cmbTitulo)
        cmbTitulo.Items.Add("")
        llenaTabla(cadena, tbTiP2)
        cadena = "select nombre,mes from meses order by mes asc"
        llena_combo(cadena, cmbMes)
        cmbMes.Items.Add("")
        llenaTabla(cadena, tbmes)
        btnLimpiar_Click(sender, e)
        cadena = "select id_area,nombre from area_nomina order by id_area asc"
        Dim filaVacia As DataRow = tbArea.NewRow()
        filaVacia("id_area") = 0
        filaVacia("nombre") = "[Seleccione área]"
        tbArea.Rows.InsertAt(filaVacia, 0)
        llenaTabla(cadena, tbArea)
        cmbArea.DataSource = tbArea
        cmbArea.DisplayMember = "nombre"
        cmbArea.ValueMember = "id_area"



    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim finConsulta, cadenaConsulta As String
        Dim fechaTemp
        finConsulta = ""
        GeneraConsulta(TbGeneral, finConsulta, "em")
        If TextEmpleado.Text.Trim <> "" Then
            finConsulta = finConsulta & " and empleado=" & TextEmpleado.Text
        End If
        If TextAvisoFecha.Visible = True Then
            finConsulta = finConsulta & consultaFecha
        Else
            If textFechaNac.Text <> "  /  /" Then
                If VerificacionFecha(textFechaNac) = True Then
                    fechaTemp = textFechaNac.Text
                    finConsulta = finConsulta & " and em.fechanac='" & fechaTemp & "'"
                Else
                    MsgBox("FORMATO DE FECHA INVALIDO", MsgBoxStyle.Information, "Mensaje del Sistema")
                    Exit Sub
                End If
            End If
        End If
        cadenaConsulta = inicioConsulta & finConsulta & " order by empleado asc"
        Mostrar(cadenaConsulta, sender, e)
    End Sub


    Private Sub Mostrar(ByVal subCadena As String, ByVal sender As System.Object, ByVal e As System.EventArgs)
        ConsultaReadOnly(TbGeneral, True)
        textFechaNac.Visible = False
        TextAvisoFecha.Visible = True
        btnBuscar.Enabled = False
        TextEmpleado.ReadOnly = True
        btnFecha.Enabled = False
        ContextoMenuEnab(True, True, ctxPrincipal)
        indice = 0
        If llenaTabla(subCadena, tbConsulta) > 0 Then
            ctxModPri.Visible = True
            LlenarTextBox(0, tbConsulta)
        Else
            MsgBox("NO HAY REGISTROS CON ESTOS CRITERIOS DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            btnLimpiar_Click(sender, e)
        End If
        mostrar_Botones(tbConsulta.Rows.Count, indice, btnSiguiente, btnAtras)
    End Sub



    Private Sub LlenarTextBox(ByVal indi As Int16, ByVal tabla As DataTable)
        Dim comando As SqlCommand
        Dim dr As SqlDataReader
        Dim filaCopiar As DataRow
        lpara.Clear()
        filaCopiar = tabla.Rows.Item(indi)
        TextEmpleado.Text = filaCopiar.Item(0)
        textConlApellido1.Text = filaCopiar.Item(1)
        textConlApellido2.Text = filaCopiar.Item(2)
        TextConlCasada.Text = filaCopiar.Item(3)
        textConlNombre1.Text = filaCopiar.Item(4)
        textConlNombre2.Text = filaCopiar.Item(5)
        textConlNombre3.Text = filaCopiar.Item(6)
        textDireccion.Text = filaCopiar.Item(7)
        TextCalle.Text = filaCopiar.Item(8)
        textNumeroCalle.Text = filaCopiar.Item(9)
        textApto.Text = filaCopiar.Item(10)
        cmbZona.SelectedIndex = cmbZona.FindStringExact(filaCopiar.Item(11).ToString.Trim)
        TextZona.Text = cmbZona.Text
        TextColonia.Text = filaCopiar.Item(12)
        BuscaElementoCombo(tbDeptos, filaCopiar.Item(13), cmbDepartamento, 1, True)
        TextDepartamento.Text = cmbDepartamento.Text
        BuscaElementoCombo(tbMunics, filaCopiar.Item(14), cmbMunicipio, 1, True)
        TextMunicipio.Text = cmbMunicipio.Text
        textTelefono.Text = filaCopiar.Item(15)
        TextCelular.Text = filaCopiar.Item(16)
        textCorreo.Text = filaCopiar.Item(17)
        BuscaElementoCombo(tbNacional, filaCopiar.Item(18), cmbNacional, 1, True)
        TextNacional.Text = cmbNacional.Text
        cmbEtnia.SelectedIndex = cmbEtnia.FindStringExact(filaCopiar.Item(19).ToString.Trim)
        TextEtnia.Text = cmbEtnia.Text
        textFechaNac.Text = filaCopiar.Item(20)
        TextAvisoFecha.Text = textFechaNac.Text
        BuscaElementoCombo(tbTipoIde, filaCopiar.Item(21), cmbIdentifica, 1, True)
        TextIdentifica.Text = cmbIdentifica.Text
        TextRegistro.Text = filaCopiar.Item(22)
        TextNumIde.Text = filaCopiar.Item(23)
        BuscaElementoCombo(tbDeptoCed, filaCopiar.Item(24), cmbDeptoce, 1, True)
        TextDeptoce.Text = cmbDeptoce.Text
        BuscaElementoCombo(tbMunicCed, filaCopiar.Item(25), cmbMunice, 1, True)
        TextMunice.Text = cmbMunice.Text
        TextDocDocente.Text = filaCopiar.Item(26)
        BuscaElementoCombo(tbCivil, filaCopiar.Item(27), cmbEstadoCivil, 1, False)
        TextEstadoCivil.Text = cmbEstadoCivil.Text
        If filaCopiar.Item(28) = "F" Then
            cmbSexo.SelectedIndex = 1
        ElseIf filaCopiar.Item(28) = "M" Then
            cmbSexo.SelectedIndex = 0
        Else
            cmbSexo.Text = ""
        End If
        If Not IsDBNull(filaCopiar.Item("id_area")) AndAlso filaCopiar.Item("id_area") > 0 Then

            cmbArea.SelectedValue = filaCopiar.Item("id_area")
        Else
            cmbArea.SelectedValue = 0
        End If

        TextSexo.Text = cmbSexo.Text
        textNumSocial.Text = filaCopiar.Item(29)
        textNit.Text = filaCopiar.Item(30)
        BuscaElementoCombo(tbSituaEcono, filaCopiar.Item(31), cmbSituaEcono, 1, True)
        TextSituaEcono.Text = cmbSituaEcono.Text
        TextFechaOp.Text = filaCopiar.Item(32)
        textUsuarios.Text = filaCopiar.Item(33)
        textCorreoColegio.Text = filaCopiar.Item("correoi")
        lpara("empresa") = empresa
        lpara("empleado") = TextEmpleado.Text
        cadena = "select  case when tipo='P' then 'PADRE' when tipo='M' then 'MADRE' " &
                 " when tipo='C' then 'CONYUGE' when tipo='H' then 'HIJO' else '' end as nombTipo, tipo," &
                 " nombreFam, case when fechaNac ='01/01/1900' then '' else convert( varchar, fechaNac,103) end as fechaNac " &
                 " from EMPLEFAM where empresa=@empresa and empleado=@empleado"
        llenaTabla(cadena, tbFamiliares, ListaParametros(lpara))
        dgDatosFam.DataSource = tbFamiliares
        Vista1(dgDatosFam)
        cadena = "select e.nivel, ni.nombre as nombnivel, t.nombre as nombtitulo, " &
                 "e.titulo, case when e.fecha ='01/01/1900' then '' else convert( varchar, fecha, 103) end as fecha" &
                 ", observa from empleaca e inner join titulos t on t.titulo=e.titulo " &
                 "inner join nivelesaca ni on ni.nivel=e.nivel " &
                 "where empresa=@empresa and empleado=@empleado"
        llenaTabla(cadena, tbAcademico, ListaParametros(lpara))
        dgDatosAca.DataSource = tbAcademico
        Vista2(dgDatosAca)

        cadena = " select b.puesto, b.nombre, a.fechaing, a.fechaeg, a.observacion " &
                 " from nom_puesto_empleado a " &
                 " inner join puestosper b on a.empresa=b.empresa and a.id_puesto=b.puesto " &
                 " where a.empresa = @empresa And a.empleado = @empleado" &
                 " order by b.puesto asc"

        llenaTabla(cadena, tbPuesto, ListaParametros(lpara))
        dgDatosPuestos.DataSource = tbPuesto
        Vista3(dgDatosPuestos)

        cadena = " select b.id_curso,b.nombre,a.mes,a.año,a.observacion " &
                 " from nom_curso_empleado a " &
                 " inner join nom_tipo_curso b on a.id_tipo_curso=b.id_curso " &
                 " where a.empresa = @empresa And a.empleado =@empleado" &
                 " order by a.id_tipo_curso asc "
        llenaTabla(cadena, tbCurso, ListaParametros(lpara))
        dgDatosCursos.DataSource = tbCurso
        Vista4(dgDatosCursos)
        CargarCamposGenericos(CInt(TextEmpleado.Text))

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

    End Sub

#Region "Formato y Limpieza"
    Private Sub Vista1(ByVal dgVista As DataGridView)
        With dgVista
            .Columns(1).Visible = False
            .Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(0).HeaderText = "Tipo"
            .Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(0).Width = 100
            .Columns(2).HeaderText = "Nombre"
            .Columns(2).Width = 490
            .Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns(3).HeaderText = "Fecha de nacimiento"
            .Columns(3).Width = 200
            .Columns(3).SortMode = DataGridViewColumnSortMode.NotSortable
            'AltoGridView(18, tbFamiliares, 275, 836, dgVista)
        End With
    End Sub

    Private Sub Vista2(ByVal dgVista As DataGridView)
        With dgVista
            .Columns("nivel").Visible = False
            .Columns("nivel").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("nombnivel").HeaderText = "Nivel"
            .Columns("nombnivel").Width = 180
            .Columns("nombnivel").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("titulo").Visible = False
            .Columns("titulo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("nombtitulo").HeaderText = "Título"
            .Columns("nombtitulo").Width = 200
            .Columns("nombtitulo").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("fecha").HeaderText = "Fecha"
            .Columns("fecha").Width = 75
            .Columns("fecha").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("observa").HeaderText = "Observaciones"
            .Columns("observa").Width = 335
            .Columns("observa").SortMode = DataGridViewColumnSortMode.NotSortable
            'AltoGridView(18, tbAcademico, 275, 836, dgVista)
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
            .Columns("id_curso").HeaderText = "Código"
            .Columns("id_curso").Width = 60
            .Columns("id_curso").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("nombre").HeaderText = "Nombre"
            .Columns("nombre").Width = 305
            .Columns("nombre").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("mes").HeaderText = "Mes"
            .Columns("mes").Width = 70
            .Columns("mes").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("año").HeaderText = "Año"
            .Columns("año").Width = 70
            .Columns("año").SortMode = DataGridViewColumnSortMode.NotSortable
            .Columns("observacion").HeaderText = "Observaciones"
            .Columns("observacion").Width = 285
            .Columns("observacion").SortMode = DataGridViewColumnSortMode.NotSortable
            'AltoGridView(18, tbCurso, 275, 836, dgVista)
        End With
    End Sub



    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        TextEmpleado.Clear()
        TextEmpleado.ReadOnly = False
        ConsultaReadOnly(TbGeneral, False)
        btnCancelarAca_Click(sender, e)
        btnCancelar_Click(sender, e)

        btnCancelarCurso_Click(sender, e)
        btnSiguiente.Enabled = False
        btnAtras.Enabled = False
        btnGuardar.Visible = False
        btnBuscar.Enabled = True
        btnBuscar.Visible = True
        gpDatosAca.Enabled = False
        gpDatosFam.Enabled = False

        gpCurso.Enabled = False
        btnFecha.Enabled = True
        TextAvisoFecha.Visible = False
        textFechaNac.Visible = True
        textFechaAca.Text = "__/__/____"
        consultaFecha = ""

        ContextoMenuEnab(True, False, ctxPrincipal)
        ContextoMenuEnab(True, False, ctxMenu1)
        ContextoMenuEnab(True, False, ctxMenu2)
        ContextoMenuEnab(True, False, ctxmenu3)
        ContextoMenuEnab(True, False, ctxmenu4)
        borra_Mejorado(TbGeneral, ep1)
        dgDatosAca.DataSource = Nothing
        dgDatosFam.DataSource = Nothing
        dgDatosPuestos.DataSource = Nothing
        dgDatosCursos.DataSource = Nothing
        picBoCuadro.Image = Nothing
        btnImagen.Enabled = False
        guardaImagen = False
        Colorea_Mejorado(TbGeneral, Color.White)
        cmbArea.SelectedValue = 0
    End Sub

    Private Sub btnCancelarAca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelarAca.Click
        opcModiAca = 0
        borra_Mejorado(gpDatosAca, ep1)
        ContextoMenuEnab(True, True, ctxMenu2)
        textFechaAca.Text = "__/__/____"
        cmbNivel.Focus()
    End Sub

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        opcModiFa = 0
        borra_Mejorado(gpDatosFam, ep1)
        ContextoMenuEnab(True, True, ctxMenu1)
        textFechaNFam.Text = "__/__/____"
        cmbTipo.Focus()
    End Sub
#End Region

    Private Sub ctxModPri_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModPri.Click
        Colorea_Mejorado(TbGeneral, ColorModi)
        textConlApellido1.BackColor = ColorModi
        textConlApellido2.BackColor = ColorModi
        TextConlCasada.BackColor = ColorModi
        textConlNombre1.BackColor = ColorModi
        textConlNombre2.BackColor = ColorModi
        textConlNombre3.BackColor = ColorModi
        ctxModPri.Visible = False
        ctxModPri.Enabled = True
        gpDatosAca.Enabled = True
        gpDatosFam.Enabled = True

        gpCurso.Enabled = True
        ContextoMenuEnab(True, True, ctxMenu1)
        ContextoMenuEnab(True, True, ctxMenu2)
        ContextoMenuEnab(True, True, ctxmenu3)
        ContextoMenuEnab(True, True, ctxmenu4)
        ConsultaReadOnly(TbGeneral, False)
        btnSiguiente.Enabled = False
        btnAtras.Enabled = False
        btnBuscar.Visible = False
        btnGuardar.Visible = True
        TextAvisoFecha.Visible = False
        textFechaNac.Visible = True
        btnImagen.Enabled = True
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregar.Click
        Dim fechaI, tipoFa As String
        Dim i As Int32
        tipoFa = ""
        If textFechaNFam.Text <> "  /  /" Then
            If VerificacionFecha(textFechaNFam) Then
                fechaI = textFechaNFam.Text
            Else
                MsgBox("FORMATO DE FECHA INVALIDO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End If
        Else
            fechaI = ""
        End If
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
        Dim fechaI As String
        If textFechaAca.Text <> "  /  /" Then
            If VerificacionFecha(textFechaAca) Then
                fechaI = textFechaAca.Text
            Else
                MsgBox("FORMATO DE FECHA INVALIDO", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End If
        Else
            fechaI = ""
        End If
        If validetError(cmbTitulo, ep1) = False Or validetComilla(textObservaciones, ep1) = False _
         Or validetError(cmbNivel, ep1) = False Then
            MsgBox("VERIFIQUE INGRESO DE CAMPOS ", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If
        If opcModiAca = 0 Then
            filaTemp = tbAcademico.NewRow()
            filaTemp.Item("nivel") = tbTiP1.Rows(cmbNivel.SelectedIndex).Item(1)
            filaTemp.Item("nombnivel") = cmbNivel.Text
            filaTemp.Item("nombtitulo") = cmbTitulo.Text
            filaTemp.Item("titulo") = tbTiP2.Rows(cmbTitulo.SelectedIndex).Item(1)
            filaTemp.Item("fecha") = fechaI
            filaTemp.Item("observa") = textObservaciones.Text
            tbAcademico.Rows.Add(filaTemp)
        Else
            filaTemp = tbAcademico.Rows(IndiceAca)
            filaTemp.BeginEdit()
            filaTemp.Item("nivel") = tbTiP1.Rows(cmbNivel.SelectedIndex).Item(1)
            filaTemp.Item("nombnivel") = cmbNivel.Text
            filaTemp.Item("nombtitulo") = cmbTitulo.Text
            filaTemp.Item("titulo") = tbTiP2.Rows(cmbTitulo.SelectedIndex).Item(1)
            filaTemp.Item("fecha") = fechaI
            filaTemp.Item("observa") = textObservaciones.Text
            filaTemp.EndEdit()
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
            ContextoMenuEnab(False, True, ctxMenu1)
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
            textFechaNac.Text = f.Item(3)
            cmbTipo.Focus()
        Else
            MsgBox("NO EXISTEN REGISTROS PARA MODIFICAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub ctxModificaAca_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ctxModificarAca.Click
        Dim f As DataRow
        If dgDatosAca.SelectedRows.Count = 0 Then
            MsgBox("SELECCIONE LA FILA A MODIFICAR", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        If dgDatosAca.SelectedRows.Count > 0 Then
            opcModiAca = 1
            IndiceAca = dgDatosAca.SelectedRows(0).Index
            ContextoMenuEnab(False, True, ctxMenu2)
            f = CType(dgDatosAca.SelectedRows(0).DataBoundItem, DataRowView).Row
            BuscaElementoCombo(tbTiP1, f.Item("nivel"), cmbNivel, 1, False)
            BuscaElementoCombo(tbTiP2, f.Item("titulo"), cmbTitulo, 1, False)
            textFechaAca.Text = f.Item("fecha")
            textObservaciones.Text = f.Item("observa")
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


    Private Sub mnuElimniarPuesto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuElimniarPuesto.Click
        'procedimiento encargado de eliminar un recorrido de la base de datos
        If dgDatosPuestos.SelectedRows.Count > 0 Then
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                filaTemp = CType(dgDatosPuestos.SelectedRows(0).DataBoundItem, DataRowView).Row
                tbPuesto.Rows.Remove(filaTemp)
                'verificar si tiene referencia en inscrip
            End If
        Else
            MsgBox("NO EXISTEN REGISTROS PARA ELIMINAR", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If

    End Sub

    Private Sub mnuModificarCurso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuModificarCurso.Click
        Dim f As DataRow
        If dgDatosCursos.SelectedRows.Count = 0 Then
            MsgBox("SELECCIONE LA FILA A MODIFICAR", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        If dgDatosCursos.SelectedRows.Count > 0 Then
            opcModiCurso = 1
            IndiceCurso = dgDatosCursos.SelectedRows(0).Index
            ContextoMenuEnab(False, True, ctxmenu4)
            f = CType(dgDatosCursos.SelectedRows(0).DataBoundItem, DataRowView).Row

            TextNombCurso.Text = f.Item("nombre")
            'textConMesCurso.Text = f.Item("mes")
            cmbMes.SelectedIndex = f.Item("mes") - 1
            textConanioCurso.Text = f.Item("año")
            textconObservaCurso.Text = f.Item("observacion")

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

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim comando As SqlCommand

        Dim i As Int32
        Dim fechaNac As Date
        Dim zona As Int16
        Dim civil, depto, munic, deptoced, municed, situaE, tipoDoc, nacional, nombAux As String
        Dim paraEmpresa As SqlParameter
        Dim paraEmpleado As SqlParameter
        Dim paraImagen As SqlParameter
        lpara.Clear()
        civil = ""
        depto = ""
        munic = ""
        deptoced = ""
        municed = ""
        situaE = ""
        tipoDoc = ""
        nacional = ""
        If VerificacionFecha(textFechaNac) = False Then
            MsgBox("FECHA DE NACIMIENTO POSEE FORMATO INVALIDO", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        Else
            fechaNac = textFechaNac.Text
        End If
        If cmbZona.Text.Trim <> "" Then
            zona = CInt(cmbZona.Text)
        Else
            zona = 0
        End If

        AsignaElemento(tbDeptoCed, deptoced, cmbDeptoce, 1, True)
        AsignaElemento(tbMunicCed, municed, cmbMunice, 1, True)

        If validetError(textConlApellido1, ep1) And validetComilla(TextConlCasada, ep1) And
            validetError(textConlNombre1, ep1) And validetComilla(textConlNombre2, ep1) And validetComilla(textConlNombre3, ep1) And
            validetError(textDireccion, ep1) And validetComilla(TextCalle, ep1) And validetComilla(textNumeroCalle, ep1) And
            validetComilla(textApto, ep1) And validetComilla(TextColonia, ep1) And validetError(cmbDepartamento, ep1) And
            validetError(cmbMunicipio, ep1) And validetComilla(textTelefono, ep1) And validetComilla(TextCelular, ep1) And
             validetComilla(textCorreo, ep1) And validetError(cmbNacional, ep1) And validetError(cmbEtnia, ep1) And
             validetError(cmbIdentifica, ep1) And validetComilla(TextRegistro, ep1) And validetError(TextNumIde, ep1) And
             validetError(cmbEstadoCivil, ep1) And validetError(cmbSexo, ep1) And validetComilla(textNumSocial, ep1) And
             validetComilla(textNit, ep1) And validetComilla(TextDocDocente, ep1) And validetError(cmbArea, ep1) Then

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
                lpara("depto") = depto
                lpara("munidir") = munic
                lpara("telefono") = textTelefono.Text
                lpara("celular") = TextCelular.Text
                lpara("correo") = textCorreo.Text
                lpara("nacional") = nacional
                lpara("etnia") = cmbEtnia.Text
                lpara("fechanac") = fechaNac
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
                lpara("usuario") = textUsuarios.Text
                lpara("correoi") = textCorreoColegio.Text
                lpara("id_area") = cmbArea.SelectedValue
                If MsgBox("ESTA SEGURO QUE DESEA MODIFICAR ESTE EMPLEADO", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Mensaje del Sistema") = MsgBoxResult.Yes Then

                    cadena = "update  emplegen set apellido1=@apellido1, apellido2=@apellido2 " &
                             ",casada=@casada,nombre1=@nombre1, nombre2=@nombre2 " &
                             ",nombre3=@nombre3, direccion=@direccion, calle=@calle " &
                             ",numero=@numero, apto=@apto, zona=@zona, colonia=@colonia " &
                             ",deptodir=@depto, munidir=@munidir, telefono=@telefono, celular=@celular " &
                             ",correo=@correo, nacional=@nacional, etnia=@etnia, fechanac=@fechanac " &
                             ",tipoiden=@tipoiden, registro=@registro, numidentica=@numidentica " &
                             ",deptoced=@deptoced, municed=@municed, docdocente=@docdocente, civil=@civil " &
                             ",sexo=@sexo, numseguro=@numseguro, nit=@nit " &
                             ",economica=@economica, usuario=@usuario " &
                             ",correoi=@correoi,id_area=@id_area where empresa=@empresa and empleado=@empleado"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                    cadena = "delete from emplefam where empresa=@empresa and empleado=@empleado"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                    For i = 0 To tbFamiliares.Rows.Count - 1
                        lpara.Clear()
                        filaTemp = tbFamiliares.Rows(i)
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
                        lpara("empleado") = TextEmpleado.Text
                        lpara("nivel") = filaTemp.Item("nivel")
                        lpara("titulo") = filaTemp.Item("titulo")
                        lpara("fecha") = filaTemp.Item("fecha")
                        lpara("observa") = filaTemp.Item("observa")
                        cadena = " insert into empleaca (empresa,empleado,nivel,titulo,fecha,observa) 
                                   values (@empresa,@empleado,@nivel,@titulo,@fecha,@observa)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    Next i


                    cadena = "delete from nom_curso_empleado where empresa=@empresa And empleado =@empleado "
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                    For i = 0 To tbCurso.Rows.Count - 1
                        lpara.Clear()
                        filaTemp = tbCurso.Rows(i)
                        lpara("empresa") = empresa
                        lpara("empleado") = TextEmpleado.Text
                        lpara("idTipo") = filaTemp.Item("id_curso")
                        lpara("observacion") = filaTemp.Item("observacion")
                        lpara("mes") = filaTemp.Item("mes")
                        lpara("año") = filaTemp.Item("año")
                        cadena = " insert into nom_curso_empleado (empresa,empleado,id_tipo_curso,observacion,mes,año) 
                                   values (@empresa,@empleado,@idTipo,@observacion,@mes,@año)"
                        modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))
                    Next i

                    nombAux = textConlNombre1.Text.Trim & " " & textConlApellido1.Text.Trim & " " & textConlApellido2.Text.Trim
                    If nombAux.Length > 60 Then
                        nombAux = nombAux.Substring(0, 60)
                    End If
                    lpara("nombreAux") = nombAux
                    cadena = "update auxiliares set nombre=@nombreAux where empresa=@empresa and numero=4 and codigo=@empleado"
                    modelo.EjecutarNonQuery(cadena, ListaParametros(lpara))

                    If modelo.Commit() Then
                        GuardarCamposGenericos(CInt(TextEmpleado.Text))
                        InsertBitacora(9, 2, Me.Text)
                        If guardaImagen = True Then
                            cadena = "delete from fotoempleado where empresa=" & empresa & " and empleado=" & TextEmpleado.Text
                            EjecutarQueryBatch(cadena)

                            Try
                                abrir_conexion(cn)
                                comando = New SqlCommand("guardaArchivo", cn)
                                comando.CommandType = CommandType.StoredProcedure
                                paraEmpresa = New SqlParameter("@empresa", empresa)
                                paraEmpleado = New SqlParameter("@empleado", CInt(TextEmpleado.Text))
                                paraImagen = New SqlParameter("@imagen", SqlDbType.Image)
                                paraImagen.Value = imagenBytes
                                comando.Parameters.Add(paraEmpresa)
                                comando.Parameters.Add(paraImagen)
                                comando.Parameters.Add(paraEmpleado)
                                comando.ExecuteNonQuery()
                                cn.Close()
                                InsertBitacora(9, 2, Me.Text)
                            Catch ex As Exception
                                MsgBox("ERROR AL GUARDAR LA IMAGEN, COMPRUEBE EL TIPO DE IMAGEN", MsgBoxStyle.Critical, "Mensaje del Sistema")
                                cn.Close()
                            End Try


                        End If
                        InsertBitacora(9, 2, Me.Text)
                        MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
                        btnLimpiar_Click(sender, e)
                    End If

                End If
            Catch ex As Exception
                modelo.RollBack()
                MsgBox("ERROR: " & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try
        Else
            MsgBox("LLENE LOS CAMPOS MARCADOS", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
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

#Region "ENTRA Y DEJA FOCO"
    Private Sub Foco(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDepartamento.Enter, cmbMunicipio.Enter, cmbNivel.Enter, cmbTitulo.Enter, cmbZona.Enter, textNit.Enter, textTelefono.Enter, textConlApellido1.Enter, textConlApellido2.Enter, TextConlCasada.Enter, textConlNombre1.Enter, textConlNombre2.Enter, textConlNombre3.Enter, textConlNombre1.Enter, textDireccion.Enter, TextCalle.Enter, textApto.Enter, textNumeroCalle.Enter, TextColonia.Enter, textTelefono.Enter, TextCelular.Enter, textFechaNac.Enter, textCorreo.Enter, cmbNacional.Enter, cmbEstadoCivil.Enter, cmbEtnia.Enter, cmbIdentifica.Enter, TextRegistro.Enter, TextNumIde.Enter, cmbDeptoce.Enter, cmbMunice.Enter, textNumSocial.Enter, cmbSituaEcono.Enter, TextDocDocente.Enter, cmbTipo.Enter, TextNombFam.Enter, textFechaNFam.Enter, cmbNivel.Enter, textFechaNFam.Enter, textObservaciones.Enter
        activa(sender)
    End Sub

    Private Sub Deja(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDepartamento.Leave, cmbMunicipio.Leave, cmbNivel.Leave, cmbTitulo.Leave, cmbZona.Leave, textNit.Leave, textTelefono.Leave, textConlApellido1.Leave, textConlApellido2.Leave, TextConlCasada.Leave, textConlNombre1.Leave, textConlNombre2.Leave, textConlNombre3.Leave, textConlNombre1.Leave, textDireccion.Leave, TextCalle.Leave, textApto.Leave, textNumeroCalle.Leave, TextColonia.Leave, textTelefono.Leave, TextCelular.Leave, textFechaNac.Leave, textCorreo.Leave, cmbNacional.Leave, cmbEstadoCivil.Leave, cmbEtnia.Leave, cmbIdentifica.Leave, TextRegistro.Leave, TextNumIde.Leave, cmbDeptoce.Leave, cmbMunice.Leave, textNumSocial.Leave, cmbSituaEcono.Leave, TextDocDocente.Leave, cmbTipo.Leave, TextNombFam.Leave, textFechaNFam.Leave, cmbNivel.Leave, textFechaNFam.Leave, textObservaciones.Leave
        desactiva(sender)
    End Sub
#End Region

    Private Sub frmDatosGen_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

#Region "Botones Siguiente"
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

#End Region

    Private Sub TextEmpleado_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextEmpleado.KeyPress
        soloNumero(sender, e)
    End Sub

#Region "Fechas"
    Private Sub btnBusCFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFecha.Click
        f = New frmConsultaFechas
        f.TopMost = True
        AddHandler f.actValor, AddressOf ActualizacionDatos
        f.inicializador("em", "fechanac")
        f.StartPosition = FormStartPosition.CenterScreen
        f.ShowDialog()
    End Sub

    Private Sub ActualizacionDatos(ByVal sender As Object, ByVal e As clsActValorREvento)
        consultaFecha = e.va1
        TextAvisoFecha.Visible = True
        textFechaNac.Visible = False
        TextAvisoFecha.Text = AvisoFecha(e.va2)
    End Sub
#End Region


#Region "CARGA DE IMAGENES"
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
        Dim imagenCarga As Image
        Dim fsFoto As FileStream

        Dim fiFoto As FileInfo
        Try
            'buscamos la imagen a grabar
            'CARGAR FOTOGRAFIA
            nombreArchivo = AbrirImagen.FileName()
            fiFoto = New FileInfo(nombreArchivo)
            If fiFoto.Exists() Then
                fsFoto = New FileStream(nombreArchivo, FileMode.Open)
                ReDim imagenBytes(fsFoto.Length)
                fsFoto.Read(imagenBytes, 0, fsFoto.Length)
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

#End Region


    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub






    Private Sub btnAgregarCurso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If validetError(TextNombCurso, ep1) = False Or validetComilla(TextNombCurso, ep1) = False _
           Or validetError(cmbMes, ep1) = False Or validetError(textConanioCurso, ep1) = False Then
            MsgBox("VERIFIQUE INGRESO DE CAMPOS ", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        If opcModiCurso = 0 Then
            filaTemp = tbCurso.NewRow()
            filaTemp.Item("id_curso") = TextNombCurso.Text
            filaTemp.Item("nombre") = TextNombCurso.Text
            filaTemp.Item("observacion") = textconObservaCurso.Text
            filaTemp.Item("mes") = cmbMes.SelectedIndex + 1 'textConMesCurso.Text
            filaTemp.Item("año") = textConanioCurso.Text
            tbCurso.Rows.Add(filaTemp)
        Else
            filaTemp = tbCurso.Rows(IndiceCurso)
            filaTemp.BeginEdit()
            filaTemp.Item("id_curso") = TextNombCurso.Text
            filaTemp.Item("nombre") = TextNombCurso.Text
            filaTemp.Item("observacion") = textconObservaCurso.Text
            filaTemp.Item("mes") = cmbMes.SelectedIndex + 1 'textConMesCurso.Text
            filaTemp.Item("año") = textConanioCurso.Text
            filaTemp.EndEdit()
        End If
        MueveScrollView(dgDatosCursos, tbCurso.Rows.Count - 1)
        btnCancelarCurso_Click(sender, e)

    End Sub

    Private Sub btnCancelarCurso_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        opcModiCurso = 0
        borra_Mejorado(gpCurso, ep1)
        ContextoMenuEnab(True, True, ctxmenu4)
        TextNombCurso.Focus()
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



End Class
