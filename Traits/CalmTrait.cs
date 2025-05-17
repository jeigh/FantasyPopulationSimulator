using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class CalmTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Calm;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
