# CM3D2 DLC Checker V2.7

![](Screen_1.jpg)
App that checking which one DLC have been installed and not.
Always up-to-date if you have an internet connection and I'm still managing the repo.

![](Screen_2.jpg)
Listfile update disabled

![](Screen_3.jpg)
This screen reflects the choice of a custom listfile

![](Screen_4.jpg)
Obviously the current directory does not contain a valid game, so the program cannot do anything.
- make sure you use the correct DLC Checker for your game
- delete the ini file, to get default settings back

## Release Description
A rebuild of tankerch's Python Release, now complete rewritten in c#.
same core as my other build, com3d2_en_dlcchecker
list of dlcs up2date

## Components
1) CM3D2_DLC_Checker.exe
2) Listfile CM_NewListDLC.lst
3) Ini File CM3D2_DLC_Checker.ini
4) Custom Listfile MY_CM_NewListDLC.lst (optional) - You have to create this file yourself, if you want it.

## How to Use

1.  Download the latest release
2.  Run "CM3D2_DLC_Checker.exe"

--------------------------------------
The listfile will be downloaded each time you start dlc-checker (configurable)
If no ini-file exists, it will be created

The ini file supports several runtime-parameter:

** CM3D2_DLC_Checker.ini ** 

[DLCListFile]
- UpdateListFile=Yes
- MyDLCListFile=No

[CustomURL]
MyURL=https://my.url
UseMyURL=No

---------
UseCurrentDir
- If set to "No" The game directory is read from the registry (only valid when game is installed) (Default)
- "Yes" means the current directory is used (only valid if current dir is a game dir)

UpdateListFile
- If set to "Yes", the actual file CM_NewListDLC.lst is downloaded from Internet, overwriting current file! (Default)
- If set to "No", the current listfile stays untouched, so you can experiment with your list file

MyDLCListFile
- If set to "No", the standard listfile is used (Default)
- If set to "Yes", you can build a listfile from scratch, using another name. This means you can switch between 2 configurations

Custom URL
- You can use your own url to search for a listfile

----------

Hint: If you screwed up your listfile or ini file, simply delete them... 
