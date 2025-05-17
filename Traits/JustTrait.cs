using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class JustTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Just;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
