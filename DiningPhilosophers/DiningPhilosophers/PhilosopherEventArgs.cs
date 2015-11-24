using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DiningPhilosophers
{
    public class PhilosopherEventArgs : RoutedEventArgs
    {
        public PhilosopherEventArgs(object obj1, object obj2, object obj3)
            :this(obj1,obj2)
        {
            this.obj3 = obj3;
        }

        public PhilosopherEventArgs(object obj1, object obj2)
            :this(obj1)
        {
            this.obj2 = obj2;
        }

        public PhilosopherEventArgs(object obj1)
        {
            this.obj1 = obj1;            
        }

        public object obj1 { get; }
        public object obj2 { get; }
        public object obj3 { get; }
    }
}
