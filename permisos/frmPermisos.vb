Imports System.Windows.Forms
'**********************************************
'*          FRMPERMISOS EN CONTABILIDAD
'*          FECHA: MARZO-2012
'*          AUTOR: IVAN TRUJILLO
'*          DESCRIPCION: Esta opción permite habilitar o deshabilitar formas en cada uno de los módulos
'**********************************************


Public Class frmAsignacionPermisos
    'Declaración de variables
    Inherits Form
    Dim fMenu As New MenuM
    Dim deshaEvento As Boolean = False
    Dim cadena As String = ""
    Dim tbRole As New DataTable("roles")
    Friend WithEvents ImageNuevos As System.Windows.Forms.ImageList
    Friend WithEvents ToolTip1 As ToolTip
    Dim tbPermiso As DataTable

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
    Friend WithEvents TreeViewPermisos As System.Windows.Forms.TreeView
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cmbRol As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAsignacionPermisos))
        Me.TreeViewPermisos = New System.Windows.Forms.TreeView()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.ImageNuevos = New System.Windows.Forms.ImageList(Me.components)
        Me.cmbRol = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'TreeViewPermisos
        '
        Me.TreeViewPermisos.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TreeViewPermisos.CheckBoxes = True
        Me.TreeViewPermisos.Location = New System.Drawing.Point(12, 33)
        Me.TreeViewPermisos.Name = "TreeViewPermisos"
        Me.TreeViewPermisos.Size = New System.Drawing.Size(504, 448)
        Me.TreeViewPermisos.TabIndex = 0
        '
        'btnGuardar
        '
        Me.btnGuardar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnGuardar.BackColor = System.Drawing.SystemColors.Control
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.ImageKey = "guardar.png"
        Me.btnGuardar.ImageList = Me.ImageNuevos
        Me.btnGuardar.Location = New System.Drawing.Point(567, 57)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(83, 30)
        Me.btnGuardar.TabIndex = 1
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ToolTip1.SetToolTip(Me.btnGuardar, "Guardar")
        Me.btnGuardar.UseVisualStyleBackColor = False
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
        'cmbRol
        '
        Me.cmbRol.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbRol.Location = New System.Drawing.Point(567, 30)
        Me.cmbRol.Name = "cmbRol"
        Me.cmbRol.Size = New System.Drawing.Size(285, 21)
        Me.cmbRol.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(529, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Rol:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(12, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Pemisos:"
        '
        'frmAsignacionPermisos
        '
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(129, Byte), Integer), CType(CType(212, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(864, 493)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmbRol)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.TreeViewPermisos)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmAsignacionPermisos"
        Me.Text = "Permisos de Acceso de módulos"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region


    'Carga valores iniciales: Los roles definidos para la contabilidad
    Private Sub frmAsignacionPermisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dv As DataView
        cadena = "select nombre, id_rol  from rol_siaco where idtipomodulo=9 and empresa=" + empresa.ToString() + " order by id_rol"
        llenaTabla(cadena, tbRole)
        dv = New DataView(tbRole)
        cmbRol.DataSource = dv
        cmbRol.DisplayMember = "nombre"
        cmbRol.ValueMember = "id_rol"



    End Sub

    'Esta función se encarga de ver que cuando marcaron o desmarcaron un elemento padre
    'Todos los nodos hijos tengan el mismo estado en lo check box que el padre
    Private Sub TreeViewPermisos_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeViewPermisos.AfterCheck
        Dim NodoCheck As TreeNode
        Dim ValorBool As Boolean
        If Not deshaEvento Then
            deshaEvento = True
            NodoCheck = e.Node
            ValorBool = NodoCheck.Checked
            UnificaValorBooleano(NodoCheck, ValorBool)
            deshaEvento = False
        End If
    End Sub

    'Función de recursiva que ayuda a la función anterior, para recorrer un arbol
    Private Sub UnificaValorBooleano(ByRef NodoPadre As TreeNode, ByVal valBool As Boolean)
        NodoPadre.Checked = valBool
        If NodoPadre.GetNodeCount(False) > 0 Then
            For Each nodoHijo As TreeNode In NodoPadre.Nodes
                UnificaValorBooleano(nodoHijo, valBool)
            Next
        End If
    End Sub

    'Al cambiarse de roles carga los permisos que tienen definido cada rol, para que sean vistos por el usuario
    Private Sub cmbRol_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbRol.SelectedValueChanged
        TreeViewPermisos.Nodes.Clear()
        If cmbRol.Text.Trim <> "" And cmbRol.ValueMember <> "" Then
            Dim nodo As TreeNode
            cadena = "select * from permisos where id_rol=" & cmbRol.SelectedValue & " order by id_permiso"
            tbPermiso = New DataTable("permisos")
            llenaTabla(cadena, tbPermiso)
            'TreeView1.ite()
            For Each MenuItem1 As ToolStripMenuItem In fMenu.MainMenuStrip.Items
                nodo = New TreeNode(MenuItem1.Text)
                nodo.Checked = VerificaPermiso(MenuItem1.Text)
                If MenuItem1.HasDropDownItems Then
                    GeneraArbol(MenuItem1, nodo)
                End If
                TreeViewPermisos.Nodes.Add(nodo)
            Next
        End If
    End Sub

    'Lee cada menu principal del módulo y crea el arbol para habilitar o deshabilitar las opciones
    Private Sub GeneraArbol(ByVal item As ToolStripMenuItem, ByRef NodoPadre As TreeNode)
        Dim nodoHijo As TreeNode
        For Each MenuItemHijo As ToolStripMenuItem In item.DropDownItems
            If MenuItemHijo.Text <> "-" Then
                nodoHijo = New TreeNode(MenuItemHijo.Text)
                nodoHijo.Checked = VerificaPermiso(MenuItemHijo.Text)
                If MenuItemHijo.HasDropDownItems Then
                    GeneraArbol(MenuItemHijo, nodoHijo)
                End If
                NodoPadre.Nodes.Add(nodoHijo)
            End If
        Next
    End Sub

    'Verifica si tiene los permisos de acceso o no
    Private Function VerificaPermiso(ByVal Nombre_Permiso As String) As Boolean
        For Each ftemp As DataRow In tbPermiso.Rows
            If ftemp.Item("nombre").ToString.ToLower.Trim = Nombre_Permiso.ToLower.Trim Then
                If ftemp.Item("acceso") = True Then
                    Return True
                Else
                    Return False
                End If
            End If
        Next
        Return False
    End Function

    'Guarda los permisos generados, recorriendo el arbol del menu 
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        For Each NodoGP As TreeNode In TreeViewPermisos.Nodes
            RecorreArbol(NodoGP)
        Next
        MsgBox("Operación realizada con éxito")
    End Sub

    'Funcion que ayuda de manera recursiva a guardar los permisos en la base de datos
    Private Sub RecorreArbol(ByRef NodoPadre As TreeNode)
        GuardaInfo(NodoPadre.Text.Trim, NodoPadre.Checked)
        For Each NodoHijo As TreeNode In NodoPadre.Nodes
            RecorreArbol(NodoHijo)
        Next
    End Sub

    'Actualiza o crea el registro del permiso en la base de datos
    Private Sub GuardaInfo(ByVal nombreModulo As String, ByVal valorAcceso As Boolean)
        Dim valB As Int16 = 0
        If valorAcceso = True Then
            valB = 1
        End If

        ' If nombreModulo.Trim = "Listado de Jefes y Subalternos" Then
        'MsgBox("guardado")
        'End If
        cadena = "select count(*) from permisos where id_rol=" & cmbRol.SelectedValue & " and nombre='" & nombreModulo.Trim & "' "
        If BuscaEscalar(cadena) > 0 Then
            cadena = "update permisos set acceso=" & valB & ",fecha='" & Today.ToShortDateString & _
            "' where id_rol=" & cmbRol.SelectedValue & " and nombre='" & nombreModulo.Trim & "' "
        Else
            cadena = "insert into permisos (id_rol,nombre,acceso,fecha) values (" & cmbRol.SelectedValue & ",'" & nombreModulo.Trim & _
            "'," & valB & ",'" & Today.ToShortDateString & "')"
        End If
        EjecutarQuery(cadena)
    End Sub


End Class
