using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arcanoid.MVC.Model;
using System.Threading;

namespace Arcanoid
{
    public delegate void Delegate(object sender, SendEventArgs e);
    public enum Direction
    {
        NE,
        SE,
        SW,
        NW
    }

    public class BallManager
    {
        Semaphore locker = new Semaphore(1,1);
        // TODO testing to multithreading
        public BallManager(Space space, Layout layout)
        {
            this.layout = layout;
            this.space = space;
            this.balls = layout.Balls;
            ballsDirections = new Dictionary<string, Direction>();
            SetInitialDirections();
        }
        public event Delegate Show;
        public void BallMoveNext()
        {

            for (int i = 0; i < balls.Count; ++i)
            {
                object o = i;
                //space.RefreshSpace();
                //TODO create multitreading architecture this!!
                Task task = new Task(PeekNewPosition, o);
                task.Start();
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

            
            space.RefreshSpace();
            int i = (int)o;

            Move(i, CreatePredicator(i));
            
            
            
        

        }

        private IPredictorable CreatePredicator(int i)
        {
            return PredictorFactory.CreatePredictor(ballsDirections[balls[i].Name]);
        }

        private void Move(int i, IPredictorable mover)
        {
            while (true)
            {
                var newPosition = mover.Peek(balls[i].Position);

                var border = space.GetBorder(newPosition);

                if (Inside(border))
                {
                    if (IsFreeSpace(newPosition))
                    {
                        balls[i].Position = newPosition;
                        locker.WaitOne();
                        SaveChanges();
                        Show(this, new SendEventArgs(layout));
                        
                        locker.Release();
                        break;
                        //return;
                    }
                    else if (IsBrick(newPosition))
                    {
                        locker.WaitOne();
                        layout.RemoveBrick(newPosition);
                        SaveChanges();
                        Show(this, new SendEventArgs(layout));
                        
                        locker.Release();
                    }
                    border = Reflector.CreateBorder(ballsDirections[balls[i].Name]);
                }

                ballsDirections[balls[i].Name] = border.ChangeDirection(ballsDirections[balls[i].Name]);
                mover = CreatePredicator(i);
            }
            
            //Move(i, CreatePredicator(i));

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
