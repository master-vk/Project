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

        public MainWindow()
        {

            InitializeComponent();

            philosofer0 = new Philosopher("0", fork0, fork4);
            philosofer1 = new Philosopher("1", fork1,  fork0);
            philosofer2 = new Philosopher("2", fork2, fork1);
            philosofer3 = new Philosopher("3", fork3, fork2);
            philosofer4 = new Philosopher("4", fork4, fork3);

            #region Subscribe
            philosofer0.Think += OnThink;
            philosofer0.GetFork += OnTakedFork;
            philosofer0.EatEvent += OnEatEvent;
            philosofer0.PutFork += OnPutFork;

            philosofer1.Think += OnThink;
            philosofer1.GetFork += OnTakedFork;
            philosofer1.EatEvent += OnEatEvent;
            philosofer1.PutFork += OnPutFork;

            philosofer2.Think += OnThink;
            philosofer2.GetFork += OnTakedFork;
            philosofer2.EatEvent += OnEatEvent;
            philosofer2.PutFork += OnPutFork;

            philosofer3.Think += OnThink;
            philosofer3.GetFork += OnTakedFork;
            philosofer3.EatEvent += OnEatEvent;
            philosofer3.PutFork += OnPutFork;

            philosofer4.Think += OnThink;
            philosofer4.GetFork += OnTakedFork;
            philosofer4.EatEvent += OnEatEvent;
            philosofer4.PutFork += OnPutFork;
            #endregion

            helperOnThink = HelperOnThink;
            helperOnTaked = HelpOnGetFork;
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

        Fork fork0 = new Fork("fork0");
        Fork fork1 = new Fork("fork1");
        Fork fork2 = new Fork("fork2");
        Fork fork3 = new Fork("fork3");
        Fork fork4 = new Fork("fork4");

        #region OnPut
        public void HelpOnPutFork(object sender, PhilosopherEventArgs e)
        {
            ForkSelect f = new ForkSelect();
            f = (ForkSelect)e.obj2;
            switch ((sender as Philosopher).Name)
            {
                case "0": {
                        if (f == ForkSelect.Left)
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
                        if (f == ForkSelect.Left)
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
                        if (f == ForkSelect.Left)
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
                        if (f == ForkSelect.Left)
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
                        if (f == ForkSelect.Left)
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
        public void HelpOnGetFork(object sender, PhilosopherEventArgs e)
        {
            ForkSelect f = new ForkSelect();
            f = (ForkSelect)e.obj2;
            switch ((sender as Philosopher).Name)
            {
                case "0":
                    {
                        el0.Fill = Brushes.Blue;
                        if (f == ForkSelect.Left)
                        {
                            elfork0.Fill = Brushes.Blue;
                        }
                        else
                        {
                            elfork4.Fill = Brushes.Blue;
                        }
                        label0.Content = e.obj1 as string;
                    } break;
                case "1":
                    {
                        el1.Fill = Brushes.Red;
                        if (f == ForkSelect.Left)
                        {
                            elfork1.Fill = Brushes.Red;
                        }
                        else
                        {
                            elfork0.Fill = Brushes.Red;
                        }
                        label1.Content = e.obj1 as string;
                    }
                    break;
                case "2":
                    {
                        el2.Fill = Brushes.Green;
                        if (f == ForkSelect.Left)
                        {
                            elfork2.Fill = Brushes.Green;
                        }
                        else
                        {
                            elfork1.Fill = Brushes.Green;
                        }
                        label2.Content = e.obj1 as string;
                    }
                    break;
                case "3":
                    {
                        el3.Fill = Brushes.Violet;
                        if (f == ForkSelect.Left)
                        {
                            elfork3.Fill = Brushes.Violet;
                        }
                        else
                        {
                            elfork2.Fill = Brushes.Violet;
                        }
                        label3.Content = e.obj1 as string;
                    }
                    break;
                case "4":
                    {
                        el4.Fill = Brushes.Yellow;
                        if (f == ForkSelect.Left)
                        {
                            elfork4.Fill = Brushes.Yellow;
                        }
                        else
                        {
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
