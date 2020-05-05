@echo off
setlocal enabledelayedexpansion


rem set generator=Visual Studio 15 2017

rem set error_message=cmake -G "%generator%" ..
set error_message=cmake .. -DNAME=%1 -DVERSION=0.0.1
!error_message!

if NOT '!ERRORLEVEL!'=='0' goto fail
