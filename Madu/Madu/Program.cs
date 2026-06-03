namespace Madu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Mängu algus ja seadistamine
            Console.WriteLine("Vali raskus (1-3): ");
            int tase = int.Parse(Console.ReadLine());
            MänguSeaded seaded = new MänguSeaded(tase);

            Console.SetWindowSize(seaded.Laius + 2, seaded.Kõrgus + 2);
            Kaart kaart = new Kaart(seaded.Laius, seaded.Kõrgus);
            Uss uss = new Uss(seaded.Laius / 2, seaded.Kõrgus / 2, 3);
            Toit toit = new Toit(seaded.Laius, seaded.Kõrgus);
            int skoor = 0;

            kaart.Joonista();

            // 2. Mängu peatsükkel
            while (true)
            {
                // ... sisendi lugemine ...

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo klahv = Console.ReadKey(true);

                    // Muudame suunda, aga väldime tagurdamist
                    if (klahv.Key == ConsoleKey.UpArrow && uss.PraeguneSuund != Suund.Alla)
                        uss.PraeguneSuund = Suund.Üles;
                    else if (klahv.Key == ConsoleKey.DownArrow && uss.PraeguneSuund != Suund.Üles)
                        uss.PraeguneSuund = Suund.Alla;
                    else if (klahv.Key == ConsoleKey.LeftArrow && uss.PraeguneSuund != Suund.Paremale)
                        uss.PraeguneSuund = Suund.Vasakule;
                    else if (klahv.Key == ConsoleKey.RightArrow && uss.PraeguneSuund != Suund.Vasakule)
                        uss.PraeguneSuund = Suund.Paremale;
                }

                uss.Liigu();
                Punkt pea = uss.HangiPea();

                // Kokkupõrge seinaga (takistusega)
                if (kaart.Takistused.Any(t => t.X == pea.X && t.Y == pea.Y))
                {
                    Heliefektid.MängiKaotust();
                    break;
                }

                
                if (uss.KasPõrkasKokkuEndaga())
                {
                    Heliefektid.MängiKaotust();
                    break;
                }

                // Toidu söömine
                if (pea.X == toit.Asukoht.X && pea.Y == toit.Asukoht.Y)
                {
                    skoor += 10;
                    uss.Kasva();
                    toit.LooUusToit();
                    Heliefektid.MängiSöömist();
                }

                Thread.Sleep(seaded.KiirusMS);
            }

            // 3. Pärast mängu lõppu
            Console.Clear();
            Console.Write("Mäng läbi! Sisesta oma nimi: ");
            string nimi = Console.ReadLine();
            Edetabel.Salvesta(nimi, skoor);
            Edetabel.KuvaEdetabel();
        }
    }
}