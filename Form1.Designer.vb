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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Main))
        Me.audioDeviceCB = New System.Windows.Forms.ListBox()
        Me.createShortcutBtn = New System.Windows.Forms.Button()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.grpBoxIcon = New System.Windows.Forms.GroupBox()
        Me.ptBoxHeadPhone = New System.Windows.Forms.PictureBox()
        Me.ptBoxSpeaker = New System.Windows.Forms.PictureBox()
        Me.rdoHeadPhone = New System.Windows.Forms.RadioButton()
        Me.rdoSpeaker = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnLog = New System.Windows.Forms.Button()
        Me.tbLog = New System.Windows.Forms.RichTextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grpBoxIcon.SuspendLayout()
        CType(Me.ptBoxHeadPhone, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ptBoxSpeaker, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
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
        Me.createShortcutBtn.Location = New System.Drawing.Point(185, 112)
        Me.createShortcutBtn.Name = "createShortcutBtn"
        Me.createShortcutBtn.Size = New System.Drawing.Size(88, 23)
        Me.createShortcutBtn.TabIndex = 1
        Me.createShortcutBtn.Text = "Create Shortcut"
        Me.createShortcutBtn.UseVisualStyleBackColor = True
        '
        'btnHelp
        '
        Me.btnHelp.Location = New System.Drawing.Point(210, 138)
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnLog)
        Me.GroupBox1.Controls.Add(Me.createShortcutBtn)
        Me.GroupBox1.Controls.Add(Me.btnHelp)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(280, 189)
        Me.GroupBox1.TabIndex = 8
        Me.GroupBox1.TabStop = False
        '
        'btnLog
        '
        Me.btnLog.Location = New System.Drawing.Point(210, 162)
        Me.btnLog.Name = "btnLog"
        Me.btnLog.Size = New System.Drawing.Size(38, 21)
        Me.btnLog.TabIndex = 6
        Me.btnLog.Text = "Log"
        Me.btnLog.UseVisualStyleBackColor = True
        '
        'tbLog
        '
        Me.tbLog.Location = New System.Drawing.Point(294, 8)
        Me.tbLog.Name = "tbLog"
        Me.tbLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical
        Me.tbLog.Size = New System.Drawing.Size(205, 183)
        Me.tbLog.TabIndex = 10
        Me.tbLog.Text = ""
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ButtonShadow
        Me.Label1.Location = New System.Drawing.Point(383, 191)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Created by Lucas Buccilli"
        '
        'Main
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(511, 203)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbLog)
        Me.Controls.Add(Me.grpBoxIcon)
        Me.Controls.Add(Me.audioDeviceCB)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Main"
        Me.Text = "Audio Shortcut"
        Me.grpBoxIcon.ResumeLayout(False)
        Me.grpBoxIcon.PerformLayout()
        CType(Me.ptBoxHeadPhone, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ptBoxSpeaker, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents audioDeviceCB As ListBox
    Friend WithEvents createShortcutBtn As Button
    Friend WithEvents btnHelp As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents grpBoxIcon As GroupBox
    Friend WithEvents rdoHeadPhone As RadioButton
    Friend WithEvents rdoSpeaker As RadioButton
    Friend WithEvents ptBoxSpeaker As PictureBox
    Friend WithEvents ptBoxHeadPhone As PictureBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents tbLog As RichTextBox
    Friend WithEvents btnLog As Button
    Friend WithEvents Label1 As Label
End Class
