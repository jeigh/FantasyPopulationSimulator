using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class DeceitfulTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Deceitful;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
