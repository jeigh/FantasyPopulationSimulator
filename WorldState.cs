using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Services;

namespace FantasyPopulationSimulator.Console
{


    public class WorldState 
    {
        private List<ChildPopulationTracker> Tickables { get; set; } = new List<ChildPopulationTracker>();
        private object tickableLock = new object();

        public List<ChildPopulationTracker> GetAllTickables()
        {
            lock (tickableLock) 
                return Tickables.ToList();
        }

        private List<Traveller> _travellers = new List<Traveller>();
        private object travellersLock = new object();
        
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

        public void Remove(ChildPopulationTracker tickable) => 
            Tickables.Remove(tickable);

        public void Add(ChildPopulationTracker tickable) => 
            Tickables.Add(tickable);

        public List<ChildPopulationTracker> GetChildren() => Tickables.ToList();

        public string GetAssignedZoneName() => "Root";
    }
}
