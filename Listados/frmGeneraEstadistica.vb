Imports System.Data.SqlClient
Imports System.Drawing.Printing
Imports System.IO

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMGENERAESTADISTICA.VB MIEMBRO DE NOMINA.SLN                               **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmGeneraEstadistica
    Inherits Form
    Dim cadena As String
    Dim tbForma As New DataTable("forma")
    Dim tbDatos As New DataTable("datos")
    Dim tbTipo As New DataTable("tipo")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim fpago, maximo, minimo, banco As Integer
    Dim moneda, cuentaBanco, cuentaNom, tipoNom As String
    Dim tasaOri As Decimal
    Dim v As New ChequeNery
    Dim tt As New DataTable("impresion")
    Dim ObLetras As New ValoresLetras
    Dim oWriteP, oWriteNac As StreamWriter
    Dim nombreNomina As String
    Dim mesi, mesf, añoi, añof As Int32
    Dim cadenaTitulo1
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageNuevo As ImageList
    Friend WithEvents pgBar As System.Windows.Forms.ProgressBar



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
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GuardaArchi As System.Windows.Forms.SaveFileDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextAñoI As System.Windows.Forms.TextBox
    Friend WithEvents cmbMesF As System.Windows.Forms.ComboBox
    Friend WithEvents cmbMesI As System.Windows.Forms.ComboBox
    Friend WithEvents TextAñoF As System.Windows.Forms.TextBox


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmGeneraEstadistica))
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.cmbMesF = New System.Windows.Forms.ComboBox()
        Me.cmbMesI = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextAñoI = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextAñoF = New System.Windows.Forms.TextBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevo = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GuardaArchi = New System.Windows.Forms.SaveFileDialog()
        Me.pgBar = New System.Windows.Forms.ProgressBar()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.gpFecha.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpFecha
        '
        Me.gpFecha.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpFecha.BackColor = System.Drawing.Color.AliceBlue
        Me.gpFecha.Controls.Add(Me.cmbMesF)
        Me.gpFecha.Controls.Add(Me.cmbMesI)
        Me.gpFecha.Controls.Add(Me.Label2)
        Me.gpFecha.Controls.Add(Me.TextAñoI)
        Me.gpFecha.Controls.Add(Me.Label6)
        Me.gpFecha.Controls.Add(Me.TextAñoF)
        Me.gpFecha.Controls.Add(Me.btnEjecutar)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.Location = New System.Drawing.Point(27, 63)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(611, 64)
        Me.gpFecha.TabIndex = 1
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Periodo"
        '
        'cmbMesF
        '
        Me.cmbMesF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMesF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMesF.Location = New System.Drawing.Point(282, 34)
        Me.cmbMesF.Name = "cmbMesF"
        Me.cmbMesF.Size = New System.Drawing.Size(139, 21)
        Me.cmbMesF.TabIndex = 3
        '
        'cmbMesI
        '
        Me.cmbMesI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMesI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMesI.Location = New System.Drawing.Point(44, 34)
        Me.cmbMesI.Name = "cmbMesI"
        Me.cmbMesI.Size = New System.Drawing.Size(139, 21)
        Me.cmbMesI.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 38)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "De:"
        '
        'TextAñoI
        '
        Me.TextAñoI.BackColor = System.Drawing.Color.White
        Me.TextAñoI.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAñoI.Location = New System.Drawing.Point(189, 35)
        Me.TextAñoI.MaxLength = 4
        Me.TextAñoI.Name = "TextAñoI"
        Me.TextAñoI.Size = New System.Drawing.Size(57, 20)
        Me.TextAñoI.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(220, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(19, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Al:"
        '
        'TextAñoF
        '
        Me.TextAñoF.BackColor = System.Drawing.Color.White
        Me.TextAñoF.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAñoF.Location = New System.Drawing.Point(430, 35)
        Me.TextAñoF.MaxLength = 4
        Me.TextAñoF.Name = "TextAñoF"
        Me.TextAñoF.Size = New System.Drawing.Size(57, 20)
        Me.TextAñoF.TabIndex = 4
        '
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "reportegenerar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevo
        Me.btnEjecutar.Location = New System.Drawing.Point(493, 27)
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
        Me.btnLimpiar.Location = New System.Drawing.Point(565, 16)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 73
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar forma")
        Me.btnLimpiar.UseVisualStyleBackColor = False
        '
        'gpEmpresa
        '
        Me.gpEmpresa.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gpEmpresa.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpEmpresa.Controls.Add(Me.TextNombEmpresa)
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(103, 0)
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
        Me.TextNombEmpresa.Location = New System.Drawing.Point(10, 16)
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(435, 21)
        Me.TextNombEmpresa.TabIndex = 2
        Me.TextNombEmpresa.TabStop = False
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'pgBar
        '
        Me.pgBar.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pgBar.BackColor = System.Drawing.Color.WhiteSmoke
        Me.pgBar.Location = New System.Drawing.Point(7, 6)
        Me.pgBar.Name = "pgBar"
        Me.pgBar.Size = New System.Drawing.Size(648, 23)
        Me.pgBar.Step = 1
        Me.pgBar.TabIndex = 72
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(662, 60)
        Me.Panel1.TabIndex = 74
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(71, Byte), Integer), CType(CType(164, Byte), Integer), CType(CType(71, Byte), Integer))
        Me.Panel2.Controls.Add(Me.pgBar)
        Me.Panel2.Location = New System.Drawing.Point(0, 149)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(662, 38)
        Me.Panel2.TabIndex = 75
        '
        'frmGeneraEstadistica
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(662, 187)
        Me.Controls.Add(Me.gpFecha)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "frmGeneraEstadistica"
        Me.Text = "Generación de Archivo Estadística Anual Ministerio de Trabajo"
        Me.gpFecha.ResumeLayout(False)
        Me.gpFecha.PerformLayout()
        Me.gpEmpresa.ResumeLayout(False)
        Me.gpEmpresa.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmSaldos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TextNombEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=" & empresa)
        cadena = "select nombre from meses order by mes"
        llena_combo(cadena, cmbMesI)
        llena_combo(cadena, cmbMesF)
        cmbMesI.Items.Add("")
        cmbMesF.Items.Add("")
    End Sub




    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click
        If Not validetError(cmbMesI, ep1) Or Not validetError(cmbMesF, ep1) Or Not validetError(TextAñoI, ep1) Or _
        Not validetError(TextAñoF, ep1) Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        MsgBox("NUEVA VERSION", MsgBoxStyle.Information, "Mensaje del Sistema")
        añoi = CInt(TextAñoI.Text)
        añof = CInt(TextAñoF.Text)
        mesi = cmbMesI.SelectedIndex + 1
        mesf = cmbMesF.SelectedIndex + 1
        If añof < añoi Then
            MsgBox("EL AÑO FINAL DEBE SER MAYOR O IGUAL QUE EL AÑO INICIAL", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        ElseIf añoi = añof Then
            If mesf < mesi Then
                MsgBox("EL MES FINAL DEBE SER MAYOR O IGUAL QUE EL MES INICIAL", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub
            End If
        End If
        nombreNomina = "ESTADISTICA ANUAL "
        GuardaArchi.Title = "GUARDAR ARCHIVO"
        GuardaArchi.FileName = "javier"
        GuardaArchi.Filter = "ARCHIVO SEPARADO POR COMAS (*.csv)|*.*|Archivos de texto" & _
        "(*.txt)|*.txt"
        ' Specify default filter
        GuardaArchi.FilterIndex = 2
        If GuardaArchi.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Me.Cursor = Cursors.WaitCursor
            Proceso()
        End If
    End Sub

    Private Sub Proceso()
        Dim nombreArchi As String
        Dim i, j As Integer
        Dim fechai, fechaf As Date
        Dim dirCadena() As String
        Dim archivo As String
        Dim lineaEscribe As String
        Dim titulo As String = "NúmeroEmpleado,Tipo Documento Identificación,Documento Identificación,PaisOrigen,Lugar Nacimiento" & _
                               ",NitEmpleado,IGSS Empleado ,Nombre1,Nombre2,Apellido1,Apellido2,EstadoCivil,NúmeroHijos,Fecha Nacimiento," & _
                               "Sexo,Fecha Inicio Labores,Fecha Reinicio labores,Fecha Retiro Labores,Puesto, Dias Trabajados Año,Jornada," & _
                               "Horas Ordinarias Trabajadas Día,Salario Ordinario Anual,Total Horas Extras,Salario Extra Ordinario,Aguinaldo,Bono14," & _
                               "Comisiones,Otros Pagos,Nivel Academico,Profesión,  Etnia, Idiomas,PermisoTrabajo,Tipo Contrato,Indemnización"

        Me.Cursor = Cursors.WaitCursor
        Try
            fechai = "01/" & mesi & "/" & añoi
            fechaf = Date.DaysInMonth(añof, mesf) & "/" & mesf & "/" & añof
            nombreArchi = GuardaArchi.FileName()
            dirCadena = nombreArchi.Split("\")
            nombreArchi = ""
            For i = 0 To dirCadena.Length() - 2
                nombreArchi = nombreArchi & dirCadena(i) & "\"
            Next i
            archivo = dirCadena(dirCadena.Length() - 1)
            oWriteP = File.CreateText(nombreArchi & "personal_" & archivo.Substring(0, archivo.Length - 4) & "_" & añof & ".csv")
            '  oWriteNac = File.CreateText(nombreArchi & "nacionales_" & archivo.Substring(0, archivo.Length - 4) & "_" & añof & ".txt")
            Me.Cursor = Cursors.WaitCursor
            cadena = "select 1 as tipodoc, cedula,83 as PaisOrigen, codigoDep as Lugar_Nacimiento," & _
                     "nit as NitEmpleado,numseguro, nombre1, nombre2,apellido1, apellido2, estadocivil,hijos,fechaNac,sexo, fechai, '' as fechaReinicio, fechafinal, " & _
                     "ocupa, CantidadDiasOrdinarios, " & _
                     "case when jornada='D' then 'DIURNA' " & _
                     "when jornada='N' then 'NOCTURNA' " & _
                     "when jornada='M' then 'MIXTA' end as jornada, horas, ValorDiasOrdinarios, CantidadHorasExtras, ValorHorasExtras, " & _
                     "valorAguinaldo, ValorBonoAnual, 0 as ValorComisiones, valotros, " & _
                     "case when nivelAcademico=1 then 0 " & _
                     "when nivelacademico=2 then 3 " & _
                     "when nivelacademico=3 then 5 " & _
                     "when nivelacademico=4 then 11 " & _
                     "when nivelacademico=5 then 9 " & _
                     "end as nivelacademico,  titulo, 4 as Etnia, 23 as Idiomas, " & _
                     "'' as Permiso_Trabajo, '' as tipo_Contrato, ValIndemnizacion " & _
                     "from ListadoEstadisticaNomina " & _
                     "(" & empresa & "," & mesi & "," & añoi & "," & mesf & "," & añof & ",'" & fechai & "','" & fechaf & "','" & "31/10/" & añof & _
                     "','" & "30/11/" & añof & "' ) where " & _
                     "CantidadDiasOrdinarios > 0 or CantidadHoras > 0 " & _
                     "order by empleado, contrato "
            If llenaTabla(cadena, tbDatos) > 0 Then
                pgBar.Maximum = tbDatos.Rows.Count
                For i = 0 To tbDatos.Rows.Count - 1
                    pgBar.PerformStep()
                    filaTemp = tbDatos.Rows(i)
                    lineaEscribe = ""
                    If i = 0 Then

                        oWriteP.WriteLine(titulo)
                    End If
                    For j = 0 To tbDatos.Columns.Count - 1
                        lineaEscribe = lineaEscribe & filaTemp.Item(j)
                        If j <> tbDatos.Columns.Count - 1 Then
                            lineaEscribe = lineaEscribe & ","
                        End If
                    Next j
                    oWriteP.WriteLine(i + 1 & "," & lineaEscribe)
                Next i
                pgBar.Value = 0
                MsgBox("OPERACION REALIZADA CON EXITO", MsgBoxStyle.Information, "Mensaje del Sistema")
            Else
                MsgBox("NO HAY REGISTROS PARA GENERAR ESTE REPORTE", MsgBoxStyle.Information, "Mensaje del Sistema")
            End If
        Catch ex As Exception
            MsgBox("ERROR AL GUARDAR EL ARCHIVO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End Try
        Try
            oWriteP.Close()
        Catch ex As Exception

        End Try

        'oWriteNac.Close()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub TextAñoI_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextAñoI.KeyPress, TextAñoF.KeyPress
        soloNumero(sender, e)
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









    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        borra_Mejorado(gpFecha, ep1)
        pgBar.Value = 0
    End Sub
End Class
