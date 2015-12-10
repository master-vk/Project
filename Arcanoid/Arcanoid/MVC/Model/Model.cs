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
        public Model(int HIGH, int LONG)
        {
            this.layer = LayoutInitializer.Initialize(HIGH, LONG);
            this.space = new Space(HIGH, LONG, layer);
            this.ballManager = new BallManager(space, layer);

            ballManager.SendChanges += OnShow;
            SendMove += space.OnSendMove;
        }
        
        public void OnShow(object sender, SendEventArgs e)
        {
            Show(this, new SendEventArgs(layer));
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
            }
        }

        BallManager ballManager;
        ILayerable layer;
        Space space;
    }
}
