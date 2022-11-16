

# Overview

This program can save your current Working Directory in cmd.exe using a bookmark. You then can access that Directory using the saved bookmark. You can add as many bookmarks as you want.

The bookmarks are saved using .json file. You can list and delete your bookmarks using the appropriate commands.

# Installation Guide

This installation guide is quite silly, if there are any suggestions on how to make the installation smarter and safer, then keep them coming.

It is best to save all the files in the same folder, the one where the .exe is stored that will be created at step 3. This folder must be entered in the "Path" system variable.

Unfortunately, relative paths do not work, because the actual working directory of the .exe is different depending on the directory in which the program is opened, so that the relative paths would constantly point to different locations, which is why absolute paths are necessary.

1. Download the repository from [leonkaspers/shellbookmark: Little programm to save cmd paths (github.com)](https://github.com/leonkaspers/shellbookmark)
2. Open the _Program.cs_ (line 21 an onward) file and edit the jsonPath Variable to represent the path where you want to save your bookmarks and the dataPath Variable to represent the path where you want the data handling to happen.
```
//change the file paths to your desired system location. You don't have to change the file names.
//To makes thing easier use the same path for every file. 
//The folder where the files are saved must be in the PATH variable.
//change jsonPath to the location you want to save your bookmarks. Only absolute paths work.
string jsonPath = @"C:\Users\uif54017\Documents\Visual Studio 2019\shellbookmark5\shellbookmark5\bin\Debug\net5.0\shellbookmarkData.json";
//change dataPath to the location where you you want the data handling to happen. Only absolute paths work.
string dataPath = @"C:\Users\uif54017\Documents\Visual Studio 2019\shellbookmark5\shellbookmark5\bin\Debug\net5.0\shellbookmarkBatchData.txt";
//change batchPath to the location where you want the batch file, which handles the exection, to be saved.
//Don't change the name.
string batchPath = @"C:\Users\uif54017\Documents\Visual Studio 2019\shellbookmark5\shellbookmark5\bin\Debug\net5.0\shellbookmark.bat";
```

3. Build the _shellbookmark_ Solution
4. Open the _shellbookmark.bat_ file and edit the bookmark path in line 8 to equal dataPath (step 2b)
```
if %arg1% == go set /p bookmark=< "C:\Users\uif54017\Documents\Visual Studio 2019\shellbookmark5\shellbookmark5\bin\Debug\net5.0\shellbookmarkBatchData.txt"
```


5. Save the _shellbookmark.bat_ file into the folder where your _.exe_ was built.

If you have completed all off the above steps and there is no bug or error or other dependency I overlooked, _shellbookmark_ should work now.

# How to use shellbookmark

You can use _shellbookmark_ from every folder using cmd. Just type shellbookmark followed by one of the following commands:

- save [bookmark name]: saves current working directory under the name of [bookmark name]
- go [bookmark name]: changes the working directory to the with [bookmark name] associated folder
- list: lists all saved bookmarks with an index number
- delete[index]: deletes the specified bookmark
- deleteall: deletes all saved bookmarks
- help: shows the help text

# Examples

## Create bookmark

```
C:\Users\uif54017\Documents>shellbookmark save 
Documents
Path saved successfully.
```

## Jump to bookmark

```
C:\Users\uif54017\Documents\SAP>shellbookmark go Documents
C:\Users\uif54017\Documents>
```

## List bookmarks

```
C:\Users\uif54017\Documents\SAP>shellbookmark list       
 0 : User - C:\Users\uif54017
 1 : Documents - C:\Users\uif54017\Documents 
```

## Delete bookmark

```
C:\Users\uif54017\Documents\SAP\SAP GUI>shellbookmark delete 0
 User - C:\Users\uif54017 successfully deleted.

C:\Users\uif54017\Documents\SAP\SAP GUI>shellbookmark list
 0 : Documents - C:\Users\uif54017\Documents  
```
