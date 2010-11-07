Public Class libUSBInstaller

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ChDir(My.Application.Info.DirectoryPath)
        Dim arch = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE")
        Shell("libUSB-Win32\" + arch + "\install-filter.exe -i -v")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        ChDir(My.Application.Info.DirectoryPath)
        Dim arch = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE")
        Shell("libUSB-Win32\" + arch + "\install-filter.exe -u -v")
    End Sub
End Class