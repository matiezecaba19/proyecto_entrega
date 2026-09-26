'importo para copiar y borrar archivos de imagenes
Imports System.IO
'importo la clase para conectar con la BD
Imports MySqlConnector

'SERVICIO DE LECCIONES
'consultas de las lecciones y sus imagenes
Public Class ServiceLecciones

    '---------------------- LECCIONES ----------------------

    'traigo las lecciones de un curso ordenadas
    Public Shared Function ListarLecciones(cursoId As Integer) As DataTable
        Dim sql As String = "SELECT id, orden, titulo, contenido FROM lecciones " &
                            "WHERE curso_id = @curso ORDER BY orden, id;"

        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@curso", cursoId)
                Dim tabla As New DataTable
                Using lector As MySqlDataReader = cmd.ExecuteReader()
                    tabla.Load(lector)
                End Using
                Return tabla
            End Using
        End Using
    End Function

    'alta de una leccion
    Public Shared Sub AgregarLeccion(cursoId As Integer, titulo As String, contenido As String, orden As Integer)
        Dim sql As String = "INSERT INTO lecciones (curso_id, titulo, contenido, orden) " &
                            "VALUES (@curso, @titulo, @contenido, @orden);"

        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@curso", cursoId)
                cmd.Parameters.AddWithValue("@titulo", titulo)
                cmd.Parameters.AddWithValue("@contenido", contenido)
                cmd.Parameters.AddWithValue("@orden", orden)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    'modificacion de una leccion
    Public Shared Sub ModificarLeccion(leccionId As Integer, titulo As String, contenido As String, orden As Integer)
        Dim sql As String = "UPDATE lecciones SET titulo = @titulo, contenido = @contenido, orden = @orden " &
                            "WHERE id = @id;"

        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@titulo", titulo)
                cmd.Parameters.AddWithValue("@contenido", contenido)
                cmd.Parameters.AddWithValue("@orden", orden)
                cmd.Parameters.AddWithValue("@id", leccionId)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    'baja de una leccion
    'las imagenes y el avance de los alumnos se borran por el ON DELETE CASCADE
    Public Shared Sub EliminarLeccion(leccionId As Integer)
        'me guardo las imagenes antes de borrar para despues borrar los archivos
        Dim imagenes As DataTable = ListarImagenes(leccionId)

        Dim sql As String = "DELETE FROM lecciones WHERE id = @id;"
        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@id", leccionId)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        For Each fila As DataRow In imagenes.Rows
            BorrarArchivo(fila("url").ToString())
        Next
    End Sub

    '---------------------- IMAGENES ----------------------

    'carpeta donde guardo las imagenes
    'si corro desde visual studio uso la carpeta Imagenes del proyecto (al lado del curso.vbproj)
    'si no la encuentro uso una carpeta Imagenes al lado del .exe
    Public Shared Function CarpetaImagenes() As String
        Dim carpeta As String = Application.StartupPath

        'subo de carpeta en carpeta buscando el curso.vbproj
        For i As Integer = 1 To 5
            If File.Exists(Path.Combine(carpeta, "curso.vbproj")) Then
                Return Path.Combine(carpeta, "Imagenes")
            End If
            Dim padre As DirectoryInfo = Directory.GetParent(carpeta)
            If padre Is Nothing Then Exit For
            carpeta = padre.FullName
        Next

        Return Path.Combine(Application.StartupPath, "Imagenes")
    End Function

    'traigo las imagenes de una leccion
    Public Shared Function ListarImagenes(leccionId As Integer) As DataTable
        Dim sql As String = "SELECT id, url, orden FROM imagenes_leccion " &
                            "WHERE leccion_id = @leccion ORDER BY orden, id;"

        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@leccion", leccionId)
                Dim tabla As New DataTable
                Using lector As MySqlDataReader = cmd.ExecuteReader()
                    tabla.Load(lector)
                End Using
                Return tabla
            End Using
        End Using
    End Function

    'copio la imagen elegida a la carpeta Imagenes y la guardo en la base
    Public Shared Sub AgregarImagen(leccionId As Integer, rutaOrigen As String, orden As Integer)
        Dim carpeta As String = CarpetaImagenes()
        'si la carpeta no existe la creo
        Directory.CreateDirectory(carpeta)

        'le pongo un nombre unico para que no se pisen: leccion3_20260926153012123.png
        Dim nombre As String = "leccion" & leccionId & "_" & DateTime.Now.ToString("yyyyMMddHHmmssfff") &
                               Path.GetExtension(rutaOrigen).ToLower()
        File.Copy(rutaOrigen, Path.Combine(carpeta, nombre))

        'en la base guardo solo el nombre del archivo
        Dim sql As String = "INSERT INTO imagenes_leccion (leccion_id, url, orden) VALUES (@leccion, @url, @orden);"
        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@leccion", leccionId)
                cmd.Parameters.AddWithValue("@url", nombre)
                cmd.Parameters.AddWithValue("@orden", orden)
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    'saco una imagen de la leccion y borro el archivo
    Public Shared Sub QuitarImagen(imagenId As Integer, nombreArchivo As String)
        Dim sql As String = "DELETE FROM imagenes_leccion WHERE id = @id;"
        Using cn As New MySqlConnection(CADENA)
            cn.Open()
            Using cmd As New MySqlCommand(sql, cn)
                cmd.Parameters.AddWithValue("@id", imagenId)
                cmd.ExecuteNonQuery()
            End Using
        End Using

        BorrarArchivo(nombreArchivo)
    End Sub

    'borro el archivo de la carpeta si existe
    'si no se puede borrar (por ejemplo si esta abierto) lo dejo, la base ya quedo bien
    Private Shared Sub BorrarArchivo(nombreArchivo As String)
        Dim ruta As String = Path.Combine(CarpetaImagenes(), nombreArchivo)
        Try
            If File.Exists(ruta) Then File.Delete(ruta)
        Catch ex As IOException
        End Try
    End Sub

End Class
