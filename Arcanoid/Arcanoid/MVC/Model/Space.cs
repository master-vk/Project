using Arcanoid.MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    public enum Border
    {
        Top,
        Right,
        Bottom,
        Left,
        Inside
    }
    public class Space
    {
        
        public Space(Matrix matrix, Layout layout)
        {
            this.matrix = matrix;
            this.layout = layout;
            InitializeSpace();
        }
        

        public AbstractEntity this[Position position]
        {
            get { return space[position.Y,position.X]; }
        }
        
        public void RefreshSpace()
        {
            InitializeSpace();
        }

        public AbstractBorder GetBorder(Position position)
        {
            if (IsInsideOfY(position) is BorderInside) //Border.Inside)
            {               
               return IsInsideOfX(position);               
            }
            return IsInsideOfY(position);
        }

        Matrix matrix;
        Layout layout;
        AbstractEntity[,] space;

        private AbstractBorder IsInsideOfX(Position position)
        {
            if (position.X >= 0)
            {
                if (position.X < matrix.Long - 1)
                {
                    return new BorderInside(); //Border.Inside;
                }
                else
                {
                    return new BorderRight(); //Border.Bottom;
                }
            }
            return new BorderLeft(); //Border.Top;
            
        }
        private AbstractBorder IsInsideOfY(Position position)
        {
            if (position.Y >= 0)
            {
                if (position.Y <= matrix.High - 1)
                {
                    return new BorderInside();//Border.Inside;
                }
                else
                {
                    return new BorderBottom(); //Border.Right;
                }
            }
            return new BorderTop(); //Border.Left;
        }

        

        void InitializeSpace()
        {
            space = new AbstractEntity[matrix.High, matrix.Long];
            SetEmptySpace();
            SetBalls();
            SetBricks();
            SetPlatforms();
        }

        void SetEmptySpace()
        {
            for (int i = 0; i < matrix.High; i++)
            {
                for (int j = 0; j < matrix.Long; j++)
                {
                    space[i, j] = new FreeSpace(new Position(i, j));
                }
            }
        }

        void SetBalls()
        {
            foreach (var item in layout.Balls)
            {
                space[item.Position.Y, item.Position.X] = item;
            }
        }

        void SetBricks()
        {
            foreach (var item in layout.Bricks)
            {
                space[item.Position.Y, item.Position.X] = item;
            }
        }

        private void SetPlatforms()
        {
            foreach (var platform in layout.Platforms)
            {
                foreach (var item in platform.PlatformElements)
                {
                    space[item.Position.Y, item.Position.X] = item;
                }
            }
        }
    }
}
