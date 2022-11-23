using System;
using System.Text.RegularExpressions;

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
            int bookmarkIndex = -1;

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

            //Bookmark or Index
            string pattern = "^[0-9]+$";
            Regex rg = new Regex(pattern);
            if (rg.IsMatch(bookmarkName) == true)
            {
                bookmarkIndex = Convert.ToInt32(bookmarkName);
                bookmarkAction = bookmarkAction + "I";
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

                //change the wd to the saved folder using name
                case "go":
                    data.goName(bookmarkName);
                    break;

                //change the wd to the saved folder using index
                case "goI":
                    data.goIndex(bookmarkIndex);
                    break;

                //show all saved shortcuts
                case "list":
                    data.list();
                    break;

                case "delete":
                    data.deleteName(bookmarkName);
                    break;

                //delete one specific bookmark using Index
                case "deleteI":
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
