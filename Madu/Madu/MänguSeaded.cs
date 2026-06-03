namespace Madu
{
    class MänguSeaded
    {
        public int Laius { get; set; }
        public int Kõrgus { get; set; }
        public int KiirusMS { get; set; }

        public MänguSeaded(int tase)
        {
            switch (tase)
            {
                case 1: KiirusMS = 200; Laius = 40; Kõrgus = 20; break;
                case 2: KiirusMS = 100; Laius = 30; Kõrgus = 15; break;
                case 3: KiirusMS = 50; Laius = 25; Kõrgus = 12; break;
                default: KiirusMS = 150; Laius = 40; Kõrgus = 20; break;
            }
        }
    }
}