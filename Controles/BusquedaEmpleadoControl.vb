Imports ControlesERP

Public Class BusquedaEmpleadoControl


    Dim cadena As String = ""

    Public Property id_empresa As Int16 = 0

    Public Property Empleado As Int32 = 0

    Public Property Contrato As Int32 = 0

    Public Property Nombre As String = ""

    ' Public cd As capa_datos


    Public Property activo As Boolean = 0

    Sub New()

        ' Esta llamada es exigida por el diseñador.
        InitializeComponent()

        ' Agregue cualquier inicialización después de la llamada a InitializeComponent().
        '   cd = New capa_datos(Singleton2.Instance.conexion)
    End Sub


    Dim tbData As New DataTable
    Dim filaTemp As DataRow
    Dim lpara As New Dictionary(Of String, Object)

    Public Sub EraserForm()
        NameTxt.Clear()
        CodTxt.Clear()
        Me.Empleado = 0
        Me.Nombre = 0
        Me.Contrato = 0
    End Sub


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SearchBtn.Click
        Dim numFilas As Int32
        Dim condi As String = ""
        lpara("empresa") = Me.id_empresa
        lpara("nombre") = NameTxt.Text.Trim()
        If Me.activo Then
            condi = " and activo = 1 "
        End If

        cadena = $"select empleado, nombre from v_empleadosNuevo where empresa=@empresa and nombre like '%' + @nombre + '%' {condi} order by nombre"
        numFilas = llenaTabla(cadena, tbData, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("No existen empleados con este criterio de búsqueda", MsgBoxStyle.Information, "Mensaje del Sistema")
            EraserForm()
        ElseIf numFilas = 1 Then
            Assign(tbData.Rows.Item(0))


        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        Dim condi As String = ""
        If Int32.TryParse(CodTxt.Text, Me.Empleado) Then
            lpara("empresa") = Me.id_empresa
            lpara("empleado") = Me.Empleado
            If Me.activo Then
                condi = " and activo = 1 "
            End If


            If BuscaEscalar("select count (*) from v_empleadosNuevo where empresa=@empresa " +
                 "and empleado=@empleado" + condi, ListaParametros(lpara)) = 0 Then
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                EraserForm()
                CodTxt.Focus()
                Exit Sub
            End If
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=@empresa " &
                 "and empleado=@empleado" + condi + " order By nombre"
            llenaTabla(cadena, tbData, ListaParametros(lpara))
            If tbData.Rows.Count > 0 Then
                Assign(tbData.Rows(0))


            Else
                EraserForm()
            End If
        Else
            MsgBox("Código de empleado no existe, verifique", MsgBoxStyle.Critical, "Mensaje del Sistema")
            EraserForm()
            CodTxt.Focus()
        End If
    End Sub

    Private Sub TextEmpleado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles CodTxt.Validated

        If CodTxt.Text.Trim <> "" Then
            ValidaEmpleado()
        Else
            EraserForm()
        End If
    End Sub



    Private Sub Assign(fila As DataRow)

        CodTxt.Text() = fila.Item("empleado")
        NameTxt.Text = fila.Item("nombre")
        Me.Empleado = fila.Item("empleado")
        Me.Nombre = fila.Item("nombre")
        VerificaEmpleado()
    End Sub

    Private Sub EnBuscaEmpleado()
        Dim fEmp As New FormMuestraCodigo
        fEmp.TopMost = True
        fEmp.inicializa(tbData)
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        If (fEmp.fila IsNot Nothing) Then
            Assign(fEmp.fila)
        End If
    End Sub



    Private Sub VerificaEmpleado()
        lpara("empresa") = Me.id_empresa
        lpara("empleado") = Me.Empleado
        Me.Contrato = BuscaEscalar("select coalesce(max(contrato), 0) from contratos1 where empresa=@empresa " &
        " and empleado=@empleado", ListaParametros(lpara))
    End Sub

    Private Function validaEmpleado(id_empleado As Int32) As DataRow

        lpara("id_empleado") = id_empleado
        cadena = "select empleado, apellido1 + ' ' + apellido2 + ' ' + nombre1 + ' ' + nombre2  as nombre, empleado 
                 from emplegen where  empleado=@id_empleado order by apellido1, apellido2, nombre1, nombre2"
        llenaTabla(cadena, tbData, ListaParametros(lpara))
        If tbData.Rows.Count = 1 Then
            Return tbData.Rows(0)
        Else
            Return Nothing
        End If

    End Function
    Public Function asigna_empleado(idEmpleado As Int32) As Boolean
        Dim dr = validaEmpleado(idEmpleado)
        If (dr IsNot Nothing) Then
            CodTxt.Text = dr("empleado")
            NameTxt.Text = dr("nombre")
            Me.Empleado = idEmpleado
            Return True
        End If
        Return False
    End Function


End Class
