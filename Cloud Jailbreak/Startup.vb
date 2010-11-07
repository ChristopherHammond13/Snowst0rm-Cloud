Imports Microsoft
Imports Microsoft.WindowsAPICodePack.Taskbar
Imports Microsoft.WindowsAPICodePack.Shell
Imports System.IO

Public Class Startup

    Private Sub Startup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ChDir(My.Application.Info.DirectoryPath)
        If My.Application.CommandLineArgs.Count > 0 Then
            If My.Application.CommandLineArgs(0) = "jailbreak" Or My.Application.CommandLineArgs(0) = "cloudstorm://jailbreak/" Then
                Dim i = MsgBox("Is libUSB installled?", vbInformation + vbApplicationModal + vbYesNo, "libUSB")
                If i = MsgBoxResult.Yes Then
                    Status.Text = "Jailbreaking..."
                    Shell("jailbreak.bat", , True)
                    Shell("itunnel.exe", AppWinStyle.Hide, False)
                    Shell("putty.bat", AppWinStyle.MaximizedFocus, True)
                    Dim pProcess() As Process = System.Diagnostics.Process.GetProcessesByName("itunnel.exe")
                    For Each p As Process In pProcess
                        p.Kill()
                        p.CloseMainWindow()
                    Next
                    End
                Else
                    MsgBox("Don't worry - you can install libUSB using the libUSB installer in the file menu!", vbInformation + vbApplicationModal, "libUSB")
                    End
                End If

            ElseIf My.Application.CommandLineArgs(0) = "make" Then
                ChDir(My.Application.Info.DirectoryPath)
                Status.Text = "Making..."
                Shell("rm -rf WorkSpace", AppWinStyle.Hide, True)
                MkDir("WorkSpace")
                ChDir("WorkSpace")
                Shell("..\unzip.exe -o " + Chr(34) + My.Application.CommandLineArgs(1) + Chr(34) + " -d 41files -x 018-7058-113.dmg", AppWinStyle.MaximizedFocus, True)
                Shell("..\unzip.exe -o " + Chr(34) + My.Application.CommandLineArgs(2) + Chr(34) + " -d . Firmware/dfu/*", AppWinStyle.MaximizedFocus, True)
                ChDir(My.Application.Info.DirectoryPath)
                Shell("make.bat", AppWinStyle.MaximizedFocus, True)
                'ramdiskStuff.doRamdisk("WorkSpace\cloudtemp.dmg", "WorkSpace\Payloads")
                ChDir(My.Application.Info.DirectoryPath)
                ChDir("WorkSpace")
                'Shell("..\rm -rf cloudtemp.dmg cloud.dmg", AppWinStyle.Hide, True)
                Shell("..\bspatch.exe 018-7103-078.dec.dmg cloudtemp.dmg ramdisk.patch", AppWinStyle.Hide, True)
                Shell("..\hfsplus.exe cloudtemp.dmg add ./filler /filler", AppWinStyle.Hide, True)
                Shell("..\hfsplus.exe cloudtemp.dmg add ./filler /filler2", AppWinStyle.Hide, True)
                Shell("..\xpwntool.exe cloudtemp.dmg cloud.dmg -t 41files\018-7103-078.dmg -k FBF443110EB11D8D1AACDBE39167DE09 -iv 58DF0D0655BBDDA2A0F1C09333940701", AppWinStyle.Hide, True)
                End
            ElseIf My.Application.CommandLineArgs(0) = "boot" Or My.Application.CommandLineArgs(0) = "cloudstorm://boot/" Then
                Status.Text = "Booting..."
                Dim i = MsgBox("Is libUSB installled?", vbInformation + vbApplicationModal + vbYesNo, "libUSB")
                If i = MsgBoxResult.Yes Then
                    System.Diagnostics.Process.Start("Boot.bat")
                    MsgBox("Your iPod Touch Should now be booting! Enjoy!", vbInformation + vbApplicationModal, "Success!")
                    End
                Else
                    MsgBox("Don't worry - you can install libUSB using the libUSB installer in the file menu!", vbInformation + vbApplicationModal, "libUSB")
                    End
                End If
            ElseIf My.Application.CommandLineArgs(0) = "cloudstorm://make/" Then
                MsgBox("This option must be done from the GUI", vbApplicationModal + vbOKOnly + vbExclamation, "Cloud")
                Main.Show()
            Else
                Main.Show()
            End If
            Else
                Main.Show()
                If MS.WindowsAPICodePack.Internal.CoreHelpers.RunningOnWin7 Then
                    ChDir(My.Application.Info.DirectoryPath)
                    Dim JList As JumpList
                    JList = JumpList.CreateJumpList()
                    JList.ClearAllUserTasks()

                    'Add 2 Links to the Usertasks with a Separator
                    'Dim Category As New JumpListCustomCategory("Jailbreak now!")
                    My.Computer.FileSystem.CurrentDirectory = My.Application.Info.DirectoryPath
                    Dim Link0 As New JumpListLink(My.Application.Info.DirectoryPath + "\jailbreakLoader.bat", "Jailbreak")
                    Dim Link1 As New JumpListLink(My.Application.Info.DirectoryPath + "\bootLoader.bat", "Boot")
                JList.AddUserTasks(Link0)
                    JList.AddUserTasks(New JumpListSeparator())
                    JList.AddUserTasks(Link1)

                    'to control which category Recent/Frequent is displayed 
                    JList.KnownCategoryToDisplay = JumpListKnownCategoryType.Neither

                    JList.Refresh()
                End If
            End If
    End Sub

End Class