@echo off
REM My kick-ass boot script. P.S. Why are you reading this high-class top-secret info??????
irecovery -x WorkSpace/stage1

sleep 4 /quiet

irecovery -k WorkSpace/stage1.exploit

sleep 1 /quiet

irecovery -f WorkSpace/stage2

sleep 1 /quiet

irecovery -c "go"

sleep 3 /quiet

irecovery -r

sleep 4 /quiet

irecovery -f Files/bootlogo.img3
irecovery -c "setpicture 0"
irecovery -c "bgcolor 20 40 128"

sleep 1 /quiet

irecovery -f WorkSpace/devtree
irecovery -c devicetree

sleep 1 /quiet

irecovery -r

sleep 3 /quiet

irecovery -f WorkSpace/kernel

irecovery -c "bootx 0x09000000"