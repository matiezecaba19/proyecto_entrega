<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class login
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
        txt_InicioSecion = New Label()
        Label2 = New Label()
        Label3 = New Label()
        LinkLabel1 = New LinkLabel()
        btn_acceder = New Button()
        txt_dni = New TextBox()
        txt_contraseña = New TextBox()
        SuspendLayout()
        ' 
        ' txt_InicioSecion
        ' 
        txt_InicioSecion.BackColor = SystemColors.ButtonFace
        txt_InicioSecion.Font = New Font("Cambria", 16F)
        txt_InicioSecion.ForeColor = SystemColors.Desktop
        txt_InicioSecion.Location = New Point(40, 30)
        txt_InicioSecion.Name = "txt_InicioSecion"
        txt_InicioSecion.Size = New Size(240, 40)
        txt_InicioSecion.TabIndex = 0
        txt_InicioSecion.Text = "Login"
        txt_InicioSecion.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Location = New Point(40, 100)
        Label2.Name = "Label2"
        Label2.Size = New Size(27, 15)
        Label2.TabIndex = 1
        Label2.Text = "DNI"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Location = New Point(40, 160)
        Label3.Name = "Label3"
        Label3.Size = New Size(67, 15)
        Label3.TabIndex = 2
        Label3.Text = "Contraseña"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.Location = New Point(58, 300)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(158, 15)
        LinkLabel1.TabIndex = 6
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "¿No tenés cuenta? Registrate"
        ' 
        ' btn_acceder
        ' 
        btn_acceder.Location = New Point(40, 245)
        btn_acceder.Name = "btn_acceder"
        btn_acceder.Size = New Size(240, 40)
        btn_acceder.TabIndex = 5
        btn_acceder.Text = "Acceder"
        btn_acceder.UseVisualStyleBackColor = True
        ' 
        ' txt_dni
        ' 
        txt_dni.Location = New Point(40, 120)
        txt_dni.MaxLength = 8
        txt_dni.Name = "txt_dni"
        txt_dni.Size = New Size(240, 23)
        txt_dni.TabIndex = 3
        ' 
        ' txt_contraseña
        ' 
        txt_contraseña.Location = New Point(40, 180)
        txt_contraseña.Name = "txt_contraseña"
        txt_contraseña.PasswordChar = "*"c
        txt_contraseña.Size = New Size(240, 23)
        txt_contraseña.TabIndex = 4
        ' 
        ' login
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(320, 360)
        Controls.Add(txt_contraseña)
        Controls.Add(txt_dni)
        Controls.Add(btn_acceder)
        Controls.Add(LinkLabel1)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(txt_InicioSecion)
        FormBorderStyle = FormBorderStyle.FixedDialog
        MaximizeBox = False
        Name = "login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txt_InicioSecion As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents btn_acceder As Button
    Friend WithEvents txt_dni As TextBox
    Friend WithEvents txt_contraseña As TextBox
End Class
