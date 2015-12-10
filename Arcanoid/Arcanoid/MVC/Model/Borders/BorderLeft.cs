using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.MVC.Model
{
    public class BorderLeft : IBorderable
    {        
        public Direction ChangeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.SW: return Direction.SE;
                case Direction.NW: return Direction.NE;
                default: return direction;
            }
        }
    }
}
