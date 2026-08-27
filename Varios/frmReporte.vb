Imports CrystalDecisions.CrystalReports.Engine
Imports System.Collections.Generic

Public Class frmReporte

    Private _ds As IEnumerable
    Private _v As ReportClass
    Private _para As Dictionary(Of String, Object)

    Public Property ds() As IEnumerable
        Get
            Return _ds
        End Get
        Set(ByVal value As IEnumerable)
            _ds = value
        End Set
    End Property
    Public Property v() As ReportClass
        Get
            Return _v
        End Get
        Set(ByVal value As ReportClass)
            _v = value
        End Set
    End Property

    Public Property parametros() As Dictionary(Of String, Object)
        Get
            Return _para
        End Get
        Set(ByVal value As Dictionary(Of String, Object))
            _para = value
        End Set
    End Property



    Private Sub frmReporte_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        v.SetDataSource(_ds)
        For Each kp As KeyValuePair(Of String, Object) In _para
            _v.SetParameterValue(kp.Key, kp.Value)
        Next
        crv.ReportSource = v
    End Sub
End Class