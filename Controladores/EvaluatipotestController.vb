Public Class EvaluatipotestController

    Private cdata As cmodelo2
    Dim cadena As String = ""

    Sub New()
        cdata = New cmodelo2(_conexionAcademia)
    End Sub

    Public Function GetEvaluatipotest_grupo_evaluacion() As DataTable
        Dim tb As New DataTable
        cadena = "select tipo, nombre from evaluatipotest_tipo order by tipo"
        tb = cdata.llenaTabla(cadena)
        Return tb
    End Function



    Public Function GetEvaluatipotest_tipo() As DataTable
        Dim tb As New DataTable
        cadena = "select grupo_asignacion, nombre from evaluatipotest_grupo_asignacion order by grupo_asignacion"
        tb = cdata.llenaTabla(cadena)
        Return tb
    End Function


    Public Sub FillCombo_grupo_evaluacion(ByRef cmb As ComboBox, Optional blank As Boolean = True)
        Dim tb As DataTable = Me.GetEvaluatipotest_tipo()
        If blank Then
            tb.Rows.Add(0, "")
        End If
        If Not tb Is Nothing Then
            cmb.DataSource = tb
            cmb.DisplayMember = "nombre"
            cmb.ValueMember = "grupo_asignacion"
        End If

    End Sub

    Public Sub FillCombo_tipo(ByRef cmb As ComboBox, Optional blank As Boolean = True)

        Dim tb As DataTable = Me.GetEvaluatipotest_grupo_evaluacion()
        If blank Then
            tb.Rows.Add(0, "")
        End If
        If Not tb Is Nothing Then
            cmb.DataSource = tb
            cmb.DisplayMember = "nombre"
            cmb.ValueMember = "tipo"
        End If
    End Sub






End Class
