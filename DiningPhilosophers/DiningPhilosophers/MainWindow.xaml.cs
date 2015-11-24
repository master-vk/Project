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

            philosofer1 = new Philosopher("0", false, false, semaphore);
            philosofer1.Think += OnThink;
            helperOnThink = HelperOnThink;

            philosofer1.StartEat();
        }

        Helper helperOnThink;
        static Semaphore semaphore = new Semaphore(2, 4);
        Philosopher philosofer1 = null;


        public void OnPutFork(object sender, PhilosopherEventArgs e)
        {

        }
        public void OnEatEvent(object sender, PhilosopherEventArgs e)
        {

        }
        public void OnGivedFork(object sender, PhilosopherEventArgs e)
        {

        }
        void HelperOnThink(object sender, PhilosopherEventArgs e)
        {
            switch ((sender as Philosopher).Name)
            {
                case "0": { el0.Fill = Brushes.Black; label0.Content = e.obj1 as string; } break;
                case "1": { el1.Fill = Brushes.Black; } break;
                default:
                    break;
            }
        }

        public void OnThink(object sender, PhilosopherEventArgs e)
        {
            this.Dispatcher.Invoke(helperOnThink,sender,e);
        }
    }
}
