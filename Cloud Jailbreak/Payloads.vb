Imports System.IO
Public Class Payloads
    Public PayloadPath As String
    Public SafePayloadFileName As String

    Private Sub btnBrowsr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ChDir(My.Application.Info.DirectoryPath)

        If File.Exists("Workspace\made") Then

            PayloadDialogue.ShowDialog()
            If Not PayloadDialogue.FileName = "" Or Nothing Then
                PayloadPath = PayloadDialogue.FileName
                txtPayloadBox.Text = PayloadPath
                SafePayloadFileName = PayloadDialogue.SafeFileName
                btnAddToRamdisk.Enabled = True
            End If
        Else
            MsgBox("Please prepare the jailbreak first!")
        End If
    End Sub

    Private Sub btnAddToRamdisk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddToRamdisk.Click
        ChDir(My.Application.Info.DirectoryPath)
        File.Copy(PayloadPath, "WorkSpace\Payloads\" + SafePayloadFileName, True)
        btnFinish.Enabled = True
        btnAddToRamdisk.Enabled = False
    End Sub

    Private Sub btnFinish_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinish.Click
        ChDir(My.Application.Info.DirectoryPath)
        doRamdisk("WorkSpace\cloudtemp.dmg", "WorkSpace\Payloads")
        btnFinish.Enabled = False
    End Sub
    Function GetFolderSize(ByVal DirPath As String, _
   Optional ByVal IncludeSubFolders As Boolean = True) As Long

        Dim lngDirSize As Long
        Dim objFileInfo As FileInfo
        Dim objDir As DirectoryInfo = New DirectoryInfo(DirPath)
        Dim objSubFolder As DirectoryInfo

        Try

            'add length of each file
            For Each objFileInfo In objDir.GetFiles()
                lngDirSize += objFileInfo.Length
            Next

            'call recursively to get sub folders
            'if you don't want this set optional
            'parameter to false 
            If IncludeSubFolders Then
                For Each objSubFolder In objDir.GetDirectories()
                    lngDirSize += GetFolderSize(objSubFolder.FullName)
                Next
            End If

        Catch Ex As Exception


        End Try

        Return lngDirSize
    End Function

    Private Sub Payloads_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MsgBox("The payloads section is buggy and probably won't work :| it is for advanced users ONLY until the ssues are ironed out.", MsgBoxStyle.Exclamation + vbApplicationModal + vbOKOnly, "Payloads")
    End Sub
End Class