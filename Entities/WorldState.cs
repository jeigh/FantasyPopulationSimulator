using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Services;
using FantasyPopulationSimulator.Console.Traits;

namespace FantasyPopulationSimulator.Console.Entities
{
    public class WorldState 
    {
        public long CurrentDate { get; set; } = 0;

        private List<Npc> _zonedNpcs { get; set; } = new List<Npc>();
        private object npcsLock = new object();

        private List<Traveller> _travellers = new List<Traveller>();
        private object travellersLock = new object();


        public int GetTravellerCount() => _travellers.Count;

        public void AddTraveller(Traveller traveller)
        {
            lock (travellersLock)
                _travellers.Add(traveller);
        }

        public void RemoveTraveller(Traveller traveller)
        {
            lock (travellersLock)
                _travellers.Remove(traveller);
        }

        public List<Traveller> GetAllTravellers()
        {
            lock (travellersLock)
                return _travellers.ToList();
        }

        public List<Npc> GetAllZonedNpcs()
        {
            lock (npcsLock)
                return _zonedNpcs.ToList();
        }

        internal void RemoveZonedNpc(Npc travellerNpc)
        {
            lock (npcsLock)
                _zonedNpcs.Remove(travellerNpc);
        }

        internal void AddZonedNpc(Npc newNpc)
        {
            lock(npcsLock)
                _zonedNpcs.Add(newNpc);
        }

        public Dictionary<string, int> GetZonesPopulationCount()
        {
            var zones = new Dictionary<string, int>();
            foreach(Npc npc in _zonedNpcs)
            {
                if (zones.ContainsKey(npc!.CurrentZone!.ZoneName))
                    zones[npc.CurrentZone.ZoneName]++;
                else
                    zones.Add(npc.CurrentZone.ZoneName, 1);
            }
            return zones;
        }



        public Dictionary<TraitEnum, ITrait> Traits { get; set; } = new Dictionary<TraitEnum, ITrait>();
        
        public ITrait GetTraitByEnum(TraitEnum trait)
        {
            if (Traits.TryGetValue(trait, out ITrait? value)) return value;
            throw new ApplicationException($"Trait {trait} not found in catalogue.");
        }

        internal void RemoveNpcTraveller(Npc npc)
        {
            lock (travellersLock)
            {
                var traveller = _travellers.FirstOrDefault(t => t.TravellerNpc == npc);
                if (traveller != null)
                {
                    _travellers.Remove(traveller);
                }
            }
        }
    }
}
