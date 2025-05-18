using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class ArrogantTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Arrogant;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
