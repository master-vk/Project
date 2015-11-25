using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiningPhilosophers
{
    public delegate void Sender(object sender, PhilosopherEventArgs e);

    enum Fork
    {
        Left,
        Right
    }

    class Philosopher
    {
        public Philosopher(string name, ForkBool leftfork, ForkBool rightfork, Semaphore semaPhore)
        {
            semaphore = semaPhore;
            this.Name = name;
            leftFork = leftfork as ForkBool;
            rightFork = rightfork as ForkBool;
        }


        public string Name { get; }
        public event Sender Think;
        public event Sender EatEvent;
        public event Sender PutFork;
        public event Sender TakedFork;


        public void Action()
        {
            while (true)
            {
                Thread.Sleep(random.Next(1000, 3000));
                semaphore.WaitOne();

                Think(this, new PhilosopherEventArgs("Think and\n wait left fork"));
                ThinkWaitLeftFork();

                Think(this, new PhilosopherEventArgs("Think and wait right fork"));
                ThinkWaitRightFork();
                
                Eat();

                PutLeftFork();

                PutRightFork();
                semaphore.Release();
            }
        }

        private void PutRightFork()
        {
            PutFork(this, new PhilosopherEventArgs("Put right fork",Fork.Right));
            Thread.Sleep(random.Next(1000,3000));
        }

        private void PutLeftFork()
        {
            PutFork(this, new PhilosopherEventArgs("Put right fork", Fork.Left));
            Thread.Sleep(random.Next(1000, 3000));
        }

        private void Eat()
        {
            EatEvent(this, new PhilosopherEventArgs("I'm Eat"));
            Thread.Sleep(5000);
        }

        private void ThinkWaitRightFork()
        {
            while (true)
            {
                if (rightFork.Fork)
                {
                    TakedFork(this, new PhilosopherEventArgs("Taked right fork",Fork.Right));
                    break;
                }
            }
            Thread.Sleep(random.Next(1000, 3000));
        }

        private void ThinkWaitLeftFork()
        {
            while (true)
            {
                if (leftFork.Fork)
                {
                    TakedFork(this, new PhilosopherEventArgs("Taked left fork", Fork.Left));
                    break;
                }
            }
            Thread.Sleep(random.Next(1000, 3000));
        }

        ForkBool leftFork = null;
        ForkBool rightFork = null;
        Random random = new Random();
        Semaphore semaphore = null;
    }
}
