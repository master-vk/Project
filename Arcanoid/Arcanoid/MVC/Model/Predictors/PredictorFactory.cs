using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid.MVC.Model
{
    public static class PredictorFactory
    {
        public static IPredictorable CreatePredictor(Direction direction)
        {
            switch (direction)
            {
                case Direction.NE: return new PredictorNE();
                case Direction.SE: return new PredictorSE();
                case Direction.SW: return new PredictorSW();
                case Direction.NW: return new PredictorNW();
                default: return null;
            }
        }
    }
}
