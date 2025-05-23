﻿using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;
using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Races;
using FantasyPopulationSimulator.Console.Cultures;
using FantasyPopulationSimulator.Console.Entities;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
            //Zone desertOfRoZone = CreateAndTrackNewZone("Desert Of Ro");
            Zone eastCommonlandsZone = CreateAndTrackNewZone("East Commonlands");
            Zone neriakZone = CreateAndTrackNewZone("Neriak");
            Zone nektulosZone = CreateAndTrackNewZone("Nektulos Forest");

            _zones.AddAdjacentZone(edenZone, freeportZone, twoWayConnection: false);
            //_zones.AddAdjacentZone(freeportZone, desertOfRoZone, twoWayConnection: true);
            _zones.AddAdjacentZone(freeportZone, eastCommonlandsZone, twoWayConnection: true);
            _zones.AddAdjacentZone(eastCommonlandsZone, nektulosZone, twoWayConnection: true);
            _zones.AddAdjacentZone(nektulosZone, neriakZone, twoWayConnection: true);
            _zones.AddAdjacentZone(darkElfEden, neriakZone, twoWayConnection: false);
        }

        public Zone CreateAndTrackNewZone(string zoneName)
        {
            var newZone = _zones.CreateNewZone(zoneName);
            _trackerFactory.CreateTrackerForZone(newZone);
            return newZone;
        }

        public void GenerateAdam(PopulationTracker pop, IZone currentZone, IRace race, ICulture culture, string name)
        {
            var adam = new Npc(race, culture, currentZone, _npcs, pop);

            adam.FirstName = name;
            adam.AgeInDays = 16 * DaysInYear;
            adam.BirthDate = -16 * DaysInYear + 36;
            adam.Sex = Sex.Male;

            pop.Add(adam);
        }

        public void GenerateEve(PopulationTracker pop, IZone currentZone, IRace race, ICulture culture, string name)
        {
            var eve = new Npc(race, culture, currentZone, _npcs, pop);

            eve.FirstName = name;
            eve.AgeInDays = 16 * DaysInYear;
            eve.BirthDate = -16 * DaysInYear + 17;
            eve.Sex = Sex.Female;

            pop.Add(eve);
        }

        public Zone CreateStartingZoneForEden(ZoneManagement zones, string zoneName, IRace race, ICulture culture, string prefix)
        {
            var returnable = zones.CreateNewZone(zoneName);
            var firstPop = _trackerFactory.CreateTrackerForZone(returnable);

            GenerateAdam(firstPop, returnable, race, culture, $"{prefix}Adam");
            GenerateEve(firstPop, returnable, race, culture, $"{prefix}Eve");

            return returnable;
        }

    }
}
