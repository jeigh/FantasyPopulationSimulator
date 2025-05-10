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

        public void GenerateAdam()
        {
            var adam = new Npc(this, new Human());

            adam.FirstName = "Adam";
            adam.AgeInDays = 16 * Constants.DaysInYear;
            adam.BirthDate = -16 * Constants.DaysInYear + 36; 
            adam.Sex = Sex.Male;

            Tickables.Add(adam);
        }

        public void GenerateEve()
        {
            var eve = new Npc(this, new Human());

            eve.FirstName = "Eve";
            eve.AgeInDays = 16 * Constants.DaysInYear;
            eve.BirthDate = -16 * Constants.DaysInYear + 17;
            eve.Sex = Sex.Female;

            Tickables.Add(eve);
        }

        public void GenerateNewNpc(Npc mother, Npc father, long day)
        {
            var newNpc = new Npc(this, mother, father);

            Sex newSex = GenerateNewbornSex();

            newNpc.Sex = newSex;

            newNpc.FirstName = Guid.NewGuid().ToString();       //todo: better name generation
            newNpc.LastName = father?.LastName;                 //todo: better last name generation
            newNpc.AgeInDays = 0;
            newNpc.BirthDate = day;

            Tickables.Add(newNpc);
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
