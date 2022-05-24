using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyBoardWatcher
{
    internal class Program
    {
        public static KeyBoardWatcher watcher;
        static void Main(string[] args)
        {
            watcher = new KeyBoardWatcher();
            watcher.OnKeyPressed += OnKeyPressed;
            watcher.Start();
        }

        private static void OnKeyPressed(object sender, OnKeyPressedEventArgs e)
        {
            if (e.Key == ConsoleKey.Escape)
            {
                watcher.Stop();
            }

            Console.WriteLine($"{e.Key} was pressed");
        }
    }
}
