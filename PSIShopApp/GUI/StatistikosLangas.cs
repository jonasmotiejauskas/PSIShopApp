using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSIShopApp
{
    class StatistikosLangas
    {
        public Statistika EsamaStatistika;
        public string KlaidosPranesimas;

        public StatistikosLangas()
        {

        }

        public void PakrautiStatistikosLanga(List<Apsipirkimas> apsipirkimas, string klaidosPranesimas)
        {
            KlaidosPranesimas = klaidosPranesimas;

            EsamaStatistika = GeneruotiStatistika(apsipirkimas);
        }

        private Statistika GeneruotiStatistika(List<Apsipirkimas> apsipirkimas)
        {
            Statistika statistika = new Statistika();

            double vidIsl = 0;
            double bendrIsl = 0;
            TimeSpan bendrTrukme = new TimeSpan(0);
            TimeSpan maxTrukme = TimeSpan.MinValue;
            TimeSpan minTrukme = TimeSpan.MaxValue;
            TimeSpan vidTrukme = new TimeSpan(0);

            foreach(Apsipirkimas aps in apsipirkimas)
            {
                vidIsl += aps.Islaidos;
                bendrIsl += aps.Islaidos;
                bendrTrukme += aps.Trukme;
                if (maxTrukme < aps.Trukme) maxTrukme = aps.Trukme;
                if (minTrukme > aps.Trukme) minTrukme = aps.Trukme;
                vidTrukme += aps.Trukme;
            }

            vidIsl /= apsipirkimas.Count;
            vidTrukme = new TimeSpan(vidTrukme.Ticks / apsipirkimas.Count);

            statistika.BendraApsipirkimoTrukme = bendrTrukme;
            statistika.BendrosIslaidos = bendrIsl;
            statistika.MaksimaliApsipirkimoTrukme = maxTrukme;
            statistika.MinimaliApsipirkimoTrukme = minTrukme;
            statistika.VidutineApsipirkimoTrukme = vidTrukme;
            statistika.VidutinesIslaidos = vidIsl;

            return statistika;
        }

        public override string ToString()
        {
            string toPrint = "";

            toPrint += KlaidosPranesimas + "\n\n";

            toPrint += "Vidutinės išlaidos: " + EsamaStatistika.VidutinesIslaidos + "\n";
            toPrint += "Bendros išlaidos: " + EsamaStatistika.BendrosIslaidos + "\n\n";
            toPrint += "Bendra apsipirkimo trukmė: " + EsamaStatistika.BendraApsipirkimoTrukme + "\n";
            toPrint += "Maksimali apsipirkimo trukmė: " + EsamaStatistika.MaksimaliApsipirkimoTrukme + "\n";
            toPrint += "Minimali apsipirkimo trukmė: " + EsamaStatistika.MinimaliApsipirkimoTrukme + "\n";
            toPrint += "Vidutinė apsipirkimo trukmė: " + EsamaStatistika.VidutineApsipirkimoTrukme + "\n";

            return toPrint;
        }
    }
}
