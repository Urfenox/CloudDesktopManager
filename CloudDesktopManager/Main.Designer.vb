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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.tbRutaRemota = New System.Windows.Forms.TextBox()
        Me.tbRutaLocal = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnStart = New System.Windows.Forms.Button()
        Me.btnConfigFile = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnVerOmitidoExtencion = New System.Windows.Forms.Button()
        Me.btnOmitirExtencion = New System.Windows.Forms.Button()
        Me.btnVerOmitidoCarpeta = New System.Windows.Forms.Button()
        Me.btnVerOmitidoFichero = New System.Windows.Forms.Button()
        Me.btnOmitirCarpeta = New System.Windows.Forms.Button()
        Me.btnOmitirFichero = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.cbAskForLocals = New System.Windows.Forms.CheckBox()
        Me.cbShowNotify = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.nudSyncTime = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.btnSaveConfig = New System.Windows.Forms.Button()
        Me.btnLoadConfig = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudSyncTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 34)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 17)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ruta nube"
        '
        'tbRutaRemota
        '
        Me.tbRutaRemota.Location = New System.Drawing.Point(19, 54)
        Me.tbRutaRemota.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbRutaRemota.Name = "tbRutaRemota"
        Me.tbRutaRemota.Size = New System.Drawing.Size(509, 22)
        Me.tbRutaRemota.TabIndex = 1
        Me.ToolTips.SetToolTip(Me.tbRutaRemota, "Ruta de la carpeta sincronizada con la nube.")
        '
        'tbRutaLocal
        '
        Me.tbRutaLocal.Location = New System.Drawing.Point(19, 118)
        Me.tbRutaLocal.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.tbRutaLocal.Name = "tbRutaLocal"
        Me.tbRutaLocal.Size = New System.Drawing.Size(509, 22)
        Me.tbRutaLocal.TabIndex = 2
        Me.ToolTips.SetToolTip(Me.tbRutaLocal, "Ruta local que se sincronizara con la ruta en la nube.")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 98)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 17)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ruta local"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(185, 267)
        Me.btnStart.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(176, 50)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Sincronizar"
        Me.ToolTips.SetToolTip(Me.btnStart, "Comienza la sincronización.")
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnConfigFile
        '
        Me.btnConfigFile.Location = New System.Drawing.Point(172, 325)
        Me.btnConfigFile.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnConfigFile.Name = "btnConfigFile"
        Me.btnConfigFile.Size = New System.Drawing.Size(204, 28)
        Me.btnConfigFile.TabIndex = 6
        Me.btnConfigFile.Text = "Archivo de Configuración"
        Me.ToolTips.SetToolTip(Me.btnConfigFile, "Importa o exporta el archivo de configuración desde o para otra computadora.")
        Me.btnConfigFile.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnVerOmitidoExtencion)
        Me.GroupBox1.Controls.Add(Me.btnOmitirExtencion)
        Me.GroupBox1.Controls.Add(Me.btnVerOmitidoCarpeta)
        Me.GroupBox1.Controls.Add(Me.btnVerOmitidoFichero)
        Me.GroupBox1.Controls.Add(Me.btnOmitirCarpeta)
        Me.GroupBox1.Controls.Add(Me.btnOmitirFichero)
        Me.GroupBox1.Location = New System.Drawing.Point(165, 428)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(248, 134)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Omisión"
        '
        'btnVerOmitidoExtencion
        '
        Me.btnVerOmitidoExtencion.Location = New System.Drawing.Point(176, 60)
        Me.btnVerOmitidoExtencion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnVerOmitidoExtencion.Name = "btnVerOmitidoExtencion"
        Me.btnVerOmitidoExtencion.Size = New System.Drawing.Size(43, 28)
        Me.btnVerOmitidoExtencion.TabIndex = 10
        Me.btnVerOmitidoExtencion.Text = "Ver"
        Me.ToolTips.SetToolTip(Me.btnVerOmitidoExtencion, "Ver las extensiones de archivo que están siendo omitidos.")
        Me.btnVerOmitidoExtencion.UseVisualStyleBackColor = True
        '
        'btnOmitirExtencion
        '
        Me.btnOmitirExtencion.Location = New System.Drawing.Point(31, 60)
        Me.btnOmitirExtencion.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOmitirExtencion.Name = "btnOmitirExtencion"
        Me.btnOmitirExtencion.Size = New System.Drawing.Size(137, 28)
        Me.btnOmitirExtencion.TabIndex = 9
        Me.btnOmitirExtencion.Text = "Omitir extenciones"
        Me.ToolTips.SetToolTip(Me.btnOmitirExtencion, "Evita que archivos con ciertas extensiones sean sincronizados, mantiene los en la" &
        " ruta local.")
        Me.btnOmitirExtencion.UseVisualStyleBackColor = True
        '
        'btnVerOmitidoCarpeta
        '
        Me.btnVerOmitidoCarpeta.Location = New System.Drawing.Point(176, 96)
        Me.btnVerOmitidoCarpeta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnVerOmitidoCarpeta.Name = "btnVerOmitidoCarpeta"
        Me.btnVerOmitidoCarpeta.Size = New System.Drawing.Size(43, 28)
        Me.btnVerOmitidoCarpeta.TabIndex = 12
        Me.btnVerOmitidoCarpeta.Text = "Ver"
        Me.ToolTips.SetToolTip(Me.btnVerOmitidoCarpeta, "Ver las carpetas que están siendo omitidas.")
        Me.btnVerOmitidoCarpeta.UseVisualStyleBackColor = True
        '
        'btnVerOmitidoFichero
        '
        Me.btnVerOmitidoFichero.Location = New System.Drawing.Point(176, 25)
        Me.btnVerOmitidoFichero.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnVerOmitidoFichero.Name = "btnVerOmitidoFichero"
        Me.btnVerOmitidoFichero.Size = New System.Drawing.Size(43, 28)
        Me.btnVerOmitidoFichero.TabIndex = 8
        Me.btnVerOmitidoFichero.Text = "Ver"
        Me.ToolTips.SetToolTip(Me.btnVerOmitidoFichero, "Ver los archivos que están siendo omitidos.")
        Me.btnVerOmitidoFichero.UseVisualStyleBackColor = True
        '
        'btnOmitirCarpeta
        '
        Me.btnOmitirCarpeta.Location = New System.Drawing.Point(31, 96)
        Me.btnOmitirCarpeta.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOmitirCarpeta.Name = "btnOmitirCarpeta"
        Me.btnOmitirCarpeta.Size = New System.Drawing.Size(137, 28)
        Me.btnOmitirCarpeta.TabIndex = 11
        Me.btnOmitirCarpeta.Text = "Omitir carpeta"
        Me.ToolTips.SetToolTip(Me.btnOmitirCarpeta, "Evita que carpetas sean sincronizadas, mantiene los en la ruta local.")
        Me.btnOmitirCarpeta.UseVisualStyleBackColor = True
        '
        'btnOmitirFichero
        '
        Me.btnOmitirFichero.Location = New System.Drawing.Point(31, 25)
        Me.btnOmitirFichero.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.btnOmitirFichero.Name = "btnOmitirFichero"
        Me.btnOmitirFichero.Size = New System.Drawing.Size(137, 28)
        Me.btnOmitirFichero.TabIndex = 7
        Me.btnOmitirFichero.Text = "Omitir ficheros"
        Me.ToolTips.SetToolTip(Me.btnOmitirFichero, "Evita que archivos sean sincronizados, mantiene los en la ruta local.")
        Me.btnOmitirFichero.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cbAskForLocals)
        Me.GroupBox2.Controls.Add(Me.cbShowNotify)
        Me.GroupBox2.Controls.Add(Me.CheckBox1)
        Me.GroupBox2.Controls.Add(Me.nudSyncTime)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.tbRutaRemota)
        Me.GroupBox2.Controls.Add(Me.btnConfigFile)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btnStart)
        Me.GroupBox2.Controls.Add(Me.tbRutaLocal)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 60)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GroupBox2.Size = New System.Drawing.Size(547, 361)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sincronización"
        '
        'cbAskForLocals
        '
        Me.cbAskForLocals.AutoSize = True
        Me.cbAskForLocals.Location = New System.Drawing.Point(9, 207)
        Me.cbAskForLocals.Name = "cbAskForLocals"
        Me.cbAskForLocals.Size = New System.Drawing.Size(126, 17)
        Me.cbAskForLocals.TabIndex = 8
        Me.cbAskForLocals.Text = "Preguntar por locales"
        Me.ToolTips.SetToolTip(Me.cbAskForLocals, "De estar activo, se preguntara al usuario para poder sincronizar cada archivo y/o" &
        " carpeta.")
        Me.cbAskForLocals.UseVisualStyleBackColor = True
        '
        'cbShowNotify
        '
        Me.cbShowNotify.AutoSize = True
        Me.cbShowNotify.Location = New System.Drawing.Point(12, 226)
        Me.cbShowNotify.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.cbShowNotify.Name = "cbShowNotify"
        Me.cbShowNotify.Size = New System.Drawing.Size(168, 21)
        Me.cbShowNotify.TabIndex = 5
        Me.cbShowNotify.Text = "Mostrar notificaciones"
        Me.ToolTips.SetToolTip(Me.cbShowNotify, "De estar activo, se mostrarán notificaciones sobre el estado, errores y otros.")
        Me.cbShowNotify.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(12, 161)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(134, 21)
        Me.CheckBox1.TabIndex = 3
        Me.CheckBox1.Text = "Sync automático"
        Me.ToolTips.SetToolTip(Me.CheckBox1, "De estar activo, la sincronización se realizará según el tiempo indicado." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "De no " &
        "estar activo, la sincronización deberá ser manual, clicando en el botón Sincroni" &
        "zar.")
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'nudSyncTime
        '
        Me.nudSyncTime.Enabled = False
        Me.nudSyncTime.Location = New System.Drawing.Point(79, 183)
        Me.nudSyncTime.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.nudSyncTime.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.nudSyncTime.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudSyncTime.Name = "nudSyncTime"
        Me.nudSyncTime.Size = New System.Drawing.Size(91, 22)
        Me.nudSyncTime.TabIndex = 4
        Me.ToolTips.SetToolTip(Me.nudSyncTime, "Cada cuantos segundos se comprobarán cambios para la sincronización.")
        Me.nudSyncTime.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(35, 186)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(207, 17)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Cada                          segundos"
        '
        'TrayIcon
        '
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        Me.TrayIcon.Text = "CloudDesktopManager"
        Me.TrayIcon.Visible = True
        '
        'btnSaveConfig
        '
        Me.btnSaveConfig.Location = New System.Drawing.Point(12, 380)
        Me.btnSaveConfig.Name = "btnSaveConfig"
        Me.btnSaveConfig.Size = New System.Drawing.Size(90, 35)
        Me.btnSaveConfig.TabIndex = 9
        Me.btnSaveConfig.Text = "Guardar configuración"
        Me.ToolTips.SetToolTip(Me.btnSaveConfig, "Guarda la configuración")
        Me.btnSaveConfig.UseVisualStyleBackColor = True
        '
        'btnLoadConfig
        '
        Me.btnLoadConfig.Location = New System.Drawing.Point(12, 414)
        Me.btnLoadConfig.Name = "btnLoadConfig"
        Me.btnLoadConfig.Size = New System.Drawing.Size(90, 35)
        Me.btnLoadConfig.TabIndex = 10
        Me.btnLoadConfig.Text = "Cargar configuración"
        Me.ToolTips.SetToolTip(Me.btnLoadConfig, "Carga la configuración para aplicar cambios")
        Me.btnLoadConfig.UseVisualStyleBackColor = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
