using System;
using System.Collections.Generic;

namespace Madu
{
    class Kaart
    {
        public List<Punkt> Takistused { get; private set; } = new List<Punkt>();
        private int laius;

        public Kaart(int laius, int kõrgus)
        {
            this.laius = laius;

            for (int x = 0; x < laius; x++)
            {
                Takistused.Add(new Punkt(x, 1, '█'));
                Takistused.Add(new Punkt(x, kõrgus, '█'));
            }
            for (int y = 1; y <= kõrgus; y++)
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

            UuendaSkoor(0);
            UuendaTaimer(10);
        }

        public void UuendaSkoor(int skoor)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(2, 0);
            Console.Write($"Skoor: {skoor}  ");
            Console.ResetColor();
        }

        public void UuendaTaimer(int sekundid)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(18, 0);
            Console.Write($"Aeg: {sekundid}s   ");
            Console.ResetColor();
        }
    }
}