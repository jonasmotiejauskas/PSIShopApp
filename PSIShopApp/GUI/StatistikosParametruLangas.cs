using System;
using System.Collections.Generic;
using System.Linq;

namespace PSIShopApp
{
    class StatistikosParametruLangas
    {
        public List<string> Buttons;
        public List<Krepselis> Krepseliai;
        public DateTime[] Laikotarpis;
        private string KlaidosPranesimas;
        private List<Krepselis> KrepseliaiPasirinkti;

        //prototipui only
        public bool Perkrauti = false;

        public StatistikosParametruLangas()
        {

        }

        public void PakrautiStatistikosParametruLanga(List<Krepselis> krepseliai, string klaidosPranesimas)
        {
            Buttons = new List<string>();
            Laikotarpis = new DateTime[2];
            KrepseliaiPasirinkti = new List<Krepselis>();

            Buttons.Add("Generuoti");

            Krepseliai = krepseliai;
            KlaidosPranesimas = klaidosPranesimas;
        }

        public void Generuoti_OnMouseClick(StatistikosLangas statistikosLangas, string klaidosPranesimas)
        {
            if (ValiduotiKrepseliuSarasaIrLaikotarpi())
            {
                List<Apsipirkimas> apsipirkimai = GautiApsipirkimus();

                if (ValiduotiApsipirkimus(apsipirkimai))
                {
                    statistikosLangas.PakrautiStatistikosLanga(apsipirkimai, "");
                }
                else
                {
                    Perkrauti = true;
                    PakrautiStatistikosParametruLanga(Krepseliai, "Pasirinktu laikotarpiu apsipirkimu nera");
                }
            }
            else
            {
                Perkrauti = true;
                PakrautiStatistikosParametruLanga(Krepseliai, "Nepasirinktas nei vienas krepselis");
            }
        }

        public bool ValiduotiKrepseliuSarasaIrLaikotarpi()
        {
            bool galimaGeneruoti = true;

            if (KrepseliaiPasirinkti.Count <= 0) galimaGeneruoti = false;

            try
            {
                TimeSpan laikotarpis = Laikotarpis[1].Subtract(Laikotarpis[0]);

                if(laikotarpis == TimeSpan.MinValue) galimaGeneruoti = false;
            }
            catch(ArgumentOutOfRangeException e)
            {
                galimaGeneruoti = false;
            }

            return galimaGeneruoti;
        }

        public List<Apsipirkimas> GautiApsipirkimus()
        {
            List<Apsipirkimas> apsipirkimai = KrepseliaiPasirinkti.SelectMany(aps => aps.Apsipirkimai).ToList();
            List<Apsipirkimas> apsipirkimaiLaik = 
                apsipirkimai.FindAll(aps => aps.Data.CompareTo(Laikotarpis[0]) > -1 && aps.Data.CompareTo(Laikotarpis[1]) < 1);

            return apsipirkimaiLaik;
        }

        public bool ValiduotiApsipirkimus(List<Apsipirkimas> apsipirkimai)
        {
            return apsipirkimai.Count > 0;
        }

        //prototipui only

        public void PasirinktiKrepseli(string pasirinkimas)
        {
            int num;
            if(int.TryParse(pasirinkimas, out num))
            {
                try
                {
                    if (!KrepseliaiPasirinkti.Contains(Krepseliai[num - 1]))
                        KrepseliaiPasirinkti.Add(Krepseliai[num - 1]);
                }
                catch(ArgumentOutOfRangeException e)
                {

                }
            }
        }

        //prototipui only, tikrame projekte butu ne konsoline programa, todel pasirinkimas nebutu bool.
        public bool PasirinktiLaikotarpi(string pradzia, string pabaiga)
        {
            bool geraData = true;

            try
            {
                Laikotarpis[0] = DateTime.ParseExact(pradzia, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                Laikotarpis[1] = DateTime.ParseExact(pabaiga, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch(Exception e)
            {
                geraData = false;
            }

            return geraData;
        }

        public override string ToString()
        {
            string toPrint = "";

            toPrint += KlaidosPranesimas + "\n\n";

            for (int i = 0; i < Krepseliai.Count; i++)
            {
                int curKrepselis = i + 1;
                toPrint += curKrepselis + ". " + Krepseliai[i].ToString() + "\n";
            }

            toPrint += "\n" +
                       "Veskite krepšelio numerius, kad pasirinkti krepšelius statistikai. \n" +
                       "Rašykite 0, kad nutraukti krepšelių rinkimasi. \n" +
                       "Tuomet rašykite laikotarpį. Rašykite pirma pradžios tada pabaigos datą. (formatas yyyy-mm-dd). \n";

            return toPrint;
        }
    }
}
