# raspberry_pi-nanoleaf

## Build on windows 10 with Powershell
dotnet publish -r linux-arm

## Deploy to raspberry pi with Powershell
scp -r .\bin\Debug\netcoreapp3.1\linux-arm\publish\ pi@192.168.1.36:~/nanoleaf

## Run on raspberry pi 
pi@raspberrypi:~/nanoleaf $ sudo ./publish/nano 
