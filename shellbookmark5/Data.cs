using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace shellbookmark5
{
    class Data
    {
        List<Bookmark> folderList = new List<Bookmark>();
        string fileJson;

        Setup setup = new Setup();

        public Data()
        {
            try
            {
                string jsonData = File.ReadAllText(setup.jsonPath);
                folderList.AddRange(JsonSerializer.Deserialize<IList<Bookmark>>(jsonData));
            }
            catch (Exception)
            {
                Console.WriteLine("JSON File corrupted or not available. A new file will be created.");
            }
        }


        public void save(string bookmarkName, string bookmarkPath)
        {
            bool alreadyExists = false;

            //checks wheter the given shortcut or path do already exist (programm could be improved)
            foreach (var item in folderList)
            {
                if (item.folderName == bookmarkName)
                {
                    Console.WriteLine("This bookmark already exists, please rename your bookmark");
                    alreadyExists = true;

                }

                if (item.folderPath == bookmarkPath)
                {
                    Console.WriteLine("This path already exists under the bookmark {0}.", item.folderName);
                    alreadyExists = true;
                    break;
                }
            }

            //if its a new shortcut its saved to the json file
            if (alreadyExists == false)
            {
                Bookmark folder = new Bookmark() { folderName = bookmarkName, folderPath = bookmarkPath };

                folderList.Add(folder);

                var opt = new JsonSerializerOptions() { WriteIndented = true };
                fileJson = JsonSerializer.Serialize<IList<Bookmark>>(folderList, opt);

                File.WriteAllText(setup.jsonPath, fileJson);

                Console.WriteLine("Path saved successfully.");
            }
        }

        public void goName(string bookmarkName)
        {
            bool doesFolderExist = false;

            for (int i = 0; i < folderList.Count; i++)
            {
                if (folderList[i].folderName == bookmarkName)
                {
                    string command = "/d \"" + folderList[i].folderPath + "\"";
                    File.WriteAllText(setup.dataPath, command);

                    doesFolderExist = true;
                }
            }

            if (doesFolderExist == false)
            {
                Console.WriteLine("This bookmark does not exist.");
                File.WriteAllText(setup.dataPath, "");
            }
        }

        public void goIndex(int index)
        {
            if (folderList.Count >= index && index >= 0)
            {
                string command = "/d \"" + folderList[index].folderPath + "\"";
                File.WriteAllText(setup.dataPath, command);
            }
            else
            {
                Console.WriteLine("This bookmark does not exist (index out of range). Only inputs between 0 and {0} are valid.", folderList.Count);
                File.WriteAllText(setup.dataPath, "");
            }
        }

        public void list()
        {
            for (int i = 0; i < folderList.Count; i++)
            {
                Console.WriteLine(" {0} : {1} - {2}", i, folderList[i].folderName, folderList[i].folderPath);
            }
        }

        public void deleteName(string bookmarkName)
        {
            bool doesFolderExist = false;

            for (int i = 0; i < folderList.Count; i++)
            {
                if (folderList[i].folderName == bookmarkName)
                {
                    Console.WriteLine(" {0} - {1} successfully deleted.", folderList[i].folderName, folderList[i].folderPath);
                    folderList.RemoveAt(i);

                    var opt1 = new JsonSerializerOptions() { WriteIndented = true };
                    fileJson = JsonSerializer.Serialize<IList<Bookmark>>(folderList, opt1);

                    File.WriteAllText(setup.jsonPath, fileJson);

                    doesFolderExist = true;
                }
            }

            if (doesFolderExist == false)
            {
                Console.WriteLine("This bookmark does not exist.");
            }
        }

        public void deleteIndex(int index)
        {
            Console.WriteLine(" {0} - {1} successfully deleted.", folderList[index].folderName, folderList[index].folderPath);
            folderList.RemoveAt(index);

            var opt1 = new JsonSerializerOptions() { WriteIndented = true };
            fileJson = JsonSerializer.Serialize<IList<Bookmark>>(folderList, opt1);

            File.WriteAllText(setup.jsonPath, fileJson);
        }

        public void deleteAll()
        {
            folderList.Clear();

            fileJson = "{}";

            File.WriteAllText(setup.jsonPath, fileJson);
        }
    }
}
