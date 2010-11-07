REM My amazing make script. P.S. Why are you reading this high-class top-secret info??????
@echo on
cd WorkSpace
REM ::..\unzip.exe -o "%1" -d 41files -x "018-7058-113.dmg"
REM ::..\unzip.exe -o "%2" "Firmware/dfu/*" "Firmware/all_flash/all_flash.n72ap.production/iBoot.n72ap.RELEASE.img3" 
REM ::..\7za.exe e "%1" 018-7058-113.dmg

..\cp.exe ./Firmware/dfu/iBSS.n72ap.RELEASE.dfu ./iBSS_3.1.2.img3
..\cp.exe ./41files/kernelc* ./kernel
..\cp.exe ./Firmware/dfu/iBEC.n72ap.RELEASE.dfu ./iBEC_3.1.2.img3
..\cp.exe ./41files/Firmware/dfu/iBSS.n72ap.RELEASE.dfu ./iBSS_4.0.img3
..\cp.exe ./41files/Firmware/dfu/iBEC.n72ap.RELEASE.dfu ./iBEC_4.0.img3
..\cp.exe ./41files/Firmware/all_flash/all_flash.n72ap.production/DeviceTree.n72ap.img3 ./devtree
..\cp.exe ../Files/filler ./filler

..\cp.exe ../Files/*.patch .
..\cp.exe ../Files/*.diff .
md Payloads
REM ..\cp.exe ../Files/Payloads/* ./Payloads

..\bspatch.exe devtree devtreep devtree.patch
..\rm.exe devtree
..\mv.exe devtreep devtree

..\xpwntool.exe 41files\018-7103-078.dmg 018-7103-078.dec.dmg -k FBF443110EB11D8D1AACDBE39167DE09 -iv 58DF0D0655BBDDA2A0F1C09333940701
REM ..\bspatch.exe 018-7103-078.dec.dmg cloudtempold.dmg ramdisk.patch
REM ..\bspatch.exe cloudtempold.dmg cloudtemp.dmg ramdisk2.patch
REM ..\hfsplus.exe cloudtemp.dmg rmall /Payloads
REM ..\hfsplus.exe cloudtemp.dmg mkdir /Payloads
REM ..\hfsplus.exe cloudtemp.dmg addall ./Payloads/ /Payloads
REM ..\xpwntool.exe cloudtemp.dmg cloud.dmg -t 41files\018-7103-078.dmg -k FBF443110EB11D8D1AACDBE39167DE09 -iv 58DF0D0655BBDDA2A0F1C09333940701

..\xpwntool.exe ./kernel ./kerneldec -iv 57D4E27152D39AF674492EB0A8252DE3 -k 7C07730B6CEB8B217653FF5161988B24
REM ..\bspatch.exe ./kerneldec ./kpwn ./kerneldec.patch
REM ..\bspatch.exe ./kpwn ./pwnedkernel ./newkernel.patch
REM ..\xpwntool.exe ./pwnedkernel ./kernel.patched -t ./kernel -iv 57D4E27152D39AF674492EB0A8252DE3 -k 7C07730B6CEB8B217653FF5161988B24
..\bspatch.exe ./kerneldec ./kernel ./kernel.patch
REM ..\mv.exe kernel kernel.old
REM ..\mv.exe kernel.patched kernel

..\xpwntool.exe ./iBSS_3.1.2.img3 ./iBSS312.dec -iv 083528a985c2e3f90f8324e1e9dce4e4 -k c7af1cfc980b24e2464b70310e2b1713
..\dd.exe if=./iBSS312.dec bs=8192 count=1 > ib8k
..\bspatch.exe ./ib8k ./iBSS_PYLD.img3 ./payload.diff
..\rm.exe -rf ib8k
..\xpwntool.exe ./41files/Firmware/dfu/iBEC.n72ap.RELEASE.dfu ./decbec -k 7341C6FB2CC09FE6D43067F7E426F708 -iv 40CECF39BC971DCE828415C7DFFCE3EA

..\bspatch.exe decbec decbecp decbec.patch
..\bspatch.exe decbecp decbecp2 newibec.patch
REM ..\bspatch.exe decbecp2 decbecp3 iBECImages.patch
REM ..\bspatch.exe decbecp decbecp2 iBEC.patch

REM 3.1.2 iBEC
REM Original Line
REM ..\xpwntool.exe ./decbecp ./iBWN.img3 -t ./Firmware/dfu/iBEC.n72ap.RELEASE.dfu -k 441af1d3003f2e4005f055d170b0b92c -iv 1f5c5fcb7d46946e5062a4b3addfc767
REM New command:
..\xpwntool.exe ./decbecp2 ./iBWN.img3 -t ./Firmware/dfu/iBEC.n72ap.RELEASE.dfu -ka2f0497c17e7181705c002f1b1c8edcf -iv0551d6bca63f6e458d65d0e308a4a676

move ./iBSS_3.1.2.img3 ./stage1
move ./iBSS_PYLD.img3 ./stage1.exploit
move ./iBWN.img3 ./stage2

echo made >> made