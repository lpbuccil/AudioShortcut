Imports System.IO
Imports System.IO.Compression
Imports System.Net
Imports System.Threading
Imports IWshRuntimeLibrary
Imports Microsoft.VisualBasic.Devices
Imports Microsoft.Win32


Public Class Main
    ReadOnly selected As Boolean = False
    Dim nircmd As Boolean = False
    Dim NirCMDPath As String
    Dim selectedIcon As Icon
    Public AudioDeviceList As New List(Of AudioDevice)
    Private isUnique As Boolean

    Public Sub loadDevices()

        AudioDeviceList = New List(Of AudioDevice)

        'Populates active audio devices'
        Try
            Using _
                myKey As RegistryKey =
                    Registry.LocalMachine.OpenSubKey("SOFTWARE").OpenSubKey("Microsoft").OpenSubKey("Windows").
                        OpenSubKey("CurrentVersion").OpenSubKey("MMDevices").OpenSubKey("Audio").OpenSubKey("Render")
                tbLog.AppendText("_Looking for devices.")

                For Each reg As String In myKey.GetSubKeyNames()

                    If (myKey.OpenSubKey(reg).GetValue("DeviceState") = 1) Then

                        Dim curAudioDevice As AudioDevice = New AudioDevice()
                        curAudioDevice.DeviceID = reg

                        myKey.OpenSubKey(reg).OpenSubKey("Properties").GetValue("{a45c254e-df1c-4efd-8020-67d146a850e0}")

                        curAudioDevice.DeviceName = myKey.OpenSubKey(reg).OpenSubKey("Properties").GetValue(
                            "{a45c254e-df1c-4efd-8020-67d146a850e0},2")
                        curAudioDevice.deviceControllerInformation = myKey.OpenSubKey(reg).OpenSubKey("Properties").GetValue(
                            "{b3f8fa53-0004-438e-9003-51a46e139bfc},6")

                        AudioDeviceList.Add(curAudioDevice)
                        tbLog.AppendText(vbNewLine + "_Found device:" + curAudioDevice.DeviceName + ".")

                    End If

                Next


            End Using
        Catch ex As Exception
            tbLog.AppendText(vbNewLine + "_Error opening registry.")
        End Try
        audioDeviceCB.DataSource = AudioDeviceList
        audioDeviceCB.ValueMember = "deviceID"
        audioDeviceCB.DisplayMember = "deviceName"


        'check for duplicates
        Dim deviceName As New List(Of String)
        For Each audioDeviceInList In AudioDeviceList
            deviceName.Add(audioDeviceInList.DeviceName)
        Next
        isUnique = deviceName.Distinct().Count() = deviceName.Count()
        If (Not isUnique) Then
            Me.Width = 527
            tbLog.Visible = True
            tbLog.AppendText(vbNewLine + "!!_More than one device have the same name. If you plan to use a shortcut for this device, double click on the device and change its name")
        End If
    End Sub

    Public Sub initalize()

        loadDevices()

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

        ptBoxSpeaker.SizeMode = PictureBoxSizeMode.CenterImage
        ptBoxHeadPhone.SizeMode = PictureBoxSizeMode.CenterImage

        tbLog.AppendText(vbNewLine + "_Select Audio Dervice and click Create.")

        Me.Update()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        btnLog_Click(btnLog, New EventArgs())
        initalize()


    End Sub


    Private Sub createShortcutBtn_Click(sender As Object, e As EventArgs) Handles createShortcutBtn.Click


        Dim NirCMDWebsite = "http://www.nirsoft.net/utils/nircmd.zip"
        Dim installPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)


        'Check if nircmd directory exists
        Dim nirCmdExists = False

        For Each Dir As String In Directory.GetDirectories(installPath)
            If (Dir.Equals(installPath + "\NirCMD")) Then
                tbLog.AppendText(vbNewLine + "_Found previous NirCmd, checking integrity.")
                nirCmdExists = True

                If (Not New FileInfo(installPath + "\NirCMD" + "\NirCmd.chm").Exists) Then
                    tbLog.AppendText(vbNewLine + "_Missing NirCmd.chm.")
                    nirCmdExists = False
                End If

                If (Not New FileInfo(installPath + "\NirCMD" + "\nircmd.exe").Exists) Then
                    tbLog.AppendText(vbNewLine + "_Missing nircmd.exe.")
                    nirCmdExists = False
                End If

                If (Not New FileInfo(installPath + "\NirCMD" + "\nircmdc.exe").Exists) Then
                    tbLog.AppendText(vbNewLine + "_Missing nircmdc.exe.")
                    nirCmdExists = False
                End If
            End If
        Next


        If (Not nirCmdExists) Then

            tbLog.AppendText(vbNewLine + "_NirCmd missing.")

            Dim req As System.Net.WebRequest
            Dim res As System.Net.WebResponse


            'check if website website download exists
            req = System.Net.WebRequest.Create(NirCMDWebsite)
            Try
                res = req.GetResponse()
                tbLog.AppendText(vbNewLine + "_Connection established to nirsoft website.")
            Catch ex As WebException
                ' URL doesn't exists
                tbLog.AppendText(vbNewLine + "_NirCmd download site down")

                Me.Update()
                Exit Sub

            End Try


            Dim temp_NirCMDDir = New DirectoryInfo(installPath + "\NirCMD")
            temp_NirCMDDir.Create()


            'download from website'
            Using webClient As New WebClient
                If System.IO.File.Exists(installPath + "\NirCMD\nircmd.zip") Then
                    tbLog.AppendText(vbNewLine + "_nircmd.zip exists, removing.")
                    My.Computer.FileSystem.DeleteFile(installPath + "\NirCMD\nircmd.zip")

                End If
                Try
                    tbLog.AppendText(vbNewLine + "_Downloading nircmd.zip.")
                    webClient.DownloadFile(New Uri(NirCMDWebsite), installPath + "\NirCMD\nircmd.zip")
                Catch ex As Exception
                    tbLog.AppendText(vbNewLine + "!!_" + ex.Message)
                End Try


                tbLog.AppendText(vbNewLine + "_Download Complete.")
            End Using



            Dim fullpath = installPath + "\NirCMD"


            'Extracts downloaded zip'
            Try
                tbLog.AppendText(vbNewLine + "_Extracting.")
                ZipFile.ExtractToDirectory(fullpath + "\nircmd.zip", fullpath)
                tbLog.AppendText(vbNewLine + "_Extracted nircmd.zip to your documents.")

                'Deletes zip'
                Dim nirCmdZip As FileInfo
                nirCmdZip = New FileInfo(fullpath + "\nircmd.zip")
                nirCmdZip.Delete()
                tbLog.AppendText(vbNewLine + "_nircmd.zip removed.")

                nircmd = True

            Catch ex As IOException
                tbLog.AppendText(vbNewLine + "!!_" + ex.Message)
                'Part of nircmd.zip exists
                tbLog.AppendText(vbNewLine + "_Parts of zip are already extracted.")

                Dim temp_file1 = New FileInfo(fullpath + "\NirCmd.chm")
                If (temp_file1.Exists) Then
                    tbLog.AppendText(vbNewLine + "_Removing NirCmd.chm.")
                    temp_file1.Delete()
                End If

                temp_file1 = New FileInfo(fullpath + "\NirCmd.exe")
                If (temp_file1.Exists) Then
                    tbLog.AppendText(vbNewLine + "_Removing NirCmd.exe.")
                    temp_file1.Delete()
                End If

                temp_file1 = New FileInfo(fullpath + "\NirCmdc.exe")
                If (temp_file1.Exists) Then
                    tbLog.AppendText(vbNewLine + "_Removing NirCmdc.exe.")
                    temp_file1.Delete()
                End If

                Try
                    ZipFile.ExtractToDirectory(fullpath + "\nircmd.zip", fullpath)
                    tbLog.AppendText(vbNewLine + "_Extracted nircmd.zip to your documents.")
                    'Deletes zip'
                    Dim nirCmdZip As FileInfo
                    nirCmdZip = New FileInfo(fullpath + "\nircmd.zip")
                    nirCmdZip.Delete()
                    tbLog.AppendText(vbNewLine + "_nircmd.zip removed.")

                    nircmd = True
                Catch exc As IOException
                    tbLog.AppendText(vbNewLine + "!!_" + exc.Message)
                    MessageBox.Show("Issue extracting zip", "Error")
                    Exit Sub
                End Try




            End Try
        Else
            tbLog.AppendText(vbNewLine + "_NirCmd is OK.")

        End If


        NirCMDPath = installPath + "\NirCMD"


        Dim name = audioDeviceCB.SelectedItem.deviceName.Replace(" ", "").Replace("-", "")
        Dim nameWithChar = audioDeviceCB.SelectedItem.deviceName.ToString()
        Dim file = New FileInfo(NirCMDPath + "\" + name + ".bat")

        'Check if bat file exists, if so, remove'
        If (file.Exists) Then
            tbLog.AppendText(vbNewLine + "_Batch file exists, removing.")
            file.Delete()
        End If

        'Create batch file'
        tbLog.AppendText(vbNewLine + "_Creating new batch file " + name + ".bat.")
        Dim fs As StreamWriter
        fs = New StreamWriter(file.ToString(), True)
        fs.WriteLine("@ECHO OFF")
        Dim cc = "\NIRCMDC"
        Dim command = "setdefaultsounddevice"
        fs.WriteLine($"{NirCMDPath}{cc} {command} ""{nameWithChar}"" 1 ")
        fs.WriteLine($"{NirCMDPath}{cc} {command} ""{nameWithChar}"" 2 ")
        fs.Close()


        'Creates shortcut'
        tbLog.AppendText(vbNewLine + "_Creating shortcut on desktop.")
        Dim wsh = CreateObject("WScript.Shell")
        Dim MyShortcut As WshShortcut
        Dim DesktopPath
        DesktopPath = wsh.SpecialFolders("Desktop")

        'Check if shortcut exists'
        Dim temp = New FileInfo($"{DesktopPath}\{name}.lnk")
        If (temp).Exists Then
            tbLog.AppendText(vbNewLine + "_Shortcut exists, removing.")
            temp.Delete()
        End If

        MyShortcut = wsh.CreateShortcut($"{DesktopPath}\{name}.lnk")

        MyShortcut.TargetPath = "C:\Windows\system32\cmd.exe"
        MyShortcut.Arguments = $"/c ""{NirCMDPath}\{name}.bat"""

        MyShortcut.WorkingDirectory = wsh.ExpandEnvironmentStrings(NirCMDPath)

        'check if dll with icon exists, if so, select icon'
        tbLog.AppendText(vbNewLine + "_Checking if icons exists.")
        Dim dll = New FileInfo("C:\Windows\system32\ddores.dll")
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
        tbLog.AppendText(vbNewLine + "_Done, shortcut has been created on desktop.")
        Me.Update()
        Thread.Sleep(1500)


        Me.Update()
    End Sub


    Private Sub audioDeviceCB_SelectedIndexChanged(sender As Object, e As EventArgs) _
        Handles audioDeviceCB.SelectedIndexChanged

        If (audioDeviceCB.SelectedItems.Count = 1) Then
            createShortcutBtn.Enabled = True
        End If
        Me.Update()
    End Sub

    Private Sub btnHelp_Click(sender As Object, e As EventArgs) Handles btnHelp.Click
        Try
            Process.Start("https://github.com/lpbuccil/AudioShortcut/wiki")
        Catch ex As Exception
            MessageBox.Show("Could not open browser, go to https://github.com/lpbuccil/AudioShortcut/wiki for information")
        End Try
    End Sub

    Private Sub ptBoxSpeaker_Click(sender As Object, e As EventArgs) Handles ptBoxSpeaker.Click
        rdoSpeaker.Checked = True
        Me.Update()
    End Sub

    Private Sub ptBoxHeadPhone_Click(sender As Object, e As EventArgs) Handles ptBoxHeadPhone.Click
        rdoHeadPhone.Checked = True
        Me.Update()
    End Sub

    Private Sub audioDeviceCB_DoubleClick(sender As Object, e As EventArgs) Handles audioDeviceCB.DoubleClick
        Dim AudioDeviceInfo As New AudioDeviceForm
        Me.Enabled = False
        AudioDeviceInfo.Show()
    End Sub

    Private Sub tbLog_MouseLeave(sender As Object, e As EventArgs) Handles tbLog.MouseLeave
        tbLog.DeselectAll()
        btnHelp.Focus()
    End Sub

    Private Sub btnLog_Click(sender As Object, e As EventArgs) Handles btnLog.Click
        If (tbLog.Visible) Then
            tbLog.Visible = False
            Me.Width = 312
        Else
            tbLog.Visible = True
            Me.Width = 527
        End If
    End Sub

End Class
