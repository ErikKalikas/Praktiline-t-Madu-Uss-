using System;
using System.Collections.Generic;
using System.Text;

namespace Madu
{
    //Умеет нарисовать и стереть себя в консоли
    class Punkt
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Sümbol { get; set; } // Näiteks '*' ussi jaoks, '@' toidu jaoks
        public Punkt(int x, int y, char sümbol)
        {
            X = x;
            Y = y;
            Sümbol = sümbol;
        }

        // See meetod joonistab punkti konsooli õigesse kohta
        public void Joonista()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(Sümbol);
        }

        // Puhastab eelmise asukoha (kui uss liigub edasi)
        public void Kustuta()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(' '); // Kirjutame tühiku peale
        }
    }
}
