<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class main
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(main))
        Me.audioDeviceCB = New System.Windows.Forms.ListBox()
        Me.createShortcutBtn = New System.Windows.Forms.Button()
        Me.installBtn = New System.Windows.Forms.Button()
        Me.setLoactionbtn = New System.Windows.Forms.Button()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.grpBoxIcon = New System.Windows.Forms.GroupBox()
        Me.ptBoxSpeaker = New System.Windows.Forms.PictureBox()
        Me.rdoHeadPhone = New System.Windows.Forms.RadioButton()
        Me.rdoSpeaker = New System.Windows.Forms.RadioButton()
        Me.ptBoxHeadPhone = New System.Windows.Forms.PictureBox()
        Me.StatusStrip1.SuspendLayout()
        Me.grpBoxIcon.SuspendLayout()
        CType(Me.ptBoxSpeaker, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptBoxHeadPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'audioDeviceCB
        '
        Me.audioDeviceCB.FormattingEnabled = True
        Me.audioDeviceCB.Location = New System.Drawing.Point(12, 16)
        Me.audioDeviceCB.Name = "audioDeviceCB"
        Me.audioDeviceCB.Size = New System.Drawing.Size(141, 160)
        Me.audioDeviceCB.TabIndex = 0
        '
        'createShortcutBtn
        '
        Me.createShortcutBtn.Enabled = False
        Me.createShortcutBtn.Location = New System.Drawing.Point(254, 153)
        Me.createShortcutBtn.Name = "createShortcutBtn"
        Me.createShortcutBtn.Size = New System.Drawing.Size(101, 23)
        Me.createShortcutBtn.TabIndex = 1
        Me.createShortcutBtn.Text = "Create Shortcut"
        Me.createShortcutBtn.UseVisualStyleBackColor = True
        '
        'installBtn
        '
        Me.installBtn.Location = New System.Drawing.Point(254, 31)
        Me.installBtn.Name = "installBtn"
        Me.installBtn.Size = New System.Drawing.Size(101, 21)
        Me.installBtn.TabIndex = 2
        Me.installBtn.Text = "Install NirCMD"
        Me.installBtn.UseVisualStyleBackColor = True
        '
        'setLoactionbtn
        '
        Me.setLoactionbtn.Location = New System.Drawing.Point(254, 58)
        Me.setLoactionbtn.Name = "setLoactionbtn"
        Me.setLoactionbtn.Size = New System.Drawing.Size(101, 47)
        Me.setLoactionbtn.TabIndex = 3
        Me.setLoactionbtn.Text = "Locate nircmd.exe Parent Directory"
        Me.setLoactionbtn.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 181)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(367, 22)
        Me.StatusStrip1.TabIndex = 4
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'status
        '
        Me.status.Name = "status"
        Me.status.Size = New System.Drawing.Size(0, 17)
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(159, 155)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(38, 21)
        Me.btnHelp.TabIndex = 5
        Me.btnHelp.Text = "Info"
        Me.btnHelp.UseVisualStyleBackColor = True
        '
        'grpBoxIcon
        '
        Me.grpBoxIcon.Controls.Add(Me.ptBoxHeadPhone)
        Me.grpBoxIcon.Controls.Add(Me.ptBoxSpeaker)
        Me.grpBoxIcon.Controls.Add(Me.rdoHeadPhone)
        Me.grpBoxIcon.Controls.Add(Me.rdoSpeaker)
        Me.grpBoxIcon.Location = New System.Drawing.Point(160, 31)
        Me.grpBoxIcon.Name = "grpBoxIcon"
        Me.grpBoxIcon.Size = New System.Drawing.Size(88, 100)
        Me.grpBoxIcon.TabIndex = 6
        Me.grpBoxIcon.TabStop = False
        Me.grpBoxIcon.Text = "Select Icon"
        '
        'ptBoxSpeaker
        '
        Me.ptBoxSpeaker.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ptBoxSpeaker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ptBoxSpeaker.Location = New System.Drawing.Point(6, 19)
        Me.ptBoxSpeaker.Name = "ptBoxSpeaker"
        Me.ptBoxSpeaker.Size = New System.Drawing.Size(56, 30)
        Me.ptBoxSpeaker.TabIndex = 2
        Me.ptBoxSpeaker.TabStop = False
        '
        'rdoHeadPhone
        '
        Me.rdoHeadPhone.AutoSize = True
        Me.rdoHeadPhone.Location = New System.Drawing.Point(68, 61)
        Me.rdoHeadPhone.Name = "rdoHeadPhone"
        Me.rdoHeadPhone.Size = New System.Drawing.Size(14, 13)
        Me.rdoHeadPhone.TabIndex = 1
        Me.rdoHeadPhone.TabStop = True
        Me.rdoHeadPhone.UseVisualStyleBackColor = True
        '
        'rdoSpeaker
        '
        Me.rdoSpeaker.AutoSize = True
        Me.rdoSpeaker.Location = New System.Drawing.Point(68, 27)
        Me.rdoSpeaker.Name = "rdoSpeaker"
        Me.rdoSpeaker.Size = New System.Drawing.Size(14, 13)
        Me.rdoSpeaker.TabIndex = 0
        Me.rdoSpeaker.TabStop = True
        Me.rdoSpeaker.UseVisualStyleBackColor = True
        '
        'ptBoxHeadPhone
        '
        Me.ptBoxHeadPhone.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.ptBoxHeadPhone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ptBoxHeadPhone.Location = New System.Drawing.Point(6, 55)
        Me.ptBoxHeadPhone.Name = "ptBoxHeadPhone"
        Me.ptBoxHeadPhone.Size = New System.Drawing.Size(56, 30)
        Me.ptBoxHeadPhone.TabIndex = 3
        Me.ptBoxHeadPhone.TabStop = False
        '
        'main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(367, 203)
        Me.Controls.Add(Me.grpBoxIcon)
        Me.Controls.Add(Me.setLoactionbtn)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.installBtn)
        Me.Controls.Add(Me.createShortcutBtn)
        Me.Controls.Add(Me.audioDeviceCB)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "main"
        Me.Text = "Audio Shortcut"
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.grpBoxIcon.ResumeLayout(False)
        Me.grpBoxIcon.PerformLayout()
        CType(Me.ptBoxSpeaker, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptBoxHeadPhone, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents audioDeviceCB As ListBox
    Friend WithEvents createShortcutBtn As Button
    Friend WithEvents installBtn As Button
    Friend WithEvents setLoactionbtn As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents status As ToolStripStatusLabel
    Friend WithEvents btnHelp As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents grpBoxIcon As GroupBox
    Friend WithEvents rdoHeadPhone As RadioButton
    Friend WithEvents rdoSpeaker As RadioButton
    Friend WithEvents ptBoxSpeaker As PictureBox
    Friend WithEvents ptBoxHeadPhone As PictureBox
End Class
