using Arcanoid.MVC.Model;
using System;


namespace Arcanoid
{
    public delegate void ViewDelegate(object sender, SendEventArgs e);
    class View
    {
        public View()
        {
            this.matrix = new Matrix();
        }

        public event ViewDelegate SendMove;

        public int High { get { return this.matrix.High; } }
        public int Long { get { return this.matrix.Long; } }

        public void Run()
        {
            while (true)
            {
                
                key = Console.ReadKey().Key;
                SendMove(this, new SendEventArgs(key));
                
            }
        }
        //TODO: create timer
        public void OnShow(object sender, SendEventArgs e)
        {
            matrix = e.Matrix as Matrix;
            Printer.PrintMatrix(matrix);
        }

        
        Matrix matrix;
        ConsoleKey key = new ConsoleKey();
    }
}
