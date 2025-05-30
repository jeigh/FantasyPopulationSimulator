using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class ForgivingTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Forgiving;
        public bool ProcessTickAndContinue(Npc npc) => true;
    }
}
