Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports NOMINA.FormsAuth
Imports System.DirectoryServices.AccountManagement
Imports System.Security.Principal
'Imports NotasProfesores.FormsAuth

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMAUTENTICACION.VB MIEMBRO DE NOMINA.SLN                                   **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/01/2008                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class Autenticacion
    Inherits Form 'System.Windows.Forms.Form
    Dim tbEmpresas As New DataTable("empresas")
    Dim cadena As String
    Dim veces As Int16 = 0
    Dim fP As MenuM
    Dim nombre_grupo_verificacion = "nominas"
    Dim autenticacion As New LdapAuthentication("LDAP://192.168.10.100")

    Dim tbRoles As New DataTable("roles")
    Private arrastrando As Boolean = False
    Friend WithEvents Label4 As Label
    Friend WithEvents lbSistema As Label
    Friend WithEvents lbgrupo As Label
    Private puntoInicial As Point

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
    Friend WithEvents txtUsuario As System.Windows.Forms.TextBox
    Friend WithEvents btnEntrar As System.Windows.Forms.Button
    Friend WithEvents txtpassword As System.Windows.Forms.TextBox
    Friend WithEvents lblUsuario As System.Windows.Forms.Label
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ep1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ImagenList As System.Windows.Forms.ImageList
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbEmpresa As System.Windows.Forms.ComboBox
    Friend WithEvents LabelVersion As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents chckMostrarContraseña As CheckBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents btnCerrar As Button
    Friend WithEvents btnSS As Button
    Friend WithEvents ColorDialog1 As ColorDialog
    Friend WithEvents pnlTitulo As Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Autenticacion))
        Me.lblUsuario = New System.Windows.Forms.Label()
        Me.lblPassword = New System.Windows.Forms.Label()
        Me.txtUsuario = New System.Windows.Forms.TextBox()
        Me.txtpassword = New System.Windows.Forms.TextBox()
        Me.btnEntrar = New System.Windows.Forms.Button()
        Me.ImagenList = New System.Windows.Forms.ImageList(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ep1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cmbEmpresa = New System.Windows.Forms.ComboBox()
        Me.LabelVersion = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSS = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.chckMostrarContraseña = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.ColorDialog1 = New System.Windows.Forms.ColorDialog()
        Me.pnlTitulo = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lbSistema = New System.Windows.Forms.Label()
        Me.lbgrupo = New System.Windows.Forms.Label()
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblUsuario
        '
        Me.lblUsuario.AutoSize = True
        Me.lblUsuario.BackColor = System.Drawing.Color.Transparent
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.ForeColor = System.Drawing.Color.White
        Me.lblUsuario.Location = New System.Drawing.Point(222, 93)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(54, 13)
        Me.lblUsuario.TabIndex = 0
        Me.lblUsuario.Text = "Usuario:"
        Me.lblUsuario.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.BackColor = System.Drawing.Color.Transparent
        Me.lblPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPassword.ForeColor = System.Drawing.Color.White
        Me.lblPassword.Location = New System.Drawing.Point(222, 139)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(75, 13)
        Me.lblPassword.TabIndex = 1
        Me.lblPassword.Text = "Contraseña:"
        Me.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtUsuario
        '
        Me.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtUsuario.Location = New System.Drawing.Point(222, 110)
        Me.txtUsuario.MaxLength = 20
        Me.txtUsuario.Name = "txtUsuario"
        Me.txtUsuario.Size = New System.Drawing.Size(304, 22)
        Me.txtUsuario.TabIndex = 2
        '
        'txtpassword
        '
        Me.txtpassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtpassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtpassword.Location = New System.Drawing.Point(222, 156)
        Me.txtpassword.MaxLength = 25
        Me.txtpassword.Name = "txtpassword"
        Me.txtpassword.Size = New System.Drawing.Size(304, 22)
        Me.txtpassword.TabIndex = 3
        Me.txtpassword.UseSystemPasswordChar = True
        '
        'btnEntrar
        '
        Me.btnEntrar.BackColor = System.Drawing.SystemColors.Control
        Me.btnEntrar.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.btnEntrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEntrar.ForeColor = System.Drawing.Color.Black
        Me.btnEntrar.ImageIndex = 0
        Me.btnEntrar.ImageList = Me.ImagenList
        Me.btnEntrar.Location = New System.Drawing.Point(222, 210)
        Me.btnEntrar.Name = "btnEntrar"
        Me.btnEntrar.Size = New System.Drawing.Size(304, 34)
        Me.btnEntrar.TabIndex = 4
        Me.btnEntrar.Text = "INICIAR SESIÓN"
        Me.btnEntrar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.ToolTip1.SetToolTip(Me.btnEntrar, "Entrar")
        Me.btnEntrar.UseVisualStyleBackColor = False
        '
        'ImagenList
        '
        Me.ImagenList.ImageStream = CType(resources.GetObject("ImagenList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImagenList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImagenList.Images.SetKeyName(0, "candado.png")
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(183, 29)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(343, 24)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "Autenticación de Usuarios"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'ep1
        '
        Me.ep1.ContainerControl = Me
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox1.ForeColor = System.Drawing.Color.Transparent
        Me.GroupBox1.Location = New System.Drawing.Point(245, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(10, 10)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'cmbEmpresa
        '
        Me.cmbEmpresa.BackColor = System.Drawing.SystemColors.Control
        Me.cmbEmpresa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbEmpresa.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmbEmpresa.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbEmpresa.FormattingEnabled = True
        Me.cmbEmpresa.Location = New System.Drawing.Point(222, 62)
        Me.cmbEmpresa.Name = "cmbEmpresa"
        Me.cmbEmpresa.Size = New System.Drawing.Size(304, 23)
        Me.cmbEmpresa.TabIndex = 0
        '
        'LabelVersion
        '
        Me.LabelVersion.AutoSize = True
        Me.LabelVersion.BackColor = System.Drawing.Color.Transparent
        Me.LabelVersion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelVersion.ForeColor = System.Drawing.Color.White
        Me.LabelVersion.Location = New System.Drawing.Point(19, 296)
        Me.LabelVersion.Name = "LabelVersion"
        Me.LabelVersion.Size = New System.Drawing.Size(48, 13)
        Me.LabelVersion.TabIndex = 65
        Me.LabelVersion.Text = "Versión: "
        '
        'btnSS
        '
        Me.btnSS.BackColor = System.Drawing.Color.Transparent
        Me.btnSS.BackgroundImage = CType(resources.GetObject("btnSS.BackgroundImage"), System.Drawing.Image)
        Me.btnSS.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSS.ForeColor = System.Drawing.Color.White
        Me.btnSS.ImageIndex = 0
        Me.btnSS.Location = New System.Drawing.Point(549, 288)
        Me.btnSS.Name = "btnSS"
        Me.btnSS.Size = New System.Drawing.Size(41, 29)
        Me.btnSS.TabIndex = 6
        Me.btnSS.Text = "SSO"
        Me.ToolTip1.SetToolTip(Me.btnSS, "Entrar")
        Me.btnSS.UseVisualStyleBackColor = False
        '
        'btnCerrar
        '
        Me.btnCerrar.BackColor = System.Drawing.Color.Transparent
        Me.btnCerrar.BackgroundImage = CType(resources.GetObject("btnCerrar.BackgroundImage"), System.Drawing.Image)
        Me.btnCerrar.FlatAppearance.BorderSize = 0
        Me.btnCerrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCerrar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCerrar.ForeColor = System.Drawing.Color.White
        Me.btnCerrar.ImageIndex = 0
        Me.btnCerrar.Location = New System.Drawing.Point(565, 5)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(32, 22)
        Me.btnCerrar.TabIndex = 74
        Me.btnCerrar.Text = "X"
        Me.ToolTip1.SetToolTip(Me.btnCerrar, "Cerrar")
        Me.btnCerrar.UseVisualStyleBackColor = False
        '
        'chckMostrarContraseña
        '
        Me.chckMostrarContraseña.AutoSize = True
        Me.chckMostrarContraseña.BackColor = System.Drawing.Color.Transparent
        Me.chckMostrarContraseña.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chckMostrarContraseña.ForeColor = System.Drawing.Color.White
        Me.chckMostrarContraseña.Location = New System.Drawing.Point(222, 184)
        Me.chckMostrarContraseña.Name = "chckMostrarContraseña"
        Me.chckMostrarContraseña.Size = New System.Drawing.Size(118, 17)
        Me.chckMostrarContraseña.TabIndex = 5
        Me.chckMostrarContraseña.Text = "Mostrar Contraseña"
        Me.chckMostrarContraseña.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(36, 169)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(154, 46)
        Me.Label1.TabIndex = 72
        Me.Label1.Text = "ASOCIACIÓN JAVERIANA GUATEMALTECA"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PictureBox2
        '
        Me.PictureBox2.BackColor = System.Drawing.Color.Transparent
        Me.PictureBox2.Image = CType(resources.GetObject("PictureBox2.Image"), System.Drawing.Image)
        Me.PictureBox2.Location = New System.Drawing.Point(51, 33)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(115, 140)
        Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox2.TabIndex = 73
        Me.PictureBox2.TabStop = False
        '
        'pnlTitulo
        '
        Me.pnlTitulo.BackColor = System.Drawing.Color.Transparent
        Me.pnlTitulo.Location = New System.Drawing.Point(1, 0)
        Me.pnlTitulo.Name = "pnlTitulo"
        Me.pnlTitulo.Size = New System.Drawing.Size(558, 27)
        Me.pnlTitulo.TabIndex = 75
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(36, 223)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(154, 20)
        Me.Label4.TabIndex = 76
        Me.Label4.Text = "SISTEMA ADMINISTRATIVO"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbSistema
        '
        Me.lbSistema.BackColor = System.Drawing.Color.Transparent
        Me.lbSistema.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbSistema.ForeColor = System.Drawing.Color.White
        Me.lbSistema.Location = New System.Drawing.Point(68, 248)
        Me.lbSistema.Name = "lbSistema"
        Me.lbSistema.Size = New System.Drawing.Size(472, 20)
        Me.lbSistema.TabIndex = 79
        Me.lbSistema.Text = "lbSistema"
        Me.lbSistema.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbgrupo
        '
        Me.lbgrupo.AutoSize = True
        Me.lbgrupo.BackColor = System.Drawing.Color.Transparent
        Me.lbgrupo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbgrupo.ForeColor = System.Drawing.Color.White
        Me.lbgrupo.Location = New System.Drawing.Point(431, 296)
        Me.lbgrupo.Name = "lbgrupo"
        Me.lbgrupo.Size = New System.Drawing.Size(42, 13)
        Me.lbgrupo.TabIndex = 78
        Me.lbgrupo.Text = "lbgrupo"
        Me.lbgrupo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Autenticacion
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(209, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(17, Byte), Integer))
        Me.BackgroundImage = Global.NOMINA.My.Resources.Resources.fondo_rojo1
        Me.ClientSize = New System.Drawing.Size(602, 337)
        Me.Controls.Add(Me.lbSistema)
        Me.Controls.Add(Me.lbgrupo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.pnlTitulo)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.PictureBox2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbEmpresa)
        Me.Controls.Add(Me.btnSS)
        Me.Controls.Add(Me.chckMostrarContraseña)
        Me.Controls.Add(Me.LabelVersion)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblPassword)
        Me.Controls.Add(Me.lblUsuario)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnEntrar)
        Me.Controls.Add(Me.txtpassword)
        Me.Controls.Add(Me.txtUsuario)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.Name = "Autenticacion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Verificación de Usuario"
        CType(Me.ep1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region



    Private Sub btnEntrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEntrar.Click

        Dim usuario As String = txtUsuario.Text.Trim
        Dim password As String = txtpassword.Text.Trim

        If validaError(txtpassword, ep1) = False Or validaError(txtUsuario, ep1) = False Then
            Return
        End If

        If autenticacion.IsAuthenticated("LICEOJAVIER", usuario, password) Then
            IngresarAlSistema(usuario, password, False)
        Else
            MsgBox("No es posible Autorizar".ToUpper, MsgBoxStyle.Information, "Mensaje del Sistema")
            veces += 1
            txtUsuario.Focus()
            If veces = 3 Then
                Application.Exit()
            End If
        End If


    End Sub
    Private Sub IngresarAlSistema(usuario As String, password As String, esSSO As Boolean)

        Dim departamento As String = ""
        Dim grupos As List(Of String) = New List(Of String)()
        Dim codigo() As String

        Try

            ' validar autorización del usuario para el módulo
            If esSSO Then
                grupos = autenticacion.GetGroupsSSO("LICEOJAVIER", usuario)   ' nuevo método sin password
                codigo = autenticacion.obtencionPropiedadSSO("company", usuario)
                departamento = autenticacion.obtencionPropiedadSSO("department", usuario)(0)
            Else
                grupos = autenticacion.GetGroups("LICEOJAVIER", usuario, password)
                codigo = autenticacion.obtencionPropiedad("company", usuario, password)
                departamento = autenticacion.obtencionPropiedad("department", usuario, password)(0)
            End If




            If grupos.Where(Function(x) x.Equals(nombre_grupo_verificacion)).Count() = 0 Then

                MsgBox("NO ESTÁ AUTORIZADO PARA UTILIZAR ESTE MÓDULO" &
                       vbNewLine & "PÓNGASE EN CONTACTO CON SU ADMINISTRADOR", MsgBoxStyle.Critical, "Mensaje del Sistema")
                Exit Sub
            End If

            If departamento <> "" Then
                Try
                    CodigoEmpleado = CInt(departamento)

                Catch ex As Exception

                    MsgBox("NÚMERO DE EMPLEADO ASIGNADO DE FORMA INCORRECTA EN EL DIRECTORIO" & vbNewLine & "PÓNGASE EN CONTACTO CON EL ADMINISTRADOR", MsgBoxStyle.Critical, "Mensaje del Sistema")
                    Exit Sub
                End Try
            Else
                MsgBox("SU CÓDIGO DE PERSONAL NO ESTÁ ASOCIADO AL DIRECTORIO" & vbNewLine & "COMUNÍQUESE CON SU ADMINISTRADOR DE SISTEMAS", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
                Exit Sub

            End If
            'guardar usuario
            _usuario = usuario
            user = _usuario
            'abrir sistema
            Me.Hide()
            fP = New MenuM
            fP.InicializaPermisos()
            fP.Show()

        Catch ex As Exception
            MsgBox("Ocurrió un error al ingresar al sistema." & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
        End Try

    End Sub



    Private Sub frmAutenticacion_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = 13 Then
            e.Handled = True
            SendKeys.Send("{Tab}")
        End If
    End Sub

    Private Sub txtcodigo_GotFocus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario.GotFocus, txtpassword.GotFocus
        activa(sender)
    End Sub

    Private Sub txtcodigo_Desactiva(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtUsuario.Leave, txtpassword.Leave
        desactiva(sender)
    End Sub


    Private Sub frmAutenticacion_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Me.Dispose()
        Application.Exit()
        Exit Sub
    End Sub

    Private Sub frmAutenticacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.LabelVersion.Text = String.Format("Version {0}", My.Application.Info.Version.ToString)
        lbSistema.Text = My.Application.Info.Title
        lbgrupo.Text = nombre_grupo_verificacion
        cadena = "select nombre, empresa from empresas order by empresa"
        llena_combo(cadena, cmbEmpresa)
        llenaTabla(cadena, tbEmpresas)
        cmbEmpresa.SelectedIndex = 0
        txtUsuario.Focus()
    End Sub


    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbEmpresa.SelectedIndexChanged
        Dim fTemp As DataRow
        fTemp = tbEmpresas.Rows.Item(cmbEmpresa.SelectedIndex)
        _nombre_empresa = cmbEmpresa.Text
        empresa = fTemp.Item(1)
    End Sub

    Private Sub chckMostrarContraseña_CheckedChanged(sender As Object, e As EventArgs) Handles chckMostrarContraseña.CheckedChanged
        If chckMostrarContraseña.Checked Then
            txtpassword.UseSystemPasswordChar = False
        Else
            txtpassword.UseSystemPasswordChar = True
        End If
    End Sub

    Private Sub btnSS_Click(sender As Object, e As EventArgs) Handles btnSS.Click

        Try
            Dim identidad As WindowsIdentity = WindowsIdentity.GetCurrent()
            If identidad Is Nothing OrElse Not identidad.IsAuthenticated Then
                MsgBox("No se pudo verificar la identidad de Windows.", MsgBoxStyle.Critical, "SSO")
                Exit Sub
            End If
            Dim usuarioWindows As String = identidad.Name
            Dim usuario As String = identidad.Name.Split("\"c)(1)

            If autenticacion.VerificacionGrupo(nombre_grupo_verificacion) Then
                IngresarAlSistema(usuario, "", True)
            Else

                MsgBox("EL USUARIO " & usuarioWindows & vbNewLine & "NO ESTÁ AUTORIZADO PARA UTILIZAR ESTE MÓDULO.", MsgBoxStyle.Critical, "Acceso denegado")
                Exit Sub
            End If

        Catch ex As Exception
            MsgBox("No fue posible realizar el inicio de sesión SSO." & vbNewLine & vbNewLine & ex.Message, MsgBoxStyle.Critical, "SSO")
        End Try
    End Sub

    Private Sub btnCerrar_Click(sender As Object, e As EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    Private Sub Autenticacion_Paint(sender As Object, e As PaintEventArgs) Handles MyBase.Paint
        ' Crear un pincel negro con un grosor de 2 píxeles
        Dim miColorRojo As Color = Color.FromArgb(164, 58, 58)
        Using pen As New Pen(miColorRojo, 2)
            ' Dibujar una línea desde (x1, y1) hasta (x2, y2)
            e.Graphics.DrawLine(pen, 20, 275, 580, 275)
        End Using
        Using pen As New Pen(Color.Yellow, 1)
            ' Dibujar una línea desde (x1, y1) hasta (x2, y2)
            e.Graphics.DrawLine(pen, 40, 215, 190, 215)
        End Using
    End Sub
    Private Sub pnlTitulo_MouseDown(sender As Object, e As MouseEventArgs) Handles pnlTitulo.MouseDown

        If e.Button = MouseButtons.Left Then
            arrastrando = True
            puntoInicial = e.Location
        End If

    End Sub

    Private Sub pnlTitulo_MouseMove(sender As Object, e As MouseEventArgs) Handles pnlTitulo.MouseMove

        If arrastrando Then
            Dim nuevaPosicion As Point = Me.PointToScreen(e.Location)

            nuevaPosicion.X -= puntoInicial.X
            nuevaPosicion.Y -= puntoInicial.Y

            Me.Location = nuevaPosicion
        End If

    End Sub

    Private Sub pnlTitulo_MouseUp(sender As Object, e As MouseEventArgs) Handles pnlTitulo.MouseUp

        If e.Button = MouseButtons.Left Then
            arrastrando = False
        End If

    End Sub


End Class
