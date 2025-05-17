using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class CravenTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Craven;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
