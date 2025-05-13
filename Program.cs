
namespace FantasyPopulationSimulator.Console
{

    internal partial class Program
    {

        static void Main(string[] args)
        {
            var rand = new RandomNumberGenerator(12); // todo:  12 seems arbitrary?
            var root = new RootPopulationTracker(rand);

            var firstZone = new Zone();
            var firstPop = root.CreateChildForZone(firstZone);

            GenerateAdam(firstPop, rand, firstZone);
            GenerateEve(firstPop, rand, firstZone);

            long day = 0;
            while (true)
            {
                if (day % Constants.DaysInYear == 0)
                {
                    int currentYear = (int)(day / Constants.DaysInYear);
                    System.Console.Clear();
                    System.Console.WriteLine($"Year: {currentYear}, NpcCount: {root.GetNpcCount()}");
                }

                root.BlockUntilTickCompletes(day);

                day++;
            }


        }

        public static void GenerateAdam(PopulationTracker pop, RandomNumberGenerator _rand, IZone currentZone)
        {
            var adam = new Npc(pop, new Human(), new DefaultCulture(_rand), currentZone);

            adam.FirstName = "Adam";
            adam.AgeInDays = 16 * Constants.DaysInYear;
            adam.BirthDate = -16 * Constants.DaysInYear + 36;
            adam.Sex = Sex.Male;

            pop.Add(adam);
        }

        public static void GenerateEve(PopulationTracker pop, RandomNumberGenerator _rand, IZone currentZone)
        {
            var eve = new Npc(pop, new Human(), new DefaultCulture(_rand), currentZone);

            eve.FirstName = "Eve";
            eve.AgeInDays = 16 * Constants.DaysInYear;
            eve.BirthDate = -16 * Constants.DaysInYear + 17;
            eve.Sex = Sex.Female;

            pop.Add(eve);
        }



    }
}
