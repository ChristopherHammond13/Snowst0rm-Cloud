Public Class Main
    Public IPSW312Path As String
    Public IPSW40Path As String
    Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        System.Diagnostics.Process.Start("http://www.youtube.com/watch?v=bITIiGswjFI")
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub DFUModeHelpToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DFUModeHelpToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.youtube.com/watch?v=bITIiGswjFI")
    End Sub

    Private Sub btn312Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn312Browse.Click
        Open312IPSW.ShowDialog()
        txt312Path.Text = Open312IPSW.FileName
        IPSW312Path = Open312IPSW.FileName
        If Not txt312Path.Text = "" And Not txt40Path.Text = "" Then
            Button1.Enabled = True
        End If
    End Sub

    Private Sub btn40Browse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn40Browse.Click
        Open40IPSW.ShowDialog()
        txt40Path.Text = Open40IPSW.FileName
        IPSW40Path = Open40IPSW.FileName
        If Not txt312Path.Text = "" And Not txt40Path.Text = "" Then
            Button1.Enabled = True
        End If
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        About.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If txt312Path.Text = "" Or txt312Path.Text = "Cancel" Or txt40Path.Text = "" Or txt40Path.Text = "Cancel" Or txt312Path.Text = "iPod2,1_3.1.2_7D11_Restore.ipsw" Or txt40Path.Text = "iPod2,1_4.0_8A293_Custom_Restore.ipsw" Then
            MsgBox("Please browse for all IPSWs!", vbExclamation + vbApplicationModal, "Error")
        Else
            Dim ipsw312
            ipsw312 = txt312Path.Text.ToString()
            Dim SHA1Hash312 As String = CalculateSHA1(ipsw312).ToString()
            If SHA1Hash312.ToString() = "e7c83d4a5baec0e81816ae1cd1caf9a4dc38ebf0" Then
                '3.1.2IPSW passed SHA1 check :)
                Dim ipsw41 = txt40Path.Text.ToString()
                Dim SHA1Hash41 As String = CalculateSHA1(ipsw41).ToString()
                If SHA1Hash41.ToString() = "97abde6207660bd876fd476275dd526d0dcf3d19" Then
                    Shell("Cloud Jailbreak.exe make " + Chr(34) + txt40Path.Text + Chr(34) + " " + Chr(34) + txt312Path.Text + Chr(34), AppWinStyle.NormalFocus, True)
                    checkButtons()
                Else
                    MsgBox("4.0 IPSW is incorrect. Please select / download the correct one.", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Exclamation, "Error")
                End If
            Else
                MsgBox("3.1.2 IPSW is incorrect. Please select / download the correct one!", MsgBoxStyle.ApplicationModal + MsgBoxStyle.Exclamation, "Error")
            End If
            checkButtons()
        End If
    End Sub

    Private Sub btnJailbreak_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnJailbreak.Click
        ChDir(My.Application.Info.DirectoryPath)
        If FileIO.FileSystem.FileExists("WorkSpace\made") Then
            Shell("Cloud Jailbreak.exe jailbreak")
        Else
            MsgBox("Please perform step 3 first!", vbExclamation + vbApplicationModal, "Error")
        End If
    End Sub

    Private Sub btnBoot_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBoot.Click
        ChDir(My.Application.Info.DirectoryPath)
        If FileIO.FileSystem.FileExists("WorkSpace\made") Then
            Shell("Cloud Jailbreak.exe boot")
        Else
            MsgBox("Please Prepare the jailbreak first!", vbExclamation + vbApplicationModal, "Error")
        End If
    End Sub

    Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel2.LinkClicked
        System.Diagnostics.Process.Start("http://www.megaupload.com/?d=OYX1RLXG&f=iPod2,1_3.1.2_7D11_Restore.ipsw")
    End Sub

    Private Sub LinkLabel3_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles LinkLabel3.LinkClicked
        System.Diagnostics.Process.Start("http://appldnld.apple.com/iPhone4/061-7937.20100908.ghj4f/iPod2,1_4.1_8B117_Restore.ipsw")
    End Sub

    Private Sub WnTeamToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WnTeamToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://0wn-team.info")
    End Sub

    Private Sub Blackthund3rToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Blackthund3rToolStripMenuItem.Click
        System.Diagnostics.Process.Start("http://www.blackthund3r.co.uk")

    End Sub

    Private Sub WebsiteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WebsiteToolStripMenuItem.Click

    End Sub

    Private Sub Main_Dispose(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Disposed
        Startup.Dispose()
    End Sub

    Private Sub Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        checkButtons()
        If Not txt312Path.Text = "" Then
            If Not txt40Path.Text = "" Then
                Button1.Enabled = True
            Else
                Button1.Enabled = False
            End If
        Else
            Button1.Enabled = False
        End If
    End Sub

    Private Sub LibUSBInstallerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibUSBInstallerToolStripMenuItem.Click
        libUSBInstaller.Show()
    End Sub
    Public Function checkButtons()
        ChDir(My.Application.Info.DirectoryPath)
        If System.IO.File.Exists("WorkSpace\made") Then
            btnJailbreak.Enabled = True
            btnBoot.Enabled = True
        Else
            btnJailbreak.Enabled = False
            btnBoot.Enabled = False
        End If
        Return 0
    End Function
    ' utility function to convert a byte array into a hex string
    Private Function ByteArrayToString(ByVal arrInput() As Byte) As String

        Dim sb As New System.Text.StringBuilder(arrInput.Length * 2)

        For i As Integer = 0 To arrInput.Length - 1
            sb.Append(arrInput(i).ToString("X2"))
        Next

        Return sb.ToString().ToLower

    End Function

    Private Function CalculateSHA1(ByVal FilePath)
        Using reader As New System.IO.FileStream(FilePath, IO.FileMode.Open, IO.FileAccess.Read)
            Using sha1 As New System.Security.Cryptography.SHA1CryptoServiceProvider
                Dim hash() As Byte = sha1.ComputeHash(reader)
                Return ByteArrayToString(hash)
            End Using
        End Using
    End Function

    Private Sub PayloasToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PayloasToolStripMenuItem.Click
        Payloads.Show()
    End Sub
End Class
