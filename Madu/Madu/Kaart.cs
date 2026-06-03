using System;
using System.Collections.Generic;
using System.Text;

namespace Madu
{
    class Kaart
    {
        public List<Punkt> Takistused { get; private set; } = new List<Punkt>();

        public Kaart(int laius, int kõrgus)
        {
            // Loome ümbermõõdu (välisseinad)
            for (int x = 0; x < laius; x++)
            {
                Takistused.Add(new Punkt(x, 0, '█'));
                Takistused.Add(new Punkt(x, kõrgus - 1, '█'));
            }
            for (int y = 0; y < kõrgus; y++)
            {
                Takistused.Add(new Punkt(0, y, '█'));
                Takistused.Add(new Punkt(laius - 1, y, '█'));
            }
        }

        public void Joonista()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            foreach (var p in Takistused) p.Joonista();

            Console.ResetColor();
        }
    }
}