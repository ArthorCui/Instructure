::@echo off
set file_source=%1
set fileName=%2

:: check if the file exist 
if not exist %fileName% (
	:: echo not exist file , prepare to rar
	echo %file_source%
	if exist %file_source% call :rar %file_source% %fileName%
	)

goto :eof

:rar
set source=%1
set target=%2
set rar_exe=C:\Program Files (x86)\WinRAR\winrar.exe
call "%rar_exe%" a -ep1 %target%.rar %source%

goto :eof
