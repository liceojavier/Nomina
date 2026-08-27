Imports System.Data.SqlClient

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMEVALUAGRUPODT.VB MIEMBRO DE NOMINA.SLN                                   **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         09/10/2014                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmEvaluaGrupoDt

    Private grupo, area, accion, detalle As Int32
    Private WithEvents fEmp As frmMuestraCodigos
    Private tbGrupo As New DataTable("grupo")
    Private tbArea As New DataTable("area")
    Private filaTemp As DataRow
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmEvaluaGrupoDt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Limpiar()
    End Sub

    Private Sub grdDetalle_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDetalle.Click
        If grdDetalle.SelectedRows.Count > 0 Then
            If Int32.TryParse(grdDetalle.SelectedRows(0).Cells(1).Value.ToString(), detalle) Then
                txtCodigoA.Text = grdDetalle.SelectedRows(0).Cells(2).Value.ToString()
                txtNombreA.Text = grdDetalle.SelectedRows(0).Cells(3).Value.ToString()
                area = Convert.ToInt32(txtCodigoA.Text)
                accion = 1
                btnEliminar.Enabled = True
            End If
        End If
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        If area <> 0 And grupo <> 0 Then
            Dim cadena As String = ""
            Dim conexion As New DbConexion()
            lpara.Clear()
            lpara("grupo") = grupo
            lpara("area") = area
            lpara("detalle") = detalle
            Select Case accion
                Case 0
                    cadena = "insert into evaluagrupodt(id_grupo, codigo) values (@grupo,@area)"
                Case 1
                    cadena = "update evaluagrupodt set codigo = @area where id_gpdetalle =@detalle "
            End Select
            conexion.ejecutarSentencia(cadena, ListaParametros(lpara))
            Select Case accion
                Case 0
                    InsertBitacora(9, 1, Me.Text)
                Case 1
                    InsertBitacora(9, 2, Me.Text)
            End Select
            Limpiar_Area()
            Llenar_Grid_Detalle()
        Else
            MsgBox("NO HA INGRESADO UN GRUPO O UN ÁREA.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEliminar.Click
        lpara.Clear()
        lpara("detalle") = detalle
        If grdDetalle.SelectedRows.Count > 0 Then
            If MsgBox("ESTA SEGURO DE ELIMINAR EL REGISTRO MARCADO.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Mensaje del Sistema") = MsgBoxResult.Yes Then
                'verificar si tiene referencia en inscripciones
                Dim conexion As New DbConexion()
                Dim cadena As String = "delete from evaluagrupodt where id_gpdetalle =@detalle "
                conexion.ejecutarSentencia(cadena, ListaParametros(lpara))
                InsertBitacora(9, 4, Me.Text)
                Limpiar_Area()
                Llenar_Grid_Detalle()
            End If
        Else
            MsgBox("DEBE SELECCIONAR UN REGISTRO PARA ELIMINAR.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnAsignarG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignarG.Click
        If (grupo <> 0) Then
            Llenar_Grid_Detalle()
        Else
            MsgBox("NO HA INGRESADO UN GRUPO.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnAsignarA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsignarA.Click
        If Not txtCodigoA.Text.Equals("") And Not txtNombreA.Text.Equals("") Then
            Int32.TryParse(txtCodigoA.Text, area)
        Else
            MsgBox("NO HA INGRESADO UN ÁREA.", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        Limpiar()
    End Sub

    Private Sub Llenar_Grid_Detalle()
        Dim conexion As New DbConexion()
        Dim cadena As String = "select row_number() over(order by egdt.id_gpdetalle) num, egdt.id_gpdetalle, " _
            & "egdt.codigo, a.nombre area  from evaluagrupodt egdt inner join areas a on egdt.codigo = a.area where " _
            & "egdt.id_grupo = " & grupo
        grdDetalle.DataSource = conexion.Hacer_Consulta(cadena).Tables("Consulta")
        With grdDetalle
            .Columns("num").HeaderText = "NÚMERO"
            .Columns("num").Width = 75
            .Columns("id_gpdetalle").Visible = False
            .Columns("codigo").Visible = False
            .Columns("area").HeaderText = "ÁREA"
            .Columns("area").Width = 300
        End With
        gbArea.Enabled = True
    End Sub

    Private Sub Limpiar_Area()
        txtNombreA.Text = Nothing
        txtCodigoA.Text = Nothing
        btnEliminar.Enabled = False
        area = 0
    End Sub

    Private Sub Limpiar()
        Limpiar_Area()
        txtCodigoG.Text = Nothing
        txtNombreG.Text = Nothing
        grdDetalle.DataSource = Nothing
        gbArea.Enabled = False
        grupo = 0
        accion = 0
        detalle = 0
    End Sub

    Private Sub GrdDetalle_CellEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdDetalle.CellEnter
        If grdDetalle.SelectedRows.Count > 0 Then
            grdDetalle.Rows(grdDetalle.SelectedRows(0).Index).Selected = True
        End If
    End Sub

#Region "GRUPO"

    Private Sub BorraGrupo(ByVal valbool As Boolean)
        txtNombreG.Clear()
        If valbool = True Then
            txtCodigoG.Clear()
        End If
    End Sub


    Private Sub BtnBuscarG_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarG.Click
        Dim numFilas As Int32
        Dim cadena As String = "select * from evaluagrupo order by id_grupo"
        numFilas = llenaTabla(cadena, tbGrupo)
        If numFilas = 0 Then
            MsgBox("NO EXISTEN GRUPOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraGrupo(True)
            txtCodigoG.Clear()
        ElseIf numFilas = 1 Then
            BorraGrupo(True)
            filaTemp = tbGrupo.Rows.Item(0)
            txtCodigoG.Text = filaTemp.Item(0)
            txtNombreG.Text = filaTemp.Item(1)
            grupo = Convert.ToInt32(txtCodigoG.Text)
        Else
            EnBuscaGrupo()
        End If
    End Sub

    Private Sub ValidaGrupo()
        lpara.Clear()
        If valida_tipo_Entero(txtCodigoG.Text, 2) = True Then
            lpara("grupo") = txtCodigoG.Text
            Dim cadena As String = "select * from evaluagrupo where id_grupo =@grupo "
            abrir_conexion(cn)
            Dim comando As New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            Dim dr As SqlDataReader = comando.ExecuteReader
            If dr.HasRows() Then
                BorraGrupo(False)
                dr.Read()
                txtNombreG.Text = dr.GetValue(1)
                grupo = Convert.ToInt32(txtCodigoG.Text)
                dr.Close()
                cn.Close()
            Else
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL GRUPO POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraGrupo(True)
            txtCodigoG.Focus()
        End If
    End Sub

    Private Sub TxtCodigoG_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoG.Validated
        If txtCodigoG.Text.Trim <> "" And txtCodigoG.ReadOnly = False Then
            ValidaGrupo()
        ElseIf txtCodigoG.ReadOnly = False Then
            BorraGrupo(False)
        End If
    End Sub

    Private Sub EnBuscaGrupo()
        fEmp = New frmMuestraCodigos
        fEmp.TopMost = True
        fEmp.inicializa(tbGrupo)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosGrupo
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosGrupo(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraGrupo(True)
        filaTemp = tbGrupo.Rows.Item(e.va2)
        txtCodigoG.Text = filaTemp.Item(0)
        txtNombreG.Text = filaTemp.Item(1)
        grupo = Convert.ToInt32(txtCodigoG.Text)
    End Sub

#End Region

#Region "AREA"

    Private Sub BorraArea(ByVal valbool As Boolean)
        txtNombreA.Clear()
        If valbool = True Then
            txtCodigoA.Clear()
        End If
    End Sub


    Private Sub BtnBuscarA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarA.Click
        Dim numFilas As Int32
        Dim cadena As String = "select distinct area, nombre from areas order by area"
        numFilas = llenaTabla(cadena, tbArea)
        If numFilas = 0 Then
            MsgBox("NO EXISTEN ÁREAS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraArea(True)
            txtCodigoA.Clear()
        ElseIf numFilas = 1 Then
            BorraArea(True)
            filaTemp = tbArea.Rows.Item(0)
            txtCodigoA.Text = filaTemp.Item(0)
            txtNombreA.Text = filaTemp.Item(1)
        Else
            EnBuscaArea()
        End If
    End Sub

    Private Sub ValidaArea()
        lpara.Clear()
        If valida_tipo_Entero(txtCodigoG.Text, 2) = True Then
            lpara("area") = txtCodigoA.Text
            Dim cadena As String = "select distinct area, nombre from areas where area =@area "
            abrir_conexion(cn)
            Dim comando As New SqlCommand(cadena, cn)
            comando.Parameters.AddRange(ListaParametros(lpara).ToArray())
            Dim dr As SqlDataReader = comando.ExecuteReader
            If dr.HasRows() Then
                BorraArea(False)
                dr.Read()
                txtNombreA.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
            Else
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL ÁREA POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraArea(True)
            txtCodigoA.Focus()
        End If
    End Sub

    Private Sub TxtCodigoA_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoA.Validated
        If txtCodigoA.Text.Trim <> "" And txtCodigoA.ReadOnly = False Then
            ValidaArea()
        ElseIf txtCodigoA.ReadOnly = False Then
            BorraArea(False)
        End If
    End Sub

    Private Sub EnBuscaArea()
        fEmp = New frmMuestraCodigos
        fEmp.TopMost = True
        fEmp.inicializa(tbArea)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosArea
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosArea(ByVal sender As Object, ByVal e As clsActValorREvento)
        BorraArea(True)
        filaTemp = tbArea.Rows.Item(e.va2)
        txtCodigoA.Text = filaTemp.Item(0)
        txtNombreA.Text = filaTemp.Item(1)
    End Sub

#End Region

End Class