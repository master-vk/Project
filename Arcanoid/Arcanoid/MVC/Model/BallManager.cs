using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcanoid.MVC.Model;

namespace Arcanoid
{
    public enum Direction
    {
        NE,
        SE,
        SW,
        NW
    }

    public class BallManager
    {

        // TODO testing to multithreading
        public BallManager(Space space, Layout layout)
        {
            this.layout = layout;
            this.space = space;
            this.balls = layout.Balls;
            ballsDirections = new Dictionary<string, Direction>();
            SetInitialDirections();
        }

        public void BallMoveNext()
        {

            for (int i = 0; i < balls.Count; ++i)
            {
                //object o = i;
                space.RefreshSpace();
                //TODO create multitreading architecture this!!
                //Task task = new Task(PeekNewPosition, o);
                //task.Start();
                PeekNewPosition(i);
            }
        }


        Space space;
        List<Ball> balls;
        Dictionary<string, Direction> ballsDirections;
        Layout layout;

        void SetInitialDirections()
        {
            foreach (var item in balls)
            {
                ballsDirections.Add(item.Name, Direction.NE);
            }
        }

        private void PeekNewPosition(object o)
        {
            int i = (int)o;
            Move(i, CreatePredicator(i));
        }

        private IPredictorable CreatePredicator(int i)
        {
            return PredictorFactory.CreatePredictor(ballsDirections[balls[i].Name]);
        }

        private void Move(int i, IPredictorable mover)
        {
            var newPosition = mover.Peek(balls[i].Position);

            var border = space.GetBorder(newPosition);

            if (Inside(border))
            {
                if (IsFreeSpace(newPosition))
                {
                    balls[i].Position = newPosition;
                    SaveChanges();
                    return;
                }
                else if (IsBrick(newPosition))
                {
                    layout.RemoveBrick(newPosition);//TODO: create event
                }
                border = Reflector.CreateBorder(ballsDirections[balls[i].Name]);
            }

            ballsDirections[balls[i].Name] = border.ChangeDirection(ballsDirections[balls[i].Name]);
            Move(i, CreatePredicator(i));

            SaveChanges();
        }

        private bool IsBrick(Position newPosition)
        {
            return space[newPosition] is Brick;
        }

        private bool IsFreeSpace(Position newPosition)
        {
            return space[newPosition] is FreeSpace;
        }

        private static bool Inside(AbstractBorder border)
        {
            return border is BorderInside;
        }

        void SaveChanges()
        {
            layout.Balls = balls;
        }

    }
}
