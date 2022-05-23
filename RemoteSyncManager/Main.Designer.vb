<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Main
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnCargar = New System.Windows.Forms.Button()
        Me.cbShowNotify = New System.Windows.Forms.CheckBox()
        Me.btnConfigFile = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbRutaLocal = New System.Windows.Forms.TextBox()
        Me.tbPassword = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbUser = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbRutaRemota = New System.Windows.Forms.TextBox()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCargar)
        Me.GroupBox1.Controls.Add(Me.cbShowNotify)
        Me.GroupBox1.Controls.Add(Me.btnConfigFile)
        Me.GroupBox1.Controls.Add(Me.btnGuardar)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.tbRutaLocal)
        Me.GroupBox1.Controls.Add(Me.tbPassword)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.tbUser)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.tbRutaRemota)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 60)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(547, 361)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sincronización"
        '
        'btnCargar
        '
        Me.btnCargar.Location = New System.Drawing.Point(277, 268)
        Me.btnCargar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnCargar.Name = "btnCargar"
        Me.btnCargar.Size = New System.Drawing.Size(148, 50)
        Me.btnCargar.TabIndex = 16
        Me.btnCargar.Text = "Cargar"
        Me.btnCargar.UseVisualStyleBackColor = True
        '
        'cbShowNotify
        '
        Me.cbShowNotify.AutoSize = True
        Me.cbShowNotify.Location = New System.Drawing.Point(12, 184)
        Me.cbShowNotify.Margin = New System.Windows.Forms.Padding(4)
        Me.cbShowNotify.Name = "cbShowNotify"
        Me.cbShowNotify.Size = New System.Drawing.Size(168, 21)
        Me.cbShowNotify.TabIndex = 14
        Me.cbShowNotify.Text = "Mostrar notificaciones"
        Me.cbShowNotify.UseVisualStyleBackColor = True
        '
        'btnConfigFile
        '
        Me.btnConfigFile.Location = New System.Drawing.Point(171, 326)
        Me.btnConfigFile.Margin = New System.Windows.Forms.Padding(4)
        Me.btnConfigFile.Name = "btnConfigFile"
        Me.btnConfigFile.Size = New System.Drawing.Size(204, 28)
        Me.btnConfigFile.TabIndex = 11
        Me.btnConfigFile.Text = "Archivo de Configuración"
        Me.btnConfigFile.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(121, 268)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(148, 50)
        Me.btnGuardar.TabIndex = 10
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 123)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Ruta local"
        '
        'tbRutaLocal
        '
        Me.tbRutaLocal.Location = New System.Drawing.Point(19, 144)
        Me.tbRutaLocal.Margin = New System.Windows.Forms.Padding(4)
        Me.tbRutaLocal.Name = "tbRutaLocal"
        Me.tbRutaLocal.Size = New System.Drawing.Size(509, 22)
        Me.tbRutaLocal.TabIndex = 9
        '
        'tbPassword
        '
        Me.tbPassword.Location = New System.Drawing.Point(361, 84)
        Me.tbPassword.Name = "tbPassword"
        Me.tbPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.tbPassword.Size = New System.Drawing.Size(167, 22)
        Me.tbPassword.TabIndex = 7
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(266, 87)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Contraseña: "
        '
        'tbUser
        '
        Me.tbUser.Location = New System.Drawing.Point(87, 84)
        Me.tbUser.Name = "tbUser"
        Me.tbUser.Size = New System.Drawing.Size(167, 22)
        Me.tbUser.TabIndex = 5
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Usuario: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Ruta nube"
        '
        'tbRutaRemota
        '
        Me.tbRutaRemota.Location = New System.Drawing.Point(19, 55)
        Me.tbRutaRemota.Margin = New System.Windows.Forms.Padding(4)
        Me.tbRutaRemota.Name = "tbRutaRemota"
        Me.tbRutaRemota.Size = New System.Drawing.Size(509, 22)
        Me.tbRutaRemota.TabIndex = 3
        '
        'TrayIcon
        '
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        Me.TrayIcon.Text = "RemoteSyncManager"
        Me.TrayIcon.Visible = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(579, 567)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Remote Sync Folder Manager"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbRutaRemota As TextBox
    Friend WithEvents tbPassword As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents tbUser As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tbRutaLocal As TextBox
    Friend WithEvents btnConfigFile As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents cbShowNotify As CheckBox
    Friend WithEvents TrayIcon As NotifyIcon
    Friend WithEvents ToolTips As ToolTip
    Friend WithEvents btnCargar As Button
End Class
