using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileWatcher
{
    internal interface IWatcher
    {
        void StartWatching();
        void StopWatching();
    }
}
