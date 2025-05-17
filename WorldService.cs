using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Services;
using FantasyPopulationSimulator.Console.Traits;

namespace FantasyPopulationSimulator.Console
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
            List<ChildPopulationTracker> tickables = _worldState.GetAllTickables();
            foreach (var child in tickables)
            {
                child?.BlockUntilTickCompletes(day);
            }

            Task.WaitAll(tasks.ToArray());
        }





    }
}
