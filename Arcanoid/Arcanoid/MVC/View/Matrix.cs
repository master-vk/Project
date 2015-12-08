using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    public class Matrix
    {
        public Matrix()
        {

        }
        public Matrix(Layout layout)
        {
            this.layout = layout;
        }
        

        public const int LONG = 30;
        public const int HIGH = 20;

        public int Long { get { return LONG; } }
        public int High { get { return HIGH; } }


        public char this[int h, int l]
        {
            get { return matrix[h, l]; }
            set { matrix[h, l] = value; }
        }

        public void SetEmptyMatrix()
        {
            for (int i = 0; i < High; i++)
            {
                for (int j = 0; j < Long; j++)
                {
                    matrix[i, j] = layout.FreeSpace.Image;
                }
            }
        }


        Layout layout;
        char[,] matrix = new char[HIGH, LONG];

        public void Refresh()
        {
            SetEmptyMatrix();
            SetLayoutOnMatrix();
        }
        void SetLayoutOnMatrix()
        {
            foreach (var item in layout.Balls)
            {
                matrix[item.Position.Y, item.Position.X] = item.Image;
            }
            foreach (var item in layout.Bricks)
            {
                matrix[item.Position.Y, item.Position.X] = item.Image;
            }
            foreach (var platform in layout.Platforms)
            {
                foreach (var item in platform.PlatformElements)
                {
                    matrix[item.Position.Y, item.Position.X] = item.Image;
                }                
            }
            
        }

    }
}
