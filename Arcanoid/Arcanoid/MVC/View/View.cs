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

        public void Visualize()
        {
            Printer.PrintMatrix(matrix);
        }
    }
}
