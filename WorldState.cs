using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Services;
using FantasyPopulationSimulator.Console.Traits;

namespace FantasyPopulationSimulator.Console
{
    public class WorldState : ITicker, ITickable
    {
        private readonly RandomNumberGenerator _rand;
        private readonly ConsoleUI _ui;
        private readonly NpcBehavior _behavior;

        public WorldState(RandomNumberGenerator rand, ConsoleUI ui, NpcBehavior behavior)
        {
            _rand = rand;
            _ui = ui;
            _behavior = behavior;
        }

        public ChildPopulationTracker CreateTrackerForZone(IZone zone)
        {
            var returnable = new ChildPopulationTracker(_rand, zone, _ui, _behavior, this);
            Add(returnable);
            return returnable;
        }

        private List<ITickable> Tickables { get; set; } = new List<ITickable>();
        private object tickableLock = new object();
        private List<Traveller> Travellers { get; set; } = new List<Traveller>();

        public void Remove(ITickable tickable) => 
            Tickables.Remove(tickable);

        public void Add(ITickable tickable) => 
            Tickables.Add(tickable);

        private void CompleteTravellerJourneys(long today)
        {
            var completedTravellers = (from trav in Travellers where trav.TravelEndDate <= today select trav).ToList();
            foreach (Traveller traveller in completedTravellers)
            {
                if (traveller.Destination == null) continue;

                var destinationTracker = GetTrackerByZoneName(traveller.Destination.ZoneName) as ChildPopulationTracker;
                if (destinationTracker == null) continue;

                // twould be nice to be able to stick these three ops in a transaction
                traveller!.TravellerNpc!.CurrentZone = traveller.Destination;
                destinationTracker.Add(traveller!.TravellerNpc);
                _behavior.RemoveTraitFromNpc(traveller!.TravellerNpc, "Wanderer");

                Travellers.Remove(traveller);
            }
        }

        public void BlockUntilTickCompletes(long day)
        {
            CompleteTravellerJourneys(day);

            var tasks = new List<Task>();

            List<ITickable> childrenCopy;
            lock (tickableLock)
            {
                childrenCopy = Tickables.ToList();
            }
            foreach (ITickable child in childrenCopy)
            {
                child?.BlockUntilTickCompletes(day);
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

        public void MoveNpcToTravellers(Traveller traveller)
        {
            string sourceZoneName = traveller.TravellerNpc.CurrentZone.ZoneName;
            ChildPopulationTracker? sourceZoneTracker = GetTrackerByZoneName(sourceZoneName) as ChildPopulationTracker;

            // it would be nice to have some kind of transaction scope around these next two statements
            Travellers.Add(traveller);
            sourceZoneTracker?.Remove(traveller.TravellerNpc);
        }

        private ITickable? GetTrackerByZoneName(string sourceZoneName)
        {
            foreach (ITickable childZoneTracker in Tickables.ToList())
            {
                if (childZoneTracker.GetAssignedZoneName() == sourceZoneName) return childZoneTracker;
            }
            return null;
        }
    }
}
