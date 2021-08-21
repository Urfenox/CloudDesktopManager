Imports System.IO.Compression
Imports Microsoft.Win32
Public Class Main
    Dim DIRCommons As String = "C:\Users\" & Environment.UserName & "\AppData\Local\CRZ_Labs\CloudDesktopManager"

    Dim LocalSyncThread As Threading.Thread
    Dim RemoteSyncThread As Threading.Thread
    Dim LocalSyncThreadStatus As Boolean = False
    Dim RemoteSyncThreadStatus As Boolean = False
    Dim IsAutoSync As Boolean = False

    Dim RutaNube As String
    Dim RutaLocal As String

    Dim fileSkip As New ArrayList
    Dim folderSkip As New ArrayList

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveSkipFiles()
        SaveSkipFolder()
        End
    End Sub

    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckForIllegalCrossThreadCalls = False
        CommonLoad()
    End Sub

    Sub CommonLoad()
        If My.Computer.FileSystem.DirectoryExists(DIRCommons) = False Then
            My.Computer.FileSystem.CreateDirectory(DIRCommons)
        End If
        If My.Computer.FileSystem.FileExists(DIRCommons & "\fileSkip.lst") Then
            ReadSkipFiles()
        End If
        If My.Computer.FileSystem.FileExists(DIRCommons & "\folderSkip.lst") Then
            ReadSkipFolder()
        End If
        ReadConfig()
    End Sub

