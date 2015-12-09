using Arcanoid.MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    class View
    {
        Matrix matrix;

        public View(Matrix matrix)
        {
            this.matrix = matrix;
        }

        public void OnShow(object sender, SendEventArgs e)
        {
            Matrix matrix = e.Matrix as Matrix;
            Printer.PrintMatrix(matrix);
        }
    }
}
