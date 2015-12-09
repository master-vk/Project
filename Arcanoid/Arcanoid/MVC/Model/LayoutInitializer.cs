using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    public static class LayoutInitializer
    {
        static Layout layout;

        static LayoutInitializer()
        {
            layout = new Layout();
        }

        public static Layout Initialize(Layout layout, int HIGH, int LONG)
        {
            layout.Balls.AddRange(new List<Ball>
            {
                new Ball(new Position(15, 6),"ball1"),
                new Ball(new Position(1, 6),"ball3"),
                new Ball(new Position(2, 9),"ball2" )
            });
            for (int i = 4; i < 6; i++)
            {
                for (int j = 0; j < LONG; j++)
                {
                    layout.Bricks.Add(new Brick(new Position(i, j)));
                }
            }

            //layout.Bricks.AddRange(new List<Brick>
            //{
            //    new Brick(new Position(0, 0)),
            //    new Brick(new Position(0, 1)),
            //    new Brick(new Position(0, 2)),
            //    new Brick(new Position(0, 3)),
            //    new Brick(new Position(0, 4)),
            //    new Brick(new Position(0, 5)),
            //    new Brick(new Position(0, 6)),
            //    new Brick(new Position(0, 7)),
            //    new Brick(new Position(0, 8)),
            //    new Brick(new Position(0, 9)),
            //    new Brick(new Position(0, 10)),
            //    new Brick(new Position(0, 11)),
            //    new Brick(new Position(0, 12)),
            //    new Brick(new Position(0, 13)),
            //    new Brick(new Position(0, 14)),
            //    new Brick(new Position(0, 15)),
            //    new Brick(new Position(0, 16)),
            //});

            layout.Platforms.Add(new Platform(new PlatformElement[] 
            {
                new PlatformElement(new Position(17, 26)),
                new PlatformElement(new Position(17, 25)),
                new PlatformElement(new Position(17, 24)),
                new PlatformElement(new Position(17, 23))
            }));

            return layout;
        }

    }
}
