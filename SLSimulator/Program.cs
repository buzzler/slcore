namespace SLSimulator
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var house = new SLCore.Entity.GameHouse();
            house.AddClient();
            house.AddClient();
            house.AddObserver();
            house.Start();
            while (true)
                house.Loop();
        }
    }
}