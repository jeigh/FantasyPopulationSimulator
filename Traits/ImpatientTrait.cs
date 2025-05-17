using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class ImpatientTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Impatient;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
