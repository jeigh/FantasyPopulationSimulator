using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class JustTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Just;
        public bool ProcessTickAndContinue(Npc npc) => true;
    }
}
