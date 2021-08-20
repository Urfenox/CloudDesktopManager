Public Class Main
    Dim DIRCommons As String = "C:\Users\" & Environment.UserName & "\AppData\Local\CRZ_Labs\CloudDesktopManager"

    Dim SyncThread As Threading.Thread

    Dim RutaNube As String
    Dim RutaLocal As String

    Dim fileSkip As New ArrayList 'Debe haber por lo menos 1 item
    Dim folderSkip As New ArrayList 'Debe haber por lo menos 1 item

    Sub AddToLog(ByVal from As String, ByVal content As String, Optional ByVal flag As Boolean = False)
        Try

            Dim finalContent As String
            If flag = True Then
                finalContent = "[!!!]" & content
            Else
                finalContent = content
            End If
            Console.WriteLine(from & " " & finalContent)
        Catch ex As Exception
            Console.WriteLine("[AddToLog@Main]Error: " & ex.Message)
        End Try
    End Sub

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        SaveSkipFiles()
        SaveSkipFolder()
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
    End Sub

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RutaNube = TextBox1.Text
        RutaLocal = TextBox2.Text
        SyncThread = New Threading.Thread(AddressOf SyncIt)
        SyncThread.Start()
    End Sub

    Sub SyncIt()
        Try
            GetLocalFilesAndFolders()



        Catch ex As Exception
            AddToLog("[SyncIt@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub

    'La idea
    '   Cuano se encuentre una archivo/carpeta en la nube se debe ver si su acceso directo en el escritorio existe
    '       Si no existe, se crea
    '       Si existe, se omite
    '           Esto se hacer asi para no ir guardando una lista
    Sub GetNubeFilesAndFolders()
        Try



        Catch ex As Exception
            AddToLog("[GetNubeFilesAndFolders@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub

#Region "LocalSync"
    'La idea
    '   Cuano se encuentre una archivo/carpeta en el escritorio, lo meta en la Nube y haga el acceso directo
    Sub GetLocalFilesAndFolders()
        Try
            For Each item As String In My.Computer.FileSystem.GetFiles(RutaLocal)
                'Toma el archivo y ve si existe un LNK (acceso directo)
                If item.Contains(".lnk") = False Then 'Omite los LNK
                    Dim FileName As String = IO.Path.GetFileName(item)
                    For Each skipFile As String In fileSkip
                        If skipFile <> FileName Then
                            'copiar a la nube, crear acceso directo
                            My.Computer.FileSystem.MoveFile(RutaLocal & "\" & FileName, RutaNube & "\" & FileName, True)
                            CreateFileLNK(item) 'pasa la ruta completa uwu
                        End If
                    Next
                End If
            Next 'Funciona, pero faltan mas pruebas

            'For Each item As String In My.Computer.FileSystem.GetDirectories(RutaNube)
            '    'Toma la carpeta y ve si exsite un LNK (acceso directo)
            '    Dim FolderName As String = item
            '    FolderName = FolderName.Remove(0, FolderName.LastIndexOf("\") + 1)
            '    For Each skipFolder As String In folderSkip
            '        'copiar a la nube y crear acceso directo
            '
            '
            '
            '    Next
            'Next
        Catch ex As Exception
            AddToLog("[GetLocalFilesAndFolders@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub

    Sub CreateFileLNK(ByVal item As String)
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
#End Region

#Region "App Config Files"
    Private Sub btnConfigFile_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If MessageBox.Show("¿Quiere importar un Archivo de Configuracion?" & vbCrLf & "Si quiere explorar, clic en 'No'", "Config file", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                        'Si (importar)
                        Dim OpenFile As New OpenFileDialog
            OpenFile.Title = "Abrir archivo..."
            OpenFile.Filter = "ConfigFile(*.cfg)|All file types(*.*)|*.*"
            If OpenFile.ShowDialog() = DialogResult.OK Then
                ReadConfigFile(OpenFile.FileName)
            End If
        Else
            'No (exportar)
            Dim SaveFile As New SaveFileDialog
            SaveFile.Title = "Guardar archivo..."
            SaveFile.Filter = "ConfigFile(*.cfg)|All file types(*.*)|*.*"
            If SaveFile.ShowDialog() = DialogResult.OK Then
                SaveConfigFile(SaveFile.FileName)
            End If
        End If
    End Sub
    Sub ReadConfigFile(ByVal filePath As String)
        Try



        Catch ex As Exception
            AddToLog("[ReadConfigFile@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub
    Sub SaveConfigFile(ByVal filePath As String)
        Try
            Dim FileContent As String = "# CloudDesktopManager" &
                vbCrLf & "" &
                vbCrLf & ""

            My.Computer.FileSystem.WriteAllText(filePath, FileContent, False)

        Catch ex As Exception
            AddToLog("[SaveConfigFile@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub

    Private Sub btnSkipFiles_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim OpenFile As New OpenFileDialog
        OpenFile.Title = "Abrir archivo..."
        OpenFile.Filter = "ConfigFile(*.cfg)|All file types(*.*)|*.*"
        OpenFile.Multiselect = True
        OpenFile.InitialDirectory = RutaLocal
        If OpenFile.ShowDialog() = DialogResult.OK Then
            For Each item As String In OpenFile.FileNames
                fileSkip.Add(item)
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
            My.Computer.FileSystem.WriteAllText(fileSkipPath, "Desktop.ini", False)
            For Each skipFile As String In fileSkip
                If skipFile <> "Desktop.ini" Then
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
            For Each item As String In IO.File.ReadLines(fileSkipPath)
                If item <> "Desktop.ini" Then
                    fileSkip.Add(item)
                End If
            Next
        Catch ex As Exception
            AddToLog("[ReadSkipFiles@Main]", "Error: " & ex.Message, True)
        End Try
    End Sub

    Private Sub btnSkipFolders_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim FolderSelect As New FolderBrowserDialog
        FolderSelect.Description = "Seleccione un directorio para agregarlo a la lista de omitidos"
        FolderSelect.SelectedPath = RutaLocal
        If FolderSelect.ShowDialog() = DialogResult.OK Then
            folderSkip.Add(FolderSelect.SelectedPath)
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
