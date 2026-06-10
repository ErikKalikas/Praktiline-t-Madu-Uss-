using System;
using System.Diagnostics;
using System.Threading;

namespace Madu
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;

            int tase = 1;
            bool taseValitud = false;

            while (!taseValitud)
            {
                Console.Clear();
                Console.WriteLine("--- VALI RASKUSASTE ---");
                Console.WriteLine(tase == 1 ? "> 1. Kerge" : "  1. Kerge");
                Console.WriteLine(tase == 2 ? "> 2. Keskmine" : "  2. Keskmine");
                Console.WriteLine(tase == 3 ? "> 3. Raske" : "  3. Raske");
                Console.WriteLine("\nKasuta nooli (Ules/Alla) ja vajuta Enter...");

                ConsoleKeyInfo klahv = Console.ReadKey(true);

                if (klahv.Key == ConsoleKey.UpArrow || klahv.Key == ConsoleKey.W)
                {
                    tase--;
                    if (tase < 1) tase = 3;
                }
                else if (klahv.Key == ConsoleKey.DownArrow || klahv.Key == ConsoleKey.S)
                {
                    tase++;
                    if (tase > 3) tase = 1;
                }
                else if (klahv.Key == ConsoleKey.Enter)
                {
                    taseValitud = true;
                }
            }

            Console.Clear();

            MänguSeaded seaded = new MänguSeaded(tase);

            Console.SetWindowSize(seaded.Laius + 5, seaded.Kõrgus + 5);
            Console.SetBufferSize(seaded.Laius + 5, seaded.Kõrgus + 5);

            Kaart kaart = new Kaart(seaded.Laius, seaded.Kõrgus);
            kaart.Joonista();

            Uss uss = new Uss(seaded.Laius / 2, (seaded.Kõrgus / 2) + 1, 3);
            Toit toit = new Toit(seaded.Laius, seaded.Kõrgus);

            int skoor = 0;
            bool mängKäib = true;
            int sekundiTaimer = 10;

            Stopwatch taimer = new Stopwatch();
            Stopwatch sekundiMootja = new Stopwatch();

            taimer.Start();
            sekundiMootja.Start();

            Suund uusSuund = uss.PraeguneSuund;

            while (mängKäib)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo klahv = Console.ReadKey(true);

                    switch (klahv.Key)
                    {
                        case ConsoleKey.UpArrow:
                        case ConsoleKey.W:
                            if (uss.PraeguneSuund != Suund.Alla) uusSuund = Suund.Üles;
                            break;
                        case ConsoleKey.DownArrow:
                        case ConsoleKey.S:
                            if (uss.PraeguneSuund != Suund.Üles) uusSuund = Suund.Alla;
                            break;
                        case ConsoleKey.LeftArrow:
                        case ConsoleKey.A:
                            if (uss.PraeguneSuund != Suund.Paremale) uusSuund = Suund.Vasakule;
                            break;
                        case ConsoleKey.RightArrow:
                        case ConsoleKey.D:
                            if (uss.PraeguneSuund != Suund.Vasakule) uusSuund = Suund.Paremale;
                            break;
                    }

                    while (Console.KeyAvailable) { Console.ReadKey(true); }
                }

                if (sekundiMootja.ElapsedMilliseconds >= 1000)
                {
                    sekundiMootja.Restart();
                    sekundiTaimer--;

                    if (sekundiTaimer < 0)
                    {
                        sekundiTaimer = 10;
                        toit.LooUusBonus();
                    }

                    kaart.UuendaTaimer(sekundiTaimer);
                }

                if (taimer.ElapsedMilliseconds >= seaded.KiirusMS)
                {
                    taimer.Restart();

                    uss.PraeguneSuund = uusSuund;
                    uss.Liigu();

                    Punkt pea = uss.HangiPea();

                    if (pea.X == toit.Asukoht.X && pea.Y == toit.Asukoht.Y)
                    {
                        uss.Kasva();
                        skoor += 10;
                        kaart.UuendaSkoor(skoor);
                        Heliefektid.MängiSöömist();
                        toit.LooUusToit();
                    }
                    else if (toit.KasBonusOnAktiivne && pea.X == toit.BonusAsukoht.X && pea.Y == toit.BonusAsukoht.Y)
                    {
                        uss.Kasva();
                        skoor += 20;
                        kaart.UuendaSkoor(skoor);
                        Heliefektid.MängiSöömist();
                        toit.KustutaBonus();
                    }

                    foreach (var takistus in kaart.Takistused)
                    {
                        if (pea.X == takistus.X && pea.Y == takistus.Y)
                        {
                            mängKäib = false;
                            break;
                        }
                    }

                    if (uss.KasPõrkasKokkuEndaga())
                    {
                        mängKäib = false;
                    }
                }

                Thread.Sleep(5);
            }

            Heliefektid.MängiKaotust();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("MÄNG LÄBI!");
            Console.ResetColor();
            Console.WriteLine($"Sinu skoor: {skoor}");

            Console.Write("Sisesta oma nimi edetabeli jaoks: ");
            string nimi = Console.ReadLine();

            if (!string.IsNullOrEmpty(nimi))
            {
                Edetabel.Salvesta(nimi, skoor);
            }

            Edetabel.KuvaEdetabel();
            Console.WriteLine("\nVajuta mis tahes klahvi lõpetamiseks...");
            Console.ReadKey();
        }
    }
}