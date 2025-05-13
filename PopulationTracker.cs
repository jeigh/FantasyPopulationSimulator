using static FantasyPopulationSimulator.Console.Program;

namespace FantasyPopulationSimulator.Console
{
    public interface ITickable
    {
        void Tick(long day);
    }

    public class PopulationTracker
    {
        private RandomNumberGenerator _rand;

        public PopulationTracker(RandomNumberGenerator rand)
        {
            _rand = rand;
        }

        private List<ITickable> Tickables { get; set; } = new List<ITickable>();

        public long NpcCount() => Tickables.Count;

        public void GenerateAdam()
        {
            var adam = new Npc(this, new Human(), new DefaultCulture(_rand));

            adam.FirstName = "Adam";
            adam.AgeInDays = 16 * Constants.DaysInYear;
            adam.BirthDate = -16 * Constants.DaysInYear + 36; 
            adam.Sex = Sex.Male;

            Tickables.Add(adam);
        }

        public void GenerateEve()
        {
            var eve = new Npc(this, new Human(), new DefaultCulture(_rand));

            eve.FirstName = "Eve";
            eve.AgeInDays = 16 * Constants.DaysInYear;
            eve.BirthDate = -16 * Constants.DaysInYear + 17;
            eve.Sex = Sex.Female;

            Tickables.Add(eve);
        }

        public void GenerateNewNpc(Npc mother, Npc father, long day)
        {
            var newNpc = new Npc(this, mother, father);

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
            //System.Console.WriteLine($"{mother.FirstName} had a baby named {newNpc.FirstName}!");
        }

        private Sex GenerateNewbornSex()
        {
            Sex newSex = Sex.None;

            var randomInt = _rand.GenerateBetween(0, 1);

            if (randomInt == 0) newSex = Sex.Female;
            if (randomInt == 1) newSex = Sex.Male;

            return newSex;
        }

        public void RemoveNpc(Npc npc) =>
            Tickables.Remove(npc);

        internal void TickPopulation(long day)
        {
            foreach (ITickable n in Tickables.ToList())
            {
                n.Tick(day);
            }
        }
    }
}
