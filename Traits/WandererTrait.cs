using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Services;

namespace FantasyPopulationSimulator.Console.Traits
{



    public class WandererTrait : ITrait 
    {
        private RandomNumberGenerator _rand;
        private WorldService _worldService;
        private WorldState _worldState;

        public WandererTrait(RandomNumberGenerator rand, WorldService worldService, WorldState worldState)
        {
            _rand = rand;
            _worldService = worldService;
            _worldState = worldState;
        }        

        public  TraitEnum Trait => TraitEnum.Wanderer;
        public bool ProcessTickAndContinue(Npc npc)
        {
            // 0.1% that are wanderers will move to a new zone each day
            if (0.001f >= _rand.GeneratePercentage())
            {
                List<IZone> potentialDestinations = npc.CurrentZone!.GetTargetZoneConnections();
                IZone destination = potentialDestinations[_rand.GenerateBetween(0, potentialDestinations.Count - 1)];
                
                var traveller = new Traveller
                {
                    TravellerNpc = npc,
                    Destination = destination,
                    TravelStartDate = _worldState.CurrentDate,
                    TravelEndDate = _worldState.CurrentDate + _rand.GenerateBetween(1, 7) // todo: create a distance attribute in the connection.
                };

                _worldService.MoveNpcToTravellers(traveller);                
                
                return false; 
            }
            return true;            
        }
    }
}
