using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;
using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console
{
    internal partial class Program
    {

        static void Main(string[] args)
        {
            var rand = new RandomNumberGenerator(12); // todo:  12 seems arbitrary?

            var ui = new ConsoleUI();
            var popTracker = new RootPopulationTracker(rand, ui);
            ZoneManagement zones = new ZoneManagement();

            var edenZone = zones.CreateNewZone("Eden");
            var firstPop = popTracker.CreateTrackerForZone(edenZone);

            GenerateAdam(firstPop, rand, edenZone, ui);
            GenerateEve(firstPop, rand, edenZone, ui);

            SetupEverquestThemedZones(popTracker, zones, edenZone);

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
                        ui.EmitSummary(popTracker, currentYear);
                    }
                }

                popTracker.BlockUntilTickCompletes(day);

                day++;
            }


        }

        private static void SetupEverquestThemedZones(RootPopulationTracker popTracker, ZoneManagement zones, Zone edenZone)
        {
            Zone freeportZone = CreateAndTrackNewZone(popTracker, zones, "Freeport");
            Zone desertOfRoZone = CreateAndTrackNewZone(popTracker, zones, "Desert Of Ro");
            Zone eastCommonlandsZone = CreateAndTrackNewZone(popTracker, zones, "East Commonlands");

            zones.AddAdjacentZone(edenZone, freeportZone, twoWayConnection: false);
            zones.AddAdjacentZone(freeportZone, desertOfRoZone, twoWayConnection: true);
            zones.AddAdjacentZone(freeportZone, eastCommonlandsZone, twoWayConnection: true);
        }

        private static Zone CreateAndTrackNewZone(RootPopulationTracker popTracker, ZoneManagement zones, string zoneName)
        {
            var newZone = zones.CreateNewZone(zoneName);
            popTracker.CreateTrackerForZone(newZone);
            return newZone;
        }

        public static void GenerateAdam(PopulationTracker pop, RandomNumberGenerator _rand, IZone currentZone, ConsoleUI ui)
        {
            var adam = new Npc(pop, new Human(), new DefaultCulture(_rand), currentZone, ui);

            adam.FirstName = "Adam";
            adam.AgeInDays = 16 * DaysInYear;
            adam.BirthDate = -16 * DaysInYear + 36;
            adam.Sex = Sex.Male;

            pop.Add(adam);
        }

        public static void GenerateEve(PopulationTracker pop, RandomNumberGenerator _rand, IZone currentZone, ConsoleUI ui)
        {
            var eve = new Npc(pop, new Human(), new DefaultCulture(_rand), currentZone, ui);

            eve.FirstName = "Eve";
            eve.AgeInDays = 16 * DaysInYear;
            eve.BirthDate = -16 * DaysInYear + 17;
            eve.Sex = Sex.Female;

            pop.Add(eve);
        }



    }
}
