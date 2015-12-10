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
        
        public Space(int HIGH, int LONG, ILayerable layer)
        {
            this.LONG = LONG;
            this.HIGH = HIGH;
            this.layer = layer;
            space = new AbstractEntity[HIGH, LONG];
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

        public IBorderable GetBorder(Position position)
        {
            if (GetBorderOfY(position) is BorderInside) //Border.Inside)
            {               
               return GetBorderOfX(position);               
            }
            return GetBorderOfY(position);
        }

        public readonly int LONG;
        public readonly int HIGH;

        ILayerable layer;
        AbstractEntity[,] space;

        private IBorderable GetBorderOfX(Position position)
        {
            if (position.X >= 0)
            {
                if (position.X < LONG - 1)
                {
                    return new BorderInside(); 
                }
                else
                {
                    return new BorderRight(); 
                }
            }
            return new BorderLeft(); 
            
        }

        public void OnSendMove(object sender, SendEventArgs e)
        {
            if (IsLeft(e))
            {
                MovePlatformsLeft();
            }
            if (IsRight(e))
            {
                MovePlatformsRight();
            }
        }

        private void MovePlatformsRight()
        {
            for (int i = 0; i < layer.Platforms.Count; i++)
            {
                MovePlatFormRight(i);
            }
        }

        private void MovePlatformsLeft()
        {
            for (int i = 0; i < layer.Platforms.Count; i++)
            {
                MovePlatformLeft(i);
            }
        }

        private static bool IsRight(SendEventArgs e)
        {
            return e.Key == ConsoleKey.RightArrow;
        }

        private static bool IsLeft(SendEventArgs e)
        {
            return e.Key == ConsoleKey.LeftArrow;
        }

        private void MovePlatformLeft(int i)
        {
            for (int j = 0; j < layer.Platforms[i].PlatformElements.Count(); j++)
            {
                if (layer.Platforms[i].PlatformElements[layer.Platforms[i].PlatformElements.Count() - 1].Position.X > 0)
                {
                    layer.Platforms[i].PlatformElements[j].Position = new Position(
                        layer.Platforms[i].PlatformElements[j].Position.Y, 
                        layer.Platforms[i].PlatformElements[j].Position.X - 1);
                }
            }
        }

        void MovePlatFormRight(int i)
        {
            if (layer.Platforms[i].PlatformElements[0].Position.X < LONG - 1)
            {
                for (int j = 0; j < layer.Platforms[i].PlatformElements.Count(); j++)
                {
                    layer.Platforms[i].PlatformElements[j].Position = new Position(
                        layer.Platforms[i].PlatformElements[j].Position.Y, 
                        layer.Platforms[i].PlatformElements[j].Position.X + 1);
                }
            }
        }

        private IBorderable GetBorderOfY(Position position)
        {
            if (position.Y >= 0)
            {
                if (position.Y <= HIGH - 1)
                {
                    return new BorderInside();
                }
                else
                {
                    return new BorderBottom(); 
                }
            }
            return new BorderTop(); 
        }

        

        void InitializeSpace()
        {
            SetEmptySpace();
            SetBalls();
            SetBricks();
            SetPlatforms();
        }

        void SetEmptySpace()
        {
            for (int i = 0; i < HIGH; i++)
            {
                for (int j = 0; j < LONG; j++)
                {
                    space[i, j] = new FreeSpace(new Position(i, j));
                }
            }
        }

        void SetBalls()
        {
            foreach (var item in layer.Balls)
            {
                space[item.Position.Y, item.Position.X] = item;
            }
        }

        void SetBricks()
        {
            foreach (var item in layer.Bricks)
            {
                space[item.Position.Y, item.Position.X] = item;
            }
        }

        private void SetPlatforms()
        {
            foreach (var platform in layer.Platforms)
            {
                foreach (var item in platform.PlatformElements)
                {
                    space[item.Position.Y, item.Position.X] = item;
                }
            }
        }
    }
}
