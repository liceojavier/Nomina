Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMCONSULTANUMERO.VB MIEMBRO DE NOMINA.SLN                                  **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmConsultaNumero
    Inherits System.Windows.Forms.Form
    Dim Elementos_select, tabla, Numero, cadena As String
    Dim fechaA, fechaDe As Date
    Dim comando As SqlCommand
    Dim primeraves As Boolean
    Dim Ent, Deci As Int16
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList


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
    Friend WithEvents cmbConsulta As System.Windows.Forms.ComboBox
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents gpDe As System.Windows.Forms.GroupBox
    Friend WithEvents gpA As System.Windows.Forms.GroupBox
    Friend WithEvents TextDe As System.Windows.Forms.TextBox
    Friend WithEvents TextA As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultaNumero))
        Me.cmbConsulta = New System.Windows.Forms.ComboBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.gpDe = New System.Windows.Forms.GroupBox()
        Me.TextDe = New System.Windows.Forms.TextBox()
        Me.gpA = New System.Windows.Forms.GroupBox()
        Me.TextA = New System.Windows.Forms.TextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.gpDe.SuspendLayout()
        Me.gpA.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmbConsulta
        '
        Me.cmbConsulta.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbConsulta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbConsulta.Items.AddRange(New Object() {"ENTRE", "MAYOR", "MENOR", "MAYOR IGUAL", "MENOR IGUAL", "DIFERENTE"})
        Me.cmbConsulta.Location = New System.Drawing.Point(8, 16)
        Me.cmbConsulta.Name = "cmbConsulta"
        Me.cmbConsulta.Size = New System.Drawing.Size(192, 21)
        Me.cmbConsulta.TabIndex = 15
        '
        'btnBuscar
        '
        Me.btnBuscar.BackColor = System.Drawing.SystemColors.Control
        Me.btnBuscar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBuscar.ForeColor = System.Drawing.Color.Black
        Me.btnBuscar.ImageKey = "checkok.png"
        Me.btnBuscar.ImageList = Me.ImageNuevos
        Me.btnBuscar.Location = New System.Drawing.Point(445, 14)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(60, 30)
        Me.btnBuscar.TabIndex = 50
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolTip1.SetToolTip(Me.btnBuscar, "Asignar")
        Me.btnBuscar.UseVisualStyleBackColor = False
        '
        'ImageNuevos
        '
        Me.ImageNuevos.ImageStream = CType(resources.GetObject("ImageNuevos.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageNuevos.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageNuevos.Images.SetKeyName(0, "checkok.png")
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.GroupBox1.Controls.Add(Me.cmbConsulta)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.Color.White
        Me.GroupBox1.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(216, 43)
        Me.GroupBox1.TabIndex = 53
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Consulta"
        '
        'gpDe
        '
        Me.gpDe.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpDe.Controls.Add(Me.TextDe)
        Me.gpDe.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpDe.ForeColor = System.Drawing.Color.White
        Me.gpDe.Location = New System.Drawing.Point(228, 8)
        Me.gpDe.Name = "gpDe"
        Me.gpDe.Size = New System.Drawing.Size(104, 43)
        Me.gpDe.TabIndex = 54
        Me.gpDe.TabStop = False
        Me.gpDe.Text = "De"
        '
        'TextDe
        '
        Me.TextDe.Location = New System.Drawing.Point(8, 16)
        Me.TextDe.MaxLength = 15
        Me.TextDe.Name = "TextDe"
        Me.TextDe.Size = New System.Drawing.Size(88, 20)
        Me.TextDe.TabIndex = 0
        '
        'gpA
        '
        Me.gpA.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gpA.Controls.Add(Me.TextA)
        Me.gpA.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gpA.ForeColor = System.Drawing.Color.White
        Me.gpA.Location = New System.Drawing.Point(336, 8)
        Me.gpA.Name = "gpA"
        Me.gpA.Size = New System.Drawing.Size(104, 43)
        Me.gpA.TabIndex = 55
        Me.gpA.TabStop = False
        Me.gpA.Text = "A"
        '
        'TextA
        '
        Me.TextA.Location = New System.Drawing.Point(8, 14)
        Me.TextA.MaxLength = 15
        Me.TextA.Name = "TextA"
        Me.TextA.Size = New System.Drawing.Size(88, 20)
        Me.TextA.TabIndex = 1
        '
        'frmConsultaNumero
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(514, 58)
        Me.Controls.Add(Me.gpA)
        Me.Controls.Add(Me.gpDe)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnBuscar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultaNumero"
        Me.Text = "Consulta de Valores"
        Me.GroupBox1.ResumeLayout(False)
        Me.gpDe.ResumeLayout(False)
        Me.gpDe.PerformLayout()
        Me.gpA.ResumeLayout(False)
        Me.gpA.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub frmConsultaFechas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbConsulta.SelectedIndex = 0
        cmbConsulta.Focus()
    End Sub

    Public Sub inicializador(ByVal nombreT As String, ByVal DataNumero As String, ByVal EntArg As Int16, ByVal DeciArg As Int16)
        tabla = nombreT
        Numero = DataNumero
        Ent = EntArg
        Deci = DeciArg
    End Sub

    Private Sub cmbConsulta_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbConsulta.SelectedIndexChanged
        Dim indice As Int16
        indice = cmbConsulta.SelectedIndex()
        Select Case indice
            Case 0
                cambio_valor(True, True)
                TextDe.Focus()
            Case 1
                cambio_valor(False, True)
                TextA.Focus()
            Case 2
                cambio_valor(False, True)
                TextA.Focus()
            Case 3
                cambio_valor(False, True)
                TextA.Focus()
            Case 4
                cambio_valor(False, True)
                TextA.Focus()
            Case 5
                cambio_valor(False, True)
                TextA.Focus()
            Case 6
                cambio_valor(False, False)
                TextA.Focus()
        End Select
    End Sub

    Private Sub cambio_valor(ByVal opc As Boolean, ByVal opc2 As Boolean)
        gpDe.Visible = opc
        gpA.Visible = opc2
    End Sub


    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        Dim indice As Int16
        Dim De, Aa As Decimal
        Dim argumentos As clsActValorREvento
        indice = cmbConsulta.SelectedIndex()
        If indice = 0 Then
            If TextDe.Text.Trim = "" Then
                MsgBox("NO HA INGRESADO NINGUN VALOR EN EL CAMPO DE", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            Else
                De = CDec(TextDe.Text)
            End If
        End If
        If TextA.Text.Trim = "" Then
            MsgBox("NO HA INGRESADO NINGUN VALOR EN EL CAMPO AL", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        Else
            Aa = CDec(TextA.Text)
        End If
        If (indice = 0) Then
            If De > Aa Then
                MsgBox("EL PRIMER VALOR NO PUEDE SER MAYOR QUE EL SEGUNDO, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                Exit Sub
            End If
        End If
        Select Case indice
            Case 0
                cadena = " and " & tabla & "." & Numero & " between " & De & " AND " & Aa
            Case 1
                cadena = " and " & tabla & "." & Numero & " > " & Aa
            Case 2
                cadena = " and " & tabla & "." & Numero & " < " & Aa
            Case 3
                cadena = " and " & tabla & "." & Numero & " >= " & Aa
            Case 4
                cadena = " and " & tabla & "." & Numero & " <= " & Aa
            Case 5
                cadena = " and " & tabla & "." & Numero & " <> " & Aa
        End Select
        argumentos = New clsActValorREvento(cadena, cmbConsulta.SelectedIndex)
        RaiseEvent actValor(Me, argumentos)
        Me.Close()
    End Sub


    Public Event actValor(ByVal sender As Object, ByVal e As clsActValorREvento)

    Private Sub frmCerrar(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose(True)
        Me.Close()
        Me.Finalize()
    End Sub

    Private Function formato(ByVal numformato As Decimal) As String
        Return Format(numformato, "#,##0.00")
    End Function


    Private Sub TextA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextA.Validated, TextDe.Validated
        validatedDecimalPreci(sender, Ent, Deci)
    End Sub

    Private Sub TextA_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextA.Enter, TextDe.Enter
        EntraDecimal(sender)
    End Sub


    Private Sub TextA_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextA.KeyPress, _
    TextDe.KeyPress
        soloNumeroDec(sender, e)
    End Sub
End Class
