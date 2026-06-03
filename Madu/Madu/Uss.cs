using System;
using System.Collections.Generic;
using System.Text;

namespace Madu
{
    /*
     * Uss on List<Punkt>,
     * kus esimene element on pea ja viimane on sabaots.
     * Liikumise loogika on lihtne: lisame liikumissuunas uue "pea" ja kustutame "saba" (viimase elemendi).
     * Kui uss sööb toidu,
     * siis me lihtsalt ei kustuta saba ja uss muutub ühe punkti võrra pikemaks!
     */
    class Uss
    {
        private List<Punkt> keha = new List<Punkt>();
        public Suund PraeguneSuund { get; set; }

        public Uss(int algX, int algY, int pikkus)
        {
            PraeguneSuund = Suund.Paremale; // Alguses liigub paremale

            // Loome ussi algse keha
            for (int i = 0; i < pikkus; i++)
            {
                Punkt p = new Punkt(algX - i, algY, '*');
                keha.Add(p);
                p.Joonista();
            }
        }

        public void Liigu()
        {
            // 1. Leiame praeguse pea asukoha
            Punkt pea = keha.First();
            Punkt uusPea = new Punkt(pea.X, pea.Y, '*');

            // 2. Arvutame uue pea asukoha vastavalt suunale
            switch (PraeguneSuund)
            {
                case Suund.Paremale: uusPea.X++; break;
                case Suund.Vasakule: uusPea.X--; break;
                case Suund.Alla: uusPea.Y++; break;
                case Suund.Üles: uusPea.Y--; break;
            }

            // 3. Lisame uue pea listi algusesse ja joonistame
            keha.Insert(0, uusPea);
            uusPea.Joonista();

            // 4. Kustutame sabaotsa (viimase elemendi), et simuleerida liikumist
            Punkt saba = keha.Last();
            saba.Kustuta();
            keha.Remove(saba);
        }

        public Punkt HangiPea()
        {
            return keha.First();
        }
        public void Kasva()
        {
            // Kasvamine on lihtne - lisame saba lõppu lihtsalt uue nähtamatu punkti, 
            // mis järgmise liikumise ajal asendab päris saba.
            // Lihtsuse mõttes võime lihtsalt järgmisel liikumisel saba mitte kustutada!
            // Siin lisame lihtsalt ajutise koopia viimasest elemendist.
            keha.Add(new Punkt(keha.Last().X, keha.Last().Y, '*'));
        }
    }
}
