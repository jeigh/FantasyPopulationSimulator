using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Services;

namespace FantasyPopulationSimulator.Console.Entities
{
    public class WorldState 
    {
        private List<PopulationTracker> PopulationTrackers { get; set; } = new List<PopulationTracker>();
        private object tickableLock = new object();

        public List<PopulationTracker> GetAllTickables()
        {
            lock (tickableLock) 
                return PopulationTrackers.ToList();
        }

        private List<Traveller> _travellers = new List<Traveller>();
        private object travellersLock = new object();
        
        public int GetTravellerCount() => _travellers.Count;

        public void AddTraveller(Traveller traveller)
        {
            lock (travellersLock)
            {
                _travellers.Add(traveller);
            }
        }

        public void RemoveTraveller(Traveller traveller)
        {
            lock (travellersLock)
            {
                _travellers.Remove(traveller);
            }
        }

        public List<Traveller> GetAllTravellers()
        {
            lock (travellersLock)
            {
                return _travellers.ToList();
            }
        }

        public void Add(PopulationTracker tickable) => 
            PopulationTrackers.Add(tickable);

    }
}
