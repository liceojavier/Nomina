Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMMUESTRA3COLUMNAS.VB MIEMBRO DE NOMINA.SLN                                **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmMuestra3Columnas
    Inherits System.Windows.Forms.Form
    Dim cadena As String
    Dim cuent As New DataTable("Cuentas")
    Dim indice As Int16
    Dim NumColumnas As Integer
    Dim primeraves As Boolean = True
    Friend WithEvents dgCuentas As System.Windows.Forms.DataGridView
    Dim ts As New DataGridTableStyle
    Dim nomb1, nomb2, nomb3 As String
    Dim var As Integer

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
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMuestra3Columnas))
        Me.dgCuentas = New System.Windows.Forms.DataGridView
        CType(Me.dgCuentas, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgCuentas
        '
        Me.dgCuentas.AllowUserToAddRows = False
        Me.dgCuentas.AllowUserToDeleteRows = False
        Me.dgCuentas.AllowUserToOrderColumns = True
        Me.dgCuentas.AllowUserToResizeRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen
        Me.dgCuentas.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgCuentas.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgCuentas.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.dgCuentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgCuentas.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgCuentas.Location = New System.Drawing.Point(0, 0)
        Me.dgCuentas.MultiSelect = False
        Me.dgCuentas.Name = "dgCuentas"
        Me.dgCuentas.ReadOnly = True
        Me.dgCuentas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgCuentas.Size = New System.Drawing.Size(684, 344)
        Me.dgCuentas.TabIndex = 0
        '
        'frmMuestra3Columnas
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(684, 344)
        Me.Controls.Add(Me.dgCuentas)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmMuestra3Columnas"
        Me.Text = "Búsqueda "
        CType(Me.dgCuentas, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub inicializa(ByRef tabla As DataTable, ByVal nom1Arg As String, ByVal nom2Arg As String, ByVal nom3Arg As String, ByVal numColuArg As Integer)
        cuent = tabla
        nomb1 = nom1Arg
        nomb2 = nom2Arg
        nomb3 = nom3Arg
        NumColumnas = numColuArg
    End Sub

    Private Sub define_vista()
        Dim i As Int16
        With dgCuentas
            .Columns(0).Width = 100
            .Columns(0).HeaderText = nomb1
            .Columns(1).Width = 375
            .Columns(1).HeaderText = nomb2
            .Columns(2).Width = 125
            .Columns(2).HeaderText = nomb3
            If NumColumnas <> 0 Then
                For i = 3 To NumColumnas + 2
                    .Columns(i).Visible = False
                Next i
            End If

        End With
    End Sub

    Private Sub frmMuestraCuentas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dgCuentas.DataSource = cuent
        'AltoGridView(17, cuent, 348, 665, dgCuentas)
        define_vista()
    End Sub

    Private Sub dgCuentas_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgCuentas.DoubleClick
        If dgCuentas.SelectedRows.Count > 0 Then
            regresar()
        Else
            MsgBox("SELECCIONE UN ELEMENTO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub regresar()
        Dim argumentos As clsActValorREvento
        argumentos = New clsActValorREvento("", dgCuentas.SelectedRows(0).Index)
        RaiseEvent actValor(Me, argumentos)
        Me.Close()
    End Sub

    Public Event actValor(ByVal sender As Object, ByVal e As clsActValorREvento)

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Public Property X() As Integer
        Get
            Return var
        End Get
        Set(ByVal value As Integer)
            var = value + 6
        End Set
    End Property


End Class
