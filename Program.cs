
namespace FantasyPopulationSimulator.Console
{

    internal partial class Program
    {

        static void Main(string[] args)
        {
            var rand = new RandomNumberGenerator(12); // todo:  12 seems arbitrary?
            var pop = new PopulationTracker(rand);   

            pop.GenerateAdam();
            pop.GenerateEve();

            long day = 0;
            while (true)
            {
                if (day % Constants.DaysInYear == 0)
                {
                    int currentYear = (int)(day / Constants.DaysInYear);
                    System.Console.WriteLine($"New Year Begins: {currentYear}");
                    //System.Console.ReadKey();
                }

                pop.TickPopulation(day);

                day++;
            }
        }



    }
}
