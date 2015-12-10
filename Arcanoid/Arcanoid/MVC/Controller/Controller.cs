using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arcanoid
{
    class Controller
    {
        public Controller()
        {
            this.view = new View();
            this.model = new Model(view.High, view.Long);
            

            model.Show += view.OnShow;
            view.SendMove += model.OnSendMove;
            t = new Thread(view.Run);
        }
        
        public void Run()
        {
            t.Start();
            model.Run();
        }
        Thread t;
        Model model;
        View view;

        
    }
}
