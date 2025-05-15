using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;
using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Races;
using FantasyPopulationSimulator.Console.Cultures;

namespace FantasyPopulationSimulator.Console
{
    public class InitialSetupHelper
    {
        private readonly ZoneManagement _zones;
        private readonly RootPopulationTracker _root;

        public InitialSetupHelper(ZoneManagement zones, RootPopulationTracker root)
        {
            _zones = zones;
            _root = root;
        }

        public void SetupEverquestThemedZones(Zone edenZone)
        {
            Zone freeportZone = CreateAndTrackNewZone("Freeport");
            Zone desertOfRoZone = CreateAndTrackNewZone("Desert Of Ro");
            Zone eastCommonlandsZone = CreateAndTrackNewZone("East Commonlands");

            _zones.AddAdjacentZone(edenZone, freeportZone, twoWayConnection: false);
            _zones.AddAdjacentZone(freeportZone, desertOfRoZone, twoWayConnection: true);
            _zones.AddAdjacentZone(freeportZone, eastCommonlandsZone, twoWayConnection: true);
        }

        public Zone CreateAndTrackNewZone(string zoneName)
        {
            var newZone = _zones.CreateNewZone(zoneName);
            _root.CreateTrackerForZone(newZone);
            return newZone;
        }

        public void GenerateAdam(ChildPopulationTracker pop, RandomNumberGenerator _rand, IZone currentZone, ConsoleUI ui, RandomNumberGenerator rand, NpcBehavior npcBehavior)
        {
            var adam = new Npc(new Human(), new DefaultCulture(_rand), currentZone, npcBehavior);

            adam.FirstName = "Adam";
            adam.AgeInDays = 16 * DaysInYear;
            adam.BirthDate = -16 * DaysInYear + 36;
            adam.Sex = Sex.Male;

            pop.Add(adam);
        }

        public void GenerateEve(ChildPopulationTracker pop, RandomNumberGenerator _rand, IZone currentZone, ConsoleUI ui, RandomNumberGenerator rand, NpcBehavior behavior)
        {
            var eve = new Npc(new Human(), new DefaultCulture(_rand), currentZone, behavior);

            eve.FirstName = "Eve";
            eve.AgeInDays = 16 * DaysInYear;
            eve.BirthDate = -16 * DaysInYear + 17;
            eve.Sex = Sex.Female;

            pop.Add(eve);
        }

    }
}
