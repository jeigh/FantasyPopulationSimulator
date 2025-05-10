
namespace FantasyPopulationSimulator.Console
{
    internal partial class Program
    {
        public const int DaysInYear = 350;

        static void Main(string[] args)
        {
            var pop = new PopulationTracker();

            pop.GenerateAdam();
            pop.GenerateEve();

            long day = 0;
            while (true)
            {
                if (day % DaysInYear == 0)
                {
                    int currentYear = (int)(day / DaysInYear);
                    System.Console.WriteLine($"New Year Begins: {currentYear}");
                    System.Console.ReadKey();
                }

                pop.TickPopulation(day);

                day++;
            }
        }



    }
}
