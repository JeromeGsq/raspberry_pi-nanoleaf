# raspberry_pi-nanoleaf

## Create ssh key on windows 10 with Powershell
PS C:\WINDOWS\system32> ssh-keygen

## Get windows ssh-key 
PS C:\WINDOWS\system32> cat ~/.ssh/id_rsa.pub

## Copy & paste windows ssh-key to remote 
copy windows ssh-key inside this file (on remote) : ~/.ssh/authorized_keys
____

## Build on windows 10 with Powershell
PS C:\WINDOWS\system32> dotnet publish -r linux-arm

## Deploy to raspberry pi with Powershell
PS C:\WINDOWS\system32> scp -r .\bin\Debug\netcoreapp3.1\linux-arm\publish\ pi@192.168.1.36:~/nanoleaf

## Run on raspberry pi 
pi@raspberrypi:~/nanoleaf $ sudo ./publish/nano 


___

## You can run remotely with SSHFS
PS C:\WINDOWS\system32> dotnet publish -r linux-arm; ssh pi@192.168.1.36 "/home/pi/nanoleaf/raspberry_pi-nanoleaf/run.sh"
