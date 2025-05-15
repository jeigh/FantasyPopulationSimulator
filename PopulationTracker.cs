using FantasyPopulationSimulator.Console.Interfaces;
using static FantasyPopulationSimulator.Console.Program;
using FantasyPopulationSimulator.Console.Constants;

namespace FantasyPopulationSimulator.Console
{


    public class PopulationTracker : ITicker, ITickable, IChildPopulationTracker
    {
        private RandomNumberGenerator _rand;
        private IZone _assignedZone;
        private ConsoleUI _ui;
        private NpcBehavior _behavior;

        public PopulationTracker(RandomNumberGenerator rand, IZone zone, ConsoleUI ui, NpcBehavior behavior)
        {
            _behavior = behavior;
            _rand = rand;
            _assignedZone = zone;
            _ui = ui;
            _behavior = behavior;
        }

        private List<ITickable> Tickables { get; set; } = new List<ITickable>();

        public long NpcCount() => Tickables.Count;

        public void GenerateNewNpc(Npc mother, Npc father, long day)
        {
            var newNpc = new Npc(mother, father, _behavior);

            newNpc.Sex = GenerateNewbornSex();

            string newName = Guid.NewGuid().ToString();

            if (newNpc.Sex == Sex.Male) newName = mother.Culture.GetRandomMaleName();
            if (newNpc.Sex == Sex.Female) newName = mother.Culture.GetRandomFemaleName();

            newNpc.FirstName = newName;
                                                                //todo: better name generation
            newNpc.LastName = father?.LastName;                 //todo: better last name generation;  and culture = matrilineal vs patrilineal?
            newNpc.AgeInDays = 0;
            newNpc.BirthDate = day;

            Tickables.Add(newNpc);
            _ui.NpcBirth(mother.FirstName, newNpc.FirstName);
        }

        private Sex GenerateNewbornSex()
        {
            Sex newSex = Sex.None;

            var randomInt = _rand.GenerateBetween(0, 1);

            if (randomInt == 0) newSex = Sex.Female;
            if (randomInt == 1) newSex = Sex.Male;

            return newSex;
        }

        public void Remove(ITickable tickable) =>
            Tickables.Remove(tickable);

        public void BlockUntilTickCompletes(long day)
        {
            foreach (ITickable n in Tickables.ToList())
            {
                n.BlockUntilTickCompletes(this, day);
            }
        }

        public void Add(ITickable tickable)
        {
            Tickables.Add(tickable);
        }

        public void TickPopulation(long day)
        {
            foreach (ITickable n in Tickables.ToList())
            {
                n.BlockUntilTickCompletes(this, day);
            }
        }

        public long GetNpcCount()
        {
            long sum = 0;
            foreach (ITickable n in Tickables.ToList())
            {
                sum += n.GetNpcCount();
            }

            return sum;
        }
        public string GetAssignedZoneName() => _assignedZone.ZoneName;

        public void BlockUntilTickCompletes(IChildPopulationTracker pop, long day) => 
            this.BlockUntilTickCompletes(day);

    }
}
