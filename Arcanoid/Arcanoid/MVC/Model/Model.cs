using Arcanoid.MVC.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Arcanoid
{
    public delegate void ModelDelegate(object sender, SendEventArgs e);
    class Model
    {
        public Model()
        {
            this.layout = new Layout();
            LayoutInitializer.Initialize(this.layout,new Matrix().High,new Matrix().Long);
            this.matrix = new Matrix(this.layout);
            this.space = new Space(matrix, layout);
            this.ballManager = new BallManager(space, layout);
            ballManager.Show += OnShow;
            SendMove += space.OnSendMove;

        }
        // TODO delete Matrix and change on int
        public Matrix matrix;
        public void OnShow(object sender, SendEventArgs e)
        {
            Show(this, new SendEventArgs(layout));
        }
        public void OnSendMove(object sender, SendEventArgs e)
        {
            SendMove(sender, e);
        }
        public event ModelDelegate Show;
        public event ModelDelegate SendMove;
        public void Run()
        {
            while (true)
            {
                ballManager.BallMoveNext();
                //break;
            }
            
        }

        BallManager ballManager;
       
        Layout layout;
        Space space;
    }
}
