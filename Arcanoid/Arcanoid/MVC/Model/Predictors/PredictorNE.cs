﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.MVC.Model
{
    public class PredictorNE : IPredictorable
    {
      
        public Position Peek(Position position)
        {
            return new Position(position.Y - 1, position.X + 1);
        }
    }
}
