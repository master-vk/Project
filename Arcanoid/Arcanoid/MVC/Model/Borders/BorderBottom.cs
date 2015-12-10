using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.MVC.Model
{
    public class BorderBottom : IBorderable
    {        
        public Direction ChangeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.SE: return Direction.NE;
                case Direction.SW: return Direction.NW;
                default: return direction;
            }
        }
    }
}
