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
        public Philosopher(string name, bool leftFork, bool rightFork, Semaphore semaphore)
        {
            this.semaphore = semaphore;
            thread = new Thread(Action);
            this.Name = name;
            
        }

        Semaphore semaphore = null;
        public event Sender Think;
        public event Sender EatEvent;
        public event Sender PutFork;
        public event Sender GivedFork;

        public void StartEat()
        {
            thread.Start();
        }

        void Action()
        {
            Thread.Sleep(2000);
            while (true)
            {
                semaphore.WaitOne();
                ThinkWaitLeftFork();
                semaphore.Release();

                semaphore.WaitOne();
                ThinkWaitRightFork();
                semaphore.Release();

                semaphore.WaitOne();
                Eat();
                semaphore.Release();

                semaphore.WaitOne();
                PutLeftFork();
                semaphore.Release();

                semaphore.WaitOne();
                PutRightFork();
                semaphore.Release();

            }

        }

        private void PutRightFork()
        {
            rightFork = false;
            PutFork(this, new PhilosopherEventArgs("Put right fork",Fork.Right));
        }

        private void PutLeftFork()
        {
            leftFork = false;
            PutFork(this, new PhilosopherEventArgs("Put right fork", Fork.Left));
        }

        private void Eat()
        {
            EatEvent(this, new PhilosopherEventArgs("I'm Eat"));
        }

        private void ThinkWaitRightFork()
        {
            Think(this, new PhilosopherEventArgs("Think and wait right fork"));

            while (true)
            {
                if (rightFork)
                {
                    GivedFork(this, new PhilosopherEventArgs("Gived right fork"));
                    break;
                }
            }
        }

        private void ThinkWaitLeftFork()
        {
            Think(this, new PhilosopherEventArgs("Think and\n wait left fork"));

            while (true)
            {
                if (leftFork)
                {
                    GivedFork(this, new PhilosopherEventArgs("Gived left fork"));
                    break;
                }
            }
        }
        bool leftFork = false;
        bool rightFork = false;
        Thread thread = null;
        public string Name { get; set; }
    }
}
