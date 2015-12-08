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

        }
        public void Run()
        {
            //TODO move dublicate balls
            while (true)
            {
                model.Run();
                model.matrix.Refresh();
                view.Visualize();
                Thread.Sleep(100);
            }

            
        }
        Model model;
        View view;

        
    }
}
