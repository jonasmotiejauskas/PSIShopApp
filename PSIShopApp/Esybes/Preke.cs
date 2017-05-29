using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSIShopApp
{
    class Preke
    {
        public string Pavadinimas { get; }
        public string VienetoPav { get; }

        public Preke(string pavadinimas, string vienetoPav)
        {
            Pavadinimas = pavadinimas;
            VienetoPav = vienetoPav;
        }
    }
}
