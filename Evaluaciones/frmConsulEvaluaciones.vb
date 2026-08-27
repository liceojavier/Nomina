Imports System.Data.SqlClient

Public Class frmConsulEvaluaciones
    Dim objquery As New cquery(_conexionAcademia)
    Dim tbTipoEvaluacion As New DataTable

    Private Sub frmConsulEvaluaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtCiclo.Text = Today.Year
    End Sub



    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim parametros As New List(Of SqlParameter)
        If validetError(txtCiclo, ep1) Then
            Dim v As New cryListadoEvaluacion
            Dim condicion As String = ""
            Dim tbData As New DataTable
            parametros.Add(New SqlParameter("ciclo", CInt(txtCiclo.Text)))
            If txtCodigoTE.Text.Trim <> "" Then
                condicion = " and a.tipotest=@tipotest "
                parametros.Add(New SqlParameter("tipotest", CInt(txtCodigoTE.Text)))
            End If

            Dim cadena As String = "select a.ciclo, a.tipotest, a.nombre, " & _
                                   "isnull(b.instrucciones,'') as instrucciones, isnull(b.numpregunta,0) as numpreguntra, isnull(b.pregunta,'') as pregunta, " & _
                                   "isnull(c.numopcion,0) as numopcion, isnull(c.opcion,'') as opcion, isnull(c.valor,0) as valor " & _
                                   "from evaluatipotest a " & _
                                   "left join evaluapreguntas b on a.ciclo=b.ciclo and a.tipotest=b.tipotest " & _
                                   "left join evaluaopciones c on b.empresa=c.empresa and b.ciclo=c.ciclo and b.tipotest=c.tipotest and c.numpregunta=b.numpregunta " & _
                                   "where a.ciclo=@ciclo " & condicion & " order by a.tipotest, b.numpregunta, c.numopcion "
            objquery.llenaTabla(cadena, tbData, parametros)
            If tbData.Rows.Count > 0 Then
                v.SetDataSource(tbData)
                crv.ReportSource = v

            Else
                MsgBox("NO EXISTEN REGISTROS CON ESTOS CRITERIOS DE BUSQUEDA ", MsgBoxStyle.Information, "Mensaje del Sistema")
            End If
        End If
    End Sub


#Region "Tipo de Evaluacion"

    Private Sub BorraTipoEvaluacion(ByVal valbool As Boolean)
        txtNombreTE.Clear()
        If valbool = True Then
            txtCodigoTE.Clear()
        End If
    End Sub


    Private Sub BtnBuscarTE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscarTE.Click
        Dim numFilas As Int32
        Dim filaTemp As DataRow
        Dim lpara As New Dictionary(Of String, Object)
        lpara("ciclo") = txtCiclo.Text
        tbTipoEvaluacion = New DataTable
        Dim cadena As String = "select tipotest, nombre from evaluatipotest where ciclo = @ciclo order by ciclo, tipotest"
        numFilas = objquery.llenaTabla(cadena, tbTipoEvaluacion, ListaParametros(lpara))
        If numFilas = 0 Then
            MsgBox("NO EXISTEN TIPOS DE EVALUACION CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraTipoEvaluacion(True)
            txtCodigoTE.Clear()
        ElseIf numFilas = 1 Then
            BorraTipoEvaluacion(True)
            filaTemp = tbTipoEvaluacion.Rows.Item(0)
            txtCodigoTE.Text = filaTemp.Item(0)
            txtNombreTE.Text = filaTemp.Item(1)
        Else
            EnBuscaTipoEvaluacion()
        End If
    End Sub

    Private Sub ValidaTipoEvaluacion()
        Dim filaTemp As DataRow
        Dim lpara As New Dictionary(Of String, Object)
        lpara("ciclo") = txtCiclo.Text
        lpara("tipotest") = txtCodigoTE.Text.Trim()
        If valida_tipo_Entero(txtCodigoTE.Text, 2) = True Then
            Dim tbTemp As New DataTable
            Dim cadena As String = "select tipotest, nombre from evaluatipotest where ciclo =@ciclo and tipotest=@tipotest"
            objquery.llenaTabla(cadena, tbTemp, ListaParametros(lpara))
            If tbTemp.Rows.Count > 0 Then
                filaTemp = tbTemp.Rows(0)
                txtCodigoTE.Text = filaTemp.Item(0)
                txtNombreTE.Text = filaTemp.Item(1)
            End If
        Else
            MsgBox("CODIGO DEL TIPO DE EVALUACION POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraTipoEvaluacion(True)
            txtCodigoTE.Focus()
        End If
    End Sub

    Private Sub TxtCodigoTE_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCodigoTE.Validated
        If txtCodigoTE.Text.Trim <> "" And txtCodigoTE.ReadOnly = False Then
            ValidaTipoEvaluacion()
        ElseIf txtCodigoTE.ReadOnly = False Then
            BorraTipoEvaluacion(False)
        End If
    End Sub

    Private Sub EnBuscaTipoEvaluacion()
        Dim fEmp As New frmMuestraCodigos
        fEmp.TopMost = True
        fEmp.inicializa(tbTipoEvaluacion)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosTipoEvaluacion
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
    End Sub

    Private Sub ActualizacionDatosTipoEvaluacion(ByVal sender As Object, ByVal e As clsActValorREvento)
        Dim filaTemp As DataRow
        BorraTipoEvaluacion(True)
        filaTemp = tbTipoEvaluacion.Rows.Item(e.va2)
        txtCodigoTE.Text = filaTemp.Item(0)
        txtNombreTE.Text = filaTemp.Item(1)
    End Sub

#End Region

    Private Sub btnLimpiar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        crv.ReportSource = Nothing
        txtNombreTE.Clear()
        txtCodigoTE.Clear()
    End Sub
End Class