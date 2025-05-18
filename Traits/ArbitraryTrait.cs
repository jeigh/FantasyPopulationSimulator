using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class ArbitraryTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Arbitrary;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
