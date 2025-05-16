using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Services;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class WandererTrait : ITrait 
    {
        private RandomNumberGenerator _rand;
        private WorldState _root;

        public WandererTrait(RandomNumberGenerator rand, WorldState root)
        {
            _rand = rand;
            _root = root;
        }

        public string Name => "Wanderer";

        public bool ProcessTickAndContinue(Npc npc, long today)
        {
            // 25% that the wanderer will move to a new zone
            if (0.25f >= _rand.GeneratePercentage())
            {
                List<IZone> potentialDestinations = npc.CurrentZone.GetTargetZoneConnections();
                IZone destination = potentialDestinations[_rand.GenerateBetween(0, potentialDestinations.Count - 1)];
                
                var traveller = new Traveller
                {
                    TravellerNpc = npc,
                    Destination = destination,
                    TravelStartDate = today,
                    TravelEndDate = today + _rand.GenerateBetween(1, 7) // todo: create a distance attribute in the connection.
                };

                _root.MoveNpcToTravellers(traveller);

                return false;
            }
            return true;            
        }
    }
}
