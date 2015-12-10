using Arcanoid.MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    public static class LayoutInitializer
    {

        static ILayerable layer;

        public static ILayerable Initialize(int HIGH, int LONG)
        {
            layer = new Layer(HIGH, LONG);
            layer.Balls.AddRange(new List<Ball>
            {
                new Ball(new Position(15, 7),"ball1"),
                new Ball(new Position(15, 4),"ball3"),
                //new Ball(new Position(2, 9),"ball2" )
            });

            for (int i = 4; i < 6; i++)
            {
                for (int j = 0; j < LONG; j++)
                {
                    layer.Bricks.Add(new Brick(new Position(i, j)));
                }
            }


            layer.Platforms.Add(new Platform(new PlatformElement[] 
            {
                new PlatformElement(new Position(17, 16)),
                new PlatformElement(new Position(17, 15)),
                new PlatformElement(new Position(17, 14)),
                new PlatformElement(new Position(17, 13))
            }));

            return layer;
        }

    }
}
