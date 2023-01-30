using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.MVC.Model
{
    public class BorderTop : IBorderable
    {
        public Direction ChangeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.NE: return Direction.SE;
                case Direction.NW: return Direction.SW;
                default: return direction;
				
            }
        }
    }
}
