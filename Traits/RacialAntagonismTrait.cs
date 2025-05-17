using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class RacialAntagonismTrait : ITrait
    {
        public static TraitEnum Trait => TraitEnum.RacialAntagonism;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
