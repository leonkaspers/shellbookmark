using System.IO;

namespace shellbookmark5
{
    public class Setup
    {
        public string jsonPath { get; private set; } 
        public string dataPath { get; private set; }
        string batchPath;

        public Setup()
        {
            //change the file paths to your desired system location. You don't have to change the file names.
            //To makes thing easier use the same path for every file. 
            //The folder where the files are saved must be in the PATH variable.
            //change jsonPath to the location you want to save your bookmarks. Only absolute paths work.
            jsonPath = @"C:\Users\uif54017\Documents\Visual Studio 2019\shellbookmark5\shellbookmark5\bin\Debug\net5.0\shellbookmarkData.json";

            //change dataPath to the location where you you want the data handling to happen. Only absolute paths work.
            dataPath = @"C:\Users\uif54017\Documents\Visual Studio 2019\shellbookmark5\shellbookmark5\bin\Debug\net5.0\shellbookmarkBatchData.txt";

            //change batchPath to the location where you want the batch file, which handles the exection, to be saved.
            //Don't change the name.
            batchPath = @"C:\Users\uif54017\Documents\Visual Studio 2019\shellbookmark5\shellbookmark5\bin\Debug\net5.0\shellbookmark.bat";
        }
        
        public void createBatchFile()
        {
            string batchFile = "@echo off\n\nset arg1=%1\nset arg2=%2\n\nstart /w /b shellbookmark5 %arg1% %arg2%\n\nif %arg1% == go set /p bookmark=<\"" + dataPath + "\"\nif %arg1% == go cd %bookmark%";

            File.WriteAllText(batchPath, batchFile);
        }

    }
}
