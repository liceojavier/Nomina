Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports Syncfusion.Windows.Forms
Imports Syncfusion.XlsIO
Imports System.Collections.Generic

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMINGRESOIMPUESTOISR.VB MIEMBRO DE NOMINA.SLN                              **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmIGSS

    Inherits Form
    Dim cadena As String
    Dim tbContra1 As New DataTable("contra1")
    Dim tbTipo As New DataTable("tipo")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim v As New cryListadoISR
    Friend WithEvents ImageNuevo As ImageList
    Dim tt As New DataTable("datos")
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
    Friend WithEvents gpEmpresa As System.Windows.Forms.GroupBox
    Friend WithEvents TextNombEmpresa As System.Windows.Forms.TextBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents sfdArchivo As System.Windows.Forms.SaveFileDialog
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button


    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmIGSS))
        Me.gpFecha = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextAño = New System.Windows.Forms.TextBox()
        Me.cmbMes = New System.Windows.Forms.ComboBox()
        Me.btnEjecutar = New System.Windows.Forms.Button()
        Me.ImageNuevo = New System.Windows.Forms.ImageList(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.gpEmpresa = New System.Windows.Forms.GroupBox()
        Me.TextNombEmpresa = New System.Windows.Forms.TextBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.sfdArchivo = New System.Windows.Forms.SaveFileDialog()
        Me.gpFecha.SuspendLayout()
        Me.gpEmpresa.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'gpFecha
        '
        Me.gpFecha.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpFecha.Controls.Add(Me.Label3)
        Me.gpFecha.Controls.Add(Me.Label2)
        Me.gpFecha.Controls.Add(Me.TextAño)
        Me.gpFecha.Controls.Add(Me.cmbMes)
        Me.gpFecha.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpFecha.ForeColor = System.Drawing.Color.White
        Me.gpFecha.Location = New System.Drawing.Point(19, 56)
        Me.gpFecha.Name = "gpFecha"
        Me.gpFecha.Size = New System.Drawing.Size(456, 43)
        Me.gpFecha.TabIndex = 1
        Me.gpFecha.TabStop = False
        Me.gpFecha.Text = "Periodo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(170, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Año:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Mes:"
        '
        'TextAño
        '
        Me.TextAño.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextAño.Location = New System.Drawing.Point(209, 17)
        Me.TextAño.MaxLength = 4
        Me.TextAño.Name = "TextAño"
        Me.TextAño.Size = New System.Drawing.Size(56, 20)
        Me.TextAño.TabIndex = 3
        '
        'cmbMes
        '
        Me.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbMes.Location = New System.Drawing.Point(43, 16)
        Me.cmbMes.Name = "cmbMes"
        Me.cmbMes.Size = New System.Drawing.Size(121, 21)
        Me.cmbMes.TabIndex = 2
        '
        'btnEjecutar
        '
        Me.btnEjecutar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEjecutar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEjecutar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnEjecutar.ImageKey = "reportegenerar.png"
        Me.btnEjecutar.ImageList = Me.ImageNuevo
        Me.btnEjecutar.Location = New System.Drawing.Point(502, 33)
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
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevo
        Me.btnLimpiar.Location = New System.Drawing.Point(502, 69)
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
        Me.gpEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpEmpresa.ForeColor = System.Drawing.Color.White
        Me.gpEmpresa.Location = New System.Drawing.Point(19, 6)
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
        Me.TextNombEmpresa.Location = New System.Drawing.Point(13, 16)
        Me.TextNombEmpresa.Name = "TextNombEmpresa"
        Me.TextNombEmpresa.ReadOnly = True
        Me.TextNombEmpresa.Size = New System.Drawing.Size(430, 21)
        Me.TextNombEmpresa.TabIndex = 2
        Me.TextNombEmpresa.TabStop = False
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnEjecutar)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Controls.Add(Me.gpFecha)
        Me.Panel1.Controls.Add(Me.gpEmpresa)
        Me.Panel1.Location = New System.Drawing.Point(2, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(628, 128)
        Me.Panel1.TabIndex = 60
        '
        'sfdArchivo
        '
        '
        'frmIGSS
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(628, 147)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmIGSS"
        Me.Text = "Generación Listado de IGSS"
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
    End Sub


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEjecutar.Click

        If Not validetError(cmbMes, ep1) Or Not validetError(TextAño, ep1) Then
            MsgBox("LLENE TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If
        sfdArchivo.FileName = "listado_igss_" & cmbMes.Text & "_" & TextAño.Text
        sfdArchivo.DefaultExt = ".xlsx"
        sfdArchivo.Filter = "Archivo de Excel|*.xlsx"
        sfdArchivo.InitialDirectory = System.Environment.GetEnvironmentVariable("homepath")
        sfdArchivo.ShowDialog()
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





    Private Sub crv_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        borra_Mejorado(gpFecha, ep1)

    End Sub

    Private Sub sfdArchivo_FileOk(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles sfdArchivo.FileOk
        Dim ltitulo As New List(Of String)(New String() {"Numero", "Número afilicación", _
                                                        "Primer Nombre", "Segundo Nombre", "Primer Apellido", _
                                                    "Segundo Apellido", "Apellido de Casada", "Sueldo Devengado", _
                                                    "Fecha de Alta", "Fecha de Baja", "Código de Centro", "Nit", _
                                                    "Código Ocupación", "Condición Laboral", "Deducciones"})
        Dim path As String = sfdArchivo.FileName
        Dim numero As Decimal
        If path.Trim <> "" Then
            Dim año, mes As Int16
            Dim i As Int32 = 1
            Dim j As Int32 = 2
            año = CInt(TextAño.Text)
            mes = cmbMes.SelectedIndex + 1
            cadena = "select * from REPORTE_IGSS (" & empresa & "," & mes & "," & año & ") order by numero_integer"
            If llenaTabla(cadena, tt) > 0 Then
                Dim excelEngine As New ExcelEngine
                Dim aplicacion As IApplication = excelEngine.Excel
                Dim workbook As IWorkbook = aplicacion.Workbooks.Create()
                Try

                    Dim worksheet As IWorksheet = workbook.Worksheets(0)
                    workbook.Version = ExcelVersion.Excel2007

                    For Each titulo As String In ltitulo
                        worksheet.Range(1, i).Text = titulo
                        i += 1
                        worksheet.Range(1, i).Text = "|"
                        i += 1
                    Next
                    For Each fila As DataRow In tt.Rows
                        i = 1
                        For Each dc As DataColumn In tt.Columns
                            If dc.ColumnName.Contains("integer") Or dc.ColumnName.Contains("decimal") Then
                                If Decimal.TryParse(fila.Item(dc.ColumnName).ToString, numero) Then
                                    worksheet.Range(j, i).Number = fila.Item(dc.ColumnName)
                                    If Not dc.ColumnName.Contains("decimal") Then
                                        worksheet.Range(j, i).CellStyle.NumberFormat = "##0"
                                    Else
                                        worksheet.Range(j, i).CellStyle.NumberFormat = "#,##0.00"
                                    End If
                                Else
                                    worksheet.Range(j, i).Text = fila.Item(dc.ColumnName)
                                End If
                            Else
                                worksheet.Range(j, i).Text = fila.Item(dc.ColumnName).ToString()
                            End If
                            i += 1
                            worksheet.Range(j, i).Text = "|"
                            i += 1
                        Next
                        j += 1
                    Next
                    workbook.SaveAs(path)
                    MsgBox("Operación realizada con éxito".ToUpper, MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Catch ex As Exception
                    MsgBox("Error del Sistema" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                Finally
                    workbook.Close()
                    excelEngine.Dispose()
                End Try
            Else
                MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
            End If
        Else
            MsgBox("NO HA INGRESADO UN NOMBRE PARA ESTE ARCHIVO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
        End If

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ltitulo As New List(Of String)(New String() {"Numero", "Número afilicación", _
                                                        "Primer Nombre", "Segundo Nombre", "Primer Apellido", _
                                                    "Segundo Apellido", "Apellido de Casada", "Sueldo Devengado", _
                                                    "Fecha de Alta", "Fecha de Baja", "Código de Centro", "Nit", _
                                                    "Código Ocupación", "Condición Laboral", "Deducciones"})
        Dim path As String = "D:\archivop.xlsx"
        Dim numero As Decimal
        If path.Trim <> "" Then
            Dim año, mes As Int16
            Dim i As Int32 = 1
            Dim j As Int32 = 2
            año = CInt(TextAño.Text)
            mes = cmbMes.SelectedIndex + 1
            cadena = "select * from REPORTE_IGSS (" & empresa & "," & mes & "," & año & ") order by numero_integer"
            If llenaTabla(cadena, tt) > 0 Then
                Dim excelEngine As New ExcelEngine
                Dim aplicacion As IApplication = excelEngine.Excel
                Dim workbook As IWorkbook = aplicacion.Workbooks.Create()
                Try

                    Dim worksheet As IWorksheet = workbook.Worksheets(0)
                    workbook.Version = ExcelVersion.Excel2007

                    For Each titulo As String In ltitulo
                        worksheet.Range(1, i).Text = titulo
                        i += 1
                        worksheet.Range(1, i).Text = "|"
                        i += 1
                    Next
                    For Each fila As DataRow In tt.Rows
                        i = 1
                        For Each dc As DataColumn In tt.Columns
                            If dc.ColumnName.Contains("integer") Or dc.ColumnName.Contains("decimal") Then
                                If Decimal.TryParse(fila.Item(dc.ColumnName).ToString, numero) Then
                                    worksheet.Range(j, i).Number = fila.Item(dc.ColumnName)
                                    If Not dc.ColumnName.Contains("decimal") Then
                                        worksheet.Range(j, i).CellStyle.NumberFormat = "##0"
                                    Else
                                        worksheet.Range(j, i).CellStyle.NumberFormat = "#,##0.00"
                                    End If
                                Else
                                    worksheet.Range(j, i).Text = fila.Item(dc.ColumnName)
                                End If
                            Else
                                worksheet.Range(j, i).Text = fila.Item(dc.ColumnName).ToString()
                            End If
                            i += 1
                            worksheet.Range(j, i).Text = "|"
                            i += 1
                        Next
                        j += 1
                    Next
                    workbook.SaveAs(path)
                    MsgBox("Operación realizada con éxito".ToUpper, MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Catch ex As Exception
                    MsgBox("Error del Sistema" & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
                Finally
                    workbook.Close()
                    excelEngine.Dispose()
                End Try
            Else
                MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
            End If
        Else
            MsgBox("NO HA INGRESADO UN NOMBRE PARA ESTE ARCHIVO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
        End If
    End Sub
End Class
