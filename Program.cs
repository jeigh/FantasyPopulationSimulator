using FantasyPopulationSimulator.Console.Entities;
using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;

namespace FantasyPopulationSimulator.Console.Services
{

    internal partial class Program
    {

        static void Main(string[] args)
        {
            var rand = new RandomNumberGenerator(12);           // todo:  12 seems arbitrary?
            var ui = new ConsoleUI();
            var npcs = new NpcBehavior(ui, rand);
            var popTracker = new WorldState(rand, ui, npcs);
            var zones = new ZoneManagement();

            var setup = new InitialSetupHelper(zones, popTracker, rand, npcs);

            Zone edenZone = setup.CreateStartingZoneForEden(popTracker, zones, "Eden");
            Zone darkElfEden = setup.CreateStartingZoneForEden(popTracker, zones, "Dark Elf Eden");

            setup.SetupEverquestThemedZones(edenZone, darkElfEden);

            long day = 0;
            while (true)
            {
                if (day % DaysInYear == 0)
                {
                    int currentYear = (int)(day / DaysInYear);
                    ui.Clear();
                    //ui.DeclareYear(currentYear, root.GetNpcCount());

                    if (day % DaysInYear == 0) ui.EmitSummary(popTracker, currentYear);
                }

                popTracker.BlockUntilTickCompletes(day);

                day++;
            }
        }


    }
}
