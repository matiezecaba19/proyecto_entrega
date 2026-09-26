'importo para armar la ruta de las imagenes
Imports System.IO

'LECCIONES DE UN CURSO
Public Class lecciones

    'datos del curso que viene del panel del profesor
    Public cursoId As Integer
    Public tituloCurso As String

    'al abrir el form
    Private Sub lecciones_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lbl_tituloLecciones.Text = "Lecciones de: " & tituloCurso
        CargarGrilla()
        LimpiarForm()
    End Sub

    '---------------------- LECCIONES ----------------------

    'cargo las lecciones del curso en la grilla
    Sub CargarGrilla()
        Try
            dgv_lecciones.DataSource = ServiceLecciones.ListarLecciones(cursoId)

            dgv_lecciones.Columns("id").Visible = False
            dgv_lecciones.Columns("contenido").Visible = False
            dgv_lecciones.Columns("orden").HeaderText = "N°"
            dgv_lecciones.Columns("titulo").HeaderText = "Título"
            dgv_lecciones.Columns("orden").FillWeight = 20

        Catch ex As Exception
            MessageBox.Show("ERROR! " & ex.Message)
        End Try
    End Sub

    'dejo los campos vacios para cargar una leccion nueva
    Sub LimpiarForm()
        txt_idLeccion.Clear()
        txt_tituloLeccion.Clear()
        txt_contenido.Clear()
        'propongo como orden la siguiente leccion
        nud_orden.Value = Math.Min(dgv_lecciones.Rows.Count + 1, nud_orden.Maximum)
        dgv_lecciones.ClearSelection()

        'sin leccion elegida no se pueden cargar imagenes
        lst_imagenes.DataSource = Nothing
        LimpiarVistaPrevia()
        grp_imagenes.Enabled = False
        grp_imagenes.Text = "Imágenes de la lección (elegí una lección de la grilla)"

        txt_tituloLeccion.Focus()
    End Sub

    'boton limpiar
    Private Sub btn_limpiar_Click(sender As Object, e As EventArgs) Handles btn_limpiar.Click
        LimpiarForm()
    End Sub

    'boton agregar
    Private Sub btn_agregar_Click(sender As Object, e As EventArgs) Handles btn_agregar.Click
        'si ya tiene id la leccion existe, para eso esta modificar
        If txt_idLeccion.Text <> "" Then
            MessageBox.Show("Esa lección ya existe, usá Modificar. Para cargar una nueva apretá Limpiar.")
            Return
        End If

        If txt_tituloLeccion.Text.Trim() = "" Then
            MessageBox.Show("Ingresá el título de la lección")
            txt_tituloLeccion.Focus()
            Return
        End If

        Try
            ServiceLecciones.AgregarLeccion(cursoId, txt_tituloLeccion.Text.Trim(), txt_contenido.Text.Trim(),
                                            CInt(nud_orden.Value))
            MessageBox.Show("Lección agregada. Hacé click en ella para cargarle imágenes.")
            CargarGrilla()
            LimpiarForm()

        Catch ex As Exception
            MessageBox.Show("ERROR! " & ex.Message)
        End Try
    End Sub

    'boton modificar
    Private Sub btn_modificar_Click(sender As Object, e As EventArgs) Handles btn_modificar.Click
        If txt_idLeccion.Text = "" Then
            MessageBox.Show("Elegí una lección de la grilla")
            Return
        End If

        If txt_tituloLeccion.Text.Trim() = "" Then
            MessageBox.Show("Ingresá el título de la lección")
            txt_tituloLeccion.Focus()
            Return
        End If

        Try
            ServiceLecciones.ModificarLeccion(CInt(txt_idLeccion.Text), txt_tituloLeccion.Text.Trim(),
                                              txt_contenido.Text.Trim(), CInt(nud_orden.Value))
            MessageBox.Show("Lección modificada")
            CargarGrilla()
            LimpiarForm()

        Catch ex As Exception
            MessageBox.Show("ERROR! " & ex.Message)
        End Try
    End Sub

    'boton eliminar
    Private Sub btn_eliminar_Click(sender As Object, e As EventArgs) Handles btn_eliminar.Click
        If txt_idLeccion.Text = "" Then
            MessageBox.Show("Elegí una lección de la grilla")
            Return
        End If

        'aviso que tambien se borra el avance de los alumnos
        Dim respuesta As DialogResult = MessageBox.Show("¿Seguro que querés eliminar la lección " & txt_tituloLeccion.Text & "?" &
                                                        vbCrLf & "También se borran sus imágenes y el avance de los alumnos en esta lección.",
                                                        "Eliminar lección", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
        If respuesta = DialogResult.No Then Return

        Try
            LimpiarVistaPrevia()
            ServiceLecciones.EliminarLeccion(CInt(txt_idLeccion.Text))
            MessageBox.Show("Lección eliminada")
            CargarGrilla()
            LimpiarForm()

        Catch ex As Exception
            MessageBox.Show("ERROR! " & ex.Message)
        End Try
    End Sub

    'al hacer click en una leccion paso los datos a los campos y cargo sus imagenes
    Private Sub dgv_lecciones_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_lecciones.CellClick
        If e.RowIndex < 0 Then Return

        Dim fila As DataGridViewRow = dgv_lecciones.Rows(e.RowIndex)
        txt_idLeccion.Text = fila.Cells("id").Value.ToString()
        txt_tituloLeccion.Text = fila.Cells("titulo").Value.ToString()
        txt_contenido.Text = fila.Cells("contenido").Value.ToString()
        nud_orden.Value = CInt(fila.Cells("orden").Value)

        grp_imagenes.Enabled = True
        grp_imagenes.Text = "Imágenes de la lección"
        CargarImagenes()
    End Sub

    '---------------------- IMAGENES ----------------------

    'cargo las imagenes de la leccion elegida
    Sub CargarImagenes()
        Try
            LimpiarVistaPrevia()
            'muestro el nombre del archivo y guardo el id
            lst_imagenes.DisplayMember = "url"
            lst_imagenes.ValueMember = "id"
            lst_imagenes.DataSource = ServiceLecciones.ListarImagenes(CInt(txt_idLeccion.Text))
            MostrarImagen()
        Catch ex As Exception
            MessageBox.Show("ERROR al cargar imágenes: " & ex.Message)
        End Try
    End Sub

    'muestro en el cuadro la imagen elegida en la lista
    Sub MostrarImagen()
        LimpiarVistaPrevia()
        If lst_imagenes.SelectedIndex = -1 Then Return

        Dim fila As DataRowView = CType(lst_imagenes.SelectedItem, DataRowView)
        Dim ruta As String = Path.Combine(ServiceLecciones.CarpetaImagenes(), fila("url").ToString())

        'si el archivo no esta en esta PC no muestro nada
        If Not File.Exists(ruta) Then Return

        'hago una copia en memoria y cierro el archivo, asi despues se puede borrar
        Using img As Image = Image.FromFile(ruta)
            pic_imagen.Image = New Bitmap(img)
        End Using
    End Sub

    'saco la imagen del cuadro y libero la memoria
    Sub LimpiarVistaPrevia()
        If pic_imagen.Image IsNot Nothing Then
            pic_imagen.Image.Dispose()
            pic_imagen.Image = Nothing
        End If
    End Sub

    Private Sub lst_imagenes_SelectedIndexChanged(sender As Object, e As EventArgs) Handles lst_imagenes.SelectedIndexChanged
        MostrarImagen()
    End Sub

    'boton agregar imagen
    Private Sub btn_agregarImagen_Click(sender As Object, e As EventArgs) Handles btn_agregarImagen.Click
        If txt_idLeccion.Text = "" Then
            MessageBox.Show("Elegí una lección de la grilla")
            Return
        End If

        'abro la ventana para elegir el archivo
        Using dlg As New OpenFileDialog()
            dlg.Title = "Elegí una imagen"
            dlg.Filter = "Imágenes|*.png;*.jpg;*.jpeg;*.bmp;*.gif"
            If dlg.ShowDialog() <> DialogResult.OK Then Return

            Try
                'la nueva va al final de la lista
                ServiceLecciones.AgregarImagen(CInt(txt_idLeccion.Text), dlg.FileName, lst_imagenes.Items.Count + 1)
                CargarImagenes()
                'dejo elegida la que acabo de agregar
                lst_imagenes.SelectedIndex = lst_imagenes.Items.Count - 1

            Catch ex As Exception
                MessageBox.Show("ERROR! " & ex.Message)
            End Try
        End Using
    End Sub

    'boton quitar imagen
    Private Sub btn_quitarImagen_Click(sender As Object, e As EventArgs) Handles btn_quitarImagen.Click
        If lst_imagenes.SelectedIndex = -1 Then
            MessageBox.Show("Elegí una imagen de la lista")
            Return
        End If

        Dim respuesta As DialogResult = MessageBox.Show("¿Quitar la imagen elegida?", "Quitar imagen",
                                                        MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If respuesta = DialogResult.No Then Return

        Try
            Dim fila As DataRowView = CType(lst_imagenes.SelectedItem, DataRowView)
            LimpiarVistaPrevia()
            ServiceLecciones.QuitarImagen(CInt(fila("id")), fila("url").ToString())
            CargarImagenes()

        Catch ex As Exception
            MessageBox.Show("ERROR! " & ex.Message)
        End Try
    End Sub

    '---------------------- GENERAL ----------------------

    'vuelvo al panel del profesor
    Private Sub btn_volver_Click(sender As Object, e As EventArgs) Handles btn_volver.Click
        Me.Close()
    End Sub

End Class
