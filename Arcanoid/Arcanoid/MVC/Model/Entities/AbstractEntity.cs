using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    public class AbstractEntity
    {
        Position position;
        char image;

        public Position Position
        {
            get
            {
                return position;
            }

            set
            {
                position = value;
            }
        }

        public char Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }
    }
}
