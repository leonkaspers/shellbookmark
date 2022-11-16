@echo off

set arg1=%1
set arg2=%2

start /w /b shellbookmark5 %arg1% %arg2%

if %arg1% == go set /p bookmark=< "C:\Users\uif54017\Documents\Visual Studio 2019\shellbookmark5\shellbookmark5\bin\Debug\net5.0\shellbookmarkBatchData.txt"
if %arg1% == go cd %bookmark%







