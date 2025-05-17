using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class VengefulTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Vengeful;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
