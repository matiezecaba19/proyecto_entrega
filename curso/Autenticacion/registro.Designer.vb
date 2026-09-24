<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class registro
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
        lbl_titulo = New Label()
        lbl_nombre = New Label()
        txt_nombre = New TextBox()
        lbl_apellido = New Label()
        txt_apellido = New TextBox()
        lbl_dni = New Label()
        txt_dni = New TextBox()
        lbl_email = New Label()
        txt_email = New TextBox()
        lbl_contraseña = New Label()
        txt_contraseña = New TextBox()
        lbl_confirmarContraseña = New Label()
        txt_confirmarContraseña = New TextBox()
        lbl_rol = New Label()
        cmb_rol = New ComboBox()
        btn_registrar = New Button()
        lnk_volverLogin = New LinkLabel()
        SuspendLayout()
        '
        ' lbl_titulo
        '
        lbl_titulo.Font = New Font("Cambria", 16F)
        lbl_titulo.Location = New Point(40, 20)
        lbl_titulo.Name = "lbl_titulo"
        lbl_titulo.Size = New Size(240, 40)
        lbl_titulo.TabIndex = 0
        lbl_titulo.Text = "Registro"
        lbl_titulo.TextAlign = ContentAlignment.MiddleCenter
        '
        ' lbl_nombre
        '
        lbl_nombre.AutoSize = True
        lbl_nombre.Location = New Point(40, 75)
        lbl_nombre.Name = "lbl_nombre"
        lbl_nombre.Size = New Size(53, 15)
        lbl_nombre.TabIndex = 1
        lbl_nombre.Text = "Nombre"
        '
        ' txt_nombre
        '
        txt_nombre.Location = New Point(40, 95)
        txt_nombre.MaxLength = 20
        txt_nombre.Name = "txt_nombre"
        txt_nombre.Size = New Size(240, 23)
        txt_nombre.TabIndex = 2
        '
        ' lbl_apellido
        '
        lbl_apellido.AutoSize = True
        lbl_apellido.Location = New Point(40, 130)
        lbl_apellido.Name = "lbl_apellido"
        lbl_apellido.Size = New Size(53, 15)
        lbl_apellido.TabIndex = 3
        lbl_apellido.Text = "Apellido"
        '
        ' txt_apellido
        '
        txt_apellido.Location = New Point(40, 150)
        txt_apellido.MaxLength = 20
        txt_apellido.Name = "txt_apellido"
        txt_apellido.Size = New Size(240, 23)
        txt_apellido.TabIndex = 4
        '
        ' lbl_dni
        '
        lbl_dni.AutoSize = True
        lbl_dni.Location = New Point(40, 185)
        lbl_dni.Name = "lbl_dni"
        lbl_dni.Size = New Size(29, 15)
        lbl_dni.TabIndex = 5
        lbl_dni.Text = "DNI"
        '
        ' txt_dni
        '
        txt_dni.Location = New Point(40, 205)
        txt_dni.MaxLength = 8
        txt_dni.Name = "txt_dni"
        txt_dni.Size = New Size(240, 23)
        txt_dni.TabIndex = 6
        '
        ' lbl_email
        '
        lbl_email.AutoSize = True
        lbl_email.Location = New Point(40, 240)
        lbl_email.Name = "lbl_email"
        lbl_email.Size = New Size(37, 15)
        lbl_email.TabIndex = 7
        lbl_email.Text = "Email"
        '
        ' txt_email
        '
        txt_email.Location = New Point(40, 260)
        txt_email.MaxLength = 50
        txt_email.Name = "txt_email"
        txt_email.Size = New Size(240, 23)
        txt_email.TabIndex = 8
        '
        ' lbl_contraseña
        '
        lbl_contraseña.AutoSize = True
        lbl_contraseña.Location = New Point(40, 295)
        lbl_contraseña.Name = "lbl_contraseña"
        lbl_contraseña.Size = New Size(74, 15)
        lbl_contraseña.TabIndex = 9
        lbl_contraseña.Text = "Contraseña"
        '
        ' txt_contraseña
        '
        txt_contraseña.Location = New Point(40, 315)
        txt_contraseña.Name = "txt_contraseña"
        txt_contraseña.PasswordChar = "*"c
        txt_contraseña.Size = New Size(240, 23)
        txt_contraseña.TabIndex = 10
        '
        ' lbl_confirmarContraseña
        '
        lbl_confirmarContraseña.AutoSize = True
        lbl_confirmarContraseña.Location = New Point(40, 350)
        lbl_confirmarContraseña.Name = "lbl_confirmarContraseña"
        lbl_confirmarContraseña.Size = New Size(127, 15)
        lbl_confirmarContraseña.TabIndex = 11
        lbl_confirmarContraseña.Text = "Confirmar contraseña"
        '
        ' txt_confirmarContraseña
        '
        txt_confirmarContraseña.Location = New Point(40, 370)
        txt_confirmarContraseña.Name = "txt_confirmarContraseña"
        txt_confirmarContraseña.PasswordChar = "*"c
        txt_confirmarContraseña.Size = New Size(240, 23)
        txt_confirmarContraseña.TabIndex = 12
        '
        ' lbl_rol
        '
        lbl_rol.AutoSize = True
        lbl_rol.Location = New Point(40, 405)
        lbl_rol.Name = "lbl_rol"
        lbl_rol.Size = New Size(28, 15)
        lbl_rol.TabIndex = 13
        lbl_rol.Text = "Rol"
        '
        ' cmb_rol
        '
        cmb_rol.DropDownStyle = ComboBoxStyle.DropDownList
        cmb_rol.FormattingEnabled = True
        cmb_rol.Items.AddRange(New Object() {"Alumno", "Profesor", "Cobranza"})
        cmb_rol.Location = New Point(40, 425)
        cmb_rol.Name = "cmb_rol"
        cmb_rol.Size = New Size(240, 23)
        cmb_rol.TabIndex = 14
        '
        ' btn_registrar
        '
        btn_registrar.Location = New Point(40, 465)
        btn_registrar.Name = "btn_registrar"
        btn_registrar.Size = New Size(240, 40)
        btn_registrar.TabIndex = 15
        btn_registrar.Text = "Registrarse"
        btn_registrar.UseVisualStyleBackColor = True
        '
        ' lnk_volverLogin
        '
        lnk_volverLogin.AutoSize = True
        lnk_volverLogin.Location = New Point(58, 515)
        lnk_volverLogin.Name = "lnk_volverLogin"
        lnk_volverLogin.Size = New Size(204, 15)
        lnk_volverLogin.TabIndex = 16
        lnk_volverLogin.TabStop = True
        lnk_volverLogin.Text = "¿Ya tenés cuenta? Iniciar sesión"
        '
        ' registro
        '
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(320, 560)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        StartPosition = FormStartPosition.CenterScreen
        Controls.Add(lnk_volverLogin)
        Controls.Add(btn_registrar)
        Controls.Add(cmb_rol)
        Controls.Add(lbl_rol)
        Controls.Add(txt_confirmarContraseña)
        Controls.Add(lbl_confirmarContraseña)
        Controls.Add(txt_contraseña)
        Controls.Add(lbl_contraseña)
        Controls.Add(txt_email)
        Controls.Add(lbl_email)
        Controls.Add(txt_dni)
        Controls.Add(lbl_dni)
        Controls.Add(txt_apellido)
        Controls.Add(lbl_apellido)
        Controls.Add(txt_nombre)
        Controls.Add(lbl_nombre)
        Controls.Add(lbl_titulo)
        Name = "registro"
        Text = "Registro"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lbl_titulo As Label
    Friend WithEvents lbl_nombre As Label
    Friend WithEvents txt_nombre As TextBox
    Friend WithEvents lbl_apellido As Label
    Friend WithEvents txt_apellido As TextBox
    Friend WithEvents lbl_dni As Label
    Friend WithEvents txt_dni As TextBox
    Friend WithEvents lbl_email As Label
    Friend WithEvents txt_email As TextBox
    Friend WithEvents lbl_contraseña As Label
    Friend WithEvents txt_contraseña As TextBox
    Friend WithEvents lbl_confirmarContraseña As Label
    Friend WithEvents txt_confirmarContraseña As TextBox
    Friend WithEvents lbl_rol As Label
    Friend WithEvents cmb_rol As ComboBox
    Friend WithEvents btn_registrar As Button
    Friend WithEvents lnk_volverLogin As LinkLabel

End Class
