<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Payloads
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Payloads))
        Me.WebBrowser1 = New System.Windows.Forms.WebBrowser()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PayloadDialogue = New System.Windows.Forms.OpenFileDialog()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPayloadBox = New System.Windows.Forms.TextBox()
        Me.btnAddToRamdisk = New System.Windows.Forms.Button()
        Me.btnFinish = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'WebBrowser1
        '
        Me.WebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebBrowser1.IsWebBrowserContextMenuEnabled = False
        Me.WebBrowser1.Location = New System.Drawing.Point(0, 0)
        Me.WebBrowser1.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebBrowser1.Name = "WebBrowser1"
        Me.WebBrowser1.ScriptErrorsSuppressed = True
        Me.WebBrowser1.ScrollBarsEnabled = False
        Me.WebBrowser1.Size = New System.Drawing.Size(487, 383)
        Me.WebBrowser1.TabIndex = 0
        Me.WebBrowser1.Url = New System.Uri("http://cloud.blackthund3r.co.uk/Win32", System.UriKind.Absolute)
        Me.WebBrowser1.WebBrowserShortcutsEnabled = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Black
        Me.Label1.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(151, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(135, 32)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Payloads"
        '
        'PayloadDialogue
        '
        Me.PayloadDialogue.Filter = "Gunzip Tarballs|*.tar.gz|Gunzip Tarballs|*.tgz"
        Me.PayloadDialogue.Title = "Open Payload..."
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(376, 265)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(111, 30)
        Me.btnBrowse.TabIndex = 2
        Me.btnBrowse.Text = "Browse"
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Black
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(19, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(456, 198)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = resources.GetString("Label2.Text")
        '
        'txtPayloadBox
        '
        Me.txtPayloadBox.Location = New System.Drawing.Point(12, 266)
        Me.txtPayloadBox.Name = "txtPayloadBox"
        Me.txtPayloadBox.ReadOnly = True
        Me.txtPayloadBox.Size = New System.Drawing.Size(358, 29)
        Me.txtPayloadBox.TabIndex = 4
        '
        'btnAddToRamdisk
        '
        Me.btnAddToRamdisk.Enabled = False
        Me.btnAddToRamdisk.Location = New System.Drawing.Point(0, 301)
        Me.btnAddToRamdisk.Name = "btnAddToRamdisk"
        Me.btnAddToRamdisk.Size = New System.Drawing.Size(243, 30)
        Me.btnAddToRamdisk.TabIndex = 5
        Me.btnAddToRamdisk.Text = "Add to Ramdisk"
        Me.btnAddToRamdisk.UseVisualStyleBackColor = True
        '
        'btnFinish
        '
        Me.btnFinish.Enabled = False
        Me.btnFinish.Location = New System.Drawing.Point(244, 301)
        Me.btnFinish.Name = "btnFinish"
        Me.btnFinish.Size = New System.Drawing.Size(243, 30)
        Me.btnFinish.TabIndex = 6
        Me.btnFinish.Text = "Finish"
        Me.btnFinish.UseVisualStyleBackColor = True
        '
        'Payloads
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(11.0!, 22.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(487, 383)
        Me.Controls.Add(Me.btnFinish)
        Me.Controls.Add(Me.btnAddToRamdisk)
        Me.Controls.Add(Me.txtPayloadBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnBrowse)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.WebBrowser1)
        Me.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(6, 5, 6, 5)
        Me.MaximizeBox = False
        Me.Name = "Payloads"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Payloads"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WebBrowser1 As System.Windows.Forms.WebBrowser
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PayloadDialogue As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnBrowse As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPayloadBox As System.Windows.Forms.TextBox
    Friend WithEvents btnAddToRamdisk As System.Windows.Forms.Button
    Friend WithEvents btnFinish As System.Windows.Forms.Button
End Class
