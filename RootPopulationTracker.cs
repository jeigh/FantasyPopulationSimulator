

namespace FantasyPopulationSimulator.Console
{
    public class RootPopulationTracker : ITicker, ITickable
    {
        private readonly RandomNumberGenerator _rand;
        private readonly ConsoleUI _ui;

        public RootPopulationTracker(RandomNumberGenerator rand, ConsoleUI ui)
        {
            _rand = rand;
            _ui = ui;
        }

        public PopulationTracker CreateChildForZone(IZone zone)
        {
            var returnable = new PopulationTracker(_rand, zone, _ui);
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


        public List<ITickable> GetChildren() => Tickables.ToList();

        public string GetAssignedZoneName() => "Root";
    }
}
