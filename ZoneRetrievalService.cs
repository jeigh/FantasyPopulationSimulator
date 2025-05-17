using FantasyPopulationSimulator.Console.Services;

namespace FantasyPopulationSimulator.Console
{
    public class ZoneRetrievalService
    {
        public readonly WorldState _worldState;

        public ZoneRetrievalService(WorldState worldState)
        {
            _worldState = worldState;
        }

        public ChildPopulationTracker? GetTrackerByZoneName(string sourceZoneName)
        {
            foreach (var childZoneTracker in _worldState.GetAllTickables().ToList())
            {
                if (childZoneTracker.GetAssignedZoneName() == sourceZoneName) return childZoneTracker;
            }
            return null;
        }
    }
}
