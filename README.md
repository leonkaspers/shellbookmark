# `shellbookmark` Documentation

## Overview

This program can save your current Working Directory in _cmd.exe_ using a bookmark. You then can access that Directory using the saved bookmark. You can add as many bookmarks as you want.

The bookmarks are saved using .json file. You can list and delete your bookmarks using the appropriate commands.

## Installation Guide

### Good to know

_This installation guide is quite silly, if there are any suggestions on how to make the installation smarter and safer, then keep them coming._

It is best to save all the files in the same folder, the one where the _.exe_ is stored that will be created at step 3 (building the solution). This folder must be entered in the [`Path`](https://www.computerhope.com/issues/ch000549.htm) system variable.

Unfortunately, relative paths do not work, because the actual working directory of the .exe is different depending on the directory in which the program is opened, so that the relative paths would constantly point to different locations, which is why absolute paths are necessary.

### How to install `shellbookmark`:

1. Clone the repository
2. Open the _Setup.cs_ file (line 13 an onward) and edit the `jsonPath` variable to represent the path where you want to save your bookmarks and the `dataPath` variable to represent the path where you want the data handling to happen. Additionally specify where you want to store your batch file by editing the `batchPath` variable.

```c#
//change the file paths to your desired system location. You don't have to change the file names.
//To makes thing easier use the same path for every file. 
//The folder where the files are saved must be in the PATH variable.
//change jsonPath to the location you want to save your bookmarks. Only absolute paths work.
string jsonPath = @"C:\Users\uif54017\Documents\Visual Studio 2019\shellbookmark5\shellbookmark5\bin\Debug\net5.0\shellbookmarkData.json";
//change dataPath to the location where you you want the data handling to happen. Only absolute paths work.
string dataPath = @"C:\Users\uif54017\Documents\Visual Studio 2019\shellbookmark5\shellbookmark5\bin\Debug\net5.0\shellbookmarkBatchData.txt";
//change batchPath to the location where you want the batch file, which handles the execution of the program, to be saved.
//Don't change the name.
string batchPath = @"C:\Users\uif54017\Documents\Visual Studio 2019\shellbookmark5\shellbookmark5\bin\Debug\net5.0\shellbookmark.bat";
```

3. Build the _shellbookmark_ Solution
4. run `shellbookmark5 setup` (the 5 is not a typo) command in _cmd_ (it creates the necessary batch file for you)

If you have completed all off the above steps and there is no bug or error or other dependency I overlooked, `shellbookmark` should work now.

## How to use shellbookmark

You can use _shellbookmark_ from every folder using cmd. Just type `shellbookmark` followed by one of the following commands:

- `save` [bookmark name]: saves current working directory under the name of [bookmark name]
- `go` (2 options)
  - `go [bookmark name]`: changes the working directory to the with [bookmark name] associated folder
  - `go [bookmark index]`: changes the working directory to the with [bookmark index] associated folder (you can look up the index using the `list` command)
- `list`: lists all saved bookmarks with an index number
- `delete` (2 options)
  - `delete [bookmark name]`: deletes the specified bookmark using it's name
  - `delete [bookmark index]`: deletes the specified bookmark using it's index (you can look up the index using the `list` command)
- `deleteall`: deletes all saved bookmarks
- `help`: shows the help text

## Examples

### Create bookmark

```dos
C:\Users\uif54017\Documents>shellbookmark save 
Documents
Path saved successfully.
```

### Jump to bookmark

```dos
C:\Users\uif54017\Documents\SAP>shellbookmark go Documents
C:\Users\uif54017\Documents>
```

### List bookmarks

```dos
C:\Users\uif54017\Documents\SAP>shellbookmark list       
 0 : User - C:\Users\uif54017
 1 : Documents - C:\Users\uif54017\Documents 
```

### Delete bookmark

```dos
C:\Users\uif54017\Documents\SAP\SAP GUI>shellbookmark delete 0
 User - C:\Users\uif54017 successfully deleted.

C:\Users\uif54017\Documents\SAP\SAP GUI>shellbookmark list
 0 : Documents - C:\Users\uif54017\Documents  
```
