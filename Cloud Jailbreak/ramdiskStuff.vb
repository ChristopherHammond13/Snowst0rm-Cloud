Imports System.IO

Module ramdiskStuff
    Public Function FolderSize(ByVal payloadFolder As String)

        Dim size As Integer = 0
        For Each foundFile As String In My.Computer.FileSystem.GetFiles(payloadFolder, FileIO.SearchOption.SearchAllSubDirectories, "*.*")
            Dim fInfo As New FileInfo(foundFile)
            size += fInfo.Length
        Next
        Return size
    End Function
    Public Function ramdiskResize(ByVal rdPath As String, ByVal payloadFolder As String)
        Dim payloadSize
        payloadSize = FolderSize(payloadFolder)
        'Dim rdOldSize As New FileInfo("WorkSpace\cloudtemp.dmg")
        'payloadSize += rdOldSize.Length
        payloadSize *= 1.05
        Shell("hfsplus.grow.exe " + Chr(34) + rdPath + Chr(34) + " grow " + payloadSize.ToString(), AppWinStyle.MaximizedFocus, True)
        Return 0
    End Function
    Public Function doRamdisk(ByVal ramdisk As String, ByVal payloadFolder As String)
        ChDir(My.Application.Info.DirectoryPath)
        Shell("rm -rf WorkSpace/cloudtemp.dmg WorkSpace/cloud.dmg WorkSpace/cloudtempold.dmg", AppWinStyle.Hide, True)
        Shell("bspatch.exe WorkSpace/018-7103-078.dec.dmg WorkSpace/cloudtemp.dmg WorkSpace/ramdisk.patch", AppWinStyle.Hide, True)
        ramdiskResize(ramdisk, payloadFolder)
        ChDir(My.Application.Info.DirectoryPath + "\WorkSpace")
        'Shell("..\hfsplus.exe cloudtemp.dmg rmall /Payloads", AppWinStyle.Hide, True)
        'Shell("..\hfsplus.exe cloudtemp.dmg mkdir /Payloads", AppWinStyle.Hide, True)
        Shell("..\hfsplus.exe cloudtemp.dmg addall ./Payloads/ /Payloads", AppWinStyle.Hide, True)
        'Shell("..\hfsplus.exe cloudtemp.dmg add ../Files/install /sbin/install", AppWinStyle.Hide, True)
        Shell("..\hfsplus.exe cloudtemp.dmg add ./filler /filler", AppWinStyle.Hide, True)
        Shell("..\hfsplus.exe cloudtemp.dmg add ./filler /filler2", AppWinStyle.Hide, True)
        Shell("..\xpwntool.exe cloudtemp.dmg cloud.dmg -t 41files\018-7103-078.dmg -k FBF443110EB11D8D1AACDBE39167DE09 -iv 58DF0D0655BBDDA2A0F1C09333940701", AppWinStyle.Hide, True)
        Return 0
    End Function
End Module
