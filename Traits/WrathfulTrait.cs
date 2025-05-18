using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class WrathfulTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Wrathful;
        public bool ProcessTickAndContinue(Npc npc, long today) => true;
    }
}
