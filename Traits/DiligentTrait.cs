using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class DiligentTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Diligent;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
