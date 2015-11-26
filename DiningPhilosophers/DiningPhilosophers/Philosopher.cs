
using System.Threading;


namespace DiningPhilosophers
{
    public delegate void Sender(object sender, PhilosopherEventArgs e);

    enum ForkSelect
    {
        Left,
        Right
    }

    class Philosopher
    {
        public Philosopher(string name, Fork leftfork, Fork rightfork)
        {
            this.Name = name;
            leftFork = leftfork;
            rightFork = rightfork;
        }


        public string Name { get; set; }
        public event Sender Think;
        public event Sender EatEvent;
        public event Sender PutFork;
        public event Sender GetFork;

        public void Action()
        {
            while (true)
            {
                leftFork.mutex.WaitOne();
                              
                GetLeftFork();               
                leftFork.mutex.ReleaseMutex();

                rightFork.mutex.WaitOne();
                
                GetRightFork();
                rightFork.mutex.ReleaseMutex();

                Eat();

                leftFork.mutex.WaitOne();
                PutLeftFork();
                leftFork.mutex.ReleaseMutex();


                rightFork.mutex.WaitOne();
                PutRightFork();
                rightFork.mutex.ReleaseMutex();
            }
        }

        Fork leftFork = null;
        Fork rightFork = null;
        bool forkInLeftHand = false;
        bool forkInRightHand = false;

        private void PutRightFork()
        {
            if (forkInRightHand)
            {
                rightFork.isUsing = false;
                forkInRightHand = false;
                PutFork(this, new PhilosopherEventArgs("Put right fork", ForkSelect.Right));
                Thread.Sleep(2000);
            }
            
        }

        private void PutLeftFork()
        {
            if (forkInLeftHand)
            {
                leftFork.isUsing = false;
                forkInLeftHand = false;
                PutFork(this, new PhilosopherEventArgs("Put right fork", ForkSelect.Left));
                Thread.Sleep(2000);
            }
            
        }

        private void Eat()
        {
            if (forkInLeftHand && forkInRightHand)
            {
                EatEvent(this, new PhilosopherEventArgs("I'm Eat"));
                Thread.Sleep(4000);
            }
            
        }

        private void GetRightFork()
        {
            Think(this, new PhilosopherEventArgs("Think and\n wait left fork"));
            int i = 500;
            while (i > 0)
            {
                --i;
                if (!rightFork.isUsing && forkInLeftHand && !forkInRightHand)
                {
                    rightFork.isUsing = true;
                    forkInRightHand = true;
                    GetFork(this, new PhilosopherEventArgs("Taked right fork",ForkSelect.Right));
                    Thread.Sleep(2000);
                    return; 
                }
            }
            
        }

        private void GetLeftFork()
        {
            Think(this, new PhilosopherEventArgs("Think and wait right fork"));
            int i = 500;
            while (i>0)
            {
                --i;
                if (!leftFork.isUsing && !forkInLeftHand)
                {
                    leftFork.isUsing = true;
                    forkInLeftHand = true;
                    GetFork(this, new PhilosopherEventArgs("Taked left fork", ForkSelect.Left));
                    Thread.Sleep(2000);
                    return; 
                }
            }
        }
    }
}
