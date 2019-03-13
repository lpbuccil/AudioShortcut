<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AudioDeviceForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(AudioDeviceForm))
        Me.lblDeviceName = New System.Windows.Forms.Label()
        Me.lblControllerInfoLabel = New System.Windows.Forms.Label()
        Me.txtDeviceName = New System.Windows.Forms.TextBox()
        Me.lblControllerInfo = New System.Windows.Forms.Label()
        Me.btnOk = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblDeviceName
        '
        resources.ApplyResources(Me.lblDeviceName, "lblDeviceName")
        Me.lblDeviceName.Name = "lblDeviceName"
        '
        'lblControllerInfoLabel
        '
        resources.ApplyResources(Me.lblControllerInfoLabel, "lblControllerInfoLabel")
        Me.lblControllerInfoLabel.Name = "lblControllerInfoLabel"
        '
        'txtDeviceName
        '
        resources.ApplyResources(Me.txtDeviceName, "txtDeviceName")
        Me.txtDeviceName.Name = "txtDeviceName"
        '
        'lblControllerInfo
        '
        resources.ApplyResources(Me.lblControllerInfo, "lblControllerInfo")
        Me.lblControllerInfo.Name = "lblControllerInfo"
        '
        'btnOk
        '
        resources.ApplyResources(Me.btnOk, "btnOk")
        Me.btnOk.Name = "btnOk"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'AudioDeviceForm
        '
        resources.ApplyResources(Me, "$this")
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ControlBox = False
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.lblControllerInfo)
        Me.Controls.Add(Me.txtDeviceName)
        Me.Controls.Add(Me.lblControllerInfoLabel)
        Me.Controls.Add(Me.lblDeviceName)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "AudioDeviceForm"
        Me.ShowInTaskbar = False
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblDeviceName As Label
    Friend WithEvents lblControllerInfoLabel As Label
    Friend WithEvents txtDeviceName As TextBox
    Friend WithEvents lblControllerInfo As Label
    Friend WithEvents btnOk As Button
End Class
