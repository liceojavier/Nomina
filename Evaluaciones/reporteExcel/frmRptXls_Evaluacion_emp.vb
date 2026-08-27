Imports ClosedXML.Excel

Public Class frmRptXls_Evaluacion_emp
    Dim cadena As String = ""
    Dim lpara As New Dictionary(Of String, Object)
    Dim tbDatos As New DataTable()
    Dim filas() As DataRow
    Dim cn_acad As New cquery(_conexionAcademia)
    Dim opcion As Short

    Private Sub frmRptXls_Evaluacion_emp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'pnArea.Visible = False
        pnIndividual.Visible = True
        txtAñoi.Text = Now.Year
        CtrlBusqEmp.id_empresa = empresa
        EscribeEmpresa(TextNombEmpresa, TextMoneEmpresa)
    End Sub

    Public Function obtener_area(ByVal emp As Int32) As String

        lpara.Clear()
        lpara("emp") = emp
        lpara("empresa") = empresa
        cadena = "select c.nombre from maestros a
                  inner join emplegen b on a.empleado=b.empleado 
                  inner join areas c on a.area=c.area
                  where b.empleado=@emp and b.empresa=@empresa"
        Return BuscaEscalar(cadena, ListaParametros(lpara))

    End Function

    Public Function obtener_nombre(ByVal emp As Int32) As String

        lpara.Clear()
        lpara("emp") = emp
        lpara("empresa") = empresa
        cadena = "select isnull(apellido1+' '+apellido2+' '+nombre1+' '+nombre2,'') as nombre from emplegen where empresa=@empresa and empleado=@emp"
        Return BuscaEscalar(cadena, ListaParametros(lpara))

    End Function


    Public Function obtener_antiguedad(ByVal emp As Int32) As Decimal

        lpara.Clear()
        lpara("emp") = emp
        lpara("empresa") = empresa
        cadena = "select isnull(años,0) as valor from v_nomi_empleado_antiguedadxmes where empleado=@emp"
        Return BuscaEscalar(cadena, ListaParametros(lpara))

    End Function

    Private Function creacadena() As String



        cadena = "select empleado,area,max(rrh) as 'Gestión Humana',max(hetero) as hetero,max(auto) as auto,max(estudiantes) as estudiantes from
                      (select a.empleado,b.area,0 as rrh,avg(c.valor*g.porcentaje/100) as auto,0 as hetero,0 as estudiantes from evaluatest1 a
                      inner join evaluatest2 b on a.numtest=b.numtest and a.tipotest=b.tipotest and a.ciclo=b.ciclo and a.empresa=b.empresa
                      inner join evaluaopciones c on b.numopcion=c.numopcion and b.tipotest=c.tipotest and b.ciclo=c.ciclo and b.empresa=c.empresa and b.numpregunta=c.numpregunta and c.aplica=1
                      inner join meta_grupo d on a.ciclo=d.ciclo
                      inner join meta_asignacion e on d.id_meta_grupo=e.id_meta_grupo and e.empleado=a.empleado
                      inner join meta_test f on e.id_meta_grupo=f.id_meta_grupo and f.id_meta_test=@metaauto
                      left join meta_compe g on f.id_meta_test=g.id_meta_test and g.area=b.area
                      where a.tipotest=@auto and a.ciclo=@ciclo and d.id_meta_grupo=@grupo and a.empresa=@empresa  and a.empleado=@empleado
                      group by a.empleado,b.area
                      union all
                      select a.empleado,b.area,0 as rrh,0 as auto, avg(c.valor*g.porcentaje/100) as hetero,0 as estudiantes from evaluatest1 a
                      inner join evaluatest2 b on a.numtest=b.numtest and a.tipotest=b.tipotest and a.ciclo=b.ciclo and a.empresa=b.empresa
                      inner join evaluaopciones c on b.numopcion=c.numopcion and b.tipotest=c.tipotest and b.ciclo=c.ciclo and b.empresa=c.empresa and b.numpregunta=c.numpregunta and c.aplica=1
                      inner join meta_grupo d on a.ciclo=d.ciclo
                      inner join meta_asignacion e on d.id_meta_grupo=e.id_meta_grupo and e.empleado=a.empleado
                      inner join meta_test f on e.id_meta_grupo=f.id_meta_grupo and f.id_meta_test=@metahetero
                      left join meta_compe g on f.id_meta_test=g.id_meta_test and g.area=b.area
                      where a.tipotest=@hetero and a.ciclo=@ciclo and d.id_meta_grupo=@grupo and a.empresa=@empresa  and a.empleado=@empleado
                      group by a.empleado,b.area
                      union all
                      select cc.empleado,bb.area,0 as rrh,0 as auto, 0 as hetero,avg(c.valor*g.porcentaje/100) as estudiantes from evadoctest1 a
                      inner join evadoctest2 b on a.numtest=b.numtest and a.ciclo=b.ciclo
                      inner join evaluapreguntas bb on a.tipotest=bb.tipotest and a.ciclo=bb.ciclo 
                      inner join evaluaopciones c on b.numopcion=c.numopcion and a.tipotest=c.tipotest and b.ciclo=c.ciclo and bb.numpregunta=c.numpregunta and c.aplica=1
                      inner join maestros cc on cc.codigo=a.codigo
                      inner join meta_grupo d on a.ciclo=d.ciclo
                      inner join meta_asignacion e on d.id_meta_grupo=e.id_meta_grupo and e.empleado=cc.empleado
                      inner join meta_test f on e.id_meta_grupo=f.id_meta_grupo and f.id_meta_test=@evaestud
                      inner join meta_compe g on f.id_meta_test=g.id_meta_test and bb.area=g.area
                      where a.ciclo=@ciclo and d.id_meta_grupo=@grupo  and cc.empleado=@empleado
                      group by cc.empleado,bb.area) a where empleado=@empleado
                      group by empleado,area"
        Return (cadena)
    End Function



    Private Sub btnEjecutar_Click(sender As Object, e As EventArgs) Handles btnEjecutar.Click

        bwProceso.RunWorkerAsync()
        'MsgBox("Se han generado los archivos", MsgBoxStyle.Information, "Mensaje del sistema")

    End Sub

    Public Function consulta_empleado(emple As Int32, opcion As Short) As DataTable
        lpara.Clear()
        lpara("empresa") = empresa
        lpara("ciclo") = txtAñoi.Text
        lpara("empleado") = emple
        tbDatos.Clear()
        lpara("grupo") = opcion
        Select Case opcion
            Case 1
                lpara("auto") = 14
                lpara("hetero") = 13
                lpara("metahetero") = 2
                lpara("metaauto") = 3
                lpara("evaestud") = 4
                cadena = creacadena()

            Case 2

                lpara("auto") = 14      'estos son los valores de 2024 en evaluatipotest
                lpara("hetero") = 13    'estos son los valores de 2024 en evaluatipotest
                lpara("metaauto") = 7   'estos son los valores de 2024 en metatest
                lpara("metahetero") = 6 'estos son los valores de 2024 en metatest

                cadena = "select empleado,area,max(rrh) as 'Gestión Humana',max(hetero) as hetero,max(auto) as auto from
                (select a.empleado,b.area,0 as rrh,avg(c.valor*g.porcentaje/100) as auto,0 as hetero from evaluatest1 a
                inner join evaluatest2 b on a.numtest=b.numtest and a.tipotest=b.tipotest and a.ciclo=b.ciclo and a.empresa=b.empresa
                inner join evaluaopciones c on b.numopcion=c.numopcion and b.tipotest=c.tipotest and b.ciclo=c.ciclo and b.empresa=c.empresa and b.numpregunta=c.numpregunta and c.aplica=1
                inner join meta_grupo d on a.ciclo=d.ciclo
                inner join meta_asignacion e on d.id_meta_grupo=e.id_meta_grupo and e.empleado=a.empleado
                inner join meta_test f on e.id_meta_grupo=f.id_meta_grupo and f.id_meta_test=@metaauto
                left join meta_compe g on f.id_meta_test=g.id_meta_test and g.area=b.area
                where a.tipotest=@auto and a.ciclo=@ciclo and e.id_meta_grupo=@grupo and a.empresa=@empresa and a.empleado=@empleado 
                group by a.empleado,b.area
                union all
                select a.empleado,b.area,0 as rrh,0 as auto, avg(c.valor*g.porcentaje/100) as hetero from evaluatest1 a
                inner join evaluatest2 b on a.numtest=b.numtest and a.tipotest=b.tipotest and a.ciclo=b.ciclo and a.empresa=b.empresa
                inner join evaluaopciones c on b.numopcion=c.numopcion and b.tipotest=c.tipotest and b.ciclo=c.ciclo and b.empresa=c.empresa and b.numpregunta=c.numpregunta and c.aplica=1
                inner join meta_grupo d on a.ciclo=d.ciclo
                inner join meta_asignacion e on d.id_meta_grupo=e.id_meta_grupo and e.empleado=a.empleado
                inner join meta_test f on e.id_meta_grupo=f.id_meta_grupo and f.id_meta_test=@metahetero
                left join meta_compe g on f.id_meta_test=g.id_meta_test and g.area=b.area
                where  a.tipotest=@hetero and a.ciclo=@ciclo and e.id_meta_grupo=@grupo and a.empresa=@empresa  and a.empleado=@empleado
                group by a.empleado,b.area) a  where empleado=@empleado
                group by empleado,area"  'where empleado in (1299)
            Case 3
                lpara("auto") = 14
                lpara("hetero") = 13
                lpara("metahetero") = 10
                lpara("metaauto") = 11
                lpara("evaestud") = 12
                cadena = creacadena()
            Case 4
                lpara("auto") = 14
                lpara("hetero") = 13
                lpara("metaauto") = 15
                lpara("metahetero") = 14
                lpara("evaestud") = 16
                cadena = creacadena()
            Case 5
                lpara("auto") = 14
                lpara("hetero") = 13
                lpara("metahetero") = 18
                lpara("metaauto") = 19
                lpara("evaestud") = 20
                cadena = creacadena()

            Case 6
                lpara("auto") = 14
                lpara("hetero") = 13
                lpara("metahetero") = 22
                lpara("metaauto") = 23
                lpara("evaestud") = 24
                cadena = creacadena()
            Case 7
                lpara("auto") = 14
                lpara("hetero") = 13
                lpara("metahetero") = 26
                lpara("metaauto") = 27
                lpara("evaestud") = 28
                cadena = creacadena()
            Case 8
                lpara("auto") = 14
                lpara("hetero") = 13
                lpara("metahetero") = 30
                lpara("metaauto") = 31
                lpara("evaestud") = 32
                cadena = creacadena()
            Case 9
                lpara("auto") = 14
                lpara("hetero") = 13
                lpara("metahetero") = 34
                lpara("metaauto") = 35
                lpara("evaestud") = 36
                cadena = creacadena()

        End Select

        If rbTAdmin.Checked = True Then

        ElseIf rbTDocentes.Checked = True Then



        End If
        cn_acad.llenaTabla(cadena, tbDatos, ListaParametros(lpara))
        'genera_excel(opcion)
        Return tbDatos

    End Function


    Public Function obtenerindicador_antiguedad(valor As Decimal) As Decimal
        Select Case valor
            Case 0 To 1
                Return 0
            Case 1.1 To 3
                Return 1.5
            Case 3.1 To 8
                Return 3.75
            Case 8.1 To 13
                Return 7.5
            Case 13.1 To 18
                Return 11.25
            Case 18.1 To 100
                Return 15
        End Select
        Return 0
    End Function



    Private Sub bwProceso_DoWork(sender As Object, e As System.ComponentModel.DoWorkEventArgs) Handles bwProceso.DoWork
        ' Aquí va la tarea de larga ejecución
        Dim empleado As Int32
        Dim tbDatosF As New DataTable
        ' Dim empleadosUnicos = tbDatos.AsEnumerable().Select(Function(r) r.Field(Of Integer)("empleado")).Distinct()
        Dim area As String = ""
        Dim FileName As String = "default"
        Dim rutaPlantilla1 As String = "plantillas\grupo1.xlsx"

        Dim tbDatosEmp As New DataTable()

        If rbTAdmin.Checked Then
            cadena = "select empleado from meta_asignacion where id_meta_grupo=2 and empleado in (961)"
            cn_acad.llenaTabla(cadena, tbDatosEmp)
            opcion = 2
        ElseIf rbTDocentes.Checked Then
            cadena = "select empleado from meta_asignacion where id_meta_grupo=1  and empleado in (1565,1463)"
            cn_acad.llenaTabla(cadena, tbDatosEmp)
            opcion = 1
        ElseIf rb1primero.Checked Then
            cadena = "select empleado from meta_asignacion where id_meta_grupo=3"
            cn_acad.llenaTabla(cadena, tbDatosEmp)
            opcion = 3
        ElseIf rb2y3primaria.Checked Then
            cadena = "select empleado from meta_asignacion where id_meta_grupo=4"
            cn_acad.llenaTabla(cadena, tbDatosEmp)
            opcion = 4
        ElseIf rb4a6primaria.Checked Then
            cadena = "select empleado from meta_asignacion where id_meta_grupo=5 and empleado in (1559)"
            cn_acad.llenaTabla(cadena, tbDatosEmp)
            opcion = 5
        ElseIf rbAcompañante.Checked Then
            cadena = "select empleado from meta_asignacion where id_meta_grupo=6"
            cn_acad.llenaTabla(cadena, tbDatosEmp)
            opcion = 6
        ElseIf rbAsistentepre.Checked Then
            cadena = "select empleado from meta_asignacion where id_meta_grupo=7"
            cn_acad.llenaTabla(cadena, tbDatosEmp)
            opcion = 7
        ElseIf rbMaestraspre.Checked Then
            cadena = "select empleado from meta_asignacion where id_meta_grupo=8"
            cn_acad.llenaTabla(cadena, tbDatosEmp)
            opcion = 8
        ElseIf rbAcompa1a3.Checked Then
            cadena = "select empleado from meta_asignacion where id_meta_grupo=9"
            cn_acad.llenaTabla(cadena, tbDatosEmp)
            opcion = 9
        End If

        Dim rowEmp As DataRow

        For Each rowEmp In tbDatosEmp.Rows 'empleadosUnicos
            ' Crear nombre de archivo para cada empleado
            Select Case opcion
                Case 1
                    tbDatosF = consulta_empleado(rowEmp("empleado"), opcion)
                    area = obtener_area(rowEmp("empleado"))
                    rutaPlantilla1 = "plantillas\grupo1.xlsx"
                    FileName = $"plantillas\grupos\docente0\empleado_{rowEmp("empleado")}-{area}.xlsx"
                Case 2
                    tbDatosF = consulta_empleado(rowEmp("empleado"), opcion)
                    area = "Admin"
                    rutaPlantilla1 = "plantillas\grupo2.xlsx"
                    FileName = $"plantillas\grupos\admin0\empleado_{rowEmp("empleado")}-{area}.xlsx"
                Case 3
                    tbDatosF = consulta_empleado(rowEmp("empleado"), opcion)
                    area = obtener_area(rowEmp("empleado"))
                    rutaPlantilla1 = "plantillas\grupo1.xlsx"
                    FileName = $"plantillas\grupos\docente31\empleado_{rowEmp("empleado")}-{area}.xlsx"
                Case 4
                    tbDatosF = consulta_empleado(rowEmp("empleado"), opcion)
                    area = obtener_area(rowEmp("empleado"))
                    rutaPlantilla1 = "plantillas\grupo1.xlsx"
                    FileName = $"plantillas\grupos\docente41\empleado_{rowEmp("empleado")}-{area}.xlsx"
                Case 5
                    tbDatosF = consulta_empleado(rowEmp("empleado"), opcion)
                    area = obtener_area(rowEmp("empleado"))
                    rutaPlantilla1 = "plantillas\grupo1.xlsx"
                    FileName = $"plantillas\grupos\docente51\empleado_{rowEmp("empleado")}-{area}.xlsx"
                Case 6
                    tbDatosF = consulta_empleado(rowEmp("empleado"), opcion)
                    area = obtener_area(rowEmp("empleado"))
                    rutaPlantilla1 = "plantillas\grupo1.xlsx"
                    FileName = $"plantillas\grupos\docente6\empleado_{rowEmp("empleado")}-{area}.xlsx"
                Case 7
                    tbDatosF = consulta_empleado(rowEmp("empleado"), opcion)
                    area = obtener_area(rowEmp("empleado"))
                    rutaPlantilla1 = "plantillas\grupo1.xlsx"
                    FileName = $"plantillas\grupos\docente7\empleado_{rowEmp("empleado")}-{area}.xlsx"
                Case 8
                    tbDatosF = consulta_empleado(rowEmp("empleado"), opcion)
                    area = obtener_area(rowEmp("empleado"))
                    rutaPlantilla1 = "plantillas\grupo1.xlsx"
                    FileName = $"plantillas\grupos\docente8\empleado_{rowEmp("empleado")}-{area}.xlsx"
                Case 9
                    tbDatosF = consulta_empleado(rowEmp("empleado"), opcion)
                    area = obtener_area(rowEmp("empleado"))
                    rutaPlantilla1 = "plantillas\grupo1.xlsx"
                    FileName = $"plantillas\grupos\docente9\empleado_{rowEmp("empleado")}-{area}.xlsx"
            End Select

            Dim n As Int32 = 6

            Dim valor_antiguedad As Decimal
            ' Crear un nuevo libro de trabajo
            Using workbook As New XLWorkbook(rutaPlantilla1)
                ' Agregar una hoja de trabajo
                Dim worksheet = workbook.Worksheet("Hoja1")
                If worksheet Is Nothing Then
                    Throw New Exception("No se pudo acceder a la hoja de trabajo")
                End If
                valor_antiguedad = obtener_antiguedad(rowEmp("empleado"))

                worksheet.Cell(3, 2).Value = rowEmp("empleado")
                worksheet.Cell(4, 2).Value = obtener_nombre(rowEmp("empleado"))
                worksheet.Cell(5, 2).Value = area
                worksheet.cell(11, 3).value = obtenerindicador_antiguedad(valor_antiguedad)
                'Dim datosEmpleado = tbDatosF.Select($"empleado = {rowEmp("empleado")}")
                Dim row As DataRow
                Dim fila = n + 1
                For Each row In tbDatosF.Rows 'datosEmpleado
                    Dim columnaExcel = 3  ' Empezamos a escribir desde la columna 1 del Excel
                    For i As Integer = 2 To tbDatosF.Columns.Count - 1  ' Empezamos desde la columna 3 del DataTable
                        worksheet.Cell(fila, columnaExcel).Value = row(i)
                        columnaExcel += 1
                    Next
                    fila += 1
                Next


                ' Escribir los datos filtrados
                'worksheet.Cell(n + 1, 3).InsertData(dtNuevo)

                ' Aplicar formato
                Dim usedRange = worksheet.RangeUsed()
                usedRange.Style.Font.SetFontSize(9)
                worksheet.Row(n + 3).Style.Font.SetBold(True)

                ' Guardar el archivo Excel
                workbook.SaveAs(FileName)
            End Using

        Next
    End Sub

    Private Sub BackgroundWorker1_ProgressChanged(sender As Object, e As System.ComponentModel.ProgressChangedEventArgs) Handles bwProceso.ProgressChanged
        ' Actualizar la interfaz de usuario con el progreso
        pb1.Value = e.ProgressPercentage
    End Sub

    Private Sub BackgroundWorker1_RunWorkerCompleted(sender As Object, e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bwProceso.RunWorkerCompleted
        ' Tarea terminada, actualizar la interfaz de usuario
        MessageBox.Show("Tarea completada")
    End Sub

End Class