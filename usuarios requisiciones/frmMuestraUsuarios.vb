Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMMUESTRAUSUARIOS.VB MIEMBRO DE NOMINA.SLN                                 **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmMuestraUsuarios
    Inherits System.Windows.Forms.Form

    Dim cadena As String
    Dim emp As New DataTable("Origenes")
    Dim codigo As Integer
    Dim num As Int16
    Dim tip As String
    Dim primeraves As Boolean = True
    Dim ts As New DataGridTableStyle

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
    Friend WithEvents dgOrigenes As System.Windows.Forms.DataGridView
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMuestraUsuarios))
        Me.dgOrigenes = New System.Windows.Forms.DataGridView
        CType(Me.dgOrigenes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dgOrigenes
        '
        Me.dgOrigenes.AllowUserToAddRows = False
        Me.dgOrigenes.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.LightGreen
        Me.dgOrigenes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dgOrigenes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgOrigenes.BackgroundColor = System.Drawing.Color.WhiteSmoke
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgOrigenes.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgOrigenes.GridColor = System.Drawing.Color.WhiteSmoke
        Me.dgOrigenes.Location = New System.Drawing.Point(0, 0)
        Me.dgOrigenes.MultiSelect = False
        Me.dgOrigenes.Name = "dgOrigenes"
        Me.dgOrigenes.ReadOnly = True
        Me.dgOrigenes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgOrigenes.Size = New System.Drawing.Size(360, 398)
        Me.dgOrigenes.TabIndex = 2
        '
        'frmMuestraUsuarios
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(361, 398)
        Me.Controls.Add(Me.dgOrigenes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmMuestraUsuarios"
        Me.Text = "Búsqueda"
        CType(Me.dgOrigenes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public Sub inicializa(ByRef cad As String)
        cadena = cad
    End Sub
    Public Sub inicializa(ByRef tbEnvio As DataTable)
        emp = tbEnvio
    End Sub
    Public Sub inicializa(ByRef tbEnvio As DataTable, ByVal numero As Int16)
        emp = tbEnvio
        num = numero
    End Sub

    Private Sub define_vista()
        'If Not primeraves Then
        'dgOrigenes.TableStyles.Remove(ts)
        'End If
        ts.MappingName = emp.TableName
        'dgOrigenes.TableStyles.Add(ts)
        With dgOrigenes '.TableStyles(emp.TableName)
            .Columns(0).Width = 80
            .Columns(0).HeaderText = "CODIGO"
            .Columns(1).Width = 240
            .Columns(1).HeaderText = "NOMBRE"
            .AlternatingRowsDefaultCellStyle.BackColor = Color.LightGreen
            '.AllowSorting = False
        End With
        primeraves = False
    End Sub

    Private Sub frmMuestraUnidadesop_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'dgOrigenes.DataSource = emp
        ''AltoGrid(17, emp, 400, 360, True, dgOrigenes)
        'define_vista()
        abrir_conexion(cn)
        Dim da As New SqlDataAdapter(cadena, cn)
        da.Fill(emp)
        cn.Close()
        dgOrigenes.DataSource = emp
        define_vista()
    End Sub

    Private Sub dgEmpleados_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgOrigenes.DoubleClick
        'If dgOrigenes.SelectedRows.Count > 0 Then
        '    regresar(codigo)
        'Else
        '    MsgBox("SELECCIONE UN ELEMENTO", MsgBoxStyle.Information, "Mensaje del Sistema")
        'End If
        If dgOrigenes.SelectedRows.Count > 0 Then
            codigo = dgOrigenes.Item(0, dgOrigenes.SelectedRows(0).Index).Value
            tip = dgOrigenes.Item(1, dgOrigenes.SelectedRows(0).Index).Value
            regresar(codigo)
        End If
    End Sub


    Private Sub dgOrigenes_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgOrigenes.CellEnter
        If dgOrigenes.SelectedRows.Count > 0 Then
            dgOrigenes.Rows(dgOrigenes.SelectedRows(0).Index).Selected = True
        End If
    End Sub

    Private Sub regresar(ByVal mandar As Int16)
        'Dim argumentos As clsActValorREvento
        'Dim valornum As String
        'valornum = CStr(num)
        'argumentos = New clsActValorREvento(valornum, dgOrigenes.SelectedRows(0).Index)
        'RaiseEvent actValor(Me, argumentos)
        'Me.Close()
        Dim argumentos As clsActValorREvento
        argumentos = New clsActValorREvento(tip, codigo)
        RaiseEvent actValor(Me, argumentos)
        Me.Close()
    End Sub

    Public Event actValor(ByVal sender As Object, ByVal e As clsActValorREvento)

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

End Class
