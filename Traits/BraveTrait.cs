using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class BraveTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Brave;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
