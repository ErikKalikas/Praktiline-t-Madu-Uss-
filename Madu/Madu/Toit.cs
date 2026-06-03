using System;
using System.Collections.Generic;
using System.Text;

namespace Madu
{
    class Toit
    {
        private Random rnd = new Random();
        private int ekraaniLaius;
        private int ekraaniKõrgus;
        public Punkt Asukoht { get; private set; }

        public Toit(int laius, int kõrgus)
        {
            ekraaniLaius = laius;
            ekraaniKõrgus = kõrgus;
            LooUusToit(); // Loome kohe alguses esimese toidu
        }

        public void LooUusToit()
        {
            int x = rnd.Next(2, ekraaniLaius - 2);
            int y = rnd.Next(2, ekraaniKõrgus - 2);
            Asukoht = new Punkt(x, y, '@'); // Toit näeb välja nagu '@'
            Asukoht.Joonista();
        }
    }
}
