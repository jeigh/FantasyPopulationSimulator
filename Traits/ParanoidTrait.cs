using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class ParanoidTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.Paranoid;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
