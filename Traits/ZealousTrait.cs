using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class ZealousTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Zealous;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
