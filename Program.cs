using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;
using FantasyPopulationSimulator.Console.Constants;

namespace FantasyPopulationSimulator.Console
{

    

    internal partial class Program
    {

        static void Main(string[] args)
        {
            var rand = new RandomNumberGenerator(12); // todo:  12 seems arbitrary?
            
            var ui = new ConsoleUI();
            var root = new RootPopulationTracker(rand, ui);

            var firstZone = new Zone();
            firstZone.ZoneName = "Eden";

            var firstPop = root.CreateChildForZone(firstZone);

            GenerateAdam(firstPop, rand, firstZone, ui);
            GenerateEve(firstPop, rand, firstZone, ui);

            long day = 0;
            while (true)
            {
                if (day % DaysInYear == 0)
                {
                    int currentYear = (int)(day / DaysInYear);
                    ui.Clear();
                    //ui.DeclareYear(currentYear, root.GetNpcCount());

                    if (day % DaysInYear == 0)
                    {
                        ui.EmitSummary(root, currentYear);
                    }                    
                }

                root.BlockUntilTickCompletes(day);

                day++;
            }


        }

        public static void GenerateAdam(PopulationTracker pop, RandomNumberGenerator _rand, IZone currentZone, ConsoleUI ui)
        {
            var adam = new Npc(pop, new Human(), new DefaultCulture(_rand), currentZone, ui);

            adam.FirstName = "Adam";
            adam.AgeInDays = 16 * DaysInYear;
            adam.BirthDate = -16 * DaysInYear + 36;
            adam.Sex = Constants.Sex.Male;

            pop.Add(adam);
        }

        public static void GenerateEve(PopulationTracker pop, RandomNumberGenerator _rand, IZone currentZone, ConsoleUI ui)
        {
            var eve = new Npc(pop, new Human(), new DefaultCulture(_rand), currentZone, ui);

            eve.FirstName = "Eve";
            eve.AgeInDays = 16 * DaysInYear;
            eve.BirthDate = -16 * DaysInYear + 17;
            eve.Sex = Constants.Sex.Female;

            pop.Add(eve);
        }



    }
}
