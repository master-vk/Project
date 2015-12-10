using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.MVC.Model
{
    public class SendEventArgs : EventArgs
    {
        
        public SendEventArgs(ILayerable layout)
        {
            this.matrix = new Matrix(layout);
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

        Matrix matrix;
        ConsoleKey key;
    }
}
