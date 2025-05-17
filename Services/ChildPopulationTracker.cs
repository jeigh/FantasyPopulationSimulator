using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;

namespace FantasyPopulationSimulator.Console.Services
{


    public class ChildPopulationTracker
    {
        private RandomNumberGenerator _rand;
        private IZone _assignedZone;
        private ConsoleUI _ui;
        private NpcBehavior _behavior;
        private TraitCatalogue _traits;
        private WorldState _worldState;

        public ChildPopulationTracker(RandomNumberGenerator rand, IZone zone, ConsoleUI ui, NpcBehavior behavior, WorldState worldState, TraitCatalogue traits)
        {
            _behavior = behavior;
            _rand = rand;
            _assignedZone = zone;
            _ui = ui;
            _behavior = behavior;
            _worldState = worldState;
            _traits = traits;
        }

        private List<Npc> Tickables { get; set; } = new List<Npc>();
        private object tickableLock = new object();

        public long NpcCount() => Tickables.Count;

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
                Tickables.Add(newNpc);
            }
            
            _ui.NpcBirth(mother.FirstName, newNpc.FirstName);
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
                if (Tickables.Count == 0) return;
                Tickables.Remove(tickable);
            }
        }

        public void BlockUntilTickCompletes(long day)
        {
            lock (tickableLock)
            {
                foreach (Npc? child in Tickables.ToList())
                {
                    child?.BlockUntilTickCompletes(_worldState, day);
                }
            }
        }

        public void Add(Npc tickable)
        {
            lock (tickableLock)
            {
                Tickables.Add(tickable);
            }
        }

        public long GetNpcCount()
        {
            long sum = 0;
            lock (tickableLock)
            {
                if (Tickables.Count == 0) return 0;
                foreach (var child in Tickables.ToList())
                {
                    sum += child.GetNpcCount();
                }
            }
            return sum;
        }
        public string GetAssignedZoneName() => _assignedZone.ZoneName;




    }
}
