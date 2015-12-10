using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arcanoid
{
    public static class Printer
    {
        public static void PrintMatrix(Matrix matrix)
        {
            
            Console.Clear();

            for (int i = 0; i < matrix.High; i++)
            {
                for (int j = 0; j < matrix.Long; j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
            Thread.Sleep(48);
        }
    }
}
