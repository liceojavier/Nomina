Imports CrystalDecisions.CrystalReports.Engine

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMLISTADOEVALUACIONDOCENTES.VB MIEMBRO DE NOMINA.SLN                       **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmListadoEvaluacionDocentes
    Inherits System.Windows.Forms.Form

    Dim cadena As String
    Dim tabla As DataTable
    Dim tbSubreporte As DataTable
    Dim tbareas As New DataTable("areas")
    Dim asignaturas As New DataTable("Asignaturas")
    Dim r As ReportClass
    Dim tbColegio As New DataTable("colegio")
    Dim tbnivel As New DataTable("nivel")
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As ToolTip
    Dim tbgrado As New DataTable("grado")


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
    Friend WithEvents btnLimpiar As System.Windows.Forms.Button
    Friend WithEvents btnGenerar As System.Windows.Forms.Button
    Friend WithEvents gbDatos As System.Windows.Forms.GroupBox
    Friend WithEvents TextGrado As System.Windows.Forms.TextBox
    Friend WithEvents TextNivel As System.Windows.Forms.TextBox
    Friend WithEvents TextColegio As System.Windows.Forms.TextBox
    Friend WithEvents cmbJornada As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbNivel As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents labelP As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbGrado As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSeccion As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents crv1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents txtCiclo As System.Windows.Forms.TextBox
    Friend WithEvents cmbAreas As System.Windows.Forms.ComboBox
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmListadoEvaluacionDocentes))
        Me.btnLimpiar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.btnGenerar = New System.Windows.Forms.Button()
        Me.crv1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.gbDatos = New System.Windows.Forms.GroupBox()
        Me.TextGrado = New System.Windows.Forms.TextBox()
        Me.TextNivel = New System.Windows.Forms.TextBox()
        Me.TextColegio = New System.Windows.Forms.TextBox()
        Me.cmbJornada = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbNivel = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbAreas = New System.Windows.Forms.ComboBox()
        Me.labelP = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbGrado = New System.Windows.Forms.ComboBox()
        Me.cmbSeccion = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCiclo = New System.Windows.Forms.TextBox()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.gbDatos.SuspendLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnLimpiar
        '
        Me.btnLimpiar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnLimpiar.BackColor = System.Drawing.SystemColors.Control
        Me.btnLimpiar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLimpiar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnLimpiar.ImageKey = "limpiar.png"
        Me.btnLimpiar.ImageList = Me.ImageNuevos
        Me.btnLimpiar.Location = New System.Drawing.Point(995, 57)
        Me.btnLimpiar.Name = "btnLimpiar"
        Me.btnLimpiar.Size = New System.Drawing.Size(80, 30)
        Me.btnLimpiar.TabIndex = 68
        Me.btnLimpiar.Text = "Limpiar"
        Me.btnLimpiar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnLimpiar, "Limpiar")
        Me.btnLimpiar.UseVisualStyleBackColor = False
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
        'btnGenerar
        '
        Me.btnGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGenerar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGenerar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGenerar.ImageKey = "reportegenerar.png"
        Me.btnGenerar.ImageList = Me.ImageNuevos
        Me.btnGenerar.Location = New System.Drawing.Point(995, 19)
        Me.btnGenerar.Name = "btnGenerar"
        Me.btnGenerar.Size = New System.Drawing.Size(80, 30)
        Me.btnGenerar.TabIndex = 67
        Me.btnGenerar.Text = "Generar"
        Me.btnGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGenerar, "Generar")
        Me.btnGenerar.UseVisualStyleBackColor = False
        '
        'crv1
        '
        Me.crv1.ActiveViewIndex = -1
        Me.crv1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crv1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv1.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv1.Location = New System.Drawing.Point(0, 93)
        Me.crv1.Name = "crv1"
        Me.crv1.SelectionFormula = ""
        Me.crv1.ShowCloseButton = False
        Me.crv1.ShowGotoPageButton = False
        Me.crv1.ShowGroupTreeButton = False
        Me.crv1.ShowRefreshButton = False
        Me.crv1.ShowTextSearchButton = False
        Me.crv1.Size = New System.Drawing.Size(1130, 512)
        Me.crv1.TabIndex = 69
        Me.crv1.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        Me.crv1.ViewTimeSelectionFormula = ""
        '
        'gbDatos
        '
        Me.gbDatos.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.gbDatos.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.gbDatos.Controls.Add(Me.TextGrado)
        Me.gbDatos.Controls.Add(Me.TextNivel)
        Me.gbDatos.Controls.Add(Me.TextColegio)
        Me.gbDatos.Controls.Add(Me.cmbJornada)
        Me.gbDatos.Controls.Add(Me.Label3)
        Me.gbDatos.Controls.Add(Me.Label26)
        Me.gbDatos.Controls.Add(Me.cmbNivel)
        Me.gbDatos.Controls.Add(Me.Label6)
        Me.gbDatos.Controls.Add(Me.cmbAreas)
        Me.gbDatos.Controls.Add(Me.labelP)
        Me.gbDatos.Controls.Add(Me.Label5)
        Me.gbDatos.Controls.Add(Me.cmbGrado)
        Me.gbDatos.Controls.Add(Me.cmbSeccion)
        Me.gbDatos.Controls.Add(Me.Label7)
        Me.gbDatos.Controls.Add(Me.txtCiclo)
        Me.gbDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbDatos.ForeColor = System.Drawing.Color.White
        Me.gbDatos.Location = New System.Drawing.Point(93, 0)
        Me.gbDatos.Name = "gbDatos"
        Me.gbDatos.Size = New System.Drawing.Size(851, 87)
        Me.gbDatos.TabIndex = 70
        Me.gbDatos.TabStop = False
        '
        'TextGrado
        '
        Me.TextGrado.BackColor = System.Drawing.Color.White
        Me.TextGrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextGrado.Location = New System.Drawing.Point(248, 56)
        Me.TextGrado.MaxLength = 60
        Me.TextGrado.Name = "TextGrado"
        Me.TextGrado.ReadOnly = True
        Me.TextGrado.Size = New System.Drawing.Size(312, 22)
        Me.TextGrado.TabIndex = 61
        '
        'TextNivel
        '
        Me.TextNivel.BackColor = System.Drawing.Color.White
        Me.TextNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextNivel.Location = New System.Drawing.Point(248, 32)
        Me.TextNivel.MaxLength = 60
        Me.TextNivel.Name = "TextNivel"
        Me.TextNivel.ReadOnly = True
        Me.TextNivel.Size = New System.Drawing.Size(312, 22)
        Me.TextNivel.TabIndex = 60
        '
        'TextColegio
        '
        Me.TextColegio.BackColor = System.Drawing.Color.White
        Me.TextColegio.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextColegio.Location = New System.Drawing.Point(248, 8)
        Me.TextColegio.MaxLength = 60
        Me.TextColegio.Name = "TextColegio"
        Me.TextColegio.ReadOnly = True
        Me.TextColegio.Size = New System.Drawing.Size(312, 22)
        Me.TextColegio.TabIndex = 59
        '
        'cmbJornada
        '
        Me.cmbJornada.BackColor = System.Drawing.Color.White
        Me.cmbJornada.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbJornada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbJornada.Location = New System.Drawing.Point(206, 8)
        Me.cmbJornada.Name = "cmbJornada"
        Me.cmbJornada.Size = New System.Drawing.Size(40, 24)
        Me.cmbJornada.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(134, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 31
        Me.Label3.Text = "Colegio:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(134, 38)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(34, 13)
        Me.Label26.TabIndex = 30
        Me.Label26.Text = "Nivel:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbNivel
        '
        Me.cmbNivel.BackColor = System.Drawing.Color.White
        Me.cmbNivel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbNivel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbNivel.Location = New System.Drawing.Point(206, 32)
        Me.cmbNivel.Name = "cmbNivel"
        Me.cmbNivel.Size = New System.Drawing.Size(40, 24)
        Me.cmbNivel.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(571, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 58
        Me.Label6.Text = "Sección:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbAreas
        '
        Me.cmbAreas.BackColor = System.Drawing.Color.White
        Me.cmbAreas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAreas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbAreas.Location = New System.Drawing.Point(643, 33)
        Me.cmbAreas.Name = "cmbAreas"
        Me.cmbAreas.Size = New System.Drawing.Size(184, 21)
        Me.cmbAreas.TabIndex = 3
        '
        'labelP
        '
        Me.labelP.AutoSize = True
        Me.labelP.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelP.Location = New System.Drawing.Point(571, 36)
        Me.labelP.Name = "labelP"
        Me.labelP.Size = New System.Drawing.Size(35, 13)
        Me.labelP.TabIndex = 34
        Me.labelP.Text = "Area: "
        Me.labelP.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(134, 61)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 13)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "Grado:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmbGrado
        '
        Me.cmbGrado.BackColor = System.Drawing.Color.White
        Me.cmbGrado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbGrado.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbGrado.Location = New System.Drawing.Point(206, 56)
        Me.cmbGrado.Name = "cmbGrado"
        Me.cmbGrado.Size = New System.Drawing.Size(40, 24)
        Me.cmbGrado.TabIndex = 4
        '
        'cmbSeccion
        '
        Me.cmbSeccion.BackColor = System.Drawing.Color.White
        Me.cmbSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSeccion.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSeccion.Location = New System.Drawing.Point(643, 8)
        Me.cmbSeccion.Name = "cmbSeccion"
        Me.cmbSeccion.Size = New System.Drawing.Size(40, 24)
        Me.cmbSeccion.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(70, 13)
        Me.Label7.TabIndex = 32
        Me.Label7.Text = "Ciclo escolar:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtCiclo
        '
        Me.txtCiclo.BackColor = System.Drawing.Color.White
        Me.txtCiclo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCiclo.ForeColor = System.Drawing.Color.Red
        Me.txtCiclo.Location = New System.Drawing.Point(82, 10)
        Me.txtCiclo.Name = "txtCiclo"
        Me.txtCiclo.Size = New System.Drawing.Size(40, 22)
        Me.txtCiclo.TabIndex = 0
        Me.txtCiclo.TabStop = False
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
        Me.Panel1.Controls.Add(Me.gbDatos)
        Me.Panel1.Controls.Add(Me.btnGenerar)
        Me.Panel1.Controls.Add(Me.btnLimpiar)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1130, 97)
        Me.Panel1.TabIndex = 71
        '
        'frmListadoEvaluacionDocentes
        '
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1130, 605)
        Me.Controls.Add(Me.crv1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmListadoEvaluacionDocentes"
        Me.Text = "Resultado de Evaluaciones de Docentes"
        Me.gbDatos.ResumeLayout(False)
        Me.gbDatos.PerformLayout()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub limpia()
        cadena = ""
        crv1.ReportSource = Nothing
        crv1.Refresh()
        tbnivel.Clear()
        tbgrado.Clear()
        gbDatos.Enabled = True
        cmbJornada.Text = Nothing
        TextColegio.Clear()
        cmbJornada.Focus()
    End Sub

    Private Sub frmListadoEvaluacionDocentes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpia()
        txtCiclo.Text = DateTime.Today.Year
        cadena = "select distinct colegio, nombre from Colegios"
        llena_combo(cadena, cmbJornada)
        llenaTabla(cadena, tbColegio)
    End Sub

    Private Sub cmbJornada_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJornada.SelectedIndexChanged
        cmbNivel.Items.Clear()
        cmbGrado.Items.Clear()
        cmbSeccion.Items.Clear()
        TextNivel.Clear()
        TextGrado.Clear()
        If cmbJornada.Text.Trim <> "" Then
            TextColegio.Text = tbColegio.Rows.Item(cmbJornada.SelectedIndex).Item(1)
            cadena = "SELECT DISTINCT NIVEL, nombre FROM NIVELES WHERE COLEGIO='" & cmbJornada.Text & "'"
            llena_combo(cadena, cmbNivel)
            llenaTabla(cadena, tbnivel)
            cmbNivel.Focus()
            cadena = "select nombre,area from areas order by area"
            llena_combo(cadena, cmbAreas)
            llenaTabla(cadena, tbareas)

        End If
    End Sub

    Private Sub cmbNivel_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbNivel.SelectedIndexChanged
        cmbGrado.Items.Clear()
        cmbSeccion.Items.Clear()
        TextGrado.Clear()
        If cmbNivel.Text.Trim <> "" Then
            TextNivel.Text = tbnivel.Rows.Item(cmbNivel.SelectedIndex).Item(1)
            cadena = "SELECT DISTINCT GRADO, nombre FROM GRADOS WHERE COLEGIO='" & cmbJornada.Text & "' AND NIVEL='" & cmbNivel.Text & "'"
            llena_combo(cadena, cmbGrado)
            llenaTabla(cadena, tbgrado)
            cmbGrado.Focus()
        End If
    End Sub

    Private Sub cmbGrado_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbGrado.SelectedIndexChanged
        cmbSeccion.Items.Clear()
        If cmbGrado.Text.Trim <> "" Then
            TextGrado.Text = tbgrado.Rows.Item(cmbGrado.SelectedIndex).Item(1)
            cadena = "SELECT DISTINCT SECCION FROM CATALOGOCOLEGIO WHERE COLEGIO='" & cmbJornada.Text & "' AND NIVEL='" & cmbNivel.Text & "' AND GRADO='" & cmbGrado.Text & "'"
            llena_combo(cadena, cmbSeccion)
            cmbSeccion.Focus()
        End If
    End Sub

    Private Sub cmbSeccion_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSeccion.SelectedIndexChanged
        cmbAreas.Focus()
    End Sub


    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim condiArea As String = ""
        Dim condiNiveles As String = ""
        Dim cadeSubReporte As String = ""
        If Not validetError(txtCiclo, ep1) Then
            MsgBox("DEBE INGRESAR TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        If cmbJornada.Text <> "" Then
            condiNiveles = " and ev1.colegio='" & cmbJornada.Text & "' "
        End If
        If cmbNivel.Text <> "" Then
            condiNiveles = condiNiveles & " and ev1.nivel='" & cmbNivel.Text & "' "
        End If
        If cmbGrado.Text <> "" Then
            condiNiveles = condiNiveles & " and ev1.grado='" & cmbGrado.Text & "' "
        End If
        If cmbSeccion.Text <> "" Then
            condiNiveles = condiNiveles & " and ev1.seccion='" & cmbSeccion.Text & "' "
        End If


        If cmbAreas.Text <> "" Then
            condiArea = " and ma.area=" & tbareas.Rows(cmbAreas.SelectedIndex).Item("area") & " "
        End If
        tabla = New DataTable("tabla")
        tbSubreporte = New DataTable("subreporte")
        If cmbSeccion.Text.Trim <> "" Then

            cadena = "select LL.*, (cast (cuenta as decimal) * 100.00 )/cast( TotalR as decimal) as porcentaje, " & _
                     "cast (LL.cuenta as varchar) + '   ' + cast(  cast( (cuenta * 100.00 )/cast( TotalR as decimal) as decimal(6,2) )  as varchar) as valor " & _
                     "FROM " & _
                     "(select ev1.ciclo, ev1.tipotest, ev1.colegio, co.nombre as nomb_colegio, ev1.nivel, ni.nombre as nomb_nivel, ev1.grado, gr.nombre as nomb_grado, " & _
                     "ev1.seccion as seccion, ev1.codigo, ma.apell1 + ' ' + ma.apell2 + ' ' + ma.nom1 + ' ' + ma.nom2 as nombre, " & _
                     "ev2.numpregunta, cp.pregunta, ev2.numopcion,cop.opcion, count(*) as cuenta, " & _
                     "(select count(*) " & _
                     "from evadoctest1 evc1 " & _
                     "inner join evadoctest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " & _
                     "where evc1.ciclo=ev1.ciclo and evc1.colegio=ev1.colegio and evc1.nivel=ev1.nivel and " & _
                     "evc1.grado=ev1.grado and evc1.seccion=ev1.seccion and evc1.codigo=ev1.codigo and evc2.numpregunta=ev2.numpregunta) " & _
                     "as totalR, ar.nombre as nombre_area " & _
                     "from evadoctest1 ev1 " & _
                     "inner join evadoctest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest " & _
                     "inner join maestros ma on ma.codigo=ev1.codigo " & _
                     "inner join colegios co on co.colegio=ev1.colegio " & _
                     "inner join niveles ni on ni.colegio=ev1.colegio and ni.nivel=ev1.nivel " & _
                     "inner join grados  gr on gr.colegio=ev1.colegio and gr.nivel=ev1.nivel and gr.grado=ev1.grado " & _
                     "inner join culturapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest and cp.numpregunta=ev2.numpregunta " & _
                     "inner join culturaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=ev2.numpregunta and cop.numopcion=ev2.numopcion " & _
                     "inner join areas ar on ma.area=ar.area " & _
                     "WHERE ev1.ciclo=" & txtCiclo.Text & condiNiveles & condiArea & _
                     "group by ev1.ciclo,  ev1.tipotest, ev1.colegio, ev1.nivel, ev1.grado, ev1.seccion, " & _
                     "ev1.codigo, ev2.numpregunta, ev2.numopcion, cp.pregunta, cop.opcion, co.nombre, ni.nombre, gr.nombre, " & _
                     "ma.nom1, ma.nom2, ma.apell1, ma.apell2, ar.nombre) LL " & _
                     "order by colegio,nivel,grado,seccion, nombre "
            cadeSubReporte = "select * from v_EvaluacionObservacion ev1 where ev1.ciclo=" & txtCiclo.Text & condiNiveles
        Else

            cadena = "select LL.*, (cast (cuenta as decimal) * 100.00 )/cast( TotalR as decimal) as porcentaje, " & _
                     "cast (LL.cuenta as varchar) + '   ' + cast(  cast( (cuenta * 100.00 )/cast( TotalR as decimal) as decimal(6,2) )  as varchar) as valor " & _
                     "FROM " & _
                     "(select ev1.ciclo, ev1.tipotest, ev1.colegio, co.nombre as nomb_colegio, ev1.nivel, ni.nombre as nomb_nivel, ev1.grado, gr.nombre as nomb_grado, " & _
                     "'' as seccion, ev1.codigo, ma.apell1 + ' ' + ma.apell2 + ' ' + ma.nom1 + ' ' + ma.nom2 as nombre, " & _
                     "ev2.numpregunta, cp.pregunta, ev2.numopcion,cop.opcion, count(*) as cuenta, " & _
                     "(select count(*) " & _
                     "from evadoctest1 evc1 " & _
                     "inner join evadoctest2 evc2 on evc1.ciclo=evc2.ciclo and evc1.numtest=evc2.numtest " & _
                     "where evc1.ciclo=ev1.ciclo and evc1.colegio=ev1.colegio and evc1.nivel=ev1.nivel and " & _
                     "evc1.grado=ev1.grado  and evc1.codigo=ev1.codigo and evc2.numpregunta=ev2.numpregunta) " & _
                     "as totalR, ar.nombre as nombre_area " & _
                     "from evadoctest1 ev1 " & _
                     "inner join evadoctest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest " & _
                     "inner join maestros ma on ma.codigo=ev1.codigo " & _
                     "inner join colegios co on co.colegio=ev1.colegio " & _
                     "inner join niveles ni on ni.colegio=ev1.colegio and ni.nivel=ev1.nivel " & _
                     "inner join grados  gr on gr.colegio=ev1.colegio and gr.nivel=ev1.nivel and gr.grado=ev1.grado " & _
                     "inner join culturapreguntas cp on cp.ciclo=ev1.ciclo and cp.tipotest=ev1.tipotest and cp.numpregunta=ev2.numpregunta " & _
                     "inner join culturaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=ev2.numpregunta and cop.numopcion=ev2.numopcion " & _
                     "inner join areas ar on ma.area=ar.area " & _
                     "WHERE ev1.ciclo=" & txtCiclo.Text & condiNiveles & condiArea & _
                     "group by ev1.ciclo,  ev1.tipotest, ev1.colegio, ev1.nivel, ev1.grado, " & _
                     "ev1.codigo, ev2.numpregunta, ev2.numopcion, cp.pregunta, cop.opcion, co.nombre, ni.nombre, gr.nombre, " & _
                     "ma.nom1, ma.nom2, ma.apell1, ma.apell2, ar.nombre) LL " & _
                     "order by colegio,nivel,grado,seccion, nombre "
            cadeSubReporte = "select * from v_EvaluacionObservacion ev1 where ev1.ciclo=" & txtCiclo.Text & condiNiveles
        End If
        Me.Cursor = Cursors.WaitCursor
        llenaTabla(cadena, tabla)
        llenaTabla(cadeSubReporte, tbSubreporte)
        If tabla.Rows.Count > 0 Then
            If cmbSeccion.Text.Trim <> "" Then
                r = New listadoevaluacionesmaestros
            Else
                r = New crylistadoevaluacionesmaestrosGrado
            End If
            r.SetDataSource(tabla)
            r.Subreports("cryEvaluacionObservacion.rpt").SetDataSource(tbSubreporte)
            crv1.ReportSource = r
            crv1.Zoom(95)
            crv1.Refresh()
        Else
            MsgBox("NO EXISTEN REGISTROS PARA GENERAR ESTA CONSULTA", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        crv1.ReportSource = Nothing
        TextColegio.Clear()
        cmbJornada.SelectedIndex = -1
        cmbNivel.SelectedIndex = -1
        cmbGrado.SelectedIndex = -1
        cmbSeccion.SelectedIndex = -1
        cmbAreas.SelectedIndex = -1
    End Sub
End Class
