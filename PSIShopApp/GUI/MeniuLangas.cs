using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSIShopApp
{
    class MeniuLangas
    {
        public List<String> Buttons;
        public string KlaidosPranesimas;

        public MeniuLangas()
        {
            Buttons = new List<string>();
        }

        public void PakrautiMeniuLanga(string klaidosPranesimas)
        {
            Buttons.Add("Statistika");
            Buttons.Add("Nustatymai");

            KlaidosPranesimas = klaidosPranesimas;
        }

        public void Statistika_OnMouseClick(StatistikosParametruLangas statistikosParametruLangas, Vartotojas vartotojas)
        {
            statistikosParametruLangas.PakrautiStatistikosParametruLanga(vartotojas.Krepseliai, "");
        }

        public override string ToString()
        {
            string toPrint = "";

            toPrint += KlaidosPranesimas + "\n\n";

            for (int i = 0; i < Buttons.Count; i++)
            {
                int curButton = i + 1;
                toPrint += curButton + ". " + Buttons[i] + "\n";
            }

            return toPrint;
        }
    }
}
