

using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console
{
    public class RootPopulationTracker : ITicker, ITickable
    {
        private readonly RandomNumberGenerator _rand;
        private readonly ConsoleUI _ui;
        private readonly NpcBehavior _behavior;

        public RootPopulationTracker(RandomNumberGenerator rand, ConsoleUI ui, NpcBehavior behavior)
        {
            _rand = rand;
            _ui = ui;
            _behavior = behavior;
        }

        public ChildPopulationTracker CreateTrackerForZone(IZone zone)
        {
            var returnable = new ChildPopulationTracker(_rand, zone, _ui, _behavior);
            Add(returnable);
            return returnable;
        }

        private List<ITickable> Tickables { get; set; } = new List<ITickable>();

        public void Remove(ITickable tickable) => 
            Tickables.Remove(tickable);

        public void Add(ITickable tickable) => 
            Tickables.Add(tickable);


        public void BlockUntilTickCompletes(ChildPopulationTracker pop, long day)
        {
            var tasks = new List<Task>();

            foreach (ITickable n in Tickables.ToList())
            {
                tasks.Add(Task.Run(() => n.BlockUntilTickCompletes(pop, day)));
            }

            Task.WaitAll(tasks.ToArray());
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
