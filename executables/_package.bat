@echo off

set VER=20260923

del grif-win-x64-*.zip

copy /y ..\LICENSE.txt win-x64

copy /y ..\README.md win-x64

7z.exe a -tzip grif-win-x64-%VER%.zip win-x64

pause
