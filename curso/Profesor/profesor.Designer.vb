<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class profesor
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lbl_bienvenida = New Label()
        btn_cerrarSesion = New Button()
        tab_profesor = New TabControl()
        tab_cursos = New TabPage()
        lbl_buscar = New Label()
        txt_buscar = New TextBox()
        dgv_cursos = New DataGridView()
        grp_datosCurso = New GroupBox()
        lbl_idCurso = New Label()
        txt_idCurso = New TextBox()
        lbl_titulo = New Label()
        txt_titulo = New TextBox()
        lbl_descripcion = New Label()
        txt_descripcion = New TextBox()
        lbl_categoria = New Label()
        cmb_categoria = New ComboBox()
        lbl_precio = New Label()
        nud_precio = New NumericUpDown()
        lbl_nivel = New Label()
        cmb_nivel = New ComboBox()
        lbl_estado = New Label()
        cmb_estado = New ComboBox()
        btn_nuevo = New Button()
        btn_guardar = New Button()
        btn_modificar = New Button()
        btn_eliminar = New Button()
        btn_lecciones = New Button()
        tab_alumnos = New TabPage()
        lbl_filtroCurso = New Label()
        cmb_filtroCurso = New ComboBox()
        lbl_cantidadAlumnos = New Label()
        lbl_mostrar = New Label()
        lst_filtroAvance = New ListBox()
        dgv_alumnos = New DataGridView()
        tab_info = New TabPage()
        grp_misDatos = New GroupBox()
        lbl_tituloNombre = New Label()
        txt_infoNombre = New TextBox()
        lbl_tituloApellido = New Label()
        txt_infoApellido = New TextBox()
        lbl_tituloDni = New Label()
        lbl_valorDni = New Label()
        lbl_tituloEmail = New Label()
        txt_infoEmail = New TextBox()
        lbl_tituloEstado = New Label()
        lbl_valorEstado = New Label()
        lbl_tituloFecha = New Label()
        lbl_valorFecha = New Label()
        lbl_foto = New Label()
        grp_descripcion = New GroupBox()
        txt_infoDescripcion = New TextBox()
        btn_guardarDatos = New Button()
        tab_profesor.SuspendLayout()
        tab_cursos.SuspendLayout()
        CType(dgv_cursos, ComponentModel.ISupportInitialize).BeginInit()
        grp_datosCurso.SuspendLayout()
        CType(nud_precio, ComponentModel.ISupportInitialize).BeginInit()
        tab_alumnos.SuspendLayout()
        CType(dgv_alumnos, ComponentModel.ISupportInitialize).BeginInit()
        tab_info.SuspendLayout()
        grp_misDatos.SuspendLayout()
        grp_descripcion.SuspendLayout()
        SuspendLayout()
        '
        ' lbl_bienvenida
        '
        lbl_bienvenida.Font = New Font("Cambria", 16F)
        lbl_bienvenida.Location = New Point(12, 9)
        lbl_bienvenida.Name = "lbl_bienvenida"
        lbl_bienvenida.Size = New Size(600, 35)
        lbl_bienvenida.TabIndex = 0
        lbl_bienvenida.Text = "Panel del Profesor"
        lbl_bienvenida.TextAlign = ContentAlignment.MiddleLeft
        '
        ' btn_cerrarSesion
        '
        btn_cerrarSesion.Location = New Point(770, 12)
        btn_cerrarSesion.Name = "btn_cerrarSesion"
        btn_cerrarSesion.Size = New Size(118, 30)
        btn_cerrarSesion.TabIndex = 1
        btn_cerrarSesion.Text = "Cerrar sesión"
        btn_cerrarSesion.UseVisualStyleBackColor = True
        '
        ' tab_profesor
        '
        tab_profesor.Controls.Add(tab_cursos)
        tab_profesor.Controls.Add(tab_alumnos)
        tab_profesor.Controls.Add(tab_info)
        tab_profesor.Location = New Point(12, 55)
        tab_profesor.Name = "tab_profesor"
        tab_profesor.SelectedIndex = 0
        tab_profesor.Size = New Size(876, 533)
        tab_profesor.TabIndex = 2
        '
        ' tab_cursos
        '
        tab_cursos.Controls.Add(grp_datosCurso)
        tab_cursos.Controls.Add(dgv_cursos)
        tab_cursos.Controls.Add(txt_buscar)
        tab_cursos.Controls.Add(lbl_buscar)
        tab_cursos.Location = New Point(4, 24)
        tab_cursos.Name = "tab_cursos"
        tab_cursos.Padding = New Padding(3)
        tab_cursos.Size = New Size(868, 505)
        tab_cursos.TabIndex = 0
        tab_cursos.Text = "Mis cursos"
        tab_cursos.UseVisualStyleBackColor = True
        '
        ' lbl_buscar
        '
        lbl_buscar.AutoSize = True
        lbl_buscar.Location = New Point(15, 18)
        lbl_buscar.Name = "lbl_buscar"
        lbl_buscar.Size = New Size(42, 15)
        lbl_buscar.TabIndex = 0
        lbl_buscar.Text = "Buscar"
        '
        ' txt_buscar
        '
        txt_buscar.Location = New Point(65, 15)
        txt_buscar.MaxLength = 30
        txt_buscar.Name = "txt_buscar"
        txt_buscar.Size = New Size(460, 23)
        txt_buscar.TabIndex = 1
        '
        ' dgv_cursos
        '
        dgv_cursos.AllowUserToAddRows = False
        dgv_cursos.AllowUserToDeleteRows = False
        dgv_cursos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv_cursos.BackgroundColor = SystemColors.Window
        dgv_cursos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgv_cursos.Location = New Point(15, 50)
        dgv_cursos.MultiSelect = False
        dgv_cursos.Name = "dgv_cursos"
        dgv_cursos.ReadOnly = True
        dgv_cursos.RowHeadersVisible = False
        dgv_cursos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv_cursos.Size = New Size(510, 440)
        dgv_cursos.TabIndex = 3
        '
        ' grp_datosCurso
        '
        grp_datosCurso.Controls.Add(btn_lecciones)
        grp_datosCurso.Controls.Add(btn_eliminar)
        grp_datosCurso.Controls.Add(btn_modificar)
        grp_datosCurso.Controls.Add(btn_guardar)
        grp_datosCurso.Controls.Add(btn_nuevo)
        grp_datosCurso.Controls.Add(cmb_estado)
        grp_datosCurso.Controls.Add(lbl_estado)
        grp_datosCurso.Controls.Add(cmb_nivel)
        grp_datosCurso.Controls.Add(lbl_nivel)
        grp_datosCurso.Controls.Add(nud_precio)
        grp_datosCurso.Controls.Add(lbl_precio)
        grp_datosCurso.Controls.Add(cmb_categoria)
        grp_datosCurso.Controls.Add(lbl_categoria)
        grp_datosCurso.Controls.Add(txt_descripcion)
        grp_datosCurso.Controls.Add(lbl_descripcion)
        grp_datosCurso.Controls.Add(txt_titulo)
        grp_datosCurso.Controls.Add(lbl_titulo)
        grp_datosCurso.Controls.Add(txt_idCurso)
        grp_datosCurso.Controls.Add(lbl_idCurso)
        grp_datosCurso.Location = New Point(540, 10)
        grp_datosCurso.Name = "grp_datosCurso"
        grp_datosCurso.Size = New Size(310, 480)
        grp_datosCurso.TabIndex = 4
        grp_datosCurso.TabStop = False
        grp_datosCurso.Text = "Datos del curso"
        '
        ' lbl_idCurso
        '
        lbl_idCurso.AutoSize = True
        lbl_idCurso.Location = New Point(15, 25)
        lbl_idCurso.Name = "lbl_idCurso"
        lbl_idCurso.Size = New Size(18, 15)
        lbl_idCurso.TabIndex = 0
        lbl_idCurso.Text = "ID"
        '
        ' txt_idCurso
        '
        txt_idCurso.Location = New Point(15, 43)
        txt_idCurso.Name = "txt_idCurso"
        txt_idCurso.ReadOnly = True
        txt_idCurso.Size = New Size(80, 23)
        txt_idCurso.TabIndex = 1
        txt_idCurso.TabStop = False
        '
        ' lbl_titulo
        '
        lbl_titulo.AutoSize = True
        lbl_titulo.Location = New Point(15, 75)
        lbl_titulo.Name = "lbl_titulo"
        lbl_titulo.Size = New Size(37, 15)
        lbl_titulo.TabIndex = 2
        lbl_titulo.Text = "Título"
        '
        ' txt_titulo
        '
        txt_titulo.Location = New Point(15, 93)
        txt_titulo.MaxLength = 30
        txt_titulo.Name = "txt_titulo"
        txt_titulo.Size = New Size(280, 23)
        txt_titulo.TabIndex = 3
        '
        ' lbl_descripcion
        '
        lbl_descripcion.AutoSize = True
        lbl_descripcion.Location = New Point(15, 125)
        lbl_descripcion.Name = "lbl_descripcion"
        lbl_descripcion.Size = New Size(69, 15)
        lbl_descripcion.TabIndex = 4
        lbl_descripcion.Text = "Descripción"
        '
        ' txt_descripcion
        '
        txt_descripcion.Location = New Point(15, 143)
        txt_descripcion.Multiline = True
        txt_descripcion.Name = "txt_descripcion"
        txt_descripcion.ScrollBars = ScrollBars.Vertical
        txt_descripcion.Size = New Size(280, 60)
        txt_descripcion.TabIndex = 5
        '
        ' lbl_categoria
        '
        lbl_categoria.AutoSize = True
        lbl_categoria.Location = New Point(15, 213)
        lbl_categoria.Name = "lbl_categoria"
        lbl_categoria.Size = New Size(58, 15)
        lbl_categoria.TabIndex = 6
        lbl_categoria.Text = "Categoría"
        '
        ' cmb_categoria
        '
        cmb_categoria.DropDownStyle = ComboBoxStyle.DropDownList
        cmb_categoria.FormattingEnabled = True
        cmb_categoria.Location = New Point(15, 231)
        cmb_categoria.Name = "cmb_categoria"
        cmb_categoria.Size = New Size(280, 23)
        cmb_categoria.TabIndex = 7
        '
        ' lbl_precio
        '
        lbl_precio.AutoSize = True
        lbl_precio.Location = New Point(15, 263)
        lbl_precio.Name = "lbl_precio"
        lbl_precio.Size = New Size(40, 15)
        lbl_precio.TabIndex = 8
        lbl_precio.Text = "Precio"
        '
        ' nud_precio
        '
        nud_precio.DecimalPlaces = 2
        nud_precio.Location = New Point(15, 281)
        nud_precio.Maximum = New Decimal(New Integer() {99999999, 0, 0, 0})
        nud_precio.Name = "nud_precio"
        nud_precio.Size = New Size(130, 23)
        nud_precio.TabIndex = 9
        nud_precio.ThousandsSeparator = True
        '
        ' lbl_nivel
        '
        lbl_nivel.AutoSize = True
        lbl_nivel.Location = New Point(155, 263)
        lbl_nivel.Name = "lbl_nivel"
        lbl_nivel.Size = New Size(34, 15)
        lbl_nivel.TabIndex = 10
        lbl_nivel.Text = "Nivel"
        '
        ' cmb_nivel
        '
        cmb_nivel.DropDownStyle = ComboBoxStyle.DropDownList
        cmb_nivel.FormattingEnabled = True
        cmb_nivel.Items.AddRange(New Object() {"inicial", "intermedio", "avanzado"})
        cmb_nivel.Location = New Point(155, 281)
        cmb_nivel.Name = "cmb_nivel"
        cmb_nivel.Size = New Size(140, 23)
        cmb_nivel.TabIndex = 11
        '
        ' lbl_estado
        '
        lbl_estado.AutoSize = True
        lbl_estado.Location = New Point(15, 313)
        lbl_estado.Name = "lbl_estado"
        lbl_estado.Size = New Size(42, 15)
        lbl_estado.TabIndex = 12
        lbl_estado.Text = "Estado"
        '
        ' cmb_estado
        '
        cmb_estado.DropDownStyle = ComboBoxStyle.DropDownList
        cmb_estado.FormattingEnabled = True
        cmb_estado.Items.AddRange(New Object() {"borrador", "publicado", "cerrado"})
        cmb_estado.Location = New Point(15, 331)
        cmb_estado.Name = "cmb_estado"
        cmb_estado.Size = New Size(280, 23)
        cmb_estado.TabIndex = 13
        '
        ' btn_nuevo
        '
        btn_nuevo.Location = New Point(15, 368)
        btn_nuevo.Name = "btn_nuevo"
        btn_nuevo.Size = New Size(135, 30)
        btn_nuevo.TabIndex = 14
        btn_nuevo.Text = "Limpiar"
        btn_nuevo.UseVisualStyleBackColor = True
        '
        ' btn_guardar
        '
        btn_guardar.Location = New Point(160, 368)
        btn_guardar.Name = "btn_guardar"
        btn_guardar.Size = New Size(135, 30)
        btn_guardar.TabIndex = 15
        btn_guardar.Text = "Agregar curso"
        btn_guardar.UseVisualStyleBackColor = True
        '
        ' btn_modificar
        '
        btn_modificar.Location = New Point(15, 404)
        btn_modificar.Name = "btn_modificar"
        btn_modificar.Size = New Size(135, 30)
        btn_modificar.TabIndex = 16
        btn_modificar.Text = "Modificar"
        btn_modificar.UseVisualStyleBackColor = True
        '
        ' btn_eliminar
        '
        btn_eliminar.Location = New Point(160, 404)
        btn_eliminar.Name = "btn_eliminar"
        btn_eliminar.Size = New Size(135, 30)
        btn_eliminar.TabIndex = 17
        btn_eliminar.Text = "Eliminar"
        btn_eliminar.UseVisualStyleBackColor = True
        '
        ' btn_lecciones
        '
        btn_lecciones.Location = New Point(15, 440)
        btn_lecciones.Name = "btn_lecciones"
        btn_lecciones.Size = New Size(280, 30)
        btn_lecciones.TabIndex = 18
        btn_lecciones.Text = "Lecciones del curso"
        btn_lecciones.UseVisualStyleBackColor = True
        '
        ' tab_alumnos
        '
        tab_alumnos.Controls.Add(dgv_alumnos)
        tab_alumnos.Controls.Add(lst_filtroAvance)
        tab_alumnos.Controls.Add(lbl_mostrar)
        tab_alumnos.Controls.Add(lbl_cantidadAlumnos)
        tab_alumnos.Controls.Add(cmb_filtroCurso)
        tab_alumnos.Controls.Add(lbl_filtroCurso)
        tab_alumnos.Location = New Point(4, 24)
        tab_alumnos.Name = "tab_alumnos"
        tab_alumnos.Padding = New Padding(3)
        tab_alumnos.Size = New Size(868, 505)
        tab_alumnos.TabIndex = 1
        tab_alumnos.Text = "Mis alumnos"
        tab_alumnos.UseVisualStyleBackColor = True
        '
        ' lbl_filtroCurso
        '
        lbl_filtroCurso.AutoSize = True
        lbl_filtroCurso.Location = New Point(15, 18)
        lbl_filtroCurso.Name = "lbl_filtroCurso"
        lbl_filtroCurso.Size = New Size(38, 15)
        lbl_filtroCurso.TabIndex = 0
        lbl_filtroCurso.Text = "Curso"
        '
        ' cmb_filtroCurso
        '
        cmb_filtroCurso.DropDownStyle = ComboBoxStyle.DropDownList
        cmb_filtroCurso.FormattingEnabled = True
        cmb_filtroCurso.Location = New Point(65, 15)
        cmb_filtroCurso.Name = "cmb_filtroCurso"
        cmb_filtroCurso.Size = New Size(300, 23)
        cmb_filtroCurso.TabIndex = 1
        '
        ' lbl_cantidadAlumnos
        '
        lbl_cantidadAlumnos.AutoSize = True
        lbl_cantidadAlumnos.Location = New Point(380, 18)
        lbl_cantidadAlumnos.Name = "lbl_cantidadAlumnos"
        lbl_cantidadAlumnos.Size = New Size(124, 15)
        lbl_cantidadAlumnos.TabIndex = 2
        lbl_cantidadAlumnos.Text = "Alumnos inscriptos: 0"
        '
        ' lbl_mostrar
        '
        lbl_mostrar.AutoSize = True
        lbl_mostrar.Location = New Point(15, 50)
        lbl_mostrar.Name = "lbl_mostrar"
        lbl_mostrar.Size = New Size(49, 15)
        lbl_mostrar.TabIndex = 3
        lbl_mostrar.Text = "Mostrar"
        '
        ' lst_filtroAvance
        '
        lst_filtroAvance.FormattingEnabled = True
        lst_filtroAvance.IntegralHeight = False
        lst_filtroAvance.Items.AddRange(New Object() {"Todos", "Sin empezar", "En curso", "Finalizados"})
        lst_filtroAvance.Location = New Point(15, 68)
        lst_filtroAvance.Name = "lst_filtroAvance"
        lst_filtroAvance.Size = New Size(140, 66)
        lst_filtroAvance.TabIndex = 4
        '
        ' dgv_alumnos
        '
        dgv_alumnos.AllowUserToAddRows = False
        dgv_alumnos.AllowUserToDeleteRows = False
        dgv_alumnos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv_alumnos.BackgroundColor = SystemColors.Window
        dgv_alumnos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgv_alumnos.Location = New Point(170, 50)
        dgv_alumnos.MultiSelect = False
        dgv_alumnos.Name = "dgv_alumnos"
        dgv_alumnos.ReadOnly = True
        dgv_alumnos.RowHeadersVisible = False
        dgv_alumnos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv_alumnos.Size = New Size(680, 440)
        dgv_alumnos.TabIndex = 5
        '
        ' tab_info
        '
        tab_info.Controls.Add(btn_guardarDatos)
        tab_info.Controls.Add(grp_descripcion)
        tab_info.Controls.Add(grp_misDatos)
        tab_info.Controls.Add(lbl_foto)
        tab_info.Location = New Point(4, 24)
        tab_info.Name = "tab_info"
        tab_info.Padding = New Padding(3)
        tab_info.Size = New Size(868, 505)
        tab_info.TabIndex = 2
        tab_info.Text = "Mi información"
        tab_info.UseVisualStyleBackColor = True
        '
        ' lbl_foto
        '
        lbl_foto.BackColor = SystemColors.ControlLight
        lbl_foto.BorderStyle = BorderStyle.FixedSingle
        lbl_foto.Location = New Point(15, 22)
        lbl_foto.Name = "lbl_foto"
        lbl_foto.Size = New Size(160, 180)
        lbl_foto.TabIndex = 1
        lbl_foto.Text = "Foto"
        lbl_foto.TextAlign = ContentAlignment.MiddleCenter
        '
        ' grp_descripcion
        '
        grp_descripcion.Controls.Add(txt_infoDescripcion)
        grp_descripcion.Location = New Point(15, 290)
        grp_descripcion.Name = "grp_descripcion"
        grp_descripcion.Size = New Size(600, 130)
        grp_descripcion.TabIndex = 2
        grp_descripcion.TabStop = False
        grp_descripcion.Text = "Sobre mí"
        '
        ' txt_infoDescripcion
        '
        txt_infoDescripcion.Location = New Point(15, 25)
        txt_infoDescripcion.MaxLength = 200
        txt_infoDescripcion.Multiline = True
        txt_infoDescripcion.Name = "txt_infoDescripcion"
        txt_infoDescripcion.ScrollBars = ScrollBars.Vertical
        txt_infoDescripcion.Size = New Size(570, 90)
        txt_infoDescripcion.TabIndex = 0
        '
        ' grp_misDatos
        '
        grp_misDatos.Controls.Add(lbl_valorFecha)
        grp_misDatos.Controls.Add(lbl_tituloFecha)
        grp_misDatos.Controls.Add(lbl_valorEstado)
        grp_misDatos.Controls.Add(lbl_tituloEstado)
        grp_misDatos.Controls.Add(txt_infoEmail)
        grp_misDatos.Controls.Add(lbl_tituloEmail)
        grp_misDatos.Controls.Add(lbl_valorDni)
        grp_misDatos.Controls.Add(lbl_tituloDni)
        grp_misDatos.Controls.Add(txt_infoApellido)
        grp_misDatos.Controls.Add(lbl_tituloApellido)
        grp_misDatos.Controls.Add(txt_infoNombre)
        grp_misDatos.Controls.Add(lbl_tituloNombre)
        grp_misDatos.Location = New Point(195, 15)
        grp_misDatos.Name = "grp_misDatos"
        grp_misDatos.Size = New Size(420, 260)
        grp_misDatos.TabIndex = 0
        grp_misDatos.TabStop = False
        grp_misDatos.Text = "Mis datos"
        '
        ' btn_guardarDatos
        '
        btn_guardarDatos.Location = New Point(465, 430)
        btn_guardarDatos.Name = "btn_guardarDatos"
        btn_guardarDatos.Size = New Size(150, 30)
        btn_guardarDatos.TabIndex = 3
        btn_guardarDatos.Text = "Guardar cambios"
        btn_guardarDatos.UseVisualStyleBackColor = True
        '
        ' lbl_tituloNombre
        '
        lbl_tituloNombre.Location = New Point(20, 35)
        lbl_tituloNombre.Name = "lbl_tituloNombre"
        lbl_tituloNombre.Size = New Size(100, 20)
        lbl_tituloNombre.TabIndex = 0
        lbl_tituloNombre.Text = "Nombre:"
        '
        ' txt_infoNombre
        '
        txt_infoNombre.Location = New Point(130, 32)
        txt_infoNombre.MaxLength = 20
        txt_infoNombre.Name = "txt_infoNombre"
        txt_infoNombre.Size = New Size(250, 23)
        txt_infoNombre.TabIndex = 1
        '
        ' lbl_tituloApellido
        '
        lbl_tituloApellido.Location = New Point(20, 70)
        lbl_tituloApellido.Name = "lbl_tituloApellido"
        lbl_tituloApellido.Size = New Size(100, 20)
        lbl_tituloApellido.TabIndex = 2
        lbl_tituloApellido.Text = "Apellido:"
        '
        ' txt_infoApellido
        '
        txt_infoApellido.Location = New Point(130, 67)
        txt_infoApellido.MaxLength = 20
        txt_infoApellido.Name = "txt_infoApellido"
        txt_infoApellido.Size = New Size(250, 23)
        txt_infoApellido.TabIndex = 3
        '
        ' lbl_tituloDni
        '
        lbl_tituloDni.Location = New Point(20, 105)
        lbl_tituloDni.Name = "lbl_tituloDni"
        lbl_tituloDni.Size = New Size(100, 20)
        lbl_tituloDni.TabIndex = 4
        lbl_tituloDni.Text = "DNI:"
        '
        ' lbl_valorDni
        '
        lbl_valorDni.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lbl_valorDni.Location = New Point(130, 105)
        lbl_valorDni.Name = "lbl_valorDni"
        lbl_valorDni.Size = New Size(270, 20)
        lbl_valorDni.TabIndex = 5
        lbl_valorDni.Text = "-"
        '
        ' lbl_tituloEmail
        '
        lbl_tituloEmail.Location = New Point(20, 140)
        lbl_tituloEmail.Name = "lbl_tituloEmail"
        lbl_tituloEmail.Size = New Size(100, 20)
        lbl_tituloEmail.TabIndex = 6
        lbl_tituloEmail.Text = "Email:"
        '
        ' txt_infoEmail
        '
        txt_infoEmail.Location = New Point(130, 137)
        txt_infoEmail.MaxLength = 50
        txt_infoEmail.Name = "txt_infoEmail"
        txt_infoEmail.Size = New Size(250, 23)
        txt_infoEmail.TabIndex = 7
        '
        ' lbl_tituloEstado
        '
        lbl_tituloEstado.Location = New Point(20, 175)
        lbl_tituloEstado.Name = "lbl_tituloEstado"
        lbl_tituloEstado.Size = New Size(100, 20)
        lbl_tituloEstado.TabIndex = 8
        lbl_tituloEstado.Text = "Estado:"
        '
        ' lbl_valorEstado
        '
        lbl_valorEstado.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lbl_valorEstado.Location = New Point(130, 175)
        lbl_valorEstado.Name = "lbl_valorEstado"
        lbl_valorEstado.Size = New Size(270, 20)
        lbl_valorEstado.TabIndex = 9
        lbl_valorEstado.Text = "-"
        '
        ' lbl_tituloFecha
        '
        lbl_tituloFecha.Location = New Point(20, 210)
        lbl_tituloFecha.Name = "lbl_tituloFecha"
        lbl_tituloFecha.Size = New Size(100, 20)
        lbl_tituloFecha.TabIndex = 10
        lbl_tituloFecha.Text = "Fecha de alta:"
        '
        ' lbl_valorFecha
        '
        lbl_valorFecha.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        lbl_valorFecha.Location = New Point(130, 210)
        lbl_valorFecha.Name = "lbl_valorFecha"
        lbl_valorFecha.Size = New Size(270, 20)
        lbl_valorFecha.TabIndex = 11
        lbl_valorFecha.Text = "-"
        '
        ' profesor
        '
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(900, 600)
        Controls.Add(tab_profesor)
        Controls.Add(btn_cerrarSesion)
        Controls.Add(lbl_bienvenida)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "profesor"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Profesor"
        tab_profesor.ResumeLayout(False)
        tab_cursos.ResumeLayout(False)
        tab_cursos.PerformLayout()
        CType(dgv_cursos, ComponentModel.ISupportInitialize).EndInit()
        grp_datosCurso.ResumeLayout(False)
        grp_datosCurso.PerformLayout()
        CType(nud_precio, ComponentModel.ISupportInitialize).EndInit()
        tab_alumnos.ResumeLayout(False)
        tab_alumnos.PerformLayout()
        CType(dgv_alumnos, ComponentModel.ISupportInitialize).EndInit()
        tab_info.ResumeLayout(False)
        grp_misDatos.ResumeLayout(False)
        grp_descripcion.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents lbl_bienvenida As Label
    Friend WithEvents btn_cerrarSesion As Button
    Friend WithEvents tab_profesor As TabControl
    Friend WithEvents tab_cursos As TabPage
    Friend WithEvents lbl_buscar As Label
    Friend WithEvents txt_buscar As TextBox
    Friend WithEvents dgv_cursos As DataGridView
    Friend WithEvents grp_datosCurso As GroupBox
    Friend WithEvents lbl_idCurso As Label
    Friend WithEvents txt_idCurso As TextBox
    Friend WithEvents lbl_titulo As Label
    Friend WithEvents txt_titulo As TextBox
    Friend WithEvents lbl_descripcion As Label
    Friend WithEvents txt_descripcion As TextBox
    Friend WithEvents lbl_categoria As Label
    Friend WithEvents cmb_categoria As ComboBox
    Friend WithEvents lbl_precio As Label
    Friend WithEvents nud_precio As NumericUpDown
    Friend WithEvents lbl_nivel As Label
    Friend WithEvents cmb_nivel As ComboBox
    Friend WithEvents lbl_estado As Label
    Friend WithEvents cmb_estado As ComboBox
    Friend WithEvents btn_nuevo As Button
    Friend WithEvents btn_guardar As Button
    Friend WithEvents btn_modificar As Button
    Friend WithEvents btn_eliminar As Button
    Friend WithEvents btn_lecciones As Button
    Friend WithEvents tab_alumnos As TabPage
    Friend WithEvents lbl_filtroCurso As Label
    Friend WithEvents cmb_filtroCurso As ComboBox
    Friend WithEvents lbl_cantidadAlumnos As Label
    Friend WithEvents lbl_mostrar As Label
    Friend WithEvents lst_filtroAvance As ListBox
    Friend WithEvents dgv_alumnos As DataGridView
    Friend WithEvents tab_info As TabPage
    Friend WithEvents grp_misDatos As GroupBox
    Friend WithEvents lbl_tituloNombre As Label
    Friend WithEvents txt_infoNombre As TextBox
    Friend WithEvents lbl_tituloApellido As Label
    Friend WithEvents txt_infoApellido As TextBox
    Friend WithEvents lbl_tituloDni As Label
    Friend WithEvents lbl_valorDni As Label
    Friend WithEvents lbl_tituloEmail As Label
    Friend WithEvents txt_infoEmail As TextBox
    Friend WithEvents lbl_tituloEstado As Label
    Friend WithEvents lbl_valorEstado As Label
    Friend WithEvents lbl_tituloFecha As Label
    Friend WithEvents lbl_valorFecha As Label
    Friend WithEvents lbl_foto As Label
    Friend WithEvents grp_descripcion As GroupBox
    Friend WithEvents txt_infoDescripcion As TextBox
    Friend WithEvents btn_guardarDatos As Button

End Class
