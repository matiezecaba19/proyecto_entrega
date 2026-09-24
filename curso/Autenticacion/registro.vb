'importo para usar MySqlException
Imports MySqlConnector

Public Class registro

    'boton registrarse
    Private Sub btn_registrar_Click(sender As Object, e As EventArgs) Handles btn_registrar.Click
        Dim nombre As String = txt_nombre.Text.Trim()
        Dim apellido As String = txt_apellido.Text.Trim()
        Dim dni As String = txt_dni.Text.Trim()
        Dim email As String = txt_email.Text.Trim()

        'valido que no haya campos vacios
        If nombre = "" OrElse apellido = "" OrElse dni = "" OrElse email = "" OrElse
           txt_contraseña.Text = "" OrElse txt_confirmarContraseña.Text = "" Then
            MessageBox.Show("Completá todos los campos")
            Return
        End If

        'valido que elija un rol
        If cmb_rol.SelectedIndex = -1 Then
            MessageBox.Show("Elegí un rol")
            Return
        End If

        'el dni tiene que tener 7 u 8 numeros (# es un numero)
        If Not (dni Like "#######" OrElse dni Like "########") Then
            MessageBox.Show("El DNI tiene que tener 7 u 8 números, sin puntos")
            txt_dni.Focus()
            Return
        End If

        'el email tiene que tener @ y punto
        If Not (email Like "*@*.*") Then
            MessageBox.Show("El email no es válido")
            txt_email.Focus()
            Return
        End If

        'minimo 6 caracteres
        If txt_contraseña.Text.Length < 6 Then
            MessageBox.Show("La contraseña tiene que tener al menos 6 caracteres")
            txt_contraseña.Focus()
            Return
        End If

        'las contraseñas tienen que coincidir
        If txt_contraseña.Text <> txt_confirmarContraseña.Text Then
            MessageBox.Show("Las contraseñas no coinciden")
            txt_confirmarContraseña.Clear()
            txt_confirmarContraseña.Focus()
            Return
        End If

        Try
            'me fijo que el dni no este registrado
            If ServiceAutenticacion.ExisteDni(dni) Then
                MessageBox.Show("Ya existe un usuario con ese DNI")
                txt_dni.Focus()
                Return
            End If

            'guardo el usuario
            ServiceAutenticacion.Registrar(nombre, apellido, dni, email, txt_contraseña.Text, cmb_rol.Text)

            MessageBox.Show("Registro exitoso. Tu cuenta queda pendiente hasta que el administrador la apruebe.")
            Me.Close()

        Catch ex As MySqlException
            'error 1062 = email repetido
            If ex.Number = 1062 Then
                MessageBox.Show("Ese email ya está registrado")
                txt_email.Focus()
            Else
                MessageBox.Show("ERROR! " & ex.Message)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR! " & ex.Message)
        End Try
    End Sub

    'vuelvo al login
    Private Sub lnk_volverLogin_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnk_volverLogin.LinkClicked
        Me.Close()
    End Sub

End Class
