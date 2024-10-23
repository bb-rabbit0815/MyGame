@echo off
pushd .
cd /d %~dp0

call bin\flatc.exe --csharp -o ../MyGamePrototype6/Assets/Scripts  schema\Entry.fbs
call bin\flatc.exe --csharp -o ../MyGamePrototype6/Assets/Scripts  schema\Character.fbs
call bin\flatc.exe --csharp -o ../MyGamePrototype6/Assets/Scripts  schema\Facilities.fbs
call bin\flatc.exe --csharp -o ../MyGamePrototype6/Assets/Scripts  schema\Brothel.fbs


popd