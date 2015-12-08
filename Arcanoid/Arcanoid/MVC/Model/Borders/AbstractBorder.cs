using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.MVC.Model
{
    public abstract class AbstractBorder
    {
        public abstract Direction ChangeDirection(Direction direction);
    }
}
