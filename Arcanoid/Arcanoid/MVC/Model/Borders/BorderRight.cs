using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arcanoid.MVC.Model
{
    public class BorderRight : AbstractBorder
    {        
        public override Direction ChangeDirection(Direction direction)
        {
            switch (direction)
            {
                case Direction.NE: return Direction.NW;
                case Direction.SE: return Direction.SW;
                default: return direction;                  
            }
        }
    }
}
