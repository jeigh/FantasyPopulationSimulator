using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;
using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Races;
using FantasyPopulationSimulator.Console.Cultures;
using FantasyPopulationSimulator.Console.Entities;

namespace FantasyPopulationSimulator.Console.Services
{
    public class InitialSetupHelper
    {
        private readonly ZoneManagement _zones;
        private readonly RandomNumberGenerator _rand;
        private readonly NpcBehavior _npcs;
        private readonly TraitCatalogue _traits;
        private readonly TrackerFactory _trackerFactory;


        public InitialSetupHelper(ZoneManagement zones, RandomNumberGenerator rand, NpcBehavior npcs, TraitCatalogue traits, TrackerFactory trackerFactory)
        {
            _zones = zones;
            _rand = rand;
            _npcs = npcs;
            _traits = traits;
            _trackerFactory = trackerFactory;
        }

        public void SetupEverquestThemedZones(Zone edenZone, Zone darkElfEden)
        {
            Zone freeportZone = CreateAndTrackNewZone("Freeport");
            Zone desertOfRoZone = CreateAndTrackNewZone("Desert Of Ro");
            Zone eastCommonlandsZone = CreateAndTrackNewZone("East Commonlands");
            Zone neriakZone = CreateAndTrackNewZone("Neriak");
            Zone nektulosZone = CreateAndTrackNewZone("Nektulos Forest");

            _zones.AddAdjacentZone(edenZone, freeportZone, twoWayConnection: false);
            _zones.AddAdjacentZone(freeportZone, desertOfRoZone, twoWayConnection: true);
            _zones.AddAdjacentZone(freeportZone, eastCommonlandsZone, twoWayConnection: true);
            _zones.AddAdjacentZone(eastCommonlandsZone, nektulosZone, twoWayConnection: true);
            _zones.AddAdjacentZone(nektulosZone, neriakZone, twoWayConnection: true);
            _zones.AddAdjacentZone(darkElfEden, neriakZone, twoWayConnection: true);
        }

        public Zone CreateAndTrackNewZone(string zoneName)
        {
            var newZone = _zones.CreateNewZone(zoneName);
            _trackerFactory.CreateTrackerForZone(newZone);
            return newZone;
        }

        public void GenerateAdam(ChildPopulationTracker pop, IZone currentZone)
        {
            var adam = new Npc(new Human(), new DefaultCulture(_rand), currentZone, _npcs, pop, _traits);

            adam.FirstName = "Adam";
            adam.AgeInDays = 16 * DaysInYear;
            adam.BirthDate = -16 * DaysInYear + 36;
            adam.Sex = Sex.Male;

            pop.Add(adam);
        }

        public void GenerateEve(ChildPopulationTracker pop, IZone currentZone)
        {
            var eve = new Npc(new Human(), new DefaultCulture(_rand), currentZone, _npcs, pop, _traits);

            eve.FirstName = "Eve";
            eve.AgeInDays = 16 * DaysInYear;
            eve.BirthDate = -16 * DaysInYear + 17;
            eve.Sex = Sex.Female;

            pop.Add(eve);
        }

        public Zone CreateStartingZoneForEden(ZoneManagement zones, string zoneName)
        {
            var returnable = zones.CreateNewZone(zoneName);
            var firstPop = _trackerFactory.CreateTrackerForZone(returnable);

            GenerateAdam(firstPop, returnable);
            GenerateEve(firstPop, returnable);

            return returnable;
        }

    }
}
