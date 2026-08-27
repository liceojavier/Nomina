Imports System.Data.SqlClient
Public Class frmAutorizacion_arbol
    Dim WithEvents f1 As frmMuestraUsuarios
    Friend WithEvents tt As System.Windows.Forms.ToolTip
    Dim realizar, realizar1, realizar2 As Boolean
    Dim unavez, unavez1, unavez2 As Boolean
    Dim cadena As String = ""
    Dim tbsubalterno As New DataTable("subalterno")
    Dim tbjefe As New DataTable("jefe")
    'Dim incremento As Integer = 1
    Dim auto_padre As Integer
    Dim auto_id As Integer
    Dim lpara As New Dictionary(Of String, Object)

    Private Class TreeMenu
        Public Codigo As Integer
        Public Padre As Integer
        Public empleado As String
        Public jefe As String
        Public nombre As String
    End Class

#Region "Empleado"
    Private Sub btnEmpleado_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        'lpara.Clear()
        'lpara("nombre") = TextNombEmpleado.Text
        If TextNombEmpleado.Text <> "" Then
            cadena = "select a.* from (select distinct(a.empleado),a.nombre1+' '+a.nombre2+' '+a.apellido1+' '+a.apellido2 as nombre from contratos1 b inner join emplegen a on a.empleado=b.empleado " &
                     " where b.estado in (0,4)) a where a.nombre like '%" & TextNombEmpleado.Text & "%' order by a.empleado"
        Else
            cadena = "select * from (select distinct(a.empleado),a.nombre1+' '+a.nombre2+' '+a.apellido1+' '+a.apellido2 as nombre  from contratos1 b inner join emplegen a on a.empleado=b.empleado " &
                     " where b.estado in (0,4)) a order by a.empleado"
        End If
        f1 = New frmMuestraUsuarios
        realizar = True
        If (unavez = False) Then
            AddHandler f1.actValor, AddressOf ActualizacionDatos
            unavez = True
            unavez1 = False
        End If
        f1.inicializa(cadena)
        f1.TopMost = True
        f1.ShowDialog()
    End Sub

    Private Sub ActualizacionDatos(ByVal sender As Object, ByVal e As clsActValorREvento) Handles f1.actValor
        'Este es un evento creado para ir a traer datos en tiempo real de otra forma
        If (realizar = True) Then
            TextEmpleado.Text = e.va2
            tt1.SetToolTip(TextNombEmpleado, e.va1)
            TextEmpleado_Validated(sender, e)
            realizar = False
            unavez = False
            realizar1 = False
            unavez1 = False
        End If
    End Sub

    Private Sub TextEmpleado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextEmpleado.Validated
        lpara.Clear()
        lpara("empleado") = TextEmpleado.Text
        If TextEmpleado.Text <> "" Then
            cadena = "select a.nombre1+' '+a.nombre2+' '+a.apellido1+' '+a.apellido2 from emplegen a where empleado =@empleado"
            abrir_conexion(cn)
            Dim com As New SqlCommand(cadena, cn)
            com.Parameters.AddRange(ListaParametros(lpara).ToArray())
            If com.ExecuteScalar Is Nothing Then
                cn.Close()
                MsgBox("NO EXISTE ESE EMPLEADO")
                tt1.SetToolTip(TextEmpleado, "")
                TextEmpleado.Clear()
                TextEmpleado.Focus()
            Else
                TextNombEmpleado.Text = com.ExecuteScalar
                tt1.SetToolTip(TextEmpleado, Trim(com.ExecuteScalar))
                cn.Close()

            End If

        End If
    End Sub
#End Region

