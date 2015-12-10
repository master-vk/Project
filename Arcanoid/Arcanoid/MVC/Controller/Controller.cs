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
            this.model = new Model();
            this.view = new View(model.matrix);
            model.Show += view.OnShow;
            view.SendMove += model.OnSendMove;
            t = new Thread(view.Run);
        }
        Thread t;
        public void Run()
        {
            t.Start();
            model.Run();
        }
        Model model;
        View view;

        
    }
}
