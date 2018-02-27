using System;
using System.IO;

namespace FarManager_2._0
{
    class Program
    {
        public static void ShowDirectoryInfo(DirectoryInfo directory, int cursor)
        {
           
            Console.CursorVisible = false;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.Clear();

            FileSystemInfo[] filesysteminfos = directory.GetFileSystemInfos();

            for (int index = 0; index < filesysteminfos.Length; index++)
            {
                FileSystemInfo filesystem_info = filesysteminfos[index];

                if (index == cursor)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                if (filesystem_info.GetType() == typeof(DirectoryInfo))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Blue;   
                }
                Console.WriteLine(filesystem_info.Name);
            }
        }

        static void Main(string[] args)
        {
            DirectoryInfo directory_info = new DirectoryInfo(@"/Users/arman/Documents");
            int cursor = 0;
            int n = directory_info.GetFileSystemInfos().Length;
            ShowDirectoryInfo(directory_info,cursor);

            while (true)
            {
                ConsoleKeyInfo key_info = Console.ReadKey();
                if (key_info.Key == ConsoleKey.UpArrow)
                {
                    cursor--;
                    if (cursor == -1)
                    {
                        cursor = n - 1;
                    }
                }
                if (key_info.Key == ConsoleKey.DownArrow)
                {
                    cursor++;
                    if (cursor == n)
                    {
                        cursor = 0;
                    }
                }

                if (key_info.Key == ConsoleKey.Enter)
                {
                    if (directory_info.GetFileSystemInfos()[cursor].GetType() == typeof(DirectoryInfo))
                    {
                        directory_info = new DirectoryInfo(directory_info.GetFileSystemInfos()[cursor].FullName);
                        n = directory_info.GetFileSystemInfos().Length;
                        cursor = 0;
                    }
                    else 
                    {

                        StreamReader sr = new StreamReader(directory_info.GetFileSystemInfos()[cursor].FullName);
                        string s = sr.ReadToEnd();
                        Console.Clear();
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(s);
                        Console.ReadKey();
                    }
                }
                if (key_info.Key == ConsoleKey.Backspace || key_info.Key == ConsoleKey.Escape)
                {
                    if (directory_info.Parent != null)
                    {
                        directory_info = directory_info.Parent;
                        cursor = 0;
                        n = directory_info.GetFileSystemInfos().Length;
                    }
                    else
                        break;
                }
                ShowDirectoryInfo(directory_info,cursor);
            }
        }
    }
}