#Region "jefe"

    Private Sub btnJefe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJefe.Click
        'lpara.Clear()
        'lpara("nombre") = txtNomJefe.Text
        If txtNomJefe.Text <> "" Then
            cadena = "select * from(select distinct(a.empleado),a.nombre1+' '+a.nombre2+' '+a.apellido1+' '+a.apellido2 as nombre from contratos1 b inner join emplegen a on a.empleado=b.empleado " &
                     " where b.estado in (0,4)) a where a.nombre like '%" & txtNomJefe.Text & " %' order by a.empleado"
        Else
            cadena = " select * from (select distinct(a.empleado),a.nombre1+' '+a.nombre2+' '+a.apellido1+' '+a.apellido2 as nombre  from contratos1 b inner join emplegen a on a.empleado=b.empleado " & _
                     " where b.estado in (0,4)) a order by a.empleado"
        End If
        f1 = New frmMuestraUsuarios
        realizar1 = True
        If (unavez1 = False) Then
            AddHandler f1.actValor, AddressOf ActualizacionDatos1
            unavez1 = True
            unavez = False
        End If
        f1.inicializa(cadena)
        f1.TopMost = True
        f1.ShowDialog()
    End Sub

    Private Sub ActualizacionDatos1(ByVal sender As Object, ByVal e As clsActValorREvento) Handles f1.actValor
        'Este es un evento creado para ir a traer datos en tiempo real de otra forma
        If (realizar1 = True) Then
            txtCodJefe.Text = e.va2
            tt1.SetToolTip(txtCodJefe, e.va1)
            txtcodJefe_Validated(sender, e)
            realizar1 = False
            unavez1 = False
            realizar = False
            unavez = False
        End If
    End Sub

    Private Sub txtcodJefe_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodJefe.Validated
        lpara.Clear()
        lpara("empleado") = txtCodJefe.Text
        If txtCodJefe.Text <> "" Then
            cadena = "select a.nombre1+' '+a.nombre2+' '+a.apellido1+' '+a.apellido2 from emplegen a where empleado=@empleado"
            abrir_conexion(cn)
            Dim com As New SqlCommand(cadena, cn)
            com.Parameters.AddRange(ListaParametros(lpara).ToArray())
            If com.ExecuteScalar Is Nothing Then
                cn.Close()
                MsgBox("NO EXISTE ESE EMPLEADO")
                tt1.SetToolTip(txtCodJefe, "")
                txtCodJefe.Clear()
                txtCodJefe.Focus()
            Else
                txtNomJefe.Text = com.ExecuteScalar
                tt1.SetToolTip(txtCodJefe, Trim(com.ExecuteScalar))
                cn.Close()

            End If

        End If
    End Sub

