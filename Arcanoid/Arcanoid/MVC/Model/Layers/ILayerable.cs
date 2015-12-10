using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.MVC.Model
{
    public interface ILayerable
    {
        List<Ball> Balls { get; set; }
        List<Brick> Bricks { get; set; }
        List<Platform> Platforms { get; set; }
        AbstractEntity FreeSpace { get; }
        void RemoveBrick(Position position);
    }
}
