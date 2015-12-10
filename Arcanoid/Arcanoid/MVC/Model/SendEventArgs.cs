using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.MVC.Model
{
    public class SendEventArgs : EventArgs
    {
        Matrix matrix;
        ConsoleKey key = new ConsoleKey();
        public SendEventArgs(Layout layout)
        {
            this.matrix = new Matrix(layout);
            matrix.Refresh();
        }
        public SendEventArgs(ConsoleKey key)
        {
            this.Key = key;
        }
        public Matrix Matrix
        {
            get
            {
                return matrix;
            }

            set
            {
                matrix = value;
            }
        }

        public ConsoleKey Key
        {
            get
            {
                return key;
            }

            set
            {
                key = value;
            }
        }
    }
}
