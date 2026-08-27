Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.Data
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.CrystalReports.Engine.ReportDocument

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMMUESTRAREPORTE.VB MIEMBRO DE NOMINA.SLN                                  **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class FrmMuestraReporte
    Inherits Form
    Dim cadena As String
    Dim tabla As New DataTable("Datos")
    Dim r As ReportClass
    Dim tamaño As PaperSize

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
    Friend WithEvents Cr1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMuestraReporte))
        Me.Cr1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.SuspendLayout()
        '
        'Cr1
        '
        Me.Cr1.ActiveViewIndex = -1
        Me.Cr1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Cr1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Cr1.Cursor = System.Windows.Forms.Cursors.Default
        Me.Cr1.Location = New System.Drawing.Point(0, 0)
        Me.Cr1.Name = "Cr1"
        Me.Cr1.SelectionFormula = ""
        Me.Cr1.ShowCloseButton = False
        Me.Cr1.ShowGotoPageButton = False
        Me.Cr1.ShowGroupTreeButton = False
        Me.Cr1.ShowRefreshButton = False
        Me.Cr1.ShowTextSearchButton = False
        Me.Cr1.Size = New System.Drawing.Size(1004, 661)
        Me.Cr1.TabIndex = 48
        Me.Cr1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.Cr1.ViewTimeSelectionFormula = ""
        '
        'FrmMuestraReporte
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1004, 661)
        Me.Controls.Add(Me.Cr1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimizeBox = False
        Me.Name = "FrmMuestraReporte"
        Me.ResumeLayout(False)

    End Sub

#End Region


    Public Sub Inicializacion(ByVal rArg As ReportClass, ByVal tablaArg As DataTable, ByVal TamPArg As PaperSize)
        r = rArg
        tabla = tablaArg
        tamaño = TamPArg
    End Sub

    Private Sub FrmReporteProvision_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
      
        r.PrintOptions.PaperSize = tamaño
        If tabla.Rows.Count > 0 Then
            'r.Load()
            r.SetDataSource(tabla)
            Cr1.ReportSource = r
            Cr1.Visible = True
            Cr1.RefreshReport()
        Else
            MsgBox("No existen datos para generar este listado".ToUpper, MsgBoxStyle.Information, "Mensaje de Sistema")
        End If
        cn.Close()
    End Sub
   

    Private Sub FrmReporteTResponsabilidad_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub
End Class
