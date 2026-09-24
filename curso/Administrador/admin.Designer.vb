<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class admin
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
        lbl_rol = New Label()
        SuspendLayout()
        '
        ' lbl_rol
        '
        lbl_rol.Font = New Font("Cambria", 16F)
        lbl_rol.Location = New Point(0, 0)
        lbl_rol.Name = "lbl_rol"
        lbl_rol.Size = New Size(400, 300)
        lbl_rol.TabIndex = 0
        lbl_rol.Text = "Panel del Administrador"
        lbl_rol.TextAlign = ContentAlignment.MiddleCenter
        '
        ' admin
        '
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(400, 300)
        Controls.Add(lbl_rol)
        Name = "admin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Administrador"
        ResumeLayout(False)
    End Sub

    Friend WithEvents lbl_rol As Label

End Class
