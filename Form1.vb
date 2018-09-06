Imports System.Diagnostics.Eventing.Reader
Imports Microsoft.Win32

Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Windows.Forms.VisualStyles
Imports IWshRuntimeLibrary



Public Class main

    Dim selected As Boolean = False
    Dim nircmd As Boolean = False
    Dim NirCMDPath As String
    Dim selectedIcon As Icon
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        'Populates active audio devices'
        'May fail at any point'
        Try
            Using myKey As RegistryKey = Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows").OpenSubKey("CurrentVersion").OpenSubKey("MMDevices").OpenSubKey("Audio").OpenSubKey("Render")
                Try
                    For Each reg As String In myKey.GetSubKeyNames()
                        Try
                            If (myKey.OpenSubKey(reg).GetValue("DeviceState") = 1) Then
                                Try
                                    myKey.OpenSubKey(reg).OpenSubKey("Properties").GetValue("{a45c254e-df1c-4efd-8020-67d146a850e0}")

                                    audioDeviceCB.Items.Add(myKey.OpenSubKey(reg).OpenSubKey("Properties").GetValue("{a45c254e-df1c-4efd-8020-67d146a850e0},2"))
                                Catch ex As Exception
                                End Try
                            End If
                        Catch ex As Exception
                        End Try
                    Next
                Catch ex As Exception
                End Try
            End Using
        Catch ex As Exception
        End Try

        status.Text = "Click Install NirCMD or Click Locate"
        Me.Update()
    End Sub

    Private Sub createShortcutBtn_Click(sender As Object, e As EventArgs) Handles createShortcutBtn.Click

        Dim name As String

        name = audioDeviceCB.SelectedItem.ToString().Replace(" ", "").Replace("-", "")
        Dim file As FileInfo = New FileInfo(NirCMDPath + "\" + name + ".bat")

        If (file.Exists) Then
            status.Text = "File exists: " + NirCMDPath + "\" + name + ".bat"
            Me.Update()
            Threading.Thread.Sleep(1000)
            file.Delete()
            status.Text = "Removed: " + NirCMDPath + "\" + name + ".bat"
            Me.Update()
        End If



        status.Text = "Creating Batch: " + NirCMDPath + "\" + name + ".bat"
        Me.Update()
        Threading.Thread.Sleep(500)


        Dim fs As StreamWriter
        fs = New StreamWriter(file.ToString(), True)
        fs.WriteLine("@ECHO OFF")
        Dim cc = "\NIRCMDC"
        Dim command = "setdefaultsounddevice"
        fs.WriteLine($"{NirCMDPath}{cc} {command} ""{name}"" 1 ")
        fs.WriteLine($"{NirCMDPath}{cc} {command} ""{name}"" 2 ")
        fs.Close()

        status.Text = "Batch created"
        Me.Update()
        Threading.Thread.Sleep(500)



        Dim wsh = CreateObject("WScript.Shell")
        Dim MyShortcut As WshShortcut
        Dim DesktopPath
        DesktopPath = wsh.SpecialFolders("Desktop")

        Dim temp As FileInfo = New FileInfo(DesktopPath + $"\{name}.lnk")
        If (temp).Exists Then
            temp.Delete()
        End If

        MyShortcut = wsh.CreateShortcut($"{DesktopPath}\{name}.lnk")

        MyShortcut.TargetPath = "C:\Windows\system32\cmd.exe"
        MyShortcut.Arguments = $"/c ""{NirCMDPath}\{name}.bat"""

        MyShortcut.WorkingDirectory = wsh.ExpandEnvironmentStrings(NirCMDPath)

        Dim dll As FileInfo = New FileInfo("C:\Windows\system32\ddores.dll")
        If dll.Exists Then
            MyShortcut.IconLocation = "%systemroot%\system32\ddores.dll,1"
        End If

        MyShortcut.WindowStyle = 4
        MyShortcut.Save()

        status.Text = "Shortcut created on Desktop"
        Me.Update()
        Threading.Thread.Sleep(1500)


        status.Text = "Done"

        Me.Update()


    End Sub


    Private Sub installBtn_Click(sender As Object, e As EventArgs) Handles installBtn.Click
        Dim folderBrowser As New FolderBrowserDialog
        Dim NirCMDWebsite As String = "http://www.nirsoft.net/utils/nircmd.zip"
        Dim pathString As String = ""
        Dim folderFile As String = "\NirCMD"
        Dim fullpath As String = ""


        folderBrowser.ShowDialog()
        If (folderBrowser.SelectedPath = Nothing) Then
            status.Text = "Select an install location"
            Me.Update()
            Exit Sub
        End If
        pathString = folderBrowser.SelectedPath
        status.Text = "Path set to: " + pathString
        Me.Update()
        Threading.Thread.Sleep(500)

        Dim directory As DirectoryInfo = New DirectoryInfo(pathString + folderFile)
        directory.Create()


        status.Text = "Created directory: " + pathString + folderFile
        Me.Update()
        Threading.Thread.Sleep(500)

        status.Text = "Downloading Nircmd to : " + pathString + folderFile
        Me.Update()
        Threading.Thread.Sleep(500)

        Dim webClient As New WebClient
        webClient.DownloadFile(NirCMDWebsite, pathString + folderFile + "\nircmd.zip")

        status.Text = "Downloaded"
        Me.Update()
        Threading.Thread.Sleep(500)

        fullpath = pathString + folderFile

        status.Text = "Unpacking"
        Me.Update()
        Threading.Thread.Sleep(500)

        If (New FileInfo(fullpath + "\nircmdc.exe").Exists) Then
            status.Text = "File nircmdc.exe exists, removing"
            Me.Update()
            Threading.Thread.Sleep(250)
            Dim file1 As FileInfo = New FileInfo(fullpath + "\nircmdc.exe")
            file1.Delete()
        End If

        If (New FileInfo(fullpath + "\NirCmd.chm").Exists) Then
            status.Text = "File NirCmd.chm exists, removing"
            Me.Update()
            Threading.Thread.Sleep(250)
            Dim file1 As FileInfo = New FileInfo(fullpath + "\NirCmd.chm")
            file1.Delete()
        End If

        If (New FileInfo(fullpath + "\nircmd.exe").Exists) Then
            status.Text = "File nircmd.exe exists, removing"
            Me.Update()
            Threading.Thread.Sleep(250)
            Dim file1 As FileInfo = New FileInfo(fullpath + "\nircmd.exe")
            file1.Delete()
        End If

        ZipFile.ExtractToDirectory(fullpath + "\nircmd.zip", fullpath)

        Dim file As FileInfo = New FileInfo(fullpath + "\nircmd.zip")
        file.Delete()


        NirCMDPath = fullpath

        status.Text = "NirCMD path set to : " + fullpath
        Me.Update()

        nircmd = True
        If (nircmd = True And selected = True) Then
            createShortcutBtn.Enabled = True
            Threading.Thread.Sleep(1000)
            status.Text = "Click Create Shortcut"
        Else
            Threading.Thread.Sleep(1000)
            status.Text = "Select audio device and click Create Shortcut"
        End If


    End Sub

    Private Sub setLoactionbtn_Click(sender As Object, e As EventArgs) Handles setLoactionbtn.Click

        Dim folderBrowser As New FolderBrowserDialog
        folderBrowser.ShowDialog()
        Dim pathString = folderBrowser.SelectedPath
        If (Not New FileInfo(pathString + "\NirCmd.chm").Exists) Then
            status.Text = "Missing " + pathString + "\NirCmd.chm"
            Me.Update()
            Exit Sub
        End If

        If (Not New FileInfo(pathString + "\nircmd.exe").Exists) Then
            status.Text = "Missing " + pathString + "\nircmd.exe."
            Me.Update()
            Exit Sub
        End If

        If (Not New FileInfo(pathString + "\nircmdc.exe").Exists) Then
            status.Text = "Missing " + pathString + "\nircmdc.exe."
            Me.Update()
            Exit Sub
        End If

        status.Text = "Path set to: " + pathString
        Me.Update()
        Threading.Thread.Sleep(500)

        NirCMDPath = pathString
        nircmd = True
        If (nircmd = True And selected = True) Then
            createShortcutBtn.Enabled = True
            Threading.Thread.Sleep(1000)
            status.Text = "Click Create Shortcut"
        Else
            Threading.Thread.Sleep(1000)
            status.Text = "Select audio device and click Create Shortcut"
        End If

    End Sub

    Private Sub audioDeviceCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles audioDeviceCB.SelectedIndexChanged

        If (audioDeviceCB.SelectedItems.Count = 1) Then
            selected = True

            If (nircmd = True And selected = True) Then
                createShortcutBtn.Enabled = True
            End If
        Else
            selected = False
        End If


    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        MessageBox.Show("Creates a taskbar pinnable shortcut to switch audio outputs")
    End Sub




End Class
