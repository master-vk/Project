using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DiningPhilosophers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void Helper(object sender, PhilosopherEventArgs e);
        static Semaphore semaphore = new Semaphore(4,10, "Sima");

        public MainWindow()
        {

            InitializeComponent();

            philosofer0 = new Philosopher("0", fork0, fork4, semaphore);
            philosofer1 = new Philosopher("1", fork1,  fork0, semaphore);
            philosofer2 = new Philosopher("2", fork2, fork1, semaphore);
            philosofer3 = new Philosopher("3", fork3, fork2, semaphore);
            philosofer4 = new Philosopher("4", fork4, fork3, semaphore);

            #region Subscribe
            philosofer0.Think += OnThink;
            philosofer0.TakedFork += OnTakedFork;
            philosofer0.EatEvent += OnEatEvent;
            philosofer0.PutFork += OnPutFork;

            philosofer1.Think += OnThink;
            philosofer1.TakedFork += OnTakedFork;
            philosofer1.EatEvent += OnEatEvent;
            philosofer1.PutFork += OnPutFork;

            philosofer2.Think += OnThink;
            philosofer2.TakedFork += OnTakedFork;
            philosofer2.EatEvent += OnEatEvent;
            philosofer2.PutFork += OnPutFork;

            philosofer3.Think += OnThink;
            philosofer3.TakedFork += OnTakedFork;
            philosofer3.EatEvent += OnEatEvent;
            philosofer3.PutFork += OnPutFork;

            philosofer4.Think += OnThink;
            philosofer4.TakedFork += OnTakedFork;
            philosofer4.EatEvent += OnEatEvent;
            philosofer4.PutFork += OnPutFork;
            #endregion

            helperOnThink = HelperOnThink;
            helperOnTaked = HelpOnTakedFork;
            helperOnEat = HelpOnEatEvent;
            helperOnPut = HelpOnPutFork;

            thread0 = new Thread(philosofer0.Action);
            thread1 = new Thread(philosofer1.Action);
            thread2 = new Thread(philosofer2.Action);
            thread3 = new Thread(philosofer3.Action);
            thread4 = new Thread(philosofer4.Action);

            thread0.Start();
            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
        }

        Thread thread0;
        Thread thread1;
        Thread thread2;
        Thread thread3;
        Thread thread4;
        

        Helper helperOnThink;
        Helper helperOnTaked;
        Helper helperOnEat;
        Helper helperOnPut;

        Philosopher philosofer0 = null;
        Philosopher philosofer1 = null;
        Philosopher philosofer2 = null;
        Philosopher philosofer3 = null;
        Philosopher philosofer4 = null;

        ForkBool fork0 = new ForkBool();
        ForkBool fork1 = new ForkBool();
        ForkBool fork2 = new ForkBool();
        ForkBool fork3 = new ForkBool();
        ForkBool fork4 = new ForkBool();

        #region OnPut
        public void HelpOnPutFork(object sender, PhilosopherEventArgs e)
        {
            Fork f = new Fork();
            f = (Fork)e.obj2;
            switch ((sender as Philosopher).Name)
            {
                case "0": {
                        if (f == Fork.Left)
                        {
                            elfork0.Fill = Brushes.Brown;
                        }
                        else
                        {
                            elfork4.Fill = Brushes.Brown;
                        }
                        label0.Content = e.obj1 as string; } break;
                case "1":
                    {
                        if (f == Fork.Left)
                        {
                            elfork1.Fill = Brushes.Brown;
                        }
                        else
                        {
                            elfork0.Fill = Brushes.Brown;
                        }
                        label1.Content = e.obj1 as string;
                    } break;
                case "2":
                    {
                        if (f == Fork.Left)
                        {
                            elfork2.Fill = Brushes.Brown;
                        }
                        else
                        {
                            elfork1.Fill = Brushes.Brown;
                        }
                        label2.Content = e.obj1 as string;
                    }
                    break;
                case "3":
                    {
                        if (f == Fork.Left)
                        {
                            elfork3.Fill = Brushes.Brown;
                        }
                        else
                        {
                            elfork2.Fill = Brushes.Brown;
                        }
                        label3.Content = e.obj1 as string;
                    }
                    break;
                case "4":
                    {
                        if (f == Fork.Left)
                        {
                            elfork4.Fill = Brushes.Brown;
                        }
                        else
                        {
                            elfork3.Fill = Brushes.Brown;
                        }
                        label4.Content = e.obj1 as string;
                    }
                    break;
                default:
                    break;
            }
        }
        public void OnPutFork(object sender, PhilosopherEventArgs e)
        {
            this.Dispatcher.Invoke(helperOnPut, sender, e);
        }
        #endregion

        #region OnEat
        public void HelpOnEatEvent(object sender, PhilosopherEventArgs e)
        {
            switch ((sender as Philosopher).Name)
            {
                case "0": { label0.Content = e.obj1 as string; } break;
                case "1": { label1.Content = e.obj1 as string; } break;
                case "2": { label2.Content = e.obj1 as string; } break;
                case "3": { label3.Content = e.obj1 as string; } break;
                case "4": { label4.Content = e.obj1 as string; } break;
                default:
                    break;
            }
            
        }
        public void OnEatEvent(object sender, PhilosopherEventArgs e)
        {
            this.Dispatcher.Invoke(helperOnEat, sender, e);
        }
        #endregion

        #region OnTaked 
        public void HelpOnTakedFork(object sender, PhilosopherEventArgs e)
        {
            Fork f = new Fork();
            f = (Fork)e.obj2;
            switch ((sender as Philosopher).Name)
            {
                case "0":
                    {
                        el0.Fill = Brushes.Blue;
                        if (f == Fork.Left)
                        {
                            fork0.Fork = false;
                            elfork0.Fill = Brushes.Blue;
                        }
                        else
                        {
                            fork4.Fork = false;
                            elfork4.Fill = Brushes.Blue;
                        }
                        label0.Content = e.obj1 as string;
                    } break;
                case "1":
                    {
                        el1.Fill = Brushes.Red;
                        if (f == Fork.Left)
                        {
                            fork1.Fork = false;
                            elfork1.Fill = Brushes.Red;
                        }
                        else
                        {
                            fork0.Fork = false;
                            elfork0.Fill = Brushes.Red;
                        }
                        label1.Content = e.obj1 as string;
                    }
                    break;
                case "2":
                    {
                        el2.Fill = Brushes.Green;
                        if (f == Fork.Left)
                        {
                            fork2.Fork = false;
                            elfork2.Fill = Brushes.Green;
                        }
                        else
                        {
                            fork1.Fork = false;
                            elfork1.Fill = Brushes.Green;
                        }
                        label2.Content = e.obj1 as string;
                    }
                    break;
                case "3":
                    {
                        el3.Fill = Brushes.Violet;
                        if (f == Fork.Left)
                        {
                            fork3.Fork = false;
                            elfork3.Fill = Brushes.Violet;
                        }
                        else
                        {
                            fork2.Fork = false;
                            elfork2.Fill = Brushes.Violet;
                        }
                        label3.Content = e.obj1 as string;
                    }
                    break;
                case "4":
                    {
                        el4.Fill = Brushes.Yellow;
                        if (f == Fork.Left)
                        {
                            fork4.Fork = false;
                            elfork4.Fill = Brushes.Yellow;
                        }
                        else
                        {
                            fork3.Fork = false;
                            elfork3.Fill = Brushes.Yellow;
                        }
                        label4.Content = e.obj1 as string;
                    }
                    break;

                default:
                    break;
            }
        }
        public void OnTakedFork(object sender, PhilosopherEventArgs e)
        {
            this.Dispatcher.Invoke(helperOnTaked, sender, e);

        }
        #endregion

        #region OnThink
        void HelperOnThink(object sender, PhilosopherEventArgs e)
        {
            switch ((sender as Philosopher).Name)
            {
                case "0": { el0.Fill = Brushes.Azure; label0.Content = e.obj1 as string; } break;
                case "1": { el1.Fill = Brushes.Azure; label1.Content = e.obj1 as string; } break;
                case "2": { el2.Fill = Brushes.Azure; label2.Content = e.obj1 as string; } break;
                case "3": { el3.Fill = Brushes.Azure; label3.Content = e.obj1 as string; } break;
                case "4": { el4.Fill = Brushes.Azure; label4.Content = e.obj1 as string; } break;
                default:
                    break;
            }
        }

        public void OnThink(object sender, PhilosopherEventArgs e)
        {
            this.Dispatcher.Invoke(helperOnThink,sender,e);
        }
        #endregion
    }
}
