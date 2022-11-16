using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace shellbookmark5
{
    //Handles the Saving and Reading of saved Folders and tries to jump to them
    class Program
    {
        static void Main(string[] args)
        {
            //creating Variables
            string bookmarkName = "";
            string bookmarkPath = "";
            string bookmarkAction = "";
            string fileJson;
            List<Folder> folderList = new List<Folder>();


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


            //check if given argumentes ar correct and valid
            try
            {
                if (args.Length == 2)
                {
                    bookmarkName = args[1];
                    bookmarkPath = Environment.CurrentDirectory;
                    bookmarkAction = args[0];
                }

                if (args.Length == 1)
                {
                    bookmarkAction = args[0];
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The given arguments are wrong and/or incomplete.");
                return;
            }

            //imports the saved folders from a json file, creates objects of those folders and saves them to a list
            try
            {
                string jsonData = File.ReadAllText(jsonPath);
                folderList.AddRange(JsonSerializer.Deserialize<IList<Folder>>(jsonData));
            }
            catch (Exception)
            {
                Console.WriteLine("json File corrupted or not available. A new file will be created.");
            }

            //Main Switch
            switch (bookmarkAction)
            {
                case "setup":
                    string batchFile = "@echo off\n\nset arg1=%1\nset arg2=%2\n\nstart /w /b shellbookmark5 %arg1% %arg2%\n\nif %arg1% == go set /p bookmark =< \"" + dataPath + "\"\nif %arg1% == go cd %bookmark%";

                    File.WriteAllText(batchPath, batchFile);
                    break;

                //saves the curren wdr witch given shortcut to the jsonfile
                case "save":
                    bool alreadyExists = false;

                    //checks wheter the given shortcut or path do already exist (programm could be improved)
                    foreach (var item in folderList)
                    {
                        if (item.folderName == bookmarkName)
                        {
                            Console.WriteLine("this folder name already exists, please rename your folder");
                            alreadyExists = true;

                        }

                        if (item.folderPath == bookmarkPath)
                        {
                            Console.WriteLine("this path already exists under the bookmark {0}.", item.folderName);
                            alreadyExists = true;
                            break;
                        }
                    }

                    //if its a new shortcut its saved to the json file
                    if (alreadyExists == false)
                    {
                        Folder folder = new Folder() { folderName = bookmarkName, folderPath = bookmarkPath };

                        folderList.Add(folder);

                        var opt = new JsonSerializerOptions() { WriteIndented = true };
                        fileJson = JsonSerializer.Serialize<IList<Folder>>(folderList, opt);

                        File.WriteAllText(jsonPath, fileJson);

                        Console.WriteLine("Path saved successfully.");
                    }

                    break;

                //change the wd to the saved folder
                case "go":
                    bool doesFolderExist = false;

                    for (int i = 0; i < folderList.Count; i++)
                    {
                        if (folderList[i].folderName == bookmarkName)
                        {
                            string command = "/d \"" + folderList[i].folderPath + "\"";
                            File.WriteAllText(dataPath, command);

                            doesFolderExist = true;
                        }
                    }

                    if (doesFolderExist == false)
                    {
                        Console.WriteLine("This bookmark does not exist.");
                        File.WriteAllText(dataPath
                            , "");
                    }

                    break;

                //show all saved shortcuts
                case "list":
                    for (int i = 0; i < folderList.Count; i++)
                    {
                        Console.WriteLine(" {0} : {1} - {2}", i, folderList[i].folderName, folderList[i].folderPath);

                    }

                    break;

                //delete one specific bookmark
                case "delete":
                    int index = Convert.ToInt32(bookmarkName);
                    Console.WriteLine(" {0} - {1} successfully deleted.", folderList[index].folderName, folderList[index].folderPath);
                    folderList.RemoveAt(index);

                    var opt1 = new JsonSerializerOptions() { WriteIndented = true };
                    fileJson = JsonSerializer.Serialize<IList<Folder>>(folderList, opt1);

                    File.WriteAllText(jsonPath, fileJson);
                    break;

                //delete all bookmarks
                case "deleteall":
                    folderList.Clear();

                    fileJson = "{}";

                    File.WriteAllText(jsonPath, fileJson);
                    break;

                //show the help
                case "help":
                    Console.WriteLine("Help:\nThis programm can save your current Working Directory using a shortcut. You then can access that Directory using the shortcut.\nAvailable Commands:\n -save[shortcut]: save current working directory under the name of[shortcut]\n -go[shortcut]: changes the working directory to the with[shortcut] associated folder\n -list: lists all saved folders\n -delete[index]: deletes the specified shortcut\n -deleteall: deletes all saved shortcuts\n -help: shows the help text");
                    break;

                //if the command was not recognized
                default:
                    Console.WriteLine("Please enter a valid command. For help please enter \"shellbookmark help\".");
                    break;
            }
        }
    }
}
