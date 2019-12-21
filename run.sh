#!/bin/bash
# https://github.com/JeromeGsq/raspberry_pi-nanoleaf

sleep 1
echo "Run script './nano'"
sudo chmod 755 /home/pi/nanoleaf/raspberry_pi-nanoleaf/bin/Debug/netcoreapp3.1/linux-arm/publish/nano
sudo /home/pi/nanoleaf/raspberry_pi-nanoleaf/bin/Debug/netcoreapp3.1/linux-arm/publish/nano $1