#End Region

    Sub limpiar()
        trvwJefe.Nodes.Clear()
        TextEmpleado.Clear()
        TextNombEmpleado.Clear()
        txtCodJefe.Clear()
        txtNomJefe.Clear()
        gbArbol.Enabled = False
    End Sub


    Private Sub frmAutorizacion_arbol_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        auto_id = 1
        lpara.Clear()
        lpara("empresa") = empresa
        Try
            limpiar()
            cadena = "select nombre from empresas where empresa =@empresa"
            abrir_conexion(cn)
            Dim com As New SqlCommand(cadena, cn)
            com.Parameters.AddRange(ListaParametros(lpara).ToArray())
            TextNombEmpresa.Text = com.ExecuteScalar
            cn.Close()
            cadena = "select * from requisicion_autorizacion where 1=2"
            llenaTabla(cadena, tbjefe)
        Catch ex As Exception
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "Mensaje del sistema")
        End Try

    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click
        lpara.Clear()
        lpara("empleado") = TextEmpleado.Text
        lpara("empresa") = empresa
        If TextEmpleado.Text <> "" Then
            cadena = " WITH autorizador(id,id_padre,empleado,jefe)" &
                     " AS( SELECT id,0 AS id_padre,empleado,jefe FROM requisicion_autorizacion WHERE id_padre =0 and empleado=@empleado and empresa=@empresa " &
                     " UNION ALL " &
                     " SELECT a.id,a.id_padre,a.empleado,a.jefe FROM requisicion_autorizacion a" &
                     " INNER JOIN autorizador b  ON a.id_padre = b.id " &
                     "  ) SELECT b.id,b.id_padre,b.empleado,b.jefe,c.nombre1+' '+c.nombre2+' '+c.apellido1+' '+c.apellido2 as nombre FROM autorizador b" &
                     " inner join emplegen c on b.jefe=c.empleado order by id, id_padre"
            llenaTabla(cadena, tbjefe, ListaParametros(lpara))
            Dim filas() As DataRow
            If tbjefe.Rows.Count > 0 Then
                filas = tbjefe.Select("id_padre = 0")
                Dim hijos() As DataRow
                If filas.Count > 0 Then

                    Dim nuevonodo As New TreeNode
                    Dim nodo As TreeNode

                    For Each row As DataRow In filas
                        Dim elemento As New TreeMenu
                        elemento.empleado = row.Item("empleado")
                        elemento.jefe = row.Item("jefe")
                        elemento.Padre = 0
                        elemento.Codigo = row.Item("id")
                        nodo = New TreeNode(row.Item("jefe") & " " & row("nombre").ToString())
                        hijos = tbjefe.Select("id_padre = " & elemento.Codigo)
                        nodo.Tag = elemento
                        If (hijos.Count > 0) Then
                            GeneraArbol(tbjefe, nodo, hijos)
                        End If
                        trvwJefe.Nodes.Add(nodo)
                    Next
                End If
            Else
                If MsgBox("EL USUARIO NO TIENE JEFES ASIGNADOS ¿DESEA AGREGARLE JEFE?", MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                    gbArbol.Enabled = True
                Else
                    limpiar()
                    Exit Sub
                End If

            End If
        End If
        maximo_valor()
        trvwJefe.ExpandAll()
        gbArbol.Enabled = True
        trvwJefe.SelectedNode = Nothing

    End Sub

    Private Sub GeneraArbol(ByVal tbData As DataTable, ByRef NodoPadre As TreeNode, ByVal fila() As DataRow)
        Dim nodoHijo As TreeNode
        Dim hijos() As DataRow
        Dim elemento As TreeMenu
        For Each row As DataRow In fila
            elemento = New TreeMenu
            elemento.empleado = row.Item("empleado")
            elemento.jefe = row.Item("jefe")
            elemento.Padre = row.Item("id_padre")
            elemento.Codigo = row.Item("id")
            nodoHijo = New TreeNode(row.Item("jefe") & " " & row("nombre").ToString())
            hijos = tbjefe.Select("id_padre = " & elemento.Codigo)
            nodoHijo.Tag = elemento
            If (hijos.Count > 0) Then
                GeneraArbol(tbData, nodoHijo, hijos)
            End If
            NodoPadre.Nodes.Add(nodoHijo)
        Next
    End Sub

    Public Sub maximo_valor()
        Dim fila() As DataRow
        fila = tbjefe.Select("id = MAX(id)")
        If fila.Count > 0 Then
            auto_id = CInt(fila(0).Item("id"))
        End If
    End Sub

    Private Sub btnAgregaJefe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAgregaJefe.Click

        Dim nodo As TreeNode
        Dim elemento, telemento As TreeMenu
        auto_id = auto_id + 1
        If txtCodJefe.Text = "" Or txtNomJefe.Text = "" Then
            MsgBox("Primero ingrese un Autorizador", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        If trvwJefe.SelectedNode Is Nothing Then
            elemento = New TreeMenu
            elemento.Codigo = auto_id
            elemento.Padre = 0
            elemento.empleado = CInt(TextEmpleado.Text)
            elemento.jefe = CInt(txtCodJefe.Text)
            elemento.nombre = txtNomJefe.Text
            nodo = New TreeNode(txtCodJefe.Text & " " & txtNomJefe.Text.ToString)
            nodo.Tag = elemento
            trvwJefe.Nodes.Add(nodo)
        Else
            telemento = trvwJefe.SelectedNode.Tag
            elemento = New TreeMenu
            elemento.Codigo = auto_id
            elemento.Padre = telemento.Codigo
            elemento.empleado = CInt(TextEmpleado.Text)
            elemento.jefe = CInt(txtCodJefe.Text)
            elemento.nombre = txtNomJefe.Text
            nodo = New TreeNode(txtCodJefe.Text & " " & txtNomJefe.Text.ToString)
            nodo.Tag = elemento
            trvwJefe.SelectedNode.Nodes.Add(nodo)
        End If
        trvwJefe.ExpandAll()
        txtCodJefe.Clear()
        txtNomJefe.Clear()
        trvwJefe.SelectedNode = Nothing

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSave.Click
        Try

            'cadena = "delete requisicion_autorizacion where empleado=" & TextEmpleado.Text
            'EjecutarQuery(cadena)
            For Each r As DataRow In tbjefe.Rows
                cadena = "delete requisicion_autorizacion where id=" & r.Item("id")
                EjecutarQuery(cadena)
            Next

            For Each nodo As TreeNode In trvwJefe.Nodes
                guarda_nodo(nodo, 0)
            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            Exit Sub
        End Try
        MsgBox("Operanción realizada con Éxito", MsgBoxStyle.Information, "Mensaje del Sistema")
        gbArbol.Enabled = False
        limpiar()
    End Sub


    Private Sub guarda_nodo(ByVal nodoPadre As TreeNode, ByVal id_padre As Integer)
        Dim dpara As New Dictionary(Of String, Object)
        Dim elemento As TreeMenu
        Dim id As Integer
        If (nodoPadre.Tag IsNot Nothing) Then
            elemento = nodoPadre.Tag
            cadena = " insert into requisicion_autorizacion (empresa,jefe,empleado,id_padre)  values(@empresa,@jefe,@empleado,@id_padre)" & _
                       " SELECT SCOPE_IDENTITY();"
            dpara("empresa") = empresa
            dpara("jefe") = elemento.jefe
            dpara("empleado") = elemento.empleado
            dpara("id_padre") = id_padre
            id = BuscaEscalar(cadena, ListaParametros(dpara))
        End If
        If (nodoPadre.Nodes.Count > 0) Then
            guarda_nodo(nodoPadre.Nodes(0), id)
        End If
    End Sub

    Private Sub btnDeletNodo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeletNodo.Click

        If trvwJefe.SelectedNode Is Nothing Then
            MsgBox("Primero seleccione el Nodo a Eliminar", MsgBoxStyle.Critical, "Mensaje del Sistema")
            Exit Sub
        Else
            trvwJefe.SelectedNode.Remove()
        End If
        trvwJefe.SelectedNode = Nothing
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        limpiar()
    End Sub
End Class