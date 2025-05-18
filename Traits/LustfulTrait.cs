using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class LustfulTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Lustful;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
