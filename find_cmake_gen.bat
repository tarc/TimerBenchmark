@echo off
setlocal enabledelayedexpansion


rem set generator=Visual Studio 15 2017

rem set error_message=cmake -G "%generator%" ..

set name=%1
shift

set version=%1
shift

set error_message=cmake .. %1 %2 %3 %4 %5 %6 %7 %8 -DNAME=%name% -DVERSION=%version%
!error_message!

if NOT '!ERRORLEVEL!'=='0' goto fail


:success
	exit /b 0


:fail
	echo Something wrong during "!error_message!"
	exit /b 1
