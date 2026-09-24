Public Class login

    'boton acceder
    Private Sub btn_acceder_Click(sender As Object, e As EventArgs) Handles btn_acceder.Click
        'valido que no esten vacios
        If txt_dni.Text.Trim() = "" OrElse txt_contraseña.Text = "" Then
            MessageBox.Show("Completá el DNI y la contraseña")
            Return
        End If

        Try
            'busco el usuario, si no existe o la contraseña esta mal devuelve Nothing
            Dim usu As Usuario = ServiceAutenticacion.iniciarSeSion(txt_dni.Text.Trim(), txt_contraseña.Text)

            If usu Is Nothing Then
                MessageBox.Show("DNI o contraseña incorrectos")
                Return
            End If

            'si todavia no lo aprobaron no entra
            If usu.estado <> "activo" Then
                MessageBox.Show("Tu usuario no está activo (estado: " & usu.estado & "). " &
                                "Esperá a que el administrador lo apruebe.")
                Return
            End If

            'guardo el usuario logueado
            ServiceAutenticacion.UsuarioActual = usu

            'abro el form segun el rol
            Dim frm As Form = Nothing
            Select Case usu.rol
                Case "admin"
                    frm = New admin()
                Case "profesor"
                    frm = New profesor()
                Case "cobranza"
                    frm = New cobranza()
                Case "alumno"
                    frm = New alumno()
            End Select

            'cuando cierra el form vuelve al login
            AddHandler frm.FormClosed, AddressOf VolverAlLogin

            'escondo el login, si lo cierro se cierra todo el programa
            frm.Show()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("ERROR! " & ex.Message)
        End Try
    End Sub

    'cerrar sesion
    Private Sub VolverAlLogin(sender As Object, e As FormClosedEventArgs)
        ServiceAutenticacion.UsuarioActual = Nothing
        txt_contraseña.Clear()
        Me.Show()
    End Sub

    'abro el registro
    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim frm As New registro()
        Me.Hide()
        'ShowDialog espera a que se cierre el registro
        frm.ShowDialog()
        Me.Show()
    End Sub

End Class
