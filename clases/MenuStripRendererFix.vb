' ============================================================
' SOLUCIÓN CORREGIDA: Texto blanco visible en menú principal
' y texto normal visible en los submenús desplegables
' ============================================================
'
' IDEA CLAVE:
' - El MENÚ PRINCIPAL (MenuStrip) siempre debe mantener el
'   fondo ROJO, incluso cuando el usuario lo selecciona o abre
'   su submenú. Así el texto BLANCO nunca se pierde.
' - Los SUBMENÚS (ToolStripDropDownMenu) deben comportarse de
'   forma normal: fondo claro/blanco con texto oscuro, que es
'   lo más legible ahí.
'
' Para lograr esto, distinguimos el "dueño" (Owner) de cada
' item: si el Owner es el MenuStrip -> es un item del menú
' principal. Si no, es un item de un submenú desplegado.

Imports System.Windows.Forms
Imports System.Drawing

Public Class MenuStripRendererFix
    Inherits ToolStripProfessionalRenderer

    Public Sub New()
        MyBase.New(New ProfessionalColorTable())
    End Sub

    ' Color del texto
    Protected Overrides Sub OnRenderItemText(e As ToolStripItemTextRenderEventArgs)
        If TypeOf e.Item.Owner Is MenuStrip Then
            ' Item del menú principal (barra roja) -> texto SIEMPRE blanco
            e.TextColor = Color.White
        Else
            ' Item de un submenú desplegado -> texto normal (oscuro)
            e.TextColor = Color.Black
        End If
        MyBase.OnRenderItemText(e)
    End Sub

    ' Color de fondo
    Protected Overrides Sub OnRenderMenuItemBackground(e As ToolStripItemRenderEventArgs)
        If TypeOf e.Item.Owner Is MenuStrip Then
            ' Item del menú principal -> SIEMPRE fondo rojo,
            ' esté o no seleccionado (para que el texto blanco
            ' nunca quede sobre fondo claro)
            Dim colorFondo As Color
            If e.Item.Selected OrElse e.Item.Pressed Then
                colorFondo = Color.FromArgb(160, 20, 20) ' rojo un poco más oscuro al pasar el mouse
            Else
                colorFondo = Color.FromArgb(178, 34, 34) ' rojo normal de la barra (ajusta a tu tono real)
            End If
            Using brush As New SolidBrush(colorFondo)
                e.Graphics.FillRectangle(brush, New Rectangle(Point.Empty, e.Item.Size))
            End Using
        Else
            ' Item de submenú -> comportamiento normal por defecto
            MyBase.OnRenderMenuItemBackground(e)
        End If
    End Sub

End Class

' ============================================================
' CÓMO USARLO:
' ============================================================
'
' En el Load del formulario (usa el nombre real de tu control,
' el que veas en la ventana de Propiedades -> (Name)):
'
'   MenuStrip1.Renderer = New MenuStripRendererFix()
'
' IMPORTANTE: ajusta el valor Color.FromArgb(178, 34, 34) para
' que coincida EXACTAMENTE con el rojo que ya usas en tu barra
' de menú (puedes tomarlo del BackColor que le pusiste al
' MenuStrip en el diseñador).