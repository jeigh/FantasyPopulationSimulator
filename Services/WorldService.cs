using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Traits;

namespace FantasyPopulationSimulator.Console.Services
{
    


    public class WorldService
    {
        private readonly TravelService _travel;
        private readonly WorldState _worldState;
        private readonly NpcBehavior _behavior;


        public WorldService(TravelService travel, WorldState worldState, NpcBehavior behavior)
        {
            _travel = travel;
            _worldState = worldState;
            _behavior = behavior;
        }

        public long GetNpcCount(WorldState _worldState)
        {
            long sum = 0;

            sum += _worldState.GetAllZonedNpcs().Count;
            sum += _worldState.GetAllTravellers().Count;

            return sum;
        }

        public void BlockUntilTickCompletes(WorldState _worldState, long day)
        {
            _travel.CompleteTravellerJourneys(day);
            foreach (Npc npc in _worldState.GetAllZonedNpcs())
            {
                _behavior.BlockUntilTickCompletes(npc, day);
            }


        }

        public void MoveNpcToTravellers(Traveller traveller)
        {
            string sourceZoneName = traveller!.TravellerNpc!.CurrentZone!.ZoneName;

            _worldState.RemoveZonedNpc(traveller!.TravellerNpc);
            _worldState.AddTraveller(traveller);
            
        }


    }
}
