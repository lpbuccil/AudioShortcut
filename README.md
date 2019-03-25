# AudioShortcut
## Info
AudioShortcut creates a pin-able shortcut that will switch the default playback device. This program uses NirCmd to switch devices. This program does not run in the background and only runs when it's executed.

This program works by downloading and unpacking NirCmd then creating a batch file to run with commands pointing at NirCmd. This batch file is not pin-able so a shortcut is created pointing at CMD.exe and these batch files. Thus creating a pin-able shortcut that can switch your playback devices.

When pinned to your taskbar, the shortcut will look like so
![alt text](https://github.com/lpbuccil/AudioShortcut/blob/master/Pictures/Taskbar.png "Screenshot 1")

![alt text](https://github.com/lpbuccil/AudioShortcut/blob/master/Pictures/Application.png "Screenshot 2")
