using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FileWatcher
{
    internal class Program
    {

        static void Main(string[] args)
        {
            if (Directory.Exists("Temp") && !File.Exists(@"Temp\temp.txt"))
            {
                Directory.CreateDirectory("Temp");

                using (Stream stream = new FileStream(@"Temp\temp.txt", FileMode.OpenOrCreate))
                {
                    stream.Flush();
                    stream.Close();
                }
            }


            FileSystemWatcher watcher = new FileSystemWatcher(@"J:\Programmieren\Tests_V\testing\FileWatcher\bin\Debug");
            watcher.Changed += FileChanged;
            watcher.Created += FileCreated;
            watcher.Deleted += FileDeleted;
            watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.Size;

            watcher.IncludeSubdirectories = true;
            watcher.EnableRaisingEvents = true;

            Console.WriteLine("Press enter to exit.");
            Console.ReadLine();
        }

        private static void FileDeleted(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{ e.Name} was deleted!");
        }

        private static void FileCreated(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.Name} was created!");
        }

        private static void FileChanged(object sender, FileSystemEventArgs e)
        {
            Console.WriteLine($"{e.Name} was changed!");
        }
    }
}
