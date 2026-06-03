using System;
using System.Collections.Generic;
using System.Text;

namespace Madu
{
    static class Edetabel
    {
        private static string failiTee = "skoorid.txt";

        public static void Salvesta(string nimi, int skoor)
        {
            File.AppendAllLines(failiTee, new[] { $"{nimi};{skoor}" });
        }

        public static void KuvaEdetabel()
        {
            if (!File.Exists(failiTee)) return;

            var skoorid = File.ReadAllLines(failiTee)
                .Select(rida => rida.Split(';'))
                .Select(osad => new { Nimi = osad[0], Punktid = int.Parse(osad[1]) })
                .OrderByDescending(x => x.Punktid)
                .Take(5); // Ainult TOP 5

            Console.Clear();
            Console.WriteLine("--- TOP 5 EDETABEL ---");
            foreach (var s in skoorid)
            {
                Console.WriteLine($"{s.Nimi}: {s.Punktid}");
            }
        }
    }
}
