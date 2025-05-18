using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class AmbitiousTrait : ITrait
    {
        public TraitEnum Trait => TraitEnum.Ambitious;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
