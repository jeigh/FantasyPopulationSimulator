using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class SettlerTrait : ITrait
    {
        public TraitEnum Trait => TraitEnum.Settler;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;  
    }
}
