using FantasyPopulationSimulator.Console.Entities;

namespace FantasyPopulationSimulator.Console.Services
{
    


    public class WorldService
    {
        private TravelService _travel;
        


        public WorldService(TravelService travel)
        {
            _travel = travel;
        }

        public long GetNpcCount(WorldState _worldState)
        {
            long sum = 0;
            foreach (var zone in _worldState.GetAllTickables())
            {
                sum += zone.GetNpcCount();
            }
            sum += _worldState.GetAllTravellers().Count;
            return sum;
        }

        public void BlockUntilTickCompletes(WorldState _worldState, long day)
        {
            _travel.CompleteTravellerJourneys(day);

            var tasks = new List<Task>();
            var tickables = _worldState.GetAllTickables();
            foreach (var child in tickables)
            {
                var task = Task.Run(() => RunInsideThread(child, day));
                tasks.Add(task);
            }

            Task.WaitAll(tasks.ToArray());
            //System.Console.Clear();
        }

        public void RunInsideThread(PopulationTracker pop, long today)
        {
            //var zoneName = pop.GetAssignedZoneName();

            //var stopwatch = new Stopwatch();
            //stopwatch.Start();
            pop.BlockUntilTickCompletes(today);
            //stopwatch.Stop();

            //System.Console.WriteLine($"Thread for {zoneName} for day {today} completed in {stopwatch.Elapsed} seconds.");
        }




    }
}
