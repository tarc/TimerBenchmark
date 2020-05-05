@echo off
setlocal enabledelayedexpansion


set error_message=where cmake
!error_message! > NUL 2> NUL
if NOT '!ERRORLEVEL!'=='0' goto fail


set script_dir=%~dp0

set gen_dir=%script_dir%build

set project_name=timerbenchmark

set solution_file_name=%project_name%.sln

if "%1"=="" (
	if EXIST %gen_dir% if EXIST %gen_dir%\%solution_file_name% (
		goto success
	)
)


if EXIST %gen_dir% (
	set error_message=rmdir /s/q %gen_dir%
	!error_message!
	if NOT '!ERRORLEVEL!'=='0' goto fail
)


set error_message=mkdir %gen_dir%
!error_message!
if NOT '!ERRORLEVEL!'=='0' goto fail

pushd %gen_dir%


set error_message=call %script_dir%find_cmake_gen.bat %project_name%
!error_message!
if NOT '!ERRORLEVEL!'=='0' goto fail


:success
	exit /b 0


:fail
	echo Something wrong during "!error_message!"
	exit /b 1
