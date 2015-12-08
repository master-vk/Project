using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.MVC.Model
{
    public interface IPredictorable
    {        
        Position Peek(Position position);
    }
}
