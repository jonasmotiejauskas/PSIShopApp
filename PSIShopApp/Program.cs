using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSIShopApp
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vartotojas> vartotojai = CreateVartotojai();
            List<Krepselis> krepseliai = CreateKrepseliai();
            Populate(vartotojai, krepseliai);

            Vartotojas vartotojasMain = vartotojai[0];

            MeniuLangas meniu = new MeniuLangas();
            StatistikosLangas statistika = new StatistikosLangas();
            StatistikosParametruLangas statParam = new StatistikosParametruLangas();

            string input = "";

            meniu.PakrautiMeniuLanga("");

            while (input != "1")
            {
                Console.WriteLine(meniu.ToString());
                input = Console.ReadLine();
            }

            meniu.Statistika_OnMouseClick(statParam, vartotojasMain);

            do
            {
                Console.WriteLine(statParam.ToString());

                input = Console.ReadLine();
                while (input != "0")
                {
                    statParam.PasirinktiKrepseli(input);
                    input = Console.ReadLine();
                }

                input = Console.ReadLine();
                string input2 = Console.ReadLine();

                while (!statParam.PasirinktiLaikotarpi(input, input2))
                {
                    input = Console.ReadLine();
                    input2 = Console.ReadLine();
                }

                statParam.Generuoti_OnMouseClick(statistika, "");
            }
            while (statParam.Perkrauti == true);

            Console.WriteLine(statistika.ToString());
            Console.Read();
        }

        static List<Vartotojas> CreateVartotojai()
        {
            List<Vartotojas> vartotojai = new List<Vartotojas>();
            vartotojai.Add(new Vartotojas());
            vartotojai.Add(new Vartotojas());
            vartotojai.Add(new Vartotojas());
            vartotojai.Add(new Vartotojas());

            return vartotojai;
        }

        static List<Krepselis> CreateKrepseliai()
        {
            List<Krepselis> krepseliai = new List<Krepselis>();
            krepseliai.Add(new Krepselis("Maisto prekės"));
            krepseliai.Add(new Krepselis("Mokyklinės priemonės"));
            krepseliai.Add(new Krepselis("Darbo prekės"));

            return krepseliai;
        }

        static void Populate(List<Vartotojas> vartotojai, List<Krepselis> krepseliai)
        {
            vartotojai[0].Krepseliai.AddRange(krepseliai);
            vartotojai[1].Krepseliai.Add(krepseliai[0]);
            vartotojai[2].Krepseliai.Add(krepseliai[0]);
            vartotojai[1].Krepseliai.Add(krepseliai[1]);
            vartotojai[3].Krepseliai.Add(krepseliai[1]);
            vartotojai[1].Krepseliai.Add(krepseliai[2]);

            krepseliai[0].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 26), 10, vartotojai[0], new TimeSpan(0, 10, 15)));
            krepseliai[0].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 26), 13.50, vartotojai[1], new TimeSpan(0, 12, 07)));
            krepseliai[0].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 27), 7, vartotojai[0], new TimeSpan(0, 7, 0)));
            krepseliai[0].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 27), 22.15, vartotojai[2], new TimeSpan(0, 20, 13)));
            krepseliai[0].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 27), 9.37, vartotojai[2], new TimeSpan(0, 17, 57)));
            krepseliai[0].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 27), 1.99, vartotojai[1], new TimeSpan(0, 3, 15)));
            krepseliai[0].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 28), 5.33, vartotojai[1], new TimeSpan(0, 5, 15)));
            krepseliai[0].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 28), 12.54, vartotojai[1], new TimeSpan(0, 5, 22)));
            krepseliai[0].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 28), 77.50, vartotojai[2], new TimeSpan(0, 47, 6)));
            krepseliai[0].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 29), 110.98, vartotojai[0], new TimeSpan(1, 10, 15)));
            krepseliai[1].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 26), 5.50, vartotojai[1], new TimeSpan(0, 10, 15)));
            krepseliai[1].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 28), 11.00, vartotojai[0], new TimeSpan(0, 12, 15)));
            krepseliai[1].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 28), 13.33, vartotojai[3], new TimeSpan(0, 13, 15)));
            krepseliai[2].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 26), 1000.57, vartotojai[0], new TimeSpan(1, 5, 0)));
            krepseliai[2].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 26), 533.11, vartotojai[0], new TimeSpan(0, 40, 15)));
            krepseliai[2].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 26), 220, vartotojai[0], new TimeSpan(0, 20, 35)));
            krepseliai[2].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 26), 357, vartotojai[1], new TimeSpan(0, 55, 15)));
            krepseliai[2].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 27), 567, vartotojai[1], new TimeSpan(0, 10, 15)));
            krepseliai[2].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 27), 58, vartotojai[1], new TimeSpan(0, 12, 15)));
            krepseliai[2].Apsipirkimai.Add(new Apsipirkimas(new DateTime(2017, 05, 29), 666, vartotojai[0], new TimeSpan(2, 37, 15)));
        }
    }
}
