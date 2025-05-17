using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Services;

namespace FantasyPopulationSimulator.Console
{
    public class TravelService
    {
        private TraitReplacementService _traitReplacer;
        private ZoneRetrievalService _zrs;
        private WorldState _worldState;

        public TravelService(TraitReplacementService traitReplacer, ZoneRetrievalService zrs, WorldState worldState)
        {
            _traitReplacer = traitReplacer;
            _zrs = zrs;
            _worldState = worldState;
        }

        public void CompleteTravellerJourneys(long today)
        {
            var completedTravellers = (from trav in _worldState.GetAllTravellers() select trav).ToList();
            foreach (Traveller traveller in completedTravellers)
            {
                if (traveller.Destination == null) continue;
                if (traveller.TravelEndDate > today) continue;

                ChildPopulationTracker? destinationTracker = _zrs.GetTrackerByZoneName(traveller.Destination.ZoneName) as ChildPopulationTracker;
                if (destinationTracker == null) continue;

                // 'twould be nice to be able to stick these following ops in a transaction so they can be rolled back as a group
                traveller!.TravellerNpc!.CurrentZone = traveller.Destination;
                destinationTracker.Add(traveller!.TravellerNpc);

                _traitReplacer.ReplaceWandererWithSettler(traveller);
                _worldState.RemoveTraveller(traveller);
            }
        }

    }
}
