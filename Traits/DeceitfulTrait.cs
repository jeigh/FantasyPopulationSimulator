using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class DeceitfulTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Deceitful;
        public bool ProcessTickAndContinue(Npc npc) => true;
    }
}
