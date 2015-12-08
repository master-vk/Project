using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    public class PlatformElement : AbstractEntity
    {
        public PlatformElement(Position position)
        {
            base.Position = position;
            base.Image = '@';
        }
    }
}
