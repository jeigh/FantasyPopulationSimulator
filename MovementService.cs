using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Services;

namespace FantasyPopulationSimulator.Console
{
    public class MovementService
    {
        private readonly ZoneRetrievalService _zrs;

        public MovementService(ZoneRetrievalService zrs)
        {
            _zrs = zrs;
        }

        public void MoveNpcToTravellers(WorldState _worldState, Traveller traveller)
        {
            string sourceZoneName = traveller!.TravellerNpc!.CurrentZone!.ZoneName;
            ChildPopulationTracker? sourceZoneTracker = _zrs.GetTrackerByZoneName(_worldState, sourceZoneName) as ChildPopulationTracker;

            // it would be nice to have some kind of transaction scope around these next two statements
            _worldState.AddTraveller(traveller);
            sourceZoneTracker?.Remove(traveller.TravellerNpc);
        }

    }
}
