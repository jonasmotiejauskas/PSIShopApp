using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSIShopApp
{
    class Pirkinys
    {
        public int Kiekis { get; }
        public bool Patvirtintas { get; set; }
        public Preke EsantiPreke { get; }

        public Pirkinys(int kiekis, bool patvirtinimas, Preke preke)
        {
            Kiekis = kiekis;
            Patvirtintas = patvirtinimas;
            EsantiPreke = preke;
        }
    }
}
