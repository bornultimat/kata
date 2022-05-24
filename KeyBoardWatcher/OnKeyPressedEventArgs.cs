using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeyBoardWatcher
{
    internal class OnKeyPressedEventArgs : EventArgs
    {
        public OnKeyPressedEventArgs(ConsoleKey key, ConsoleModifiers modifier)
        {
            this.Key = key;
            this.Modifier = modifier;
        }

        public ConsoleModifiers Modifier { get; private set; }
        public ConsoleKey Key { get; private set; }
    }
}
