namespace FantasyPopulationSimulator.Console
{
    internal partial class Program
    {
        public interface ITickable
        {
            void Tick(long day);
        }

        public class PopulationTracker
        {
            private List<ITickable> Tickables { get; set; } = new List<ITickable>();

            public void GenerateAdam()
            {
                var adam = new Npc(this, new Human());
                
                adam.FirstName = "Adam";
                adam.AgeInDays = 16 * DaysInYear;
                adam.BirthDay = 34;
                adam.Sex = Sex.Male;
                
                Tickables.Add(adam);
            }

            public void GenerateEve()
            {
                var eve = new Npc(this, new Human());
                
                eve.FirstName = "Eve";
                eve.AgeInDays = 16 * DaysInYear;
                eve.BirthDay = 17;
                eve.Sex = Sex.Female;

                Tickables.Add(eve);
            }

            public void GenerateNewNpc(Npc mother, Npc father, long day)
            {
                var newNpc = new Npc(this, mother.GetRaceOfChildren());

                newNpc.Mother = mother;
                newNpc.Father = father;

                newNpc.FirstName = Guid.NewGuid().ToString();  //todo: better name generation
                newNpc.LastName = father?.LastName;  //todo: better last name generation
                newNpc.AgeInDays = 0;
                newNpc.BirthDay = (int) ( day % DaysInYear);

                Tickables.Add(newNpc);
            }

            internal void TickPopulation(long day)
            {
                foreach (ITickable n in Tickables.ToList())
                {
                    n.Tick(day);
                }
            }
        }


    }
}
