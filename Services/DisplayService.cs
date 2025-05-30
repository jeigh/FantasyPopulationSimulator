using FantasyPopulationSimulator.Console.Entities;

namespace FantasyPopulationSimulator.Console.Services
{
    public class DisplayService 
    {
        private readonly WorldService _worldService;
        private readonly WorldState _worldState;

        public DisplayService(WorldService worldService, WorldState worldState)
        {
            _worldService = worldService;
            _worldState = worldState;
        }

        public void EmitSummary(long currentYear) 
        {
            var totalNpcCount = _worldService.GetNpcCount(_worldState);
            System.Console.WriteLine($"Year: {currentYear}, Total Npc Count: {totalNpcCount}");
            Dictionary<string, int> zonePopulationCounts = _worldState.GetZonesPopulationCount();

            foreach (KeyValuePair<string, int> kvp in zonePopulationCounts) 
            {
                System.Console.WriteLine($"Zone: {kvp.Key}, Npc Count: {kvp.Value}");
            }


            var travellerCount = _worldState.GetTravellerCount();
            System.Console.WriteLine($"Total Travellers: {travellerCount}");
        }

        public void Clear() => System.Console.Clear();
    }
}


