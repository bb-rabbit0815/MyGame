@echo off
pushd .
cd /d %~dp0

call bin\flatc.exe --csharp -o ../MyGamePrototype6/Assets/Scripts  schema\CharctorParametersSchema.fbs

popd