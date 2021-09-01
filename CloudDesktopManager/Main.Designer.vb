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
        Me.cbShowNotify = New System.Windows.Forms.CheckBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.nudSyncTime = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TrayIcon = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ToolTips = New System.Windows.Forms.ToolTip(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudSyncTime, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Ruta nube"
        '
        'tbRutaRemota
        '
        Me.tbRutaRemota.Location = New System.Drawing.Point(14, 44)
        Me.tbRutaRemota.Name = "tbRutaRemota"
        Me.tbRutaRemota.Size = New System.Drawing.Size(383, 20)
        Me.tbRutaRemota.TabIndex = 1
        Me.ToolTips.SetToolTip(Me.tbRutaRemota, "Ruta de la carpeta sincronizada con la nube.")
        '
        'tbRutaLocal
        '
        Me.tbRutaLocal.Location = New System.Drawing.Point(14, 96)
        Me.tbRutaLocal.Name = "tbRutaLocal"
        Me.tbRutaLocal.Size = New System.Drawing.Size(383, 20)
        Me.tbRutaLocal.TabIndex = 2
        Me.ToolTips.SetToolTip(Me.tbRutaLocal, "Ruta local que se sincronizara con la ruta en la nube.")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Ruta local"
        '
        'btnStart
        '
        Me.btnStart.Location = New System.Drawing.Point(139, 217)
        Me.btnStart.Name = "btnStart"
        Me.btnStart.Size = New System.Drawing.Size(132, 41)
        Me.btnStart.TabIndex = 0
        Me.btnStart.Text = "Sincronizar"
        Me.ToolTips.SetToolTip(Me.btnStart, "Comienza la sincronización.")
        Me.btnStart.UseVisualStyleBackColor = True
        '
        'btnConfigFile
        '
        Me.btnConfigFile.Location = New System.Drawing.Point(129, 264)
        Me.btnConfigFile.Name = "btnConfigFile"
        Me.btnConfigFile.Size = New System.Drawing.Size(153, 23)
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
        Me.GroupBox1.Location = New System.Drawing.Point(124, 348)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(186, 109)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Omisión"
        '
        'btnVerOmitidoExtencion
        '
        Me.btnVerOmitidoExtencion.Location = New System.Drawing.Point(132, 49)
        Me.btnVerOmitidoExtencion.Name = "btnVerOmitidoExtencion"
        Me.btnVerOmitidoExtencion.Size = New System.Drawing.Size(32, 23)
        Me.btnVerOmitidoExtencion.TabIndex = 10
        Me.btnVerOmitidoExtencion.Text = "Ver"
        Me.ToolTips.SetToolTip(Me.btnVerOmitidoExtencion, "Ver las extensiones de archivo que están siendo omitidos.")
        Me.btnVerOmitidoExtencion.UseVisualStyleBackColor = True
        '
        'btnOmitirExtencion
        '
        Me.btnOmitirExtencion.Location = New System.Drawing.Point(23, 49)
        Me.btnOmitirExtencion.Name = "btnOmitirExtencion"
        Me.btnOmitirExtencion.Size = New System.Drawing.Size(103, 23)
        Me.btnOmitirExtencion.TabIndex = 9
        Me.btnOmitirExtencion.Text = "Omitir extenciones"
        Me.ToolTips.SetToolTip(Me.btnOmitirExtencion, "Evita que archivos con ciertas extensiones sean sincronizados, mantiene los en la" &
        " ruta local.")
        Me.btnOmitirExtencion.UseVisualStyleBackColor = True
        '
        'btnVerOmitidoCarpeta
        '
        Me.btnVerOmitidoCarpeta.Location = New System.Drawing.Point(132, 78)
        Me.btnVerOmitidoCarpeta.Name = "btnVerOmitidoCarpeta"
        Me.btnVerOmitidoCarpeta.Size = New System.Drawing.Size(32, 23)
        Me.btnVerOmitidoCarpeta.TabIndex = 12
        Me.btnVerOmitidoCarpeta.Text = "Ver"
        Me.ToolTips.SetToolTip(Me.btnVerOmitidoCarpeta, "Ver las carpetas que están siendo omitidas.")
        Me.btnVerOmitidoCarpeta.UseVisualStyleBackColor = True
        '
        'btnVerOmitidoFichero
        '
        Me.btnVerOmitidoFichero.Location = New System.Drawing.Point(132, 20)
        Me.btnVerOmitidoFichero.Name = "btnVerOmitidoFichero"
        Me.btnVerOmitidoFichero.Size = New System.Drawing.Size(32, 23)
        Me.btnVerOmitidoFichero.TabIndex = 8
        Me.btnVerOmitidoFichero.Text = "Ver"
        Me.ToolTips.SetToolTip(Me.btnVerOmitidoFichero, "Ver los archivos que están siendo omitidos.")
        Me.btnVerOmitidoFichero.UseVisualStyleBackColor = True
        '
        'btnOmitirCarpeta
        '
        Me.btnOmitirCarpeta.Location = New System.Drawing.Point(23, 78)
        Me.btnOmitirCarpeta.Name = "btnOmitirCarpeta"
        Me.btnOmitirCarpeta.Size = New System.Drawing.Size(103, 23)
        Me.btnOmitirCarpeta.TabIndex = 11
        Me.btnOmitirCarpeta.Text = "Omitir carpeta"
        Me.ToolTips.SetToolTip(Me.btnOmitirCarpeta, "Evita que carpetas sean sincronizadas, mantiene los en la ruta local.")
        Me.btnOmitirCarpeta.UseVisualStyleBackColor = True
        '
        'btnOmitirFichero
        '
        Me.btnOmitirFichero.Location = New System.Drawing.Point(23, 20)
        Me.btnOmitirFichero.Name = "btnOmitirFichero"
        Me.btnOmitirFichero.Size = New System.Drawing.Size(103, 23)
        Me.btnOmitirFichero.TabIndex = 7
        Me.btnOmitirFichero.Text = "Omitir ficheros"
        Me.ToolTips.SetToolTip(Me.btnOmitirFichero, "Evita que archivos sean sincronizados, mantiene los en la ruta local.")
        Me.btnOmitirFichero.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
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
        Me.GroupBox2.Location = New System.Drawing.Point(12, 49)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(410, 293)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Sincronización"
        '
        'cbShowNotify
        '
        Me.cbShowNotify.AutoSize = True
        Me.cbShowNotify.Location = New System.Drawing.Point(9, 184)
        Me.cbShowNotify.Name = "cbShowNotify"
        Me.cbShowNotify.Size = New System.Drawing.Size(129, 17)
        Me.cbShowNotify.TabIndex = 5
        Me.cbShowNotify.Text = "Mostrar notificaciones"
        Me.ToolTips.SetToolTip(Me.cbShowNotify, "De estar activo, se mostrarán notificaciones sobre el estado, errores y otros.")
        Me.cbShowNotify.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(9, 131)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(105, 17)
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
        Me.nudSyncTime.Location = New System.Drawing.Point(59, 149)
        Me.nudSyncTime.Maximum = New Decimal(New Integer() {999999, 0, 0, 0})
        Me.nudSyncTime.Minimum = New Decimal(New Integer() {10, 0, 0, 0})
        Me.nudSyncTime.Name = "nudSyncTime"
        Me.nudSyncTime.Size = New System.Drawing.Size(68, 20)
        Me.nudSyncTime.TabIndex = 4
        Me.ToolTips.SetToolTip(Me.nudSyncTime, "Cada cuantos segundos se comprobarán cambios para la sincronización.")
        Me.nudSyncTime.Value = New Decimal(New Integer() {60, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Enabled = False
        Me.Label3.Location = New System.Drawing.Point(26, 151)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(156, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Cada                          segundos"
        '
        'TrayIcon
        '
        Me.TrayIcon.Icon = CType(resources.GetObject("TrayIcon.Icon"), System.Drawing.Icon)
        Me.TrayIcon.Text = "CloudDesktopManager"
        Me.TrayIcon.Visible = True
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(434, 461)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
End Class
