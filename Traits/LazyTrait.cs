using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class LazyTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Lazy;
        public bool ProcessTickAndContinue(Npc npc) => true;
    }
}
