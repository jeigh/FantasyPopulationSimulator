using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class AmbitiousTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Ambitious;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
