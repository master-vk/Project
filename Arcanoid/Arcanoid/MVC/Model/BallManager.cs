
#define MultyThreads
//#define SingleThread

using System.Collections.Generic;
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
        
        public BallManager(Space space, ILayerable layer)
        {
            this.layer = layer;
            this.space = space;
            this.balls = layer.Balls;
            ballsDirections = new Dictionary<string, Direction>();
            SetInitialDirections();
        }

        object o;
        Task task;
        public event Delegate SendChanges;
        public void BallMoveNext()
        {
            
            for (int i = 0; i < balls.Count; ++i)
            {

#if             MultyThreads
                
                o = i;
                task = new Task(PeekNewPosition, o);
                task.Start();
#endif

#if SingleThread
                PeekNewPosition(i);
#endif
            }
        }

        Semaphore locker = new Semaphore(1, 1);
        Space space;
        List<Ball> balls;
        Dictionary<string, Direction> ballsDirections;
        ILayerable layer;

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
            space.RefreshSpace();
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
                        MoveToFreeSpace(i, newPosition);
                        break;
                    }
                    else if (IsBrick(newPosition))
                    {
                        RemoveBrick(newPosition);
                    }
                    border = Reflector.CreateBorder(ballsDirections[balls[i].Name]);
                }

                ballsDirections[balls[i].Name] = border.ChangeDirection(ballsDirections[balls[i].Name]);
                mover = CreatePredicator(i);
            }
            

        }

        private void RemoveBrick(Position newPosition)
        {
            locker.WaitOne();
            layer.RemoveBrick(newPosition);
            SendChanges(this, new SendEventArgs(layer));

            locker.Release();
        }

        private void MoveToFreeSpace(int i, Position newPosition)
        {
            locker.WaitOne();
            balls[i].Position = newPosition;

            SendChanges(this, new SendEventArgs(layer));

            locker.Release();
        }

        private bool IsBrick(Position newPosition)
        {
            return space[newPosition] is Brick;
        }

        private bool IsFreeSpace(Position newPosition)
        {
            return space[newPosition] is FreeSpace;
        }

        private static bool Inside(IBorderable border)
        {
            return border is BorderInside;
        }

       

    }
}
