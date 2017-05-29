using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSIShopApp
{
    class Apsipirkimas
    {
        public DateTime Data { get; }
        public double Islaidos { get; }
        public Vartotojas Pirkejas { get; }
        public TimeSpan Trukme { get; }
        public List<Pirkinys> Pirkiniai { get; }
        
        public Apsipirkimas(DateTime data, double islaidos, Vartotojas pirkejas, TimeSpan trukme)
        {
            Data = data;
            Islaidos = islaidos;
            Pirkejas = pirkejas;
            Trukme = trukme;
            Pirkiniai = new List<Pirkinys>();
        }
    }
}
