Imports System.Collections.Generic

Public Class frmCambioCodigo

    Dim cadena As String = ""
    Dim tabla As New DataTable


    Private Sub frmCambioCodigo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cadena = "SELECT cargo, nombre, cargo as cargon FROM cargosmin order by cargo "
        llenaTabla(cadena, tabla)
        dgvCodigo.DataSource = tabla

        Vista(dgvCodigo)
        If tabla.Rows.Count > 0 Then
            MueveScrollView(dgvCodigo, tabla.Rows.Count - 1)
        End If
    End Sub

    Private Sub Vista(ByVal dgVista As DataGridView)
        With dgVista
            .Columns(0).HeaderText = "Cargo"
            .Columns(0).Width = 75
            .Columns(0).ReadOnly = True
            .Columns(1).HeaderText = "Nombre"
            .Columns(1).Width = 350
            .Columns(1).ReadOnly = True
            .Columns(2).HeaderText = "Nuevo"
            .Columns(2).Width = 75
            'AltoGridView(18, tabla, 292, 552, dgVista)
        End With
    End Sub

    Private Sub btnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGuardar.Click
        Dim modelo As New cmodelo
        Dim dpara As New Dictionary(Of String, Object)

        For Each dr As DataRow In tabla.Rows
            If (Not String.IsNullOrEmpty(dr.Item("cargon")) AndAlso dr.Item("cargon").ToString().Length = 4) Then
                dpara("cargo") = dr.Item("cargo")
                dpara("cargon") = dr.Item("cargon")

                cadena = "update cargosmin set cargo=@cargon where cargo=@cargo"
                modelo.EjecutarNonQuery(cadena, ListaParametros(dpara))

                cadena = "update puestosper set cargo=@cargon where cargo=@cargo"
                modelo.EjecutarNonQuery(cadena, ListaParametros(dpara))

            End If
        Next

        If modelo.Commit Then
            MsgBox("Operación realizada con éxito")
        End If


    End Sub
End Class