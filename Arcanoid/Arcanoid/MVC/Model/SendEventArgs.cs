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

        public SendEventArgs(Layout layout)
        {
            this.matrix = new Matrix(layout);
            matrix.Refresh();
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
    }
}