<<<<<<< Updated upstream
        Me.ClientSize = New System.Drawing.Size(434, 461)
        Me.Controls.Add(Me.btnLoadConfig)
        Me.Controls.Add(Me.btnSaveConfig)
=======
        Me.ClientSize = New System.Drawing.Size(579, 567)
>>>>>>> Stashed changes
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.Name = "Main"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cloud Folder Manager"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudSyncTime, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tbRutaRemota As TextBox
    Friend WithEvents tbRutaLocal As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents btnStart As Button
    Friend WithEvents btnConfigFile As Button
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnOmitirCarpeta As Button
    Friend WithEvents btnOmitirFichero As Button
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents nudSyncTime As NumericUpDown
    Friend WithEvents Label3 As Label
    Friend WithEvents TrayIcon As NotifyIcon
    Friend WithEvents btnVerOmitidoCarpeta As Button
    Friend WithEvents btnVerOmitidoFichero As Button
    Friend WithEvents ToolTips As ToolTip
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents cbShowNotify As CheckBox
    Friend WithEvents btnOmitirExtencion As Button
    Friend WithEvents btnVerOmitidoExtencion As Button
    Friend WithEvents cbAskForLocals As CheckBox
    Friend WithEvents btnSaveConfig As Button
    Friend WithEvents btnLoadConfig As Button
End Class
