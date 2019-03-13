
Imports System.Net
Imports Microsoft.Win32
Imports System.Security.AccessControl

Public Class AudioDeviceForm
    Private Sub AudioDeviceForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim selectedAudioDevice As AudioDevice = Main.audioDeviceCB.SelectedItem
        lblControllerInfo.Text = selectedAudioDevice.deviceControllerInformation
        txtDeviceName.Text = selectedAudioDevice.DeviceName
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        Dim selectedAudioDevice As AudioDevice = Main.audioDeviceCB.SelectedItem
        Try
            'MessageBox.Show("Path is " + $"SOFTWARE\Microsoft\Windows\CurrentVersion\MMDevices\Audio\Render\{selectedAudioDevice.deviceID}\Properties")
            Using regKey As RegistryKey = Registry.LocalMachine.OpenSubKey($"SOFTWARE\Microsoft\Windows\CurrentVersion\MMDevices\Audio\Render\{selectedAudioDevice.deviceID}\Properties\", RegistryRights.SetValue, RegistryRights.SetValue)
                regKey.SetValue("{a45c254e-df1c-4efd-8020-67d146a850e0},2", txtDeviceName.Text, RegistryValueKind.String)
            End Using

            For Each audioDeviceInList In Main.AudioDeviceList

                If audioDeviceInList.deviceID = selectedAudioDevice.DeviceID Then
                    audioDeviceInList.deviceName = txtDeviceName.Text
                End If

            Next
            Application.Restart()
        Catch ex As Exception
            MessageBox.Show("Could not change name, please change it through the sound menu in control panel.")

            Application.Restart()
        End Try
    End Sub
End Class