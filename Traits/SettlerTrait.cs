using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class SettlerTrait : ITrait
    {
        public static string Name => "Settler";

        public bool ProcessTickAndContinue(WorldState _worldState, Npc npc, long today)
        {
            return true;  // nothing to do on tick
        }
    }
}
