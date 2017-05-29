using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSIShopApp
{
    class Krepselis
    {
        public string Pavadinimas { get; }
        public List<Apsipirkimas> Apsipirkimai { get; }

        public Krepselis(string pavadinimas)
        {
            Pavadinimas = pavadinimas;
            Apsipirkimai = new List<Apsipirkimas>();
        }

        public override string ToString()
        {
            return Pavadinimas;
        }
    }
}
