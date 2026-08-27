Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine

'*************************************************************************************************
'*************************************************************************************************
'**  FORMULARIO:    FRMCONSULTAJEFES.VB MIEMBRO DE NOMINA.SLN                                   **
'**  AUTOR:         IVAN TRUJILLO                                                               **
'**  FECHA:         01/04/2013                                                                  **
'**  FECHA DE MOD:  --/--/----                                                                  **
'**  DESCRIPCION:                                                                               **
'*************************************************************************************************
'*************************************************************************************************

Public Class frmConsultaxMaestrosEvaluados
    'Inherits frmPrincipal

    Dim tbTipo As New DataTable("tipo")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbCodigo As New DataTable("codigo")
    Dim tbMotivoEvento As New DataTable("motivos")
    Dim tbtipoevaluacion As New DataTable("tipoevaluacion")
    Dim comando As SqlCommand
    Dim dr As SqlDataReader
    Dim filaTemp As DataRow
    Dim tt As New DataTable("datos")
    Dim cadena As String
    Dim cadenasub As String
    Dim v As cryconsultamaestrosevaluadosxgrado
    Dim lpara As New Dictionary(Of String, Object)

    Private Sub frmConsultaxMaestrosEvaluados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lpara.Clear()
        lpara("empresa") = empresa
        TextEmpresa.Text = BuscaEscalar("select nombre from empresas where empresa=@empresa", ListaParametros(lpara))
        txtCiclo.Text = Now.Year.ToString
    End Sub

    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        lpara.Clear()
        lpara("tipotest") = tbtipoevaluacion.Rows(cmbTipoEvaluacion.SelectedIndex).Item("tipotest")
        Me.Cursor = Cursors.WaitCursor

        If Not validetError(cmbTipoEvaluacion, ep1) Then
            MsgBox("INGRESE UN TIPO DE EVALUACION", MsgBoxStyle.Exclamation, "Mensaje del Sistema")
            Exit Sub
        End If

        Dim v As New cryconsultamaestrosevaluadosxgrado
        cadena = "select a.colegio,a.nivel,a.grado,d.numpregunta,d.pregunta,c.opcion, count(b.numopcion) as totopcion" &
                 " from evadoctest1 a " &
                 " inner join evadoctest2 b on a.numtest=b.numtest " &
                 " inner join culturaopciones c on b.numopcion=c.numopcion and a.ciclo=c.ciclo and a.tipotest=c.tipotest " &
                 " inner join culturapreguntas d on b.numpregunta=d.numpregunta and a.ciclo=d.ciclo and a.tipotest=d.tipotest " &
                 " where a.tipotest = @tipotest" &
                 " group by a.colegio,a.nivel,a.grado,d.numpregunta,d.pregunta,c.opcion "

        If llenaTabla(cadena, tt, ListaParametros(lpara)) > 0 Then

            v.SetDataSource(tt)
            v.SetParameterValue("tipotest", cmbTipoEvaluacion.Text)
            Me.Cursor = Cursors.WaitCursor
            crv.ReportSource = v

        Else
            MsgBox("NO HAY DATOS PARA PODER GENERAR ESTE LISTADO", MsgBoxStyle.Information, "Mensaje del Sistema")
        End If
        Me.Cursor = Cursors.Default


    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        cadena = ""
        cadenasub = ""
        cmbTipoEvaluacion.SelectedIndex = -1
        crv.ReportSource = Nothing
    End Sub

    Private Sub txtCiclo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCiclo.Validated
        lpara.Clear()
        lpara("ciclo") = txtCiclo.Text
        If Not validetError(txtCiclo, ep1) Then
            MsgBox("INGRESE UN CICLO VALIDO", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        cadena = "select nombretest,tipotest from culturatipotest1 where ciclo=@ciclo and id_tipo=2"
        llenaTabla(cadena, tbtipoevaluacion, ListaParametros(lpara))
        llena_combo(cadena, cmbTipoEvaluacion, ListaParametros(lpara))

    End Sub
End Class