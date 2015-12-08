using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    
    public class Ball : AbstractEntity
    {        
        public Ball(Position position, string name)
        {
            base.Position = position;
            base.Image = 'o';
            this.Name = name;
        }
        public string Name { get; set; }

    }
}
