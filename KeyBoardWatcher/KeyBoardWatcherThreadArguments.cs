using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyBoardWatcher
{
    internal class KeyBoardWatcherThreadArguments
    {
        public KeyBoardWatcherThreadArguments()
        {
            this.Exit = false;
        }

        public bool Exit { get; set; }
    }
}
