using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class ShyTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Shy;
        public bool ProcessTickAndContinue(Npc npc) => true;
    }
}
