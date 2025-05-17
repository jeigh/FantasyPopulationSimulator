using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Services;

namespace FantasyPopulationSimulator.Console
{
    

    public class MovementService
    {
        private readonly ZoneRetrievalService _zrs;
        private WorldState _worldState;

        public MovementService(ZoneRetrievalService zrs, WorldState worldState)
        {
            _zrs = zrs;
            _worldState = worldState;
        }

        public void MoveNpcToTravellers(Traveller traveller)
        {
            string sourceZoneName = traveller!.TravellerNpc!.CurrentZone!.ZoneName;
            ChildPopulationTracker? sourceZoneTracker = _zrs.GetTrackerByZoneName(sourceZoneName);

            // it would be nice to have some kind of transaction scope around these next two statements
            _worldState.AddTraveller(traveller);
            sourceZoneTracker?.Remove(traveller.TravellerNpc);
        }

    }
}
