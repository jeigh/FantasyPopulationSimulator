using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class RacialAgonismTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.RacialAgonism;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
