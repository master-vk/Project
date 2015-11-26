using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    class Fork
    {
        public Fork(string mutexName)
        {
            isUsing = false;
            mutex = new Mutex(false, mutexName);
        }
        
        public bool isUsing { get; set; }        

        public Mutex mutex = null;

    }
}
