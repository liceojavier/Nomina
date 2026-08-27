Imports System.IO
Public Class frmImagen
    Dim lpara As New Dictionary(Of String, Object)
    Dim cadena As String = ""

    Private Sub btnGet_Click(sender As Object, e As EventArgs) Handles btnGet.Click

        Dim cadena As String
        Dim empleado As Int32 = 0

        If Int32.TryParse(txtEmpleado.Text, empleado) Then
            cadena = "Select foto From fotoEmpleado Where empresa =@empresa And empleado =@empleado"
            lpara("empresa") = empresa
            lpara("empleado") = empleado
            Dim fs As FileStream
            Dim imageData As Byte() = DirectCast(modelo.BuscaEscalar(cadena, ListaParametros(lpara)), Byte())
            If Not imageData Is Nothing Then
                Using ms As New MemoryStream(imageData, 0, imageData.Length)
                    ms.Write(imageData, 0, imageData.Length)
                    sfdArchivo.AddExtension = True
                    sfdArchivo.Filter = "jpg Files (*.jpg*)|*.jpg"
                    sfdArchivo.ShowDialog()
                    If (sfdArchivo.FileName.Trim <> "") Then
                        fs = New FileStream(sfdArchivo.FileName, FileMode.Create, FileAccess.Write)
                        ms.WriteTo(fs)
                        fs.Close()
                        MsgBox("Operación realizada con éxito")
                    End If
                End Using
            End If
        End If



    End Sub

    Private Sub txtEmpleado_Validated(sender As Object, e As EventArgs) Handles txtEmpleado.Validated
        If Not String.IsNullOrEmpty(txtEmpleado.Text) Then
            cadena = "Select apellido1 + ' ' + apellido2 + ' ' + nombre1 + ' ' + nombre2 as nombre From emplegen Where empresa =@empresa And empleado =@empleado"
            lpara("empresa") = empresa
            lpara("empleado") = CInt(txtEmpleado.Text)
            txtNombre.Text = modelo.BuscaEscalar(cadena, ListaParametros(lpara))
        Else
            txtNombre.Clear()
        End If
    End Sub
End Class