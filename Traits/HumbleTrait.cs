using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class HumbleTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Humble;
        public bool ProcessTickAndContinue(Npc npc) => true;
    }
}
