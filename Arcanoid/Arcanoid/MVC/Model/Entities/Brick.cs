using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    public class Brick : AbstractEntity
    {
        public Brick(Position position)
        {
            base.Position = position;
            base.Image = '#';
        }
    }
}
