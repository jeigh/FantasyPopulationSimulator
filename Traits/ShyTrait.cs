using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class ShyTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Shy;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
