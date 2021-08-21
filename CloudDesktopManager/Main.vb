Imports Microsoft.Win32
Public Class Main
    Dim DIRCommons As String = "C:\Users\" & Environment.UserName & "\AppData\Local\CRZ_Labs\CloudDesktopManager"

    Dim LocalSyncThread As Threading.Thread
    Dim RemoteSyncThread As Threading.Thread
    Dim LocalSyncThreadStatus As Boolean = False
    Dim RemoteSyncThreadStatus As Boolean = False

    Dim RutaNube As String
    Dim RutaLocal As String

    Dim fileSkip As New ArrayList
    Dim folderSkip As New ArrayList

    Sub AddToLog(ByVal from As String, ByVal content As String, Optional ByVal flag As Boolean = False)
        Try
            Dim finalContent As String
            If flag = True Then
                finalContent = "[!!!]" & content
            Else
                finalContent = content
            End If
            Console.WriteLine(DateTime.Now.ToString("hh:mm:ss tt dd/MM/yyyy ") & from & " " & finalContent)
        Catch ex As Exception
            Console.WriteLine("[AddToLog@Main]Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveSkipFiles()
        SaveSkipFolder()
        'seria algo bonito cerrar los threads antes de cerrar.
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

#Region "RemoteSync"
    'La idea
    '   Cuano se encuentre una archivo/carpeta en la nube se debe ver si su acceso directo en el escritorio existe
    '       Si no existe, se crea
    '       Si existe, se omite
    '           Esto se hacer asi para no ir guardando una lista
    Sub GetNubeFilesAndFolders()
        Try
            While True 'algun coso para romper esto.
                'Files
                For Each item As String In My.Computer.FileSystem.GetFiles(RutaNube)
                    'Toma el archivo, y ve si existe un acceso directo en el escritorio
                    '   Si no, lo crea
                    '   Si existe, lo omite
                    If item.Contains("desktop.ini") = False Then
                        Dim FileName As String = IO.Path.GetFileNameWithoutExtension(item)
                        If My.Computer.FileSystem.FileExists(RutaLocal & "\" & FileName & ".lnk") = False Then
                            'No existe el LNK. se debe crear
                            CreateFileLNKRemoto(item)
                        End If
                    End If
                Next 'Pass 20/08/2021 08:12 PM

                'Folders
                For Each item As String In My.Computer.FileSystem.GetDirectories(RutaNube)
                    'Toma la carpeta, y ve si existe un acceso directo en el escritorio
                    '   Si no, lo crea
                    '   Si existe, lo omite
                    Dim FolderName As String = item
                    FolderName = FolderName.Remove(0, FolderName.LastIndexOf("\") + 1)
                    If My.Computer.FileSystem.FileExists(RutaLocal & "\" & FolderName & ".lnk") = False Then
                        'No existe el LNK. se debe crear
                        CreateFolderLNKRemoto(item)
                    End If
                Next 'Pass 20/08/2021 08:14 PM
                Threading.Thread.Sleep(Val(nudSyncTime.Value & "000")) 'ESPERAR
            End While
        Catch ex As Exception
            btnStart.Enabled = True
            RemoteSyncThreadStatus = False
            AddToLog("[GetNubeFilesAndFolders@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub CreateFileLNKRemoto(ByVal item As String)
        Try
            Dim WSHShell As Object = CreateObject("WScript.Shell")
            Dim Shortcut As Object
            'Formato ejemplo
            '   C:\.1.\.2.\.3.\Hola.txt
            Dim fileName As String = IO.Path.GetFileName(item) 'Obtiene el nombre del archivo (Hola.txt)
            Dim filePath As String = IO.Path.GetDirectoryName(item) 'Obtiene la ruta del archivo (C:\.1.\.2.\.3.)
            Dim fileNameNoExt As String = IO.Path.GetFileNameWithoutExtension(fileName) 'Obtiene el nombre sin extencion del archivo (Hola)
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
            'Formato ejemplo
            '   C:\.1.\.2.\.3.\Hola.txt
            Dim FolderName As String = item 'FolderName = "C:\.1.\.2.\.3.\RutaLocal\SubFolder"
            FolderName = FolderName.Remove(0, FolderName.LastIndexOf("\") + 1) 'FolderName = "SubFolder"
            Shortcut = WSHShell.CreateShortcut(RutaLocal & "\" & FolderName & ".lnk")
            Shortcut.TargetPath = RutaNube & "\" & FolderName
            Shortcut.Save()
        Catch ex As Exception
            AddToLog("[CreateFolderLNK@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
#End Region

#Region "LocalSync"
    'La idea
    '   Cuano se encuentre una archivo/carpeta en el escritorio, lo meta en la Nube y haga el acceso directo
    Sub GetLocalFilesAndFolders()
        Try
            While True 'algun coso para romper esto.
                For Each item As String In My.Computer.FileSystem.GetFiles(RutaLocal)
                    'Toma el archivo y ve si existe un LNK (acceso directo)
                    If item.Contains("desktop.ini") = False Then
                        If item.Contains(".lnk") = False Then 'Omite los LNK
                            Dim FileName As String = IO.Path.GetFileName(item)
                            Dim result = fileSkip.ToArray().Any(Function(x) x.ToString().Contains(FileName))
                            If result = False Then 'Si es True, entonces el archivo esta en la lista de omitidos, si no, entonces se debe subir a la nube
                                'copiar a la nube, crear acceso directo
                                My.Computer.FileSystem.MoveFile(RutaLocal & "\" & FileName, RutaNube & "\" & FileName, True)
                                CreateFileLNKLocal(item) 'pasa la ruta completa uwu
                            End If
                        End If
                    End If
                Next 'Funciona. Pass 20/08/2021 07:23 PM

                For Each item As String In My.Computer.FileSystem.GetDirectories(RutaLocal)
                    'Toma la carpeta y crear acceso directo (cuz el LNK no se toma como carpeta, si no como archivo :D)
                    'Formato de ejemplo
                    '   C:\.1.\.2.\.3.\RutaLocal\SubFolder
                    Dim FolderName As String = item 'FolderName = "C:\.1.\.2.\.3.\RutaLocal\SubFolder"
                    FolderName = FolderName.Remove(0, FolderName.LastIndexOf("\") + 1) 'FolderName = "SubFolder"
                    Dim result = folderSkip.ToArray().Any(Function(x) x.ToString().Contains(FolderName))
                    If result = False Then
                        My.Computer.FileSystem.MoveDirectory(item, RutaNube & "\" & FolderName, True)
                        CreateFolderLNKLocal(item)
                    End If
                Next 'Funciona. Pass 20/08/2021 07:23 PM
                Threading.Thread.Sleep(Val(nudSyncTime.Value & "000")) 'ESPERAR
            End While
        Catch ex As Exception
            btnStart.Enabled = True
            LocalSyncThreadStatus = True
            AddToLog("[GetLocalFilesAndFolders@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub 'Pass 20/08/2021 07:47 PM. Faltan pruebas, aun asi creo que ira bien.

    Sub CreateFileLNKLocal(ByVal item As String)
        Try
            Dim WSHShell As Object = CreateObject("WScript.Shell")
            Dim Shortcut As Object
            'Formato ejemplo
            '   C:\.1.\.2.\.3.\Hola.txt
            Dim fileName As String = IO.Path.GetFileName(item) 'Obtiene el nombre del archivo (Hola.txt)
            Dim filePath As String = IO.Path.GetDirectoryName(item) 'Obtiene la ruta del archivo (C:\.1.\.2.\.3.)
            Dim fileNameNoExt As String = IO.Path.GetFileNameWithoutExtension(fileName) 'Obtiene el nombre sin extencion del archivo (Hola)
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
            'Formato ejemplo
            '   C:\.1.\.2.\.3.\Hola.txt
            Dim FolderName As String = item 'FolderName = "C:\.1.\.2.\.3.\RutaLocal\SubFolder"
            FolderName = FolderName.Remove(0, FolderName.LastIndexOf("\") + 1) 'FolderName = "SubFolder"
            Shortcut = WSHShell.CreateShortcut(RutaLocal & "\" & FolderName & ".lnk")
            Shortcut.TargetPath = RutaNube & "\" & FolderName
            Shortcut.Save()
        Catch ex As Exception
            AddToLog("[CreateFolderLNK@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
#End Region

#Region "App Config Files"
    Private Sub btnConfigFile_Click(sender As Object, e As EventArgs) Handles btnConfigFile.Click
        If MessageBox.Show("¿Quiere importar un Archivo de Configuracion?" & vbCrLf & "Si quiere explorar, clic en 'No'", "Config file", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            'Si (importar)
            Dim OpenFile As New OpenFileDialog
            OpenFile.Title = "Abrir archivo..."
            OpenFile.Filter = "ConfigFile(*.cfg)|*.cfg|All file types(*.*)|*.*"
            If OpenFile.ShowDialog() = DialogResult.OK Then
                ReadConfig()
            End If
        Else
            'No (exportar)
            Dim SaveFile As New SaveFileDialog
            SaveFile.Title = "Guardar archivo..."
            SaveFile.Filter = "ConfigFile(*.cfg)|*.cfg|All file types(*.*)|*.*"
            If SaveFile.ShowDialog() = DialogResult.OK Then
                SaveConfig()
            End If
        End If
    End Sub
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

        Catch ex As Exception
            AddToLog("[ReadConfigFile@Main]", "Error: " & ex.Message, True)
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
            'My.Computer.FileSystem.WriteAllText(folderSkipPath, "Shared Folder", False)
            For Each skipFolder As String In folderSkip
                My.Computer.FileSystem.WriteAllText(folderSkipPath, skipFolder, True)
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
                folderSkip.Add(item)
            Next
        Catch ex As Exception
            AddToLog("[ReadSkipFolder@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
#End Region
End Class
'Idea principal
'   Este programa es para administrar carpetas y archivos que se encuentren en el escritorio
'   La razon del crearlo es que tengo OneDrive y ademas me encanta dejar carpetitas y archivos sueltos en el escritorio, y, me encantaria que esos archivos y cositas que dejo
'   esten en el OneDrive, en la carpeta Escritorio de OneDrive, asi desde cualquier otro pc que yo tenga podre acceder a ello.
'   La idea es que este programa tome los archivos y carpetas y los suba a esa carpeta en OneDrive y luego haga un acceso directo a ese archivo/carpeta y este lo deje en el escritorio real.
'   De esta forma los archivos/carpetas estan en la nube, y solo tengo un acceso directo, como si estubiese ahi, pero no, estan en la nube.
'   Asi que.
'       Debe ser capaz de ver archivos y carpetas que se encuentre en el Escritorio real (desde ahora Desktop)
'       Cuano los encuentre, los debe MOVER a el escritorio OneDrive (desde ahora Nube)
'       Cuando los mueva, debe ir creando el acceso directo en el Desktop.
'
'LISTO
'   Un problema seria
'       Cuando un computador es servidor (el que mete todos los archivos/carpetas a la Nube)
'       entonces un PC nuevo no sabria que hay archivos en la nube, por lo que no funcionaria
'       Ambos programas deben ser capaz de:
'           Si hay archivos/carpetas en la Nube, automaticamente se deben hacer el acceso directo
'           Si no hay, pues no se hacen.
'           Ambos programas, deben ser capaz de no interferir con el otro
'               Ejemplo:
'                   Si utilizo los programas al mismo tiempo, entonces el PC1 sube un archivo, entonces automaticamente el PC2 debera crear
'                   el acceso directo en el Desktop
'                   Tienen que ser capaces de funcionar asincronicamente, independiente uno del otro.
'
'PROHIBIDO USAR APIS
'   La magia de el programa tambien puede ser que no solo permita OneDrive, si no que cualquier metodo que tenga guardado en nube
'       Como DropBox, GoogleDrive, etc.
'
'Modular
'   Para poder configurarlo
'   Un archivo de configuracion importable y exportable se agradece, asi no tendriamos que configurarlo todo el tiempo que queramos agregar un nuevo PC
