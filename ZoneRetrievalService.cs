using FantasyPopulationSimulator.Console.Services;

namespace FantasyPopulationSimulator.Console
{
    public class ZoneRetrievalService
    {
        public ChildPopulationTracker? GetTrackerByZoneName(WorldState _worldState, string sourceZoneName)
        {
            foreach (var childZoneTracker in _worldState.GetAllTickables().ToList())
            {
                if (childZoneTracker.GetAssignedZoneName() == sourceZoneName) return childZoneTracker;
            }
            return null;
        }
    }
}
