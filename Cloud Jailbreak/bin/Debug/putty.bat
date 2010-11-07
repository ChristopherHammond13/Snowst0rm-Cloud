@ECHO OFF
cd %~pd0
regedit /s putty.reg
regedit /s puttyrnd.reg
start /w .\putty.exe -load Jailbreak -pw alpine
regedit /s PuttyRemove.reg
