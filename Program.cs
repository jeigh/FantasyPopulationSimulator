using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Traits;
using System.Security.Cryptography.X509Certificates;
using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;

namespace FantasyPopulationSimulator.Console.Services
{

    internal partial class Program
    {

        

        static void Main(string[] args)
        {
            // DI stuff
            var rand = new RandomNumberGenerator(12);           // todo:  12 seems arbitrary?
            var worldState = new WorldState();
            var zrs = new ZoneRetrievalService(worldState);

            var movementService = new MovementService(zrs, worldState);
            var wandererTrait = new WandererTrait(rand, movementService, worldState);
            var traits = new TraitCatalogue(wandererTrait, new SettlerTrait());
            var npcs = new NpcBehavior(rand, traits);
            var traitReplacer = new TraitReplacementService(npcs);
            var travel = new TravelService(traitReplacer, zrs, worldState);
            var worldService = new WorldService(travel);
            var ui = new ConsoleUI(worldService, worldState);
            var zones = new ZoneManagement();
            var trackerFactory = new TrackerFactory(rand, ui, npcs, traits, worldState);
            var setup = new InitialSetupHelper(zones, rand, npcs, traits, trackerFactory);
            // end of DI stuff


            Zone edenZone = setup.CreateStartingZoneForEden(zones, "Eden");
            Zone darkElfEden = setup.CreateStartingZoneForEden(zones, "Dark Elf Eden");

            setup.SetupEverquestThemedZones(edenZone, darkElfEden);

            long day = 0;
            while (true)
            {
                if (day % DaysInYear == 0)
                {
                    int currentYear = (int)(day / DaysInYear);
                    ui.Clear();
                    //ui.DeclareYear(currentYear, root.GetNpcCount());

                    if (day % DaysInYear == 0) ui.EmitSummary(currentYear);
                }

                worldService.BlockUntilTickCompletes(worldState, day);

                day++;
            }
        }


    }
}
