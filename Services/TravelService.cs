using FantasyPopulationSimulator.Console.Entities;

namespace FantasyPopulationSimulator.Console.Services
{
    public class TravelService
    {
        private readonly TraitReplacementService _traitReplacer;
        private readonly WorldState _worldState;

        public TravelService(TraitReplacementService traitReplacer,  WorldState worldState)
        {
            _traitReplacer = traitReplacer;
            _worldState = worldState;
        }

        public void CompleteTravellerJourneys()
        {
            var completedTravellers = (from trav in _worldState.GetAllTravellers() select trav).ToList();
            foreach (Traveller traveller in completedTravellers)
            {
                if (traveller.Destination == null) continue;
                if (traveller.TravelEndDate > _worldState.CurrentDate) continue;

                // 'twould be nice to be able to stick these following ops in a transaction so they can be rolled back as a group
                traveller!.TravellerNpc!.CurrentZone = traveller.Destination;
                _worldState.AddZonedNpc(traveller!.TravellerNpc);

                _traitReplacer.ReplaceWandererWithSettler(traveller);
                _worldState.RemoveTraveller(traveller);
            }
        }

    }
}
