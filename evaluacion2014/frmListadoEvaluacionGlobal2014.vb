Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.IO

Public Class frmListadoEvaluacionGlobal2014

    Dim cadena As String
    Dim tabla As DataTable
    Dim tbSubreporte As DataTable
    Dim tbareas As New DataTable("areas")
    Dim asignaturas As New DataTable("Asignaturas")
    Dim tbColegio As New DataTable("colegio")
    Dim tbnivel As New DataTable("nivel")
    Dim tbgrado As New DataTable("grado")
    Dim tbTipotest As New DataTable("tipotest")
    Dim tbEmpleado As New DataTable("empleado")
    Dim tbPrincipal As DataTable




    Private Sub limpia()
        cadena = ""
        crv1.ReportSource = Nothing
        crv1.Refresh()
        tbnivel.Clear()
        tbgrado.Clear()

    End Sub

    Private Sub frmListadoEvaluacionDocentes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        limpia()
        txtCiclo.Text = DateTime.Today.Year
        cadena = "select nombre,area from areas order by area"
        llena_combo(cadena, cmbAreas)
        cmbAreas.Items.Add("")
        llenaTabla(cadena, tbareas)
      
    End Sub


   
  


    Sub realiza_reporte(ByVal ciclo As Integer, ByVal empleado As Integer, ByVal area As Integer, ByVal path As String)
        Dim tbEmpleado As New DataTable("empleado")
        Dim tbAutoJavier As New DataTable("autoevaluacionj")
        Dim tbEvaJavier As New DataTable("evaluacionj")

        cadena = "select a.empleado, a.apellido1 + '  ' + a.apellido2 + '  ' + a.nombre1 + ' ' + a.nombre2 " & _
                 " as nombre_empleado, isnull(b.area,0) as area, isnull(c.nombre,'') as nombre_area " & _
                 "from emplegen a " & _
                 "left join maestros b on a.empleado=b.empleado " & _
                 "left join areas c on b.area=c.area " & _
                 "where a.empresa=@empresa and ( " & _
                 " a.empleado in ( " & _
                 "select m.empleado from evadoctest1 e1 " & _
                 "inner join maestros m on e1.codigo=m.codigo " & _
                 "where e1.ciclo=@ciclo   ) " & _
                 " or a.empleado in (" & _
                 "select e2.empleado from evaluatest1 e2 where ciclo=@ciclo " & _
                 ") " & _
                 ") " & _
                 "order by a.apellido1, a.apellido2, a.nombre1, a.nombre2 desc "
        Dim para1 As New List(Of SqlParameter)
        para1.Add(New SqlParameter("empresa", empresa))
        para1.Add(New SqlParameter("ciclo", ciclo))
        llenaTabla(cadena, tbEmpleado, para1)


        cadena = "SELECT  area, nombre_area,avg(porcentaje) as porcentaje FROM " & _
                "(select " & _
                "ev1.numtest, ev2.area, eva.nombre as nombre_area, ev2.numpregunta, " & _
                "( cop.valor /  " & _
                "isnull((select cast( max(valor) as decimal) from evaluaopciones2 cop2 where " & _
                "cop2.ciclo=ev1.ciclo and cop2.tipotest=ev1.tipotest and cop2.numpregunta=ev2.numpregunta ),1) " & _
                ") * 100.00 as porcentaje " & _
                "from evaluatest1 ev1 " & _
                "inner join evaluatest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest " & _
                "inner join evalua_areas eva on eva.empresa=ev1.empresa and ev2.area=eva.area " & _
                "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
                "inner join evaluaopciones2 cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=ev2.numpregunta and cop.numopcion=ev2.numopcion " & _
                "where ev1.empresa=@empresa and ev1.ciclo =@ciclo And ct.tipo = 2 And cop.valor <> 0 " & _
                ") LL " & _
                "group by area,nombre_area "
        Dim paraE As New List(Of SqlParameter)
        paraE.Add(New SqlParameter("empresa", empresa))
        paraE.Add(New SqlParameter("ciclo", ciclo))
        llenaTabla(cadena, tbEvaJavier, paraE)



        cadena = "SELECT  area, nombre_area,avg(porcentaje) as porcentaje FROM " & _
                "(select " & _
                "ev1.numtest, ev2.area, eva.nombre as nombre_area, ev2.numpregunta, " & _
                "( cop.valor /  " & _
                "isnull((select cast( max(valor) as decimal) from evaluaopciones2 cop2 where " & _
                "cop2.ciclo=ev1.ciclo and cop2.tipotest=ev1.tipotest and cop2.numpregunta=ev2.numpregunta ),1) " & _
                ") * 100.00 as porcentaje " & _
                "from evaluatest1 ev1 " & _
                "inner join evaluatest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest " & _
                "inner join evalua_areas eva on eva.empresa=ev1.empresa and ev2.area=eva.area " & _
                "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
                "inner join evaluaopciones2 cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=ev2.numpregunta and cop.numopcion=ev2.numopcion " & _
                "where ev1.empresa=@empresa and ev1.ciclo =@ciclo And ct.tipo = 1 And cop.valor <> 0 " & _
                ") LL " & _
                "group by area,nombre_area "
        Dim paraA As New List(Of SqlParameter)
        paraA.Add(New SqlParameter("empresa", empresa))
        paraA.Add(New SqlParameter("ciclo", ciclo))
        llenaTabla(cadena, tbAutoJavier, paraA)


        Dim paraEmpAuto As List(Of SqlParameter)
        Dim paraEmpEva As List(Of SqlParameter)
        Dim paraAluEva As List(Of SqlParameter)
        Dim parametros As List(Of SqlParameter)
        Dim tbEmpAuto As DataTable
        Dim tbEmpEva As DataTable
        Dim tbAluEva As DataTable
        Dim tbAreaAuto As DataTable
        Dim tbAreaEva As DataTable

        Dim fnuevo As DataRow
        Dim i As Integer = 0

        For Each femp As DataRow In tbEmpleado.Rows
            i = i + 1
            tbPrincipal = New DataTable("principal")
            tbPrincipal.Columns.Add(New DataColumn("id", System.Type.GetType("System.Int32")))
            tbPrincipal.Columns.Add(New DataColumn("empleado", System.Type.GetType("System.Int32")))
            tbPrincipal.Columns.Add(New DataColumn("nombre_empleado", System.Type.GetType("System.String")))
            tbPrincipal.Columns.Add(New DataColumn("tipo_test", System.Type.GetType("System.Int32")))
            tbPrincipal.Columns.Add(New DataColumn("nombre_tipo_test", System.Type.GetType("System.String")))
            tbPrincipal.Columns.Add(New DataColumn("area", System.Type.GetType("System.Int32")))
            tbPrincipal.Columns.Add(New DataColumn("nombre_area", System.Type.GetType("System.String")))
            tbPrincipal.Columns.Add(New DataColumn("porcentaje", System.Type.GetType("System.Decimal")))
            tbPrincipal.Columns.Add(New DataColumn("descrip_cuadro", System.Type.GetType("System.String")))
            tbPrincipal.Columns("id").AutoIncrement = True


            cadena = "SELECT  area, nombre_area,avg(porcentaje) as porcentaje FROM " & _
            "(select " & _
            "ev1.numtest, ev2.area, eva.nombre as nombre_area, ev2.numpregunta, " & _
            "( cop.valor /  " & _
            "isnull((select cast( max(valor) as decimal) from evaluaopciones2 cop2 where " & _
            "cop2.ciclo=ev1.ciclo and cop2.tipotest=ev1.tipotest and cop2.numpregunta=ev2.numpregunta ),1) " & _
            ") * 100.00 as porcentaje " & _
            "from evaluatest1 ev1 " & _
            "inner join evaluatest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest " & _
            "inner join evalua_areas eva on eva.empresa=ev1.empresa and ev2.area=eva.area " & _
            "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
            "inner join evaluaopciones2 cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=ev2.numpregunta and cop.numopcion=ev2.numopcion " & _
            "where ev1.empresa=@empresa and ev1.ciclo =@ciclo And ct.tipo = 2 and ev1.empleado=@empleado And cop.valor <> 0 " & _
            ") LL " & _
            "group by area,nombre_area "
            paraEmpEva = New List(Of SqlParameter)
            paraEmpEva.Add(New SqlParameter("empresa", empresa))
            paraEmpEva.Add(New SqlParameter("ciclo", ciclo))
            paraEmpEva.Add(New SqlParameter("empleado", femp.Item("empleado")))
            tbEmpEva = New DataTable("emple-eva")
            llenaTabla(cadena, tbEmpEva, paraEmpEva)
            cadena = "Analice los resultados de la siguiente gráfica " & vbNewLine & _
                     "¿Por qué me percibe mi coordinador de esa manera? Argumenta"

            For Each fila As DataRow In tbEmpEva.Rows
                fnuevo = tbPrincipal.NewRow()
                fnuevo.Item("empleado") = femp.Item("empleado")
                fnuevo.Item("nombre_empleado") = femp.Item("nombre_empleado")
                fnuevo.Item("tipo_test") = 2
                fnuevo.Item("nombre_tipo_test") = "Hetero Evaluación "
                fnuevo.Item("area") = fila.Item("area")
                fnuevo.Item("nombre_area") = fila.Item("nombre_area")
                fnuevo.Item("porcentaje") = fila.Item("porcentaje")
                fnuevo.Item("descrip_cuadro") = cadena
                tbPrincipal.Rows.Add(fnuevo)
            Next

            cadena = "SELECT  area, nombre_area,avg(porcentaje) as porcentaje FROM " & _
                  "(select  " & _
                  "ev1.numtest, cp.area, eva.nombre as nombre_area, ev2.numpregunta, " & _
                  "( cop.valor /  " & _
                  "isnull((select cast( max(valor) as decimal) from culturaopciones cop2 where " & _
                  "cop2.ciclo=ev1.ciclo and cop2.tipotest=ev1.tipotest and cop2.numpregunta=ev2.numpregunta ),1) " & _
                  ") * 100.00 as porcentaje " & _
                  "from evadoctest1 ev1 " & _
                  "inner join evadoctest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest " & _
                  "inner join culturatipotest1 ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
                  "inner join culturapreguntas cp on ev1.ciclo=cp.ciclo and ev1.tipotest=cp.tipotest and ev2.numpregunta=cp.numpregunta " & _
                  "inner join culturaareas eva on cp.area=eva.area " & _
                  "inner join culturaopciones cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest " & _
                  "and cop.numpregunta=ev2.numpregunta and cop.numopcion=ev2.numopcion " & _
                  "inner join maestros ma on ma.codigo=ev1.codigo  " & _
                  "where(ev1.ciclo =@ciclo and ma.empleado=@empleado And cop.valor <> 0) " & _
                  ") LL " & _
                  "group by area,nombre_area "
            paraAluEva = New List(Of SqlParameter)
            paraAluEva.Add(New SqlParameter("ciclo", ciclo))
            paraAluEva.Add(New SqlParameter("empleado", femp.Item("empleado")))
            tbAluEva = New DataTable("alu-eva")
            llenaTabla(cadena, tbAluEva, paraAluEva)
            cadena = "Analice los resultados de la siguiente gráfica " & vbNewLine & _
                    "¿Por qué me percibirán de esa manera los alumnos? Busca virtudes y debilidades. " & vbNewLine & _
                    "¿Qué puedo hacer para mejorar con respecto a mis estudiantes? Enumera las ideas. "
            For Each fila As DataRow In tbAluEva.Rows
                fnuevo = tbPrincipal.NewRow()
                fnuevo.Item("empleado") = femp.Item("empleado")
                fnuevo.Item("nombre_empleado") = femp.Item("nombre_empleado")
                fnuevo.Item("tipo_test") = 3
                fnuevo.Item("nombre_tipo_test") = "Evaluación por Alumnos "
                fnuevo.Item("area") = fila.Item("area")
                fnuevo.Item("nombre_area") = fila.Item("nombre_area")
                fnuevo.Item("porcentaje") = fila.Item("porcentaje")
                fnuevo.Item("descrip_cuadro") = cadena
                tbPrincipal.Rows.Add(fnuevo)
            Next

            cadena = "SELECT  area, nombre_area,avg(porcentaje) as porcentaje FROM " & _
              "(select " & _
              "ev1.numtest, ev2.area, eva.nombre as nombre_area, ev2.numpregunta, " & _
              "( cop.valor /  " & _
              "isnull((select cast( max(valor) as decimal) from evaluaopciones2 cop2 where " & _
              "cop2.ciclo=ev1.ciclo and cop2.tipotest=ev1.tipotest and cop2.numpregunta=ev2.numpregunta ),1) " & _
              ") * 100.00 as porcentaje " & _
              "from evaluatest1 ev1 " & _
              "inner join evaluatest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest " & _
              "inner join evalua_areas eva on eva.empresa=ev1.empresa and ev2.area=eva.area " & _
              "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
              "inner join evaluaopciones2 cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=ev2.numpregunta and cop.numopcion=ev2.numopcion " & _
              "where ev1.empresa=@empresa and ev1.ciclo =@ciclo And ct.tipo = 1 and ev1.empleado=@empleado And cop.valor <> 0 " & _
              ") LL " & _
              "group by area,nombre_area "
            paraEmpAuto = New List(Of SqlParameter)
            paraEmpAuto.Add(New SqlParameter("empresa", empresa))
            paraEmpAuto.Add(New SqlParameter("ciclo", ciclo))
            paraEmpAuto.Add(New SqlParameter("empleado", femp.Item("empleado")))
            tbEmpAuto = New DataTable("emple-auto")
            llenaTabla(cadena, tbEmpAuto, paraEmpAuto)
            cadena = "Analice los resultados de la siguiente gráfica " & vbNewLine & _
                            "¿Por qué me evalué en cada rubro de esa manera? Argumenta y justifica con ejemplos concretos. " & vbNewLine & _
                            "¿Qué puedo hacer para mejorar en cada una de las competencias? Enumera las ideas. "

            For Each fila As DataRow In tbEmpAuto.Rows
                fnuevo = tbPrincipal.NewRow()
                fnuevo.Item("empleado") = femp.Item("empleado")
                fnuevo.Item("nombre_empleado") = femp.Item("nombre_empleado")
                fnuevo.Item("tipo_test") = 1
                fnuevo.Item("nombre_tipo_test") = "Auto Evaluación "
                fnuevo.Item("area") = fila.Item("area")
                fnuevo.Item("nombre_area") = fila.Item("nombre_area")
                fnuevo.Item("porcentaje") = fila.Item("porcentaje")
                fnuevo.Item("descrip_cuadro") = cadena
                tbPrincipal.Rows.Add(fnuevo)
            Next







            'If femp.Item("area") <> 0 Then
            '    cadena = "SELECT  area, nombre_area,avg(porcentaje) as porcentaje FROM " & _
            '             "(select " & _
            '             "ev1.numtest, ev2.area, eva.nombre as nombre_area, ev2.numpregunta, " & _
            '             "( cop.valor /  " & _
            '             "isnull((select cast( max(valor) as decimal) from evaluaopciones2 cop2 where " & _
            '             "cop2.ciclo=ev1.ciclo and cop2.tipotest=ev1.tipotest and cop2.numpregunta=ev2.numpregunta ),1) " & _
            '             ") * 100.00 as porcentaje " & _
            '             "from evaluatest1 ev1 " & _
            '             "inner join evaluatest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest " & _
            '             "inner join evalua_areas eva on eva.empresa=ev1.empresa and ev2.area=eva.area " & _
            '             "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
            '             "inner join evaluaopciones2 cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=ev2.numpregunta and cop.numopcion=ev2.numopcion " & _
            '             "where ev1.empresa=@empresa and ev1.ciclo =@ciclo And ct.tipo = 1 And cop.valor <> 0 " & _
            '                " and ev1.empleado in (select empleado from maestros ma where ma.area=@area) " & _
            '             ") LL " & _
            '            "group by area,nombre_area "
            '    parametros = New List(Of SqlParameter)
            '    parametros.Add(New SqlParameter("empresa", empresa))
            '    parametros.Add(New SqlParameter("ciclo", ciclo))
            '    parametros.Add(New SqlParameter("area", femp.Item("area")))
            '    tbAreaAuto = New DataTable("area-auto")
            '    llenaTabla(cadena, tbAreaAuto, parametros)
            '    For Each fila As DataRow In tbAreaAuto.Rows
            '        fnuevo = tbPrincipal.NewRow()
            '        fnuevo.Item("empleado") = femp.Item("empleado")
            '        fnuevo.Item("nombre_empleado") = femp.Item("nombre_empleado")
            '        fnuevo.Item("tipo_test") = 4
            '        fnuevo.Item("nombre_tipo_test") = "Autoevaluación de colaboradores del área"
            '        fnuevo.Item("area") = fila.Item("area")
            '        fnuevo.Item("nombre_area") = fila.Item("nombre_area")
            '        fnuevo.Item("porcentaje") = fila.Item("porcentaje")
            '        tbPrincipal.Rows.Add(fnuevo)
            '    Next

            '    cadena = "SELECT  area, nombre_area,avg(porcentaje) as porcentaje FROM " & _
            '                "(select " & _
            '                "ev1.numtest, ev2.area, eva.nombre as nombre_area, ev2.numpregunta, " & _
            '                "( cop.valor /  " & _
            '                "isnull((select cast( max(valor) as decimal) from evaluaopciones2 cop2 where " & _
            '                "cop2.ciclo=ev1.ciclo and cop2.tipotest=ev1.tipotest and cop2.numpregunta=ev2.numpregunta ),1) " & _
            '                ") * 100.00 as porcentaje " & _
            '                "from evaluatest1 ev1 " & _
            '                "inner join evaluatest2 ev2 on ev1.ciclo=ev2.ciclo and ev1.numtest=ev2.numtest " & _
            '                "inner join evalua_areas eva on eva.empresa=ev1.empresa and ev2.area=eva.area " & _
            '                "inner join evaluatipotest ct on ev1.ciclo=ct.ciclo and ev1.tipotest=ct.tipotest " & _
            '                "inner join evaluaopciones2 cop on cop.ciclo=ev1.ciclo and cop.tipotest=ev1.tipotest and cop.numpregunta=ev2.numpregunta and cop.numopcion=ev2.numopcion " & _
            '                "where ev1.empresa=@empresa and ev1.ciclo =@ciclo And ct.tipo = 2 And cop.valor <> 0 " & _
            '                " and ev1.empleado in (select empleado from maestros ma where ma.area=@area) " & _
            '                ") LL " & _
            '                "group by area,nombre_area "
            '    parametros = New List(Of SqlParameter)
            '    parametros.Add(New SqlParameter("empresa", empresa))
            '    parametros.Add(New SqlParameter("ciclo", ciclo))
            '    parametros.Add(New SqlParameter("area", femp.Item("area")))
            '    tbAreaEva = New DataTable("area-auto")
            '    llenaTabla(cadena, tbAreaEva, parametros)
            '    For Each fila As DataRow In tbAreaEva.Rows
            '        fnuevo = tbPrincipal.NewRow()
            '        fnuevo.Item("empleado") = femp.Item("empleado")
            '        fnuevo.Item("nombre_empleado") = femp.Item("nombre_empleado")
            '        fnuevo.Item("tipo_test") = 5
            '        fnuevo.Item("nombre_tipo_test") = "Evaluación General por Jefe(s) y Sub-alterno(s) colaboradores del área"
            '        fnuevo.Item("area") = fila.Item("area")
            '        fnuevo.Item("nombre_area") = fila.Item("nombre_area")
            '        fnuevo.Item("porcentaje") = fila.Item("porcentaje")
            '        tbPrincipal.Rows.Add(fnuevo)
            '    Next
            'End If

            'For Each fila As DataRow In tbAutoJavier.Rows
            '    fnuevo = tbPrincipal.NewRow()
            '    fnuevo.Item("empleado") = femp.Item("empleado")
            '    fnuevo.Item("nombre_empleado") = femp.Item("nombre_empleado")
            '    fnuevo.Item("tipo_test") = 6
            '    fnuevo.Item("nombre_tipo_test") = "Autoevaluación General de la Institución"
            '    fnuevo.Item("area") = fila.Item("area")
            '    fnuevo.Item("nombre_area") = fila.Item("nombre_area")
            '    fnuevo.Item("porcentaje") = fila.Item("porcentaje")
            '    tbPrincipal.Rows.Add(fnuevo)
            'Next

            'For Each fila As DataRow In tbEvaJavier.Rows
            '    fnuevo = tbPrincipal.NewRow()
            '    fnuevo.Item("empleado") = femp.Item("empleado")
            '    fnuevo.Item("nombre_empleado") = femp.Item("nombre_empleado")
            '    fnuevo.Item("tipo_test") = 7
            '    fnuevo.Item("nombre_tipo_test") = "Evaluación General de ña"
            '    fnuevo.Item("area") = fila.Item("area")
            '    fnuevo.Item("nombre_area") = fila.Item("nombre_area")
            '    fnuevo.Item("porcentaje") = fila.Item("porcentaje")
            '    tbPrincipal.Rows.Add(fnuevo)
            'Next
            Try
                If Not File.Exists(path & "\" & femp.Item("empleado") & "-" & femp.Item("nombre_empleado") & ".pdf") Then
                    Dim r As New ListadoTEva2014
                    r.SetDataSource(tbPrincipal)
                    r.PrintOptions.PaperSize = PaperSize.PaperFolio
                    r.ExportToDisk(ExportFormatType.PortableDocFormat, path & "\" & femp.Item("empleado") & "-" & femp.Item("nombre_empleado") & ".pdf")
                End If
            Catch ex As Exception
                MsgBox("Error en la exportacion " & vbNewLine & ex.Message, MsgBoxStyle.Critical, "Mensaje del Sistema")
            End Try

        Next
    End Sub


    

#Region "EMLEADO"

    Private Sub BorraEmpleado(ByVal valbool As Boolean)
        textNombreEmple.Clear()
        If valbool = True Then
            textConxEmpleado.Clear()
        End If
    End Sub


    Private Sub btnEmpleadoNomb_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpleado.Click
        Dim numFilas As Integer
        Dim filaTemp As DataRow
        cadena = "select empleado, nombre from v_empleadosNuevo where empresa=" & empresa & " and nombre like '%" & _
        textNombreEmple.Text.Trim & "%'  order by nombre"
        tbEmpleado = New DataTable("empleado")
        numFilas = llenaTabla(cadena, tbEmpleado)
        If numFilas = 0 Then
            MsgBox("NO EXISTEN EMPLEADOS CON ESTE CRITERIO DE BUSQUEDA", MsgBoxStyle.Information, "Mensaje del Sistema")
            BorraEmpleado(True)
            textConxEmpleado.Clear()
        ElseIf numFilas = 1 Then
            BorraEmpleado(True)
            filaTemp = tbEmpleado.Rows.Item(0)
            textConxEmpleado.Text() = filaTemp.Item(0)
            textNombreEmple.Text = filaTemp.Item(1)
            btnGenerar.Focus()
        Else
            EnBuscaEmpleado()
        End If
    End Sub

    Private Sub ValidaEmpleado()
        If valida_tipo_Entero(textConxEmpleado.Text, 2) = True Then
            Dim comando As SqlCommand
            Dim dr As SqlDataReader
           
            cadena = "select empleado, nombre from v_empleadosNuevo where empresa=" & empresa & _
                 " and empleado=" & textConxEmpleado.Text.Trim
            abrir_conexion(cn)
            comando = New SqlCommand(cadena, cn)
            dr = comando.ExecuteReader
            If dr.HasRows() Then
                BorraEmpleado(False)
                dr.Read()
                textNombreEmple.Text = dr.GetValue(1)
                dr.Close()
                cn.Close()
                btnGenerar.Focus()
            Else
                MsgBox("CODIGO DEL EMPLEADO NO EXISTE, VERIFIQUE", MsgBoxStyle.Information, "Mensaje del Sistema")
                BorraEmpleado(True)
                textConxEmpleado.Focus()
                dr.Close()
                cn.Close()
            End If
        Else
            MsgBox("CODIGO DEL EMPLEADO POSEE FORMATO INVALIDO, VERIFIQUE", MsgBoxStyle.Critical, "Mensaje del Sistema")
            BorraEmpleado(True)
            textConxEmpleado.Focus()
        End If
    End Sub

    Private Sub TextEmpleado_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles textConxEmpleado.Validated
        If textConxEmpleado.Text.Trim <> "" Then
            ValidaEmpleado()
        Else
            BorraEmpleado(False)
        End If
    End Sub

    Private Sub EnBuscaEmpleado()
        Dim fEmp As New frmMuestra2Columnas
        fEmp.TopMost = True
        fEmp.inicializa(tbEmpleado, "CODIGO", "NOMBRE", 0)
        AddHandler fEmp.actValor, AddressOf ActualizacionDatosEmpleados
        fEmp.StartPosition = FormStartPosition.CenterScreen
        fEmp.ShowDialog()
        btnGenerar.Focus()
    End Sub

    Private Sub ActualizacionDatosEmpleados(ByVal sender As Object, ByVal e As clsActValorREvento)
        Dim filaTemp As DataRow
        BorraEmpleado(True)
        filaTemp = tbEmpleado.Rows.Item(e.va2)
        textConxEmpleado.Text() = filaTemp.Item(0)
        textNombreEmple.Text = filaTemp.Item(1)
    End Sub

#End Region





    Private Sub btnGenerar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click
        Dim destino As String = ""
       
        If Not validetError(txtCiclo, ep1) Then
            MsgBox("DEBE INGRESAR TODOS LOS CAMPOS REQUERIDOS", MsgBoxStyle.Information, "Mensaje del Sistema")
            Exit Sub
        End If
        fbdFolder.ShowNewFolderButton = True
        fbdFolder.ShowDialog()
        destino = fbdFolder.SelectedPath
        If Not String.IsNullOrEmpty(destino) Then
            realiza_reporte(CInt(txtCiclo.Text), 1062, 0, destino)
        Else
            MsgBox("No selecciono ningún folder, verifique".ToUpper(), MsgBoxStyle.Exclamation, "Mensaje del Sistema")
        End If
    End Sub

    Private Sub btnLimpiar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLimpiar.Click
        crv1.ReportSource = Nothing
        cmbAreas.SelectedIndex = -1
    End Sub

    Private Sub btnAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerar.Click

    End Sub

    Private Sub txtCiclo_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCiclo.Validated

    End Sub

    Private Sub rdbPreguntas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

End Class