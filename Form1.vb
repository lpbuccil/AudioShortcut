Imports System.Diagnostics.Eventing.Reader
Imports Microsoft.Win32

Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Security.AccessControl
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

        'adds icon pictures'
        Dim speakerIcon = My.Resources.ico3011
        Dim headphoneIcon = My.Resources.ico3012

        Dim speakerBmp As New Bitmap(speakerIcon.Width, speakerIcon.Height)
        Dim headphoneBmp As New Bitmap(headphoneIcon.Width, headphoneIcon.Height)

        Dim speakerG As Graphics = Graphics.FromImage(speakerBmp)
        Dim headphoneG As Graphics = Graphics.FromImage(headphoneBmp)

        speakerG.DrawIcon(speakerIcon, 0, 0)
        headphoneG.DrawIcon(headphoneIcon, 0, 0)

        speakerG.Dispose()
        headphoneG.Dispose()

        ptBoxSpeaker.Image = speakerBmp
        ptBoxHeadPhone.Image = headphoneBmp

        ptBoxSpeaker.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        ptBoxHeadPhone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage

        status.Text = "Select Audio Dervice and click Create"
        Me.Update()
    End Sub

    Private Sub createShortcutBtn_Click(sender As Object, e As EventArgs) Handles createShortcutBtn.Click




        Dim NirCMDWebsite As String = "http://www.nirsoft.net/utils/nircmd.zip"
        Dim installPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)


        'Check if nircmd directory exists
        Dim nirCmdExists = False

        For Each Dir As String In Directory.GetDirectories(installPath)
            If (Dir.Equals(installPath + "\NirCMD")) Then

                nirCmdExists = True

                If (Not New FileInfo(installPath + "\NirCMD" + "\NirCmd.chm").Exists) Then
                    status.Text = installPath + "\NirCMD" + "\NirCmd.chm"
                    Me.Update()
                    nirCmdExists = False
                End If

                If (Not New FileInfo(installPath + "\NirCMD" + "\nircmd.exe").Exists) Then
                    status.Text = installPath + "\NirCMD" + "\nircmd.exe."
                    Me.Update()
                    nirCmdExists = False
                End If

                If (Not New FileInfo(installPath + "\NirCMD" + "\nircmdc.exe").Exists) Then
                    status.Text = installPath + "\NirCMD" + "\nircmdc.exe."
                    Me.Update()
                    nirCmdExists = False
                End If
            End If
        Next


        If (Not nirCmdExists) Then


            Dim temp_NirCMDDir = New DirectoryInfo(installPath + "\NirCMD")
            temp_NirCMDDir.Create()




            'download from website'
            Dim webClient As New WebClient
            webClient.DownloadFile(NirCMDWebsite, installPath + "\NirCMD\NirCMD.zip")

            status.Text = "Downloaded"
            Me.Update()
            Threading.Thread.Sleep(500)

            Dim fullpath = installPath + "\NirCMD"

            status.Text = "Unpacking"
            Me.Update()
            Threading.Thread.Sleep(500)

            'Extracts downloaded zip'
            Try
                ZipFile.ExtractToDirectory(fullpath + "\nircmd.zip", fullpath)

            Catch ex As IOException
                'Part of nircmd.zip exists

                Dim temp_file1 = New FileInfo(fullpath + "\NirCmd.chm")
                If (temp_file1.Exists) Then
                    temp_file1.Delete()
                End If

                temp_file1 = New FileInfo(fullpath + "\NirCmd.exe")
                If (temp_file1.Exists) Then
                    temp_file1.Delete()
                End If

                temp_file1 = New FileInfo(fullpath + "\NirCmdc.exe")
                If (temp_file1.Exists) Then
                    temp_file1.Delete()
                End If


                ZipFile.ExtractToDirectory(fullpath + "\nircmd.zip", fullpath)
            End Try





            'Deletes zip'
            Dim nirCmdZip As FileInfo
            nirCmdZip = New FileInfo(fullpath + "\nircmd.zip")
            nirCmdZip.Delete()
        End If



        NirCMDPath = installPath + "\NirCMD"

        status.Text = "NirCMD path set to : " + NirCMDPath
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




        Dim name = audioDeviceCB.SelectedItem.ToString().Replace(" ", "").Replace("-", "")
        Dim nameWithChar = audioDeviceCB.SelectedItem.ToString()
        Dim file As FileInfo = New FileInfo(NirCMDPath + "\" + name + ".bat")

        'Check if bat file exists, if so, remove'
        If (file.Exists) Then
            status.Text = $"File exists: {NirCMDPath}\{name}.bat"
            Me.Update()
            Threading.Thread.Sleep(500)
            file.Delete()
            status.Text = $"Removed: {NirCMDPath}\{name}.bat"
            Me.Update()
            Threading.Thread.Sleep(500)
        End If



        status.Text = "Creating Batch: " + NirCMDPath + "\" + name + ".bat"
        Me.Update()
        Threading.Thread.Sleep(500)

        'Create batch file'
        Dim fs As StreamWriter
        fs = New StreamWriter(file.ToString(), True)
        fs.WriteLine("@ECHO OFF")
        Dim cc = "\NIRCMDC"
        Dim command = "setdefaultsounddevice"
        fs.WriteLine($"{NirCMDPath}{cc} {command} ""{nameWithChar}"" 1 ")
        fs.WriteLine($"{NirCMDPath}{cc} {command} ""{nameWithChar}"" 2 ")
        fs.Close()

        status.Text = "Batch file created"
        Me.Update()
        Threading.Thread.Sleep(500)


        'Creates shortcut'
        Dim wsh = CreateObject("WScript.Shell")
        Dim MyShortcut As WshShortcut
        Dim DesktopPath
        DesktopPath = wsh.SpecialFolders("Desktop")

        'Check if shortcut exists'
        Dim temp As FileInfo = New FileInfo($"{DesktopPath}\{name}.lnk")
        If (temp).Exists Then
            temp.Delete()
            status.Text = "Shortcut exists, deleting"
            Me.Update()
            Threading.Thread.Sleep(500)
        End If

        MyShortcut = wsh.CreateShortcut($"{DesktopPath}\{name}.lnk")

        MyShortcut.TargetPath = "C:\Windows\system32\cmd.exe"
        MyShortcut.Arguments = $"/c ""{NirCMDPath}\{name}.bat"""

        MyShortcut.WorkingDirectory = wsh.ExpandEnvironmentStrings(NirCMDPath)

        'check if dll with icon exists, if so, select icon'
        Dim dll As FileInfo = New FileInfo("C:\Windows\system32\ddores.dll")
        If dll.Exists Then
            If rdoSpeaker.Checked = True Then

                MyShortcut.IconLocation = "%systemroot%\system32\ddores.dll,88"

            ElseIf rdoHeadPhone.Checked = True Then

                MyShortcut.IconLocation = "%systemroot%\system32\ddores.dll,89"

            Else

                MyShortcut.IconLocation = "%systemroot%\system32\ddores.dll,1"

            End If

        End If

        MyShortcut.WindowStyle = 4


        MyShortcut.Save()

        status.Text = "Shortcut created on Desktop"
        Me.Update()
        Threading.Thread.Sleep(1500)


        status.Text = "Done"

        Me.Update()


    End Sub



    Private Sub audioDeviceCB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles audioDeviceCB.SelectedIndexChanged

        If (audioDeviceCB.SelectedItems.Count = 1) Then
            createShortcutBtn.Enabled = True
        End If


    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        MessageBox.Show("Creates a taskbar pinnable shortcut to switch audio outputs. Created by Lucas Buccilli")
    End Sub

    Private Sub ptBoxSpeaker_Click(sender As Object, e As EventArgs) Handles ptBoxSpeaker.Click
        rdoSpeaker.Checked = True
    End Sub

    Private Sub ptBoxHeadPhone_Click(sender As Object, e As EventArgs) Handles ptBoxHeadPhone.Click
        rdoHeadPhone.Checked = True
    End Sub
End Class
