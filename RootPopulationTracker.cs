
namespace FantasyPopulationSimulator.Console
{
    public class RootPopulationTracker : ITicker, ITickable
    {
        private RandomNumberGenerator _rand;

        public RootPopulationTracker(RandomNumberGenerator rand)
        {
            _rand = rand;
        }

        public PopulationTracker CreateChildForZone(IZone zone)
        {
            var returnable = new PopulationTracker(_rand, zone);
            Add(returnable);
            return returnable;
        }

        private List<ITickable> Tickables { get; set; } = new List<ITickable>();

        public void Remove(ITickable tickable) => 
            Tickables.Remove(tickable);

        public void Add(ITickable tickable) => 
            Tickables.Add(tickable);


        public void BlockUntilTickCompletes(long day)
        {
            foreach (ITickable n in Tickables.ToList())
            {
                n.BlockUntilTickCompletes(day);
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
    }
}