#Region "Objetos, controles"
    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        Try
            If tbRutaRemota.Text = Nothing Or tbRutaLocal.Text = Nothing Or nudSyncTime.Value = 0 Then
                MsgBox("Rellene con la informacion solicitada", MsgBoxStyle.Critical, "Datos vacios")
            Else
                RutaNube = tbRutaRemota.Text
                RutaLocal = tbRutaLocal.Text

                SaveConfig()

                If My.Computer.FileSystem.DirectoryExists(RutaLocal) = False Then
                    My.Computer.FileSystem.CreateDirectory(RutaLocal)
                End If
                If My.Computer.FileSystem.DirectoryExists(RutaNube) = False Then
                    My.Computer.FileSystem.CreateDirectory(RutaNube)
                End If

                If LocalSyncThreadStatus = False Then
                    LocalSyncThread = New Threading.Thread(AddressOf GetLocalFilesAndFolders)
                    LocalSyncThread.Start()
                    LocalSyncThreadStatus = True
                End If
                If RemoteSyncThreadStatus = False Then
                    RemoteSyncThread = New Threading.Thread(AddressOf GetNubeFilesAndFolders)
                    RemoteSyncThread.Start()
                    RemoteSyncThreadStatus = True
                End If

                btnStart.Enabled = False
            End If
        Catch ex As Exception
            AddToLog("[btnStart_Click@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub AddToLog(ByVal from As String, ByVal content As String, Optional ByVal flag As Boolean = False)
        Try
            Dim finalContent As String
            If flag = True Then
                finalContent = "[!!!]" & content
            Else
                finalContent = content
            End If
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss tt dd/MM/yyyy ") & from & " " & finalContent)
            ShowNotify(1000, "O-Onichan, A-algo ha fallado A///W///A", content, ToolTipIcon.Error)
        Catch ex As Exception
            Console.WriteLine("[AddToLog@Main]Error: " & ex.Message)
        End Try
    End Sub

    Sub ShowNotify(ByVal timeout As Integer, ByVal title As String, ByVal text As String, ByVal icon As ToolTipIcon)
        If cbShowNotify.Checked = True Then
            TrayIcon.ShowBalloonTip(1000, title, text, icon)
        End If
    End Sub

    Private Sub Main_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Select Case WindowState
            Case FormWindowState.Minimized
                Me.Hide()
        End Select
    End Sub
    Private Sub TrayIcon_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles TrayIcon.MouseDoubleClick
        Me.Show()
        Me.Focus()
        Me.CenterToScreen()
    End Sub
    Private Sub btnVerOmitidoFichero_Click(sender As Object, e As EventArgs) Handles btnVerOmitidoFichero.Click
        Process.Start("notepad.exe", DIRCommons & "\fileSkip.lst")
    End Sub
    Private Sub btnVerOmitidoCarpeta_Click(sender As Object, e As EventArgs) Handles btnVerOmitidoCarpeta.Click
        Process.Start("notepad.exe", DIRCommons & "\folderSkip.lst")
    End Sub
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            btnStart.Text = "Comenzar"
            Label3.Enabled = True
            nudSyncTime.Enabled = True
            IsAutoSync = True
        Else
            btnStart.Text = "Sincronizar"
            Label3.Enabled = False
            nudSyncTime.Enabled = False
            IsAutoSync = False
        End If
    End Sub
#End Region

#Region "RemoteSync"
    Sub GetNubeFilesAndFolders()
        Try
            Dim syncCounter As Integer = 0
            While True
                For Each item As String In My.Computer.FileSystem.GetFiles(RutaNube)
                    If item.Contains("desktop.ini") = False Then
                        Dim FileName As String = IO.Path.GetFileNameWithoutExtension(item)
                        If My.Computer.FileSystem.FileExists(RutaLocal & "\" & FileName & ".lnk") = False Then
                            syncCounter += 1
                            CreateFileLNKRemoto(item)
                        End If
                    End If
                Next 'Funciona.

                For Each item As String In My.Computer.FileSystem.GetDirectories(RutaNube)
                    Dim FolderName As String = item
                    FolderName = FolderName.Remove(0, FolderName.LastIndexOf("\") + 1)
                    If My.Computer.FileSystem.FileExists(RutaLocal & "\" & FolderName & ".lnk") = False Then
                        syncCounter += 1
                        CreateFolderLNKRemoto(item)
                    End If
                Next 'Funciona.
                If IsAutoSync = True Then
                    If syncCounter <> 0 Then
                        ShowNotify(1000, "Se ha sincronizado", "Sincronizados a local " & syncCounter & " Archivos/Carpetas", ToolTipIcon.Info)
                    End If
                    Threading.Thread.Sleep(Val(nudSyncTime.Value & "000")) 'ESPERAR
                Else
                    syncCounter = 0
                    Exit While
                End If
                syncCounter = 0
            End While
            RemoteSyncThread.Abort()
        Catch ex As Exception
            btnStart.Enabled = True
            RemoteSyncThreadStatus = False
            AddToLog("[GetNubeFilesAndFolders@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub 'Pass 21/08/2021

    Sub CreateFileLNKRemoto(ByVal item As String)
        Try
            Dim WSHShell As Object = CreateObject("WScript.Shell")
            Dim Shortcut As Object
            Dim fileName As String = IO.Path.GetFileName(item)
            Dim filePath As String = IO.Path.GetDirectoryName(item)
            Dim fileNameNoExt As String = IO.Path.GetFileNameWithoutExtension(fileName)
            Shortcut = WSHShell.CreateShortcut(RutaLocal & "\" & fileNameNoExt & ".lnk")
            Shortcut.TargetPath = RutaNube & "\" & fileName
            Shortcut.Save()
        Catch ex As Exception
            AddToLog("[CreateFileLNK@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub CreateFolderLNKRemoto(ByVal item As String)
        Try
            Dim WSHShell As Object = CreateObject("WScript.Shell")
            Dim Shortcut As Object
            Dim FolderName As String = item
            FolderName = FolderName.Remove(0, FolderName.LastIndexOf("\") + 1)
            Shortcut = WSHShell.CreateShortcut(RutaLocal & "\" & FolderName & ".lnk")
            Shortcut.TargetPath = RutaNube & "\" & FolderName
            Shortcut.Save()
        Catch ex As Exception
            AddToLog("[CreateFolderLNK@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
#End Region

#Region "LocalSync"
    Sub GetLocalFilesAndFolders()
        Try
            Dim syncCounter As Integer = 0
            While True
                For Each item As String In My.Computer.FileSystem.GetFiles(RutaLocal)
                    If item.Contains("desktop.ini") = False Then
                        If item.Contains(".lnk") = False Then
                            Dim FileName As String = IO.Path.GetFileName(item)
                            Dim result = fileSkip.ToArray().Any(Function(x) x.ToString().Contains(FileName))
                            If result = False Then
                                syncCounter += 1
                                My.Computer.FileSystem.MoveFile(RutaLocal & "\" & FileName, RutaNube & "\" & FileName, True)
                                CreateFileLNKLocal(item)
                            End If
                        End If
                    End If
                Next 'Funciona.

                For Each item As String In My.Computer.FileSystem.GetDirectories(RutaLocal)
                    Dim FolderName As String = item
                    FolderName = FolderName.Remove(0, FolderName.LastIndexOf("\") + 1)
                    Dim result = folderSkip.ToArray().Any(Function(x) x.ToString().Contains(FolderName))
                    If result = False Then
                        syncCounter += 1
                        My.Computer.FileSystem.MoveDirectory(item, RutaNube & "\" & FolderName, True)
                        CreateFolderLNKLocal(item)
                    End If
                Next 'Funciona.
                If IsAutoSync = True Then
                    If syncCounter <> 0 Then
                        ShowNotify(1000, "Se ha sincronizado", "Sincronizados a la nube " & syncCounter & " Archivos/Carpetas", ToolTipIcon.Info)
                    End If
                    Threading.Thread.Sleep(Val(nudSyncTime.Value & "000")) 'ESPERAR
                Else
                    syncCounter = 0
                    Exit While
                End If
                syncCounter = 0
            End While
            LocalSyncThread.Abort()
        Catch ex As Exception
            btnStart.Enabled = True
            LocalSyncThreadStatus = True
            AddToLog("[GetLocalFilesAndFolders@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub 'Pass 21/08/2021

    Sub CreateFileLNKLocal(ByVal item As String)
        Try
            Dim WSHShell As Object = CreateObject("WScript.Shell")
            Dim Shortcut As Object
            Dim fileName As String = IO.Path.GetFileName(item)
            Dim filePath As String = IO.Path.GetDirectoryName(item)
            Dim fileNameNoExt As String = IO.Path.GetFileNameWithoutExtension(fileName)
            Shortcut = WSHShell.CreateShortcut(RutaLocal & "\" & fileNameNoExt & ".lnk")
            Shortcut.TargetPath = RutaNube & "\" & fileName
            Shortcut.Save()
        Catch ex As Exception
            AddToLog("[CreateFileLNK@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub CreateFolderLNKLocal(ByVal item As String)
        Try
            Dim WSHShell As Object = CreateObject("WScript.Shell")
            Dim Shortcut As Object
            Dim FolderName As String = item
            FolderName = FolderName.Remove(0, FolderName.LastIndexOf("\") + 1)
            Shortcut = WSHShell.CreateShortcut(RutaLocal & "\" & FolderName & ".lnk")
            Shortcut.TargetPath = RutaNube & "\" & FolderName
            Shortcut.Save()
        Catch ex As Exception
            AddToLog("[CreateFolderLNK@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
#End Region
    Sub SaveConfig()
        Try
            Dim RutaBaseDatos As String = "SOFTWARE\\CRZ Labs\\CloudDesktopManager"
            Dim BaseDataRegeditWriter As RegistryKey
            BaseDataRegeditWriter = Registry.CurrentUser.OpenSubKey(RutaBaseDatos, True)
            If BaseDataRegeditWriter Is Nothing Then
                Registry.CurrentUser.CreateSubKey(RutaBaseDatos)
                BaseDataRegeditWriter = Registry.CurrentUser.OpenSubKey(RutaBaseDatos, True)
            End If

            BaseDataRegeditWriter.SetValue("Ruta_Nube", RutaNube, RegistryValueKind.String)
            BaseDataRegeditWriter.SetValue("Ruta_Local", RutaLocal, RegistryValueKind.String)
            BaseDataRegeditWriter.SetValue("SyncTimer", nudSyncTime.Value, RegistryValueKind.String)
            BaseDataRegeditWriter.SetValue("AutoSync", CheckBox1.Checked, RegistryValueKind.String)
            BaseDataRegeditWriter.SetValue("ShowNotify", cbShowNotify.Checked, RegistryValueKind.String)

            ReadConfig()
        Catch ex As Exception
            AddToLog("[SaveConfigFile@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub ReadConfig()
        Try
            Dim RutaBaseDatos As String = "SOFTWARE\\CRZ Labs\\CloudDesktopManager"
            Dim BaseDataRegeditReader As RegistryKey
            BaseDataRegeditReader = Registry.CurrentUser.OpenSubKey(RutaBaseDatos, True)
            If BaseDataRegeditReader Is Nothing Then
                Registry.CurrentUser.CreateSubKey(RutaBaseDatos)
                BaseDataRegeditReader = Registry.CurrentUser.OpenSubKey(RutaBaseDatos, True)
                Exit Sub
            End If

            RutaNube = BaseDataRegeditReader.GetValue("Ruta_Nube")
            RutaLocal = BaseDataRegeditReader.GetValue("Ruta_Local")

            tbRutaRemota.Text = RutaNube
            tbRutaLocal.Text = RutaLocal
            nudSyncTime.Value = BaseDataRegeditReader.GetValue("SyncTimer")
            CheckBox1.Checked = Boolean.Parse(BaseDataRegeditReader.GetValue("AutoSync"))
            cbShowNotify.Checked = Boolean.Parse(BaseDataRegeditReader.GetValue("ShowNotify"))

        Catch ex As Exception
            AddToLog("[ReadConfigFile@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
#Region "App Config Files"
    Private Sub btnConfigFile_Click(sender As Object, e As EventArgs) Handles btnConfigFile.Click
        If MessageBox.Show("¿Quiere importar un Archivo de Configuracion?" & vbCrLf & "Si quiere explorar, clic en 'No'", "Config file", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            'Si (importar)
            Dim OpenFile As New OpenFileDialog
            OpenFile.Title = "Abrir archivo..."
            OpenFile.Filter = "ZIP File(*.zip)|*.zip|All file types(*.*)|*.*"
            If OpenFile.ShowDialog() = DialogResult.OK Then
                LoadConfigFile(OpenFile.FileName)
            End If
        Else
            'No (exportar)
            Dim SaveFile As New SaveFileDialog
            SaveFile.Title = "Guardar archivo..."
            SaveFile.Filter = "ZIP File(*.zip)|*.zip|All file types(*.*)|*.*"
            If SaveFile.ShowDialog() = DialogResult.OK Then
                SaveConfigFile(SaveFile.FileName)
            End If
        End If
    End Sub
    Sub SaveConfigFile(ByVal filePath As String)
        Try
            If My.Computer.FileSystem.FileExists(filePath) = True Then
                My.Computer.FileSystem.DeleteFile(filePath)
            End If
            My.Computer.FileSystem.WriteAllText(DIRCommons & "\Config.cfg", "# CloudDesktopManager Config" &
                                                vbCrLf & RutaNube & 'Ruta_Nube
                                                vbCrLf & RutaLocal & 'Ruta_Local
                                                vbCrLf & nudSyncTime.Value & 'SyncTimer
                                                vbCrLf & CheckBox1.Checked & 'AutoSync
                                                vbCrLf & cbShowNotify.Checked, False)
            ZipFile.CreateFromDirectory(DIRCommons, filePath)
            MsgBox("Se ha creado el archivo de configuracion correctamente", MsgBoxStyle.Information, "Archivo de Configuracion")
        Catch ex As Exception
            MsgBox("No se logro crear el archivo de configuracion", MsgBoxStyle.Critical, "Archivo de Configuracion")
            AddToLog("[SaveConfigFile@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub LoadConfigFile(ByVal filePath As String)
        Try
            ZipFile.ExtractToDirectory(filePath, DIRCommons)
            Dim lineas = IO.File.ReadLines(DIRCommons & "\Config.cfg")
            RutaNube = lineas(1)
            RutaLocal = lineas(2)
            nudSyncTime.Value = lineas(3)
            CheckBox1.Checked = Boolean.Parse(lineas(4))
            cbShowNotify.Checked = Boolean.Parse(lineas(5))
            SaveConfig()
            MsgBox("Se ha leido el archivo de configuracion correctamente" & vbCrLf & "Vuelva a iniciar el programa", MsgBoxStyle.Information, "Archivo de Configuracion")
            End
        Catch ex As Exception
            MsgBox("No se logro entender el archivo de configuracion", MsgBoxStyle.Critical, "Archivo de Configuracion")
            AddToLog("[LoadConfigFile@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub

    Private Sub btnSkipFiles_Click(sender As Object, e As EventArgs) Handles btnOmitirFichero.Click
        Dim OpenFile As New OpenFileDialog
        OpenFile.Title = "Abrir archivo..."
        OpenFile.Filter = "All file types(*.*)|*.*"
        OpenFile.Multiselect = True
        OpenFile.InitialDirectory = RutaLocal
        If OpenFile.ShowDialog() = DialogResult.OK Then
            For Each item As String In OpenFile.FileNames
                Dim FileName As String = IO.Path.GetFileName(item)
                fileSkip.Add(FileName)
            Next
            SaveSkipFiles()
        End If
    End Sub
    Sub SaveSkipFiles()
        Try
            Dim fileSkipPath As String = DIRCommons & "\fileSkip.lst"
            If My.Computer.FileSystem.FileExists(fileSkipPath) = True Then
                My.Computer.FileSystem.DeleteFile(fileSkipPath)
            End If
            My.Computer.FileSystem.WriteAllText(fileSkipPath, "desktop.ini", False)
            For Each skipFile As String In fileSkip
                If skipFile <> "desktop.ini" Then
                    My.Computer.FileSystem.WriteAllText(fileSkipPath, vbCrLf & skipFile, True)
                End If
            Next
            ReadSkipFiles()
        Catch ex As Exception
            AddToLog("[SaveSkipFiles@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub ReadSkipFiles()
        Try
            fileSkip.Clear()
            Dim fileSkipPath As String = DIRCommons & "\fileSkip.lst"
            fileSkip.Add("desktop.ini")
            For Each item As String In IO.File.ReadLines(fileSkipPath)
                If item <> "desktop.ini" Then
                    fileSkip.Add(item)
                End If
            Next
        Catch ex As Exception
            AddToLog("[ReadSkipFiles@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub

    Private Sub btnSkipFolders_Click(sender As Object, e As EventArgs) Handles btnOmitirCarpeta.Click
        Dim FolderSelect As New FolderBrowserDialog
        FolderSelect.Description = "Seleccione un directorio para agregarlo a la lista de omitidos"
        FolderSelect.SelectedPath = RutaLocal
        If FolderSelect.ShowDialog() = DialogResult.OK Then
            Dim FolderName As String = FolderSelect.SelectedPath
            FolderName = FolderName.Remove(0, FolderName.LastIndexOf("\") + 1)
            folderSkip.Add(FolderName)
            SaveSkipFolder()
        End If
    End Sub
    Sub SaveSkipFolder()
        Try
            Dim folderSkipPath As String = DIRCommons & "\folderSkip.lst"
            If My.Computer.FileSystem.FileExists(folderSkipPath) Then
                My.Computer.FileSystem.DeleteFile(folderSkipPath)
            End If
            My.Computer.FileSystem.WriteAllText(folderSkipPath, "My Shared Folder", False)
            For Each skipFolder As String In folderSkip
                If skipFolder <> "My Shared Folder" Then
                    My.Computer.FileSystem.WriteAllText(folderSkipPath, vbCrLf & skipFolder, True)
                End If
            Next
            ReadSkipFolder()
        Catch ex As Exception
            AddToLog("[SaveSkipFolder@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub ReadSkipFolder()
        Try
            folderSkip.Clear()
            Dim folderSkipPath As String = DIRCommons & "\folderSkip.lst"
            For Each item As String In IO.File.ReadLines(folderSkipPath)
                If item <> "My Shared Folder" Then
                    folderSkip.Add(item)
                End If
            Next
        Catch ex As Exception
            AddToLog("[ReadSkipFolder@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
#End Region
End Class