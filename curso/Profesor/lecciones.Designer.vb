<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class lecciones
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
        lbl_tituloLecciones = New Label()
        btn_volver = New Button()
        dgv_lecciones = New DataGridView()
        grp_datosLeccion = New GroupBox()
        lbl_idLeccion = New Label()
        txt_idLeccion = New TextBox()
        lbl_orden = New Label()
        nud_orden = New NumericUpDown()
        lbl_tituloLeccion = New Label()
        txt_tituloLeccion = New TextBox()
        lbl_contenido = New Label()
        txt_contenido = New TextBox()
        btn_limpiar = New Button()
        btn_agregar = New Button()
        btn_modificar = New Button()
        btn_eliminar = New Button()
        grp_imagenes = New GroupBox()
        lst_imagenes = New ListBox()
        pic_imagen = New PictureBox()
        btn_agregarImagen = New Button()
        btn_quitarImagen = New Button()
        CType(dgv_lecciones, ComponentModel.ISupportInitialize).BeginInit()
        grp_datosLeccion.SuspendLayout()
        CType(nud_orden, ComponentModel.ISupportInitialize).BeginInit()
        grp_imagenes.SuspendLayout()
        CType(pic_imagen, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        '
        ' lbl_tituloLecciones
        '
        lbl_tituloLecciones.Font = New Font("Cambria", 16F)
        lbl_tituloLecciones.Location = New Point(12, 9)
        lbl_tituloLecciones.Name = "lbl_tituloLecciones"
        lbl_tituloLecciones.Size = New Size(740, 35)
        lbl_tituloLecciones.TabIndex = 0
        lbl_tituloLecciones.Text = "Lecciones del curso"
        lbl_tituloLecciones.TextAlign = ContentAlignment.MiddleLeft
        '
        ' btn_volver
        '
        btn_volver.Location = New Point(770, 12)
        btn_volver.Name = "btn_volver"
        btn_volver.Size = New Size(118, 30)
        btn_volver.TabIndex = 1
        btn_volver.Text = "Volver"
        btn_volver.UseVisualStyleBackColor = True
        '
        ' dgv_lecciones
        '
        dgv_lecciones.AllowUserToAddRows = False
        dgv_lecciones.AllowUserToDeleteRows = False
        dgv_lecciones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv_lecciones.BackgroundColor = SystemColors.Window
        dgv_lecciones.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgv_lecciones.Location = New Point(12, 55)
        dgv_lecciones.MultiSelect = False
        dgv_lecciones.Name = "dgv_lecciones"
        dgv_lecciones.ReadOnly = True
        dgv_lecciones.RowHeadersVisible = False
        dgv_lecciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv_lecciones.Size = New Size(400, 530)
        dgv_lecciones.TabIndex = 2
        '
        ' grp_datosLeccion
        '
        grp_datosLeccion.Controls.Add(btn_eliminar)
        grp_datosLeccion.Controls.Add(btn_modificar)
        grp_datosLeccion.Controls.Add(btn_agregar)
        grp_datosLeccion.Controls.Add(btn_limpiar)
        grp_datosLeccion.Controls.Add(txt_contenido)
        grp_datosLeccion.Controls.Add(lbl_contenido)
        grp_datosLeccion.Controls.Add(txt_tituloLeccion)
        grp_datosLeccion.Controls.Add(lbl_tituloLeccion)
        grp_datosLeccion.Controls.Add(nud_orden)
        grp_datosLeccion.Controls.Add(lbl_orden)
        grp_datosLeccion.Controls.Add(txt_idLeccion)
        grp_datosLeccion.Controls.Add(lbl_idLeccion)
        grp_datosLeccion.Location = New Point(425, 50)
        grp_datosLeccion.Name = "grp_datosLeccion"
        grp_datosLeccion.Size = New Size(463, 285)
        grp_datosLeccion.TabIndex = 3
        grp_datosLeccion.TabStop = False
        grp_datosLeccion.Text = "Datos de la lección"
        '
        ' lbl_idLeccion
        '
        lbl_idLeccion.AutoSize = True
        lbl_idLeccion.Location = New Point(15, 25)
        lbl_idLeccion.Name = "lbl_idLeccion"
        lbl_idLeccion.Size = New Size(18, 15)
        lbl_idLeccion.TabIndex = 0
        lbl_idLeccion.Text = "ID"
        lbl_idLeccion.Visible = False
        '
        ' txt_idLeccion
        '
        txt_idLeccion.Location = New Point(15, 43)
        txt_idLeccion.Name = "txt_idLeccion"
        txt_idLeccion.ReadOnly = True
        txt_idLeccion.Size = New Size(80, 23)
        txt_idLeccion.TabIndex = 1
        txt_idLeccion.TabStop = False
        txt_idLeccion.Visible = False
        '
        ' lbl_orden
        '
        lbl_orden.AutoSize = True
        lbl_orden.Location = New Point(15, 25)
        lbl_orden.Name = "lbl_orden"
        lbl_orden.Size = New Size(40, 15)
        lbl_orden.TabIndex = 2
        lbl_orden.Text = "Orden"
        '
        ' nud_orden
        '
        nud_orden.Location = New Point(15, 43)
        nud_orden.Maximum = New Decimal(New Integer() {999, 0, 0, 0})
        nud_orden.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        nud_orden.Name = "nud_orden"
        nud_orden.Size = New Size(80, 23)
        nud_orden.TabIndex = 3
        nud_orden.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        ' lbl_tituloLeccion
        '
        lbl_tituloLeccion.AutoSize = True
        lbl_tituloLeccion.Location = New Point(15, 75)
        lbl_tituloLeccion.Name = "lbl_tituloLeccion"
        lbl_tituloLeccion.Size = New Size(37, 15)
        lbl_tituloLeccion.TabIndex = 4
        lbl_tituloLeccion.Text = "Título"
        '
        ' txt_tituloLeccion
        '
        txt_tituloLeccion.Location = New Point(15, 93)
        txt_tituloLeccion.MaxLength = 150
        txt_tituloLeccion.Name = "txt_tituloLeccion"
        txt_tituloLeccion.Size = New Size(433, 23)
        txt_tituloLeccion.TabIndex = 5
        '
        ' lbl_contenido
        '
        lbl_contenido.AutoSize = True
        lbl_contenido.Location = New Point(15, 125)
        lbl_contenido.Name = "lbl_contenido"
        lbl_contenido.Size = New Size(62, 15)
        lbl_contenido.TabIndex = 6
        lbl_contenido.Text = "Contenido"
        '
        ' txt_contenido
        '
        txt_contenido.Location = New Point(15, 143)
        txt_contenido.Multiline = True
        txt_contenido.Name = "txt_contenido"
        txt_contenido.ScrollBars = ScrollBars.Vertical
        txt_contenido.Size = New Size(433, 90)
        txt_contenido.TabIndex = 7
        '
        ' btn_limpiar
        '
        btn_limpiar.Location = New Point(15, 243)
        btn_limpiar.Name = "btn_limpiar"
        btn_limpiar.Size = New Size(100, 30)
        btn_limpiar.TabIndex = 8
        btn_limpiar.Text = "Limpiar"
        btn_limpiar.UseVisualStyleBackColor = True
        '
        ' btn_agregar
        '
        btn_agregar.Location = New Point(125, 243)
        btn_agregar.Name = "btn_agregar"
        btn_agregar.Size = New Size(100, 30)
        btn_agregar.TabIndex = 9
        btn_agregar.Text = "Agregar"
        btn_agregar.UseVisualStyleBackColor = True
        '
        ' btn_modificar
        '
        btn_modificar.Location = New Point(235, 243)
        btn_modificar.Name = "btn_modificar"
        btn_modificar.Size = New Size(100, 30)
        btn_modificar.TabIndex = 10
        btn_modificar.Text = "Modificar"
        btn_modificar.UseVisualStyleBackColor = True
        '
        ' btn_eliminar
        '
        btn_eliminar.Location = New Point(345, 243)
        btn_eliminar.Name = "btn_eliminar"
        btn_eliminar.Size = New Size(103, 30)
        btn_eliminar.TabIndex = 11
        btn_eliminar.Text = "Eliminar"
        btn_eliminar.UseVisualStyleBackColor = True
        '
        ' grp_imagenes
        '
        grp_imagenes.Controls.Add(btn_quitarImagen)
        grp_imagenes.Controls.Add(btn_agregarImagen)
        grp_imagenes.Controls.Add(pic_imagen)
        grp_imagenes.Controls.Add(lst_imagenes)
        grp_imagenes.Location = New Point(425, 345)
        grp_imagenes.Name = "grp_imagenes"
        grp_imagenes.Size = New Size(463, 240)
        grp_imagenes.TabIndex = 4
        grp_imagenes.TabStop = False
        grp_imagenes.Text = "Imágenes de la lección"
        '
        ' lst_imagenes
        '
        lst_imagenes.FormattingEnabled = True
        lst_imagenes.IntegralHeight = False
        lst_imagenes.Location = New Point(15, 25)
        lst_imagenes.Name = "lst_imagenes"
        lst_imagenes.Size = New Size(205, 160)
        lst_imagenes.TabIndex = 0
        '
        ' pic_imagen
        '
        pic_imagen.BorderStyle = BorderStyle.FixedSingle
        pic_imagen.Location = New Point(230, 25)
        pic_imagen.Name = "pic_imagen"
        pic_imagen.Size = New Size(218, 160)
        pic_imagen.SizeMode = PictureBoxSizeMode.Zoom
        pic_imagen.TabIndex = 1
        pic_imagen.TabStop = False
        '
        ' btn_agregarImagen
        '
        btn_agregarImagen.Location = New Point(15, 195)
        btn_agregarImagen.Name = "btn_agregarImagen"
        btn_agregarImagen.Size = New Size(205, 30)
        btn_agregarImagen.TabIndex = 2
        btn_agregarImagen.Text = "Agregar imagen"
        btn_agregarImagen.UseVisualStyleBackColor = True
        '
        ' btn_quitarImagen
        '
        btn_quitarImagen.Location = New Point(230, 195)
        btn_quitarImagen.Name = "btn_quitarImagen"
        btn_quitarImagen.Size = New Size(150, 30)
        btn_quitarImagen.TabIndex = 3
        btn_quitarImagen.Text = "Quitar imagen"
        btn_quitarImagen.UseVisualStyleBackColor = True
        '
        ' lecciones
        '
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(900, 600)
        Controls.Add(grp_imagenes)
        Controls.Add(grp_datosLeccion)
        Controls.Add(dgv_lecciones)
        Controls.Add(btn_volver)
        Controls.Add(lbl_tituloLecciones)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "lecciones"
        StartPosition = FormStartPosition.CenterParent
        Text = "Lecciones"
        CType(dgv_lecciones, ComponentModel.ISupportInitialize).EndInit()
        grp_datosLeccion.ResumeLayout(False)
        grp_datosLeccion.PerformLayout()
        CType(nud_orden, ComponentModel.ISupportInitialize).EndInit()
        grp_imagenes.ResumeLayout(False)
        CType(pic_imagen, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents lbl_tituloLecciones As Label
    Friend WithEvents btn_volver As Button
    Friend WithEvents dgv_lecciones As DataGridView
    Friend WithEvents grp_datosLeccion As GroupBox
    Friend WithEvents lbl_idLeccion As Label
    Friend WithEvents txt_idLeccion As TextBox
    Friend WithEvents lbl_orden As Label
    Friend WithEvents nud_orden As NumericUpDown
    Friend WithEvents lbl_tituloLeccion As Label
    Friend WithEvents txt_tituloLeccion As TextBox
    Friend WithEvents lbl_contenido As Label
    Friend WithEvents txt_contenido As TextBox
    Friend WithEvents btn_limpiar As Button
    Friend WithEvents btn_agregar As Button
    Friend WithEvents btn_modificar As Button
    Friend WithEvents btn_eliminar As Button
    Friend WithEvents grp_imagenes As GroupBox
    Friend WithEvents lst_imagenes As ListBox
    Friend WithEvents pic_imagen As PictureBox
    Friend WithEvents btn_agregarImagen As Button
    Friend WithEvents btn_quitarImagen As Button

End Class
