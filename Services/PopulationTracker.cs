using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;

namespace FantasyPopulationSimulator.Console.Services
{


    public class PopulationTracker
    {
        private RandomNumberGenerator _rand;
        private IZone _assignedZone;
        private DisplayService _ui;
        private NpcBehavior _behavior;
        private TraitCatalogue _traits;

        public PopulationTracker(RandomNumberGenerator rand, IZone zone, DisplayService ui, NpcBehavior behavior, TraitCatalogue traits)
        {
            _behavior = behavior;
            _rand = rand;
            _assignedZone = zone;
            _ui = ui;
            _behavior = behavior;
            _traits = traits;
        }

        private List<Npc> Npcs { get; set; } = new List<Npc>();
        private object tickableLock = new object();

        public long NpcCount() => Npcs.Count;

        public void GenerateNewNpc(Npc mother, Npc? father, long day)
        {
            var newNpc = new Npc(mother, father, _behavior, this, _traits);

            newNpc.Sex = GenerateNewbornsBiologicalSex();

            string newName = Guid.NewGuid().ToString();

            if (newNpc.Sex == Sex.Male) newName = mother.Culture.GetRandomMaleName();
            if (newNpc.Sex == Sex.Female) newName = mother.Culture.GetRandomFemaleName();

            newNpc.FirstName = newName;
                                                                //todo: better name generation
            newNpc.LastName = father?.LastName;                 //todo: better last name generation;  and culture = matrilineal vs patrilineal?
            newNpc.AgeInDays = 0;
            newNpc.BirthDate = day;
            lock(tickableLock)
            {
                Npcs.Add(newNpc);
            }
        }

        private Sex GenerateNewbornsBiologicalSex()
        {
            Sex newSex = Sex.None;

            var randomInt = _rand.GenerateBetween(0, 1);

            if (randomInt == 0) newSex = Sex.Female;
            if (randomInt == 1) newSex = Sex.Male;

            return newSex;
        }

        public void Remove(Npc tickable)
        {
            lock (tickableLock)
            {
                if (Npcs.Count == 0) return;
                Npcs.Remove(tickable);
            }
        }

        public void BlockUntilTickCompletes(long day)
        {
            List<Npc> iterateOver;
            lock (tickableLock)
            {
                 iterateOver = Npcs.ToList();
            }
            foreach (Npc? child in iterateOver)
            {
                child?.BlockUntilTickCompletes(day);
            }

        }

        public void Add(Npc tickable)
        {
            lock (tickableLock)
            {
                Npcs.Add(tickable);
            }
        }

        public long GetNpcCount()
        {
            List<Npc> tickables = new List<Npc>();
            long sum = 0;
            lock (tickableLock)
            {
                 tickables.AddRange(Npcs);
            }
            if (tickables.Count == 0) return 0;
            foreach (var child in tickables.ToList())
            {
                if (child == null) continue;
                if (child.IsDead) continue;
                sum += child.GetNpcCount();
            }
            
            return sum;
        }
        public string GetAssignedZoneName() => _assignedZone.ZoneName;




    }
}
