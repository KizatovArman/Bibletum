using System;
using System.IO;

namespace FarManager
{
    class Program
    {
        public static void ShowDirectoryInfo(DirectoryInfo directory, int cursor)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.Clear();

            FileSystemInfo[] fileSystemInfos = directory.GetFileSystemInfos();

            for (int index = 0; index < fileSystemInfos.Length; index++)
            {
                FileSystemInfo fileSystemInfo = fileSystemInfos[index];
                if (index == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                }
                else 
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }

                if (fileSystemInfo.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                }

                Console.WriteLine(fileSystemInfo.Name);
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo directory_Info = new DirectoryInfo(@"/Users/arman/Documents/Bibletum");

            int cursor = 0;
            int l = directory_Info.GetFileSystemInfos().Length;
            ShowDirectoryInfo(directory_Info,cursor);

            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor == -1)
                    {
                        cursor = l - 1;
                    }
                }

                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == l)
                    {
                        cursor = 0;
                    }
                }

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    if (directory_Info.GetFileSystemInfos()[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        directory_Info = new DirectoryInfo(directory_Info.GetFileSystemInfos()[cursor].FullName);
                        cursor = 0;
                        l = directory_Info.GetFileSystemInfos().Length;
                    }
                    else
                    {
                        StreamReader sr = new StreamReader(directory_Info.GetFileSystemInfos()[cursor].FullName);
                        string s = sr.ReadToEnd();
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine(s);
                        Console.ReadKey();
                    }
                }
                if (keyInfo.Key == ConsoleKey.Escape )
                {
                    if (directory_Info.Parent != null)
                    {
                        directory_Info = directory_Info.Parent;
                        cursor = 0;
                        l = directory_Info.GetFileSystemInfos().Length;
                    }
                    else
                        break;
                }
                if (keyInfo.Key == ConsoleKey.Backspace)
                {
                    if (directory_Info.Parent != null)
                    {
                        directory_Info = directory_Info.Parent;
                        cursor = 0;
                        l = directory_Info.GetFileSystemInfos().Length;
                    }
                    else
                        break;
                    
                }
                ShowDirectoryInfo(directory_Info, cursor);
            }
        }
    }
}
