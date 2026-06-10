using System;
using System.Collections.Generic;
using System.Text;

namespace Madu
{
    //играет звуки
    static class Heliefektid
    {
        public static void MängiSöömist()
        {
            // Käivitame uue ülesandena, et mäng ei jääks heli ootama
            Task.Run(() => Console.Beep(800, 100));
        }

        public static void MängiKaotust()
        {
            Task.Run(() => {
                Console.Beep(400, 200);
                Console.Beep(300, 200);
                Console.Beep(200, 400);
            });
        }
    }
}
