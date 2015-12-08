using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.MVC.Model
{
    public static class Reflector
    {
        public static AbstractBorder CreateBorder(Direction direction)
        {
            switch (direction)
            {
                case Direction.NE: 
                case Direction.NW: return new BorderTop();
                case Direction.SW: 
                case Direction.SE: return new BorderBottom();
                default: return null;
            }
        }
    }
}
