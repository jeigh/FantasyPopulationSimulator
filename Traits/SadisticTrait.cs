using FantasyPopulationSimulator.Console.Constants;
using FantasyPopulationSimulator.Console.Entities;
using FantasyPopulationSimulator.Console.Interfaces;

namespace FantasyPopulationSimulator.Console.Traits
{
    public class SadisticTrait : ITrait
    {
        public  TraitEnum Trait => TraitEnum.Sadistic;
        public bool ProcessTickAndContinue(Npc npc) => true;
    }
}
