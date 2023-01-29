Imports System.IO.Compression
Imports Microsoft.Win32
Public Class Main
    Dim DIRCommons As String = "C:\Users\" & Environment.UserName & "\AppData\Local\CRZ_Labs\RemoteSyncManager"
    Dim dirPath As String = DIRCommons & "\Uploads"
    Dim zipFileName As String

    Dim LocalSyncThread As Threading.Thread
    Dim RemoteSyncThread As Threading.Thread
    Dim LocalSyncThreadStatus As Boolean = False
    Dim RemoteSyncThreadStatus As Boolean = False

    Dim IsAutoSync As Boolean = False
    Dim RutaNube As String
    Dim RutaLocal As String
    Dim User As String
    Dim Password As String

    Dim SaveLog As Boolean = True 'True para desarrollo, False para version final estable

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveConfig()
    End Sub
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        CommonLoad()
    End Sub

    Sub CommonLoad()
        If My.Computer.FileSystem.DirectoryExists(DIRCommons) = False Then
            My.Computer.FileSystem.CreateDirectory(DIRCommons)
        End If
        If My.Computer.FileSystem.DirectoryExists(dirPath) = False Then
            My.Computer.FileSystem.CreateDirectory(dirPath)
        End If
        'If My.Computer.FileSystem.FileExists(DIRCommons & "\fileSkip.lst") Then
        '    ReadSkipFiles()
        'End If
        'If My.Computer.FileSystem.FileExists(DIRCommons & "\folderSkip.lst") Then
        '    ReadSkipFolder()
        'End If
        'If My.Computer.FileSystem.FileExists(DIRCommons & "\extensionSkip.lst") Then
        '    ReadSkipExtension()
        'End If
        If My.Computer.FileSystem.FileExists(DIRCommons & "\Activity.log") = False Then
            My.Computer.FileSystem.WriteAllText(DIRCommons & "\Activity.log", My.Application.Info.AssemblyName & " " & My.Application.Info.Version.ToString & " (" & Application.ProductVersion & ")", False)
        End If
        ReadConfig()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If tbRutaRemota.Text = Nothing Or tbRutaLocal.Text = Nothing Then
                MsgBox("Rellene con la información solicitada", MsgBoxStyle.Critical, "Datos vacíos")
            Else
                RutaNube = tbRutaRemota.Text
                RutaLocal = tbRutaLocal.Text
                User = tbUser.Text
                Password = tbPassword.Text

                SaveConfig()

                If My.Computer.FileSystem.DirectoryExists(RutaLocal) = False Then
                    My.Computer.FileSystem.CreateDirectory(RutaLocal)
                End If

                SaveLocalToServer()

            End If
        Catch ex As Exception
            AddToLog("[btnGuardar_Click@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
    Private Sub btnCargar_Click(sender As Object, e As EventArgs) Handles btnCargar.Click
        Try
            If tbRutaRemota.Text = Nothing Or tbRutaLocal.Text = Nothing Then
                MsgBox("Rellene con la información solicitada", MsgBoxStyle.Critical, "Datos vacíos")
            Else
                RutaNube = tbRutaRemota.Text
                RutaLocal = tbRutaLocal.Text
                User = tbUser.Text
                Password = tbPassword.Text

                SaveConfig()

                If My.Computer.FileSystem.DirectoryExists(RutaLocal) = False Then
                    My.Computer.FileSystem.CreateDirectory(RutaLocal)
                End If

                LoadServerToLocal()

            End If
        Catch ex As Exception
            AddToLog("[btnCargar_Click@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub

    Private Sub btnConfigFile_Click(sender As Object, e As EventArgs) Handles btnConfigFile.Click

    End Sub

    'AVISO: Como un servidor FTP NO es un directorio comun, NO se podran ver cambios de archivos en el servidor
    ' por lo que solo se podran monitorear los archivos/carpetas locales
    ' por esta razon, la sincronizacion solo sera en una via
    ' Local a Servidor
    ' y NO Servidor a Local como se hace en CloudDesktopManager
    'Aunque si se podria hacer en busqueda de ficheros/carpetas nuevas, pero nada mas que eso.
    'Cambios solo podran ser desde Local a Servidor.

    Sub LoadServerToLocal()
        Try
            'Cuando el usuario haga click en "Cargar"
            '   1) El .ZIP en nube se descarga
            '   2) Se descomprime en la carpeta seleccionada
            '   3) Notificacion

            'Obtener la ultima carga
            Dim remoteFilePath As String = RutaNube & "/" & zipFileName & ".cph"
            Dim localFilePath As String = dirPath & "\" & zipFileName & ".zip"

            'Verificar
            If My.Computer.FileSystem.FileExists(localFilePath) = True Then
                My.Computer.FileSystem.DeleteFile(localFilePath)
            End If

            'Descargar
            My.Computer.Network.DownloadFile(remoteFilePath, localFilePath, User, Password)

            'Descomprimir
            ZipFile.ExtractToDirectory(localFilePath, RutaLocal)

        Catch ex As Exception
            AddToLog("[LoadServerToLocal@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub SaveLocalToServer()
        Try
            'Cuando el usuario haga click en "Guardar"
            '   1) La carpeta seleccionada se comprimira en un .ZIP
            '   2) El .ZIP se subira al servidor
            '   3) Notificacion
            'OJO, se debe poder identificar cual fue la ultima copia que se subio, esto para luego poder cargarla
            zipFileName = "sync_compressed_file"
            Dim localFilePath As String = dirPath & "\" & zipFileName & ".zip"
            'Verificar
            If My.Computer.FileSystem.FileExists(localFilePath) = True Then
                My.Computer.FileSystem.DeleteFile(localFilePath)
            End If

            'Comprimir
            ZipFile.CreateFromDirectory(RutaLocal, localFilePath)

            'Subir
            My.Computer.Network.UploadFile(localFilePath, RutaNube & "/" & zipFileName & ".cph", User, Password)

        Catch ex As Exception
            AddToLog("[SaveLocalToServer@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub AddToLog(ByVal from As String, ByVal content As String, Optional ByVal flag As Boolean = False)
        Try
            Dim finalContent As String
            If flag = True Then
                finalContent = "[!!!]" & content
                ShowNotify(1000, "O-Onichan, A-algo ha fallado AwA", content, ToolTipIcon.Error)
            Else
                finalContent = content
            End If
            Dim Message As String = DateTime.Now.ToString("hh:mm:ss tt dd/MM/yyyy ") & from & " " & finalContent
            Console.WriteLine(Message)
            If SaveLog = True Then
                Try
                    My.Computer.FileSystem.WriteAllText(DIRCommons & "\Activity.log", vbCrLf & Message, True)
                Catch
                End Try
            End If
        Catch ex As Exception
            Console.WriteLine("[AddToLog@Main]Error: " & ex.Message)
        End Try
    End Sub
    Sub ShowNotify(ByVal timeout As Integer, ByVal title As String, ByVal text As String, ByVal icon As ToolTipIcon)
        If cbShowNotify.Checked = True Then
            TrayIcon.ShowBalloonTip(1000, title, text, icon)
        End If
    End Sub
    Sub TrayIconStatus(ByVal icon As Icon)
        Try
            TrayIcon.Icon = icon
            Me.Icon = icon
            Me.Refresh()
        Catch ex As Exception
            AddToLog("[TrayIconStatus@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
    Private Sub Main_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Select Case WindowState
            Case FormWindowState.Minimized
                Me.Hide()
        End Select
    End Sub
    Private Sub Main_HelpRequested(sender As Object, hlpevent As HelpEventArgs) Handles Me.HelpRequested
        CommonLoad()
        Me.Refresh()
        Me.CenterToScreen()
        If MessageBox.Show("¿Quiere ir al sitio web del software?", "Ayuda", MessageBoxButtons.YesNo, MessageBoxIcon.Information) = DialogResult.Yes Then
            Process.Start("https://github.com/Urfenox/CloudDesktopManager")
        End If
    End Sub
    Private Sub TrayIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TrayIcon.MouseDoubleClick
        Me.Show()
        Me.Refresh()
        Me.Focus()
    End Sub

    Sub SaveConfig()
        Try
            Dim RutaBaseDatos As String = "SOFTWARE\\CRZ Labs\\RemoteSyncManager"
            Dim BaseDataRegeditWriter As RegistryKey
            BaseDataRegeditWriter = Registry.CurrentUser.OpenSubKey(RutaBaseDatos, True)
            If BaseDataRegeditWriter Is Nothing Then
                Registry.CurrentUser.CreateSubKey(RutaBaseDatos)
                BaseDataRegeditWriter = Registry.CurrentUser.OpenSubKey(RutaBaseDatos, True)
            End If

            BaseDataRegeditWriter.SetValue("User", User, RegistryValueKind.String)
            BaseDataRegeditWriter.SetValue("Password", Password, RegistryValueKind.String)
            BaseDataRegeditWriter.SetValue("Ruta_Nube", RutaNube, RegistryValueKind.String)
            BaseDataRegeditWriter.SetValue("Ruta_Local", RutaLocal, RegistryValueKind.String)
            BaseDataRegeditWriter.SetValue("ShowNotify", cbShowNotify.Checked, RegistryValueKind.String)

            ReadConfig()
        Catch ex As Exception
            AddToLog("[SaveConfigFile@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub ReadConfig()
        Try
            Dim RutaBaseDatos As String = "SOFTWARE\\CRZ Labs\\RemoteSyncManager"
            Dim BaseDataRegeditReader As RegistryKey
            BaseDataRegeditReader = Registry.CurrentUser.OpenSubKey(RutaBaseDatos, True)
            If BaseDataRegeditReader Is Nothing Then
                Registry.CurrentUser.CreateSubKey(RutaBaseDatos)
                BaseDataRegeditReader = Registry.CurrentUser.OpenSubKey(RutaBaseDatos, True)
                Exit Sub
            End If

            User = BaseDataRegeditReader.GetValue("User")
            Password = BaseDataRegeditReader.GetValue("Password")
            RutaNube = BaseDataRegeditReader.GetValue("Ruta_Nube")
            RutaLocal = BaseDataRegeditReader.GetValue("Ruta_Local")

            tbUser.Text = User
            tbPassword.Text = Password
            tbRutaRemota.Text = RutaNube
            tbRutaLocal.Text = RutaLocal
            cbShowNotify.Checked = Boolean.Parse(BaseDataRegeditReader.GetValue("ShowNotify"))
        Catch ex As Exception
            AddToLog("[ReadConfigFile@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
End Class