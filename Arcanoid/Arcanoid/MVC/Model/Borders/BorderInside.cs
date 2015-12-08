using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.MVC.Model
{
    public class BorderInside : AbstractBorder
    {
        public override Direction ChangeDirection(Direction direction)
        {
            return direction;
        }

        

        
    }
}
