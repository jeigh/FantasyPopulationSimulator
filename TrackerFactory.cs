using FantasyPopulationSimulator.Console.Interfaces;
using FantasyPopulationSimulator.Console.Services;

namespace FantasyPopulationSimulator.Console
{
    public class TrackerFactory
    {
        private readonly RandomNumberGenerator _rand;
        private readonly ConsoleUI _ui;
        private readonly NpcBehavior _behavior;
        private readonly TraitCatalogue _traits;
        private readonly WorldState _worldState;

        public TrackerFactory(RandomNumberGenerator rand, ConsoleUI ui, NpcBehavior behavior, TraitCatalogue traits, WorldState worldState)
        {
            _rand = rand;
            _ui = ui;
            _behavior = behavior;
            _traits = traits;
            _worldState = worldState;
        }

        public ChildPopulationTracker CreateTrackerForZone(IZone zone)
        {
            var returnable = new ChildPopulationTracker(_rand, zone, _ui, _behavior, _worldState, _traits);
            _worldState.Add(returnable);
            return returnable;
        }
    }
}
