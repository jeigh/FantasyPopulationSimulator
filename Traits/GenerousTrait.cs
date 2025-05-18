using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class GenerousTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Generous;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
