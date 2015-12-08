using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arcanoid
{
    public class Platform
    {
        public Platform(PlatformElement[] platform)
        {
            this.platform = platform;
        }

        public PlatformElement[] PlatformElements
        {
            get
            {
                return platform;
            }

            set
            {
                platform = value;
            }
        }

        PlatformElement[] platform;
    }
}
