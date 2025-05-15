using static FantasyPopulationSimulator.Console.Constants.GlobalConstants;

namespace FantasyPopulationSimulator.Console
{

    internal partial class Program
    {

        static void Main(string[] args)
        {
            var rand = new RandomNumberGenerator(12);           // todo:  12 seems arbitrary?
            var ui = new ConsoleUI();
            var npcBehavior = new NpcBehavior(ui, rand);
            var popTracker = new RootPopulationTracker(rand, ui, npcBehavior);            
            var zones = new ZoneManagement();

            var setup = new InitialSetupHelper(zones, popTracker);

            var edenZone = zones.CreateNewZone("Eden");
            var firstPop = popTracker.CreateTrackerForZone(edenZone);

            setup.GenerateAdam(firstPop, rand, edenZone, ui, rand, npcBehavior);
            setup.GenerateEve(firstPop, rand, edenZone, ui, rand, npcBehavior);

            setup.SetupEverquestThemedZones(edenZone);

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

                popTracker.BlockUntilTickCompletes(firstPop, day);

                day++;
            }
        }
    }
}
