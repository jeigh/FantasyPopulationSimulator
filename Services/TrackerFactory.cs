using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Services
{
    public class TrackerFactory
    {
        private readonly RandomNumberGenerator _rand;
        private readonly DisplayService _ui;
        private readonly NpcBehavior _behavior;
        private readonly TraitCatalogue _traits;
        private readonly WorldState _worldState;

        public TrackerFactory(RandomNumberGenerator rand, DisplayService ui, NpcBehavior behavior, TraitCatalogue traits, WorldState worldState)
        {
            _rand = rand;
            _ui = ui;
            _behavior = behavior;
            _traits = traits;
            _worldState = worldState;
        }

        public PopulationTracker CreateTrackerForZone(IZone zone)
        {
            var returnable = new PopulationTracker(_rand, zone, _ui, _behavior, _traits);
            _worldState.Add(returnable);
            return returnable;
        }
    }
}
