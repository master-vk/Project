using Arcanoid.MVC.Model;
using System.Collections.Generic;
using System.Linq;

namespace Arcanoid
{
    public class Layer : ILayerable
    {
        public Layer(int HIGH, int LONG)
        {
            this.Balls = new List<Ball>();
            this.Bricks = new List<Brick>();
            this.Platforms = new List<Platform>();
            this.freeSpace = new FreeSpace(new Position(0, 0));

        }

        public void RemoveBrick(Position position)
        {
            var findElement = (from b in Bricks
                        where b.Position.X == position.X && b.Position.Y == position.Y
                        select b).ToList();
            foreach (var item in findElement)
            {
                Bricks.Remove(item);
            }
            
        }
        #region Properties
        

        public List<Ball> Balls
        {
            get
            {
                return balls;
            }

            set
            {
                balls = value;
            }
        }

        public List<Brick> Bricks
        {
            get
            {
                return bricks;
            }

            set
            {
                bricks = value;
            }
        }

        public List<Platform> Platforms
        {
            get
            {
                return platforms;
            }

            set
            {
                platforms = value;
            }
        }

        public AbstractEntity FreeSpace
        {
            get
            {
                return freeSpace;
            }

            
        }
        #endregion

        List<Ball> balls;
        List<Brick> bricks;
        List<Platform> platforms;
        AbstractEntity freeSpace { get; }
    }
}
