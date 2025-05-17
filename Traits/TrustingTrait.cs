using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class TrustingTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Trusting;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
