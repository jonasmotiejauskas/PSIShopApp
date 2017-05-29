using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSIShopApp
{
    class Vartotojas
    {
        public List<Krepselis> Krepseliai { get; }

        public Vartotojas()
        {
            Krepseliai = new List<Krepselis>();
        }
    }
}
