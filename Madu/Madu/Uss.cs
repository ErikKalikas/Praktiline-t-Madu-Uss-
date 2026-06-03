namespace Madu
{
    class Uss
    {
        private List<Punkt> keha = new List<Punkt>();
        public Suund PraeguneSuund { get; set; }

        public Uss(int algX, int algY, int pikkus)
        {
            PraeguneSuund = Suund.Paremale;
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < pikkus; i++)
            {
                Punkt p = new Punkt(algX - i, algY, '█');
                keha.Add(p);
                p.Joonista();
            }
            Console.ResetColor();
        }

        public void Liigu()
        {
            Punkt pea = keha.First();
            Punkt uusPea = new Punkt(pea.X, pea.Y, '█');

            switch (PraeguneSuund)
            {
                case Suund.Paremale: uusPea.X++; break;
                case Suund.Vasakule: uusPea.X--; break;
                case Suund.Alla: uusPea.Y++; break;
                case Suund.Üles: uusPea.Y--; break;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            keha.Insert(0, uusPea);
            uusPea.Joonista();
            Console.ResetColor();

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
            keha.Add(new Punkt(keha.Last().X, keha.Last().Y, '█'));
        }

        public bool KasPõrkasKokkuEndaga()
        {
            Punkt pea = keha.First();
            return keha.Skip(1).Any(p => p.X == pea.X && p.Y == pea.Y);
        }
    }
}