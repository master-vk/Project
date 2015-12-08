using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    class Model
    {
        public Model()
        {
            this.layout = new Layout();
            LayoutInitializer.Initialize(this.layout,new Matrix().High,new Matrix().Long);
            this.matrix = new Matrix(this.layout);
            this.space = new Space(matrix, layout);
            this.ballManager = new BallManager(space, layout);
        }
        // TODO delete Matrix and change on int
        public Matrix matrix;
        

        public void Run()
        {
            while (true)
            {
                ballManager.BallMoveNext();
                break;
            }
            
        }

        BallManager ballManager;
        Layout layout;
        Space space;
    }
}
