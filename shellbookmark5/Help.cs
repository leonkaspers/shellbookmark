using System;
using System.Diagnostics;

namespace shellbookmark5
{
    public static class Help
    {
        public static void showHelp()
        {
            Console.WriteLine("You can use _shellbookmark_ from every folder using cmd. Just type shellbookmark followed by one of the following commands:\n");
            Console.WriteLine("- save [bookmark name]: saves current working directory under the name of [bookmark name]");
            Console.WriteLine("- go [bookmark name]: changes the working directory to the with [bookmark name] associated folder");
            Console.WriteLine("- list: lists all saved bookmarks with an index number");
            Console.WriteLine("- delete[index]: deletes the specified bookmark");
            Console.WriteLine("- deleteall: deletes all saved bookmarks");
            Console.WriteLine("- help: shows the help text");

            Console.WriteLine("If you need further help, please press i. If your question was answered, please press any key.");

            var key = Console.Read();

            if (key == 105)
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/leonkaspers/shellbookmark#how-to-use-shellbookmark",
                    UseShellExecute = true
                });
            }
        }

        public static void openHelp()
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = "https://github.com/leonkaspers/shellbookmark#how-to-use-shellbookmark",
                UseShellExecute = true
            });
        }
    }
}
