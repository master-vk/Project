using Arcanoid.MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arcanoid
{
    public delegate void ViewDelegate(object sender, SendEventArgs e);
    class View
    {
        Matrix matrix;
        public event ViewDelegate SendMove;
        public View(Matrix matrix)
        {
            this.matrix = matrix;
        }
        ConsoleKey key = new ConsoleKey();
        public void Run()
        {
            while (true)
            {
                
                key = Console.ReadKey().Key;
                SendMove(this, new SendEventArgs(key));
                
            }
        }
        public void OnShow(object sender, SendEventArgs e)
        {
           
                matrix = e.Matrix as Matrix;
               
            
            
            Printer.PrintMatrix(matrix);
        }
    }
}
