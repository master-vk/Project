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
            model.ballManager.Show += view.OnShow;
        }
        public void Run()
        {
            //TODO move dublicate balls
            while (true)
            {
                model.Run();
               
            }

            
        }
        Model model;
        View view;

        
    }
}
