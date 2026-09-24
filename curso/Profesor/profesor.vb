'importo para poder atrapar los errores de MariaDB (MySqlException)
Imports MySqlConnector

'FORM DEL PROFESOR
'aca solo esta la pantalla: validar, mostrar y avisar
'todo lo que toca la base esta en ServiceProfesor
Public Class profesor

    'al abrir el form
    Private Sub profesor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'muestro el nombre del profesor que entro
        lbl_bienvenida.Text = "Bienvenido, " & ServiceAutenticacion.UsuarioActual.nombre & " " &
                              ServiceAutenticacion.UsuarioActual.apellido
        CargarComboCategorias()
        CargarGrilla()
        LimpiarForm()
        CargarMisDatos()
    End Sub

    'cuando cambia de pestaña
    Private Sub tab_profesor_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tab_profesor.SelectedIndexChanged
        'si entra a mis alumnos recargo el combo, por si creo o borro cursos en la otra pestaña
        If tab_profesor.SelectedTab Is tab_alumnos Then
            CargarComboCursosAlumnos()
            'arranca mostrando todos
            lst_filtroAvance.SelectedIndex = 0
            CargarGrillaAlumnos()
        End If
    End Sub

    '---------------------- PESTAÑA MIS CURSOS ----------------------

    'cargo en la grilla los cursos del profesor
    Sub CargarGrilla(Optional filtro As String = "")
        Try
            dgv_cursos.DataSource = ServiceProfesor.ListarCursos(ServiceAutenticacion.UsuarioActual.id, filtro)

            'oculto las columnas que no hace falta ver (las uso al hacer click)
            dgv_cursos.Columns("id").Visible = False
            dgv_cursos.Columns("descripcion").Visible = False
            dgv_cursos.Columns("categoria_id").Visible = False

            'pongo lindos los titulos de las columnas
            dgv_cursos.Columns("titulo").HeaderText = "Título"
            dgv_cursos.Columns("categoria").HeaderText = "Categoría"
            dgv_cursos.Columns("precio").HeaderText = "Precio"
            dgv_cursos.Columns("nivel").HeaderText = "Nivel"
            dgv_cursos.Columns("estado").HeaderText = "Estado"
            'el precio con 2 decimales
            dgv_cursos.Columns("precio").DefaultCellStyle.Format = "N2"

        Catch ex As Exception
            MessageBox.Show("ERROR! " & ex.Message)
        End Try
    End Sub

    'cargo el combo con las categorias de la base
    Sub CargarComboCategorias()
        Try
            'se ve el nombre pero por atras guarda el id
            cmb_categoria.DisplayMember = "nombre"
            cmb_categoria.ValueMember = "id"
            cmb_categoria.DataSource = ServiceProfesor.ListarCategorias()
        Catch ex As Exception
            MessageBox.Show("ERROR al cargar categorías: " & ex.Message)
        End Try
    End Sub

    'dejo los campos vacios para cargar un curso nuevo
    Sub LimpiarForm()
        txt_idCurso.Clear()
        txt_titulo.Clear()
        txt_descripcion.Clear()
        nud_precio.Value = 0
        'dejo elegida la primera opcion de cada combo
        If cmb_categoria.Items.Count > 0 Then cmb_categoria.SelectedIndex = 0
        cmb_nivel.SelectedIndex = 0
        cmb_estado.SelectedIndex = 0
        dgv_cursos.ClearSelection()
        txt_titulo.Focus()
    End Sub

    'reviso los datos antes de guardar o modificar
    Function DatosValidos() As Boolean
        If txt_titulo.Text.Trim() = "" Then
            MessageBox.Show("Ingresá el título del curso")
            txt_titulo.Focus()
            Return False
        End If

        If cmb_categoria.SelectedValue Is Nothing Then
            MessageBox.Show("Elegí una categoría")
            Return False
        End If

        Return True
    End Function

    'boton limpiar
    Private Sub btn_nuevo_Click(sender As Object, e As EventArgs) Handles btn_nuevo.Click
        LimpiarForm()
    End Sub

    'boton agregar curso (alta)
    Private Sub btn_guardar_Click(sender As Object, e As EventArgs) Handles btn_guardar.Click
        'si tiene id es un curso que ya existe, para eso esta modificar
        If txt_idCurso.Text <> "" Then
            MessageBox.Show("Ese curso ya existe, usá Modificar. Para cargar uno nuevo apretá Limpiar.")
            Return
        End If

        If Not DatosValidos() Then Return

        Try
            'SelectedValue tiene el id de la categoria elegida
            ServiceProfesor.AgregarCurso(ServiceAutenticacion.UsuarioActual.id, txt_titulo.Text.Trim(),
                                         txt_descripcion.Text.Trim(), CInt(cmb_categoria.SelectedValue),
                                         nud_precio.Value, cmb_nivel.Text, cmb_estado.Text)

            MessageBox.Show("Curso agregado")
            CargarGrilla(txt_buscar.Text.Trim())
            LimpiarForm()

        Catch ex As Exception
            MessageBox.Show("ERROR! " & ex.Message)
        End Try
    End Sub

    'boton modificar
    Private Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        If txt_idCurso.Text = "" Then
            MessageBox.Show("Elegí un curso de la grilla")
            Return
        End If

        If Not DatosValidos() Then Return

        Try
            ServiceProfesor.ModificarCurso(CInt(txt_idCurso.Text), ServiceAutenticacion.UsuarioActual.id,
                                           txt_titulo.Text.Trim(), txt_descripcion.Text.Trim(),
                                           CInt(cmb_categoria.SelectedValue), nud_precio.Value,
                                           cmb_nivel.Text, cmb_estado.Text)

            MessageBox.Show("Curso modificado")
            CargarGrilla(txt_buscar.Text.Trim())
            LimpiarForm()

        Catch ex As Exception
            MessageBox.Show("ERROR! " & ex.Message)
        End Try
    End Sub

    'boton eliminar
    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        If txt_idCurso.Text = "" Then
            MessageBox.Show("Elegí un curso de la grilla")
            Return
        End If

        'pido confirmacion antes de borrar
        Dim respuesta As DialogResult = MessageBox.Show("¿Seguro que querés eliminar el curso " & txt_titulo.Text & "?",
                                                        "Eliminar curso", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If respuesta = DialogResult.No Then Return

        Try
            ServiceProfesor.EliminarCurso(CInt(txt_idCurso.Text), ServiceAutenticacion.UsuarioActual.id)

            MessageBox.Show("Curso eliminado")
            CargarGrilla(txt_buscar.Text.Trim())
            LimpiarForm()

        Catch ex As MySqlException
            'error 1451 = el curso tiene inscripciones y la base no deja borrarlo
            If ex.Number = 1451 Then
                MessageBox.Show("No se puede eliminar porque tiene alumnos inscriptos. Podés ponerlo en estado cerrado.")
            Else
                MessageBox.Show("ERROR! " & ex.Message)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR! " & ex.Message)
        End Try
    End Sub

    'al hacer click en una fila paso los datos a los campos
    Private Sub dgv_cursos_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_cursos.CellClick
        'si hizo click en el encabezado no hago nada
        If e.RowIndex < 0 Then Return

        Dim fila As DataGridViewRow = dgv_cursos.Rows(e.RowIndex)
        txt_idCurso.Text = fila.Cells("id").Value.ToString()
        txt_titulo.Text = fila.Cells("titulo").Value.ToString()
        txt_descripcion.Text = fila.Cells("descripcion").Value.ToString()
        cmb_categoria.SelectedValue = fila.Cells("categoria_id").Value
        nud_precio.Value = CDec(fila.Cells("precio").Value)
        cmb_nivel.Text = fila.Cells("nivel").Value.ToString()
        cmb_estado.Text = fila.Cells("estado").Value.ToString()
    End Sub

    'buscador: filtra la grilla mientras escribe
    Private Sub txt_buscar_TextChanged(sender As Object, e As EventArgs) Handles txt_buscar.TextChanged
        CargarGrilla(txt_buscar.Text.Trim())
    End Sub

    '---------------------- PESTAÑA MIS ALUMNOS ----------------------

    'cargo el combo con los cursos del profesor
    Sub CargarComboCursosAlumnos()
        Try
            cmb_filtroCurso.DisplayMember = "titulo"
            cmb_filtroCurso.ValueMember = "id"
            cmb_filtroCurso.DataSource = ServiceProfesor.ListarCursos(ServiceAutenticacion.UsuarioActual.id, "")
        Catch ex As Exception
            MessageBox.Show("ERROR al cargar cursos: " & ex.Message)
        End Try
    End Sub

    'cargo en la grilla los alumnos del curso elegido, segun el filtro de la lista
    Sub CargarGrillaAlumnos()
        'si todavia no hay curso elegido (o no tiene cursos) dejo la grilla vacia
        If cmb_filtroCurso.SelectedValue Is Nothing OrElse lst_filtroAvance.SelectedIndex = -1 Then
            dgv_alumnos.DataSource = Nothing
            lbl_cantidadAlumnos.Text = "Alumnos inscriptos: 0"
            Return
        End If

        Try
            'le paso la posicion elegida en la lista: 0 todos, 1 sin empezar, 2 en curso, 3 finalizados
            dgv_alumnos.DataSource = ServiceProfesor.ListarAlumnos(CInt(cmb_filtroCurso.SelectedValue),
                                                                   ServiceAutenticacion.UsuarioActual.id,
                                                                   lst_filtroAvance.SelectedIndex)

            dgv_alumnos.Columns("id").Visible = False
            dgv_alumnos.Columns("alumno").HeaderText = "Alumno"
            dgv_alumnos.Columns("email").HeaderText = "Email"
            dgv_alumnos.Columns("fecha_solicitud").HeaderText = "Inscripto desde"
            dgv_alumnos.Columns("completadas").HeaderText = "Completadas"
            dgv_alumnos.Columns("total").HeaderText = "Total"
            'la fecha sin la hora
            dgv_alumnos.Columns("fecha_solicitud").DefaultCellStyle.Format = "dd/MM/yyyy"
            'le doy mas lugar al email y menos a los numeros
            dgv_alumnos.Columns("email").FillWeight = 170
            dgv_alumnos.Columns("completadas").FillWeight = 70
            dgv_alumnos.Columns("total").FillWeight = 50

            lbl_cantidadAlumnos.Text = "Alumnos inscriptos: " & dgv_alumnos.Rows.Count

        Catch ex As Exception
            MessageBox.Show("ERROR! " & ex.Message)
        End Try
    End Sub

    'cuando cambia el curso o el filtro recargo la grilla
    Private Sub cmb_filtroCurso_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmb_filtroCurso.SelectedIndexChanged
        CargarGrillaAlumnos()
    End Sub

    Private Sub lst_filtroAvance_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_filtroAvance.SelectedIndexChanged
        CargarGrillaAlumnos()
    End Sub

    '---------------------- PESTAÑA MI INFORMACION ----------------------

    'muestro los datos del profesor logueado
    Sub CargarMisDatos()
        Try
            Dim fila As DataRow = ServiceProfesor.ObtenerDatos(ServiceAutenticacion.UsuarioActual.id)
            If fila Is Nothing Then Return

            txt_infoNombre.Text = fila("nombre").ToString()
            txt_infoApellido.Text = fila("apellido").ToString()
            lbl_valorDni.Text = fila("dni").ToString()
            txt_infoEmail.Text = fila("email").ToString()
            lbl_valorEstado.Text = fila("estado").ToString()
            'si todavia no escribio nada viene NULL y ToString lo deja vacio
            txt_infoDescripcion.Text = fila("descripcion").ToString()
            lbl_valorFecha.Text = CDate(fila("fecha_creacion")).ToString("dd/MM/yyyy")

        Catch ex As Exception
            MessageBox.Show("ERROR al cargar tus datos: " & ex.Message)
        End Try
    End Sub

    'boton guardar cambios
    Private Sub btn_guardarDatos_Click(sender As Object, e As EventArgs) Handles btn_guardarDatos.Click
        Dim nombre As String = txt_infoNombre.Text.Trim()
        Dim apellido As String = txt_infoApellido.Text.Trim()
        Dim email As String = txt_infoEmail.Text.Trim()

        'mismas validaciones que en el registro
        If nombre = "" OrElse apellido = "" OrElse email = "" Then
            MessageBox.Show("Completá nombre, apellido y email")
            Return
        End If

        If Not (email Like "*@*.*") Then
            MessageBox.Show("El email no es válido")
            txt_infoEmail.Focus()
            Return
        End If

        Try
            'la descripcion puede quedar vacia
            ServiceProfesor.GuardarDatos(ServiceAutenticacion.UsuarioActual.id, nombre, apellido, email,
                                         txt_infoDescripcion.Text.Trim())

            'actualizo tambien el usuario logueado y el saludo de arriba
            ServiceAutenticacion.UsuarioActual.nombre = nombre
            ServiceAutenticacion.UsuarioActual.apellido = apellido
            lbl_bienvenida.Text = "Bienvenido, " & nombre & " " & apellido

            MessageBox.Show("Datos actualizados")

        Catch ex As MySqlException
            'error 1062 = ese email ya lo tiene otro profesor
            If ex.Number = 1062 Then
                MessageBox.Show("Ese email ya está registrado")
                txt_infoEmail.Focus()
            Else
                MessageBox.Show("ERROR! " & ex.Message)
            End If
        Catch ex As Exception
            MessageBox.Show("ERROR! " & ex.Message)
        End Try
    End Sub

    '---------------------- GENERAL ----------------------

    'cerrar sesion: al cerrar este form el login vuelve a aparecer
    Private Sub btn_cerrarSesion_Click(sender As Object, e As EventArgs) Handles btn_cerrarSesion.Click
        Me.Close()
    End Sub

End Class
