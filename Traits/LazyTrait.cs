using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class LazyTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Lazy;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
