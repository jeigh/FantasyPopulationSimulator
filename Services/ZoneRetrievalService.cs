using FantasyPopulationSimulator.Console.Entities;

namespace FantasyPopulationSimulator.Console.Services
{
    public class ZoneRetrievalService
    {
        public readonly WorldState _worldState;

        public ZoneRetrievalService(WorldState worldState)
        {
            _worldState = worldState;
        }

        public PopulationTracker? GetTrackerByZoneName(string sourceZoneName)
        {
            foreach (var childZoneTracker in _worldState.GetAllTickables().ToList())
            {
                if (childZoneTracker.GetAssignedZoneName() == sourceZoneName) return childZoneTracker;
            }
            return null;
        }
    }
}
