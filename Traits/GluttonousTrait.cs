using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class GluttonousTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Gluttonous;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
