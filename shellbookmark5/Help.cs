using System;
using System.Diagnostics;

namespace shellbookmark5
{
    public static class Help
    {
        public static void help()
        {
            ShowHelp();

            Console.WriteLine("If you need further help, please press i. If your question was answered, please press any key.");

            var key = Console.ReadKey();

            if (key.Key.Equals(ConsoleKey.I))
            {
                OpenHelp();
            }
        }

        public static void ShowHelp()
        {
            Console.WriteLine("You can use _shellbookmark_ from every folder using cmd. Just type shellbookmark followed by one of the following commands:\n");
            Console.WriteLine("- save [bookmark name]: saves current working directory under the name of [bookmark name]");
            Console.WriteLine("- go (2 options)");
            Console.WriteLine("- go [bookmark name]: changes the working directory to the with [bookmark name] associated folder");
            Console.WriteLine("\t- go [bookmark name]: changes the working directory to the with [bookmark name] associated folder");
            Console.WriteLine("\t- go [bookmark index]: changes the working directory to the with [bookmark index] associated folder (you can look up the index using the list command)");
            Console.WriteLine("- list: lists all saved bookmarks with an index number");
            Console.WriteLine("- delete (2 options)");
            Console.WriteLine("\t- delete [bookmark name]: deletes the specified bookmark using it's name");
            Console.WriteLine("\t- delete [bookmark index]: deletes the specified bookmark using it's index (you can look up the index using the list command)");
            Console.WriteLine("- deleteall: deletes all saved bookmarks");
            Console.WriteLine("- help: shows the help text");
        }

        public static void OpenHelp()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/leonkaspers/shellbookmark#how-to-use-shellbookmark",
                UseShellExecute = true
            });
        }
    }
}
