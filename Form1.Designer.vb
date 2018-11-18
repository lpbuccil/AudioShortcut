<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Main
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
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.status = New System.Windows.Forms.ToolStripStatusLabel()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.grpBoxIcon = New System.Windows.Forms.GroupBox()
        Me.ptBoxHeadPhone = New System.Windows.Forms.PictureBox()
        Me.ptBoxSpeaker = New System.Windows.Forms.PictureBox()
        Me.rdoHeadPhone = New System.Windows.Forms.RadioButton()
        Me.rdoSpeaker = New System.Windows.Forms.RadioButton()
        Me.StatusStrip1.SuspendLayout()
        Me.grpBoxIcon.SuspendLayout()
        CType(Me.ptBoxHeadPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptBoxSpeaker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'audioDeviceCB
        '
        Me.audioDeviceCB.FormattingEnabled = True
        Me.audioDeviceCB.Location = New System.Drawing.Point(12, 16)
        Me.audioDeviceCB.Name = "audioDeviceCB"
        Me.audioDeviceCB.Size = New System.Drawing.Size(165, 160)
        Me.audioDeviceCB.TabIndex = 0
        '
        'createShortcutBtn
        '
        Me.createShortcutBtn.Enabled = False
        Me.createShortcutBtn.Location = New System.Drawing.Point(194, 128)
        Me.createShortcutBtn.Name = "createShortcutBtn"
        Me.createShortcutBtn.Size = New System.Drawing.Size(88, 23)
        Me.createShortcutBtn.TabIndex = 1
        Me.createShortcutBtn.Text = "Create Shortcut"
        Me.createShortcutBtn.UseVisualStyleBackColor = True
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.status})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 181)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(299, 22)
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
        Me.btnHelp.Location = New System.Drawing.Point(218, 157)
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
        Me.grpBoxIcon.Location = New System.Drawing.Point(194, 12)
        Me.grpBoxIcon.Name = "grpBoxIcon"
        Me.grpBoxIcon.Size = New System.Drawing.Size(88, 100)
        Me.grpBoxIcon.TabIndex = 6
        Me.grpBoxIcon.TabStop = False
        Me.grpBoxIcon.Text = "Select Icon"
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
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(299, 203)
        Me.Controls.Add(Me.grpBoxIcon)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.StatusStrip1)
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
        CType(Me.ptBoxHeadPhone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptBoxSpeaker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents audioDeviceCB As ListBox
    Friend WithEvents createShortcutBtn As Button
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
