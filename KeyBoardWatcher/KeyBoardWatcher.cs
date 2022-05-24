using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KeyBoardWatcher
{
    internal class KeyBoardWatcher
    {
        private Thread _thread;

        private KeyBoardWatcherThreadArguments _threadArguments;

        public event EventHandler<OnKeyPressedEventArgs> OnKeyPressed;

        public KeyBoardWatcher()
        {
            this._threadArguments = new KeyBoardWatcherThreadArguments();
        }

        public void Start()
        {
            if (this._thread != null && this._thread.IsAlive)
            {
                throw new InvalidOperationException("Watcher already running");
            }
            this._threadArguments.Exit = false;
            this._thread = new Thread(this.Worker);
            this._thread.Start(this._threadArguments);
        }

        public void Stop()
        {
            if (this._thread == null || !_thread.IsAlive)
            {
                throw new InvalidOperationException("Watcher already stopped");
            }
            this._threadArguments.Exit = true;
            this._thread.Abort();
        }

        protected virtual void FireOnKeyPressed(OnKeyPressedEventArgs e)
        {
            if (this.OnKeyPressed != null)
            {
                this.OnKeyPressed(this, e);
            }
        }

        private void Worker(object data)
        {
            if (!(data is KeyBoardWatcherThreadArguments))
            {
                throw new ArgumentOutOfRangeException(nameof(data), "Wrong Arguments");
            }

            KeyBoardWatcherThreadArguments threadArgs = (KeyBoardWatcherThreadArguments)data;

            Console.WriteLine("Watcher started");

            while (!threadArgs.Exit)
            {
                ConsoleKeyInfo cki = Console.ReadKey(true);
                this.FireOnKeyPressed(new OnKeyPressedEventArgs(cki.Key, cki.Modifiers));
            }

            Console.WriteLine("Watcher stopped");
        }
    }
}
