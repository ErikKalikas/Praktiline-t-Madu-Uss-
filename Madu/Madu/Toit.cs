using System;

namespace Madu
{
    class Toit
    {
        private Random rnd = new Random();
        private int ekraaniLaius;
        private int ekraaniKõrgus;

        public Punkt Asukoht { get; private set; }
        public Punkt BonusAsukoht { get; private set; }
        public bool KasBonusOnAktiivne { get; private set; }

        public Toit(int laius, int kõrgus)
        {
            ekraaniLaius = laius;
            ekraaniKõrgus = kõrgus;
            KasBonusOnAktiivne = false;
            LooUusToit();
        }

        public void LooUusToit()
        {
            int x = rnd.Next(2, ekraaniLaius - 2);
            int y = rnd.Next(2, ekraaniKõrgus - 1);

            if (KasBonusOnAktiivne && BonusAsukoht != null && x == BonusAsukoht.X && y == BonusAsukoht.Y)
            {
                x = (x + 2) % (ekraaniLaius - 2);
            }

            Asukoht = new Punkt(x, y, '█');

            Console.ForegroundColor = ConsoleColor.DarkRed;
            Asukoht.Joonista();
            Console.ResetColor();
        }

        public void LooUusBonus()
        {
            if (KasBonusOnAktiivne && BonusAsukoht != null)
            {
                BonusAsukoht.Kustuta();
            }

            int x = rnd.Next(2, ekraaniLaius - 2);
            int y = rnd.Next(2, ekraaniKõrgus - 1);

            if (x == Asukoht.X && y == Asukoht.Y)
            {
                x = (x + 2) % (ekraaniLaius - 2);
            }

            BonusAsukoht = new Punkt(x, y, '█');
            KasBonusOnAktiivne = true;

            Console.ForegroundColor = ConsoleColor.Yellow;
            BonusAsukoht.Joonista();
            Console.ResetColor();
        }

        public void KustutaBonus()
        {
            if (KasBonusOnAktiivne && BonusAsukoht != null)
            {
                BonusAsukoht.Kustuta();
                KasBonusOnAktiivne = false;
            }
        }
    }
}