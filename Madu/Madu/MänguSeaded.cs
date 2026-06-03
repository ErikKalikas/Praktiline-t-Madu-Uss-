using System;
using System.Collections.Generic;
using System.Text;

namespace Madu
{
    class MänguSeaded
    {
        public int Laius { get; set; }
        public int Kõrgus { get; set; }
        public int KiirusMS { get; set; } // Viivitus millisekundites

        public MänguSeaded(int tase)
        {
            // Raskusastme valik (1 - Lihtne, 2 - Keskmine, 3 - Raske)
            switch (tase)
            {
                case 1: KiirusMS = 200; Laius = 40; Kõrgus = 20; break;
                case 2: KiirusMS = 100; Laius = 30; Kõrgus = 15; break;
                case 3: KiirusMS = 50; Laius = 20; Kõrgus = 10; break;
                default: KiirusMS = 150; Laius = 40; Kõrgus = 20; break;
            }
        }
    }
}
