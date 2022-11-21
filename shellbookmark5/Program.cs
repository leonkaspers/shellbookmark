using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace shellbookmark5
{
    //Handles the user input
    class Program
    {
        static void Main(string[] args)
        {
            //creating Variables
            string bookmarkName = "";
            string bookmarkPath = "";
            string bookmarkAction = "";

            //creating objects
            Setup setup = new Setup();
            Data data = new Data();

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

            //Main Switch
            switch (bookmarkAction)
            {
                case "setup":
                    setup.createBatchFile();
                    break;

                //saves the curren wdr witch given shortcut to the jsonfile
                case "save":
                    data.save(bookmarkName, bookmarkPath);

                    break;

                //change the wd to the saved folder
                case "go":
                    data.goName(bookmarkName);

                    break;

                //show all saved shortcuts
                case "list":
                    data.list();

                    break;

                //delete one specific bookmark
                case "delete":
                    int index = Convert.ToInt32(bookmarkName);
                    data.deleteIndex(index);
                    break;

                //delete all bookmarks
                case "deleteall":
                    data.deleteAll();
                    break;

                //show the help
                case "help":
                    Help.help();
                    break;

                //if the command was not recognized
                default:
                    Console.WriteLine("Please enter a valid command. For help please enter \"shellbookmark help\".");
                    break;
            }
        }
    }
}
