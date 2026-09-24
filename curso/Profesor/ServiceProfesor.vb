'importo la clase para conectar con la BD
Imports MySqlConnector

'SERVICIO DEL PROFESOR
'consultas del panel del profesor
Public Class ServiceProfesor

    '---------------------- CURSOS ----------------------

    'traigo los cursos del profesor, con el JOIN saco el nombre de la categoria
    'uso LIKE para el buscador
    Public Shared Function ListarCursos(profesorId As Integer, filtro As String) As DataTable
        Dim sql As String =
            "SELECT c.id, c.titulo, c.descripcion, c.categoria_id, ca.nombre AS categoria, " &
            "c.precio, c.nivel, c.estado " &
            "FROM cursos AS c " &
            "JOIN categorias AS ca ON c.categoria_id = ca.id " &
            "WHERE c.profesor_id = @profesor AND c.titulo LIKE @filtro " &
            "ORDER BY c.titulo;"

        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@profesor", profesorId)
                cmd.Parameters.AddWithValue("@filtro", "%" & filtro & "%")

                'paso lo que trae el datareader a una tabla
                Dim tabla As New DataTable
                Using lector As MySqlDataReader = cmd.ExecuteReader()
                    tabla.Load(lector)
                End Using
                Return tabla
            End Using
        End Using
    End Function

    'traigo las categorias para el combo
    Public Shared Function ListarCategorias() As DataTable
        Dim sql As String = "SELECT id, nombre FROM categorias ORDER BY nombre;"

        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                Dim tabla As New DataTable
                Using lector As MySqlDataReader = cmd.ExecuteReader()
                    tabla.Load(lector)
                End Using
                Return tabla
            End Using
        End Using
    End Function

    'alta de un curso
    Public Shared Sub AgregarCurso(profesorId As Integer, titulo As String, descripcion As String,
                                   categoriaId As Integer, precio As Decimal, nivel As String, estado As String)
        Dim sql As String =
            "INSERT INTO cursos (titulo, descripcion, profesor_id, categoria_id, precio, nivel, estado) " &
            "VALUES (@titulo, @descripcion, @profesor, @categoria, @precio, @nivel, @estado);"

        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@titulo", titulo)
                cmd.Parameters.AddWithValue("@descripcion", descripcion)
                cmd.Parameters.AddWithValue("@profesor", profesorId)
                cmd.Parameters.AddWithValue("@categoria", categoriaId)
                cmd.Parameters.AddWithValue("@precio", precio)
                cmd.Parameters.AddWithValue("@nivel", nivel)
                cmd.Parameters.AddWithValue("@estado", estado)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    'modificacion de un curso
    'con profesor_id me aseguro de que solo toque sus propios cursos
    Public Shared Sub ModificarCurso(cursoId As Integer, profesorId As Integer, titulo As String, descripcion As String,
                                     categoriaId As Integer, precio As Decimal, nivel As String, estado As String)
        Dim sql As String =
            "UPDATE cursos SET titulo = @titulo, descripcion = @descripcion, " &
            "categoria_id = @categoria, precio = @precio, nivel = @nivel, estado = @estado " &
            "WHERE id = @id AND profesor_id = @profesor;"

        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@titulo", titulo)
                cmd.Parameters.AddWithValue("@descripcion", descripcion)
                cmd.Parameters.AddWithValue("@categoria", categoriaId)
                cmd.Parameters.AddWithValue("@precio", precio)
                cmd.Parameters.AddWithValue("@nivel", nivel)
                cmd.Parameters.AddWithValue("@estado", estado)
                cmd.Parameters.AddWithValue("@id", cursoId)
                cmd.Parameters.AddWithValue("@profesor", profesorId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    'baja de un curso
    'las lecciones se borran por el ON DELETE CASCADE
    Public Shared Sub EliminarCurso(cursoId As Integer, profesorId As Integer)
        Dim sql As String = "DELETE FROM cursos WHERE id = @id AND profesor_id = @profesor;"

        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@id", cursoId)
                cmd.Parameters.AddWithValue("@profesor", profesorId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    '---------------------- ALUMNOS ----------------------

    'traigo los alumnos de un curso con la inscripcion aceptada (ya pagaron)
    'JOIN con la tabla puente: alumnos -> inscripciones -> cursos
    'filtroAvance: 0 todos, 1 sin empezar, 2 en curso, 3 finalizados
    Public Shared Function ListarAlumnos(cursoId As Integer, profesorId As Integer, filtroAvance As Integer) As DataTable
        'cuento completadas y total con subconsultas
        Dim sql As String =
            "SELECT a.id, CONCAT(a.nombre, ' ', a.apellido) AS alumno, a.email, i.fecha_solicitud, " &
            "(SELECT COUNT(*) FROM progreso_leccion AS p " &
            " WHERE p.inscripcion_id = i.id AND p.completada = 1) AS completadas, " &
            "(SELECT COUNT(*) FROM lecciones AS l WHERE l.curso_id = c.id) AS total " &
            "FROM alumnos AS a " &
            "JOIN inscripciones AS i ON i.alumno_id = a.id " &
            "JOIN cursos AS c ON c.id = i.curso_id " &
            "WHERE c.id = @curso AND c.profesor_id = @profesor AND i.estado = 'aceptada' "

        'agrego el filtro de la lista
        Select Case filtroAvance
            Case 1 'sin empezar
                sql = sql & "HAVING completadas = 0 "
            Case 2 'en curso
                sql = sql & "HAVING completadas > 0 AND completadas < total "
            Case 3 'finalizados
                sql = sql & "HAVING total > 0 AND completadas = total "
        End Select
        sql = sql & "ORDER BY alumno;"

        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@curso", cursoId)
                cmd.Parameters.AddWithValue("@profesor", profesorId)
                Dim tabla As New DataTable
                Using lector As MySqlDataReader = cmd.ExecuteReader()
                    tabla.Load(lector)
                End Using
                Return tabla
            End Using
        End Using
    End Function

    '---------------------- MIS DATOS ----------------------

    'traigo los datos del profesor, devuelvo la fila o Nothing si no existe
    Public Shared Function ObtenerDatos(profesorId As Integer) As DataRow
        Dim sql As String = "SELECT nombre, apellido, dni, email, estado, descripcion, fecha_creacion " &
                            "FROM profesores WHERE id = @id;"

        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@id", profesorId)
                Dim tabla As New DataTable
                Using lector As MySqlDataReader = cmd.ExecuteReader()
                    tabla.Load(lector)
                End Using

                If tabla.Rows.Count = 0 Then Return Nothing
                Return tabla.Rows(0)
            End Using
        End Using
    End Function

    'guardo los datos del profesor (el dni no se cambia)
    Public Shared Sub GuardarDatos(profesorId As Integer, nombre As String, apellido As String,
                                   email As String, descripcion As String)
        Dim sql As String = "UPDATE profesores SET nombre = @nombre, apellido = @apellido, email = @email, " &
                            "descripcion = @descripcion WHERE id = @id;"

        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@nombre", nombre)
                cmd.Parameters.AddWithValue("@apellido", apellido)
                cmd.Parameters.AddWithValue("@email", email)
                cmd.Parameters.AddWithValue("@descripcion", descripcion)
                cmd.Parameters.AddWithValue("@id", profesorId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class
