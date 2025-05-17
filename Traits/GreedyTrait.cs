using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class GreedyTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Greedy;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
