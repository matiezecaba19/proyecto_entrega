'importo la clase para conextar la BD
Imports MySqlConnector

'clase con los datos del usuario
Public Class Usuario
    Public Property id As Integer
    Public Property nombre As String
    Public Property apellido As String
    Public Property rol As String   'admin, profesor, alumno, cobranza
    Public Property estado As String   'activo, pendiende, inactivo, rechazar
End Class


'SERVICIO DE AUTENTICACION
Public Class ServiceAutenticacion

    'nothing si no entro nadie
    Public Shared Property UsuarioActual As Usuario

    'busco DNI en las 4 tablas y verificar contraseña
    Public Shared Function iniciarSeSion(dni As String, password As String) As Usuario

        Dim sql As String = "SELECT id, nombre, apellido, password_hash, estado, 'admin' AS rol " &
            "FROM administradores WHERE dni = @dni " &
            "UNION ALL " &
            "SELECT id, nombre, apellido, password_hash, estado, 'profesor' " &
            "FROM profesores WHERE dni = @dni " &
            "UNION ALL " &
            "SELECT id, nombre, apellido, password_hash, estado, 'cobranza' " &
            "FROM cobranza WHERE dni = @dni " &
            "UNION ALL " &
            "SELECT id, nombre, apellido, password_hash, estado, 'alumno' " &
            "FROM alumnos WHERE dni = @dni;"

        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@dni", dni)

                'uso datareader para leer la fila
                Using rd As MySqlDataReader = cmd.ExecuteReader()
                    'read devuelve true si encontro una fila (dni existente)
                    If rd.Read() Then
                        Dim hash As String = rd("password_hash").ToString()

                        'comparo la contraseña escrita con el hash guardado
                        If verificarPassword(password, hash) Then
                            'armo el usuario con los datos de la fila
                            Dim usu As New Usuario()
                            usu.id = CInt(rd("id"))
                            usu.nombre = rd("nombre").ToString()
                            usu.apellido = rd("apellido").ToString()
                            usu.estado = rd("estado").ToString()
                            usu.rol = rd("rol").ToString()
                            Return usu
                        End If
                    End If
                End Using
            End Using
        End Using

        'sino Dni no exite o la contra no concide
        Return Nothing
    End Function

    'genero el hash 
    Public Shared Function generarHash(password As String) As String
        Return BCrypt.Net.BCrypt.HashPassword(password)
    End Function

    'devuelve si la contraseña concide con el hash
    Private Shared Function verificarPassword(password As String, hash As String) As Boolean
        Try
            Return BCrypt.Net.BCrypt.Verify(password, hash)
        Catch ex As BCrypt.Net.SaltParseException
            'si el hash no es correcto no entra
            Return False
        End Try
    End Function

    'me fijo si el DNI ya esta en alguna de las 4 tablas
    Public Shared Function ExisteDni(dni As String) As Boolean
        'cuento cuantas veces aparece el dni
        Dim sql As String =
            "SELECT COUNT(*) FROM (" &
            "SELECT dni FROM administradores WHERE dni = @dni " &
            "UNION ALL SELECT dni FROM profesores WHERE dni = @dni " &
            "UNION ALL SELECT dni FROM cobranza WHERE dni = @dni " &
            "UNION ALL SELECT dni FROM alumnos WHERE dni = @dni" &
            ") AS t;"

        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@dni", dni)
                'ExecuteScalar trae un solo valor
                Dim cant As Integer = CInt(cmd.ExecuteScalar())
                Return cant > 0
            End Using
        End Using
    End Function

    'guardo el usuario nuevo, el estado queda en pendiente por defecto
    Public Shared Sub Registrar(nombre As String, apellido As String, dni As String,
                                email As String, password As String, rol As String)
        'elijo la tabla segun el rol (la tabla no se puede pasar con @)
        Dim tabla As String
        Select Case rol
            Case "Alumno"
                tabla = "alumnos"
            Case "Profesor"
                tabla = "profesores"
            Case "Cobranza"
                tabla = "cobranza"
            Case Else
                Throw New Exception("Rol no válido: " & rol)
        End Select

        Dim sql As String =
            "INSERT INTO " & tabla & " (nombre, apellido, dni, email, password_hash) " &
            "VALUES (@nombre, @apellido, @dni, @email, @hash);"

        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@nombre", nombre)
                cmd.Parameters.AddWithValue("@apellido", apellido)
                cmd.Parameters.AddWithValue("@dni", dni)
                cmd.Parameters.AddWithValue("@email", email)
                'guardo el hash, no la contraseña
                cmd.Parameters.AddWithValue("@hash", generarHash(password))
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class