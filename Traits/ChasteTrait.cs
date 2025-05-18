using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class ChasteTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Chaste;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
